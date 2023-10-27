// See https://aka.ms/new-console-template for more information
using LawnMowerApp;
using System.Xml.Linq;



InventoryManager manager = new InventoryManager();

List<Customer> customerDatabase = new List<Customer>();
List<LawnMower> inventory = new List<LawnMower>();

PrimeCustomer primeCustomer = new PrimeCustomer("", "", "", "", "");
BasicCustomer basicCustomer = new BasicCustomer("", "", "", "", "");



Console.WriteLine("\n-------Welcome to Lawn Mower Rental App!-------");


while (true)
{

    Console.WriteLine("\nMain Menu");
    Console.WriteLine("1. Register New Customer");
    Console.WriteLine("2. Display Inventory");
    Console.WriteLine("3. Rent a Lawn Mower");
    Console.WriteLine("4. Return a Lawn Mower");
    Console.WriteLine("5. View Customers with Active Rentals");
    Console.WriteLine("6. Display the status of the customer");
    Console.WriteLine("7. Exit");
    Console.Write("\nEnter your choice: ");

    if (int.TryParse(Console.ReadLine(), out int choice))
    {
        switch (choice)
        {
            case 1:
                Customer.RegisterNewCustomer();
                break;

            case 2:
                manager.DisplayInventory();
                
                break;

            case 3:
                manager.RentLawnMower();
                break;

            case 4:
                manager.ReturnLawnMower();
                break;

            case 5:
                InventoryManager.ListCustomersWithAtiveRentals();
                break;

         
                case 6:
                Environment.Exit(0);
                break;
            default:
                Console.WriteLine("Invalid option. Please try again.");
                break;

        }
    }

    else
    {
        Console.WriteLine("Invalid input. Please enter a valid option.");
    }
}
    




