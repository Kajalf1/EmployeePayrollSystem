<%@ Page Title="My Payslip" Language="C#" MasterPageFile="~/Site.master"
    AutoEventWireup="true" CodeBehind="EmployeePayslip.aspx.cs"
    Inherits="EmployeePayrollSystem.EmployeePayslip" %>

<asp:Content ID="Content1"
    ContentPlaceHolderID="MainContent"
    runat="server">

    <div style="padding:30px;">

        <h2 style="margin-bottom:25px;">
            My Payslip
        </h2>

        <div style="background:white;
                    padding:30px;
                    border-radius:10px;
                    box-shadow:0 4px 15px rgba(0,0,0,0.08);">

            <h3 style="text-align:center;
                       margin-bottom:30px;">
                Employee Payslip
            </h3>

            <div style="text-align:center;
                        margin-bottom:25px;">

                <h2 style="margin-bottom:5px;">
                    Employee Payroll System
                </h2>

                <p style="margin:0;">
                    Salary Payslip
                </p>

            </div>

            <div style="display:grid;
                        grid-template-columns:1fr 1fr;
                        gap:15px;
                        margin-bottom:25px;">

                <div>
                    <strong>Employee Name:</strong>

                    <asp:Label
                        ID="lblEmployeeName"
                        runat="server">
                    </asp:Label>
                </div>

                <div>
                    <strong>Salary Month:</strong>

                    <asp:Label
                        ID="lblSalaryMonth"
                        runat="server">
                    </asp:Label>
                </div>

                <div>
                    <strong>Salary Year:</strong>

                    <asp:Label
                        ID="lblSalaryYear"
                        runat="server">
                    </asp:Label>
                </div>

                <div>
                    <strong>Generated Date:</strong>

                    <asp:Label
                        ID="lblGeneratedDate"
                        runat="server">
                    </asp:Label>
                </div>

            </div>

            <table style="width:100%;
                          border-collapse:collapse;">

                <tr>

                    <th style="border:1px solid #ddd;
                               padding:12px;
                               text-align:left;">
                        Salary Component
                    </th>

                    <th style="border:1px solid #ddd;
                               padding:12px;
                               text-align:right;">
                        Amount
                    </th>

                </tr>

                <tr>

                    <td style="border:1px solid #ddd;
                               padding:12px;">
                        Basic Salary
                    </td>

                    <td style="border:1px solid #ddd;
                               padding:12px;
                               text-align:right;">

                        ₹
                        <asp:Label
                            ID="lblBasicSalary"
                            runat="server">
                        </asp:Label>

                    </td>

                </tr>

                <tr>

                    <td style="border:1px solid #ddd;
                               padding:12px;">
                        HRA
                    </td>

                    <td style="border:1px solid #ddd;
                               padding:12px;
                               text-align:right;">

                        ₹
                        <asp:Label
                            ID="lblHRA"
                            runat="server">
                        </asp:Label>

                    </td>

                </tr>

                <tr>

                    <td style="border:1px solid #ddd;
                               padding:12px;">
                        Allowance
                    </td>

                    <td style="border:1px solid #ddd;
                               padding:12px;
                               text-align:right;">

                        ₹
                        <asp:Label
                            ID="lblAllowance"
                            runat="server">
                        </asp:Label>

                    </td>

                </tr>

                <tr>

                    <td style="border:1px solid #ddd;
                               padding:12px;">
                        Bonus
                    </td>

                    <td style="border:1px solid #ddd;
                               padding:12px;
                               text-align:right;">

                        ₹
                        <asp:Label
                            ID="lblBonus"
                            runat="server">
                        </asp:Label>

                    </td>

                </tr>

                <tr>

                    <td style="border:1px solid #ddd;
                               padding:12px;">
                        Deduction
                    </td>

                    <td style="border:1px solid #ddd;
                               padding:12px;
                               text-align:right;">

                        ₹
                        <asp:Label
                            ID="lblDeduction"
                            runat="server">
                        </asp:Label>

                    </td>

                </tr>

                <tr>

                    <td style="border:1px solid #ddd;
                               padding:12px;
                               font-weight:bold;">
                        Net Salary
                    </td>

                    <td style="border:1px solid #ddd;
                               padding:12px;
                               text-align:right;
                               font-weight:bold;">

                        ₹
                        <asp:Label
                            ID="lblNetSalary"
                            runat="server">
                        </asp:Label>

                    </td>

                </tr>

            </table>

        </div>


        <div style="background:white;
                    padding:25px;
                    border-radius:10px;
                    box-shadow:0 4px 15px rgba(0,0,0,0.08);
                    margin-top:30px;">

            <h3 style="margin-bottom:20px;">
                My Generated Payslips
            </h3>

            <div style="overflow-x:auto;">

                <asp:GridView
                    ID="gvPayslips"
                    runat="server"
                    AutoGenerateColumns="False"
                    CssClass="table table-bordered table-striped"
                    Width="100%"
                    EmptyDataText="No payslips found.">

                    <Columns>

                        <asp:BoundField
                            DataField="SalaryMonth"
                            HeaderText="Month" />

                        <asp:BoundField
                            DataField="SalaryYear"
                            HeaderText="Year" />

                        <asp:BoundField
                            DataField="NetSalary"
                            HeaderText="Net Salary"
                            DataFormatString="{0:0.00}" />

                        <asp:BoundField
                            DataField="GeneratedDate"
                            HeaderText="Generated Date"
                            DataFormatString="{0:dd-MM-yyyy HH:mm}" />

                    </Columns>

                </asp:GridView>

            </div>

        </div>

    </div>

</asp:Content>