<%@ Page Title="Salary" Language="C#" MasterPageFile="~/Site.master"
    AutoEventWireup="true" CodeBehind="Salary.aspx.cs"
    Inherits="EmployeePayrollSystem.Salary" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div style="padding:30px;">

        <h2 style="margin-bottom:25px;">Salary</h2>

        <div style="background:white; padding:25px; border-radius:10px;
                    box-shadow:0 4px 15px rgba(0,0,0,0.08);">

            <h3 style="margin-bottom:20px;">Generate Salary</h3>

            <div style="display:grid; grid-template-columns:1fr 1fr; gap:20px;">

                <div>
                    <label>Employee</label>

                    <asp:DropDownList
                        ID="ddlEmployee"
                        runat="server"
                        CssClass="form-control">
                    </asp:DropDownList>
                </div>

                <div>
                    <label>Salary Month</label>

                    <asp:DropDownList
                        ID="ddlMonth"
                        runat="server"
                        CssClass="form-control">

                        <asp:ListItem Text="January" Value="1" />
                        <asp:ListItem Text="February" Value="2" />
                        <asp:ListItem Text="March" Value="3" />
                        <asp:ListItem Text="April" Value="4" />
                        <asp:ListItem Text="May" Value="5" />
                        <asp:ListItem Text="June" Value="6" />
                        <asp:ListItem Text="July" Value="7" />
                        <asp:ListItem Text="August" Value="8" />
                        <asp:ListItem Text="September" Value="9" />
                        <asp:ListItem Text="October" Value="10" />
                        <asp:ListItem Text="November" Value="11" />
                        <asp:ListItem Text="December" Value="12" />

                    </asp:DropDownList>
                </div>

                <div>
                    <label>Salary Year</label>

                    <asp:TextBox
                        ID="txtYear"
                        runat="server"
                        CssClass="form-control"
                        TextMode="Number"
                        placeholder="Enter year">
                    </asp:TextBox>
                </div>

                <div>
                    <label>Basic Salary</label>

                    <asp:TextBox
                        ID="txtBasicSalary"
                        runat="server"
                        CssClass="form-control"
                        TextMode="Number"
                        placeholder="Enter basic salary">
                    </asp:TextBox>
                </div>

                <div>
                    <label>HRA</label>

                    <asp:TextBox
                        ID="txtHRA"
                        runat="server"
                        CssClass="form-control"
                        TextMode="Number"
                        placeholder="Enter HRA">
                    </asp:TextBox>
                </div>

                <div>
                    <label>Allowance</label>

                    <asp:TextBox
                        ID="txtAllowance"
                        runat="server"
                        CssClass="form-control"
                        TextMode="Number"
                        placeholder="Enter allowance">
                    </asp:TextBox>
                </div>

                <div>
                    <label>Bonus</label>

                    <asp:TextBox
                        ID="txtBonus"
                        runat="server"
                        CssClass="form-control"
                        TextMode="Number"
                        placeholder="Enter bonus">
                    </asp:TextBox>
                </div>

                <div>
                    <label>Deduction</label>

                    <asp:TextBox
                        ID="txtDeduction"
                        runat="server"
                        CssClass="form-control"
                        TextMode="Number"
                        placeholder="Enter deduction">
                    </asp:TextBox>
                </div>

            </div>

            <div style="margin-top:25px;">

                <asp:Button
                    ID="btnGenerateSalary"
                    runat="server"
                    Text="Generate Salary"
                    CssClass="btn btn-dark"
                    OnClick="btnGenerateSalary_Click" />

                <asp:Label
                    ID="lblMessage"
                    runat="server"
                    style="margin-left:15px;">
                </asp:Label>

            </div>

        </div>


        <div style="background:white; padding:25px; border-radius:10px;
                    box-shadow:0 4px 15px rgba(0,0,0,0.08);
                    margin-top:30px;">

            <h3 style="margin-bottom:20px;">Salary Records</h3>

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
                            DataField="SalaryID"
                            HeaderText="ID" />

                        <asp:BoundField
                            DataField="EmployeeName"
                            HeaderText="Employee Name" />

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