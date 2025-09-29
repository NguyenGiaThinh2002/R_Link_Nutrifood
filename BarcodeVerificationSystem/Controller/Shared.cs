using BarcodeVerificationSystem.Controller.Camera.Keyence;
using BarcodeVerificationSystem.Model;
using BarcodeVerificationSystem.Model.Payload.DispatchingPayload.Response;
using BarcodeVerificationSystem.Model.Payload.ManufacturingPayload.Response;
using BarcodeVerificationSystem.Model.RunningMode.Dispatching;
using BarcodeVerificationSystem.Model.UserPermission;
using BarcodeVerificationSystem.Services;
using BarcodeVerificationSystem.View;
using BarcodeVerificationSystem.View.CustomDialogs;
using CommonVariable;
using EncrytionFile.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace BarcodeVerificationSystem.Controller
{
    public class Shared
    {

        #region Variables
        public static OperationStatus OperStatus = OperationStatus.Stopped;
        public static UserDataModel LoggedInUser = null;
        public static List<PODController> PODControllerList = new List<PODController>();
        public static PODController PrinterPODController = null;
        public static SettingsModel Settings = new SettingsModel();
        public static UserPermission UserPermission = new UserPermission();
        public static JobModel CurrentJob;
        public static bool IsSensorControllerConnected = false;
        public static bool IsSerialDeviceConnected = false;
        public static bool IsSampled = false;

        public static ResponseReservation Reservation;
        public static int SelectedRESMaterialIndex = 0;

        public static PODController SensorController = null;
        public static SerialDeviceController SerialDevController = null;

        public static CameraController CamController = null;
        public static CvxCamera cvxCamera = null;

        public static List<HardwareIDModel> listPCAllow = new List<HardwareIDModel>();
        public static string JobNameSelected = "";
        public static string databasePath = "";
        public static int numberOfCodesGenerate = 0;
        public static int SelectedMaterialIndex = 0;

        // shared models
        // Dispatching
        internal static ResponseListRePrint ResponseListRePrint = new ResponseListRePrint();
        internal static PrintingMode PrintMode = new PrintingMode();
        public static bool isPushDatabase = false;
        public static int FirstGeneratedCodeIndex = 0;
        public static int LastGeneratedCodeIndex = 0;
        public static int NumberPrinted = 0;
        public static int TotalCodes = 0;
        public static int NumberOfSentSaaS = 0;
        public static int NumberOfSentSAP = 0;

        public static int NumberChecked = 0;
        public static int NumberOfCheckSentSaaS = 0;
        public static int NumberOfCheckSentSAP = 0;
        public static int NumberOfCheckSentSuccess = 0;


        public enum HistoryFilter{
            All,
            Finished,
            NotFinished,
        }
        
        #endregion Variables

        #region Events

        public static event EventHandler OnSyncDataParameterChange;
        public static void RaiseOnSyncDataParameterChangeEvent(SyncDataParams sender)
        {
            OnSyncDataParameterChange?.Invoke(sender, EventArgs.Empty);
        }

        public static event EventHandler OnSyncCheckDataParameterChange;
        public static void RaiseOnSyncCheckDataParameterChangeEvent(SyncDataParams sender)
        {
            OnSyncCheckDataParameterChange?.Invoke(sender, EventArgs.Empty);
        }

        public static event EventHandler OnNextButtonEvent;
        public static void RaiseOnNextButtonEvent()
        {
            OnNextButtonEvent?.Invoke(null, EventArgs.Empty);
        }

        public static event EventHandler OnNumberEventISCount;
        public static void RaiseOnNumberEventISCountEvent(CountEventISCamera eventCounter)
        {
            OnNumberEventISCount?.Invoke(eventCounter, EventArgs.Empty);
        }

        public static event EventHandler OnLanguageChange;
        public static void RaiseLanguageChangeEvent(String languageCode)
        {
            UILanguage.Lang.Culture = System.Globalization.CultureInfo.CreateSpecificCulture(languageCode);
            OnLanguageChange?.Invoke(languageCode, EventArgs.Empty);
        }
        public static event EventHandler OnRepeatTCPMessageChange;
        public static void RaiseOnRepeatTCPMessageChange(object tcpMessage)
        {
            OnRepeatTCPMessageChange?.Invoke(tcpMessage, EventArgs.Empty);
        }

        public static event EventHandler OnSensorControllerChangeEvent;
        public static void RaiseSensorControllerChangeEvent()
        {
            OnSensorControllerChangeEvent?.Invoke(null, EventArgs.Empty);
        }

        public static event EventHandler OnSerialDeviceControllerChangeEvent;
        public static void RaiseSerialDeviceControllerChangeEvent()
        {
            OnSerialDeviceControllerChangeEvent?.Invoke(null, EventArgs.Empty);
        }

        public static event EventHandler OnPrinterStatusChange;
        public static void RaiseOnPrinterStatusChangeEvent()
        {
            OnPrinterStatusChange?.Invoke(null, EventArgs.Empty);
        }
        public static event EventHandler OnPrintingStateChange;
        public static void RaiseOnPrintingStateChange()
        {
            OnPrintingStateChange?.Invoke(null, EventArgs.Empty);
        }
        public static event EventHandler OnPrinterDataChange;
        public static void RaiseOnPrinterDataChangeEvent(PODDataModel data)
        {
            OnPrinterDataChange?.Invoke(data, EventArgs.Empty);
        }
        public static event EventHandler OnCameraStatusChange;
        public static void RaiseOnCameraStatusChangeEvent()
        {
            OnCameraStatusChange?.Invoke(null, EventArgs.Empty);
        }
        public static event EventHandler OnCameraReadDataChange;
        public static void RaiseOnCameraReadDataChangeEvent(DetectModel detectModel)
        {
            OnCameraReadDataChange?.Invoke(detectModel, EventArgs.Empty);
        }

        public static event EventHandler OnCameraPositionDataChange;
        public static void RaiseOnCameraPositionDataChangeEvent(DetectModel detectModel)
        {
            OnCameraPositionDataChange?.Invoke(detectModel, EventArgs.Empty);
        }

        public static event EventHandler OnSerialDeviceReadDataChange;
        public static void RaiseOnSerialDeviceReadDataChangeEvent(DetectModel detectModel)
        {
            OnSerialDeviceReadDataChange?.Invoke(detectModel, EventArgs.Empty);
        }

        public static event EventHandler OnOperationStatusChange;
        public static void RaiseOnOperationStatusChangeEvent(OperationStatus operationStatus)
        {
            OnOperationStatusChange?.Invoke(operationStatus, EventArgs.Empty);
        }
        public static event EventHandler OnCameraOutputSignalChange;
        public static void RaiseOnCameraOutputSignalChangeEvent(object sender)
        {
            OnCameraOutputSignalChange?.Invoke(sender, EventArgs.Empty);
        }
        public static event EventHandler OnCameraTriggerOnChange;
        public static void RaiseOnCameraTriggerOnChangeEvent()
        {
            OnCameraTriggerOnChange?.Invoke(null, EventArgs.Empty);
        }

        public static event EventHandler OnCameraTriggerOffChange;
        public static void RaiseOnCameraTriggerOffChangeEvent()
        {
            OnCameraTriggerOffChange?.Invoke(null, EventArgs.Empty);
        }
        public static event EventHandler OnReceiveResponsePrinter;
        public static void RaiseOnReceiveResponsePrinter(object response)
        {
            OnReceiveResponsePrinter?.Invoke(response, EventArgs.Empty);
        }
        public static event EventHandler OnVerifyAndPrindSendDataMethod;
        public static void RaiseOnVerifyAndPrindSendDataMethod()
        {
            OnVerifyAndPrindSendDataMethod?.Invoke(true, EventArgs.Empty);
        }
        public static event EventHandler OnHanlderException;
        public static void RaiseOnOnHanlderException(Exception ex)
        {
            OnHanlderException?.Invoke(ex, UnhandledExceptionEventArgs.Empty);
        }

        public static event EventHandler OnAddSuffix;
        public static void RaiseAddSuffix(object camModel)
        {
            OnAddSuffix?.Invoke(camModel, EventArgs.Empty);
        }



        public static event EventHandler OnStopButtonClick;
        public static void RaiseOnStopButtonClick()
        {
            OnStopButtonClick?.Invoke(null, EventArgs.Empty);
        }

        public static event EventHandler OnLogError;
        public static void RaiseOnLogError(object sender)
        {
            OnLogError?.Invoke(sender, EventArgs.Empty);
        }
        #endregion Events

        #region Methods

        public static void ExportCheckedResult(string sourceFilePath)
        {
            if (Path.GetFileName(sourceFilePath) != "")
            {
                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Title = "Select destination to save the copied file";
                    saveFileDialog.FileName = Path.GetFileName(sourceFilePath);
                    saveFileDialog.Filter = "All Files|*.*";
                    saveFileDialog.Filter = "CSV files (*.csv)|*.csv|PDF files (*.pdf)|*.pdf";

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {
                            if (saveFileDialog.FileName.EndsWith(".pdf"))
                            {
                                List<string> lines = new List<string>();

                                if (File.Exists(sourceFilePath))
                                {
                                    lines.AddRange(File.ReadAllLines(sourceFilePath));
                                    FrmMain.ConvertCsvToPdf(lines.ToArray(), saveFileDialog.FileName);
                                    Process.Start("explorer.exe", $"/select,\"{saveFileDialog.FileName}\"");
                                }
                                else
                                {
                                    MessageBox.Show("File not found: " + sourceFilePath);
                                }
                            }
                            else
                            {
                                File.Copy(sourceFilePath, saveFileDialog.FileName, true);
                            Process.Start("explorer.exe", $"/select,\"{saveFileDialog.FileName}\"");
                        }

                        }
                        catch (Exception ex)
                        {
                            CustomMessageBox.Show($"Result file does not exist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }

        }

        public static PrinterSettingsModel GetSettingsPrinter()
        {
            PrinterSettingsModel printerSettingsModel = new PrinterSettingsModel();
            try
            {
                string printerIPAddress = Settings.PrinterList.FirstOrDefault().IP;
                int printerPort = Settings.PrinterList.FirstOrDefault().NumPortRemote;
                string url = string.Format("http://{0}:{1}/api/request?act=get_system_setting", printerIPAddress, printerPort);
                var request = (HttpWebRequest)WebRequest.Create(url);

                request.Method = "GET";
                request.Timeout = 1000;
                request.ContentType = "application/json";
                var httpResponse = (HttpWebResponse)request.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    string responseFromServer = streamReader.ReadToEnd();
                    var printerSettingsResponse = JsonConvert.DeserializeObject<PrinterSettingsResponseModel>(responseFromServer);
                    if (printerSettingsResponse != null)
                    {
                        if (printerSettingsResponse.Success)
                        {
                            printerSettingsModel = printerSettingsResponse.data;
                        }
                    }
                }
                printerSettingsModel.IsSupportHttpRequest = true;
                return printerSettingsModel;
            }
            catch (WebException)
            {
                printerSettingsModel.IsSupportHttpRequest = false;
                return printerSettingsModel;
            }
            catch (Exception)
            {
                return printerSettingsModel;
            }

        }

        public static ActivationStatus LoginLocal(string username, string password)
        {
            LoggedInUser = UserController.Login(username, password);

            // Save Username in App Lifetime
            if (LoggedInUser != null)
            {
                Properties.Settings.Default.Username = username;
                Properties.Settings.Default.Save();
            }

            if (LoggedInUser == null)
            {
                return ActivationStatus.Failed;
            }
            else
            {
                return ActivationStatus.Successful;
            }
        }

        public static string GetLocalIPAddress()
        {
            IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            throw new Exception("No network adapters with an IPv4 address in the system!");
        }

        #endregion

        #region Functions
        public static void LoadSettings()
        {
            try
            {
                string path = CommVariables.PathSettingsApp + "Settings.xml";
                Settings = SettingsModel.LoadSetting(path);
            }
            catch
            {
                Settings = new SettingsModel();
            }
            if (Settings.CameraList.Count <= 0)
            {
                Settings.CameraList.Add(new CameraModel { Index = 0,IP = "192.168.0.2",RoleOfCamera = RoleOfStation.ForProduct });
            }
            if (Settings.PrinterList.Count <= 0)
            {
                Settings.PrinterList.Add(new PrinterModel { Index = 0,IP = "192.168.1.2",RoleOfPrinter = RoleOfStation.ForProduct });
            }
            if (Settings.SensorControllerEncoderDiameter == null)
            {
                Settings.SensorControllerDelayBefore = new List<int>() { 0, 0 };
                Settings.SensorControllerDelayAfter = new List<int>() { 0, 0 };
                Settings.SensorControllerPulseEncoder = new List<int>() { 3600, 3600 };
                Settings.SensorControllerEncoderDiameter = new List<float>() { 48.51f, 48.51f };
                Settings.GapLength1 = new List<int>() { 0, 0 };
                Settings.Length2Error1 = new List<int>() { 0, 0 };
                Settings.DelayOutputError = new List<int>() { 0, 0 };
            }
        }

        public static void SaveSettings()
        {
            try
            {
                string path = CommVariables.PathSettingsApp;
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                Settings.SaveSettings(path + "Settings.xml");
            }
            catch { }
        }

        public static CameraModel GetCameraModelBasedOnIPAddress(string ipAddress)
        {
            foreach (CameraModel cameraModel in Settings.CameraList)
            {
                if (cameraModel.IP.Equals(ipAddress) && cameraModel.IsEnable)
                {
                    return cameraModel;
                }
            }
            return null;
        }

        public static bool CheckJobHasExist(string templateNameWithoutExtension)
        {
            string filePath = CommVariables.PathJobsApp + templateNameWithoutExtension + Settings.JobFileExtension;
            return File.Exists(filePath);
        }

        public static bool DeleteJob(JobModel templatePath)
        {
            string filePath = CommVariables.PathJobsApp + templatePath.FileName + Settings.JobFileExtension;
            string filePathCheckResult = CommVariables.PathCheckedResult + templatePath.CheckedResultPath;
            string filePathPrintedResponse = CommVariables.PathPrintedResponse + templatePath.PrintedResponePath;

            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
            if (File.Exists(filePathCheckResult))
            {
                File.Delete(filePathCheckResult);
            }
            if (File.Exists(filePathPrintedResponse))
            {
                File.Delete(filePathPrintedResponse);
            }
            return true;
        }

        public static JobModel GetJob(string templateNameWithExtension)
        {
            string filePath = CommVariables.PathJobsApp + templateNameWithExtension;
            return JobModel.LoadFile(filePath);
        }

        public static List<string> GetJobNameList()
        {
            try
            {
                string folderPath = CommVariables.PathJobsApp;
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }

                var dir = new DirectoryInfo(folderPath);
                var strFileNameExtension = string.Format("*{0}",Settings.JobFileExtension);
                FileInfo[] files = dir.GetFiles(strFileNameExtension).OrderByDescending(x => x.CreationTime).ToArray();
                var result = new List<string>();
                foreach (FileInfo file in files)
                {
                    result.Add(file.Name);
                }
                return result;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static string GetReadStringFromResultXml(string resultXml)
        {
            try
            {
                var doc = new XmlDocument();
                doc.LoadXml(resultXml);
                XmlNode fullStringNode = doc.SelectSingleNode("result/general/full_string");
                if (fullStringNode != null)
                {
                    XmlAttribute encoding = fullStringNode.Attributes["encoding"];
                    if (encoding != null && encoding.InnerText == "base64")
                    {
                        if (!string.IsNullOrEmpty(fullStringNode.InnerText))
                        {
                            byte[] code = Convert.FromBase64String(fullStringNode.InnerText);
                            return Encoding.UTF8.GetString(code,0,code.Length);
                        }
                        else
                        {
                            return "";
                        }
                    }

                    return fullStringNode.InnerText;
                }
            }
            catch (Exception)
            {
            }

            return "";
        }

        public static bool GetCameraStatus()
        {
            foreach (CameraModel cameraModel in Settings.CameraList)
            {
                if (cameraModel.IsEnable && !cameraModel.IsConnected)
                {
                    return false;
                }
            }
            return true;
        }

        public static bool GetPrinterStatus()
        {
            foreach (PrinterModel printerModel in Settings.PrinterList)
            {
                if (printerModel.IsEnable && !printerModel.IsConnected)
                {
                    return false;
                }
            }
            return true;
        }

        //  const string commandErrorOutput = "(R00001001000000100000000000000000000000000000000000000000000000000000000)";

        public static string ResumeA = "(T11000000000000000000000000000000000000000000000000000000000000000000000000000000000)";
        public static string ResumeAB = "(T10100000000000000000000000000000000000000000000000000000000000000000000000000000000)";
        public static void SendErrorOutputToSensorController(int Index)
        {
            if (Settings.CameraList.FirstOrDefault().IsIndexCommandEnable)
            {
                string formattedCompareIndex = Index.ToString("D7"); // Formats as a 7-digit number

                switch (Settings.PLCVersion)
                {
                    case 0:
                        SensorController.Send((Settings.CameraList.FirstOrDefault()).CommandErrorOutput + formattedCompareIndex);
                        break;
                    case 1:
                        SensorController.Send((Settings.CameraList.FirstOrDefault()).CommandErrorOutput + formattedCompareIndex);
                        break;
                    case 2:
                        SensorController.Send("(C00005)" + formattedCompareIndex);
                        break;

                }

                if (SensorController.IsConnected2())
                {
                    SensorController.Send2((Settings.CameraList.FirstOrDefault()).CommandErrorOutput + formattedCompareIndex);
                }
            }
            else
            {
                switch (Settings.PLCVersion)
                {
                    case 0:
                        SensorController.Send(Settings.CameraList.FirstOrDefault().CommandErrorOutput);
                        break;
                    case 1:
                        SensorController.Send(Settings.CameraList.FirstOrDefault().CommandErrorOutput);
                        break;
                    case 2:
                        SensorController.Send2("(C00005)");
                        break;

                }

                if (Settings.PLCVersion != 2)
                {
                    SensorController.Send2(Settings.CameraList.FirstOrDefault().CommandErrorOutput);
                }
            }
            //SensorController.Send("1");

        }

        public static void SendCommandToSensorController(string command)
        {
            if (SensorController != null && IsSensorControllerConnected)
            {
                SensorController.Send(command);
            }
        }

        public static void SendSettingToSensorController()
        {
            try
            {
                if (SensorController != null && IsSensorControllerConnected)
                {
                    bool includeError = Settings.PLCVersion == 1;
                    string strCommand = "(" + BuildSensorSegment(0, includeError) + BuildSensorSegment(1, includeError) + ")";
                    SensorController.Send(strCommand);
                }
            }
            catch { }
        }

        private static string BuildSensorSegment(int index, bool includeDelayOutput)
        {
            string strPulseEncoder = Settings.SensorControllerPulseEncoder[index].ToString("D5");
            float encoderDiameter = Settings.SensorControllerEncoderDiameter[index] * 100.0f;
            string strEncoderDiameter = ((int)encoderDiameter).ToString("D5");
            string strSensorDisableLength = Settings.SensorControllerDelayBefore[index].ToString("D5");
            string strSensorEnableLength = Settings.SensorControllerDelayAfter[index].ToString("D5");
            string strGapLength = Settings.GapLength1[index].ToString("D5");
            string strLength2Err = Settings.Length2Error1[index].ToString("D5");

            string EncoderModeCharacter = (Settings.PLCVersion == 2
                                        && Settings.EncoderMode == SettingsModel.ResumeEncoderMode.Internal
                                        && index == 1
                                        ) ? "I" : "P";

            string segment = string.Format("{6}{0}D{1}L{2}H{3}G{4}E{5}",
                                strPulseEncoder,
                                strEncoderDiameter,
                                strSensorDisableLength,
                                strSensorEnableLength,
                                strGapLength,
                                strLength2Err,
                                EncoderModeCharacter
                            );

            //string segment = string.Format("P{0}D{1}L{2}H{3}G{4}E{5}",
            //    strPulseEncoder,
            //    strEncoderDiameter,
            //    strSensorDisableLength,
            //    strSensorEnableLength,
            //    strGapLength,
            //    strLength2Err
            //);

            if (includeDelayOutput)
            {
                string strDelayOutputError = Settings.DelayOutputError[index].ToString("D5");
                segment += "O" + strDelayOutputError;
            }

            return segment;
        }

        #endregion
    }
}
