using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using REIQ.Entities;

namespace REIQ.Helpers
{
    public class PropertyHelper
    {
        //generate SEO friendly agent url
        public static string GenerateURLAgent(string agentName, string suburb, string agentId)
        {

            if (String.IsNullOrEmpty(agentName.ToString()))
                agentName = "na";

            if (String.IsNullOrEmpty(suburb.ToString()))
                suburb = "na";

            #region Generate SEO Friendly URL based on Address
            //Trim Start and End Spaces.
            agentName = agentName.Trim();
            suburb = suburb.Trim();
            //Trim "-" Hyphen
            agentName = agentName.Trim('-');
            suburb = suburb.Trim();

            agentName = agentName.ToLower();
            suburb = suburb.ToLower();
            char[] chars = @"$%#@!*?;:~`+=()[]{}|\'<>,/^&"".".ToCharArray();
            
            //Replace . with - hyphen
            agentName = agentName.Replace(".", "-");
            suburb = suburb.Replace(".", "-");
            //Replace Special-Characters
            for (int i = 0; i < chars.Length; i++)
            {
                string strChar = chars.GetValue(i).ToString();
                if (agentName.Contains(strChar))
                {
                    agentName = agentName.Replace(strChar, string.Empty);
                }
                if (suburb.Contains(strChar))
                {
                    suburb = suburb.Replace(strChar, string.Empty);
                }
            }

            //Replace all spaces with one "-" hyphen
            agentName = agentName.Replace(" ", "-");
            suburb = suburb.Replace(" ", "-");
            //Replace multiple "-" hyphen with single "-" hyphen.
            agentName = agentName.Replace("--", "-");
            suburb = suburb.Replace("--", "-");
            //Run the code again...
            //Trim Start and End Spaces.
            agentName = agentName.Trim();
            suburb = suburb.Trim();
            //Trim "-" Hyphen
            agentName = agentName.Trim('-');
            suburb = suburb.Trim('-');
            #endregion
            //Append ID at the end of SEO Friendly URL
            agentName = "real-estate-agents-" + suburb + "/" + agentName + "/" + agentId;

            return agentName;
        }

        //generate SEO friendly agency url
        public static string GenerateURLAgency(string agencyName, string suburb, int acId)
        {

            if (String.IsNullOrEmpty(agencyName.ToString()))
                agencyName = "na";

            if (String.IsNullOrEmpty(suburb.ToString()))
                suburb = "na";

            #region Generate SEO Friendly URL based on Address
            //Trim Start and End Spaces.
            agencyName = agencyName.Trim();
            suburb = suburb.Trim();
            //Trim "-" Hyphen
            agencyName = agencyName.Trim('-');
            suburb = suburb.Trim('-');

            agencyName = agencyName.ToLower();
            suburb = suburb.ToLower();
            char[] chars = @"$%#@!*?;:~`+=()[]{}|\'<>,/^&"".".ToCharArray();

            //Replace . with - hyphen
            agencyName = agencyName.Replace(".", "-");
            suburb = suburb.Replace(".", "-");
            //Replace Special-Characters
            for (int i = 0; i < chars.Length; i++)
            {
                string strChar = chars.GetValue(i).ToString();
                if (agencyName.Contains(strChar))
                {
                    agencyName = agencyName.Replace(strChar, string.Empty);
                }
                if (suburb.Contains(strChar))
                {
                    suburb = suburb.Replace(strChar, string.Empty);
                }
            }

            //Replace all spaces with one "-" hyphen
            agencyName = agencyName.Replace(" ", "-");
            suburb = suburb.Replace(" ", "-");

            //Replace multiple "-" hyphen with single "-" hyphen.
            agencyName = agencyName.Replace("--", "-");
            suburb = suburb.Replace("--", "-");
            //Run the code again...
            //Trim Start and End Spaces.
            agencyName = agencyName.Trim();
            suburb = suburb.Trim();
            //Trim "-" Hyphen
            agencyName = agencyName.Trim('-');
            suburb = suburb.Trim('-');
            #endregion
            //Append ID at the end of SEO Friendly URL
            agencyName = "real-estate-agencies-" + suburb + "/" + agencyName + "/" + acId;
            
            return agencyName;
        }

        public static string GenerateURL(string suburb, string strId, string type, string status, REIQ.Enum.SearchType paramSearchType, string region)
        {
            String url = String.Empty;

            if (String.IsNullOrEmpty(suburb)) suburb = "na";
            else suburb = PrepareUrlParts(suburb);

            if (String.IsNullOrEmpty(status)) status = "na";
            else status = PrepareUrlParts(status);            

            if (String.IsNullOrEmpty(region)) region = "na";
            else region = PrepareUrlParts(region);

            if (String.IsNullOrEmpty(type)) type = "na";
            else type = PrepareType(type, paramSearchType.ToString(), region);

            url = type;
            if (type.Contains("sale") || type.Contains("lease"))
            {
                url += "/";
            }
            else url += "-" + status + "/";

            url += region + "/" + suburb + "/" + strId;

            return url;
        }

        public static string PrepareUrlParts(string urlPart)
        {
            //Trim Start and End Spaces and hypens.
            urlPart = urlPart.Trim().Trim('-').ToLower();

            //Replace Special-Characters
            char[] chars = @"$%#@!*?;:~`+=()[]{}|\'<>,/^&""._".ToCharArray();
            for (int i = 0; i < chars.Length; i++)
            {
                string strChar = chars.GetValue(i).ToString();
                if (urlPart.Contains(strChar))
                {
                    urlPart = urlPart.Replace(strChar, "-");
                }
            }
            //Trim Start and End Spaces and hypens
            urlPart = urlPart.Trim().Trim('-');
            //Replace all spaces with one "-" hyphen
            urlPart = urlPart.Replace(" ", "-");
            //Replace multiple "-" hyphen with single "-" hyphen.
            urlPart = urlPart.Replace("----", "-");
            urlPart = urlPart.Replace("---", "-");
            urlPart = urlPart.Replace("--", "-");            

            return urlPart;
        }

        public static string PrepareType(string type, string paramSearchType, string region)
        {
            type = type.Replace("/", "-").Replace(" ", "-").Trim().ToLower();            

            if (paramSearchType.ToString() == "co")
                type = "commercial-real-estate/property-for-sale";
            else if (paramSearchType.ToString() == "cr")
                type = "commercial-real-estate/property-for-lease";
            else if (paramSearchType.ToString() == "bu")
                type = "business-for-sale";
            else if (paramSearchType.ToString() == "ru" || paramSearchType.ToString() == "fs")
                type = "rural-properties-for-sale";
            else if (paramSearchType.ToString() == "ra" && type.Contains("land"))
                type = "land-for-lease";
            else
            {
                if (type.Contains("apartment"))
                {
                    type = "apartments-units";
                }
                else if (type.Contains("townhouse"))
                {
                    type = "townhouses";
                }
                else if (type.Contains("acreage") || type.Contains("rural"))
                {
                    type = "rural-properties";
                }
                else if (!type.Contains("land"))
                {
                    if (!type.Contains("block")) type += "s";
                }
            }

            return type;
        }

        public static string GetAddress(Property Property)
        {
            string address = "";
            if (Property != null)
            {
                if (!Property.hideRoadName)
                {
                    if (!String.IsNullOrEmpty(Property.rdNum))
                    {
                        address = address + Property.rdNum + " ";
                    }
                    if (!String.IsNullOrEmpty(Property.rdName))
                    {
                        address = address + Property.rdName + " ";
                    }
                    if (!String.IsNullOrEmpty(Property.rdType))
                    {
                        address = address + Property.rdType;
                    }
                    if (!String.IsNullOrEmpty(Property.unitNum))
                    {
                        address = "Unit " + Property.unitNum + "/" + address;
                    }
                    if (!String.IsNullOrEmpty(Property.name))
                    {
                        address = Property.name + "<br>" + address;
                    }
                    if (!String.IsNullOrEmpty(Property.suburb))
                    {
                        if (!String.IsNullOrEmpty(address))
                        {
                            address = Property.suburb + ", " + address;
                        }
                        else
                        {
                            address = Property.suburb;
                        }
                    }

                }
                else
                {
                    if (!String.IsNullOrEmpty(Property.suburb))
                    {
                        address = Property.suburb;
                    }
                }
            }
            return HttpUtility.HtmlDecode(address).ToUpper();
        }

        public static string GetAddress_Featured(Property Property)
        {
            string address = "";
            if (Property != null)
            {
                if (!Property.hideRoadName)
                {
                    if (!String.IsNullOrEmpty(Property.rdNum))
                    {
                        address = address + Property.rdNum + " ";
                    }
                    if (!String.IsNullOrEmpty(Property.rdName))
                    {
                        address = address + Property.rdName + " ";
                    }
                    if (!String.IsNullOrEmpty(Property.rdType))
                    {
                        address = address + Property.rdType;
                    }
                    if (!String.IsNullOrEmpty(Property.unitNum))
                    {
                        address = "Unit " + Property.unitNum + "/" + address;
                    }
                    if (!String.IsNullOrEmpty(Property.name))
                    {
                        address = Property.name + "<br>" + address;
                    }
                }
            }
            return HttpUtility.HtmlDecode(address);
        }

        public static string GetGoogleAddress(string strName, string strUnitNum, string strRoadNum, string strRoadName, string strRoadType, string strSuburb, Boolean blHideRoadName, Boolean blHideRoadNum)
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

        public static string GetSearchImageUrl(string pid, bool hasphoto, string type, string address, string status, string price, string width, string height)
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
                    imgurl = "<img src=" + ConfigurationManager.AppSettings["imageurl"].ToString() + "resize.asp?width=" + width + "&height=" + height + "&path=images/properties/" + pid + "/" + pid + "_lg.jpg title='" + type + " " + status.ToLower() + " in " + address + "' border=0 class=propertyimg />";
                }
                else
                {
                    imgurl = "<img src=" + ConfigurationManager.AppSettings["imageurl"].ToString() + "resize.asp?width=" + width + "&height=" + height + "&path=images/properties/" + pid + "/" + pid + "_lg.jpg title='" + type + " " + status.ToLower() + " in " + address + " for " + price + "' border=0 class=propertyimg />";
                }

            }
            else
            {
                if (price.ToUpper() == "RENTED" || price.ToUpper() == "SOLD" || price.ToUpper() == "UNDER OFFER")
                {
                    imgurl = "<img src=" + ConfigurationManager.AppSettings["imageurl"].ToString() + "resize.asp?width=" + width + "&height=" + height + "&path=images/properties/0/0_lg.jpg title='" + type + " " + status.ToLower() + " in " + address + "' border=0 class=propertyimg />";
                }
                else
                {
                    imgurl = "<img src=" + ConfigurationManager.AppSettings["imageurl"].ToString() + "resize.asp?width=" + width + "&height=" + height + "&path=images/properties/0/0_lg.jpg title='" + type + " " + status.ToLower() + " in " + address + " for " + price + "' border=0 class=propertyimg />";
                }

            }

            return imgurl;
        }

        public static string GetFurnished(bool furnished)
        {
            return furnished ?  "<span class=furnished>Furnished</span>" : String.Empty;
        }

        public static string GetNewlyAdded(DateTime dateListed)
        {
            TimeSpan ts = DateTime.Today - dateListed;
            // Difference in days.
            return ts.Days <= 7 ? "<span class='newly'>newly added</span>" : String.Empty;
        }

        public static string GetShortDescription(string s, int noChars)
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

        public static bool isNewlyAdded(DateTime? dateListed)
        {
            if (dateListed != null)
            {
                TimeSpan ts = DateTime.Today - (DateTime)dateListed;
                // Difference in days.
                return ts.Days <= 7;
            }
            return false;
        }

        public static string GetAuctionFormat(string strAuctionDate, string strAuctionTime)
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

        public static string GetHomeOpensFormat_New(string strHomeopen1From, string strHomeopen1To, string strHomeopen2From, string strHomeopen2To)
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
            return homeopent.ToUpper();
        }

        public static string GetDisplaySearchFeaturesSmall(string numbedroom, string numbathroom, string numcarbay, string numstudy, string haspool, string numgarage)
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

        public static string GetAgentData(Agent agent, int pID)
        {
            string strAgentData = "";
            string strAgentName = "";

            bool tempnonimis = false;
            if (agent.nonIMIS != null)
            {
                tempnonimis = (bool)agent.nonIMIS;
            }
            if (agent.ImisAid != null || tempnonimis)
            {
                bool isdisplay = false;
                if (agent.isWebDisplay != null)
                {
                    isdisplay = agent.isWebDisplay;
                }

                if (isdisplay)
                {

                    strAgentName = agent.firstname;
                    strAgentName += " " + agent.surname;
                }

                strAgentData += strAgentName;

                if (!String.IsNullOrEmpty(agent.mobile))
                {
                    string phonetemp = "";
                    if (!String.IsNullOrEmpty(agent.phone))
                    {
                        phonetemp = agent.phone;
                    }

                    string mobiletemp = agent.mobile;
                    if (!String.IsNullOrEmpty(phonetemp))
                    {
                        phonetemp = phonetemp.Replace("(", "").Replace(")", "").Replace(" ", "");
                        mobiletemp = mobiletemp.Replace("(", "").Replace(")", "").Replace(" ", "");
                    }
                    if (phonetemp != mobiletemp)
                    {
                        bool hidemobile = false;
                        if (agent.hidemobile != null)
                        {
                            hidemobile = (bool)agent.hidemobile;
                        }

                        if (!hidemobile)
                        {
                            strAgentData += "<br />" + getAgentMobileFormat(agent.mobile);
                        }
                    }
                }
                else if (!String.IsNullOrEmpty(agent.phone))
                {
                    strAgentData += "<br />" + agent.phone.Replace("(", "").Replace(")", "");
                }
            }
            return strAgentData;
        }

        private static string getAgentMobileFormat(string mobile)
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

        public static string GetEmailbox(string body)
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

        public static string GetPropertyPrice(Property property)
        {
            //Determine if we should hide the price
            bool isHidePrice = false;
            if (property.hidePrice != null)
                isHidePrice = (Boolean)property.hidePrice;

            if (!isHidePrice)
            {
                if (property.pricetext == "0$" || String.IsNullOrEmpty(property.pricetext))
                {
                    if (property.priceLow != null)
                    {
                        if (property.priceLow > 0)
                        {
                            if (property.status == "For Rent")
                            {
                                //Form nice rent string
                                String priceText = ((int)property.priceLow).ToString("c0");
                                if (!String.IsNullOrEmpty(property.paymentPeriod))
                                    priceText += " per " + property.paymentPeriod;
                                return priceText.ToUpper();
                            }
                            else return ((int)property.priceLow).ToString("c0");
                        }
                    }
                }
                else return HttpUtility.HtmlDecode(property.pricetext).ToUpper();
            }

            return "";
        }

			/// <summary>
			/// returns formatted lotSize: 5.00 -> 5, 5.25 -> 5.25, 5.5 -> 5.50 
			/// </summary>
			/// <param name="lotSize"></param>
			/// <returns></returns>
        public static string GetLotSizeFormatted(decimal lotSize)
        {
            const string intFormat = "0.";
            const string floatFormat = "0.00";

            if (lotSize == Math.Floor(lotSize))
                return lotSize.ToString(intFormat);
            else
            {
                decimal formattedLotSize = TruncateToDecimalPlace(lotSize, 2);
                return formattedLotSize.ToString(floatFormat);
            }
        }

        //Used to truncate decimal value in order to show always certain amount of digits without math rounding
        //e.g. 123,456 -> 123,45
        public static decimal TruncateToDecimalPlace(decimal numberToTruncate, int decimalPlaces)
        {
            decimal power = (decimal)(Math.Pow(10.0, (double)decimalPlaces));

            return Math.Truncate((power * numberToTruncate)) / power;
        }

        public static void CheckIfHidden(Property property)
        {
            if (property.goLive == null) property.goLive = false;
            //If property sold or isWebDisplay = false or golive = true make redirection to agent profile
            if (property.status.ToLower() == "sold" || property.isWebDisplay == false || property.goLive == true)
            {
                String agentId = String.Empty;
                int agencyId = 0;

                //Determine which agent or agency this property belongs
                if (!String.IsNullOrEmpty(property.aID1.ToString())) agentId = property.aID1.ToString();
                else if (!String.IsNullOrEmpty(property.aID2.ToString())) agentId = property.aID2.ToString();
                else if (!String.IsNullOrEmpty(property.aID3.ToString())) agentId = property.aID3.ToString();
                
                agencyId = property.acID;

                //Redirection to agent profile                    
                if (!String.IsNullOrEmpty(agentId))
                {
                    var agent = REIQ.Access.Agent.GetFromAgentId(Convert.ToInt32(agentId));

                    if (agent != null) HttpContext.Current.Response.Redirect(REIQ.Helpers.PropertyHelper.GenerateURLAgent(agent.firstname + " " + agent.surname, property.suburb, agentId));
                }
                //Redirection to agency profile 
                if (agencyId != 0) HttpContext.Current.Response.Redirect(REIQ.Helpers.PropertyHelper.GenerateURLAgency(REIQ.Access.Agency.GetFromAgencyId(agencyId).name, property.suburb, agencyId));
            }
        }
    }
}