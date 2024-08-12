using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;


public partial class Admin : System.Web.UI.Page
{
    protected string str;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["isAdmin"].ToString() != "True")
            Response.Redirect("Unauthorized.aspx");
       
        generateAdminTable();
    }
    private void generateAdminTable()
    {
        string dbPath = this.MapPath("App_Data/Database.mdf");
        DAL dal = new DAL(dbPath);
        string sqlQuery;

        // Code for delete or edit a user ////////////////////////////////
        if (Request.Form["delete"] != null)
        {
            sqlQuery = "DELETE FROM Users WHERE usr_userName = '" + Request.Form["userName"] + "'";
            dal.UpdateDB(sqlQuery);
        }
        else if (Request.Form["setAdmin"] != null)
        {
            sqlQuery = "UPDATE Users SET usr_isAdmin=1 WHERE usr_userName = '" + Request.Form["userName"] + "'";
            dal.UpdateDB(sqlQuery);
        }
        else if (Request.Form["resetAdmin"] != null)
        {
            sqlQuery = "UPDATE Users SET usr_isAdmin=0 WHERE usr_userName = '" + Request.Form["userName"] + "'";
            dal.UpdateDB(sqlQuery);
        }

        //////////////////////////////////////////////////////////////////

        //Creating the users table
        sqlQuery =
            "SELECT * FROM Users";

        DataSet ds = dal.GetDataSet(sqlQuery);
        DataTable dt = ds.Tables[0];

        str += "<table dir=\"ltr\">\n";

        for (int j = 0; j < dt.Columns.Count; j++)
        {
            str += "\t\t<th>";
            str += dt.Columns[j];
            str += "</th>\n";
        }

        for (int i = 0; i < dt.Rows.Count; i++)
        {
            DataRow row = dt.Rows[i];

            str += "\t<tr>\n";

            for (int j = 0; j < dt.Columns.Count; j++)
            {
                str += "\t\t<td>";

                str += row[j];
                str += "</td>\n";
            }

            // Code for adding a column for delete/set buttons //////////////////
            str += "\t<td>\n";
            str += "\t\t<form method=\"post\" action=\"Admin.aspx\">\n";
            str += "\t\t\t<input type=\"hidden\" id=\"userName\" name=\"userName\" value=\"" + row["usr_userName"].ToString() + "\"/>\n";
            str += "\t\t\t<input type=\"submit\" name=\"delete\" value=\"delete\"/>\n";
            if (row["usr_isAdmin"].ToString() == "False")
            {
                str += "\t\t\t<input type=\"submit\" name=\"setAdmin\" value=\"Set Admin\"/>\n";
            }
            else
            {
                str += "\t\t\t<input type=\"submit\" name=\"resetAdmin\" value=\"Reset Admin\"/>\n";
            }
            str += "\t\t</form>\n";
            str += "\t</td>\n";
            /////////////////////////////////////////////////////////////////////////////////////////////////

            str += "\t</tr>\n";
        }


        str += "</table>";
    }

}