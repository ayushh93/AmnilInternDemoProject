using ItemsApp.Helpers;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Runtime.CompilerServices.RuntimeHelpers;

namespace ItemsApp
{
    public partial class frmManufacturer : Form
    {
        static string connectionString = ConfigurationHelper.GetConnectionString("ItemsDB");
        int pid = 0;
        int _id = 0;
        string _name;
        public frmManufacturer()
        {
            InitializeComponent();
        }

        #region Custom Methods

        //Validation
        private bool ValidateData()
        {
            bool isValid = true;

            // Validate Name
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Please fill in the name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtName.Focus();
                isValid = false;
            }

            // Validate Email
            string emailPattern = @"^\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,3}$";
            if (!Regex.IsMatch(txtEmail.Text, emailPattern))
            {
                MessageBox.Show("Please fill in the email", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtEmail.Focus();
                isValid = false;
            }

            // Validate Contact Number
            string contactPattern = @"\+(9[976]\d|8[987530]\d|6[987]\d|5[90]\d|42\d|3[875]\d|
                                    2[98654321]\d|9[8543210]|8[6421]|6[6543210]|5[87654321]|
                                    4[987654310]|3[9643210]|2[70]|7|1)\d{1,14}$$";
            if (!Regex.IsMatch(txtContactNumber.Text, contactPattern))
            {
                MessageBox.Show("Please fill in valid contact number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtContactNumber.Focus();
                isValid = false;
            }

            // Validate Country
            if (string.IsNullOrWhiteSpace(txtCountry.Text))
            {
                MessageBox.Show("Please fill in the country", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCountry.Focus();
                isValid = false;
            }

            // Validate Address
            if (string.IsNullOrWhiteSpace(txtAddress.Text))
            {
                MessageBox.Show("Please fill in the address", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                txtAddress.Focus();
                isValid = false;
            }

            // Validate Postal Code
            string postalPattern = @"^[0-9]{5}$";
            if (!Regex.IsMatch(txtPostalCode.Text, postalPattern))
            {
                MessageBox.Show("Postal code should be 5 digit long integer", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPostalCode.Focus();
                isValid = false;
            }

            return isValid;
        }

        private void clearControls(Control c)
        {
            if (c is TextBox tb)
            {
                tb.Clear();
            }
            else if (c is ComboBox cb)
            {
                cb.SelectedIndex = -1;
            }
            else if (c is RadioButton rb)
            {
                rb.Checked = false;
            }
            else if (c is DateTimePicker dateTimePicker)
            {
                dateTimePicker.Value = DateTime.Now;
            }
            _id = 0;
            btnUpdate.Enabled = false;
            btnUpdate.Visible = false;
            btnSubmit.Enabled = true;
            btnSubmit.Visible = true;
        }

        private void LoadData()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = connection.CreateCommand())
                    {
                        cmd.CommandText = "exec sp_GetManufacturerList;";
                        // Open the connection to the database
                        connection.Open();

                        // Create a new SqlDataReader object by executing the command
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            // Create a new DataTable to store the data from the SqlDataReader
                            DataTable dataTable = new DataTable();

                            // Load the data from the SqlDataReader into the DataTable
                            dataTable.Load(reader);

                            // Bind the DataTable to the DataGridView
                            dgvManufacturer.DataSource = dataTable;

                            // Hide the second column i.e id in the DataGridView control
                            dgvManufacturer.Columns[1].Visible = false;

                            // Customize the DataGridView appearance
                            dgvManufacturer.DefaultCellStyle.Font = new Font("Tahoma", 10);
                            dgvManufacturer.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                            foreach (DataGridViewColumn column in dgvManufacturer.Columns)
                            {
                                column.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                            }
                            
                            dgvManufacturer.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                            dgvManufacturer.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;
                            dgvManufacturer.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 10, FontStyle.Bold);
                            dgvManufacturer.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkGray;
                            dgvManufacturer.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                            dgvManufacturer.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                        }
                        connection.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Data could not be loaded! - {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        #endregion

        private void lblCreateManufacturer_Click(object sender, EventArgs e)
        {
            txtName.Focus();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            foreach (Control c in tableLayoutPanel2.Controls)
            {
                clearControls(c);
            }
        }

        private void frmManufacturer_Load(object sender, EventArgs e)
        {
            btnUpdate.Enabled = false;
            btnUpdate.Visible = false;
            LoadData();
        }

        private void btnSubmit_Click(object sender, EventArgs e) 
        {
            if (!ValidateData())
            {
                return;
            }
            try
                {
                    // Insert into pl_object table first
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        using (SqlCommand cmd = connection.CreateCommand())
                        {
                        //Unique validation for name starts
                        SqlCommand query = new SqlCommand("SELECT name FROM pl_object WHERE object_name = 'Manufacturer' AND name = @name",connection);
                        query.Parameters.AddWithValue("@name", txtName.Text);
                        SqlDataAdapter nameCheck = new SqlDataAdapter(query);
                        DataTable nameTable = new DataTable();
                        nameCheck.Fill(nameTable);
                        if (nameTable.Rows.Count > 0)
                        {
                            MessageBox.Show("Manufacturer Name already exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        //Unique validation for name ends
                            cmd.CommandText = "INSERT INTO pl_object(object_name, name) VALUES(@objectName, @name)";
                            cmd.Parameters.AddWithValue("@objectName", "Manufacturer");
                            cmd.Parameters.AddWithValue("@name", txtName.Text);
                            connection.Open();
                            cmd.ExecuteNonQuery();
                            connection.Close();
                        }
                    }
                    //retrieve id of object for assigning foreign key in child tables
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        using (SqlCommand cmd = connection.CreateCommand())
                        {
                            cmd.CommandText = "SELECT MAX(id) FROM pl_object";
                            cmd.Parameters.AddWithValue("@name", txtName.Text);
                            connection.Open();
                            pid = (int)cmd.ExecuteScalar();
                            connection.Close();
                        }
                    }
                    //Insert into child tables of pl_object
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        using (SqlCommand cmd = connection.CreateCommand())
                        {

                            cmd.CommandText = "INSERT INTO pl_string(pid,column_type, value) VALUES(@pid, @columnType1, @value1)" + "INSERT INTO pl_string(pid,column_type, value) VALUES(@pid, @columnType2, @value2)" +
                                "INSERT INTO pl_string(pid,column_type, value) VALUES(@pid, @columnType3, @value3)" +
                                "INSERT INTO pl_string(pid,column_type, value) VALUES(@pid, @columnType4, @value4)" +
                                "INSERT INTO pl_string(pid,column_type, value) VALUES(@pid, @columnType5, @value5)";

                            cmd.Parameters.AddWithValue("@pid", pid);

                            //* STRING data parameters starts*//*
                            //Email
                            cmd.Parameters.AddWithValue("@columnType1", "manufacturer_email");
                            cmd.Parameters.AddWithValue("@value1", txtEmail.Text);
                            //Contact Number
                            cmd.Parameters.AddWithValue("@columnType2", "manufacturer_contact_number");
                            cmd.Parameters.AddWithValue("@value2", txtContactNumber.Text);
                            //Country
                            cmd.Parameters.AddWithValue("@columnType3", "manufacturer_country");
                            cmd.Parameters.AddWithValue("@value3", txtCountry.Text);
                            //Address
                            cmd.Parameters.AddWithValue("@columnType4", "manufacturer_address");
                            cmd.Parameters.AddWithValue("@value4", txtAddress.Text);
                            //Postal Code
                            cmd.Parameters.AddWithValue("@columnType5", "manufacturer_postal_code");
                            cmd.Parameters.AddWithValue("@value5", txtPostalCode.Text);
                            //* STRING data parameters ends*/

                            connection.Open();
                            cmd.ExecuteNonQuery();
                            connection.Close();
                        }
                    }
                    MessageBox.Show("Manufacturer created succesfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Manufacturer could not be created! - {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    //redirect to tabPage2
                    tabControl1.SelectedTab = tabPage2;
                    //refresh data in datagridview
                    LoadData();
                    //clearcontrols
                    foreach (Control c in tableLayoutPanel2.Controls)
                    {
                        clearControls(c);
                    }
                } 
            
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadData();

        }

        private void dgvManufacturer_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex>= 0)
            {
                DataGridViewRow row = dgvManufacturer.Rows[e.RowIndex];
                if (row != null)
                {
                    _id = Convert.ToInt32(row.Cells["ID"].Value.ToString());
                    txtName.Text = row.Cells["Name"].Value.ToString();
                    txtEmail.Text = row.Cells["Email"].Value.ToString();
                    txtContactNumber.Text = row.Cells["Contact Number"].Value.ToString(); 
                    txtCountry.Text = row.Cells["Country"].Value.ToString(); 
                    txtAddress.Text = row.Cells["Address"].Value.ToString();
                    txtPostalCode.Text = row.Cells["Postal Code"].Value.ToString();

                    //Redirect to form
                    tabControl1.SelectedTab = tabPage1;
                    btnUpdate.Enabled = true;
                    btnUpdate.Visible= true;
                    btnSubmit.Enabled = false;
                    btnSubmit.Visible= false;

                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!ValidateData())
            {
                return;
            }
            if (_id == 0)
            {
                MessageBox.Show($"No item selected!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (MessageBox.Show("Do you want to update this manufacturer?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;
            try
            {
                // Insert into pl_object table first
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = connection.CreateCommand())
                    {
                        //Unique validation for name starts
                        SqlCommand query = new SqlCommand("SELECT name FROM pl_object WHERE object_name = 'Manufacturer' AND name = @name AND id != @id", connection);
                        query.Parameters.AddWithValue("@id", _id);
                        query.Parameters.AddWithValue("@name", txtName.Text);
                        SqlDataAdapter nameCheck = new SqlDataAdapter(query);
                        DataTable nameTable = new DataTable();
                        nameCheck.Fill(nameTable);
                        if (nameTable.Rows.Count > 0)
                        {
                            MessageBox.Show("Manufacturer Name already exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        //Unique validation for name ends

                        cmd.CommandText = "UPDATE pl_object SET name = @name WHERE id = @id ";
                        cmd.Parameters.AddWithValue("@id", _id);
                        cmd.Parameters.AddWithValue("@name", txtName.Text);
                        connection.Open();
                        cmd.ExecuteNonQuery();
                        connection.Close();
                    }
                }
                //Insert into child tables of pl_object
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = connection.CreateCommand())
                    {

                        cmd.CommandText = "UPDATE pl_string SET value = @value1 WHERE pid = @pid AND column_type = @columnType1 " +
                            "UPDATE pl_string SET value = @value2 WHERE pid = @pid AND column_type = @columnType2 " +
                            "UPDATE pl_string SET value = @value3 WHERE pid = @pid AND column_type = @columnType3 " +
                            "UPDATE pl_string SET value = @value4 WHERE pid = @pid AND column_type = @columnType4 " +
                            "UPDATE pl_string SET value = @value5 WHERE pid = @pid AND column_type = @columnType5 ";

                        cmd.Parameters.AddWithValue("@pid", _id);

                        //* STRING data parameters starts*//*
                        //Email
                        cmd.Parameters.AddWithValue("@columnType1", "manufacturer_email");
                        cmd.Parameters.AddWithValue("@value1", txtEmail.Text);
                        //Contact Number
                        cmd.Parameters.AddWithValue("@columnType2", "manufacturer_contact_number");
                        cmd.Parameters.AddWithValue("@value2", txtContactNumber.Text);
                        //Country
                        cmd.Parameters.AddWithValue("@columnType3", "manufacturer_country");
                        cmd.Parameters.AddWithValue("@value3", txtCountry.Text);
                        //Address
                        cmd.Parameters.AddWithValue("@columnType4", "manufacturer_address");
                        cmd.Parameters.AddWithValue("@value4", txtAddress.Text);
                        //Postal Code
                        cmd.Parameters.AddWithValue("@columnType5", "manufacturer_postal_code");
                        cmd.Parameters.AddWithValue("@value5", txtPostalCode.Text);
                        //* STRING data parameters ends*/

                        connection.Open();
                        cmd.ExecuteNonQuery();
                        connection.Close();
                    }
                }
                MessageBox.Show("Manufacturer updated succesfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Manufacturer could not be updated! - {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                //redirect to tabPage2
                tabControl1.SelectedTab = tabPage2;
                //refresh data in datagridview
                LoadData();
                //clearcontrols
                foreach (Control c in tableLayoutPanel2.Controls)
                {
                    clearControls(c);
                }
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DataGridViewRow currentRow = dgvManufacturer.CurrentRow;
            if(currentRow != null)
            {
                _id = Convert.ToInt32(currentRow.Cells["Id"].Value.ToString());
                _name = currentRow.Cells["Name"].Value.ToString();
                if (MessageBox.Show($"Are you sure you want to delete this manufacturer? \r\n  {_name}", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                    return;

                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        using (SqlCommand cmd = connection.CreateCommand())
                        {
                            cmd.CommandText = " DELETE FROM pl_string WHERE pid = @id " +
                                " DELETE FROM pl_object WHERE id=@id ";
                            cmd.Parameters.AddWithValue("@id", _id);
                            connection.Open();
                            cmd.ExecuteNonQuery();

                            //delete rows in pivot table starts
                            SqlCommand deletequery = new SqlCommand("DELETE FROM manufacturer_supplier WHERE manufacturer_id = @id", connection);
                            deletequery.Parameters.AddWithValue("@id", _id);
                            deletequery.ExecuteNonQuery();
                            //delete rows in pivot table ends

                            connection.Close();
                        }
                    }
                    MessageBox.Show("Manufacturer Deleted Succesfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Manufacturer could not be deleted at the moment! - {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    LoadData();
                }
            }
        }
    }
}
