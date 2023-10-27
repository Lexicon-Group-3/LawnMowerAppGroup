using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawnMowerApp
{
	public class BasicCustomer : Customer
	{

		public int MinRentalDays { get; set; }
		public double RentDiscount { get; set; }

		public BasicCustomer(
		string name, string address, string phoneNumber, string personalNumber, string type) :
		base(name, address, phoneNumber, personalNumber, type)
		{
			MinRentalDays = 7;
			RentDiscount = 0.20d;
		}

		public bool DiscountManager()
		{
			InventoryManager inventoryInstance = new InventoryManager();

			bool usedDiscount = false;
			double rentCost = inventoryInstance.Rentalcost();
			double disCount = inventoryInstance.Rentalcost() * RentDiscount;
			double disCountedRentalCost = inventoryInstance.Rentalcost() - disCount;
			DateTime yearlyDiscount = new DateTime(/*RentalDate or Maybe fixed years???*/);
			DateTime endYearlyDiscountDate = yearlyDiscount.AddYears(1);
			if (usedDiscount == false)
			{
				Console.WriteLine("You have not yet used your discount, would you like to do so: ");
				if (Console.ReadKey().Key == ConsoleKey.Y)
				{
					Console.WriteLine($"You chose to use your discount\nHere is the costs: " +
					$"\nCost: {rentCost}" +
					$"\nDiscount: {disCount}" +
					$"\nTotal rent cost: {disCountedRentalCost}");
					usedDiscount = true;
					return usedDiscount;
				}
				else
				{
					Console.WriteLine("You chose to keep your discount for later");
				}
			}

			if (usedDiscount == true)
			{
				Console.WriteLine("Sorry, but you have already used this years discount");
			}



			return usedDiscount;
		}
		/*
		public void RentalLimit(RentalTime)
		{
			if (RentalTime<RentalTime + 7 days)
			{
				Console.WriteLine("Sorry but the minimum time to rent for Basic customer is seven days");
				
			}

			Console.WriteLine("The Lawnmower has been rented for "RentalTime"");
		}
		*/
	}




}
