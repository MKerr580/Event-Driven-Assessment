using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Manager
/// </summary>
public class Manager:User
{

    public Manager(string pin)
    {
        this.pin = pin;
    }
    private string pin;
    public string getpin()
    {
        return pin;
    }
    public string setpin(string pin)
    {
        pin = this.pin;
        return pin;
    }
    public Manager()
    {
    }
    public Manager(string id,string firstname,string surname,string address,string number,string email,string pin): base (id,firstname,surname,address,number,email)
    {
        this.pin = pin;
    }
}