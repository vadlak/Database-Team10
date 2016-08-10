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
    public partial class ViewPrinters : Form
    {
        string ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\vadla\Documents\GitHub\Database-Team10\InventoryManagement\InventoryManagement\InventoryDB.mdf;Integrated Security=True";

        BindingSource bindingSource1 = new BindingSource();
        SqlDataAdapter dataAdapter = new SqlDataAdapter();

        public ViewPrinters()
        {
            InitializeComponent();


        }

        private void button1_Click(object sender, EventArgs e)
        {
            var query = "";
            if (comboBox1.SelectedIndex == 1)
            {
                query = @"SELECT a.SerialNumber, p.StaticIP FROM Assets AS a 
                        INNER JOIN Printer AS p 
                        ON a.AssetID = p.AssetID
                        WHERE a." + comboBox1.SelectedItem.ToString().Replace(" ", "") + " = '" + textBox1.Text + "'";

            }
            else
            {
                query = @"SELECT a.SerialNumber, p.StaticIP FROM Printer AS p 
                        INNER JOIN Assets AS a 
                        ON a.AssetID = p.AssetID
                        WHERE p." + comboBox1.SelectedItem.ToString().Replace(" ", "") + " = '" + textBox1.Text + "'";
            }

            if (comboBox1.SelectedIndex == 0)
                query = @"SELECT a.SerialNumber, p.StaticIP FROM Assets AS a
                        INNER JOIN Printer AS p
                        ON a.AssetID = p.AssetID";
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

        private void ViewPrinters_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
            dataGridView1.DataSource = bindingSource1;
        }
    }
}
