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


public partial class usercontrols_GoogleMapsStreet : System.Web.UI.UserControl
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

    public string address = String.Empty;

    #endregion

    #region Page Events

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!String.IsNullOrEmpty(Request.QueryString["pid"]))
            {
                Property = REIQ.Access.Property.GetFromPropertyId(this.PropertyId);
                address = getAddress();
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
        string address = String.Empty;
        if (Property != null)
            address = PropertyHelper.GetGoogleAddress(null, Property.unitNum, Property.rdNum, Property.rdName, Property.rdType, Property.suburb, Property.hideRoadName, Property.hideRoadNum) + "," + Property.state + " " + Property.postcode; 
        return address.Replace("'", " ");
    }

    #endregion
}
