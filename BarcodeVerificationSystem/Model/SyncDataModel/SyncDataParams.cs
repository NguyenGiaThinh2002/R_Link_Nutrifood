﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarcodeVerificationSystem.Model
{
    public class SyncDataParams
    {
        public enum SyncDataType
        {
            SentData,
            SAPSuccess,
            SaaSSuccess,
            SAPFailed,
            SaaSFailed,
        }
        public SyncDataType DataType { get; set; }
        public int CodeIndex { get; set; }
        public object Data { get; set; } // For more generic data

        public SyncDataParams(SyncDataType name, int value)
        {
            DataType = name;
            CodeIndex = value; // Default value
        }


    }
}
