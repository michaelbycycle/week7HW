using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sept9
{
    public partial class WebForm10 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                showTable();
            }
        }

        protected void btnSubmit_Click1(object sender, EventArgs e)
        {
            Response.Write("On Button Click");

            //retrieve first name from textbox
            string Address = txtAddress.Text;

            //retrieve last name from textbox
            string City = txtCity.Text;

            Database myDatabase = new Database();
            myDatabase.insertNewAddresses(Address, City);

            //string connection = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();

            //string query = "spInsertNewAddress_wade";
            //SqlParameter[] sqlParameters = new SqlParameter[2];
            //sqlParameters[0] = new SqlParameter("address", Address);
            //sqlParameters[1] = new SqlParameter("city", City);

            //connection string, server name, username, password
            //string connection = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();

            //SqlConnection myConnection;

            //myConnection = new SqlConnection(connection);
            //A tunnel for data to flow back and forth
            //myConnection.Open();

            /*SqlCommand myCommand = new SqlCommand(query);
            myCommand.Connection = myConnection;
            myCommand.CommandType = CommandType.StoredProcedure;
            myCommand.Parameters.Add(new SqlParameter("address", Address));
            myCommand.Parameters.Add(new SqlParameter("city", City));
            myCommand.ExecuteNonQuery();*/

            //myConnection.Close();

            showTable();
        }

        private void showTable()
        {
            //connection string, server name, username, password
            //string connection = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();

            //SqlConnection myConnection;

            //myConnection = new SqlConnection(connection);
            //A tunnel for data to flow back and forth
            //myConnection.Open();

            //can test to see if the connection worked
            // Response.Write(myConnection.State);



            //to execute a SELECT, we need the following
            //string query = "spSelectAllAddresses_wade";

            //Data set is like an array - object that holds lots of other stuff
            //DataSet myDataSet = new DataSet();
            //go and get me information - use this query i just created
            //SqlCommand myCommand = new SqlCommand(query);
            //myCommand.Connection = myConnection;
            //myCommand.CommandType = CommandType.StoredProcedure;

            //use our command and put into our array
            //SqlDataAdapter myAdapter = new SqlDataAdapter(myCommand);
            //myAdapter.Fill(myDataSet);

            //myConnection.Close();

            Database myDatabase = new Database();
            DataSet myDataSet = myDatabase.getAllAddresses();

            gvUsers.DataSource = myDataSet.Tables[0];
            gvUsers.DataBind();
        }
    }
}