<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AgentPropertiesResultIframe.ascx.cs" Inherits="usercontrols_AgentPropertiesResultIframe" %>

<asp:Repeater runat="server" ID="rptProperties" OnItemDataBound="rptProperties_ItemDataBound">
    <ItemTemplate>
        <section class="search-result-block clearfix">
            <a href="<%# "/" + REIQ.Helpers.PropertyHelper.GenerateURL(((REIQ.Entities.Property)Container.DataItem).suburb.ToString(), ((REIQ.Entities.Property)Container.DataItem).pID.ToString(), ((REIQ.Entities.Property)Container.DataItem).type.ToString(), ((REIQ.Entities.Property)Container.DataItem).status.ToString(), ParamSearchType, ((REIQ.Access.PropertyExtended)Container.DataItem).region.ToString()) + "i" %>">
                <!-- SEARCH RESULT BLOCK -->
                <h3 class="title"><%# HttpUtility.HtmlDecode(REIQ.Helpers.PropertyHelper.GetAddress((REIQ.Entities.Property)Container.DataItem).ToUpper()) %>
                    <span class="right-side">
                        <%--<asp:Label runat="server" ID="lblPrice"></asp:Label>--%>
                        <%# getPriceText(Container.DataItem) %>
                    </span> 
                </h3>
            </a>
            <figure class="img"><a href="<%# "/" + REIQ.Helpers.PropertyHelper.GenerateURL(((REIQ.Entities.Property)Container.DataItem).suburb.ToString(), ((REIQ.Entities.Property)Container.DataItem).pID.ToString(), ((REIQ.Entities.Property)Container.DataItem).type.ToString(), ((REIQ.Entities.Property)Container.DataItem).status.ToString(), ParamSearchType, ((REIQ.Access.PropertyExtended)Container.DataItem).region.ToString()) + "i"  %>">
                <img src="<%# REIQ.Helpers.Images.GetDefaultPropertyImage(((REIQ.Entities.Property)Container.DataItem).pID, 320, 240) %>" alt="" /></a></figure>
            <section class="detail clearfix">
                <span class="apartment-unit"><%# ((REIQ.Entities.Property)Container.DataItem).type.ToUpper() %></span>
                <%# REIQ.Helpers.SearchResultsHelper.GetDisplaySearchFeatures(((REIQ.Entities.Property)Container.DataItem).numBedrooms.ToString(), ((REIQ.Entities.Property)Container.DataItem).numBathrooms.ToString(), ((REIQ.Entities.Property)Container.DataItem).numCarbays.ToString(), ((REIQ.Entities.Property)Container.DataItem).numStudy.ToString(), ((REIQ.Entities.Property)Container.DataItem).hasPool.ToString(), ((REIQ.Entities.Property)Container.DataItem).numGarage.ToString()) %>
                <div class="clear"></div>
                <br />
                <p class="detail-title"><%# ((REIQ.Entities.Property)Container.DataItem).descriptionShort %></p>
                <p class="title2"><%# REIQ.Helpers.PropertyHelper.GetHomeOpensFormat_New(((REIQ.Entities.Property)Container.DataItem).homeopen1From.ToString(), ((REIQ.Entities.Property)Container.DataItem).homeopen1To.ToString(), ((REIQ.Entities.Property)Container.DataItem).homeopen2From.ToString(), ((REIQ.Entities.Property)Container.DataItem).homeopen2To.ToString())%></p>
                <p><%# REIQ.Helpers.PropertyHelper.GetShortDescription(((REIQ.Entities.Property)Container.DataItem).descriptionLong, 130)%>...</p>
                <section class="search-page-agent-detail">
                    <asp:Literal ID="litAgencyImage" runat="server"></asp:Literal>
                    <span class="agent-name"><%= (Agent.firstname + " " + Agent.surname).ToUpper() %></span><br />
                    <span class="agent-pg"><%= AgentHelper.GetAgentPhoneWithLog(Agent)%></span>
                </section>
            </section>
        </section>
        <%--<p class="add-to-myfavourites"><a href="javascript:;"><span class="icons"></span>ADD TO FAVOURITES</a> </p>--%>
    </ItemTemplate>
</asp:Repeater>
<h3><asp:Label runat="server" ID="lblNoResults" Text="There are no listings for this agent" Visible="false"></asp:Label></h3>
