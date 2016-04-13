using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DataAccess
/// </summary>
public class DataAccess
{
    SqlConnection SqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["MyCon"].ConnectionString);

    public DataTable GetData(SqlCommand CMD)
    {
        DataSet objDS = new DataSet();

        SqlDataAdapter objDA = new SqlDataAdapter();

        CMD.Connection = SqlCon;
        objDA.SelectCommand = CMD;
        objDA.Fill(objDS);
        return objDS.Tables[0];
    }

    public int ModifyData(SqlCommand CMD)
    {
        CMD.Connection = SqlCon;
        SqlCon.Open();
        int rowsaffected = CMD.ExecuteNonQuery();
        SqlCon.Close();
        return rowsaffected;
    }

    public int InsertDataGetNewId(SqlCommand CMD)
    {
        int newid;
        CMD.Connection = SqlCon;
        SqlCon.Open();
        newid = Convert.ToInt32(CMD.ExecuteScalar());
        SqlCon.Close();
        
        return newid;
    }
}