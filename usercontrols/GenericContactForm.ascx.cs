using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using REIQ.Helpers;
using umbraco.NodeFactory;

public partial class usercontrols_GenericContactForm : System.Web.UI.UserControl
{
    #region Properties

    protected Node CurrentPage = null;
    public String ToEmail = ConfigurationManager.AppSettings["adminemail"];
    public String RelatedThankYouPage = ConfigurationManager.AppSettings["DefaultThankYouPageURL"];
    
    #endregion

    #region Page Events

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            CurrentPage = Node.GetCurrent();

            if (CurrentPage.GetProperty("showContactForm") == null)
                return;

            if (CurrentPage.GetProperty("showContactForm").Value != "1")
                return;
            else
            {
                ContactForm.Visible = true;

                if (CurrentPage.GetProperty("contactFormEmailAddress") != null && !String.IsNullOrEmpty(CurrentPage.GetProperty("contactFormEmailAddress").Value))
                {
                    Int32 emailAddressNodeID = Convert.ToInt32(CurrentPage.GetProperty("contactFormEmailAddress").Value);
                    if (emailAddressNodeID > 0)
                    {
                        Node emailAddressNode = new Node(emailAddressNodeID);

                        if (emailAddressNode != null)
                        {
                            if (emailAddressNode.GetProperty("emailAddress") != null && !String.IsNullOrEmpty(emailAddressNode.GetProperty("emailAddress").Value))
                            {
                                ToEmail = DataUtility.Encrypt(emailAddressNode.GetProperty("emailAddress").Value);
                            }
                            if (emailAddressNode.GetProperty("relatedThankYouPage") != null && !String.IsNullOrEmpty(emailAddressNode.GetProperty("relatedThankYouPage").Value))
                            {
                                Int32 relatedThankYouPageID = Convert.ToInt32(emailAddressNode.GetProperty("relatedThankYouPage").Value);
                                if (relatedThankYouPageID > 0)
                                {
                                    Node relatedThankYouPageNode = new Node(relatedThankYouPageID);
                                    if (relatedThankYouPageNode != null)
                                    {
                                        RelatedThankYouPage = relatedThankYouPageNode.Url;
                                    }
                                }
                            }
                        }
                    }
                }
            }   
        }
        catch (Exception ex)
        {
            AutoMail.sendErrorMail(ex);
        }
    }

    //protected void btnSend_Click(object sender, EventArgs e)
    //{
    //    String capthcaImageText = String.Empty;
    //    if (Session["CaptchaImageText"] != null) capthcaImageText = Session["CaptchaImageText"].ToString();

    //    if (String.IsNullOrEmpty(txtCode.Text) || txtCode.Text != capthcaImageText)
    //    {
    //        lblError.Visible = true;
    //        lblError.Text = "**The code entered did not match the image, please try again.";
    //    }
    //    else
    //    {
    //        try
    //        {
    //            Node redirectTo = null;
    //            string toEmail = ConfigurationManager.AppSettings["adminemail"];
    //            if (!String.IsNullOrEmpty(CurrentPage.GetProperty("contactFormEmailAddress").Value))
    //            {
    //                Int32 emailAddressNodeID = Convert.ToInt32(CurrentPage.GetProperty("contactFormEmailAddress").Value);
    //                if (emailAddressNodeID > 0)
    //                {
    //                    Node emailAddressNode = new Node(emailAddressNodeID);
    //                    //toEmail = new Node(emailAddressNodeID).GetProperty("emailAddress").Value;
                        
    //                    toEmail = emailAddressNode.GetProperty("emailAddress").Value;
    //                    if (emailAddressNode.GetProperty("relatedThankYouPage") != null && !String.IsNullOrEmpty(emailAddressNode.GetProperty("relatedThankYouPage").Value))
    //                    {
    //                        redirectTo = new Node(Convert.ToInt32(emailAddressNode.GetProperty("relatedThankYouPage").Value));
    //                    }
    //                }
    //            }
    //            //string recipientName = Agency.name;

    //            string strBody = "";

    //            //strBody = strBody + "<br>To " + agencyName + "<br><br>";
    //            strBody = strBody + "<font style='color:#c0143c'>The form on " + CurrentPage.Name + " was submitted</font><br><br>";
    //            strBody = strBody + "<b>Please find below an enquiry from reiq.com</b><br><br>";

    //            strBody = strBody + "<table width=600 border=0>";
    //            strBody = strBody + "<tr>";
    //            strBody = strBody + "<td width=150>From: </td>";
    //            strBody = strBody + "<td width=450>" + txtName.Text + "</td>";
    //            strBody = strBody + "</tr>";
    //            strBody = strBody + "<tr>";
    //            strBody = strBody + "<tr>";
    //            strBody = strBody + "<td>Email: </td>";
    //            strBody = strBody + "<td>" + txtEmail.Text + "</td>";
    //            strBody = strBody + "</tr>";
    //            strBody = strBody + "<tr>";
    //            strBody = strBody + "<td>Phone: </td>";
    //            strBody = strBody + "<td>" + txtPhone.Text + "</td>";
    //            strBody = strBody + "</tr>";
    //            strBody = strBody + "<tr>";
    //            strBody = strBody + "<td>Date of enquiry: </td>";
    //            strBody = strBody + "<td>" + DateTime.Now.ToLongDateString() + "</td>";
    //            strBody = strBody + "</tr>";
    //            strBody = strBody + "<tr>";
    //            strBody = strBody + "<td valign='top'>Message: </td>";
    //            strBody = strBody + "<td >" + txtComments.Text + "</td>";
    //            strBody = strBody + "</tr>";
    //            strBody = strBody + "</table>";

    //            strBody = strBody + "<br><br><font style='color:#c0143c'>PLEASE HIT 'REPLY' TO RESPOND DIRECTLY TO THIS ENQUIRY.</font><br><br>";

    //            strBody = AgencyHelper.GetEmailBox(strBody);

    //            //AutoMail.Mail_Send(txtEmail.Text, toEmail, "Web Enquiry from REIQ", strBody);

    //            //prop.insertLog(prop.pid, prop.acid, prop.aid1.ToString(), prop.strSuburb, txtEmail.Text, txtPhone.Text);
                
    //            if (redirectTo == null)
    //            {
    //                lblMsg.Visible = true;
    //                ContactUs.Visible = false;
    //            }
    //            else Response.Redirect(redirectTo.Url);
    //        }
    //        catch (Exception ex)
    //        {
    //            lblMsg.Visible = true;
    //            ContactUs.Visible = false;

    //            lblMsg.Text = ex.Message;

    //            AutoMail.sendErrorMail(ex);
    //        }
    //    }
    //}

    #endregion

    #region Page Methods

    protected String GetHeading()
    {
        if (!String.IsNullOrEmpty(CurrentPage.GetProperty("contactFormHeader").Value))
            return CurrentPage.GetProperty("contactFormHeader").Value.ToUpper();
        else return "CONTACT US";
    }

    #endregion
}