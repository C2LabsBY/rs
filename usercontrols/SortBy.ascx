<%@ Control Language="C#" AutoEventWireup="false" CodeFile="SortBy.ascx.cs" Inherits="usercontrols_SortBy" %>
<% if (FoundProperties.Count() > 0)
   {%>
<section class="sort-by">
    <!-- SORT BY -->
    <section class="right-panel">
        <asp:Literal runat="server" ID="litDispalyInfo"></asp:Literal></section>
    <section class="left-panel">
        <label for="sort-by">SORT BY:</label>
        <asp:DropDownList ID="cboOrder" runat="server" AutoPostBack="true" OnSelectedIndexChanged="cboOrder_SelectedIndexChanged">
            <asp:ListItem Value="Most_recent">MOST RECENT</asp:ListItem>
            <asp:ListItem Value="By_suburb">BY SUBURB</asp:ListItem>
            <asp:ListItem Value="Highest_price">HIGHEST PRICE</asp:ListItem>
            <asp:ListItem Value="Lowest_price">LOWEST PRICE</asp:ListItem>
            <asp:ListItem Value="Number_bedrooms"># OF BEDROOMS</asp:ListItem>
        </asp:DropDownList>
        <%--<select name="sort-by"  id="sort-by">
        <option>MOST RECENT</option>
        <option>1</option>
        <option>2</option>
        </select>--%>
    </section>
</section>
<!-- /SORT BY -->
<%} %>
