using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class usercontrols_SortBy : REIQ.usercontrols.PropertySearchBase
{
    #region Properties

    protected IEnumerable<int> FoundProperties = null;
    protected int DisplayingFrom = 0;
    protected int DisplayingTo = 0;

    //Pagination variables
    public Int32? PageSize { get; set; }

    #endregion

    #region Page Events

    protected override void OnPreRender(EventArgs e)
    {
        if (!IsPostBack)
        {
            FoundProperties = RetrievePropertyIds();
            if (FoundProperties == null)
            {
                this.Visible = false;
                return;
            }

            ShowDisplayInfo();

            InitSortBox();
        }

        base.OnPreRender(e);
    }

    protected void cboOrder_SelectedIndexChanged(object sender, EventArgs e)
    {
        string searchorderby;
        //search orderby
        if (!String.IsNullOrEmpty(cboOrder.SelectedValue))
        {
            searchorderby = cboOrder.SelectedValue.ToString();
        }
        else
        {
            searchorderby = "status,suburb,pricelow desc";
        }

        String redirectUrl = Request.Url.AbsoluteUri;
        String existingSortVariable = String.Empty;

        //Determine if there is sorting variable defined already
        if (redirectUrl.Contains("&ob="))
        {
            existingSortVariable = redirectUrl.Substring(redirectUrl.IndexOf("&ob="));
            while (existingSortVariable.LastIndexOf("&") > 0)
                existingSortVariable = existingSortVariable.Remove(existingSortVariable.LastIndexOf("&"));
        }

        //If sorting already defined - replace it with new sort
        //Else add sort variable
        if(!String.IsNullOrEmpty(existingSortVariable))
            redirectUrl = redirectUrl.Replace(existingSortVariable, "&ob=" + searchorderby);
        else redirectUrl = redirectUrl + "&ob=" + searchorderby;
            
        Response.Redirect(redirectUrl);
    }

    #endregion

    #region Page Methods

    private void ShowDisplayInfo()
    {
        Int32 pageSize = PageSize == null ? PropertiesPerPage : (Int32)PageSize;

        DisplayingFrom = ((ParamPageNumber - 1) * pageSize) + 1;

        DisplayingTo = DisplayingFrom + pageSize - 1;
        if (!(DisplayingTo < FoundProperties.Count()))
        {
            DisplayingTo = FoundProperties.Count();
        }

        litDispalyInfo.Text = FoundProperties.Count() + " PROPERTIES - DISPLAYING " + DisplayingFrom + " TO " + DisplayingTo;
    }

    private void InitSortBox()
    {
        string searchorderby;
        
        //search orderby
        if (!String.IsNullOrEmpty(Request.QueryString["ob"]))
        {
            searchorderby = Request.QueryString["ob"].ToString();
        }
        else
        {
            searchorderby = "status,suburb,pricelow desc";
        }

        cboOrder.SelectedIndex = cboOrder.Items.IndexOf(cboOrder.Items.FindByValue(searchorderby));
    }

    #endregion
}