using Shop.Core;
namespace Database.Shop

{    
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
            LoyaltyPoint = 0;
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
        
        public List<ProductDB> _products;
        public List<CustomerDB> _customers;
        public List<StaffDB> _staffs;

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
}

}