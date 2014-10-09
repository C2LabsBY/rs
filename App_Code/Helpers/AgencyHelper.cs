using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using REIQ.Entities;

namespace REIQ.Helpers
{
    public class AgencyHelper
    {
        public static String GetAgencyAddress(Agency agency)
        {
            string agencyAddress = String.Empty;

            if (!String.IsNullOrEmpty(agency.unitNum)) agencyAddress += agencyAddress;
            if (!String.IsNullOrEmpty(agency.rdNum)) agencyAddress += "/" + agency.rdNum;
            if (!String.IsNullOrEmpty(agency.rdName)) agencyAddress += " " + agency.rdName;
            if (!String.IsNullOrEmpty(agency.rdType)) agencyAddress += " " + agency.rdType;
            if (!String.IsNullOrEmpty(agency.suburb)) agencyAddress += ", " + agency.suburb;
            if (!String.IsNullOrEmpty(agency.state) && !String.IsNullOrEmpty(agency.suburb)) agencyAddress += ", " + agency.state;
            if (!String.IsNullOrEmpty(agency.postcode) && !String.IsNullOrEmpty(agency.suburb)) agencyAddress += " " + agency.postcode;
            
            return agencyAddress;
        }

        public static string GetAgentDetail(string acid, string aid, string name, bool hasphoto, string phone, string mobile, string email, bool? hidemobile, string suburb)
        {
            if (String.IsNullOrEmpty(suburb)) suburb = "na";
            string agentDet = "<li>";
            if (hasphoto)                
                agentDet += "<figure class='photo'><a href='/" + REIQ.Helpers.PropertyHelper.GenerateURLAgent(name, suburb, aid) +"'><img src='" + REIQ.Helpers.Images.GetAgentImage(Int32.Parse(acid), Int32.Parse(aid), 75, 99) + "'></a></figure>";
            
            agentDet += "<section class='team-short-des'>";
            agentDet += "<strong>" + name + "</strong><br/>";
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
                    bool isHideMobile = false;

                    if (hidemobile != null)
                        Boolean.TryParse(hidemobile.ToString(), out isHideMobile);

                    if (!isHideMobile)
                        agentDet += "M: " + GetAgentMobileFormat(mobile) + "<br />";
                }
            }
            if (!String.IsNullOrEmpty(phone))
            {
                agentDet += "P: " + phone.Replace("(", "").Replace(")", "") + "<br />";
            }
            if (!String.IsNullOrEmpty(email))
            {
                agentDet += "<a href='mailto:"+email+"'>"+email+"</a>";
            }
            //agentDet += "<a class='view-list-link' href='/agentdetails.aspx?aid=" + aid + "'>View my listings</a>";
            agentDet += "<a class='view-list-link' href='/" + REIQ.Helpers.PropertyHelper.GenerateURLAgent(name, suburb, aid) + "'>View my listings</a>";
            agentDet += "</li>";
            return agentDet;
        }

        public static string GetAgentMobileFormat(string mobile)
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

        public static string GetEmailBox(string body)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("<html>");
            sb.Append("<head>");
            sb.Append("<link rel='stylesheet' type='text/css' href='" + HttpContext.Current.Request.Url.Host + "default.css' />");
            sb.Append("<base href='" + HttpContext.Current.Request.Url.Host + "'>");
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

				public static string GetWebAddressFormatted(string url)
				{
					const string URL_PREFIX = "http://";
					if (!url.StartsWith(URL_PREFIX)) return URL_PREFIX + url;
					return url;
				}
    }
}