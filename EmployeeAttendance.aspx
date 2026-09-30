<%@ Page Title="My Attendance" Language="C#" MasterPageFile="~/Site.master"
    AutoEventWireup="true" CodeBehind="EmployeeAttendance.aspx.cs"
    Inherits="EmployeePayrollSystem.EmployeeAttendance" %>

<asp:Content ID="Content1"
    ContentPlaceHolderID="MainContent"
    runat="server">

    <div style="padding:30px;">

        <h2 style="margin-bottom:25px;">
            My Attendance
        </h2>

        <div style="background:white;
                    padding:25px;
                    border-radius:10px;
                    box-shadow:0 4px 15px rgba(0,0,0,0.08);">

            <h3 style="margin-bottom:20px;">
                Attendance Records
            </h3>

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