using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
        public static string path = "register.dg";
        public static Dictionary<string, Dog> registry = new Dictionary<string, Dog>();
        void Setup() {
            try {
                ParseFile(File.ReadAllText(path));
            }
            catch {
                Console.WriteLine("Database not found... Creating new one");
                File.WriteAllText(path, "");
            }
        }
        void ParseFile(string text) {
            if (string.IsNullOrEmpty(text)) return;
            try {
                foreach (string entry in text.Split('\n')) {
                    if (string.IsNullOrEmpty(entry)) continue;
                    List<string> records = new List<string>();
                    string record = "";
                    foreach (char ch in entry) {
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
                Console.WriteLine("Database is corrupted... Creating new one");
                registry.Clear();
                File.WriteAllText(path, "");
            }
        }
        public UI() {
            Setup();
            InitializeComponent();
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
