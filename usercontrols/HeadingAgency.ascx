<%@ Control Language="C#" AutoEventWireup="true" CodeFile="HeadingAgency.ascx.cs" Inherits="usercontrols_content_header_AgencyHeading" %>
<% if(Agency != null)
   { %>
<header id="content-header" class="agent-header" style="height:55px !important;">
	<h1><%=Agency.name %></h1>
    <section class="contact-detail"><!-- CONTACT DETAIL -->
        <strong><% if (!String.IsNullOrEmpty(AgencyAddress)) {%><%= AgencyAddress%><%}%></strong> <br/>
        <% if (!String.IsNullOrEmpty(Agency.phone)) {%>P: <%= Agency.phone %> <br/><%}%>
        <% if (!String.IsNullOrEmpty(Agency.fax)) {%>F: <%= Agency.fax %> <br/><%}%>
        <% if (!String.IsNullOrEmpty(Agency.web))
					 {%>W: <a href="<%= REIQ.Helpers.AgencyHelper.GetWebAddressFormatted(Agency.web) %>"><%= Agency.web %></a><%}%>
    </section><!-- /CONTACT DETAIL -->

    <section class="agent-adv"><!-- AGENT ADV -->
  	<img src="<%=REIQ.Helpers.Images.GetAgencyImage(Agency.acID, 196, 88) %>" alt="<%=Agency.name %>" />
  </section><!-- /AGENT ADV -->
    
</header>
<%} %>