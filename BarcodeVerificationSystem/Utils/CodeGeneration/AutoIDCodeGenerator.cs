using GenCode.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarcodeVerificationSystem.Utils.CodeGeneration.Helper
{
    internal class AutoIDCodeGenerator
    {
        static Dictionary<string, int> autoIdPerMonth = new Dictionary<string, int>();
        private const string AutoIdStatePath = "autoid_state.json";


        public static void SaveAutoIdState(string path = AutoIdStatePath)
        {
            File.WriteAllText(path, JsonConvert.SerializeObject(autoIdPerMonth));
        }

        public static void LoadAutoIdState(string path = AutoIdStatePath)
        {
            if (File.Exists(path))
                autoIdPerMonth = JsonConvert.DeserializeObject<Dictionary<string, int>>(File.ReadAllText(path));
            else
                autoIdPerMonth = new Dictionary<string, int>();
        }


     

        /// <summary>
        /// Auto gen code tracking by autoid , with line Number (1-n)
        /// Test :  1000000 / 283 ms
        /// </summary>
        /// <param name="lineNo"></param>
        /// <param name="quantity"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="Exception"></exception>
        public static List<string> GenerateCodesWithAutoID(int lineNo = 1, int quantity=1)
        {
         
           LoadAutoIdState(); // Load old key when start new sesion gen
            if (quantity <= 0)
                throw new ArgumentException("Quantity must be > 0");

           
          //  Stopwatch sw = Stopwatch.StartNew();

            // 1. Get the current + month code
            string currentYear = DateCodeHelper.GetCurrentYearTwoDigits();
            string currentMonth = DateCodeHelper.GetCurrentMonthTwoDigits();
            char yearCode = YearCodeHelper.GetYearCode(currentYear);
            char monthCode = MonthCodeHelper.GetMonthCode(currentMonth);
            char lineCode = LineConvertHelper.GetLineCode(lineNo); // 

            // 2. The only lock over time and line
            string key = $"{yearCode}-{monthCode}-{lineCode}";

            // 3. Get the current Autoid
            if (!autoIdPerMonth.ContainsKey(key))
                autoIdPerMonth[key] = 0;

            int currentAutoId = autoIdPerMonth[key];

            // 4.Check the limit
            if (currentAutoId + quantity > 10_000_000)
                throw new Exception("Exceeding the limit of 10 million codes in the month for this line");

            // 5. Born a code list
            List<string> codes = new List<string>();
            for (int i = 0; i < quantity; i++)
            {
                int id = currentAutoId + i;
                string autoIdStr = id.ToString("D7");
                string code = $"{yearCode}{monthCode}{autoIdStr}{lineCode}";
                codes.Add(code);
            }

            // 6. Update Autoid after birth
            autoIdPerMonth[key] = currentAutoId + quantity;

            SaveAutoIdState(); // Save latest key
            //sw.Stop();
            //Console.WriteLine($"✅ Đã sinh {quantity} mã trong {sw.ElapsedMilliseconds} ms");

            return codes;
        }
    }
}
