<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="ICT4EVENTS._Default" %>

<asp:Content ID="homeContent" ContentPlaceHolderID="MainContent" runat="server">
<div class="home_container">
    <div class="jumbotron">
        <h1>ASPNET.</h1>
        
        
        
        <div id ="homepagecontent">
            <asp:ListBox ID="ReserverationInfoListBox" runat="server" Height="157px" Width="991px"></asp:ListBox>

        </div>
        <p class="lead">ASP.NET is a free web framework for building great Web sites and Web applications using HTML, CSS, and JavaScript.</p>
        <p><a href="http://www.asp.net" class="btn btn-primary btn-large">Learn more &raquo;</a></p>
    </div>
</div>
</asp:Content>
