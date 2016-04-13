using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_ProduktOversigt : System.Web.UI.Page
{
    ProduktFac objProd = new ProduktFac();
    DataTable dt = new DataTable();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["user"] == null)
        {
            Response.Redirect("Login.aspx");
        }

        dt = objProd.HentAlleProdukterMedAlt();

        if (!IsPostBack)
        {
            foreach (DataRow dr in dt.Rows)
            {
                litResult.Text += "<tr>";

                litResult.Text += "<td>";
                litResult.Text += dr["Titel"].ToString();
                litResult.Text += "</td>";

                litResult.Text += "<td>";
                litResult.Text += dr["Stoerelse"].ToString();
                litResult.Text += "</td>";

                litResult.Text += "<td>";
                litResult.Text += dr["Pris"].ToString();
                litResult.Text += "</td>";

                litResult.Text += "<td>";
                litResult.Text += dr["Antal"].ToString();
                litResult.Text += "</td>";

                litResult.Text += "<td>";
                litResult.Text += "<img src='../Gfx/Plakater/" + dr["Billede"].ToString() + "' style='width: 80px;'>";
                litResult.Text += "</td>";

                litResult.Text += "<td>";
                litResult.Text += dr["Kategori"].ToString();
                litResult.Text += "</td>";

                litResult.Text += "<td>";
                litResult.Text += "<a href='EditProdukt.aspx?editprod=" + dr["Id"].ToString() + "'><img src='../Gfx/edit.png' alt='rediger' ></a>";
                litResult.Text += "</td>";

                litResult.Text += "<td>";
                litResult.Text += "<a href='?del=" + dr["Id"].ToString() +
                    "' onclick=\"javascript:return confirm('Er du sikker på, at du vil SLETTE dette produkt?')\"><img src='../Gfx/delete.png' alt='slet' ></a>";
                litResult.Text += "</td>";

                litResult.Text += "</tr>"; 
            }

            if (!string.IsNullOrEmpty(Request.QueryString["del"]))
            {
                SletProdukt();
            }
        }
    }

    protected void SletProdukt()
    {
        int sletID = Convert.ToInt32(Request.QueryString["del"]);
        //DataRow dr = dt.Rows[0];
        //string billedenavn = dr["Billede"].ToString();

        //File.Delete(Server.MapPath("../Gfx/Plakater/" + billedenavn));
        int numRows = objProd.SletProdukt(sletID);

        if (numRows > 0)
        {
            Response.Redirect("ProduktOversigt.aspx");
        }
        else
        {
            litResult.Text = "Noget gik galt, produktet blev ikke slettet!";
        }
    }
}