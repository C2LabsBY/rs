using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using REIQ.Helpers;


public partial class usercontrols_Gmap : System.Web.UI.UserControl
{
    #region Properties

    /// <summary>
    /// Id of the property we want to find the agent for.  Comes from the querystring
    /// </summary>
    protected int PropertyId
    {
        get
        {
            if (_propertyId == 0)
            {
                Int32.TryParse(Request.QueryString["pID"], out _propertyId);
            }
            return _propertyId;
        }
        set { _propertyId = value; }
    }
    private int _propertyId;

    /// <summary>
    /// The Agent of the property
    /// </summary>
    protected REIQ.Entities.Property Property { get; set; }

    public string strLoadMap;
    public string strJTable;
    public string daddress;

    #endregion

    #region Page Events

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!String.IsNullOrEmpty(Request.QueryString["pid"]))
            {
                Property = REIQ.Access.Property.GetFromPropertyId(this.PropertyId);

                if (Property != null)
                {
                    string gaddress = PropertyHelper.GetGoogleAddress(null, Property.unitNum, Property.rdNum, Property.rdName, Property.rdType, Property.suburb, Property.hideRoadName, Property.hideRoadNum) + "," + Property.state + " " + Property.postcode; ;

                    daddress = gaddress.Replace(" ", "+");
                    daddress = daddress.Replace(",", "+");
                    if (gaddress.Contains("'"))
                    {
                        daddress = Property.suburb + "," + Property.state + " " + Property.postcode;
                    }
                    else
                    {
                        daddress = gaddress;
                    }

                    strLoadMap = strLoadMap + Environment.NewLine + "function load(){";

                    strLoadMap = strLoadMap + Environment.NewLine + "var mapOptions = {";
                    strLoadMap = strLoadMap + Environment.NewLine + "zoom: 13,";
                    strLoadMap = strLoadMap + Environment.NewLine + "overviewMapControl: true,";
                    strLoadMap = strLoadMap + Environment.NewLine + "overviewMapControlOptions:{opened:true},";
                    strLoadMap = strLoadMap + Environment.NewLine + "mapTypeId: google.maps.MapTypeId.ROADMAP,";
                    strLoadMap = strLoadMap + Environment.NewLine + "scaleControl: true";
                    strLoadMap = strLoadMap + Environment.NewLine + "};";

                    strLoadMap = strLoadMap + Environment.NewLine + "map = new google.maps.Map(document.getElementById('map'), mapOptions);";
                    //strLoadMap = strLoadMap + Environment.NewLine + "map.setCenter(new google.maps.LatLng(-19.7061, 145.774002), 13);";
                    strLoadMap = strLoadMap + Environment.NewLine + "geocoder = new google.maps.Geocoder();";
                    strLoadMap = strLoadMap + Environment.NewLine + "var strTable = ''";
                    if (gaddress.Contains("'"))
                    {
                        strLoadMap = strLoadMap + Environment.NewLine + "strTable = '<table border=0 celllpadding=0 cellspacing=0><tr><td valign=top>" + Property.suburb + "," + Property.state + " " + Property.postcode + "</td></tr>';";
                    }
                    else
                    {
                        strLoadMap = strLoadMap + Environment.NewLine + "strTable = '<table border=0 celllpadding=0 cellspacing=0><tr><td valign=top>" + gaddress + "</td></tr>';";
                    }
                    //strLoadMap = strLoadMap + Environment.NewLine + "strTable = strTable + '<tr><td>Directions <a href=javascript:myShow1();javascript:myHide1();>To here</a>  | <a href=javascript:myShow2();javascript:myHide2();>From here</a></td></tr></table>';";
                    //strLoadMap = strLoadMap + Environment.NewLine + "strTable = strTable + '<table border=0 celllpadding=0 cellspacing=0 height=50><tr><td height=5></td></tr><tr><td valign=top id=tohere STYLE=display:none;>Enter your start point<br><input name=txtfrom id=txtfrom type=text ><input type=button onclick=javascript:openFrom() name=btnGo1 value=Go></td></tr>';";
                    //strLoadMap = strLoadMap + Environment.NewLine + "strTable = strTable + '<tr><td id=fromhere STYLE=display:none;>End address<br><input name=txtto id=txtto type=text ><input type=button onclick=javascript:openTo() name=btnGo2 value=Go></td></tr>';";
                    strLoadMap = strLoadMap + Environment.NewLine + "strTable = strTable + '</table>';";
                    if (gaddress.Contains("'"))
                    {
                        strLoadMap = strLoadMap + Environment.NewLine + "showAddress('" + Property.suburb + "," + Property.state + " " + Property.postcode + "', strTable);";
                    }
                    else
                    {
                        strLoadMap = strLoadMap + Environment.NewLine + "showAddress('" + gaddress + "', strTable);";
                    }
                    strLoadMap = strLoadMap + Environment.NewLine + "}";
                }
            }
            if (!String.IsNullOrEmpty(Request.QueryString["add"]))
            {
                daddress = ConfigurationManager.AppSettings["companyaddress"];
                daddress = daddress.Replace(",", "+");

                strLoadMap = strLoadMap + Environment.NewLine + "function load(){";

                strLoadMap = strLoadMap + Environment.NewLine + "var mapOptions = {";
                strLoadMap = strLoadMap + Environment.NewLine + "zoom: 13,";
                strLoadMap = strLoadMap + Environment.NewLine + "overviewMapControl: true,";
                strLoadMap = strLoadMap + Environment.NewLine + "overviewMapControlOptions:{opened:true},";
                strLoadMap = strLoadMap + Environment.NewLine + "mapTypeId: google.maps.MapTypeId.ROADMAP,";
                strLoadMap = strLoadMap + Environment.NewLine + "scaleControl: true";
                strLoadMap = strLoadMap + Environment.NewLine + "};";

                strLoadMap = strLoadMap + Environment.NewLine + "map = new google.maps.Map(document.getElementById('map'), mapOptions);";
                //strLoadMap = strLoadMap + Environment.NewLine + "map.setCenter(new google.maps.LatLng(-19.7061,145.774002), 13);";
                strLoadMap = strLoadMap + Environment.NewLine + "geocoder = new google.maps.Geocoder();";
                strLoadMap = strLoadMap + Environment.NewLine + "var strTable = ''";
                strLoadMap = strLoadMap + Environment.NewLine + "strTable = '<table border=0 celllpadding=0 cellspacing=0><tr><td valign=top>" + ConfigurationManager.AppSettings["companyaddress"] + "</td></tr>';";
                //strLoadMap = strLoadMap + Environment.NewLine + "strTable = strTable + '<tr><td>Directions <a href=javascript:myShow1();javascript:myHide1();>To here</a>  | <a href=javascript:myShow2();javascript:myHide2();>From here</a></td></tr></table>';";
                //strLoadMap = strLoadMap + Environment.NewLine + "strTable = strTable + '<table border=0 celllpadding=0 cellspacing=0 height=50><tr><td height=5></td></tr><tr><td valign=top id=tohere STYLE=display:none;>Enter your start point<br><input name=txtfrom id=txtfrom type=text ><input type=button onclick=javascript:openFrom() name=btnGo1 value=Go></td></tr>';";
                //strLoadMap = strLoadMap + Environment.NewLine + "strTable = strTable + '<tr><td id=fromhere STYLE=display:none;>End address<br><input name=txtto id=txtto type=text ><input type=button onclick=javascript:openTo() name=btnGo2 value=Go></td></tr>';";
                strLoadMap = strLoadMap + Environment.NewLine + "strTable = strTable + '</table>';";
                strLoadMap = strLoadMap + Environment.NewLine + "showAddress('" + ConfigurationManager.AppSettings["companyaddress"] + "', strTable);";
                strLoadMap = strLoadMap + Environment.NewLine + "}";
            }
        }
        catch (Exception ex)
        {
            AutoMail.sendErrorMail(ex);
        }
    }

    #endregion

    #region Page Methods

    protected string getAddress()
    {
        string address = "";
        if (Property != null)
        {
            if (!Property.hideRoadName)
            {
                if (!String.IsNullOrEmpty(Property.rdNum))
                {
                    address = address + Property.rdNum + " ";
                }
                if (!String.IsNullOrEmpty(Property.rdName))
                {
                    address = address + Property.rdName + " ";
                }
                if (!String.IsNullOrEmpty(Property.rdType))
                {
                    address = address + Property.rdType;
                }
                if (!String.IsNullOrEmpty(Property.unitNum))
                {
                    address = "Unit " + Property.unitNum + "/" + address;
                }
                if (!String.IsNullOrEmpty(Property.name))
                {
                    address = Property.name + "<br>" + address;
                }
                if (!String.IsNullOrEmpty(Property.suburb))
                {
                    if (!String.IsNullOrEmpty(address))
                    {
                        address = Property.suburb + ", " + address;
                    }
                    else
                    {
                        address = Property.suburb;
                    }
                }

            }
            else
            {
                if (!String.IsNullOrEmpty(Property.suburb))
                {
                    address = Property.suburb;
                }
            }
        }
        return address;
    }

    #endregion
}
