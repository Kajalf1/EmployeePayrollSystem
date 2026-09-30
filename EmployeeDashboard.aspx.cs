using System;
using System.Configuration;
using System.Data.SqlClient;

namespace EmployeePayrollSystem
{
    public partial class EmployeeDashboard : System.Web.UI.Page
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

                LoadEmployeeDetails(employeeID);
            }
        }

        private void LoadEmployeeDetails(int employeeID)
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
                        e.EmployeeName,
                        e.Email,
                        e.Phone,
                        d.DepartmentName,
                        e.Designation,
                        e.JoiningDate,
                        e.BasicSalary,
                        e.Status
                    FROM Employees e
                    INNER JOIN Departments d
                        ON e.DepartmentID = d.DepartmentID
                    WHERE e.EmployeeID = @EmployeeID";

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
                        if (reader.Read())
                        {
                            lblEmployeeName.Text =
                                reader["EmployeeName"].ToString();

                            lblEmail.Text =
                                reader["Email"].ToString();

                            lblPhone.Text =
                                reader["Phone"].ToString();

                            lblDepartment.Text =
                                reader["DepartmentName"].ToString();

                            lblDesignation.Text =
                                reader["Designation"].ToString();

                            if (reader["JoiningDate"] != DBNull.Value)
                            {
                                lblJoiningDate.Text =
                                    Convert.ToDateTime(
                                        reader["JoiningDate"]
                                    ).ToString("dd-MM-yyyy");
                            }

                            lblBasicSalary.Text =
                                Convert.ToDecimal(
                                    reader["BasicSalary"]
                                ).ToString("0.00");

                            lblStatus.Text =
                                reader["Status"].ToString();
                        }
                    }
                }
            }
        }
    }
}