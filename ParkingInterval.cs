using System;

public class ParkingInterval
{
    public ParkingSpot ParkingSpot { get; private set; }
    public string RegistrationPlate { get; private set; }
    public int HoursParked { get; private set; }
    public double Revenue { get; private set; }

    public ParkingInterval(ParkingSpot parkingSpot, string registrationPlate, int hoursParked)
    {
        if (hoursParked <= 0)
        {
            throw new ArgumentException("Hours parked must be greater than zero.");
        }

        ParkingSpot = parkingSpot ?? throw new ArgumentNullException(nameof(parkingSpot));
        RegistrationPlate = string.IsNullOrEmpty(registrationPlate) ? throw new ArgumentException("Registration plate must not be null or empty.") : registrationPlate;
        HoursParked = hoursParked;
        Revenue = parkingSpot.Price * hoursParked;
    }

    public override string ToString()
    {
        return $"Parking Spot #{ParkingSpot.Id}\nRegistrationPlate: {RegistrationPlate}\nHoursParked: {HoursParked}\nRevenue: {Revenue} BGN";
    }
}
