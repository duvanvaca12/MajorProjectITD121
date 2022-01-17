using System;
using System.Collections.Generic;
//using DatabaseShop.Entities;
    
    //class Sale
    //{
    //    public bool Delivery {get; set;}
    //    public bool SpendLoyalty {get; set;}
    //    public int Stock{get; set;}

    //    public Sale(bool delivery,bool spendLoyalty)
    //    {
    //        Delivery = delivery;
    //        SpendLoyalty = spendLoyalty;
    //    }
    //}
    public class StaffDB
    {
        public int ID {get;set; }
        public string Password {get;set; }
        public bool Admin {get; set;}
        public StaffDB(int id,string password, bool admin)
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
        public bool Delivery;
        public CustomerDB(string name, string phone,
        string address,string email, int customerID)
        {
            CustomerID = customerID;
            Name = name;
            Phone = phone;
            Address = address;
            LoyaltyPoint = 460;
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
            _staffs = new List<StaffDB> ();
        }
        public void AddStaff(int id, string password, bool admin)
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

        public StaffDB GetLogin(int Username, string Password)
        {
            for (int i = 0; i < _staffs.Count; i++)
            {
                if (_staffs[i].ID == Username && _staffs[i].Password == Password)
                {
                    return _staffs[i];
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
        customer.Delivery = delivery;
        product.RemainQuantity -= quantity;
        //double TotalPrice;
        double TotalPrice = product.Quantity * product.Price;
        if (customer.SpendLoyalty == true)
        {
            customer.LoyaltyPoint -= 200;
            //customer.LoyaltyPoint -= product.Price * quantity;
        }
        if (customer.Delivery == true)
        {
            TotalPrice += 20;
        }
        
    }
    public bool ValidateLogin(int ID, string password)
    {
        bool state = false;
        StaffDB User = GetLogin(ID, password);
        if (User != null)
        {
            if (User.ID == ID && User.Password == password)
            {
                state = true;
            }
        }
        else
        {
            state = false;
        }
        return state;
    }
    public void DisplayAll()
        {
            List<string[]> printCustomerDB = new List<string[]>();
            List<string[]> printProductDB = new List<string[]>();
            // displays the header row
            printCustomerDB.Add(new string[] {"ID", "Name","Loyalty points"});
            printProductDB.Add(new string[] {"ID", "Product name","Price","In stock"});

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

class Program
{
    static void Main(string[] args)
    {

        StoreDB store = new StoreDB();
        store.AddCustomerDB("Ted Lasso","345-656-45",
        "Baker 24 street","tedlasso@email.com",1);
        store.AddCustomerDB("Kada Jin","435-356-455",
        "Cook 24 street","kadajin@email.com",2);
        store.AddCustomerDB("May Jay","534-643-852",
        "Salmon 24 street","Mayday@email.com",3);
        store.AddProductDB("Witcher",105,50);
        store.AddProductDB("MW3",80,80);
        store.AddStaff(1,"admin", true);

        // Login part. Use Userinput.CS methods
        while(true)
        {
        Console.WriteLine("=== STAFF ===");
        Console.Write("ID User: ");
        var ID = 0;
        try 
        {
            ID = int.Parse(Console.ReadLine());
        }
        catch (Exception)
        {
            Console.WriteLine("The number must be in an integer");
            return;
        }
        Console.Write("Password: ");
        var password = Console.ReadLine();
        var login = store.ValidateLogin(ID, password);
        if (login == true) 
        {
            store.ExecuteSale(1,1,2,true,true);
            store.ExecuteSale(2,2,5,true,false);
            store.DisplayAll();
            Console.ReadLine();
        }
        else
        {
            Console.WriteLine("User not found try again");
        }
        }
    }
}

