using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace Entities
{
    /// <summary>
    /// Maps to the tblCMS table
    /// </summary>
    public partial class CMS
    {
        public Int16 id { get; set; }

        public Int16? acID { get; set; }

        public String heading { get; set; }

        public String text { get; set; }

        public String date { get; set; }

        public String attachment { get; set; }

        public String link { get; set; }

        public String pageURL { get; set; }

        public Boolean isWebDisplay { get; set; }

        public String displaytext { get; set; }

        public Int32 orderid { get; set; }

        public Boolean isactive { get; set; }

        public Int32 orderidInside { get; set; }

    }


    /// <summary>
    /// Maps to the tblCMS table.  This holds static content items (they cannot be created or deleted through the CMS)
    /// </summary>
    public partial class CMSStatic
    {

        public String title { get; set; }

        public String description { get; set; }

        public String text { get; set; }

        public DateTime? dateModified { get; set; }

    }


    /// <summary>
    /// Maps to tht tblCMSPage table.  Represents a SEO friendly page. Managed in the CMS (psadmin).
    /// </summary>
    public partial class CMSPage
    {

        public Int32 id { get; set; }

        /// <summary>
        /// The search engine friendly URL.  This should be unique (no other item should have the same pageUrl).
        /// </summary>
        public String pageUrl { get; set; }

        /// <summary>
        /// The main title of the page
        /// </summary>
        public String title { get; set; }

        /// <summary>
        /// The meta/document title
        /// </summary>
        public String metaTitle { get; set; }

        public String metaDescription { get; set; }

        public String metaKeywords { get; set; }

        public String canonicalUrl { get; set; }
        
        public DateTime? dateModified { get; set; }

        public Boolean showPropertySearch { get; set; }

        public String propertySearchBlurb { get; set; }

        public Boolean hideHardCodedFooter { get; set; }

    }


    /// <summary>
    /// Maps to the tblCMSContent table.  These are the content sections that make up a page.  
    /// </summary>
    public partial class CMSContent
    {
        public Int32 id { get; set; }

        /// <summary>
        /// The pageId is the id of the CMSPage entity that the content item belongs to.
        /// </summary>
        public Int32 pageId { get; set; }

        public String heading { get; set; }

        public String text { get; set; }

        public Boolean isWebDisplay { get; set; }

        public Boolean isActive { get; set; }

        public Int32 orderidInside { get; set; }

        public DateTime? dateModified { get; set; }
    }

}