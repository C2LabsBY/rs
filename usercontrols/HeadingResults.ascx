<%@ Control Language="C#" AutoEventWireup="false" CodeFile="HeadingResults.ascx.cs" Inherits="usercontrols_Heading" %>
<header id="content-header" class="" style="height:auto;margin-bottom:-30px;">
    <section class="content-header-first-full-block">
	    <h1><asp:Label runat="server" ID="lblsearchheading"></asp:Label><%//=(string.IsNullOrEmpty(Request.QueryString["su"]) || Request.QueryString["su"].ToLower() == "any") ? "" : " in <span style='text-transform:capitalize;'>" + Request.QueryString["su"].Replace(",", "; ").Replace("-", ", ").ToLower() + "</span>"%></h1>
    </section>
    <section style="width:960px;float:left;margin-top: -10px;">
        <% //if (!string.IsNullOrEmpty(Request.QueryString["txt"]) && Request.QueryString["txt"] != REIQ.usercontrols.PropertySearchBase.DefaultSearchText){ %>
        <!--Results for properties for <asp:Label runat="server" ID="forSearchkey"></asp:Label> <asp:Label runat="server" ID="keyWord"></asp:Label> -->
        <%// } %>    

        <asp:Label ID="lblSearchHeadingContent" runat="server"></asp:Label>
    </section>
</header>