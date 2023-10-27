using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawnMowerApp
{ 
        public class PrimeCustomer : Customer
        {
            public int BonusPoints { get; set; }

            public PrimeCustomer(string customerId, string name, string phoneNumber, string address, string type) : base(customerId, name, phoneNumber, address, type)
            {
                BonusPoints = 0;
            }


            public void AddBonusPoints(/*int rentalCost*/)
            {

                InventoryManager InventoryManagerInstance = new InventoryManager();

                BonusPoints += InventoryManagerInstance.Rentalcost();
            }

            public void DisplayBonusPoints(string customerId)
            {

                if (Exists(customerId))
                {
                    Customer customer = new Customer();
                    if (customer is PrimeCustomer primeCustomer)
                    {
                        Console.WriteLine($"Customer with the ID: {customerId}) has {primeCustomer.BonusPoints} bonus points.");
                    }
                    else
                    {
                        Console.WriteLine("Customer is not a Prime Customer.");
                    }
                }
                else
                {
                    Console.WriteLine("Customer not found.");
                }

            }

        }
    }

