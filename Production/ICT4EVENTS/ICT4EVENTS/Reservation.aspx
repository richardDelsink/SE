<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Reservation.aspx.cs" Inherits="ICT4EVENTS.Reservation" %>

<!DOCTYPE html>

<webopt:bundlereference runat="server" path="~/Content/Reservering.css" />

<head runat="server">
    <title>Camping</title>
</head>
<body>
     <form id="form1" runat="server">
          <b>Selecteer een plaats:</b>
         
         <div class ="map">   
            <asp:Button CssClass="buttons btn201" ID="Btn1" runat="server" Height="19px" Text="1" Width="35px" OnClick="Btn_Click" OnLoad="Getcolor"  />
            <asp:Button CssClass="buttons btn202" ID="Btn2" runat="server" Height="19px" Text="2" Width="35px" OnClick="Btn_Click" OnLoad="Getcolor"/>
            <asp:Button CssClass="buttons btn203" ID="Btn3" runat="server" Height="19px" Text="3" Width="35px" OnClick="Btn_Click" OnLoad="Getcolor"/>
         </div>
         <div class="Reserveren">
            <a>kies een Begindatum:</a>
            <asp:Calendar CssClass="Calendar" ID="Calendar1" runat="server" BackColor="White" BorderColor="#3366CC" BorderWidth="1px" CellPadding="1" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="#003399" Height="160px" Width="161px" >
                <DayHeaderStyle BackColor="#99CCCC" ForeColor="#336666" Height="1px"/>
                <NextPrevStyle Font-Size="8pt" ForeColor="#CCCCFF" />
                <OtherMonthDayStyle ForeColor="#999999" />
                <SelectedDayStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                <SelectorStyle BackColor="#99CCCC" ForeColor="#336666" />
                <TitleStyle BackColor="#003399" BorderColor="#3366CC" BorderWidth="1px" Font-Bold="True" Font-Size="10pt" ForeColor="#CCCCFF" Height="25px" />
                <TodayDayStyle BackColor="#99CCCC" ForeColor="White" />
                <WeekendDayStyle BackColor="#CCCCFF" />
            </asp:Calendar>
            <a>kies een Einddatum:</a>
            <asp:Calendar CssClass="Calendar" ID="Calendar2" runat="server" BackColor="White" BorderColor="#3366CC" BorderWidth="1px" CellPadding="1" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="#003399" Height="160px" Width="160px" VisibleDate="2015-01-09">
                <DayHeaderStyle BackColor="#99CCCC" ForeColor="#336666" Height="1px" />
                <NextPrevStyle Font-Size="8pt" ForeColor="#CCCCFF" />
                <OtherMonthDayStyle ForeColor="#999999" />
                <SelectedDayStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                <SelectorStyle BackColor="#99CCCC" ForeColor="#336666" />
                <TitleStyle BackColor="#003399" BorderColor="#3366CC" BorderWidth="1px" Font-Bold="True" Font-Size="10pt" ForeColor="#CCCCFF" Height="25px" />
                <TodayDayStyle BackColor="#99CCCC" ForeColor="White" />
                <WeekendDayStyle BackColor="#CCCCFF" />
            </asp:Calendar>
             <a>Aantal personen:</a>
             <asp:DropDownList ID="DropDownList1" runat="server">
                 <asp:ListItem Value="1"></asp:ListItem>
                 <asp:ListItem Value="2"></asp:ListItem>
                 <asp:ListItem Value="3"></asp:ListItem>
                 <asp:ListItem Value="4"></asp:ListItem>
                 <asp:ListItem Value="5"></asp:ListItem>
             </asp:DropDownList>

           </div>
         <div class="Reserveerbtn">
             
         <asp:Button CssClass="buttons btnreserveer" ID="BtnReserveer" runat="server" Height="40px" Text="Reserveer" Width="150px" OnClick="BtnReserveer_Click"/>

            <asp:CustomValidator CssClass="text-danger" id="CustomValidator2" runat="server" Display="Dynamic" ErrorMessage="Please select a place"  OnServerValidate="CustomValidator2_ServerValidate"></asp:CustomValidator>
            <asp:CustomValidator CssClass="text-danger" id="CustomValidator3" runat="server" Display="Dynamic" ErrorMessage="Enddate must be after startdate"  OnServerValidate="CustomValidator3_ServerValidate"></asp:CustomValidator>

            <asp:CustomValidator CssClass="text-danger" id="CustomValidator1" runat="server" Display="Dynamic" ErrorMessage="Please select a start and enddate"  OnServerValidate="CustomValidator1_ServerValidate"></asp:CustomValidator>

         </div>
            </form>
</body>
