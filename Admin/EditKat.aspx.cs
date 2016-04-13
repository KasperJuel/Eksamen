using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_EditKat : System.Web.UI.Page
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
            if (!string.IsNullOrEmpty(Request.QueryString["edit"]))
            {
                RedigerKat();
            }
        }
    }

    protected void RedigerKat()
    {
        int editid = Convert.ToInt32(Request.QueryString["edit"]);

        dt = objKat.HentKatUdFraId(editid);

        DataRow dr = dt.Rows[0];

        txtKategorinavn.Text = dr["Kategori"].ToString();
    }

    protected void btnEdit_Click(object sender, EventArgs e)
    {
        objKat._id = Convert.ToInt32(Request.QueryString["edit"]);
        objKat._kat = txtKategorinavn.Text;

        int numRows = objKat.RedigerKat();


        if (numRows > 0)
        {
            litMsg.Text = "Kategorien blev redigeret!";
            Response.AddHeader("REFRESH", "2;URL=" + Request.RawUrl);
        }
        else
        {
            litMsg.Text = "<p style='color: red'>Noget gik galt! Produktet blev ikke ændret.</p>";
        }

        objKat.RedigerKat();

        
    }
}