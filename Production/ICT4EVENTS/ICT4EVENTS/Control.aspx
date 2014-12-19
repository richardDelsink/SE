<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Control.aspx.cs" Inherits="ICT4EVENTS.Controle" %>

<asp:Content ID="controlContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="home_container">
       < <div class="jumbotron">
        <h3>Toegangscontrole</h3>
        <div class="control-top"></div>
        <div class="control-bottom">
            <div class="Infolabels"
            <asp:Label ID="Label1" runat="server" Text="Naam"></asp:Label>
            <br />
            <asp:Label ID="Label2" runat="server" Text="E-mail"></asp:Label>
             </div>
            <div class="Label-content">

            </div>
        </div>
        <p><a href="http://www.asp.net" class="btn btn-primary btn-large">Learn more &raquo;</a></p>
    </div>
    </div>
</asp:Content>
