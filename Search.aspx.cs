using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Search : System.Web.UI.Page
{
    SearchFac objSearch = new SearchFac();
    KategoriFac objKat = new KategoriFac();
    ProduktFac objProd = new ProduktFac();

    DataTable dt = new DataTable();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(Request.QueryString["result"]))
        {
            dt = objSearch.Search((Request.QueryString["result"]));

            if (dt.Rows.Count > 0)
            {
                

                foreach (DataRow dr in dt.Rows)
                {
                    litResult.Text += "<div class='prod-oversigt'>";

                    litResult.Text += "<a href='VisProdukt.aspx?id=" + dr["Id"] + "'>"
                            + "<img src='Gfx/Plakater/" + dr["Billede"].ToString() + "' alt='" + dr["Titel"] + "' class='prod-img-oversigt'></a>";

                    litResult.Text += "<div class='left-titel'><p>" + dr["Titel"].ToString() + "</div></p>";

                    litResult.Text += "</div>";
                }

                
            }
            else
            {
                litResult.Text = "<h3>Der desværre var ingen match til dit søgekriterie!</h3>";
            }



        }
    }
}