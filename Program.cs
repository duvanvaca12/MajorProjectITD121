using System;
using Database.Shop;

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
        store.AddProductDB("Witcher",100,50);
        store.AddProductDB("MW3",80,80);
        store.AddStaff(1,"admin", true);
        while(true)
        {

            var login = store.ValidateLogin(1, "admin");

            if (login == true) 
            {
            store.ExecuteSale(1,1,3,false,false);
            store.ExecuteSale(2,2,3,false,false);
            store.ExecuteSale(2,1,1,true,true);
            store.ExecuteSale(1,2,1,true,true);  
            store.DisplayAll();
            Console.ReadLine();
            break;
            }

        }
    }
}

