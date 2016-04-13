using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for KategoriFac
/// </summary>
public class KategoriFac
{
    DataAccess da = new DataAccess();

    public DataTable HentAlleKat()
    {
        string strSql = "SELECT KatId, Kategori FROM tblKategori";
        SqlCommand cmd = new SqlCommand(strSql);
        return da.GetData(cmd);
    }

    public DataTable HentAlleKatMedAlt()
    {
        string strSql = "SELECT * FROM tblKategori";
        SqlCommand cmd = new SqlCommand(strSql);
        return da.GetData(cmd);
    }

    public DataTable HentKatUdFraId(int id)
    {
        string strSql = "SELECT KatId, Kategori FROM tblKategori WHERE KatId = @Id";
        SqlCommand cmd = new SqlCommand(strSql);
        cmd.Parameters.AddWithValue("@Id", id);
        return da.GetData(cmd);
    }

    public int OpretKategori(string _kategorinavn)
    {
        string strSql = "INSERT INTO tblKategori (Kategori) VALUES (@kat)";
        SqlCommand cmd = new SqlCommand(strSql);
        cmd.Parameters.AddWithValue("@kat", _kategorinavn);
        return da.ModifyData(cmd);
    }

    public string _kat { get; set; }
    public int _id { get; set; }

    public int RedigerKat()
    {
        string strSql = "UPDATE tblKategori SET Kategori = @kat WHERE KatId = @Id";
        SqlCommand cmd = new SqlCommand(strSql);
        cmd.Parameters.AddWithValue("@kat", _kat);
        cmd.Parameters.AddWithValue("@Id", _id);
        return da.ModifyData(cmd);
    }

    public int SletKategori(int id)
    {
        string strSql = @"DELETE FROM tblKategori WHERE KatId = @id";
        SqlCommand cmd = new SqlCommand(strSql);
        cmd.Parameters.AddWithValue("@id", id);
        return da.ModifyData(cmd);
    }
}