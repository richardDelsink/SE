﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ICT4EVENTS.Login" %>

<!DOCTYPE html>




<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">


    <title>Login</title>

    <link href="~/Content/normalizer.css" rel="stylesheet" />
    <link href="~/Content/login_PT.css" rel="stylesheet" />

</head>

<body>
    <form id="sign" runat="server">
        <div>
            <div class="signin">
                <h1>Login</h1>
                <asp:TextBox ID="tbUsername" runat="server" Class="input" placeholder="Username"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvcandidate" runat="server" CssClass="validator" ForeColor="Red" ValidationGroup="LoginGroup" ControlToValidate="tbUsername" ErrorMessage="Please fill in username" InitialValue="">
                </asp:RequiredFieldValidator>
                <asp:TextBox ID="tbPassword" runat="server" Class="input" placeholder="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" CssClass="validator" ForeColor="Red" runat="server" ValidationGroup="LoginGroup" ControlToValidate="tbPassword" ErrorMessage="Please fill in password" InitialValue="">
                </asp:RequiredFieldValidator>
                <asp:Label ID="lblLoginError" runat="server" Visible="false" CssClass="validator" Text="Wrong Username/Password" ForeColor="Red"></asp:Label>
                <div class="alibaba" style="float: left">
                    <asp:CheckBox ID="chkBox" runat="server" CssClass="checkbox" Width="20%" Text="Remember me?" ForeColor="Gray" />
                </div>
                <asp:Label ID="lblLogin" runat="server" Visible="false" Text="Wrong Username/Password" ForeColor="Red"></asp:Label>
                <asp:Button ID="btnLogin" CssClass="button" Text="Submit" ValidationGroup="LoginGroup" runat="server" OnClick="btnLogin_Click"></asp:Button>
            </div>
            <div class="signup">
                <h1>Register</h1>
                <asp:TextBox ID="tbFirstName" runat="server" Class="input" placeholder="Firstname"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ForeColor="Red" CssClass="validator" runat="server" ValidationGroup="SignupGroup" ControlToValidate="tbFirstname" ErrorMessage="Please fill in username" InitialValue="">
                </asp:RequiredFieldValidator>
                <asp:TextBox ID="tbLastName" runat="server" Class="input" placeholder="Lastname"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ForeColor="Red" CssClass="validator" runat="server" ValidationGroup="SignupGroup" ControlToValidate="tbLastname" ErrorMessage="Please fill in lastname" InitialValue="">
                </asp:RequiredFieldValidator>
                <asp:TextBox ID="tbEmail" runat="server" Class="input" placeholder="Email"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ForeColor="Red" CssClass="validator" runat="server" ValidationGroup="SignupGroup" ControlToValidate="tbEmail" ErrorMessage="Please fill in email" InitialValue="">
                </asp:RequiredFieldValidator>
                <asp:TextBox ID="tbUsernameSU" runat="server" Class="input" placeholder="Username"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ForeColor="Red" CssClass="validator" runat="server" ValidationGroup="SignupGroup" ControlToValidate="tbUsernameSU" ErrorMessage="Please fill in username" InitialValue="">
                </asp:RequiredFieldValidator>
                <asp:Label ID="lblUsernameError" runat="server" Visible="false" CssClass="validator" Text="Username already exists" ForeColor="Red"></asp:Label>
                <asp:TextBox ID="tbPassword1" runat="server" Class="input" placeholder="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ForeColor="Red" CssClass="validator" runat="server" ValidationGroup="SignupGroup" ControlToValidate="tbPassword1" ErrorMessage="Please fill in password" InitialValue="">
                </asp:RequiredFieldValidator>
                <asp:TextBox ID="tbPassword2" runat="server" Class="input" placeholder="Confirm Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" ForeColor="Red" CssClass="validator" runat="server" ValidationGroup="SignupGroup" ControlToValidate="tbPassword2" ErrorMessage="Please fill in password" InitialValue="">
                </asp:RequiredFieldValidator>
                <asp:Button ID="btnSignup" runat="server" Class="button" ValidationGroup="SignupGroup" Text="Sign up" OnClick="btnSignup_Click" />
            </div>
        </div>

        <div id="block" class="block"></div>
        <div id="block1" class="block1"></div>
    </form>
</body>
</html>
