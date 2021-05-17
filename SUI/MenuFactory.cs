using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using SBL;
using SDL;
using SDL.Entities;
namespace SUI
{
    public class MenuFactory
    {
        public static InterfaceMenu GetMenu(string menuSelect)
        {
            //used to build a connection with the database
            var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();
            
            string connector = configuration.GetConnectionString("BakeryDB");
            DbContextOptions<OnlineBakeryContext> options = new DbContextOptionsBuilder<OnlineBakeryContext>()
            .UseSqlServer(connector)
            .Options;

            var context = new OnlineBakeryContext(options);
            switch(menuSelect.ToLower())
            {
                case "main":
                    return new MainMenu();
                case "order":
                    return new OrderMenu(new CustomerBL(new CustomerDB(context)));
                case "customer":
                    return new CustomerMenu(new CustomerBL(new CustomerDB(context)));
                default:
                    return null;
            }
        }
    }
}