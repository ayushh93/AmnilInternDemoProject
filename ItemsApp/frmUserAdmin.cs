using ItemsApp.Helpers;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ItemsApp
{
    public partial class frmUserAdmin : Form
    {

        int userId = 0;
        static string connectionString = ConfigurationHelper.GetConnectionString("UserManagementDB");
        public frmUserAdmin()
        {
            InitializeComponent();
        }
        private void frmUser_Load(object sender, EventArgs e)
        {
            showData();
            BindRolesToComboBox();
            BindDepartmentsToComboBox();
            BindDesignationToComboBox();
        }
        public bool validation()
        {
            Regex regex = new Regex(@"^[a-zA-Z]+(([',. -][a-zA-Z ])?[a-zA-Z]*)*$");
            if (txtName.Text == string.Empty)
            {
                MessageBox.Show("Name field is required", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return false;
            }
            if (!regex.IsMatch(txtName.Text))
            {
                MessageBox.Show("Name should not be a number!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return false;
            }
            string email = txtEmail.Text.Trim();
            if (email == string.Empty)
            {
                MessageBox.Show("Email is required", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return false;
            }
            if (!Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                MessageBox.Show("Invalid email address!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return false;
            }
            string phone = txtPhone.Text;
            if (phone == string.Empty)
            {
                MessageBox.Show("Please enter phone number!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPhone.Focus();
                return false;
            }
            if (!Regex.IsMatch(phone, @"^\d+$") || phone.Length != 10)
            {
                MessageBox.Show("Phone number should be a digit and 10 digit", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPhone.Focus();
                return false;
            }
            if (txtAddress.Text == string.Empty)
            {
                MessageBox.Show("Address field is empty!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAddress.Focus();
                return false;
            }
            if (cmbRole.SelectedItem == null)
            {
                MessageBox.Show("Please select Role", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbRole.Focus();
                return false;
            }
            if (cmbDepartment.SelectedItem == null)
            {
                MessageBox.Show("Please select Department", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbDepartment.Focus();
                return false;
            }
            DateTime dateTime = dtpJoinDate.Value;
            if (dtpJoinDate.Value > DateTime.Today.AddDays(1))
            {
                MessageBox.Show("Invalid date! Join date cannot be more that current date!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpJoinDate.Focus();
                return false;
            }
            if (!optMale.Checked && !optFemale.Checked && !optOthers.Checked)
            {
                MessageBox.Show("Please select Gender", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (txtUserName.Text is null)
            {
                MessageBox.Show("Please choose username", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (txtPassword.Text is null)
            {
                MessageBox.Show("Password should not be empty!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }
        public void showData()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "Exec spGetUserDetails";
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataSet dataSet = new DataSet();
                    adapter.Fill(dataSet, "pl_users");
                    ugUserList.DataSource = dataSet.Tables["pl_users"];
                    ugUserList.Columns[0].Visible = false;
                }
            }
        }
        //Populate data in combo box from database tables
        public void BindRolesToComboBox()
        {
            DataTable rolesTable = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT role_id, name FROM pl_roles", connectionString);
            adapter.Fill(rolesTable);
            cmbRole.DataSource = rolesTable;
            cmbRole.DisplayMember = "name";
            cmbRole.ValueMember = "role_id";
            cmbRole.SelectedIndex = -1;
        }
        public void BindDepartmentsToComboBox()
        {
            DataTable departmentsTable = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter("Select dept_id, dept_name from pl_departments", connectionString);
            adapter.Fill(departmentsTable);
            cmbDepartment.DataSource = departmentsTable;
            cmbDepartment.DisplayMember = "dept_name";
            cmbDepartment.ValueMember = "dept_id";
            cmbDepartment.SelectedIndex = -1;
        }
        public void BindDesignationToComboBox()
        {
            DataTable designationTable = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter("Select desig_id, desig_name from pl_designations", connectionString);
            adapter.Fill(designationTable);
            cmbDesignation.DataSource = designationTable;
            cmbDesignation.DisplayMember = "desig_name";
            cmbDesignation.ValueMember = "desig_id";
            cmbDesignation.SelectedIndex = -1;
        }
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (validation() == true)
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = connection.CreateCommand())
                    {
                        SqlCommand query = new SqlCommand("Select username from pl_users where username = @username", connection);
                        query.Parameters.AddWithValue("@username", txtUserName.Text);
                        SqlDataAdapter sdaUserCheck = new SqlDataAdapter(query);
                        DataTable dtUserCheck = new DataTable();
                        sdaUserCheck.Fill(dtUserCheck);
                        if (dtUserCheck.Rows.Count > 0)
                        {
                            MessageBox.Show("Username already exists! Please select another username!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        if (txtPassword.Text != txtConfirmPassword.Text)
                        {
                            MessageBox.Show("Password did not match!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }


                        int roleId = (int)cmbRole.SelectedValue;
                        int deptId = (int)cmbDepartment.SelectedValue;
                        int desigId = (int)cmbDesignation.SelectedValue;
                        cmd.CommandText = "Insert INTO pl_users(name, phone, email, address, join_date, gender, username, password, fk_role_id, fk_dept_id, fk_desig_id) " +
                         " VALUES(@name, @phone, @email, @address, @join_date,@gender,@username, @password, @fk_role_id, @fk_dept_id, @fk_desig_id)";
                        cmd.Parameters.AddWithValue("@name", txtName.Text);
                        cmd.Parameters.AddWithValue("@phone", txtPhone.Text);
                        cmd.Parameters.AddWithValue("@email", txtEmail.Text);
                        cmd.Parameters.AddWithValue("@address", txtAddress.Text);
                        cmd.Parameters.AddWithValue("@join_date", dtpJoinDate.Value);
                        if (optMale.Checked)
                        {
                            cmd.Parameters.AddWithValue("@gender", "Male");
                        }
                        else if (optFemale.Checked)
                        {
                            cmd.Parameters.AddWithValue("@gender", "Female");
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@gender", "Others");
                        }
                        cmd.Parameters.AddWithValue("@username", txtUserName.Text);
                        cmd.Parameters.AddWithValue("@password", txtPassword.Text);
                        cmd.Parameters.AddWithValue("@fk_role_id", roleId);
                        cmd.Parameters.AddWithValue("@fk_dept_id", deptId);
                        cmd.Parameters.AddWithValue("@fk_desig_id", desigId);
                        connection.Open();
                        cmd.ExecuteNonQuery();
                        connection.Close();
                        btnClear.PerformClick();
                        showData();
                        MessageBox.Show("User Added!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }

            }

        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            foreach (Control c in Controls)
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
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            btnClear.PerformClick();
            txtUserName.Enabled= true;
            txtPassword.Enabled= true;
            txtConfirmPassword.Enabled= true;
            btnSubmit.Enabled= true;
            btnUpdate.Enabled= false;
            btnCancel.Enabled= false;
            btnDelete.Enabled= false;
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (validation() == true)
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "update pl_users set name = @name, phone = @phone, email= @email," +
                            " address = @address,join_date=@join_date, gender = @gender, fk_dept_id=@fk_dept_id," +
                            " fk_role_id= @fk_role_id, fk_desig_id=@fk_desig_id where user_id=@user_id";
                        string name = txtName.Text;
                        cmd.Parameters.AddWithValue("@user_id", userId);
                        cmd.Parameters.AddWithValue("@name", txtName.Text);
                        cmd.Parameters.AddWithValue("@phone", txtPhone.Text);
                        cmd.Parameters.AddWithValue("@email", txtEmail.Text);
                        cmd.Parameters.AddWithValue("@address", txtAddress.Text);
                        cmd.Parameters.AddWithValue("@join_date", dtpJoinDate.Value);
                        if (optMale.Checked)
                        {
                            cmd.Parameters.AddWithValue("@gender", "Male");
                        }
                        else if (optFemale.Checked)
                        {
                            cmd.Parameters.AddWithValue("@gender", "Female");
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@gender", "Others");
                        }
                        cmd.Parameters.AddWithValue("@fk_role_id", cmbRole.SelectedValue);
                        cmd.Parameters.AddWithValue("@fk_dept_id", cmbDepartment.SelectedValue);
                        cmd.Parameters.AddWithValue("@fk_desig_id", cmbDesignation.SelectedValue);
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        conn.Close();
                        btnCancel.PerformClick();
                        MessageBox.Show($"User {name} updated!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        showData();
                    }
                }
            }
        }
        private void ugUserList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;
            btnSubmit.Enabled = false;
            btnCancel.Enabled = true;

            txtUserName.Enabled = false;
            userId = Convert.ToInt32(ugUserList.Rows[e.RowIndex].Cells[0].Value.ToString());
            txtName.Text = ugUserList.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtPhone.Text = ugUserList.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtEmail.Text = ugUserList.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtAddress.Text = ugUserList.Rows[e.RowIndex].Cells[4].Value.ToString();
            dtpJoinDate.Text = ugUserList.Rows[e.RowIndex].Cells[5].Value.ToString();
            string gender = ugUserList.Rows[e.RowIndex].Cells[6].Value.ToString();
            if (gender == "Male")
            {
                optMale.Checked = true;
            }
            else if (gender == "Female")
            {
                optFemale.Checked = true;
            }
            else
            {
                optOthers.Checked = true;
            }
            txtUserName.Text = ugUserList.Rows[e.RowIndex].Cells[7].Value.ToString();
            txtPassword.Text = ugUserList.Rows[e.RowIndex].Cells[8].Value.ToString();
            txtPassword.Enabled = false;
            txtConfirmPassword.Enabled = false;
            string designation = ugUserList.Rows[e.RowIndex].Cells[9].Value.ToString();
            if (designation == "")
            {
                cmbDesignation.Text = "N/A";

            }
            else
            {
                cmbDesignation.Text = ugUserList.Rows[e.RowIndex].Cells[9].Value.ToString();
            }
            string role = ugUserList.Rows[e.RowIndex].Cells[10].Value.ToString();
            if (role == "")
            {
                cmbRole.Text = "N/A";
            }
            else
            {
                cmbRole.Text = ugUserList.Rows[e.RowIndex].Cells[10].Value.ToString();

            }
            string department = ugUserList.Rows[e.RowIndex].Cells[11].Value.ToString();
            if (department == "")
            {
                cmbDepartment.Text = "N/A";
            }
            else
            {
                cmbDepartment.Text = ugUserList.Rows[e.RowIndex].Cells[11].Value.ToString();

            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            DialogResult result = MessageBox.Show($"Do you want to delete user {name}!", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                SqlConnection conn = new SqlConnection(connectionString);
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "DELETE FROM pl_users where user_id = @userid";
                    cmd.Parameters.AddWithValue("@userid", userId);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show($"User Deleted!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    showData();
                    btnClear.PerformClick();
                }
            }



        }
    }
}