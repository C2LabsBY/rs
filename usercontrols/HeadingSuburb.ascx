<%@ Control Language="C#" AutoEventWireup="true" CodeFile="HeadingSuburb.ascx.cs" Inherits="usercontrols_content_header_HeadingSuburb" %>
<% if(Suburb != null)
   { %>
<header id="content-header" class="agent-header">
	<h1>Suburb Profile - <%=Suburb.name %></h1>
</header>
<%} %>