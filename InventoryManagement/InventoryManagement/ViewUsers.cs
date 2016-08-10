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
    public partial class ViewUsers : Form
    {
        string ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\vadla\Documents\GitHub\Database-Team10\InventoryManagement\InventoryManagement\InventoryDB.mdf;Integrated Security=True";

        BindingSource bindingSource1 = new BindingSource();
        SqlDataAdapter dataAdapter = new SqlDataAdapter();

        public ViewUsers()
        {
            InitializeComponent();
        }

        private void ViewUsers_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
            dataGridView1.DataSource = bindingSource1;


        }

        private void button1_Click(object sender, EventArgs e)
        {
            var query = "";
            if (comboBox1.SelectedIndex == 2 || comboBox1.SelectedIndex == 3 || comboBox1.SelectedIndex == 7)
            {
                query = @"SELECT p.SSN,p.FirstName,p.LastName,u.Department,u.SupervisorID,u.UserType FROM PersonalInfo AS p 
                        INNER JOIN Users AS u 
                        ON u.SSN = p.SSN
                        WHERE p." + comboBox1.SelectedItem.ToString().Replace(" ", "") + " = '" + textBox1.Text + "'";

            }
            else
            {
                query = @"SELECT p.SSN,p.FirstName,p.LastName,u.Department,u.SupervisorID,u.UserType FROM PersonalInfo AS p 
                        INNER JOIN Users AS u 
                        ON u.SSN = p.SSN
                        WHERE u." + comboBox1.SelectedItem.ToString().Replace(" ", "") + " = '" + textBox1.Text + "'";
            }

            if (comboBox1.SelectedIndex == 0)
                query = "SELECT p.SSN,p.FirstName,p.LastName,u.Department,u.SupervisorID,u.UserType FROM Users AS u INNER JOIN PersonalInfo AS p ON u.SSN = p.SSN";
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
