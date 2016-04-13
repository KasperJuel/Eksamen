using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_OpretProdukt : System.Web.UI.Page
{
    KategoriFac objKat = new KategoriFac();
    ProduktFac objProdukt = new ProduktFac();

    DataTable dt = new DataTable();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["user"] == null)
        {
            Response.Redirect("Login.aspx");
        }

        dt = objKat.HentAlleKat();

        ddlKat.Items.Add(new ListItem("Vælg Kategori", "0"));

        foreach (DataRow drKat in dt.Rows)
        {
            ddlKat.Items.Add(new ListItem(drKat["Kategori"].ToString(), drKat["KatId"].ToString()));
        }
    }

    protected void btnOpret_Click(object sender, EventArgs e)
    {
        if (fuImg.HasFile)
        {
            string fileTjek = Path.GetExtension(fuImg.FileName);

            // Kontrollere om filen er en billede fil
            if (fileTjek.ToLower() != ".jpg" && fileTjek.ToLower() != ".jpeg" && fileTjek.ToLower() != ".png")
            {
                litMsg.Text = "Filen skal være den rigtig fil-type (jpg eller png)!";
            }
            else
            {
                fuImg.SaveAs(Server.MapPath("../Gfx/Plakater/" + fuImg.FileName));

                objProdukt.OpretProdukt(txtTitel.Text,
                                txtBeskrivelse.Text.Replace(Environment.NewLine, "<br />"),
                                txtStoerelse.Text,
                                Convert.ToInt32(txtPris.Text),
                                Convert.ToInt32(txtAntal.Text),
                                Convert.ToInt32(ddlKat.SelectedValue),
                                fuImg.FileName);

                litMsg.Text = "Produktet blev oprettet!";

                Response.AddHeader("REFRESH", "2;URL=" + Request.RawUrl);
            }
        }
        else
        {
            litMsg.Text = "Du skal vælge et billede!";
        }
    }
}