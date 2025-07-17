using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarcodeVerificationSystem.Model.UserPermission
{

    public class UserPermission
    {
        private static string _settings = "settings";
        private static string _controls = "controls";
        private static string _exports = "exports";
        private static string _accounts = "accounts";
        private static string _createJob = "createJob";
        private static string _deleteJob = "deleteJob";
        private static string _manufacturingMode = "manufacturingMode";
        private static string _dispatchingMode = "dispatchingMode";
        private static string _partialDisplay = "partialDisplay";
        private static string _repackFactory = "repackFactory";
        private static string _repackWarehouse = "repackWarehouse";

        public static UserPermission AdminPermission = new UserPermission
        {
            Permissions = new Dictionary<string, bool>
            {
                { _settings, true },
                { _controls, true },
                { _exports, true },
                { _accounts, true },
                { _createJob, true },
                { _deleteJob, true },
                { _manufacturingMode, true },
                { _dispatchingMode, true },
                { _partialDisplay, true },
                { _repackFactory, true },
                { _repackWarehouse, true }
            }
        };

        public static UserPermission OperatorPermission = new UserPermission
        {
            Permissions = new Dictionary<string, bool>
            {
                { _settings, false },
                { _controls, true },
                { _exports, false },
                { _accounts, false },
                { _createJob, true },
                { _deleteJob, false },
                { _manufacturingMode, false },
                { _dispatchingMode, false },
                { _partialDisplay, false },
                { _repackFactory, false },
                { _repackWarehouse, false }
            }
        };

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

        public bool CreateJob => this[_createJob];
        public bool DeleteJob => this[_deleteJob];
        public bool Settings => this[_deleteJob];
        public bool Controls => this[_controls];
        public bool Exports => this[_exports];
        public bool Accounts => this[_accounts];
        public bool ManufacturingMode => this[_manufacturingMode];
        public bool DispatchingMode => this[_dispatchingMode];
        public bool PartialDisplay => this[_partialDisplay];
        public bool RepackFactory => this[_repackFactory];
        public bool RepackWarehouse => this[_repackWarehouse];


        //private readonly Dictionary<string, bool> _permissions;

        //public static readonly UserPermission Admin = new UserPermission(new Dictionary<string, bool>
        //{
        //    ["settings"] = true,
        //    ["controls"] = true,
        //    ["exports"] = true,
        //    ["accounts"] = true,
        //    ["createJob"] = true,
        //    ["deleteJob"] = true
        //});

        //public static readonly UserPermission Operator = new UserPermission(new Dictionary<string, bool>
        //{
        //    ["settings"] = false,
        //    ["controls"] = true,
        //    ["exports"] = false,
        //    ["accounts"] = false,
        //    ["createJob"] = true,
        //    ["deleteJob"] = false
        //});

        //public UserPermission(Dictionary<string, bool> permissions)
        //{
        //    _permissions = permissions ?? new Dictionary<string, bool>();
        //}

        //public bool this[string key] => _permissions.TryGetValue(key, out var value) && value;

        //public IReadOnlyDictionary<string, bool> Permissions => _permissions;

        //public bool CreateJob => this["createJob"];
        //public bool DeleteJob => this["deleteJob"];
        //public bool Settings => this["settings"];
        //public bool Controls => this["controls"];
        //public bool Exports => this["exports"];
        //public bool Accounts => this["accounts"];

        //public class UserPermission
        //{
    }


}
