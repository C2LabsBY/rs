using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using REIQ.Helpers;
using umbraco.presentation.nodeFactory;
using System.Web.Script.Serialization;

/// <summary>
/// Сводное описание для SendEmailFromContactForm
/// </summary>
namespace REIQ.Handlers
{
    public class SendEmailFromContactForm : IHttpHandler, IRequiresSessionState
    {
        public SendEmailFromContactForm()
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
            String toEmail = (!String.IsNullOrEmpty(context.Request["sendToEmail"]) ? DataUtility.Decrypt(context.Request["sendToEmail"]) : ConfigurationManager.AppSettings["adminemail"]);
            String currentPageName = context.Request["currentPageName"];

            String capthcaImageText = String.Empty;
            if (context.Session["CaptchaImageText"] != null) capthcaImageText = context.Session["CaptchaImageText"].ToString();

            context.Response.ContentType = "text/html";

            if (String.IsNullOrEmpty(txtCode) || txtCode != capthcaImageText)
            {
                context.Response.Write("captchaFail");
            }
            else
            {
                try
                {
                    string strBody = "";

                    //strBody = strBody + "<br>To " + agencyName + "<br><br>";
                    strBody = strBody + "<font style='color:#c0143c'>The form on " + currentPageName + " was submitted</font><br><br>";
                    strBody = strBody + "<b>Please find below an enquiry from reiq.com</b><br><br>";

                    strBody = strBody + "<table width=600 border=0>";
                    strBody = strBody + "<tr>";
                    strBody = strBody + "<td width=150>From: </td>";
                    strBody = strBody + "<td width=450>" + txtName + "</td>";
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
                    strBody = strBody + "<td>Date of enquiry: </td>";
                    strBody = strBody + "<td>" + DateTime.Now.ToLongDateString() + "</td>";
                    strBody = strBody + "</tr>";
                    strBody = strBody + "<tr>";
                    strBody = strBody + "<td valign='top'>Message: </td>";
                    strBody = strBody + "<td >" + txtComments + "</td>";
                    strBody = strBody + "</tr>";
                    strBody = strBody + "</table>";

                    strBody = strBody + "<br><br><font style='color:#c0143c'>PLEASE HIT 'REPLY' TO RESPOND DIRECTLY TO THIS ENQUIRY.</font><br><br>";

                    strBody = AgencyHelper.GetEmailBox(strBody);

                    AutoMail.Mail_Send(txtEmail, toEmail, "Web Enquiry from REIQ", strBody);
                    context.Response.Write("true");
                }
                catch (Exception ex)
                {
                    AutoMail.sendErrorMail(ex);
                    context.Response.Write(ex.Message);
                }
            }
        }
    }
}