<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	|| User Home In Personal Events Organizing  ||
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2> Welcome Back  <b><%: Page.User.Identity.Name %></b>!</h2>

    <p>You have created bellow events...</p>

    
    
      
       <table style="border:2px solid black;margin:5px">
          <tr>
            <td style="border:0px;width:200px;text-align:center"><h3>Event Type</h3></td>                      
            <td  style="border:0px;width:200px;text-align:center"><h3>Date(dd/MM/yyyy)</h3></td>
            <td  style="border:0px;width:200px;text-align:center"><h3>Remarks</h3></td>                        
            </tr>
       
    <% using (Html.BeginForm())
       { %>       
        <%foreach (System.Data.DataRow dr in new MvcPersonalEventsOrganization.Models.tbEventsModelService().GetEvents("").Rows)
          {%>

          
          
          
          <tr>
            <td style="border:0px;width:200px;text-align:center">
            <a href="<%:Url.Action("EditEvent", "Home",new { mNumber = dr["ID"].ToString() }, null)%>">
            <%=dr["EventType"].ToString()%>
            </a>
            </td>                      
            <td  style="border:0px;width:200px;text-align:center">
            <a href="<%:Url.Action("EditEvent", "Home",new { mNumber = dr["ID"].ToString() }, null)%>">
            <%=dr["EventDate"].ToString()%>
            </a>
            </td>

            <td  style="border:0px;width:200px;text-align:center">
            <a href="<%:Url.Action("EditEvent", "Home",new { mNumber = dr["ID"].ToString() }, null)%>">
            <%=dr["Remarks"].ToString()%>
            </a>
            </td>                        
            </tr>
        
            
      
       <%}
       }%>
</table>
</asp:Content>
