using System;
using System.Web.UI;

namespace EmployeePayrollSystem
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string currentPage =
                System.IO.Path.GetFileName(
                    Request.Url.AbsolutePath
                );

            // Login page
            if (currentPage.Equals(
                    "Login.aspx",
                    StringComparison.OrdinalIgnoreCase)
                ||
                currentPage.Equals(
                    "Login",
                    StringComparison.OrdinalIgnoreCase))
            {
                pnlAdminMenu.Visible = false;
                pnlEmployeeMenu.Visible = false;

                return;
            }

            // Check login
            if (Session["Role"] == null)
            {
                Response.Redirect("~/Login.aspx");
                return;
            }

            string role =
                Session["Role"].ToString().Trim();

            // ADMIN
            if (role.Equals(
                "Admin",
                StringComparison.OrdinalIgnoreCase))
            {
                pnlAdminMenu.Visible = true;
                pnlEmployeeMenu.Visible = false;

                return;
            }

            // EMPLOYEE
            if (role.Equals(
                "Employee",
                StringComparison.OrdinalIgnoreCase))
            {
                pnlAdminMenu.Visible = false;
                pnlEmployeeMenu.Visible = true;

                // Employee allowed pages
                if (currentPage.Equals(
                        "EmployeeDashboard.aspx",
                        StringComparison.OrdinalIgnoreCase)
                    ||
                    currentPage.Equals(
                        "EmployeeDashboard",
                        StringComparison.OrdinalIgnoreCase)
                    ||
                    currentPage.Equals(
                        "EmployeeAttendance.aspx",
                        StringComparison.OrdinalIgnoreCase)
                    ||
                    currentPage.Equals(
                        "EmployeeAttendance",
                        StringComparison.OrdinalIgnoreCase)
                    ||
                    currentPage.Equals(
                        "EmployeeSalary.aspx",
                        StringComparison.OrdinalIgnoreCase)
                    ||
                    currentPage.Equals(
                        "EmployeeSalary",
                        StringComparison.OrdinalIgnoreCase)
                    ||
                    currentPage.Equals(
                        "EmployeePayslip.aspx",
                        StringComparison.OrdinalIgnoreCase)
                    ||
                    currentPage.Equals(
                        "EmployeePayslip",
                        StringComparison.OrdinalIgnoreCase))
                {
                    return;
                }

                // Any other page goes to Employee Dashboard
                Response.Redirect(
                    "~/EmployeeDashboard.aspx"
                );

                return;
            }

            // Invalid role
            Session.Clear();

            Response.Redirect("~/Login.aspx");
        }

        protected void lnkLogout_Click(
            object sender,
            EventArgs e)
        {
            Session.Clear();
            Session.Abandon();

            Response.Redirect("~/Login.aspx");
        }
    }
}