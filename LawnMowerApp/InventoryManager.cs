using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace LawnMowerApp
{

    public class InventoryManager
    {

        static List<Customer> customers= new List<Customer>();
        static List<Rental> rentals = new List<Rental>();

        static List<LawnMower> inventory;

        public InventoryManager()
        {

            inventory = new List<LawnMower>
        {
          
            new ElectricLawnMower(1, "HUSKVARNA Electrical", 75 , 30, 5),
            new ElectricLawnMower(2, "HUSKVARNA Electrical", 146, 50, 5),
            new PetrolLawnMower  (3, "HUSKVARNA Petrol    ", 862, 80, 5),
        };
       
        }
		// DisplayInventory Status: WORKS
        public void DisplayInventory()
        {
            Console.WriteLine("\nCurrent Inventory:");
            Console.WriteLine("-------------------");
            foreach (var mower in inventory)
            {
                Console.WriteLine($"Mower ID:{mower.MowerId}, Model: {mower.Model}, {mower.GetAdditionalInfo()}, Price: {mower.Price}SEK, QuantityInStock: {mower.QuantityInStock}");
                
            }
        }

        public bool RentLawnMower()
        {      
            Console.WriteLine("\n Rent a lawn Mower ");
            Console.WriteLine("---------------------\n ");
            Console.Write("\nEnter Customer ID: ");
            string customerId = Console.ReadLine();

            List<Customer> customers = new List<Customer>();

            bool customer = customers.Exists(x => x.CustomerId.Equals(customerId));
            if (customer = false)
            {
                Console.WriteLine("Customer is not registered. Please register the customer first.");
                return true;
                
            }


            Console.Write("Enter MowerId to Rent: ");
            int mowerId = int.Parse(Console.ReadLine());
           

            var lawnMower = inventory.Find(lm => lm.MowerId == mowerId);
            if (lawnMower == null)
            {
                Console.WriteLine("Lawn mowerId not found.");
                return false;
            }

            if (lawnMower.QuantityInStock >0)
            {
                Console.Write("Enter Rental Start Date (YY-MM-DD): ");
                if (!DateTime.TryParse(Console.ReadLine(), out var startDate))
                {
                    Console.WriteLine("Invalid date format. Please use YY-MM-DD.");
                    return false;
                }

                Console.Write("Enter Rental Return Date (YY-MM-DD): ");
            
                if (!DateTime.TryParse(Console.ReadLine(), out var returnDate))
                {
                    Console.WriteLine("Invalid date format. Please use YY-MM-DD.");
                    return false;
                }

                Console.Write("Enter Customer Type (Basic/Prime): ");
                string customerType = Console.ReadLine();

                if (customerType.Equals("basic", StringComparison.OrdinalIgnoreCase))
                {
                   
                    if ((returnDate - startDate).TotalDays > 7)
                    {
                        Console.WriteLine("\nBasic customers have a rental limit of seven days for new rentals.");
                        return false;
                    }
                }

                int daysRented = (int)(returnDate - startDate).TotalDays;

                lawnMower.QuantityInStock --;
                rentals.Add(new Rental
                {
                    CustomerId = customerId, 
                    MowerId = mowerId,
                    StartDate = startDate,
                    ReturnDate = returnDate
                });

                Console.WriteLine($"\n{customerType} customer rented MowerId:{mowerId} for {daysRented} days.");
                return true;

            }
            else
            {
                Console.WriteLine($"Not enough {mowerId} lawn mowers available.");
                return false;
            }
        }
  
        public bool ReturnLawnMower()
        {
            Console.WriteLine("\n Return a lawn Mower ");
            Console.WriteLine("---------------------\n ");
            Console.Write("Enter Customer ID: ");
            int customerid = int.Parse(Console.ReadLine());        

            Console.Write("Enter the MowerId to return: ");
            int mowerId = int.Parse(Console.ReadLine());


            var lawnMower = inventory.Find(lm => lm.MowerId == mowerId);
            if (lawnMower == null)
            {
                Console.WriteLine("Lawn MowerId not found.");
                return false;
            }

            lawnMower.QuantityInStock ++;
            decimal rentalCost = CalculateRentalCost(mowerId);

            Console.WriteLine($"\nRental Cost: {rentalCost} SEK");
            Console.WriteLine($"\nMowerId:{mowerId} has returned successfully.");
            return true;

        }
        public int Rentalcost()
        {
            Console.WriteLine("Enter the rented mower Id.");
            int input = Convert.ToInt32(Console.ReadLine());
            LawnMower mower = inventory.Find(m => m.MowerId == input);
            if (mower != null)
            {
                Console.WriteLine("enter the number of the days rented: ");
                int rentalDays = Convert.ToInt32(Console.ReadLine());
                int rentalcost = rentalDays * mower.Price;
                Console.WriteLine($"The rental cost is: {rentalcost}");
                return rentalcost;
            }
            else
            {
                Console.WriteLine("Invalid mower Id.");
                return 0;
            }
        }
        public decimal CalculateRentalCost(int mowerId)
        {

            LawnMower mower = inventory.Find(m => m.MowerId == mowerId);

            if (mower != null)
            {
                Console.WriteLine("Enter the number of days rented: ");
                int rentalDays = int.Parse(Console.ReadLine());
                decimal rentalCost = rentalDays * mower.Price; ;
                return rentalCost;
            }
            else
            {
                Console.WriteLine("Invalid mower ID.");
                return 0;
            }
        }


        public static void ListCustomersWithAtiveRentals()
        {

            foreach (var rental in rentals)
            {
                if (DateTime.Now >= rental.StartDate && DateTime.Now <= rental.ReturnDate)
                {
                    Console.WriteLine($"\n----Customer with Active Rentals----\n");
                    Console.WriteLine($"CustomerId: {rental.CustomerId}");
                    Console.WriteLine($"MowerId: {rental.MowerId}");
                    Console.WriteLine($"Start Date: {rental.StartDate.ToShortDateString()}");
                    Console.WriteLine($"Return Date: {rental.ReturnDate.ToShortDateString()}");
                }
                else { Console.WriteLine("No Customers with active rentals"); }
            }
            }
        }
    }


      












