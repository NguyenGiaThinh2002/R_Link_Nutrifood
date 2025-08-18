using BarcodeVerificationSystem.Controller;
using BarcodeVerificationSystem.Controller.NutrifoodController.DispatchingController;
using BarcodeVerificationSystem.Model.CodeGeneration;
using BarcodeVerificationSystem.Modules.ReliableDataSender.Interfaces;
using BarcodeVerificationSystem.Modules.ReliableDataSender.Models;
using BarcodeVerificationSystem.Utils;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;


namespace BarcodeVerificationSystem.Modules.ReliableDataSender.Services
{
    public class PrintingStorageService : IStorageService<PrintingDataEntry>
    {
        private readonly string _filePath;
        private readonly object _fileLock = new object();
        private readonly string _unsentStatus = "NotSent";
        private readonly string _sentStatus = "Sent";

        private readonly string _databasePath;

        public PrintingStorageService(string filePath, string databasePath)
        {
            _filePath = filePath;
            _databasePath = databasePath;
            if (!File.Exists(_filePath))
            {
                File.Create(_filePath).Dispose(); // Dispose to release the handle immediately
                InitializeDefaultDatabaseFormat();
            }

        }

        public void InitializeDefaultDatabaseFormat()
        {
            try
            {
                lock (_fileLock)
                {
                    var lines = File.ReadAllLines(_databasePath).ToList();
                    var newLines = new List<string>();

                    for (int i = 0; i < lines.Count; i++)
                    {
                        var parts = lines[i].Split(',');
                        var newLine = $"{i + 1},{parts[0]},{parts[1]},,,,,,";
                        newLines.Add(newLine);
                    }

                    File.WriteAllLines(_filePath, newLines, Encoding.UTF8);
                }
            }
            catch (System.Exception ex)
            {
                ProjectLogger.WriteError("Error occurred in InitializeDefaultDatabaseFormat" + ex.Message);
            }
           
        }


        public void AppendEntry(PrintingDataEntry entry)
        {
            try
            {
                lock (_fileLock)
                {
                    var lines = File.ReadAllLines(_filePath).ToList();

                    // This will throw if entryId is out of range
                    var parts = lines[entry.Id - 1].Split(',');

                    // Blindly replace the line like MarkAsSent
                    lines[entry.Id - 1] = $"{entry.Id},{entry.Code},{entry.UniqueCode},{entry.PrintedDate},,,,,{_unsentStatus}";

                    File.WriteAllLines(_filePath, lines, Encoding.UTF8);
                }
            }
            catch (System.Exception ex)
            {
                ProjectLogger.WriteError("Error occurred in InitializeDefaultDatabaseFormat" + ex.Message);
            }
        }

        public List<PrintingDataEntry> LoadUnsentEntries()
        {
            try
            {
                lock (_fileLock)
                {

                    return File.ReadAllLines(_filePath)
                    .Select((line, index) =>
                    {
                        var parts = line.Split(',');
                        return new PrintingDataEntry
                        {
                            Id = int.Parse(parts[DispatchingSharedValues.Index]), // parts[0]}
                            Code = parts[DispatchingSharedValues.QrCodeIndex], // parts[1]
                            UniqueCode = parts[DispatchingSharedValues.UniqueCode],
                            PrintedDate = parts[DispatchingSharedValues.PrintedDate],
                            SaasStatus = parts[DispatchingSharedValues.SaaSStatus],
                            SAPStatus = parts[DispatchingSharedValues.SAPStatus],
                            SaasError = parts[DispatchingSharedValues.SaaSError],
                            SAPError = parts[DispatchingSharedValues.SAPError],
                            Status = parts[DispatchingSharedValues.SentStatus],
                        };
                    })
                    .Where(e => e.Status == _unsentStatus)
                    .ToList();
                }
            }
            catch (System.Exception ex)
            {
                ProjectLogger.WriteError("Error occurred in LoadUnsentEntries" + ex.Message);
                return default;
            }
 
        }
        public void MarkAsFailed(int entryId, string PrintedDate, string SaasStatus, string SAPStatus, string SaasSError, string SAPError)
        {
            try
            {
                lock (_fileLock)
                {
                    var lines = File.ReadAllLines(_filePath).ToList();

                    // This will throw if entryId is out of range
                    var parts = lines[entryId - 1].Split(',');

                    // Blindly replace the line like MarkAsSent
                    lines[entryId - 1] = $"{parts[0]},{parts[1]},{parts[2]},{PrintedDate},{SaasStatus},{SAPStatus},{SaasSError},{SAPError},{_unsentStatus}";

                    File.WriteAllLines(_filePath, lines, Encoding.UTF8);
                }
            }
            catch (System.Exception ex)
            {
                ProjectLogger.WriteError("Error occurred in MarkAsFailed" + ex.Message);
            }
        }


        public void MarkAsSent(int entryId, string PrintedDate, string SaasStatus, string SAPStatus, string SaasSError, string SAPError)
        {
            try
            {
                lock (_fileLock)
                {
                    var lines = File.ReadAllLines(_filePath).ToList();

                    // This will throw if entryId is out of range
                    var parts = lines[entryId - 1].Split(',');

                    // Blindly replace the line
                    lines[entryId - 1] = $"{parts[0]},{parts[1]},{parts[2]},{PrintedDate},{SaasStatus},{SAPStatus},{SaasSError},{SAPError},{_sentStatus}";

                    File.WriteAllLines(_filePath, lines, Encoding.UTF8);
                }
            }
            catch (System.Exception ex)
            {
                ProjectLogger.WriteError("Error occurred in MarkAsSent" + ex.Message);
            }
           
        }



    }

}


//public void MarkAsSent(int entryId, string SaasStatus, string ServerStatus, string SaasSError, string ServerError)
//{
//    lock (_fileLock)
//    {
//        var lines = File.ReadAllLines(_filePath).ToList();
//        for (int i = 0; i < lines.Count; i++) // int = 1
//        {
//            var parts = lines[i].Split(',');
//            if (int.Parse(parts[0]) == entryId)
//            {
//                //MessageBox.Show($"Line index = {i}, parts[0] = {parts[0]}, entryId = {entryId}");
//                lines[i] = $"{parts[0]},{parts[1]},{parts[2]},{SaasStatus},{ServerStatus},{SaasSError},{ServerError},{_sentStatus}";
//                break;
//            }
//        }
//        File.WriteAllLines(_filePath, lines, Encoding.UTF8);
//    }
//}

//public void MarkAsFailed(int entryId, string SaasStatus, string ServerStatus, string SaasSError, string ServerError)
//{
//    lock (_fileLock)
//    {
//        var lines = File.ReadAllLines(_filePath).ToList();
//        for (int i = 0; i < lines.Count; i++) // int = 1
//        {
//            var parts = lines[i].Split(',');
//            if (int.Parse(parts[0]) == entryId)
//            {
//                //lines[i] = $"{parts[0]},{parts[1]},{parts[2]},{parts[3]},Sent";
//                lines[i] = $"{parts[0]},{parts[1]},{parts[2]},{SaasStatus},{ServerStatus},{SaasSError},{ServerError},{_unsentStatus}";
//                break;
//            }
//        }
//        File.WriteAllLines(_filePath, lines, Encoding.UTF8);
//    }
//}



//if (!File.Exists(_filePath))
//{
//    File.WriteAllText(_filePath, "Id,Code,Status\n");
//}

//public void AppendEntry(VerificationEntry entry)
//{
//    lock (_fileLock)
//    {
//        var existsAndSent = File.ReadAllLines(_filePath)
//            .Skip(1)
//            .Any(l => l.StartsWith($"{entry.Id},") && l.EndsWith("Sent"));

//        if (existsAndSent)
//            return;

//        var entryLine = $"{entry.Id},{entry.Code},{entry.Status}";
//        File.AppendAllLines(_filePath, new[] { entryLine }, Encoding.UTF8);
//    }
//}