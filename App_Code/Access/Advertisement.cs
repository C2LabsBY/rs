using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Dapper;

namespace REIQ.Access{
    public class Advertisement
    {
        public static List<Entities.Advertisement> GetTowerAdsBySuburb(String adCategory, Int32 suburbID)
        {
            String adType = "toweradlist";
            
            using (var conn = Data.CreateConnection())
            {
                return conn.Query<Entities.Advertisement>(
                    @"
                    select	a.*,--s.name as suburb,s.postcode,                
		                    hits=(
			                    select sum(hitcount) 
			                    from tblAdvertiesmenthits h 
			                    where h.adid=a.adid),       
		                    agencyname = ag.name            

                    from    tblAdvertiesment a  WITH (NOLOCK)                              

                    --left join tblsuburb s WITH (NOLOCK) on s.sid = a.suburbid                                      

                    left join tblagency ag WITH (NOLOCK) on ag.acid = a.acid      

                    where AdId is not null and Adtype in (@adType) 
		                    and category =@adCategory 
                            and a.suburbid = @suburbID
		                    --and s.name in ('Wynnum West') 
		                    --and s.postcode in ('4178') 
		                    and (GETDATE() between StartDate and ExpDate or GETDATE() between StartDate and ExpDate)  
		                    and isnull(imgurl,'')!='' ;", new { adType = adType, adCategory = adCategory, suburbID = suburbID }).ToList();
            }
        }

        public static List<Entities.Advertisement> GetTowerAdsByRegion(String adCategory, String region)
        {
            String adType = "toweradlist";

            using (var conn = Data.CreateConnection())
            {
                return conn.Query<Entities.Advertisement>(
                    @"
                    select	a.*,--s.name as suburb,s.postcode,                
		                    hits=(
			                    select sum(hitcount) 
			                    from tblAdvertiesmenthits h 
			                    where h.adid=a.adid),       
		                    agencyname = ag.name            

                    from    tblAdvertiesment a  WITH (NOLOCK)                              

                    --left join tblsuburb s WITH (NOLOCK) on s.sid = a.suburbid                                      

                    left join tblagency ag WITH (NOLOCK) on ag.acid = a.acid      

                    where AdId is not null and Adtype in (@adType) 
		                    and category =@adCategory 
                            and a.region = @region
		                    and (GETDATE() between StartDate and ExpDate or GETDATE() between StartDate and ExpDate)  
		                    and isnull(imgurl,'')!='' ;", new { adType = adType, adCategory = adCategory, region = region }).ToList();
            }
        }

        public static List<Entities.Advertisement> GetBannerAdsBySuburb(String adCategory, Int32 suburbID)
        {
            String adType = "banneradgap";

            using (var conn = Data.CreateConnection())
            {
                return conn.Query<Entities.Advertisement>(
                    @"
                    select	a.*,            
		                    hits=(
			                    select sum(hitcount) 
			                    from tblAdvertiesmenthits h 
			                    where h.adid=a.adid),       
		                    agencyname = ag.name            

                    from    tblAdvertiesment a  WITH (NOLOCK)                              

                    left join tblagency ag WITH (NOLOCK) on ag.acid = a.acid      

                    where AdId is not null and Adtype in (@adType) 
		                    and category =@adCategory 
                            and a.suburbid = @suburbID
		                    and (GETDATE() between StartDate and ExpDate or GETDATE() between StartDate and ExpDate)  
		                    and isnull(imgurl,'')!='' ;", new { adType = adType, adCategory = adCategory, suburbID = suburbID }).ToList();
            }
        }

        public static List<Entities.Advertisement> GetBannerAdsByRegion(String adCategory, String region)
        {
            String adType = "banneradgap";

            using (var conn = Data.CreateConnection())
            {
                return conn.Query<Entities.Advertisement>(
                    @"
                    select	a.*,
		                    hits=(
			                    select sum(hitcount) 
			                    from tblAdvertiesmenthits h 
			                    where h.adid=a.adid),       
		                    agencyname = ag.name            

                    from    tblAdvertiesment a  WITH (NOLOCK)                              

                    left join tblagency ag WITH (NOLOCK) on ag.acid = a.acid      

                    where AdId is not null and Adtype in (@adType) 
		                    and category =@adCategory 
                            and a.region = @region
		                    and (GETDATE() between StartDate and ExpDate or GETDATE() between StartDate and ExpDate)  
		                    and isnull(imgurl,'')!='' ;", new { adType = adType, adCategory = adCategory, region = region }).ToList();
            }
        }

        public class AdvertisementExtended
        {
            public int AdId { get; set; }

            public string imgurl { get; set; }

            public string alttext { get; set; }

            public string link { get; set; }

            public int? acid { get; set; }

            public string ThirdPartyName { get; set; }

            public String AgencyName { get; set; }

            public String AgencyWeb { get; set; }
        }

        public static List<AdvertisementExtended> GetBannerAdsHomePage()
        {
            String adType = "toweradhome";

            using (var conn = Data.CreateConnection())
            {
                return conn.Query<AdvertisementExtended>(
                    @"
                    select	a.*,		                          
		                    AgencyName = ag.name,
		                    AgencyWeb = ag.web                                        

                    from    tblAdvertiesment a WITH (NOLOCK)                              

                    left join tblagency ag WITH (NOLOCK) on ag.acid = a.acid      

                    where AdId is not null and Adtype in (@adType) 
		            and GETDATE() between StartDate and ExpDate;",
                    new { adType = adType }).ToList <AdvertisementExtended>();
            }
        }

        public static String GetCategoryParam(String searchType)
        {
            if (searchType == "fr" || searchType == "ra")
                return "residentialrentals";
            else if (searchType == "co")
                return "commercialsales";
            else if (searchType == "cr")
                return "commercialrentals";
            else if (searchType == "bu")
                return "businesssales";
            else if (searchType == "ru")
                return "ruralsales";
            else
                return "residentialsales";
        }

        public static void UpdateAdvertHit(string adid)
        {
            using (var conn = Data.CreateConnection())
            {
                string query = @"
                DECLARE @lastdate DATETIME
    
                SELECT @lastdate=MAX(hitdate) 
                FROM tblAdvertiesmenthits WITH (NOLOCK)
                WHERE adid=@adid
    
                IF CONVERT(DATETIME,CONVERT(VARCHAR,@lastdate,103),103)=CONVERT(DATETIME,CONVERT(VARCHAR,getdate(),103),103)
                BEGIN
                    UPDATE tblAdvertiesmenthits SET hitcount=hitcount+1
                    WHERE adid=@adid AND CONVERT(DATETIME,CONVERT(VARCHAR,hitdate,103),103)=CONVERT(DATETIME,CONVERT(VARCHAR,@lastdate,103),103)
                END
                ELSE
                BEGIN
                    INSERT INTO tblAdvertiesmenthits
                    VALUES (@adid,getdate(),1)
                END";

                conn.Execute(query, new { adid = adid });
            }
        }        
    }
}