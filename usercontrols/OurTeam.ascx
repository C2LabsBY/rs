<%@ Control Language="C#" AutoEventWireup="true" CodeFile="OurTeam.ascx.cs" Inherits="usercontrols_OurTeam" %>
<asp:Panel runat="server" ID="pnlOurTeam" Visible="false">
    <!-- OUR TEAM -->
    <h2 class="title">Our Team</h2>
    <ul class="our-team-view">
        <asp:Repeater ID="rptAgent" runat="Server" OnItemDataBound="rptAgent_ItemDataBound">
            <ItemTemplate>
                <asp:Literal runat="server" ID="litTeamContent"></asp:Literal>
            </ItemTemplate>
        </asp:Repeater>
    </ul>
    <!-- /OUR TEAM -->
</asp:Panel>
