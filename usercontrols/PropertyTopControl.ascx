<%@ Control Language="C#" AutoEventWireup="true" CodeFile="PropertyTopControl.ascx.cs" Inherits="usercontrols_PropertyTopControl" %>
<a href="javascript:history.go(-1);" class="back">
    <span class="icons"></span>
    BACK
</a> 
<% if(!String.IsNullOrEmpty(Request.QueryString["pid"])) 
{%>
<span class="fright">Property ID: <%= Request.QueryString["pid"] %></span>
<% } %>