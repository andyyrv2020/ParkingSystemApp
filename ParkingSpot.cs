using System.Text.RegularExpressions;

namespace ParkingSystemApp
{
    public abstract class ParkingSpot
    {
        private int id;
        private bool occupied;
        private string type;
        private double price;
        protected List<ParkingInterval> parkingIntervals;

        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        public bool Occupied
        {
            get
            {
                return occupied;
            }

            set
            {
                occupied = value;
            }
        }

        public string Type
        {
            get
            {
                return type;
            }

            set
            {
                type = value;
            }

        }

        public double Price
        {
            get
            {
                return price;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Parking price cannot be less or equal to 0!");
                }
                price = value;
            }
        }

        public ParkingSpot(int id, bool occupied, string type, double price)
        {
            Id = id;
            Occupied = occupied;
            Type = type;
            Price = price;
            parkingIntervals = new List<ParkingInterval>();
        }

        public abstract bool ParkVehicle(string registrationPlate, int hoursParked);
        public abstract void FreeParkingSpot();
        public abstract List<ParkingInterval> GetAllParkingIntervalsByRegistrationPlate(string registrationPlate);
        public abstract double CalculateTotal();
        public override string ToString()
        {
            return $"Parking Spot #{Id}\nOccupied: {Occupied}\nType: {Type}\nPrice per hour: {Price:F2} BGN";
        }
    }
}