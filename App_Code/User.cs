using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for User
/// </summary>
public class User
{
    public User()
    {

    }
    public User(string id, string firstname, string surname, string address, string number, string email)
    {
        this.id = id;
        this.firstname = firstname;
        this.surname = surname;
        this.address = address;
        this.number = number;
        this.email = email;
    }

    public User(string id, string firstname, string surname, string address, string number, string email, Dictionary<string, Account> accounts) : this(id, firstname, surname, address, number, email)
    {
        this.accounts = accounts;
    }

    private string id;
    private string firstname;
    private string surname;
    private string address;
    private string number;
    private string email;
    private Dictionary<string, Account> accounts;

    public string getid()
    {
        return id;
    }
    public string setid(string id)
    {
        id = this.id;
        return id;
    }
    public string getfirstname()
    {
        return firstname;
    }
    public string setfirstname(string firstname)
    {
        firstname = this.firstname;
        return firstname;
    }
    public string getsurname()
    {
        return surname;
    }
    public string setsurname(string surname)
    {
        surname = this.surname;
        return surname;
    }
    public string getaddress()
    {
        return address;
    }
    public string setaddress(string address)
    {
        address = this.address;
        return address;
    }
    public string getnumber()
    {
        return number;
    }
    public string setnumber(string number)
    {
        number = this.number;
        return number;
    }
    public string getemail()
    {
        return email;
    }
    public string setemail(string email)
    {
        email = this.email;
        return email;
    }
}