<%@ Control Language="C#" AutoEventWireup="true" CodeFile="FeaturedProperties.ascx.cs" Inherits="usercontrols_FeaturedProperties" %>

<% if (FinalList.Count > 0)
   { %>
<h2 class="title-red">FEATURED PROPERTIES</h2>
<section class="featured-property-block-view clearfix">
    <!-- FEATURED PROPERTY BLOCK VIEW -->
    <asp:Repeater runat="server" ID="rptProperties" OnItemDataBound="rptProperties_ItemDataBound">
        <ItemTemplate>

            <section class="<%# getSectionClass(Container.DataItem) %>">
                <!-- SEARCH RESULT BLOCK -->
                <h3 class="title">
                    <table style="width:100%;">
                        <tr>
                            <td>
                                <%# ((REIQ.Entities.Property)Container.DataItem).suburb %>
                            </td>
                            <td>
                                <span class="right-side" style="text-align: right;">
                                    <%--<asp:Label runat="server" ID="lblPrice"></asp:Label>--%>
                                    <%# getPriceText(Container.DataItem) %>
                                </span>
                            </td>
                        </tr>
                    </table>
                </h3>
                <%# REIQ.Helpers.SearchResultsHelper.GetDisplaySearchFeatures_Featured(((REIQ.Entities.Property)Container.DataItem).numBedrooms.ToString(), ((REIQ.Entities.Property)Container.DataItem).numBathrooms.ToString(), ((REIQ.Entities.Property)Container.DataItem).numCarbays.ToString(), ((REIQ.Entities.Property)Container.DataItem).numStudy.ToString(), ((REIQ.Entities.Property)Container.DataItem).hasPool.ToString(), ((REIQ.Entities.Property)Container.DataItem).numGarage.ToString()) %>
                <figure class="img clearfix">
                    <asp:Literal runat="server" ID="ltlNew"/>
                    <span class="info"><%# REIQ.Helpers.PropertyHelper.GetAddress_Featured((REIQ.Entities.Property)Container.DataItem).ToUpper() %></span> 
                    <a href="<%# "/" + REIQ.Helpers.PropertyHelper.GenerateURL(((REIQ.Entities.Property)Container.DataItem).suburb.ToString(), ((REIQ.Entities.Property)Container.DataItem).pID.ToString(), ((REIQ.Entities.Property)Container.DataItem).type.ToString(), ((REIQ.Entities.Property)Container.DataItem).status.ToString(), ParamSearchType, REIQ.Access.Property.GetPropertyRegion(((REIQ.Entities.Property)Container.DataItem).pID).ToString()) %>"> 
                        <img src="<%# REIQ.Helpers.Images.GetDefaultPropertyImage(((REIQ.Entities.Property)Container.DataItem).pID, 250, 200) %>" alt="" />
                    </a> 
                </figure>
                <section class="detail">
                    <p>
                        <span class="title-red"><%# ((REIQ.Entities.Property)Container.DataItem).descriptionShort %></span>
                        <br />
                        <%# REIQ.Helpers.PropertyHelper.GetShortDescription(((REIQ.Entities.Property)Container.DataItem).descriptionLong, 65)%>...
                    </p>
                    <p class="contact-detail">
                        <asp:Literal ID="litAgentName" runat="server"></asp:Literal><br />
                        <asp:Literal ID="litAgentPhone" runat="server"></asp:Literal>
                    </p>
                    <figure class="agency-logo"><asp:Literal ID="litAgencyImage" runat="server"></asp:Literal></figure>
                </section>
                <%--<section class="detail clearfix">
                    <span class="apartment-unit"><%# ((REIQ.Entities.Property)Container.DataItem).type.ToUpper() %></span>
                    <%# REIQ.Helpers.SearchResultsHelper.GetDisplaySearchFeatures(((REIQ.Entities.Property)Container.DataItem).numBedrooms.ToString(), ((REIQ.Entities.Property)Container.DataItem).numBathrooms.ToString(), ((REIQ.Entities.Property)Container.DataItem).numCarbays.ToString(), ((REIQ.Entities.Property)Container.DataItem).numStudy.ToString(), ((REIQ.Entities.Property)Container.DataItem).hasPool.ToString(), ((REIQ.Entities.Property)Container.DataItem).numGarage.ToString()) %>
                    <div class="clear"></div>
                    <br />
                    <p class="detail-title"><%# ((REIQ.Entities.Property)Container.DataItem).descriptionShort %></p>
                    <p class="title2"><%# REIQ.Helpers.PropertyHelper.GetHomeOpensFormat_New(((REIQ.Entities.Property)Container.DataItem).homeopen1From.ToString(), ((REIQ.Entities.Property)Container.DataItem).homeopen1To.ToString(), ((REIQ.Entities.Property)Container.DataItem).homeopen2From.ToString(), ((REIQ.Entities.Property)Container.DataItem).homeopen2To.ToString())%></p>
                    <p><%# REIQ.Helpers.PropertyHelper.GetShortDescription(((REIQ.Entities.Property)Container.DataItem).descriptionLong, 130)%>...</p>
                    <section class="search-page-agent-detail">
                        <asp:Literal ID="litAgencyImage" runat="server"></asp:Literal>
                        <asp:Literal ID="litAgentName" runat="server"></asp:Literal>
                        <asp:Literal ID="litAgentPhone" runat="server"></asp:Literal>
                    </section>
                </section>--%>
            </section>
        </ItemTemplate>
    </asp:Repeater>
    <!-- /FEATURED BLOCK -->
</section>
<!-- /FEATURED PROPERTY BLOCK VIEW -->
<%} %>
