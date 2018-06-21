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
        //if the session bank variable is empty
        if (Session["Bank"] == null)
        {
            //disable customer radio button
            rblChoose.Items[1].Enabled = false;
        } else
        {
            //enable customer radio button
            rblChoose.Items[1].Enabled = true;
        }
    }
    protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
    {
        //if session bank is null
        if (Session["Bank"] == null)
        {
            //create a new bank variable
            BankSys = new Bank();

        } else
        {
            //get the bank variable from the session
            BankSys = (Bank)Session["Bank"];
        }
        //filling login and pin information from textbox
        login = Login1.UserName;
        pin = Login1.Password;
        //if first checkbox is chosen
        if (rblChoose.Items[0].Selected == true)
        {
            //testing to see if the login and pin match any stored managers in bank
            if (BankSys.isValidManagerLogin(login, pin) == true)
            {

                //retrieving bank login and pin from the session
                Session["Bank"] = BankSys;
                Session["login"] = login;
                Session["pin"] = pin;
                //puts the user through to the manager home page
                Response.Redirect("~/manager/managerHome.aspx");

            } else
            {
                //display error message
                LabelError.Text = "Error : Failed Login";


            }
        }

        //if second checkbox is chosen
        if (rblChoose.Items[1].Selected == true) {
            //testing to see if the login and pin match any stored customers in bank
            if (BankSys.isValidAccountLogin(login, pin) == true)
            {
                //retrieving bank login and pin from the session
                Session["Bank"] = BankSys;
                Session["login"] = login;
                Session["pin"] = pin;
                BankSys.settimeused(timeused = timeused + 1);
                //puts the user through to the customer home page
                Response.Redirect("~/customer/CustomerHome.aspx");

            }
            else
            {
                failedlogins = BankSys.getfailedlogins();
                //adding 1 to failed logins
                failedlogins = failedlogins + 1;
                //storing failed logins in the bank system
                BankSys.setfailedlogins(failedlogins);
                Session["BankSys"] = BankSys;
                if (BankSys.getfailedlogins() >= 3)
                {
                    //adding 1 to cardsret
                    cardsret = cardsret + 1;
                    //storinng cards retained in the system
                    BankSys.setCardsRet(cardsret);
                    Session["BankSys"] = BankSys;
                    //disabling the customer button
                    rblChoose.SelectedIndex = 0;
                    rblChoose.Items[1].Enabled = false;
                    BankSys.setfailedlogins(0);
                    //displaying error message to the user
                    LabelError.Text = "Your Card has been Swallowed";
                }
                else
                {
                    //displaying error message
                    LabelError.Text = "Invalid login - try again";
                }
            }
        }
    }
    protected void rblChoose_SelectedIndexChanged(object sender, EventArgs e)
    {
        //making it so the login menu appears once ytou click manager or customer radio button
        if (rblChoose.Items[1].Selected == true) {
            Login1.Visible = true;
        }else if (rblChoose.Items[0].Selected == true)
        {
            Login1.Visible = true;
        }
    }
 }
