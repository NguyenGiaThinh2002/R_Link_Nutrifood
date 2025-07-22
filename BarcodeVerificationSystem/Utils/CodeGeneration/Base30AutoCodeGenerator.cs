using BarcodeVerificationSystem.Controller;
using BarcodeVerificationSystem.Model.CodeGeneration;
using BarcodeVerificationSystem.Utils.CodeGeneration.Helper;
using GenCode.Types;
using System;
using System.Collections.Generic;
using System.IO;

namespace GenCode.Utils
{

    /*

     n	Số Lines mỗi lần sinh mã | Dùng để tính bước nhảy và độ lệch theo dòng
     s	Giá trị bắt đầu (start)	| Cơ sở tính toán cho c, b, u
     m	Max random (ví dụ: 4 → giá trị r từ 0 đến 3) | Điều khiển độ ngẫu nhiên trong giá trị u
     r	Số random tại thời điểm hiện tại | Làm u khó đoán, tăng tính ngẫu nhiên
     j	Bước nhảy (jump step) = n × m | Khoảng nhảy lớn giữa các lần sinh
     c	Giá trị hiện tại, tăng đều mỗi lần sinh mã | Là thông số duy nhất cần lưu để sinh mã không trùng
     b	Bộ số bước nhảy: (c - s) / j | Giúp phân phối u cách đều các khoảng
     t	Số tăng phụ thuộc random và index dòng: t = n × r + i | Tăng nhỏ trong từng bước j
     u	Giá trị số nguyên cần chuyển sang base30: u = s + j × b + t	| Làm đầu vào cho encode
     i	Chỉ số Line, từ 0 đến n - 1	| Phân biệt các Line sinh cùng lượt

     */
    public class Base30AutoCodeGenerator
    {
        

      

        static StreamWriter csvWriter = new StreamWriter("log.csv", append: false);
        static HashSet<string> generatedCodes = new HashSet<string>(); // Kiểm tra trùng
        static Dictionary<int, int> currentPerLine = new Dictionary<int, int>(); // Quản lý current theo lineIndex ,Duy trì current riêng cho từng line

        public static event Action<string> OnDuplicateCode;
        public static event Action<int, double> OnGenerationCompleted;
        public static event Action<string> OnCodeGenerated;
        private static int totalCodeCount = 0;
        public static event Action<int> OnCodeCountChanged;


      
        
        public static List<string> GenerateLineCodes(
                int lineIndex = 0,      // i: line ID từ 0 đến n - 1
                int totalLines= 14,     // n: tổng số line
                int startValue = 100,     // s: giá trị bắt đầu
                int initialCurrent = 100, // c: giá trị hiện tại
                int quantity = 10  ,      // số lượng mã muốn tạo ra,
                GenCodeMode genCodeMode= GenCodeMode.Loyaltly, 
                string shiptoCode = "",
                string shipment = "",
                string lineCode ="" // Bình dương B1, B2 //Hưng yên H1 , H2
)
        {

            try
            {

                if (!currentPerLine.ContainsKey(lineIndex))
                    currentPerLine[lineIndex] = startValue;

                List<string> randomCodes = new List<string>();

                int s = startValue;
                int c = currentPerLine[lineIndex];
                // int c = initialCurrent;
                int i = lineIndex;
                int n = totalLines;

                Random rand = new Random(Guid.NewGuid().GetHashCode());

                int r = rand.Next(1, 4);  // từ 1 đến 14 theo mô tả (tránh 0 vì j=0 không hợp lệ)

                int j = n * r;             // bước nhảy cố định cho line này trong đợt sinh
                int t = n * r + i;         // bước tăng theo line index (i)

                Console.WriteLine($"[INIT] Line={i}, n={n}, r={r}, j={j}, t={t}");

                for (int k = 0; k < quantity; k++)
                {
                    int b = (c - s) / j;       // số bước nhảy đã đi
                    int u = s + (j * b) + t;   // giá trị u cuối cùng để mã hóa base30

                    string lineIDStr = i.ToString();
                    string base30code = genCodeMode == GenCodeMode.Loyaltly ? Base30Helper.EncodeToBase30_Loyaltly(u) : Base30Helper.EncodeToBase30WithChecksum_Export(u,lineIDStr);


                    string rawCode = "";
                    string focusCode = "";
                    string fullCode = "";
                   
                    if (genCodeMode == GenCodeMode.Loyaltly)
                    {
                        int factoryCodeInt = (int)FactoryCode.GiaLai;
                        string factoryCode = factoryCodeInt.ToString();
                        string currentYear = DateCodeHelper.GetCurrentYearTwoDigits();
                        string currentMonth = DateCodeHelper.GetCurrentMonthTwoDigits();
                        char monthVal = MonthCodeHelper.GetMonthCode(currentMonth);
                        char yearVal = YearCodeHelper.GetYearCode(currentYear);
                        string[] twoChar = Random2CharHelper.GetTwoRandomChars();

                        rawCode = factoryCode +
                                currentYear +
                                currentMonth +
                                monthVal +
                                yearVal +
                                base30code +
                                lineIDStr +
                                twoChar[0] +
                                twoChar[1];
                        string checksumSource = monthVal.ToString() +
                                     yearVal.ToString() +
                                     base30code +
                                     lineIDStr +
                                     twoChar[0] +
                                     twoChar[1];




                        int total;
                        char checksum = CodeConverter.GetChecksumChar(checksumSource, out total);

                        
                        focusCode = monthVal.ToString() +
                                         yearVal.ToString() +
                                         base30code +
                                         lineIDStr +
                                         twoChar[0] +
                                         twoChar[1] + checksum;

                        // Tạo mã full QR Code
                        fullCode = "https://loyalty.nuti.vn/"+ rawCode + checksum;
                    }
                    else
                    {
                           focusCode = base30code;
                           fullCode =  shiptoCode + shipment + base30code;

                    }

                    string _focusCode = Shared.Settings.IsManufacturingMode ? ManufacturingCode.GenerateCode(focusCode) : DispatchingCode.GenerateCode(focusCode);
                  
                    string allPODCode = focusCode + "," + (genCodeMode == GenCodeMode.Loyaltly ? fullCode : _focusCode);


                    randomCodes.Add(allPODCode);

                    if (!generatedCodes.Add(fullCode))
                    {
                        Console.WriteLine($"⚠️ Trùng mã: {fullCode}");
                        OnDuplicateCode?.Invoke(fullCode); // báo trùng
                    }
                    else
                    {
                        OnCodeGenerated?.Invoke(fullCode); // báo mã mới               
                        totalCodeCount++;
                        OnCodeCountChanged?.Invoke(totalCodeCount);
                    }

                    Console.WriteLine($"Line index: {lineIDStr}, c: {c}, b: {b}, u: {u}, base30: {base30code}, full Code: {fullCode}");
                    // Ghi dòng dữ liệu vào CSV
                    csvWriter.WriteLine($"Line index: {lineIDStr}, c: {c}, b: {b}, u: {u}, base30: {base30code}, full Code: {fullCode}");
                    c = u;
                }
                currentPerLine[lineIndex] = c; // cập nhật lại current
                csvWriter.Flush();
                csvWriter.Close();
                Console.WriteLine($"Tong so code : {totalCodeCount}");
                    // TODO: Save lại `c` cho line này nếu cần
                return randomCodes;
            }
            catch (Exception)
            {
                return new List<string>();
            }
        }



        public static void RunBulkGenerationTest(int totalCodes = 729000, 
            int codesPerBatch = 1000,
            int totalLines = 14, 
            int startValue = 100,
            int current = 100)
        {
            int codeGenerated = 0;
            int batch = 0;
            var stopwatch = System.Diagnostics.Stopwatch.StartNew();

            while (codeGenerated < totalCodes)
            {
                int remaining = totalCodes - codeGenerated;
                int quantity = Math.Min(codesPerBatch, remaining);

                Console.WriteLine($"[Batch {batch++}] Generating {quantity} codes...");

                int quantitySoFar = 0;

                for (int lineIndex = 0; lineIndex < totalLines; lineIndex++)
                {
                    int quantityPerLine = quantity / totalLines;

                    // ⚠ Phân bổ số dư cho các line đầu
                    if (lineIndex < quantity % totalLines)
                        quantityPerLine++;

                    // ❌ Bỏ qua line nếu không có gì để sinh
                    if (quantityPerLine <= 0)
                        continue;

                    GenerateLineCodes(lineIndex, totalLines, startValue, current, quantityPerLine);

                    current += quantityPerLine;
                    quantitySoFar += quantityPerLine;
                }

                codeGenerated += quantitySoFar;

                // ⚠ Nếu chẳng có mã nào sinh ra (quantitySoFar == 0), dừng để tránh lặp vô hạn
                if (quantitySoFar == 0)
                {
                    Console.WriteLine("⚠ Không còn mã nào được sinh ra. Thoát vòng lặp.");
                    break;
                }
            }

            stopwatch.Stop();
            Console.WriteLine($"✅ Done generating {codeGenerated} codes in {stopwatch.Elapsed.TotalSeconds:F2} seconds.");

            csvWriter.Flush();
            csvWriter.Close();
            OnGenerationCompleted?.Invoke(codeGenerated, stopwatch.Elapsed.TotalSeconds);
        }

    }
}
