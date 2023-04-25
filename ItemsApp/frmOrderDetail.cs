using ItemsApp.Helpers;
using Microsoft.Data.SqlClient;
using System;
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
    public partial class frmOrderDetail : Form
    {
        string ordernumber = "";
        static string connectionString = ConfigurationHelper.GetConnectionString("ItemsDB");

        public frmOrderDetail()
        {
            InitializeComponent();
        }
        public void showOrderDetails()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "select p.id, order_id, item, supplier, manufacturer, qty, unit_of_measurement," +
                        " p.ordered_at, p.updated_at from pl_order_details as p right join pl_orders on" +
                        " p.order_id = pl_orders.id where order_no = @ordernumber";
                    SqlDataAdapter adapter =  new SqlDataAdapter(cmd);
                    cmd.Parameters.AddWithValue("@ordernumber", ordernumber);
                    DataTable orderDetailsTable =  new DataTable();
                    adapter.Fill(orderDetailsTable);
                    ugOrderDetails.DataSource = orderDetailsTable;
                    DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn();
                    buttonColumn.HeaderText = "Action";
                    buttonColumn.Name = "actionButton";
                    ugOrderDetails.Columns.Add(buttonColumn);
                }
            }
        }
        private void frmOrderDetail_Load(object sender, EventArgs e)
        {
            showOrderDetails();
        }
    }
}
