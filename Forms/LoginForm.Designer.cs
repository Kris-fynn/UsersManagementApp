namespace UsersManagementApp.Forms
{
    partial class Login
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.LogoPictureBox = new System.Windows.Forms.PictureBox();
            this.UserName = new System.Windows.Forms.Label();
            this.UserNamTextBox = new System.Windows.Forms.TextBox();
            this.LoginButton = new System.Windows.Forms.Button();
            this.Password = new System.Windows.Forms.Label();
            this.PasswordTextBox = new System.Windows.Forms.TextBox();
            this.ExitButton = new System.Windows.Forms.Button();
            this.UserNameTextBox = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.LogoPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // LogoPictureBox
            // 
            this.LogoPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LogoPictureBox.Location = new System.Drawing.Point(8, 12);
            this.LogoPictureBox.Name = "LogoPictureBox";
            this.LogoPictureBox.Size = new System.Drawing.Size(424, 151);
            this.LogoPictureBox.TabIndex = 0;
            this.LogoPictureBox.TabStop = false;
            // 
            // UserName
            // 
            this.UserName.AutoSize = true;
            this.UserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.UserName.Location = new System.Drawing.Point(159, 189);
            this.UserName.Name = "UserName";
            this.UserName.Size = new System.Drawing.Size(0, 20);
            this.UserName.TabIndex = 1;
            // 
            // UserNamTextBox
            // 
            this.UserNamTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.UserNamTextBox.Location = new System.Drawing.Point(23, 212);
            this.UserNamTextBox.Name = "UserNamTextBox";
            this.UserNamTextBox.Size = new System.Drawing.Size(402, 26);
            this.UserNamTextBox.TabIndex = 0;
            this.UserNamTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // LoginButton
            // 
            this.LoginButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LoginButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.LoginButton.Location = new System.Drawing.Point(23, 321);
            this.LoginButton.Name = "LoginButton";
            this.LoginButton.Size = new System.Drawing.Size(180, 45);
            this.LoginButton.TabIndex = 2;
            this.LoginButton.Text = "Login To App";
            this.LoginButton.UseVisualStyleBackColor = true;
            this.LoginButton.Click += new System.EventHandler(this.LoginButton_Click);
            // 
            // Password
            // 
            this.Password.AutoSize = true;
            this.Password.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Password.Location = new System.Drawing.Point(159, 252);
            this.Password.Name = "Password";
            this.Password.Size = new System.Drawing.Size(0, 20);
            this.Password.TabIndex = 4;
            // 
            // PasswordTextBox
            // 
            this.PasswordTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.PasswordTextBox.Location = new System.Drawing.Point(23, 275);
            this.PasswordTextBox.Name = "PasswordTextBox";
            this.PasswordTextBox.Size = new System.Drawing.Size(402, 26);
            this.PasswordTextBox.TabIndex = 1;
            this.PasswordTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.PasswordTextBox.UseSystemPasswordChar = true;
            // 
            // ExitButton
            // 
            this.ExitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ExitButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.ExitButton.Location = new System.Drawing.Point(209, 321);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(216, 45);
            this.ExitButton.TabIndex = 3;
            this.ExitButton.Text = "Exit App";
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // UserNameTextBox
            // 
            this.UserNameTextBox.AutoSize = true;
            this.UserNameTextBox.Location = new System.Drawing.Point(187, 189);
            this.UserNameTextBox.Name = "UserNameTextBox";
            this.UserNameTextBox.Size = new System.Drawing.Size(0, 13);
            this.UserNameTextBox.TabIndex = 5;
            this.UserNameTextBox.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(165, 184);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "User Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(165, 252);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "Password";
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(438, 387);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.UserNameTextBox);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.PasswordTextBox);
            this.Controls.Add(this.Password);
            this.Controls.Add(this.LoginButton);
            this.Controls.Add(this.UserNamTextBox);
            this.Controls.Add(this.UserName);
            this.Controls.Add(this.LogoPictureBox);
            this.Name = "Login";
            this.Text = "Login";
            ((System.ComponentModel.ISupportInitialize)(this.LogoPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox LogoPictureBox;
        private System.Windows.Forms.Label UserName;
        private System.Windows.Forms.TextBox UserNamTextBox;
        private System.Windows.Forms.Button LoginButton;
        private System.Windows.Forms.Label Password;
        private System.Windows.Forms.TextBox PasswordTextBox;
        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.Label UserNameTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}