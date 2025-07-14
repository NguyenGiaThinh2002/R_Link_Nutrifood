using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarcodeVerificationSystem.Model.UserPermission
{
    public class UserPermission
    {
        public Dictionary<string, bool> Permissions { get; set; }

        public bool this[string functionKey]
        {
            get
            {
                return Permissions != null &&
                       Permissions.ContainsKey(functionKey) &&
                       Permissions[functionKey];
            }
        }
    }
}
