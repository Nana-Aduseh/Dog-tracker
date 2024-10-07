using System;
using System.Collections.Generic;

class Program
{
    // Dog class to represent a dog's details
    class Dog
    {
        public string Breed { get; set; }
        public int Age { get; set; }
        public float Height { get; set; }
        public float Weight { get; set; } // Added weight field
        public string Location { get; set; } // Added location field
        public string OwnerName { get; set; }
        public string HouseNumber { get; set; }
    }

    // Dictionary to store registered dogs using their Tag ID as the key
    static Dictionary<string, Dog> dogRegistry = new Dictionary<string, Dog>();

    static void Main()
    {
        // Add some initial dog entries for testing
        dogRegistry.Add("DOG001", new Dog { Breed = "Golden Retriever", Age = 3, Height = 55.2f, Weight = 28.3f, Location = "Park", OwnerName = "Immanuel", HouseNumber = "12A" });
        dogRegistry.Add("DOG002", new Dog { Breed = "Bulldog", Age = 2, Height = 40.1f, Weight = 23.0f, Location = "Garden", OwnerName = "Bernard", HouseNumber = "34B" });
        dogRegistry.Add("DOG003", new Dog { Breed = "St. Bernards", Age = 4, Height = 65.3f, Weight = 80.5f, Location = "Yard", OwnerName = "Anim", HouseNumber = "8D" });
        dogRegistry.Add("DOG004", new Dog { Breed = "Dalmatian", Age = 6, Height = 45.3f, Weight = 20.8f, Location = "Street", OwnerName = "Mickey", HouseNumber = "15C" });
        dogRegistry.Add("DOG005", new Dog { Breed = "German Shepherd", Age = 4, Height = 65.3f, Weight = 30.5f, Location = "Park", OwnerName = "Ann", HouseNumber = "25E" });

        // Home menu loop
        while (true)
        {
            Console.WriteLine("\nDog Registry System");
            Console.WriteLine("1. Register a new dog");
            Console.WriteLine("2. Search for a dog by Tag ID");
            Console.WriteLine("3. Exit");
            Console.Write("Choose an option: ");

            string option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    RegisterNewDog();
                    break;
                case "2":
                    RetrieveDogDetails();
                    break;
                case "3":
                    Console.WriteLine("Exiting the program...");
                    return; // Exit the program
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }

    // Function to register a new dog
    static void RegisterNewDog()
    {
        Console.WriteLine("\nRegistering a new dog:");

        // Collect dog details from the user
        Console.Write("Enter Dog Tag ID: ");
        string tagId = Console.ReadLine();

        if (dogRegistry.ContainsKey(tagId))
        {
            Console.WriteLine("A dog with this Tag ID is already registered.");
            return;
        }

        Console.Write("Enter Dog Breed: ");
        string breed = Console.ReadLine();

        Console.Write("Enter Dog Age: ");
        int age = int.Parse(Console.ReadLine());

        Console.Write("Enter Dog Height (in cm): ");
        float height = float.Parse(Console.ReadLine());

        Console.Write("Enter Dog Weight (in kg): "); // Collect weight
        float weight = float.Parse(Console.ReadLine());

        Console.Write("Enter Location: "); // Collect location
        string location = Console.ReadLine();

        Console.Write("Enter Owner's Name: ");
        string ownerName = Console.ReadLine();

        Console.Write("Enter Owner's House Number: ");
        string houseNumber = Console.ReadLine();

        // Create a new dog object
        Dog newDog = new Dog
        {
            Breed = breed,
            Age = age,
            Height = height,
            Weight = weight, // Store weight
            Location = location, // Store location
            OwnerName = ownerName,
            HouseNumber = houseNumber
        };

        // Add the new dog to the registry
        dogRegistry.Add(tagId, newDog);
        Console.WriteLine("Dog successfully registered with Tag ID: " + tagId);
    }

    // Function to retrieve and display dog details based on Tag ID
    static void RetrieveDogDetails()
    {
        Console.WriteLine("\nSearching for a dog:");

        // Prompt for user to enter a dog tag ID
        Console.Write("Enter the Dog Tag ID: ");
        string tagId = Console.ReadLine();

        // Check if the dog tag ID exists in the registry
        if (dogRegistry.ContainsKey(tagId))
        {
            Dog dog = dogRegistry[tagId];
            Console.WriteLine("\nDog Details:");
            Console.WriteLine($"Breed: {dog.Breed}");
            Console.WriteLine($"Age: {dog.Age}");
            Console.WriteLine($"Height: {dog.Height} cm");
            Console.WriteLine($"Weight: {dog.Weight} kg"); // Display weight
            Console.WriteLine($"Location: {dog.Location}"); // Display location
            Console.WriteLine($"Owner's Name: {dog.OwnerName}");
            Console.WriteLine($"House Number: {dog.HouseNumber}");
        }
        else
        {
            Console.WriteLine("Dog Tag ID not found.");
        }
    }
}
