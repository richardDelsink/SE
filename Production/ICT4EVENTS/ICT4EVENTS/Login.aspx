<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ICT4EVENTS.Login" %>

<!DOCTYPE html>

    <webopt:bundlereference runat="server" path="~/Content/reset.css" />
    <webopt:bundlereference runat="server" path="~/Content/login.css" />

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    
    <title>Login</title>
</head>
<body>
    
      
	     <form id="signin">
    	    <h1>Login</h1>
    	    <input type="email" placeholder="hahhahaha@email.com" required="">
    	    <input type="password" placeholder="Choose your password" required="">                 
    	    <button type="submit">Login</button>    
	    </form>
	<div id="block"></div>
	<div id="block1"></div>
	<form id="signup">
    	<h1>Register</h1>
    	<input type="email" placeholder="hahhahaha@email.com" required="">
    	<input type="username" placeholder="Username" required="">
    	<input type="password" placeholder="Choose your password" required="">
    	<input type="password" placeholder="Confirm password" required="">                  
    	<button type="submit">Register</button>    
	</form>	

    
</body>
</html>
