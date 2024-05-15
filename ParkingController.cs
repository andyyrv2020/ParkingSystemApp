using System;
using System.Collections.Generic;
using System.Linq;

public class ParkingController
{
    private List<ParkingSpot> parkingSpots = new List<ParkingSpot>();

    public string CreateParkingSpot(List<string> args)
    {
        try
        {
            int id = int.Parse(args[0]);
            bool occupied = bool.Parse(args[1]);
            string type = args[2];
            double price = double.Parse(args[3]);

            if (parkingSpots.Any(ps => ps.Id == id))
            {
                return $"Parking spot {id} is already registered!";
            }

            ParkingSpot spot;
            if (type == "car")
            {
                spot = new CarParkingSpot(id, occupied, price);
            }
            else if (type == "bus")
            {
                spot = new BusParkingSpot(id, occupied, price);
            }
            else if (type == "subscription")
            {
                string registrationPlate = args[4];
                spot = new SubscriptionParkingSpot(id, occupied, price, registrationPlate);
            }
            else
            {
                return "Unable to create parking spot!";
            }

            parkingSpots.Add(spot);
            return $"Parking spot {spot.Id} was successfully registered in the system!";
        }
        catch
        {
            return "Unable to create parking spot!";
        }
    }

    public string ParkVehicle(List<string> args)
    {
        try
        {
            int parkingSpotId = int.Parse(args[0]);
            string registrationPlate = args[1];
            int hoursParked = int.Parse(args[2]);
            string type = args[3];

            var spot = parkingSpots.FirstOrDefault(ps => ps.Id == parkingSpotId);
            if (spot == null)
            {
                return $"Parking spot {parkingSpotId} not found!";
            }

            if (spot.Occupied || spot.Type != type)
            {
                return $"Vehicle {registrationPlate} can't park at {parkingSpotId}.";
            }

            spot.Occupied = true;
            var interval = new ParkingInterval(spot, registrationPlate, hoursParked);
            spot.ParkingIntervals.Add(interval);
            return $"Vehicle {registrationPlate} parked at {parkingSpotId} for {hoursParked} hours.";
        }
        catch
        {
            return "Unable to park vehicle!";
        }
    }

    public string FreeParkingSpot(List<string> args)
    {
        try
        {
            int parkingSpotId = int.Parse(args[0]);

            var spot = parkingSpots.FirstOrDefault(ps => ps.Id == parkingSpotId);
            if (spot == null)
            {
                return $"Parking spot {parkingSpotId} not found!";
            }

            if (!spot.Occupied)
            {
                return $"Parking spot {parkingSpotId} is not occupied.";
            }

            spot.Occupied = false;
            return $"Parking spot {parkingSpotId} is now free!";
        }
        catch
        {
            return "Unable to free parking spot!";
        }
    }

    public string GetParkingSpotById(List<string> args)
    {
        try
        {
            int parkingSpotId = int.Parse(args[0]);

            var spot = parkingSpots.FirstOrDefault(ps => ps.Id == parkingSpotId);
            if (spot == null)
            {
                return $"Parking spot {parkingSpotId} not found!";
            }

            return spot.ToString();
        }
        catch
        {
            return "Unable to get parking spot!";
        }
    }

    public string GetParkingIntervalsByParkingSpotIdAndRegistrationPlate(List<string> args)
    {
        try
        {
            int parkingSpotId = int.Parse(args[0]);
            string registrationPlate = args[1];

            var spot = parkingSpots.FirstOrDefault(ps => ps.Id == parkingSpotId);
            if (spot == null)
            {
                return $"Parking spot {parkingSpotId} not found!";
            }

            var intervals = spot.ParkingIntervals
                .Where(pi => pi.RegistrationPlate == registrationPlate)
                .Select(pi => pi.ToString());

            return "Parking intervals for parking spot " + parkingSpotId + ":\n" + string.Join("\n", intervals);
        }
        catch
        {
            return "Unable to get parking intervals!";
        }
    }

    public string CalculateTotal()
    {
        try
        {
            double total = parkingSpots
                .Where(ps => ps.Type != "subscription")
                .SelectMany(ps => ps.ParkingIntervals)
                .Sum(pi => pi.Revenue);

            return $"Total revenue from the parking: {total:F2} BGN";
        }
        catch
        {
            return "Unable to calculate total revenue!";
        }
    }
}
