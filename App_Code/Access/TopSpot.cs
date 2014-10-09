using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dapper;

namespace REIQ.Access
{
    public class TopSpot
    {
        public static List<Entities.topspot> Select(string suburb, string category, string postcode, string startdate, string enddate)
        {
            using (var conn = Data.CreateConnection())
            {
                return conn.Query<Entities.topspot>(
                    @"select    t.*
                                --,a.name,s.name as suburb,s.postcode,ag.firstname,ag.surname ,      
		                        --hits=(select sum(hitcount) from tbltopspothits h where h.topspotid=t.topspotid )      
		            from        tbltopspot t                
		            --left join   tblagency a on t.acid=a.acid                
		            left join   tblsuburb s on s.sid=t.suburbid                
		            --left join   tblagent ag on ag.aid=t.optionsAid                
		            where       topspotid is not null  
                                and s.name = @name 
                                and s.postcode = @postcode 
                                and (cast(@startdate as datetime) between StartDate and ExpDate or cast(@enddate as datetime) between StartDate and ExpDate)  
                                and category =@category 
                    order by    topspotid ;",
                    new { name = suburb, postcode = postcode, startdate = startdate, enddate = enddate, category = category }).ToList();
            }
        }
    }
}