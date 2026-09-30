using System;
using System.Configuration;
using System.Data.SqlClient;

namespace EmployeePayrollSystem
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            string connectionString =
                ConfigurationManager
                .ConnectionStrings["EmployeePayrollDB"]
                .ConnectionString;

            try
            {
                using (SqlConnection con =
                       new SqlConnection(connectionString))
                {
                    string query = @"
                        SELECT
                            UserID,
                            Role,
                            EmployeeID
                        FROM Users
                        WHERE Username = @Username
                        AND Password = @Password";

                    using (SqlCommand cmd =
                           new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue(
                            "@Username",
                            username
                        );

                        cmd.Parameters.AddWithValue(
                            "@Password",
                            password
                        );

                        con.Open();

                        using (SqlDataReader reader =
                               cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string role =
                                reader["Role"].ToString().Trim();

                                Session["UserID"] =
                                    reader["UserID"];

                                Session["Role"] =
                                    role;

                                if (reader["EmployeeID"] != DBNull.Value)
                                {
                                        Session["EmployeeID"] =
                                        reader["EmployeeID"];
                                }
                                else
                                {
                                    Session["EmployeeID"] = null;
                                }

                                if (role.Equals(
                                    "Admin",
                                    StringComparison.OrdinalIgnoreCase))
                                {
                                    Response.Redirect(
                                        "AdminDashboard.aspx",
                                        false
                                    );

                                    Context.ApplicationInstance
                                        .CompleteRequest();

                                    return;
                                }

                                if (role.Equals(
                                    "Employee",
                                    StringComparison.OrdinalIgnoreCase))
                                {
                                    if (reader["EmployeeID"] == DBNull.Value)
                                    {
                                        lblMessage.ForeColor =
                                            System.Drawing.Color.Red;

                                        lblMessage.Text =
                                            "Employee account is not linked to an employee.";

                                        return;
                                    }

                                    Response.Redirect(
                                        "EmployeeDashboard.aspx",
                                        false
                                    );

                                    Context.ApplicationInstance
                                        .CompleteRequest();

                                    return;
                                }

                                lblMessage.ForeColor =
                                    System.Drawing.Color.Red;

                                lblMessage.Text =
                                    "Invalid user role.";
                            }
                            else
                            {
                                lblMessage.ForeColor =
                                    System.Drawing.Color.Red;

                                lblMessage.Text =
                                    "Invalid username or password.";
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                lblMessage.ForeColor =
                    System.Drawing.Color.Red;

                lblMessage.Text =
                    "Error: " + ex.Message;
            }
        }
    }
}