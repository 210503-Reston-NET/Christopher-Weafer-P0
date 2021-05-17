using System;
using SModel;
using System.Collections.Generic;
using System.Linq;
using SBL;
namespace SUI
{
    public class OrderMenu : InterfaceMenu  
    {
        private ICustomerBL _BreadBL;

        public OrderMenu(ICustomerBL cBL)
        {
            _BreadBL = cBL;
        }
        public static List<Bread> breadTypes = new List<Bread>()
            {
                new Bread("Baguette", 2.00),
                new Bread("Brioche", 1.00),
                new Bread("Bagel", 1.00),
                new Bread("Sourdough", 1.00),
                new Bread("Rye", 1.00),
                new Bread("Pita", 1.00),
                new Bread("Multigrain", 1.00),
                new Bread("Focaccia", 1.00),
                new Bread("White", 1.00),
                new Bread("Wheat", 1.00),
                new Bread("English Muffin", 1.00),
                new Bread("Matzo", 1.00),
                new Bread("Tortilla", 1.00),
                new Bread("Banana", 1.00),
                new Bread("BreadStick", 1.00),
                new Bread("Corn Bread", 1.00),
                new Bread("Pumpernickel", 1.00),
                new Bread("Rye", 1.00)
            };
        
        public void Launch()
        {
            
            //TODO:
            //Add ability to order multiple breads in one order
            //Add Name Verficiation and searching if customer already exists in DB

            string firstName;
            string lastName;
            string orderString;
            string adOrder;
            bool additionalOrder = false;
            
            Console.WriteLine("Order Screen");
            Console.WriteLine("Please Enter your name to login.");
            Console.WriteLine("If you are a new user a new account will be created automatically");
            Console.WriteLine("Please Enter your First Name");
            firstName = Console.ReadLine();
            Console.WriteLine("Please Enter your Last Name");
            lastName = Console.ReadLine();
            do{

                Console.WriteLine("Please enter the type of bread you would like to buy?");
                orderString = Console.ReadLine();
                AddOrder(firstName, lastName, orderString);

                Console.WriteLine("would you like to add additional bread? yes or no");
                adOrder = Console.ReadLine();
                switch(adOrder)
                {
                    case "yes":
                        additionalOrder = true;
                        break;
                    case "no":
                    additionalOrder = false;
                        break;
                    default:
                        Console.WriteLine("Invalid input");
                        break;
                }
            }while(additionalOrder);
            
            
            
        }

        private void AddOrder(string firstname, string lastname, string order)
        {
            

            Bread match = breadTypes.FirstOrDefault(resto => resto.Breadtype.Contains(order));

            if(match == null)
            {
                Console.WriteLine("Bread Does Not Exist");
            }
            else{
                Customer cust = new Customer(firstname, lastname);
                Orders freshOrder = new Orders(match, 1);
                //cust.addOrder(freshOrder);
                Customer newCustomer = _BreadBL.AddCustomer(cust);
                newCustomer.ToString();
                Console.WriteLine("Customer Added");

            }
            
            
        }
        private void OrderSearch()
        {

        }
        
    }
}