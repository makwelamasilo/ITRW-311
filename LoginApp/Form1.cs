﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace LoginApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            PassTextBox.PasswordChar = '•';
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string user = "me";
            int pass = 1234;
            if (user == this.UserTextBox.Text && pass == Convert.ToInt32(this.PassTextBox.Text))
            {
                    MessageBox.Show("Username and password is correct");
                    this.Hide();
                    Form2 f2 = new Form2();
                    f2.ShowDialog();
            
            }
            string MyConnection = "server=den1.mysql6.gear.host;uid=connection;pwd=@12345;database=connection";
            MySqlConnection MyConn = new MySqlConnection(MyConnection);
            try
            {
                MySqlCommand MyCommand = new MySqlCommand("select * from student where user_name='" + this.UserTextBox.Text + "' and password='" + this.PassTextBox.Text + "' ;", MyConn);
                MyConn.Open();
                MySqlDataReader MyReader = MyCommand.ExecuteReader();
                int count = 0;
                while (MyReader.Read())
                {
                    Console.WriteLine(MyReader[count]);
                    count++;
                }
                MessageBox.Show("Username and password is correct");
                this.Hide();
                Form2 f2 = new Form2();
                f2.ShowDialog();
                if (count == 1)
                {
                    MessageBox.Show("Username and password is correct");
                    this.Hide();
                    Form2 fo2 = new Form2();
                    fo2.ShowDialog();
                }
                else if (count > 1)
                {

                    MessageBox.Show("Duplicate Username and passwor.\nAccess denied.");
                }
                else
                {
                    MessageBox.Show("Username and password is incorrect.\nPleas try again.");
                }
                

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                MyConn.Close();
            }
        }
    }
}
