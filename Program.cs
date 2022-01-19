using System;
using System.Collections.Generic;
using Database.Shop;
    
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

// Put this methods on different classes and then assign to the Entities folder
    class StoreDB
    {
        
        private List<ProductDB> _products;
        private List<CustomerDB> _customers;
        private List<StaffDB> _staffs;

        /// <summary>
        /// Make empty lists of the products,staff,customer database
        /// </summary>
        public StoreDB()
        {
            _products = new List<ProductDB> ();
            _customers = new List<CustomerDB> ();
            _staffs = new List<StaffDB> ();
        }


        /// <summary>
        /// Add the information of the staff's database
        /// </summary>
        /// <param name="id">Input the number of the staff's ID</param>
        /// <param name="password">Input the string of the staff's password</param>
        /// <param name="admin">The password that matches staff's password</param>
        public void AddStaff(int id, string password, bool admin)
        {
            StaffDB newstaff = new StaffDB(id,password,admin);
            if (admin == true)
            {
            _staffs.Add(newstaff); 
            }
        }


        /// <summary>
        /// Add new customer's data to the database of customer
        /// </summary>
        /// <param name="name">Input the name of the new customer</param>
        /// <param name="phone">Input the phone number of new customer</param>
        /// <param name="address">Input the address of the new customer</param>
        /// <param name="email">Input the email of the new customer</param>
        /// <param name="customerID">Input the unique number of the new customer's ID</param>
        public void AddCustomerDB(string name,string phone,string address,
        string email,int customerID)
        {
            CustomerDB newCustomer = new CustomerDB(name,phone,address,
            email,customerID);
            _customers.Add(newCustomer);
        }
        
        
        /// <summary>
        /// Add new product's data to the database of product
        /// </summary>
        /// <param name="productName">Input the new product name</param>
        /// <param name="price">Input the price of the product</param>
        /// <param name="quantity">Input the stock of the product</param>
        public void AddProductDB(string productName, int price, int quantity)
        {
            ProductDB newProduct = new ProductDB(productName,price,quantity);
            _products.Add(newProduct);
        }


        /// <summary>
        /// Get the list of product
        /// </summary>
        /// <param name="productID">Input the number of the projectID</param>
        /// <returns>components of the product's list</returns>
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


        /// <summary>
        /// Get the list of customer
        /// </summary>
        /// <param name="customerID"></param>
        /// <returns>The array of the list of customer's DB</returns>
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

    /// <summary>
    /// Brings the list of the staff's database if input username and password is correct
    /// </summary>
    /// <param name="Username">Input the number of staff</param>
    /// <param name="Password">Input the string password of staff</param>
    /// <returns>The database components of staff list</returns>
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



/// <summary>
/// Execute the sale process
/// </summary>
/// <param name="customerID">Input the customer's unique ID</param>
/// <param name="productID">Input the product's unique ID</param>
/// <param name="quantity">Input the number of the product's stocks </param>
/// <param name="spendLoyalty">Spend Loyalty points if true</param>
/// <param name="delivery">add 20$ of the costs if true</param>
    public void ExecuteSale(int customerID,int productID,int quantity,
    bool spendLoyalty, bool delivery)
    {
        
        CustomerDB customer = GetCustomer(customerID);
        ProductDB product = GetProduct(productID);
        customer.SpendLoyalty = spendLoyalty;
        customer.Delivery = delivery;
        product.RemainQuantity -= quantity;
        //double TotalPrice;
        double TotalPrice = product.Quantity * product.Price;
        customer.LoyaltyPoint += product.Price * quantity;
        if (customer.SpendLoyalty == true && customer.LoyaltyPoint > 200)
        {
            customer.LoyaltyPoint -= 200;
            product.Price -= 20;
            //product.Price -= customer.LoyaltyPoint;
            //customer.LoyaltyPoint -= product.Price * quantity;
            
        }
        //customer.LoyaltyPoint += product.Price * quantity;
        if (customer.Delivery == true)
        {
            product.Price += 20;
        }
        
    }


    /// <summary>
    /// Login system that refuses access if ID or password is unmatched
    /// </summary>
    /// <param name="ID">integer ID of staff</param>
    /// <param name="password">string password of staff</param>
    /// <returns>Unable to login if state is false</returns>
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


    /// <summary>
    /// Displays the list of all databases bt table
    /// </summary>
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
        while(true)
        {

            var login = store.ValidateLogin(1, "admin");

            if (login == true) 
            {
            store.ExecuteSale(1,1,2,true,true);
            store.ExecuteSale(2,2,1,false,false);
            store.ExecuteSale(1,1,2,false,true);
            store.DisplayAll();
            Console.ReadLine();
            break;
            }

        }

    // static void PartB()
    // {
            // Console.WriteLine("=== STAFF ===");
            // Console.Write("ID User: ");
    //             // Login part. Use Userinput.CS methods
    //     while(true)
    //     {
    //     Console.WriteLine("=== STAFF ===");
    //     Console.Write("ID User: ");
    //     var ID = 0;
    //     try 
    //     {
    //         ID = int.Parse(Console.ReadLine());
    //     }
    //     catch (Exception)
    //     {
    //         Console.WriteLine("The number must be in an integer");
    //         return;
    //     }
    //     Console.Write("Password: ");
    //     var password = Console.ReadLine();
    //     var login = store.ValidateLogin(ID, password);
    //     if (login == true) 
    //     {
    //         store.ExecuteSale(1,1,2,true,true);
    //         store.ExecuteSale(2,2,5,true,false);
    //         store.DisplayAll();
    //         Console.ReadLine();
    //     }
    //     else
    //     {
    //         Console.WriteLine("User not found try again");
    //     }
    //     }
    }
}

