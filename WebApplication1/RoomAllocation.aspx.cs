using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class RoomAllocation : System.Web.UI.Page
    {
        string connectionString = @"Server=DESKTOP-37QINF6\SQLEXPRESS;Database=HotelManagement;Integrated Security=True;";

        HotelManagementEntities db = new HotelManagementEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindStudentDropdown();
            }

        }
        private void BindStudentDropdown()
        {
            // Replace with your actual database connection string

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT Pk_CustomerID, C_Name FROM HotelCustomerDetails";
                SqlCommand cmd = new SqlCommand(query, con);

                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                // Bind data to the DropDownList
                DrpName.DataSource = dr;
                DrpName.DataTextField = "C_Name"; // Column to display
                DrpName.DataValueField = "Pk_CustomerID";  // Column to use as value
                DrpName.DataBind();

                // Optionally, you can add a default item at the top
                DrpName.Items.Insert(0, new ListItem("--Select --", "0"));

                con.Close();
            }
        }
        protected void DrpName_SelectedIndexChanged(object sender, EventArgs e)
        {
            var x = DrpName.SelectedValue;

        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            { 
                var id = ID.Text;
                var name = Name.Text;
                var CNo = CNum.Text;
                var email = Email.Text;
                var RNO =Convert.ToInt32(RNum.Text);

                HotelCustomerDetail CD = new HotelCustomerDetail()
                {
                    C_ID = Convert.ToInt32(id),
                    C_Name = Convert.ToString(name),
                    C_Num = Convert.ToString(CNo),
                    C_Email = Convert.ToString(email),
                     R_Num= RNO,
                    
                    CreatedDate = DateTime.Now,
                };
                db.HotelCustomerDetails.Add(CD);
                db.SaveChanges();
                Response.Redirect(Request.RawUrl);
            }
            catch(Exception ex)
            {
                Response.Redirect(Request.RawUrl);
            }

        }
    }
}