using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class usercontrols_content_header_PropertyHeading : System.Web.UI.UserControl
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

    #endregion

    #region Page Events

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Property = REIQ.Access.Property.GetFromPropertyId(this.PropertyId);
        }
        catch (Exception ex)
        {
            AutoMail.sendErrorMail(ex);
        }
    }

    #endregion

    #region Page Methods

    public string getdisplaysearchfeatures(string numbedroom, string numbathroom, string numcarbay, string numstudy, string haspool, string numgarage)
    {
        string dislayhtml = "";
        int xBed = 0;
        int xBath = 0;
        int xCar = 0;

        if (!String.IsNullOrEmpty(numbedroom))
        {
            if (int.Parse(numbedroom) > 0)
            {
                xBed = 1;
            }
        }

        if (!String.IsNullOrEmpty(numbathroom))
        {
            if (int.Parse(numbathroom) > 0)
            {
                xBath = 1;
            }

        }

        if (!String.IsNullOrEmpty(numcarbay))
        {
            if (int.Parse(numcarbay) > 0)
            {
                xCar = 1;
            }
        }
        if (!String.IsNullOrEmpty(numgarage))
        {
            if (int.Parse(numgarage) > 0)
            {
                xCar = 1;
            }
        }
        if (xBed > 0 || xBath > 0 || xCar > 0)
        {
            dislayhtml = dislayhtml + "<ul class='prop-serv'>";
            int TotalSpace = 0;
            if (!String.IsNullOrEmpty(numbedroom))
            {
                if (int.Parse(numbedroom) > 0)
                {
                    dislayhtml = dislayhtml + "<li><a class='bed'><span class='icons'></span>" + numbedroom + "</a></li>";
                }
            }
            if (!String.IsNullOrEmpty(numbathroom))
            {
                if (int.Parse(numbathroom) > 0)
                {
                    dislayhtml = dislayhtml + "<li><a class='bath'><span class='icons'></span>" + numbathroom + "</a></li>";
                }
            }
            if (!String.IsNullOrEmpty(numcarbay))
            {
                TotalSpace = TotalSpace + int.Parse(numcarbay);

            }
            if (!String.IsNullOrEmpty(numgarage))
            {
                TotalSpace = TotalSpace + int.Parse(numgarage);

            }
            if (TotalSpace > 0)
            {
                dislayhtml = dislayhtml + "<li><a class='parking'><span class='icons'></span>" + TotalSpace + "</a></li>";
            }

            dislayhtml = dislayhtml + "</ul>";
        }
        return dislayhtml;
    }
    #endregion
}