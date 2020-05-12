using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace Inventory.App_Code
{ 
    public class clsSql
{

    protected SqlConnection Connection = new SqlConnection("Server = .\\SQLEXPRESS; Initial catalog = mydb; Integrated Security = sspi;");
    protected SqlCommand Command;
    protected SqlDataReader Reader;
    protected String Query;
    protected Int32 RowsAffected;
    public string Message { get; set; }
    protected Boolean FlagSuccess;

    public Boolean OpenConnection()
    {
        FlagSuccess = false;
        try
        {
            if (Connection.State == ConnectionState.Open)
            {
                FlagSuccess = true;
            }
            else
            {
                Connection.Open();
                if (Connection.State == ConnectionState.Open)
                    FlagSuccess = true;
                else
                    FlagSuccess = false;
            }
        }
        catch (Exception ex)
        {
            FlagSuccess = false;
            Message = ex.Message.ToString();
        }
        return FlagSuccess;
    }

    public Boolean CloseConnection()
    {
        FlagSuccess = false;
        try
        {
            if (Connection.State == ConnectionState.Open)
            {
                Connection.Close();
                if (Connection.State == ConnectionState.Closed)
                    FlagSuccess = true;
                else
                    FlagSuccess = false;
            }
            else
            {
                FlagSuccess = true;
            }
        }
        catch (Exception ex)
        {
            FlagSuccess = false;
            Message = ex.Message.ToString();
        }
        return FlagSuccess;
    }
    public Int32 ExecuteNonQuery(SqlCommand _Command)
    {
        try
        {
            this.Command = _Command;
            this.Command.Connection = this.Connection;
            if (OpenConnection())
            {
                RowsAffected = Command.ExecuteNonQuery();
            }
            if (RowsAffected > 0)
            {
                Message = "Success";
            }
        }
        catch (Exception ex)
        {
            FlagSuccess = false;
            Message = "Error :" + ex.Message.ToString();
        }
        finally
        {
            CloseConnection();
        }
        return RowsAffected;
    }
}
}