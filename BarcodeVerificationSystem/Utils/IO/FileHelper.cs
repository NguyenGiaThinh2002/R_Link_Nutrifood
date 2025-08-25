using BarcodeVerificationSystem.Modules.ReliableDataSender.Models;
using System;
using System.IO;
using System.Linq;
using System.Text;


namespace BarcodeVerificationSystem.Utils
{
    public static class FileHelper
    {
        private static readonly object _fileLock = new object();

        public static void UpdateEntry(string filePath, int entryId, string PrintedDate,
                                       string SaasStatus, string SAPStatus,
                                       string SaasSError, string SAPError,
                                       string status)
        {
            lock (_fileLock)
            {
                var lines = File.ReadAllLines(filePath).ToList();

                if (entryId < 1 || entryId > lines.Count)
                    throw new ArgumentOutOfRangeException(nameof(entryId));

                var parts = lines[entryId - 1].Split(',');

                lines[entryId - 1] =
                    $"{parts[0]},{parts[1]},{parts[2]},{PrintedDate},{SaasStatus},{SAPStatus},{SaasSError},{SAPError},{status}";

                string tempFile = filePath + ".tmp";

                // Write to temp file first
                File.WriteAllLines(tempFile, lines, Encoding.UTF8);

                // Atomically replace the original file
                File.Replace(tempFile, filePath, null);
            }
        }

        public static void AppendEntry(string filePath, PrintingDataEntry entry, string unsentStatus)
        {
            lock (_fileLock)
            {
                var lines = File.ReadAllLines(filePath).ToList();

                if (entry.Id < 1 || entry.Id > lines.Count)
                    throw new ArgumentOutOfRangeException(nameof(entry.Id));

                lines[entry.Id - 1] =
                    $"{entry.Id},{entry.Code},{entry.UniqueCode},{entry.PrintedDate},,,,,{unsentStatus}";

                string tempFile = filePath + ".tmp";

                // Write to temp file first
                File.WriteAllLines(tempFile, lines, Encoding.UTF8);

                // Replace atomically
                File.Replace(tempFile, filePath, null);
            }
        }

    }
}
