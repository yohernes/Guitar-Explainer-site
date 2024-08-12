using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;


public partial class login : System.Web.UI.Page
{
    public string str;

    protected void Page_Load(object sender, EventArgs e)
    {

        str = "";
        if (Request.Form["userName"] != null)
        {
            string dbPath = this.MapPath("App_Data/Database.mdf");
            DAL dal = new DAL(dbPath);

            string sqlQuery = "SELECT * FROM users WHERE usr_userName = @userName AND usr_pswd = @pswd";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@userName", Request.Form["userName"].ToString()),
                new SqlParameter("@pswd", Request.Form["pswd"].ToString())
            };

            DataSet ds = dal.GetDataSet(sqlQuery, parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Session["userName"] = Request.Form["userName"];

                DataRow row = ds.Tables[0].Rows[0];

                Session["uMsg"] = "שלום, " + row["usr_firstName"].ToString() + "   <a href=\"Logout.aspx\">ליציאה לחץ כאן </a>";

                Session["isAdmin"] = row["usr_isAdmin"].ToString();

                if (Session["isAdmin"].ToString() == "True")
                    Session["uMsg"] += " <a href= \"Admin.aspx\"> ,לדף הניהול לחץ כאן </a>";

                Response.Redirect("Home.aspx");
            }
            else
            {
                str = "שם משתמש או סיסמה אינם נכונים";
            }
        }


    }
}
