using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Manager : System.Web.UI.MasterPage
{
    Bank BankSys1;
    private DAL2 DAL;
    private Account a;
    private Customer c;
    private string pin;
    protected void Page_Load(object sender, EventArgs e)
    {
        //
        pin = Session["pin"].ToString();
        if (Session["Bank"] == null)
        {
            Response.Redirect("~/Index.aspx");
        }
        else
        {
            BankSys1 = (Bank)Session["Bank"];
            lblExchRate.Text = "Exchange Rate: " + BankSys1.getexchangerate().ToString();
            lblTimeUsed.Text = "Times Used: "+BankSys1.gettimeused().ToString();
            lblFailedLogins.Text = "Failed logins: "+BankSys1.getfailedlogins().ToString();
            lblCardsret.Text = "Cards Retained: "+BankSys1.getCardsRet().ToString();
            LblTotalBal.Text = "Total Balance: "+BankSys1.gettotalbal().ToString();
            LblAmountWithdrawn.Text = "Amount Withdrawn: "+BankSys1.getwithdrawls().ToString();
        }
    }

    protected void lBtnStartup_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Index.aspx");
    }

    protected void lBtnMaintenance_Click(object sender, EventArgs e)
    {
        if(TxtRate.ToString()!= "")
        {
            decimal exchRate;
            exchRate = Convert.ToDecimal(TxtRate.Text);
            BankSys1.setexchangerate(exchRate);
            Session["Bank"]= BankSys1;
            lblExchRate.Text = "Exchange Rate: " + BankSys1.getexchangerate().ToString();
        }
        else
        {
            lblErrorMSG.Text = "Error";
        }
    }
    protected void lBtnShutdown_Click(object sender,EventArgs e)
    {
        string connStr = ConfigurationManager.ConnectionStrings["Bank"].ConnectionString;

        Bank BankSys1 = (Bank)Session["Bank"];


        //for each loop to insert all Customers accounts in the customers accounts dictionary into the database

        DAL = new DAL2();

        //loop through each each customer
        foreach (KeyValuePair<string, Customer> kvp in BankSys1.getcustomerData())
        {
            c = kvp.Value;
            //loop through cust account
            foreach (KeyValuePair<string, Account> kvp1 in c.getAccounts())
            {
                //run update acc from the DAL
               DAL.updateAccountData(kvp1.Value);

           }
        }
        //setting the session variables to null due to system shutdown
        Session["Bank"] = null;
        Session["pin"] = null;
        Session["login"] = null;

        //Abandoning session and redirecting user the index
        Session.Abandon();
        Response.Redirect("..\\Index.aspx");
    }
    protected void lBtnManagerHome_Click(object sender, EventArgs e)
    {

    }
}
