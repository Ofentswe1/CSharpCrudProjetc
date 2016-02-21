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

namespace Crud_Mysql_project
{
    public partial class Option : Form
    {
        public Option()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void Option_Load(object sender, EventArgs e)
        {
            MySqlAuth connectstring = new MySqlAuth();
            string connectionString = connectstring.connectMysql();


            try
            {

                DataTable datable = new DataTable();


                MySqlConnection connection = new MySqlConnection(connectionString);
                connection.Open();
                string query = "SELECT * FROM users ";
                MySqlCommand command = new MySqlCommand(query, connection);

                MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection);

                command.ExecuteNonQuery();
                adapter.Fill(datable);

                BindingSource bSource = new BindingSource();
                bSource.DataSource = datable;


                dataGridView1.DataSource = bSource;

            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }

      
    }
}
