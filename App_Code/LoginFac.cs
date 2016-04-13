using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for LoginFac
/// </summary>
public class LoginFac
{
    DataAccess da = new DataAccess();

    public DataTable HentBruger()
    {
        string strSql = @"SELECT Username, Password FROM tblUser";
        SqlCommand cmd = new SqlCommand(strSql);
        return da.GetData(cmd);
    }

    public string _username { get; set; }
    public string _password { get; set; }

    public DataTable HentBrugerFraLogin()
    {
        string strSql = @"SELECT Id, Username, Password FROM tblUser
                        WHERE Password = @password and Username = @username";
        SqlCommand cmd = new SqlCommand(strSql);
        cmd.Parameters.AddWithValue("@username", _username);
        cmd.Parameters.AddWithValue("@password", _password);
        return da.GetData(cmd);
    }
}