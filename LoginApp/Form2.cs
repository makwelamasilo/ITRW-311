using System;
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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //This is my connection string i have assigned the database file address path
                //MySqlConnection con = new MySqlConnection();
                string MyConnection2 = "server=den1.mysql6.gear.host;uid=connection;pwd=@12345;database=connection";
                //This is my insert query in which i am taking input from the user through windows forms
                //string Query = "INSERT INTO connection.student(st_id,name,father_name,age,semester) values('" +this.IdTextBox.Text+ "','" +this.NameTextBox.Text+ "','" +this.FnameTextBox.Text+ "','" +this.AgeTextBox.Text+ "','" +this.SemesterTextBox.Text+ "');";
                //This is  MySqlConnection here i have created the object and pass my connection string.
                MySqlConnection MyConn2 = new MySqlConnection(MyConnection2);
               //This is command class which will handle the query and connection object.
                //MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);
                //MySqlDataReader MyReader2;
                MyConn2.Open();
                //MyReader2 = MyCommand2.ExecuteReader();     // Here our query will be executed and data saved into the database.

                MySqlCommand Cmd = new MySqlCommand();
                Cmd.Connection = MyConn2;
                Cmd.CommandText = "new_procedure";
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.Parameters.AddWithValue("@p0", 1);

                try
                {
                    Cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    string Message = ex.Message.ToString();
                }

                MessageBox.Show("Save Data");
                //while (MyReader2.Read())
                {
                    
                }
                MyConn2.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                /*//This is my connection string i have assigned the database file address path
                string MyConnection2 = "server=den1.mysql6.gear.host;uid=connection;pwd=@12345;database=connection";

                //This is my update query in which i am taking input from the user through windows forms and update the record.
                string Query = "update student.studentinfo set idStudentInfo='" + this.IdTextBox.Text + "',Name='" + this.NameTextBox.Text + "',Father_Name='" + this.FnameTextBox.Text + "',Age='" + this.AgeTextBox.Text + "',Semester='" + this.SemesterTextBox.Text + "' where idStudentInfo='" + this.IdTextBox.Text + "';";
                //This is  MySqlConnection here i have created the object and pass my connection string.
                MySqlConnection MyConn2 = new MySqlConnection(MyConnection2);
                MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);
                MySqlDataReader MyReader2;
                MyConn2.Open();
                MyReader2 = MyCommand2.ExecuteReader();
                MessageBox.Show("Data Updated");
                while (MyReader2.Read())
                {

                }
                MyConn2.Close();//Connection closed here*/
            }
            catch (Exception ex)
            {

                //MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                /*string MyConnection2 = "server=den1.mysql6.gear.host;uid=connection;pwd=@12345;database=connection";
                string Query = "delete from student.studentinfo where idStudentInfo='" + this.IdTextBox.Text + "';";
                MySqlConnection MyConn2 = new MySqlConnection(MyConnection2);
                MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);
                MySqlDataReader MyReader2;
                MyConn2.Open();
                MyReader2 = MyCommand2.ExecuteReader();
                MessageBox.Show("Data Deleted");
                while (MyReader2.Read())
                {

                }
                MyConn2.Close();*/
            }
            catch (Exception ex)
            {

               // MessageBox.Show(ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
            try
            {
                string MyConnection2 = "server=den1.mysql6.gear.host;uid=connection;pwd=@12345;database=connection";
                string Query = @"SELECT * from connection.student where st_id='" + this.IdTextBox.Text + "';";
                MySqlConnection MyConn2 = new MySqlConnection(MyConnection2);
                MySqlCommand cmd = new MySqlCommand(Query, MyConn2);
                MySqlDataReader read;
                MyConn2.Open();
                read = cmd.ExecuteReader();
                MessageBox.Show("Data fetched!");
                MySqlDataAdapter adapter = new MySqlDataAdapter(Query, MyConn2);
                DataSet ds = new DataSet();
                adapter.Fill(ds, "student");
                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = "student";
                while (read.Read())
                {
                    
                }
                MyConn2.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}
