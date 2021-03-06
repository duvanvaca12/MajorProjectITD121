using System;
using System.Collections.Generic;
using Database.Shop;

class Program
{
    static Store store = new Store();
    static Staff staff = new Staff(1, "admin", "Dane", true);
    public static int customerCount = 1;

    public static int productCount= 1;

    public static int staffCount = 1;
    static void Main(string[] args)
    {
        if (Login())
        {
            store.AddStaff(1, "Admin", "Dane", true);
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
        Console.Clear();
        int USER = staff.ID;
        string PASS = staff.Password;
        int userID;
        string password;
        store.ValidateLogin(USER, PASS);
        do
        {
            Console.Clear();
            Console.WriteLine("=== Login ===");
            userID = int.Parse(Input.GetFieldInt("UserID", min: 0));
            password = Input.GetFieldPassword("Password");
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
                ViewStaffSale();
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
        //currentPW = staff.Password;
        string newPW = Input.GetFieldSimple("Enter new password");
        string confirm = Input.GetFieldSimple("Confirm?");
        if (confirm == "yes" || confirm == "Yes")
        {
            currentPW = newPW;
            Console.WriteLine("Password Updated!");
        }
        staff.Password = currentPW;
        Input.GetEnter();
    }
    static void ViewStaffSale()
    {
        Console.Clear();
        store.DisplayStaffSale();
        Input.GetEnter();
    }
    static void RegisterStaff()
    {
        Console.Clear();
        //Staff staff = new Staff(1,"admin",true);
        bool staffAdmin = false;
        string staffName = Input.GetFieldSimple("Enter staff name");
        string staffPassword = Input.GetFieldPassword("Enter staff password");
        string confirmAdmin = Input.GetFieldSimple("Confirm Admin? ").ToUpper();
        if (confirmAdmin == "YES" || confirmAdmin == "Y")
        {
            staffAdmin = true;
        }
        else { staffAdmin = false; }
        Console.WriteLine("Staff added!");
        int ID = staffCount + 1;
        store.AddStaff(ID, staffPassword, staffName, staffAdmin);
        store.ValidateLogin(staff.ID, staffPassword);
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
                EditCustomer();
                break;
            case "4": // Exit
                DeleteCustomer();
                break;
        }

        Input.GetEnter(); // press ENTER to continue
    }
    private static void EditCustomer()
    {
        Console.Clear();
        if (store._customers.Count == 0)
        {
            Console.WriteLine("No Customers found");
        } else 
        {             
            store.DisplayCustomerDB();
            string query = Input.GetFieldInt("Enter the ID of the customer");
            var customer = store.GetCustomer(int.Parse(query));

            Console.Clear();
            string[] CustomerOptions = new string[] {
                    $"Name: {customer.Name}", // 1
                    $"Address: {customer.Address}", // 2
                    $"Phone: {customer.Phone}",// 3
                    $"Email: {customer.Email}", // 4
                    //$"Birthday: {customer.Birthday}", // 5
                    $"LoyaltyPoint: {customer.LoyaltyPoint}"
                };
            string choice = Input.GetFieldOptions(CustomerOptions, returnOptionName: false);
            string editing = string.Empty;
            if (choice == "1")
            {
                editing = Input.GetFieldSimple("Name");
            }
            else if (choice == "2")
            {
                editing = Input.GetFieldSimple("Adress");
            }
            else if (choice == "3")
            {
                editing = Input.GetFieldSimple("Phone");
            }
            else if (choice == "4")
            {
                editing = Input.GetFieldSimple("Email");
            }
            switch (choice)
            {
                case "1":
                    Console.WriteLine("New Name");
                    store.EditCustomerDB(editing, "1", int.Parse(query));
                    break;
                case "2":
                    store.EditCustomerDB(editing, "2", int.Parse(query));
                    break;
                case "3": // Enter a date
                    store.EditCustomerDB(editing, "3", int.Parse(query));
                    break;
                case "4": // Exit
                    store.EditCustomerDB(editing, "4", int.Parse(query));
                    break;
            }
            Console.Clear();
            store.DisplayCustomerDB(); 
        }

    }

    //customer menu
    static void DisplayCustomer()
    {
        if (store._customers.Count == 0)
        {
            Console.Clear();
            Console.WriteLine("No customers found");
        } else
        {
        Console.Clear();
        store.DisplayCustomerDB();
        while (true)
        {
            string query = Input.GetFieldSimple("Enter the ID of the customer or search: ");
            if (string.IsNullOrEmpty(query)) { return; }
            Console.Clear();
            SearchCustomerInfo(query);
        }
        }
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
        int ID = customerCount++;
        //Customer customer = new Customer(customerName, customerPhone, customerAddress,
        //customerEmail, ID);
        //customerName = customer.Name;
        //customerPhone = customer.Phone;
        //customerAddress = customer.Address;
        //customerEmail = customer.Email;
        store.AddCustomerDB(customerName, customerPhone, customerAddress, customerEmail, ID);
        Console.WriteLine("Customer info added!");
        Input.GetEnter();
    }

    static void DeleteCustomer()
    {
        if (store._customers.Count == 0)
        {
            Console.Clear();
            Console.WriteLine("No customers found");
        } else
        {
        int customersID = int.Parse(Input.GetFieldSimple("Select customer ID"));
        store.DeleteCustomerDB(customersID);
        Console.WriteLine("Customer info Deleted!");
        }
    }

    static void GetProductMenu()
    {
        Console.Clear();
        Console.WriteLine("=== Product ===");

        string[] productOptions = new string[] {
                    "View Product", // 1
                    "Register new Product", // 2
                    "Edit Product",// 3
                };
        string choice = Input.GetFieldOptions(productOptions, returnOptionName: false);

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
        int ID = productCount++;
        /*string name, string phone,
        string address, string email, int customerID*/
        string ProductName = Input.GetFieldSimple("Enter product name");
        int ProductPrice = int.Parse(Input.GetFieldSimple("Enter Price"));
        int ProductQuantity = int.Parse(Input.GetFieldSimple("Enter stock"));
        // Product product = new Product(ProductName, ProductPrice, ProductQuantity);
        store.AddProductDB(ProductName, ProductPrice, ProductQuantity, ID);
        Console.WriteLine("product info added!");
        Input.GetEnter();
    }
    //products menu
    private static void EditProduct()
    {
        if (store._products.Count == 0)
        {
            Console.WriteLine("No Products found");
        } else 
        {  
            Console.Clear();
            store.DisplayProductDB();
            string query = Input.GetFieldInt("Enter the ID of the product");
            var product = store.GetProduct(int.Parse(query));

            Console.Clear();
            string[] productOptions = new string[] {
                        $"Name: {product.ProductName}", // 1
                        $"Price: {product.Price}", // 2
                        $"Stock: {product.RemainQuantity}",// 3
                    };
            string ProductChoice = Input.GetFieldOptions(productOptions, returnOptionName: false);
            string editing = string.Empty;
            if (ProductChoice == "1")
            {
                editing = Input.GetFieldSimple("Name");
            }
            else if (ProductChoice == "2")
            {
                editing = Input.GetFieldSimple("Price");
            }
            else if (ProductChoice == "3")
            {
                editing = Input.GetFieldInt("Quantity");
            }
            switch (ProductChoice)
            {
                case "1":
                    Console.WriteLine("New Name");
                    store.EditProductDB(editing, "1", int.Parse(query));
                    break;
                case "2":
                    store.EditProductDB(editing, "2", int.Parse(query));
                    break;
                case "3": // Enter a date
                    store.EditProductDB(editing, "3", int.Parse(query));
                    break;
            }
            Console.Clear();
            store.DisplayProductDB();
        }
    }
    
    static void GetSaleMenu()
    {
        Console.Clear();
        //int customerID, int productID, int quantity,
        store.ValidateLogin(staff.ID,staff.Password);
        bool spendPoints = false;
        bool applyDelivery = false;

        store.DisplayCustomerDB();
        int SaleCustomerID = int.Parse(Input.GetFieldSimple("Select customer ID"));
        
        Console.Clear();
        store.DisplayProductDB();
        int SaleProductID = int.Parse(Input.GetFieldSimple("Select product ID"));

        Console.Clear();
        int SaleAmount = int.Parse(Input.GetFieldSimple("Type number of quantity"));

        string SaleSpendLoyalty = Input.GetFieldSimple("Will you Spend points?").ToUpper();
        if (SaleSpendLoyalty == "YES" || SaleSpendLoyalty == "Y")
        {
            spendPoints = true;
        }else{spendPoints = false;}

        string SaleDelivery = Input.GetFieldSimple("Will you apply delivery?").ToUpper();
        if (SaleDelivery == "YES" || SaleDelivery == "Y")
        {
            applyDelivery = true;
        }else{applyDelivery = false;}

        store.ExecuteSale(SaleCustomerID, SaleProductID, SaleAmount, spendPoints,
        applyDelivery);
        store.DisplaySale();

        Input.GetEnter();

    }
}






