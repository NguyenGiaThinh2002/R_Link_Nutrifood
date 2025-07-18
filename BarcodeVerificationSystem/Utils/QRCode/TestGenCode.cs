using GenCode.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarcodeVerificationSystem.Utils.QRCode
{
    public class TestGenCode
    {
        public static void StartGen(int quantity = 100, int totalLine = 14, int startValue = 100)
        {
            Base30AutoCodeGenerator.OnDuplicateCode += (code) =>
            {
              // Phát hiện trùng
            };

            Base30AutoCodeGenerator.OnGenerationCompleted += (count, seconds) =>
            {
               // Hoàn thành
            };
            Base30AutoCodeGenerator.OnCodeGenerated += (code) =>
            {
               // Code đang gen
            };
            //OnCodeGenerated
            Base30AutoCodeGenerator.OnCodeCountChanged += (count) =>
            {
               // Đếm lên
            };

            // Bắt đầu sinh mã
            Task.Run(() =>
            {
                Base30AutoCodeGenerator.RunBulkGenerationTest(
                totalCodes: quantity,
                totalLines: totalLine,
                startValue: startValue,
                current: startValue);
            });

        }
    }
}
