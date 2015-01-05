<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ICT4EVENTS.Login" %>

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
