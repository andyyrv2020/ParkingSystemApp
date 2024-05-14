using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingSystemApp
{
    public class CarParkingSpot : ParkingSpot
    {
        public CarParkingSpot(int id, bool occupied, double price) : base(id, occupied, "car", price)
        {
        }
        public override bool ParkVehicle(string registrationPlate, int hoursParked)
        {
            // Implementation specific to CarParkingSpot
            throw new NotImplementedException();
        }

        public override void FreeParkingSpot()
        {
            // Implementation specific to CarParkingSpot
            throw new NotImplementedException();
        }

        public override List<ParkingInterval> GetAllParkingIntervalsByRegistrationPlate(string registrationPlate)
        {
            // Implementation specific to CarParkingSpot
            throw new NotImplementedException();
        }

        public override double CalculateTotal()
        {
            // Implementation specific to CarParkingSpot
            throw new NotImplementedException();
        }

    }
}
