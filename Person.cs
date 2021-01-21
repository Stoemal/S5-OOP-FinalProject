using System;

abstract public class Person
{
    protected string firstName;
    protected string lastName;
    protected string address;
    protected string phoneNumber;

	public Person(string firstName, string lastName, string address, string phoneNumber)
	{
        this.firstName = firstName;
        this.lastName = lastName;
        this.address = address;
        this.phoneNumber = phoneNumber;
	}

    #region Accesseurs
    public string FirstName
    {
        get { return this.firstName; }
        set { this.firstName = value; }
    }

    public string LastName
    {
        get { return this.lastName; }
        set { this.lastName = value; }
    }

    public string Address
    {
        get { return this.address; }
        set { this.address = value; }
    }

    public string PhoneNumber
    {
        get { return this.phoneNumber; }
        set { this.phoneNumber = value; }
    }

    #endregion Accesseurs

    public override string ToString()
    {
        return "Nom : " + lastName + "\nPrénom : " + firstName + "\nAdresse : " + address + "\nTéléphone : " + phoneNumber;
    }
}
