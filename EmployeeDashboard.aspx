<%@ Page Title="Employee Dashboard" Language="C#" MasterPageFile="~/Site.master"
    AutoEventWireup="true" CodeBehind="EmployeeDashboard.aspx.cs"
    Inherits="EmployeePayrollSystem.EmployeeDashboard" %>

<asp:Content ID="Content1"
    ContentPlaceHolderID="MainContent"
    runat="server">

    <div style="padding:30px;">

        <!-- Page Header -->

        <div style="margin-bottom:25px;">

            <h2 style="margin:0;
                       color:#1f2937;
                       font-size:30px;">
                Employee Dashboard
            </h2>

            <p style="margin-top:8px;
                      color:#6b7280;
                      font-size:15px;">
                View your personal and employment information
            </p>

        </div>


        <!-- Employee Profile Card -->

        <div style="background:linear-gradient(135deg,#1f2937,#374151);
                    color:white;
                    padding:30px;
                    border-radius:14px;
                    box-shadow:0 5px 18px rgba(0,0,0,0.12);
                    margin-bottom:25px;">

            <div style="display:flex;
                        align-items:center;
                        gap:20px;">

                <div style="width:65px;
                            height:65px;
                            background:#ffffff;
                            color:#1f2937;
                            border-radius:50%;
                            display:flex;
                            align-items:center;
                            justify-content:center;
                            font-size:27px;
                            font-weight:bold;">

                    👤

                </div>

                <div>

                    <div style="font-size:14px;
                                opacity:0.8;
                                margin-bottom:5px;">
                        Welcome
                    </div>

                    <div style="font-size:27px;
                                font-weight:bold;">

                        <asp:Label
                            ID="lblEmployeeName"
                            runat="server">
                        </asp:Label>

                    </div>

                    <div style="font-size:14px;
                                opacity:0.85;
                                margin-top:5px;">

                        <asp:Label
                            ID="lblDesignation"
                            runat="server">
                        </asp:Label>

                    </div>

                </div>

            </div>

        </div>


        <!-- My Information -->

        <div style="background:white;
                    padding:30px;
                    border-radius:14px;
                    box-shadow:0 4px 15px rgba(0,0,0,0.08);">

            <div style="margin-bottom:25px;">

                <h3 style="margin:0;
                           color:#1f2937;">
                    My Information
                </h3>

                <p style="margin-top:7px;
                          color:#6b7280;
                          font-size:14px;">
                    Your current employee details
                </p>

            </div>


            <!-- Information Grid -->

            <div style="display:grid;
                        grid-template-columns:1fr 1fr;
                        gap:20px;">


                <!-- Email -->

                <div style="border:1px solid #e5e7eb;
                            border-radius:10px;
                            padding:18px;">

                    <div style="color:#6b7280;
                                font-size:13px;
                                margin-bottom:7px;">
                        Email
                    </div>

                    <div style="font-size:16px;
                                font-weight:600;
                                color:#1f2937;">

                        <asp:Label
                            ID="lblEmail"
                            runat="server">
                        </asp:Label>

                    </div>

                </div>


                <!-- Phone -->

                <div style="border:1px solid #e5e7eb;
                            border-radius:10px;
                            padding:18px;">

                    <div style="color:#6b7280;
                                font-size:13px;
                                margin-bottom:7px;">
                        Phone
                    </div>

                    <div style="font-size:16px;
                                font-weight:600;
                                color:#1f2937;">

                        <asp:Label
                            ID="lblPhone"
                            runat="server">
                        </asp:Label>

                    </div>

                </div>


                <!-- Department -->

                <div style="border:1px solid #e5e7eb;
                            border-radius:10px;
                            padding:18px;">

                    <div style="color:#6b7280;
                                font-size:13px;
                                margin-bottom:7px;">
                        Department
                    </div>

                    <div style="font-size:16px;
                                font-weight:600;
                                color:#1f2937;">

                        <asp:Label
                            ID="lblDepartment"
                            runat="server">
                        </asp:Label>

                    </div>

                </div>


                <!-- Designation -->

                <div style="border:1px solid #e5e7eb;
                            border-radius:10px;
                            padding:18px;">

                    <div style="color:#6b7280;
                                font-size:13px;
                                margin-bottom:7px;">
                        Designation
                    </div>

                    <div style="font-size:16px;
                                font-weight:600;
                                color:#1f2937;">

                        <asp:Label
                            ID="Label1"
                            runat="server">
                        </asp:Label>

                    </div>

                </div>


                <!-- Joining Date -->

                <div style="border:1px solid #e5e7eb;
                            border-radius:10px;
                            padding:18px;">

                    <div style="color:#6b7280;
                                font-size:13px;
                                margin-bottom:7px;">
                        Joining Date
                    </div>

                    <div style="font-size:16px;
                                font-weight:600;
                                color:#1f2937;">

                        <asp:Label
                            ID="lblJoiningDate"
                            runat="server">
                        </asp:Label>

                    </div>

                </div>


                <!-- Basic Salary -->

                <div style="border:1px solid #e5e7eb;
                            border-radius:10px;
                            padding:18px;">

                    <div style="color:#6b7280;
                                font-size:13px;
                                margin-bottom:7px;">
                        Basic Salary
                    </div>

                    <div style="font-size:20px;
                                font-weight:bold;
                                color:#1f2937;">

                        ₹
                        <asp:Label
                            ID="lblBasicSalary"
                            runat="server">
                        </asp:Label>

                    </div>

                </div>


                <!-- Status -->

                <div style="border:1px solid #e5e7eb;
                            border-radius:10px;
                            padding:18px;">

                    <div style="color:#6b7280;
                                font-size:13px;
                                margin-bottom:7px;">
                        Employment Status
                    </div>

                    <div style="display:inline-block;
                                background:#dcfce7;
                                color:#166534;
                                padding:6px 14px;
                                border-radius:20px;
                                font-size:14px;
                                font-weight:600;">

                        <asp:Label
                            ID="lblStatus"
                            runat="server">
                        </asp:Label>

                    </div>

                </div>


                <!-- Employee Name -->

                <div style="border:1px solid #e5e7eb;
                            border-radius:10px;
                            padding:18px;">

                    <div style="color:#6b7280;
                                font-size:13px;
                                margin-bottom:7px;">
                        Employee Name
                    </div>

                    <div style="font-size:16px;
                                font-weight:600;
                                color:#1f2937;">

                        <asp:Label
                            ID="lblEmployeeName2"
                            runat="server">
                        </asp:Label>

                    </div>

                </div>

            </div>

        </div>

    </div>

</asp:Content>