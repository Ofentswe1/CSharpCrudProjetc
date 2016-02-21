/********************************************************************************************************
*       AUTHOR   : OFENTSWE RAMOSHAU LEBOGO                                                             *
*       YEAR     : 2015                                                                                 *
*       LANGUAGE : C# PROGRAMMING                                                                       *
*       COPYRIGHT: GNU                                                                                  *
*                                                                                                       *
********************************************************************************************************/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;
using MySql.Web.Security;

namespace Crud_Mysql_project
{
    public partial class DeleteUser : Form
    {
        public DeleteUser()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlAuth connectstring = new MySqlAuth();
                string connectionString = connectstring.connectMysql();

                MySqlConnection connection = new MySqlConnection(connectionString);
                connection.Open();
                string query = "DELETE FROM users WHERE USERNAME='"+textBox1.Text+"'";
                MySqlCommand command = new MySqlCommand(query, connection);

                command.ExecuteNonQuery();
                connection.Close();

                MessageBox.Show("Deleted Successfully");
             
                connection.Open();
                comboBox1.Items.Clear();
                comboBox1.SelectedText = "";
                textBox1.Clear();
                string query1 = "SELECT USERNAME FROM users";
                MySqlCommand command1 = new MySqlCommand(query1, connection);

                command.ExecuteNonQuery();

                MySqlDataReader datareader = command1.ExecuteReader();

                while (datareader.Read())
                {

                    comboBox1.Items.Add(datareader["USERNAME"].ToString());
                }

            }
            catch (MySqlException ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Text = comboBox1.SelectedItem.ToString();
        }

        private void DeleteUser_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            try
            {
                MySqlAuth connectstring = new MySqlAuth();
                string connectionString = connectstring.connectMysql();

                MySqlConnection connection = new MySqlConnection(connectionString);
                connection.Open();
                string query = "SELECT USERNAME FROM users";
                MySqlCommand command = new MySqlCommand(query, connection);

                command.ExecuteNonQuery();

                MySqlDataReader datareader = command.ExecuteReader();

                while (datareader.Read())
                {

                    comboBox1.Items.Add(datareader["USERNAME"].ToString());
                }


            }
            catch (MySqlException ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}
