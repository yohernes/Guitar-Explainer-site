using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class logout : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Session["uName"] = "";
        Session["uMsg"] = "שלום אורח, " + "<a href=\"Login.aspx\">לכניסה לחץ כאן</a>";
        Session["isAdmin"] = "False";
        Session["userName"] = null;
        Response.Redirect("Home.aspx");

    }
}   