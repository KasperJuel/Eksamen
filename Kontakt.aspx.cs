using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Kontakt : System.Web.UI.Page
{
    KontaktFac objKon = new KontaktFac();

    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnSend_Click(object sender, EventArgs e)
    {
        objKon.OpretBesked(txtNavn.Text, txtMail.Text, txtKommentar.Text.Replace(Environment.NewLine, "<br />"));

        litMsg.Text = "Tak for din besked!";

        Response.AddHeader("REFRESH", "3;URL=" + Request.RawUrl);
    }
}