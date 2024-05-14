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
            //TODO: implement me
        }

        public virtual bool ParkVehicle(string registrationPlate, int hoursParked, string type)
        {
            //TODO: implement me
        }

        public List<ParkingInterval> GetAllParkingIntervalsByRegistrationPlate(string registrationPlate)
        {
            //TODO: implement me
        }

        public virtual double CalculateTotal()
        {
            //TODO: implement me
        }

        public override string ToString()
        {
            //TODO: implement me
        }

    }
}