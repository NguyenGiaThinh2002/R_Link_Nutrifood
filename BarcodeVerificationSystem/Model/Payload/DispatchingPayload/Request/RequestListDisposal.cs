using BarcodeVerificationSystem.Controller;
using BarcodeVerificationSystem.Model.UserInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarcodeVerificationSystem.Model.Payload.DispatchingPayload.Request
{
    internal class RequestListDisposal
    {
        public string username { get; set; } = CurrentUser.UserName;
        public string plant { get; set; } = Shared.Settings.FactoryCode;

        public List<RequestDisposal> qrCodes { get; set; } = new List<RequestDisposal>();
    }
}
