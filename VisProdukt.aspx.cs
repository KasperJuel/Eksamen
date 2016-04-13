using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class VisProdukt : System.Web.UI.Page
{
    ProduktFac objProd = new ProduktFac();

    DataTable dt = new DataTable();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["id"]))
            {
                int _Id = Convert.ToInt32(Request.QueryString["id"]);

                dt = objProd.HentProduktUdFraId(_Id);

                foreach (DataRow dr in dt.Rows)
                {
                    litResult.Text += "<div id='produkt-img-detaljer'><img src='Gfx/Plakater/" + dr["Billede"].ToString()
                + "' alt='" + dr["Titel"].ToString() + "' style='width: 550px;'></div>";

                    litResult.Text += "<div id='produkt-info'>";

                    litResult.Text += "<div class='h2'><h2>" + dr["Kategori"].ToString() + "</h2></div>";
                    litResult.Text += "<h3 style='color:grey'>Titel</h3>";
                    litResult.Text += "<h2>" + dr["Titel"].ToString() + "</h2><br />";
                    litResult.Text += "<p class='italic'>" + dr["Beskrivelse"].ToString() + "</p><br />";
                    litResult.Text += "<p class='italic'>Størrelse: " + dr["Stoerelse"].ToString() + " cm</p><br />";
                    litResult.Text += "<h2 class='italic' style='margin-bottom:20px;'>kr. " + dr["Pris"].ToString() + ",-</h2>";

                    if (Convert.ToInt32(dr["Antal"].ToString()) < 1)
                    {
                        litResult.Text += "<div class='pladser-red'>";
                        litResult.Text += "<p>UDSOLGT</p>";
                        litResult.Text += "</div>";
                    }
                    else if (Convert.ToInt32(dr["Antal"].ToString()) < 4)
                    {
                        litResult.Text += "<div class='pladser-yellow'>";
                        litResult.Text += "<p><a href='Bestilling.aspx?bestillingsid=" + dr["Id"] +"'>BESTIL</a></p>";
                        litResult.Text += "</div>";
                    }
                    else if (Convert.ToInt32(dr["Antal"].ToString()) > 3)
                    {
                        litResult.Text += "<div class='pladser-green'>";
                        litResult.Text += "<p><a href='Bestilling.aspx?bestillingsid=" + dr["Id"] + "'>BESTIL</a></p>";
                        litResult.Text += "</div>";
                    }

                    litResult.Text += "<img src='/gfx/graf.png' alt='antal på lager' />";
                    litResult.Text += "</div>";
                }
            }
        }
    }
}