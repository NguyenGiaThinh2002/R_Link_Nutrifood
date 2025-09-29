using BarcodeVerificationSystem.Modules.ReliableDataSender.Models;
using BarcodeVerificationSystem.View.CustomDialogs;
using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;


namespace BarcodeVerificationSystem.Utils
{
    public static class FileHelper
    {
        private static readonly object _fileLock = new object();

        public static void UpdatePrintingEntry(string filePath, StorageUpdate storageUpdate,
                                       string status)
        {
            lock (_fileLock)
            {
                var lines = File.ReadAllLines(filePath).ToList();

                if (storageUpdate.Id < 1 || storageUpdate.Id > lines.Count)
                    throw new ArgumentOutOfRangeException(nameof(storageUpdate.Id));

                var parts = lines[storageUpdate.Id - 1].Split(',');

                lines[storageUpdate.Id - 1] =
                    $"{parts[0]},{parts[1]},{parts[2]},{storageUpdate.PrintedDate},{storageUpdate.SaaSStatus}" +
                    $",{storageUpdate.SAPStatus},{storageUpdate.SaaSError},{storageUpdate.SAPError},{status}";

                string tempFile = filePath + ".tmp";

                // Write to temp file first
                File.WriteAllLines(tempFile, lines, Encoding.UTF8);

                // Atomically replace the original file
                File.Replace(tempFile, filePath, null);
            }
        }

        public static void AppendPrintingEntry(string filePath, PrintingDataEntry entry, string unsentStatus)
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

        //public static void UpdateVerifyingEntry(string filePath, StorageUpdate storageUpdate, string status)
        //{
        //    const int maxRetries = 3;
        //    const int delayMs = 200;

        //    for (int attempt = 1; attempt <= maxRetries; attempt++)
        //    {
        //        var lines = File.ReadAllLines(filePath).ToList();

        //        if (storageUpdate.Id < 1 || storageUpdate.Id > lines.Count)
        //            return;

        //        var parts = lines[storageUpdate.Id - 1].Split(',');

        //        if (storageUpdate.Id - 1 != int.Parse(parts[0]))
        //        {
        //            CustomMessageBox.Show("Lỗi dữ liệu đồng bộ kiểm tra bị sai Index", "Lỗi Index",
        //                    System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
        //            throw new ArgumentOutOfRangeException(nameof(storageUpdate.Id));
        //        }


        //        lines[storageUpdate.Id - 1] =
        //            $"{parts[0]},{parts[1]},{storageUpdate.VerifiedStatus},{storageUpdate.VerifiedDate}" +
        //            $",{storageUpdate.SaaSStatus},{storageUpdate.SAPStatus},{storageUpdate.SaaSError},{storageUpdate.SAPError},{status}";

        //        string tempFile = filePath + ".tmp";

        //        File.WriteAllLines(tempFile, lines, Encoding.UTF8);

        //        File.Replace(tempFile, filePath, null);

        //        return; // ✅ success, exit method
        //        //try
        //        //{

        //        //}
        //        //catch (IOException)
        //        //{
        //        //}
        //    }
        //}

        public static void UpdateVerifyingEntry(string filePath, StorageUpdate storageUpdate,
                               string status)
        {
            var lines = File.ReadAllLines(filePath).ToList();

            if (storageUpdate.Id < 1 || storageUpdate.Id > lines.Count)
                throw new ArgumentOutOfRangeException(nameof(storageUpdate.Id));


            var parts = lines[storageUpdate.Id - 1].Split(',');

            //if (storageUpdate.Id - 1 != int.Parse(parts[0]))
            //{
            //    CustomMessageBox.Show("Lỗi dữ liệu đồng bộ kiểm tra bị sai Index", "Lỗi Index",
            //            System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            //    throw new ArgumentOutOfRangeException(nameof(storageUpdate.Id));
            //}

            lines[storageUpdate.Id - 1] =
                $"{parts[0]},{parts[1]},{storageUpdate.VerifiedStatus},{storageUpdate.VerifiedDate}" +
                $",{storageUpdate.SaaSStatus},{storageUpdate.SAPStatus},{storageUpdate.SaaSError},{storageUpdate.SAPError},{status}";

            string tempFile = filePath + ".tmp";

            // Write to temp file first
            File.WriteAllLines(tempFile, lines, Encoding.UTF8);

            // Atomically replace the original file
            File.Replace(tempFile, filePath, null);
        }

    }
}
