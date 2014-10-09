using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace REIQ.usercontrols
{
    /// <summary>
    /// Summary description for AgencyBase
    /// </summary>
    public class AgencyBase : System.Web.UI.UserControl
    {
        private int _agencyId;

        public int AgencyId
        {
            get
            {
                if (_agencyId == 0)
                    _agencyId = Convert.ToInt32(Request.QueryString["acId"]);
                return _agencyId;
            }
            set { _agencyId = value; }
        }
    }

}