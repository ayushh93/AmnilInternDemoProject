using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemsApp.Helpers
{
    public static class AuthorisationHelper
    {
        static string connectionString = ConfigurationHelper.GetConnectionString("UserManagementDB");

        //Returns role id of the logged in user
        public static int GetUserRoleId(int loginId)
        {
            int roleId = 0;
            string query = "SELECT fk_role_id FROM pl_users WHERE user_id = @userId";
            using(SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@userId", loginId);
                SqlDataReader reader = command.ExecuteReader();
                if(reader.Read())
                {
                    roleId =  reader.GetInt32(0);
                }
                connection.Close();

                return roleId;
            }
        }

        public static bool HasPermission(int loginId, string permissionName)
        {
            //Get roleId of the user
            int roleId = GetUserRoleId(loginId);
            bool hasPermission = false;
            string query = "SELECT COUNT(*) FROM pl_roles_permissions rp " +
                           "JOIN pl_permission p ON rp.fk_permission_id = p.p_id " +
                           "WHERE rp.fk_role_id = @roleId AND p.permission_name = @permissionName";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@roleId", roleId);
                command.Parameters.AddWithValue("@permissionName", permissionName);
                int count = (int)command.ExecuteScalar();
                connection.Close();

                if (count > 0)
                {
                    hasPermission = true;
                }
            }

            return hasPermission;
        }


    }
}
