public class SubscriptionParkingSpot : ParkingSpot
{
    public string RegistrationPlate { get; private set; }

    public SubscriptionParkingSpot(int id, bool occupied, double price, string registrationPlate)
        : base(id, occupied, "subscription", price)
    {
        if (string.IsNullOrEmpty(registrationPlate))
        {
            throw new ArgumentException("Registration plate must not be null or empty.");
        }

        RegistrationPlate = registrationPlate;
    }

    public override string ToString()
    {
        return base.ToString() + $"\nRegistration Plate: {RegistrationPlate}";
    }
}
