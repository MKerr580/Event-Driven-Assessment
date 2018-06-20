using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Account
/// </summary>
public class Account
{
    public Account()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    //overloaded constructer
    public Account(string accountnumber, string pin, decimal balance, int swallowed)
    {
        this.accountnumber = accountnumber;
        this.pin = pin;
        this.balance = balance;
        Swallowed = swallowed;
    }

    public Account(string accountNumber, string pin, decimal balance)
    {
        this.accountnumber = accountNumber;
        this.pin = pin;
        this.balance = balance;
    }


    //declaring the private properties
    private  string accountnumber;
    private  string pin;
    decimal balance;
    int Swallowed;

    //getters and setters
    public string getaccnumber()
    {
        return accountnumber;
    }
    public string setaccnumber(string accountnumber)
    {
        this.accountnumber = accountnumber;
        return accountnumber;
    }
   public string getpin()
    {
        return this.pin;
    }
    public string setpin(string pin)
    {
        this.pin = pin;
        return pin;
    }
    public decimal getbalance()
    {
        return balance;
    }
    public decimal setbalance(decimal balance)
    {
        this.balance = balance;
        return balance;
    }
    int getSwallowed()
    {
        return Swallowed;
    }
    int setSwallowed(int Swallowed)
    {
        this.Swallowed = Swallowed;
        return Swallowed;
    }
    //creating additional methods
    public void credit(int amount)
    {
        balance = balance + amount;
    }
    public Boolean debit(int amount)
    {
        Boolean ok;
        if (balance >= amount){
            balance = balance - amount;
            ok = true;
       }
        else
        {
            ok = false;
        }
        return ok;
    }

}