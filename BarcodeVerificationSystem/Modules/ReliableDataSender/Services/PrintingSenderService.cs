﻿using BarcodeVerificationSystem.Controller;
using BarcodeVerificationSystem.Model.Payload.DispatchingPayload.Request;
using BarcodeVerificationSystem.Modules.ReliableDataSender.Interfaces;
using BarcodeVerificationSystem.Modules.ReliableDataSender.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Concurrent;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using BarcodeVerificationSystem.View;
using BarcodeVerificationSystem.Model.Payload.DispatchingPayload;
using BarcodeVerificationSystem.Model.Payload.ManufacturingPayload;
using System.Windows;
using BarcodeVerificationSystem.Model;
using CommonVariable;
using BarcodeVerificationSystem.Model.Apis.Dispatching;
using BarcodeVerificationSystem.Services;
using BarcodeVerificationSystem.Utils;
using BarcodeVerificationSystem.Model.Payload.DispatchingPayload.Response;
using Org.BouncyCastle.Asn1.Ocsp;
using System.Windows.Forms;

namespace BarcodeVerificationSystem.Modules.ReliableDataSender.Services
{
    public class PrintingSenderService : ISenderService<PrintingDataEntry>
    {
        private readonly BlockingCollection<PrintingDataEntry> _queue;
        private readonly IStorageService<PrintingDataEntry> _storageService;
        private readonly CancellationTokenSource _cts = new CancellationTokenSource();
        private readonly ApiService apiService = new ApiService();
        private readonly string _endpoint;

        public PrintingSenderService(BlockingCollection<PrintingDataEntry> queue, IStorageService<PrintingDataEntry> storageService, string endpoint)
        {
            _queue = queue;
            _storageService = storageService;
            _endpoint = endpoint;
        }

        public void Start()
        {
            try
            {
                Task.Run(async () =>
                {
                    foreach (var entry in _queue.GetConsumingEnumerable(_cts.Token))
                    {
                        _ = ProcessEntryAsync(entry); // fire-and-forget task
                        await Task.Delay(100); // optional small delay to avoid CPU spike
                    }
                }, _cts.Token);
            }
            catch (Exception ex)
            {
                ProjectLogger.WriteError("Error occurred in Start PrintingSenderService: " + ex.Message);
            }
         
        }

        private async Task ProcessEntryAsync(PrintingDataEntry entry)
        {
            var storageUpdate = new StorageUpdate();

            try
            {

                var printedContent = new object();

                bool isManuMode = Shared.Settings.IsManufacturingMode;

                if ((Shared.PrintMode.IsPrintingMode || Shared.PrintMode.IsPrintingModeOffline) && !isManuMode)
                {
                    printedContent = new RequestPrinted
                    {
                        index_qr_code = entry.Id,
                        qr_code = entry.Code,
                        unique_code = entry.UniqueCode, // entry.HumanCode
                        printed_date = DateTime.Parse(entry.PrintedDate),
                        shipto_name = Shared.CurrentJob.DispatchingOrderPayload.payload.shipto_name,  // 
                        shipto_code = Shared.CurrentJob.DispatchingOrderPayload.payload.shipto_code, // 
                        resource_code = Shared.Settings.LineId,
                        resource_name = Shared.Settings.LineName,
                    };
                }

                if(Shared.PrintMode.IsReprintMode && !isManuMode)
                {
                    printedContent = new RequestRePrint
                    {
                        qr_code = entry.Code,
                        unique_code = entry.UniqueCode, // entry.HumanCode
                        scan_date = DateTime.Parse(entry.PrintedDate),

                    };
                }

                if (isManuMode && Shared.CurrentJob.IsProcessOrderMode)
                {
                    var PO = Shared.CurrentJob.ProcessOrderItem;

                    printedContent = new Model.Payload.ManufacturingPayload.Request.RequestPrinted
                    {
                        index_qr_code = entry.Id,
                        qr_code = entry.Code,
                        unique_code = entry.UniqueCode, // entry.HumanCode
                        printed_date = DateTime.Parse(entry.PrintedDate),
                        process_order = PO.process_order,
                        material_number = PO.material_number,
                        print_type = "process_order",
                        batch = PO.batch_info[Shared.Settings.SelectedBatchIndex].batch, // Shared.CurrentJob.SelectedBatchIndex
                        mauf_date = PO.batch_info[Shared.Settings.SelectedBatchIndex].mauf_date,
                        expired_date = PO.batch_info[Shared.Settings.SelectedBatchIndex].expired_date,
                    }; 
                }
              
                if (isManuMode && Shared.CurrentJob.IsReservationMode)
                {
                    var Material = Shared.CurrentJob.ReservationItem;

                    printedContent = new Model.Payload.ManufacturingPayload.Request.RequestPrinted
                    {
                        index_qr_code = entry.Id,
                        qr_code = entry.Code,
                        unique_code = entry.UniqueCode, // entry.HumanCode
                        printed_date = DateTime.Parse(entry.PrintedDate),
                        material_number = Material.material_number,
                        material_doc = Shared.CurrentJob.Reservation.material_doc,
                        print_type = "reservation",
                        batch = Material.batch,
                        mauf_date = Material.mauf_date,
                        expired_date = Material.expried_date
                    };
                }

                if (Shared.UserPermission.isOnline)
                {
                    var ResponsePrinted = await apiService.PostApiDataAsync<ResponsePrinted>(_endpoint, printedContent);

                    entry.SaaSStatus = ResponsePrinted.is_success ? "success" : "failed";
                    entry.SAPStatus = ResponsePrinted.is_success_sap ? "success" : "failed";
                    entry.SaasError = ResponsePrinted.message ?? string.Empty;
                    entry.SAPError = ResponsePrinted.message_sap ?? string.Empty;

                    var syncDataModel = new SyncDataParams(SyncDataParams.SyncDataType.SentData, entry.Id){};

                    if (ResponsePrinted.is_success)
                    {
                        Shared.CurrentJob.NumberOfSaaSSentCodes++;
                        Shared.CurrentJob.SaveFile(); // Có thể không save ở đây nhưng khi đọc job phải đọc file lên và đếm lại.
                        syncDataModel.DataType = SyncDataParams.SyncDataType.SaaSSuccess;
                        Shared.RaiseOnSyncDataParameterChangeEvent(syncDataModel);
                    }
                    if (ResponsePrinted.is_success_sap)
                    {
                        Shared.CurrentJob.NumberOfSAPSentCodes++;
                        Shared.CurrentJob.SaveFile();
                        syncDataModel.DataType = SyncDataParams.SyncDataType.SAPSuccess;
                        Shared.RaiseOnSyncDataParameterChangeEvent(syncDataModel);
                    }

                    storageUpdate = new StorageUpdate()
                    {
                        Id = entry.Id,
                        SaaSStatus = entry.SaaSStatus,
                        SAPStatus = entry.SAPStatus,
                        SaaSError = entry.SaasError,
                        SAPError = entry.SAPError,
                        PrintedDate = entry.PrintedDate
                    };

                    if (ResponsePrinted.is_success && ResponsePrinted.is_success_sap) // nho chinh khuc nay
                    {
                        _storageService.MarkAsSent(storageUpdate);
                    }
                    else
                    {
                        _storageService.MarkAsFailed(storageUpdate);
                        _queue.Add(entry);
                    }

                    if (!ResponsePrinted.is_success_sap)
                    {
                        ProjectLogger.WriteError($"Error occurred in {_endpoint}): " + entry.PrintedDate + entry.SaaSStatus + entry.SAPStatus + entry.SaasError + entry.SAPError);
                    }
                }
                else
                {
                    _storageService.MarkAsFailed(storageUpdate);
                }

            }
            catch (Exception ex)
            {
                storageUpdate = new StorageUpdate()
                {
                    Id = entry.Id,
                    SaaSStatus = "failed",
                    SAPStatus = entry.SAPStatus,
                    SaaSError = ex.Message,
                    SAPError = entry.SAPError,
                    PrintedDate = entry.PrintedDate
                };

                ProjectLogger.WriteError($"Error occurred in {_endpoint}): " + entry.PrintedDate + entry.SaaSStatus + entry.SAPStatus + entry.SaasError + entry.SAPError + ex.Message);
                //_storageService.AppendEntry(entry);
                _storageService.MarkAsFailed(storageUpdate);
                _queue.Add(entry);
            }
        }

        public void Stop()
        {
            //_httpClient.Dispose();
            _cts.Cancel();
            _queue.CompleteAdding();
        }

    }

}
