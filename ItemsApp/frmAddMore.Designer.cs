namespace ItemsApp
{
    partial class frmAddMore
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabRole = new System.Windows.Forms.TabPage();
            this.ugRoleList = new System.Windows.Forms.DataGridView();
            this.btnUpdateRole = new System.Windows.Forms.Button();
            this.btnDeleteRole = new System.Windows.Forms.Button();
            this.btnAddRole = new System.Windows.Forms.Button();
            this.txtRoleName = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.tabDept = new System.Windows.Forms.TabPage();
            this.btnClearDepart = new System.Windows.Forms.Button();
            this.ugDepartments = new System.Windows.Forms.DataGridView();
            this.txtDeptDescription = new System.Windows.Forms.TextBox();
            this.lblDeptDescription = new System.Windows.Forms.Label();
            this.btnUpdateDepart = new System.Windows.Forms.Button();
            this.btnDeleteDepart = new System.Windows.Forms.Button();
            this.btnAddDepartment = new System.Windows.Forms.Button();
            this.txtDepartmentName = new System.Windows.Forms.TextBox();
            this.lblDepartment = new System.Windows.Forms.Label();
            this.tabDesig = new System.Windows.Forms.TabPage();
            this.btnClearDesig = new System.Windows.Forms.Button();
            this.ugDesignation = new System.Windows.Forms.DataGridView();
            this.txtDesigDetails = new System.Windows.Forms.TextBox();
            this.lblDesiDetails = new System.Windows.Forms.Label();
            this.btnUpdateDesig = new System.Windows.Forms.Button();
            this.btnDeleteDesig = new System.Windows.Forms.Button();
            this.btnAddDesignation = new System.Windows.Forms.Button();
            this.txtDesignation = new System.Windows.Forms.TextBox();
            this.lblDesignation = new System.Windows.Forms.Label();
            this.tabPermission = new System.Windows.Forms.TabPage();
            this.ugPermissionList = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblRole = new System.Windows.Forms.Label();
            this.cmbRoles = new System.Windows.Forms.ComboBox();
            this.btnAddPermission = new System.Windows.Forms.Button();
            this.permission = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl1.SuspendLayout();
            this.tabRole.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ugRoleList)).BeginInit();
            this.tabDept.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ugDepartments)).BeginInit();
            this.tabDesig.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ugDesignation)).BeginInit();
            this.tabPermission.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ugPermissionList)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabRole);
            this.tabControl1.Controls.Add(this.tabDept);
            this.tabControl1.Controls.Add(this.tabDesig);
            this.tabControl1.Controls.Add(this.tabPermission);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(863, 627);
            this.tabControl1.TabIndex = 0;
            // 
            // tabRole
            // 
            this.tabRole.Controls.Add(this.ugRoleList);
            this.tabRole.Controls.Add(this.btnUpdateRole);
            this.tabRole.Controls.Add(this.btnDeleteRole);
            this.tabRole.Controls.Add(this.btnAddRole);
            this.tabRole.Controls.Add(this.txtRoleName);
            this.tabRole.Controls.Add(this.lblName);
            this.tabRole.Location = new System.Drawing.Point(4, 29);
            this.tabRole.Name = "tabRole";
            this.tabRole.Padding = new System.Windows.Forms.Padding(3);
            this.tabRole.Size = new System.Drawing.Size(855, 594);
            this.tabRole.TabIndex = 0;
            this.tabRole.Text = "Add Role";
            this.tabRole.UseVisualStyleBackColor = true;
            // 
            // ugRoleList
            // 
            this.ugRoleList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ugRoleList.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ugRoleList.Location = new System.Drawing.Point(3, 211);
            this.ugRoleList.Name = "ugRoleList";
            this.ugRoleList.RowHeadersWidth = 51;
            this.ugRoleList.RowTemplate.Height = 29;
            this.ugRoleList.Size = new System.Drawing.Size(849, 380);
            this.ugRoleList.TabIndex = 5;
            this.ugRoleList.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ugRoleList_CellContentDoubleClick);
            // 
            // btnUpdateRole
            // 
            this.btnUpdateRole.Location = new System.Drawing.Point(732, 159);
            this.btnUpdateRole.Name = "btnUpdateRole";
            this.btnUpdateRole.Size = new System.Drawing.Size(94, 29);
            this.btnUpdateRole.TabIndex = 4;
            this.btnUpdateRole.Text = "Update";
            this.btnUpdateRole.UseVisualStyleBackColor = true;
            // 
            // btnDeleteRole
            // 
            this.btnDeleteRole.Location = new System.Drawing.Point(594, 159);
            this.btnDeleteRole.Name = "btnDeleteRole";
            this.btnDeleteRole.Size = new System.Drawing.Size(94, 29);
            this.btnDeleteRole.TabIndex = 3;
            this.btnDeleteRole.Text = "Delete";
            this.btnDeleteRole.UseVisualStyleBackColor = true;
            this.btnDeleteRole.Click += new System.EventHandler(this.btnDeleteRole_Click);
            // 
            // btnAddRole
            // 
            this.btnAddRole.Location = new System.Drawing.Point(467, 159);
            this.btnAddRole.Name = "btnAddRole";
            this.btnAddRole.Size = new System.Drawing.Size(94, 29);
            this.btnAddRole.TabIndex = 2;
            this.btnAddRole.Text = "Add";
            this.btnAddRole.UseVisualStyleBackColor = true;
            this.btnAddRole.Click += new System.EventHandler(this.btnAddRole_Click);
            // 
            // txtRoleName
            // 
            this.txtRoleName.Location = new System.Drawing.Point(110, 16);
            this.txtRoleName.Name = "txtRoleName";
            this.txtRoleName.Size = new System.Drawing.Size(265, 27);
            this.txtRoleName.TabIndex = 1;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblName.Location = new System.Drawing.Point(16, 20);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(88, 19);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Role Name";
            // 
            // tabDept
            // 
            this.tabDept.Controls.Add(this.btnClearDepart);
            this.tabDept.Controls.Add(this.ugDepartments);
            this.tabDept.Controls.Add(this.txtDeptDescription);
            this.tabDept.Controls.Add(this.lblDeptDescription);
            this.tabDept.Controls.Add(this.btnUpdateDepart);
            this.tabDept.Controls.Add(this.btnDeleteDepart);
            this.tabDept.Controls.Add(this.btnAddDepartment);
            this.tabDept.Controls.Add(this.txtDepartmentName);
            this.tabDept.Controls.Add(this.lblDepartment);
            this.tabDept.Location = new System.Drawing.Point(4, 29);
            this.tabDept.Name = "tabDept";
            this.tabDept.Padding = new System.Windows.Forms.Padding(3);
            this.tabDept.Size = new System.Drawing.Size(855, 594);
            this.tabDept.TabIndex = 1;
            this.tabDept.Text = "Add Department";
            this.tabDept.UseVisualStyleBackColor = true;
            // 
            // btnClearDepart
            // 
            this.btnClearDepart.Location = new System.Drawing.Point(547, 242);
            this.btnClearDepart.Name = "btnClearDepart";
            this.btnClearDepart.Size = new System.Drawing.Size(94, 29);
            this.btnClearDepart.TabIndex = 13;
            this.btnClearDepart.Text = "Clear";
            this.btnClearDepart.UseVisualStyleBackColor = true;
            // 
            // ugDepartments
            // 
            this.ugDepartments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ugDepartments.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ugDepartments.Location = new System.Drawing.Point(3, 403);
            this.ugDepartments.Name = "ugDepartments";
            this.ugDepartments.RowHeadersWidth = 51;
            this.ugDepartments.RowTemplate.Height = 29;
            this.ugDepartments.Size = new System.Drawing.Size(849, 188);
            this.ugDepartments.TabIndex = 12;
            // 
            // txtDeptDescription
            // 
            this.txtDeptDescription.Location = new System.Drawing.Point(172, 59);
            this.txtDeptDescription.Multiline = true;
            this.txtDeptDescription.Name = "txtDeptDescription";
            this.txtDeptDescription.Size = new System.Drawing.Size(325, 87);
            this.txtDeptDescription.TabIndex = 11;
            // 
            // lblDeptDescription
            // 
            this.lblDeptDescription.AutoSize = true;
            this.lblDeptDescription.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblDeptDescription.Location = new System.Drawing.Point(21, 63);
            this.lblDeptDescription.Name = "lblDeptDescription";
            this.lblDeptDescription.Size = new System.Drawing.Size(92, 19);
            this.lblDeptDescription.TabIndex = 10;
            this.lblDeptDescription.Text = "Description";
            // 
            // btnUpdateDepart
            // 
            this.btnUpdateDepart.Location = new System.Drawing.Point(403, 242);
            this.btnUpdateDepart.Name = "btnUpdateDepart";
            this.btnUpdateDepart.Size = new System.Drawing.Size(94, 29);
            this.btnUpdateDepart.TabIndex = 9;
            this.btnUpdateDepart.Text = "Update";
            this.btnUpdateDepart.UseVisualStyleBackColor = true;
            // 
            // btnDeleteDepart
            // 
            this.btnDeleteDepart.Location = new System.Drawing.Point(258, 242);
            this.btnDeleteDepart.Name = "btnDeleteDepart";
            this.btnDeleteDepart.Size = new System.Drawing.Size(94, 29);
            this.btnDeleteDepart.TabIndex = 8;
            this.btnDeleteDepart.Text = "Delete";
            this.btnDeleteDepart.UseVisualStyleBackColor = true;
            this.btnDeleteDepart.Click += new System.EventHandler(this.btnDeleteDepart_Click);
            // 
            // btnAddDepartment
            // 
            this.btnAddDepartment.Location = new System.Drawing.Point(122, 242);
            this.btnAddDepartment.Name = "btnAddDepartment";
            this.btnAddDepartment.Size = new System.Drawing.Size(94, 29);
            this.btnAddDepartment.TabIndex = 7;
            this.btnAddDepartment.Text = "Add";
            this.btnAddDepartment.UseVisualStyleBackColor = true;
            this.btnAddDepartment.Click += new System.EventHandler(this.btnAddDepartment_Click);
            // 
            // txtDepartmentName
            // 
            this.txtDepartmentName.Location = new System.Drawing.Point(172, 15);
            this.txtDepartmentName.Name = "txtDepartmentName";
            this.txtDepartmentName.Size = new System.Drawing.Size(325, 27);
            this.txtDepartmentName.TabIndex = 6;
            // 
            // lblDepartment
            // 
            this.lblDepartment.AutoSize = true;
            this.lblDepartment.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblDepartment.Location = new System.Drawing.Point(21, 19);
            this.lblDepartment.Name = "lblDepartment";
            this.lblDepartment.Size = new System.Drawing.Size(140, 19);
            this.lblDepartment.TabIndex = 5;
            this.lblDepartment.Text = "Department Name";
            // 
            // tabDesig
            // 
            this.tabDesig.Controls.Add(this.btnClearDesig);
            this.tabDesig.Controls.Add(this.ugDesignation);
            this.tabDesig.Controls.Add(this.txtDesigDetails);
            this.tabDesig.Controls.Add(this.lblDesiDetails);
            this.tabDesig.Controls.Add(this.btnUpdateDesig);
            this.tabDesig.Controls.Add(this.btnDeleteDesig);
            this.tabDesig.Controls.Add(this.btnAddDesignation);
            this.tabDesig.Controls.Add(this.txtDesignation);
            this.tabDesig.Controls.Add(this.lblDesignation);
            this.tabDesig.Location = new System.Drawing.Point(4, 29);
            this.tabDesig.Name = "tabDesig";
            this.tabDesig.Padding = new System.Windows.Forms.Padding(3);
            this.tabDesig.Size = new System.Drawing.Size(855, 594);
            this.tabDesig.TabIndex = 2;
            this.tabDesig.Text = "Add Designation";
            this.tabDesig.UseVisualStyleBackColor = true;
            // 
            // btnClearDesig
            // 
            this.btnClearDesig.Location = new System.Drawing.Point(547, 236);
            this.btnClearDesig.Name = "btnClearDesig";
            this.btnClearDesig.Size = new System.Drawing.Size(94, 29);
            this.btnClearDesig.TabIndex = 22;
            this.btnClearDesig.Text = "Clear";
            this.btnClearDesig.UseVisualStyleBackColor = true;
            this.btnClearDesig.Click += new System.EventHandler(this.btnClearDesig_Click);
            // 
            // ugDesignation
            // 
            this.ugDesignation.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ugDesignation.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ugDesignation.Location = new System.Drawing.Point(3, 403);
            this.ugDesignation.Name = "ugDesignation";
            this.ugDesignation.RowHeadersWidth = 51;
            this.ugDesignation.RowTemplate.Height = 29;
            this.ugDesignation.Size = new System.Drawing.Size(849, 188);
            this.ugDesignation.TabIndex = 21;
            // 
            // txtDesigDetails
            // 
            this.txtDesigDetails.Location = new System.Drawing.Point(172, 53);
            this.txtDesigDetails.Multiline = true;
            this.txtDesigDetails.Name = "txtDesigDetails";
            this.txtDesigDetails.Size = new System.Drawing.Size(325, 87);
            this.txtDesigDetails.TabIndex = 20;
            // 
            // lblDesiDetails
            // 
            this.lblDesiDetails.AutoSize = true;
            this.lblDesiDetails.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblDesiDetails.Location = new System.Drawing.Point(21, 57);
            this.lblDesiDetails.Name = "lblDesiDetails";
            this.lblDesiDetails.Size = new System.Drawing.Size(92, 19);
            this.lblDesiDetails.TabIndex = 19;
            this.lblDesiDetails.Text = "Description";
            // 
            // btnUpdateDesig
            // 
            this.btnUpdateDesig.Location = new System.Drawing.Point(403, 236);
            this.btnUpdateDesig.Name = "btnUpdateDesig";
            this.btnUpdateDesig.Size = new System.Drawing.Size(94, 29);
            this.btnUpdateDesig.TabIndex = 18;
            this.btnUpdateDesig.Text = "Update";
            this.btnUpdateDesig.UseVisualStyleBackColor = true;
            // 
            // btnDeleteDesig
            // 
            this.btnDeleteDesig.Location = new System.Drawing.Point(258, 236);
            this.btnDeleteDesig.Name = "btnDeleteDesig";
            this.btnDeleteDesig.Size = new System.Drawing.Size(94, 29);
            this.btnDeleteDesig.TabIndex = 17;
            this.btnDeleteDesig.Text = "Delete";
            this.btnDeleteDesig.UseVisualStyleBackColor = true;
            this.btnDeleteDesig.Click += new System.EventHandler(this.btnDeleteDesig_Click);
            // 
            // btnAddDesignation
            // 
            this.btnAddDesignation.Location = new System.Drawing.Point(122, 236);
            this.btnAddDesignation.Name = "btnAddDesignation";
            this.btnAddDesignation.Size = new System.Drawing.Size(94, 29);
            this.btnAddDesignation.TabIndex = 16;
            this.btnAddDesignation.Text = "Add";
            this.btnAddDesignation.UseVisualStyleBackColor = true;
            this.btnAddDesignation.Click += new System.EventHandler(this.btnAddDesignation_Click);
            // 
            // txtDesignation
            // 
            this.txtDesignation.Location = new System.Drawing.Point(172, 9);
            this.txtDesignation.Name = "txtDesignation";
            this.txtDesignation.Size = new System.Drawing.Size(325, 27);
            this.txtDesignation.TabIndex = 15;
            // 
            // lblDesignation
            // 
            this.lblDesignation.AutoSize = true;
            this.lblDesignation.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblDesignation.Location = new System.Drawing.Point(21, 13);
            this.lblDesignation.Name = "lblDesignation";
            this.lblDesignation.Size = new System.Drawing.Size(95, 19);
            this.lblDesignation.TabIndex = 14;
            this.lblDesignation.Text = "Designation";
            // 
            // tabPermission
            // 
            this.tabPermission.Controls.Add(this.ugPermissionList);
            this.tabPermission.Controls.Add(this.panel1);
            this.tabPermission.Controls.Add(this.btnAddPermission);
            this.tabPermission.Location = new System.Drawing.Point(4, 29);
            this.tabPermission.Name = "tabPermission";
            this.tabPermission.Padding = new System.Windows.Forms.Padding(3);
            this.tabPermission.Size = new System.Drawing.Size(855, 594);
            this.tabPermission.TabIndex = 3;
            this.tabPermission.Text = "Add Permission";
            this.tabPermission.UseVisualStyleBackColor = true;
            // 
            // ugPermissionList
            // 
            this.ugPermissionList.AllowUserToAddRows = false;
            this.ugPermissionList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.ugPermissionList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ugPermissionList.Dock = System.Windows.Forms.DockStyle.Top;
            this.ugPermissionList.Location = new System.Drawing.Point(3, 70);
            this.ugPermissionList.Name = "ugPermissionList";
            this.ugPermissionList.RowHeadersWidth = 51;
            this.ugPermissionList.RowTemplate.Height = 29;
            this.ugPermissionList.Size = new System.Drawing.Size(849, 450);
            this.ugPermissionList.TabIndex = 32;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.PaleTurquoise;
            this.panel1.Controls.Add(this.lblRole);
            this.panel1.Controls.Add(this.cmbRoles);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(849, 67);
            this.panel1.TabIndex = 31;
            // 
            // lblRole
            // 
            this.lblRole.AutoSize = true;
            this.lblRole.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblRole.Location = new System.Drawing.Point(20, 18);
            this.lblRole.Name = "lblRole";
            this.lblRole.Size = new System.Drawing.Size(43, 24);
            this.lblRole.TabIndex = 1;
            this.lblRole.Text = "Role";
            // 
            // cmbRoles
            // 
            this.cmbRoles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRoles.FormattingEnabled = true;
            this.cmbRoles.Location = new System.Drawing.Point(69, 18);
            this.cmbRoles.Name = "cmbRoles";
            this.cmbRoles.Size = new System.Drawing.Size(291, 28);
            this.cmbRoles.TabIndex = 0;
            this.cmbRoles.SelectionChangeCommitted += new System.EventHandler(this.cmbRoles_SelectionChangeCommitted);
            // 
            // btnAddPermission
            // 
            this.btnAddPermission.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAddPermission.Location = new System.Drawing.Point(753, 557);
            this.btnAddPermission.Name = "btnAddPermission";
            this.btnAddPermission.Size = new System.Drawing.Size(94, 29);
            this.btnAddPermission.TabIndex = 25;
            this.btnAddPermission.Text = "Save";
            this.btnAddPermission.UseVisualStyleBackColor = true;
            this.btnAddPermission.Click += new System.EventHandler(this.btnAddPermission_Click);
            // 
            // permission
            // 
            this.permission.HeaderText = "Permissions";
            this.permission.MinimumWidth = 6;
            this.permission.Name = "permission";
            this.permission.ReadOnly = true;
            this.permission.Width = 125;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Permission/Interface";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 125;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Permission/Interface";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 125;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Permission/Interface";
            this.dataGridViewTextBoxColumn3.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Width = 125;
            // 
            // frmAddMore
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(863, 627);
            this.Controls.Add(this.tabControl1);
            this.Name = "frmAddMore";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Adder";
            this.Load += new System.EventHandler(this.frmAddMore_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabRole.ResumeLayout(false);
            this.tabRole.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ugRoleList)).EndInit();
            this.tabDept.ResumeLayout(false);
            this.tabDept.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ugDepartments)).EndInit();
            this.tabDesig.ResumeLayout(false);
            this.tabDesig.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ugDesignation)).EndInit();
            this.tabPermission.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ugPermissionList)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabRole;
        private TabPage tabDept;
        private TabPage tabDesig;
        private Button btnAddRole;
        private TextBox txtRoleName;
        private Label lblName;
        private Button btnUpdateRole;
        private Button btnDeleteRole;
        private TextBox txtDeptDescription;
        private Label lblDeptDescription;
        private Button btnUpdateDepart;
        private Button btnDeleteDepart;
        private Button btnAddDepartment;
        private TextBox txtDepartmentName;
        private Label lblDepartment;
        private Button btnClearDepart;
        private DataGridView ugDepartments;
        private Button btnClearDesig;
        private DataGridView ugDesignation;
        private TextBox txtDesigDetails;
        private Label lblDesiDetails;
        private Button btnUpdateDesig;
        private Button btnDeleteDesig;
        private Button btnAddDesignation;
        private TextBox txtDesignation;
        private Label lblDesignation;
        private TabPage tabPermission;
        private Button btnAddPermission;
        private DataGridView ugRoleList;
        private Panel panel1;
        private Label lblRole;
        private ComboBox cmbRoles;
        private DataGridView dataGridView1;
        private DataGridViewCheckBoxColumn Value;
        private DataGridViewTextBoxColumn permission;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewCheckBoxColumn Column2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridView ugPermissionList;
    }
}