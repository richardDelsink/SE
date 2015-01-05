<<<<<<< HEAD
﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ICT4EVENTS.Login" %>

<!DOCTYPE html>




<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">


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
                <asp:TextBox ID="tbPassword" runat="server" Class="input" placeholder="Password"></asp:TextBox>
                <asp:Button ID="btnLogin" CssClass="button" Text="Submit" runat="server"></asp:Button>
            </div>
            <div class="signup">
                <h1>Register</h1>
                <asp:TextBox ID="tbEmail" runat="server" Class="input" placeholder="Email"></asp:TextBox>
                <asp:TextBox ID="tbUsernameSU" runat="server" Class="input" placeholder="Username"></asp:TextBox>
                <asp:TextBox ID="tbPassword1" runat="server" Class="input" placeholder="Password"></asp:TextBox>
                <asp:TextBox ID="tbPassword2" runat="server" Class="input" placeholder="Confirm Password"></asp:TextBox>
                <asp:Button ID="btnSignup" runat="server" Class="button" Text="Sign up" />
            </div>
        </div>

        <div id="block" class="block"></div>
        <div id="block1" class="block1"></div>
    </form>
</body>
</html>
=======
﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ICT4EVENTS.Login" %>

<!DOCTYPE html>

    


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    
    
    <title>Login</title>
    
     <link href="~/Content/normalizer.css" rel="stylesheet"/>
    <link href="~/Content/login_PT.css" rel="stylesheet"/>

</head>

<body>     
	     <form id="sign" class="signin" runat="server">
    	    <h1>Login</h1>
	         <input type="email" placeholder="hahhahaha@email.com" required=""/>
	         <input type="password" placeholder="Choose your password" required=""/>                 
    	    <asp:button id="b1" CssClass="button" Text="Submit" runat="server"></asp:button>
           </form>

	<div id="block" class="block"></div>
	<div id="block1" class="block1"></div>

    <form id="Form1" class="signup">
             
    	        <h1>Register</h1>
	            <input type="email" placeholder="hahhahaha@email.com" required=""/>
	            <input type="username" placeholder="Username" required=""/>
	            <input type="password" placeholder="Choose your password" required=""/>
	            <input type="password" placeholder="Confirm password" required=""/>   
                <button type="button" class="button">Register</button>   
                          
	</form>	

    
</body>
</html>
>>>>>>> origin/master
