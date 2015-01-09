<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Event_AdminCreate.aspx.cs" Inherits="ICT4EVENTS.Event_AdminCreate" %>



<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

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
    <li><a href="Event_AdminCreate">Create Event</a></li>
  </ul>
</div>

           
           <p>Maak een Event aan !</p>
           <p>&nbsp;</p>
           <p>&nbsp;</p>
           <p>Naam :<asp:TextBox ID="TextBox1" runat="server" Height="22px"></asp:TextBox>
           </p>
           <p>Locatie :<asp:DropDownList ID="DropDownList1" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
               </asp:DropDownList></p>
               <p>&nbsp;</p>
           <p>Begin Datum :&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Eind Datum:</p>
            <div class="calenders" style="width: 812px">

                <div class="calender2" style="float : right; width: 571px;">
                     <asp:Calendar ID="Calendar1" runat="server"></asp:Calendar> 
                    </div>


                <div class="calender1" style="width: 186px">
            <asp:Calendar ID="Calendar2" runat="server"></asp:Calendar>  
                    </div>
           </div>
           <p>&nbsp;</p>
               <p>MaxBezoekers : 
               <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
           </p>
           <p>
                              <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Create" /> <br />

                           <asp:CustomValidator CssClass="text-danger" id="CustomValidator2" runat="server" Display="Dynamic" ErrorMessage="please fill in all the fields !"  OnServerValidate="CustomValidator2_ServerValidate"></asp:CustomValidator>
           </p>
               <p>
            <asp:CustomValidator CssClass="text-danger" id="CustomValidator1" runat="server" Display="Dynamic" ErrorMessage="please choose a valid date !"  OnServerValidate="CustomValidator1_ServerValidate"></asp:CustomValidator>
           </p>


       </div>
    </div>
</asp:Content>
