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
    public partial class AddSoftware : Form
    {
        public AddSoftware()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlManager SQLManager;
            SQLManager = new SqlManager(Settings.Default.InventoryDBConnectionString);


            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "INSERT INTO Software (Name, SerialNumber) VALUES (@Name, @SerialNumber)";
            cmd.Parameters.AddWithValue("@Name", textBox1.Text);
            cmd.Parameters.AddWithValue("@SerialNumber", textBox2.Text);

            cmd.CommandType = CommandType.Text;

            SQLManager.Open();
            SQLManager.ExecuteQuery(cmd);
            SQLManager.Close();

            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
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
