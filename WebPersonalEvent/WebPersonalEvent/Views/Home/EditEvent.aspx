<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<MvcPersonalEventsOrganization.Models.tbEventsModel>" %>



<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	|| Edit/Delete/View Event In Personal Events Organizing  ||
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

     <h2>Edit Event</h2>
    <p>
        Use the form below to create a new event. 
    </p>
    
    <% using (Html.BeginForm()) { %>
        <%: Html.ValidationSummary(true, "Event creation was unsuccessful. Please correct the errors and try again.") %>
        <div>
            <fieldset>
                <legend>Account Information</legend>
                
         
<div class="editor-field" style="display:none">
    <%:Html.EditorFor(model => model.ID)%>
    <%:Html.ValidationMessageFor(model => model.ID)%>
</div>

                    <div class="editor-label">
                    <%: Html.LabelFor(m => m.EventType)%>
                </div>
                 <div class="editor-label">
              <%:Html.DropDownListFor(m => m.EventType, new List<SelectListItem>
                     {
                        new SelectListItem{ Text="Birthday", Value = "Birthday" }, 
                        new SelectListItem{ Text="Wedding", Value = "Wedding" },
                        new SelectListItem{ Text="Bar-Mitzvah", Value = "Bar-Mitzvah" },
                         new SelectListItem{ Text="Company Event", Value = "BarCompany Event" }
                     }) %>
                </div>
                  
                    <div class="editor-label">
                    <%: Html.LabelFor(m => m.EventDate)%>
                </div>
                <div class="editor-field">
                    <%: Html.TextBoxFor(m => m.EventDate)%>
                    <%: Html.ValidationMessageFor(m => m.EventDate)%>
                </div>
            
         <div class="editor-label">
                    <%: Html.LabelFor(m => m.Remarks)%>
                </div>
                <div class="editor-field">
                    <%: Html.TextAreaFor(m => m.Remarks)%>
                    <%: Html.ValidationMessageFor(m => m.Remarks)%>
                </div>
            
        </div>
                

                <p>
                    <input type="submit" value="Save" />
                </p>
                <%= Html.ActionLink("Would you like to delete this event ?", "DeleteEvent", new { mNumber = Model.ID }, null)%>
                
            </fieldset>
        </div>
    <% } %>

</asp:Content>
