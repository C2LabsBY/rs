using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class usercontrols_SideBarPropertyTopControl : System.Web.UI.UserControl
{
    /// <summary>
    /// Id of the property we want to find the agent for.  Comes from the querystring
    /// </summary>
    //protected int PropertyId
    //{
    //    get
    //    {
    //        if (_propertyId == 0)
    //        {
    //            Int32.TryParse(Request.QueryString["pID"], out _propertyId);
    //        }
    //        return _propertyId;
    //    }
    //    set { _propertyId = value; }
    //}
    //private int _propertyId;

    ///// <summary>
    ///// The Agent of the property
    ///// </summary>
    //protected REIQ.Entities.Agent Agent { get; set; }

    ///// <summary>
    ///// The Agency of the property
    ///// </summary>
    //protected REIQ.Entities.Agency Agency { get; set; }

    protected override void OnLoad(EventArgs e)
    {
        //Agent = REIQ.Access.Agent.GetFromPropertyId(this.PropertyId);
        //Agency = REIQ.Access.Agency.GetFromPropertyId(this.PropertyId);


        //base.OnLoad(e);
    }
}