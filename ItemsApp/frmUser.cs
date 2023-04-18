using Microsoft.Data.SqlClient;
using System.Data;
using System.Text.RegularExpressions;

namespace ItemsApp
{
    public partial class frmUser : Form
    {
        frmAddMore addMore;
        static string connectionString = "Server=AYUSH-KARMA;Initial Catalog=UserManagementDB;Integrated Security=True;Encrypt=False;";
        public frmUser()
        {
            InitializeComponent();
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

            if (!optMale.Checked && !optFemale.Checked && !optOthers.Checked)
            {
                MessageBox.Show("Please select Gender", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (txtUserName.Text == string.Empty)
            {
                MessageBox.Show("Please choose username", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (txtPassword.Text == string.Empty)
            {
                MessageBox.Show("Password should not be empty!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
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
                        cmd.CommandText = "Insert INTO pl_users(name, phone, email, address, gender, username, password) " +
                         " VALUES(@name, @phone, @email, @address, @gender, @username, @password)";
                        cmd.Parameters.AddWithValue("@name", txtName.Text);
                        cmd.Parameters.AddWithValue("@phone", txtPhone.Text);
                        cmd.Parameters.AddWithValue("@email", txtEmail.Text);
                        cmd.Parameters.AddWithValue("@address", txtAddress.Text);
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
                        connection.Open();
                        cmd.ExecuteNonQuery();
                        connection.Close();
                        btnClear.PerformClick();
                        MessageBox.Show("User Added!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        frmLogin frmLogin = new frmLogin();
                        frmLogin.Show();
                    }

                }

            }

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            addMore = new frmAddMore();
                addMore.clearControls(this);
        }
        private void frmUser_Load(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }



}