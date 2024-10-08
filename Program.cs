using System;
using System.IO;
using System.Collections.Generic;

internal class Program {
    static Dictionary<string, Dog> registry = [];
    static string path = "register.dg";
    class Dog {
        string ID;
        string Breed;
        int Age;
        float Height;
        float Weight;
        string Location;
        string OwnerName;
        string HouseNumber;
        public Dog(string id, string breed, int age, float height, float weight, string location, string owner_name, string house_number) {
            ID = id;
            Breed = breed;
            Age = age;
            Height = height;
            Weight = weight;
            Location = location;
            OwnerName = owner_name;
            HouseNumber = house_number;
        }
        public string ToEntry() {
            return $"{ID}|{Breed}|{Age}|{Height}|{Weight}|{Location}|{OwnerName}|{HouseNumber}|";
        }
        public override string ToString() {
            return $"\nDog Details:\nBreed: {Breed}\nAge: {Age}\nHeight: {Height} cm\nWeight: {Weight} kg\nLocation: {Location}\nOwner's Name: {OwnerName}\nHouse Number: {HouseNumber}";
        }
    }
    static void Main(string[] args) {
        Setup();
        while (true) {
            Console.WriteLine("\nDog Registry System");
            Console.WriteLine("1. Register a new dog");
            Console.WriteLine("2. Search for a dog by Tag ID");
            Console.WriteLine("3. Exit");
            Console.Write("Choose an option: ");
            switch (Console.ReadLine()) {
                case "1":
                    RegisterNewDog();
                    break;
                case "2":
                    RetrieveDogDetails();
                    break;
                case "3":
                    Console.WriteLine("Exiting the program...");
                    return;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }
    static void ParseFile(string text) {
        if (string.IsNullOrEmpty(text)) return;
        try {
            foreach (string entry in text.Split("\n")) {
                if (string.IsNullOrEmpty(entry)) continue;
                List<string> records = [];
                string record = "";
                foreach (char ch in entry) {
                    if (ch == '|') {
                        records.Add(record);
                        record = "";
                    } else {
                        record += ch;
                    }
                }
                if (records.Count != 8) { throw new Exception(); }
                registry.Add(records[0], new Dog( records[0], records[1], int.Parse(records[2]), float.Parse(records[3]), float.Parse(records[4]), records[5], records[6], records[7]) );
            }
        } catch {
            Console.WriteLine("Database is corrupted... Creating new one");
            registry.Clear();
            File.WriteAllText(path, "");
        }
    }
    static void Setup() {
        try {
            ParseFile(File.ReadAllText(path));
        } catch {
            Console.WriteLine("Database not found... Creating new one");
            File.WriteAllText(path, "");
        }
    }
    static void RegisterNewDog() {
        Console.WriteLine("\nRegistering a new dog:");
        
        string ID = GetInput<string>("Enter Dog Tag ID: ");
        if (registry.ContainsKey(ID)) {
            Console.WriteLine("A dog with this Tag ID is already registered.");
            return;
        }

        string breed = GetInput<string>("Enter Dog Breed: ");
        int age = GetInput<int>("Enter Dog Age: ");
        float height = GetInput<float>("Enter Dog Height (in cm): ");
        float weight = GetInput<float>("Enter Dog Weight (in kg): ");
        string location = GetInput<string>("Enter Location: ");
        string owner_name = GetInput<string>("Enter Owner's Name: ");
        string house_number = GetInput<string>("Enter Owner's House Number: ");

        Dog dog = new(ID, breed, age, height, weight, location, owner_name, house_number);
        registry.Add(ID, dog);
        using (StreamWriter writer = File.AppendText(path)) { writer.WriteLine(dog.ToEntry()); }

        Console.WriteLine("Dog successfully registered with Tag ID: " + ID);
    }
    static void RetrieveDogDetails() {
        Console.WriteLine("\nSearching for a dog:");
        string ID = GetInput<string>("Enter the Dog Tag ID: ");

        if (registry.TryGetValue(ID, out Dog? dog)) {
            Console.WriteLine(dog);
        }
        else {
            Console.WriteLine("Dog Tag ID not found.");
        }
    }
    static T GetInput<T>(string prompt) {
        while (true) {
            Console.Write(prompt);
            string? response = Console.ReadLine();
            if (typeof(T) == typeof(string) && !string.IsNullOrWhiteSpace(response)) {
                return (T)(object)response;
            }
            else if (typeof(T) == typeof(float)) {
                bool success = float.TryParse(response, out float data);
                if (success) {
                    return (T)(object)data;
                }
            }
            else if (typeof(T) == typeof(int)) {
                bool success = int.TryParse(response, out int data);
                if (success) {
                    return (T)(object)data;
                }
            }
            Console.WriteLine("Invalid Input. Please try again");
        }
    }
}