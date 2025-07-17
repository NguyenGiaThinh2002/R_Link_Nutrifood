using BarcodeVerificationSystem.Modules.ReliableDataSender.Interfaces;
using BarcodeVerificationSystem.Modules.ReliableDataSender.Models;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarcodeVerificationSystem.Modules.ReliableDataSender.Core
{
    public class VerificationQueueProcessor
    {
        private readonly BlockingCollection<VerificationDataEntry> _queue;
        private readonly IStorageService<VerificationDataEntry> _storage;
        private readonly ISenderService<VerificationDataEntry> _sender;

        public VerificationQueueProcessor(BlockingCollection<VerificationDataEntry> queue, IStorageService<VerificationDataEntry> storage, ISenderService<VerificationDataEntry> sender)
        {
            _storage = storage;
            _sender = sender;
            _queue = queue;
        }

        public async void Start()
        {
            _sender.Start();
            //Task.Run(async () => await Task.Delay(100));
            await Task.Delay(200); // Ensure the sender is ready before loading entries


            foreach (var entry in _storage.LoadUnsentEntries())
            {
                _queue.Add(entry);
            }

        }

        public void Enqueue(int id, string[] code)
        {

            var entry = new VerificationDataEntry
            {
                Id = id,
                Code = code[1],
                VerifiedStatus = "Verified", // reconsider to (duplicate, valid, invalid)
                VerifiedDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                Status = "NotSent"
            };
            _storage.AppendEntry(entry);
            _queue.Add(entry);

        }

        public void Stop()
        {
            _sender.Stop();
        }
    }

}
