using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace EmployeePayrollSystem
{
    public partial class Salary : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadEmployees();

                ddlMonth.SelectedValue =
                    DateTime.Today.Month.ToString();

                txtYear.Text =
                    DateTime.Today.Year.ToString();

                LoadSalary();
            }
        }

        private void LoadEmployees()
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
                        EmployeeID,
                        EmployeeName
                    FROM Employees
                    WHERE Status = 'Active'
                    ORDER BY EmployeeName";

                using (SqlCommand cmd =
                       new SqlCommand(query, con))
                {
                    con.Open();

                    using (SqlDataReader reader =
                           cmd.ExecuteReader())
                    {
                        ddlEmployee.DataSource = reader;
                        ddlEmployee.DataTextField =
                            "EmployeeName";
                        ddlEmployee.DataValueField =
                            "EmployeeID";
                        ddlEmployee.DataBind();
                    }
                }
            }

            ddlEmployee.Items.Insert(
                0,
                new ListItem(
                    "-- Select Employee --",
                    ""
                )
            );
        }

        private void LoadSalary()
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
                        s.SalaryID,
                        e.EmployeeName,
                        s.SalaryMonth,
                        s.SalaryYear,
                        s.BasicSalary,
                        s.HRA,
                        s.Allowance,
                        s.Bonus,
                        s.Deduction,
                        s.NetSalary
                    FROM Salary s
                    INNER JOIN Employees e
                        ON s.EmployeeID = e.EmployeeID
                    ORDER BY
                        s.SalaryYear DESC,
                        s.SalaryMonth DESC,
                        s.SalaryID DESC";

                using (SqlCommand cmd =
                       new SqlCommand(query, con))
                {
                    con.Open();

                    using (SqlDataReader reader =
                           cmd.ExecuteReader())
                    {
                        gvSalary.DataSource = reader;
                        gvSalary.DataBind();
                    }
                }
            }
        }

        protected void btnGenerateSalary_Click(
            object sender,
            EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(
                    ddlEmployee.SelectedValue))
                {
                    lblMessage.ForeColor =
                        System.Drawing.Color.Red;

                    lblMessage.Text =
                        "Please select an employee.";

                    return;
                }

                if (string.IsNullOrWhiteSpace(
                    txtYear.Text))
                {
                    lblMessage.ForeColor =
                        System.Drawing.Color.Red;

                    lblMessage.Text =
                        "Please enter salary year.";

                    return;
                }

                if (string.IsNullOrWhiteSpace(
                    txtBasicSalary.Text))
                {
                    lblMessage.ForeColor =
                        System.Drawing.Color.Red;

                    lblMessage.Text =
                        "Please enter basic salary.";

                    return;
                }

                int employeeID =
                    Convert.ToInt32(
                        ddlEmployee.SelectedValue
                    );

                int salaryMonth =
                    Convert.ToInt32(
                        ddlMonth.SelectedValue
                    );

                int salaryYear =
                    Convert.ToInt32(
                        txtYear.Text
                    );

                decimal basicSalary =
                    Convert.ToDecimal(
                        txtBasicSalary.Text
                    );

                decimal hra = 0;

                decimal allowance = 0;

                decimal bonus = 0;

                decimal deduction = 0;

                if (!string.IsNullOrWhiteSpace(
                    txtHRA.Text))
                {
                    hra =
                        Convert.ToDecimal(
                            txtHRA.Text
                        );
                }

                if (!string.IsNullOrWhiteSpace(
                    txtAllowance.Text))
                {
                    allowance =
                        Convert.ToDecimal(
                            txtAllowance.Text
                        );
                }

                if (!string.IsNullOrWhiteSpace(
                    txtBonus.Text))
                {
                    bonus =
                        Convert.ToDecimal(
                            txtBonus.Text
                        );
                }

                if (!string.IsNullOrWhiteSpace(
                    txtDeduction.Text))
                {
                    deduction =
                        Convert.ToDecimal(
                            txtDeduction.Text
                        );
                }

                decimal netSalary =
                    basicSalary
                    + hra
                    + allowance
                    + bonus
                    - deduction;

                string connectionString =
                    ConfigurationManager
                    .ConnectionStrings["EmployeePayrollDB"]
                    .ConnectionString;

                using (SqlConnection con =
                       new SqlConnection(connectionString))
                {
                    con.Open();

                    string checkQuery = @"
                        SELECT COUNT(*)
                        FROM Salary
                        WHERE EmployeeID = @EmployeeID
                        AND SalaryMonth = @SalaryMonth
                        AND SalaryYear = @SalaryYear";

                    using (SqlCommand checkCmd =
                           new SqlCommand(
                               checkQuery,
                               con))
                    {
                        checkCmd.Parameters.AddWithValue(
                            "@EmployeeID",
                            employeeID
                        );

                        checkCmd.Parameters.AddWithValue(
                            "@SalaryMonth",
                            salaryMonth
                        );

                        checkCmd.Parameters.AddWithValue(
                            "@SalaryYear",
                            salaryYear
                        );

                        int count =
                            Convert.ToInt32(
                                checkCmd.ExecuteScalar()
                            );

                        if (count > 0)
                        {
                            lblMessage.ForeColor =
                                System.Drawing.Color.Red;

                            lblMessage.Text =
                                "Salary already generated for this employee for the selected month and year.";

                            return;
                        }
                    }

                    string insertQuery = @"
                        INSERT INTO Salary
                        (
                            EmployeeID,
                            SalaryMonth,
                            SalaryYear,
                            BasicSalary,
                            HRA,
                            Allowance,
                            Bonus,
                            Deduction,
                            NetSalary
                        )
                        VALUES
                        (
                            @EmployeeID,
                            @SalaryMonth,
                            @SalaryYear,
                            @BasicSalary,
                            @HRA,
                            @Allowance,
                            @Bonus,
                            @Deduction,
                            @NetSalary
                        )";

                    using (SqlCommand cmd =
                           new SqlCommand(
                               insertQuery,
                               con))
                    {
                        cmd.Parameters.AddWithValue(
                            "@EmployeeID",
                            employeeID
                        );

                        cmd.Parameters.AddWithValue(
                            "@SalaryMonth",
                            salaryMonth
                        );

                        cmd.Parameters.AddWithValue(
                            "@SalaryYear",
                            salaryYear
                        );

                        cmd.Parameters.AddWithValue(
                            "@BasicSalary",
                            basicSalary
                        );

                        cmd.Parameters.AddWithValue(
                            "@HRA",
                            hra
                        );

                        cmd.Parameters.AddWithValue(
                            "@Allowance",
                            allowance
                        );

                        cmd.Parameters.AddWithValue(
                            "@Bonus",
                            bonus
                        );

                        cmd.Parameters.AddWithValue(
                            "@Deduction",
                            deduction
                        );

                        cmd.Parameters.AddWithValue(
                            "@NetSalary",
                            netSalary
                        );

                        cmd.ExecuteNonQuery();
                    }
                }

                lblMessage.ForeColor =
                    System.Drawing.Color.Green;

                lblMessage.Text =
                    "Salary generated successfully! Net Salary: ₹"
                    + netSalary.ToString("0.00");

                ClearFields();

                LoadSalary();
            }
            catch (FormatException)
            {
                lblMessage.ForeColor =
                    System.Drawing.Color.Red;

                lblMessage.Text =
                    "Please enter valid numeric values.";
            }
            catch (Exception ex)
            {
                lblMessage.ForeColor =
                    System.Drawing.Color.Red;

                lblMessage.Text =
                    "Error: " + ex.Message;
            }
        }

        private void ClearFields()
        {
            if (ddlEmployee.Items.Count > 0)
            {
                ddlEmployee.SelectedIndex = 0;
            }

            ddlMonth.SelectedValue =
                DateTime.Today.Month.ToString();

            txtYear.Text =
                DateTime.Today.Year.ToString();

            txtBasicSalary.Text = "";

            txtHRA.Text = "";

            txtAllowance.Text = "";

            txtBonus.Text = "";

            txtDeduction.Text = "";
        }
    }
}