using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ProduktFac
/// </summary>
public class ProduktFac
{
    DataAccess da = new DataAccess();

    public DataTable HentAlleProdukter()
    {
        string strSql = @"SELECT * FROM tblProdukt";
        SqlCommand cmd = new SqlCommand(strSql);
        return da.GetData(cmd);
    }

    public DataTable HentAlleProdukterMedAlt()
    {
        string strSql = @"SELECT Id, Titel, Beskrivelse, Stoerelse, Pris, Antal, Kategori, Billede
                        FROM tblProdukt
                        INNER JOIN tblKategori ON Fk_KategoriId = KatId";
        SqlCommand cmd = new SqlCommand(strSql);
        return da.GetData(cmd);
    }

    public DataTable HentProduktUdFraId(int id)
    {
        string strSql = @"SELECT Id, Titel, Beskrivelse, Stoerelse, Pris, Antal, Fk_KategoriId, Kategori, Billede
                        FROM tblProdukt
                        INNER JOIN tblKategori ON Fk_KategoriId = KatId
                        WHERE Id = @id";
        SqlCommand cmd = new SqlCommand(strSql);
        cmd.Parameters.AddWithValue("@id", id);
        return da.GetData(cmd);
    }

    public DataTable HentSenesteFireProdukter()
    {
        string strSql = @"SELECT TOP 4 Id, Billede FROM tblProdukt ORDER BY Id DESC";
        SqlCommand cmd = new SqlCommand(strSql);
        return da.GetData(cmd);
    }

    public DataTable HentAlleKategoriFraProdukter()
    {
        string strSql = @"SELECT KatId, Kategori, Billede, Pris, Titel FROM tblProdukt
                        INNER JOIN tblKategori ON Fk_KategoriId = KatId
                        ";
        SqlCommand cmd = new SqlCommand(strSql);
        //cmd.Parameters.AddWithValue("@id", _id);
        return da.GetData(cmd);
    }

    public DataTable HentProdukterUdFraKategori(int id)
    {
        string strSql = @"SELECT Id, KatId, Kategori, Billede, Pris, Titel FROM tblProdukt
                        INNER JOIN tblKategori ON Fk_KategoriId = KatId WHERE KatId = @id";
        SqlCommand cmd = new SqlCommand(strSql);
        cmd.Parameters.AddWithValue("@id", id);
        return da.GetData(cmd);
    }

    public DataTable HentAntal()
    {
        string strSql = @"SELECT Antal FROM tblProdukt";
        SqlCommand cmd = new SqlCommand(strSql);
        return da.GetData(cmd);
        
    }

    public string _id { get; set; }

    public DataTable Test()
    {
        string strSql = @"SELECT Id, KatId, Kategori, Billede, Pris, Titel FROM tblProdukt
                        INNER JOIN tblKategori ON Fk_KategoriId = KatId WHERE KatId = @id";
        SqlCommand cmd = new SqlCommand(strSql);
        cmd.Parameters.AddWithValue("@id", _id);
        return da.GetData(cmd);
    }

    public int OpretProdukt(string _titel, string _beskrivelse, string _stoerelse, int _pris, int _antal, int _katid, string _billede)
    {
        string strSql = @"INSERT INTO tblProdukt (Titel, Beskrivelse, Stoerelse, Pris, Antal, Fk_KategoriId, Billede)
                        VALUES (@titel, @beskrivelse, @stoerelse, @pris, @antal, @katid, @billede)";
        SqlCommand cmd = new SqlCommand(strSql);
        cmd.Parameters.AddWithValue("@titel", _titel);
        cmd.Parameters.AddWithValue("@beskrivelse", _beskrivelse);
        cmd.Parameters.AddWithValue("@stoerelse", _stoerelse);
        cmd.Parameters.AddWithValue("@pris", _pris);
        cmd.Parameters.AddWithValue("@antal", _antal);
        cmd.Parameters.AddWithValue("@katid", _katid);
        cmd.Parameters.AddWithValue("@billede", _billede);
        return da.ModifyData(cmd);
    }

    public int _prodid { get; set; }
    public string _titel { get; set; }
    public string _beskrivelse { get; set; }
    public string _stoerelse { get; set; }
    public int _pris { get; set; }
    public int _antal { get; set; }
    public int _katid { get; set; }
    public string _billede { get; set; }

    public int RedigerProdukt()
    {
        string strSql = @"UPDATE tblProdukt SET Titel = @titel, Beskrivelse = @beskrivelse, Stoerelse = @stoerelse,
                        Pris = @pris, Antal = @antal, Fk_KategoriId = @katid, Billede = @billede
                        WHERE Id = @id";
        SqlCommand cmd = new SqlCommand(strSql);
        cmd.Parameters.AddWithValue("id", _prodid);
        cmd.Parameters.AddWithValue("@titel", _titel);
        cmd.Parameters.AddWithValue("@beskrivelse", _beskrivelse);
        cmd.Parameters.AddWithValue("@stoerelse", _stoerelse);
        cmd.Parameters.AddWithValue("@pris", _pris);
        cmd.Parameters.AddWithValue("@antal", _antal);
        cmd.Parameters.AddWithValue("@katid", _katid);
        cmd.Parameters.AddWithValue("@billede", _billede);
        return da.ModifyData(cmd);
    }

    public int UpdateAntal(int antal)
    {
        string strSql = @"UPDATE tblProdukt SET Antal";
        SqlCommand cmd = new SqlCommand(strSql);
        cmd.Parameters.AddWithValue("@antal", antal);
        return da.ModifyData(cmd);
    }

    public int SletProdukt(int id)
    {
        string strSql = @"DELETE FROM tblProdukt WHERE Id = @id";
        SqlCommand cmd = new SqlCommand(strSql);
        cmd.Parameters.AddWithValue("@id", id);
        return da.ModifyData(cmd);
    }
}