using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for SearchFac
/// </summary>
public class SearchFac
{
    DataAccess da = new DataAccess();

    public DataTable Search(string key)
    {
        string strSql = @"SELECT P.Id AS Id, P.Titel AS Titel, P.Beskrivelse AS Beskrivelse, P.Billede AS Billede
                        FROM tblProdukt AS P                        

                        WHERE P.Titel LIKE @key
                        OR P.Beskrivelse LIKE @key
                        OR P.Billede LIKE @key";           

//                        @"SELECT
//                        K.KatId AS KatId,
//                        K.Kategori AS Kategori,
//                        P.Id AS Id, 
//                        P.Titel AS Titel,
//                        P.Beskrivelse AS Beskrivelse
//
//                        FROM tblKategori AS K
//                        INNER JOIN tblProdukt AS P
//                        ON K.KatId = P.Id
//
//                        WHERE K.Kategori LIKE @key
//                        OR P.Titel LIKE @key
//                        OR P.Beskrivelse LIKE @key";
        SqlCommand cmd = new SqlCommand(strSql);
        cmd.Parameters.AddWithValue("@key", "%" + key + "%");
        return da.GetData(cmd);
    }
}