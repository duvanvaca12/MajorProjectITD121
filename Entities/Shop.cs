using Database.Shop;
namespace Shop.Core
{
    class CoreShop
    {
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
    class Login
    {
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
    }


}