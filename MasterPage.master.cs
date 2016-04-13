using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
    KategoriFac objKat = new KategoriFac();
    ProduktFac objProd = new ProduktFac();

    DataTable dt = new DataTable(); 

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            dt = objProd.HentAlleProdukterMedAlt();
            int totalRows = dt.Rows.Count;

            foreach (DataRow drAlle in dt.Rows)
            {
                litOversigt.Text = "<a href='PlakatOversigt.aspx'><h5 style='color: #000;'>Plakater (" + totalRows + ")</h5></a>";
            }

            dt = objProd.HentAlleKategoriFraProdukter();
            int totalKatRows = dt.Rows.Count;

            dt = objKat.HentAlleKat();
            foreach (DataRow drKat in dt.Rows)
            {
                if (dt.Rows.Count > 0)
                {
                    litKategori.Text += "<a href='ProduktKategori.aspx?katid=" + drKat["KatId"] + "'>" + "<h4 style='color: #000; margin-top: 5px; float: left;'>" + drKat["Kategori"];

                    DataTable dtKat = new DataTable();

                    dtKat = objProd.HentProdukterUdFraKategori(Convert.ToInt32(drKat["KatId"]));
                    DataRow drTest = dtKat.Rows[0];

                    int totalprod = dtKat.Rows.Count;

                    litKategori.Text += "<div style='color: grey; float: right;'>(" + totalprod + ")</div></h4></a>";

                }
            } 
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        Response.Redirect("Search.aspx?result=" + txtSearch.Text);
    }
}
