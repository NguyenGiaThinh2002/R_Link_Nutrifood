using BarcodeVerificationSystem.Modules.ReliableDataSender.Interfaces;
using BarcodeVerificationSystem.Modules.ReliableDataSender.Models;
using BarcodeVerificationSystem.Modules.ReliableDataSender.SharedValues;
using BarcodeVerificationSystem.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarcodeVerificationSystem.Modules.ReliableDataSender.Services
{
    public class VerificationStorageService : IStorageService<VerificationDataEntry>
    {
        private readonly string _filePath;
        private readonly object _fileLock = new object();
        private readonly string _unsentStatus = "NotSent";
        private readonly string _sentStatus = "Sent";
        private readonly string _databasePath;

        public VerificationStorageService(string filePath, string databasePath)
        {
            _filePath = filePath;
            _databasePath = databasePath;
            if (!File.Exists(_filePath))
            {
                File.Create(_filePath).Dispose(); // Dispose to release the handle immediately
                //InitializeDefaultDatabaseFormat();
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

        //public void AppendEntry(VerificationDataEntry entry)
        //{
        //    try
        //    {
        //        lock (_fileLock)
        //        {
        //            FileHelper.AppendVerifyingEntry(_filePath, entry, _unsentStatus);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        ProjectLogger.WriteError("Error in AppendNewEntry: " + ex.Message);
        //    }
        //}
        public void AppendEntry(VerificationDataEntry entry)  
        {
            lock (_fileLock)
            {
                var entryLine = $"{entry.Id},{entry.Code},{entry.UniqueCode},{entry.VerifiedDate},{entry.SaasStatus},{entry.SAPStatus},{entry.SaasError},{entry.SAPError},{entry.Status}";
                File.AppendAllLines(_filePath, new[] { entryLine }, Encoding.UTF8);
            }
        }

        public List<VerificationDataEntry> LoadUnsentEntries()
        {
            try
            {
                lock (_fileLock)
                {
                    return File.ReadAllLines(_filePath)
                    .Select((line, index) =>
                    {
                        var parts = line.Split(',');
                        return new VerificationDataEntry
                        {
                            Id = int.Parse(parts[VerifyingValues.Index]), // parts[0]}
                            Code = parts[VerifyingValues.QrCodeIndex], // parts[1]
                            UniqueCode = parts[VerifyingValues.UniqueCode],
                            VerifiedDate = parts[VerifyingValues.VerifiedDate],
                            SaasStatus = parts[VerifyingValues.SaaSStatus],
                            SAPStatus = parts[VerifyingValues.SAPStatus],
                            SaasError = parts[VerifyingValues.SaaSError],
                            SAPError = parts[VerifyingValues.SAPError],
                            Status = parts[VerifyingValues.SentStatus],
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
                FileHelper.UpdateVerifyingEntry(_filePath, entryId, PrintedDate, SaasStatus, SAPStatus, SaasSError, SAPError, _unsentStatus);
            }
            catch (Exception ex)
            {
                ProjectLogger.WriteError("Error in MarkAsFailed: " + ex.Message);
            }
        }

        public void MarkAsSent(int entryId, string PrintedDate, string SaasStatus, string SAPStatus, string SaasSError, string SAPError)
        {
            try
            {
                FileHelper.UpdateVerifyingEntry(_filePath, entryId, PrintedDate, SaasStatus, SAPStatus, SaasSError, SAPError, _sentStatus);
            }
            catch (Exception ex)
            {
                ProjectLogger.WriteError("Error in MarkAsSent: " + ex.Message);
            }
        }
    }
}
