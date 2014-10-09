using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class usercontrols_SearchForm_EbeddableAsMacro : REIQ.usercontrols.PropertySearchBase
{
    #region Page Events
    /// <summary>
    /// Where the search form should submit to (i.e. the search results page URL)
    /// </summary>
    public string Target = "/results/";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["nomatches"] == "1")
            Response.Write("<script>alert('Please type in correct suburb, postcode, region or property ID to begin your search');</script>");

        if (!IsPostBack)
        {
            ////IEnumerable<String> types = REIQ.Access.Lookups.ListPropertyTypes();
            ////foreach(var type in types)
            //ListItemCollection coll = new ListItemCollection();
            //foreach(String type in REIQ.Access.Lookups.ListPropertyTypes())
            //{
            //    coll.Add(new ListItem(type));
            //}
            //chblType.DataSource = coll;
            //chblType.DataBind();

            //tbSearch_Buy.Text = REIQ.usercontrols.PropertySearchBase.DefaultSearchText;
            //tbSearch_Buy.Attributes.Add("onfocus", "if(this.value=='"+  REIQ.usercontrols.PropertySearchBase.DefaultSearchText +"')this.value='';");
            //tbSearch_Buy.Attributes.Add("onblur", "if(this.value=='')this.value='"+ REIQ.usercontrols.PropertySearchBase.DefaultSearchText +"';");
        }
    }

    #endregion
    //protected void btnSearch_BuyTab_Click(object sender, EventArgs e)
    //{
    //    String redirectString = Target + "?st=sa";

    //    redirectString += "&txt=" + tbSearch_Buy.Text;

    //    // Iterate through the Items collection of the CheckBoxList 
    //    // control and display the selected items.
    //    for (int i = 0; i < chblType.Items.Count; i++)
    //    {
    //        if (chblType.Items[i].Selected)
    //            redirectString += "&ty=" + chblType.Items[i].Text;
    //    }

    //    Response.Redirect(redirectString);
    //}
}