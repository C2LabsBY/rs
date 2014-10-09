<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ClickToCallStats.ascx.cs" Inherits="usercontrols_ClickToCallStats" %>
<%@ Register Src="~/usercontrols/DatePicker.ascx" TagName="DatePicker" TagPrefix="uc1" %>

<link href='http://fonts.googleapis.com/css?family=Titillium+Web:400,600,700' rel='stylesheet' type='text/css'>
<link rel="stylesheet" type="text/css" href="/basemedia/css/style4.css" media="all">
<style>
    .table_h a:hover {
        color: #ffffff;
    }
    .table_h a {
        color: #bfbfbf;
    }
</style>
<h3 style="margin-bottom: 0px;">Click To Call Stats</h3>

<div class="pt15">
    <form name="clickToCallForm" id="clickToCallForm" method="post" action="ClickToCallStats.aspx">
        <label>Start date:</label>
        <uc1:DatePicker runat="server" ID="StartDatePicker" />
        <label>End Date:</label>
        <uc1:DatePicker runat="server" ID="EndDatePicker" />
        <asp:Button ID="btnFilter" CssClass="button" runat="server" Text="Filter" OnClick="btnFilter_Click" style="width:65px;padding-left:0px;padding-right:0px;" />  
        <asp:Button ID="btnExport" runat="server" Text="Export To Excel" OnClick="btnExport_Click" Style="float: right; width: 125px;padding-left:0px;padding-right:0px;" CssClass="button" />      
    </form>
</div>

<div>
    <table style="color:#333333;width:100%;border-collapse:collapse;border:0px;margin:0px;" cellspacing="0" cellpadding="4">
        <tr class="table_b">
            <td style="width:40%;">
                <asp:Literal runat="server" ID="litTotalAgenciesTop"></asp:Literal>
            </td>
            <td style="width:40%;">
                <asp:Literal runat="server" ID="litTotalAgentsTop"></asp:Literal>
            </td>
            <td style="width:20%;">
                <asp:Literal runat="server" ID="litTotalTop"></asp:Literal>
            </td>
        </tr>
    </table>

    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" CellPadding="4"
        DataSourceID="dsCalickToCallStats" GridLines="None" PageSize="50" ShowFooter="False" Width="100%" >
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:BoundField DataField="AgencyName" HeaderText="Agency Name" SortExpression="AgencyName" HtmlEncode="False" >
                <HeaderStyle Font-Bold="false" />
            </asp:BoundField>
            <asp:BoundField DataField="AgentName" HeaderText="Agent Name" ReadOnly="True" SortExpression="AgentName" HtmlEncode="False">
                <HeaderStyle Font-Bold="false" />
            </asp:BoundField>
            <asp:BoundField DataField="total" HeaderText="Total Clicks" SortExpression="total">
                <HeaderStyle HorizontalAlign="Center" Font-Bold="false"/>
                <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
        </Columns>
        <FooterStyle Font-Bold="True" ForeColor="White"/>
        <HeaderStyle ForeColor="White" CssClass="table_h" HorizontalAlign="Left" />
        <PagerSettings Mode="Numeric" />
        <PagerStyle CssClass="table_h" Font-Bold="true" HorizontalAlign="Right" />
        <RowStyle BackColor="#f1f1f1" ForeColor="#464646" Font-Names="'Titillium Web', sans-serif" Font-Size="14px" />
        <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
        <SortedAscendingCellStyle BackColor="#f1f1f1" />
        <SortedAscendingHeaderStyle BackColor="#464646" />
        <SortedDescendingCellStyle BackColor="#f1f1f1" />
        <SortedDescendingHeaderStyle BackColor="#464646" />
    </asp:GridView>
    <%--<table style="width: 100%;">
        <tr>
            <td>
                <h2 style="float: left;">
                    <asp:Literal runat="server" ID="litTotalAgencies"></asp:Literal></h2>
            </td>
            <td>
                <h2 style="float: right; margin-right: 75px">
                    <asp:Literal runat="server" ID="litTotalAgents"></asp:Literal></h2>
            </td>
            <td>
                <h2 style="float: right;">
                    <asp:Literal runat="server" ID="litTotal"></asp:Literal></h2>
            </td>
        </tr>
    </table>--%>

    <asp:SqlDataSource ID="dsCalickToCallStats" runat="server" ConnectionString="<%$ ConnectionStrings:propertiesdb %>"
        SelectCommand="SELECT   tlmpc.aID, tlmpc.acID, tblAgency.name AS AgencyName, (tblAgent.firstname + ' ' + tblAgent.surname) AS AgentName, SUM(tlmpc.total) as total
    FROM            tblLogMobilePhoneClick tlmpc WITH (NOLOCK)

    INNER JOIN  tblAgency WITH (NOLOCK) ON tblAgency.acID = tlmpc.acID
    INNER JOIN  tblAgent WITH (NOLOCK) ON tblAgent.aID = tlmpc.aID

    WHERE           tlmpc.date BETWEEN @DateFrom AND DATEADD(day, 1, @DateTo)

    GROUP BY        tlmpc.acID, tlmpc.aID, tblAgency.name, (tblAgent.firstname + ' ' + tblAgent.surname)
    ORDER BY  AgencyName, AgentName">
        <SelectParameters>
            <asp:ControlParameter ControlID="StartDatePicker" Name="DateFrom" PropertyName="SelectedDate" />
            <asp:ControlParameter ControlID="EndDatePicker" Name="DateTo" PropertyName="SelectedDate" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="dsTotal" runat="server" ConnectionString="<%$ ConnectionStrings:propertiesdb %>"
        SelectCommand="SELECT COUNT(DISTINCT(tlmpc.acID)) AS AGENCIES, COUNT(DISTINCT(tlmpc.aID)) AS AGENTS, SUM(tlmpc.total) AS Total FROM tblLogMobilePhoneClick tlmpc WITH (NOLOCK) WHERE tlmpc.date BETWEEN @DateFrom AND DATEADD(day, 1, @DateTo)">
        <SelectParameters>
            <asp:ControlParameter ControlID="StartDatePicker" Name="DateFrom" PropertyName="SelectedDate" />
            <asp:ControlParameter ControlID="EndDatePicker" Name="DateTo" PropertyName="SelectedDate" />
        </SelectParameters>
    </asp:SqlDataSource>
</div>
<br />

