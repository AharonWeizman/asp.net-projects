
using System.Data;
using System.Data.SqlClient;
using System;
using System.Configuration;

public class SQLData
{
    private string GetConnection()
    {
        return @"Data Source=(LocalDB)\v11.0;AttachDbFilename="+AppDomain.CurrentDomain.GetData("DataDirectory").ToString() +"\\dbEvents.mdf;Integrated Security=True";
        //return @"Data Source=.\SQLEXPRESS;AttachDbFilename='" + AppDomain.CurrentDomain.GetData("DataDirectory").ToString() + @"\dbEvents.mdf';Integrated Security=True;User Instance=True";       
    }
    // Insert / Update / Delete Query Execute
    public Boolean ExecuteQuery(string strQuery)
    {
      
            
            //Create SQL connection 
            SqlConnection sqlConn = new SqlConnection(GetConnection());

            //Create Command variable
            SqlCommand cmd = new SqlCommand();

            //Assigne Query
            cmd.CommandText = strQuery;

            //Set Query Type
            cmd.CommandType = CommandType.Text;

            //Set connection to command
            cmd.Connection = sqlConn;

            //Open Connection if Close
            if (sqlConn.State == ConnectionState.Closed)
                sqlConn.Open();

            cmd.ExecuteNonQuery();

            return true;
       
    }

    // Select Query
    public DataTable GetData(string strQuery)
    {
       
            //Create SQL connection 
            SqlConnection sqlConn = new SqlConnection(GetConnection());

            //DataTable   
            DataTable dtData = new DataTable();

            //Create Command variable
            SqlCommand cmd = new SqlCommand();

            //Assigne Query
            cmd.CommandText = strQuery;

            //Set Query Type
            cmd.CommandType = CommandType.Text;

            //Set connection to command
            cmd.Connection = sqlConn;

            //Open Connection if Close
            if (sqlConn.State == ConnectionState.Closed)
                sqlConn.Open();




            // create data adapter
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            // this will query your database and return the result to your datatable
            da.Fill(dtData);

            //Close Connection
            if (sqlConn.State == ConnectionState.Open)
                sqlConn.Close();

            //Close Adapter                
            da.Dispose();

            return dtData;
      
    }

}