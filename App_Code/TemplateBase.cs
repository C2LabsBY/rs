using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for TemplateBase
/// </summary>
public class TemplateBase : System.Web.UI.Page
{
    public T GetTopMaster<T>() where T : MasterPageBase
    {
        var master = this.Master;
        if (master == null)
            return null;

        while (master.Master != null)
        {
            master = master.Master;
        }

        return master as T;
    }

    public void SetBodyClass(string className)
    {
        var topmostMaster = GetTopMaster<MasterPageBase>();
        if (topmostMaster != null)
        {
            topmostMaster.BodyClassName = className;
        }
    }
}