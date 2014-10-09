using System;
using Dapper;
using REIQ.Access;

namespace REIQ.Helpers
{
    public class LogHelper
    {
        public static void EditPublicLog(string strPID, string strACID)
        {
            using (var conn = Data.CreateConnection())
            {
                string query = @"
                 DECLARE @lastDateStamp AS datetime  
                 DECLARE @pIDInTotal as int  
                 DECLARE @dateDiff as smallint  
  
                 SET @lastDateStamp = (SELECT top 1 date from tblPublicActivityLog where (pid = @pID) AND (site = @site) order by date desc)  
                 IF @lastDateStamp <> '' -- there is an entry  
                  BEGIN  
                  SET @dateDiff = (SELECT datediff(dd, getdate(), @lastDateStamp))  
                  IF (@dateDiff <= -1) -- last stamp was made yesterday or older, so we insert a new entry  
                   INSERT tblPublicActivityLog VALUES(@pID, @acID, GETDATE(), 1, @site)  
                  ELSE  
                   UPDATE tblPublicActivityLog SET pageView = (pageView + 1), date = GETDATE() WHERE (pID = @pID) AND (site = @site) AND ((datediff(dd, getdate(), date) > -1))  
                  END  
                 ELSE -- new entry  
                  INSERT tblPublicActivityLog VALUES(@pID, @acID, GETDATE(), 1, @site)  
  
                 -- now take care of tblPublicActivityTotal  
                -- SET @lastDateStamp = (SELECT top 1 pid from tblPublicActivityLog where (pid = @pID) order by date desc)  
  
                 SET @pIDInTotal = (SELECT pid from tblPublicActivityLogTotal where (pid = @pID) )  
                 IF @pIDInTotal <> '' -- there is an entry  
                  UPDATE tblPublicActivityLogTotal SET total = (total + 1) WHERE pID = @pID  
                 ELSE -- new entry  
                  INSERT tblPublicActivityLogTotal VALUES(@pID, @acID, 1)";

                conn.Execute(query, new { pID = strPID, acID = strACID, site = "REIQ" });
            }
        }

        public static void InsertLog(string pid, string acID, string aid, string suburb, string email, string phone)
        {
            using (var conn = Data.CreateConnection())
            {
                string query = @"
                INSERT tblEnquiryLog  
                VALUES(@pID, @acID, @aID, @suburb, @email, @phone, GETDATE())";

                conn.Execute(query, new { pid = pid, acID = acID, aid = aid, suburb = suburb, email = email, phone = phone });
            }
        }
    }
}