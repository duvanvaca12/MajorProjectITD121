using System.Collections.Generic;

namespace Database.Shop
{
    public class Sale
    {
        public string CustomerName{ get; set; }
        public string ProductName { get; set; }
        public int ProductID { get; set; }
        public int Quantity { get; set; }
        public int TotalPrice { get; set; }
        public int SaleLoyalty { get; set; }
        public int StaffID { get; set; }

        public Sale (string customerName, string productName, int productID, int quantity, int totalPrice, 
        int saleLoyalty, int staffID)
        {
            CustomerName = customerName; 
            ProductName = productName;
            ProductID = productID;
            Quantity = quantity;
            TotalPrice = totalPrice;
            SaleLoyalty = saleLoyalty;
            StaffID = staffID;

        }
    }
    public class Staff
    {

        public int ID { get; set; }
        public string Password { get; set; }
        public bool Admin { get; set; }
        public Staff(int id, string password, bool admin)
        {
            ID = id;
            Password = password;
            Admin = admin;
        }
    }
    class Customer
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public int CustomerID { get; set; }
        public int LoyaltyPoint { get; set; }
        public bool SpendLoyalty;
        public bool Delivery;
        public Customer(string name, string phone,
        string address, string email, int customerID)
        {
            CustomerID = customerID;
            Name = name;
            Phone = phone;
            Address = address;
            LoyaltyPoint = 0;
        }
    }
    class ProductDB
    {
        public string ProductName { get; set; }
        public int Price { get; set; }
        public int RemainQuantity { get; set; }
        public int Quantity { get; set; }
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

        public int StaffActive;
        public int TotalPrice;
        private List<ProductDB> _products;
        private List<Customer> _customers;
        private List<Staff> _staffs;
        private List<Sale> _sales;

        /// <summary>
        /// Make empty lists of the products,staff,customer database
        /// </summary>
        public StoreDB()
        {
            _products = new List<ProductDB>();
            _customers = new List<Customer>();
            _staffs = new List<Staff>();
            _sales = new List<Sale>();
        }


        /// <summary>
        /// Add the information of the staff's database
        /// </summary>
        /// <param name="id">Input the number of the staff's ID</param>
        /// <param name="password">Input the string of the staff's password</param>
        /// <param name="admin">The password that matches staff's password</param>
        public void AddStaff(int id, string password, bool admin)
        {
            Staff newstaff = new Staff(id, password, admin);
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
        public void AddCustomerDB(string name, string phone, string address,
        string email, int customerID)
        {
            Customer newCustomer = new Customer(name, phone, address,
            email, customerID);
            _customers.Add(newCustomer);
        }

        public void AddSaleDB(string customerName, string productName, int productID, int quantity,
        int totalPrice, int saleLoyalty, int staffID)
        {
            Sale newSale = new Sale(customerName, productName, productID, quantity, totalPrice, 
            saleLoyalty, staffID);
            _sales.Add(newSale);
        }


        /// <summary>
        /// Add new product's data to the database of product
        /// </summary>
        /// <param name="productName">Input the new product name</param>
        /// <param name="price">Input the price of the product</param>
        /// <param name="quantity">Input the stock of the product</param>
        public void AddProductDB(string productName, int price, int quantity)
        {
            ProductDB newProduct = new ProductDB(productName, price, quantity);
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
        public Customer GetCustomer(int customerID)
        {
            for (int i = 0; i < _customers.Count; i++)
            {
                if (_customers[i].CustomerID == customerID)
                {
                    return _customers[i];
                }
            }
            return null;
        }
        public Staff GetStaff(int staffID)
        {
            for (int i = 0; i < _staffs.Count; i++)
            {
                if (_staffs[i].ID == staffID)
                {
                    return _staffs[i];
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
        public Staff GetLogin(int Username, string Password)
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
        public void ExecuteSale(int customerID, int productID, int quantity,
        bool spendLoyalty, bool delivery)
        {
            
            Customer customer = GetCustomer(customerID);
            ProductDB product = GetProduct(productID);
            Staff staff = GetStaff(StaffActive);
            customer.SpendLoyalty = spendLoyalty;
            customer.Delivery = delivery;
            product.RemainQuantity -= quantity;
            TotalPrice = product.Price * quantity;
            int pointsEarned = 0;
            //customer.LoyaltyPoint += product.Price * quantity;
            if (customer.SpendLoyalty == true && customer.LoyaltyPoint >= 200)
            {
                customer.LoyaltyPoint -= 200;
                TotalPrice -= 20;
                pointsEarned += product.Price * quantity - 20;
                customer.LoyaltyPoint = pointsEarned;

            }
            else
            {
                pointsEarned += product.Price * quantity;
                customer.LoyaltyPoint = pointsEarned;
            }
            if (customer.Delivery == true)
            {
                TotalPrice += 20;
            }
            AddSaleDB(customer.Name, product.ProductName, productID, quantity, TotalPrice,
            pointsEarned, staff.ID);
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
            StaffActive = ID;
            Staff User = GetLogin(ID, password);
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
            printCustomerDB.Add(new string[] { "ID", "Name", "Loyalty points" });
            printProductDB.Add(new string[] { "ID", "Product name", "Price", "In stock" });

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