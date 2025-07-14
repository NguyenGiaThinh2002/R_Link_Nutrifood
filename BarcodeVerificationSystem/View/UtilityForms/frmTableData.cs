using BarcodeVerificationSystem.Controller;
using BarcodeVerificationSystem.Model;
using System;
using System.Data;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using System.Data.SQLite;
using System.IO;
using System.Windows.Forms;
using UILanguage;
using Newtonsoft.Json.Linq;

namespace BarcodeVerificationSystem.View
{
    public partial class frmTableData : Form
    {
        private string _connectionString;
        private string _tableName;
        private string _databaseType;
        private JArray _jArray;

        public frmTableData(string connectionString, string tableName, string databaseType)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = Lang.previewdatabase;
            _connectionString = connectionString;
            _tableName = tableName;
            _databaseType = databaseType;
            LoadTableData();
        }

        public frmTableData(string tableName, string databaseType, JArray array)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            _jArray = array;
            LoadTableApi();

        }

        public frmTableData(string tableName, SQLiteConnection currentConnection)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            LoadTableDataSqLite(tableName, currentConnection);
        }

        private void LoadTableDataSqLite(string tableName, SQLiteConnection currentConnection)
        {
            try
            {
                if (currentConnection == null || currentConnection.State != ConnectionState.Open)
                {
                    MessageBox.Show("No open SQLite connection available.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string query = $"SELECT * FROM \"{tableName}\"";

                using (SQLiteCommand command = new SQLiteCommand(query, currentConnection))
                {
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        DataTable dataTable = new DataTable();
                        dataTable.Load(reader);
                        dataGridView.DataSource = dataTable;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load data from table '{tableName}': {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadTableApi()
        {
            DataTable table = new DataTable();

            // Dynamically create columns
            foreach (JProperty prop in _jArray[0])
            {
                table.Columns.Add(prop.Name);
            }

            // Add rows
            foreach (JObject row in _jArray)
            {
                DataRow dataRow = table.NewRow();
                foreach (JProperty prop in row.Properties())
                {
                    dataRow[prop.Name] = prop.Value.ToString();
                }
                table.Rows.Add(dataRow);
            }

            dataGridView.DataSource = table;
        }


        private void LoadTableData()
        {
            try
            {
                using (IDbConnection connection = GetDatabaseConnection(_databaseType, _connectionString))
                {
                    connection.Open();
                    string query = $"SELECT * FROM {_tableName}";
                    using (IDbCommand command = connection.CreateCommand())
                    {
                        command.CommandText = query;
                        using (IDataReader reader = command.ExecuteReader())
                        {
                            DataTable dataTable = new DataTable();
                            dataTable.Load(reader);
                            dataGridView.DataSource = dataTable;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load table data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private IDbConnection GetDatabaseConnection(string databaseType, string connectionString)
        {
            switch (databaseType.ToLower())
            {
                case "sql":
                    return new SqlConnection(connectionString);
                case "mysql":
                    return new MySqlConnection(connectionString);
                //case "postgresql":
                //    return new NpgsqlConnection(connectionString);
                //case "oracle":
                //    return new OracleConnection(connectionString);
                default:
                    throw new ArgumentException("Unsupported database type.");
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
 
    }
}