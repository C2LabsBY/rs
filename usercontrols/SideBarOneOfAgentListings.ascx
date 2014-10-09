<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SideBarOneOfAgentListings.ascx.cs" Inherits="usercontrols_SideBarOneOfAgentListings" %>

<%  if (Agent != null)
    {
        if (Property != null)
        {%>
        <h4>One of <%=Agent.firstname + " " + Agent.surname %>'s listings </h4>
        <a href="/property?pid=<%=Property.pID %>">
            <img src="<%= REIQ.Helpers.Images.GetDefaultPropertyImage(Property.pID, 240) %>" class="img-border" title="<%= Property.type%> <%=Property.status%> in <%= REIQ.Helpers.PropertyHelper.GetAddress(Property)%>" />
        </a>
        <br />
        <%= Property.suburb %><br />
        <%}
    }%>   