using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        ParkingController controller = new ParkingController();

        while (true)
        {
            string input = Console.ReadLine();
            if (input == "End")
            {
                break;
            }

            var parts = input.Split(':');
            var command = parts[0];
            var commandArgs = new List<string>(parts[1..]);

            string result = command switch
            {
                "CreateParkingSpot" => controller.CreateParkingSpot(commandArgs),
                "ParkVehicle" => controller.ParkVehicle(commandArgs),
                "FreeParkingSpot" => controller.FreeParkingSpot(commandArgs),
                "GetParkingSpotById" => controller.GetParkingSpotById(commandArgs),
                "GetParkingIntervalsByParkingSpotIdAndRegistrationPlate" => controller.GetParkingIntervalsByParkingSpotIdAndRegistrationPlate(commandArgs),
                "CalculateTotal" => controller.CalculateTotal(),
                _ => "Invalid command!"
            };

            Console.WriteLine(result);
        }
    }
}
