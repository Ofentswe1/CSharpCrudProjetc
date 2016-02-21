/********************************************************************************************************
*       AUTHOR   : OFENTSWE RAMOSHAU LEBOGO                                                             *
*       YEAR     : 2015                                                                                 *
*       LANGUAGE : C# PROGRAMMING                                                                       *
*       COPYRIGHT: GNU                                                                                  *
*                                                                                                       *
********************************************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crud_Mysql_project
{
    public class MySqlAuth
    {
        public string db_host = "Server=localhost;";
        public string db_name = "Database=mysqlcsharp;";
        public string db_user = "UID=root;";
        public string db_pass = "Password=''";

        public string connectMysql()
        {
            string connector = db_host + db_name + db_user + db_pass;
            return connector;
        }
    }
}
