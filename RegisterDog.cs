using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Dog_tracker.UI;

namespace Dog_tracker {
    public partial class RegisterDog : Form {
        public RegisterDog() {
            InitializeComponent();
        }
        public void HideWindow() { Hide(); }
        private void CheckIDButton_Click(object sender, EventArgs e) {
            string ID = IDTextBox.Text;
            if (ID == "") {
                MessageBox.Show("Enter an ID");
                return;
            }
            if (registry.ContainsKey(ID)) {
                MessageBox.Show("A dog with this Tag ID is already registered.");
            } else {
                MessageBox.Show("ID is Unregistered.");

            }
        }
        private void RegisterButton_Click(object sender, EventArgs e) {
            string ID = IDTextBox.Text;
            if (ID == "") {
                MessageBox.Show("Enter an ID");
                return;
            }
            if (registry.ContainsKey(ID)) {
                MessageBox.Show("A dog with this Tag ID is already registered.");
                return;
            }
            string breed = BreedInput.Text;
            int age = Convert.ToInt32(AgeInput.Value);
            double height = Convert.ToDouble(HeightInput.Value);
            double weight = Convert.ToDouble(WeightInput.Value);
            string location = LocationInput.Text;
            string owner_name = OwnerNameInput.Text;
            string house_number = HouseNumberInput.Text;

            Dog dog = new Dog(ID, breed, age, height, weight, location, owner_name, house_number);
            registry.Add(ID, dog);
            using (StreamWriter writer = File.AppendText(path)) { writer.WriteLine(dog.ToEntry()); }
            MessageBox.Show("Registration Successful");
        }
    }
}
