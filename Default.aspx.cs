using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    ProduktFac objProd = new ProduktFac();
    DataTable dt = new DataTable();

    protected void Page_Load(object sender, EventArgs e)
    {
        dt = objProd.HentSenesteFireProdukter();

        DataRow drFirst = dt.Rows[0];

        litFirst.Text = "<a href='VisProdukt.aspx?id=" + drFirst["Id"] + "'>" + "<img src='Gfx/Plakater/" + drFirst["Billede"].ToString() + "' id='left-img'></a>";

        for (int i = 1; i < 4; i++)
        {
            DataRow drSeneste = dt.Rows[i];

            litContent.Text += "<a href='VisProdukt.aspx?id=" + drSeneste["Id"] + "'>" + "<img src='Gfx/Plakater/" + drSeneste["Billede"].ToString() + "' id='right-img'></a>";
        }

    }
}