using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Bank
/// </summary>
public class Bank
{
    public Bank()
    {
        //
        // TODO: Add constructor logic here
        //
        loadData();
        DAL2 db = new DAL2();
     
        db.LoadAllPersonData();
        ManagerData = db.GetManagers();
        customerData = db.GetCustomers();
        atmid ="ABANK01" ;
        exchangerate = 1.12m;
        timeused = 0;
        withdrawls = 0;
        totalbal = 10000;
        failedlogins = 0;
        CardsRet = 0;



    }
    //creating public properties

    //creating private fields
    private string atmid;
    private Dictionary<string, Manager> ManagerData;
    private Dictionary<string, Customer> customerData;
    private int CardsRet;
    private int failedlogins;
    private int timeused;
    private decimal exchangerate;
    private decimal totalbal;
    private decimal withdrawls;
    private List<Account> CustomerAccountData;

    //creating getters and setters
    public string getatmid()
    {
        return atmid;
    }
    public string setatmid(string atmid)
    {
        this.atmid = atmid;
        return atmid;
    }
    public Dictionary<string, Manager> getManagerData()
    {
        return ManagerData;
    }
    public Dictionary<string, Manager> setManagerData(Dictionary<string, Manager> ManagerData)
    {
        this.ManagerData = ManagerData;
        return ManagerData;
    }
    public Dictionary<string, Customer> getcustomerData()
    {
        return customerData;
    }
    public Dictionary<string, Customer> setcustomerData(Dictionary<string, Customer> customerData)
    {
        this.customerData = customerData;
        return customerData;
    }
    public int getCardsRet()
    {
        return CardsRet;
    }
    public int setCardsRet(int CardsRet)
    {
        this.CardsRet = CardsRet;
        return CardsRet;
    }
    public int getfailedlogins()
    {
        return failedlogins;
    }
    public int setfailedlogins(int failedlogins)
    {
        this.failedlogins = failedlogins;
        return failedlogins;
    }
    public int gettimeused()
    {
        return timeused;
    }
    public int settimeused(int timeused)
    {
        this.timeused = timeused;
        return timeused;
    }
    public decimal getexchangerate()
    {
        return exchangerate;
    }
    public decimal setexchangerate(decimal exchangerate)
    {
        this.exchangerate = exchangerate;
        return exchangerate;
    }
    public decimal gettotalbal()
    {
        return totalbal; 
    }
    public decimal settotalbal(decimal totalbal)
    {
        this.totalbal = totalbal;
        return totalbal;
    }
    public decimal getwithdrawls()
    {
        return withdrawls;
    }
    public decimal setwithdrawls(decimal withdrawls)
    {
        this.withdrawls = withdrawls;
        return withdrawls;
    }


    //creating additional methods
    public void addCustomer(Customer aCustomer)
    {
        if (!customerData.ContainsKey(aCustomer.getid()))
        {
            customerData.Add(aCustomer.getid(), aCustomer); 
        }

    }
    public decimal getBalance(string login, string inputPin)
    {
        Customer aCustomer;
        Account anAccount;
        decimal balance;
        aCustomer = customerData[login];
        anAccount = aCustomer.getAccount(inputPin);
        balance = anAccount.getbalance();
        return balance;


    }
    public Manager getManager(string userlogin,string userpin)
    {
        Manager aManager=new Manager();
        foreach(KeyValuePair<string, Manager> kvp in ManagerData)
        {
            if((kvp.Key.Equals(userlogin) && kvp.Value.getpin().Equals(userpin)))
            {
                aManager = kvp.Value;
            }
        }
        return aManager;
    }
    public Boolean isValidAccountLogin(string login, string inputPin)
    {
        bool validLogin;
        validLogin = false;
        
        foreach (KeyValuePair<string, Customer> kvp in customerData)
        {
            if (kvp.Key.Equals(login) && kvp.Value.checkPin(inputPin))
            {
                validLogin = true;
            }
        }
        return validLogin;

    }

    public Boolean isValidManagerLogin(string login, string inputPin)
    {
        bool validLogin;
        validLogin = false;
        foreach (KeyValuePair<string, Manager> kvp in ManagerData)
        {
            if (kvp.Key.Equals(login) && kvp.Value.getpin().Equals(inputPin))
            {
                validLogin = true;
            }
        }
        return validLogin;
    }
    public Boolean Withdraw(string login,string inputPin,decimal amount)
    {
        Customer aCustomer;
        Account anAccount;
        Boolean succ;
        aCustomer = customerData[login];
        anAccount = aCustomer.getAccount(inputPin);
        succ = anAccount.debit(Convert.ToInt32(amount));
        if (succ==true){
            withdrawls = amount + withdrawls;
            totalbal = totalbal - amount;
        }
        return succ;
    }
    public void loadData()
    {
        DAL2 db = new DAL2();
        db.LoadAllPersonData();
    }
}