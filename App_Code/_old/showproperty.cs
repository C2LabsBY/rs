using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Data.SqlTypes;
using System.Data.SqlClient;
using System.Data.Sql;
/// <summary>
/// Summary description for property
/// </summary>
public class showproperty
{
    public string acid;
    public string acids;
    public string pid;
    public string reid;

    public bool iswebdisplay;
    public bool hidemap;
    public bool hidestreet;
    //featur property
    public string featureSuburb1;
    public string featureSuburb2;
    public string featurepid1;
    public string featurepid2;

    // google
    public string googleX;
    public string googleY;

    public DateTime strdateListed;
    // address
    public string strName;
    public string strStatus;
    public string strUnitNum;
    public string strRoadNum;
    public string strRoadName;
    public string strRoadType;
    public string strSuburb;
    public string strState;
    public Boolean blHideRoadNum;
    public Boolean blHideRoadName;
    public string address = "";
    public string gaddress = "";
    public string postcode;

    //suburb details
    public string suburbdescription;
    public string suburbname;
    public int suburbphotos = 0;
    public int suburbsid;
    public Boolean blLifestyle;
    // price 
    public string strPriceOption;
    public Decimal strPriceLow;
    public Decimal strPriceHigh;
    public string strPaymentPeriod;
    public Boolean pricedisplay;
    public string price;
    public Decimal commercialpriceYearly;
    public string strPricetext;
    public Boolean strPricered;

    public decimal soldprice;
    public Boolean bldisplaysoldprice;

    public bool isAvailableNow;
    public DateTime strAvailablefrom;
    //homeopen    
    public string homeopen = "";
    public DateTime strHomeopen1From;
    public DateTime strHomeopen1To;
    public DateTime strHomeopen2From;
    public DateTime strHomeopen2To;

    public string txt_Homeopen1From;
    public string txt_Homeopen1To;
    public string txt_Homeopen2From;
    public string txt_Homeopen2To;
    //sold
    public DateTime dateSold;
    public DateTime onadate;
    public DateTime datelisted;
    //feature counters and display 
    public int landCounter = 0;
    public int parkingCounter = 0;
    public int strTotalSpace = 0;
    public int ExternalCounter = 0;
    public int devCounter = 0;
    public int InternalCounter = 0;
    public int featureCounter = 0;
    public string morefeaturesdisplay;
    public string moreDescription;

    //photos and visual
    public Boolean hasphotolarge;
    public Boolean hasAttachment;
    public Boolean isnonimis;
    public int numPhotoMore;
    public int numFloorPlan;
    public Boolean hasLotPlan;
    public string link;
    public string link2;


    // agent details
    public int aid1;
    public int aid2;
    public int aid3;
    public string agentname;
    public string agentFirstName;
    public string agentposition;
    public string agentmobile;
    public string agentmobiledisplay;
    public string agentphone;
    public string agentfax;
    public string agentemail;
    public Boolean hasphoto;
    public Boolean hasphoto2;
    public string agentprofile;
    public int agentsoldcount;
    public int agentspropcount;
    public int agentsphotopropcount;
    public int agentfeaturepid;
    public string agentimisAid;
    public Boolean agentiswebdisplay;
    public Boolean agenthidemobile;
    // agency details
    public string agencyname;
    public Boolean agencyhasLogo;
    public string agencyunitnum;
    public string agencyroadnum;
    public string agencyroadname;
    public string agencyroadtype;
    public string agencysuburb;
    public string agencyphone;
    public string agencyfax;
    public string agencyemail;
    public string agenyaddress;
    public string agencylink;
    public string agencyweb;
    public string agencyprofile;
    public string agencyimisAcid;

    //description
    public string descriptionshort;
    public string descriptionlong;
    public string descriptionbullet;

    //property details
    public string beds;
    public string baths;
    public string carbays;
    public string status;
    public string propertytype;
    public string lotMeasurement;
    public decimal lotSize;
    public Boolean blFurnished;
    public bool hassustainability;
    // out goings and others
    public decimal ratesCouncil;
    public decimal ratesWater;
    public decimal ratesStrata;

    //Land Details
    public string strLotSize;
    public string strLotMeasure;
    public string strZoning;
    public string strLotOrientation;
    public string strLotFrontage;
    //parking
    public int strcarBays;
    public int strgarages;
    public Boolean blParkingExposed;
    public Boolean blRemote;
    public Boolean blSecure;
    //Externals
    public Boolean blOutdoorEnt;
    public Boolean blCourtyard;
    public Boolean blReticulation;
    public Boolean blBore;
    public Boolean blFirb;
    public Boolean blGardenShed;
    public Boolean blPool;
    public Boolean strhascourtyard;
    public string strnumBalcony;
    public string strExternalSqm;
    //Internals
    public string strNumStudy;
    public string strNumWC;
    public string strHeating;
    public string strCooling;
    public Boolean blSecurity;
    public Boolean blAlarm;
    public Boolean blRoomDining;
    public Boolean blRoomLiving;
    public Boolean blHasVacumm;
    public Boolean blRoomGames;
    public Boolean blRoomFamily;
    public string strInternalSqm;
    //development
    public string strStage;
    public string strBalcony;
    public string strFloor;
    public Boolean blLift;
    public Boolean blGym;
    public Boolean blSpa;
    public Boolean blManager;
    public Boolean blDoorman;
    public Boolean blPdf;
    public Boolean blhaslogo;

    public string auctiondate;
    public string auctiontime;

    // building
    public string bid;
    public string bacid;
    public string BName;
    public string BRoadNum;
    public string BRoadName;
    public string BRoadType;
    public string BSuburb;
    public string BState;
    public string Baddress = "";
    public Boolean Bhasphotolarge;
    public int BnumPhotoMore;
    public int BnumFloorPlan;
    public string Bdescriptionshort;
    public string Bdescriptionlong;
    public string Bdescriptionbullet;
    public string BType;
    public string BFeaturesUnit;
    public string BFeaturesBuilding;
    public Decimal BstrPriceLow;
    public Decimal BstrPriceHigh;
    public string Bprice;
    public string BPostcode;
    public string Bpid;

    public string strRegion;

    public bool hideprice = false;

    //connection strings
    public SqlConnection connection;
    public string connectionString;
    public showproperty()
    {
        acids = "Any";
        connectionString = ConfigurationManager.ConnectionStrings["propertiesdb"].ConnectionString;
        connection = new SqlConnection(connectionString);
    }

    public void editPublicLog(string strPID, string strACID)
    {
        connection.Open();
        SqlCommand command = new SqlCommand("spEditPublicLog", connection);
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.Add(new SqlParameter("@pID", strPID));
        command.Parameters.Add(new SqlParameter("@acID", strACID));
        command.Parameters.Add(new SqlParameter("@site", "REIQ"));
        SqlDataReader reader = command.ExecuteReader();
        connection.Close();
    }
    public void getProperty(string pID, string acID)
    {
        pid = pID;
        connection.Open();
        SqlCommand command = new SqlCommand("spgetProperties", connection);
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.Add(new SqlParameter("@pid", pID));
        command.Parameters.Add(new SqlParameter("@acID", acID));
        command.Parameters.Add(new SqlParameter("@iswebdisplay", "Any"));
        SqlDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
            if (!reader.IsDBNull(reader.GetOrdinal("hideprice")))
            {
                hideprice = reader.GetBoolean(reader.GetOrdinal("hideprice"));
            }

            if (!reader.IsDBNull(reader.GetOrdinal("isWebDisplay")))
            {
                iswebdisplay = reader.GetBoolean(reader.GetOrdinal("isWebDisplay"));
            }
            if (!reader.IsDBNull(reader.GetOrdinal("hidemap")))
            {
                hidemap = reader.GetBoolean(reader.GetOrdinal("hidemap"));
            }
            if (!reader.IsDBNull(reader.GetOrdinal("hidestreet")))
            {
                hidestreet = reader.GetBoolean(reader.GetOrdinal("hidestreet"));
            }
            if (!reader.IsDBNull(reader.GetOrdinal("displaysoldprice")))
            {
                bldisplaysoldprice = reader.GetBoolean(reader.GetOrdinal("displaysoldprice"));
            }
            if (!reader.IsDBNull(reader.GetOrdinal("pricesold")))
            {
                soldprice = reader.GetDecimal(reader.GetOrdinal("pricesold"));
            }

            if (!reader.IsDBNull(reader.GetOrdinal("hassustainability")))
            {
                hassustainability = reader.GetBoolean(reader.GetOrdinal("hassustainability"));
            }
            if (!reader.IsDBNull(reader.GetOrdinal("googlex")))
            {
                googleX = reader.GetString(reader.GetOrdinal("googlex"));
            }
            if (!reader.IsDBNull(reader.GetOrdinal("googley")))
            {
                googleY = reader.GetString(reader.GetOrdinal("googley"));
            }
            if (!reader.IsDBNull(reader.GetOrdinal("lotSize")))
            {
                lotSize = reader.GetDecimal(reader.GetOrdinal("lotSize"));
            }
            if (!reader.IsDBNull(reader.GetOrdinal("acID")))
            {
                acid = reader.GetValue(reader.GetOrdinal("acID")).ToString();
            }
            if (!reader.IsDBNull(reader.GetOrdinal("lotMeasurement")))
            {
                lotMeasurement = reader.GetString(reader.GetOrdinal("lotMeasurement"));
            }
            if (!reader.IsDBNull(reader.GetOrdinal("hasAttachment")))
            {
                hasAttachment = reader.GetBoolean(reader.GetOrdinal("hasAttachment"));
            }
            if (!reader.IsDBNull(reader.GetOrdinal("hasLotPlan")))
            {
                hasLotPlan = reader.GetBoolean(reader.GetOrdinal("hasLotPlan"));
            }
            if (!reader.IsDBNull(reader.GetOrdinal("link")))
            {
                link = reader.GetString(reader.GetOrdinal("link"));
            }
            if (!reader.IsDBNull(reader.GetOrdinal("link2")))
            {
                link2 = reader.GetString(reader.GetOrdinal("link2"));
            }
            if (!reader.IsDBNull(reader.GetOrdinal("numPhotoMore")))
            {
                numPhotoMore = int.Parse(reader.GetValue(reader.GetOrdinal("numPhotoMore")).ToString());
            }

            if (!reader.IsDBNull(reader.GetOrdinal("numFloorPlan")))
            {
                numFloorPlan = int.Parse(reader.GetValue(reader.GetOrdinal("numFloorPlan")).ToString());
            }
            if (!reader.IsDBNull(reader.GetOrdinal("ratesCouncil")))
            {
                ratesCouncil = reader.GetDecimal(reader.GetOrdinal("ratesCouncil"));
            }
            if (!reader.IsDBNull(reader.GetOrdinal("commercialpriceyearly")))
            {
                commercialpriceYearly = reader.GetDecimal(reader.GetOrdinal("commercialpriceyearly"));
            }
            if (!reader.IsDBNull(reader.GetOrdinal("ratesStrata")))
            {
                ratesStrata = reader.GetDecimal(reader.GetOrdinal("ratesStrata"));
            }
            if (!reader.IsDBNull(reader.GetOrdinal("ratesWater")))
            {
                ratesWater = reader.GetDecimal(reader.GetOrdinal("ratesWater"));
            }

            if (!reader.IsDBNull(reader.GetOrdinal("hasAttachment")))
            {
                blPdf = reader.GetBoolean(reader.GetOrdinal("hasAttachment"));
            }

            if (!reader.IsDBNull(reader.GetOrdinal("status")))
            {
                status = reader.GetString(reader.GetOrdinal("status"));
            }
            if (!reader.IsDBNull(reader.GetOrdinal("type")))
            {
                propertytype = reader.GetString(reader.GetOrdinal("type"));
            }
            if (!reader.IsDBNull(reader.GetOrdinal("numBedrooms")))
            {
                //beds = reader.GetInt16(reader.GetOrdinal("numBedrooms")).ToString();
                beds = reader.GetValue(reader.GetOrdinal("numBedrooms")).ToString();
            }
            if (!reader.IsDBNull(reader.GetOrdinal("numBathrooms")))
            {
                //baths = reader.GetInt16(reader.GetOrdinal("numBathrooms")).ToString();
                baths = reader.GetValue(reader.GetOrdinal("numBathrooms")).ToString();
            }
            if (!reader.IsDBNull(reader.GetOrdinal("numGarage")))
            {
                carbays = reader.GetValue(reader.GetOrdinal("numGarage")).ToString();
            }
            if (!reader.IsDBNull(reader.GetOrdinal("aid3")))
            {
                aid3 = int.Parse(reader.GetValue(reader.GetOrdinal("aid3")).ToString());
                //aid3 = reader.GetInt16(reader.GetOrdinal("aid3"));
            }

            if (!reader.IsDBNull(reader.GetOrdinal("descriptionShort")))
            {
                descriptionshort = reader.GetString(reader.GetOrdinal("descriptionShort"));
            }
            if (!reader.IsDBNull(reader.GetOrdinal("descriptionLong")))
            {
                descriptionlong = reader.GetString(reader.GetOrdinal("descriptionLong"));
                descriptionlong = descriptionlong.Replace(Environment.NewLine, "<BR>");
            }

            if (!reader.IsDBNull(reader.GetOrdinal("descriptionBullet")))
            {
                descriptionbullet = reader.GetString(reader.GetOrdinal("descriptionBullet"));
                descriptionbullet = descriptionbullet.Replace("<li></li>", "");
                descriptionbullet = descriptionbullet.Replace("<ul></ul>", "");
                descriptionbullet = descriptionbullet.Replace("<li>", "<li>");
                descriptionbullet = descriptionbullet.Replace("<ul>", "<ul class=check>");
            }

            if (!String.IsNullOrEmpty(descriptionlong))
            {
                if (descriptionlong.Length > 500)
                {
                    moreDescription = moreDescription + "<table width=100% >";
                    moreDescription = moreDescription + "<tr>";
                    moreDescription = moreDescription + "<td   align=left id=moreDescDisplay>" + getshortDescription(descriptionlong, 500) + "...<A  HREF=javascript:javascript:myShow('moreDescHide');javascript:myHide('moreDescDisplay');><b>>> more descriptions</b></a></td>";
                    moreDescription = moreDescription + "</tr>";
                    moreDescription = moreDescription + "<tr><td align=left id=moreDescHide STYLE=display:none;>";
                    moreDescription = moreDescription + descriptionlong;

                    if (!String.IsNullOrEmpty(descriptionbullet))
                    {
                        moreDescription = moreDescription + "<br>" + descriptionbullet;

                    }


                    moreDescription = moreDescription + "<a  href=javascript:javascript:myHide('moreDescHide');javascript:myShow('moreDescDisplay');><b>>> hide descriptions</b></a></td></tr>";
                    moreDescription = moreDescription + "</td></tr>";
                    moreDescription = moreDescription + "</table>";
                }
                else
                {
                    moreDescription = descriptionlong;
                }
            }


            if (!reader.IsDBNull(reader.GetOrdinal("name")))
            {
                strName = reader.GetString(reader.GetOrdinal("name"));
            }
            if (!reader.IsDBNull(reader.GetOrdinal("unitNum")))
            {
                strUnitNum = reader.GetString(reader.GetOrdinal("unitNum"));
            }
            if (!reader.IsDBNull(reader.GetOrdinal("rdNum")))
            {
                strRoadNum = reader.GetString(reader.GetOrdinal("rdNum"));
            }
            if (!reader.IsDBNull(reader.GetOrdinal("rdName")))
            {
                strRoadName = reader.GetString(reader.GetOrdinal("rdName"));
            }
            if (!reader.IsDBNull(reader.GetOrdinal("rdType")))
            {
                strRoadType = reader.GetString(reader.GetOrdinal("rdType"));
            }
            if (!reader.IsDBNull(reader.GetOrdinal("status")))
            {
                strStatus = reader.GetString(reader.GetOrdinal("status"));
            }
            if (!reader.IsDBNull(reader.GetOrdinal("suburb")))
            {
                strSuburb = reader.GetString(reader.GetOrdinal("suburb"));
            }
            if (!reader.IsDBNull(reader.GetOrdinal("hideRoadNum")))
            {
                blHideRoadNum = reader.GetBoolean(reader.GetOrdinal("hideRoadNum"));
            }
            if (!reader.IsDBNull(reader.GetOrdinal("hideRoadName")))
            {
                blHideRoadName = reader.GetBoolean(reader.GetOrdinal("hideRoadName"));
            }
            if (!reader.IsDBNull(reader.GetOrdinal("postcode")))
            {
                postcode = reader.GetString(reader.GetOrdinal("postcode"));
            }
            if (!reader.IsDBNull(reader.GetOrdinal("state")))
            {
                strState = reader.GetString(reader.GetOrdinal("state"));
            }
            if (!reader.IsDBNull(reader.GetOrdinal("priceOption")))
            {
                strPriceOption = reader.GetString(reader.GetOrdinal("priceOption"));
            }
            if (!reader.IsDBNull(reader.GetOrdinal("pricetext")))
            {
                strPricetext = reader.GetString(reader.GetOrdinal("pricetext"));
            }

            if (!reader.IsDBNull(reader.GetOrdinal("priceRed")))
            {
                strPricered = reader.GetBoolean(reader.GetOrdinal("priceRed"));
            }
            if (!reader.IsDBNull(reader.GetOrdinal("priceLow")))
            {
                strPriceLow = reader.GetDecimal(reader.GetOrdinal("priceLow"));
            }
            if (!reader.IsDBNull(reader.GetOrdinal("priceHigh")))
            {
                strPriceHigh = reader.GetDecimal(reader.GetOrdinal("priceHigh"));
            }
            if (!reader.IsDBNull(reader.GetOrdinal("paymentPeriod")))
            {
                strPaymentPeriod = reader.GetString(reader.GetOrdinal("paymentPeriod"));
            }

            if (!reader.IsDBNull(reader.GetOrdinal("dateListed")))
            {
                strdateListed = reader.GetDateTime(reader.GetOrdinal("dateListed"));
            }
            //For available
            if (!reader.IsDBNull(reader.GetOrdinal("isAvailableNow")))
            {
                isAvailableNow = reader.GetBoolean(reader.GetOrdinal("isAvailableNow"));

                if (!reader.IsDBNull(reader.GetOrdinal("availablefrom")))
                {
                    strAvailablefrom = reader.GetDateTime(reader.GetOrdinal("availablefrom"));
                }



            }

            txt_Homeopen2To = "";
            txt_Homeopen1To = "";
            txt_Homeopen2From = "";
            txt_Homeopen1From = "";

            if (!reader.IsDBNull(reader.GetOrdinal("homeopen2To")))
            {
                strHomeopen2To = reader.GetDateTime(reader.GetOrdinal("homeopen2To"));
                txt_Homeopen2To = strHomeopen2To.ToString();
            }
            if (!reader.IsDBNull(reader.GetOrdinal("homeopen2From")))
            {
                strHomeopen2From = reader.GetDateTime(reader.GetOrdinal("homeopen2From"));
                txt_Homeopen2From = strHomeopen2From.ToString();
            }
            if (!reader.IsDBNull(reader.GetOrdinal("homeopen1To")))
            {
                strHomeopen1To = reader.GetDateTime(reader.GetOrdinal("homeopen1To"));
                txt_Homeopen1To = strHomeopen1To.ToString();
            }
            if (!reader.IsDBNull(reader.GetOrdinal("homeopen1From")))
            {
                strHomeopen1From = reader.GetDateTime(reader.GetOrdinal("homeopen1From"));
                txt_Homeopen1From = strHomeopen1From.ToString();
            }


            if (!reader.IsDBNull(reader.GetOrdinal("dateSold")))
            {
                dateSold = reader.GetDateTime(reader.GetOrdinal("dateSold"));
            }
            if (!reader.IsDBNull(reader.GetOrdinal("onadate")))
            {
                onadate = reader.GetDateTime(reader.GetOrdinal("onadate"));
            }
            if (!reader.IsDBNull(reader.GetOrdinal("datelisted")))
            {
                datelisted = reader.GetDateTime(reader.GetOrdinal("datelisted"));
            }
            auctiondate = "";
            auctiontime = "";
            if (!reader.IsDBNull(reader.GetOrdinal("auctionDate")))
            {
                DateTime auctiondateS = reader.GetDateTime(reader.GetOrdinal("auctionDate"));
                auctiondate = auctiondateS.ToString();
            }

            if (!reader.IsDBNull(reader.GetOrdinal("auctionTime")))
            {
                auctiontime = reader.GetString(reader.GetOrdinal("auctionTime"));
            }
            if (!reader.IsDBNull(reader.GetOrdinal("aid1")))
            {
                aid1 = int.Parse(reader.GetValue(reader.GetOrdinal("aid1")).ToString());
                //aid1 = reader.GetInt16(reader.GetOrdinal("aid1"));
            }
            if (!reader.IsDBNull(reader.GetOrdinal("aid2")))
            {
                aid2 = int.Parse(reader.GetValue(reader.GetOrdinal("aid2")).ToString());
                //aid2 = reader.GetInt16(reader.GetOrdinal("aid2"));
            }
            if (!reader.IsDBNull(reader.GetOrdinal("aid3")))
            {
                aid3 = int.Parse(reader.GetValue(reader.GetOrdinal("aid3")).ToString());
                //aid3 = reader.GetInt16(reader.GetOrdinal("aid3"));
            }
            if (!reader.IsDBNull(reader.GetOrdinal("hideprice")))
            {
                pricedisplay = reader.GetBoolean(reader.GetOrdinal("hideprice"));
            }
            if (!reader.IsDBNull(reader.GetOrdinal("hasPhotoLarge")))
            {
                hasphotolarge = reader.GetBoolean(reader.GetOrdinal("hasPhotoLarge"));
            }

            if (!reader.IsDBNull(reader.GetOrdinal("isFurnished")))
            {
                blFurnished = reader.GetBoolean(reader.GetOrdinal("isFurnished"));

            }

            if (!reader.IsDBNull(reader.GetOrdinal("lotSize")))
            {
                strLotSize = reader.GetDecimal(reader.GetOrdinal("lotSize")).ToString();
                landCounter = landCounter + 1;
            }
            if (!reader.IsDBNull(reader.GetOrdinal("lotMeasurement")))
            {
                strLotMeasure = reader.GetString(reader.GetOrdinal("lotMeasurement"));

            }
            if (!reader.IsDBNull(reader.GetOrdinal("zoning")))
            {
                strZoning = reader.GetString(reader.GetOrdinal("zoning"));
                landCounter = landCounter + 1;
            }
            if (!reader.IsDBNull(reader.GetOrdinal("lotOrientation")))
            {
                strLotOrientation = reader.GetString(reader.GetOrdinal("lotOrientation"));
                landCounter = landCounter + 1;
            }
            if (!reader.IsDBNull(reader.GetOrdinal("lotFrontage")))
            {
                strLotFrontage = reader.GetString(reader.GetOrdinal("lotFrontage"));
                landCounter = landCounter + 1;
            }
            if (!reader.IsDBNull(reader.GetOrdinal("numcarbays")))
            {
                //strcarBays = reader.GetInt16(reader.GetOrdinal("numcarbays"));
                strcarBays = int.Parse(reader.GetValue(reader.GetOrdinal("numcarbays")).ToString());
                strTotalSpace = strTotalSpace + strcarBays;
                parkingCounter = parkingCounter + 1;
            }
            if (!reader.IsDBNull(reader.GetOrdinal("numGarage")))
            {
                //strgarages = reader.GetInt16(reader.GetOrdinal("numGarage"));
                strgarages = int.Parse(reader.GetValue(reader.GetOrdinal("numGarage")).ToString());
                strTotalSpace = strTotalSpace + strgarages;
                parkingCounter = parkingCounter + 1;
            }
            if (!reader.IsDBNull(reader.GetOrdinal("hasParkingExposed")))
            {
                blParkingExposed = reader.GetBoolean(reader.GetOrdinal("hasParkingExposed"));
                if (blParkingExposed)
                {
                    //  parkingCounter = parkingCounter + 1;
                }
            }
            if (!reader.IsDBNull(reader.GetOrdinal("hasgarageremote")))
            {
                blRemote = reader.GetBoolean(reader.GetOrdinal("hasgarageremote"));
                if (blRemote)
                {
                    // parkingCounter = parkingCounter + 1;
                }
            }
            if (!reader.IsDBNull(reader.GetOrdinal("hasSecureCarPark")))
            {
                blSecure = reader.GetBoolean(reader.GetOrdinal("hasSecureCarPark"));
                if (blSecure)
                {
                    // parkingCounter = parkingCounter + 1;
                }
            }
            if (!reader.IsDBNull(reader.GetOrdinal("hasOutdoorEnt")))
            {
                blOutdoorEnt = reader.GetBoolean(reader.GetOrdinal("hasOutdoorEnt"));
                if (blOutdoorEnt)
                {
                    ExternalCounter = ExternalCounter + 1;
                }
            }
            /* if (!reader.IsDBNull(reader.GetOrdinal("hasCourtyard")))
             {
                 blCourtyard = reader.GetBoolean(reader.GetOrdinal("hasCourtyard"));
                 if (blCourtyard)
                 {
                     ExternalCounter = ExternalCounter + 1;
                 }
             }*/
            if (!reader.IsDBNull(reader.GetOrdinal("hasReticulation")))
            {
                blReticulation = reader.GetBoolean(reader.GetOrdinal("hasReticulation"));
                if (blReticulation)
                {
                    ExternalCounter = ExternalCounter + 1;
                }
            }
            if (!reader.IsDBNull(reader.GetOrdinal("hasBore")))
            {
                blBore = reader.GetBoolean(reader.GetOrdinal("hasBore"));
                if (blBore)
                {
                    ExternalCounter = ExternalCounter + 1;
                }
            }

            if (!reader.IsDBNull(reader.GetOrdinal("isFirb")))
            {
                blFirb = reader.GetBoolean(reader.GetOrdinal("isFirb"));
                if (blFirb)
                {
                    ExternalCounter = ExternalCounter + 1;
                }
            }


            if (!reader.IsDBNull(reader.GetOrdinal("hasGardenShed")))
            {
                blGardenShed = reader.GetBoolean(reader.GetOrdinal("hasGardenShed"));
                if (blGardenShed)
                {
                    ExternalCounter = ExternalCounter + 1;
                }
            }
            if (!reader.IsDBNull(reader.GetOrdinal("hasPool")))
            {
                blPool = reader.GetBoolean(reader.GetOrdinal("hasPool"));
                if (blPool)
                {
                    ExternalCounter = ExternalCounter + 1;
                }
            }
            if (!reader.IsDBNull(reader.GetOrdinal("hascourtyard")))
            {
                strhascourtyard = reader.GetBoolean(reader.GetOrdinal("hascourtyard"));
                if (strhascourtyard)
                {
                    ExternalCounter = ExternalCounter + 1;
                }
            }
            if (!reader.IsDBNull(reader.GetOrdinal("numBalcony")))
            {
                //strnumBalcony = reader.GetInt16(reader.GetOrdinal("numBalcony")).ToString();
                byte Balcony = reader.GetByte(reader.GetOrdinal("numBalcony"));
                strnumBalcony = Balcony.ToString();
                ExternalCounter = ExternalCounter + 1;
            }
            if (!reader.IsDBNull(reader.GetOrdinal("sqmExternal")))
            {
                strExternalSqm = reader.GetValue(reader.GetOrdinal("sqmExternal")).ToString();
                ExternalCounter = ExternalCounter + 1;
            }
            if (!reader.IsDBNull(reader.GetOrdinal("numStudy")))
            {
                //strNumStudy = reader.GetInt32(reader.GetOrdinal("numStudy")).ToString();
                strNumStudy = reader.GetValue(reader.GetOrdinal("numStudy")).ToString();
                InternalCounter = InternalCounter + 1;
            }
            if (!reader.IsDBNull(reader.GetOrdinal("numWC")))
            {
                strNumWC = reader.GetValue(reader.GetOrdinal("numWC")).ToString();
                InternalCounter = InternalCounter + 1;
            }
            if (!reader.IsDBNull(reader.GetOrdinal("heatingType")))
            {
                strHeating = reader.GetString(reader.GetOrdinal("heatingType"));
                InternalCounter = InternalCounter + 1;
            }
            if (!reader.IsDBNull(reader.GetOrdinal("coolingType")))
            {
                strCooling = reader.GetString(reader.GetOrdinal("coolingType"));
                InternalCounter = InternalCounter + 1;
            }
            if (!reader.IsDBNull(reader.GetOrdinal("hasSecuritySystem")))
            {
                blSecurity = reader.GetBoolean(reader.GetOrdinal("hasSecuritySystem"));
                if (blSecurity)
                {
                    InternalCounter = InternalCounter + 1;
                }
            }
            if (!reader.IsDBNull(reader.GetOrdinal("hasHouseAlarm")))
            {
                blAlarm = reader.GetBoolean(reader.GetOrdinal("hasHouseAlarm"));
                if (blAlarm)
                {
                    InternalCounter = InternalCounter + 1;
                }
            }
            if (!reader.IsDBNull(reader.GetOrdinal("hasRoomDining")))
            {
                blRoomDining = reader.GetBoolean(reader.GetOrdinal("hasRoomDining"));
                if (blRoomDining)
                {
                    InternalCounter = InternalCounter + 1;
                }
            }
            if (!reader.IsDBNull(reader.GetOrdinal("hasRoomLiving")))
            {
                blRoomLiving = reader.GetBoolean(reader.GetOrdinal("hasRoomLiving"));
                if (blRoomLiving)
                {
                    InternalCounter = InternalCounter + 1;
                }
            }
            if (!reader.IsDBNull(reader.GetOrdinal("hasvaccumsystem")))
            {
                blHasVacumm = reader.GetBoolean(reader.GetOrdinal("hasvaccumsystem"));
                if (blHasVacumm)
                {
                    InternalCounter = InternalCounter + 1;
                }
            }
            if (!reader.IsDBNull(reader.GetOrdinal("hasRoomGames")))
            {
                blRoomGames = reader.GetBoolean(reader.GetOrdinal("hasRoomGames"));
                if (blRoomGames)
                {
                    InternalCounter = InternalCounter + 1;
                }
            }
            if (!reader.IsDBNull(reader.GetOrdinal("hasRoomFamily")))
            {
                blRoomFamily = reader.GetBoolean(reader.GetOrdinal("hasRoomFamily"));
                if (blRoomFamily)
                {
                    InternalCounter = InternalCounter + 1;
                }
            }
            if (!reader.IsDBNull(reader.GetOrdinal("sqmInternal")))
            {
                strInternalSqm = reader.GetValue(reader.GetOrdinal("sqmInternal")).ToString();
                InternalCounter = InternalCounter + 1;
            }
            if (!reader.IsDBNull(reader.GetOrdinal("stage")))
            {
                strStage = reader.GetString(reader.GetOrdinal("stage"));
                devCounter = devCounter + 1;
            }
            if (!reader.IsDBNull(reader.GetOrdinal("numBalcony")))
            {
                byte Balcony = reader.GetByte(reader.GetOrdinal("numBalcony"));
                strBalcony = Balcony.ToString();
                devCounter = devCounter + 1;
            }
            if (!reader.IsDBNull(reader.GetOrdinal("unitLevel")))
            {
                strFloor = reader.GetString(reader.GetOrdinal("unitLevel"));
                devCounter = devCounter + 1;
            }
            if (!reader.IsDBNull(reader.GetOrdinal("hasLift")))
            {
                blLift = reader.GetBoolean(reader.GetOrdinal("hasLift"));
                if (blLift)
                {
                    devCounter = devCounter + 1;
                }
            }
            if (!reader.IsDBNull(reader.GetOrdinal("hasGym")))
            {
                blGym = reader.GetBoolean(reader.GetOrdinal("hasGym"));
                if (blGym)
                {
                    devCounter = devCounter + 1;
                }
            }
            if (!reader.IsDBNull(reader.GetOrdinal("hasSpa")))
            {
                blSpa = reader.GetBoolean(reader.GetOrdinal("hasSpa"));
                if (blSpa)
                {
                    devCounter = devCounter + 1;
                }
            }
            if (!reader.IsDBNull(reader.GetOrdinal("hasManager")))
            {
                blManager = reader.GetBoolean(reader.GetOrdinal("hasManager"));
                if (blManager)
                {
                    devCounter = devCounter + 1;
                }
            }
            if (!reader.IsDBNull(reader.GetOrdinal("hasDoorman")))
            {
                blDoorman = reader.GetBoolean(reader.GetOrdinal("hasDoorman"));
                if (blDoorman)
                {
                    devCounter = devCounter + 1;
                }
            }
        }

        homeopen = "";
        if (!String.IsNullOrEmpty(strHomeopen1To.ToString()) && !String.IsNullOrEmpty(strHomeopen1From.ToString()))
        {

            if (!(strHomeopen1From.ToShortTimeString().ToString() == strHomeopen1To.ToShortTimeString().ToString()))
            {
                if (strHomeopen1From.Year < DateTime.Now.Year)
                {
                    homeopen = "Sat: " + strHomeopen1From.ToShortTimeString().ToString() + " to " + strHomeopen1To.ToShortTimeString().ToString();
                }
                else
                {
                    homeopen = strHomeopen1From.ToLongDateString().ToString() + " " + strHomeopen1From.ToShortTimeString().ToString() + " to " + strHomeopen1To.ToShortTimeString().ToString();
                }
            }


        }
        if (!String.IsNullOrEmpty(strHomeopen2To.ToString()) && !String.IsNullOrEmpty(strHomeopen2From.ToString()))
        {

            if (!(strHomeopen2From.ToShortTimeString().ToString() == strHomeopen2To.ToShortTimeString().ToString()))
            {
                if (homeopen == "")
                {

                    if (strHomeopen2From.Year < DateTime.Now.Year)
                    {
                        homeopen = "Sun: " + strHomeopen2From.ToShortTimeString().ToString() + " to " + strHomeopen2To.ToShortTimeString().ToString();
                    }
                    else
                    {
                        homeopen = strHomeopen2From.ToLongDateString().ToString() + " " + strHomeopen2From.ToShortTimeString().ToString().ToLower() + " to " + strHomeopen2To.ToShortTimeString().ToString();
                    }
                }
                else
                {
                    if (strHomeopen2From.Year < DateTime.Now.Year)
                    {
                        homeopen = homeopen + "<br>Sun: " + strHomeopen2From.ToShortTimeString().ToString() + " to " + strHomeopen2To.ToShortTimeString().ToString();
                    }
                    else
                    {
                        homeopen = homeopen + "<br>" + strHomeopen2From.ToLongDateString().ToString() + " " + strHomeopen2From.ToShortTimeString().ToString() + " to " + strHomeopen2To.ToShortTimeString().ToString();
                    }
                }

            }

        }

        connection.Close();
        address = getAddress(strName, strUnitNum, strRoadNum, strRoadName, strRoadType, strSuburb, blHideRoadName, blHideRoadNum);
        gaddress = getGAddress(null, strUnitNum, strRoadNum, strRoadName, strRoadType, strSuburb, blHideRoadName, blHideRoadNum) + "," + strState + " " + postcode;

        // more features display code
        featureCounter = landCounter + parkingCounter + ExternalCounter + devCounter + InternalCounter;
        if (featureCounter > 0)
        {
            morefeaturesdisplay = morefeaturesdisplay + "<table width=100%>";
            morefeaturesdisplay = morefeaturesdisplay + "<tr><td class=heading2>";
            morefeaturesdisplay = morefeaturesdisplay + "<table width=100%>";
            morefeaturesdisplay = morefeaturesdisplay + "<tr><td></td><td align=left id=moreFeatureDisplay valign='middle'><b><A class=nav HREF=javascript:myShow('MoreInfoBox');javascript:myShow('moreFeatureHide');javascript:myHide('moreFeatureDisplay');><img src='" + ConfigurationManager.AppSettings["webUrl"] + "images/i_plus.jpg' style='vertical-align:baseline;'/> view " + featureCounter + " more feature(s)</a></b></td>";
            morefeaturesdisplay = morefeaturesdisplay + "<td align=left id=moreFeatureHide STYLE=display:none;><b><a class=nav href=javascript:myHide('MoreInfoBox');javascript:myHide('moreFeatureHide');javascript:myShow('moreFeatureDisplay');>>> hide more feature(s)</a></b></td></table>";
            morefeaturesdisplay = morefeaturesdisplay + "</td></tr>";
            morefeaturesdisplay = morefeaturesdisplay + "<tr><td>";
            morefeaturesdisplay = morefeaturesdisplay + "<table width=100% id=MoreInfoBox  STYLE=display:none; >";
            //morefeaturesdisplay = morefeaturesdisplay + "<tr><td>";
            morefeaturesdisplay = morefeaturesdisplay + "<tr><td width='200'></td></tr>";
            if (landCounter > 0)
            {

                //  morefeaturesdisplay = morefeaturesdisplay + "<table width=100%>";
                morefeaturesdisplay = morefeaturesdisplay + "<tR><td colspan=4><b>Land</b></td></tr>";
                morefeaturesdisplay = morefeaturesdisplay + "<tr>";
                if (!String.IsNullOrEmpty(strLotSize))
                {
                    morefeaturesdisplay = morefeaturesdisplay + "<td class=smalldata align=left>" + strLotSize + " " + strLotMeasure + "</td>";
                }
                if (!String.IsNullOrEmpty(strLotFrontage))
                {
                    morefeaturesdisplay = morefeaturesdisplay + "<td class=smalldata align=left>" + strLotFrontage + "M Frontage</td>";
                }

                morefeaturesdisplay = morefeaturesdisplay + "</tr>";
                morefeaturesdisplay = morefeaturesdisplay + "<tr>";

                if (!String.IsNullOrEmpty(strLotOrientation))
                {
                    morefeaturesdisplay = morefeaturesdisplay + "<td class=smalldata align=left>" + strLotOrientation + " Orientation</td>";
                }

                if (!String.IsNullOrEmpty(strZoning))
                {
                    morefeaturesdisplay = morefeaturesdisplay + "<td class=smalldata align=left>Zoning: " + strZoning + "</td>";
                }
                morefeaturesdisplay = morefeaturesdisplay + "</tr>";
                //morefeaturesdisplay = morefeaturesdisplay + "</table>";
            }
            if (parkingCounter > 0)
            {
                //morefeaturesdisplay = morefeaturesdisplay + "<table width=100% >";
                morefeaturesdisplay = morefeaturesdisplay + "<tR><td class=smalldata colspan=4><b>Parking</b></td></tr>";
                morefeaturesdisplay = morefeaturesdisplay + "<tr >";
                if (strcarBays > 0)
                {
                    morefeaturesdisplay = morefeaturesdisplay + "<td class=smalldata align=left>" + strcarBays + " Car Bays</td>";
                }
                if (blParkingExposed)
                {
                    morefeaturesdisplay = morefeaturesdisplay + "<td class=smalldata align=left>Exposed</td>";
                }
                morefeaturesdisplay = morefeaturesdisplay + "</tr><tr >";
                if (strgarages > 0)
                {
                    morefeaturesdisplay = morefeaturesdisplay + "<td class=smalldata align=left>" + strgarages + " Lock-Up Garage</td>";
                }
                if (blRemote)
                {
                    morefeaturesdisplay = morefeaturesdisplay + "<td class=smalldata align=left>Remote</td>";
                }
                if (blSecure)
                {
                    morefeaturesdisplay = morefeaturesdisplay + "<td class=smalldata align=left>Secure</td>";
                }
                morefeaturesdisplay = morefeaturesdisplay + "</tr>";
                //morefeaturesdisplay = morefeaturesdisplay + "</table>";

            }
            if (ExternalCounter > 0)
            {
                //morefeaturesdisplay = morefeaturesdisplay + "<table width=100% >";
                morefeaturesdisplay = morefeaturesdisplay + "<tR><td class=smalldata colspan=4><b>Externals</b></td></tr>";
                morefeaturesdisplay = morefeaturesdisplay + "<tR >";
                if (blOutdoorEnt)
                {
                    morefeaturesdisplay = morefeaturesdisplay + "<td class=smalldata align=left>Outdoor Entertainment</td>";
                }
                if (blReticulation)
                {
                    morefeaturesdisplay = morefeaturesdisplay + "<td class=smalldata align=left>Reticulation</td>";
                }
                if (!String.IsNullOrEmpty(strExternalSqm))
                {
                    morefeaturesdisplay = morefeaturesdisplay + "<td class=smalldata align=left>Ext. Area " + strExternalSqm + "&nbsp;sqm</td>";
                }
                morefeaturesdisplay = morefeaturesdisplay + "</tr><tR >";
                if (blCourtyard)
                {
                    morefeaturesdisplay = morefeaturesdisplay + "<td class=smalldata align=left>Courtyard</td>";
                }
                if (blBore)
                {
                    morefeaturesdisplay = morefeaturesdisplay + "<td class=smalldata align=left>Bore</td>";
                }
                if (blFirb)
                {
                    morefeaturesdisplay = morefeaturesdisplay + "<td class=smalldata align=left>Firb</td>";
                }


                if (!String.IsNullOrEmpty(strnumBalcony))
                {
                    morefeaturesdisplay = morefeaturesdisplay + "<td class=smalldata align=left>" + strnumBalcony + "&nbsp;Balcony(s)</td>";
                }
                morefeaturesdisplay = morefeaturesdisplay + "</tR><tR >";
                if (blPool)
                {
                    morefeaturesdisplay = morefeaturesdisplay + "<td class=smalldata align=left>Pool</td>";
                }
                if (blGardenShed)
                {
                    morefeaturesdisplay = morefeaturesdisplay + "<td class=smalldata align=left>Garden Shed</td>";
                }
                morefeaturesdisplay = morefeaturesdisplay + "</tR>";
                //morefeaturesdisplay = morefeaturesdisplay + "</table>";
            }
            if (InternalCounter > 0)
            {
                //morefeaturesdisplay = morefeaturesdisplay + "<table width=100% >";
                morefeaturesdisplay = morefeaturesdisplay + "<tr><td colspan=4 class=smalldata><b>Internals</b></td></tr><tR >";
                if (!String.IsNullOrEmpty(strNumStudy))
                {
                    morefeaturesdisplay = morefeaturesdisplay + "<td class=smalldata align=left>" + strNumStudy + " Study</td>";
                }

                if (blSecurity)
                {
                    morefeaturesdisplay = morefeaturesdisplay + "<td class=smalldata align=left>Security System</td>";
                }
                morefeaturesdisplay = morefeaturesdisplay + "</tr><tR >";
                if (!String.IsNullOrEmpty(strNumWC))
                {
                    morefeaturesdisplay = morefeaturesdisplay + "<td class=smalldata align=left>" + strNumWC + " WC</td>";
                }
                if (!String.IsNullOrEmpty(strHeating))
                {
                    morefeaturesdisplay = morefeaturesdisplay + "<td class=smalldata align=left>Heating>&nbsp;" + strHeating + "</td>";
                }

                morefeaturesdisplay = morefeaturesdisplay + "</tr><tR >";

                if (blRoomDining)
                {
                    morefeaturesdisplay = morefeaturesdisplay + "<td class=smalldata align=left>Dining</td>";
                }
                if (!String.IsNullOrEmpty(strCooling))
                {
                    morefeaturesdisplay = morefeaturesdisplay + "<td class=smalldata align=left>Cooling>&nbsp;" + strCooling + "</td>";
                }

                morefeaturesdisplay = morefeaturesdisplay + "</tr><tR >";
                if (blRoomLiving)
                {
                    morefeaturesdisplay = morefeaturesdisplay + "<td class=smalldata align=left>Living</td>";
                }
                if (blHasVacumm)
                {
                    morefeaturesdisplay = morefeaturesdisplay + "<td class=smalldata align=left>Vaccum System</td>";
                }

                morefeaturesdisplay = morefeaturesdisplay + "</tr><tR >";

                if (!String.IsNullOrEmpty(strInternalSqm))
                {
                    morefeaturesdisplay = morefeaturesdisplay + "<td class=smalldata align=left>Int. Area " + strInternalSqm + "&nbsp;sqm</td>";
                }
                if (blAlarm)
                {
                    morefeaturesdisplay = morefeaturesdisplay + "<td class=smalldata align=left>House Alarm</td>";
                }


                morefeaturesdisplay = morefeaturesdisplay + "</tr><tR >";
                if (blRoomGames)
                {
                    morefeaturesdisplay = morefeaturesdisplay + "<td class=smalldata align=left>Games</td>";
                }
                if (blRoomFamily)
                {
                    morefeaturesdisplay = morefeaturesdisplay + "<td class=smalldata align=left>Family</td>";
                }
                morefeaturesdisplay = morefeaturesdisplay + "</tR>";
                //morefeaturesdisplay = morefeaturesdisplay + "</table>";
            }
            if (devCounter > 0)
            {
                //morefeaturesdisplay = morefeaturesdisplay + "<table width=100% >";

                morefeaturesdisplay = morefeaturesdisplay + "<tr><td colspan=4 class=smalldata><b>Development Information</b></td></tr>";
                morefeaturesdisplay = morefeaturesdisplay + "<tr >";
                if (!String.IsNullOrEmpty(strStage))
                {
                    morefeaturesdisplay = morefeaturesdisplay + "<td class=smalldata align=left>Stage <%=strStage%> </td>";
                }

                if (!String.IsNullOrEmpty(strBalcony))
                {
                    morefeaturesdisplay = morefeaturesdisplay + "<td class=smalldata align=left><%=strBalcony%> Balcony(s)</td>";
                }

                morefeaturesdisplay = morefeaturesdisplay + "</tr><tr >";

                if (!String.IsNullOrEmpty(strFloor))
                {
                    morefeaturesdisplay = morefeaturesdisplay + "<td class=smalldata align=left>Floor " + strFloor + "</td>";
                }

                if (blDoorman)
                {
                    morefeaturesdisplay = morefeaturesdisplay + "<td class=smalldata align=left>Doorman</td>";
                }

                morefeaturesdisplay = morefeaturesdisplay + "</tr><tr >";
                if (blLift)
                {
                    morefeaturesdisplay = morefeaturesdisplay + "<td class=smalldata align=left>Lift</td>";
                }
                if (blGym)
                {
                    morefeaturesdisplay = morefeaturesdisplay + "<td class=smalldata align=left>Gym</td>";
                }

                morefeaturesdisplay = morefeaturesdisplay + "</tr><tr >";
                if (blManager)
                {
                    morefeaturesdisplay = morefeaturesdisplay + "<td class=smalldata align=left>On Site Manager</td>";
                }
                if (blSpa)
                {
                    morefeaturesdisplay = morefeaturesdisplay + "<td class=smalldata align=left>Spa</td>";
                }
                morefeaturesdisplay = morefeaturesdisplay + "</tR>";
                //morefeaturesdisplay = morefeaturesdisplay + "</table>";
            }
            morefeaturesdisplay = morefeaturesdisplay + "</table></td></tr></table>";
        }
        if (strStatus != null)
        {
            price = getPrice(strPriceOption, strPriceLow.ToString(), strPriceHigh.ToString(), strStatus, strPaymentPeriod, pricedisplay.ToString(), strPricetext, strPricered.ToString());
        }
        getSuburb(strSuburb);
    }

    public void getPropertyNotLive(string pID, string acID)
    {
        pid = pID;
        connection.Open();
        SqlCommand command = new SqlCommand("spGetPropertiesAll", connection);
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.Add(new SqlParameter("@pid", pID));
        command.Parameters.Add(new SqlParameter("@acID", acID));
        command.Parameters.Add(new SqlParameter("@iswebdisplay", "Any"));
        command.Parameters.Add(new SqlParameter("@golive", "Any"));
        SqlDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {

            if (!reader.IsDBNull(reader.GetOrdinal("isWebDisplay")))
            {
                iswebdisplay = reader.GetBoolean(reader.GetOrdinal("isWebDisplay"));
            }
            if (!reader.IsDBNull(reader.GetOrdinal("hidemap")))
            {
                hidemap = reader.GetBoolean(reader.GetOrdinal("hidemap"));
            }
            if (!reader.IsDBNull(reader.GetOrdinal("hidestreet")))
            {
                hidestreet = reader.GetBoolean(reader.GetOrdinal("hidestreet"));
            }

            if (!reader.IsDBNull(reader.GetOrdinal("hassustainability")))
            {
                hassustainability = reader.GetBoolean(reader.GetOrdinal("hassustainability"));
            }
            if (!reader.IsDBNull(reader.GetOrdinal("googlex")))
            {
                googleX = reader.GetString(reader.GetOrdinal("googlex"));
            }
            if (!reader.IsDBNull(reader.GetOrdinal("googley")))
            {
                googleY = reader.GetString(reader.GetOrdinal("googley"));
            }
            if (!reader.IsDBNull(reader.GetOrdinal("lotSize")))
            {
                lotSize = reader.GetDecimal(reader.GetOrdinal("lotSize"));
            }
            if (!reader.IsDBNull(reader.GetOrdinal("acID")))
            {
                acid = reader.GetValue(reader.GetOrdinal("acID")).ToString();
            }
            if (!reader.IsDBNull(reader.GetOrdinal("lotMeasurement")))
            {
                lotMeasurement = reader.GetString(reader.GetOrdinal("lotMeasurement"));
            }
            if (!reader.IsDBNull(reader.GetOrdinal("hasAttachment")))
            {
                hasAttachment = reader.GetBoolean(reader.GetOrdinal("hasAttachment"));
            }
            if (!reader.IsDBNull(reader.GetOrdinal("hasLotPlan")))
            {
                hasLotPlan = reader.GetBoolean(reader.GetOrdinal("hasLotPlan"));
            }
            if (!reader.IsDBNull(reader.GetOrdinal("link")))
            {
                link = reader.GetString(reader.GetOrdinal("link"));
            }
            if (!reader.IsDBNull(reader.GetOrdinal("link2")))
            {
                link2 = reader.GetString(reader.GetOrdinal("link2"));
            }
            if (!reader.IsDBNull(reader.GetOrdinal("numPhotoMore")))
            {
                numPhotoMore = int.Parse(reader.GetValue(reader.GetOrdinal("numPhotoMore")).ToString());
            }
            if (!reader.IsDBNull(reader.GetOrdinal("commercialpriceyearly")))
            {
                commercialpriceYearly = reader.GetDecimal(reader.GetOrdinal("commercialpriceyearly"));
            }
            if (!reader.IsDBNull(reader.GetOrdinal("numFloorPlan")))
            {
                numFloorPlan = int.Parse(reader.GetValue(reader.GetOrdinal("numFloorPlan")).ToString());
            }
            if (!reader.IsDBNull(reader.GetOrdinal("ratesCouncil")))
            {
                ratesCouncil = reader.GetDecimal(reader.GetOrdinal("ratesCouncil"));
            }
            if (!reader.IsDBNull(reader.GetOrdinal("pricesold")))
            {
                soldprice = reader.GetDecimal(reader.GetOrdinal("pricesold"));
            }
            if (!reader.IsDBNull(reader.GetOrdinal("displaysoldprice")))
            {
                bldisplaysoldprice = reader.GetBoolean(reader.GetOrdinal("displaysoldprice"));
            }
            if (!reader.IsDBNull(reader.GetOrdinal("ratesStrata")))
            {
                ratesStrata = reader.GetDecimal(reader.GetOrdinal("ratesStrata"));
            }
            if (!reader.IsDBNull(reader.GetOrdinal("ratesWater")))
            {
                ratesWater = reader.GetDecimal(reader.GetOrdinal("ratesWater"));
            }

            if (!reader.IsDBNull(reader.GetOrdinal("hasAttachment")))
            {
                blPdf = reader.GetBoolean(reader.GetOrdinal("hasAttachment"));
            }

            if (!reader.IsDBNull(reader.GetOrdinal("status")))
            {
                status = reader.GetString(reader.GetOrdinal("status"));
            }
            if (!reader.IsDBNull(reader.GetOrdinal("type")))
            {
                propertytype = reader.GetString(reader.GetOrdinal("type"));
            }
            if (!reader.IsDBNull(reader.GetOrdinal("numBedrooms")))
            {
                //beds = reader.GetInt16(reader.GetOrdinal("numBedrooms")).ToString();
                beds = reader.GetValue(reader.GetOrdinal("numBedrooms")).ToString();
            }
            if (!reader.IsDBNull(reader.GetOrdinal("numBathrooms")))
            {
                //baths = reader.GetInt16(reader.GetOrdinal("numBathrooms")).ToString();
                baths = reader.GetValue(reader.GetOrdinal("numBathrooms")).ToString();
            }
            if (!reader.IsDBNull(reader.GetOrdinal("numGarage")))
            {
                carbays = reader.GetValue(reader.GetOrdinal("numGarage")).ToString();
            }
            if (!reader.IsDBNull(reader.GetOrdinal("aid3")))
            {
                aid3 = int.Parse(reader.GetValue(reader.GetOrdinal("aid3")).ToString());
                //aid3 = reader.GetInt16(reader.GetOrdinal("aid3"));
            }

            if (!reader.IsDBNull(reader.GetOrdinal("descriptionShort")))
            {
                descriptionshort = reader.GetString(reader.GetOrdinal("descriptionShort"));
            }
            if (!reader.IsDBNull(reader.GetOrdinal("descriptionLong")))
            {
                descriptionlong = reader.GetString(reader.GetOrdinal("descriptionLong"));
                descriptionlong = descriptionlong.Replace(Environment.NewLine, "<BR>");
            }

            if (!reader.IsDBNull(reader.GetOrdinal("descriptionBullet")))
            {
                descriptionbullet = reader.GetString(reader.GetOrdinal("descriptionBullet"));
                descriptionbullet = descriptionbullet.Replace("<li></li>", "");
                descriptionbullet = descriptionbullet.Replace("<ul></ul>", "");
                descriptionbullet = descriptionbullet.Replace("<li>", "<li>");
                descriptionbullet = descriptionbullet.Replace("<ul>", "<ul class=check>");
            }

            if (!String.IsNullOrEmpty(descriptionlong))
            {
                if (descriptionlong.Length > 500)
                {
                    moreDescription = moreDescription + "<table width=100% >";
                    moreDescription = moreDescription + "<tr>";
                    moreDescription = moreDescription + "<td   align=left id=moreDescDisplay>" + getshortDescription(descriptionlong, 500) + "...<A  HREF=javascript:javascript:myShow('moreDescHide');javascript:myHide('moreDescDisplay');><b>>> more descriptions</b></a></td>";
                    moreDescription = moreDescription + "</tr>";
                    moreDescription = moreDescription + "<tr><td align=left id=moreDescHide STYLE=display:none;>";
                    moreDescription = moreDescription + descriptionlong;

                    if (!String.IsNullOrEmpty(descriptionbullet))
                    {
                        moreDescription = moreDescription + "<br>" + descriptionbullet;

                    }


                    moreDescription = moreDescription + "<a  href=javascript:javascript:myHide('moreDescHide');javascript:myShow('moreDescDisplay');><b>>> hide descriptions</b></a></td></tr>";
                    moreDescription = moreDescription + "</td></tr>";
                    moreDescription = moreDescription + "</table>";
                }
                else
                {
                    moreDescription = descriptionlong;
                }
            }


            if (!reader.IsDBNull(reader.GetOrdinal("name")))
            {
                strName = reader.GetString(reader.GetOrdinal("name"));
            }
            if (!reader.IsDBNull(reader.GetOrdinal("unitNum")))
            {
                strUnitNum = reader.GetString(reader.GetOrdinal("unitNum"));
            }
            if (!reader.IsDBNull(reader.GetOrdinal("rdNum")))
            {
                strRoadNum = reader.GetString(reader.GetOrdinal("rdNum"));
            }
            if (!reader.IsDBNull(reader.GetOrdinal("rdName")))
            {
                strRoadName = reader.GetString(reader.GetOrdinal("rdName"));
            }
            if (!reader.IsDBNull(reader.GetOrdinal("rdType")))
            {
                strRoadType = reader.GetString(reader.GetOrdinal("rdType"));
            }
            if (!reader.IsDBNull(reader.GetOrdinal("status")))
            {
                strStatus = reader.GetString(reader.GetOrdinal("status"));
            }
            if (!reader.IsDBNull(reader.GetOrdinal("suburb")))
            {
                strSuburb = reader.GetString(reader.GetOrdinal("suburb"));
            }
            if (!reader.IsDBNull(reader.GetOrdinal("hideRoadNum")))
            {
                blHideRoadNum = reader.GetBoolean(reader.GetOrdinal("hideRoadNum"));
            }
            if (!reader.IsDBNull(reader.GetOrdinal("hideRoadName")))
            {
                blHideRoadName = reader.GetBoolean(reader.GetOrdinal("hideRoadName"));
            }
            if (!reader.IsDBNull(reader.GetOrdinal("postcode")))
            {
                postcode = reader.GetString(reader.GetOrdinal("postcode"));
            }
            if (!reader.IsDBNull(reader.GetOrdinal("state")))
            {
                strState = reader.GetString(reader.GetOrdinal("state"));
            }
            if (!reader.IsDBNull(reader.GetOrdinal("priceOption")))
            {
                strPriceOption = reader.GetString(reader.GetOrdinal("priceOption"));
            }
            if (!reader.IsDBNull(reader.GetOrdinal("pricetext")))
            {
                strPricetext = reader.GetString(reader.GetOrdinal("pricetext"));
            }

            if (!reader.IsDBNull(reader.GetOrdinal("priceRed")))
            {
                strPricered = reader.GetBoolean(reader.GetOrdinal("priceRed"));
            }
            if (!reader.IsDBNull(reader.GetOrdinal("priceLow")))
            {
                strPriceLow = reader.GetDecimal(reader.GetOrdinal("priceLow"));
            }
            if (!reader.IsDBNull(reader.GetOrdinal("priceHigh")))
            {
                strPriceHigh = reader.GetDecimal(reader.GetOrdinal("priceHigh"));
            }
            if (!reader.IsDBNull(reader.GetOrdinal("paymentPeriod")))
            {
                strPaymentPeriod = reader.GetString(reader.GetOrdinal("paymentPeriod"));
            }

            if (!reader.IsDBNull(reader.GetOrdinal("dateListed")))
            {
                strdateListed = reader.GetDateTime(reader.GetOrdinal("dateListed"));
            }
            //For available
            if (!reader.IsDBNull(reader.GetOrdinal("isAvailableNow")))
            {
                isAvailableNow = reader.GetBoolean(reader.GetOrdinal("isAvailableNow"));

                if (!reader.IsDBNull(reader.GetOrdinal("availablefrom")))
                {
                    strAvailablefrom = reader.GetDateTime(reader.GetOrdinal("availablefrom"));
                }



            }

            txt_Homeopen2To = "";
            txt_Homeopen1To = "";
            txt_Homeopen2From = "";
            txt_Homeopen1From = "";

            if (!reader.IsDBNull(reader.GetOrdinal("homeopen2To")))
            {
                strHomeopen2To = reader.GetDateTime(reader.GetOrdinal("homeopen2To"));
                txt_Homeopen2To = strHomeopen2To.ToString();
            }
            if (!reader.IsDBNull(reader.GetOrdinal("homeopen2From")))
            {
                strHomeopen2From = reader.GetDateTime(reader.GetOrdinal("homeopen2From"));
                txt_Homeopen2From = strHomeopen2From.ToString();
            }
            if (!reader.IsDBNull(reader.GetOrdinal("homeopen1To")))
            {
                strHomeopen1To = reader.GetDateTime(reader.GetOrdinal("homeopen1To"));
                txt_Homeopen1To = strHomeopen1To.ToString();
            }
            if (!reader.IsDBNull(reader.GetOrdinal("homeopen1From")))
            {
                strHomeopen1From = reader.GetDateTime(reader.GetOrdinal("homeopen1From"));
                txt_Homeopen1From = strHomeopen1From.ToString();
            }


            if (!reader.IsDBNull(reader.GetOrdinal("dateSold")))
            {
                dateSold = reader.GetDateTime(reader.GetOrdinal("dateSold"));
            }
            if (!reader.IsDBNull(reader.GetOrdinal("onadate")))
            {
                onadate = reader.GetDateTime(reader.GetOrdinal("onadate"));
            }
            if (!reader.IsDBNull(reader.GetOrdinal("datelisted")))
            {
                datelisted = reader.GetDateTime(reader.GetOrdinal("datelisted"));
            }
            auctiondate = "";
            auctiontime = "";
            if (!reader.IsDBNull(reader.GetOrdinal("auctionDate")))
            {
                DateTime auctiondateS = reader.GetDateTime(reader.GetOrdinal("auctionDate"));
                auctiondate = auctiondateS.ToString();
            }

            if (!reader.IsDBNull(reader.GetOrdinal("auctionTime")))
            {
                auctiontime = reader.GetString(reader.GetOrdinal("auctionTime"));
            }
            if (!reader.IsDBNull(reader.GetOrdinal("aid1")))
            {
                aid1 = int.Parse(reader.GetValue(reader.GetOrdinal("aid1")).ToString());
                //aid1 = reader.GetInt16(reader.GetOrdinal("aid1"));
            }
            if (!reader.IsDBNull(reader.GetOrdinal("aid2")))
            {
                aid2 = int.Parse(reader.GetValue(reader.GetOrdinal("aid2")).ToString());
                //aid2 = reader.GetInt16(reader.GetOrdinal("aid2"));
            }
            if (!reader.IsDBNull(reader.GetOrdinal("aid3")))
            {
                aid3 = int.Parse(reader.GetValue(reader.GetOrdinal("aid3")).ToString());
                //aid3 = reader.GetInt16(reader.GetOrdinal("aid3"));
            }
            if (!reader.IsDBNull(reader.GetOrdinal("hideprice")))
            {
                pricedisplay = reader.GetBoolean(reader.GetOrdinal("hideprice"));
            }
            if (!reader.IsDBNull(reader.GetOrdinal("hasPhotoLarge")))
            {
                hasphotolarge = reader.GetBoolean(reader.GetOrdinal("hasPhotoLarge"));
            }

            if (!reader.IsDBNull(reader.GetOrdinal("isFurnished")))
            {
                blFurnished = reader.GetBoolean(reader.GetOrdinal("isFurnished"));

            }

            if (!reader.IsDBNull(reader.GetOrdinal("lotSize")))
            {
                strLotSize = reader.GetDecimal(reader.GetOrdinal("lotSize")).ToString();
                landCounter = landCounter + 1;
            }
            if (!reader.IsDBNull(reader.GetOrdinal("lotMeasurement")))
            {
                strLotMeasure = reader.GetString(reader.GetOrdinal("lotMeasurement"));

            }
            if (!reader.IsDBNull(reader.GetOrdinal("zoning")))
            {
                strZoning = reader.GetString(reader.GetOrdinal("zoning"));
                landCounter = landCounter + 1;
            }
            if (!reader.IsDBNull(reader.GetOrdinal("lotOrientation")))
            {
                strLotOrientation = reader.GetString(reader.GetOrdinal("lotOrientation"));
                landCounter = landCounter + 1;
            }
            if (!reader.IsDBNull(reader.GetOrdinal("lotFrontage")))
            {
                strLotFrontage = reader.GetString(reader.GetOrdinal("lotFrontage"));
                landCounter = landCounter + 1;
            }
            if (!reader.IsDBNull(reader.GetOrdinal("numcarbays")))
            {
                //strcarBays = reader.GetInt16(reader.GetOrdinal("numcarbays"));
                strcarBays = int.Parse(reader.GetValue(reader.GetOrdinal("numcarbays")).ToString());
                strTotalSpace = strTotalSpace + strcarBays;
                parkingCounter = parkingCounter + 1;
            }
            if (!reader.IsDBNull(reader.GetOrdinal("numGarage")))
            {
                //strgarages = reader.GetInt16(reader.GetOrdinal("numGarage"));
                strgarages = int.Parse(reader.GetValue(reader.GetOrdinal("numGarage")).ToString());
                strTotalSpace = strTotalSpace + strgarages;
                parkingCounter = parkingCounter + 1;
            }
            if (!reader.IsDBNull(reader.GetOrdinal("hasParkingExposed")))
            {
                blParkingExposed = reader.GetBoolean(reader.GetOrdinal("hasParkingExposed"));
                if (blParkingExposed)
                {
                    //  parkingCounter = parkingCounter + 1;
                }
            }
            if (!reader.IsDBNull(reader.GetOrdinal("hasgarageremote")))
            {
                blRemote = reader.GetBoolean(reader.GetOrdinal("hasgarageremote"));
                if (blRemote)
                {
                    // parkingCounter = parkingCounter + 1;
                }
            }
            if (!reader.IsDBNull(reader.GetOrdinal("hasSecureCarPark")))
            {
                blSecure = reader.GetBoolean(reader.GetOrdinal("hasSecureCarPark"));
                if (blSecure)
                {
                    // parkingCounter = parkingCounter + 1;
                }
            }
            if (!reader.IsDBNull(reader.GetOrdinal("hasOutdoorEnt")))
            {
                blOutdoorEnt = reader.GetBoolean(reader.GetOrdinal("hasOutdoorEnt"));
                if (blOutdoorEnt)
                {
                    ExternalCounter = ExternalCounter + 1;
                }
            }
            /* if (!reader.IsDBNull(reader.GetOrdinal("hasCourtyard")))
             {
                 blCourtyard = reader.GetBoolean(reader.GetOrdinal("hasCourtyard"));
                 if (blCourtyard)
                 {
                     ExternalCounter = ExternalCounter + 1;
                 }
             }*/
            if (!reader.IsDBNull(reader.GetOrdinal("hasReticulation")))
            {
                blReticulation = reader.GetBoolean(reader.GetOrdinal("hasReticulation"));
                if (blReticulation)
                {
                    ExternalCounter = ExternalCounter + 1;
                }
            }
            if (!reader.IsDBNull(reader.GetOrdinal("hasBore")))
            {
                blBore = reader.GetBoolean(reader.GetOrdinal("hasBore"));
                if (blBore)
                {
                    ExternalCounter = ExternalCounter + 1;
                }
            }

            if (!reader.IsDBNull(reader.GetOrdinal("isFirb")))
            {
                blFirb = reader.GetBoolean(reader.GetOrdinal("isFirb"));
                if (blFirb)
                {
                    ExternalCounter = ExternalCounter + 1;
                }
            }

            if (!reader.IsDBNull(reader.GetOrdinal("hasGardenShed")))
            {
                blGardenShed = reader.GetBoolean(reader.GetOrdinal("hasGardenShed"));
                if (blGardenShed)
                {
                    ExternalCounter = ExternalCounter + 1;
                }
            }
            if (!reader.IsDBNull(reader.GetOrdinal("hasPool")))
            {
                blPool = reader.GetBoolean(reader.GetOrdinal("hasPool"));
                if (blPool)
                {
                    ExternalCounter = ExternalCounter + 1;
                }
            }
            if (!reader.IsDBNull(reader.GetOrdinal("hascourtyard")))
            {
                strhascourtyard = reader.GetBoolean(reader.GetOrdinal("hascourtyard"));
                if (strhascourtyard)
                {
                    ExternalCounter = ExternalCounter + 1;
                }
            }
            if (!reader.IsDBNull(reader.GetOrdinal("numBalcony")))
            {
                //strnumBalcony = reader.GetInt16(reader.GetOrdinal("numBalcony")).ToString();
                byte Balcony = reader.GetByte(reader.GetOrdinal("numBalcony"));
                strnumBalcony = Balcony.ToString();
                ExternalCounter = ExternalCounter + 1;
            }
            if (!reader.IsDBNull(reader.GetOrdinal("sqmExternal")))
            {
                strExternalSqm = reader.GetValue(reader.GetOrdinal("sqmExternal")).ToString();
                ExternalCounter = ExternalCounter + 1;
            }
            if (!reader.IsDBNull(reader.GetOrdinal("numStudy")))
            {
                //strNumStudy = reader.GetInt32(reader.GetOrdinal("numStudy")).ToString();
                strNumStudy = reader.GetValue(reader.GetOrdinal("numStudy")).ToString();
                InternalCounter = InternalCounter + 1;
            }
            if (!reader.IsDBNull(reader.GetOrdinal("numWC")))
            {
                strNumWC = reader.GetValue(reader.GetOrdinal("numWC")).ToString();
                InternalCounter = InternalCounter + 1;
            }
            if (!reader.IsDBNull(reader.GetOrdinal("heatingType")))
            {
                strHeating = reader.GetString(reader.GetOrdinal("heatingType"));
                InternalCounter = InternalCounter + 1;
            }
            if (!reader.IsDBNull(reader.GetOrdinal("coolingType")))
            {
                strCooling = reader.GetString(reader.GetOrdinal("coolingType"));
                InternalCounter = InternalCounter + 1;
            }
            if (!reader.IsDBNull(reader.GetOrdinal("hasSecuritySystem")))
            {
                blSecurity = reader.GetBoolean(reader.GetOrdinal("hasSecuritySystem"));
                if (blSecurity)
                {
                    InternalCounter = InternalCounter + 1;
                }
            }
            if (!reader.IsDBNull(reader.GetOrdinal("hasHouseAlarm")))
            {
                blAlarm = reader.GetBoolean(reader.GetOrdinal("hasHouseAlarm"));
                if (blAlarm)
                {
                    InternalCounter = InternalCounter + 1;
                }
            }
            if (!reader.IsDBNull(reader.GetOrdinal("hasRoomDining")))
            {
                blRoomDining = reader.GetBoolean(reader.GetOrdinal("hasRoomDining"));
                if (blRoomDining)
                {
                    InternalCounter = InternalCounter + 1;
                }
            }
            if (!reader.IsDBNull(reader.GetOrdinal("hasRoomLiving")))
            {
                blRoomLiving = reader.GetBoolean(reader.GetOrdinal("hasRoomLiving"));
                if (blRoomLiving)
                {
                    InternalCounter = InternalCounter + 1;
                }
            }
            if (!reader.IsDBNull(reader.GetOrdinal("hasvaccumsystem")))
            {
                blHasVacumm = reader.GetBoolean(reader.GetOrdinal("hasvaccumsystem"));
                if (blHasVacumm)
                {
                    InternalCounter = InternalCounter + 1;
                }
            }
            if (!reader.IsDBNull(reader.GetOrdinal("hasRoomGames")))
            {
                blRoomGames = reader.GetBoolean(reader.GetOrdinal("hasRoomGames"));
                if (blRoomGames)
                {
                    InternalCounter = InternalCounter + 1;
                }
            }
            if (!reader.IsDBNull(reader.GetOrdinal("hasRoomFamily")))
            {
                blRoomFamily = reader.GetBoolean(reader.GetOrdinal("hasRoomFamily"));
                if (blRoomFamily)
                {
                    InternalCounter = InternalCounter + 1;
                }
            }
            if (!reader.IsDBNull(reader.GetOrdinal("sqmInternal")))
            {
                strInternalSqm = reader.GetValue(reader.GetOrdinal("sqmInternal")).ToString();
                InternalCounter = InternalCounter + 1;
            }
            if (!reader.IsDBNull(reader.GetOrdinal("stage")))
            {
                strStage = reader.GetString(reader.GetOrdinal("stage"));
                devCounter = devCounter + 1;
            }
            if (!reader.IsDBNull(reader.GetOrdinal("numBalcony")))
            {
                byte Balcony = reader.GetByte(reader.GetOrdinal("numBalcony"));
                strBalcony = Balcony.ToString();
                devCounter = devCounter + 1;
            }
            if (!reader.IsDBNull(reader.GetOrdinal("unitLevel")))
            {
                strFloor = reader.GetString(reader.GetOrdinal("unitLevel"));
                devCounter = devCounter + 1;
            }
            if (!reader.IsDBNull(reader.GetOrdinal("hasLift")))
            {
                blLift = reader.GetBoolean(reader.GetOrdinal("hasLift"));
                if (blLift)
                {
                    devCounter = devCounter + 1;
                }
            }
            if (!reader.IsDBNull(reader.GetOrdinal("hasGym")))
            {
                blGym = reader.GetBoolean(reader.GetOrdinal("hasGym"));
                if (blGym)
                {
                    devCounter = devCounter + 1;
                }
            }
            if (!reader.IsDBNull(reader.GetOrdinal("hasSpa")))
            {
                blSpa = reader.GetBoolean(reader.GetOrdinal("hasSpa"));
                if (blSpa)
                {
                    devCounter = devCounter + 1;
                }
            }
            if (!reader.IsDBNull(reader.GetOrdinal("hasManager")))
            {
                blManager = reader.GetBoolean(reader.GetOrdinal("hasManager"));
                if (blManager)
                {
                    devCounter = devCounter + 1;
                }
            }
            if (!reader.IsDBNull(reader.GetOrdinal("hasDoorman")))
            {
                blDoorman = reader.GetBoolean(reader.GetOrdinal("hasDoorman"));
                if (blDoorman)
                {
                    devCounter = devCounter + 1;
                }
            }
        }

        homeopen = "";
        if (!String.IsNullOrEmpty(strHomeopen1To.ToString()) && !String.IsNullOrEmpty(strHomeopen1From.ToString()))
        {

            if (!(strHomeopen1From.ToShortTimeString().ToString() == strHomeopen1To.ToShortTimeString().ToString()))
            {
                if (strHomeopen1From.Year < DateTime.Now.Year)
                {
                    homeopen = "Sat: " + strHomeopen1From.ToShortTimeString().ToString() + " to " + strHomeopen1To.ToShortTimeString().ToString();
                }
                else
                {
                    homeopen = strHomeopen1From.ToLongDateString().ToString() + " " + strHomeopen1From.ToShortTimeString().ToString() + " to " + strHomeopen1To.ToShortTimeString().ToString();
                }
            }


        }
        if (!String.IsNullOrEmpty(strHomeopen2To.ToString()) && !String.IsNullOrEmpty(strHomeopen2From.ToString()))
        {

            if (!(strHomeopen2From.ToShortTimeString().ToString() == strHomeopen2To.ToShortTimeString().ToString()))
            {
                if (homeopen == "")
                {

                    if (strHomeopen2From.Year < DateTime.Now.Year)
                    {
                        homeopen = "Sun: " + strHomeopen2From.ToShortTimeString().ToString() + " to " + strHomeopen2To.ToShortTimeString().ToString();
                    }
                    else
                    {
                        homeopen = strHomeopen2From.ToLongDateString().ToString() + " " + strHomeopen2From.ToShortTimeString().ToString().ToLower() + " to " + strHomeopen2To.ToShortTimeString().ToString();
                    }
                }
                else
                {
                    if (strHomeopen2From.Year < DateTime.Now.Year)
                    {
                        homeopen = homeopen + "<br>Sun: " + strHomeopen2From.ToShortTimeString().ToString() + " to " + strHomeopen2To.ToShortTimeString().ToString();
                    }
                    else
                    {
                        homeopen = homeopen + "<br>" + strHomeopen2From.ToLongDateString().ToString() + " " + strHomeopen2From.ToShortTimeString().ToString() + " to " + strHomeopen2To.ToShortTimeString().ToString();
                    }
                }

            }

        }

        connection.Close();
        address = getAddress(strName, strUnitNum, strRoadNum, strRoadName, strRoadType, strSuburb, blHideRoadName, blHideRoadNum);
        gaddress = getGAddress(null, strUnitNum, strRoadNum, strRoadName, strRoadType, strSuburb, blHideRoadName, blHideRoadNum) + "," + strState + " " + postcode;

        // more features display code
        featureCounter = landCounter + parkingCounter + ExternalCounter + devCounter + InternalCounter;
        if (featureCounter > 0)
        {
            morefeaturesdisplay = morefeaturesdisplay + "<table width=100%>";
            morefeaturesdisplay = morefeaturesdisplay + "<tr><td class=heading2>";
            morefeaturesdisplay = morefeaturesdisplay + "<table width=100%>";
            morefeaturesdisplay = morefeaturesdisplay + "<tr><td></td><td align=left id=moreFeatureDisplay valign='middle'><b><A class=nav HREF=javascript:myShow('MoreInfoBox');javascript:myShow('moreFeatureHide');javascript:myHide('moreFeatureDisplay');><img src='" + ConfigurationManager.AppSettings["webUrl"] + "images/i_plus.jpg' style='vertical-align:baseline;'/> view " + featureCounter + " more feature(s)</a></b></td>";
            morefeaturesdisplay = morefeaturesdisplay + "<td align=left id=moreFeatureHide STYLE=display:none;><b><a class=nav href=javascript:myHide('MoreInfoBox');javascript:myHide('moreFeatureHide');javascript:myShow('moreFeatureDisplay');>>> hide more feature(s)</a></b></td></table>";
            morefeaturesdisplay = morefeaturesdisplay + "</td></tr>";
            morefeaturesdisplay = morefeaturesdisplay + "<tr><td>";
            morefeaturesdisplay = morefeaturesdisplay + "<table width=100% id=MoreInfoBox  STYLE=display:none; >";
            //morefeaturesdisplay = morefeaturesdisplay + "<tr><td>";
            morefeaturesdisplay = morefeaturesdisplay + "<tr><td width='200'></td></tr>";
            if (landCounter > 0)
            {

                //  morefeaturesdisplay = morefeaturesdisplay + "<table width=100%>";
                morefeaturesdisplay = morefeaturesdisplay + "<tR><td colspan=4><b>Land</b></td></tr>";
                morefeaturesdisplay = morefeaturesdisplay + "<tr>";
                if (!String.IsNullOrEmpty(strLotSize))
                {
                    morefeaturesdisplay = morefeaturesdisplay + "<td class=smalldata align=left>" + strLotSize + " " + strLotMeasure + "</td>";
                }
                if (!String.IsNullOrEmpty(strLotFrontage))
                {
                    morefeaturesdisplay = morefeaturesdisplay + "<td class=smalldata align=left>" + strLotFrontage + "M Frontage</td>";
                }

                morefeaturesdisplay = morefeaturesdisplay + "</tr>";
                morefeaturesdisplay = morefeaturesdisplay + "<tr>";

                if (!String.IsNullOrEmpty(strLotOrientation))
                {
                    morefeaturesdisplay = morefeaturesdisplay + "<td class=smalldata align=left>" + strLotOrientation + " Orientation</td>";
                }

                if (!String.IsNullOrEmpty(strZoning))
                {
                    morefeaturesdisplay = morefeaturesdisplay + "<td class=smalldata align=left>Zoning: " + strZoning + "</td>";
                }
                morefeaturesdisplay = morefeaturesdisplay + "</tr>";
                //morefeaturesdisplay = morefeaturesdisplay + "</table>";
            }
            if (parkingCounter > 0)
            {
                //morefeaturesdisplay = morefeaturesdisplay + "<table width=100% >";
                morefeaturesdisplay = morefeaturesdisplay + "<tR><td class=smalldata colspan=4><b>Parking</b></td></tr>";
                morefeaturesdisplay = morefeaturesdisplay + "<tr >";
                if (strcarBays > 0)
                {
                    morefeaturesdisplay = morefeaturesdisplay + "<td class=smalldata align=left>" + strcarBays + " Car Bays</td>";
                }
                if (blParkingExposed)
                {
                    morefeaturesdisplay = morefeaturesdisplay + "<td class=smalldata align=left>Exposed</td>";
                }
                morefeaturesdisplay = morefeaturesdisplay + "</tr><tr >";
                if (strgarages > 0)
                {
                    morefeaturesdisplay = morefeaturesdisplay + "<td class=smalldata align=left>" + strgarages + " Lock-Up Garage</td>";
                }
                if (blRemote)
                {
                    morefeaturesdisplay = morefeaturesdisplay + "<td class=smalldata align=left>Remote</td>";
                }
                if (blSecure)
                {
                    morefeaturesdisplay = morefeaturesdisplay + "<td class=smalldata align=left>Secure</td>";
                }
                morefeaturesdisplay = morefeaturesdisplay + "</tr>";
                //morefeaturesdisplay = morefeaturesdisplay + "</table>";

            }
            if (ExternalCounter > 0)
            {
                //morefeaturesdisplay = morefeaturesdisplay + "<table width=100% >";
                morefeaturesdisplay = morefeaturesdisplay + "<tR><td class=smalldata colspan=4><b>Externals</b></td></tr>";
                morefeaturesdisplay = morefeaturesdisplay + "<tR >";
                if (blOutdoorEnt)
                {
                    morefeaturesdisplay = morefeaturesdisplay + "<td class=smalldata align=left>Outdoor Entertainment</td>";
                }
                if (blReticulation)
                {
                    morefeaturesdisplay = morefeaturesdisplay + "<td class=smalldata align=left>Reticulation</td>";
                }
                if (!String.IsNullOrEmpty(strExternalSqm))
                {
                    morefeaturesdisplay = morefeaturesdisplay + "<td class=smalldata align=left>Ext. Area " + strExternalSqm + "&nbsp;sqm</td>";
                }
                morefeaturesdisplay = morefeaturesdisplay + "</tr><tR >";
                if (blCourtyard)
                {
                    morefeaturesdisplay = morefeaturesdisplay + "<td class=smalldata align=left>Courtyard</td>";
                }
                if (blBore)
                {
                    morefeaturesdisplay = morefeaturesdisplay + "<td class=smalldata align=left>Bore</td>";
                }
                if (blFirb)
                {
                    morefeaturesdisplay = morefeaturesdisplay + "<td class=smalldata align=left>Firb</td>";
                }


                if (!String.IsNullOrEmpty(strnumBalcony))
                {
                    morefeaturesdisplay = morefeaturesdisplay + "<td class=smalldata align=left>" + strnumBalcony + "&nbsp;Balcony(s)</td>";
                }
                morefeaturesdisplay = morefeaturesdisplay + "</tR><tR >";
                if (blPool)
                {
                    morefeaturesdisplay = morefeaturesdisplay + "<td class=smalldata align=left>Pool</td>";
                }
                if (blGardenShed)
                {
                    morefeaturesdisplay = morefeaturesdisplay + "<td class=smalldata align=left>Garden Shed</td>";
                }
                morefeaturesdisplay = morefeaturesdisplay + "</tR>";
                //morefeaturesdisplay = morefeaturesdisplay + "</table>";
            }
            if (InternalCounter > 0)
            {
                //morefeaturesdisplay = morefeaturesdisplay + "<table width=100% >";
                morefeaturesdisplay = morefeaturesdisplay + "<tr><td colspan=4 class=smalldata><b>Internals</b></td></tr><tR >";
                if (!String.IsNullOrEmpty(strNumStudy))
                {
                    morefeaturesdisplay = morefeaturesdisplay + "<td class=smalldata align=left>" + strNumStudy + " Study</td>";
                }

                if (blSecurity)
                {
                    morefeaturesdisplay = morefeaturesdisplay + "<td class=smalldata align=left>Security System</td>";
                }
                morefeaturesdisplay = morefeaturesdisplay + "</tr><tR >";
                if (!String.IsNullOrEmpty(strNumWC))
                {
                    morefeaturesdisplay = morefeaturesdisplay + "<td class=smalldata align=left>" + strNumWC + " WC</td>";
                }
                if (!String.IsNullOrEmpty(strHeating))
                {
                    morefeaturesdisplay = morefeaturesdisplay + "<td class=smalldata align=left>Heating>&nbsp;" + strHeating + "</td>";
                }

                morefeaturesdisplay = morefeaturesdisplay + "</tr><tR >";

                if (blRoomDining)
                {
                    morefeaturesdisplay = morefeaturesdisplay + "<td class=smalldata align=left>Dining</td>";
                }
                if (!String.IsNullOrEmpty(strCooling))
                {
                    morefeaturesdisplay = morefeaturesdisplay + "<td class=smalldata align=left>Cooling>&nbsp;" + strCooling + "</td>";
                }

                morefeaturesdisplay = morefeaturesdisplay + "</tr><tR >";
                if (blRoomLiving)
                {
                    morefeaturesdisplay = morefeaturesdisplay + "<td class=smalldata align=left>Living</td>";
                }
                if (blHasVacumm)
                {
                    morefeaturesdisplay = morefeaturesdisplay + "<td class=smalldata align=left>Vaccum System</td>";
                }

                morefeaturesdisplay = morefeaturesdisplay + "</tr><tR >";

                if (!String.IsNullOrEmpty(strInternalSqm))
                {
                    morefeaturesdisplay = morefeaturesdisplay + "<td class=smalldata align=left>Int. Area " + strInternalSqm + "&nbsp;sqm</td>";
                }
                if (blAlarm)
                {
                    morefeaturesdisplay = morefeaturesdisplay + "<td class=smalldata align=left>House Alarm</td>";
                }


                morefeaturesdisplay = morefeaturesdisplay + "</tr><tR >";
                if (blRoomGames)
                {
                    morefeaturesdisplay = morefeaturesdisplay + "<td class=smalldata align=left>Games</td>";
                }
                if (blRoomFamily)
                {
                    morefeaturesdisplay = morefeaturesdisplay + "<td class=smalldata align=left>Family</td>";
                }
                morefeaturesdisplay = morefeaturesdisplay + "</tR>";
                //morefeaturesdisplay = morefeaturesdisplay + "</table>";
            }
            if (devCounter > 0)
            {
                //morefeaturesdisplay = morefeaturesdisplay + "<table width=100% >";

                morefeaturesdisplay = morefeaturesdisplay + "<tr><td colspan=4 class=smalldata><b>Development Information</b></td></tr>";
                morefeaturesdisplay = morefeaturesdisplay + "<tr >";
                if (!String.IsNullOrEmpty(strStage))
                {
                    morefeaturesdisplay = morefeaturesdisplay + "<td class=smalldata align=left>Stage <%=strStage%> </td>";
                }

                if (!String.IsNullOrEmpty(strBalcony))
                {
                    morefeaturesdisplay = morefeaturesdisplay + "<td class=smalldata align=left><%=strBalcony%> Balcony(s)</td>";
                }

                morefeaturesdisplay = morefeaturesdisplay + "</tr><tr >";

                if (!String.IsNullOrEmpty(strFloor))
                {
                    morefeaturesdisplay = morefeaturesdisplay + "<td class=smalldata align=left>Floor " + strFloor + "</td>";
                }

                if (blDoorman)
                {
                    morefeaturesdisplay = morefeaturesdisplay + "<td class=smalldata align=left>Doorman</td>";
                }

                morefeaturesdisplay = morefeaturesdisplay + "</tr><tr >";
                if (blLift)
                {
                    morefeaturesdisplay = morefeaturesdisplay + "<td class=smalldata align=left>Lift</td>";
                }
                if (blGym)
                {
                    morefeaturesdisplay = morefeaturesdisplay + "<td class=smalldata align=left>Gym</td>";
                }

                morefeaturesdisplay = morefeaturesdisplay + "</tr><tr >";
                if (blManager)
                {
                    morefeaturesdisplay = morefeaturesdisplay + "<td class=smalldata align=left>On Site Manager</td>";
                }
                if (blSpa)
                {
                    morefeaturesdisplay = morefeaturesdisplay + "<td class=smalldata align=left>Spa</td>";
                }
                morefeaturesdisplay = morefeaturesdisplay + "</tR>";
                //morefeaturesdisplay = morefeaturesdisplay + "</table>";
            }
            morefeaturesdisplay = morefeaturesdisplay + "</table></td></tr></table>";
        }
        price = getPrice(strPriceOption, strPriceLow.ToString(), strPriceHigh.ToString(), strStatus, strPaymentPeriod, pricedisplay.ToString(), strPricetext, strPricered.ToString());
        getSuburb(strSuburb);
    }


    public string getdisplaysearchfeatures(string numbedroom, string numbathroom, string numcarbay, string numstudy, string haspool, string numgarage)
    {
        string dislayhtml = "";
        int xBed = 0;
        int xBath = 0;
        int xCar = 0;

        if (!String.IsNullOrEmpty(numbedroom))
        {
            if (int.Parse(numbedroom) > 0)
            {
                xBed = 1;
            }
        }

        if (!String.IsNullOrEmpty(numbathroom))
        {
            if (int.Parse(numbathroom) > 0)
            {
                xBath = 1;
            }

        }

        if (!String.IsNullOrEmpty(numcarbay))
        {
            if (int.Parse(numcarbay) > 0)
            {
                xCar = 1;
            }
        }
        if (!String.IsNullOrEmpty(numgarage))
        {
            if (int.Parse(numgarage) > 0)
            {
                xCar = 1;
            }
        }
        if (xBed > 0 || xBath > 0 || xCar > 0)
        {
            dislayhtml = dislayhtml + "<table class='borderGrey'><tr>";
            int TotalSpace = 0;
            if (!String.IsNullOrEmpty(numbedroom))
            {
                if (int.Parse(numbedroom) > 0)
                {
                    dislayhtml = dislayhtml + "<td><img src=" + ConfigurationManager.AppSettings["webUrl"].ToString() + "images/i_bed.jpg title=bed align=absmiddle>" + numbedroom + "</td>";
                }
            }
            if (!String.IsNullOrEmpty(numbathroom))
            {
                if (int.Parse(numbathroom) > 0)
                {
                    dislayhtml = dislayhtml + "<td><img src=" + ConfigurationManager.AppSettings["webUrl"].ToString() + "images/i_bath.jpg title=bath align=absmiddle>&nbsp;" + numbathroom + "</td>";
                }
            }
            if (!String.IsNullOrEmpty(numcarbay))
            {
                TotalSpace = TotalSpace + int.Parse(numcarbay);

            }
            if (!String.IsNullOrEmpty(numgarage))
            {
                TotalSpace = TotalSpace + int.Parse(numgarage);

            }
            if (TotalSpace > 0)
            {
                dislayhtml = dislayhtml + "<td><img src=" + ConfigurationManager.AppSettings["webUrl"].ToString() + "images/i_car.jpg title=car align=absmiddle>&nbsp;" + TotalSpace + "</td>";
            }

            dislayhtml = dislayhtml + "</tr></table>";
        }
        return dislayhtml;
    }

    public string getdisplaysearchfeaturesSmall(string numbedroom, string numbathroom, string numcarbay, string numstudy, string haspool, string numgarage)
    {
        string dislayhtml = "";
        int xBed = 0;
        int xBath = 0;
        int xCar = 0;

        if (!String.IsNullOrEmpty(numbedroom))
        {
            if (int.Parse(numbedroom) > 0)
            {
                xBed = 1;
            }
        }

        if (!String.IsNullOrEmpty(numbathroom))
        {
            if (int.Parse(numbathroom) > 0)
            {
                xBath = 1;
            }

        }

        if (!String.IsNullOrEmpty(numcarbay))
        {
            if (int.Parse(numcarbay) > 0)
            {
                xCar = 1;
            }
        }
        if (!String.IsNullOrEmpty(numgarage))
        {
            if (int.Parse(numgarage) > 0)
            {
                xCar = 1;
            }
        }

        if (xBed > 0 || xBath > 0 || xCar > 0)
        {


            // dislayhtml = dislayhtml + "<table border=0 cellspacing=0 cellpadding=0><tr><td align=right><img src=" + ConfigurationManager.AppSettings["webUrl"].ToString() + "images/ahc/web/icon_left_s.gif ></td>";
            int TotalSpace = 0;
            if (!String.IsNullOrEmpty(numbedroom))
            {
                if (int.Parse(numbedroom) > 0)
                {
                    dislayhtml = dislayhtml + "<td><img src=images/i_bed.jpg title=bed align=absmiddle>&nbsp;" + numbedroom + "&nbsp;</td>";
                }
            }
            if (!String.IsNullOrEmpty(numbathroom))
            {
                if (int.Parse(numbathroom) > 0)
                {
                    dislayhtml = dislayhtml + "<td><img src=images/i_bath.jpg title=bath align=absmiddle>&nbsp;" + numbathroom + "&nbsp;</td>";
                }
            }
            if (!String.IsNullOrEmpty(numcarbay))
            {
                TotalSpace = TotalSpace + int.Parse(numcarbay);

            }
            if (!String.IsNullOrEmpty(numgarage))
            {
                TotalSpace = TotalSpace + int.Parse(numgarage);

            }
            if (TotalSpace > 0)
            {
                dislayhtml = dislayhtml + "<td><img src=images/i_car.jpg title=car align=absmiddle>&nbsp;" + TotalSpace + "&nbsp;</td>";
            }

            //dislayhtml = dislayhtml + "<td align=left><img src=" + ConfigurationManager.AppSettings["webUrl"].ToString() + "images/ahc/web/icon_right_s.gif></td></tr></table>";
        }

        if (dislayhtml != "")
        {
            dislayhtml = "<table width=140><tr>" + dislayhtml + "</tr></table>";
        }

        return dislayhtml;
    }

    public string getAgencyLogoresult(string acID, string width)
    {
        string strLogo = "";

        if (!String.IsNullOrEmpty(acID))
        {
            connection.Close();
            getAgency(acID);

            if (agencyhasLogo == true)
            {
                strLogo = "<img src='" + ConfigurationManager.AppSettings["imageurl"].ToString() + "resizeheight.ashx?width=" + width + "&type=logo&path=images/agency/" + acID + "/" + acID + "_logo.jpg'/>";
            }
        }
        else
        {
            strLogo = "";
        }
        return strLogo;
    }


    public Boolean checkSuburbName(string name, string state)
    {

        connection.Open();
        SqlCommand command = new SqlCommand("spCheckSuburbName", connection);
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.Add(new SqlParameter("@name", name));
        command.Parameters.Add(new SqlParameter("@state", state));
        SqlDataReader reader = command.ExecuteReader();
        if (reader.Read())
        {
            connection.Close();
            return true;
        }
        else
        {
            connection.Close();
            return false;
        }

    }


    public int getAgentByName(string firstname, string lastname)
    {
        int agentID = 0;
        connection.Open();
        SqlCommand command = new SqlCommand("spGetAgentByName", connection);
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.Add(new SqlParameter("@firstname", firstname));
        command.Parameters.Add(new SqlParameter("@lastname", lastname));
        SqlDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
            if (!reader.IsDBNull(reader.GetOrdinal("aid")))
            {
                agentID = int.Parse(reader.GetValue(reader.GetOrdinal("aid")).ToString());
                //agentID = reader.GetInt16(reader.GetOrdinal("aid"));
            }
        }

        return agentID;

    }

    public int getAgentsByName_New(string firstname, string lastname, string state)
    {
        int agentID = 0;
        connection.Open();
        SqlCommand command = new SqlCommand("spGetAgentByName_list", connection);
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.Add(new SqlParameter("@firstname", firstname));
        command.Parameters.Add(new SqlParameter("@lastname", lastname));
        command.Parameters.Add(new SqlParameter("@state", state));
        SqlDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
            if (!reader.IsDBNull(reader.GetOrdinal("aid")))
            {
                agentID = int.Parse(reader.GetValue(reader.GetOrdinal("aid")).ToString());
                //agentID = reader.GetInt16(reader.GetOrdinal("aid"));
            }
        }

        return agentID;

    }
    public SqlDataReader getAgentsByName(string firstname, string lastname, string state)
    {
        connection.Open();
        SqlCommand command = new SqlCommand("spGetAgentByName_list", connection);
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.Add(new SqlParameter("@firstname", firstname));
        command.Parameters.Add(new SqlParameter("@lastname", lastname));
        command.Parameters.Add(new SqlParameter("@state", state));
        SqlDataReader reader = command.ExecuteReader();
        return reader;

    }
    public string getAgentData(string aid)
    {
        string strAgentData = "";
        if (connection.State == ConnectionState.Open)
        {
            connection.Close();
        }
        connection.Open();
        SqlCommand command = new SqlCommand("spGetAgent", connection);
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.Add(new SqlParameter("@aID", aid));
        SqlDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
            if (!reader.IsDBNull(reader.GetOrdinal("email")))
            {
                strAgentData = "<a href='mailto:" + reader.GetString(reader.GetOrdinal("email")) + "'><img src='" + ConfigurationManager.AppSettings["webUrl"] + "images/btn_contact_agent.jpg' title='contact agent' alt='contact agent' /></a>";
            }
            strAgentData += "<div class='txtblue11'> ";
            if (!reader.IsDBNull(reader.GetOrdinal("firstname")))
            {
                strAgentData += reader.GetString(reader.GetOrdinal("firstname"));
            }
            if (!reader.IsDBNull(reader.GetOrdinal("surname")))
            {
                strAgentData += " " + reader.GetString(reader.GetOrdinal("surname"));
            }
            if (!reader.IsDBNull(reader.GetOrdinal("phone")))
            {
                strAgentData += "<br />" + reader.GetString(reader.GetOrdinal("phone")).Replace("(", "").Replace(")", "");
            }
        }
        connection.Close();
        strAgentData += "</div>";
        return strAgentData;
    }

    public string getAgentData(string aid, string strpid)
    {
        string strAgentData = "";
        string strAgentName = "";
        if (connection.State == ConnectionState.Open)
        {
            connection.Close();
        }
        connection.Open();
        SqlCommand command = new SqlCommand("spGetAgent", connection);
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.Add(new SqlParameter("@aID", aid));
        SqlDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
            bool tempnonimis = false;
            if (!reader.IsDBNull(reader.GetOrdinal("nonimis")))
            {
                tempnonimis = reader.GetBoolean(reader.GetOrdinal("nonimis"));
            }
            if (!reader.IsDBNull(reader.GetOrdinal("imisaid")) || tempnonimis)
            {
                bool isdisplay = false;
                if (!reader.IsDBNull(reader.GetOrdinal("iswebdisplay")))
                {
                    isdisplay = reader.GetBoolean(reader.GetOrdinal("iswebdisplay"));
                }



                if (isdisplay)
                {

                    if (!reader.IsDBNull(reader.GetOrdinal("firstname")))
                    {
                        strAgentName = reader.GetString(reader.GetOrdinal("firstname"));
                    }
                    if (!reader.IsDBNull(reader.GetOrdinal("surname")))
                    {
                        strAgentName += " " + reader.GetString(reader.GetOrdinal("surname"));
                    }



                    strAgentData += strAgentName;


                    if (!reader.IsDBNull(reader.GetOrdinal("mobile")))
                    {
                        string phonetemp = "";
                        if (!reader.IsDBNull(reader.GetOrdinal("phone")))
                        {
                            phonetemp = reader.GetString(reader.GetOrdinal("phone"));
                        }

                        string mobiletemp = reader.GetString(reader.GetOrdinal("mobile"));
                        if (!String.IsNullOrEmpty(phonetemp))
                        {
                            phonetemp = phonetemp.Replace("(", "").Replace(")", "").Replace(" ", "");
                            mobiletemp = mobiletemp.Replace("(", "").Replace(")", "").Replace(" ", "");
                        }
                        if (phonetemp != mobiletemp)
                        {
                            bool hidemobile = false;
                            if (!reader.IsDBNull(reader.GetOrdinal("hidemobile")))
                            {
                                hidemobile = reader.GetBoolean(reader.GetOrdinal("hidemobile"));
                            }

                            if (!hidemobile)
                            {
                                strAgentData += "<br />" + getagentmobileformat(reader.GetString(reader.GetOrdinal("mobile")));
                            }
                        }
                    }
                    else if (!reader.IsDBNull(reader.GetOrdinal("phone")))
                    {
                        strAgentData += "<br />" + reader.GetString(reader.GetOrdinal("phone")).Replace("(", "").Replace(")", "");
                    }
                }
            }
        }
        connection.Close();

        return strAgentData;
    }
    public string getAgentContact(string aid, string strpid)
    {
        string strAgentData = "";
        string strAgentName = "";
        if (connection.State == ConnectionState.Open)
        {
            connection.Close();
        }
        connection.Open();
        SqlCommand command = new SqlCommand("spGetAgent", connection);
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.Add(new SqlParameter("@aID", aid));
        SqlDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
            bool tempnonimis = false;
            if (!reader.IsDBNull(reader.GetOrdinal("nonimis")))
            {
                tempnonimis = reader.GetBoolean(reader.GetOrdinal("nonimis"));
            }
            if (!reader.IsDBNull(reader.GetOrdinal("imisaid")) || tempnonimis)
            {
                bool isdisplay = false;
                if (!reader.IsDBNull(reader.GetOrdinal("iswebdisplay")))
                {
                    isdisplay = reader.GetBoolean(reader.GetOrdinal("iswebdisplay"));
                }

                if (isdisplay)
                {
                    if (!reader.IsDBNull(reader.GetOrdinal("firstname")))
                    {
                        strAgentName = reader.GetString(reader.GetOrdinal("firstname"));
                    }
                    if (!reader.IsDBNull(reader.GetOrdinal("surname")))
                    {
                        strAgentName += " " + reader.GetString(reader.GetOrdinal("surname"));
                    }
                    strAgentData = "<a class='green' href='javascript:void(0);' onClick=\"javascript:editWidget('PropertyEmail.aspx?pid=" + strpid + "&aid=" + aid + "&Agentname=" + strAgentName.Replace("&", "") + "','500','470')\"><img src='" + ConfigurationManager.AppSettings["webUrl"] + "images/btn_contact_agent.jpg' title='contact agent' alt='contact agent' /></a>";
                }
            }
        }
        connection.Close();

        return strAgentData;
    }


    public void getAgent(string aid)
    {
        // was failing on some properties, possibly because the connection was already open (i.e. not being closed properly)
        if (connection.State == ConnectionState.Closed) //TODO: find where the connection is supposed to be closed.
            connection.Open();

        SqlCommand command = new SqlCommand("spGetAgent", connection);
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.Add(new SqlParameter("@aID", aid));
        SqlDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
            agentname = "";
            agentFirstName = "";
            string tempAgentName = "";
            string AgentLastName = "";

            if (!reader.IsDBNull(reader.GetOrdinal("acid")))
            {
                acid = reader.GetInt32(reader.GetOrdinal("acid")).ToString();
            }

            if (!reader.IsDBNull(reader.GetOrdinal("firstname")))
            {
                agentFirstName = agentFirstName + reader.GetString(reader.GetOrdinal("firstname"));
                //agentFirstName = agentFirstName.ToLower();
                //tempAgentName = agentFirstName.Remove(1);
                //tempAgentName = tempAgentName.ToUpper() + agentFirstName.Substring(1);
                //agentFirstName = tempAgentName;
                agentname = agentFirstName;
            }
            if (!reader.IsDBNull(reader.GetOrdinal("surname")))
            {
                AgentLastName = reader.GetString(reader.GetOrdinal("surname"));
                //AgentLastName = AgentLastName.ToLower();
                //tempAgentName = AgentLastName.Remove(1);
                //tempAgentName = tempAgentName.ToUpper() + AgentLastName.Substring(1);
                //AgentLastName = tempAgentName;
                agentname = agentname + " " + AgentLastName;
            }


            if (!reader.IsDBNull(reader.GetOrdinal("phone")))
            {
                agentphone = reader.GetString(reader.GetOrdinal("phone")).Replace("(", "").Replace(")", "");
            }
            if (!reader.IsDBNull(reader.GetOrdinal("position")))
            {
                agentposition = reader.GetString(reader.GetOrdinal("position"));
            }
            if (!reader.IsDBNull(reader.GetOrdinal("hidemobile")))
            {
                agenthidemobile = reader.GetBoolean(reader.GetOrdinal("hidemobile"));
            }
            if (!reader.IsDBNull(reader.GetOrdinal("mobile")))
            {
                agentmobile = reader.GetString(reader.GetOrdinal("mobile"));
                string phonetemp = agentphone;
                string mobiletemp = agentmobile;
                if (!String.IsNullOrEmpty(phonetemp))
                {
                    phonetemp = phonetemp.Replace("(", "").Replace(")", "").Replace(" ", "");
                    mobiletemp = mobiletemp.Replace("(", "").Replace(")", "").Replace(" ", "");
                }
                if (phonetemp != mobiletemp)
                {
                    if (!agenthidemobile)
                    {
                        agentmobiledisplay = getagentmobileformat(agentmobile);
                    }
                }
            }

            if (!reader.IsDBNull(reader.GetOrdinal("fax")))
            {
                agentfax = reader.GetString(reader.GetOrdinal("fax"));
            }
            if (!reader.IsDBNull(reader.GetOrdinal("email")))
            {
                agentemail = reader.GetString(reader.GetOrdinal("email"));
            }
            if (!reader.IsDBNull(reader.GetOrdinal("profile")))
            {
                agentprofile = reader.GetString(reader.GetOrdinal("profile"));

                agentprofile = agentprofile.Replace(Environment.NewLine, "<BR>");
            }

            if (!reader.IsDBNull(reader.GetOrdinal("hasphoto")))
            {
                hasphoto = reader.GetBoolean(reader.GetOrdinal("hasphoto"));
            }
            if (!reader.IsDBNull(reader.GetOrdinal("nonimis")))
            {
                isnonimis = reader.GetBoolean(reader.GetOrdinal("nonimis"));
            }
            if (!reader.IsDBNull(reader.GetOrdinal("iswebdisplay")))
            {
                agentiswebdisplay = reader.GetBoolean(reader.GetOrdinal("iswebdisplay"));
            }


            if (!reader.IsDBNull(reader.GetOrdinal("hasPhoto2")))
            {
                hasphoto2 = reader.GetBoolean(reader.GetOrdinal("hasPhoto2"));
            }
            if (!reader.IsDBNull(reader.GetOrdinal("featurepid")))
            {
                agentfeaturepid = reader.GetInt32(reader.GetOrdinal("featurepid"));
            }

            if (!reader.IsDBNull(reader.GetOrdinal("imisAid")))
            {
                agentimisAid = reader.GetInt32(reader.GetOrdinal("imisAid")).ToString();
            }



        }
        connection.Close();
        //current listings
        connection.Open();
        command = new SqlCommand("spGetPropertiesCount", connection);
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.Add(new SqlParameter("@isWebdisplay", "1"));
        command.Parameters.Add(new SqlParameter("@aID1", aid));
        reader = command.ExecuteReader();
        while (reader.Read())
        {
            if (!reader.IsDBNull(reader.GetOrdinal("count")))
            {
                agentspropcount = reader.GetInt32(reader.GetOrdinal("count"));
            }
        }
        connection.Close();
        //sold lisings
        connection.Open();
        command = new SqlCommand("spGetPropertiesCount", connection);
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.Add(new SqlParameter("@isWebdisplay", "Any"));
        command.Parameters.Add(new SqlParameter("@aID1", aid));
        command.Parameters.Add(new SqlParameter("@status", "('Sold')"));
        reader = command.ExecuteReader();
        while (reader.Read())
        {
            if (!reader.IsDBNull(reader.GetOrdinal("count")))
            {
                agentsoldcount = reader.GetInt32(reader.GetOrdinal("count"));
            }
        }
        connection.Close();
    }
    public string getAgentTestimonials(string aid)
    {
        string testi = "";
        connection.Open();
        SqlCommand command = new SqlCommand("spGetAgentTestimonials", connection);
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.Add(new SqlParameter("@aID", aid));

        SqlDataReader reader = command.ExecuteReader();

        while (reader.Read())
        {
            if (!reader.IsDBNull(reader.GetOrdinal("testimonial")))
            {
                testi = testi + "<br><br>" + reader.GetString(reader.GetOrdinal("testimonial"));
            }
        }
        connection.Close();
        return testi;
    }


    public string getAgentDetail(string acid, string aid, string name, bool hasphoto, string phone, string mobile, string email, string pid)
    {
        string agentDet = "<table cellpadding='0' cellspacing='0'>";

        agentDet += "<tr>";
        if (hasphoto == true)
        {
            agentDet += "<td style='vertical-align:bottom;' ><a href=\'AgentDetails.aspx?aid=" + aid + "'><img src='" + ConfigurationManager.AppSettings["imageurl"].ToString() + "images/agency/" + acid + "/" + aid + "_PIC.jpg' alt='" + name + "' width='76'  align='left'></a></td>";
        }
        agentDet += "<td width='5'></td><td valign='top' width='124'><table cellpadding='1' cellspacing='1'>";
        agentDet += "<tr><td align='left'>" + name + "</td></tr>";

        if (!String.IsNullOrEmpty(mobile))
        {
            string phonetemp = phone;
            string mobiletemp = mobile;
            if (!String.IsNullOrEmpty(phonetemp))
            {
                phonetemp = phonetemp.Replace("(", "").Replace(")", "").Replace(" ", "");
                mobiletemp = mobiletemp.Replace("(", "").Replace(")", "").Replace(" ", "");
            }
            if (phonetemp != mobiletemp)
            {

                agentDet += "<tr><td>M: " + getagentmobileformat(mobile) + "</td></tr>";

            }
        }


        if (!String.IsNullOrEmpty(phone))
        {
            agentDet += "<tr><td>P: " + phone.Replace("(", "").Replace(")", "") + "</td></tr>";
        }
        if (!String.IsNullOrEmpty(email))
        {
            agentDet += "<tr><td style='vertical-align:bottom;'><img src='" + ConfigurationManager.AppSettings["webUrl"] + "images/i_emailagent_green.gif' align='absmiddle' /> <a class='green' href='#' onClick=\"javascript:editWidget('PropertyEmail.aspx?pid=" + pid + "&aid=" + aid + "&Agentname=" + name.Replace("&", "") + "','500','470'); return false;\"><strong>Email</strong></a></td></tr>";
        }

        agentDet += "<tr><td><br><a class='btnGold' href='" + ConfigurationManager.AppSettings["webUrl"].ToString() + "AgentDetails.aspx?aid=" + aid + "'>view my listings</a></td> </tr>";

        agentDet += "</table></td></tr></table>";
        return agentDet;

    }

    public string getAgentDetail2(string acid, string aid, string name, bool hasphoto, string phone, string mobile, string email)
    {


        string agentDet = "";
        if (hasphoto == true)
        {
            agentDet = "<img src='" + ConfigurationManager.AppSettings["imageurl"].ToString() + "images/agency/" + acid + "/" + aid + "_PIC.jpg' alt='" + name + "' hspace='2' width='76'  align='left'>";
        }
        if (!String.IsNullOrEmpty(name))
        {
            agentDet += "<p align='left'><strong>" + name + "</strong><br>";
        }
        if (!String.IsNullOrEmpty(mobile))
        {
            string phonetemp = phone;
            string mobiletemp = mobile;
            if (!String.IsNullOrEmpty(phonetemp))
            {
                phonetemp = phonetemp.Replace("(", "").Replace(")", "").Replace(" ", "");
                mobiletemp = mobiletemp.Replace("(", "").Replace(")", "").Replace(" ", "");
            }
            if (phonetemp != mobiletemp)
            {

                agentDet += "M: " + getagentmobileformat(mobile) + "<br>";

            }
        }
        if (!String.IsNullOrEmpty(phone))
        {
            agentDet += "P: " + phone.Replace("(", "").Replace(")", "") + "<br>";
        }

        agentDet += "</p>";
        return agentDet;

    }

    public string getAgentDetail3(string acid, string aid, string name, bool hasphoto, string phone, string mobile, string email, string position)
    {
        string agentDet = "";
        if (hasphoto == true)
        {
            agentDet = "<img src='" + ConfigurationManager.AppSettings["imageurl"].ToString() + "images/agency/" + acid + "/" + aid + "_PIC.jpg' alt='" + name + "' hspace='5' width='76'  align='left'>";
        }
        if (!String.IsNullOrEmpty(name))
        {
            agentDet += "<p align='left'><strong>" + name + "</strong><br>";
        }
        getAgency(acid);

        if (!String.IsNullOrEmpty(agencyname))
        {
            agentDet += agencyname + "<br>";
        }
        if (!String.IsNullOrEmpty(mobile))
        {
            string phonetemp = phone;
            string mobiletemp = mobile;
            if (!String.IsNullOrEmpty(phonetemp))
            {
                phonetemp = phonetemp.Replace("(", "").Replace(")", "").Replace(" ", "");
                mobiletemp = mobiletemp.Replace("(", "").Replace(")", "").Replace(" ", "");
            }
            if (phonetemp != mobiletemp)
            {
                agentDet += "M: " + getagentmobileformat(mobile) + "<br>";
            }
        }
        if (!String.IsNullOrEmpty(phone))
        {
            agentDet += "P: " + phone.Replace("(", "").Replace(")", "") + "<br>";
        }
        if (!String.IsNullOrEmpty(email))
        {
            agentDet += "<a href=mailto:" + email + "?subject=inquiry%20from%20REIQ.com>Email Me</a><br>";
        }
        agentDet += "</p>";
        return agentDet;

    }

    public void getAgency(string acID)
    {
        connection.Open();
        SqlCommand command = new SqlCommand("spGetAgency", connection);
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.Add(new SqlParameter("@acID", acID));
        SqlDataReader reader = command.ExecuteReader();
        agenyaddress = "";
        agencyphone = "";
        agencyfax = "";
        agencyemail = "";
        agencyweb = "";
        agencyname = "";
        while (reader.Read())
        {
            if (!reader.IsDBNull(reader.GetOrdinal("unitNum")))
            {
                agencyunitnum = reader.GetString(reader.GetOrdinal("unitNum"));
                agenyaddress = agenyaddress + agencyunitnum;
            }
            if (!reader.IsDBNull(reader.GetOrdinal("rdNum")))
            {
                agencyroadnum = reader.GetString(reader.GetOrdinal("rdNum"));
                if (!String.IsNullOrEmpty(agenyaddress))
                {
                    agenyaddress = agenyaddress + "/" + agencyroadnum;
                }
                else
                {
                    agenyaddress = agencyroadnum;
                }
            }
            if (!reader.IsDBNull(reader.GetOrdinal("rdName")))
            {
                agencyroadname = reader.GetString(reader.GetOrdinal("rdName"));
                agenyaddress = agenyaddress + " " + agencyroadname;
            }
            if (!reader.IsDBNull(reader.GetOrdinal("rdType")))
            {
                agencyroadtype = reader.GetString(reader.GetOrdinal("rdType"));
                agenyaddress = agenyaddress + " " + agencyroadtype;
            }
            if (!reader.IsDBNull(reader.GetOrdinal("suburb")))
            {
                agencysuburb = reader.GetString(reader.GetOrdinal("suburb"));
                agenyaddress = agenyaddress + ", " + agencysuburb;
            }

            if (!reader.IsDBNull(reader.GetOrdinal("state")) && agencysuburb != "")
            {
                agenyaddress = agenyaddress + ", " + reader.GetString(reader.GetOrdinal("state")); ;
            }
            if (!reader.IsDBNull(reader.GetOrdinal("postcode")) && agencysuburb != "")
            {
                agenyaddress = agenyaddress + " " + reader.GetString(reader.GetOrdinal("postcode")); ;
            }
            if (!reader.IsDBNull(reader.GetOrdinal("phone")))
            {
                agencyphone = reader.GetString(reader.GetOrdinal("phone")).Replace("(", "").Replace(")", "");
            }
            if (!reader.IsDBNull(reader.GetOrdinal("fax")))
            {
                agencyfax = reader.GetString(reader.GetOrdinal("fax"));
            }
            if (!reader.IsDBNull(reader.GetOrdinal("email")))
            {
                agencyemail = reader.GetString(reader.GetOrdinal("email"));
            }
            if (!reader.IsDBNull(reader.GetOrdinal("name")))
            {
                agencyname = reader.GetString(reader.GetOrdinal("name"));
            }
            if (!reader.IsDBNull(reader.GetOrdinal("hasLogo")))
            {
                agencyhasLogo = reader.GetBoolean(reader.GetOrdinal("hasLogo"));
            }
            if (!reader.IsDBNull(reader.GetOrdinal("link")))
            {
                agencylink = reader.GetString(reader.GetOrdinal("link"));
            }
            if (!reader.IsDBNull(reader.GetOrdinal("web")))
            {
                agencyweb = reader.GetString(reader.GetOrdinal("web"));
            }
            if (!reader.IsDBNull(reader.GetOrdinal("profile")))
            {
                agencyprofile = reader.GetString(reader.GetOrdinal("profile"));
                agencyprofile = agencyprofile.Replace("\r\n", "<br>");
            }
            if (!reader.IsDBNull(reader.GetOrdinal("imisAcid")))
            {
                agencyimisAcid = reader.GetInt32(reader.GetOrdinal("imisAcid")).ToString();
            }


        }
        connection.Close();
    }
    public string getAgencyPhone(string acID)
    {
        string strPhone = "";
        connection.Close();
        connection.Open();
        SqlCommand command = new SqlCommand("spGetAgency", connection);
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.Add(new SqlParameter("@acID", acID));
        SqlDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
            if (!reader.IsDBNull(reader.GetOrdinal("phone")))
            {
                strPhone = reader.GetString(reader.GetOrdinal("phone")).Replace("(", "").Replace(")", "");
            }

        }

        if (!String.IsNullOrEmpty(strPhone))
        {
            strPhone = "<img src='" + ConfigurationManager.AppSettings["webUrl"].ToString() + "images/ahc/web/phone.gif' alt='phone' align='absmiddle'>" + strPhone;
        }
        else
        {
            strPhone = strPhone;
        }
        return strPhone;
    }

    public string getAgencyLogo(string acID)
    {
        string strLogo = "";



        if (!String.IsNullOrEmpty(acID))
        {
            connection.Close();
            getAgency(acID);

            if (agencyhasLogo == true)
            {
                strLogo = "<img src='" + ConfigurationManager.AppSettings["imageurl"].ToString() + "resizeheight.ashx?width=170&type=logo&path=images/agency/" + acID + "/" + acID + "_logo.jpg'/>";
            }
        }
        else
        {
            strLogo = "";
        }
        return strLogo;
    }
    public string getAgencyName(string acID)
    {
        connection.Close();
        connection.Open();

        SqlCommand command = new SqlCommand("spGetAgency", connection);
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.Add(new SqlParameter("@acID", acID));
        SqlDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
            if (!reader.IsDBNull(reader.GetOrdinal("name")))
            {
                agencyname = reader.GetString(reader.GetOrdinal("name"));
            }

        }
        return agencyname;
    }
    public string getAgencyDetails(string acID)
    {
        connection.Close();
        getAgency(acID);
        string strAgencyDetails = "";
        strAgencyDetails = "<table cellpadding=0 cellspacing=0 border=0  width=525 ><tr>";

        strAgencyDetails = strAgencyDetails + "<td width=240 valign=top><b>" + agencyname + "</b><br>" + agenyaddress + "</td>";
        strAgencyDetails = strAgencyDetails + "<td width=285><table cellpadding=0 cellspacing=1>";
        strAgencyDetails = strAgencyDetails + "<tr><td width=50>Phone</td><td>" + agencyphone + "</td>";
        strAgencyDetails = strAgencyDetails + "<tr><td width=50>Fax</td><td>" + agencyfax + "</td>";
        strAgencyDetails = strAgencyDetails + "<tr><td width=50>Email</td><td>" + agencyemail + "</td>";
        strAgencyDetails = strAgencyDetails + "<tr><td width=50>Web</td><td><a target=_blank href=http://" + agencyweb + ">" + agencyweb + "</a></td>";
        strAgencyDetails = strAgencyDetails + "</tr></table></td>";
        strAgencyDetails = strAgencyDetails + "</tr></table>";

        return strAgencyDetails;
    }

    public void insertLog(string pid, string acID, string aid, string suburb, string email, string phone)
    {
        connection.Open();
        using (SqlCommand command = new SqlCommand("spInsertEnquiryLog", connection))
        {
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@pid", pid));
            command.Parameters.Add(new SqlParameter("@acID", acID));
            command.Parameters.Add(new SqlParameter("@aid", aid));
            command.Parameters.Add(new SqlParameter("@suburb", suburb));
            command.Parameters.Add(new SqlParameter("@email", email));
            command.Parameters.Add(new SqlParameter("@phone", phone));
            command.ExecuteNonQuery();
        }
        connection.Close();
    }



    public string getIcons(string pid, string numPhotoMore, bool hasphoto, string numFloorPlan)
    {
        string txtIcon = "";
        txtIcon = "<a href=\"javascript:openPopUp('/GoogleMap.aspx?ty=fp&amp;pid=" + pid + "', 'mp','scrollbars=yes, menubar=no, width=600, height=550, resizable=yes')\"><img src='" + ConfigurationManager.AppSettings["webUrl"].ToString() + "images/ahc/web/mapit.gif' alt='Map it' /></a>";
        if (hasphoto)
        {
            txtIcon = txtIcon + "&nbsp;&nbsp;<a target='_blank' href='/brochure.aspx?pid=" + pid + "'><img src='" + ConfigurationManager.AppSettings["webUrl"].ToString() + "images/ahc/web/brochure.gif' alt='Print Brochure' /></a>";
        }
        if (Int32.Parse(numFloorPlan) > 0)
        {
            txtIcon = txtIcon + "&nbsp;&nbsp;<a href=\"javascript:openPopUp('/VisualInfo.aspx?ty=fp&amp;pid=" + pid + "', 'mp', 'scrollbars=yes, menubar=no, width=925, height=750, resizable=yes')\" ><img src='" + ConfigurationManager.AppSettings["webUrl"].ToString() + "images/ahc/web/floorplan.gif' alt='Floor Plan' /></a>";
        }
        if (Int32.Parse(numPhotoMore) > 0)
        {
            txtIcon = txtIcon + "&nbsp;&nbsp;<a href=\"javascript:openPopUp('/VisualInfo.aspx?ty=mp&amp;pid=" + pid + "', 'mp', 'scrollbars=yes, menubar=no, width=925, height=750, resizable=yes')\"><img src='" + ConfigurationManager.AppSettings["webUrl"].ToString() + "images/ahc/web/slideshow.gif' alt='Photo Slideshow' /></a>";
        }
        return txtIcon;
    }


    public SqlDataReader getHomeopenSuburbs(string strDay, string state)
    {
        connection.Open();
        SqlCommand command = new SqlCommand("spGetHomeOpensSuburbs", connection);
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.Add(new SqlParameter("@day", strDay));
        command.Parameters.Add(new SqlParameter("@state", state));
        SqlDataReader reader = command.ExecuteReader();
        return reader;
    }

    public SqlDataReader getHomeOpensProperties(string acID, string aid, string suburb, string strDay, string orderby)
    {
        connection.Open();
        SqlCommand command = new SqlCommand("spGetHomeOpens", connection);
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.Add(new SqlParameter("@acID", acID));
        command.Parameters.Add(new SqlParameter("@aID", aid));
        command.Parameters.Add(new SqlParameter("@suburb", suburb));
        command.Parameters.Add(new SqlParameter("@day", strDay));
        command.Parameters.Add(new SqlParameter("@orderBy", orderby));
        SqlDataReader reader = command.ExecuteReader();
        return reader;
    }

    public SqlDataReader getHomeOpenProperties_WithStatus(string suburb, string strDay, string orderby, string acID, string status, string state)
    {
        //get suburbs for a search status
        connection.Open();
        SqlCommand command = new SqlCommand("spGetProperties", connection);
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.Add(new SqlParameter("@acID", acID));
        command.Parameters.Add(new SqlParameter("@status", status));
        command.Parameters.Add(new SqlParameter("@state", state));
        command.Parameters.Add(new SqlParameter("@suburb", convertListToSQL(suburb)));
        command.Parameters.Add(new SqlParameter("@homeopen", strDay));
        command.Parameters.Add(new SqlParameter("@orderby", "suburb,pricelow"));
        SqlDataReader reader = command.ExecuteReader();
        return reader;
    }
    public SqlDataReader getHomeOpenProperties_WithStatus(string suburb, string strDay, string orderby, string acID, string status, string state, string strPriceLow, string strPriceHigh)
    {
        //get suburbs for a search status
        connection.Open();
        SqlCommand command = new SqlCommand("spGetProperties", connection);
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.Add(new SqlParameter("@acID", acID));
        command.Parameters.Add(new SqlParameter("@status", status));
        command.Parameters.Add(new SqlParameter("@state", state));
        command.Parameters.Add(new SqlParameter("@suburb", convertListToSQL(suburb)));
        command.Parameters.Add(new SqlParameter("@homeopen", strDay));
        command.Parameters.Add(new SqlParameter("@priceLow", strPriceLow));
        command.Parameters.Add(new SqlParameter("@priceHigh", strPriceHigh));
        command.Parameters.Add(new SqlParameter("@orderby", orderby));
        SqlDataReader reader = command.ExecuteReader();
        return reader;
    }


    public int getHomeOpenCount(string status, string suburb, string day, string acID, string AID, string state, string country)
    {
        int count = 0;
        connection.Close();
        connection.Open();

        SqlCommand command = new SqlCommand("spGetHomeOpensCount_new", connection);
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.Add(new SqlParameter("@acID", acID));
        command.Parameters.Add(new SqlParameter("@aID", AID));
        command.Parameters.Add(new SqlParameter("@suburb", suburb));
        command.Parameters.Add(new SqlParameter("@day", day));
        command.Parameters.Add(new SqlParameter("@status", status));
        command.Parameters.Add(new SqlParameter("@state", state));
        command.Parameters.Add(new SqlParameter("@country", country));
        SqlDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
            if (!reader.IsDBNull(reader.GetOrdinal("count")))
            {
                count = reader.GetInt32(reader.GetOrdinal("count"));
            }
        }

        return count;
    }

    public string getHomeOpensFormat(string strHomeopen1From, string strHomeopen1To, string strHomeopen2From, string strHomeopen2To)
    {
        string homeopent = "";
        if (!String.IsNullOrEmpty(strHomeopen1From.ToString()) && !String.IsNullOrEmpty(strHomeopen1To.ToString()))
        {
            homeopent = "Sat: " + DateTime.Parse(strHomeopen1From).ToShortTimeString().ToString();
            if (!(DateTime.Parse(strHomeopen1From).ToShortTimeString().ToString() == DateTime.Parse(strHomeopen1To).ToShortTimeString().ToString()))
            {
                homeopent = "Sat: " + DateTime.Parse(strHomeopen1From).ToShortTimeString().ToString() + " to " + DateTime.Parse(strHomeopen1To).ToShortTimeString().ToString();
            }
            homeopent = homeopent.ToLower();
            homeopent = homeopent.Replace(" ", "");
            homeopent = homeopent.Replace("sat:", "Sat: ");
            homeopent = homeopent.Replace("sun:", "Sun: ");
            homeopent = homeopent.Replace("to", " to ");
        }
        if (!String.IsNullOrEmpty(strHomeopen2From.ToString()) && !String.IsNullOrEmpty(strHomeopen2To.ToString()))
        {


            if (!(DateTime.Parse(strHomeopen2From).ToShortTimeString().ToString() == DateTime.Parse(strHomeopen2To).ToShortTimeString().ToString()))
            {

                if (String.IsNullOrEmpty(homeopent))
                {
                    homeopent = "Sun: " + DateTime.Parse(strHomeopen2From).ToShortTimeString().ToString() + " to " + DateTime.Parse(strHomeopen2To).ToShortTimeString().ToString();
                }
                else
                {
                    homeopent = homeopent + "<br>Sun: " + DateTime.Parse(strHomeopen2From).ToShortTimeString().ToString() + " to " + DateTime.Parse(strHomeopen2To).ToShortTimeString().ToString();
                }

            }
            homeopent = homeopent.ToLower();
            homeopent = homeopent.Replace(" ", "");
            homeopent = homeopent.Replace("sun:", "Sun: ");
            homeopent = homeopent.Replace("sat:", "Sat: ");
            homeopent = homeopent.Replace("to", " to ");

        }

        if (!String.IsNullOrEmpty(homeopent))
        {
            homeopent = "Open Home: " + homeopent;
        }
        return homeopent;
    }


    public string getHomeOpensFormat_New(string strHomeopen1From, string strHomeopen1To, string strHomeopen2From, string strHomeopen2To)
    {
        string homeopent = "";
        string homeopen1year = "";
        string homeopen1day = "";
        string homeopen1from = "";
        string homeopen1to = "";

        string homeopen2year = "";
        string homeopen2day = "";
        string homeopen2from = "";
        string homeopen2to = "";

        if (!String.IsNullOrEmpty(strHomeopen1From.ToString()) && !String.IsNullOrEmpty(strHomeopen1To.ToString()))
        {
            homeopen1from = DateTime.Parse(strHomeopen1From).ToShortTimeString().ToString();
            homeopen1to = DateTime.Parse(strHomeopen1To).ToShortTimeString().ToString();
            homeopen1year = DateTime.Parse(strHomeopen1From).Year.ToString();
            if (homeopen1year == "1900")
            {
                homeopen1day = "Sat";
            }
            else
            {
                homeopen1day = DateTime.Parse(strHomeopen1From).DayOfWeek.ToString() + ", " + DateTime.Parse(strHomeopen1From).ToString("dd MMM yyyy");
                homeopen1day = homeopen1day.Replace("Monday", "Mon");
                homeopen1day = homeopen1day.Replace("Tuesday", "Tue");
                homeopen1day = homeopen1day.Replace("Wednesday", "Wed");
                homeopen1day = homeopen1day.Replace("Thursday", "Thu");
                homeopen1day = homeopen1day.Replace("Friday", "Fri");
                homeopen1day = homeopen1day.Replace("Saturday", "Sat");
                homeopen1day = homeopen1day.Replace("Sunday", "Sun");
            }

            //homeopent = homeopen1day + homeopen1from;

            if (!(homeopen1from == homeopen1to))
            {
                homeopent = homeopen1day + ": " + homeopen1from.Replace(" ", "").ToLower() + " to " + homeopen1to.Replace(" ", "").ToLower();
            }
        }
        if (!String.IsNullOrEmpty(strHomeopen2From.ToString()) && !String.IsNullOrEmpty(strHomeopen2To.ToString()))
        {
            homeopen2from = DateTime.Parse(strHomeopen2From).ToShortTimeString().ToString();
            homeopen2to = DateTime.Parse(strHomeopen2To).ToShortTimeString().ToString();
            homeopen2year = DateTime.Parse(strHomeopen2From).Year.ToString();
            if (homeopen2year == "1900")
            {
                homeopen2day = "Sun";
            }
            else
            {
                homeopen2day = DateTime.Parse(strHomeopen2From).DayOfWeek.ToString() + ", " + DateTime.Parse(strHomeopen2From).ToString("dd MMM yyyy");
                homeopen2day = homeopen2day.Replace("Monday", "Mon");
                homeopen2day = homeopen2day.Replace("Tuesday", "Tue");
                homeopen2day = homeopen2day.Replace("Wednesday", "Wed");
                homeopen2day = homeopen2day.Replace("Thursday", "Thu");
                homeopen2day = homeopen2day.Replace("Friday", "Fri");
                homeopen2day = homeopen2day.Replace("Saturday", "Sat");
                homeopen2day = homeopen2day.Replace("Sunday", "Sun");
            }

            if (!(homeopen2from == homeopen2to))
            {
                if (homeopent == "")
                {
                    homeopent = homeopen2day + ": " + homeopen2from.Replace(" ", "").ToLower() + " to " + homeopen2to.Replace(" ", "").ToLower();
                }
                else
                {
                    homeopent = homeopent + "<br>" + homeopen2day + ": " + homeopen2from.Replace(" ", "").ToLower() + " to " + homeopen2to.Replace(" ", "").ToLower();
                }
            }

        }

        if (!String.IsNullOrEmpty(homeopent))
        {
            homeopent = "Open Home: " + homeopent;
        }
        return homeopent;
    }

    public string getRates(string strWater, string strCouncil, string strStrata)
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
    public string getAuctionFormat(string strAuctionDate, string strAuctionTime)
    {
        string auctiont = "";
        if (!String.IsNullOrEmpty(strAuctionTime))
        {
            auctiont = strAuctionTime;
        }
        if (!String.IsNullOrEmpty(strAuctionDate))
        {
            if (DateTime.Parse(strAuctionDate.ToString()) > DateTime.Now)
            {
                auctiont = "<h4 style='color:#c41645' ><b>Auction Date & Time: </b>" + DateTime.Parse(strAuctionDate.ToString()).ToString("dddd, dd MMMM, yyyy") + "&nbsp;&nbsp;" + auctiont + "</h4>";
            }
            else
            {
                auctiont = "";
            }
        }

        return auctiont;
    }
    public string getAvailableFrom(bool isavailablenow1, DateTime dtAvailableFrom)
    {
        string strDate = "";

        if (isavailablenow1)
        {
            strDate = "<br /><font>Available now</font><br />";
        }
        else if (dtAvailableFrom > Convert.ToDateTime("0001/01/01"))
        {
            if (dtAvailableFrom <= Convert.ToDateTime(DateTime.Now.Year.ToString() + "/" + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Day.ToString()))
            {
                strDate = "<br /><font>Available now</font><br />";
            }
            else
            {
                strDate = "<br /><font>Date available: " + String.Format("{0:dddd, dd MMMM yyyy}", dtAvailableFrom) + "</font><br />";
            }
        }

        return strDate;
    }

    public string getAddress(string strName, string strUnitNum, string strRoadNum, string strRoadName, string strRoadType, string strSuburb, Boolean blHideRoadName, Boolean blHideRoadNum)
    {
        string address = "";

        if (!(blHideRoadName))
        {
            if (!String.IsNullOrEmpty(strRoadNum))
            {
                address = address + strRoadNum + " ";
            }
            if (!String.IsNullOrEmpty(strRoadName))
            {
                address = address + strRoadName + " ";
            }
            if (!String.IsNullOrEmpty(strRoadType))
            {
                address = address + strRoadType;
            }
            if (!String.IsNullOrEmpty(strUnitNum))
            {
                address = "Unit " + strUnitNum + "/" + address;
            }
            if (!String.IsNullOrEmpty(strName))
            {
                address = strName + "<br>" + address;
            }
            if (!String.IsNullOrEmpty(strSuburb))
            {
                if (!String.IsNullOrEmpty(address))
                {
                    address = strSuburb + ", " + address;
                }
                else
                {
                    address = strSuburb;
                }
            }

        }
        else
        {
            if (!String.IsNullOrEmpty(strSuburb))
            {
                address = strSuburb;
            }
        }

        return address;
    }

    public string getGAddress(string strName, string strUnitNum, string strRoadNum, string strRoadName, string strRoadType, string strSuburb, Boolean blHideRoadName, Boolean blHideRoadNum)
    {
        string address = "";

        if (!(blHideRoadName))
        {
            if (!String.IsNullOrEmpty(strRoadNum))
            {
                address = address + strRoadNum + " ";
            }
            if (!String.IsNullOrEmpty(strRoadName))
            {
                address = address + strRoadName + " ";
            }
            if (!String.IsNullOrEmpty(strRoadType))
            {
                address = address + strRoadType;
            }
            if (!String.IsNullOrEmpty(strUnitNum))
            {
                address = "Unit " + strUnitNum + "/" + address;
            }
            if (!String.IsNullOrEmpty(strName))
            {
                address = strName + "<br>" + address;
            }

            if (!String.IsNullOrEmpty(strSuburb))
            {
                if (!String.IsNullOrEmpty(address))
                {
                    address = address + ", " + strSuburb;
                }
                else
                {
                    address = strSuburb;
                }
            }
        }
        else
        {
            if (!String.IsNullOrEmpty(strSuburb))
            {
                address = strSuburb;
            }
        }


        return address;
    }


    public string getPrice(string strPriceOption, string strPriceLow, string strPriceHigh, string strStatus, string strPaymentPeriod, string pricehide, string pricetext, string pricered)
    {
        string price = "";
        strPriceOption = strPriceOption.ToLower();
        if (!String.IsNullOrEmpty(strPriceOption))
        {
            if (strPriceOption.ToLower().Equals("price"))
            {
                if (!String.IsNullOrEmpty(strPriceLow))
                {
                    price = decimal.Parse(strPriceLow).ToString("$#,##0");
                }
            }
            if (strPriceOption.ToLower().Equals("range"))
            {
                if (!String.IsNullOrEmpty(strPriceLow))
                {
                    price = decimal.Parse(strPriceLow).ToString("$#,##0");
                }
                if (!String.IsNullOrEmpty(strPriceHigh))
                {
                    price = price + " to ";
                    price = price + decimal.Parse(strPriceHigh).ToString("$#,##0");
                }

            }
            if (strPriceOption.ToLower().Equals("pricefrom"))
            {
                if (!String.IsNullOrEmpty(strPriceLow))
                {
                    price = "From " + decimal.Parse(strPriceLow).ToString("$#,##0");
                }
            }
            if (!string.IsNullOrEmpty(pricehide) && bool.Parse(pricehide))
            {
                price = "";
            }
            if (strPriceOption.ToLower().Equals("auction"))
            {
                price = "For Auction";
            }
            if (strPriceOption.ToLower().Equals("tender"))
            {
                price = "Tender";
            }
            if (strPriceOption.ToLower().Equals("eoi"))
            {
                price = "EOI";
            }
            if (strPriceOption.ToLower().Equals("poa"))
            {
                price = "Price on Application";
            }
            if (strStatus.ToLower().Equals("sold"))
            {
                price = "<font color=#dc0000>sold</font>";
            }
            if (strStatus.ToLower().Equals("under offer"))
            {
                price = "under offer";
            }
            if (strStatus.ToLower().Equals("rented"))
            {
                price = "<font color=#dc0000>rented</font>";
            }
            if (strStatus.ToLower().Equals("for rent"))
            {
                price = price + " " + strPaymentPeriod;
            }
        }

        if (!String.IsNullOrEmpty(pricered))
        {
            if (pricered == "True")
            {
                price = "<span class=comment>New Price</span>&nbsp;" + price;
            }
        }

        if (strStatus.ToLower() != "sold" && strStatus.ToLower() != "rented")
        {
            if (!String.IsNullOrEmpty(pricetext))
            {
                price = pricetext;
            }
        }

        if (string.IsNullOrEmpty(price))
        {
            price = "Contact agent";
        }

        return price;
    }



    public string getArchivedPrice(string strPriceOption, string strPriceLow, string strPriceHigh, string strStatus, string strPaymentPeriod)
    {
        string price = "";
        if (!String.IsNullOrEmpty(strPriceOption))
        {
            if (strPriceOption.ToLower().Equals("price"))
            {
                if (!String.IsNullOrEmpty(strPriceLow))
                {
                    price = decimal.Parse(strPriceLow).ToString("$#,##0");
                }
            }
            if (strPriceOption.ToLower().Equals("range"))
            {
                if (!String.IsNullOrEmpty(strPriceLow))
                {
                    price = decimal.Parse(strPriceLow).ToString("$#,##0");
                }
                if (!String.IsNullOrEmpty(strPriceHigh))
                {
                    price = price + " to ";
                    price = price + decimal.Parse(strPriceHigh).ToString("$#,##0");
                }

            }
            if (strPriceOption.ToLower().Equals("pricefrom"))
            {
                if (!String.IsNullOrEmpty(strPriceLow))
                {
                    price = "From " + decimal.Parse(strPriceLow).ToString("$#,##0");
                }
            }
            if (strPriceOption.ToLower().Equals("auction"))
            {
                price = "For Auction";
            }
            if (strPriceOption.ToLower().Equals("tender"))
            {
                price = "Tender";
            }
            if (strPriceOption.ToLower().Equals("eoi"))
            {
                price = "EOI";
            }
            if (strPriceOption.ToLower().Equals("poa"))
            {
                price = "Price on Application";
            }
            if (strStatus.ToLower().Equals("for rent"))
            {
                price = price + " " + strPaymentPeriod;
            }

        }
        else
        {

            price = "";
        }
        if (!String.IsNullOrEmpty(price))
        {
            price = "Listed price:  " + price;
        }
        return price;
    }
    public string getMonthSold(string dateSold, string onadate, string dateListed)
    {
        string month = "";
        if (!String.IsNullOrEmpty(onadate))
        {
            if (DateTime.Parse(onadate).Year > 1999)
            {
                month = DateTime.Parse(onadate).ToString("MMM") + "-" + DateTime.Parse(onadate).Year;
            }
        }
        else if (!String.IsNullOrEmpty(dateSold))
        {
            if (DateTime.Parse(dateSold).Year > 1999)
            {
                month = DateTime.Parse(dateSold).ToString("MMM") + "-" + DateTime.Parse(dateSold).Year;
            }
        }
        else
        {
            if (DateTime.Parse(dateListed).Year > 1999)
            {
                month = DateTime.Parse(dateListed).ToString("MMM") + "-" + DateTime.Parse(dateListed).Year;
            }
        }

        if (!String.IsNullOrEmpty(month))
        {
            month = "Sold Month: " + month;
        }
        return month;
    }
    public string getPriceBuilding2(string strPriceOption, string strPriceLow, string strPriceHigh)
    {
        string price = "";
        if (!String.IsNullOrEmpty(strPriceLow))
        {
            if (decimal.Parse(strPriceLow.ToString()) > 0)
            {
                if (strPriceOption.ToLower().Equals("price"))
                {
                    if (!String.IsNullOrEmpty(strPriceLow))
                    {
                        price = decimal.Parse(strPriceLow).ToString("$#,##0");
                    }
                }
                if (strPriceOption.ToLower().Equals("range"))
                {
                    if (!String.IsNullOrEmpty(strPriceLow))
                    {
                        price = decimal.Parse(strPriceLow).ToString("$#,##0");
                    }
                    if (decimal.Parse(strPriceHigh.ToString()) > 0)
                    {
                        if (!String.IsNullOrEmpty(strPriceHigh))
                        {
                            price = price + " to ";
                            price = price + decimal.Parse(strPriceHigh).ToString("$#,##0");
                        }
                    }
                    else
                    {
                        price = "From " + price;
                    }
                }
            }
            else
            {
                price = "";
            }
        }
        else
        {

            price = "";
        }


        return price;
    }

    public string getPriceBuilding(string strPriceOption, string strPriceLow, string strPriceHigh, string strStatus, string strPaymentPeriod)
    {
        string price = "";
        if (!String.IsNullOrEmpty(strPriceOption))
        {
            if (strPriceOption.ToLower().Equals("price"))
            {
                if (!String.IsNullOrEmpty(strPriceLow))
                {
                    price = decimal.Parse(strPriceLow).ToString("$#,##0");
                }
            }
            if (strPriceOption.ToLower().Equals("range"))
            {
                if (!String.IsNullOrEmpty(strPriceLow))
                {
                    price = decimal.Parse(strPriceLow).ToString("$#,##0");
                }
                if (!String.IsNullOrEmpty(strPriceHigh))
                {
                    price = price + " to ";
                    price = price + decimal.Parse(strPriceHigh).ToString("$#,##0");
                }

            }
            if (strPriceOption.ToLower().Equals("pricefrom"))
            {
                if (!String.IsNullOrEmpty(strPriceLow))
                {
                    price = "From " + decimal.Parse(strPriceLow).ToString("$#,##0");
                }
            }
            if (strPriceOption.ToLower().Equals("auction"))
            {
                price = "<font color=red>For Auction</font>";
            }
            if (strPriceOption.ToLower().Equals("tender"))
            {
                price = "<font color=red>TENDER</font>";
            }
            if (strPriceOption.ToLower().Equals("eoi"))
            {
                price = "<font color=red>EOI</font>";
            }
            if (strStatus.ToLower().Equals("sold"))
            {
                price = "<font color=red>SOLD</font>";
            }
            if (strStatus.ToLower().Equals("under offer"))
            {
                price = "<font color=red>UNDER OFFER</font>";
            }
            if (strStatus.ToLower().Equals("rented"))
            {
                price = "<font color=red>RENTED</font>";
            }
            if (strStatus.ToLower().Equals("for rent"))
            {
                price = price + " " + strPaymentPeriod;
            }

        }
        else
        {

            price = "";
        }
        return price;
    }


    public string getBedRange(string bedLow, string bedHigh)
    {
        string bed = "";
        if (!String.IsNullOrEmpty(bedLow))
        {
            if (decimal.Parse(bedLow.ToString()) > 0)
            {
                if (!String.IsNullOrEmpty(bedLow))
                {
                    bed = "Bedrooms: " + bedLow;
                }
                if (!String.IsNullOrEmpty(bedHigh))
                {
                    bed = bed + " to " + bedHigh;
                }
            }
            else
            {
                bed = "";
            }
        }
        else
        {
            bed = "";
        }
        return bed;
    }

    public string getSuburbsNearBy(string suburb)
    {
        string strSuburbs = "";
        connection.Open();
        SqlCommand command = new SqlCommand("spGetSuburbsNearBy", connection);
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.Add(new SqlParameter("@suburb", suburb));
        SqlDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
            if (!reader.IsDBNull(reader.GetOrdinal("suburbs1")) && reader.GetString(reader.GetOrdinal("suburbs1")) != "")
            {
                if (strSuburbs == "")
                {
                    strSuburbs = reader.GetString(reader.GetOrdinal("suburbs1"));
                }
                else
                {
                    strSuburbs = strSuburbs + "," + reader.GetString(reader.GetOrdinal("suburbs1"));
                }
            }
            //
            if (!reader.IsDBNull(reader.GetOrdinal("suburbs2")) && reader.GetString(reader.GetOrdinal("suburbs2")) != "")
            {
                if (strSuburbs == "")
                {
                    strSuburbs = reader.GetString(reader.GetOrdinal("suburbs2"));
                }
                else
                {
                    strSuburbs = strSuburbs + "," + reader.GetString(reader.GetOrdinal("suburbs2"));
                }
            }
            if (!reader.IsDBNull(reader.GetOrdinal("suburbs3")) && reader.GetString(reader.GetOrdinal("suburbs3")) != "")
            {
                if (strSuburbs == "")
                {
                    strSuburbs = reader.GetString(reader.GetOrdinal("suburbs3"));
                }
                else
                {
                    strSuburbs = strSuburbs + "," + reader.GetString(reader.GetOrdinal("suburbs3"));
                }
            }
            if (!reader.IsDBNull(reader.GetOrdinal("suburbs4")) && reader.GetString(reader.GetOrdinal("suburbs4")) != "")
            {
                if (strSuburbs == "")
                {
                    strSuburbs = reader.GetString(reader.GetOrdinal("suburbs4"));
                }
                else
                {
                    strSuburbs = strSuburbs + "," + reader.GetString(reader.GetOrdinal("suburbs4"));
                }
            }
            if (!reader.IsDBNull(reader.GetOrdinal("suburbs5")) && reader.GetString(reader.GetOrdinal("suburbs5")) != "")
            {
                if (strSuburbs == "")
                {
                    strSuburbs = reader.GetString(reader.GetOrdinal("suburbs5"));
                }
                else
                {
                    strSuburbs = strSuburbs + "," + reader.GetString(reader.GetOrdinal("suburbs5"));
                }
            }
            if (!reader.IsDBNull(reader.GetOrdinal("suburbs6")) && reader.GetString(reader.GetOrdinal("suburbs6")) != "")
            {
                if (strSuburbs == "")
                {
                    strSuburbs = reader.GetString(reader.GetOrdinal("suburbs6"));
                }
                else
                {
                    strSuburbs = strSuburbs + "," + reader.GetString(reader.GetOrdinal("suburbs6"));
                }
            }
            if (!reader.IsDBNull(reader.GetOrdinal("suburbs7")) && reader.GetString(reader.GetOrdinal("suburbs7")) != "")
            {
                if (strSuburbs == "")
                {
                    strSuburbs = reader.GetString(reader.GetOrdinal("suburbs7"));
                }
                else
                {
                    strSuburbs = strSuburbs + "," + reader.GetString(reader.GetOrdinal("suburbs7"));
                }
            }
            if (!reader.IsDBNull(reader.GetOrdinal("suburbs8")) && reader.GetString(reader.GetOrdinal("suburbs8")) != "")
            {
                if (strSuburbs == "")
                {
                    strSuburbs = reader.GetString(reader.GetOrdinal("suburbs8"));
                }
                else
                {
                    strSuburbs = strSuburbs + "," + reader.GetString(reader.GetOrdinal("suburbs8"));
                }
            }
            if (!reader.IsDBNull(reader.GetOrdinal("suburbs9")) && reader.GetString(reader.GetOrdinal("suburbs9")) != "")
            {
                if (strSuburbs == "")
                {
                    strSuburbs = reader.GetString(reader.GetOrdinal("suburbs9"));
                }
                else
                {
                    strSuburbs = strSuburbs + "," + reader.GetString(reader.GetOrdinal("suburbs9"));
                }
            }
            if (!reader.IsDBNull(reader.GetOrdinal("suburbs10")) && reader.GetString(reader.GetOrdinal("suburbs10")) != "")
            {
                if (strSuburbs == "")
                {
                    strSuburbs = reader.GetString(reader.GetOrdinal("suburbs10"));
                }
                else
                {
                    strSuburbs = strSuburbs + "," + reader.GetString(reader.GetOrdinal("suburbs10"));
                }
            }
            if (!reader.IsDBNull(reader.GetOrdinal("suburbs11")) && reader.GetString(reader.GetOrdinal("suburbs11")) != "")
            {
                if (strSuburbs == "")
                {
                    strSuburbs = reader.GetString(reader.GetOrdinal("suburbs11"));
                }
                else
                {
                    strSuburbs = strSuburbs + "," + reader.GetString(reader.GetOrdinal("suburbs11"));
                }
            }
            if (!reader.IsDBNull(reader.GetOrdinal("suburbs12")) && reader.GetString(reader.GetOrdinal("suburbs12")) != "")
            {
                if (strSuburbs == "")
                {
                    strSuburbs = reader.GetString(reader.GetOrdinal("suburbs12"));
                }
                else
                {
                    strSuburbs = strSuburbs + "," + reader.GetString(reader.GetOrdinal("suburbs12"));
                }
            }
        }
        connection.Close();
        return strSuburbs;

    }

    public string getSuburbsNearByMultiple(string suburb)
    {
        string strSuburbs = "";
        connection.Open();
        SqlCommand command = new SqlCommand("spGetSuburbsNearByMultiple", connection);
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.Add(new SqlParameter("@suburb", suburb));
        SqlDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
            if (!reader.IsDBNull(reader.GetOrdinal("suburbs1")) && reader.GetString(reader.GetOrdinal("suburbs1")) != "")
            {
                if (strSuburbs == "")
                {
                    strSuburbs = reader.GetString(reader.GetOrdinal("suburbs1"));
                }
                else
                {
                    strSuburbs = strSuburbs + "," + reader.GetString(reader.GetOrdinal("suburbs1"));
                }
            }
            //
            if (!reader.IsDBNull(reader.GetOrdinal("suburbs2")) && reader.GetString(reader.GetOrdinal("suburbs2")) != "")
            {
                if (strSuburbs == "")
                {
                    strSuburbs = reader.GetString(reader.GetOrdinal("suburbs2"));
                }
                else
                {
                    strSuburbs = strSuburbs + "," + reader.GetString(reader.GetOrdinal("suburbs2"));
                }
            }
            if (!reader.IsDBNull(reader.GetOrdinal("suburbs3")) && reader.GetString(reader.GetOrdinal("suburbs3")) != "")
            {
                if (strSuburbs == "")
                {
                    strSuburbs = reader.GetString(reader.GetOrdinal("suburbs3"));
                }
                else
                {
                    strSuburbs = strSuburbs + "," + reader.GetString(reader.GetOrdinal("suburbs3"));
                }
            }
            if (!reader.IsDBNull(reader.GetOrdinal("suburbs4")) && reader.GetString(reader.GetOrdinal("suburbs4")) != "")
            {
                if (strSuburbs == "")
                {
                    strSuburbs = reader.GetString(reader.GetOrdinal("suburbs4"));
                }
                else
                {
                    strSuburbs = strSuburbs + "," + reader.GetString(reader.GetOrdinal("suburbs4"));
                }
            }
            if (!reader.IsDBNull(reader.GetOrdinal("suburbs5")) && reader.GetString(reader.GetOrdinal("suburbs5")) != "")
            {
                if (strSuburbs == "")
                {
                    strSuburbs = reader.GetString(reader.GetOrdinal("suburbs5"));
                }
                else
                {
                    strSuburbs = strSuburbs + "," + reader.GetString(reader.GetOrdinal("suburbs5"));
                }
            }
            if (!reader.IsDBNull(reader.GetOrdinal("suburbs6")) && reader.GetString(reader.GetOrdinal("suburbs6")) != "")
            {
                if (strSuburbs == "")
                {
                    strSuburbs = reader.GetString(reader.GetOrdinal("suburbs6"));
                }
                else
                {
                    strSuburbs = strSuburbs + "," + reader.GetString(reader.GetOrdinal("suburbs6"));
                }
            }
            if (!reader.IsDBNull(reader.GetOrdinal("suburbs7")) && reader.GetString(reader.GetOrdinal("suburbs7")) != "")
            {
                if (strSuburbs == "")
                {
                    strSuburbs = reader.GetString(reader.GetOrdinal("suburbs7"));
                }
                else
                {
                    strSuburbs = strSuburbs + "," + reader.GetString(reader.GetOrdinal("suburbs7"));
                }
            }
            if (!reader.IsDBNull(reader.GetOrdinal("suburbs8")) && reader.GetString(reader.GetOrdinal("suburbs8")) != "")
            {
                if (strSuburbs == "")
                {
                    strSuburbs = reader.GetString(reader.GetOrdinal("suburbs8"));
                }
                else
                {
                    strSuburbs = strSuburbs + "," + reader.GetString(reader.GetOrdinal("suburbs8"));
                }
            }
            if (!reader.IsDBNull(reader.GetOrdinal("suburbs9")) && reader.GetString(reader.GetOrdinal("suburbs9")) != "")
            {
                if (strSuburbs == "")
                {
                    strSuburbs = reader.GetString(reader.GetOrdinal("suburbs9"));
                }
                else
                {
                    strSuburbs = strSuburbs + "," + reader.GetString(reader.GetOrdinal("suburbs9"));
                }
            }
            if (!reader.IsDBNull(reader.GetOrdinal("suburbs10")) && reader.GetString(reader.GetOrdinal("suburbs10")) != "")
            {
                if (strSuburbs == "")
                {
                    strSuburbs = reader.GetString(reader.GetOrdinal("suburbs10"));
                }
                else
                {
                    strSuburbs = strSuburbs + "," + reader.GetString(reader.GetOrdinal("suburbs10"));
                }
            }
            if (!reader.IsDBNull(reader.GetOrdinal("suburbs11")) && reader.GetString(reader.GetOrdinal("suburbs11")) != "")
            {
                if (strSuburbs == "")
                {
                    strSuburbs = reader.GetString(reader.GetOrdinal("suburbs11"));
                }
                else
                {
                    strSuburbs = strSuburbs + "," + reader.GetString(reader.GetOrdinal("suburbs11"));
                }
            }
            if (!reader.IsDBNull(reader.GetOrdinal("suburbs12")) && reader.GetString(reader.GetOrdinal("suburbs12")) != "")
            {
                if (strSuburbs == "")
                {
                    strSuburbs = reader.GetString(reader.GetOrdinal("suburbs12"));
                }
                else
                {
                    strSuburbs = strSuburbs + "," + reader.GetString(reader.GetOrdinal("suburbs12"));
                }
            }
        }
        connection.Close();
        return strSuburbs;

    }
    public string getSuburbsNearByPostcode(string suburb)
    {
        string strSuburbs = "";
        connection.Open();
        SqlCommand command = new SqlCommand("spGetSuburbsNearBy", connection);
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.Add(new SqlParameter("@suburb", suburb));
        SqlDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
            if (!reader.IsDBNull(reader.GetOrdinal("postcode1")) && reader.GetValue(reader.GetOrdinal("postcode1")).ToString() != "")
            {
                if (strSuburbs == "")
                {
                    strSuburbs = reader.GetValue(reader.GetOrdinal("postcode1")).ToString();
                }
                else
                {
                    strSuburbs = strSuburbs + "," + reader.GetValue(reader.GetOrdinal("postcode1")).ToString();
                }
            }
            if (!reader.IsDBNull(reader.GetOrdinal("postcode2")) && reader.GetValue(reader.GetOrdinal("postcode2")).ToString() != "")
            {
                if (strSuburbs == "")
                {
                    strSuburbs = reader.GetValue(reader.GetOrdinal("postcode2")).ToString();
                }
                else
                {
                    strSuburbs = strSuburbs + "," + reader.GetValue(reader.GetOrdinal("postcode2")).ToString();
                }
            }
            if (!reader.IsDBNull(reader.GetOrdinal("postcode3")) && reader.GetValue(reader.GetOrdinal("postcode3")).ToString() != "")
            {
                if (strSuburbs == "")
                {
                    strSuburbs = reader.GetValue(reader.GetOrdinal("postcode3")).ToString();
                }
                else
                {
                    strSuburbs = strSuburbs + "," + reader.GetValue(reader.GetOrdinal("postcode3")).ToString();
                }
            }
            if (!reader.IsDBNull(reader.GetOrdinal("postcode4")) && reader.GetValue(reader.GetOrdinal("postcode4")).ToString() != "")
            {
                if (strSuburbs == "")
                {
                    strSuburbs = reader.GetValue(reader.GetOrdinal("postcode4")).ToString();
                }
                else
                {
                    strSuburbs = strSuburbs + "," + reader.GetValue(reader.GetOrdinal("postcode4")).ToString();
                }
            }
            if (!reader.IsDBNull(reader.GetOrdinal("postcode5")) && reader.GetValue(reader.GetOrdinal("postcode5")).ToString() != "")
            {
                if (strSuburbs == "")
                {
                    strSuburbs = reader.GetValue(reader.GetOrdinal("postcode5")).ToString();
                }
                else
                {
                    strSuburbs = strSuburbs + "," + reader.GetValue(reader.GetOrdinal("postcode5")).ToString();
                }
            }
            if (!reader.IsDBNull(reader.GetOrdinal("postcode6")) && reader.GetValue(reader.GetOrdinal("postcode6")).ToString() != "")
            {
                if (strSuburbs == "")
                {
                    strSuburbs = reader.GetValue(reader.GetOrdinal("postcode6")).ToString();
                }
                else
                {
                    strSuburbs = strSuburbs + "," + reader.GetValue(reader.GetOrdinal("postcode6")).ToString();
                }
            }
            if (!reader.IsDBNull(reader.GetOrdinal("postcode7")) && reader.GetValue(reader.GetOrdinal("postcode7")).ToString() != "")
            {
                if (strSuburbs == "")
                {
                    strSuburbs = reader.GetValue(reader.GetOrdinal("postcode7")).ToString();
                }
                else
                {
                    strSuburbs = strSuburbs + "," + reader.GetValue(reader.GetOrdinal("postcode7")).ToString();
                }
            }
            if (!reader.IsDBNull(reader.GetOrdinal("postcode8")) && reader.GetValue(reader.GetOrdinal("postcode8")).ToString() != "")
            {
                if (strSuburbs == "")
                {
                    strSuburbs = reader.GetValue(reader.GetOrdinal("postcode8")).ToString();
                }
                else
                {
                    strSuburbs = strSuburbs + "," + reader.GetValue(reader.GetOrdinal("postcode8")).ToString();
                }
            }
            if (!reader.IsDBNull(reader.GetOrdinal("postcode9")) && reader.GetValue(reader.GetOrdinal("postcode9")).ToString() != "")
            {
                if (strSuburbs == "")
                {
                    strSuburbs = reader.GetValue(reader.GetOrdinal("postcode9")).ToString();
                }
                else
                {
                    strSuburbs = strSuburbs + "," + reader.GetValue(reader.GetOrdinal("postcode9")).ToString();
                }
            }
            if (!reader.IsDBNull(reader.GetOrdinal("postcode10")) && reader.GetValue(reader.GetOrdinal("postcode10")).ToString() != "")
            {
                if (strSuburbs == "")
                {
                    strSuburbs = reader.GetValue(reader.GetOrdinal("postcode10")).ToString();
                }
                else
                {
                    strSuburbs = strSuburbs + "," + reader.GetValue(reader.GetOrdinal("postcode10")).ToString();
                }
            }
            if (!reader.IsDBNull(reader.GetOrdinal("postcode11")) && reader.GetValue(reader.GetOrdinal("postcode11")).ToString() != "")
            {
                if (strSuburbs == "")
                {
                    strSuburbs = reader.GetValue(reader.GetOrdinal("postcode11")).ToString();
                }
                else
                {
                    strSuburbs = strSuburbs + "," + reader.GetValue(reader.GetOrdinal("postcode11")).ToString();
                }
            }
            if (!reader.IsDBNull(reader.GetOrdinal("postcode12")) && reader.GetValue(reader.GetOrdinal("postcode12")).ToString() != "")
            {
                if (strSuburbs == "")
                {
                    strSuburbs = reader.GetValue(reader.GetOrdinal("postcode12")).ToString();
                }
                else
                {
                    strSuburbs = strSuburbs + "," + reader.GetValue(reader.GetOrdinal("postcode12")).ToString();
                }
            }


        }
        connection.Close();
        return strSuburbs;

    }
    public string getSuburbsNearByPostcodeMultiple(string suburb)
    {
        string strSuburbs = "";
        connection.Open();
        SqlCommand command = new SqlCommand("spGetSuburbsNearByMultiple", connection);
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.Add(new SqlParameter("@suburb", suburb));
        SqlDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
            if (!reader.IsDBNull(reader.GetOrdinal("postcode1")) && reader.GetValue(reader.GetOrdinal("postcode1")).ToString() != "")
            {
                if (strSuburbs == "")
                {
                    strSuburbs = reader.GetValue(reader.GetOrdinal("postcode1")).ToString();
                }
                else
                {
                    strSuburbs = strSuburbs + "," + reader.GetValue(reader.GetOrdinal("postcode1")).ToString();
                }
            }
            if (!reader.IsDBNull(reader.GetOrdinal("postcode2")) && reader.GetValue(reader.GetOrdinal("postcode2")).ToString() != "")
            {
                if (strSuburbs == "")
                {
                    strSuburbs = reader.GetValue(reader.GetOrdinal("postcode2")).ToString();
                }
                else
                {
                    strSuburbs = strSuburbs + "," + reader.GetValue(reader.GetOrdinal("postcode2")).ToString();
                }
            }
            if (!reader.IsDBNull(reader.GetOrdinal("postcode3")) && reader.GetValue(reader.GetOrdinal("postcode3")).ToString() != "")
            {
                if (strSuburbs == "")
                {
                    strSuburbs = reader.GetValue(reader.GetOrdinal("postcode3")).ToString();
                }
                else
                {
                    strSuburbs = strSuburbs + "," + reader.GetValue(reader.GetOrdinal("postcode3")).ToString();
                }
            }
            if (!reader.IsDBNull(reader.GetOrdinal("postcode4")) && reader.GetValue(reader.GetOrdinal("postcode4")).ToString() != "")
            {
                if (strSuburbs == "")
                {
                    strSuburbs = reader.GetValue(reader.GetOrdinal("postcode4")).ToString();
                }
                else
                {
                    strSuburbs = strSuburbs + "," + reader.GetValue(reader.GetOrdinal("postcode4")).ToString();
                }
            }
            if (!reader.IsDBNull(reader.GetOrdinal("postcode5")) && reader.GetValue(reader.GetOrdinal("postcode5")).ToString() != "")
            {
                if (strSuburbs == "")
                {
                    strSuburbs = reader.GetValue(reader.GetOrdinal("postcode5")).ToString();
                }
                else
                {
                    strSuburbs = strSuburbs + "," + reader.GetValue(reader.GetOrdinal("postcode5")).ToString();
                }
            }
            if (!reader.IsDBNull(reader.GetOrdinal("postcode6")) && reader.GetValue(reader.GetOrdinal("postcode6")).ToString() != "")
            {
                if (strSuburbs == "")
                {
                    strSuburbs = reader.GetValue(reader.GetOrdinal("postcode6")).ToString();
                }
                else
                {
                    strSuburbs = strSuburbs + "," + reader.GetValue(reader.GetOrdinal("postcode6")).ToString();
                }
            }
            if (!reader.IsDBNull(reader.GetOrdinal("postcode7")) && reader.GetValue(reader.GetOrdinal("postcode7")).ToString() != "")
            {
                if (strSuburbs == "")
                {
                    strSuburbs = reader.GetValue(reader.GetOrdinal("postcode7")).ToString();
                }
                else
                {
                    strSuburbs = strSuburbs + "," + reader.GetValue(reader.GetOrdinal("postcode7")).ToString();
                }
            }
            if (!reader.IsDBNull(reader.GetOrdinal("postcode8")) && reader.GetValue(reader.GetOrdinal("postcode8")).ToString() != "")
            {
                if (strSuburbs == "")
                {
                    strSuburbs = reader.GetValue(reader.GetOrdinal("postcode8")).ToString();
                }
                else
                {
                    strSuburbs = strSuburbs + "," + reader.GetValue(reader.GetOrdinal("postcode8")).ToString();
                }
            }
            if (!reader.IsDBNull(reader.GetOrdinal("postcode9")) && reader.GetValue(reader.GetOrdinal("postcode9")).ToString() != "")
            {
                if (strSuburbs == "")
                {
                    strSuburbs = reader.GetValue(reader.GetOrdinal("postcode9")).ToString();
                }
                else
                {
                    strSuburbs = strSuburbs + "," + reader.GetValue(reader.GetOrdinal("postcode9")).ToString();
                }
            }
            if (!reader.IsDBNull(reader.GetOrdinal("postcode10")) && reader.GetValue(reader.GetOrdinal("postcode10")).ToString() != "")
            {
                if (strSuburbs == "")
                {
                    strSuburbs = reader.GetValue(reader.GetOrdinal("postcode10")).ToString();
                }
                else
                {
                    strSuburbs = strSuburbs + "," + reader.GetValue(reader.GetOrdinal("postcode10")).ToString();
                }
            }
            if (!reader.IsDBNull(reader.GetOrdinal("postcode11")) && reader.GetValue(reader.GetOrdinal("postcode11")).ToString() != "")
            {
                if (strSuburbs == "")
                {
                    strSuburbs = reader.GetValue(reader.GetOrdinal("postcode11")).ToString();
                }
                else
                {
                    strSuburbs = strSuburbs + "," + reader.GetValue(reader.GetOrdinal("postcode11")).ToString();
                }
            }
            if (!reader.IsDBNull(reader.GetOrdinal("postcode12")) && reader.GetValue(reader.GetOrdinal("postcode12")).ToString() != "")
            {
                if (strSuburbs == "")
                {
                    strSuburbs = reader.GetValue(reader.GetOrdinal("postcode12")).ToString();
                }
                else
                {
                    strSuburbs = strSuburbs + "," + reader.GetValue(reader.GetOrdinal("postcode12")).ToString();
                }
            }


        }
        connection.Close();
        return strSuburbs;

    }
    public SqlDataReader getPropertyTypes()
    {
        connection.Open();
        SqlCommand command = new SqlCommand("spGetConstPropertyTypeNew", connection);
        command.CommandType = CommandType.StoredProcedure;
        SqlDataReader reader = command.ExecuteReader();
        return reader;
    }
    public SqlDataReader getOfficeAgents(string acID)
    {
        connection.Open();
        SqlCommand command = new SqlCommand("spGetAgencyAgents", connection);
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.Add(new SqlParameter("@acID", acID));
        SqlDataReader reader = command.ExecuteReader();
        return reader;
    }

    public SqlDataReader getOfficeAgentsImis(string acID)
    {
        connection.Open();
        SqlCommand command = new SqlCommand("spGetAgencyAgentsImis", connection);
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.Add(new SqlParameter("@acID", acID));
        SqlDataReader reader = command.ExecuteReader();
        return reader;
    }
    public SqlDataReader getOfficeAgentsImisProfile(string acID)
    {
        connection.Open();
        SqlCommand command = new SqlCommand("spGetAgencyAgentsImisAgencyProf", connection);
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.Add(new SqlParameter("@acID", acID));
        SqlDataReader reader = command.ExecuteReader();
        return reader;
    }

    public SqlDataReader getOfficeAgentsOrder(string acID, string ordermin, string ordermax)
    {
        connection.Open();
        SqlCommand command = new SqlCommand("spGetAgencyAgentsOrderID", connection);
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.Add(new SqlParameter("@acID", acID));
        command.Parameters.Add(new SqlParameter("@ordermin", ordermin));
        command.Parameters.Add(new SqlParameter("@ordermax", ordermax));
        SqlDataReader reader = command.ExecuteReader();
        return reader;
    }

    public SqlDataReader getSoldProperties(string state, string suburb, string strNumDays)
    {
        connection.Close();
        connection.Open();
        SqlCommand command = new SqlCommand("spSoldPropertiesGet", connection);
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.Add(new SqlParameter("@state", state));
        command.Parameters.Add(new SqlParameter("@suburb", suburb));
        command.Parameters.Add(new SqlParameter("@daystocount", strNumDays));
        SqlDataReader reader = command.ExecuteReader();
        return reader;
    }

    public int getSoldPropertiesCount(string state, string suburb, string strNumDays)
    {
        int count = 0;
        connection.Close();
        connection.Open();
        SqlCommand command = new SqlCommand("spSoldPropertiesGetCount", connection);
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.Add(new SqlParameter("@state", state));
        command.Parameters.Add(new SqlParameter("@suburb", suburb));
        command.Parameters.Add(new SqlParameter("@daystocount", strNumDays));
        SqlDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
            if (!reader.IsDBNull(reader.GetOrdinal("count")))
            {
                count = reader.GetInt32(reader.GetOrdinal("count"));
            }
        }

        return count;
    }


    public SqlDataReader getSearchResultsFeature(string acID, string status, string suburb, string orderby, string postcode, string aid, string pid, string type)
    {
        connection.Open();
        SqlCommand command = new SqlCommand("spGetPropertiesWithSoldnew", connection);
        command.CommandType = CommandType.StoredProcedure;
        command.CommandTimeout = 120;
        command.Parameters.Add(new SqlParameter("@acID", acID));
        command.Parameters.Add(new SqlParameter("@status", status));
        command.Parameters.Add(new SqlParameter("@type", type));
        command.Parameters.Add(new SqlParameter("@suburb", suburb));
        command.Parameters.Add(new SqlParameter("@postcode1", postcode));
        command.Parameters.Add(new SqlParameter("@aid1", aid));
        command.Parameters.Add(new SqlParameter("@pids", pid));
        command.Parameters.Add(new SqlParameter("@orderBy", orderby));
        command.Parameters.Add(new SqlParameter("@hideAHC", "0"));

        SqlDataReader reader = command.ExecuteReader();
        return reader;
    }

    public SqlDataReader getSearchResults(string region, string state, string acID, string status, string suburb, string type, string ctype, string pricelow, string priceHigh, string bedlow, string bedhigh, string bathlow, string bathhigh, string carlow, string carhigh, string keyword, string days, string orderby, string blinvest, string lifestyle, string lotsize, string furnished, string hasVT, string strPets, string postcode, string homeopen, string aid, string pids)
    {
        connection.Open();
        SqlCommand command = new SqlCommand("spGetPropertiesWithSoldnew", connection);
        command.CommandType = CommandType.StoredProcedure;
        command.CommandTimeout = 120;
        command.Parameters.Add(new SqlParameter("@top", "5000"));
        command.Parameters.Add(new SqlParameter("@acID", acID));
        command.Parameters.Add(new SqlParameter("@state", state));
        command.Parameters.Add(new SqlParameter("@type", type));
        command.Parameters.Add(new SqlParameter("@commercialcategory", ctype));
        command.Parameters.Add(new SqlParameter("@suburb", suburb));
        command.Parameters.Add(new SqlParameter("@postcode1", postcode));
        command.Parameters.Add(new SqlParameter("@region", region));
        command.Parameters.Add(new SqlParameter("@status", status));
        command.Parameters.Add(new SqlParameter("@priceLow", pricelow));
        command.Parameters.Add(new SqlParameter("@priceHigh", priceHigh));
        command.Parameters.Add(new SqlParameter("@numBedLow", bedlow));
        command.Parameters.Add(new SqlParameter("@numBedhigh", bedhigh));
        command.Parameters.Add(new SqlParameter("@numBathLow", bathlow));
        command.Parameters.Add(new SqlParameter("@numBathhigh", bathhigh));
        command.Parameters.Add(new SqlParameter("@numcarlow", carlow));
        command.Parameters.Add(new SqlParameter("@numcarhigh", carhigh));
        command.Parameters.Add(new SqlParameter("@dateListed", days));
        command.Parameters.Add(new SqlParameter("@isInvestment", blinvest));
        command.Parameters.Add(new SqlParameter("@descriptionSearch", keyword));
        command.Parameters.Add(new SqlParameter("@lifestyle", convertListToSQL(lifestyle)));
        command.Parameters.Add(new SqlParameter("@lotSizeLow", lotsize));
        command.Parameters.Add(new SqlParameter("@isFurnished", furnished));
        command.Parameters.Add(new SqlParameter("@hasVT", hasVT));
        command.Parameters.Add(new SqlParameter("@petStatus", strPets));
        command.Parameters.Add(new SqlParameter("@hideAHC", "0"));
        command.Parameters.Add(new SqlParameter("@pIDs", pids));
        command.Parameters.Add(new SqlParameter("@aid1", aid));
        command.Parameters.Add(new SqlParameter("@orderBy", orderby));

        if (!string.IsNullOrEmpty(homeopen))
            command.Parameters.Add(new SqlParameter("@homeopen", homeopen));

        if (status == "fs" || status == "sa" || status == "fr" || status == "ra")
            command.Parameters.Add(new SqlParameter("@flagAllTypeWithoutCommBuss", "allwithoutcommandbuss"));
        else if (status.ToLower() == "('for sale')" && (type.ToLower() == "any" || type.ToLower() == ""))
            command.Parameters.Add(new SqlParameter("@flagAllTypeWithoutCommBuss", "allwithoutcommandbuss"));



        SqlDataReader reader = command.ExecuteReader();
        return reader;
    }




    public int getSearchResultsCount(string state, string status, string justlisted)
    {
        int count = 0;
        connection.Close();
        connection.Open();

        string type = "Any";
        if (status == "co")
        {
            status = "fs";
            type = "Commercial";
        }

        if (status == "cr")
        {
            status = "fr";
            type = "Commercial";
        }
        if (status == "bu")
        {
            status = "fs";
            type = "Business";
        }
        if (status == "buso")
        {
            status = "so";
            type = "Business";
        }
        if (status == "ru")
        {
            status = "fs";
            type = "Acreage/Rural";
        }

        SqlCommand command = new SqlCommand("spGetPropertiesCount_New", connection);
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.Add(new SqlParameter("@state", state));
        command.Parameters.Add(new SqlParameter("@status", status));
        command.Parameters.Add(new SqlParameter("@dateListed", justlisted));
        command.Parameters.Add(new SqlParameter("@type", convertListToSQL(type)));
        command.Parameters.Add(new SqlParameter("@hideAHC", "0"));

        if (status == "sa" || status == "fs" || status == "au" || status == "ra" || status == "fr")
            command.Parameters.Add(new SqlParameter("@flagAllTypeWithoutCommBuss", "AllWithoutCommAndBusiness"));

        SqlDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
            if (!reader.IsDBNull(reader.GetOrdinal("count")))
            {
                count = reader.GetInt32(reader.GetOrdinal("count"));
            }
        }

        return count;
    }
    public int getSearchSoldResultsCount(string state, string status, string justlisted)
    {
        int count = 0;
        connection.Close();
        connection.Open();
        SqlCommand command = new SqlCommand("spGetPropertiesCount_New", connection);
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.Add(new SqlParameter("@state", state));
        command.Parameters.Add(new SqlParameter("@status", status));
        command.Parameters.Add(new SqlParameter("@dateListed", justlisted));
        command.Parameters.Add(new SqlParameter("@isWebDisplay", "any"));
        command.Parameters.Add(new SqlParameter("@hideAHC", "0"));
        SqlDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
            if (!reader.IsDBNull(reader.GetOrdinal("count")))
            {
                count = reader.GetInt32(reader.GetOrdinal("count"));
            }
        }

        return count;
    }
    public int getSearchResultsCountInvestment(string state, string status, string justlisted, string strInvestment)
    {
        int count = 0;
        connection.Close();
        connection.Open();

        string type = "Any";
        if (status == "co")
        {
            status = "fs";
            type = "Commercial";
        }

        if (status == "cr")
        {
            status = "fr";
            type = "Commercial";
        }
        if (status == "bu")
        {
            status = "fs";
            type = "Business";
        }

        SqlCommand command = new SqlCommand("spGetPropertiesCount_New", connection);
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.Add(new SqlParameter("@state", state));
        command.Parameters.Add(new SqlParameter("@status", status));
        command.Parameters.Add(new SqlParameter("@dateListed", justlisted));
        command.Parameters.Add(new SqlParameter("@type", convertListToSQL(type)));
        command.Parameters.Add(new SqlParameter("@isInvestment", strInvestment));
        command.Parameters.Add(new SqlParameter("@hideAHC", "0"));

        SqlDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
            if (!reader.IsDBNull(reader.GetOrdinal("count")))
            {
                count = reader.GetInt32(reader.GetOrdinal("count"));
            }
        }

        return count;
    }
    public int getSearchResultsCount(string state, string status, string justlisted, string strSuburb)
    {
        int count = 0;
        connection.Close();
        connection.Open();

        string type = "Any";
        if (status == "co")
        {
            status = "fs";
            type = "Commercial";
        }

        if (status == "cr")
        {
            status = "fr";
            type = "Commercial";
        }
        if (status == "bu")
        {
            status = "fs";
            type = "Business";
        }


        SqlCommand command = new SqlCommand("spGetPropertiesCount_New", connection);
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.Add(new SqlParameter("@state", state));
        command.Parameters.Add(new SqlParameter("@status", status));
        command.Parameters.Add(new SqlParameter("@dateListed", justlisted));
        command.Parameters.Add(new SqlParameter("@suburb", convertListToSQL(strSuburb)));
        command.Parameters.Add(new SqlParameter("@type", convertListToSQL(type)));
        command.Parameters.Add(new SqlParameter("@hideAHC", "0"));
        if (status == "fs" || status == "sa" || status == "fr" || status == "ra")
            command.Parameters.Add(new SqlParameter("@flagAllTypeWithoutCommBuss", "allwithoutcommandbuss"));
        SqlDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
            if (!reader.IsDBNull(reader.GetOrdinal("count")))
            {
                count = reader.GetInt32(reader.GetOrdinal("count"));
            }
        }

        return count;
    }

    public int getSearchResultsCountPerSuburb(string state, string suburb, string status)
    {
        int count = 0;
        connection.Open();
        SqlCommand command = new SqlCommand("spGetPropertiesCountWithSold", connection);
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.Add(new SqlParameter("@state", state));
        command.Parameters.Add(new SqlParameter("@suburb", convertListToSQL(suburb)));
        command.Parameters.Add(new SqlParameter("@status", status));
        SqlDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
            if (!reader.IsDBNull(reader.GetOrdinal("count")))
            {
                count = reader.GetInt32(reader.GetOrdinal("count"));
            }
        }
        connection.Close();
        return count;
    }

    public int getSearchAgentCountPerSuburb(string suburb)
    {
        int count = 0;
        connection.Open();
        SqlCommand command = new SqlCommand("spGetFindAgentCount", connection);
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.Add(new SqlParameter("@isWebDisplay", "1"));
        command.Parameters.Add(new SqlParameter("@suburb", convertListToSQL(suburb)));
        SqlDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
            if (!reader.IsDBNull(reader.GetOrdinal("count")))
            {
                count = reader.GetInt32(reader.GetOrdinal("count"));
            }
        }
        connection.Close();
        return count;
    }

    public SqlDataReader getFindAgent(string state, string status, string suburb, string orderby)
    {

        connection.Open();
        SqlCommand command = new SqlCommand("spGetFindAgent", connection);
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.Add(new SqlParameter("@isWebDisplay", "1"));
        command.Parameters.Add(new SqlParameter("@state", state));
        command.Parameters.Add(new SqlParameter("@status", status));
        command.Parameters.Add(new SqlParameter("@suburb", suburb));
        command.Parameters.Add(new SqlParameter("@orderBy", orderby));
        SqlDataReader reader = command.ExecuteReader();
        return reader;
    }



    public int getSearchResultsCount(string state, string acID, string status, string suburb, string type, string pricelow, string priceHigh, string beds, string baths, string keyword, string days, string orderby)
    {
        int count = 0;
        connection.Open();
        SqlCommand command = new SqlCommand("spGetPropertiesCountWithSold", connection);
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.Add(new SqlParameter("@acID", acID));
        command.Parameters.Add(new SqlParameter("@state", state));
        command.Parameters.Add(new SqlParameter("@type", type));
        command.Parameters.Add(new SqlParameter("@suburb", suburb));
        command.Parameters.Add(new SqlParameter("@status", status));
        command.Parameters.Add(new SqlParameter("@priceLow", pricelow));
        command.Parameters.Add(new SqlParameter("@priceHigh", priceHigh));
        command.Parameters.Add(new SqlParameter("@numBedLow", beds));
        command.Parameters.Add(new SqlParameter("@numBathLow", baths));
        command.Parameters.Add(new SqlParameter("@dateListed", days));
        command.Parameters.Add(new SqlParameter("@descriptionSearch", keyword));
        command.Parameters.Add(new SqlParameter("@orderBy", orderby));
        command.Parameters.Add(new SqlParameter("@isWebDisplay", "Any"));
        SqlDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
            if (!reader.IsDBNull(reader.GetOrdinal("count")))
            {
                count = reader.GetInt32(reader.GetOrdinal("count"));
            }
        }
        connection.Close();
        return count;
    }

    public string getsearchimageurl(string pid, bool hasphoto, string type, string address, string status, string price, string width, string height)
    {
        string imgurl = "";
        address = address.Replace("'", "");
        address = address.Replace("<BR>", ",");
        price = price.Replace("</font>", "");
        price = price.Replace("<font color=#dc0000>", "");
        price = price.Replace("<font color=#8400e9>", "");
        price = price.Replace("'", "");

        if (!String.IsNullOrEmpty(pid) && hasphoto)
        {
            if (price.ToUpper() == "RENTED" || price.ToUpper() == "SOLD" || price.ToUpper() == "UNDER OFFER")
            {
                imgurl = "<img src=" + ConfigurationManager.AppSettings["imageurl"].ToString() + "resize.ashx?width=" + width + "&height=" + height + "&path=images/properties/" + pid + "/" + pid + "_lg.jpg title='" + type + " " + status.ToLower() + " in " + address + "' border=0 class=propertyimg />";
            }
            else
            {
                imgurl = "<img src=" + ConfigurationManager.AppSettings["imageurl"].ToString() + "resize.ashx?width=" + width + "&height=" + height + "&path=images/properties/" + pid + "/" + pid + "_lg.jpg title='" + type + " " + status.ToLower() + " in " + address + " for " + price + "' border=0 class=propertyimg />";
            }

        }
        else
        {
            if (price.ToUpper() == "RENTED" || price.ToUpper() == "SOLD" || price.ToUpper() == "UNDER OFFER")
            {
                imgurl = "<img src=" + ConfigurationManager.AppSettings["imageurl"].ToString() + "resize.ashx?width=" + width + "&height=" + height + "&path=images/properties/0/0_lg.jpg title='" + type + " " + status.ToLower() + " in " + address + "' border=0 class=propertyimg />";
            }
            else
            {
                imgurl = "<img src=" + ConfigurationManager.AppSettings["imageurl"].ToString() + "resize.ashx?width=" + width + "&height=" + height + "&path=images/properties/0/0_lg.jpg title='" + type + " " + status.ToLower() + " in " + address + " for " + price + "' border=0 class=propertyimg />";
            }

        }

        return imgurl;
    }

    public string getsearchimageurlAll(string pid, int serial, string type, string address, string status, string price, string width, string height, string strcssclass)
    {
        string imgurl = "";
        address = address.Replace("'", "");
        address = address.Replace("<BR>", ",");
        price = price.Replace("</font>", "");
        price = price.Replace("<font color=#dc0000>", "");
        price = price.Replace("<font color=#8400e9>", "");
        price = price.Replace("'", "");

        if (!String.IsNullOrEmpty(pid))
        {
            if (price.ToUpper() == "RENTED" || price.ToUpper() == "SOLD" || price.ToUpper() == "UNDER OFFER")
            {
                imgurl = "<img src=" + ConfigurationManager.AppSettings["imageurl"].ToString() + "resizeheight.ashx?width=" + width + "&height=" + height + "&path=images/properties/" + pid + "/" + pid + "_MP" + serial + ".jpg title='" + type + " " + status.ToLower() + " in " + address + "' border=0 " + (!string.IsNullOrEmpty(strcssclass) ? "class=" + strcssclass : "") + "/>";
            }
            else
            {
                imgurl = "<img src=" + ConfigurationManager.AppSettings["imageurl"].ToString() + "resizeheight.ashx?width=" + width + "&height=" + height + "&path=images/properties/" + pid + "/" + pid + "_MP" + serial + ".jpg title='" + type + " " + status.ToLower() + " in " + address + " for " + price + "' border=0 " + (!string.IsNullOrEmpty(strcssclass) ? "class=" + strcssclass : "") + " />";
            }
        }

        return imgurl;
    }

    public string convertListToSQL(string listtocon)
    {
        if (!String.IsNullOrEmpty(listtocon))
        {
            listtocon = listtocon.Replace("'", "''");
            if (!listtocon.Equals("Any"))
            {
                listtocon = listtocon.Replace(",", "','");
                listtocon = listtocon + "')";
                listtocon = "('" + listtocon;
            }
        }
        else
        {
            listtocon = "Any";
        }
        return listtocon;
    }

    public string getfileName(string s)
    {
        string srn = s.Substring(s.LastIndexOf("192"));
        return srn;
    }
    public string getshortDescription(string s, int noChars)
    {
        if (s == null)
            s = "";
        if (s.Length > noChars)
        {
            s = s.Remove(noChars);
            if (s.LastIndexOf(" ") >= 0)
                s = s.Remove(s.LastIndexOf(" "));
        }
        return s;
    }

    public string getagentpic(string aid, bool hasphoto)
    {
        string imgurl = "";
        if (hasphoto)
        {
            if (!String.IsNullOrEmpty(aid))
            {
                imgurl = "<img border=0 src=" + ConfigurationManager.AppSettings["imageurl"].ToString() + "images/agency/" + acid + "/" + aid + "_PIC.jpg>";
            }

        }
        else
        {
            imgurl = "<img border=0 src=" + ConfigurationManager.AppSettings["webUrl"].ToString() + "images/ahc/web/blank_staff.gif>";
        }

        return imgurl;
    }
    public string getagentpic2(string aid, bool hasphoto)
    {
        string imgurl = "";
        if (hasphoto)
        {
            if (!String.IsNullOrEmpty(aid))
            {
                imgurl = "<img width='49' src='" + ConfigurationManager.AppSettings["imageurl"].ToString() + "images/agency/" + acid + "/" + aid + "_PIC.jpg' >";
            }
            else
            {
                imgurl = "<img src=/images/agentpic.gif>";
            }

        }
        return imgurl;
    }
    public string getNewlyAdded(string dateListed)
    {
        string newlyadded = "";
        TimeSpan ts = DateTime.Today - DateTime.Parse(dateListed);

        // Difference in days.
        int differenceInDays = ts.Days;
        if (differenceInDays <= 7)
        {
            newlyadded = "<span class='newly'>newly added</span>";
        }
        else
        {
            newlyadded = "";
        }

        return newlyadded;
    }
    public string getFurnished(string furnished)
    {
        string strFurnished = "";

        if (furnished == "True")
        {
            strFurnished = "<span class=furnished>Furnished</span>";
        }
        else
        {
            strFurnished = "";
        }


        return strFurnished;
    }

    public string getagentsoldlink(string aid)
    {
        SqlConnection connection2 = new SqlConnection(connectionString);
        connection2.Open();
        SqlCommand command = new SqlCommand("spGetPropertiesCount", connection2);
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.Add(new SqlParameter("@isWebdisplay", "Any"));
        command.Parameters.Add(new SqlParameter("@aID1", aid));
        command.Parameters.Add(new SqlParameter("@status", "('Sold')"));
        SqlDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
            if (!reader.IsDBNull(reader.GetOrdinal("count")))
            {
                agentsoldcount = reader.GetInt32(reader.GetOrdinal("count"));
            }
        }
        connection2.Close();
        string link = "";
        if (agentsoldcount > 0)
        {
            link = "<a href=agent.aspx?aid=" + aid + "&st=so>view sales</a>";
        }
        return link;
    }

    public string getagentlistinglink(string aid)
    {
        SqlConnection connection2 = new SqlConnection(connectionString);
        connection2.Open();
        SqlCommand command = new SqlCommand("spGetPropertiesCount", connection2);
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.Add(new SqlParameter("@isWebdisplay", "1"));
        command.Parameters.Add(new SqlParameter("@aID1", aid));
        SqlDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
            if (!reader.IsDBNull(reader.GetOrdinal("count")))
            {
                agentspropcount = reader.GetInt32(reader.GetOrdinal("count"));
            }
        }
        connection2.Close();
        string link = "";
        if (agentspropcount > 0)
        {
            link = "<a href=agent.aspx?aid=" + aid + ">>> more</a>";
        }
        return link;
    }


    public string getAgentProperty(string aid)
    {
        string sql = "SELECT * FROM tblProperty WHERE isWebDisplay = 1 AND (aID1 in " + convertListToSQL(aid) + " or aID2 in " + convertListToSQL(aid) + ") and numPhotoMore > 2 order by pid";
        string pid = "";
        connection.Open();
        SqlCommand command = new SqlCommand(sql, connection);
        command.CommandType = CommandType.Text;
        SqlDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
            if (!reader.IsDBNull(reader.GetOrdinal("pid")))
            {
                pid = reader.GetInt32(reader.GetOrdinal("pid")).ToString();
            }
        }
        connection.Close();
        return pid;
    }

    public string getAgentFeatureProperty(string aid, int featurepid)
    {
        string Fpid = "";
        if (featurepid > 0)
        {
            Fpid = featurepid.ToString();
        }
        else
        {
            connection.Open();
            SqlCommand command = new SqlCommand("spGetProperties", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@isWebdisplay", "1"));
            command.Parameters.Add(new SqlParameter("@aID1", aid));
            command.Parameters.Add(new SqlParameter("@hasPhotoSmall", 1));
            SqlDataReader reader = command.ExecuteReader();

            DataSet Items = new DataSet();
            Items = convertDataReaderToDataSet(reader);

            int NoOfProp = Items.Tables[0].Rows.Count;

            Random RandomClass = new Random();
            int rndNo = RandomClass.Next(NoOfProp);

            if (NoOfProp > 0)
                Fpid = Items.Tables[0].Rows[rndNo]["pid"].ToString();

            connection.Close();
        }


        return Fpid;
    }

    public SqlDataReader getAgentProperties(string aid)
    {
        connection.Open();
        SqlCommand command = new SqlCommand("spGetAgentProperties_ahc", connection);
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.Add(new SqlParameter("@aID", aid));
        SqlDataReader reader = command.ExecuteReader();
        return reader;
    }

    public DataTable getAgentRandomProperty(string aid, string strIswebDisplay, string strStatus)
    {

        SqlCommand command = new SqlCommand("spGetRandomAgentProperties", connection);
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.Add(new SqlParameter("@aID", aid));
        command.Parameters.Add(new SqlParameter("@isWebDisplay", strIswebDisplay));
        command.Parameters.Add(new SqlParameter("@status", strStatus));

        SqlDataAdapter objAdapter = new SqlDataAdapter();
        objAdapter.SelectCommand = command;
        DataSet objDS = new DataSet();
        DataTable objDT = new DataTable();
        objAdapter.Fill(objDS, "Searchsave");
        objDT = objDS.Tables["Searchsave"];
        return objDT;
    }

    public DataTable GetSuburbsByStatus(string status, string type, string state)
    {
        SqlCommand command = new SqlCommand("spGetSuburbsByStatus", connection);
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.Add(new SqlParameter("@status", status));
        command.Parameters.Add(new SqlParameter("@type", type));
        command.Parameters.Add(new SqlParameter("@state", state));

        SqlDataAdapter objAdapter = new SqlDataAdapter();
        objAdapter.SelectCommand = command;
        DataSet objDS = new DataSet();
        DataTable objDT = new DataTable();
        objAdapter.Fill(objDS, "distinctsuburb");
        objDT = objDS.Tables["distinctsuburb"];
        return objDT;
    }
    public string GetRegionByMaparea(string maparea)
    {
        string strregionlist = "";

        SqlCommand command = new SqlCommand("spgetRegionByMaparea", connection);
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.Add(new SqlParameter("@maparea", maparea));

        SqlDataAdapter objAdapter = new SqlDataAdapter();
        objAdapter.SelectCommand = command;
        DataSet objDS = new DataSet();
        DataTable objDT = new DataTable();
        objAdapter.Fill(objDS, "distinctRegion");
        objDT = objDS.Tables["distinctRegion"];

        for (int i = 0; i < objDT.Rows.Count; i++)
        {
            strregionlist += objDT.Rows[i]["region"].ToString() + ",";
        }

        if (strregionlist.Contains(","))
            strregionlist = strregionlist.Substring(0, strregionlist.Length - 1);

        return strregionlist;

    }
    public DataTable GetSuburbsByStatusAndregion(string status, string type, string state, string region)
    {
        SqlCommand command = new SqlCommand("spGetSuburbsByStatusWithPostcode", connection);
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.Add(new SqlParameter("@status", status));
        command.Parameters.Add(new SqlParameter("@type", type));
        command.Parameters.Add(new SqlParameter("@state", state));
        command.Parameters.Add(new SqlParameter("@region", region));

        SqlDataAdapter objAdapter = new SqlDataAdapter();
        objAdapter.SelectCommand = command;
        DataSet objDS = new DataSet();
        DataTable objDT = new DataTable();
        objAdapter.Fill(objDS, "distinctsuburb");
        objDT = objDS.Tables["distinctsuburb"];
        return objDT;
    }
    public DataTable GetSuburbsByStatusAndregion(string status, string type, string state, string region, string keyword)
    {
        SqlCommand command = new SqlCommand("spGetSuburbsByStatusWithPostcode", connection);
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.Add(new SqlParameter("@status", status));
        command.Parameters.Add(new SqlParameter("@type", type));
        command.Parameters.Add(new SqlParameter("@state", state));
        command.Parameters.Add(new SqlParameter("@region", region));
        command.Parameters.Add(new SqlParameter("@keyword", keyword));
        SqlDataAdapter objAdapter = new SqlDataAdapter();
        objAdapter.SelectCommand = command;
        DataSet objDS = new DataSet();
        DataTable objDT = new DataTable();
        objAdapter.Fill(objDS, "distinctsuburb");
        objDT = objDS.Tables["distinctsuburb"];
        return objDT;
    }
    public DataTable GetSuburbsByStatusAndMaparea(string status, string type, string state, string maparea)
    {
        SqlCommand command = new SqlCommand("spGetSuburbsByStatusWithPostcode", connection);
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.Add(new SqlParameter("@status", status));
        command.Parameters.Add(new SqlParameter("@type", type));
        command.Parameters.Add(new SqlParameter("@state", state));
        command.Parameters.Add(new SqlParameter("@maparea", maparea));

        SqlDataAdapter objAdapter = new SqlDataAdapter();
        objAdapter.SelectCommand = command;
        DataSet objDS = new DataSet();
        DataTable objDT = new DataTable();
        objAdapter.Fill(objDS, "distinctsuburb");
        objDT = objDS.Tables["distinctsuburb"];
        return objDT;
    }
    public DataTable GetSuburbsByStatusAndMaparea(string status, string type, string state, string maparea, string keyword)
    {
        SqlCommand command = new SqlCommand("spGetSuburbsByStatusWithPostcode", connection);
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.Add(new SqlParameter("@status", status));
        command.Parameters.Add(new SqlParameter("@type", type));
        command.Parameters.Add(new SqlParameter("@state", state));
        command.Parameters.Add(new SqlParameter("@maparea", maparea));
        command.Parameters.Add(new SqlParameter("@keyword", keyword));
        SqlDataAdapter objAdapter = new SqlDataAdapter();
        objAdapter.SelectCommand = command;
        DataSet objDS = new DataSet();
        DataTable objDT = new DataTable();
        objAdapter.Fill(objDS, "distinctsuburb");
        objDT = objDS.Tables["distinctsuburb"];
        return objDT;
    }
    public DataTable GetAgenciesByStatus(string status, string type, string state, string maparea, string region)
    {
        SqlCommand command = new SqlCommand("spGetAgenciesByStatus", connection);
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.Add(new SqlParameter("@status", status));
        command.Parameters.Add(new SqlParameter("@type", type));
        command.Parameters.Add(new SqlParameter("@state", state));
        command.Parameters.Add(new SqlParameter("@maparea", maparea));
        command.Parameters.Add(new SqlParameter("@region", region));

        SqlDataAdapter objAdapter = new SqlDataAdapter();
        objAdapter.SelectCommand = command;
        DataSet objDS = new DataSet();
        DataTable objDT = new DataTable();
        objAdapter.Fill(objDS, "distinctAgency");
        objDT = objDS.Tables["distinctAgency"];
        return objDT;
    }


    public int getAgentPropertiesCount(string aid)
    {
        int count = 0;
        connection.Open();
        SqlCommand command = new SqlCommand("spGetPropertiesCount", connection);
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.Add(new SqlParameter("@isWebdisplay", "1"));
        command.Parameters.Add(new SqlParameter("@aID1", aid));
        command.Parameters.Add(new SqlParameter("@orderby", "suburb,pricelow desc"));
        SqlDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
            if (!reader.IsDBNull(reader.GetOrdinal("count")))
            {
                count = reader.GetInt32(reader.GetOrdinal("count"));
            }
        }
        connection.Close();
        return count;
    }

    public SqlDataReader getAgentSoldProperties(string aid)
    {
        connection.Open();
        SqlCommand command = new SqlCommand("spGetProperties", connection);
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.Add(new SqlParameter("@isWebdisplay", "Any"));
        command.Parameters.Add(new SqlParameter("@status", "('Sold')"));
        command.Parameters.Add(new SqlParameter("@aID1", aid));
        command.Parameters.Add(new SqlParameter("@orderby", "dateupdated desc"));
        SqlDataReader reader = command.ExecuteReader();
        return reader;
    }


    /********************** suburb ads ***************************************/
    public string getAgentSuburb(string suburb)
    {
        string strAgentSuburb = "";
        string strTempSuburb = "";
        if (!String.IsNullOrEmpty(suburb))
        {
            if (suburb.IndexOf(",") > 0)
            {
                strTempSuburb = suburb.Substring(0, suburb.IndexOf(","));
                //strTempSuburb = strTempSuburb.Substring(0, strTempSuburb.Length - 1);
                strTempSuburb = strTempSuburb.Trim();
            }
            else
            {
                strTempSuburb = suburb.Trim();
            }
            strAgentSuburb = strTempSuburb;
        }
        else
        {
            strAgentSuburb = "";

        }

        return strTempSuburb;
    }

    public SqlDataReader getAIDForSuburbs(string agentSuburb, string agentNo)
    {
        connection.Close();
        connection.Open();
        SqlCommand command = new SqlCommand("spGetAIDForSuburbs", connection);
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.Add(new SqlParameter("@suburb", convertListToSQL(agentSuburb)));
        command.Parameters.Add(new SqlParameter("@type", agentNo));
        SqlDataReader reader = command.ExecuteReader();
        return reader;
    }

    public SqlDataReader InsertAgentViewCounter(string aid, string agentSuburb)
    {
        connection.Close();
        connection.Open();
        SqlCommand command = new SqlCommand("spInsertAgentViewCounter", connection);
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.Add(new SqlParameter("@aid", aid));
        command.Parameters.Add(new SqlParameter("@suburb", agentSuburb));
        SqlDataReader reader = command.ExecuteReader();
        return reader;
    }



    /********************** suburb ads ***************************************/


    /********************** Development ***************************************/
    public string getsearchimageurlBuilding(string bid, string name, string width, string height)
    {
        string imgurl = "";
        /*address = address.Replace("'", "");
        address = address.Replace("<BR>", ",");
        price = price.Replace("</font>", "");
        price = price.Replace("<font color=red>", "");*/

        if (!String.IsNullOrEmpty(bid))
        {
            imgurl = "<img src=" + ConfigurationManager.AppSettings["imageurl"].ToString() + "resize.ashx?width=" + width + "&height=" + height + "&path=images/buildings/" + bid + "/" + bid + "_lg.jpg title='" + name + "' border=0 class=propertyimg />";
        }
        return imgurl;
    }
    public SqlDataReader getBuildings(string state, string strType, string strregion)
    {
        connection.Open();
        SqlCommand command = new SqlCommand("spGetBuildings", connection);
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.Add(new SqlParameter("@state", state));
        command.Parameters.Add(new SqlParameter("@type", strType));
        command.Parameters.Add(new SqlParameter("@region", strregion));
        SqlDataReader reader = command.ExecuteReader();
        return reader;
    }

    public SqlDataReader getBuildingProperties(string strBID, string orderby)
    {

        connection.Open();
        SqlCommand command = new SqlCommand("spGetBuldingProperties", connection);
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.Add(new SqlParameter("@bID", strBID));
        command.Parameters.Add(new SqlParameter("@isWebDisplay", "Any"));
        command.Parameters.Add(new SqlParameter("@orderby", orderby));
        SqlDataReader reader = command.ExecuteReader();
        return reader;
    }

    public string getBuildingsCount(string strBID)
    {

        string strStatus = "";
        string strDetails = "";
        int forsale = 0;
        int sold = 0;
        int underoffer = 0;

        connection.Close();
        connection.Open();
        SqlCommand command = new SqlCommand("spGetBuildingProperties", connection);
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.Add(new SqlParameter("@bID", strBID));
        SqlDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
            strStatus = "";
            if (!reader.IsDBNull(reader.GetOrdinal("status")))
            {
                strStatus = reader.GetString(reader.GetOrdinal("status"));
            }
            if (strStatus.ToLower() == "for sale")
            {
                forsale = forsale + 1;
            }
            if (strStatus.ToLower() == "sold")
            {
                sold = sold + 1;
            }
            if (strStatus.ToLower() == "under offer")
            {
                underoffer = underoffer + 1;
            }
        }
        if (forsale > 0 || sold > 0 || underoffer > 0)
        {
            strDetails = "<table><tr>";


            if (forsale > 0)
            {
                strDetails = strDetails + "<td><b>" + forsale + "</b>&nbsp;<img align=absmiddle src=" + ConfigurationManager.AppSettings["webUrl"].ToString() + "images/ahc/web/sale-s.jpg>&nbsp;&nbsp;&nbsp;</td>";
            }
            if (underoffer > 0)
            {
                strDetails = strDetails + "<td><b>" + underoffer + "</b>&nbsp;<img align=absmiddle src=" + ConfigurationManager.AppSettings["webUrl"].ToString() + "images/ahc/web/under-s.jpg>&nbsp;&nbsp;&nbsp;</td>";
            }
            if (sold > 0)
            {
                strDetails = strDetails + "<td><b>" + sold + "</b>&nbsp;<img align=absmiddle src=" + ConfigurationManager.AppSettings["webUrl"].ToString() + "images/ahc/web/sold-s.jpg>&nbsp;&nbsp;&nbsp;</td>";
            }
            strDetails = strDetails + "</tr></table>";

        }

        return strDetails;
    }



    public void getBuilding(string strBID)
    {

        connection.Open();
        SqlCommand command = new SqlCommand("spGetBuilding", connection);
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.Add(new SqlParameter("@bID", strBID));
        SqlDataReader reader = command.ExecuteReader();
        bid = strBID;
        while (reader.Read())
        {

            if (!reader.IsDBNull(reader.GetOrdinal("acid")))
            {
                bacid = reader.GetValue(reader.GetOrdinal("acid")).ToString();
            }
            if (!reader.IsDBNull(reader.GetOrdinal("pID")))
            {
                Bpid = reader.GetValue(reader.GetOrdinal("pID")).ToString();
            }
            if (!reader.IsDBNull(reader.GetOrdinal("name")))
            {
                BName = reader.GetString(reader.GetOrdinal("name"));
            }
            if (!reader.IsDBNull(reader.GetOrdinal("rdNum")))
            {
                BRoadNum = reader.GetString(reader.GetOrdinal("rdNum"));
            }
            if (!reader.IsDBNull(reader.GetOrdinal("rdName")))
            {
                BRoadName = reader.GetString(reader.GetOrdinal("rdName"));
            }
            if (!reader.IsDBNull(reader.GetOrdinal("rdType")))
            {
                BRoadType = reader.GetString(reader.GetOrdinal("rdType"));
            }
            if (!reader.IsDBNull(reader.GetOrdinal("suburb")))
            {
                BSuburb = reader.GetString(reader.GetOrdinal("suburb"));
            }
            if (!reader.IsDBNull(reader.GetOrdinal("postcode")))
            {
                BPostcode = reader.GetString(reader.GetOrdinal("postcode"));
            }
            if (!reader.IsDBNull(reader.GetOrdinal("type")))
            {
                BType = reader.GetString(reader.GetOrdinal("type"));
            }

            if (!reader.IsDBNull(reader.GetOrdinal("state")))
            {
                BState = reader.GetString(reader.GetOrdinal("state"));
            }
            if (!reader.IsDBNull(reader.GetOrdinal("hasPhotoLarge")))
            {
                Bhasphotolarge = reader.GetBoolean(reader.GetOrdinal("hasPhotoLarge"));
            }

            if (!reader.IsDBNull(reader.GetOrdinal("haslogo")))
            {
                blhaslogo = reader.GetBoolean(reader.GetOrdinal("haslogo"));
            }



            if (!reader.IsDBNull(reader.GetOrdinal("numPhotoMore")))
            {
                BnumPhotoMore = int.Parse(reader.GetValue(reader.GetOrdinal("numPhotoMore")).ToString());
            }
            if (!reader.IsDBNull(reader.GetOrdinal("numFloorPlan")))
            {
                BnumFloorPlan = int.Parse(reader.GetValue(reader.GetOrdinal("numFloorPlan")).ToString());
            }

            if (!reader.IsDBNull(reader.GetOrdinal("descriptionShort")))
            {
                Bdescriptionshort = reader.GetString(reader.GetOrdinal("descriptionShort"));
            }
            if (!reader.IsDBNull(reader.GetOrdinal("featuresUnit")))
            {
                BFeaturesUnit = reader.GetString(reader.GetOrdinal("featuresUnit"));
            }

            if (!reader.IsDBNull(reader.GetOrdinal("featuresBuilding")))
            {
                BFeaturesBuilding = reader.GetString(reader.GetOrdinal("featuresBuilding"));
            }
            if (!reader.IsDBNull(reader.GetOrdinal("descriptionLong")))
            {
                Bdescriptionlong = reader.GetString(reader.GetOrdinal("descriptionLong"));
                // Bdescriptionlong = Bdescriptionlong.Replace(Environment.NewLine, "<BR>");
            }
            if (!reader.IsDBNull(reader.GetOrdinal("priceLow")))
            {
                BstrPriceLow = reader.GetDecimal(reader.GetOrdinal("priceLow"));
            }
            if (!reader.IsDBNull(reader.GetOrdinal("priceHigh")))
            {
                BstrPriceHigh = reader.GetDecimal(reader.GetOrdinal("priceHigh"));
            }

        }
        Bprice = getPrice("Range", BstrPriceLow.ToString(), BstrPriceHigh.ToString(), "For Sale", null, "false", null, null);
        //Baddress = getAddress(BName, BUnitNum, BRoadNum, BRoadName, BRoadType, BSuburb, BblHideRoadName, BblHideRoadNum);
        Baddress = BRoadNum + " " + BRoadName + " " + BRoadType + ", " + BSuburb;
    }

    public string getRolloverScriptBuilding()
    {
        string rollover = "";
        rollover = rollover + "<script language=javascript>";
        rollover = rollover + "numSeconds = 2500;";
        rollover = rollover + "numCurrentImg = 1;";
        rollover = rollover + "numPhotos = " + Convert.ToString(BnumPhotoMore + 1) + ";";
        rollover = rollover + "timer = null;var imgPhoto1 = new Image();";
        rollover = rollover + "imgPhoto1.src = '" + ConfigurationManager.AppSettings["imageurl"].ToString() + "resizeheight.ashx?width=800&height=600&path=/images/buildings/" + bid + "/" + bid + "_LG.jpg';";
        int counter = 1;
        int varcounter = 2;
        do
        {
            rollover = rollover + "var imgPhoto" + varcounter + " = new Image();";
            rollover = rollover + "imgPhoto" + varcounter + ".src = '" + ConfigurationManager.AppSettings["imageurl"].ToString() + "resizeheight.ashx?width=800&height=600&path=/images/buildings/" + bid + "/" + bid + "_MP" + counter + ".jpg';";
            counter = counter + 1;
            varcounter = varcounter + 1;
        } while (counter <= BnumPhotoMore);
        rollover = rollover + "function swapImg( numNewImg ) {";
        rollover = rollover + "stopShow();";
        rollover = rollover + "eval('document.imgMain.src = imgPhoto' + numNewImg + '.src');";
        rollover = rollover + "if (document.getElementById('imgLabel'))";
        rollover = rollover + "document.getElementById('imgLabel').innerHTML = numNewImg;";
        rollover = rollover + "numCurrentImg = numNewImg;";
        rollover = rollover + "}";

        rollover = rollover + "function startShow() {if (timer == null)swapTimeout();}";
        rollover = rollover + "function stopShow() {if (timer != null){window.clearTimeout(timer);timer = null;}}";
        rollover = rollover + "function toggleShow() {if (timer == null) {startShow();	} else {stopShow();}}";

        rollover = rollover + "function nextImg() {";
        rollover = rollover + "numNewImg = numCurrentImg+1;";
        rollover = rollover + "if (numNewImg > numPhotos)";
        rollover = rollover + "numNewImg = 1;";
        rollover = rollover + "eval('document.imgMain.src = imgPhoto' + numNewImg + '.src');";
        rollover = rollover + "if (document.getElementById('imgLabel'))";
        rollover = rollover + "document.getElementById('imgLabel').innerHTML = numNewImg;";
        rollover = rollover + "numCurrentImg = numNewImg;";
        rollover = rollover + "}";

        rollover = rollover + "function prevImg() {";
        rollover = rollover + "numNewImg = numCurrentImg-1;";
        rollover = rollover + "if (numNewImg < 1)";
        rollover = rollover + "numNewImg = numPhotos;";
        rollover = rollover + "eval('document.imgMain.src = imgPhoto' + numNewImg + '.src');";
        rollover = rollover + "if (document.getElementById('imgLabel'))";
        rollover = rollover + "document.getElementById('imgLabel').innerHTML = numNewImg;";
        rollover = rollover + "numCurrentImg = numNewImg;";
        rollover = rollover + "}";
        rollover = rollover + "function swapTimeout() {	if ( numCurrentImg == numPhotos ) {	numCurrentImg = 1;	} else {numCurrentImg++;}swapImg(numCurrentImg);timer = window.setTimeout(swapTimeout, numSeconds);}";
        rollover = rollover + "</script>";
        return rollover;
    }


    /********************** Development ***************************************/



    public string getRolloverScript()
    {
        string rollover = "";
        rollover = rollover + "<script language=javascript>";
        rollover = rollover + "numSeconds = 2500;";
        rollover = rollover + "numCurrentImg = 1;";
        rollover = rollover + "numPhotos = " + (numPhotoMore + 1).ToString() + ";";
        rollover = rollover + "timer = null;var imgPhoto1 = new Image();";
        rollover = rollover + "imgPhoto1.src = '" + ConfigurationManager.AppSettings["imageurl"].ToString() + "resizeheight.ashx?width=800&height=600&path=/images/properties/" + pid + "/" + pid + "_LG.jpg';";
        int counter = 1;
        int varcounter = 2;
        do
        {
            rollover = rollover + "var imgPhoto" + varcounter + " = new Image();";
            rollover = rollover + "imgPhoto" + varcounter + ".src = '" + ConfigurationManager.AppSettings["imageurl"].ToString() + "resizeheight.ashx?width=800&height=600&path=/images/properties/" + pid + "/" + pid + "_MP" + counter + ".jpg';";
            counter = counter + 1;
            varcounter = varcounter + 1;
        } while (counter <= numPhotoMore + 1);
        rollover = rollover + "function swapImg( numNewImg ) {";
        rollover = rollover + "stopShow();";
        rollover = rollover + "eval('document.imgMain.src = imgPhoto' + numNewImg + '.src');";
        rollover = rollover + "if (document.getElementById('imgLabel'))";
        rollover = rollover + "document.getElementById('imgLabel').innerHTML = numNewImg;";
        rollover = rollover + "numCurrentImg = numNewImg;";
        rollover = rollover + "}";

        rollover = rollover + "function startShow() {if (timer == null)swapTimeout();}";
        rollover = rollover + "function stopShow() {if (timer != null){window.clearTimeout(timer);timer = null;}}";
        rollover = rollover + "function toggleShow() {if (timer == null) {startShow();	} else {stopShow();}}";

        rollover = rollover + "function nextImg() {";
        rollover = rollover + "numNewImg = numCurrentImg+1;";
        rollover = rollover + "if (numNewImg > numPhotos)";
        rollover = rollover + "numNewImg = 1;";
        rollover = rollover + "eval('document.imgMain.src = imgPhoto' + numNewImg + '.src');";
        rollover = rollover + "if (document.getElementById('imgLabel'))";
        rollover = rollover + "document.getElementById('imgLabel').innerHTML = numNewImg;";
        rollover = rollover + "numCurrentImg = numNewImg;";
        rollover = rollover + "}";

        rollover = rollover + "function prevImg() {";
        rollover = rollover + "numNewImg = numCurrentImg-1;";
        rollover = rollover + "if (numNewImg < 1)";
        rollover = rollover + "numNewImg = numPhotos;";
        rollover = rollover + "eval('document.imgMain.src = imgPhoto' + numNewImg + '.src');";
        rollover = rollover + "if (document.getElementById('imgLabel'))";
        rollover = rollover + "document.getElementById('imgLabel').innerHTML = numNewImg;";
        rollover = rollover + "numCurrentImg = numNewImg;";
        rollover = rollover + "}";
        rollover = rollover + "function swapTimeout() {	if ( numCurrentImg == numPhotos ) {	numCurrentImg = 1;	} else {numCurrentImg++;}swapImg(numCurrentImg);timer = window.setTimeout(swapTimeout, numSeconds);}";
        rollover = rollover + "</script>";
        return rollover;
    }

    public string getRolloverSuburb()
    {
        string rollover = "";
        rollover = rollover + "<script language=javascript>";
        rollover = rollover + "numSeconds = 2500;";
        rollover = rollover + "numCurrentImg = 1;";
        rollover = rollover + "numPhotos = " + suburbphotos.ToString() + ";";
        rollover = rollover + "timer = null;var imgPhoto1 = new Image();";
        rollover = rollover + "imgPhoto1.src = '" + ConfigurationManager.AppSettings["imageurl"].ToString() + "resizeheight.ashx?width=800&height=600&path=images/suburbs/" + suburbsid + "/IMG1.jpg';";
        rollover = rollover + "var Label = new Array();";
        rollover = rollover + "Label[0]='" + getSuburbPhotoLabel(1, suburbsid).ToString().Replace("'", "&quot;") + "';";
        int varcounterX = 1;
        do
        {
            rollover = rollover + "Label[" + varcounterX + "]='" + getSuburbPhotoLabel((varcounterX + 1), suburbsid).ToString().Replace("'", "&quot;") + "';";
            varcounterX = varcounterX + 1;
        } while (varcounterX < suburbphotos);

        int varcounter = 2;
        do
        {
            rollover = rollover + "var imgPhoto" + varcounter + " = new Image();";
            rollover = rollover + "imgPhoto" + varcounter + ".src = '" + ConfigurationManager.AppSettings["imageurl"].ToString() + "resizeheight.ashx?width=800&height=600&path=images/suburbs/" + suburbsid + "/IMG" + varcounter + ".jpg';";
            varcounter = varcounter + 1;
        } while (varcounter <= suburbphotos);

        rollover = rollover + "function swapImg( numNewImg ) {";
        rollover = rollover + "stopShow();";
        rollover = rollover + "eval('document.imgMain.src = imgPhoto' + numNewImg + '.src');";
        rollover = rollover + "if (document.getElementById('imgLabel'))";
        rollover = rollover + "document.getElementById('imgLabel').innerHTML = Label[numNewImg-1];";
        rollover = rollover + "numCurrentImg = numNewImg;";
        rollover = rollover + "}";

        rollover = rollover + "function startShow() {if (timer == null)swapTimeout();}";
        rollover = rollover + "function stopShow() {if (timer != null){window.clearTimeout(timer);timer = null;}}";
        rollover = rollover + "function toggleShow() {if (timer == null) {startShow();	} else {stopShow();}}";

        rollover = rollover + "function nextImg() {";
        rollover = rollover + "numNewImg = numCurrentImg+1;";
        rollover = rollover + "if (numNewImg > numPhotos)";
        rollover = rollover + "numNewImg = 1;";
        rollover = rollover + "eval('document.imgMain.src = imgPhoto' + numNewImg + '.src');";
        rollover = rollover + "if (document.getElementById('imgLabel'))";
        rollover = rollover + "document.getElementById('imgLabel').innerHTML = Label[numNewImg-1];";
        rollover = rollover + "numCurrentImg = numNewImg;";
        rollover = rollover + "}";

        rollover = rollover + "function prevImg() {";
        rollover = rollover + "numNewImg = numCurrentImg-1;";
        rollover = rollover + "if (numNewImg < 1)";
        rollover = rollover + "numNewImg = numPhotos;";
        rollover = rollover + "eval('document.imgMain.src = imgPhoto' + numNewImg + '.src');";
        rollover = rollover + "if (document.getElementById('imgLabel'))";
        rollover = rollover + "document.getElementById('imgLabel').innerHTML = Label[numNewImg-1];";
        rollover = rollover + "numCurrentImg = numNewImg;";
        rollover = rollover + "}";
        rollover = rollover + "function swapTimeout() {	if ( numCurrentImg == numPhotos ) {	numCurrentImg = 1;	} else {numCurrentImg++;}swapImg(numCurrentImg);timer = window.setTimeout(swapTimeout, numSeconds);}";
        rollover = rollover + "</script>";
        return rollover;
    }
    public DataTable getSuburbbyname(string name)
    {
        SqlCommand command = new SqlCommand("spGetSuburb", connection);
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.Add(new SqlParameter("@name", name));
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = command;
        DataTable dt = new DataTable();
        da.Fill(dt);

        return dt;
    }
    public DataTable SelectSuburbBySynonymousName(string name)
    {
        SqlCommand command = new SqlCommand("spSelectSuburbBySynonymousName", connection);
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.Add(new SqlParameter("@suburb", name));
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = command;
        DataTable dt = new DataTable();
        da.Fill(dt);

        return dt;
    }
    public DataTable getSuburbbypostcode(string postcode)
    {
        SqlCommand command = new SqlCommand("spGetSuburb", connection);
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.Add(new SqlParameter("@postcode", postcode));
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = command;
        DataTable dt = new DataTable();
        da.Fill(dt);

        return dt;
    }
    public DataTable getSuburbbynamepostcode(string name, string postcode)
    {
        SqlCommand command = new SqlCommand("spGetSuburb", connection);
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.Add(new SqlParameter("@name", name));
        command.Parameters.Add(new SqlParameter("@postcode", postcode));
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = command;
        DataTable dt = new DataTable();
        da.Fill(dt);

        return dt;
    }
    public DataTable getRegionbyName(string name)
    {
        SqlCommand command = new SqlCommand("spgetRegionbyName", connection);
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.Add(new SqlParameter("@region", name));

        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = command;
        DataTable dt = new DataTable();
        da.Fill(dt);

        return dt;
    }

    public void getSuburb(string name)
    {
        connection.Open();
        SqlCommand command = new SqlCommand("spGetSuburb", connection);
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.Add(new SqlParameter("@name", name));
        SqlDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
            if (!reader.IsDBNull(reader.GetOrdinal("numPhotos")))
            {
                suburbphotos = int.Parse(reader.GetValue(reader.GetOrdinal("numPhotos")).ToString());
            }
            if (!reader.IsDBNull(reader.GetOrdinal("descriptionLong")))
            {
                suburbdescription = reader.GetString(reader.GetOrdinal("descriptionLong")).ToString();
                suburbdescription = suburbdescription.Replace(Environment.NewLine, "<BR>");
                suburbdescription = suburbdescription.Replace("&lt;br&gt;", "");
                suburbdescription = suburbdescription.Replace("&lt;BR&gt;", "<BR>");
            }
            else
            { suburbdescription = ""; }
            if (!reader.IsDBNull(reader.GetOrdinal("sID")))
            {
                suburbsid = int.Parse(reader.GetValue(reader.GetOrdinal("sID")).ToString());
            }
            if (!reader.IsDBNull(reader.GetOrdinal("Region")))
            {
                strRegion = reader.GetString(reader.GetOrdinal("Region"));
            }



        }
        connection.Close();
        if (!String.IsNullOrEmpty(strSuburb))
        {
            if ((strSuburb.Equals("Cottesloe")) || (strSuburb.Equals("City Beach")) || (strSuburb.Equals("Nedlands")) || (strSuburb.Equals("South Perth")) || (strSuburb.Equals("Nedlands")) || (strSuburb.Equals("Subiaco")) || (strSuburb.Equals("Applecross")) || (strSuburb.Equals("Scarborough")) || (strSuburb.Equals("Peppermint Grove")) || (strSuburb.Equals("Claremont")) || (strSuburb.Equals("Fremantle")) || (strSuburb.Equals("Mount Lawley")))
            {
                blLifestyle = true;
            }
        }
    }
    public void getSuburbBySID(string SID)
    {
        connection.Open();
        SqlCommand command = new SqlCommand("spGetSuburb", connection);
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.Add(new SqlParameter("@sID", SID));
        SqlDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
            if (!reader.IsDBNull(reader.GetOrdinal("numPhotos")))
            {
                suburbphotos = int.Parse(reader.GetValue(reader.GetOrdinal("numPhotos")).ToString());
            }
            if (!reader.IsDBNull(reader.GetOrdinal("descriptionLong")))
            {
                suburbdescription = reader.GetString(reader.GetOrdinal("descriptionLong"));
                suburbdescription = suburbdescription.Replace(Environment.NewLine, "<BR>");
                suburbdescription = suburbdescription.Replace("&lt;br&gt;", "");
            }

            if (!reader.IsDBNull(reader.GetOrdinal("sID")))
            {
                suburbsid = int.Parse(reader.GetValue(reader.GetOrdinal("sID")).ToString());
            }

            if (!reader.IsDBNull(reader.GetOrdinal("name")))
            {
                suburbname = reader.GetString(reader.GetOrdinal("name"));
            }

            if (!reader.IsDBNull(reader.GetOrdinal("postcode")))
            {
                postcode = reader.GetValue(reader.GetOrdinal("postcode")).ToString();
            }
        }
        connection.Close();

    }
    public string getSuburbPhotoLabel(int id, int sid)
    {
        int counter = 0;
        string lable = "";
        connection.Open();
        SqlCommand command = new SqlCommand("spGetSuburbPhotos", connection);
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.Add(new SqlParameter("@sID", sid));
        SqlDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
            counter = counter + 1;
            if (!reader.IsDBNull(reader.GetOrdinal("label")))
            {
                if (counter == id)
                {
                    lable = reader.GetValue(reader.GetOrdinal("label")).ToString();
                }
            }
        }
        connection.Close();
        return lable;
    }

    public DataTable GetSuburbsByKeyword(string status, string keyword, string state)
    {
        SqlCommand command = new SqlCommand("spGetSuburbsByStatusWithPostcodeWithKeyWord", connection);
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.Add(new SqlParameter("@status", status));
        command.Parameters.Add(new SqlParameter("@keyWord", keyword));
        command.Parameters.Add(new SqlParameter("@state", state));
        SqlDataAdapter objAdapter = new SqlDataAdapter();
        objAdapter.SelectCommand = command;
        DataSet objDS = new DataSet();
        DataTable objDT = new DataTable();
        objAdapter.Fill(objDS, "distinctsuburb");
        objDT = objDS.Tables["distinctsuburb"];
        return objDT;
    }

    public String getLatestRandomProperty(string strIswebDisplay, string strStatus, string days)
    {
        string Fpid = "";
        connection.Open();
        SqlCommand command = new SqlCommand("spGetPropertiesWithSoldnew", connection);
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.Add(new SqlParameter("@dateListed", days));
        command.Parameters.Add(new SqlParameter("@isWebDisplay", strIswebDisplay));
        command.Parameters.Add(new SqlParameter("@status", strStatus));
        SqlDataReader reader = command.ExecuteReader();

        DataSet Items = new DataSet();
        Items = convertDataReaderToDataSet(reader);

        DataView dvProp = new DataView(Items.Tables[0], "pricetext is null", "", DataViewRowState.CurrentRows);

        int NoOfProp = dvProp.Count;

        Random RandomClass = new Random();
        int rndNo = RandomClass.Next(NoOfProp);

        if (NoOfProp > 0)
            Fpid = dvProp[rndNo]["pid"].ToString();

        connection.Close();
        return Fpid;
    }
    public static DataSet convertDataReaderToDataSet(SqlDataReader reader)
    {
        DataSet dataSet = new DataSet();
        do
        {
            // Create new data table

            DataTable schemaTable = reader.GetSchemaTable();
            DataTable dataTable = new DataTable();

            if (schemaTable != null)
            {
                // A query returning records was executed

                for (int i = 0; i < schemaTable.Rows.Count; i++)
                {
                    DataRow dataRow = schemaTable.Rows[i];
                    // Create a column name that is unique in the data table
                    string columnName = (string)dataRow["ColumnName"]; //+ "<C" + i + "/>";
                    // Add the column definition to the data table
                    DataColumn column = new DataColumn(columnName, (Type)dataRow["DataType"]);
                    dataTable.Columns.Add(column);
                }

                dataSet.Tables.Add(dataTable);

                // Fill the data table we just created

                while (reader.Read())
                {
                    DataRow dataRow = dataTable.NewRow();

                    for (int i = 0; i < reader.FieldCount; i++)
                        dataRow[i] = reader.GetValue(i);

                    dataTable.Rows.Add(dataRow);
                }
            }
            else
            {
                // No records were returned

                DataColumn column = new DataColumn("RowsAffected");
                dataTable.Columns.Add(column);
                dataSet.Tables.Add(dataTable);
                DataRow dataRow = dataTable.NewRow();
                dataRow[0] = reader.RecordsAffected;
                dataTable.Rows.Add(dataRow);
            }
        }
        while (reader.NextResult());
        return dataSet;
    }
    public string GenerateURL(string agentname, string strAId)
    {

        if (String.IsNullOrEmpty(agentname.ToString()))
            agentname = "na";

        #region Generate SEO Friendly URL based on Address
        //Trim Start and End Spaces.
        agentname = agentname.Trim();

        //Trim "-" Hyphen
        agentname = agentname.Trim('-');

        agentname = agentname.ToLower();
        char[] chars = @"$%#@!*?;:~`+=()[]{}|\'<>,/^&"".".ToCharArray();
        agentname = agentname.Replace("c#", "C-Sharp");
        agentname = agentname.Replace("vb.net", "VB-Net");
        agentname = agentname.Replace("asp.net", "Asp-Net");

        //Replace . with - hyphen
        agentname = agentname.Replace(".", "-");

        //Replace Special-Characters
        for (int i = 0; i < chars.Length; i++)
        {
            string strChar = chars.GetValue(i).ToString();
            if (agentname.Contains(strChar))
            {
                agentname = agentname.Replace(strChar, string.Empty);
            }
        }

        //Replace all spaces with one "-" hyphen
        agentname = agentname.Replace(" ", "-");

        //Replace multiple "-" hyphen with single "-" hyphen.
        agentname = agentname.Replace("--", "-");
        agentname = agentname.Replace("---", "-");
        agentname = agentname.Replace("----", "-");
        agentname = agentname.Replace("-----", "-");
        agentname = agentname.Replace("----", "-");
        agentname = agentname.Replace("---", "-");
        agentname = agentname.Replace("--", "-");

        //Run the code again...
        //Trim Start and End Spaces.
        agentname = agentname.Trim();

        //Trim "-" Hyphen
        agentname = agentname.Trim('-');
        #endregion
        //Append ID at the end of SEO Friendly URL
        agentname = agentname + "/" + strAId;

        return agentname;
    }

    public int getSearchResultsCountAgency(string state, string status, string acid)
    {
        int count = 0;
        connection.Close();
        connection.Open();

        string type = "Any";

        SqlCommand command = new SqlCommand("spGetPropertiesCount_New", connection);
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.Add(new SqlParameter("@state", state));
        command.Parameters.Add(new SqlParameter("@status", status));
        command.Parameters.Add(new SqlParameter("@acid", acid));
        command.Parameters.Add(new SqlParameter("@hideAHC", "0"));
        SqlDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
            if (!reader.IsDBNull(reader.GetOrdinal("count")))
            {
                count = reader.GetInt32(reader.GetOrdinal("count"));
            }
        }

        return count;
    }
    public string getAgentDetail(string acid, string aid, string name, bool hasphoto, string phone, string mobile, string email, bool hidemobile)
    {
        //string agenturl = GenerateURL(name, aid);

        string agentDet = "<table bgcolor=\"#ecedef\" cellpadding=\"2\"  style=\"height:110px; width:180px;\">";
        agentDet += "<tr>";
        if (hasphoto == true)
        {
            agentDet += "<td valign='top' width='78' align='left'><a href=\'AgentDetails.aspx?aid=" + aid + "'><img src='" + ConfigurationManager.AppSettings["imageurl"].ToString() + "images/agency/" + acid + "/" + aid + "_PIC.jpg' alt='" + name + "' width='76'  align='left'></a></td>";
        }
        agentDet += "<td valign='top' align='left'>";
        agentDet += "<b>" + name + "</b><br />";
        if (!String.IsNullOrEmpty(mobile))
        {
            string phonetemp = phone;
            string mobiletemp = mobile;
            if (!String.IsNullOrEmpty(phonetemp))
            {
                phonetemp = phonetemp.Replace("(", "").Replace(")", "").Replace(" ", "");
                mobiletemp = mobiletemp.Replace("(", "").Replace(")", "").Replace(" ", "");
            }
            if (phonetemp != mobiletemp)
            {
                if (!hidemobile)
                {
                    agentDet += "M: " + getagentmobileformat(mobile) + "<br />";
                }
            }
        }
        if (!String.IsNullOrEmpty(phone))
        {
            agentDet += "P: " + phone.Replace("(", "").Replace(")", "") + "<br />";
        }
        if (!String.IsNullOrEmpty(email))
        {
            agentDet += "<img src='" + ConfigurationManager.AppSettings["webUrl"] + "images/i_emailagent_green.gif' align='absmiddle' /><a class='green' href='#' onClick=\"javascript:editWidget('EmailAgent.aspx?name=" + name + "&email=" + email + "','500','470'); return false;\"><strong>Email</strong></a><br>";
        }

        agentDet += "<br><a class='btnGold' href='/AgentDetails.aspx?aid=" + aid + "'>view my listings</a></td> </tr>";
        agentDet += "</table>";
        return agentDet;

    }

    public string getAgencyFormat(string acid, string name, bool haslogo, string phone, string fax, string email)
    {
        //string agenturl = GenerateURL(name, aid);

        string agencyDet = "<table bgcolor=\"#ecedef\" cellpadding=\"2\"  style=\"height:110px; width:180px;\">";
        agencyDet += "<tr>";
        if (haslogo == true)
        {
            agencyDet += "<td valign='top' width='78' align='left'><a href=\'AgencyDetails.aspx?acid=" + acid + "'><img src='" + ConfigurationManager.AppSettings["imageurl"].ToString() + "resizeheight.ashx?width=76&height=115&path=images/agency/" + acid + "/" + acid + "_logo.jpg' alt='" + name + "' width='76'  align='left'></a></td>";
        }
        else
            agencyDet += "<td valign='top' width='78' align='left'><a href=\'AgencyDetails.aspx?acid=" + acid + "'><img src='" + ConfigurationManager.AppSettings["imageurl"].ToString() + "resizeheight.ashx?width=76&height=115&path=images/Image-not-available-75.gif' alt='" + name + "' width='76'  align='left'></a></td>";
        agencyDet += "<td valign='top' align='left'>";
        agencyDet += "<b>" + name + "</b><br />";
        if (!String.IsNullOrEmpty(phone))
        {
            agencyDet += "P: " + phone.Replace("(", "").Replace(")", "") + "<br />";
        }
        if (!String.IsNullOrEmpty(fax))
        {
            agencyDet += "F: " + fax + "<br />";
        }
        if (!String.IsNullOrEmpty(email))
        {
            agencyDet += "<img src='" + ConfigurationManager.AppSettings["webUrl"] + "images/i_emailagent_green.gif' align='absmiddle' /><a class='green' href='#' onClick=\"javascript:editWidget('EmailAgent.aspx?name=" + name + "&email=" + email + "','500','470')\"><strong>Email</strong></a><br>";
        }

        agencyDet += "<br><a class='btnGold' href='/AgencyDetails.aspx?acid=" + acid + "'>view listings</a></td> </tr>";
        agencyDet += "</table>";
        return agencyDet;

    }
    public string getRolloverSuburbNew()
    {

        string rollover = "";
        rollover = rollover + "<script language=javascript>\n";
        rollover = rollover + "var j1 = 0;\n";
        rollover = rollover + "var ART1 = 0;\n";
        rollover = rollover + "var PICT_ART1 = new Array()\n";
        rollover = rollover + "var PICT_ART2 = new Array()\n";
        rollover = rollover + "var LINK_ART1 = new Array()\n";
        rollover = rollover + "var title_ART1 = new Array()\n";
        rollover = rollover + "var ADD_ART1 = new Array()\n\n";

        for (int i = 0; i < suburbphotos; i++)
        {
            rollover = rollover + "PICT_ART1[ART1]=new Image()\n";
            rollover = rollover + "PICT_ART1[ART1].src=\"" + ConfigurationManager.AppSettings["imageurl"].ToString() + "resizeheight.ashx?height=240&path=images/suburbs/" + suburbsid + "/IMG" + Convert.ToString(i + 1) + ".jpg" + "\"\n";
            rollover = rollover + "PICT_ART1[ART1].value = \"\";\n";
            rollover = rollover + "LINK_ART1[ART1] = \"\"\n";
            rollover = rollover + "title_ART1[ART1]=\"" + getSuburbPhotoLabel((i + 1), suburbsid).ToString().Replace("'", "&quot;") + "\"\n";
            rollover = rollover + "ADD_ART1[ART1] = \"\";\n";
            rollover = rollover + "PICT_ART2[ART1] = \"\"\n";
            rollover = rollover + "ART1++;\n\n";
        }


        rollover = rollover + "j1=0;\n";
        rollover = rollover + "var slideShowSpeed = 4000\n";
        rollover = rollover + "var crossFadeDuration = 40\n";
        rollover = rollover + "var t\n\n";

        rollover = rollover + "function runSlideShow()\n";
        rollover = rollover + "{  \n";
        rollover = rollover + "if(document.images.SlideShow_ART1!=null)\n";
        rollover = rollover + "{\n";

        rollover = rollover + "if (document.all)\n";
        rollover = rollover + "{\n";
        rollover = rollover + "document.images.SlideShow_ART1.style.filter=\"blendTrans(duration=5)\"\n";
        rollover = rollover + "document.images.SlideShow_ART1.style.filter=\"blendTrans(duration=crossFadeDuration)\"\n";
        rollover = rollover + "document.images.SlideShow_ART1.filters.blendTrans.Apply()   \n";


        rollover = rollover + "}   \n";
        rollover = rollover + "document.images.SlideShow_ART1.src = PICT_ART1[j1].src\n";
        rollover = rollover + "document.getElementById(\"spnAdd1\").innerHTML = title_ART1[j1] \n";


        rollover = rollover + "if (document.all)\n";
        rollover = rollover + "{\n";
        rollover = rollover + "document.images.SlideShow_ART1.filters.blendTrans.Play() 	 \n";

        rollover = rollover + "}\n";
        rollover = rollover + "}\n";
        rollover = rollover + "var b1;\n";
        rollover = rollover + "if (j1 >=ART1-1) \n";
        rollover = rollover + "{    \n";
        rollover = rollover + "j1=0\n";
        rollover = rollover + "b1 = ART1\n";
        rollover = rollover + "}\n";
        rollover = rollover + "else\n";
        rollover = rollover + "{\n";
        rollover = rollover + "j1 = j1 + 1\n";
        rollover = rollover + "b1 = j1\n";
        rollover = rollover + "}\n";

        rollover = rollover + "t = setTimeout('runSlideShow()', slideShowSpeed)    \n";

        rollover = rollover + "}\n\n";

        rollover = rollover + "function StartSlide() \n";
        rollover = rollover + "{\n";
        rollover = rollover + "runSlideShow();\n";
        rollover = rollover + "}\n";


        rollover = rollover + "function StopSlide()\n";
        rollover = rollover + "{\n";
        rollover = rollover + "if (t != null){\n";
        rollover = rollover + "window.clearTimeout(t);\n";
        rollover = rollover + "t = null;				\n";
        rollover = rollover + "}\n";

        rollover = rollover + "}\n";

        rollover = rollover + "function NextSlide()\n";
        rollover = rollover + "{\n";
        rollover = rollover + "StopSlide();\n";
        rollover = rollover + "j1=j1+1\n";
        rollover = rollover + "var b1;\n";

        rollover = rollover + "if (j1 >ART1-1) \n";
        rollover = rollover + "{      \n";
        rollover = rollover + "j1=0\n";
        rollover = rollover + "}\n";
        rollover = rollover + "document.images.SlideShow_ART1.src = PICT_ART1[j1].src \n";
        rollover = rollover + "document.getElementById(\"spnAdd1\").innerHTML = title_ART1[j1] \n";

        rollover = rollover + "b1 = j1*1 + 1;\n";
        rollover = rollover + "}\n";
        rollover = rollover + "function PreviousSlide()\n";
        rollover = rollover + "{\n";
        rollover = rollover + "StopSlide();\n";
        rollover = rollover + "var b1;\n";

        rollover = rollover + "j1=j1-1\n";

        rollover = rollover + "if (j1 <0) \n";
        rollover = rollover + "{      \n";
        rollover = rollover + "j1=ART1-1\n";
        rollover = rollover + "}\n";
        rollover = rollover + "document.images.SlideShow_ART1.src = PICT_ART1[j1].src \n";
        rollover = rollover + "document.getElementById(\"spnAdd1\").innerHTML = title_ART1[j1] \n";


        rollover = rollover + "b1 = j1*1 + 1;\n";



        rollover = rollover + "}\n";



        rollover = rollover + "</Script>\n";

        return rollover;
    }
    public string getemailbox(string body)
    {
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.Append("<html>");
        sb.Append("<head>");
        sb.Append("<link rel='stylesheet' type='text/css' href='" + ConfigurationManager.AppSettings["webUrl"].ToString() + "default.css' />");
        sb.Append("<base href='" + ConfigurationManager.AppSettings["webUrl"].ToString() + "'>");
        sb.Append("</head>");
        sb.Append("<body>");
        sb.Append("<table cellpadding='0' cellspacing='2' style='background-color:#c2113d;'>");
        sb.Append("<tr><td ><a href='" + ConfigurationManager.AppSettings["reiqcorporateurl"].ToString() + "' target='_blank'><img src='" + ConfigurationManager.AppSettings["webUrl"].ToString() + "images/reiqdotcom-header.jpeg' alt='' style='border:none;'/></a></td></tr>");
        sb.Append("<tr style='height:250px;' ><td  style='background-color:White;padding:20px;vertical-align:top;'>");
        sb.Append(body);
        sb.Append("</td></tr>");
        sb.Append("<tr><td><a href='" + ConfigurationManager.AppSettings["reiqcorporateurl"].ToString() + "REIQ/ContactUs/Social_media/REIQ/Contact_us/Social_media.aspx' target='_blank'><img src='" + ConfigurationManager.AppSettings["webUrl"].ToString() + "images/propertyalert-footer.jpg' alt='' style='border:none;'/></a></td></tr>");
        sb.Append("</table>");
        sb.Append("</body>");
        sb.Append("</html>");

        return sb.ToString();
    }
    public string GenerateURL(string suburb, string strId, string type, string status)
    {

        if (String.IsNullOrEmpty(suburb.ToString()))
            suburb = "na";

        if (String.IsNullOrEmpty(status))
            status = "na";


        #region Generate SEO Friendly URL based on Address
        //Trim Start and End Spaces.
        status = status.Trim();

        //Trim "-" Hyphen
        status = status.Trim('-');

        status = status.ToLower();
        char[] chars = @"$%#@!*?;:~`+=()[]{}|\'<>,/^&"".".ToCharArray();
        status = status.Replace("c#", "C-Sharp");
        status = status.Replace("vb.net", "VB-Net");
        status = status.Replace("asp.net", "Asp-Net");

        //Replace . with - hyphen
        status = status.Replace(".", "-");

        //Replace Special-Characters
        for (int i = 0; i < chars.Length; i++)
        {
            string strChar = chars.GetValue(i).ToString();
            if (status.Contains(strChar))
            {
                status = status.Replace(strChar, string.Empty);
            }
        }

        //Replace all spaces with one "-" hyphen
        status = status.Replace(" ", "-");

        //Replace multiple "-" hyphen with single "-" hyphen.
        status = status.Replace("--", "-");
        status = status.Replace("---", "-");
        status = status.Replace("----", "-");
        status = status.Replace("-----", "-");
        status = status.Replace("----", "-");
        status = status.Replace("---", "-");
        status = status.Replace("--", "-");

        //Run the code again...
        //Trim Start and End Spaces.
        status = status.Trim();

        //Trim "-" Hyphen
        status = status.Trim('-');
        #endregion

        #region Generate SEO Friendly URL based on Suburb
        //Trim Start and End Spaces.
        suburb = suburb.Trim();

        //Trim "-" Hyphen
        suburb = suburb.Trim('-');

        suburb = suburb.ToLower();
        suburb = suburb.Replace("c#", "C-Sharp");
        suburb = suburb.Replace("vb.net", "VB-Net");
        suburb = suburb.Replace("asp.net", "Asp-Net");

        //Replace . with - hyphen
        suburb = suburb.Replace(".", "-");

        //Replace Special-Characters
        for (int j = 0; j < chars.Length; j++)
        {
            string strChar = chars.GetValue(j).ToString();
            if (status.Contains(strChar))
            {
                status = status.Replace(strChar, string.Empty);
            }
        }

        //Replace all spaces with one "-" hyphen
        suburb = suburb.Replace(" ", "-");

        //Replace multiple "-" hyphen with single "-" hyphen.
        suburb = suburb.Replace("--", "-");
        suburb = suburb.Replace("---", "-");
        suburb = suburb.Replace("----", "-");
        suburb = suburb.Replace("-----", "-");
        suburb = suburb.Replace("----", "-");
        suburb = suburb.Replace("---", "-");
        suburb = suburb.Replace("--", "-");

        //Run the code again...
        //Trim Start and End Spaces.
        suburb = suburb.Trim();

        //Trim "-" Hyphen
        suburb = suburb.Trim('-');
        #endregion
        //type = "real-estate";
        //Append ID at the end of SEO Friendly URL

        type = type.Replace("/", "-");
        type = type.Trim();

        status = type + "/" + status + "/" + suburb + "/" + strId + ".aspx";

        return status;
    }
    public string getagentmobileformat(string mobile)
    {
        //0418759223
        string strmobile = mobile;
        if (!string.IsNullOrEmpty(strmobile))
        {
            strmobile = strmobile.Trim().Replace(" ", "");

            if (strmobile.StartsWith("04") && strmobile.Length == 10)
            {
                char[] str = strmobile.ToCharArray();
                strmobile = "";
                for (int i = 0; i < str.Length; i++)
                {
                    if (i == 4 || i == 7)
                        strmobile += " ";

                    strmobile += str[i];
                }
                return strmobile;

            }

        }
        return mobile;
    }
    public string getdisplaysearchfeaturesHomepage(string numbedroom, string numbathroom, string numcarbay, string numstudy, string haspool, string numgarage)
    {
        string dislayhtml = "";
        int xBed = 0;
        int xBath = 0;
        int xCar = 0;

        if (!String.IsNullOrEmpty(numbedroom))
        {
            if (int.Parse(numbedroom) > 0)
            {
                xBed = 1;
            }
        }

        if (!String.IsNullOrEmpty(numbathroom))
        {
            if (int.Parse(numbathroom) > 0)
            {
                xBath = 1;
            }

        }

        if (!String.IsNullOrEmpty(numcarbay))
        {
            if (int.Parse(numcarbay) > 0)
            {
                xCar = 1;
            }
        }
        if (!String.IsNullOrEmpty(numgarage))
        {
            if (int.Parse(numgarage) > 0)
            {
                xCar = 1;
            }
        }
        if (xBed > 0 || xBath > 0 || xCar > 0)
        {

            int TotalSpace = 0;
            if (!String.IsNullOrEmpty(numbedroom))
            {
                if (int.Parse(numbedroom) > 0)
                {
                    dislayhtml = dislayhtml + "<td><img src=" + ConfigurationManager.AppSettings["webUrl"].ToString() + "images/i_bed.jpg width='18' title=bed ></td><td>" + numbedroom + "&nbsp;</td>";
                }
            }
            if (!String.IsNullOrEmpty(numbathroom))
            {
                if (int.Parse(numbathroom) > 0)
                {
                    dislayhtml = dislayhtml + "<td><img src=" + ConfigurationManager.AppSettings["webUrl"].ToString() + "images/i_bath.jpg width='18' title=bath ></td><td>" + numbathroom + "&nbsp;</td>";
                }
            }
            if (!String.IsNullOrEmpty(numcarbay))
            {
                TotalSpace = TotalSpace + int.Parse(numcarbay);

            }
            if (!String.IsNullOrEmpty(numgarage))
            {
                TotalSpace = TotalSpace + int.Parse(numgarage);

            }
            if (TotalSpace > 0)
            {
                dislayhtml = dislayhtml + "<td><img src=" + ConfigurationManager.AppSettings["webUrl"].ToString() + "images/i_car.jpg width='18' title=car ></td><td>" + TotalSpace + "&nbsp;</td>";
            }

        }
        return dislayhtml;
    }
    public DataSet getAutocomplete(string status, string type, string keyword)
    {
        SqlCommand command = new SqlCommand("spgetAutocomplete", connection);
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.Add(new SqlParameter("@status", status));
        command.Parameters.Add(new SqlParameter("@type", type));
        command.Parameters.Add(new SqlParameter("@keyword", keyword));
        SqlDataAdapter objAdapter = new SqlDataAdapter();
        objAdapter.SelectCommand = command;
        DataSet objDS = new DataSet();
        objAdapter.Fill(objDS);
        return objDS;
    }
    public DataTable getLatestliveProp()
    {
        DataTable dt = new DataTable();

        SqlCommand command = new SqlCommand("spgetLatestliveProp", connection);
        command.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = command;
        da.Fill(dt);

        return dt;
    }


}
