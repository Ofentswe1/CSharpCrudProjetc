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
//import this method or add reference if not there install mysql connector
using MySql.Data;
using MySql.Data.MySqlClient;
using MySql.Web.Security;

namespace Crud_Mysql_project
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlAuth connectstring = new MySqlAuth();
            string connectionString = connectstring.connectMysql();

            try
            {
                MySqlConnection connection = new MySqlConnection(connectionString);
                connection.Open();
                string query = "SELECT USERNAME,PASSWORD FROM users WHERE USERNAME='"+ textBox1.Text + "' AND PASSWORD='" + textBox2.Text +"'";
                MySqlCommand command = new MySqlCommand(query, connection);

                command.ExecuteNonQuery();

                MySqlDataReader datareader = command.ExecuteReader();

                if (datareader.Read() == true)
                {
                    MessageBox.Show("Connected!");
                    Menu form = new Menu();
                    this.Hide();
                    form.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Username or Password is Incorrect!!!");
                }
               
            }
            catch (MySqlException ex)
            {

                MessageBox.Show(ex.Message);
            }
           
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
