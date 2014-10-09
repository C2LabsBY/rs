using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web;
using System.Net.Mail;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Text;
using System.Collections.Generic;
/// <summary>
/// Summary description for AutoMail
/// </summary>
public class AutoMail
{
    public static void Mail_Send(string replyTo, string mailto, string mailsubject, string mailmessage)
    {
        //Trying to fix Emails stuck in filters
        string mailfrom = "no-reply@reiq.com";

        //Create Mail Message Object with content that you want to send with mail.
        System.Net.Mail.MailMessage MyMailMessage =
            new System.Net.Mail.MailMessage(mailfrom, mailto, mailsubject, mailmessage);

        MyMailMessage.ReplyToList.Add(replyTo);
        MyMailMessage.IsBodyHtml = true;

        //Temporary: send duplicate to reiq acc
        System.Net.Mail.MailMessage BCCMessage =
            new System.Net.Mail.MailMessage(mailfrom, "reiqemail@gmail.com", mailsubject, mailmessage);

        BCCMessage.ReplyToList.Add(replyTo);
        BCCMessage.IsBodyHtml = true;

        System.Net.Mail.SmtpClient mailClient = new System.Net.Mail.SmtpClient("127.0.0.1");

        mailClient.Send(MyMailMessage);
        mailClient.Send(BCCMessage);
    }

    public static void Mail_SendBcc(string mailfrom, string mailto, string mailtoBCC, string mailsubject, string mailmessage)
    {        
	 if (checkblocklist(mailfrom, HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"]) && checkblocklist(mailto, HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"]))
        {
        MailMessage message = new MailMessage(mailfrom, mailto, mailsubject, mailmessage);
        message.IsBodyHtml = true;
        message.Bcc.Add(mailtoBCC);
        SmtpClient emailClient = new SmtpClient(ConfigurationManager.AppSettings["SmtpIpAddress"]);
        try
        {
            emailClient.Send(message);
        }
        catch (Exception err)
        { }
		
		}

    }
    public static void Mail_SendCc(string mailfrom, string mailto, string mailtoCC, string mailsubject, string mailmessage)
    {        
	 if (checkblocklist(mailfrom, HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"]) && checkblocklist(mailto, HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"]))
        {
        MailMessage message = new MailMessage(mailfrom, mailto, mailsubject, mailmessage);
        message.IsBodyHtml = true;
        message.CC.Add(mailtoCC);
        SmtpClient emailClient = new SmtpClient(ConfigurationManager.AppSettings["SmtpIpAddress"]);
        try
        {
            emailClient.Send(message);
        }
        catch (Exception err)
        { }
}
    }
    public static void Mail_SendAttach(string mailfrom, string mailto, string mailsubject, string mailmessage, FileUpload file)
    {        
	 if (checkblocklist(mailfrom, HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"]) && checkblocklist(mailto, HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"]))
        {
        MailMessage message = new MailMessage(mailfrom, mailto, mailsubject, mailmessage);
        message.IsBodyHtml = true;
        SmtpClient emailClient = new SmtpClient(ConfigurationManager.AppSettings["SmtpIpAddress"]);
        if (file.HasFile)
        {
            message.Attachments.Add(new Attachment(file.PostedFile.InputStream, file.FileName));
        }

        try
        {
            emailClient.Send(message);
        }
        catch (Exception err)
        { }
		}
    }
    public static void sendErrorMail(Exception ex)
    {
        try
        {
            //Mail_Send("test@vibetechindia.com", "rakesh.agrawal@vibetechindia.com", "Error in REIQ " + ex.Message + " in " + HttpContext.Current.Request.RawUrl, ex.StackTrace);            
        }
        catch (Exception err)
        { }
    }
	
	 public static bool checkblocklist(string email,string ip)
    {
        List<string> blockedemaillist = new List<string>();
        blockedemaillist.Add("ronthetowelguy@bellsouth.net");
        blockedemaillist.Add("thecraftbegins@gmail.com");
        blockedemaillist.Add("side@effects.of");
        blockedemaillist.Add("mlady@yahoo.com");
        blockedemaillist.Add("mjonassaint@hallmarkhealth.org");

        List<string> blockediplist = new List<string>();
        blockediplist.Add("69.89.160.5");

        if (blockedemaillist.Contains(email.ToLower()))
        {
            return false;
        }
        else if (blockediplist.Contains(ip.ToLower()))
        {
            return false;
        }
        return true;
    }

}
