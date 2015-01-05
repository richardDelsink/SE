<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Mediasharing.aspx.cs" Inherits="ICT4EVENTS.About" %>

<asp:Content ID="mediasharingContent" ContentPlaceHolderID="MainContent" runat="server">
   <div class="home_container" style="height: 542px">
        <%--<div class="jumbotron">--%>
   
            <ul class="nav nav-tabs">
  <li role="presentation" class="active"><a href="#">Personal Info</a></li>
  <li role="presentation"><a href="#">Media</a></li>
            </ul>
       <div class="container">
            <div class="row">

<%--  <div class="col-md-4">.col-md-4</div>--%>

<div class="col-md-4"><asp:DataGrid CssClass="list-group" id="ownmedialist" OnSelectedIndexChanged="ownmedialist_OnSelectedIndexChanged" runat="server"></asp:DataGrid></div>        
<div class="col-md-4">
    <asp:Label ID="Label1" runat="server" Text="Filename: "></asp:Label>
    <asp:Label ID="Label2" runat="server" Text="Filesize: "></asp:Label>
    <asp:Label ID="Label3" runat="server" Text="Category"></asp:Label>
    <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl=""/>
    <asp:TextBox ID="TextBox1" CssClass="input" runat="server"></asp:TextBox> 

</div>
<div class="col-md-4">
    <asp:FileUpload ID="FileUpload1" runat="server"></asp:FileUpload>
    <asp:DropDownList ID="categoriecb" OnSelectedIndexChanged="categoriecb_OnSelectedIndexChanged" runat="server"></asp:DropDownList>
    <asp:Button ID="btnUp" runat="server" OnClick="btnUpload_OnClick" Text="Upload"/>
</div>

    
    </div>
    </div>
    </div>
</asp:Content>
