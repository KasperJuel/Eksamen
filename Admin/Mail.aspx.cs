using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Mail : System.Web.UI.Page
{
    KontaktFac objKon = new KontaktFac();

    DataTable dt = new DataTable();

    protected void Page_Load(object sender, EventArgs e)
    {
        dt = objKon.HentBeskeder();

        foreach (DataRow dr in dt.Rows)
        {
            litResult.Text += "<p><b>Navn: </b>" + dr["Navn"].ToString() + "</p>";
            litResult.Text += "<p><b>Mail: </b>" + dr["Mail"].ToString() + "</p>";
            litResult.Text += "<p><b>Kommentar: </b>" + dr["Kommentar"].ToString() + "</p>";
            litResult.Text += "<a href='?del=" + dr["Id"].ToString() +
                    "' onclick=\"javascript:return confirm('Er du sikker på, at du vil SLETTE denne besked?')\"><img src='../Gfx/delete.png' alt='slet' ></a>";
            litResult.Text += "</td>";
            litResult.Text += "<hr />";
        }

        if (!string.IsNullOrEmpty(Request.QueryString["del"]))
        {
            SletBesked();
        }
    }

    protected void SletBesked()
    {
        int sletID = Convert.ToInt32(Request.QueryString["del"]);

        int numRows = objKon.SletBesked(sletID);

        if (numRows > 0)
        {
            Response.Redirect("Mail.aspx");
        }
        else
        {
            litResult.Text = "Noget gik galt, produktet blev ikke slettet!";
        }
    }
}