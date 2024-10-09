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
            if (DogStorage.registry.ContainsKey(ID)) {
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
            if (DogStorage.registry.ContainsKey(ID)) {
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
            DogStorage.Add(ID, dog);
            MessageBox.Show("Registration Successful");
        }

        private void EditButton_Click(object sender, EventArgs e) {
            string ID = IDTextBox.Text;
            if (ID == "") {
                MessageBox.Show("Enter an ID");
                return;
            }
            if (!DogStorage.registry.ContainsKey(ID)) {
                MessageBox.Show("A dog with this Tag ID is not registered.");
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
            if (MessageBox.Show("Are you sure you want to proceed?", "Alert!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No) return;
            DogStorage.Edit(ID, dog);
            MessageBox.Show("Edit Successful");
        }
    }
}
