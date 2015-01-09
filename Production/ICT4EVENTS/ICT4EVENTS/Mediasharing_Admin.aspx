<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Mediasharing_Admin.aspx.cs" Inherits="ICT4EVENTS.Mediasharing_Admin" %>

<asp:Content ID="mediasharingAdminContent" ContentPlaceHolderID="MainContent" runat="server">
     <div class="home_container">
       <div class="page-header"><h1>Mediasharing</h1></div>
         
         
         <div class="col-md-4">
             <asp:Label ID="lblcat" runat="server" Text="Categorie" />

             &nbsp;:<br />
             <asp:DropDownList ID="CategorieList" runat="server"  OnTextChanged="CategorieList_TextChanged" AutoPostBack="true" OnSelectedIndexChanged="CategorieList_SelectedIndexChanged">
             </asp:DropDownList>
         </div>
<div class="col-md-4">
    <asp:Label ID="lblfile" runat="server" Text="Files" />
       <br />
    <asp:ListBox ID="fileslist" runat="server" AutoPostBack="true" Height="254px" Width="311px" OnSelectedIndexChanged="fileslist_SelectedIndexChanged1"></asp:ListBox>

</div>

<div class="col-md-4">
    <asp:FileUpload ID="FileUpload1" runat="server"></asp:FileUpload>
    <asp:DropDownList ID="categoriecb"  runat="server"></asp:DropDownList>
    <asp:Button ID="btnUp" runat="server" OnClick="btnUpload_OnClick" Text="Upload"/>

</div>
         <br />
         <br />


         <div class="col-md-5">
             Comments :<br />
             <br />
             <asp:GridView ID="GridView1" runat="server" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical" Height="218px" Width="427px">
                 <AlternatingRowStyle BackColor="White" />
                 <FooterStyle BackColor="#CCCC99" />
                 <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                 <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                 <RowStyle BackColor="#F7F7DE" />
                 <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                 <SortedAscendingCellStyle BackColor="#FBFBF2" />
                 <SortedAscendingHeaderStyle BackColor="#848384" />
                 <SortedDescendingCellStyle BackColor="#EAEAD3" />
                 <SortedDescendingHeaderStyle BackColor="#575357" />
             </asp:GridView>

</div>

         <br />
         <br />
         <div class="col-md-5">
             Place a Comment :<br />
             <br />
             Titel :
             <asp:TextBox ID="TextBox2" runat="server" Height="18px"></asp:TextBox>
             <br />
             <br />
             <asp:TextBox ID="TextBox1" runat="server" Height="104px" Width="665px"></asp:TextBox>
             <br />
             <br />
             <asp:Button ID="BtnComment" runat="server" OnClick="BtnComment_Click" Text="Place Comment" Width="119px" />
             <br />
             <br />

</div>

    </div>
</asp:Content>
