using System;
using SBL;
using SModel;
namespace SUI
{
    public class CustomerMenu : InterfaceMenu
    {
        private ICustomerBL _custBL;

        public CustomerMenu(ICustomerBL cBL)
        {
            _custBL = cBL;
        }
        public void Launch()
        {
            string firstName;
            string lastName;

            string selection; 
            Console.WriteLine("Please select an option: ");
            Console.WriteLine("[1] Add a customer");
            Console.WriteLine("[2] Search a customer");
            selection = Console.ReadLine();

            switch(selection)
            {
                case "1":
                    Console.WriteLine("Please Enter your First Name");
                    firstName = Console.ReadLine();
                    Console.WriteLine("Please Enter your Last Name");
                    lastName = Console.ReadLine();
                    AddCustomer(firstName, lastName);
                    break;
                case "2":
                    Console.WriteLine("Please Enter their First Name");
                    firstName = Console.ReadLine();
                    Console.WriteLine("Please Enter their Last Name");
                    lastName = Console.ReadLine();
                    Customer custo = SearchCustomer(firstName, lastName);
                    if(custo != null)
                    {
                        Console.WriteLine("found");
                    }
                    else{
                        Console.WriteLine("not found");
                    }
                    Console.WriteLine(custo.ToString());
                    break;
                default:
                    break;
            }
        }


        private void AddCustomer(string first, string last){
            Customer cust = new Customer(first, last);
            Customer doesExist = SearchCustomer(first, last);
            
            if(doesExist != null)
            {}
            else
            {
                Customer newBoi = _custBL.AddCustomer(cust);
                Console.WriteLine(newBoi.ToString());
                Console.WriteLine("Customer added(not really)");
            }
        }

        private Customer SearchCustomer(string first, string last)
        {
            try
            {
                Customer isCusto = _custBL.GetCustomer(new Customer(first, last));
                return isCusto;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Customer does not exist. Select option 1 to add them now!");
                return null;
            }
        }
    }


    
}