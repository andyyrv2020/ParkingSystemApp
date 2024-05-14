using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//https://pastebin.com/v0RMPsZv
//

namespace ParkingSystemApp
{
    internal class SubscriptionParkingSpot : ParkingSpot
    {
        private string registrationPlate;
        public string RegistrationPlate
        {
            get
            {
                return registrationPlate;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Registration plate can’t be null or empty!");
                }
                registrationPlate = value;
            }
        }

        public SubscriptionParkingSpot(int id, bool occupied, double price, string registrationPlate) : base(id, occupied, "subscription", price)
        {
            //TODO: Implement me
            throw new NotImplementedException();
        }

        public override bool ParkVehicle(string registrationPlate, int hoursParked, string type)
        {
            //TODO: Implement me
            throw new NotImplementedException();
        }

        public override double CalculateTotal()
        {
            //TODO: Implement me
            throw new NotImplementedException();
        }
    }
}
