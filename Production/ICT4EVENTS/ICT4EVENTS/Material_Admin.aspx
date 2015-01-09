<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Material_Admin.aspx.cs" Inherits="ICT4EVENTS.Material_Admin" %>

<asp:Content ID="materialAdminContent" ContentPlaceHolderID="MainContent" runat="server">
     <div class="home_container">
        <div class="jumbotron">
            
            <div class="Calendar123" align="center">
                <h1>Gereserveerde Materialen</h1>
                <Br />
            <asp:Calendar ID="Calendar1" runat="server" BackColor="White" BorderColor="Black" BorderStyle="Solid" CellSpacing="1" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" Height="250px" NextPrevFormat="ShortMonth" Width="330px" SelectedDate="2013-12-27">
                <DayHeaderStyle Font-Bold="True" Font-Size="8pt" ForeColor="#333333" Height="8pt" />
                <DayStyle BackColor="#CCCCCC" />
                <NextPrevStyle Font-Bold="True" Font-Size="8pt" ForeColor="White" />
                <OtherMonthDayStyle ForeColor="#999999" />
                <SelectedDayStyle BackColor="#666666" ForeColor="White" />
                <TitleStyle BackColor="#666666" BorderStyle="Solid" Font-Bold="True" Font-Size="12pt" ForeColor="White" Height="12pt" />
                <TodayDayStyle BackColor="#999999" ForeColor="White" />
            </asp:Calendar>
                </div>
            <div class="ChangeLease">
            <asp:Button ID="Button1" runat="server" Text="Materiaal innemen" OnClick="Button1_Click" />
                <br />
            <asp:Button ID="Button2" runat="server" Text="Materiaal Uitlenen" OnClick="Button2_Click" />
                </div>
            <br/>
            <div class="grid" align="center">
           <asp:GridView ID="ItemGridView" runat="server" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical" AutoGenerateSelectButton="True" Font-Size="Medium">
               <AlternatingRowStyle BackColor="#CCCCCC" />
               <FooterStyle BackColor="#CCCCCC" />
               <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
               <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
               <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
               <SortedAscendingCellStyle BackColor="#F1F1F1" />
               <SortedAscendingHeaderStyle BackColor="#808080" />
               <SortedDescendingCellStyle BackColor="#CAC9C9" />
               <SortedDescendingHeaderStyle BackColor="#383838" />
             </asp:GridView>
                <asp:Label ID="Label2" runat="server" Text="Label" Visible="False"></asp:Label>
                </div>
        
    </div>
    </div>
</asp:Content>
