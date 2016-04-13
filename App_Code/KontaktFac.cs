using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for KontaktFac
/// </summary>
public class KontaktFac
{
    DataAccess da = new DataAccess();

    public DataTable HentBeskeder()
    {
        string strSql = @"SELECT * FROM tblKontakt";
        SqlCommand cmd = new SqlCommand(strSql);
        return da.GetData(cmd);
    }

    public int OpretBesked(string navn, string mail, string kommentar)
    {
        string strSql = @"INSERT INTO tblKontakt (Navn, Mail, Kommentar)
                        VALUES (@navn, @mail, @kommentar)";
        SqlCommand cmd = new SqlCommand(strSql);
        cmd.Parameters.AddWithValue("@navn", navn);
        cmd.Parameters.AddWithValue("@mail", mail);
        cmd.Parameters.AddWithValue("@kommentar", kommentar);
        return da.ModifyData(cmd);
    }

    public int SletBesked(int id)
    {
        string strSql = @"DELETE FROM tblKontakt WHERE Id = @id";
        SqlCommand cmd = new SqlCommand(strSql);
        cmd.Parameters.AddWithValue("@id", id);
        return da.ModifyData(cmd);
    }
}