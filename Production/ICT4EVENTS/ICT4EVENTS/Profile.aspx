<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="ICT4EVENTS.Profile" %>

<asp:Content ID="profileContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="home_container">
        <div class="jumbotron">
        <div align="center" class="control-top">
             
          
            <h2>Profielgegevens</h2>
             </div>
            <br />
            <br />
    
         
        <div class="control-bottom">
            <div class="Infolabels">
            <asp:Label ID="Infolabeluser" runat="server" Text="Username:"></asp:Label>
            <br />
           <asp:Label ID="Infolabelpass" runat="server" Text="Wachtwoord:"></asp:Label>
                  <br />
            <asp:Label ID="Infolabelmail" runat="server" Text="E-mail:"></asp:Label>
                  <br />
             </div>
            <div class="content-labels" >
           <asp:Label ID="UserLB" runat="server" Enabled="false"></asp:Label>           
            <br />
           <asp:Label ID="PassLB" runat="server" Enabled="false"></asp:Label>
           <br />
          <asp:Label ID="MailLB" runat="server" Enabled="false"></asp:Label>
          <br />
          <br />

            </div>
    

           </div>  
                    
    </div>
    </div>
</asp:Content>
