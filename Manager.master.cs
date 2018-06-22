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
        //retrieving pin from the session
        pin = Session["pin"].ToString();
        if (Session["Bank"] == null)
        {
            //sends the user back to the main menu
            Response.Redirect("~/Index.aspx");
        }
        else
        {
            //retrieving bank from the session
            BankSys1 = (Bank)Session["Bank"];
            //filling the labels with designated data
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
        //sends the user back to the main menu
        Response.Redirect("~/Index.aspx");
        DAL.retrieveAllAccountData();
    }

    protected void lBtnMaintenance_Click(object sender, EventArgs e)
    {

        //making relevant content box show and the shutdown button invisible
        CPHContent.Visible = true;
        Shutdown.Visible = false;

    }
    protected void lBtnShutdown_Click(object sender,EventArgs e)
    {
        //making relevant text boxes visible and others disappear
        LblAmountWithdrawn.Visible = false;
        lblCardsret.Visible = false;
        lblErrorMSG.Visible = false;
        lblExchRate.Visible = false;
        lblTimeUsed.Visible = false;
        LblTotalBal.Visible = false;
        lBtnExchRate.Visible = false;
        TxtRate.Visible = false;
        lblFailedLogins.Visible = false;
        Shutdown.Visible = true;

    }
    protected void lBtnManagerHome_Click(object sender, EventArgs e)
    {

    }
    protected void lBtnExchRate_Click(object sender,EventArgs e)
    {
        if (TxtRate.ToString() != "")
        {
            decimal exchRate;
            //getting exchrate from the text box and converting it to deciamal
            exchRate = Convert.ToDecimal(TxtRate.Text);
            //set the banks exchangerate to exchrate
            BankSys1.setexchangerate(exchRate);
            //save banksys1 to the session
            Session["Bank"] = BankSys1;
            //display the current exch rate in the box
            lblExchRate.Text = "Exchange Rate: " + BankSys1.getexchangerate().ToString();
        }
        else
        {
            //error message
            lblErrorMSG.Text = "Error";
        }
    }


    protected void Shutdown_Click(object sender, EventArgs e)
    {
        //retrieving bank from the session
        Bank BankSys1 = (Bank)Session["Bank"];
        string pin = (string)Session["pin"];

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
}
