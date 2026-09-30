<%@ Page Title="Login" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="EmployeePayrollSystem.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div style="max-width: 450px; margin: 60px auto;">

        <div style="background: white; padding: 35px; border-radius: 10px; box-shadow: 0 4px 15px rgba(0,0,0,0.1);">

            <h2 style="text-align:center; margin-bottom:30px;">
                Employee Payroll System
            </h2>

            <h4 style="text-align:center; margin-bottom:25px;">
                Login
            </h4>

            <!-- Username -->

            <div style="margin-bottom:20px;">

                <label>Username</label>

                <asp:TextBox
                    ID="txtUsername"
                    runat="server"
                    CssClass="form-control"
                    placeholder="Enter username">
                </asp:TextBox>

            </div>


            <!-- Password -->

            <div style="margin-bottom:20px;">

                <label>Password</label>

                <asp:TextBox
                    ID="txtPassword"
                    runat="server"
                    TextMode="Password"
                    CssClass="form-control"
                    placeholder="Enter password">
                </asp:TextBox>

            </div>


            <!-- Login Button -->

            <div style="text-align:center;">

                <asp:Button
                    ID="btnLogin"
                    runat="server"
                    Text="Login"
                    CssClass="btn btn-dark"
                    OnClick="btnLogin_Click" />

            </div>


            <!-- Message -->

            <div style="text-align:center; margin-top:20px;">

                <asp:Label
                    ID="lblMessage"
                    runat="server"
                    ForeColor="Red">
                </asp:Label>

            </div>

        </div>

    </div>

</asp:Content>