using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

public class DAL
{
    private string dbPath;
    private SqlConnection conn;
    private SqlCommand command;
    private SqlDataAdapter adapter;
    private string connString = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = {0}; Integrated Security = True";
    private string connectionString;

    public DAL(string dbPath)
    {
        this.dbPath = dbPath;

        connectionString = string.Format(connString, dbPath);
        conn = new SqlConnection(connectionString);
        command = new SqlCommand(/*Query*/ "", conn);
        adapter = new SqlDataAdapter(command);
    }

    public DAL()
    {
    }

    //Execute SQL query and get a dataet filled with the data
    public DataSet GetDataSet(string strSql)
    {
        DataSet ds = new DataSet();
        command.CommandText = strSql;
        adapter.SelectCommand = command;
        adapter.Fill(ds);
        return ds;
    }
    public DataSet GetDataSet(string strSql, SqlParameter[] parameters)
    {
        DataSet ds = new DataSet();
        command.CommandText = strSql;

        if (parameters != null)
        {
            command.Parameters.Clear(); // Clear previous parameters
            command.Parameters.AddRange(parameters); // Add new parameters
        }

        adapter.SelectCommand = command;
        adapter.Fill(ds);
        return ds;
    }

    //for inserting or deleting rows
    public int UpdateDB(string sqlUpdate)
    {
        int rowsEffected;
        command.CommandText = sqlUpdate;
        conn.Open();
        rowsEffected = command.ExecuteNonQuery();
        conn.Close();
        return rowsEffected;
    }
}

