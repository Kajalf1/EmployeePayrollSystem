using System;
using System.Configuration;
using System.Data.SqlClient;

namespace EmployeePayrollSystem
{
    public partial class EmployeePayslip : System.Web.UI.Page
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

                LoadPayslips(employeeID);
                LoadLatestPayslip(employeeID);
            }
        }

        private void LoadPayslips(int employeeID)
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
                        s.SalaryMonth,
                        s.SalaryYear,
                        s.NetSalary,
                        p.GeneratedDate
                    FROM Payslips p
                    INNER JOIN Salary s
                        ON p.SalaryID = s.SalaryID
                    WHERE p.EmployeeID = @EmployeeID
                    ORDER BY
                        s.SalaryYear DESC,
                        s.SalaryMonth DESC";

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
                        gvPayslips.DataSource = reader;
                        gvPayslips.DataBind();
                    }
                }
            }
        }

        private void LoadLatestPayslip(int employeeID)
        {
            string connectionString =
                ConfigurationManager
                .ConnectionStrings["EmployeePayrollDB"]
                .ConnectionString;

            using (SqlConnection con =
                   new SqlConnection(connectionString))
            {
                string query = @"
                    SELECT TOP 1
                        e.EmployeeName,
                        s.SalaryMonth,
                        s.SalaryYear,
                        s.BasicSalary,
                        s.HRA,
                        s.Allowance,
                        s.Bonus,
                        s.Deduction,
                        s.NetSalary,
                        p.GeneratedDate
                    FROM Payslips p
                    INNER JOIN Salary s
                        ON p.SalaryID = s.SalaryID
                    INNER JOIN Employees e
                        ON p.EmployeeID = e.EmployeeID
                    WHERE p.EmployeeID = @EmployeeID
                    ORDER BY
                        p.GeneratedDate DESC";

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

                            int month =
                                Convert.ToInt32(
                                    reader["SalaryMonth"]
                                );

                            lblSalaryMonth.Text =
                                new DateTime(
                                    2000,
                                    month,
                                    1
                                ).ToString("MMMM");

                            lblSalaryYear.Text =
                                reader["SalaryYear"].ToString();

                            lblBasicSalary.Text =
                                Convert.ToDecimal(
                                    reader["BasicSalary"]
                                ).ToString("0.00");

                            lblHRA.Text =
                                Convert.ToDecimal(
                                    reader["HRA"]
                                ).ToString("0.00");

                            lblAllowance.Text =
                                Convert.ToDecimal(
                                    reader["Allowance"]
                                ).ToString("0.00");

                            lblBonus.Text =
                                Convert.ToDecimal(
                                    reader["Bonus"]
                                ).ToString("0.00");

                            lblDeduction.Text =
                                Convert.ToDecimal(
                                    reader["Deduction"]
                                ).ToString("0.00");

                            lblNetSalary.Text =
                                Convert.ToDecimal(
                                    reader["NetSalary"]
                                ).ToString("0.00");

                            lblGeneratedDate.Text =
                                Convert.ToDateTime(
                                    reader["GeneratedDate"]
                                ).ToString(
                                    "dd-MM-yyyy HH:mm"
                                );
                        }
                    }
                }
            }
        }
    }
}