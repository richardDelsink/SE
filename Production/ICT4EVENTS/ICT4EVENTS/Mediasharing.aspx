<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Mediasharing.aspx.cs" Inherits="ICT4EVENTS.About" %>

<asp:Content ID="mediasharingContent" ContentPlaceHolderID="MainContent" runat="server">
   <div class="home_container" style="height: 542px">
        <div class="jumbotron">
   
            <ul class="nav nav-tabs">
  <li role="presentation" class="active"><a href="#">Personal Info</a></li>
  <li role="presentation"><a href="#">Media</a></li>
            </ul>
<asp:ListBox CssClass="list-group" id="ownmedialist" OnSelectedIndexChanged="ownmedialist_OnSelectedIndexChanged" runat="server">
<asp:ListItem selected="true">Item 1</asp:ListItem>
</asp:ListBox>
            

    </div>
    
    </div>
</asp:Content>
