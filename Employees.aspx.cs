using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace EmployeePayrollSystem
{
    public partial class Employees : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadDepartments();
                LoadEmployees();
            }
        }


        // =========================================================
        // LOAD DEPARTMENTS
        // =========================================================

        private void LoadDepartments()
        {
            string connectionString =
                ConfigurationManager
                .ConnectionStrings["EmployeePayrollDB"]
                .ConnectionString;

            using (SqlConnection con =
                   new SqlConnection(connectionString))
            {
                string query =
                    "SELECT DepartmentID, DepartmentName " +
                    "FROM Departments " +
                    "ORDER BY DepartmentName";

                using (SqlCommand cmd =
                       new SqlCommand(query, con))
                {
                    con.Open();

                    using (SqlDataReader reader =
                           cmd.ExecuteReader())
                    {
                        ddlDepartment.DataSource = reader;

                        ddlDepartment.DataTextField =
                            "DepartmentName";

                        ddlDepartment.DataValueField =
                            "DepartmentID";

                        ddlDepartment.DataBind();
                    }
                }
            }

            ddlDepartment.Items.Insert(
                0,
                new ListItem(
                    "-- Select Department --",
                    ""
                )
            );
        }


        // =========================================================
        // LOAD EMPLOYEES
        // =========================================================

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
                        e.EmployeeID,
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
                    ORDER BY e.EmployeeID DESC";

                using (SqlCommand cmd =
                       new SqlCommand(query, con))
                {
                    con.Open();

                    using (SqlDataReader reader =
                           cmd.ExecuteReader())
                    {
                        gvEmployees.DataSource = reader;

                        gvEmployees.DataBind();
                    }
                }
            }
        }


        // =========================================================
        // ADD EMPLOYEE
        // =========================================================

        protected void btnAddEmployee_Click(
            object sender,
            EventArgs e)
        {
            try
            {
                string connectionString =
                    ConfigurationManager
                    .ConnectionStrings["EmployeePayrollDB"]
                    .ConnectionString;

                using (SqlConnection con =
                       new SqlConnection(connectionString))
                {
                    string query = @"
                        INSERT INTO Employees
                        (
                            EmployeeName,
                            Email,
                            Phone,
                            Address,
                            DepartmentID,
                            Designation,
                            JoiningDate,
                            BasicSalary,
                            Status
                        )
                        VALUES
                        (
                            @EmployeeName,
                            @Email,
                            @Phone,
                            @Address,
                            @DepartmentID,
                            @Designation,
                            @JoiningDate,
                            @BasicSalary,
                            @Status
                        )";

                    using (SqlCommand cmd =
                           new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue(
                            "@EmployeeName",
                            txtEmployeeName.Text.Trim()
                        );

                        cmd.Parameters.AddWithValue(
                            "@Email",
                            txtEmail.Text.Trim()
                        );

                        cmd.Parameters.AddWithValue(
                            "@Phone",
                            txtPhone.Text.Trim()
                        );

                        cmd.Parameters.AddWithValue(
                            "@Address",
                            txtAddress.Text.Trim()
                        );

                        cmd.Parameters.AddWithValue(
                            "@DepartmentID",
                            ddlDepartment.SelectedValue
                        );

                        cmd.Parameters.AddWithValue(
                            "@Designation",
                            txtDesignation.Text.Trim()
                        );

                        cmd.Parameters.AddWithValue(
                            "@JoiningDate",
                            Convert.ToDateTime(
                                txtJoiningDate.Text
                            )
                        );

                        cmd.Parameters.AddWithValue(
                            "@BasicSalary",
                            Convert.ToDecimal(
                                txtBasicSalary.Text
                            )
                        );

                        cmd.Parameters.AddWithValue(
                            "@Status",
                            ddlStatus.SelectedValue
                        );

                        con.Open();

                        cmd.ExecuteNonQuery();
                    }
                }


                lblMessage.ForeColor =
                    System.Drawing.Color.Green;

                lblMessage.Text =
                    "Employee added successfully!";


                ClearFields();

                LoadEmployees();
            }
            catch (Exception ex)
            {
                lblMessage.ForeColor =
                    System.Drawing.Color.Red;

                lblMessage.Text =
                    "Error: " + ex.Message;
            }
        }


        // =========================================================
        // GRIDVIEW EDIT + DELETE
        // =========================================================

        protected void gvEmployees_RowCommand(
            object sender,
            GridViewCommandEventArgs e)
        {
            // =====================================================
            // EDIT EMPLOYEE
            // =====================================================

            if (e.CommandName == "EditEmployee")
            {
                try
                {
                    int employeeID =
                        Convert.ToInt32(
                            e.CommandArgument
                        );

                    LoadEmployeeForEdit(employeeID);
                }
                catch (Exception ex)
                {
                    lblMessage.ForeColor =
                        System.Drawing.Color.Red;

                    lblMessage.Text =
                        "Error: " + ex.Message;
                }
            }


            // =====================================================
            // DELETE EMPLOYEE
            // =====================================================

            if (e.CommandName == "DeleteEmployee")
            {
                try
                {
                    int employeeID =
                        Convert.ToInt32(
                            e.CommandArgument
                        );


                    string connectionString =
                        ConfigurationManager
                        .ConnectionStrings["EmployeePayrollDB"]
                        .ConnectionString;


                    using (SqlConnection con =
                           new SqlConnection(
                               connectionString))
                    {
                        con.Open();


                        SqlTransaction transaction =
                            con.BeginTransaction();


                        try
                        {
                            // Delete Payslips
                            string deletePayslips = @"
                                DELETE FROM Payslips
                                WHERE EmployeeID = @EmployeeID";


                            using (SqlCommand cmd =
                                   new SqlCommand(
                                       deletePayslips,
                                       con,
                                       transaction))
                            {
                                cmd.Parameters.AddWithValue(
                                    "@EmployeeID",
                                    employeeID
                                );

                                cmd.ExecuteNonQuery();
                            }


                            // Delete Salary
                            string deleteSalary = @"
                                DELETE FROM Salary
                                WHERE EmployeeID = @EmployeeID";


                            using (SqlCommand cmd =
                                   new SqlCommand(
                                       deleteSalary,
                                       con,
                                       transaction))
                            {
                                cmd.Parameters.AddWithValue(
                                    "@EmployeeID",
                                    employeeID
                                );

                                cmd.ExecuteNonQuery();
                            }


                            // Delete Attendance
                            string deleteAttendance = @"
                                DELETE FROM Attendance
                                WHERE EmployeeID = @EmployeeID";


                            using (SqlCommand cmd =
                                   new SqlCommand(
                                       deleteAttendance,
                                       con,
                                       transaction))
                            {
                                cmd.Parameters.AddWithValue(
                                    "@EmployeeID",
                                    employeeID
                                );

                                cmd.ExecuteNonQuery();
                            }


                            // Delete User
                            string deleteUser = @"
                                DELETE FROM Users
                                WHERE EmployeeID = @EmployeeID";


                            using (SqlCommand cmd =
                                   new SqlCommand(
                                       deleteUser,
                                       con,
                                       transaction))
                            {
                                cmd.Parameters.AddWithValue(
                                    "@EmployeeID",
                                    employeeID
                                );

                                cmd.ExecuteNonQuery();
                            }


                            // Finally delete Employee
                            string deleteEmployee = @"
                                DELETE FROM Employees
                                WHERE EmployeeID = @EmployeeID";


                            using (SqlCommand cmd =
                                   new SqlCommand(
                                       deleteEmployee,
                                       con,
                                       transaction))
                            {
                                cmd.Parameters.AddWithValue(
                                    "@EmployeeID",
                                    employeeID
                                );


                                int rowsAffected =
                                    cmd.ExecuteNonQuery();


                                if (rowsAffected > 0)
                                {
                                    transaction.Commit();


                                    lblMessage.ForeColor =
                                        System.Drawing.Color.Green;

                                    lblMessage.Text =
                                        "Employee deleted successfully!";
                                }
                                else
                                {
                                    transaction.Rollback();


                                    lblMessage.ForeColor =
                                        System.Drawing.Color.Red;

                                    lblMessage.Text =
                                        "Employee not found.";
                                }
                            }
                        }
                        catch
                        {
                            transaction.Rollback();

                            throw;
                        }
                    }


                    LoadEmployees();
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


        // =========================================================
        // LOAD SELECTED EMPLOYEE INTO FORM
        // =========================================================

        private void LoadEmployeeForEdit(int employeeID)
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
                        EmployeeName,
                        Email,
                        Phone,
                        Address,
                        DepartmentID,
                        Designation,
                        JoiningDate,
                        BasicSalary,
                        Status
                    FROM Employees
                    WHERE EmployeeID = @EmployeeID";


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
                            txtEmployeeName.Text =
                                reader["EmployeeName"]
                                .ToString();

                            txtEmail.Text =
                                reader["Email"]
                                .ToString();

                            txtPhone.Text =
                                reader["Phone"]
                                .ToString();

                            txtAddress.Text =
                                reader["Address"]
                                .ToString();

                            ddlDepartment.SelectedValue =
                                reader["DepartmentID"]
                                .ToString();

                            txtDesignation.Text =
                                reader["Designation"]
                                .ToString();


                            if (reader["JoiningDate"] != DBNull.Value)
                            {
                                DateTime joiningDate =
                                    Convert.ToDateTime(
                                        reader["JoiningDate"]
                                    );

                                txtJoiningDate.Text =
                                    joiningDate.ToString(
                                        "yyyy-MM-dd"
                                    );
                            }
                            else
                            {
                                txtJoiningDate.Text = "";
                            }


                            txtBasicSalary.Text =
                                reader["BasicSalary"]
                                .ToString();

                            ddlStatus.SelectedValue =
                                reader["Status"]
                                .ToString();


                            // Store Employee ID
                            ViewState["EditEmployeeID"] =
                                employeeID;


                            // Change form to Edit mode
                            lblFormTitle.Text =
                                "Edit Employee";

                            btnAddEmployee.Visible =
                                false;

                            btnUpdateEmployee.Visible =
                                true;

                            btnCancelEdit.Visible =
                                true;


                            lblMessage.ForeColor =
                                System.Drawing.Color.Black;

                            lblMessage.Text =
                                "Editing Employee ID: "
                                + employeeID;
                        }
                    }
                }
            }
        }


        // =========================================================
        // UPDATE EMPLOYEE
        // =========================================================

        protected void btnUpdateEmployee_Click(
            object sender,
            EventArgs e)
        {
            try
            {
                if (ViewState["EditEmployeeID"] == null)
                {
                    lblMessage.ForeColor =
                        System.Drawing.Color.Red;

                    lblMessage.Text =
                        "Please select an employee to edit.";

                    return;
                }


                int employeeID =
                    Convert.ToInt32(
                        ViewState["EditEmployeeID"]
                    );


                string connectionString =
                    ConfigurationManager
                    .ConnectionStrings["EmployeePayrollDB"]
                    .ConnectionString;


                using (SqlConnection con =
                       new SqlConnection(
                           connectionString))
                {
                    string query = @"
                        UPDATE Employees
                        SET
                            EmployeeName = @EmployeeName,
                            Email = @Email,
                            Phone = @Phone,
                            Address = @Address,
                            DepartmentID = @DepartmentID,
                            Designation = @Designation,
                            JoiningDate = @JoiningDate,
                            BasicSalary = @BasicSalary,
                            Status = @Status
                        WHERE EmployeeID = @EmployeeID";


                    using (SqlCommand cmd =
                           new SqlCommand(
                               query,
                               con))
                    {
                        cmd.Parameters.AddWithValue(
                            "@EmployeeName",
                            txtEmployeeName.Text.Trim()
                        );

                        cmd.Parameters.AddWithValue(
                            "@Email",
                            txtEmail.Text.Trim()
                        );

                        cmd.Parameters.AddWithValue(
                            "@Phone",
                            txtPhone.Text.Trim()
                        );

                        cmd.Parameters.AddWithValue(
                            "@Address",
                            txtAddress.Text.Trim()
                        );

                        cmd.Parameters.AddWithValue(
                            "@DepartmentID",
                            ddlDepartment.SelectedValue
                        );

                        cmd.Parameters.AddWithValue(
                            "@Designation",
                            txtDesignation.Text.Trim()
                        );

                        cmd.Parameters.AddWithValue(
                            "@JoiningDate",
                            Convert.ToDateTime(
                                txtJoiningDate.Text
                            )
                        );

                        cmd.Parameters.AddWithValue(
                            "@BasicSalary",
                            Convert.ToDecimal(
                                txtBasicSalary.Text
                            )
                        );

                        cmd.Parameters.AddWithValue(
                            "@Status",
                            ddlStatus.SelectedValue
                        );

                        cmd.Parameters.AddWithValue(
                            "@EmployeeID",
                            employeeID
                        );


                        con.Open();

                        cmd.ExecuteNonQuery();
                    }
                }


                lblMessage.ForeColor =
                    System.Drawing.Color.Green;

                lblMessage.Text =
                    "Employee updated successfully!";


                ClearFields();

                ExitEditMode();

                LoadEmployees();
            }
            catch (Exception ex)
            {
                lblMessage.ForeColor =
                    System.Drawing.Color.Red;

                lblMessage.Text =
                    "Error: " + ex.Message;
            }
        }


        // =========================================================
        // CANCEL EDIT
        // =========================================================

        protected void btnCancelEdit_Click(
            object sender,
            EventArgs e)
        {
            ClearFields();

            ExitEditMode();

            lblMessage.ForeColor =
                System.Drawing.Color.Black;

            lblMessage.Text = "";
        }


        // =========================================================
        // EXIT EDIT MODE
        // =========================================================

        private void ExitEditMode()
        {
            ViewState["EditEmployeeID"] = null;


            lblFormTitle.Text =
                "Add Employee";


            btnAddEmployee.Visible =
                true;


            btnUpdateEmployee.Visible =
                false;


            btnCancelEdit.Visible =
                false;
        }


        // =========================================================
        // CLEAR FORM
        // =========================================================

        private void ClearFields()
        {
            txtEmployeeName.Text = "";

            txtEmail.Text = "";

            txtPhone.Text = "";

            txtAddress.Text = "";

            txtDesignation.Text = "";

            txtJoiningDate.Text = "";

            txtBasicSalary.Text = "";


            if (ddlDepartment.Items.Count > 0)
            {
                ddlDepartment.SelectedIndex = 0;
            }


            if (ddlStatus.Items.Count > 0)
            {
                ddlStatus.SelectedIndex = 0;
            }
        }
    }
}