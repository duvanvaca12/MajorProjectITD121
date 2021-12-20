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
    public int ProductName {get; set; }
    public int Price {get; set; }
    public int Quantity {get; set; }
    public int ProductID {get; set;}
    public Product (int name, int price, int quantity)
    {
       //ProductID
       ProductName = name;
       Price = price;
       Quantity = quantity;
    }
}
class Sale
{
    public int CustomerID;
    public int ProductID;
    public int Quantity;
    public Sale(int customerId, int productId, int quantity)
    {
        CustomerID = customerId;
        ProductID = productId;
        Quantity = quantity;

    }

}

class Store
{

}

class Program
{
    static void Main(string[] args)
    {
        //Store store = new Store("Ted","Lasso");
        Console.ReadLine();
        
    }
}