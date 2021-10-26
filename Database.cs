using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Sept9
{
    public class Database
    {
        private string getConnectionString()
        {
            string connection = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
            return connection;
        }
    
        private SqlConnection OpenDatabase()
        {
            string connection = getConnectionString();
            //variable for database connection
            SqlConnection myConnection;

            myConnection = new SqlConnection(connection);
            //A tunnel for data to flow back and forth
            myConnection.Open();
            return myConnection;
        }

        public DataSet getAllAddresses() 
        {
            SqlConnection myConnection = OpenDatabase();
            string query = "spSelectAllAddresses_wade";

            //Data set is like an array - object that holds lots of other stuff
            DataSet myDataSet = new DataSet();
            SqlCommand myCommand = new SqlCommand(query);
            myCommand.Connection = myConnection;
            myCommand.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter myAdapter = new SqlDataAdapter(myCommand);
            myAdapter.Fill(myDataSet);

            closeDatabase(myConnection);
            return myDataSet;
        }

        private void closeDatabase(SqlConnection myConnection)
        {
            myConnection.Close();
        }

        public void insertNewAddresses(string Address, string City)
        {
            SqlConnection myConnection = OpenDatabase();
            string query = "spInsertNewAddress_wade";
            SqlParameter[] sqlParameters = new SqlParameter[2];
            sqlParameters[0] = new SqlParameter("address", Address);
            sqlParameters[1] = new SqlParameter("city", City);

           

            SqlCommand myCommand = new SqlCommand(query);
            myCommand.Connection = myConnection;
            myCommand.CommandType = CommandType.StoredProcedure;
            myCommand.Parameters.AddRange(sqlParameters);

            myCommand.ExecuteNonQuery();
            closeDatabase(myConnection);
        }
    }
}
