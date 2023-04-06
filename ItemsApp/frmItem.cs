
using Microsoft.Data.SqlClient;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ItemsApp
{
    public partial class frmItem : Form
    {
        static string connectionString = "Server=AYUSH-KARMA;Initial Catalog=ItemsDB;Integrated Security=True;Encrypt=False;";
        int pid = 0;
        int _id = 0;
        string _name;

        public frmItem()
        {
            InitializeComponent();
        }

        #region Custom Methods

        //clear controls
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
                        cmd.CommandText = "EXEC sp_GetItemList";
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
                            dgvItem.DataSource = dataTable;

                            // Hide the second column in the DataGridView control
                            dgvItem.Columns[1].Visible = false;

                            // Customize the DataGridView appearance
                            dgvItem.DefaultCellStyle.Font = new Font("Tahoma", 10);
                            dgvItem.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                            dgvItem.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;
                            dgvItem.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 10, FontStyle.Bold);
                            dgvItem.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkGray;
                            dgvItem.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                            dgvItem.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
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

        private void lblHeading_Click(object sender, EventArgs e)
        {
            txtName.Focus();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            foreach (Control c in tabPage1.Controls)
            {
                clearControls(c);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            btnUpdate.Enabled = false;
            btnUpdate.Visible= false;
            LoadData();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(txtName.Text) || cmbType.SelectedIndex == -1 || cmbCategory.SelectedIndex == -1 ||
                cmbStandard.SelectedIndex == -1 || string.IsNullOrEmpty(txtMeasurementUnit.Text) ||
                string.IsNullOrEmpty(txtCode.Text) || string.IsNullOrEmpty(txtMinReorderUnit.Text))
            {
                MessageBox.Show("Please fill in all the required fields", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(txtMinReorderUnit.Text, out int minReorderUnit))
            {
                MessageBox.Show("Measurement Unit must be a valid integer", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMinReorderUnit.Focus();
                return;
            }

            try
            {
                // Insert into pl_object table first
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = connection.CreateCommand())
                    {
                        //Item code unique validation starts
                        SqlCommand query = new SqlCommand("Select value from pl_string where column_type = 'item_code' AND value = @code", connection);
                        query.Parameters.AddWithValue("@code", txtCode.Text);
                        SqlDataAdapter codeCheck = new SqlDataAdapter(query);
                        DataTable codeTable = new DataTable();
                        codeCheck.Fill(codeTable);
                        if (codeTable.Rows.Count > 0)
                        {
                            MessageBox.Show("Item Code already exists! Please select another code!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        //Item code unique validation ends

                        cmd.CommandText = "INSERT INTO pl_object(object_name, name) VALUES(@objectName, @name)";
                        cmd.Parameters.AddWithValue("@objectName", "Item");
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
                        cmd.CommandText = "SELECT MAX(id) FROM pl_object ";
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

                        cmd.CommandText = "INSERT INTO pl_string(pid,column_type, value) VALUES(@pid, @columnType1, @value1)" +                            "INSERT INTO pl_string(pid,column_type, value) VALUES(@pid, @columnType2, @value2)" +
                            "INSERT INTO pl_string(pid,column_type, value) VALUES(@pid, @columnType3, @value3)" +
                            "INSERT INTO pl_string(pid,column_type, value) VALUES(@pid, @columnType4, @value4)" +
                            "INSERT INTO pl_string(pid,column_type, value) VALUES(@pid, @columnType5, @value5)" +
                            "INSERT INTO pl_int(pid,column_type, value) VALUES(@pid, @columnType6, @value6)";

                        cmd.Parameters.AddWithValue("@pid", pid);

                        //* STRING data parameters starts*//*
                        //Type
                        cmd.Parameters.AddWithValue("@columnType1", "item_type");
                        cmd.Parameters.AddWithValue("@value1", cmbType.SelectedItem);
                        //Category
                        cmd.Parameters.AddWithValue("@columnType2", "item_category");
                        cmd.Parameters.AddWithValue("@value2", cmbCategory.SelectedItem);
                        //Standard
                        cmd.Parameters.AddWithValue("@columnType3", "item_standard");
                        cmd.Parameters.AddWithValue("@value3", cmbStandard.SelectedItem);
                        //Measurement Unit
                        cmd.Parameters.AddWithValue("@columnType4", "item_measurement_unit");
                        cmd.Parameters.AddWithValue("@value4", txtMeasurementUnit.Text);
                        //Code
                        cmd.Parameters.AddWithValue("@columnType5", "item_code");
                        cmd.Parameters.AddWithValue("@value5", txtCode.Text);
                        //* STRING data parameters ends*/

                        /* INT data parameters starts*/
                        //MinReorderUnit
                        cmd.Parameters.AddWithValue("@columnType6", "item_MinReorderUnit");
                        cmd.Parameters.AddWithValue("@value6", minReorderUnit);
                        //* INT data parameters ends*/

                        connection.Open();
                        cmd.ExecuteNonQuery();
                        connection.Close();
                    }
                }
                MessageBox.Show("Data inserted succesfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Data could not be inserted! - {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                //refresh data in datagridview
                LoadData();
                //redirect to tabPage2
                tabControl1.SelectedTab = tabPage2;
                //clearcontrols
                foreach (Control c in tabPage1.Controls)
                {
                    clearControls(c);
                }
            }
         
        }

        private void dgvItem_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0) // Check if a row is actually selected
            {
                DataGridViewRow row = dgvItem.Rows[e.RowIndex];
                _id = Convert.ToInt32(row.Cells["Id"].Value.ToString());
                txtName.Text = row.Cells["Name"].Value.ToString();
                txtCode.Text = row.Cells["Code"].Value.ToString();
                cmbType.Text = row.Cells["Type"].Value.ToString();
                cmbCategory.Text = row.Cells["Category"].Value.ToString();
                cmbStandard.Text = row.Cells["Standard"].Value.ToString();
                txtMeasurementUnit.Text= row.Cells["Measurement Unit"].Value.ToString();
                txtMinReorderUnit.Text= row.Cells["Min Reorder Unit"].Value.ToString();

                // Switch to tabPage1 to show the selected row in the form
                tabControl1.SelectedTab = tabPage1;
                btnUpdate.Enabled = true;
                btnUpdate.Visible = true;
                btnSubmit.Enabled = false;
                btnSubmit.Visible = false;
                txtName.Focus();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtName.Text) || cmbType.SelectedIndex == -1 || cmbCategory.SelectedIndex == -1 ||
                cmbStandard.SelectedIndex == -1 || string.IsNullOrEmpty(txtMeasurementUnit.Text) ||
                string.IsNullOrEmpty(txtCode.Text) || string.IsNullOrEmpty(txtMinReorderUnit.Text))
            {
                MessageBox.Show("Please fill in all the required fields", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(txtMinReorderUnit.Text, out int minReorderUnit))
            {
                MessageBox.Show("Measurement Unit must be a valid integer", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMinReorderUnit.Focus();
                return;
            }

            if (_id == 0)
            {
                MessageBox.Show($"No item selected!!", "ItemsApp", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (MessageBox.Show("Do you want to update this item?", "ItemsApp", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;
            try
            {
                // Update pl_object table first
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = connection.CreateCommand())
                    {
                        //Item code unique validation starts
                        SqlCommand query = new SqlCommand("Select value from pl_string where column_type = 'item_code' and value = @code and pid != @id", connection);
                        query.Parameters.AddWithValue("@code", txtCode.Text);
                        query.Parameters.AddWithValue("@id",_id);
                        SqlDataAdapter codeCheck = new SqlDataAdapter(query);
                        DataTable codeTable = new DataTable();
                        codeCheck.Fill(codeTable);
                        if (codeTable.Rows.Count > 0)
                        {
                            MessageBox.Show("Item Code already exists! Please select another code!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        //Item code unique validation ends
                        cmd.CommandText = "UPDATE pl_object SET  name=@name WHERE id=@id";
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

                        cmd.CommandText = "UPDATE pl_string SET  value=@value1  WHERE pid=@pid AND column_type=@columnType1" +
                            " UPDATE pl_string SET value=@value2  WHERE pid=@pid AND column_type=@columnType2" +
                            " UPDATE pl_string SET value=@value3  WHERE pid=@pid AND column_type=@columnType3" +
                            " UPDATE pl_string SET value=@value4  WHERE pid=@pid AND column_type=@columnType4" +
                            " UPDATE pl_string SET value=@value5  WHERE pid=@pid AND column_type=@columnType5" +
                            " UPDATE pl_int SET value=@value6 WHERE pid=@pid AND column_type=@columnType6";

                        cmd.Parameters.AddWithValue("@pid", _id);
                        //* STRING data parameters starts*//*
                        //Type
                        cmd.Parameters.AddWithValue("@columnType1", "item_type");
                        cmd.Parameters.AddWithValue("@value1", cmbType.SelectedItem);
                        //Category
                        cmd.Parameters.AddWithValue("@columnType2", "item_category");
                        cmd.Parameters.AddWithValue("@value2", cmbCategory.SelectedItem);
                        //Standard
                        cmd.Parameters.AddWithValue("@columnType3", "item_standard");
                        cmd.Parameters.AddWithValue("@value3", cmbStandard.SelectedItem);
                        //Measurement Unit
                        cmd.Parameters.AddWithValue("@columnType4", "item_measurement_unit");
                        cmd.Parameters.AddWithValue("@value4", txtMeasurementUnit.Text);
                        //Code
                        cmd.Parameters.AddWithValue("@columnType5", "item_code");
                        cmd.Parameters.AddWithValue("@value5", txtCode.Text);
                        //* STRING data parameters ends*/

                        /* INT data parameters starts*/
                        //MinReorderUnit
                        cmd.Parameters.AddWithValue("@columnType6", "item_MinReorderUnit");
                        cmd.Parameters.AddWithValue("@value6", minReorderUnit);
                        //* INT data parameters ends*/

                        connection.Open();
                        cmd.ExecuteNonQuery();
                        connection.Close();
                    }
                }
                MessageBox.Show("Item updated succesfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Item could not be updated at the moment! - {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                //clear controls
                foreach(Control c in tabPage1.Controls)
                {
                    clearControls(c);
                }
                //refresh data in datagridview
                LoadData();
                //redirect to tabPage2
                tabControl1.SelectedTab = tabPage2;
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            //refresh data in datagridview
            LoadData();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DataGridViewRow currentRow = dgvItem.CurrentRow;
            if (currentRow != null)
            {
                _id = Convert.ToInt32(currentRow.Cells["Id"].Value.ToString());
                _name = currentRow.Cells["Name"].Value.ToString();
                if (MessageBox.Show($"Are you sure you want to delete this item {_name}?", "ItemsApp", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                return;
                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        using (SqlCommand cmd = connection.CreateCommand())
                        {
                            cmd.CommandText = " DELETE FROM pl_string WHERE pid = @id " +
                                " DELETE FROM pl_int WHERE pid=@id " +
                                " DELETE FROM pl_object WHERE id=@id ";
                            cmd.Parameters.AddWithValue("@id", _id);
                            connection.Open();
                            cmd.ExecuteNonQuery();
                            connection.Close();
                        }
                    }
                    MessageBox.Show("Item Deleted Succesfully.", "ItemsApp", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Item could not be deleted at the moment! - {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    LoadData();
                }
            }

        }
    }
}