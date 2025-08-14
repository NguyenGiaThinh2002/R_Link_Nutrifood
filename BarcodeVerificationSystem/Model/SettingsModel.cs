using BarcodeVerificationSystem.Controller;
using BarcodeVerificationSystem.Labels.ProjectLabel;
using BarcodeVerificationSystem.Model.CodeGeneration;
using BarcodeVerificationSystem.Model.Payload.DispatchingPayload;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;

namespace BarcodeVerificationSystem.Model
{
    public class SettingsModel
    {
        #region Properties

        public ResponseOrder DispatchingOrderPayload { get; set; } = null;
        public int AddQuantity = 0;
        private string _printTemplate = "";
        public string PrintTemplate { get => _printTemplate; set => _printTemplate = value; }

        private string _RLinkName = "";
        public string RLinkName
        {
            get { return _RLinkName; }
            set { _RLinkName = value; }
        }

        public int TotalLines = 14;
        public int LineIndex = 0;


        private CompareType _CompareType = CompareType.CanRead;
        public CompareType CompareType { get => _CompareType; set => _CompareType = value; }

        private string _JobFileExtension = ".rvis";

        private List<CameraModel> _CameraList = new List<CameraModel>();
        public List<CameraModel> CameraList { get => _CameraList; set => _CameraList = value; }

        private List<PrinterModel> _PrinterList = new List<PrinterModel>();
        public List<PrinterModel> PrinterList { get => _PrinterList; set => _PrinterList = value; }
        private bool _IsPrinting = true;
        public bool IsPrinting { get => _IsPrinting; set => _IsPrinting = value; }

        private char _splitCharacter = ';';
        public char SplitCharacter { get => _splitCharacter; set => _splitCharacter = value; }

        private bool _SensorControllerEnable = true;
        private string _SensorControllerIP = "192.168.1.100";
        private int _SensorControllerPort = 2001;
        private int _SensorControllerPort2 = 2002;
        private int _NumberOfPort = 1;
        public int NumberOfPort { get => _NumberOfPort; set => _NumberOfPort = value; }

        private bool _allowDupAndNonStop = false;
        public bool AllowDupAndNonStop { get => _allowDupAndNonStop; set => _allowDupAndNonStop = value; }

        private bool _maskData = false;
        public bool MaskData { get => _maskData && ProjectLabel.IsNutrifood; set => _maskData = value; }
        public bool SensorControllerEnable { get => _SensorControllerEnable; set => _SensorControllerEnable = value; }
        public int SensorControllerPort2 { get => _SensorControllerPort2; set => _SensorControllerPort2 = value; }
        public string SensorControllerIP { get => _SensorControllerIP; set => _SensorControllerIP = value; }
        public int SensorControllerPort { get => _SensorControllerPort; set => _SensorControllerPort = value; }

        private int _PLCVersion = 0;
        public int PLCVersion { get => _PLCVersion; set => _PLCVersion = value; }

        private ResumeEncoderType _ResumeEncoderType = ResumeEncoderType.ResumeA;
        private bool _ResumeEncoderEnable = false;
        public bool ResumeEncoderEnable { get => _ResumeEncoderEnable; set => _ResumeEncoderEnable = value; }
        public enum ResumeEncoderType
        {
            ResumeA,
            ResumeAB,
        }
        public ResumeEncoderType ResumeEncoder { get => _ResumeEncoderType; set => _ResumeEncoderType = value; }

        private bool _EnablePosition = false;
        public bool EnablePosition { get => _EnablePosition && Shared.Settings.CameraList.FirstOrDefault().CameraType != CameraType.DM; set => _EnablePosition = value; }

        private bool _isItemsPerHour = false;
        public bool IsItemsPerHour { get => _isItemsPerHour; set => _isItemsPerHour = value; }
        public enum PositionType
        {
            LogoPosition,
            BarcodePosition,
        }
        private PositionType _PositionType = PositionType.BarcodePosition;
        public PositionType Position { get => _PositionType; set => _PositionType = value; }


        public List<int> SensorControllerDelayBefore;
        public List<int> SensorControllerDelayAfter;
        public List<int> SensorControllerPulseEncoder;
        public List<float> SensorControllerEncoderDiameter;
        public List<int> GapLength1;
        public List<int> Length2Error1;
        public List<int> DelayOutputError;

        public T Get<T>(List<T> list, int index)
        {
            while (list.Count <= index) list.Add(default);
            return list[index];
        }

        public void Set<T>(List<T> list, int index, T value)
        {
            while (list.Count <= index) list.Add(default);
            list[index] = value;
        }

        private int _gapLength2 = 0;
        public int GapLength2
        {
            get { return _gapLength2; }
            set { _gapLength2 = value; }
        }


        #region Production Mode

        private bool _isProductionMode = false;
        public bool IsProductionMode
        {
            get { return _isProductionMode; }
            set { _isProductionMode = value; }
        }

        private int _increasedDataPercent = 10;
        public int IncreasedDataPercent
        {
            get { return _increasedDataPercent; }
            set { _increasedDataPercent = value; }
        }

        private bool _isManufacturingMode = true;
        public bool IsManufacturingMode
        {
            get { return _isManufacturingMode; } 
            set { _isManufacturingMode = value; }
        }


        private string _apiUrl = "https://www.google.com/";

        public string ApiUrl
        {
            get { return _apiUrl; }
            set { _apiUrl = value; }
        }

        private string _RLinkId = "";

        public string LineId
        {
            get { return _RLinkId; }
            set { _RLinkId = value; }
        }

        private string _OrderId = "";
        public string OrderId
        {
            get { return _OrderId; }
            set { _OrderId = value; }
        }

        private string _wmsNumber = "";
        public string WmsNumber
        {
            get { return _wmsNumber; }
            set { _wmsNumber = value; }
        }

        private string _lineName = "";
        public string LineName
        {
            get { return _lineName; }
            set { _lineName = value; }
        }

        private string _factoryCode = "";
        public string FactoryCode
        {
            get { return _factoryCode; }
            set { _factoryCode = value; }
        }

        #endregion


        #region Serial Device
        public bool EnSerialDevice { get; set; }
        private string _serialDivComName = "COM3";
        private int _serialDivbitPerSecond = 9600;
        private int _serialDivDataBits = 8;
        private Parity _serialDivParity = Parity.None;
        private StopBits _serialDivStopBits = StopBits.One;

        public string SerialDivComName { get => _serialDivComName; set => _serialDivComName = value; }
        public int SerialDivBitPerSecond { get => _serialDivbitPerSecond; set => _serialDivbitPerSecond = value; }
        public int SerialDivDataBits { get => _serialDivDataBits; set => _serialDivDataBits = value; }
        public Parity SerialDivParity { get => _serialDivParity; set => _serialDivParity = value; }
        public StopBits SerialDivStopBits { get => _serialDivStopBits; set => _serialDivStopBits = value; }
        #endregion Serial Device

        private int _SensorControllerPulseEncoder2 = 3600;

        private int _length2Error2 = 0;
        public int Length2Error2
        {
            get { return _length2Error2; }
            set { _length2Error2 = value; }
        }

        public int SensorControllerPulseEncoder2
        {
            get { return _SensorControllerPulseEncoder2; }
            set { _SensorControllerPulseEncoder2 = value; }
        }

        private float _SensorControllerEncoderDiameter2 = 48.51f;

        public float SensorControllerEncoderDiameter2
        {
            get { return _SensorControllerEncoderDiameter2; }
            set { _SensorControllerEncoderDiameter2 = value; }
        }

        private int _SensorControllerDelayBefore2 = 0;

        public int SensorControllerDelayBefore2
        {
            get { return _SensorControllerDelayBefore2; }
            set { _SensorControllerDelayBefore2 = value; }
        }

        private int _SensorControllerDelayAfter2 = 0;

        public int SensorControllerDelayAfter2
        {
            get { return _SensorControllerDelayAfter2; }
            set { _SensorControllerDelayAfter2 = value; }
        }



        private string _ExportCheckedResultPath = @"C:\Users\Public\Exports\CheckedResult";
        private string _DataCheckedFileName = "20191220_164200_DataChecked.txt";
        private bool _ExportImageEnable = false;
        private string _ExportImagePath = @"C:\Users\Public\Exports\Images";
        private string _FailedDataSentToPrinter = @"Failure";
        private List<PODModel> _PrintFieldForVerifyAndPrint = new List<PODModel>();
        public string ExportCheckedResultPath { get => _ExportCheckedResultPath; set => _ExportCheckedResultPath = value; }
        public string DataCheckedFileName { get => _DataCheckedFileName; set => _DataCheckedFileName = value; }
        public bool ExportImageEnable { get => _ExportImageEnable; set => _ExportImageEnable = value; }
        public string ExportImagePath { get => _ExportImagePath; set => _ExportImagePath = value; }
        public string FailedDataSentToPrinter { get => _FailedDataSentToPrinter; set => _FailedDataSentToPrinter = value; }
        public List<PODModel> PrintFieldForVerifyAndPrint { get => _PrintFieldForVerifyAndPrint; set => _PrintFieldForVerifyAndPrint = value; }

        private string _Language = "vi-VN";
        public string Language { get => _Language; set => _Language = value; }

        private string _DateTimeFormatOfResult = "yyyy/MM/dd HH:mm:ss";
        public string DateTimeFormatOfResult { get => _DateTimeFormatOfResult; set => _DateTimeFormatOfResult = value; }

        private bool _OutputEnable = true;
        public bool OutputEnable { get => _OutputEnable; set => _OutputEnable = value; }

        private bool _ExportOneForAllEnable = false;
        public bool ExportOneForAllEnable { get => _ExportOneForAllEnable; set => _ExportOneForAllEnable = value; }
        private bool _DuplicatedDBEnable = false;
        public bool DuplicatedDBEnable { get => _DuplicatedDBEnable; set => _DuplicatedDBEnable = value; }

        private bool _TotalCheckEnable = true;
        public bool TotalCheckEnable { get => _TotalCheckEnable; set => _TotalCheckEnable = value; }
        private bool _VerifyAndPrintBasicSentMethod = true;
        public bool VerifyAndPrintBasicSentMethod { get => _VerifyAndPrintBasicSentMethod; set => _VerifyAndPrintBasicSentMethod = value; }

        private string _ExportNamePrefixFormat = "yyyyMMdd_HHmmss";
        public string ExportNamePrefixFormat { get => _ExportNamePrefixFormat; set => _ExportNamePrefixFormat = value; }


        private string _JobDateTimeFormat = "yyyyMMdd_HHmmss";
        public string JobDateTimeFormat { get => _JobDateTimeFormat; set => _JobDateTimeFormat = value; }
        private string _JobFileNameDefault = "Template";
        public string JobFileNameDefault { get => _JobFileNameDefault; set => _JobFileNameDefault = value; }
        public string JobFileExtension { get => _JobFileExtension; set => _JobFileExtension = value; }

        #endregion Properties

        #region Methods
        public virtual void SaveSettings(string fileName)
        {
            try
            {
                var xmlDocument = new XmlDocument();
                var serializer = new XmlSerializer(this.GetType());
                using (var stream = new MemoryStream())
                {
                    serializer.Serialize(stream, this);
                    stream.Position = 0;
                    xmlDocument.Load(stream);
                    xmlDocument.Save(fileName);
                    stream.Close();
                }
            }
            catch (Exception)
            {

            }
        }

        public static SettingsModel LoadSetting(string fileName)
        {
            SettingsModel info = null;
            try
            {
                var xmlDocument = new XmlDocument();
                xmlDocument.Load(fileName);
                string xmlString = xmlDocument.OuterXml;

                using (var read = new StringReader(xmlString))
                {
                    Type outType = typeof(SettingsModel);
                    var serializer = new XmlSerializer(outType);
                    using (var reader = new XmlTextReader(read))
                    {
                        info = (SettingsModel)serializer.Deserialize(reader);
                        reader.Close();
                    }

                    read.Close();
                }
            }
            catch (Exception)
            {
                return new SettingsModel();
            }

            return info;
        }

        #endregion Methods
    }
}
