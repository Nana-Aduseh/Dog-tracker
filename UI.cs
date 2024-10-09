using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Dog_tracker.UI;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.LinkLabel;

namespace Dog_tracker {
    public partial class UI : Form {
        public class Dog {
            string ID;
            string Breed;
            int Age;
            double Height;
            double Weight;
            string Location;
            string OwnerName;
            string HouseNumber;
            public Dog(string id, string breed, int age, double height, double weight, string location, string owner_name, string house_number) {
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
                return $"Dog Details:\nBreed: {Breed}\nAge: {Age}\nHeight: {Height} cm\nWeight: {Weight} kg\nLocation: {Location}\nOwner's Name: {OwnerName}\nHouse Number: {HouseNumber}";
            }
        }
        public class DogStorage {
            public static Dictionary<string, Dog> registry = new Dictionary<string, Dog>();
            public static string path = "register.dg";
            private static Dictionary<string, ulong> Index = new Dictionary<string, ulong>();
            private static string[] storage;
            public static void Setup() {
                Load();
                Parse();
            }
            public static void Edit(string ID, Dog dog) {
                storage[Index[ID]] = dog.ToEntry();
                registry[ID] = dog;
                File.WriteAllText(path, string.Join("\n", storage));
                File.Encrypt(path);
            }
            public static void Save() {
                List<string> save = new List<string>();
                string indexes = "";
                foreach (string ID in Index.Keys) {
                    indexes += ID + "|";
                }
                save.Add(indexes);
                foreach (Dog dog in registry.Values) {
                    save.Add(dog.ToEntry());
                }
                storage = save.ToArray();
                File.WriteAllText(path, string.Join("\n", storage));
                File.Encrypt(path);
            }
            private static void Load() {
                try {
                    File.Decrypt(path);
                    storage = File.ReadAllLines(path);
                    File.Encrypt(path);

                }
                catch {
                    MessageBox.Show("Database not found... Creating new one");
                    storage = new string[] { };
                    File.WriteAllText(path, "");
                    File.Encrypt(path);
                }
            }
            private static void Parse() {
                if (storage.Length == 0) return;
                try {
                    string ID = "";
                    ulong index = 1;
                    foreach (char ch in storage[0]) {
                        if (ch == '|') {
                            Index.Add(ID, index);
                            ID = "";
                            index += 1;
                        }
                        else {
                            ID += ch;
                        }
                    }
                    for (int i = 1; i < storage.Length; i++) {
                        if (string.IsNullOrEmpty(storage[i])) continue;
                        List<string> records = new List<string>();
                        string record = "";
                        foreach (char ch in storage[i]) {
                            if (ch == '|') {
                                records.Add(record);
                                record = "";
                            }
                            else {
                                record += ch;
                            }
                        }
                        if (records.Count != 8) { throw new Exception(); }
                        registry.Add(records[0], new Dog(records[0], records[1], int.Parse(records[2]), double.Parse(records[3]), double.Parse(records[4]), records[5], records[6], records[7]));
                    }
                }
                catch {
                    MessageBox.Show("Database is corrupted... Creating new one");
                    registry.Clear();
                    File.WriteAllText(path, "");
                }
            }
            public static void Add(string ID, Dog dog) {
                Index.Add(ID, (ulong) Index.Count);
                registry.Add(ID, dog);
                Save();
            }
            public static void Remove(string ID) {
                Index.Remove(ID);
                registry.Remove(ID);
                Save();
            }
        }
        public UI() {
            InitializeComponent();
            DogStorage.Setup();
        }
        private void RegisterDog_Click(object sender, EventArgs e) {
            Form RegisterDogUI = new RegisterDog();
            RegisterDogUI.ShowDialog();
        }
        private void RetriveDogDetails_Click(object sender, EventArgs e) {
            Form RetriveDogDetailsUI = new RetriveDogDetails();
            RetriveDogDetailsUI.ShowDialog();
        }
    }
}
