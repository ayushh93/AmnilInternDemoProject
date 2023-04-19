using ItemsApp.Helpers;
using Microsoft.Data.SqlClient;
using System.Data;

namespace ItemsApp
{
    public partial class frmAddMore : Form
    {
        int roleId = 0;
        private Dictionary<int, bool> permissions = new Dictionary<int, bool>();

        frmUserAdmin addRoles = new frmUserAdmin();
        static string connectionString = ConfigurationHelper.GetConnectionString("UserManagementDB");

        public frmAddMore()
        {
            InitializeComponent();
        }
        public void clearControls(Control parentControl)
        {
            foreach (Control c in parentControl.Controls)
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
        private void btnAddRole_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "Insert into pl_roles values(@name)";
                    cmd.Parameters.AddWithValue("@name", txtRoleName.Text);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    clearControls(this);
                    MessageBox.Show("Roles Added!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //update combobox instantly after inserting data in database tables 
                    if (addRoles != null)
                    {
                        addRoles.BindRolesToComboBox();
                    }
                }

            }
        }
        private void btnAddDepartment_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "Insert into pl_departments values(@dept_name, @description)";
                    cmd.Parameters.AddWithValue("@dept_name", txtDepartmentName.Text);
                    cmd.Parameters.AddWithValue("@description", txtDeptDescription.Text);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    clearControls(this);
                    MessageBox.Show("Departments Added!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (addRoles != null)
                    {
                        addRoles.BindDepartmentsToComboBox();
                    }

                }
            }
        }
        private void btnAddDesignation_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "Insert into pl_designations values (@desig_name, @description)";
                    cmd.Parameters.AddWithValue("@desig_name", txtDesignation.Text);
                    cmd.Parameters.AddWithValue("@description", txtDesigDetails.Text);
                    connection.Open();
                    cmd.ExecuteNonQuery();
                    connection.Close();
                    MessageBox.Show("Designation Added!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnClearDesig.PerformClick();
                    if (addRoles != null)
                    {
                        addRoles.BindDesignationToComboBox();
                    }

                }
            }
        }
        private void btnClearDesig_Click(object sender, EventArgs e)
        {
            foreach (Control c in tabDesig.Controls)
            {
                clearControls(this);
            }
        }
        private void btnAddPermission_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    if (cmbRoles.SelectedValue is null)
                    {
                        MessageBox.Show("Select role to update!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;

                    }
                    else
                    {
                        int roleid = (int)cmbRoles.SelectedValue;
                        SqlCommand deletecmd = conn.CreateCommand();
                        deletecmd.CommandText = "Delete from pl_roles_permissions where fk_role_id = @role_id";
                        deletecmd.Parameters.AddWithValue("@role_id", roleid);
                        conn.Open();
                        deletecmd.ExecuteNonQuery();
                        conn.Close();
                        foreach (DataGridViewRow row in ugPermissionList.Rows)
                        {
                            bool assigned = Convert.ToBoolean(row.Cells["Allow"].Value);
                            int permissionId = Convert.ToInt32(row.Cells["p_id"].Value);
                            if (assigned)
                            {
                                cmd.CommandText = "insert into pl_roles_permissions values(@fk_role_id, @fk_permission_id)";
                                cmd.Parameters.Clear();
                                cmd.Parameters.AddWithValue("@fk_role_id", roleid);
                                cmd.Parameters.AddWithValue("@fk_permission_id", permissionId);
                                conn.Open();
                                cmd.ExecuteNonQuery();
                                conn.Close();
                            }
                        }
                        ShowSelectedPermission();
                        MessageBox.Show("Updated permission!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }


                }
            }
        }
        private void btnDeleteRole_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        SqlCommand updateUserTable = new SqlCommand("Update pl_users set fk_role_id = null where fk_role_id = @roleid", conn, trans);
                        updateUserTable.Parameters.AddWithValue("@roleid", roleId);
                        SqlCommand dltroleperm = new SqlCommand("Delete from pl_roles_permissions where fk_role_id = @roleid", conn, trans);
                        dltroleperm.Parameters.AddWithValue("@roleid", roleId);
                        SqlCommand dltrole = new SqlCommand("Delete from pl_roles where role_id = @roleid", conn, trans);
                        dltrole.Parameters.AddWithValue("@roleid", roleId);
                        updateUserTable.ExecuteNonQuery();
                        dltroleperm.ExecuteNonQuery();
                        dltrole.ExecuteNonQuery();
                        trans.Commit();
                        MessageBox.Show("Role Deleted!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    catch (Exception ex)
                    {
                        trans.Rollback();
                        MessageBox.Show("An error occurred: " + ex.Message);
                    }
                    finally
                    {
                        showAllRoles();

                        conn.Close();
                    }
                }

            }
        }
        public void BindRolesToComboBox()
        {
            DataTable rolesTable = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT role_id, name FROM pl_roles", connectionString);
            adapter.Fill(rolesTable);
            cmbRoles.DataSource = rolesTable;
            cmbRoles.DisplayMember = "name";
            cmbRoles.ValueMember = "role_id";
            cmbRoles.SelectedIndex = -1;
        }
        public void ShowSelectedPermission()
        {
            try
            {
                if (cmbRoles.SelectedItem != null)
                {
                    int roleId = (int)cmbRoles.SelectedValue;
                    string sql = "sp_GetPermission @roleid";
                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        SqlCommand cmd = new SqlCommand(sql, con);
                        cmd.Parameters.AddWithValue("@roleid", roleId);
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        ugPermissionList.DataSource = dt;
                        ugPermissionList.Columns[0].Visible = false;
                        ugPermissionList.Columns[2].ValueType = typeof(bool);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void showPermission()
        {
            DataTable permissioDatatable = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter("Select p_id, permission_name as Permission from pl_permission", connectionString);
            adapter.Fill(permissioDatatable);
            ugPermissionList.DataSource = permissioDatatable;
            ugPermissionList.Columns[0].Visible = false;

            DataGridViewCheckBoxColumn chkColumn = new DataGridViewCheckBoxColumn();
            chkColumn.HeaderText = "Allow";
            chkColumn.Name = "chkHasPermission";
            ugPermissionList.Columns.Add(chkColumn);
            ugPermissionList.Columns["Permission"].ReadOnly = true;
        }
        public void showAllRoles()
        {
            SqlDataAdapter adapter= new SqlDataAdapter("Select role_id, name as Roles from pl_roles", connectionString);
            DataTable dataTable= new DataTable();
            adapter.Fill(dataTable);
            ugRoleList.DataSource= dataTable;
            ugRoleList.Columns[0].Visible = false;
        }
        public void showAllDepartments()
        {
            SqlDataAdapter adapter = new SqlDataAdapter("Select * from pl_departments", connectionString);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            ugDepartments.DataSource = dataTable;
            ugDepartments.Columns[0].Visible = false;
        }
        public void showAllDesignations()
        {
            SqlDataAdapter adapter = new SqlDataAdapter("Select * from pl_designations", connectionString);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            ugDesignation.DataSource = dataTable;
        }
        private void frmAddMore_Load(object sender, EventArgs e)
        {
            showPermission();
            BindRolesToComboBox();
            showAllRoles();
            showAllDepartments();
            showAllDesignations();
        }
        private void cmbRoles_SelectionChangeCommitted(object sender, EventArgs e)
        {
            ShowSelectedPermission();
        }
        private void ugRoleList_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btnAddRole.Enabled = false;
            roleId = Convert.ToInt32(ugRoleList.Rows[e.RowIndex].Cells[0].Value.ToString());
            txtRoleName.Text = ugRoleList.Rows[e.RowIndex].Cells[1].Value.ToString();

        }

        private void btnDeleteDesig_Click(object sender, EventArgs e)
        {

        }

        private void btnDeleteDepart_Click(object sender, EventArgs e)
        {

        }
    }
}
