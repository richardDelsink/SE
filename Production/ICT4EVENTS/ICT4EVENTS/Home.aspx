﻿<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="ICT4EVENTS._Default" %>

<asp:Content ID="homeContent" ContentPlaceHolderID="MainContent" runat="server">
<div class="home_container">
    <div class="jumbotron">
        <h1>ASPNET.</h1>
        
        
        
        <div id ="homepagecontent">
             <div class="Reservering" align="center"> 
            <h3><b>Informatie Reservering</b></h3>
            <asp:GridView ID="ReservationGridView" runat="server" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical" Font-Names="Calibri" Font-Size="16px">
                <AlternatingRowStyle BackColor="#CCCCCC" />
                <FooterStyle BackColor="#CCCCCC" />
                <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                <SortedAscendingHeaderStyle BackColor="#808080" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#383838" />
            </asp:GridView>
                  </div>
            <br />
         
              <div class="Materialen">   <h3><b>Gereserveerde materialen</b> </h3>
            <asp:GridView ID="reservedItemgrid" runat="server" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical" Font-Names="Calibri" Font-Size="16px">
                <AlternatingRowStyle BackColor="White" />
                <FooterStyle BackColor="#808080" />
                <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                <RowStyle BackColor="White" />
                <SelectedRowStyle BackColor="White" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="White" />
                <SortedAscendingHeaderStyle BackColor="White" />
                <SortedDescendingCellStyle BackColor="White" />
                <SortedDescendingHeaderStyle BackColor="White" />
            </asp:GridView>
                  </div>
              
      </div>
    </div>
</div>
</asp:Content>
