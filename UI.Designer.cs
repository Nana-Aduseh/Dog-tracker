namespace Dog_tracker {
    partial class UI {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.RegisterDogButton = new System.Windows.Forms.Button();
            this.RetriveDogDetailsButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // RegisterDogButton
            // 
            this.RegisterDogButton.Location = new System.Drawing.Point(45, 61);
            this.RegisterDogButton.Name = "RegisterDogButton";
            this.RegisterDogButton.Size = new System.Drawing.Size(102, 34);
            this.RegisterDogButton.TabIndex = 0;
            this.RegisterDogButton.Text = "Register Dog";
            this.RegisterDogButton.UseVisualStyleBackColor = true;
            this.RegisterDogButton.Click += new System.EventHandler(this.RegisterDog_Click);
            // 
            // RetriveDogDetailsButton
            // 
            this.RetriveDogDetailsButton.Location = new System.Drawing.Point(177, 61);
            this.RetriveDogDetailsButton.Name = "RetriveDogDetailsButton";
            this.RetriveDogDetailsButton.Size = new System.Drawing.Size(133, 34);
            this.RetriveDogDetailsButton.TabIndex = 1;
            this.RetriveDogDetailsButton.Text = "Retrive Dog Details";
            this.RetriveDogDetailsButton.UseVisualStyleBackColor = true;
            this.RetriveDogDetailsButton.Click += new System.EventHandler(this.RetriveDogDetails_Click);
            // 
            // UI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(350, 172);
            this.Controls.Add(this.RetriveDogDetailsButton);
            this.Controls.Add(this.RegisterDogButton);
            this.Name = "UI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DogTracker";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button RegisterDogButton;
        private System.Windows.Forms.Button RetriveDogDetailsButton;
    }
}