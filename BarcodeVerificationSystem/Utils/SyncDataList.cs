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

        public static List<SyncDataList> ReturnSyncDataList(List<string> _JobNameList)
        {
            //string folderPath = CommVariables.PathJobsApp;
            //if (!Directory.Exists(folderPath))
            //{
            //    Directory.CreateDirectory(folderPath);
            //}

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
                    MaSanPham = payload?.item[CurrentJob.SelectedMaterialIndex].material_number,
                    SoLuongCanXuat = CurrentJob.NumberOfNeededSentCodes,
                    SoLuongDongBoSaaS = CurrentJob.NumberOfSaaSSentCodes,
                    SoLuongDongBoSAP = CurrentJob.NumberOfSAPSentCodes
                });
            }

            return rows;
        }
        public static List<SyncDataList> ReturnSyncDataListOld(List<string> _JobNameList)
        {

            List<SyncDataList> rows = new List<SyncDataList>();
            foreach (var x in _JobNameList)
            {
                rows.Add(new SyncDataList
                {
                    STT = 1,
                    MaCongViec = x,
                    MaPhieuSoanHang = "...",
                    MaSanPham = "...",
                    SoLuongCanXuat = 0,
                    SoLuongDongBoSaaS = 0,
                    SoLuongDongBoSAP = 5
                });
            }

            return rows;
        }
    }
}
