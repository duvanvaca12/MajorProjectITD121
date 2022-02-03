using System;
using Database.Shop;

class Program
{
    static Store store = new Store();
    static Staff staff = new Staff(1,"admin","Dane",true);
    static void Main(string[] args)
    {
      if (Login())
        {
            bool exit = false;
            // program repeats until exit is true
            while (exit == false)
            {
                // display welcome message
                Console.Clear();
                Console.WriteLine("=== Main Menu ===");

                // get menu choice from user
                string[] options = new string[] {
                    "Staff", // 1
                    "Customers", // 2
                    "Products",// 3
                    "Sales",
                    "Logout",
                    "Exit" // 4
                };
                string choice = Input.GetFieldOptions(options, returnOptionName: false);
                // respond to the user's choice
                switch (choice)
                {
                    case "1": // Fahrenheit to Celcius
                        GetStaffMenu();
                        break;
                    case "2": // Celsius to Fahrenheit
                        GetCustomerMenu();
                        break;
                    case "3": // Enter a date
                        //string date = Input.GetFieldDate("Birthday");
                        //Console.WriteLine(date);
                        //Console.WriteLine("You entered " + date);
                        GetProductMenu();
                        break;
                    case "4":
                        GetSaleMenu();
                        //sales
                        break;
                    case "5":
                    Login();
                         //Logout
                         break;
                    case "6": // Exit
                        exit = true;
                        break;
                }
            }
        }
    }

    static bool Login()
    {
        bool validID = false;
        bool validPass = false;
        Console.Clear();
        //const string USER = "admin";
        //const string PASS = "admin";
        int USER = staff.ID;
        string PASS = staff.Password;
        int userID;
        string password;

        do
        {
            Console.Clear();
            try { userID = int.Parse(Input.GetFieldInt("UserID", min: 0)); }
            catch (FormatException)
            {
                Console.WriteLine("ID must be an integer");
                return validID;
            }

            try { password = Input.GetFieldPassword("Password"); }
            catch (FormatException)
            { return validPass; }
        } while (password != PASS);
        //userID = int.Parse(Input.GetFieldInt("UserID", min: 0));
        //password = Input.GetFieldPassword("Password");

        return userID == USER && password == PASS;
    }

    //main menu
    static void GetStaffMenu()
    {
        Console.Clear();
        Console.WriteLine("=== STAFF ===");
        Staff staff = new Staff(1, "admin","Dane", true);
        Console.WriteLine($"Staff ID: {staff.ID}");
        if (staff.Admin == true)
        {
            Console.WriteLine("Type: Administrater");
        }
        else { Console.WriteLine("Type: Staff"); }

        string[] staffOptions = new string[] {
                    "Update Password", // 1
                    "Your sales", // 2
                    "Register Staff",// 3
                    "View Staff" // 4
                };
        string choice = Input.GetFieldOptions(staffOptions, returnOptionName: false);

        switch (choice)
        {
            case "1":
                UpdatePass();
                break;
            case "2":
                Console.WriteLine("2");
                break;
            case "3": // Enter a date
                RegisterStaff();
                break;
            case "4": // Exit
                ViewStaff();
                break;
        }
        //double fahrenheit = double.Parse(Input.GetFieldDouble("Fahrenheit"));
        //double celsius = (fahrenheit - 32.0) * 5.0 / 9.0;
        //Console.WriteLine($"{fahrenheit:F2}°F == {celsius:F2}°C");

        Input.GetEnter(); // press ENTER to continue
    }

    //staff menu
    static void UpdatePass()
    {
        Console.Clear();
        //Staff staff = new Staff(1,"admin","Dane",true);
        string currentPW = Input.GetFieldSimple("Enter current password");
        currentPW = staff.Password;
        string newPW = Input.GetFieldSimple("Enter new password");
        string confirm = Input.GetFieldSimple("Confirm?");
        if (confirm == "yes"||confirm == "Yes")
        {
            currentPW = newPW;
            Console.WriteLine("Password Updated!");
        }
        Input.GetEnter();
    }
    static void RegisterStaff()
    {
        Console.Clear();
        //Staff staff = new Staff(1,"admin",true);
        bool admin = false;
        string staffName = Input.GetFieldSimple("Enter staff name");
        string staffPassword  = Input.GetFieldPassword("Enter staff password");
        string confirmAdmin = Input.GetFieldSimple("Confirm Admin? ");
        if (confirmAdmin == "Yes")
        {
            admin = true;
        } else {admin = false;} 
        Console.WriteLine("Staff added!");
        store.AddStaff(staff.ID,staffPassword,staffName,admin);
        
        Input.GetEnter();
    }
    static void ViewStaff()
    {
         Console.Clear();
         //store.AddStaff(1,"admin","Dane",true);
         store.DisplayStaffDB();
         Input.GetEnter();
        
    }

    //Main Menu                    
    static void GetCustomerMenu()
    {
        Console.Clear();
        Console.WriteLine("=== CUSTOMER ===");

        string[] CustomerOptions = new string[] {
                    "View Customer", // 1
                    "Add Customer", // 2
                    "Edit Customer",// 3
                    "Delete Customer" // 4
                };
        string choice = Input.GetFieldOptions(CustomerOptions, returnOptionName: false);

        switch (choice)
        {
            case "1":
                DisplayCustomer();
                break;
            case "2":
                AddCustomer();
                break;
            case "3": // Enter a date
                Console.WriteLine("3");
                break;
            case "4": // Exit
                DeleteCustomer();
                break;
        }

        Input.GetEnter(); // press ENTER to continue
    }
    //customer menu
    static void DisplayCustomer()
    {
         Console.Clear();
        //store.AddCustomerDB("Kada Jin","435-356-455",
        //"Cook 24 street","kadajin@email.com",2);
         store.DisplayCustomerDB();
         Input.GetEnter();
        store.DisplayCustomerDB();
        store.AddCustomerDB("Cesar","301203213", "123142 Ssat", "sdad@msdasd.com", 213);
        Console.Write("Enter the ID of the customer or search: ");
        Console.Clear();
        string SerchInput = Console.ReadLine();
        SearchCustomerInfo(SerchInput);
        Input.GetEnter();
    }

    static void SearchCustomerInfo(string SearchInput)
    {
        store.DisplayCustomerDB(SearchInput);
    }
    //customer menu
    static void AddCustomer()
    {
        Console.Clear();
        /*string name, string phone,
        string address, string email, int customerID*/
        string customerName = Input.GetFieldSimple("Enter customer name");
        string customerPhone = Input.GetFieldSimple("Enter phone number");
        string customerAddress = Input.GetFieldSimple("Enter address");
        string customerEmail = Input.GetFieldSimple("Enter email");
        int ID = int.Parse(Input.GetFieldSimple("Enter ID"));
        Customer customer = new Customer(customerName, customerPhone, customerAddress,
        customerEmail, ID);
        customerName = customer.Name;
        customerPhone = customer.Phone;
        customerAddress = customer.Address;
        customerEmail = customer.Email;
        ID = customer.CustomerID;
        store.AddCustomerDB(customerName, customerPhone, customerAddress, customerEmail, ID);
        Console.WriteLine("Customer info added!");
        Input.GetEnter();
    }
    static void DeleteCustomer()
    {
        int customersID = int.Parse(Input.GetFieldSimple("Select customer ID"));
        store.DeleteCustomerDB(customersID);
        Console.WriteLine("Customer info Deleted!");
    }

    static void GetProductMenu()
    {
        Console.Clear();
        Console.WriteLine("=== Product ===");

        string[] staffOptions = new string[] {
                    "View Product", // 1
                    "Register new Product", // 2
                    "Edit Product",// 3
                };
        string choice = Input.GetFieldOptions(staffOptions, returnOptionName: false);

        switch (choice)
        {
            case "1":
                ViewProduct();
                break;
            case "2":
                RegisterProduct();
                break;
            case "3": // Enter a date
                EditProduct();
                break;
        }
    }
    static void ViewProduct()
    {
        Console.Clear();
        store.DisplayProductDB();
        Input.GetEnter();
    }
    //products menu
    static void RegisterProduct()
    {
        Console.Clear();
        /*string name, string phone,
        string address, string email, int customerID*/
        string ProductName = Input.GetFieldSimple("Enter product name");
        int ProductPrice = int.Parse(Input.GetFieldSimple("Enter Price"));
        int ProductQuantity = int.Parse(Input.GetFieldSimple("Enter stock"));
        //Product product = new Product(ProductName,ProductPrice,ProductQuantity);
        Product product = new Product(ProductName, ProductPrice, ProductQuantity);
        store.AddProductDB(ProductName, ProductPrice, ProductQuantity);
        Console.WriteLine("product info added!");
        Input.GetEnter();
    }
    //products menu
    static void EditProduct()
    {
        //Product product = new Product();
        //store.GetProduct();
    }

    static void GetSaleMenu()
    {
       Console.Clear();
       //int customerID, int productID, int quantity,
       bool spendPoints = false;
       bool applyDelivery = false;
       int SaleCustomerID = int.Parse(Input.GetFieldSimple("Select customer ID"));
       //Customer customer = store.GetCustomer(SaleCustomerID);
       int SaleProductID = int.Parse(Input.GetFieldSimple("Select product ID"));
       int SaleAmount = int.Parse(Input.GetFieldSimple("Type number of quantity"));
       string SaleSpendLoyalty = Input.GetFieldSimple("Will you Spend points?");
       if (SaleSpendLoyalty == "Yes"||SaleSpendLoyalty == "Y")
       {
           spendPoints = true;
       }
       string SaleDelivery = Input.GetFieldSimple("Will you apply delivery?");
       if (SaleDelivery == "Yes"||SaleDelivery == "Y")
       {
           applyDelivery = true;
       }
       store.ExecuteSale(SaleCustomerID,SaleProductID,SaleAmount,spendPoints,
       applyDelivery);
       store.DisplaySale();
       
       Input.GetEnter();
        
    }
}
