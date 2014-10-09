<%@ Page Title="" Language="C#" MasterPageFile="Main.master" AutoEventWireup="true" Inherits="TemplateBase" %>
<%@ Register Src="~/usercontrols/HeadingResults.ascx" TagPrefix="reiq" TagName="heading" %>
<%@ Register Src="~/usercontrols/SideBarControlSearchResults.ascx" TagPrefix="reiq" TagName="sbctrl" %>
<%@ Register Src="~/usercontrols/SideBarRefineResults.ascx" TagPrefix="reiq" TagName="refineresults" %>
<%@ Register Src="~/usercontrols/FeaturedProperties.ascx" TagPrefix="reiq" TagName="featured" %>
<%@ Register Src="~/usercontrols/SortBy.ascx" TagPrefix="reiq" TagName="sort" %>
<%@ Register Src="~/usercontrols/Pagination.ascx" TagPrefix="reiq" TagName="pagination" %>
<%@ Register Src="~/usercontrols/Result.ascx" TagPrefix="reiq" TagName="result" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentHeader" Runat="Server">
    <reiq:heading runat="server" />
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="SideBarTopControl" Runat="Server">
    <reiq:sbctrl runat="server" />
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="RightSideBar" Runat="Server">
    <reiq:refineresults  runat="server" />
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="MainDataTopControl" Runat="Server">
    <a href="javascript:;" class="back"><span class="icons"></span>BACK TO PROPERTY LISTINGS</a> <span class="fright-block2"><a href="javascript:;" class="view-prop-map"><span class="icons"></span>VIEW PROPERTIES ON A MAP</a></span> 
</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="MainData" Runat="Server">

    <reiq:featured runat="server" />
    <reiq:sort runat="server" />
    <reiq:result runat="server" />
    <reiq:result runat="server" />
    <reiq:pagination runat="server" />

</asp:Content>

