using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;


public partial class Registration : System.Web.UI.Page
{
    protected string data;
    protected string firstName;
    protected string lastName;
    protected string userName;
    protected string idNum;
    protected string phone;
    protected string mail;


    protected void Page_Load(object sender, EventArgs e)
    {

        data = "";
        if (Request.Form["userName"] != null)
        {
            if (Form_Validation())
            {
                string dbPath = this.MapPath("App_Data/Database.mdf");
                DAL dal = new DAL(dbPath);

                string sqlQuery = "SELECT * FROM users WHERE usr_userName = '" + Request.Form["userName"].ToString() + "'";
                DataSet ds = dal.GetDataSet(sqlQuery);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    data = "שם משתמש קיים במערכת. אנא בחר.י שם אחר.";
                    Return_Fields_Value();
                }
                else
                {
                    sqlQuery = "INSERT INTO Users VALUES (" +
                    "'" + Request.Form["firstName"].ToString() + "', " +
                    "'" + Request.Form["lastName"].ToString() + "', " +
                    "'" + Request.Form["userName"].ToString() + "', " +
                    "'" + Request.Form["pswd"].ToString() + "', " +
                    "'" + Request.Form["idNum"].ToString() + "'," +
                    "'" + Request.Form["phone"].ToString() + "'," +
                    "'" + Request.Form["mail"].ToString() + "'," +
                    "'" + Request.Form["gender"].ToString() + "'," +
                    "'" + DateTime.Now.ToString("yyyy-MM-dd") + "'," +
                    "0);";

                    dal.UpdateDB(sqlQuery);
                    Response.Redirect("Login.aspx");
                }
            }
            else
            {
                Return_Fields_Value();
            }
        }
        else
        {
            firstName = "";
            lastName = "";
            userName = "";
            idNum = "";
            phone = "";
            mail = "";
        }
    }



    private void Return_Fields_Value()
    {
        firstName = Request.Form["firstName"].ToString();
        lastName = Request.Form["lastName"].ToString();
        userName = Request.Form["userName"].ToString();
        idNum = Request.Form["idNum"].ToString();
        phone = Request.Form["phone"].ToString();
        mail = Request.Form["mail"].ToString();
    }


    private bool Form_Validation()
    {
        return
            First_Name_Validation() &&
            Last_Name_Validation() &&
            User_Name_Validation() &&
            Password_Validation() &&
            ID_Validation() &&
            Phone_Validation() &&
            Email_Validation()&&
            Gender_Validation()&&
            Approval_Validation();
    }

    private bool First_Name_Validation()
    {
        string fname = Request.Form["firstName"].ToString();

        if (fname.Length < 2)
        {
            data += "שם פרטי חייב להכיל לפחות שני תווים.";
            return false;
        }

        return true;
    }

    private bool Last_Name_Validation()
    {
        string lname = Request.Form["lastName"].ToString();

        if (lname.Length < 2)
        {
            data += "שם משפחה חייב להכיל לפחות שני תווים.";
            return false;
        }

        return true;
    }

    private bool User_Name_Validation()
    {
        string uname = Request.Form["userName"].ToString();

        //קוד שמוודא ששם המשתמש בן 3 ל-8 תווים בלבד
        if (uname.Length < 3 || uname.Length > 8)
        {
            data += "שם משתמש חייב להכיל בין 3 ל-8 תווים.";
            return false;
        }

        return true;
    }

    private bool Password_Validation()
    {
        string pswd = Request.Form["pswd"].ToString();

        //קוד שמוודא שהסיסמה בן 8 ל-10 תווים בלבד
        if (pswd.Length < 8 || pswd.Length > 10)
        {
            data += "הסיסמה חייבת להכיל בין 8 ל-10 תווים";
            return false;
        }

        //קוד שמוודא שהסיסמה מכילה אותיות ומספרים
        bool letterExist = false;
        bool numberExist = false;
        for (int i = 0; i < pswd.Length; i++)
        {
            //בדיקת קיום אותיות
            if (pswd[i] >= 'a' && pswd[i] <= 'z' || pswd[i] >= 'A' && pswd[i] <= 'Z')
                letterExist = true;
            //בדיקת קיום מספרים
            else if (pswd[i] >= '0' && pswd[i] <= '9')
                numberExist = true;
        }
        if (!letterExist || !numberExist)
        {
            data += "הסיסמה חייבת להכיל אותיות ומספרים";
            return false;
        }

        string pswdValidate = Request.Form["pswdValidate"].ToString();

        //קוד לוידוא סיסמה ווידוא סיסמה זהים
        if (pswdValidate != pswd)
        {
            data += "הסיסמה ווידוא הסיסמה אינם זהים";
            return false;
        }

        return true;
    }

    private bool ID_Validation()
    {
        string idNumber = Request.Form["idNum"].ToString();

        //קוד שמוודא רצף של 9 ספרות בדיוק - יש לוודא גודל והכלה של ספרות בלבד
        if (idNumber.Length != 9)
        {
            data += "מספר תעודת זהות חייב להכיל 9 ספרות בלבד.";
            return false;
        }

        //קוד שמוודא שתעודת הזהות מכילה מספרים בלבד
        for (int i = 0; i < idNumber.Length; i++)
        {
            if (!(idNumber[i] >= '0' && idNumber[i] <= '9'))
            {
                data += "מספר תעודת זהות חייב להכיל ספרות בלבד.";
                return false;
            }
        }

        return true;
    }

    private bool Phone_Validation()
    {
        //קוד שמוודא רצף של 10 ספרות בדיוק - יש לוודא גודל והכלה של ספרות בלבד
        //בנוסף הקוד יוודא שהספרה הראשונה היא 0

        string phoneNum = Request.Form["phone"].ToString();

        if (phoneNum.Length != 10)
        {
            data += "מספר הטלפון חייב להכיל 10 ספרות בלבד.";
            return false;
        }

        if (phoneNum[0] != '0')
        {
            data += "מספר טלפון לא תקין. ספרה ראשונה חייבת להיות 0.";
            return false;
        }

        for (int i = 0; i < phoneNum.Length; i++)
        {
            if (!(phoneNum[i] >= '0' && phoneNum[i] <= '9'))
            {
                data += "מספר הטלפון חייב להכיל ספרות בלבד.";
                return false;
            }
        }
        return true;
    }

    private bool Email_Validation()
    {
        //הקוד יוודא את הדברים הבאים:
        //קיים תו @ אחד בלבד שאינו התו הראשון
        //קיים תו . אחד בלבד שאינו התו האחרון והוא נמצא אחרי התו שטרודל
        string mailAddress = Request.Form["mail"].ToString();

        int atPos = -1;
        int dotPos = -1;

        for (int i = 0; i < mailAddress.Length; i++)
        {
            if (mailAddress[i] == '@')
            {
                if (atPos != -1 || i == 0)
                {
                    data += "אימייל לא תקין.";
                    return false;
                }
                atPos = i;
            }
            else if (mailAddress[i] == '.')
            {
                if (dotPos != -1 || atPos == -1 || i == atPos + 1 || i == mailAddress.Length - 1)
                {
                    data += "אימייל לא תקין.";
                    return false;
                }
                dotPos = i;
            }
        }

        if (atPos == -1 || dotPos == -1)
        {
            data += "אימייל לא תקין.";
            return false;
        }

        return true;
    }

    private bool Approval_Validation()
    {
        if (Request.Form["approval"] == null)
        {
            data += "יש לאשר את תקנון האתר.";
            return false;
        }

        return true;
    }
    private bool Gender_Validation()
    {
        if (Request.Form["gender"] == null)
        {
            data += "יש לסמן את מגדרך";
            return false;
        }

        return true;
    }

}