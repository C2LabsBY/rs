using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace REIQ.usercontrols
{
    /// <summary>
    /// Collects all of the search parameters in one place and provides a bunch of useful functions
    /// </summary>
    public class PropertySearchBase : System.Web.UI.UserControl
    {
        protected const int PropertiesPerPage = 20;

        public static string DefaultSearchText = "Type in a suburb, postcode, region or property ID to begin your search";

        #region search parameter properties
        private REIQ.Enum.SearchType _st;
        private string _txt;
        private int _be, _ba;
        private int _prl;
        private int _prh;
        private bool? _surr;
        private bool? _exoffer;
        private bool? _hoonly;
        private int _p;
        private int _acId;
        private REIQ.Enum.SortOptions _sort;

        /// <summary>
        /// Search type
        /// </summary>
        public REIQ.Enum.SearchType ParamSearchType
        {
            get
            {
                if (!string.IsNullOrWhiteSpace(Request.QueryString["st"]) && System.Enum.IsDefined(typeof(REIQ.Enum.SearchType), Request.QueryString["st"]))
                    _st = (REIQ.Enum.SearchType)System.Enum.Parse(typeof(REIQ.Enum.SearchType), Request.QueryString["st"], true);
                return _st;
            }
        }

        /// <summary>
        /// Sorting
        /// </summary>
        public REIQ.Enum.SortOptions ParamSort
        {
            get
            {
                if (!string.IsNullOrWhiteSpace(Request.QueryString["ob"]) && System.Enum.IsDefined(typeof(REIQ.Enum.SortOptions), Request.QueryString["ob"]))
                    _sort = (REIQ.Enum.SortOptions)System.Enum.Parse(typeof(REIQ.Enum.SortOptions), Request.QueryString["ob"], true);
                return _sort;
            }
        }

        /// <summary>
        /// Property type
        /// </summary>
        public IEnumerable<string> ParamPropertyType
        {
            get
            {
                if (string.IsNullOrEmpty(Request.QueryString["ty"]))
                {
                    return Enumerable.Empty<string>();
                }
                return Request.QueryString["ty"].Split(',').ToList().Where(ty => !String.IsNullOrEmpty(ty));
            }
        }

        /// <summary>
        /// Keywords e.g. suburb, postcode, address or region
        /// </summary>
        public string ParamKeyword
        {
            get
            {
                if (!string.IsNullOrWhiteSpace(_txt))
                    return _txt;
                return Request.QueryString["txt"];
            }
        }

        /// <summary>
        /// Minimum number of beds
        /// </summary>
        public int ParamMinimumBeds
        {
            get
            {
                if (_be > 0)
                    return _be;
                else if (Int32.TryParse(Request.QueryString["be"], out _be))
                    return _be;
                else return 0;
            }
        }

        /// <summary>
        /// Minimum number of baths
        /// </summary>
        public int ParamMinimumBaths
        {
            get
            {
                if (_ba > 0)
                    return _ba;
                else if (Int32.TryParse(Request.QueryString["ba"], out _ba))
                    return _ba;
                else return 0;
            }
        }
        
        /// <summary>
        /// Minimum price
        /// </summary>
        public int ParamPriceLow
        {
            get
            {
                if (_prl > 0)
                    return _prl;
                else if (Int32.TryParse(Request.QueryString["prl"], out _prl))
                    return _prl;
                else return 0;
            }
        }

        /// <summary>
        /// Maximum price
        /// </summary>
        public int ParamPriceHigh
        {
            get
            {
                if (_prh > 0)
                    return _prh;
                else if (Int32.TryParse(Request.QueryString["prh"], out _prh))
                    return _prh;
                else return 100000000;
            }
        }

        /// <summary>
        /// Include surrounding suburbs
        /// </summary>
        public bool ParamIncludeSurroundingSuburbs
        {
            get
            {
                if (!_surr.HasValue)
                    _surr = Request.QueryString["surr"] == "1";
                return _surr.Value;
            }
        }

        /// <summary>
        /// Exclude properties under offer
        /// </summary>
        public bool ParamExcludePropertiesUnderOffer
        {
            get
            {
                if (!_exoffer.HasValue)
                    _exoffer = Request.QueryString["exoffer"] == "1";
                return _exoffer.Value;
            }
        }

        /// <summary>
        /// Include open homes only
        /// </summary>
        public bool ParamIncludeOpenHomesOnly
        {
            get
            {
                if (!_hoonly.HasValue)
                    _hoonly = Request.QueryString["hoonly"] == "1";
                return _hoonly.Value;
            }
        }
        
        /// <summary>
        /// Page number
        /// </summary>
        public int ParamPageNumber
        {
            get
            {
                Int32.TryParse(Request.QueryString["p"], out _p);
                if (_p == 0)
                {
                    return 1; //default to the first page
                }

                return _p;
            }
        }

        /// <summary>
        /// Agency Id
        /// </summary>
        public int ParamAgencyId
        {
            get
            {
                Int32.TryParse(Request.QueryString["acId"], out _acId);
                return _acId;
            }
        }


        #endregion

        /// <summary>
        /// Put list of property ids in request scope
        /// </summary>
        protected void RememberPropertyIds(IEnumerable<int> propertyIds)
        {
            System.Web.HttpContext.Current.Items["SearchResults"] = propertyIds;
        }

        /// <summary>
        /// Get list of property ids from request scope
        /// </summary>
        protected IEnumerable<int> RetrievePropertyIds()
        {
            var results = System.Web.HttpContext.Current.Items["SearchResults"] as IEnumerable<int>;
            return results;
        }
    }
}