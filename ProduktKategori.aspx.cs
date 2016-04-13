using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ProduktKategori : System.Web.UI.Page
{
    ProduktFac objProd = new ProduktFac();
    DataTable dt = new DataTable();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["katid"]))
            {
                int _catId = Convert.ToInt32(Request.QueryString["katid"]);

                dt = objProd.HentProdukterUdFraKategori(_catId);

                DataRow drtest = dt.Rows[0];
                litResult.Text = "<div class='h2'><h2>" + drtest["Kategori"].ToString() + "</h2></div>";


                    foreach (DataRow dr in dt.Rows)
                    {
                        litResult.Text += "<div class='prod-oversigt'>";
                        litResult.Text += "<a href='VisProdukt.aspx?id=" + dr["Id"] + "'>" 
                                + "<img src='Gfx/Plakater/" + dr["Billede"].ToString() 
                                + "' alt='" + dr["Titel"] + "' class='prod-img-oversigt'></a>";
                        litResult.Text += "<div class='left-titel'><p>" + dr["Titel"].ToString() 
                                + "</div><div class='right-price'>" + dr["Pris"] + ",-" + "</p></div>";
                        litResult.Text += "</div>";
                        
                    } 

            }
        }


    }
}