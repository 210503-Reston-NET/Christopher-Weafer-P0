using System;
namespace SUI
{
    
    public class MainMenu : InterfaceMenu
    {
        public void Launch(){
            bool exit = false;
            do
            {
                string selection;

                Console.WriteLine("Welcome to the Bread Store: Where people go to buy the bread");
                Console.WriteLine("Please enter a correspoonding number to select an option");
                Console.WriteLine("[1]: Place an Order");
                Console.WriteLine("[2]: Customer Search");
                Console.WriteLine("[3]: Add Customer");
                Console.WriteLine("[4]: Manager Portal");

                selection = Console.ReadLine();

                switch(selection)
                {
                    case "0":
                        Console.WriteLine("[1]: Place an Order");
                        break;
                    case "1":
                        break;
                    
                    case "2":
                        break;
                }
            }while(!exit);
        }
    }
}