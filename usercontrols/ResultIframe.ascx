<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ResultIframe.ascx.cs" Inherits="usercontrols_ResultIframe" %>

<asp:Repeater runat="server" ID="rptProperties" OnItemDataBound="rptProperties_ItemDataBound">
    <ItemTemplate>
        <section class="search-result-block clearfix">
            <!-- SEARCH RESULT BLOCK -->
            <a href="<%# "/" + REIQ.Helpers.PropertyHelper.GenerateURL(((REIQ.Entities.Property)Container.DataItem).suburb.ToString(), ((REIQ.Entities.Property)Container.DataItem).pID.ToString(), ((REIQ.Entities.Property)Container.DataItem).type.ToString(), ((REIQ.Entities.Property)Container.DataItem).status.ToString(), ParamSearchType, ((REIQ.Access.PropertyExtended)Container.DataItem).region.ToString()) + "i" %>">   
            <h3 class="title">
                    <table style="width: 100%;">
                        <tr>
                            <td>
                                <%# HttpUtility.HtmlDecode(REIQ.Helpers.PropertyHelper.GetAddress((REIQ.Entities.Property)Container.DataItem).ToUpper()) %>
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
            </a>
            <figure class="img">
                <asp:Literal runat="server" ID="ltlNew"/>
                <a href="<%# "/" + REIQ.Helpers.PropertyHelper.GenerateURL(((REIQ.Entities.Property)Container.DataItem).suburb.ToString(), ((REIQ.Entities.Property)Container.DataItem).pID.ToString(), ((REIQ.Entities.Property)Container.DataItem).type.ToString(), ((REIQ.Entities.Property)Container.DataItem).status.ToString(), ParamSearchType, ((REIQ.Access.PropertyExtended)Container.DataItem).region.ToString()) + "i" %>">
                    <img src="<%# REIQ.Helpers.Images.GetDefaultPropertyImage(((REIQ.Entities.Property)Container.DataItem).pID, 320, 240) %>" alt="" /></a>
            </figure>
            <section class="detail clearfix">
                <span class="apartment-unit"><%# ((REIQ.Entities.Property)Container.DataItem).type.ToUpper() %></span>
                <%# REIQ.Helpers.SearchResultsHelper.GetDisplaySearchFeatures(((REIQ.Entities.Property)Container.DataItem).numBedrooms.ToString(), ((REIQ.Entities.Property)Container.DataItem).numBathrooms.ToString(), ((REIQ.Entities.Property)Container.DataItem).numCarbays.ToString(), ((REIQ.Entities.Property)Container.DataItem).numStudy.ToString(), ((REIQ.Entities.Property)Container.DataItem).hasPool.ToString(), ((REIQ.Entities.Property)Container.DataItem).numGarage.ToString()) %>
                <div class="clear"></div>
                <br />
                <p class="detail-title"><%# ((REIQ.Entities.Property)Container.DataItem).descriptionShort %></p>
                <p class="title2"><%# REIQ.Helpers.PropertyHelper.GetHomeOpensFormat_New(((REIQ.Entities.Property)Container.DataItem).homeopen1From.ToString(), ((REIQ.Entities.Property)Container.DataItem).homeopen1To.ToString(), ((REIQ.Entities.Property)Container.DataItem).homeopen2From.ToString(), ((REIQ.Entities.Property)Container.DataItem).homeopen2To.ToString())%></p>
                <p><%# REIQ.Helpers.PropertyHelper.GetShortDescription(((REIQ.Entities.Property)Container.DataItem).descriptionLong, 130)%>...</p>
                <section class="search-page-agent-detail">
                    <table style="width: 100%">
                        <tr>
                            <td>
                                <table>
                                    <tr>
                                        <td>
                                            <asp:Literal ID="litAgentName" runat="server"></asp:Literal></td>
                                    </tr>
                                    <tr>
                                        <td nowrap>
                                            <asp:Literal ID="litAgentPhone" runat="server"></asp:Literal></td>
                                    </tr>
                                </table>
                            </td>
                            <td>
                                <div style="float: right">
                                    <asp:Literal ID="litAgencyImage" runat="server"></asp:Literal>
                                </div>
                            </td>
                        </tr>
                    </table>
                </section>
            </section>
        </section>
        <%--<p class="add-to-myfavourites"><a href="javascript:;"><span class="icons"></span>ADD TO FAVOURITES</a> </p>--%>
        <asp:Literal ID="ltlBannerAd" runat="server"></asp:Literal>
    </ItemTemplate>
</asp:Repeater>
<asp:Label runat="server" ID="lblNoResults" Text="Sorry, no properties found. Please try again..." Visible="false"></asp:Label>
