<%@ Control Language="C#" AutoEventWireup="true" CodeFile="HeadingAgent.ascx.cs" Inherits="usercontrols_content_header_AgentHeading" %>

<% if(Agent != null)
   { %>
<header id="content-header" class="agent-header" style="height:75px !important;">
    <%if ((Agent.ImisAid != null || !(bool)Agent.nonIMIS) && Agent.ImisAid != 0)
    { 
        if (String.IsNullOrEmpty(Agent.firstname) || !Agent.isWebDisplay)
        { %>                
                <br /><br />
                <b>Sorry, but the agent profile you requested is no longer accessible.</b>
                <br /><br /><br />
        <%}
        else
        { %>
	        <h1><%=Agent.firstname %> <%=Agent.surname %></h1>
            <section class="contact-detail"><!-- CONTACT DETAIL -->
                <strong><% if (Agency != null) {%><%= Agency.name%><%}%></strong> <br/>
                <% if (!String.IsNullOrEmpty(Agent.phone))
                   {%>P: <%= Agent.phone %> <br/><%}%>
                <% if (!String.IsNullOrEmpty(Agent.fax))
                   {%>F: <%= Agent.fax %> <br/><%}%>
                <% if (!String.IsNullOrEmpty(Agent.email))
                   {%>E: <a href="mailto:<%= Agent.email %>"><%= Agent.email %></a><%}%>
            </section><!-- /CONTACT DETAIL -->
            <% if (Agency != null) {%>
                <section class="agent-adv"><!-- AGENT ADV -->
  	                <img src="<%=REIQ.Helpers.Images.GetAgentImage(Agency.acID, Agent.aID, 75, 99) %>" alt="<%=Agent.firstname %> <%=Agent.surname %>" />
                </section><!-- /AGENT ADV -->
            <%}%>
        <%}%>
    <%}%>
    
</header>
<%} %>