using InventoryManagement.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventoryManagement
{
    public partial class AddLaptop : Form
    {
        public AddLaptop()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlManager SQLManager;

            SQLManager = new SqlManager(Settings.Default.InventoryDBConnectionString);


            SqlCommand insertAsset = new SqlCommand();
            insertAsset.CommandText = "INSERT INTO Assets (SerialNumber) OUTPUT Inserted.AssetID VALUES (@SerialNumber)";
            insertAsset.Parameters.AddWithValue("@SerialNumber", textBox2.Text);

            insertAsset.CommandType = CommandType.Text;

            SqlCommand insertPrinter = new SqlCommand();
            insertPrinter.CommandText = "INSERT INTO Laptop (AssetID, WiFiAddress) VALUES (@AssetID, @WiFiAddress)";
            insertPrinter.Parameters.AddWithValue("@WiFiAddress", textBox1.Text);

            insertPrinter.CommandType = CommandType.Text;


            SQLManager.Open();

            SqlDataReader reader = SQLManager.ExecuteQuery(insertAsset);
            reader.Read();
            int assetId = reader.GetInt32(0);
            reader.Close();

            insertPrinter.Parameters.AddWithValue("@AssetID", assetId);
            SQLManager.ExecuteQuery(insertPrinter);

            SQLManager.Close();

            this.Close();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
