using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class usercontrols_Paging : REIQ.usercontrols.PropertySearchBase
{ 
    #region Properties

    protected int AgentId
    {
        get
        {
            if (_agentId == 0)
            {
                Int32.TryParse(Request.QueryString["aid"], out _agentId);
            }
            return _agentId;
        }
        set { _agentId = value; }
    }
    private int _agentId;

    //Pagination variables
    public Int32 PageSize { get; set; }
    
    //Determines if we overrided default PropertiesPerPage param with PageSize
    private Int32 pageSizeOverride
    {
        get {return PageSize == null ? PropertiesPerPage : (Int32)PageSize; }
    }

    protected IEnumerable<int> FoundProperties = null;
    public string aid, agentImageURL;
    public int ItemsExist;
    public string page, paging;
    public int startNo, endNo, CurrentPage, noOfProp;
    public double x;
    public int noOfProps = 0;
    public string Fpid = "";

    #endregion

    #region Page Events

    protected override void OnPreRender(EventArgs e)
    {
        FoundProperties = RetrievePropertyIds();
        
        if (FoundProperties == null)
        {
            this.Visible = false;
            return;
        }

        // Populate the PagedDataSource with the Items DataSet
        // needed for determining 1st and last pages
        PagedDataSource objPds = new PagedDataSource();
        objPds.DataSource = FoundProperties.ToList();
        objPds.AllowPaging = true;

        // Set the number of items you wish to display per page
        objPds.PageSize = pageSizeOverride;

        //Set Current Page index
        CurrentPage = ParamPageNumber - 1;
        objPds.CurrentPageIndex = CurrentPage;
       
        noOfProp = FoundProperties.Count();

        paging = "";

        //call the paging
        x = noOfProp / double.Parse(pageSizeOverride.ToString());
        double NoOfPage = (Math.Ceiling(x));
        int maxpage = 0;
        int m = 1;
        if (noOfProp > 100)
        {
            if (ParamPageNumber >= 10)
            {
                m = ParamPageNumber - 5;
            }
        }

        String currentUrl = Request.Url.AbsoluteUri;
        if (currentUrl.Contains("&p="))
        {
            //If there is something in QueryString after "&p=" - we need to make sure we remove it from QuesryString
            if (currentUrl.IndexOf("&p=") < currentUrl.LastIndexOf('&'))
            {
                String pageQuesryString = currentUrl.Substring(currentUrl.IndexOf("&p="), (currentUrl.LastIndexOf('&') - currentUrl.IndexOf("&p=")));
                currentUrl = currentUrl.Replace(pageQuesryString, "");
            }
            else currentUrl = currentUrl.Remove(currentUrl.IndexOf("&p="));
        }

        for (m = m; m <= NoOfPage && maxpage < 14; m++)
        {
            if (ParamPageNumber == m) // if it is the current page then dont make it into a link
                paging = paging + "<li><a href='javascript:void(0)' class='active'>" + m + "</a></li>";
            else// make it as a link
                paging = paging + "<li><a href='" + currentUrl + "&p=" + m + "'>" + m + "</a></li>";

            maxpage = maxpage + 1;
        }

        if (NoOfPage == 1)
        {
            paging = "";
        }

        //Next/back links code
        bool isShowNextLink = false;
        bool isShowBackLink = false;

        if (noOfProp > pageSizeOverride)
        {
            if (objPds.IsFirstPage)
                isShowNextLink = true;
            else
                isShowNextLink = !objPds.IsLastPage;
        }

        isShowBackLink = !objPds.IsFirstPage;

        if (isShowNextLink)
            litNextLink.Text = "<li><a href='" + currentUrl + "&p=" + (ParamPageNumber + 1) + "'> Next <span class='icons next'></span> </a></li>";
        else
            //What an UGLY hack - needs to show first page li element appropriate
            //Decided to leave that for future refactoring// Robert
            litNextLink.Text = "<li class='last' style='display:none;'></li>";

        if (isShowBackLink)
            litBackLink.Text = "<li class='first'><a href='" + currentUrl + "&p=" + (ParamPageNumber - 1) + "'> <span class='icons prev'></span> Back</a></li>";
        else
            //What an UGLY hack - needs to show first page li element appropriate
            //Decided to leave that for future refactoring// Robert
            litBackLink.Text = "<li class='first' style='display:none;'></li>";

        base.OnPreRender(e);
    }

    #endregion
}