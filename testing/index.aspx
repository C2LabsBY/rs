<%@ Page Title="" Language="C#" MasterPageFile="BaseMasterPage.master" AutoEventWireup="true" Inherits="System.Web.UI.Page" %>
<%@ Register Src="~/usercontrols/SearchForm.ascx" TagPrefix="reiq" TagName="search" %>
<%@ Register Src="~/usercontrols/HomeTabs.ascx" TagPrefix="reiq" TagName="tabs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HomeSection" Runat="Server">

    <reiq:search ID="Search1" runat="server" />

    <reiq:tabs ID="Search2" runat="server" />

</asp:Content>