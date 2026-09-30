<%@ Page Title="My Salary" Language="C#" MasterPageFile="~/Site.master"
    AutoEventWireup="true" CodeBehind="EmployeeSalary.aspx.cs"
    Inherits="EmployeePayrollSystem.EmployeeSalary" %>

<asp:Content ID="Content1"
    ContentPlaceHolderID="MainContent"
    runat="server">

    <div style="padding:30px;">

        <h2 style="margin-bottom:25px;">
            My Salary
        </h2>

        <div style="background:white;
                    padding:25px;
                    border-radius:10px;
                    box-shadow:0 4px 15px rgba(0,0,0,0.08);">

            <h3 style="margin-bottom:20px;">
                My Salary Records
            </h3>

            <div style="overflow-x:auto;">

                <asp:GridView
                    ID="gvSalary"
                    runat="server"
                    AutoGenerateColumns="False"
                    CssClass="table table-bordered table-striped"
                    Width="100%"
                    EmptyDataText="No salary records found.">

                    <Columns>

                        <asp:BoundField
                            DataField="SalaryMonth"
                            HeaderText="Month" />

                        <asp:BoundField
                            DataField="SalaryYear"
                            HeaderText="Year" />

                        <asp:BoundField
                            DataField="BasicSalary"
                            HeaderText="Basic Salary"
                            DataFormatString="{0:0.00}" />

                        <asp:BoundField
                            DataField="HRA"
                            HeaderText="HRA"
                            DataFormatString="{0:0.00}" />

                        <asp:BoundField
                            DataField="Allowance"
                            HeaderText="Allowance"
                            DataFormatString="{0:0.00}" />

                        <asp:BoundField
                            DataField="Bonus"
                            HeaderText="Bonus"
                            DataFormatString="{0:0.00}" />

                        <asp:BoundField
                            DataField="Deduction"
                            HeaderText="Deduction"
                            DataFormatString="{0:0.00}" />

                        <asp:BoundField
                            DataField="NetSalary"
                            HeaderText="Net Salary"
                            DataFormatString="{0:0.00}" />

                    </Columns>

                </asp:GridView>

            </div>

        </div>

    </div>

</asp:Content>