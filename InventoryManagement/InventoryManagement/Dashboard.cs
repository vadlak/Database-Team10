using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace InventoryManagement
{
    public partial class Dashboard : Form
    {
        SqlManager SQLManager;

        public Dashboard()
        {
            InitializeComponent();

        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            SQLManager = new SqlManager(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\vadla\Documents\GitHub\Database-Team10\InventoryManagement\InventoryManagement\InventoryDB.mdf;Integrated Security=True");

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT * FROM Users";
            cmd.CommandType = CommandType.Text;

            SQLManager.Open();
            SqlDataReader temp = SQLManager.ExecuteQuery(cmd);
            SQLManager.Close();

            SQLManager.Open();
            SqlDataReader temp1 = SQLManager.ExecuteQuery("SELECT * FROM Users");
            SQLManager.Close();

        }
    }
}
