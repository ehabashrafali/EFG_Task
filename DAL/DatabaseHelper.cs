using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataControl_Task.BLL
{

    //Single tone Dsigen Pattern 
    public class DatabaseHelper
    {
        public SqlConnection connection;
        private static SqlCommand sqlCommand;
        private static SqlDataAdapter adapter;
        private static readonly object Locker = new object();
        private static DatabaseHelper instance = null;

        public static DatabaseHelper Instance
        {
            get
            {
                lock (Locker)
                {
                    if (instance == null)
                    {
                        instance = new DatabaseHelper();
                    }
                    return instance;
                }
            }
        }
        private DatabaseHelper()
        {
            connection = new SqlConnection("Server = 192.168.1.2; Database = Company_SD; User Id = SA; Password = Opaa0100@; Encrypt = False; TrustServerCertificate = true;"); // please put your connection string 
            sqlCommand = new SqlCommand();
            sqlCommand.Connection = connection;
            adapter = new SqlDataAdapter(sqlCommand);
        }

        public void OpenConnection()
        {
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }
        }

        public void CloseConnection()
        {
            if (connection.State != ConnectionState.Closed)
            {
                connection.Close();
            }
        }
    }
}
