<%@ Page Title="Departments" Language="C#" MasterPageFile="~/Site.master"
    AutoEventWireup="true" CodeBehind="Departments.aspx.cs"
    Inherits="EmployeePayrollSystem.Departments" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div style="padding: 30px;">

        <h2 style="margin-bottom: 25px;">Departments</h2>

        <div style="background:white; padding:25px; border-radius:10px;
                    box-shadow:0 4px 15px rgba(0,0,0,0.08);">

            <h3 style="margin-bottom:20px;">

                <asp:Label
                    ID="lblFormTitle"
                    runat="server"
                    Text="Add Department">
                </asp:Label>

            </h3>

            <div style="display:grid; grid-template-columns:1fr; gap:20px;">

                <div>
                    <label>Department Name</label>

                    <asp:TextBox
                        ID="txtDepartmentName"
                        runat="server"
                        CssClass="form-control"
                        placeholder="Enter department name">
                    </asp:TextBox>
                </div>

            </div>

            <div style="margin-top:25px;">

                <asp:Button
                    ID="btnAddDepartment"
                    runat="server"
                    Text="Add Department"
                    CssClass="btn btn-dark"
                    OnClick="btnAddDepartment_Click" />

                <asp:Button
                    ID="btnUpdateDepartment"
                    runat="server"
                    Text="Update Department"
                    CssClass="btn btn-dark"
                    OnClick="btnUpdateDepartment_Click"
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

            <h3 style="margin-bottom:20px;">Department List</h3>

            <div style="overflow-x:auto;">

                <asp:GridView
                    ID="gvDepartments"
                    runat="server"
                    AutoGenerateColumns="False"
                    OnRowCommand="gvDepartments_RowCommand"
                    CssClass="table table-bordered table-striped"
                    Width="100%"
                    EmptyDataText="No departments found.">

                    <Columns>

                        <asp:BoundField
                            DataField="DepartmentID"
                            HeaderText="ID" />

                        <asp:BoundField
                            DataField="DepartmentName"
                            HeaderText="Department Name" />

                        <asp:TemplateField HeaderText="Action">

                            <ItemTemplate>

                                <asp:Button
                                    ID="btnEdit"
                                    runat="server"
                                    Text="Edit"
                                    CommandName="EditDepartment"
                                    CommandArgument='<%# Eval("DepartmentID") %>'
                                    CssClass="btn btn-primary"
                                    style="margin-right:5px;" />

                                <asp:Button
                                    ID="btnDelete"
                                    runat="server"
                                    Text="Delete"
                                    CommandName="DeleteDepartment"
                                    CommandArgument='<%# Eval("DepartmentID") %>'
                                    CssClass="btn btn-danger"
                                    OnClientClick="return confirm('Are you sure you want to delete this department?');" />

                            </ItemTemplate>

                        </asp:TemplateField>

                    </Columns>

                </asp:GridView>

            </div>

        </div>

    </div>

</asp:Content>