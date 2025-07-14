using System.Diagnostics;
using System.IO;
using System.Management;
using System.Security.Cryptography;
using System.Windows;
using MessageBox = System.Windows.MessageBox;

namespace LicenseGenerator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string _savedPath = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "R-LinkLicense");
        private static string _EncyptionPassword = "rynan_encrypt_remember";
        private static readonly string _EncrytionFilePassword = "RhapsodosZyl_ft_Tieunhan1st";
        public MainWindow()
        {
            InitializeComponent();
            if (!File.Exists(_savedPath))
            {
                Directory.CreateDirectory(_savedPath);
            }
        }

        #region Button Action

        private void Generate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var content = TextBoxUUID.Text;
                if (string.IsNullOrEmpty(content)) return;
                EncryptFile(content, _savedPath + "\\RConfig.dat");
                MessageBox.Show("Done !", "Create License File", MessageBoxButton.OK, MessageBoxImage.Information);   
            }
            catch (Exception)
            {
            }
        }

        private void Br_Click(object sender, RoutedEventArgs e)
        {
            // Create an OpenFileDialog
            OpenFileDialog openFileDialog = new();
            openFileDialog.InitialDirectory = _savedPath;
            openFileDialog.Filter = "Text files (*.dat)|*.dat|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
            }
        }

        private async void GetUUID_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                TextBoxMyUUID.Text = await GetUniqueID();
            }
            catch (Exception)
            {
            }
        }

        #endregion Button Action

        #region Enscription
        static async Task<string> GetUniqueID()
        {
          return await Task.Run(() =>
            {
                string cpuID = GetHardwareID("Win32_Processor", "ProcessorId");
                string biosID = GetHardwareID("Win32_BIOS", "SerialNumber");
                string diskID = GetHardwareID("Win32_DiskDrive", "SerialNumber");

                return cpuID + biosID + diskID;
            });
           
        }
        static string GetHardwareID(string wmiClass, string wmiProperty)
        {
            string result = "";
            ManagementClass mc = new(wmiClass);
            ManagementObjectCollection moc = mc.GetInstances();

            foreach (ManagementObject mo in moc)
            {
                if (result == "")
                {
                    result = mo[wmiProperty].ToString();
                    break;
                }
            }

            return result;
        }
        public static void EncryptFile(string inputFileContent, string outputFile)
        {
            try
            {
                string password = _EncrytionFilePassword;
                byte[] key = CreateKey(password);
                var fsCrypt = new FileStream(outputFile, FileMode.Create);
                using var aes = Aes.Create();
                aes.BlockSize = 128;
                aes.KeySize = 256;
                aes.IV = key.Take(aes.BlockSize / 8).ToArray();
                aes.Key = key;
                aes.Padding = PaddingMode.PKCS7; // Ensure padding mode is set
                Debug.WriteLine($"Key: {BitConverter.ToString(key)}");
                Debug.WriteLine($"IV: {BitConverter.ToString(aes.IV)}");

                using var cs = new CryptoStream(fsCrypt, aes.CreateEncryptor(), CryptoStreamMode.Write);
                using var writer = new StreamWriter(cs);
                writer.Write(inputFileContent); // Use Write instead of WriteLine to avoid adding extra newline
            }
            catch (Exception)
            {
                // Handle exceptions as needed
            }
        }

        private static readonly byte[] Salt = [10, 20, 30, 40, 50, 60, 70, 80];
        private static byte[] CreateKey(string password, int keyBytes = 32)
        {
            const int Iterations = 300;
            using var keyGenerator = new Rfc2898DeriveBytes(password, Salt, Iterations, HashAlgorithmName.SHA256);
            return keyGenerator.GetBytes(keyBytes);
        }

        #endregion Enscription

       
    }
}