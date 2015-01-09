<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Mediasharing_Admin.aspx.cs" Inherits="ICT4EVENTS.Mediasharing_Admin" %>

<asp:Content ID="mediasharingAdminContent" ContentPlaceHolderID="MainContent" runat="server">
     <div class="home_container">
       <div class="page-header"><h1>Mediasharing</h1></div>
         
         
         <div class="col-md-4">
             <asp:Label ID="lblcat" runat="server" Text="Categorie" />

             &nbsp;:<br />
             <asp:DropDownList ID="CategorieList" runat="server"  OnTextChanged="CategorieList_TextChanged" AutoPostBack="true">
             </asp:DropDownList>
         </div>
<div class="col-md-4">
    <asp:Label ID="lblfile" runat="server" Text="Files" />
       <br />
    <asp:ListBox ID="fileslist" runat="server" Height="92px" Width="117px"></asp:ListBox>

</div>

<div class="col-md-4">
    <asp:FileUpload ID="FileUpload1" runat="server"></asp:FileUpload>
    <asp:DropDownList ID="categoriecb"  runat="server"></asp:DropDownList>
    <asp:Button ID="btnUp" runat="server" OnClick="btnUpload_OnClick" Text="Upload"/>

</div>

    </div>
</asp:Content>
