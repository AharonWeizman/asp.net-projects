<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
   || Welcome to  Personal Events Organizing  ||
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<div style="height:500px">
<div style="width:50%;float:right">
    <h2>
  
    <%: ViewData["Message"] %></h2>
    
        Here you can create and manage different events like 
        <ol>
        <li>Birthday</li><li> Wedding</li><li> Bar-Mitzvah</li><li> Bat-Mitzvah</li><li> Company Event</li>
        </ol>
        <h1>Quick Views</h1>
        <h2>
        <ol >
       <li><%: Html.ActionLink("Home", "Index", "Home")%></li>
         <%
             if (Request.IsAuthenticated)
             {
                    %>
                       <li><%: Html.ActionLink("Person Home", "PersonalHome", "Home")%></li>
                         <li><%: Html.ActionLink("Create Event", "CreateNewEvent", "Home")%></li>
                    <%
             }
             else { 
                 %>
                   <li><%: Html.ActionLink("Log In", "LogOn", "Account")%></li>
        <li><%: Html.ActionLink("Registration", "Register", "Account")%></li>
                 <%
             }
                         %>
                         </ol>
                         </h2>
        </div>
        <div style="width:50%;float:left">
        <img src="../images/events-icon.jpg"  alt="Events Organizing System" />
        </div>
</div>    
</asp:Content>
