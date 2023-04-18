namespace ItemsApp
{
    partial class frmUserAdmin
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
            this.ugUserList = new System.Windows.Forms.DataGridView();
            this.lblName = new System.Windows.Forms.Label();
            this.EmailLabel = new System.Windows.Forms.Label();
            this.PhoneLabel = new System.Windows.Forms.Label();
            this.AddressLabel = new System.Windows.Forms.Label();
            this.RoleLabel = new System.Windows.Forms.Label();
            this.DepartmentLabel = new System.Windows.Forms.Label();
            this.JoinDateLabel = new System.Windows.Forms.Label();
            this.GenderLabel = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.cmbRole = new System.Windows.Forms.ComboBox();
            this.cmbDepartment = new System.Windows.Forms.ComboBox();
            this.dtpJoinDate = new System.Windows.Forms.DateTimePicker();
            this.optMale = new System.Windows.Forms.RadioButton();
            this.optFemale = new System.Windows.Forms.RadioButton();
            this.optOthers = new System.Windows.Forms.RadioButton();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnAddRole = new System.Windows.Forms.Button();
            this.cmbDesignation = new System.Windows.Forms.ComboBox();
            this.lblDesignation = new System.Windows.Forms.Label();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.lblUserName = new System.Windows.Forms.Label();
            this.txtConfirmPassword = new System.Windows.Forms.TextBox();
            this.lblConfirmPassword = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ugUserList)).BeginInit();
            this.SuspendLayout();
            // 
            // ugUserList
            // 
            this.ugUserList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ugUserList.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ugUserList.Location = new System.Drawing.Point(0, 513);
            this.ugUserList.Name = "ugUserList";
            this.ugUserList.ReadOnly = true;
            this.ugUserList.RowHeadersWidth = 51;
            this.ugUserList.RowTemplate.Height = 29;
            this.ugUserList.Size = new System.Drawing.Size(1164, 236);
            this.ugUserList.TabIndex = 0;
            this.ugUserList.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ugUserList_CellDoubleClick);
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
            this.PhoneLabel.Location = new System.Drawing.Point(680, 80);
            this.PhoneLabel.Name = "PhoneLabel";
            this.PhoneLabel.Size = new System.Drawing.Size(56, 19);
            this.PhoneLabel.TabIndex = 3;
            this.PhoneLabel.Text = "Phone";
            // 
            // AddressLabel
            // 
            this.AddressLabel.AutoSize = true;
            this.AddressLabel.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.AddressLabel.Location = new System.Drawing.Point(663, 180);
            this.AddressLabel.Name = "AddressLabel";
            this.AddressLabel.Size = new System.Drawing.Size(69, 19);
            this.AddressLabel.TabIndex = 4;
            this.AddressLabel.Text = "Address";
            // 
            // RoleLabel
            // 
            this.RoleLabel.AutoSize = true;
            this.RoleLabel.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.RoleLabel.Location = new System.Drawing.Point(688, 230);
            this.RoleLabel.Name = "RoleLabel";
            this.RoleLabel.Size = new System.Drawing.Size(41, 19);
            this.RoleLabel.TabIndex = 5;
            this.RoleLabel.Text = "Role";
            // 
            // DepartmentLabel
            // 
            this.DepartmentLabel.AutoSize = true;
            this.DepartmentLabel.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.DepartmentLabel.Location = new System.Drawing.Point(65, 230);
            this.DepartmentLabel.Name = "DepartmentLabel";
            this.DepartmentLabel.Size = new System.Drawing.Size(93, 19);
            this.DepartmentLabel.TabIndex = 6;
            this.DepartmentLabel.Text = "Department";
            // 
            // JoinDateLabel
            // 
            this.JoinDateLabel.AutoSize = true;
            this.JoinDateLabel.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.JoinDateLabel.Location = new System.Drawing.Point(650, 280);
            this.JoinDateLabel.Name = "JoinDateLabel";
            this.JoinDateLabel.Size = new System.Drawing.Size(79, 19);
            this.JoinDateLabel.TabIndex = 7;
            this.JoinDateLabel.Text = "Join Date";
            // 
            // GenderLabel
            // 
            this.GenderLabel.AutoSize = true;
            this.GenderLabel.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.GenderLabel.Location = new System.Drawing.Point(88, 280);
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
            this.txtPhone.Location = new System.Drawing.Point(747, 76);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(378, 27);
            this.txtPhone.TabIndex = 12;
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(747, 176);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(378, 27);
            this.txtAddress.TabIndex = 16;
            // 
            // cmbRole
            // 
            this.cmbRole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRole.FormattingEnabled = true;
            this.cmbRole.Location = new System.Drawing.Point(747, 226);
            this.cmbRole.Name = "cmbRole";
            this.cmbRole.Size = new System.Drawing.Size(378, 28);
            this.cmbRole.TabIndex = 18;
            // 
            // cmbDepartment
            // 
            this.cmbDepartment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDepartment.FormattingEnabled = true;
            this.cmbDepartment.Items.AddRange(new object[] {
            "Mobile",
            "Web",
            "Desktop",
            "Human Resource"});
            this.cmbDepartment.Location = new System.Drawing.Point(178, 226);
            this.cmbDepartment.Name = "cmbDepartment";
            this.cmbDepartment.Size = new System.Drawing.Size(378, 28);
            this.cmbDepartment.TabIndex = 17;
            // 
            // dtpJoinDate
            // 
            this.dtpJoinDate.Location = new System.Drawing.Point(747, 276);
            this.dtpJoinDate.Name = "dtpJoinDate";
            this.dtpJoinDate.Size = new System.Drawing.Size(378, 27);
            this.dtpJoinDate.TabIndex = 22;
            // 
            // optMale
            // 
            this.optMale.AutoSize = true;
            this.optMale.Location = new System.Drawing.Point(177, 276);
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
            this.optFemale.Location = new System.Drawing.Point(282, 276);
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
            this.optOthers.Location = new System.Drawing.Point(410, 276);
            this.optOthers.Name = "optOthers";
            this.optOthers.Size = new System.Drawing.Size(73, 24);
            this.optOthers.TabIndex = 21;
            this.optOthers.TabStop = true;
            this.optOthers.Text = "Others";
            this.optOthers.UseVisualStyleBackColor = true;
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(282, 421);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(94, 29);
            this.btnSubmit.TabIndex = 23;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(434, 421);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(94, 29);
            this.btnClear.TabIndex = 24;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Enabled = false;
            this.btnUpdate.Location = new System.Drawing.Point(582, 421);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(94, 29);
            this.btnUpdate.TabIndex = 21;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Enabled = false;
            this.btnDelete.Location = new System.Drawing.Point(731, 421);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(94, 29);
            this.btnDelete.TabIndex = 22;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnAddRole
            // 
            this.btnAddRole.Location = new System.Drawing.Point(876, 421);
            this.btnAddRole.Name = "btnAddRole";
            this.btnAddRole.Size = new System.Drawing.Size(94, 29);
            this.btnAddRole.TabIndex = 26;
            this.btnAddRole.Text = "Adder";
            this.btnAddRole.UseVisualStyleBackColor = true;
            this.btnAddRole.Click += new System.EventHandler(this.btnAddRole_Click);
            // 
            // cmbDesignation
            // 
            this.cmbDesignation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDesignation.FormattingEnabled = true;
            this.cmbDesignation.Location = new System.Drawing.Point(747, 126);
            this.cmbDesignation.Name = "cmbDesignation";
            this.cmbDesignation.Size = new System.Drawing.Size(378, 28);
            this.cmbDesignation.TabIndex = 15;
            // 
            // lblDesignation
            // 
            this.lblDesignation.AutoSize = true;
            this.lblDesignation.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblDesignation.Location = new System.Drawing.Point(645, 130);
            this.lblDesignation.Name = "lblDesignation";
            this.lblDesignation.Size = new System.Drawing.Size(95, 19);
            this.lblDesignation.TabIndex = 25;
            this.lblDesignation.Text = "Designation";
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(178, 76);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(378, 27);
            this.txtUserName.TabIndex = 11;
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblUserName.Location = new System.Drawing.Point(75, 80);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(83, 19);
            this.lblUserName.TabIndex = 26;
            this.lblUserName.Text = "Username";
            // 
            // txtConfirmPassword
            // 
            this.txtConfirmPassword.Location = new System.Drawing.Point(180, 176);
            this.txtConfirmPassword.Name = "txtConfirmPassword";
            this.txtConfirmPassword.PasswordChar = '*';
            this.txtConfirmPassword.Size = new System.Drawing.Size(378, 27);
            this.txtConfirmPassword.TabIndex = 14;
            // 
            // lblConfirmPassword
            // 
            this.lblConfirmPassword.AutoSize = true;
            this.lblConfirmPassword.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblConfirmPassword.Location = new System.Drawing.Point(15, 180);
            this.lblConfirmPassword.Name = "lblConfirmPassword";
            this.lblConfirmPassword.Size = new System.Drawing.Size(143, 19);
            this.lblConfirmPassword.TabIndex = 28;
            this.lblConfirmPassword.Text = "Confirm Password";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(180, 126);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(378, 27);
            this.txtPassword.TabIndex = 13;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblPassword.Location = new System.Drawing.Point(77, 130);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(80, 19);
            this.lblPassword.TabIndex = 30;
            this.lblPassword.Text = "Password";
            // 
            // frmUserAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1164, 749);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.txtConfirmPassword);
            this.Controls.Add(this.lblConfirmPassword);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.lblUserName);
            this.Controls.Add(this.lblDesignation);
            this.Controls.Add(this.cmbDesignation);
            this.Controls.Add(this.btnAddRole);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.optOthers);
            this.Controls.Add(this.optFemale);
            this.Controls.Add(this.optMale);
            this.Controls.Add(this.dtpJoinDate);
            this.Controls.Add(this.cmbDepartment);
            this.Controls.Add(this.cmbRole);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.GenderLabel);
            this.Controls.Add(this.JoinDateLabel);
            this.Controls.Add(this.DepartmentLabel);
            this.Controls.Add(this.RoleLabel);
            this.Controls.Add(this.AddressLabel);
            this.Controls.Add(this.PhoneLabel);
            this.Controls.Add(this.EmailLabel);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.ugUserList);
            this.Name = "frmUserAdmin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "User Module";
            this.Load += new System.EventHandler(this.frmUser_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ugUserList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DataGridView ugUserList;
        private Label lblName;
        private Label EmailLabel;
        private Label PhoneLabel;
        private Label AddressLabel;
        private Label RoleLabel;
        private Label DepartmentLabel;
        private Label JoinDateLabel;
        private Label GenderLabel;
        private TextBox txtName;
        private TextBox txtEmail;
        private TextBox txtPhone;
        private TextBox txtAddress;
        private ComboBox cmbRole;
        private ComboBox cmbDepartment;
        private DateTimePicker dtpJoinDate;
        private RadioButton optMale;
        private RadioButton optFemale;
        private RadioButton optOthers;
        private Button btnSubmit;
        private Button btnClear;
        private Button btnUpdate;
        private Button btnDelete;
        private Button btnAddRole;
        private Button btnAddDept;
        private ComboBox cmbDesignation;
        private Label lblDesignation;
        private TextBox txtUserName;
        private Label lblUserName;
        private TextBox txtConfirmPassword;
        private Label lblConfirmPassword;
        private TextBox txtPassword;
        private Label lblPassword;
    }
}