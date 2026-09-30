using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace EmployeePayrollSystem
{
    public partial class Departments : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadDepartments();
            }
        }

        private void LoadDepartments()
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
                        DepartmentID,
                        DepartmentName
                    FROM Departments
                    ORDER BY DepartmentID DESC";

                using (SqlCommand cmd =
                       new SqlCommand(query, con))
                {
                    con.Open();

                    using (SqlDataReader reader =
                           cmd.ExecuteReader())
                    {
                        gvDepartments.DataSource = reader;
                        gvDepartments.DataBind();
                    }
                }
            }
        }

        protected void btnAddDepartment_Click(
            object sender,
            EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(
                    txtDepartmentName.Text))
                {
                    lblMessage.ForeColor =
                        System.Drawing.Color.Red;

                    lblMessage.Text =
                        "Please enter department name.";

                    return;
                }

                string connectionString =
                    ConfigurationManager
                    .ConnectionStrings["EmployeePayrollDB"]
                    .ConnectionString;

                using (SqlConnection con =
                       new SqlConnection(connectionString))
                {
                    string query = @"
                        INSERT INTO Departments
                        (
                            DepartmentName
                        )
                        VALUES
                        (
                            @DepartmentName
                        )";

                    using (SqlCommand cmd =
                           new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue(
                            "@DepartmentName",
                            txtDepartmentName.Text.Trim()
                        );

                        con.Open();
                        cmd.ExecuteNonQuery();
                    }
                }

                lblMessage.ForeColor =
                    System.Drawing.Color.Green;

                lblMessage.Text =
                    "Department added successfully!";

                txtDepartmentName.Text = "";

                LoadDepartments();
            }
            catch (Exception ex)
            {
                lblMessage.ForeColor =
                    System.Drawing.Color.Red;

                lblMessage.Text =
                    "Error: " + ex.Message;
            }
        }

        protected void gvDepartments_RowCommand(
            object sender,
            GridViewCommandEventArgs e)
        {
            if (e.CommandName == "EditDepartment")
            {
                try
                {
                    int departmentID =
                        Convert.ToInt32(
                            e.CommandArgument
                        );

                    LoadDepartmentForEdit(
                        departmentID
                    );
                }
                catch (Exception ex)
                {
                    lblMessage.ForeColor =
                        System.Drawing.Color.Red;

                    lblMessage.Text =
                        "Error: " + ex.Message;
                }
            }

            if (e.CommandName == "DeleteDepartment")
            {
                try
                {
                    int departmentID =
                        Convert.ToInt32(
                            e.CommandArgument
                        );

                    DeleteDepartment(
                        departmentID
                    );
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

        private void LoadDepartmentForEdit(
            int departmentID)
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
                        DepartmentName
                    FROM Departments
                    WHERE DepartmentID = @DepartmentID";

                using (SqlCommand cmd =
                       new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue(
                        "@DepartmentID",
                        departmentID
                    );

                    con.Open();

                    using (SqlDataReader reader =
                           cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            txtDepartmentName.Text =
                                reader["DepartmentName"]
                                .ToString();

                            ViewState[
                                "EditDepartmentID"
                            ] = departmentID;

                            lblFormTitle.Text =
                                "Edit Department";

                            btnAddDepartment.Visible =
                                false;

                            btnUpdateDepartment.Visible =
                                true;

                            btnCancelEdit.Visible =
                                true;

                            lblMessage.ForeColor =
                                System.Drawing.Color.Black;

                            lblMessage.Text =
                                "Editing Department ID: "
                                + departmentID;
                        }
                    }
                }
            }
        }

        protected void btnUpdateDepartment_Click(
            object sender,
            EventArgs e)
        {
            try
            {
                if (ViewState[
                    "EditDepartmentID"
                ] == null)
                {
                    lblMessage.ForeColor =
                        System.Drawing.Color.Red;

                    lblMessage.Text =
                        "Please select a department to edit.";

                    return;
                }

                if (string.IsNullOrWhiteSpace(
                    txtDepartmentName.Text))
                {
                    lblMessage.ForeColor =
                        System.Drawing.Color.Red;

                    lblMessage.Text =
                        "Please enter department name.";

                    return;
                }

                int departmentID =
                    Convert.ToInt32(
                        ViewState[
                            "EditDepartmentID"
                        ]
                    );

                string connectionString =
                    ConfigurationManager
                    .ConnectionStrings["EmployeePayrollDB"]
                    .ConnectionString;

                using (SqlConnection con =
                       new SqlConnection(connectionString))
                {
                    string query = @"
                        UPDATE Departments
                        SET
                            DepartmentName =
                                @DepartmentName
                        WHERE DepartmentID =
                            @DepartmentID";

                    using (SqlCommand cmd =
                           new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue(
                            "@DepartmentName",
                            txtDepartmentName.Text.Trim()
                        );

                        cmd.Parameters.AddWithValue(
                            "@DepartmentID",
                            departmentID
                        );

                        con.Open();
                        cmd.ExecuteNonQuery();
                    }
                }

                lblMessage.ForeColor =
                    System.Drawing.Color.Green;

                lblMessage.Text =
                    "Department updated successfully!";

                ClearFields();
                ExitEditMode();
                LoadDepartments();
            }
            catch (Exception ex)
            {
                lblMessage.ForeColor =
                    System.Drawing.Color.Red;

                lblMessage.Text =
                    "Error: " + ex.Message;
            }
        }

        private void DeleteDepartment(
            int departmentID)
        {
            string connectionString =
                ConfigurationManager
                .ConnectionStrings["EmployeePayrollDB"]
                .ConnectionString;

            using (SqlConnection con =
                   new SqlConnection(connectionString))
            {
                con.Open();

                try
                {
                    string checkEmployees = @"
                        SELECT COUNT(*)
                        FROM Employees
                        WHERE DepartmentID =
                            @DepartmentID";

                    using (SqlCommand checkCmd =
                           new SqlCommand(
                               checkEmployees,
                               con))
                    {
                        checkCmd.Parameters.AddWithValue(
                            "@DepartmentID",
                            departmentID
                        );

                        int employeeCount =
                            Convert.ToInt32(
                                checkCmd.ExecuteScalar()
                            );

                        if (employeeCount > 0)
                        {
                            lblMessage.ForeColor =
                                System.Drawing.Color.Red;

                            lblMessage.Text =
                                "Cannot delete this department because employees are assigned to it.";

                            return;
                        }
                    }

                    string query = @"
                        DELETE FROM Departments
                        WHERE DepartmentID =
                            @DepartmentID";

                    using (SqlCommand cmd =
                           new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue(
                            "@DepartmentID",
                            departmentID
                        );

                        int rowsAffected =
                            cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            lblMessage.ForeColor =
                                System.Drawing.Color.Green;

                            lblMessage.Text =
                                "Department deleted successfully!";
                        }
                        else
                        {
                            lblMessage.ForeColor =
                                System.Drawing.Color.Red;

                            lblMessage.Text =
                                "Department not found.";
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

            LoadDepartments();
        }

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

        private void ExitEditMode()
        {
            ViewState[
                "EditDepartmentID"
            ] = null;

            lblFormTitle.Text =
                "Add Department";

            btnAddDepartment.Visible =
                true;

            btnUpdateDepartment.Visible =
                false;

            btnCancelEdit.Visible =
                false;
        }

        private void ClearFields()
        {
            txtDepartmentName.Text = "";
        }
    }
}