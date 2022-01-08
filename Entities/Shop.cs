using System;
using System.Collections.Generic;

namespace CoreShop.Entities
{
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
    class StaffDB
{
    public string ID {get;set; }
    public string Password {get;set; }
    public bool Admin {get; set;}
    public StaffDB(string id,string password, bool admin)
    {
        ID = id;
        Password = password;
        Admin = admin;
    }
}
    class CustomerDB 
    {
        public string Name {get;set;}
        public string Phone {get;set; }
        public string Address {get;set; }
        public string Email {get; set; }
        public int CustomerID {get;set;}
        public int LoyaltyPoint {get; set; }
        public bool SpendLoyalty;
        public CustomerDB(string name, string phone,
        string address,string email, int customerID)
        {
            CustomerID = customerID;
            Name = name;
            Phone = phone;
            Address = address;
            LoyaltyPoint = 500;
        }
    }
    class ProductDB
    {
        public string ProductName {get; set; }
        public int Price {get; set; }
        public int RemainQuantity {get; set;}
        public int Quantity {get; set;} 
        public int ProductID = 0;
        private static int _numProducts = 0;
        public bool Delivery;
        public ProductDB(string productName, int price, int quantity)
        {
            _numProducts += 1;
            ProductID = _numProducts;
            ProductName = productName;
            Price = price; 
            RemainQuantity = quantity;
            
        }   
    }
    class StoreDB
    {
        private List<ProductDB> _products;
        private List<CustomerDB> _customers;
        private List<StaffDB> _staffs;
        public StoreDB()
        {
            _products = new List<ProductDB> ();
            _customers = new List<CustomerDB> ();
        }
        public void AddStaff(string id, string password, bool admin)
    {
        StaffDB newstaff = new StaffDB(id,password,admin);
        if (admin == true)
        {
           _staffs.Add(newstaff); 
        }
    }
        public void AddCustomerDB(string name,string phone,string address,
        string email,int customerID)
        {
            CustomerDB newCustomer = new CustomerDB(name,phone,address,
            email,customerID);
            _customers.Add(newCustomer);
        }
        public void AddProductDB(string productName, int price, int quantity)
        {
            ProductDB newProduct = new ProductDB(productName,price,quantity);
            _products.Add(newProduct);
        }
        public ProductDB GetProduct(int productID)
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
        public CustomerDB GetCustomer(int customerID)
    {
        for (int i = 0; i < _products.Count; i++)
        {
            if (_customers[i].CustomerID == customerID)
            {
                return _customers[i];
            }
        }
        return null;
    }

    public void ExecuteSale(int customerID,int productID,int quantity,
    bool spendLoyalty, bool delivery)
    {
        CustomerDB customer = GetCustomer(customerID);
        ProductDB product = GetProduct(productID);
        customer.LoyaltyPoint += 10;
        customer.SpendLoyalty = spendLoyalty;
        product.Delivery = delivery;
        product.RemainQuantity -= quantity;
        if (customer.SpendLoyalty == true)
        {
            customer.LoyaltyPoint -= product.Price * 10;
        }
        if (product.Delivery == true)
        {
             product.Price += 20;
        }
        
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
                    _products[i].RemainQuantity.ToString()
                });
            }
            Utility.PrintTable(printCustomerDB);
            Utility.PrintTable(printProductDB);
        }
    }
}