namespace ItemsApp
{
    partial class frmUser
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblName = new System.Windows.Forms.Label();
            this.EmailLabel = new System.Windows.Forms.Label();
            this.PhoneLabel = new System.Windows.Forms.Label();
            this.AddressLabel = new System.Windows.Forms.Label();
            this.GenderLabel = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.optMale = new System.Windows.Forms.RadioButton();
            this.optFemale = new System.Windows.Forms.RadioButton();
            this.optOthers = new System.Windows.Forms.RadioButton();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.lblUserName = new System.Windows.Forms.Label();
            this.txtConfirmPassword = new System.Windows.Forms.TextBox();
            this.lblConfirmPassword = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblName.Location = new System.Drawing.Point(107, 30);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(51, 19);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "Name";
            // 
            // EmailLabel
            // 
            this.EmailLabel.AutoSize = true;
            this.EmailLabel.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.EmailLabel.Location = new System.Drawing.Point(689, 30);
            this.EmailLabel.Name = "EmailLabel";
            this.EmailLabel.Size = new System.Drawing.Size(49, 19);
            this.EmailLabel.TabIndex = 2;
            this.EmailLabel.Text = "Email";
            // 
            // PhoneLabel
            // 
            this.PhoneLabel.AutoSize = true;
            this.PhoneLabel.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.PhoneLabel.Location = new System.Drawing.Point(680, 95);
            this.PhoneLabel.Name = "PhoneLabel";
            this.PhoneLabel.Size = new System.Drawing.Size(56, 19);
            this.PhoneLabel.TabIndex = 3;
            this.PhoneLabel.Text = "Phone";
            // 
            // AddressLabel
            // 
            this.AddressLabel.AutoSize = true;
            this.AddressLabel.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.AddressLabel.Location = new System.Drawing.Point(667, 158);
            this.AddressLabel.Name = "AddressLabel";
            this.AddressLabel.Size = new System.Drawing.Size(69, 19);
            this.AddressLabel.TabIndex = 4;
            this.AddressLabel.Text = "Address";
            // 
            // GenderLabel
            // 
            this.GenderLabel.AutoSize = true;
            this.GenderLabel.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.GenderLabel.Location = new System.Drawing.Point(671, 229);
            this.GenderLabel.Name = "GenderLabel";
            this.GenderLabel.Size = new System.Drawing.Size(63, 19);
            this.GenderLabel.TabIndex = 8;
            this.GenderLabel.Text = "Gender";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(178, 26);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(378, 27);
            this.txtName.TabIndex = 9;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(747, 26);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(378, 27);
            this.txtEmail.TabIndex = 10;
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(747, 91);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(378, 27);
            this.txtPhone.TabIndex = 12;
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(747, 154);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(378, 27);
            this.txtAddress.TabIndex = 16;
            // 
            // optMale
            // 
            this.optMale.AutoSize = true;
            this.optMale.Location = new System.Drawing.Point(760, 225);
            this.optMale.Name = "optMale";
            this.optMale.Size = new System.Drawing.Size(63, 24);
            this.optMale.TabIndex = 19;
            this.optMale.TabStop = true;
            this.optMale.Text = "Male";
            this.optMale.UseVisualStyleBackColor = true;
            // 
            // optFemale
            // 
            this.optFemale.AutoSize = true;
            this.optFemale.Location = new System.Drawing.Point(865, 225);
            this.optFemale.Name = "optFemale";
            this.optFemale.Size = new System.Drawing.Size(78, 24);
            this.optFemale.TabIndex = 20;
            this.optFemale.TabStop = true;
            this.optFemale.Text = "Female";
            this.optFemale.UseVisualStyleBackColor = true;
            // 
            // optOthers
            // 
            this.optOthers.AutoSize = true;
            this.optOthers.Location = new System.Drawing.Point(993, 225);
            this.optOthers.Name = "optOthers";
            this.optOthers.Size = new System.Drawing.Size(73, 24);
            this.optOthers.TabIndex = 21;
            this.optOthers.TabStop = true;
            this.optOthers.Text = "Others";
            this.optOthers.UseVisualStyleBackColor = true;
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(178, 91);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(378, 27);
            this.txtUserName.TabIndex = 11;
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblUserName.Location = new System.Drawing.Point(75, 95);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(83, 19);
            this.lblUserName.TabIndex = 26;
            this.lblUserName.Text = "Username";
            // 
            // txtConfirmPassword
            // 
            this.txtConfirmPassword.Location = new System.Drawing.Point(181, 224);
            this.txtConfirmPassword.Name = "txtConfirmPassword";
            this.txtConfirmPassword.PasswordChar = '*';
            this.txtConfirmPassword.Size = new System.Drawing.Size(378, 27);
            this.txtConfirmPassword.TabIndex = 14;
            // 
            // lblConfirmPassword
            // 
            this.lblConfirmPassword.AutoSize = true;
            this.lblConfirmPassword.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblConfirmPassword.Location = new System.Drawing.Point(16, 228);
            this.lblConfirmPassword.Name = "lblConfirmPassword";
            this.lblConfirmPassword.Size = new System.Drawing.Size(143, 19);
            this.lblConfirmPassword.TabIndex = 28;
            this.lblConfirmPassword.Text = "Confirm Password";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(180, 154);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(378, 27);
            this.txtPassword.TabIndex = 13;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblPassword.Location = new System.Drawing.Point(77, 158);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(80, 19);
            this.lblPassword.TabIndex = 30;
            this.lblPassword.Text = "Password";
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(462, 352);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(104, 45);
            this.btnSubmit.TabIndex = 23;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(667, 352);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(103, 45);
            this.btnClear.TabIndex = 24;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(1022, 426);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(103, 37);
            this.btnExit.TabIndex = 31;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // frmUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1141, 488);
            this.ControlBox = false;
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.txtConfirmPassword);
            this.Controls.Add(this.lblConfirmPassword);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.lblUserName);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.optOthers);
            this.Controls.Add(this.optFemale);
            this.Controls.Add(this.optMale);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.GenderLabel);
            this.Controls.Add(this.AddressLabel);
            this.Controls.Add(this.PhoneLabel);
            this.Controls.Add(this.EmailLabel);
            this.Controls.Add(this.lblName);
            this.Name = "frmUser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "User Module";
            this.Load += new System.EventHandler(this.frmUser_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Label lblName;
        private Label EmailLabel;
        private Label PhoneLabel;
        private Label AddressLabel;
        private Label GenderLabel;
        private TextBox txtName;
        private TextBox txtEmail;
        private TextBox txtPhone;
        private TextBox txtAddress;
        private RadioButton optMale;
        private RadioButton optFemale;
        private RadioButton optOthers;
        private Button btnAddDept;
        private TextBox txtUserName;
        private Label lblUserName;
        private TextBox txtConfirmPassword;
        private Label lblConfirmPassword;
        private TextBox txtPassword;
        private Label lblPassword;
        private Button btnSubmit;
        private Button btnClear;
        private Button btnExit;
    }
}