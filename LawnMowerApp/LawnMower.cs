using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LawnMowerApp
{
    abstract class LawnMower
    {
        public int MowerId { get; set; }
        public string Model { get; set; }
        public string Type { get; set; }
        public int QuantityInStock { get; set; }
        public int Price { get; set; }
   
        public LawnMower(int id, string model, int price,int stock)
        {
            MowerId = id;
            Model = model;
            Price = price;
            QuantityInStock = stock;
        }
       
        public virtual string GetAdditionalInfo()
        {
            return "";
        }

        public abstract double RentalRate(string customerType);

    }

     class ElectricLawnMower : LawnMower
    {
        public int BatteryEffectWh { get; set; }

        public ElectricLawnMower(int id, string model, int batteryWh, int price, int stock )
            : base(id, model,price, stock)

        {
            BatteryEffectWh = batteryWh;
        }

        public override string GetAdditionalInfo()
        {
            return $"Battery Effect: {BatteryEffectWh} Wh";
        }
        public override double RentalRate(string customerType)
    {
        return customerType == "basic" ? 10 : 8;
    }
        
    }

    class PetrolLawnMower : LawnMower
    {
        public decimal CO2Emission { get; set; }

        public PetrolLawnMower(int id, string model, decimal co2Emission,int price,int stock)
            : base(id, model,price, stock)
        {
            CO2Emission = co2Emission;
        }

        public override string GetAdditionalInfo()
        {
            return $"CO2 Emission: {CO2Emission} g/kWh";
        }
        public override double RentalRate(string customerType)
        {
            return customerType == "basic" ? 12 : 10;
        }
    }
}




 