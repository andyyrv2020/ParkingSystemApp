using System;
using System.Collections.Generic;

public abstract class ParkingSpot
{
    public int Id { get; private set; }
    public bool Occupied { get; set; }
    public string Type { get; private set; }
    public double Price { get; private set; }
    public List<ParkingInterval> ParkingIntervals { get; private set; }

    protected ParkingSpot(int id, bool occupied, string type, double price)
    {
        if (price <= 0)
        {
            throw new ArgumentException("Price must be greater than zero.");
        }

        Id = id;
        Occupied = occupied;
        Type = type;
        Price = price;
        ParkingIntervals = new List<ParkingInterval>();
    }

    public override string ToString()
    {
        return $"Parking Spot #{Id}\nOccupied: {Occupied}\nType: {Type}\nPrice per hour: {Price} BGN";
    }
}