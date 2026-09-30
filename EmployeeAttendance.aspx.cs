using System;
using System.Configuration;
using System.Data.SqlClient;

namespace EmployeePayrollSystem
{
    public partial class EmployeeAttendance : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["Role"] == null ||
                    Session["Role"].ToString() != "Employee")
                {
                    Response.Redirect("Login.aspx");
                    return;
                }

                if (Session["EmployeeID"] == null)
                {
                    Response.Redirect("Login.aspx");
                    return;
                }

                int employeeID =
                    Convert.ToInt32(Session["EmployeeID"]);

                LoadAttendance(employeeID);
            }
        }

        private void LoadAttendance(int employeeID)
        {
            string connectionString =
                ConfigurationManager
                .ConnectionStrings["EmployeePayrollDB"]
                .ConnectionString;

            using (SqlConnection con =
                   new SqlConnection(connectionString))
            {
                string query = @"
                    SELECT
                        AttendanceDate,
                        AttendanceStatus
                    FROM Attendance
                    WHERE EmployeeID = @EmployeeID
                    ORDER BY AttendanceDate DESC";

                using (SqlCommand cmd =
                       new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue(
                        "@EmployeeID",
                        employeeID
                    );

                    con.Open();

                    using (SqlDataReader reader =
                           cmd.ExecuteReader())
                    {
                        gvAttendance.DataSource = reader;
                        gvAttendance.DataBind();
                    }
                }
            }
        }
    }
}