using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Bestilling : System.Web.UI.Page
{
    ProduktFac objProd = new ProduktFac();
    OrdrerFac objOrd = new OrdrerFac();

    DataTable dt = new DataTable();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["bestillingsid"]))
            {
                int _Id = Convert.ToInt32(Request.QueryString["bestillingsid"]);

                dt = objProd.HentProduktUdFraId(_Id);

                foreach (DataRow dr in dt.Rows)
                {
                    litResult.Text += "<div id='bestilling-info'>";

                    litResult.Text += "<img src='Gfx/Plakater/" + dr["Billede"].ToString()
+ "' alt='" + dr["Titel"].ToString() + "' style='width: 200px; cursor: pointer;'onclick='goBack()'>";

                    litResult.Text += "<h3 style='color:grey'>Titel</h3>";
                    litResult.Text += "<h2>" + dr["Titel"].ToString() + "</h2><br />";
                    litResult.Text += "<p class='italic'>" + dr["Stoerelse"].ToString() + "</p><br />";
                    litResult.Text += "<h2 class='italic' style='margin-bottom:20px;'>kr. " + dr["Pris"].ToString() + ",-</h2>";

                    litResult.Text += "</div>";
                }
            }
        }

    }
    protected void btnBestil_Click(object sender, EventArgs e)
    {
        objOrd.OpretOrder(txtNavn.Text,
                        txtAdresse.Text,
                        Convert.ToInt32(txtPostnr.Text),
                        txtBy.Text,
                        txtMail.Text,
                        Convert.ToInt32(txtAntal.Text),
                        Convert.ToInt32(Request.QueryString["bestillingsid"]));

        //dt = objProd.HentAntal();
        //DataRow drAntal = dt.Rows[0];

        //int count = Convert.ToInt32(drAntal["Antal"]);
        //int minus = count - Convert.ToInt32(txtAntal.Text);

        //if (count >= 0)
        //{
        //    objProd.UpdateAntal(minus);
        //}
        //else
        //{
        //    litMsg.Text = "Der er ikke nok på lageret!";
        //}



        litMsg.Text = "Din order er blevet oprettet!";


        Response.AddHeader("REFRESH", "5;URL=" + "Tak.aspx");
    }
}