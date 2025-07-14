using BarcodeVerificationSystem.Modules.ReliableDataSender.Core;
using BarcodeVerificationSystem.Modules.ReliableDataSender.Models;
using BarcodeVerificationSystem.Modules.ReliableDataSender.Services;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarcodeVerificationSystem.Modules.ReliableDataSender.Factories
{
    public class ReliableProcessorFactory
    {
        public static PrintingQueueProcessor CreatePrintingProcessor(string filePath, string endpoint)
        {
            var queue = new BlockingCollection<PrintingDataEntry>();
            var fileStorage = new PrintingStorageService(filePath);
            var senderWorker = new PrintingSenderService(queue, fileStorage, endpoint);
            var processor = new PrintingQueueProcessor(queue, fileStorage, senderWorker);
            return processor;
        }

        public static VerificationQueueProcessor CreateVerificationProcessor(string filePath, string endpoint)
        {
            var queue = new BlockingCollection<VerificationDataEntry>();
            var fileStorage = new VerificationStorageService(filePath);
            var senderWorker = new VerificationSenderService(queue, fileStorage, endpoint);
            var processor = new VerificationQueueProcessor(queue, fileStorage, senderWorker);
            return processor;
        }
    }

}
