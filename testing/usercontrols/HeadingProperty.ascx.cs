using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class usercontrols_content_header_PropertyHeading : System.Web.UI.UserControl
{
    private int _propertyId;

    public int PropertyId
    {
        get
        {
            if (_propertyId == 0)
                _propertyId = Convert.ToInt32(Request.QueryString["pId"]);
            return _propertyId;
        }
        set { _propertyId = value; }
    }
}