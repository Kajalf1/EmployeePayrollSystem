using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace EmployeePayrollSystem
{
    public partial class Attendance : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadEmployees();
                SetDefaultDate();
                LoadAttendance();
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

        private void SetDefaultDate()
        {
            txtAttendanceDate.Text =
                DateTime.Today.ToString("yyyy-MM-dd");
        }

        private void LoadAttendance()
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
                        a.AttendanceID,
                        e.EmployeeName,
                        a.AttendanceDate,
                        a.AttendanceStatus
                    FROM Attendance a
                    INNER JOIN Employees e
                        ON a.EmployeeID = e.EmployeeID
                    ORDER BY
                        a.AttendanceDate DESC,
                        e.EmployeeName";

                using (SqlCommand cmd =
                       new SqlCommand(query, con))
                {
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

        protected void btnMarkAttendance_Click(
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
                    txtAttendanceDate.Text))
                {
                    lblMessage.ForeColor =
                        System.Drawing.Color.Red;

                    lblMessage.Text =
                        "Please select attendance date.";

                    return;
                }

                DateTime attendanceDate =
                    Convert.ToDateTime(
                        txtAttendanceDate.Text
                    );

                int employeeID =
                    Convert.ToInt32(
                        ddlEmployee.SelectedValue
                    );

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
                        FROM Attendance
                        WHERE EmployeeID = @EmployeeID
                        AND AttendanceDate = @AttendanceDate";

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
                            "@AttendanceDate",
                            attendanceDate.Date
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
                                "Attendance already marked for this employee on this date.";

                            return;
                        }
                    }

                    string insertQuery = @"
                        INSERT INTO Attendance
                        (
                            EmployeeID,
                            AttendanceDate,
                            AttendanceStatus
                        )
                        VALUES
                        (
                            @EmployeeID,
                            @AttendanceDate,
                            @AttendanceStatus
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
                            "@AttendanceDate",
                            attendanceDate.Date
                        );

                        cmd.Parameters.AddWithValue(
                            "@AttendanceStatus",
                            ddlAttendanceStatus.SelectedValue
                        );

                        cmd.ExecuteNonQuery();
                    }
                }

                lblMessage.ForeColor =
                    System.Drawing.Color.Green;

                lblMessage.Text =
                    "Attendance marked successfully!";

                ddlEmployee.SelectedIndex = 0;

                ddlAttendanceStatus.SelectedIndex = 0;

                SetDefaultDate();

                LoadAttendance();
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