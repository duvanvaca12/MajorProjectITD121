using System;

class Customer
{
    public string Name {get; set; }
    public string Surname {get; set; }
    public string Phone {get; set; }
    public string Address {get;set; }
    public string Email {get; set; } 
    public int ID {get; set; }
    public Customer (string name, string surname, string phone, string address, string email)
    {
      ID += 1;
      Name = name;
      Surname = surname;
      Phone = phone;
      Address = address;
      Email = email;
    }
}
class Product
{
    public Customer Name {get; set; }
    public int Price {get; set; }
    public int Quality {get; set; }
    public int ProductID {get; set;}
    public Product (Customer name, int price, int quality)
    {
       //ProductID = Customer ID;
       Name = name;
       Price = price;
       Quality = quality;
    }
}
class Sale
{
    public Customer ID;
    public int ProductID;
    public Customer quantity;
    public Sale(Customer id, int productId, Customer quantity)
    {
        ID = id;

    }

}

class Program
{
    static void Main(string[] args)
    {
        //Store store = new Store("Ted","Lasso");
        Console.ReadLine();
        
    }
}