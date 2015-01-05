<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Control.aspx.cs" Inherits="ICT4EVENTS.Controle" %>

<asp:Content ID="controlContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="home_container">
       < <div class="jumbotron">
    
        <div align="center" class="control-top">
              <h2>Toegangscontrole</h2>
            <br />
            <img src="img/barcodeimg.png" width="200px"/>
            <asp:Image ID="Barcodeimg" src="barcodeimg.png" runat="server" />
            <br />
            <asp:TextBox ID="barcodetb" runat="server" OnTextChanged="barcodetb_TextChanged"></asp:TextBox>
              <asp:Label ID="rfidworth" runat="server" Text="Incheckstatus:"></asp:Label>
             </div>
            <br />
            <br />
    
         
        <div class="control-bottom">
            <div class="Infolabels">
            <asp:Label ID="Infolabeluser" runat="server" Text="Username:"></asp:Label>
            <br />
            <asp:Label ID="Infolabelmail" runat="server" Text="E-mail:"></asp:Label>
                  <br />
            <asp:Label ID="Infolabelactiv" runat="server" Text="Activatie-status:"></asp:Label>
                  <br />
            <asp:Label ID="Infolabelbarc" runat="server" Text="Barcodewaarde:"></asp:Label>
                  <br />
            <asp:Label ID="Infolabelpayment" runat="server" Text=Betaal-status:></asp:Label>
                  <br />
            <asp:Label ID="Infolabelaanw" runat="server" Text="Incheckstatus:"></asp:Label>
             </div>
            <div class="content-labels">
                    <asp:Label ID="userlabel" runat="server" Text="  "></asp:Label>
            <br />
            <asp:Label ID="mailLabel" runat="server" Text="  "></asp:Label>
                  <br />
            <asp:Label ID="activLabel" runat="server" Text="   "></asp:Label>
                  <br />
            <asp:Label ID="BarcoLabel" runat="server" Text="   "></asp:Label>
                  <br />
            <asp:Label ID="PaidLabel" runat="server" Text="   "></asp:Label>
                  <br />
            <asp:Label ID="Presencelbl" runat="server" Text="  "></asp:Label>
            <br />
            <br />
            
            </div>
    

           </div>  
                    
           <div align="center" class="ControlGrid" > 
               <h3>Aanwezigen</h3>
                      <asp:GridView ID="gridview" runat="server"  ></asp:GridView>
        </div> 
    </div>
    </div>
</asp:Content>
