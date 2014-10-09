using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dapper;

namespace REIQ.Access
{
    /// <summary>
    /// Constants, lookups and lists used throughout the site. 
    /// </summary>
    public class Lookups
    {
        /// <summary>
        /// If no properties of a particular type are actively listed on the site, then that property type will not be returned
        /// </summary>
        public static IEnumerable<string> ListPropertyTypes()
        {
            using (var conn = Data.CreateConnection())
            {
                return conn.Query<string>("SELECT const FROM tblConstPropertyType WHERE const IN (SELECT DISTINCT type FROM tblProperty WHERE isWebdisplay = 1) AND const NOT IN ('Commercial', 'Business')  ORDER BY const");
            }
        }

        public static IEnumerable<KeyValuePair<int, string>> ListNumberOfBedrooms()
        {
            yield return new KeyValuePair<int, string>(1, "1 bedroom");
            yield return new KeyValuePair<int, string>(2, "2 bedrooms");
            yield return new KeyValuePair<int, string>(3, "3 bedrooms");
            yield return new KeyValuePair<int, string>(4, "4 bedrooms");
            yield return new KeyValuePair<int, string>(5, "5 bedrooms");
            /*yield return new KeyValuePair<string, string>("1only", "1 Bedroom");
            yield return new KeyValuePair<string, string>("1", "1 Bedroom +");
            yield return new KeyValuePair<string, string>("2only", "2 Bedrooms");
            yield return new KeyValuePair<string, string>("2", "2 Bedrooms +");
            yield return new KeyValuePair<string, string>("3only", "3 Bedrooms");
            yield return new KeyValuePair<string, string>("3", "3 Bedrooms +");
            yield return new KeyValuePair<string, string>("4only", "4 Bedrooms");
            yield return new KeyValuePair<string, string>("4", "4 Bedrooms + ");
            yield return new KeyValuePair<string, string>("5only", "5 Bedrooms");
            yield return new KeyValuePair<string, string>("5", "5 Bedrooms +");*/
        }

        public static IEnumerable<KeyValuePair<int, string>> ListNumberOfBathrooms()
        {
            yield return new KeyValuePair<int, string>(1, "1 bath");
            yield return new KeyValuePair<int, string>(2, "2 baths");
            yield return new KeyValuePair<int, string>(3, "3 baths");
            yield return new KeyValuePair<int, string>(4, "4 baths");
            yield return new KeyValuePair<int, string>(5, "5 baths");
        }

        public static IEnumerable<KeyValuePair<string, string>> ListLotSizes()
        {
            yield return new KeyValuePair<string, string>("400", "400 Sqm +");
            yield return new KeyValuePair<string, string>("600", "600 Sqm +");
            yield return new KeyValuePair<string, string>("800", "800 Sqm +");
            yield return new KeyValuePair<string, string>("1000", "1000 Sqm +");
            yield return new KeyValuePair<string, string>("2000", "2000 Sqm +");
        }

        /// <summary>
        /// Get a list of valid prices for the property type
        /// </summary>
        public static IEnumerable<int> ListPrices(Enum.SearchTab propertyType)
        {
            switch (propertyType)
            {
                default:
                case Enum.SearchTab.Business:
                case Enum.SearchTab.Buy:
                case Enum.SearchTab.Commercial:
                case Enum.SearchTab.Rural:
                    for(int price = 150000; price < 1000000; price += 50000)
                    {
                         yield return price;
                    }
                    for (int price = 1000000; price < 2000000; price += 250000)
                    {
                         yield return price;
                    }
                    yield return 2000000;
                    yield return 2500000;
                    yield return 3000000;
                    break;
                case Enum.SearchTab.Rent:
                    for (int price = 25; price < 1000; price += 25)
                    {
                        yield return price;
                    }
                    for (int price = 1000; price <= 2000; price += 50)
                    {
                        yield return price;
                    }
                    break;
            }
        }
    }
}