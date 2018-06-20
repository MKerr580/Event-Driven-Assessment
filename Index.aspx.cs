using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Index : System.Web.UI.Page
{
    Bank BankSys = new Bank();
    string login;
    string pin;
    int timeused = 0;
    int failedlogins = 0;
    int cardsret = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Bank"] == null)
        {
            rblChoose.Items[1].Enabled = false;
        } else
        {
            rblChoose.Items[1].Enabled = true;
        }
    }
    protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
    {

        if (Session["Bank"] == null)
        {
            BankSys = new Bank();

        } else
        {
            BankSys = (Bank)Session["Bank"];
        }

        login = Login1.UserName;
        pin = Login1.Password;

        if (rblChoose.Items[0].Selected == true)
        {
            if (BankSys.isValidManagerLogin(login, pin) == true)
            {


                Session["Bank"] = BankSys;
                Session["login"] = login;
                Session["pin"] = pin;
                Response.Redirect("~/manager/managerHome.aspx");

            } else
            {
                LabelError.Text = "Error : Failed Login";


            }
        }


        if (rblChoose.Items[1].Selected == true) {
            if (BankSys.isValidAccountLogin(login, pin) == true)
            {

                Session["Bank"] = BankSys;
                Session["login"] = login;
                Session["pin"] = pin;
                BankSys.settimeused(timeused = timeused + 1);

                Response.Redirect("~/customer/CustomerHome.aspx");

            }
            else
            {

                BankSys.setfailedlogins(failedlogins++);
                if (BankSys.getfailedlogins() >= 3)
                {
                    BankSys.setCardsRet(cardsret++);
                    rblChoose.Items[0].Enabled = false;
                    LabelError.Text = "Your Card has been Swallowed";
                }
                else
                {
                    LabelError.Text = "Invalid login - try again";
                }
            }
        }
    }
    protected void rblChoose_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rblChoose.Items[1].Selected == true) {
            Login1.Visible = true;
        }else if (rblChoose.Items[0].Selected == true)
        {
            Login1.Visible = true;
        }
    }
 }
