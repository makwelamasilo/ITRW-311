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

        private void btnSave_Click(object sender, EventArgs e)
        {
            /*//This is my connection string i have assigned the database file address path
            string MyConnection2 = "server=den1.mysql6.gear.host;uid=connection;pwd=@12345;database=connection";
            //This is  MySqlConnection here i have created the object and pass my connection string.
            MySqlConnection MyConn2 = new MySqlConnection(MyConnection2);
            try
            {
                
                //This is my insert query in which i am taking input from the user through windows forms
                string Query = "INSERT INTO connection.student(st_id,name,father_name,age,semester) values('" +this.IdTextBox.Text+ "','" +this.NameTextBox.Text+ "','" +this.FnameTextBox.Text+ "','" +this.AgeTextBox.Text+ "','" +this.SemesterTextBox.Text+ "');";
                
               //This is command class which will handle the query and connection object.
                MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);
                MySqlDataReader MyReader2;
                MyConn2.Open();
                MyReader2 = MyCommand2.ExecuteReader();     // Here our query will be executed and data saved into the database.

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
                while (MyReader2.Read())
                {
                    
                }
                
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            finally
            {
                MyConn2.Close();
            }*/

            string MyConnection2 = "server=den1.mysql6.gear.host;uid=connection;pwd=@12345;database=connection";
            //This is  MySqlConnection here i have created the object and pass my connection string.
            MySqlConnection MyConn2 = new MySqlConnection(MyConnection2);

            MySqlParameter[] pms = new MySqlParameter[5];
            pms[0] = new MySqlParameter("id", MySqlDbType.Int32);
            pms[0].Value = IdTextBox.Text;

            pms[1] = new MySqlParameter("st_name", MySqlDbType.VarChar);
            pms[1].Value = NameTextBox.Text;

            pms[2] = new MySqlParameter("fat_name", MySqlDbType.VarChar);
            pms[2].Value = FnameTextBox.Text;

            pms[3] = new MySqlParameter("age", MySqlDbType.Int32);
            pms[3].Value = AgeTextBox.Text;

            pms[4] = new MySqlParameter("semester", MySqlDbType.Int32);
            pms[4].Value = SemesterTextBox.Text;

            MySqlCommand command = new MySqlCommand();

            command.Connection = MyConn2;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "INSERTION";

            command.Parameters.AddRange(pms);
            
            MyConn2.Open();
            if (command.ExecuteNonQuery() == 1)
            {
                
                MessageBox.Show("Saved");
            }
            else
            {
                MessageBox.Show("Error in saving");
            }
            MyConn2.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //This is my connection string i have assigned the database file address path
            string MyConnection2 = "server=den1.mysql6.gear.host;uid=connection;pwd=@12345;database=connection";
            //This is  MySqlConnection here i have created the object and pass my connection string.
            MySqlConnection MyConn2 = new MySqlConnection(MyConnection2);
            /*try
            {
                //This is my update query in which i am taking input from the user through windows forms and update the record.
                string Query = "UPDATE student SET name='" + this.NameTextBox.Text + "',father_name='" + this.FnameTextBox.Text + "',age='" + this.AgeTextBox.Text + "',semester='" + this.SemesterTextBox.Text + "' WHERE st_id='" + this.IdTextBox.Text + "'";
                MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);
                MySqlDataReader MyReader2;
                MyConn2.Open();
                MyReader2 = MyCommand2.ExecuteReader();
                MessageBox.Show("Data Updated");
                
                MySqlDataAdapter adapter = new MySqlDataAdapter(Query, MyConn2);
                DataSet ds = new DataSet();
                adapter.Fill(ds, "List");
                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = "List";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                MyConn2.Close();//Connection closed here
            }*/

            MySqlParameter[] pms = new MySqlParameter[5];
            pms[0] = new MySqlParameter("id", MySqlDbType.Int32);
            pms[0].Value = IdTextBox.Text;

            pms[1] = new MySqlParameter("st_name", MySqlDbType.VarChar);
            pms[1].Value = NameTextBox.Text;

            pms[2] = new MySqlParameter("fat_name", MySqlDbType.VarChar);
            pms[2].Value = FnameTextBox.Text;

            pms[3] = new MySqlParameter("age", MySqlDbType.Int32);
            pms[3].Value = AgeTextBox.Text;

            pms[4] = new MySqlParameter("semester", MySqlDbType.Int32);
            pms[4].Value = SemesterTextBox.Text;

            MySqlCommand command = new MySqlCommand();

            command.Connection = MyConn2;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "UPDATE";

            command.Parameters.AddRange(pms);

            MyConn2.Open();
            if (command.ExecuteNonQuery() == 1)
            {

                MessageBox.Show("Updated");
            }
            else
            {
                MessageBox.Show("No record found for updating");
            }
            MyConn2.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string MyConnection2 = "server=den1.mysql6.gear.host;uid=connection;pwd=@12345;database=connection";
            MySqlConnection MyConn2 = new MySqlConnection(MyConnection2);
            
            /*try
            {
                MyConn2.Open();
                MySqlDataAdapter adapter = new MySqlDataAdapter(@"SELECT * FROM student", MyConn2);
                MySqlCommand sql = new MySqlCommand(@"DELETE FROM student WHERE st_id='" + this.IdTextBox.Text + "'", MyConn2);
                adapter.DeleteCommand = sql;
                adapter.DeleteCommand.ExecuteNonQuery();
                DataSet ds = new DataSet();
                adapter.Fill(ds, "List");
                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = "List";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                MyConn2.Close();
            }*/

            MySqlParameter[] pms = new MySqlParameter[1];
            pms[0] = new MySqlParameter("ID", MySqlDbType.Int32);
            pms[0].Value = IdTextBox.Text;

            MySqlCommand command = new MySqlCommand();

            command.Connection = MyConn2;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "DELETION";

            command.Parameters.AddRange(pms);

            MyConn2.Open();
            if (command.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Deleted");
            }
            else
            {
                MessageBox.Show("Error in deleting");
            }
            MyConn2.Close();

        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            string MyConnection2 = "server=den1.mysql6.gear.host;uid=connection;pwd=@12345;database=connection";
            MySqlConnection MyConn2 = new MySqlConnection(MyConnection2);
            /*string Query;
            try
            {
                MyConn2.Open();
                if(IdTextBox.Text == "")
                {
                    Query = @"SELECT * FROM student";
                }
                else
                {
                    Query = @"SELECT * FROM student WHERE st_id='" + this.IdTextBox.Text + "'";
                }
                
                MySqlCommand cmd = new MySqlCommand(Query, MyConn2);
                MySqlDataAdapter adapter = new MySqlDataAdapter(Query, MyConn2);
                DataSet ds = new DataSet();
                adapter.Fill(ds, "List");
                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = "List";
                MessageBox.Show("Data fetched!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                MyConn2.Close();
            }*/

            MySqlParameter[] pms = new MySqlParameter[1];
            pms[0] = new MySqlParameter("ID", MySqlDbType.Int32);
            pms[0].Value = IdTextBox.Text;

            MySqlCommand command = new MySqlCommand();

            command.Connection = MyConn2;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "SHOW";
            MyConn2.Open();
            command.Parameters.AddRange(pms);
            DataTable dt = new DataTable();
            dt.Load(command.ExecuteReader());
            dataGridView1.DataSource = dt;
            //command.ExecuteReader();

            /*MySqlDataAdapter adapter = new MySqlDataAdapter("SHOW", MyConn2);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "List");
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "List";
            MessageBox.Show("Data fetched!");*/

            MyConn2.Close();
        }
    }
}
