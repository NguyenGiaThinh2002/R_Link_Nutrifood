using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BarcodeVerificationSystem.Modules.ReliableDataSender.Models;
using BarcodeVerificationSystem.Modules.ReliableDataSender.Interfaces;
using BarcodeVerificationSystem.Controller;
using BarcodeVerificationSystem.Model.CodeGeneration;


namespace BarcodeVerificationSystem.Modules.ReliableDataSender.Services
{
    public class PrintingStorageService : IStorageService<PrintingDataEntry>
    {
        private readonly string _filePath;
        private readonly object _fileLock = new object();
        private readonly string _unsentStatus = "NotSent";
        private readonly string _sentStatus = "Sent";


        public PrintingStorageService(string filePath)
        {
            _filePath = filePath;
            if (!File.Exists(_filePath))
            {
                File.Create(_filePath).Dispose(); // Dispose to release the handle immediately
            }

        }

        public void AppendEntry(PrintingDataEntry entry)
        {
            lock (_fileLock)
            {
                var entryLine = $"{entry.Id},{entry.Code},{entry.PrintedDate},{entry.SaasStatus}.{entry.ServerStatus},{entry.SaasError},{entry.ServerError},{entry.Status}";
                File.AppendAllLines(_filePath, new[] { entryLine }, Encoding.UTF8);
            }
        }

        public List<PrintingDataEntry> LoadUnsentEntries()
        {
            lock (_fileLock)
            {

                return File.ReadAllLines(_filePath)
                    .Select((line, index) =>
                    {
                        var parts = line.Split(',');
                        return new PrintingDataEntry
                        {
                            Id = int.Parse(parts[0]),
                            Code = parts[1],
                            HumanCode = Shared.Settings.IsManufacturingMode ? Manufacturing.GetHumanReadableCode(parts[1]) : Dispatching.GetHumanReadableCode(parts[1]),
                            PrintedDate = parts[2],
                            PrintedStatus = parts[3],
                            SaasStatus = parts.Length > 4 ? parts[4] : null,
                            ServerStatus = parts.Length > 5 ? parts[5] : null,
                            SaasError = parts.Length > 6 ? parts[6] : null,
                            ServerError = parts.Length > 7 ? parts[7] : null,
                            Status = parts[parts.Length-1]
                        };
                    })
                    .Where(e => e.Status == _unsentStatus)
                    .ToList();
            }
        }

        public void MarkAsSent(int entryId, string SaasStatus, string ServerStatus, string SaasSError, string ServerError)
        {
            lock (_fileLock)
            {
                var lines = File.ReadAllLines(_filePath).ToList();
                for (int i = 0; i < lines.Count; i++) // int = 1
                {
                    var parts = lines[i].Split(',');
                    if (int.Parse(parts[0]) == entryId)
                    {
                        //lines[i] = $"{parts[0]},{parts[1]},{parts[2]},{parts[3]},Sent";
                        lines[i] = $"{parts[0]},{parts[1]},{parts[2]},{SaasStatus},{ServerStatus},{SaasSError},{ServerError},{_sentStatus}";
                        break;
                    }
                }
                File.WriteAllLines(_filePath, lines, Encoding.UTF8);
            }
        }

        public void MarkAsFailed(int entryId, string SaasStatus, string ServerStatus, string SaasSError, string ServerError)
        {
            lock (_fileLock)
            {
                var lines = File.ReadAllLines(_filePath).ToList();
                for (int i = 0; i < lines.Count; i++) // int = 1
                {
                    var parts = lines[i].Split(',');
                    if (int.Parse(parts[0]) == entryId)
                    {
                        //lines[i] = $"{parts[0]},{parts[1]},{parts[2]},{parts[3]},Sent";
                        lines[i] = $"{parts[0]},{parts[1]},{parts[2]},{SaasStatus},{ServerStatus},{SaasSError},{ServerError},{_unsentStatus}";
                        break;
                    }
                }
                File.WriteAllLines(_filePath, lines, Encoding.UTF8);
            }
        }

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
    }

}
