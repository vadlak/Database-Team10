using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventoryManagement
{
    public partial class AddComputer : Form
    {
        public AddComputer()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlManager SQLManager;

            SQLManager = new SqlManager(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\vadla\Documents\GitHub\Database-Team10\InventoryManagement\InventoryManagement\InventoryDB.mdf;Integrated Security=True");

            SqlCommand insertAsset = new SqlCommand();
            insertAsset.CommandText = "INSERT INTO Assets (SerialNumber) OUTPUT Inserted.AssetID VALUES (@SerialNumber)";
            insertAsset.Parameters.AddWithValue("@SerialNumber", textBox1.Text);

            insertAsset.CommandType = CommandType.Text;

            SqlCommand insertPrinter = new SqlCommand();
            insertPrinter.CommandText = "INSERT INTO Computer (AssetID, OS, FormFactor) VALUES (@AssetID, @OS, @FormFactor)";
            insertPrinter.Parameters.AddWithValue("@OS", textBox1.Text);
            insertPrinter.Parameters.AddWithValue("@FormFactor", textBox2.Text);

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
    }
}
