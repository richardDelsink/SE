<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Mediasharing.aspx.cs" Inherits="ICT4EVENTS.About" %>

<asp:Content ID="mediasharingContent" ContentPlaceHolderID="MainContent" runat="server">
   <div class="home_container" style="height: 542px">
        <%--<div class="jumbotron">--%>
   
            <ul class="nav nav-tabs">
  <li role="presentation" class="active"><a href="#">Personal Info</a></li>
  <li role="presentation"><a href="#">Media</a></li>
            </ul>
       <div class="container">
            <div class="row">

<%--  <div class="col-md-4">.col-md-4</div>--%>

<div class="col-md-4"><asp:DataGrid CssClass="list-group" id="ownmedialist" OnSelectedIndexChanged="ownmedialist_OnSelectedIndexChanged" runat="server"></asp:DataGrid></div>        
<div class="col-md-4">
    <asp:Label runat="server" Text="Filename: "></asp:Label><br/>
    <asp:Label runat="server" Text="Filesize: "></asp:Label><br/>
    <asp:Label runat="server" Text="Category"></asp:Label><br/>
    <asp:ImageButton ID="likebtn" runat="server" ImageUrl="http://i758.photobucket.com/albums/xx221/Mark_MJB15/thumb-up-facebook-emoticon-like-symbol_zps5cca22e1.png"> </asp:ImageButton>
    <asp:ImageButton ID="dislikebtn" runat="server" ImageUrl="http://i758.photobucket.com/albums/xx221/Mark_MJB15/facebook-emoticon-of--dislike-symbol_zpsf59dfd62.png">  </asp:ImageButton>
    <asp:ImageButton ID="reportbtn" runat="server" ImageUrl="http://i758.photobucket.com/albums/xx221/Mark_MJB15/report_zpsd968ebcf.png"> </asp:ImageButton>


</div>
<div class="col-md-4">
    <asp:FileUpload runat="server"></asp:FileUpload>
    <asp:DropDownList ID="categoriecb" OnSelectedIndexChanged="categoriecb_OnSelectedIndexChanged" runat="server"></asp:DropDownList>
    <asp:Button ID="btnUp" runat="server" OnClick="btnUpload_OnClick" Text="Upload"/>
</div>

    
    </div>
    </div>
    </div>
</asp:Content>
