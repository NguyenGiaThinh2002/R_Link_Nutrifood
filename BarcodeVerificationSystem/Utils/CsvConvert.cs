using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarcodeVerificationSystem.Utils
{
    internal class CsvConvert
    {
        public static void WriteStringListToCsv(List<string> list, string filePath)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    // Write header
                    //writer.WriteLine("LineCode");

                    // Write each string in the list
                    foreach (var lineCode in list)
                    {
                        // Escape any quotes in the string and wrap in quotes to handle commas or special characters
                        //writer.WriteLine($"\"{lineCode.Replace("\"", "\"\"")}\"");
                        writer.WriteLine(lineCode);

                    }
                }
                Console.WriteLine($"Successfully wrote list to {filePath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error writing to CSV file: {ex.Message}");
            }
        }

        public static List<string> ReadStringListFromCsv(string filePath)
        {
            var result = new List<string>();

            try
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        // If you later decide to handle quoted values:
                        // line = line.Trim('"').Replace("\"\"", "\"");

                        result.Add(line);
                    }
                }
                Console.WriteLine($"Successfully read list from {filePath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading CSV file: {ex.Message}");
            }

            return result;
        }
    }
}
