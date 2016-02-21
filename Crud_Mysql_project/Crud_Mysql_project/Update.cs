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
    public partial class Update : Form
    {


        public Update()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox2.Text = comboBox1.SelectedItem.ToString();
            
           
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                MySqlAuth connectstring = new MySqlAuth();
                string connectionString = connectstring.connectMysql();

                MySqlConnection connection = new MySqlConnection(connectionString);
                connection.Open();
                string query = "UPDATE  users SET PASSWORD='" + textBox1.Text + "' WHERE USERNAME='" + textBox2.Text + "'";

                if (textBox1.Text == "" || textBox1.Text.Length < 6)
                {
                    MessageBox.Show("Password cannot be less than 6 characters or empty!!");
                }
                else
                {
                    MySqlCommand command = new MySqlCommand(query, connection);

                    command.ExecuteNonQuery();

                    MessageBox.Show("Successfully Updated");
                    textBox1.Clear();
                    textBox2.Clear();
                }
                
            }
            catch (MySqlException ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void Update_Load(object sender, EventArgs e)
        {
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
