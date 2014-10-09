using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for MasterPageBase
/// </summary>
public class MasterPageBase : System.Web.UI.MasterPage
{
    /// <summary>
    /// Set a class name for the body so we can have different styles/behaviours depending on the type of page
    /// </summary>
    public string BodyClassName
    {
        get;
        set;
    }
}