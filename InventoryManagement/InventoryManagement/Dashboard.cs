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

        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddUser newUserForm = new AddUser();
            newUserForm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AddSoftware newSoftwareForm = new AddSoftware();
            newSoftwareForm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AddPrinter newPrinterForm = new AddPrinter();
            newPrinterForm.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ViewUsers newViewUsers = new ViewUsers();
            newViewUsers.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            AddLaptop newAddLaptop = new AddLaptop();
            newAddLaptop.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            AddComputer newAddComputer = new AddComputer();
            newAddComputer.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            ViewPrinters newViewPrinters = new ViewPrinters();
            newViewPrinters.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            ViewSoftware newViewSoftware = new ViewSoftware();
            newViewSoftware.Show();
        }
    }
}
