using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication1.Data;

namespace WebApplication1
{
    public partial class ContractWebForm : System.Web.UI.Page
    {
        VenkataAshokEntities db = new VenkataAshokEntities();
        string connectionString = @"Server=DESKTOP-37QINF6\SQLEXPRESS;Database=VenkataAshok;Integrated Security=True;";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGridView();
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            var id = ID.Text;
            var name = Name.Text;
            var city = City.Text;
            var email = Email.Text;
            var dob = DOB.Text;
            var num = NUM.Text;

            ContractDetail CD = new ContractDetail()
            {
                ContractID = Convert.ToInt32(id),
                ContractName = Convert.ToString(name),
                City = Convert.ToString(city),
                Email = Convert.ToString(email),
                DOB = DateTime.Now,
                MobileNo = num,
                CreatedDate = DateTime.Now,
            };
            db.ContractDetails.Add(CD);
            db.SaveChanges();
            //try
            //{
            //    string connectionString = @"Server=DESKTOP-37QINF6\SQLEXPRESS;Database=VenkataAshok;Integrated Security=True;";

            //    using (SqlConnection connection = new SqlConnection(connectionString))
            //    {
            //        string sql = "INSERT INTO ContractDetails (ContractID, ContractName,City,Email,DOB,MobileNo,CreatedDate) VALUES (@ContractID, @ContractName,@City,@Email,@DOB,@MobileNo,@CreatedDate)";

            //        using (SqlCommand command = new SqlCommand(sql, connection))
            //        {
            //            command.Parameters.AddWithValue("@ContractID", Convert.ToInt32(id));
            //            command.Parameters.AddWithValue("@ContractName", name);
            //            command.Parameters.AddWithValue("@City", city);
            //            command.Parameters.AddWithValue("@Email", email);
            //            command.Parameters.AddWithValue("@DOB",DateTime.Now);
            //            command.Parameters.AddWithValue("@MobileNo", num);
            //            command.Parameters.AddWithValue("@CreatedDate", DateTime.Now);

            //            connection.Open();
            //            int result = command.ExecuteNonQuery();
            //            connection.Close();


            //        }
            //    }
            //}
            //catch(Exception ex)
            //{

            //}
            BindGridView();

        }
        protected void BindGridView()
        {
            string connectionString = @"Server=DESKTOP-37QINF6\SQLEXPRESS;Database=VenkataAshok;Integrated Security=True;";

            // SQL select command to retrieve data
            string sql = "SELECT * FROM ContractDetails";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter(sql, connection))
                {
                    DataTable dataTable = new DataTable();
                    try
                    {
                        connection.Open();
                        adapter.Fill(dataTable);
                        GridView1.DataSource = dataTable;
                        GridView1.DataBind();
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

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            BindGridView();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            

            GridViewRow row = GridView1.Rows[e.RowIndex];
            int id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values["Pk_ContractID"]);

            string contractID = (row.FindControl("TextBox1") as TextBox).Text;
            string contractName = (row.FindControl("TextBox2") as TextBox).Text;
            string city = (row.FindControl("TextBox3") as TextBox).Text;
            string email = (row.FindControl("TextBox4") as TextBox).Text;
            string mobileNo = (row.FindControl("TextBox5") as TextBox).Text;
            string sql = "UPDATE ContractDetails SET ContractID=@ContractID, ContractName=@ContractName,City=@City,MobileNo=@MobileNo,Email=@Email WHERE Pk_ContractID=@Id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);

                    command.Parameters.AddWithValue("@ContractID",Convert.ToInt32(contractID));
                    command.Parameters.AddWithValue("@ContractName", contractName);
                    command.Parameters.AddWithValue("@City", city);
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@MobileNo", mobileNo);

                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                        GridView1.EditIndex = -1;
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

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            BindGridView();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[0]);
            string sql = "DELETE FROM ContractDetails WHERE Pk_ContractID=@Id";

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