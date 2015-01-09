<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Material.aspx.cs" Inherits="ICT4EVENTS.Material" %>

<asp:Content ID="materialContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="home_container">
        <div class ="materialp">
         <table>
    <tr>
        <td>
            <h1>Product</h1>
            <asp:GridView runat="server" ID="gvLeft" AutoGenerateColumns="false" HeaderStyle-BackColor="CornflowerBlue" HeaderStyle-Font-Bold="true" HeaderStyle-ForeColor="White" CellPadding="5">
                <Columns>
                    <asp:TemplateField HeaderText="Select">
                        <ItemTemplate>
                            <asp:CheckBox runat="server" ID="chk" OnCheckedChanged="chk_CheckedChanged" AutoPostBack="true"/>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="Id" HeaderText="Id"> </asp:BoundField>
                    <asp:BoundField DataField="Merk" HeaderText="Brand"> </asp:BoundField>
                    <asp:BoundField DataField="Serie" HeaderText="Serie"> </asp:BoundField>
                    <asp:BoundField DataField="Naam" HeaderText="Name"> </asp:BoundField>
                    <asp:BoundField DataField="Prijs" HeaderText="Price"> </asp:BoundField>
                </Columns>
            </asp:GridView>
        </td>
        <td>
            <h1>Reserve Product</h1>
            <asp:GridView runat="server" ID="gvRight"  AutoGenerateColumns="false" HeaderStyle-BackColor="CornflowerBlue" HeaderStyle-Font-Bold="true" HeaderStyle-ForeColor="White" CellPadding="5">
                <Columns>
                    <asp:BoundField DataField="Id" HeaderText="Id"> </asp:BoundField>
                    <asp:BoundField DataField="Merk" HeaderText="Brand"> </asp:BoundField>
                    <asp:BoundField DataField="Serie" HeaderText="Serie"> </asp:BoundField>
                    <asp:BoundField DataField="Naam" HeaderText="Name"> </asp:BoundField>
                    <asp:BoundField DataField="Prijs" HeaderText="Price"> </asp:BoundField>
                </Columns>
            </asp:GridView><br />
            <asp:Button ID="MatReserv" runat="server" Text="Material Reservation" CssClass="btn" OnClick="MatReserv_Click"/>
        </td>
        <asp:Label ID="abc" runat="server" Text="Label"></asp:Label>
    </tr>
</table>

        </div>
    </div>
</asp:Content>
