using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenCode.Utils
{
    public static class DateCodeHelper
    {
        // Lấy 2 ký tự cuối của năm hiện tại, ví dụ: "24"
        public static string GetCurrentYearTwoDigits()
        {
            return DateTime.Now.ToString("yy");
        }

        // Lấy tháng hiện tại với định dạng 2 ký tự, ví dụ: "07"
        public static string GetCurrentMonthTwoDigits()
        {
            return DateTime.Now.ToString("MM");
        }
    }

}
