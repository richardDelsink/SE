<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Reservation.aspx.cs" Inherits="ICT4EVENTS.Reservation" %>
<!DOCTYPE html>

<webopt:bundlereference runat="server" path="~/Content/Reservering.css" />

<asp:SqlDataSource ID="SqlDataSource1" Runat="server" 
  SelectCommand="Select * from Customers"
  ConnectionString="<%$ ConnectionStrings:NorthwindConnectionString %>" />
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Camping</title>
</head>
<body>
     <form id="form1" runat="server">
            <asp:Button CssClass="buttons btn201" ID="Btn201" runat="server" Height="19px" Text="201" Width="35px" OnClick="Btn_Click" BackColor="green" />
            <asp:Button CssClass="buttons btn202" ID="Btn202" runat="server" Height="19px" Text="202" Width="35px" OnClick="Btn_Click" BackColor="green"/>
            <asp:Button CssClass="buttons btn203" ID="Btn203" runat="server" Height="19px" Text="203" Width="35px" OnClick="Btn_Click" BackColor="red"/>

            </form>
</body>
</html>
