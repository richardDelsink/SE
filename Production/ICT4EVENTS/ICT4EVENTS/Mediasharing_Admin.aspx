<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Mediasharing_Admin.aspx.cs" Inherits="ICT4EVENTS.Mediasharing_Admin" %>

<asp:Content ID="mediasharingAdminContent" ContentPlaceHolderID="MainContent" runat="server">
     <div class="home_container">
       <div class="page-header"><h1>Mediasharing</h1></div>
         
         
         <div class="col-md-4">
             <asp:Label ID="lblcat" runat="server" Text="Categorie" />

             <asp:GridView runat="server" ID="categorylist"></asp:GridView>
         </div>
<div class="col-md-4">
    <asp:Label ID="lblfile" runat="server" Text="Files" />
     <asp:GridView ID="fileslist" runat="server"></asp:GridView>
</div>

<div class="col-md-4">
    <asp:FileUpload ID="FileUpload1" runat="server"></asp:FileUpload>
    <asp:DropDownList ID="categoriecb"  runat="server"></asp:DropDownList>
    <asp:Button ID="btnUp" runat="server" OnClick="btnUpload_OnClick" Text="Upload"/>

</div>
 <div class="row">
<div class="col-md-4">     
<h3>File</h3>     
     
     
     
    </div>
 </div>

    </div>
</asp:Content>
