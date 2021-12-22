using System;
using System.Collections.Generic;
class Customer
{
    public string Name {get; set; }
    public string Surname {get; set; }
    public string Phone {get; set; }
    public string Address {get;set; }
    public string Email {get; set; } 
    public int CustomerID {get; set; }
    private static int LoyaltyPoints = 100;
    public Customer (string customername, string surname, string phone, string address, string email)
    {
      CustomerID += 1;
      Name = customername;
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
    public Product (int productname, int price, int quantity)
    {
       ProductID += 1;
       ProductName = productname;
       Price = price;
       Quantity = quantity;
    }
}
class Sale
{
    public int CustomerID;
    public int ProductID;
    public int Quantity;
    public bool Delivery;
    public bool SpendLoyalty;
    public Sale(int customerId, int productId, int quantity)
    {
        CustomerID = customerId;
        ProductID = productId;
        Quantity = quantity;

    }

}

class Store
{
    private List<Customer> _customer;
    private List<Product> _product;
    public Store()
    {
        _customer = new List<Customer>();
        _product = new List<Product>();
    }
    public void AddProduct(int name, int price, int quantity)
    {
        Product newProduct = new Product(name,price,quantity);
        _product.Add(newProduct);
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