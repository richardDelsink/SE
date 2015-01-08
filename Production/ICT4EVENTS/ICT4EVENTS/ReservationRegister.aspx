<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReservationRegister.aspx.cs" Inherits="ICT4EVENTS.ReservationRegister" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="~/Content/normalizer.css" rel="stylesheet" />
    <link href="~/Content/Register.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
            <div class="signup">
                <h1>Persons To Register : <asp:Label ID="LblRegister" runat="server" >5</asp:Label></h1>
                <asp:TextBox ID="tbVoornaam" runat="server" Class="input" placeholder="Voornaam"></asp:TextBox>
                                <asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" ControlToValidate="tbVoornaam" ErrorMessage="voornaam is a required field" ForeColor="Red"></asp:RequiredFieldValidator>
                <asp:TextBox ID="tbtussenvoegsel" runat="server" Class="input" placeholder="tussenvoegsel"></asp:TextBox>
                <asp:TextBox ID="tbachternaam" runat="server" Class="input" placeholder="achternaam"></asp:TextBox>
                                <asp:RequiredFieldValidator id="RequiredFieldValidator3" runat="server" ControlToValidate="tbachternaam" ErrorMessage="achternaam is a required field" ForeColor="Red"></asp:RequiredFieldValidator>

                <asp:TextBox ID="tbstraat" runat="server" Class="input" placeholder="straat"></asp:TextBox>
                                <asp:RequiredFieldValidator id="RequiredFieldValidator4" runat="server" ControlToValidate="tbstraat" ErrorMessage="straat is a required field" ForeColor="Red"></asp:RequiredFieldValidator>

                <asp:TextBox ID="tbhuisnr" runat="server" Class="input" placeholder="huisnummer"></asp:TextBox>
                                <asp:RequiredFieldValidator id="RequiredFieldValidator5" runat="server" ControlToValidate="tbhuisnr" ErrorMessage="huisnr is a required field" ForeColor="Red"></asp:RequiredFieldValidator>

                <asp:TextBox ID="tbwoonplaats" runat="server" Class="input" placeholder="postcode"></asp:TextBox>
                                <asp:RequiredFieldValidator id="RequiredFieldValidator6" runat="server" ControlToValidate="tbwoonplaats" ErrorMessage="postcode is a required field" ForeColor="Red"></asp:RequiredFieldValidator>

                <asp:TextBox ID="tbbanknr" runat="server" Class="input" placeholder="banknr"></asp:TextBox>
                                <asp:RequiredFieldValidator id="RequiredFieldValidator7" runat="server" ControlToValidate="tbbanknr" ErrorMessage="banknr is a required field" ForeColor="Red"></asp:RequiredFieldValidator>

                <asp:Button ID="btnSignup" runat="server" Class="button" Text="Sign up" OnClick="btnSignup_OnClick"/>
            </div>

    </div>
    </form>
</body>
</html>
