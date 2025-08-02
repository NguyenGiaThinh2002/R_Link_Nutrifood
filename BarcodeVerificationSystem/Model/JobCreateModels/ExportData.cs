using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarcodeVerificationSystem.Model.JobCreateModels
{
    public class ExportData
    {
        public int STT { get; set; }
        public string MaCongViec { get; set; }
        public string MaPhieuSoanHang { get; set; }
        public string MaSanPham { get; set; }
        public int SoLuongCanXuat { get; set; }
        public int SoLuongDongBoSaaS { get; set; }
        public int SoLuongDongBoSAP { get; set; }

        public static List<ExportData> ReturnSampleData(List<string> _JobNameList)
        {

            List<ExportData> rows = new List<ExportData>();
            foreach (var x in _JobNameList)
            {
                rows.Add(new ExportData
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
