<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SuburbProfileSmall.ascx.cs" Inherits="usercontrols_SuburbProfileSmall" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <style>
        body {
            margin: 0;
            padding: 0;
        }
    </style>
    <link rel="stylesheet" type="text/css" href="/basemedia/css/style.css" media="all">
    <%--<script src="http://maps.google.com/maps?file=api&amp;v=2&amp;key=<%=ConfigurationManager.AppSettings["GoogleMapKey"] %>" type="text/javascript"></script>--%>
</head>
<body>
    <script language="Javascript" src="/basemedia/scripts/FusionCharts1.js"></script>
    <script language="JavaScript">
        var data = new Array();
	<%
        if (dt != null)
        {
            if (SuburbAmount() != "")
            {
	         %>		
        data[0] = new Array("<%=Suburb.name %>",<%=SuburbAmount()%>);
	         <%
            }
        }		
	%>
        //the array of colors contains 4 unique Hex coded colours (without #) for the 4 products
        var colors=new Array("1D8BD1", "F1683C", "ab5153", "7b9625","2a8283");
        /**
         * updateChart method is called, when user changes any of the checkboxes.
         * Here, we generate the XML data again and build the chart.		  
         *	@param	domId	domId of the Chart
        */
        function updateChart(domId){			
            //Update it's XML - set animate Flag from AnimateChart checkbox in form
            //using updateChartXML method defined in FusionCharts.js

            updateChartXML(domId,generateXML(document.getElementsByName("AnimateChart").checked));
        }

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
            strXML = "<graph numberPrefix='$' <%=StrPrCission%>   rotateNames='1' animation='" + ((animate==true)?"1":"0") + "' " + ((document.getElementsByName("ShowValues").checked==true)?("showValues='1' rotateValues='1'"):(" showValues='0' ")) + "yAxisMaxValue='<%=maxvalue %>' numdivlines='9' divLineColor='CC3300' hovercapbg='FFFFFF' bgColor='FFFFFF,000000' caption='Median Prices in Selected Suburbs (Australian $)                                                                                         (c) REIQ     ' >";

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

    <form runat="server">

        <%if (Suburb != null)
          { %>
        <h2 style="font-size:16px;color:#ba002f;font-weight:bold;margin:0 0 15px 0;">Suburb Profile - <%=Suburb.name %></h2>
        <%= Suburb.descriptionLong %>
        <%}
          else
          {%>
        <h2>No Suburb associated with Property</h2>
        <%} %>
        <br />
        <br />
        <div style="float: left; width: 200px;">
            <asp:DropDownList ID="cboChartType" runat="server" Width="200" CssClass="dropdown">
                <asp:ListItem Text="Houses (under 2400sqm)" Value="1"></asp:ListItem>
                <asp:ListItem Text="Houses (over 2400sqm)" Value="2"></asp:ListItem>
                <asp:ListItem Text="Units" Value="0"></asp:ListItem>
            </asp:DropDownList>
        </div>
        <div style="float: right;">
            <asp:Button ID="btnView" CssClass="red-btn" runat="server" Text="View" OnClick="btnView_onClick"></asp:Button>
        </div>
        <div id="chart1div" style="border-bottom: #e0e0e0 1px solid; border-left: #e0e0e0 1px solid; border-top: #e0e0e0 1px solid; border-right: #e0e0e0 1px solid;"></div>
        <script language="JavaScript">
            var chart1 = new FusionCharts("/FusionCharts/FCF_MSColumn3D.swf", "chart1Id", "600", "450");
            var strXML = generateXML(document.getElementsByName("AnimateChart").checked);
            chart1.setDataXML(strXML);
            chart1.render("chart1div");
        </script>
        <br />
        <p>
            <i>
                <p>Where no median is available, insufficient sales were recorded in order to compile a reliable statistic.<br/>
For more information go to <a href="http://www.reiq.com/about-us/research-methodology" target="_blank">REIQ Research Methodology</a></p><br/>
                <p>SOURCE: REIQ. Data obtained from RP Data. Enquiries about the reproduction of part or all of the information should be directed to the Corporate Affairs Division, REIQ.</p><br/>
                <p>© The State of Queensland (Department of Natural Resources and Mines) 2014. Based on or contains data provided by the State of Queensland (Department of Natural Resources and Mines) 2014. In consideration of the State permitting use of this data you acknowledge and agree that the State gives no warranty in relation to the data (including accuracy, reliability, completeness, currency or suitability) and accepts no liability (including without limitation, liability in negligence) for any loss, damage or costs (including consequential damage) relating to any use of the data. Data must not be used for direct marketing or be used in breach of the privacy laws.</p>
               <%-- All figures are subject to further revision as more sales data becomes available.<br>
                Where no median is available, insufficient sales were recorded in order to compile a reliable statistic.<br>
                SOURCE: REIQ, Data obtained from PriceFinder.<br>
                <p>Based on or contains data provided by the State of Queensland (Department of Environment and Resource Management) 2012. In consideration of the State permitting use of this data you acknowledge and agree that the State gives no warranty in relation to the data (including accuracy, reliability, completeness, currency or suitability) and accepts no liability (including without limitation, liability in negligence) for any loss, damage or costs (including consequential damage) relating to any use of the data. Data must not be used for direct marketing or be used in breach of the privacy laws.</p>--%>
            </i>
        </p>
    </form>
</body>
</html>
