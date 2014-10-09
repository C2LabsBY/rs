<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SuburbProfile.ascx.cs" Inherits="usercontrols_SuburbProfile" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<%--<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <style>
        body {
            margin: 0;
            padding: 0;
        }
    </style>
    <link rel="stylesheet" type="text/css" href="/basemedia/css/style.css" media="all">
    <script src="http://maps.google.com/maps?file=api&amp;v=2&amp;key=<%=ConfigurationManager.AppSettings["GoogleMapKey"] %>" type="text/javascript"></script>
</head>
<body>--%>
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

  <% if (Suburb == null)
  {%>
    <h2 class="title">Suburb Profiles</h2>
    <div>
        <p>The REIQ has developed profiles of suburbs and localities around Queensland to give investors, homebuyers and other interested parties a quick overview of the facilities and housing available in a particular area.</p>
        <p>The REIQ suburb profiles contain helpful information including:</p>
        <ul>
            <li>Distance from amenities</li>
            <li>Style of homes</li>
            <li>New and proposed developments</li>
            <li>Access to public transport</li>
            <li>Recreational facilities and attractions</li>
            <li>Local schools and universities</li>
            <li>Latest median house price data</li>
        </ul>
    </div>
    <br />
    <b>To view a suburb profile, please select a suburb from the list below and click view.</b>
<%} %>
<table>
    <tr>
        <td>
            <span>Suburb:&nbsp;</span>
    <span><asp:DropDownList Width="200" CssClass="dropdown" ID="cboSuburbInfo" runat="server" DataTextField="name" DataValueField="name"></asp:DropDownList></span>
    </td>
        <td>&nbsp;&nbsp;including median data for:
    <asp:DropDownList ID="cboChartType" runat="server" Width="200" CssClass="dropdown">
        <asp:ListItem Text="Houses (under 2400sqm)" Value="1"></asp:ListItem>
        <asp:ListItem Text="Houses (over 2400sqm)" Value="2"></asp:ListItem>
        <asp:ListItem Text="Units" Value="0"></asp:ListItem>
    </asp:DropDownList></td>
        <td><asp:Button ID="btnView" CssClass="red-btn-profile" runat="server" Text="View" OnClick="btnView_onClick"></asp:Button></td>
    </tr>
</table>
    

<div style="float: right;">
    
</div>
<%if (Suburb != null)
  { %>
<h2 class="title"><%=Suburb.name %></h2>

<%if (Suburb.numPhotos > 0)
  {%>
    <section class="property-slider-outer">
    <!-- PROPERTY SLIDER OUTER -->
        <section id="property-slider">
        <!-- PROPERTY SLIDER -->
            <ul>
                 <%int counter = 1;
                   do
                   {   
                %>
                <li>
                    <img src="<%=REIQ.Helpers.Images.GetSuburbImage(Suburb.sID, counter, 640) %>" alt="" />
                </li>
                <%
                     counter = counter + 1;
                 } while (counter <= Suburb.numPhotos);%>
              </ul>
        </section>
    <!-- /PROPERTY SLIDER -->
    </section>
    <!-- PROPERTY SLIDER OUTER -->
<%} %>

<%--<%if (Suburb.numPhotos > 0)
                                      { %>
                                    <tr>
                                        <td>&nbsp;</td>
                                        <td align="center">
                                            <img name='SlideShow_ART1' src="images/trans.gif" border="0" height="240" />
                                            <br />
                                            <table width="100%">
                                                <tr>
                                                    <td align="left">
                                                        <p id="spnAdd1"></p>
                                                    </td>
                                                    <td>
                                                        <table align="right">
                                                            <tr>
                                                                <td><a href="javascript:PreviousSlide()">
                                                                    <img src="/images/ahc/misc/prev.gif" width="20"></a></td>
                                                                <td><a href="javascript:NextSlide()">
                                                                    <img src="/images/ahc/misc/next.gif" width="20"></a></td>
                                                                <td><a href="javascript:StartSlide()">
                                                                    <img src="/images/ahc/misc/play.gif" width="20"></a></td>
                                                                <td><a href="javascript:StopSlide()">
                                                                    <img src="/images/ahc/misc/stop.gif" width="20"></a></td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>


                                            </table>

                                            <script language="javascript" type="text/javascript">
                                                StartSlide();
                                            </script>
                                        </td>
                                        <td>&nbsp;</td>
                                    </tr>
                                    <%} %>--%>
<%= Suburb.descriptionLong %>
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
For more information go to <a href="http://www.reiq.com/about-us/research-methodology" target="_blank">REIQ Research Methodology</a></p>
                <p>SOURCE: REIQ. Data obtained from RP Data. Enquiries about the reproduction of part or all of the information should be directed to the Corporate Affairs Division, REIQ.</p>
                <p>© The State of Queensland (Department of Natural Resources and Mines) 2014. Based on or contains data provided by the State of Queensland (Department of Natural Resources and Mines) 2014. In consideration of the State permitting use of this data you acknowledge and agree that the State gives no warranty in relation to the data (including accuracy, reliability, completeness, currency or suitability) and accepts no liability (including without limitation, liability in negligence) for any loss, damage or costs (including consequential damage) relating to any use of the data. Data must not be used for direct marketing or be used in breach of the privacy laws.</p>
               <%-- All figures are subject to further revision as more sales data becomes available.<br>
                Where no median is available, insufficient sales were recorded in order to compile a reliable statistic.<br>
                SOURCE: REIQ, Data obtained from PriceFinder.<br>
                <p>Based on or contains data provided by the State of Queensland (Department of Environment and Resource Management) 2012. In consideration of the State permitting use of this data you acknowledge and agree that the State gives no warranty in relation to the data (including accuracy, reliability, completeness, currency or suitability) and accepts no liability (including without limitation, liability in negligence) for any loss, damage or costs (including consequential damage) relating to any use of the data. Data must not be used for direct marketing or be used in breach of the privacy laws.</p>--%>
            </i>
</p>
<%}%>


