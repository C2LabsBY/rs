<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SideBarRefineResults.ascx.cs" Inherits="usercontrols_SideBarRefineResults" %>
<asp:PlaceHolder runat="server" ID="phSearchRefineForm" Visible="false">
    <section class="sidebar-form sidebar-form2 clearfix">
        <h2>REFINE SEARCH</h2>
        <input type="hidden" name="st" value="sa" />
        <ul class="form-view refine-search-form">
            <%if (Request.QueryString["st"] != "ru" && Request.QueryString["st"] != "co" && Request.QueryString["st"] != "cr" && Request.QueryString["st"] != "bu")
              {%>
            <li>
                <label for="poperty-type">PROPERTY TYPE:</label>
                <asp:ListBox CssClass="multiselectdropdown" ID="cboPropertyType" runat="server" SelectionMode="Multiple"></asp:ListBox>
            </li>
            <%} %>
            <%if (Request.QueryString["st"] != "co" && Request.QueryString["st"] != "cr" && Request.QueryString["st"] != "bu")
              {%>
            <li>
                <label for="poperty-type">MIN. BEDROOMS:</label>
                <asp:DropDownList ID="ddlBedrooms" runat="server"></asp:DropDownList>
            </li>
            <%} %>
            <%if (Request.QueryString["st"] != "co" && Request.QueryString["st"] != "cr" && Request.QueryString["st"] != "bu")
              {%>
            <li>
                <label for="poperty-type">MIN BATHROOMS:</label>
                <asp:DropDownList ID="ddlBaths" runat="server" />
            </li>
            <%--<li>
                <label for="poperty-type">MIN CAR BAYS:</label>
                <asp:DropDownList ID="ddlCars" runat="server" />
            </li>--%>
            <%} %>
            <li>
                <label for="min-price">MIN PRICE:</label>
                <asp:DropDownList ID="ddlMinPrice" runat="server"></asp:DropDownList>
            </li>
            <li>
                <label for="max-price">MAX PRICE:</label>
                <asp:DropDownList ID="ddlMaxPrice" runat="server"></asp:DropDownList>
            </li>
            <li class="no-label">
                <asp:Button CssClass="red-btn" ID="btnSearchProp" runat="server" Text="Search" OnClick="btnSearchProp_Click"></asp:Button>
            </li>
        </ul>
    </section>
</asp:PlaceHolder>

