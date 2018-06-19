using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Customer
/// </summary>
public class Customer:User
{
    Dictionary<string, Account> Accounts;

   

    public Customer(Dictionary<string, Account> accounts)
    {
        Accounts = accounts;
    }
    Dictionary<string, Account> getAccounts()
    {
        return Accounts;
    }
    Dictionary<string, Account> setAccounts(Dictionary<string, Account> Accounts)
    {
        this.Accounts = Accounts;
        return Accounts;
    }
    //empty constructer
    public Customer()
    {

    }

   

    public Customer(string id, string firstname, string surname, string address, string number, string email) : base(id, firstname, surname, address, number, email)
    {
        this.Accounts= new Dictionary<string, Account> ();
    }

    //creating method to add an account
    public void addAccount(Account newacc)
    {
        //search that accounts doesnt(!) contain the key we passed in
        if (!this.Accounts.ContainsKey(newacc.getaccnumber())) {
            //add the new key to the dictionary
            Accounts.Add(newacc.getaccnumber(), newacc);
        }

    }
    //creating method to check pin
    public Boolean checkPin(string inputpin)
    {
        
        Boolean validpin = false;
        foreach ( KeyValuePair<string,Account> kvp in Accounts)
        {
            Account acc = kvp.Value;
            //check that account pin matches input pin
            if (acc.getpin().Equals(inputpin))
            {
                validpin = true;
            }
                
        }
        return validpin;
    }
    //creating method to get account
    public Account getAccount(string inputpin)
    {
        Account AnAccount = new Account();
        Boolean validpin = false;
        foreach (KeyValuePair<string, Account> kvp in Accounts)
        {
            Account acc = kvp.Value;
            //check that account pin matches input pin
            if (acc.getpin().Equals(inputpin))
            {
                AnAccount = acc;
            }

        }
        return AnAccount;
    }

   
}