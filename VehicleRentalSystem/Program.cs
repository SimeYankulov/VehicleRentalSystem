using System.Security.Cryptography.X509Certificates;
using VehicleRentalSystem.Entities;

public static class Program
{
    static List<Vehicle> vehicles = new List<Vehicle>();
    static List<Customer> customers = new List<Customer>();
    static List<Rental> rentals = new List<Rental>();
    public static void Main()
    {
        SeedData();

        foreach(var rental in rentals)
        {
            rental.PrintInfo();
        }

    }

    static void SeedData()
    {
        vehicles.Add(new Car("Mitsubishi","Mirage",15000.0,3));
        vehicles.Add(new Motorcycle("Triump", "Tiger Sport 660", 10000.0));
        vehicles.Add(new CargoVan("Citroen", "Jumper", 20000.0));

        customers.Add(new Customer("John Doe", 0, 0));
        customers.Add(new Customer("Mary Johnson", 20, 0));
        customers.Add(new Customer("John Markson", 0, 8));

        rentals.Add(new Rental(
                DateOnly.Parse("2024-06-13"),
                vehicles[0],
                customers[0],
                DateTime.Parse("2024-06-03"),
                DateTime.Parse("2024-06-13"),
                DateTime.Parse("2024-06-13")
            ));
        rentals.Add(new Rental(
                DateOnly.Parse("2024-06-13"),
                vehicles[1],
                customers[1],
                DateTime.Parse("2024-06-03"),
                DateTime.Parse("2024-06-13"),
                DateTime.Parse("2024-06-13")
            ));
        rentals.Add(new Rental(
                DateOnly.Parse("2024-06-13"),
                vehicles[2],
                customers[2],
                DateTime.Parse("2024-06-03"),
                DateTime.Parse("2024-06-18"),
                DateTime.Parse("2024-06-13")
            ));

    }
}