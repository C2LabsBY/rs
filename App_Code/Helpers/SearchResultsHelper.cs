using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using REIQ.Entities;

namespace REIQ.Helpers
{
    public class SearchResultsHelper
    {
        public static string GetDisplaySearchFeatures(string numbedroom, string numbathroom, string numcarbay, string numstudy, string haspool, string numgarage)
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
                dislayhtml = dislayhtml + "<ul class='property-icons'>";
                int TotalSpace = 0;
                if (!String.IsNullOrEmpty(numbedroom))
                {
                    if (int.Parse(numbedroom) > 0)
                    {
                        dislayhtml = dislayhtml + "<li><span class='icons bed'></span>" + numbedroom + "</li>";
                    }
                }
                if (!String.IsNullOrEmpty(numbathroom))
                {
                    if (int.Parse(numbathroom) > 0)
                    {
                        dislayhtml = dislayhtml + "<li><span class='icons bath'></span>" + numbathroom + "</li>";
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
                    dislayhtml = dislayhtml + "<li><span class='icons parking'></span>" + TotalSpace + "</li>";
                }

                dislayhtml = dislayhtml + "</ul>";
            }
            return dislayhtml;
        }

        public static string GetDisplaySearchFeatures_Featured(string numbedroom, string numbathroom, string numcarbay, string numstudy, string haspool, string numgarage)
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
                dislayhtml = dislayhtml + "<ul class='featured-block-icons'>";
                int TotalSpace = 0;
                if (!String.IsNullOrEmpty(numbedroom))
                {
                    if (int.Parse(numbedroom) > 0)
                    {
                        dislayhtml = dislayhtml + "<li><span class='icons bed'></span>" + numbedroom + "</li>";
                    }
                }
                if (!String.IsNullOrEmpty(numbathroom))
                {
                    if (int.Parse(numbathroom) > 0)
                    {
                        dislayhtml = dislayhtml + "<li><span class='icons bath'></span>" + numbathroom + "</li>";
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
                    dislayhtml = dislayhtml + "<li><span class='icons parking'></span>" + TotalSpace + "</li>";
                }

                dislayhtml = dislayhtml + "</ul>";
            }
            return dislayhtml;
        }
    }
}