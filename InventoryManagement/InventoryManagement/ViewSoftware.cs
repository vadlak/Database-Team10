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
    public partial class ViewSoftware : Form
    {
        string ConnectionString = Settings.Default.InventoryDBConnectionString;

        BindingSource bindingSource1 = new BindingSource();
        SqlDataAdapter dataAdapter = new SqlDataAdapter();

        public ViewSoftware()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            string query = @"SELECT Name, SerialNumber FROM Software 
                    WHERE " + comboBox1.SelectedItem.ToString().Replace(" ", "") + " = '" + textBox1.Text + "'";

            if (comboBox1.SelectedIndex == 0)
                query = "SELECT * FROM Software";

            // Create a new data adapter based on the specified query.
            dataAdapter = new SqlDataAdapter(query, ConnectionString);



            // Create a command builder to generate SQL update, insert, and
            // delete commands based on selectCommand. These are used to
            // update the database.
            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);

            // Populate a new data table and bind it to the BindingSource.
            DataTable table = new DataTable();
            table.Locale = System.Globalization.CultureInfo.InvariantCulture;
            dataAdapter.Fill(table);
            bindingSource1.DataSource = table;

            // Resize the DataGridView columns to fit the newly loaded content.
            dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }

        private void ViewSoftware_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
            dataGridView1.DataSource = bindingSource1;
        }
    }
}
