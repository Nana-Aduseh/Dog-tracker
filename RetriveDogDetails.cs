using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Dog_tracker.UI;

namespace Dog_tracker {
    public partial class RetriveDogDetails : Form {
        public RetriveDogDetails() {
            InitializeComponent();
        }
        public void HideWindow() { Hide(); }
        private void RetriveButton_Click(object sender, EventArgs e) {
            if (DogStorage.registry.TryGetValue(IDTextBox.Text, out Dog dog)) {
                OutputTextBox.Text = dog.ToString();
            }
            else {
                MessageBox.Show("Dog Tag ID not found.");
            }
        }
    }
}
