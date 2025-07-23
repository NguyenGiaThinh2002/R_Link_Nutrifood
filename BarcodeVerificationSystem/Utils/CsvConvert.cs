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
    }
}
