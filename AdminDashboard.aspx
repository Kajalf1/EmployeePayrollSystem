<%@ Page Title="Admin Dashboard" Language="C#" MasterPageFile="~/Site.master"
    AutoEventWireup="true" CodeBehind="AdminDashboard.aspx.cs"
    Inherits="EmployeePayrollSystem.AdminDashboard" %>

<asp:Content ID="Content1"
    ContentPlaceHolderID="MainContent"
    runat="server">

    <div style="padding:30px;">

        <!-- Dashboard Header -->

        <div style="margin-bottom:30px;">

            <h2 style="margin:0;
                       color:#1f2937;
                       font-size:30px;">
                Admin Dashboard
            </h2>

            <p style="margin-top:8px;
                      color:#6b7280;
                      font-size:15px;">
                Manage employees, attendance, salary and payroll records
            </p>

        </div>


        <!-- Welcome Card -->

        <div style="background:linear-gradient(135deg,#1f2937,#374151);
                    color:white;
                    padding:28px;
                    border-radius:14px;
                    margin-bottom:30px;
                    box-shadow:0 5px 18px rgba(0,0,0,0.12);">

            <div style="font-size:14px;
                        opacity:0.8;
                        margin-bottom:6px;">
                Welcome back
            </div>

            <div style="font-size:25px;
                        font-weight:bold;">
                Administrator
            </div>

            <div style="font-size:14px;
                        opacity:0.85;
                        margin-top:8px;">
                Use the dashboard to manage your employee payroll system.
            </div>

        </div>


        <!-- Dashboard Cards -->

        <div style="display:grid;
                    grid-template-columns:repeat(auto-fit,minmax(220px,1fr));
                    gap:22px;">


            <!-- Employees -->

            <div style="background:white;
                        padding:25px;
                        border-radius:14px;
                        box-shadow:0 4px 15px rgba(0,0,0,0.08);
                        border:1px solid #e5e7eb;
                        transition:transform 0.2s, box-shadow 0.2s;"
                 onmouseover="this.style.transform='translateY(-5px)'; this.style.boxShadow='0 8px 20px rgba(0,0,0,0.12)'"
                 onmouseout="this.style.transform='translateY(0)'; this.style.boxShadow='0 4px 15px rgba(0,0,0,0.08)'">

                <div style="font-size:32px;
                            margin-bottom:15px;">
                    👥
                </div>

                <h3 style="margin:0 0 10px 0;
                           color:#1f2937;">
                    Employees
                </h3>

                <p style="margin:0;
                          color:#6b7280;
                          line-height:1.5;">
                    Manage employee records and information.
                </p>

            </div>


            <!-- Departments -->

            <div style="background:white;
                        padding:25px;
                        border-radius:14px;
                        box-shadow:0 4px 15px rgba(0,0,0,0.08);
                        border:1px solid #e5e7eb;
                        transition:transform 0.2s, box-shadow 0.2s;"
                 onmouseover="this.style.transform='translateY(-5px)'; this.style.boxShadow='0 8px 20px rgba(0,0,0,0.12)'"
                 onmouseout="this.style.transform='translateY(0)'; this.style.boxShadow='0 4px 15px rgba(0,0,0,0.08)'">

                <div style="font-size:32px;
                            margin-bottom:15px;">
                    🏢
                </div>

                <h3 style="margin:0 0 10px 0;
                           color:#1f2937;">
                    Departments
                </h3>

                <p style="margin:0;
                          color:#6b7280;
                          line-height:1.5;">
                    Manage company departments.
                </p>

            </div>


            <!-- Attendance -->

            <div style="background:white;
                        padding:25px;
                        border-radius:14px;
                        box-shadow:0 4px 15px rgba(0,0,0,0.08);
                        border:1px solid #e5e7eb;
                        transition:transform 0.2s, box-shadow 0.2s;"
                 onmouseover="this.style.transform='translateY(-5px)'; this.style.boxShadow='0 8px 20px rgba(0,0,0,0.12)'"
                 onmouseout="this.style.transform='translateY(0)'; this.style.boxShadow='0 4px 15px rgba(0,0,0,0.08)'">

                <div style="font-size:32px;
                            margin-bottom:15px;">
                    📅
                </div>

                <h3 style="margin:0 0 10px 0;
                           color:#1f2937;">
                    Attendance
                </h3>

                <p style="margin:0;
                          color:#6b7280;
                          line-height:1.5;">
                    Manage employee attendance records.
                </p>

            </div>


            <!-- Salary -->

            <div style="background:white;
                        padding:25px;
                        border-radius:14px;
                        box-shadow:0 4px 15px rgba(0,0,0,0.08);
                        border:1px solid #e5e7eb;
                        transition:transform 0.2s, box-shadow 0.2s;"
                 onmouseover="this.style.transform='translateY(-5px)'; this.style.boxShadow='0 8px 20px rgba(0,0,0,0.12)'"
                 onmouseout="this.style.transform='translateY(0)'; this.style.boxShadow='0 4px 15px rgba(0,0,0,0.08)'">

                <div style="font-size:32px;
                            margin-bottom:15px;">
                    💰
                </div>

                <h3 style="margin:0 0 10px 0;
                           color:#1f2937;">
                    Salary
                </h3>

                <p style="margin:0;
                          color:#6b7280;
                          line-height:1.5;">
                    Manage employee salary records.
                </p>

            </div>


            <!-- Payslip -->

            <div style="background:white;
                        padding:25px;
                        border-radius:14px;
                        box-shadow:0 4px 15px rgba(0,0,0,0.08);
                        border:1px solid #e5e7eb;
                        transition:transform 0.2s, box-shadow 0.2s;"
                 onmouseover="this.style.transform='translateY(-5px)'; this.style.boxShadow='0 8px 20px rgba(0,0,0,0.12)'"
                 onmouseout="this.style.transform='translateY(0)'; this.style.boxShadow='0 4px 15px rgba(0,0,0,0.08)'">

                <div style="font-size:32px;
                            margin-bottom:15px;">
                    📄
                </div>

                <h3 style="margin:0 0 10px 0;
                           color:#1f2937;">
                    Payslip
                </h3>

                <p style="margin:0;
                          color:#6b7280;
                          line-height:1.5;">
                    Generate and manage employee payslips.
                </p>

            </div>

        </div>


        <!-- Quick Information -->

        <div style="background:white;
                    padding:25px;
                    border-radius:14px;
                    box-shadow:0 4px 15px rgba(0,0,0,0.08);
                    border:1px solid #e5e7eb;
                    margin-top:30px;">

            <h3 style="margin:0 0 10px 0;
                       color:#1f2937;">
                Payroll Management
            </h3>

            <p style="margin:0;
                      color:#6b7280;
                      line-height:1.6;">
                Use the sidebar to access employee management,
                departments, attendance, salary and payslip modules.
            </p>

        </div>

    </div>

</asp:Content>