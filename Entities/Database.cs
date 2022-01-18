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
}