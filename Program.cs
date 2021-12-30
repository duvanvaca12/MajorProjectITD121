using System;
using System.Collections.Generic;
using CoreShop.Entities;

class Program
{
    static void Main(string[] args)
    {
        Store store = new Store();
        store.AddCustomer("Ted Lasso","345-656-45",
        "Baker 24 street","tedlasso@email.com",1);
        store.AddProduct("Mario",105,30);
        store.AddProduct("Zelda",80,80);
        store.DisplayAll();
        Console.ReadLine();
    }
}
