<%@ Page Title="Employees" Language="C#" MasterPageFile="~/Site.master"
    AutoEventWireup="true" CodeBehind="Employees.aspx.cs"
    Inherits="EmployeePayrollSystem.Employees" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div style="padding: 30px;">

        <h2 style="margin-bottom: 25px;">Employees</h2>

        <div style="background:white; padding:25px; border-radius:10px;
                    box-shadow:0 4px 15px rgba(0,0,0,0.08);">

            <h3 style="margin-bottom:20px;">

                <asp:Label
                    ID="lblFormTitle"
                    runat="server"
                    Text="Add Employee">
                </asp:Label>

            </h3>


            <div style="display:grid; grid-template-columns:1fr 1fr; gap:20px;">

                <div>
                    <label>Employee Name</label>

                    <asp:TextBox
                        ID="txtEmployeeName"
                        runat="server"
                        CssClass="form-control"
                        placeholder="Enter employee name">
                    </asp:TextBox>
                </div>


                <div>
                    <label>Email<asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmail" ErrorMessage="Please enter valid email" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                    </label>
&nbsp;<asp:TextBox
                        ID="txtEmail"
                        runat="server"
                        CssClass="form-control"
                        placeholder="Enter email">
                    </asp:TextBox>
                </div>


                <div>
                    <label>Phone<asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtPhone" ErrorMessage="Please enter valid phone number" ForeColor="Red" ValidationExpression="^[6-9][0-9]{9}$"></asp:RegularExpressionValidator>
                    </label>

                    &nbsp;<asp:TextBox
                        ID="txtPhone"
                        runat="server"
                        CssClass="form-control"
                        placeholder="Enter phone number">
                    </asp:TextBox>
                </div>


                <div>
                    <label>Department</label>

                    <asp:DropDownList
                        ID="ddlDepartment"
                        runat="server"
                        CssClass="form-control">
                    </asp:DropDownList>
                </div>


                <div>
                    <label>Designation</label>

                    <asp:TextBox
                        ID="txtDesignation"
                        runat="server"
                        CssClass="form-control"
                        placeholder="Enter designation">
                    </asp:TextBox>
                </div>


                <div>
                    <label>Joining Date</label>

                    <asp:TextBox
                        ID="txtJoiningDate"
                        runat="server"
                        TextMode="Date"
                        CssClass="form-control">
                    </asp:TextBox>
                </div>


                <div>
                    <label>Basic Salar</label>

                    <asp:TextBox
                        ID="txtBasicSalary"
                        runat="server"
                        CssClass="form-control"
                        placeholder="Enter basic salary">
                    </asp:TextBox>
                </div>


                <div>
                    <label>Status</label>

                    <asp:DropDownList
                        ID="ddlStatus"
                        runat="server"
                        CssClass="form-control">

                        <asp:ListItem
                            Text="Active"
                            Value="Active" />

                        <asp:ListItem
                            Text="Inactive"
                            Value="Inactive" />

                    </asp:DropDownList>
                </div>

            </div>


            <div style="margin-top:20px;">

                <label>Address</label>

                <asp:TextBox
                    ID="txtAddress"
                    runat="server"
                    TextMode="MultiLine"
                    Rows="3"
                    CssClass="form-control"
                    placeholder="Enter address">
                </asp:TextBox>

            </div>


            <div style="margin-top:25px;">

                <asp:Button
                    ID="btnAddEmployee"
                    runat="server"
                    Text="Add Employee"
                    CssClass="btn btn-dark"
                    OnClick="btnAddEmployee_Click" />


                <asp:Button
                    ID="btnUpdateEmployee"
                    runat="server"
                    Text="Update Employee"
                    CssClass="btn btn-dark"
                    OnClick="btnUpdateEmployee_Click"
                    Visible="false"
                    style="margin-left:10px;" />


                <asp:Button
                    ID="btnCancelEdit"
                    runat="server"
                    Text="Cancel"
                    CssClass="btn btn-secondary"
                    OnClick="btnCancelEdit_Click"
                    Visible="false"
                    style="margin-left:10px;" />


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

            <h3 style="margin-bottom:20px;">Employee List</h3>


            <div style="overflow-x:auto;">

                <asp:GridView
                    ID="gvEmployees"
                    runat="server"
                    AutoGenerateColumns="False"
                    OnRowCommand="gvEmployees_RowCommand"
                    CssClass="table table-bordered table-striped"
                    Width="100%"
                    EmptyDataText="No employees found.">

                    <Columns>

                        <asp:BoundField
                            DataField="EmployeeID"
                            HeaderText="ID" />

                        <asp:BoundField
                            DataField="EmployeeName"
                            HeaderText="Name" />

                        <asp:BoundField
                            DataField="Email"
                            HeaderText="Email" />

                        <asp:BoundField
                            DataField="Phone"
                            HeaderText="Phone" />

                        <asp:BoundField
                            DataField="DepartmentName"
                            HeaderText="Department" />

                        <asp:BoundField
                            DataField="Designation"
                            HeaderText="Designation" />

                        <asp:BoundField
                            DataField="JoiningDate"
                            HeaderText="Joining Date"
                            DataFormatString="{0:dd-MM-yyyy}" />

                        <asp:BoundField
                            DataField="BasicSalary"
                            HeaderText="Basic Salary"
                            DataFormatString="{0:0.00}" />

                        <asp:BoundField
                            DataField="Status"
                            HeaderText="Status" />

                        <asp:TemplateField HeaderText="Action">

                            <ItemTemplate>

                                <asp:Button
                                    ID="btnEdit"
                                    runat="server"
                                    Text="Edit"
                                    CommandName="EditEmployee"
                                    CommandArgument='<%# Eval("EmployeeID") %>'
                                    CssClass="btn btn-primary"
                                    style="margin-right:5px;" />

                                <asp:Button
                                    ID="btnDelete"
                                    runat="server"
                                    Text="Delete"
                                    CommandName="DeleteEmployee"
                                    CommandArgument='<%# Eval("EmployeeID") %>'
                                    CssClass="btn btn-danger"
                                    OnClientClick="return confirm('Are you sure you want to delete this employee?');" />

                            </ItemTemplate>

                        </asp:TemplateField>

                    </Columns>

                </asp:GridView>

            </div>

        </div>

    </div>

</asp:Content>