using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using REIQ.Helpers;
using umbraco.NodeFactory;
using System.Configuration;

public partial class usercontrols_ContactAgency : System.Web.UI.UserControl
{
    #region Properties

    /// <summary>
    /// Id of the property we want to find the agent for.  Comes from the querystring
    /// </summary>
    protected int AgencyId
    {
        get
        {
            if (_agencyId == 0)
            {
                Int32.TryParse(Request.QueryString["acid"], out _agencyId);
            }
            return _agencyId;
        }
        set { _agencyId = value; }
    }
    private int _agencyId;

    /// <summary>
    /// The Agency itself
    /// </summary>
    protected REIQ.Entities.Agency Agency { get; set; }
    public String ToEmail = DataUtility.Encrypt(ConfigurationManager.AppSettings["adminemail"]);
    protected Node CurrentPage = null;
    public String RelatedThankYouPage = ConfigurationManager.AppSettings["DefaultThankYouPageURL"];
    public String AgencyName = String.Empty;

    #endregion

    #region Page Events

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Agency = REIQ.Access.Agency.GetFromAgencyId(this.AgencyId);

            if (Agency != null)
            {
                if (Agency.email != null && !String.IsNullOrEmpty(Agency.email)) ToEmail = DataUtility.Encrypt(Agency.email);
                if (Agency.name != null && !String.IsNullOrEmpty(Agency.name)) AgencyName = Agency.name;

                CurrentPage = Node.GetCurrent();

                if (CurrentPage.GetProperty("relatedThankYouPage") != null && !String.IsNullOrEmpty(CurrentPage.GetProperty("relatedThankYouPage").Value))
                {
                    Int32 relatedThankYouPageID = Convert.ToInt32(CurrentPage.GetProperty("relatedThankYouPage").Value);
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
    //            string toEmail = Agency.email;
    //            string agencyName = Agency.name;

    //            string strBody = "";

    //            strBody = strBody + "<br>To " + agencyName + "<br><br>";
    //            strBody = strBody + "<font style='color:#c0143c'>RE: WEB ENQUIRY</font><br><br>";
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
    //            strBody = strBody + "<td valign='top'>Comments: </td>";
    //            strBody = strBody + "<td >" + txtComments.Text + "</td>";
    //            strBody = strBody + "</tr>";
    //            strBody = strBody + "</table>";

    //            strBody = strBody + "<br><br><font style='color:#c0143c'>PLEASE HIT 'REPLY' TO RESPOND DIRECTLY TO THIS ENQUIRY.</font><br><br>";

    //            strBody = AgencyHelper.GetEmailBox(strBody);

    //            AutoMail.Mail_Send(txtEmail.Text, toEmail, "Web Enquiry from REIQ", strBody);

    //            //prop.insertLog(prop.pid, prop.acid, prop.aid1.ToString(), prop.strSuburb, txtEmail.Text, txtPhone.Text);

    //            lblMsg.Visible = true;
    //            ContactUs.Visible = false;

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

    protected String GetHeading()
    {
        if (CurrentPage.GetProperty("contactAgencyFormHeader") != null)
        {
            if (!String.IsNullOrEmpty(CurrentPage.GetProperty("contactAgencyFormHeader").Value))
                return CurrentPage.GetProperty("contactAgencyFormHeader").Value.ToUpper();
        }

        return "CONTACT US";
    }

    #endregion
}