using Serilog;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarcodeVerificationSystem.Utils
{
    public class ProjectLogger
    {
        private static readonly string LogFilePath =
           Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logs", "log-.txt");

        static ProjectLogger()
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                //.WriteTo.Debug()
                .WriteTo.File(LogFilePath, rollingInterval: RollingInterval.Day)
                .CreateLogger();
        }

        public static void WriteInfo(string message)
        {
            Log.Information(message);
        }

        public static void WriteWarning(string message)
        {
            Log.Warning(message);
        }

        public static void WriteError(string message, Exception ex = null)
        {
            try
            {
                if (ex == null)
                    Log.Error(message);
                else
                    Log.Error(ex, message);
            }
            catch (Exception)
            {
            }
    
        }

        public static void WriteDebug(string message)
        {
            Log.Debug(message);
        }

        public static void OpenErrorFile()
        {
            string todayFile = LogFilePath.Replace("log-.txt", $"log-{DateTime.Now:yyyyMMdd}.txt");

            if (File.Exists(todayFile))
            {
                Process.Start("notepad.exe", todayFile);
            }
            else
            {
                throw new FileNotFoundException("Log file not found", todayFile);
            }
        }

        public static void Close()
        {
            Log.CloseAndFlush();
        }
    }

}
