using BarcodeVerificationSystem.Controller;
using BarcodeVerificationSystem.Model;
using CommonVariable;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarcodeVerificationSystem.Utils
{
    internal class SyncDataList
    {
        public int STT { get; set; }
        public string MaCongViec { get; set; }
        public string MaPhieuSoanHang { get; set; }
        public string MaSanPham { get; set; }
        public int SoLuongCanXuat { get; set; }
        public int SoLuongDongBoSaaS { get; set; }
        public int SoLuongDongBoSAP { get; set; }
        public bool Hoanthanh { get; set; }

        public static List<SyncDataList> ReturnSyncDataList(List<string> _JobNameList)
        {
            try
            {
                List<SyncDataList> rows = new List<SyncDataList>();
                foreach (var x in _JobNameList)
                {
                    JobModel CurrentJob = Shared.GetJob(x);
                    var payload = CurrentJob.DispatchingOrderPayload.payload;

                    rows.Add(new SyncDataList
                    {
                        STT = 1,
                        MaCongViec = x,
                        MaPhieuSoanHang = payload?.wms_number,
                        MaSanPham = (payload?.items != null
                                                     && CurrentJob.SelectedMaterialIndex >= 0
                                                     && CurrentJob.SelectedMaterialIndex < payload.items.Count)
                                                    ? payload.items[CurrentJob.SelectedMaterialIndex]?.material_number
                                                    : "null",
                        SoLuongCanXuat = CurrentJob.NumberOfPrintedCodes,
                        SoLuongDongBoSaaS = CurrentJob.NumberOfSaaSSentCodes,
                        SoLuongDongBoSAP = CurrentJob.NumberOfSAPSentCodes,
                        Hoanthanh = CurrentJob.NumberOfPrintedCodes == CurrentJob.NumberOfSAPSentCodes
                    });
                }

                return rows;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex);
            }
            return null;
            
        }
    }
}
