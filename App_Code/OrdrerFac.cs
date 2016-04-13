using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for OrdrerFac
/// </summary>
public class OrdrerFac
{
    DataAccess da = new DataAccess();

    public DataTable HentOrder()
    {
        string strSql = @"SELECT OrdrerId, Navn, Adresse, Postnr, City, Mail, Fk_ProduktId, AntalBestilt, Titel, Stoerelse, Pris, Billede FROM tblOrdrer
                        INNER JOIN tblProdukt ON Fk_ProduktId = Id";
        SqlCommand cmd = new SqlCommand(strSql);
        return da.GetData(cmd);
    }

    public int OpretOrder(string navn, string adresse, int postnr, string city, string mail, int antalbestilt, int prodid)
    {
        string strSql;

        strSql = @"INSERT INTO tblOrdrer (Navn, Adresse, Postnr, City, Mail, AntalBestilt, Fk_ProduktId) 
                        VALUES (@navn, @adresse, @postnr, @city, @mail, @bestil, @prodid)";
        SqlCommand cmd = new SqlCommand(strSql);
        cmd.Parameters.AddWithValue("@navn", navn);
        cmd.Parameters.AddWithValue("@adresse", adresse);
        cmd.Parameters.AddWithValue("@postnr", postnr);
        cmd.Parameters.AddWithValue("@city", city);
        cmd.Parameters.AddWithValue("@mail", mail);
        cmd.Parameters.AddWithValue("@bestil", antalbestilt);
        cmd.Parameters.AddWithValue("@prodid", prodid);
        return da.ModifyData(cmd);
    }

    public int AfslutOrder(int id)
    {
        string strSql = @"DELETE FROM tblOrdrer WHERE OrdrerId = @id";
        SqlCommand cmd = new SqlCommand(strSql);
        cmd.Parameters.AddWithValue("@id", id);
        return da.ModifyData(cmd);
    }
}