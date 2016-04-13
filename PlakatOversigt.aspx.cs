using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PlakatOversigt : System.Web.UI.Page
{
    KategoriFac objKat = new KategoriFac();
    ProduktFac objProd = new ProduktFac();

    DataTable dt = new DataTable();

    protected void Page_Load(object sender, EventArgs e)
    {
        dt = objKat.HentAlleKat();
        foreach (DataRow drKat in dt.Rows)
        {
            litResult.Text += "<div class='hej'>";
            litResult.Text += "<a href='ProduktKategori.aspx?katid=" + drKat["KatId"] +  "'>" + "<div class='kat-oversigt'><h2>" + drKat["Kategori"].ToString() + "</h2></a></div>";

            litResult.Text += "<div class='test'>";

            dt = objProd.HentProdukterUdFraKategori(Convert.ToInt32(drKat["KatId"]));
            foreach (DataRow drProd in dt.Rows)
            {
                litResult.Text += "<div class='prod-oversigt'>";

                litResult.Text += "<a href='VisProdukt.aspx?id=" + drProd["Id"] + "'>"
                                + "<img src='Gfx/Plakater/" + drProd["Billede"].ToString() + "' class='prod-img-oversigt'></a>";

                litResult.Text += "<div class='left-titel'>" + drProd["Titel"].ToString() 
                                + "</div><div class='right-price'>" + "kr. " + drProd["Pris"].ToString() + ",-" + "</div>";

                litResult.Text += "</div>";
            }

            litResult.Text += "</div>"; //test
            litResult.Text += "</div>"; //hej

            litResult.Text += "<div class='clear'></div>";
        }

    }
}