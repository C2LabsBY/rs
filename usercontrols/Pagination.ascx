<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Pagination.ascx.cs" Inherits="usercontrols_Paging" %>

<div>
    <asp:Label ID="noresultsmessage" runat="server"></asp:Label>
</div>
<ul class="pagination">
    <asp:Literal runat="server" ID="litBackLink"></asp:Literal>
    <% if (!String.IsNullOrEmpty(paging)) {%><%= paging %><% } %>
    <asp:Literal runat="server" ID="litNextLink"></asp:Literal>
</ul>