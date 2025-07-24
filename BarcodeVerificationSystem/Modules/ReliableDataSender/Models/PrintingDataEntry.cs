using BarcodeVerificationSystem.Modules.ReliableDataSender.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarcodeVerificationSystem.Modules.ReliableDataSender.Models
{
    public class PrintingDataEntry : IDataEntry
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string HumanCode { get; set; }
        public string PrintedDate { get; set; }
        public string PrintedStatus { get; set; }
        public string SaasStatus { get; set; } 
        public string ServerStatus { get; set; }
        public string SaasError { get; set; }
        public string ServerError { get; set; }
        public string Status { get; set; } // "NotSent" or "Sent"
    }
}
