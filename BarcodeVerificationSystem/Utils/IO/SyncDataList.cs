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
                    try
                    {
                        JobModel CurrentJob = Shared.GetJob(x);
                        var payload = CurrentJob.DispatchingOrderPayload.payload;
                        string sentDataPath = CommVariables.PathSentDataPrinted + CurrentJob.PrintedResponePath;
                        var _SentPrintedCodeObtainFromFile = ReadPrintedCodeData(sentDataPath);

                        CurrentJob.NumberOfSAPSentCodes =
                        _SentPrintedCodeObtainFromFile.Count(item => item.Length > 5 &&
                                        item[5].Equals("success", StringComparison.OrdinalIgnoreCase));


                        CurrentJob.NumberOfSaaSSentCodes =
                        _SentPrintedCodeObtainFromFile.Count(item => item.Length > 4 &&
                                                              item[4].Equals("success", StringComparison.OrdinalIgnoreCase));

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
                    catch (Exception)
                    {
                    }
                 
                }

                return rows;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex);
            }
            return null;
            
        }

        public static List<string[]> ReadPrintedCodeData(string fullFilePath, char delimiter = ',')
        {
            var result = new List<string[]>();

            if (string.IsNullOrWhiteSpace(fullFilePath) || !File.Exists(fullFilePath))
                return result;

            try
            {
                using (var fs = new FileStream(
                    fullFilePath,
                    FileMode.Open,
                    FileAccess.Read,
                    FileShare.ReadWrite)) // 👈 allow other readers and writers
                using (var sr = new StreamReader(fs))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        if (!string.IsNullOrWhiteSpace(line))
                        {
                            var values = line.Split(delimiter);
                            result.Add(values);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading file at {fullFilePath}: {ex.Message}");
            }

            return result;
        }


    }
}
