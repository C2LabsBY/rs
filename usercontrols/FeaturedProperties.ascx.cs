using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using REIQ.Helpers;

public partial class usercontrols_FeaturedProperties : REIQ.usercontrols.PropertySearchBase
{
    #region Properties

    protected IEnumerable<int> FoundProperties = null;
    protected List<REIQ.Entities.Property> FinalList = new List<REIQ.Entities.Property>();
    #endregion

    #region Page Events

    protected override void OnPreRender(EventArgs e)
    {
        if (!IsPostBack)
        {
            //Does not show Featured Properties for Agency
            if (ParamAgencyId > 0)
            {
                this.Visible = false;
                return;
            }

            FoundProperties = RetrievePropertyIds();
            if (FoundProperties == null)
            {
                this.Visible = false;
                return;
            }

            //Try to Determine current Suburb
            REIQ.Entities.Suburb suburb = REIQ.Access.Suburb.TryGetSuburbFromSearchString(ResetKeywordIfDefault(ParamKeyword).Trim());

            //If we could not take suburb from search string then
            //get first available suburb from Search Results
            if (suburb == null)
            {
                foreach (Int32 propertyId in FoundProperties.Take(20))
                {
                    suburb = REIQ.Access.Suburb.GetFromPropertyId(propertyId);
                    if (suburb != null) break;
                }
            }

            if (suburb != null)
            {
                //Get data from TopSpot table based on suburb info
                List<REIQ.Entities.topspot> topspots = REIQ.Access.TopSpot.Select(suburb.name, GetCategoryParam(), suburb.postcode == null ? String.Empty : suburb.postcode.ToString(), DateTime.Now.ToString("yyyy/MM/dd"), DateTime.Now.ToString("yyyy/MM/dd"));

                //TopSpot
                if (topspots.Count() > 0)
                {
                    //I guess we need to get two topspots and get 1 property per topspot... So...
                    List<REIQ.Entities.topspot> chosenTopspots = new List<REIQ.Entities.topspot>();

                    if (topspots.Count() == 1)//We have only one TopSpot booked - so just get properties for that topspot
                    {
                        chosenTopspots.Add(topspots.First());
                        chosenTopspots.Add(topspots.First());
                    }
                    else//If we have many TopSpots - take random two
                    {
                        Random RandomClass = new Random();
                        int rndNo1 = RandomClass.Next(topspots.Count());
                        int rndNo2 = RandomClass.Next(topspots.Count());

                        while (rndNo1 == rndNo2)
                        {
                            rndNo2 = RandomClass.Next(topspots.Count());
                        }

                        chosenTopspots.Add(topspots.ToList()[rndNo1]);
                        chosenTopspots.Add(topspots.ToList()[rndNo2]);
                    }

                    foreach (REIQ.Entities.topspot topspot in chosenTopspots)
                    {

                        //Get all closest suburbs
                        IEnumerable<KeyValuePair<String, String>> surroundingSuburbs = REIQ.Access.Suburb.ListSurroundingSuburbs(suburb.name, suburb.postcode == null ? 0 : (Int32)suburb.postcode);

                        List<String> searchsuburbs = new List<string>();
                        List<String> searchpostcode = new List<string>();

                        //Forming list of surroundining suburbs and postcodes
                        foreach (KeyValuePair<String, String> surroundingSuburb in surroundingSuburbs)
                        {
                            if (!searchsuburbs.Contains(surroundingSuburb.Key))
                                searchsuburbs.Add(surroundingSuburb.Key);
                            if (!searchpostcode.Contains(surroundingSuburb.Value) && !String.IsNullOrEmpty(surroundingSuburb.Value))
                                searchpostcode.Add(surroundingSuburb.Value);
                        }
                        //Adding current chosen suburb postcode and name to params
                        if (!searchsuburbs.Contains(suburb.name))
                            searchsuburbs.Add(suburb.name);
                        string currentSuburbPostcode = suburb.postcode == null ? String.Empty : suburb.postcode.ToString();
                        if (!searchpostcode.Contains(currentSuburbPostcode) && !String.IsNullOrEmpty(currentSuburbPostcode))
                            searchpostcode.Add(currentSuburbPostcode);

                        string status = "sa";
                        List<String> type = new List<string>();

                        if (topspot.category == "residentialsales")
                        {
                            status = "sa";
                            type.AddRange(new List<string>() { "Acreage/Rural", "Apartment/Unit", "Block of Units", "House", "land", "Townhouse/Villa" });
                        }
                        else if (topspot.category == "residentialrentals")
                        {
                            status = "ra";
                            type.AddRange(new List<string>() { "Acreage/Rural", "Apartment/Unit", "Block of Units", "House", "land", "Townhouse/Villa" });
                        }
                        else if (topspot.category == "commercialsales")
                        {
                            status = "sa";
                            type.AddRange(new List<string>() { "Commercial" });
                        }
                        else if (topspot.category == "commercialrentals")
                        {
                            status = "ra";
                            type.AddRange(new List<string>() { "Commercial" });
                        }
                        else if (topspot.category == "businesssales")
                        {
                            status = "sa";
                            type.AddRange(new List<string>() { "Business" });
                        }
                        else if (topspot.category == "ruralsales")
                        {
                            status = "sa";
                            type.AddRange(new List<string>() { "Acreage/Rural" });
                        }

                        IEnumerable<REIQ.Entities.Property> resultList = new List<REIQ.Entities.Property>();

                        if (topspot.options == "pid")
                        {
                            resultList = REIQ.Access.Property.GetFeaturedProperties(topspot.acid.ToString(), status, searchsuburbs, searchpostcode, String.Empty, topspot.optionsPid == null ? String.Empty : topspot.optionsPid.ToString(), type);
                        }
                        else if (topspot.options == "agent")
                        {
                            resultList = REIQ.Access.Property.GetFeaturedProperties(topspot.acid.ToString(), status, searchsuburbs, searchpostcode, topspot.optionsAid == null ? String.Empty : topspot.optionsAid.ToString(), String.Empty, type);
                        }
                        else if (topspot.options == "office")
                        {
                            resultList = REIQ.Access.Property.GetFeaturedProperties(topspot.acid.ToString(), status, searchsuburbs, searchpostcode, String.Empty, String.Empty, type);
                        }

                        if (resultList.Count() > 0)
                        {
                            //If we have 1 property - then just show it
                            //Else take random property from list
                            if (resultList.Count() == 1)
                            {
                                if (!FinalList.Contains(resultList.First()))
                                    FinalList.Add(resultList.First());
                            }
                            else
                            {
                                Random RandomClass = new Random();
                                int rndNo1 = RandomClass.Next(resultList.Count());

                                while (FinalList.Any(s => s.pID == resultList.ToList()[rndNo1].pID))
                                {
                                    rndNo1 = RandomClass.Next(resultList.Count());
                                }

                                FinalList.Add(resultList.ToList()[rndNo1]);
                            }
                        }
                    }
                    rptProperties.DataSource = FinalList;
                    rptProperties.DataBind();
                }
            }
        }
        base.OnPreRender(e);
    }

    protected void rptProperties_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            REIQ.Entities.Property property = (REIQ.Entities.Property)e.Item.DataItem;

            //Label lblPrice = e.Item.FindControl("lblPrice") as Label;
            Literal litAgencyImage = e.Item.FindControl("litAgencyImage") as Literal;

            //if (property.pricetext == "0$" || String.IsNullOrEmpty(property.pricetext))
            //    lblPrice.Text = "N/A";
            //else lblPrice.Text = HttpUtility.HtmlDecode(property.pricetext).ToUpper();

            if (property.acID > 0)
            {
                REIQ.Entities.Agency agency = REIQ.Access.Agency.GetFromPropertyId(property.pID);
                litAgencyImage.Text = "<a href='/" + REIQ.Helpers.PropertyHelper.GenerateURLAgency(agency.name.ToString(), property.suburb.ToString(), property.acID) + "'><img src=" + Images.GetAgencyImage(property.acID, 150, 50) + " class='agent-logo'/></a>";
            }
            REIQ.Entities.Agent agent = REIQ.Access.Agent.GetFromPropertyId(property.pID);

            if (agent != null)
            {
                Literal litAgentName = e.Item.FindControl("litAgentName") as Literal;
                Literal litAgentPhone = e.Item.FindControl("litAgentPhone") as Literal;
                litAgentName.Text = "<span class='agent-name'>" + (agent.firstname + " " + agent.surname).ToUpper() + "</span><br />";
                litAgentPhone.Text = "<span class='agent-pg'>" + AgentHelper.GetAgentPhoneWithLog(agent) + "</span>";//"<span class='agent-pg'>" + agent.phone + "</span>";
            }

            //Showing New span
            Literal ltlNew = e.Item.FindControl("ltlNew") as Literal;
            if(REIQ.Helpers.PropertyHelper.isNewlyAdded(property.dateListed))
                ltlNew.Text = "<span class='new-label'></span>";
        }
    }

    #endregion

    #region Page Methods

    string GetCategoryParam()
    {
        if (Request.QueryString["st"] == "fr" || Request.QueryString["st"] == "ra")
            return "residentialrentals";
        else if (Request.QueryString["st"] == "co")
            return "commercialsales";
        else if (Request.QueryString["st"] == "cr")
            return "commercialrentals";
        else if (Request.QueryString["st"] == "bu")
            return "businesssales";
        else if (Request.QueryString["st"] == "ru")
            return "ruralsales";
        else
            return "residentialsales";
    }

    protected string getSectionClass(object item)
    {
        if((REIQ.Entities.Property)item == FinalList.First())
            return "featured-property-block clearfix";
        else return "featured-property-block featured-property-block-right clearfix";
    }
    protected string getPriceText(object item)
    {
        REIQ.Entities.Property property = (REIQ.Entities.Property)item;

        return PropertyHelper.GetPropertyPrice(property);
    }

    private string ResetKeywordIfDefault(string keyword)
    {
        if (string.IsNullOrEmpty(keyword) || ParamKeyword.Trim().Equals(REIQ.usercontrols.PropertySearchBase.DefaultSearchText, StringComparison.CurrentCultureIgnoreCase))
        {
            return "";
        }
        return ParamKeyword;
    }


    #endregion
}