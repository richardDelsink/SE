<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Events_admin.aspx.cs" Inherits="ICT4EVENTS.Events_admin" %>


<asp:Content ID="eventsAdminContent" ContentPlaceHolderID="MainContent" runat="server">

        <webopt:bundlereference runat="server" path="~/Content/Events.css" />




    <div class="home_container">
       <div class ="content-body">



               <div class="btn-group" style="float : right">
  <button type="button" class="btn btn-default dropdown-toggle" data-toggle="dropdown" aria-expanded="false">
    Action <span class="caret"></span>
  </button>
  <ul class="dropdown-menu" role="menu">
    <li><a href="Events_admin">View Events</a></li>
    <li class="divider"></li>
    <li><a href="Events_AdminCreate">Create Event</a></li>
  </ul>
</div>
               <br />
               <br />
               <br />
               <br />
               <br />
               <br />
               <br />
               <br />
               <br />
               <asp:GridView ID="GridView1" runat="server" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
               </asp:GridView>
           </div>
        </div>
</asp:Content>
