using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace REIQ.Helpers
{
    public class Images
    {
        private static string ImageUrl 
        {
            get
            {
                return System.Configuration.ConfigurationManager.AppSettings["ImageUrl"];
            }
        }

        public static string GetAgentImage(int agencyId, int agentId, int width, int height)
        {
            //return string.Format("{0}/images/agency/{1}/{2}_PIC.jpg", ImageUrl, agencyId, agentId);
            return string.Format("{0}/resizeheight.ashx?width={1}&amp;height={2}&amp;type=logo&amp;path=/images/agency/{3}/{4}_PIC.jpg", ImageUrl, width, height, agencyId, agentId);
        }

        public static string GetAgencyImage(int agencyId, int width)
        {
            return string.Format("{0}/resizeheight.ashx?width={1}&amp;type=logo&amp;path=/images/agency/{2}/{2}_logo.jpg", ImageUrl, width, agencyId);
        }

        public static string GetAgencyImage(int agencyId, int width, int height)
        {
            return string.Format("{0}/resizeheight.ashx?width={1}&amp;height={2}&amp;type=logo&amp;path=/images/agency/{3}/{3}_logo.jpg", ImageUrl, width, height, agencyId);
        }

        public static string GetPropertyImage(int propertyId, int imageNo, int width)
        {
            return string.Format("{0}/resizeheight.ashx?width={1}&amp;path=images/properties/{2}/{2}_MP{3}.jpg", ImageUrl, width, propertyId, imageNo);
        }

        public static string GetPropertyFloorImage(int propertyId, int imageNo, int width)
        {
            return string.Format("{0}/resizeheight.ashx?width={1}&amp;path=images/properties/{2}/{2}_fp{3}.jpg", ImageUrl, width, propertyId, imageNo);
        }

        public static string GetDefaultPropertyImage(int propertyId, int width)
        {
            return string.Format("{0}/resizeheight.ashx?width={1}&amp;path=images/properties/{2}/{2}_lg.jpg", ImageUrl, width, propertyId);
        }

        public static string GetDefaultPropertyImage(int propertyId, int width, int height)
        {
            return string.Format("{0}/resizeheight.ashx?width={1}&amp;height={2}&amp;path=images/properties/{3}/{3}_lg.jpg", ImageUrl, width, height, propertyId);
        }

        public static string GetSuburbImage(int suburbId, int imageNo, int width)
        {
            return string.Format("{0}/resizeheight.ashx?width={1}&amp;path=images/suburbs/{2}/IMG{3}.jpg", ImageUrl, width, suburbId, imageNo);
        }
    }
}