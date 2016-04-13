using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_OpretKategori : System.Web.UI.Page
{
    KategoriFac objKat = new KategoriFac();
    DataTable dt = new DataTable(); 
 
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["user"] == null)
        {
            Response.Redirect("Login.aspx");
        }

        if (!IsPostBack)
        {
            dt = objKat.HentAlleKat();

            foreach (DataRow dr in dt.Rows)
            {
                litResult.Text += "<tr>";

                litResult.Text += "<td>";
                litResult.Text += dr["Kategori"].ToString();
                litResult.Text += "</td>";

                litResult.Text += "<td>";
                litResult.Text += "<a href='EditKat.aspx?edit=" + dr["KatId"].ToString() + "'><img src='../Gfx/edit.png' alt='rediger' ></a></a>";
                litResult.Text += "</td>";

                litResult.Text += "<td>";
                litResult.Text += "<a href='?del=" + dr["KatId"].ToString() +
                    "' onclick=\"javascript:return confirm('Er du sikker på, at du vil SLETTE denne kategori?')\"><img src='../Gfx/delete.png' alt='slet' ></a>";
                litResult.Text += "</td>";


                litResult.Text += "</tr>";

                if (!string.IsNullOrEmpty(Request.QueryString["del"]))
                {
                    SletKategori();
                }
            }
        }
    }
    protected void btnOpret_Click(object sender, EventArgs e)
    {
        if (txtKategorinavn.Text != "")
        {
            objKat.OpretKategori(txtKategorinavn.Text);
            litMsg.Text = "Kategorien blev oprettet!";
        }
        else
        {
            litMsg.Text = "Der skete en fejl. Kategorien blev ikke oprettet!";
        }

        Response.AddHeader("REFRESH", "2;URL=" + Request.RawUrl);
    }

    protected void SletKategori()
    {
        int sletID = Convert.ToInt32(Request.QueryString["del"]);
        int numRows = objKat.SletKategori(sletID);

        if (numRows > 0)
        {
            Response.Redirect("OpretKategori.aspx");
        }
        else
        {
            litResult.Text = "Noget gik galt, kategori'en blev ikke slettet";
        }
    }

}