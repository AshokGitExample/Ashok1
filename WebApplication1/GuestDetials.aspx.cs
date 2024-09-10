using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class GuestDetials : System.Web.UI.Page
    {
        HotelManagementEntities db = new HotelManagementEntities();

        string connectionString = @"Server=DESKTOP-37QINF6\SQLEXPRESS;Database=HotelManagement;Integrated Security=True;";

        protected void Page_Load(object sender, EventArgs e)
        {
            BindGridView();

        }

        protected void BindGridView()
        {
            // SQL select command to retrieve data
            string sql = "SELECT * FROM HotelCustomerDetails";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter(sql, connection))
                {
                    DataTable dataTable = new DataTable();
                    try
                    {
                        connection.Open();
                        adapter.Fill(dataTable);
                        GridView12.DataSource = dataTable;
                        GridView12.DataBind();
                    }
                    catch (Exception ex)
                    {
                        ResultLabel.Text = "An error occurred: " + ex.Message;
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
        }

        protected void GridView12_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView12.EditIndex = e.NewEditIndex;
            BindGridView();
        }

        protected void GridView12_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {


            GridViewRow row = GridView12.Rows[e.RowIndex];
            int id = Convert.ToInt32(GridView12.DataKeys[e.RowIndex].Values["Pk_CustomerID"]);

            string CID = (row.FindControl("TextBoxCID") as TextBox).Text;
            string CName = (row.FindControl("TextBoxCName") as TextBox).Text;
            string CNum = (row.FindControl("TextBoxCNum") as TextBox).Text;
            string email = (row.FindControl("TextBoxCEmail") as TextBox).Text;
            string RNum = (row.FindControl("TextBoxRNum") as TextBox).Text;

            
            try
            {
                var customer = db.HotelCustomerDetails.FirstOrDefault(c => c.Pk_CustomerID == id);

                if (customer != null)
                {
                    // Modify the properties of the customer
                    customer.C_ID =Convert.ToInt32(CID);
                    customer.C_Name = CName;
                    customer.C_Num = CNum;
                    customer.C_Email = email;
                    customer.R_Num = Convert.ToInt32(RNum);
                    
                    // Save the changes to the database
                    db.SaveChanges();
                }
                GridView12.EditIndex = -1;
                BindGridView();

            }
            catch (Exception ex)
            {

            }
            
            // string sql = "UPDATE HotelCustomerDetails SET ContractID=@ContractID, ContractName=@ContractName,City=@City,MobileNo=@MobileNo,Email=@Email WHERE Pk_ContractID=@Id";

            // using (SqlConnection connection = new SqlConnection(connectionString))
            //  {
            //using (SqlCommand command = new SqlCommand(sql, connection))
            //{
            //    command.Parameters.AddWithValue("@Id", id);

            //    command.Parameters.AddWithValue("@ContractID", Convert.ToInt32(contractID));
            //    command.Parameters.AddWithValue("@ContractName", contractName);
            //    command.Parameters.AddWithValue("@City", city);
            //    command.Parameters.AddWithValue("@Email", email);
            //    command.Parameters.AddWithValue("@MobileNo", mobileNo);

            //    try
            //    {
            //        connection.Open();
            //        command.ExecuteNonQuery();
            //        GridView1.EditIndex = -1;
            //        BindGridView();
            //    }
            //    catch (Exception ex)
            //    {
            //        ResultLabel.Text = "An error occurred: " + ex.Message;
            //    }
            //    finally
            //    {
            //        connection.Close();
            //    }
            //}
            // }
        }

        protected void GridView12_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView12.EditIndex = -1;
            BindGridView();
        }

        protected void GridView12_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(GridView12.DataKeys[e.RowIndex].Values[0]);
            string sql = "DELETE FROM HotelCustomerDetails WHERE Pk_CustomerID=@Id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);

                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                        BindGridView();
                    }
                    catch (Exception ex)
                    {
                        ResultLabel.Text = "An error occurred: " + ex.Message;
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }

        }
    }
}