<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SuburbSearchStats.ascx.cs" Inherits="usercontrols_SuburbSearchStats" %>
<%@ Register Src="~/usercontrols/DatePicker_narrow.ascx" TagName="DatePicker" TagPrefix="uc1" %>

<link href='http://fonts.googleapis.com/css?family=Titillium+Web:400,600,700' rel='stylesheet' type='text/css'>
<link rel="stylesheet" type="text/css" href="/basemedia/css/style3.css" media="all">

<script language="Javascript" src="/basemedia/scripts/FusionCharts1.js"></script>
<script language="JavaScript">
    var data = new Array();
	<%
    if (chartDataList != null)
    {
        if (ChartAmounts() != "")
        {
	         %>		
    data[0] = new Array("<%=SuburbName %>",<%=ChartAmounts()%>);
	         <%
        }
    }		
	%>
    //the array of colors contains 4 unique Hex coded colours (without #) for the 4 products
    var colors=new Array("1D8BD1", "F1683C", "ab5153", "7b9625","2a8283");

    /**
     * generateXML method returns the XML data for the chart based on the
     * checkboxes which the user has checked.
     *	@param	animate		Boolean value indicating to  animate the chart.
     *	@return				XML Data for the entire chart.
    */		
    function generateXML(animate){			
        //Variable to store XML
        var strXML="";
		
        //<graph> element
        //Added animation parameter based on animate parameter			
        //Added value related attributes if show value is selected by the user
        strXML = "<graph <%=StrPrCission%>   rotateNames='1' animation='" + ((animate==true)?"1":"0") + "' " + ((document.getElementsByName("ShowValues").checked==true)?("showValues='1' rotateValues='1'"):(" showValues='0' ")) + "yAxisMaxValue='<%=maxNumberOfClicks %>' numdivlines='<%=(Convert.ToInt32(maxNumberOfClicks)-1 < 10) ? Convert.ToInt32(maxNumberOfClicks)-1:9%>' divLineColor='CC3300' hovercapbg='FFFFFF' bgColor='FFFFFF,000000' caption='Number of suburb searches by date                                                                                                     (c) REIQ     ' >";

        //Store <categories> and child <category> elements
        strXML = strXML + "<categories><%=GetQtrName()%></categories>";
        //Based on the products for which we've to generate data, generate XML		
        if(data[0] != undefined) strXML = strXML + getProductXML(0);

        //Close <graph> element;
        strXML = strXML + "</graph>";
        //Return data
        return strXML;
    }
	
    /**
     * getProductXML method returns the <dataset> and <set> elements XML for
     * a particular product index (in data array). 
     *	@param	productIndex	Product index (in data array)
     *	@return					XML Data for the product.
    */
    function getProductXML(productIndex){		
        var productXML;
        //Create <dataset> element taking data from 'data' array and color vaules from 'colors' array defined above
        productXML = "<dataset seriesName='" + data[productIndex][0] + "' color='"+ colors[productIndex]  +"' >";			
        //Create set elements
        for (var i=1; i<=<%=intNoOfRow%>; i++){
            productXML = productXML + "<set value='" + data[productIndex][i] + "' />";
        }
        //Close <dataset> element
        productXML = productXML + "</dataset>";
        //Return dataset data
        return productXML;			
    }
		
</script>

<script>
    function check(){
        var start = $('#startDatePicker input').val();
        var end = $('#endDatePicker input').val();
        var pattern = new RegExp(/([0][1-9]|[1][0-9]|[2][0-9]|3[0-1])-(0[1-9]|1[0-2])-(201)\d/);

        if (start == ''){
            alert('Start date is required.');
            return false;
        }
        if (end == ''){
            alert('End date is required.');
            return false;
        }
        if (!pattern.test(start)){
            alert('Start date is not valid.');
            return false;
        }
        if (!pattern.test(end)){
            alert('End date is not valid.');
            return false;
        }
        return true;
    };
</script>

<style>
    .table_f a:hover {
        color: #ffffff;
    }
    .table_f a {
        color: #bfbfbf;
    }
</style>

<div class="">
    <h3 style="margin: 0px;">Suburb Search Stats</h3>
    <form name="suburbsFilterForm" id="suburbsFilterForm" method="post" action="SuburbSearchStats.aspx">
        <div class="search_inputs">
            <asp:DropDownList ID="cboSuburbName" runat="server" CssClass="dropdown"></asp:DropDownList>
        </div>
        <label>Start date:</label><span id="startDatePicker"><uc1:DatePicker runat="server" ID="StartDatePicker" /> </span>   
        <label>End Date:</label> <span id="endDatePicker"><uc1:DatePicker runat="server" ID="EndDatePicker" /></span>

        <asp:Button ID="btnFilter" CssClass="button" runat="server" Text="Filter" OnClick="btnFilter_Click" OnClientClick="if (!check()) return false;"/>
        <asp:Button ID="btnExport" CssClass="button" runat="server" Text="Export To Excel" OnClick="btnExport_Click" Style="width:136px;" />
        <asp:Button ID="btnBuildChart" runat="server" Text="Build Chart" CssClass="button" OnClick="btnBuildChart_Click"/>
        <asp:Button ID="btnShowAll" runat="server" Text="Show All Suburbs" CssClass="button" OnClick="btnShowAll_Click" Visible="false"/>
    </form>

    <table class="table_main">
        <tr class="table_b">
            <td class="table_d" width="75%">
                <asp:Literal runat="server" ID="litTotalSuburbs"></asp:Literal>
            </td>
            <td class="table_d cen" width="25%">
                <asp:Literal runat="server" ID="litTotalTop"></asp:Literal>
            </td>
        </tr>
    </table>

    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" CellPadding="4"
        DataSourceID="dsSuburbSearchStats" GridLines="None" PageSize="50" ShowFooter="False" Width="100%" OnRowDataBound="GridView1_RowDataBound">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:BoundField DataField="Name" HeaderText="Suburb Name" SortExpression="Name" HtmlEncode="False">
                <HeaderStyle Width="75%" Font-Bold="false" CssClass="table_d" />
                <ItemStyle CssClass="table_d1 first" />
            </asp:BoundField>
            <asp:BoundField DataField="Count" HeaderText="Total Searches" ReadOnly="True" SortExpression="Count" HtmlEncode="False">
                <HeaderStyle Width="25%" Font-Bold="false" HorizontalAlign="Center" CssClass="table_d" />
                <ItemStyle HorizontalAlign="Center" CssClass="table_d1 cen last" />
            </asp:BoundField>
        </Columns>
        <FooterStyle BackColor="#464646" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#464646" Font-Bold="False" ForeColor="White" CssClass="table_h" HorizontalAlign="Left"/>
        <PagerStyle CssClass="table_f" HorizontalAlign="Right" Font-Bold="true" />
        <RowStyle ForeColor="#333333" CssClass="table_r" />
        <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
        <SortedAscendingCellStyle BackColor="#f1f1f1" />
        <SortedAscendingHeaderStyle BackColor="#464646" />
        <SortedDescendingCellStyle BackColor="#f1f1f1" />
        <SortedDescendingHeaderStyle BackColor="#464646" />
    </asp:GridView>

    <asp:SqlDataSource ID="dsSuburbSearchStats" runat="server" ConnectionString="<%$ ConnectionStrings:propertiesdb %>"
        SelectCommand="SELECT tlss.name as Name, COUNT(tlss.name) as Count
    FROM            tblLogSuburbSearch as tlss WITH (NOLOCK)

    WHERE             tlss.date BETWEEN @DateFrom AND DATEADD(day, 1, @DateTo) AND tlss.name LIKE @Suburb

    GROUP BY        tlss.name
    ORDER BY        tlss.name ASC">
        <SelectParameters>
            <asp:ControlParameter ControlID="cboSuburbName" Name="Suburb" PropertyName="SelectedValue" />
            <asp:ControlParameter ControlID="StartDatePicker" Name="DateFrom" PropertyName="SelectedDate" />
            <asp:ControlParameter ControlID="EndDatePicker" Name="DateTo" PropertyName="SelectedDate" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="dsTotal" runat="server" ConnectionString="<%$ ConnectionStrings:propertiesdb %>"
        SelectCommand="SELECT COUNT(DISTINCT(tlss.name)) AS Name, COUNT(tlss.sId) AS Total FROM tblLogSuburbSearch tlss WITH (NOLOCK) WHERE tlss.date BETWEEN @DateFrom AND DATEADD(day, 1, @DateTo) AND tlss.name LIKE @Suburb">
        <SelectParameters>        
            <asp:ControlParameter ControlID="cboSuburbName" Name="Suburb" PropertyName="SelectedValue" />
            <asp:ControlParameter ControlID="StartDatePicker" Name="DateFrom" PropertyName="SelectedDate" />
            <asp:ControlParameter ControlID="EndDatePicker" Name="DateTo" PropertyName="SelectedDate" />
        </SelectParameters>
    </asp:SqlDataSource>
    <br />
    <% if (!String.IsNullOrEmpty(Suburb))
       { %>
    <div id="chart"></div>
    <script language="JavaScript">
        var chart1 = new FusionCharts("/FusionCharts/FCF_MSline.swf", "chart1Id", "600", "450");
        var strXML = generateXML(document.getElementsByName("AnimateChart").checked);
        chart1.setDataXML(strXML);
        chart1.render("chart");
    </script>
    <% } %>
    <br />
</div>