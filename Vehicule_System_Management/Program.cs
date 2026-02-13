using System;
using Vehicule_System_Management;
using Vehicule_System_Management.Vehicule;

// Create a list to store vehicles
List<Vehicule> vehicules = new List<Vehicule>();

void AddVehicle(List<Vehicule> vehicles)
{
    Console.WriteLine("Enter vehicle type (Car, Motorcycle, Truck):");
    string? typeInput = Console.ReadLine();
    VehiculeType? type = ParseVehicleType(typeInput ?? "");

    if (type == null)
        return;

    Console.WriteLine("Enter make:");
    string? make = Console.ReadLine();

    Console.WriteLine("Enter model:");
    string? model = Console.ReadLine();

    Console.WriteLine("Enter year:");
    string? yearInput = Console.ReadLine();
    if (!int.TryParse(yearInput, out int year))
    {
        Console.WriteLine("Invalid year.");
        return;
    }

    Console.WriteLine("Enter registration number:");
    string? regNum = Console.ReadLine();

    Console.WriteLine("Enter registration date (yyyy-MM-dd):");
    string? regDateInput = Console.ReadLine();
    if (!DateTime.TryParse(regDateInput, out DateTime regDate))
    {
        Console.WriteLine("Invalid date.");
        return;
    }

    Console.WriteLine("Enter owner name (optional):");
    string? ownerName = Console.ReadLine();

    RegistrationInfo regInfo = new RegistrationInfo(regNum ?? "", regDate);

    Vehicule? vehicule = null;
    try
    {
        switch (type)
        {
            case VehiculeType.Car:
                vehicule = new Car(make ?? "", model ?? "", regInfo, year);
                break;
            case VehiculeType.Motorcycle:
                vehicule = new Motorcycle(make ?? "", model ?? "", regInfo, year);
                break;
            case VehiculeType.Truck:
                vehicule = new Truck(make ?? "", model ?? "", regInfo, year);
                break;
            default:
                Console.WriteLine("Unsupported vehicle type.");
                return;
        }

        vehicule.OwnerName = string.IsNullOrWhiteSpace(ownerName) ? null : ownerName;
        vehicles.Add(vehicule);
        Console.WriteLine("Vehicle added successfully!");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error adding vehicle: {ex.Message}");
    }
}

void DisplayAllVehicles(List<Vehicule> vehicles)
{
    if (vehicles.Count == 0)
    {
        Console.WriteLine("No vehicles to display.");
        return;
    }

    foreach (var v in vehicles)
    {
        v.DisplayInfo();
        Console.WriteLine("-------------------");
    }
}

VehiculeType? ParseVehicleType(string input)
{
    if (Enum.TryParse<VehiculeType>(input, true, out VehiculeType type))
    {
        return type;
    }
    else
    {
        Console.WriteLine("Invalid vehicle type. Please enter Car, Motorcycle, or Truck.");
        return null;
    }
}

void MainMenu()
{
    while (true)
    {
        Console.WriteLine("\nVehicle Management System");
        Console.WriteLine("1. Add Vehicle");
        Console.WriteLine("2. Display All Vehicles");
        Console.WriteLine("3. Exit");
        Console.Write("Select an option: ");
        string? choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                AddVehicle(vehicules);
                break;
            case "2":
                DisplayAllVehicles(vehicules);
                break;
            case "3":
                return;
            default:
                Console.WriteLine("Invalid option. Try again.");
                break;
        }
    }
}

// Entry point
MainMenu();

