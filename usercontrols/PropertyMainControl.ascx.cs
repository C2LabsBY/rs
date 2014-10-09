using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using REIQ.Helpers;

public partial class usercontrols_PropertyMainControl : System.Web.UI.UserControl
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
    /// The Property itself
    /// </summary>
    protected REIQ.Entities.Property Property { get; set; }

    #endregion

    #region Page Events

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            //Property = REIQ.Access.Property.GetFromPropertyId(this.PropertyId);
            Property = REIQ.Access.Property.GetAnyFromPropertyId(this.PropertyId);
            
            //Log page view
            if (Property != null && !IsPostBack)
            {
                LogHelper.EditPublicLog(Property.pID.ToString(), Property.acID.ToString());
                //cheking if property is hidden for some reason and make redirection in that case
                REIQ.Helpers.PropertyHelper.CheckIfHidden(Property);
            }
        }
        catch (System.Threading.ThreadAbortException)
        {

        }
        catch (Exception ex)
        {
            AutoMail.sendErrorMail(ex);
        }
    }

    #endregion

    #region Page Methods

    protected string getAvailableFrom(bool isavailablenow1, DateTime? dtAvailableFrom)
    {
        string strDate = "";

        if (isavailablenow1)
        {
            strDate = "<strong>Available now</strong>";
        }
        else if (dtAvailableFrom > Convert.ToDateTime("0001/01/01") && dtAvailableFrom != null)
        {
            if (dtAvailableFrom <= Convert.ToDateTime(DateTime.Now.Year.ToString() + "/" + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Day.ToString()))
            {
                strDate = "<strong>Available now</strong>";
            }
            else
            {
                strDate = "<strong>Date available: " + String.Format("{0:dddd, dd MMMM yyyy}", dtAvailableFrom) + "</strong>";
            }
        }

        return strDate;
    }

    protected string getRates(string strWater, string strCouncil, string strStrata)
    {
        string ratet = "";
        if (!String.IsNullOrEmpty(strCouncil) && decimal.Parse(strCouncil) > 0)
        {
            ratet = ratet + "Council Rates: " + decimal.Parse(strCouncil).ToString("$#,##0") + "/qtr, ";
        }
        if (!String.IsNullOrEmpty(strWater) && decimal.Parse(strWater) > 0)
        {
            ratet = ratet + "Water Rates: " + decimal.Parse(strWater).ToString("$#,##0") + "/qtr, ";
        }
        if (!String.IsNullOrEmpty(strStrata) && decimal.Parse(strStrata) > 0)
        {
            ratet = ratet + "Strata Levies: " + decimal.Parse(strStrata).ToString("$#,##0") + "/qtr";
        }

        if (!String.IsNullOrEmpty(ratet))
        {
            ratet = "<br>" + ratet;
        }
        return ratet;
    }

    protected string showMoreInfo()
    {
        string morefeaturesdisplay = string.Empty;
        if (Property != null)
        {
            int landCounter = 0;
            int parkingCounter = 0;
            //int strTotalSpace = 0;
            int ExternalCounter = 0;
            int devCounter = 0;
            int InternalCounter = 0;
            int featureCounter = 0;
            //string moreDescription;

            if (Property.lotSize != null)
            {
                if (Property.lotSize > 0)
                    landCounter = landCounter + 1;
            }
            if (!String.IsNullOrEmpty(Property.zoning))
                landCounter = landCounter + 1;
            if (!String.IsNullOrEmpty(Property.lotOrientation))
                landCounter = landCounter + 1;
            if (!String.IsNullOrEmpty(Property.lotFrontage))
                landCounter = landCounter + 1;

            if (Property.numCarbays != null)
            {
                if (Property.numCarbays > 0)
                    parkingCounter = parkingCounter + 1;
            }
            if (Property.numGarage != null)
            {
                if (Property.numGarage > 0)
                    parkingCounter = parkingCounter + 1;
            }

            if (Property.hasOutdoorEnt)
                ExternalCounter = ExternalCounter + 1;
            if (Property.hasReticulation)
                ExternalCounter = ExternalCounter + 1;
            if (Property.hasBore)
                ExternalCounter = ExternalCounter + 1;
            if (Property.isFIRB)
                ExternalCounter = ExternalCounter + 1;
            if (Property.hasGardenShed)
                ExternalCounter = ExternalCounter + 1;
            if (Property.hasPool)
                ExternalCounter = ExternalCounter + 1;
            if (Property.hasCourtyard)
                ExternalCounter = ExternalCounter + 1;
            if (Property.numBalcony != null)
            {
                if (Property.numBalcony > 0)
                    ExternalCounter = ExternalCounter + 1;
            }
            if (Property.sqmExternal != null)
            {
                if (Property.sqmExternal > 0)
                    ExternalCounter = ExternalCounter + 1;
            }
            if (!String.IsNullOrEmpty(Property.stage))
                devCounter = devCounter + 1;
            if (Property.numBalcony != null)
            {
                if (Property.numBalcony > 0)
                    devCounter = devCounter + 1;
            }
            if (!String.IsNullOrEmpty(Property.unitLevel))
                devCounter = devCounter + 1;
            if (Property.hasLift)
                devCounter = devCounter + 1;
            if (Property.hasGym)
                devCounter = devCounter + 1;
            if (Property.hasSpa)
                devCounter = devCounter + 1;
            if (Property.hasManager)
                devCounter = devCounter + 1;
            if (Property.hasDoorman)
                devCounter = devCounter + 1;

            if (Property.numStudy != null)
            {
                if (Property.numStudy > 0)
                    InternalCounter = InternalCounter + 1;
            }
            if (Property.numWC != null)
            {
                if (Property.numWC > 0)
                    InternalCounter = InternalCounter + 1;
            }
            if (!String.IsNullOrEmpty(Property.heatingType))
                InternalCounter = InternalCounter + 1;
            if (!String.IsNullOrEmpty(Property.coolingtype))
                InternalCounter = InternalCounter + 1;
            if (Property.hasSecuritySystem)
                InternalCounter = InternalCounter + 1;
            if (Property.hasHouseAlarm)
                InternalCounter = InternalCounter + 1;
            if (Property.hasRoomDining)
                InternalCounter = InternalCounter + 1;
            if (Property.hasRoomLiving)
                InternalCounter = InternalCounter + 1;
            if (Property.hasVaccumSystem != null)
            {
                if ((bool)Property.hasVaccumSystem)
                    InternalCounter = InternalCounter + 1;
            }
            if (Property.hasRoomGames)
                InternalCounter = InternalCounter + 1;
            if (Property.hasRoomFamily)
                InternalCounter = InternalCounter + 1;
            if (Property.sqmInternal != null)
            {
                if (Property.sqmInternal > 0)
                    InternalCounter = InternalCounter + 1;
            }

            // more features display code
            featureCounter = landCounter + parkingCounter + ExternalCounter + devCounter + InternalCounter;
            if (featureCounter > 0)
            {
                if (landCounter > 0)
                {
                    morefeaturesdisplay = morefeaturesdisplay + "<h3>Land</h3>";
                    morefeaturesdisplay = morefeaturesdisplay + "<ul class='right-sign'>";
										if (Property.lotSize != null)
										{
											if (Property.lotSize > 0)
												morefeaturesdisplay = morefeaturesdisplay + "<li>" + PropertyHelper.GetLotSizeFormatted(Property.lotSize.Value) + " " + Property.lotMeasurement + "</li>";
										}
                    if (!String.IsNullOrEmpty(Property.lotFrontage))
                    {
                        morefeaturesdisplay = morefeaturesdisplay + "<li>" + Property.lotFrontage + "M Frontage</li>";
                    }
                    if (!String.IsNullOrEmpty(Property.lotOrientation))
                    {
                        morefeaturesdisplay = morefeaturesdisplay + "<li>" + Property.lotOrientation + " Orientation</li>";
                    }

                    if (!String.IsNullOrEmpty(Property.zoning))
                    {
                        morefeaturesdisplay = morefeaturesdisplay + "<li>Zoning: " + Property.zoning + "</li>";
                    }
                    morefeaturesdisplay = morefeaturesdisplay + "</ul>";
                }
                if (parkingCounter > 0)
                {
                    morefeaturesdisplay = morefeaturesdisplay + "<h3>Parking</h3>";
                    morefeaturesdisplay = morefeaturesdisplay + "<ul class='right-sign'>";
                    if (Property.numCarbays != null)
                    {
                        if (Property.numCarbays > 0)
                            morefeaturesdisplay = morefeaturesdisplay + "<li>" + Property.numCarbays + " Car Bays</li>";
                    }
                    if (Property.hasParkingExposed != null)
                    {
                        if ((bool)Property.hasParkingExposed)
                            morefeaturesdisplay = morefeaturesdisplay + "<li>Exposed</li>";
                    }

                    if (Property.numGarage != null)
                    {
                        if (Property.numGarage > 0)
                            morefeaturesdisplay = morefeaturesdisplay + "<li>" + Property.numGarage + " Lock-Up Garage</li>";
                    }
                    if (Property.hasGarageRemote)
                    {
                        morefeaturesdisplay = morefeaturesdisplay + "<li>Remote</li>";
                    }
                    if (Property.hasSecureCarPark != null)
                    {
                        if ((bool)Property.hasSecureCarPark)
                            morefeaturesdisplay = morefeaturesdisplay + "<li>Secure</li>";
                    }
                    morefeaturesdisplay = morefeaturesdisplay + "</ul>";
                }
                if (ExternalCounter > 0)
                {
                    morefeaturesdisplay = morefeaturesdisplay + "<h3>Externals</h3>";
                    morefeaturesdisplay = morefeaturesdisplay + "<ul class='right-sign'>";
                    if (Property.hasOutdoorEnt)
                    {
                        morefeaturesdisplay = morefeaturesdisplay + "<li>Outdoor Entertainment</li>";
                    }
                    if (Property.hasReticulation)
                    {
                        morefeaturesdisplay = morefeaturesdisplay + "<li>Reticulation</li>";
                    }
                    if (Property.sqmExternal != null)
                    {
                        if (Property.sqmExternal > 0)
                            morefeaturesdisplay = morefeaturesdisplay + "<li>Ext. Area " + Property.sqmExternal + "&nbsp;sqm</li>";
                    }
                    morefeaturesdisplay = morefeaturesdisplay + "</tr><tR >";
                    if (Property.hasCourtyard)
                    {
                        morefeaturesdisplay = morefeaturesdisplay + "<li>Courtyard</li>";
                    }
                    if (Property.hasBore)
                    {
                        morefeaturesdisplay = morefeaturesdisplay + "<li>Bore</li>";
                    }
                    if (Property.isFIRB)
                    {
                        morefeaturesdisplay = morefeaturesdisplay + "<li>Firb</li>";
                    }
                    if (Property.numBalcony != null)
                    {
                        if (Property.numBalcony > 0)
                            morefeaturesdisplay = morefeaturesdisplay + "<li>" + Property.numBalcony + "&nbsp;Balcony(s)</li>";
                    }
                    if (Property.hasPool)
                    {
                        morefeaturesdisplay = morefeaturesdisplay + "<li>Pool</li>";
                    }
                    if (Property.hasGardenShed)
                    {
                        morefeaturesdisplay = morefeaturesdisplay + "<li>Garden Shed</li>";
                    }
                    morefeaturesdisplay = morefeaturesdisplay + "</ul>";
                }
                if (InternalCounter > 0)
                {
                    morefeaturesdisplay = morefeaturesdisplay + "<h3>Internals</h3>";
                    morefeaturesdisplay = morefeaturesdisplay + "<ul class='right-sign'>";
                    if (Property.numStudy != null)
                    {
                        if (Property.numStudy > 0)
                            morefeaturesdisplay = morefeaturesdisplay + "<li>" + Property.numStudy + " Study</li>";
                    }

                    if (Property.hasSecuritySystem)
                    {
                        morefeaturesdisplay = morefeaturesdisplay + "<li>Security System</li>";
                    }
                    if (Property.numWC != null)
                    {
                        if (Property.numWC > 0)
                            morefeaturesdisplay = morefeaturesdisplay + "<li>" + Property.numWC + " WC</li>";
                    }
                    if (!String.IsNullOrEmpty(Property.heatingType))
                    {
                        morefeaturesdisplay = morefeaturesdisplay + "<li>Heating>&nbsp;" + Property.heatingType + "</li>";
                    }
                    if (Property.hasRoomDining)
                    {
                        morefeaturesdisplay = morefeaturesdisplay + "<li>Dining</li>";
                    }
                    if (!String.IsNullOrEmpty(Property.coolingtype))
                    {
                        morefeaturesdisplay = morefeaturesdisplay + "<li>Cooling>&nbsp;" + Property.coolingtype + "</li>";
                    }
                    if (Property.hasRoomLiving)
                    {
                        morefeaturesdisplay = morefeaturesdisplay + "<li>Living</li>";
                    }
                    if (Property.hasVaccumSystem != null)
                    {
                        if ((bool)Property.hasVaccumSystem)
                            morefeaturesdisplay = morefeaturesdisplay + "<li>Vaccum System</li>";
                    }
                    if (Property.sqmInternal != null)
                    {
                        if (Property.sqmInternal > 0)
                            morefeaturesdisplay = morefeaturesdisplay + "<li>Int. Area " + Property.sqmInternal + "&nbsp;sqm</li>";
                    }
                    if (Property.hasHouseAlarm)
                    {
                        morefeaturesdisplay = morefeaturesdisplay + "<li>House Alarm</li>";
                    }
                    if (Property.hasRoomGames)
                    {
                        morefeaturesdisplay = morefeaturesdisplay + "<li>Games</li>";
                    }
                    if (Property.hasRoomFamily)
                    {
                        morefeaturesdisplay = morefeaturesdisplay + "<li>Family</li>";
                    }
                    morefeaturesdisplay = morefeaturesdisplay + "</ul>";
                }
                if (devCounter > 0)
                {
                    morefeaturesdisplay = morefeaturesdisplay + "<h3>Development Information</h3>";
                    morefeaturesdisplay = morefeaturesdisplay + "<ul class='right-sign'>";
                    if (!String.IsNullOrEmpty(Property.stage))
                    {
                        morefeaturesdisplay = morefeaturesdisplay + "<li>Stage " + Property.stage + " </li>";
                    }

                    if (Property.numBalcony != null)
                    {
                        if (Property.numBalcony > 0)
                            morefeaturesdisplay = morefeaturesdisplay + "<li>" + Property.numBalcony + " Balcony(s)</li>";
                    }
                    if (Property.numFloorPlan != null)
                    {
                        if (Property.numFloorPlan > 0)
                            morefeaturesdisplay = morefeaturesdisplay + "<li>Floor " + Property.numFloorPlan + "</li>";
                    }
                    if (Property.hasDoorman)
                    {
                        morefeaturesdisplay = morefeaturesdisplay + "<li>Doorman</li>";
                    }
                    if (Property.hasLift)
                    {
                        morefeaturesdisplay = morefeaturesdisplay + "<li>Lift</li>";
                    }
                    if (Property.hasGym)
                    {
                        morefeaturesdisplay = morefeaturesdisplay + "<li>Gym</li>";
                    }
                    if (Property.hasManager)
                    {
                        morefeaturesdisplay = morefeaturesdisplay + "<li>On Site Manager</li>";
                    }
                    if (Property.hasSpa)
                    {
                        morefeaturesdisplay = morefeaturesdisplay + "<li>Spa</li>";
                    }
                    morefeaturesdisplay = morefeaturesdisplay + "</ul>";
                }
            }
        }
        return morefeaturesdisplay;
    }

    //Showing Last Updated Date
    protected string showLastUpdatedDate()
    {
        string morefeaturesdisplay = string.Empty;
        if (Property != null)
        {
            if (Property.dateUpdated != null)
            {
                morefeaturesdisplay = morefeaturesdisplay + "Last Updated Date:" + ((DateTime)Property.dateUpdated).ToString("dd MMMM yyyy");
            }
        }
        return morefeaturesdisplay;
    }
    #endregion
}