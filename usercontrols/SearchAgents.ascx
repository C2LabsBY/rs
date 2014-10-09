<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SearchAgents.ascx.cs" Inherits="usercontrols_SearchAgents" %>
<%@ Register Assembly="FindAnAgent.Web" Namespace="FindAnAgent.Web.UserControls" TagPrefix="cc1" %>
<asp:ScriptManager ID="ScriptManager1" runat="server" />
<h2 class="title">FIND AN AGENT</h2>
<section class="sidebar-form clearfix">
<asp:UpdatePanel ID="SearchUpdatePanel" runat="server" UpdateMode="Conditional" >
    <ContentTemplate>
        <ul class="form-view">
            <li><asp:Label ID="AgencyNameLabel" AssociatedControlID="AgencyNameTextBox" runat="server" Text="Agency Name: " /><asp:TextBox ID="AgencyNameTextBox" runat="server" /></li>
            <li><asp:Label ID="TownSuburbLabel" AssociatedControlID="TownSuburbTextBox" runat="server" Text="Town/Suburb: " /><asp:TextBox ID="TownSuburbTextBox" runat="server" /></li>
            <li><asp:Label ID="PostCodeLabel" AssociatedControlID="PostCodeTextBox" runat="server" Text="Post Code: " /><asp:TextBox ID="PostCodeTextBox" runat="server" /></li>
            <li><asp:Label ID="FirstNameLabel" AssociatedControlID="FirstNameTextBox" runat="server" Text="First Name: " /><asp:TextBox ID="FirstNameTextBox" runat="server" /></li>
            <li><asp:Label ID="LastNameLabel" AssociatedControlID="LastNameTextBox" runat="server" Text="Last Name: " /><asp:TextBox ID="LastNameTextBox" runat="server" /></li>
            <li><asp:Label ID="OfficeActivityLabel" AssociatedControlID="OfficeActivityListBox" runat="server" Text="Office Activity: " /><asp:ListBox ID="OfficeActivityListBox" runat="server" DataValueField="Code" DataTextField="Description" CssClass="multiselectdropdown" SelectionMode="Multiple" /></li>
            <li><asp:Button ID="SearchButton" runat="server" OnClick="SearchButton_Click" Text="Find" CssClass="red-btn" /></li>
        </ul>

        <asp:customvalidator ID="SearchCustomValidator" errormessage="You must enter a value for at least one filter." runat="server" OnServerValidate="SearchCustomValidator_ServerValidate" />

    </ContentTemplate>
</asp:UpdatePanel>

<asp:UpdateProgress ID="SearchUpdateProgress" AssociatedUpdatePanelID="SearchUpdatePanel" runat="server">
    <ProgressTemplate>           
    <img alt="progress" src="/basemedia/images/progress.gif"/>
        Finding agents...           
    </ProgressTemplate>
</asp:UpdateProgress>

<asp:UpdatePanel ID="ResultsUpdatePanel" runat="server" UpdateMode="Conditional" >
    <ContentTemplate>
        <div id="ResultsDiv" runat="server">
            <asp:GridView ID="ResultsGridView" runat="server" AutoGenerateColumns="false" AllowPaging="true" ShowHeaderWhenEmpty="true" OnRowDataBound="ResultsGridView_RowDataBound" OnDataBound="ResultsGridView_DataBound">
                <RowStyle CssClass="even" />
                <AlternatingRowStyle CssClass="odd" />
                <Columns>
                    <asp:BoundField DataField="AgentName" HeaderText="REIQ Accredited Agency" />
                    <asp:BoundField DataField="Address" HeaderText="Address" />
                    <asp:BoundField DataField="FullName" HeaderText="Name" Visible="false"/>
                    <asp:BoundField DataField="Phone" HeaderText="Phone">
                        <ItemStyle Wrap="false" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Email" HeaderText="Email" DataFormatString="<a href=mailto:{0}>Email office</a>" HtmlEncodeFormatString="false" />
                    <asp:HyperLinkField DataNavigateUrlFields="Website" Text="Agency Website" HeaderText="Website" Target="_blank" />
                </Columns>
                <PagerTemplate>
                    <cc1:GridPager ID="ResultsGridPager" runat="server" 
                        ShowFirstAndLast="True"
                        ShowNextAndPrevious="True"
                        PageLinksToShow="5"
                        FirstText="|<"
                        PreviousText="<"
                        NextText=">"
                        LastText=">|"
                        />
                </PagerTemplate>
                <EmptyDataTemplate>
                    <asp:Label ID="ResultsGridViewEmptyDataLabel" runat="server" Text="0 results found" />
                </EmptyDataTemplate>
            </asp:GridView>

            <asp:ObjectDataSource id="ResultsObjectDataSource" runat="server" TypeName="FindAnAgent.BusinessLogic.Agents" SelectMethod="GetAgents" OnObjectCreating="ResultsObjectDataSource_ObjectCreating" OnObjectDisposing="ResultsObjectDataSource_ObjectDisposing" OnSelecting="ResultsObjectDataSource_OnSelecting">
                <SelectParameters>
                    <asp:ControlParameter ControlID="AgencyNameTextBox" PropertyName="Text"  Name="agencyName" Type="String" DefaultValue="" />
                    <asp:ControlParameter ControlID="TownSuburbTextBox" PropertyName="Text"  Name="townSuburb" Type="String" DefaultValue="" />
                    <asp:ControlParameter ControlID="PostCodeTextBox" PropertyName="Text"  Name="postCode" Type="String" DefaultValue="" />
                    <asp:ControlParameter ControlID="FirstNameTextBox" PropertyName="Text"  Name="firstName" Type="String" DefaultValue="" />
                    <asp:ControlParameter ControlID="LastNameTextBox" PropertyName="Text"  Name="lastName" Type="String" DefaultValue=""  />
                    <asp:Parameter Name="activities" Type="Object" />
                </SelectParameters>
            </asp:ObjectDataSource>

        </div>
        <div id="ErrorsDiv" runat="server" visible="false">
            <asp:Label ID="ErrorMessageLabel" runat="server" />
            <asp:Label ID="ErrorStackLabel" runat="server" />
        </div>
    </ContentTemplate>
</asp:UpdatePanel>

    </section>
<div class="clear" />
