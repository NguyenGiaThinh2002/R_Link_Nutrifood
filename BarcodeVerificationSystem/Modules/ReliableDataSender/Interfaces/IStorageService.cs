﻿using BarcodeVerificationSystem.Modules.ReliableDataSender.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarcodeVerificationSystem.Modules.ReliableDataSender.Interfaces
{
    public interface IStorageService<T>
    {
        void AppendEntry(T entry);
        List<T> LoadUnsentEntries();
        void MarkAsSent(StorageUpdate update);
        void MarkAsFailed(StorageUpdate update);
        //void MarkAsSent(int id, string PrintedDate , string SaasStatus, string ServerStatus, string SaasSError, string ServerError);
        //void MarkAsFailed(int id,string PrintedDate, string SaasStatus, string ServerStatus, string SaasSError, string ServerError);

    }

}
