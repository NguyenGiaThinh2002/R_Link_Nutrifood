using Serilog;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace BarcodeVerificationSystem.Utils
{
    public class ProjectLogger
    {
        private static readonly string LogDirectory =
        Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "R-Link", "Logs");

        private static readonly string LogFilePath =
            Path.Combine(LogDirectory, "log.txt");

        static ProjectLogger()
        {
            try
            {
                // Ensure folder exists
                if (!Directory.Exists(LogDirectory))
                {
                    Directory.CreateDirectory(LogDirectory);
                }

                // Ensure file exists
                if (!File.Exists(LogFilePath))
                {
                    using (File.Create(LogFilePath)) { }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Logger initialization failed: " + ex.Message);
            }
        }

        public static void OpenErrorFile()
        {
            try
            {
                if (!File.Exists(LogFilePath))
                {
                    using (File.Create(LogFilePath)) { }
                }

                Process.Start("notepad.exe", LogFilePath);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Failed to open log file: " + ex.Message);
            }
        }

        public static void WriteError(string message, Exception ex = null)
        {
            try
            {
                string logMessage = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] ERROR: {message}";
                if (ex != null)
                {
                    logMessage += Environment.NewLine + ex.ToString();
                }

                File.AppendAllText(LogFilePath, logMessage + Environment.NewLine);
            }
            catch (Exception logEx)
            {
                Debug.WriteLine("Logging failed: " + logEx.Message);
            }
        }

        public static void WriteInfo(string message)
        {
            try
            {
                string logMessage = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] INFO: {message}";
                File.AppendAllText(LogFilePath, logMessage + Environment.NewLine);
            }
            catch (Exception logEx)
            {
                Debug.WriteLine("Logging failed: " + logEx.Message);
            }
        }

        public static void WriteWarning(string message)
        {
            Log.Warning(message);
        }



        public static void WriteDebug(string message)
        {
            Log.Debug(message);
        }



        public static void Close()
        {
            Log.CloseAndFlush();
        }
    }

}

//  Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logs", "log-.txt");

// string documentsPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "R-Link", "Database");
