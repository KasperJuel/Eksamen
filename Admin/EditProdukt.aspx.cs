using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_EditProdukt : System.Web.UI.Page
{
    ProduktFac objProd = new ProduktFac();
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
            if (!string.IsNullOrEmpty(Request.QueryString["editprod"]))
            {
                dt = objKat.HentAlleKat();

                ddlKat.Items.Add(new ListItem("Vælg Kategori", "0"));
                foreach (DataRow drKat in dt.Rows)
                {
                    ddlKat.Items.Add(new ListItem(drKat["Kategori"].ToString(), drKat["KatId"].ToString()));
                }

                RedigerProdukt();
            }
        }
    }

    protected void RedigerProdukt()
    {
        int editid = Convert.ToInt32(Request.QueryString["editprod"]);

        dt = objProd.HentProduktUdFraId(editid);
        DataRow drProd = dt.Rows[0];

        txtTitel.Text = drProd["Titel"].ToString();
        txtBeskrivelse.Text = drProd["Beskrivelse"].ToString();
        txtStoerelse.Text = drProd["Stoerelse"].ToString();
        txtPris.Text = drProd["Pris"].ToString();
        txtAntal.Text = drProd["Antal"].ToString();
        ddlKat.SelectedValue = drProd["Fk_KategoriId"].ToString();
        imgShow.Attributes.Add("src", "../Gfx/Plakater/" + drProd["Billede"].ToString());
    }

    protected void btnEdit_Click(object sender, EventArgs e)
    {
        objProd._prodid = Convert.ToInt32(Request.QueryString["editprod"]);
        objProd._titel = txtTitel.Text;
        objProd._beskrivelse = txtBeskrivelse.Text.Replace("<br />", Environment.NewLine);
        objProd._stoerelse = txtStoerelse.Text;
        objProd._pris = Convert.ToInt32(txtPris.Text);
        objProd._antal = Convert.ToInt32(txtAntal.Text);
        objProd._katid = Convert.ToInt32(ddlKat.SelectedValue);
        objProd._billede = fuImg.FileName;

        int numrows = objProd.RedigerProdukt();

        if (fuImg.HasFile)
        {
            string fileTjek = Path.GetExtension(fuImg.FileName);

            if (fileTjek.ToLower() != ".jpg" && fileTjek.ToLower() != ".jpeg" && fileTjek.ToLower() != ".png")
            {
                litMsg.Text = "<p style='color: red'>Filen SKAL være en billede fil (.jpg, .jpeg eller .png)</p>";
            }
            else
            {
                fuImg.SaveAs(Server.MapPath("../Gfx/Plakater/" + fuImg.FileName));

                objProd._billede = fuImg.FileName;

                Response.Redirect(Request.RawUrl);
            }
        }
        else
        {
            litMsg.Text = "Du skal vælge et billede";
        }
    }
}