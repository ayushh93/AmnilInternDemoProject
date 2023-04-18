﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ItemsApp
{
    public partial class frmDashboard : Form
    {
        public frmDashboard()
        {
            InitializeComponent();
            int loginId = frmLogin.loginId;
        }

        private void btnManufacturer_Click(object sender, EventArgs e)
        {
            frmManufacturer manufacturer= new frmManufacturer();
            manufacturer.ShowDialog();
        }

        private void btnSupplier_Click(object sender, EventArgs e)
        {
            frmSupplier supplier= new frmSupplier();    
            supplier.ShowDialog();
        }

        private void btnItem_Click(object sender, EventArgs e)
        {
            frmItem item = new frmItem();
            item.ShowDialog();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            frmLogin login = new frmLogin();
            login.Show();
            this.Close();
        }

        private void btnUserManagement_Click(object sender, EventArgs e)
        {
            frmUserAdmin admin = new frmUserAdmin();
            admin.ShowDialog();
        }
    }
}
