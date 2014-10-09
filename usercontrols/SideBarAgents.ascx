<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SideBarAgents.ascx.cs" Inherits="usercontrols_SideBarAgents" %>
<% if(!String.IsNullOrEmpty(Request.QueryString["acID"]))
   { %>
	<section class="sidebar-form2 clearfix">
            <h2>OUR PROPERTIES FOR SALE/RENT</h2>
            <ul class="sidebar-property-sale">
              <li><a href="/Results.aspx?st=sa&acid=<%= Request.QueryString["acID"]%>"><span class="icons pro-sall"></span>RESIDENTIAL PROPERTY FOR SALE</a></li>
              <li><a href="/Results.aspx?st=ra&acid=<%= Request.QueryString["acID"]%>"><span class="icons pro-rent"></span>RESIDENTIAL PROPERTY FOR RENT</a></li>
              <li><a href="/Results.aspx?st=co&acid=<%= Request.QueryString["acID"]%>"><span class="icons commer-sall"></span>COMMERCIAL PROPERTY FOR SALE</a></li>
              <li><a href="/Results.aspx?st=cr&acid=<%= Request.QueryString["acID"]%>"><span class="icons commer-rent"></span>COMMERCIAL PROPERTY FOR RENT</a></li>
              <li><a href="/Results.aspx?st=bu&acid=<%= Request.QueryString["acID"]%>"><span class="icons bus-sall"></span>BUSINESS FOR SALE</a></li>
            </ul>
	</section>
<%} %>
