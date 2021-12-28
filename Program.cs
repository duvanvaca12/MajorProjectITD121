using System;
using System.Collections.Generic;

class Sale
{
    public bool Delivery {get; set;}
    public bool SpendLoyalty{get; set;}
    public int Stock{get;set; }

    public Sale(bool delivery,bool spendLoyalty)
    {
        Delivery = delivery;
        SpendLoyalty = spendLoyalty;
    }
}
class Staff
{
    public string Input {get;set; }
    public string Password = "admin";
    public bool Admin {get; set;}
}
class Customer 
{
    public string Name {get;set;}
    public string Phone {get;set; }
    public string Address {get;set; }
    public string Email {get; set; }
    public int CustomerID {get;set;}
    public int LoyaltyPoint {get; set; }
    public Customer(string name, string phone,
    string address,string email, int customerID)
    {
        CustomerID = customerID;
        Name = name;
        Phone = phone;
        Address = address;
    }
}
class Product
{
    public string ProductName {get; set; }
    public int Price {get; set; }
    public int Quantity {get; set;} 
    public int ProductID = 0;
    private static int _numProducts = 0;
    public Product(string productName, int price, int quantity)
    {
        _numProducts += 1;
        ProductID = _numProducts;
        ProductName = productName;
        Price = price; 
        Quantity = quantity;
         
    }   
}

class Store
{
    private List<Product> _products;
    private List<Customer> _customers;
    public Store()
    {
        _products = new List<Product> ();
        _customers = new List<Customer> ();
    }
    public void AddCustomer(string name,string phone,string address,
    string email,int customerID)
    {
        Customer newCustomer = new Customer(name,phone,address,
        email,customerID);
        _customers.Add(newCustomer);
    }
    public void AddProduct(string productName, int price, int quantity)
    {
        Product newProduct = new Product(productName,price,quantity);
        _products.Add(newProduct);
    }
    public Product GetProduct(int productID,int quantity)
    {
        for (int i = 0; i < _products.Count; i++)
        {
            if (_products[i].ProductID == productID)
            {
                return _products[i];
            }
        }
        return null;
    }
    public void ExecuteSale(int customerID,int productID,int quantity)
    {
        
    }
    public void DisplayAll()
    {
        List<string[]> printCustomerDB = new List<string[]>();
        List<string[]> printProductDB = new List<string[]>();
        // displays the header row
        printCustomerDB.Add(new string[] {"ID", "Name","Loyalty points"});
        printProductDB.Add(new string[] {"ID", "Product name","In stock"});

        // add details of all books to the print data
        for (int i = 0; i < _customers.Count; i++)
        {
            printCustomerDB.Add(new string[] {
                _customers[i].CustomerID.ToString(),
                _customers[i].Name,
                _customers[i].LoyaltyPoint.ToString()
            });
        }
        for (int i = 0; i < _products.Count; i++)
        {
            printProductDB.Add(new string[] {
                _products[i].ProductID.ToString(),
                _products[i].ProductName,
                _products[i].Price.ToString(),
                _products[i].Quantity.ToString()
            });
        }
        Utility.PrintTable(printCustomerDB);
        Utility.PrintTable(printProductDB);
}
class Program
{
    static void Main(string[] args)
    {
        Store store = new Store();
        store.AddCustomer("Ted Lasso","345-656-45",
        "Baker 24 street","tedlasso@email.com",1);
        store.AddProduct("Mario",105,30);
        store.AddProduct("Zelda",80,80);
        store.DisplayAll();
        Console.ReadLine();
    }
}
}
