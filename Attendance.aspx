<%@ Page Title="Attendance" Language="C#" MasterPageFile="~/Site.master"
    AutoEventWireup="true" CodeBehind="Attendance.aspx.cs"
    Inherits="EmployeePayrollSystem.Attendance" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div style="padding: 30px;">

        <h2 style="margin-bottom: 25px;">Attendance</h2>

        <div style="background:white; padding:25px; border-radius:10px;
                    box-shadow:0 4px 15px rgba(0,0,0,0.08);">

            <h3 style="margin-bottom:20px;">Mark Attendance</h3>

            <div style="display:grid; grid-template-columns:1fr 1fr 1fr; gap:20px;">

                <div>
                    <label>Employee</label>

                    <asp:DropDownList
                        ID="ddlEmployee"
                        runat="server"
                        CssClass="form-control">
                    </asp:DropDownList>
                </div>

                <div>
                    <label>Attendance Date</label>

                    <asp:TextBox
                        ID="txtAttendanceDate"
                        runat="server"
                        TextMode="Date"
                        CssClass="form-control">
                    </asp:TextBox>
                </div>

                <div>
                    <label>Attendance Status</label>

                    <asp:DropDownList
                        ID="ddlAttendanceStatus"
                        runat="server"
                        CssClass="form-control">

                        <asp:ListItem
                            Text="Present"
                            Value="Present" />

                        <asp:ListItem
                            Text="Absent"
                            Value="Absent" />

                    </asp:DropDownList>
                </div>

            </div>

            <div style="margin-top:25px;">

                <asp:Button
                    ID="btnMarkAttendance"
                    runat="server"
                    Text="Mark Attendance"
                    CssClass="btn btn-dark"
                    OnClick="btnMarkAttendance_Click" />

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

            <h3 style="margin-bottom:20px;">Attendance Records</h3>

            <div style="overflow-x:auto;">

                <asp:GridView
                    ID="gvAttendance"
                    runat="server"
                    AutoGenerateColumns="False"
                    CssClass="table table-bordered table-striped"
                    Width="100%"
                    EmptyDataText="No attendance records found.">

                    <Columns>

                        <asp:BoundField
                            DataField="AttendanceID"
                            HeaderText="ID" />

                        <asp:BoundField
                            DataField="EmployeeName"
                            HeaderText="Employee Name" />

                        <asp:BoundField
                            DataField="AttendanceDate"
                            HeaderText="Date"
                            DataFormatString="{0:dd-MM-yyyy}" />

                        <asp:BoundField
                            DataField="AttendanceStatus"
                            HeaderText="Status" />

                    </Columns>

                </asp:GridView>

            </div>

        </div>

    </div>

</asp:Content>