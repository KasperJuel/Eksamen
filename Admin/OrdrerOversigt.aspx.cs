using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_OrdrerOversigt : System.Web.UI.Page
{
    OrdrerFac objOrd = new OrdrerFac();

    DataTable dt = new DataTable();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["user"] == null)
        {
            Response.Redirect("Login.aspx");
        }

        dt = objOrd.HentOrder();

        foreach (DataRow dr in dt.Rows)
        {
            litResult.Text += "<tr>";

            litResult.Text += "<td>";
            litResult.Text += dr["OrdrerId"].ToString();
            litResult.Text += "</td>";

            litResult.Text += "<td>";
            litResult.Text += dr["Navn"].ToString();
            litResult.Text += "</td>";

            litResult.Text += "<td>";
            litResult.Text += dr["Adresse"].ToString();
            litResult.Text += "</td>";

            litResult.Text += "<td>";
            litResult.Text += dr["Postnr"].ToString();
            litResult.Text += "</td>";

            litResult.Text += "<td>";
            litResult.Text += dr["City"].ToString();
            litResult.Text += "</td>";

            litResult.Text += "<td>";
            litResult.Text += dr["Mail"].ToString();
            litResult.Text += "</td>";

            litResult.Text += "<td>";
            litResult.Text += dr["AntalBestilt"].ToString();
            litResult.Text += "</td>";

            litResult.Text += "<td>";
            litResult.Text += "<img src='../Gfx/Plakater/" + dr["Billede"].ToString() + "' style='width: 80px;'>";
            litResult.Text += "</td>";

            litResult.Text += "<td>";
            litResult.Text += "<a href='?afslut=" + dr["OrdrerId"].ToString() +
                "' onclick=\"javascript:return confirm('Er du sikker på, at du vil Afslutte denne order? Dette vil slette ordren!')\">Afslut</a>";
            litResult.Text += "</td>";

            litResult.Text += "</tr>"; 
        }

        if (!string.IsNullOrEmpty(Request.QueryString["afslut"]))
        {
            AfslutOrder();
        }
    }

    protected void AfslutOrder()
    {
        int sletID = Convert.ToInt32(Request.QueryString["afslut"]);
        int numRows = objOrd.AfslutOrder(sletID);

        if (numRows > 0)
        {
            Response.Redirect("OrdrerOversigt.aspx");
        }
        else
        {
            litResult.Text = "Noget gik galt, order'en blev ikke afsluttet!";
        }
    }
}

