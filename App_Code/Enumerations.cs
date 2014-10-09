using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace REIQ.Enum
{
    /// <summary>
    /// Idnetify the search form tab
    /// </summary>
    public enum SearchTab
    {
        Buy,
        Rent,
        Commercial,
        Business,
        Rural
    }

    /// <summary>
    /// Identify what to search on
    /// </summary>
    public enum SearchType
    {
        /// <summary>
        /// Buy
        /// </summary>
        sa,
        /// <summary>
        /// Rent
        /// </summary>
        ra,
        /// <summary>
        /// Commercial for sale
        /// </summary>
        co,
        /// <summary>
        /// Commercial for lease
        /// </summary>
        cr,
        /// <summary>
        /// Businesses
        /// </summary>
        bu,
        /// <summary>
        /// Rural
        /// </summary>
        ru,
        /// <summary>
        /// For Sale ???
        /// </summary>
        fs,
        /// <summary>
        /// For Rent ???
        /// </summary>
        fr,
        /// <summary>
        /// Auction
        /// </summary>
        au,
        /// <summary>
        /// POA
        /// </summary>
        po,
        /// <summary>
        /// Under Offer
        /// </summary>
        uo,
        /// <summary>
        /// Sold
        /// </summary>
        so

    }

    /// <summary>
    /// The sorting options for the search results
    /// </summary>
    public enum SortOptions
    {
        Most_recent,
        By_suburb,
        Highest_price,
        Lowest_price,
        Number_bedrooms
    }
}