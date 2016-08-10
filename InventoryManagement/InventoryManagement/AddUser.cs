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
    public partial class AddUser : Form
    {
        public AddUser()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlManager SQLManager;

            SQLManager = new SqlManager(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\vadla\Documents\GitHub\Database-Team10\InventoryManagement\InventoryManagement\InventoryDB.mdf;Integrated Security=True");

            SqlCommand insertUser = new SqlCommand();
            insertUser.CommandText = "INSERT INTO Users (SSN, UserType, Department, SupervisorID) OUTPUT Inserted.UserID VALUES (@SSN, @UserType, @Department, @SupervisorID)";
            insertUser.Parameters.AddWithValue("@SSN", textBox1.Text);
            insertUser.Parameters.AddWithValue("@UserType", textBox5.Text);
            insertUser.Parameters.AddWithValue("@Department", textBox6.Text);
            insertUser.Parameters.AddWithValue("@SupervisorID", textBox7.Text);
            insertUser.CommandType = CommandType.Text;

            SqlCommand insertPersonalInfo = new SqlCommand();
            insertPersonalInfo.CommandText = "INSERT INTO PersonalInfo (UserID, SSN, FirstName, LastName, ZipCode) VALUES (@UserID, @SSN, @FirstName, @LastName, @ZipCode)";
            insertPersonalInfo.Parameters.AddWithValue("@SSN", textBox1.Text);
            insertPersonalInfo.Parameters.AddWithValue("@FirstName", textBox2.Text);
            insertPersonalInfo.Parameters.AddWithValue("@LastName", textBox3.Text);
            insertPersonalInfo.Parameters.AddWithValue("@ZipCode", textBox4.Text);
            insertPersonalInfo.CommandType = CommandType.Text;



            SQLManager.Open();

            var user = SQLManager.ExecuteQuery(insertUser);
            user.Read();
            int userId = user.GetInt32(0);
            user.Close();

            insertPersonalInfo.Parameters.AddWithValue("@UserID", userId);
            var personalInfo = SQLManager.ExecuteQuery(insertPersonalInfo);
            personalInfo.Close();

            SQLManager.Close();

            this.Close();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
