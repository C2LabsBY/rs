using REIQ.Helpers;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.SessionState;

/// <summary>
/// Сводное описание для SendEmailFromEnquireForm
/// </summary>
namespace REIQ.Handlers
{
    public class SendEmailFromEnquireForm : IHttpHandler, IRequiresSessionState
    {
        protected REIQ.Entities.Property Property { get; set; }
        protected REIQ.Entities.Agent DefaultAgent { get; set; }
        protected REIQ.Entities.Agent Agent1 { get; set; }
        protected REIQ.Entities.Agent Agent2 { get; set; }
        protected REIQ.Entities.Agent Agent3 { get; set; }
        protected REIQ.Entities.Agency Agency { get; set; }
        protected String Region { get; set; }

        public SendEmailFromEnquireForm()
        {
            //
            // TODO: добавьте логику конструктора
            //
        }

        public bool IsReusable
        {
            get { return true; }
        }

        public void ProcessRequest(HttpContext context)
        {
            String txtName = context.Request["txtName"];
            String txtPhone = context.Request["txtPhone"];
            String txtEmail = context.Request["txtEmail"];
            String txtComments = context.Request["txtComments"];
            String txtCode = context.Request["txtCode"];
            String toEmail = ConfigurationManager.AppSettings["adminemail"]; 
            String currentPageName = context.Request["currentPageName"];
            String replyBy = context.Request["replyBy"];
            String toKnow = context.Request["toKnow"];
            int propertyId = Convert.ToInt32(context.Request["propertyId"]);
            String link = DataUtility.Decrypt(context.Request["link"]);

            REIQ.Entities.Property Property = REIQ.Access.Property.GetFromPropertyId(propertyId);
            DefaultAgent = REIQ.Access.Agent.GetFromPropertyId(propertyId);
            Agency = REIQ.Access.Agency.GetFromPropertyId(propertyId);
            Region = REIQ.Access.Property.GetPropertyRegion(propertyId);

            String capthcaImageText = String.Empty;
            if (context.Session["CaptchaImageText"] != null) capthcaImageText = context.Session["CaptchaImageText"].ToString();

            context.Response.ContentType = "text/html";

            if (String.IsNullOrEmpty(txtCode) || txtCode != capthcaImageText)
            {
                context.Response.Write("captchaFail");
            }
            else
            {
                string agentNames = String.Empty;

                //Trying to get all associated agents emails
                if (Property.aID1 != null)
                {
                    Agent1 = REIQ.Access.Agent.GetFromAgentId((int)Property.aID1);
                    if (Agent1 != null)
                    {
                        toEmail = Agent1.email;
                        agentNames = Agent1.firstname + " " + Agent1.surname;
                    }
                }

                if (Property.aID2 != null)
                {
                    Agent2 = REIQ.Access.Agent.GetFromAgentId((int)Property.aID2);
                    if (Agent2 != null)
                    {
                        if (!String.IsNullOrEmpty(Agent2.email)) toEmail += ", " + Agent2.email;
                        agentNames = ", " + Agent2.firstname + " " + Agent2.surname;
                    }
                }

                if (Property.aID3 != null)
                {
                    Agent3 = REIQ.Access.Agent.GetFromAgentId((int)Property.aID3);
                    if (Agent3 != null)
                    {
                        if (!String.IsNullOrEmpty(Agent3.email)) toEmail += ", " + Agent3.email;
                        agentNames = ", " + Agent3.firstname + " " + Agent3.surname;
                    }
                }

                //If no associated agents - then try get associated agency
                if (string.IsNullOrEmpty(toEmail))
                {
                    if (Agency != null)
                        toEmail = Agency.email;
                }

                //If still nothing associated - send error message. 
                if (string.IsNullOrEmpty(toEmail))
                {
                    AutoMail.sendErrorMail(new Exception("No email found for propertyID:" + propertyId));
                }

                string strlink = link;
                string strprice = PropertyHelper.GetPropertyPrice(Property);
                string address = PropertyHelper.GetAddress(Property);

                string strBody = "";

                strBody = strBody + "To " + agentNames + "<br><br>";
                strBody = strBody + "<font style='color:#c0143c'>RE: WEB ENQUIRY FOR " + address + "</font><br><br>";
                strBody = strBody + "<b>Please find below an enquiry from reiq.com</b><br><br>";

                strBody = strBody + "<table width=650 border=0>";
                strBody = strBody + "<tr>";
                strBody = strBody + "<td width=250>From: </td>";
                strBody = strBody + "<td >" + txtName + "</td>";
                strBody = strBody + "</tr>";
                strBody = strBody + "<tr>";
                strBody = strBody + "<tr>";
                strBody = strBody + "<td>Email: </td>";
                strBody = strBody + "<td>" + txtEmail + "</td>";
                strBody = strBody + "</tr>";
                strBody = strBody + "<tr>";
                strBody = strBody + "<td>Phone: </td>";
                strBody = strBody + "<td>" + txtPhone + "</td>";
                strBody = strBody + "</tr>";
                strBody = strBody + "<tr>";
                strBody = strBody + "<td>Preferred Contact: </td>";
                strBody = strBody + "<td>" + replyBy + "</td>";
                strBody = strBody + "</tr>";
                strBody = strBody + "<tr>";
                strBody = strBody + "<td>Date of enquiry: </td>";
                strBody = strBody + "<td>" + DateTime.Now.ToLongDateString() + "</td>";
                strBody = strBody + "</tr>";
                strBody = strBody + "<tr>";
                strBody = strBody + "<td>Would like to request information on: </td>";
                strBody = strBody + "<td>" + toKnow + "</td>";
                strBody = strBody + "</tr>";
                strBody = strBody + "<tr>";
                strBody = strBody + "<td valign='top'>Comments: </td>";
                strBody = strBody + "<td >" + txtComments + "</td>";
                strBody = strBody + "</tr>";
                strBody = strBody + "</table>";

                strBody = strBody + "<br><br><font style='color:#c0143c'>PLEASE HIT 'REPLY' TO RESPOND DIRECTLY TO THIS ENQUIRY.</font><br><br>";

                strBody = strBody + "<table border='0' width='650'>";
                strBody = strBody + "<tr>";
                strBody = strBody + "<td valign='top'><a href='" + strlink + "'>" + PropertyHelper.GetSearchImageUrl(Property.pID.ToString(), Property.hasPhotoLarge, Property.type, address, Property.status, strprice, "106", "70") + "</a></td>";
                strBody = strBody + "<td width='10'></td>";
                strBody = strBody + "<td valign='top' align='left'>";
                strBody = strBody + "<table cellpadding='0' cellspacing='0' border='0' width='100%'>";
                strBody = strBody + "<tr>";
                strBody = strBody + "<td colspan='2' align='left' class='txtAddress' height='25' valign='top'>" + address.ToUpper() + "&nbsp;<span class='newly'>" + Property.type + "</span>  &nbsp;" + PropertyHelper.GetFurnished(Property.isFurnished) + "" + PropertyHelper.GetNewlyAdded(Property.dateListed == null ? DateTime.MinValue : (DateTime)Property.dateListed) + "" + getstatus(Property.status) + "</span></td>";
                strBody = strBody + "</tr>";
                strBody = strBody + "<tr height='20'><td colspan='2' style='color:#595a5f;' valign='top'><b>" + Property.descriptionShort + "</b></td></tr>";
                strBody = strBody + "<tr>";
                strBody = strBody + "<td colspan='2' align='left'>";
                strBody = strBody + PropertyHelper.GetShortDescription(Property.descriptionLong, 120) + "...<br />   ";
                strBody = strBody + PropertyHelper.GetAuctionFormat(Property.auctionDate == null ? String.Empty : Property.auctionDate.ToString(), Property.auctionTime);
                strBody = strBody + "</td>";
                strBody = strBody + "</tr>";
                strBody = strBody + checkHomeOpen(PropertyHelper.GetHomeOpensFormat_New(Property.homeopen1From.ToString(), Property.homeopen1To.ToString(), Property.homeopen2From.ToString(), Property.homeopen2To.ToString()));
                strBody = strBody + "<tr height='20'><td  colspan='2'><b><span class='txtPink14'>" + strprice + "</span> | <span class='txtPink'>Property Type: " + Property.type + "</span></b></td></tr>";
                strBody = strBody + "</table>";
                strBody = strBody + "<a href='" + strlink + "' ><img name='btn_view_more2' src='images/btn_view_more.jpg' onMouseOver='this.src='images/btn_view_more_f2.jpg''  onMouseOut='this.src='images/btn_view_more.jpg''/></a>";
                strBody = strBody + "</td>";
                strBody = strBody + "<td valign='top' width='200' align='right'>";
                strBody = strBody + PropertyHelper.GetDisplaySearchFeaturesSmall(Property.numBedrooms.ToString(), Property.numBathrooms.ToString(), Property.numCarbays.ToString(), Property.numStudy.ToString(), Property.hasPool.ToString(), Property.numGarage.ToString());
                strBody = strBody + "<br />";
                if (Agency != null)
                {
                    strBody = strBody + Images.GetAgencyImage(Agency.acID, 196, 88);
                    strBody = strBody + "<br /><br />";
                }
                if (DefaultAgent != null) strBody = strBody + PropertyHelper.GetAgentData(DefaultAgent, Property.pID);
                strBody = strBody + "</td>";
                strBody = strBody + "</tr>";
                strBody = strBody + "</table>";

                strBody = PropertyHelper.GetEmailbox(strBody);

                string sub = "";
                if (address != null)
                    sub = "Web Enquiry for " + address.Replace("<b>", "").Replace("</b>", "") + "  from REIQ";
                else
                    sub = "Web Enquiry for from REIQ";

                try
                {
                    AutoMail.Mail_Send(txtEmail, toEmail, sub, strBody);

                    LogHelper.InsertLog(Property.pID.ToString(), Property.acID.ToString(), Property.aID1.ToString(), Property.suburb, txtEmail, txtPhone);

                    context.Response.Write("true");
                }
                catch (Exception ex)
                {
                    AutoMail.sendErrorMail(ex);
                    context.Response.Write(ex.Message);
                }
            }
        }

        private string getstatus(string status)
        {
            if (status.ToLower() == "under offer")
            {
                return "<span class='newlyred'>under offer</span>";
            }
            if (status.ToLower() == "sold")
            {
                return "<span class='newlyred'>sold</span>";
            }
            return "";
        }

        private string checkHomeOpen(string strHomeOpen)
        {
            if (strHomeOpen.Trim() != "")
            {
                return "<tr height=\"20\"><td colspan=\"2\"><font color='red'><b>" + strHomeOpen + "</b></font></td></tr>";
            }
            else
            {
                return "";
            }
        }
    }
}