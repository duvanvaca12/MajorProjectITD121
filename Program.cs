using System;
using Database.Shop;

class Program
{
    static void Main(string[] args)
    {
      Store store = new Store();
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
                    "Sales" // 4
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
                        string date = Input.GetFieldDate("Birthday");
                        Console.WriteLine(date);
                        Console.WriteLine("You entered " + date);
                        break;
                    case "4": // Exit
                        //exit = true;
                        break;
                }
            }
        }
    }

    static bool Login()
    {
        Console.Clear();
        Store store = new Store();
        Staff staff = new Staff(1,"admin",true);
        //const string USER = "admin";
        //const string PASS = "admin";
        int USER = staff.ID;
        string PASS = staff.Password;
        
        int userID = int.Parse(Input.GetFieldInt("UserID", min: 0));
        string password = Input.GetFieldPassword("Password");

        return userID == USER && password == PASS;
    }
    
    //main menu
    static void GetStaffMenu()
    {
        Console.Clear();
        Console.WriteLine("=== STAFF ===");
        
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
        Staff staff = new Staff(1,"admin",true);
        string currentPW = Input.GetFieldSimple("Enter current password");
        currentPW = staff.Password;
        string newPW = Input.GetFieldSimple("Enter new password");
        string confirm = Input.GetFieldSimple("Confirm?");
        if (confirm == "yes")
        {
           currentPW = newPW;
           Console.WriteLine("Password Updated!");
        }
        Input.GetEnter();
    }
    static void RegisterStaff()
    {
        Console.Clear();
        Store store = new Store();
        Staff staff = new Staff(1,"admin",true);
        bool admin = staff.Admin;
        string name = Input.GetFieldSimple("Enter staff name");
        string password  = Input.GetFieldPassword("Enter staff password");
        string confirmAdmin = Input.GetFieldSimple("Confirm Admin? ");
        if (confirmAdmin == "yes")
        {
            admin = true;
        } else {admin = false;} 
        
        Input.GetEnter();
    }
    static void ViewStaff()
    {
        Console.Clear();
         Store store = new Store();
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
                    Console.WriteLine("4");
                        break;
                }

        Input.GetEnter(); // press ENTER to continue
    }
    //customer menu
    static void DisplayCustomer()
    {
         Console.Clear();
         Store store = new Store();
         store.DisplayCustomerDB();
         Input.GetEnter();
    }
    //customer menu
    static void AddCustomer()
    {
        Console.Clear();
        Store store = new Store();
        /*string name, string phone,
        string address, string email, int customerID*/
        string name = Input.GetFieldSimple("Enter customer name");
        string phone = Input.GetFieldSimple("Enter phone number");
        string address = Input.GetFieldSimple("Enter address");
        string email = Input.GetFieldSimple("Enter email");
        int ID = int.Parse(Input.GetFieldSimple("Enter ID"));
        store.AddCustomerDB(name,phone,address,email,ID);
        Console.WriteLine("Customer info added!");
        Input.GetEnter();
    }
}
