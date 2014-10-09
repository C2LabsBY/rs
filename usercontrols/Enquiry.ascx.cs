using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using REIQ.Helpers;
using umbraco.NodeFactory;

public partial class usercontrols_Enquiry : REIQ.usercontrols.PropertySearchBase
{
    #region Properties

    /// <summary>
    /// Id of the property we want to find the agent for.  Comes from the querystring
    /// </summary>
    protected int PropertyId
    {
        get
        {
            if (_propertyId == 0)
            {
                Int32.TryParse(Request.QueryString["pID"], out _propertyId);
            }
            return _propertyId;
        }
        set { _propertyId = value; }
    }
    private int _propertyId;

    /// <summary>
    /// The Property itself
    /// </summary>
    protected REIQ.Entities.Property Property { get; set; }
    
    /// <summary>
    /// The Agent of the property
    /// </summary>
    protected REIQ.Entities.Agent DefaultAgent { get; set; }
    protected REIQ.Entities.Agent Agent1 { get; set; }
    protected REIQ.Entities.Agent Agent2 { get; set; }
    protected REIQ.Entities.Agent Agent3 { get; set; }

    /// <summary>
    /// Agency of the property
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected REIQ.Entities.Agency Agency { get; set; }
    public String CurrentUrl { get; set; }
    /// <summary>
    /// Region of the property
    /// </summary>
    protected String Region { get; set; }

    protected Node CurrentPage = null;
    public String RelatedThankYouPage = ConfigurationManager.AppSettings["DefaultThankYouPageURL"];    

    #endregion

    #region Page Events

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Property = REIQ.Access.Property.GetFromPropertyId(this.PropertyId);

            if (Property != null)
            {
                DefaultAgent = REIQ.Access.Agent.GetFromPropertyId(Property.pID);
                Agency = REIQ.Access.Agency.GetFromPropertyId(this.PropertyId);
                Region = REIQ.Access.Property.GetPropertyRegion(Property.pID);

                CurrentPage = Node.GetCurrent();
                CurrentUrl = DataUtility.Encrypt("http://" + Request.Url.Host + Request.RawUrl);

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

        if (Property == null) btnSend.Enabled = false;
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
    //        string toEmail = String.Empty;
    //        string agentNames = String.Empty; 

    //        //Trying to get all associated agents emails
    //        if (Property.aID1 != null)
    //        {
    //            Agent1 = REIQ.Access.Agent.GetFromAgentId((int)Property.aID1);
    //            if (Agent1 != null)
    //            {
    //                toEmail = Agent1.email;
    //                agentNames = Agent1.firstname + " " + Agent1.surname;
    //            }
    //        }

    //        if (Property.aID2 != null)
    //        {
    //            Agent2 = REIQ.Access.Agent.GetFromAgentId((int)Property.aID2);
    //            if (Agent2 != null)
    //            {
    //                toEmail += ", " + Agent2.email;
    //                agentNames = ", " + Agent2.firstname + " " + Agent2.surname;
    //            }
    //        }

    //        if (Property.aID3 != null)
    //        {
    //            Agent3 = REIQ.Access.Agent.GetFromAgentId((int)Property.aID3);
    //            if (Agent3 != null)
    //            {
    //                toEmail += ", " + Agent3.email;
    //                agentNames = ", " + Agent3.firstname + " " + Agent3.surname;
    //            }
    //        }

    //        //If no associated agents - then try get associated agency
    //        if (string.IsNullOrEmpty(toEmail))
    //        {
    //            if (Agency != null)
    //                toEmail = Agency.email;
    //        }

    //        //If still nothing associated - send error message. 
    //        if (string.IsNullOrEmpty(toEmail))
    //        {
    //            AutoMail.sendErrorMail(new Exception("No email found for propertyID:" + this.PropertyId));
    //        }

    //        string strlink = PropertyHelper.GenerateURL(Property.suburb, Property.pID.ToString(), Property.type, Property.status, ParamSearchType, Region);
    //        string strprice = PropertyHelper.GetPropertyPrice(Property);
    //        string address = PropertyHelper.GetAddress(Property);

    //        string strBody = "";

    //        strBody = strBody + "To " + agentNames + "<br><br>";
    //        strBody = strBody + "<font style='color:#c0143c'>RE: WEB ENQUIRY FOR " + address + "</font><br><br>";
    //        strBody = strBody + "<b>Please find below an enquiry from reiq.com</b><br><br>";

    //        strBody = strBody + "<table width=650 border=0>";
    //        strBody = strBody + "<tr>";
    //        strBody = strBody + "<td width=250>From: </td>";
    //        strBody = strBody + "<td >" + txtName.Text + "</td>";
    //        strBody = strBody + "</tr>";
    //        strBody = strBody + "<tr>";
    //        strBody = strBody + "<tr>";
    //        strBody = strBody + "<td>Email: </td>";
    //        strBody = strBody + "<td>" + txtEmail.Text + "</td>";
    //        strBody = strBody + "</tr>";
    //        strBody = strBody + "<tr>";
    //        strBody = strBody + "<td>Phone: </td>";
    //        strBody = strBody + "<td>" + txtPhone.Text + "</td>";
    //        strBody = strBody + "</tr>";
    //        strBody = strBody + "<tr>";
    //        strBody = strBody + "<td>Preferred Contact: </td>";
    //        strBody = strBody + "<td>" + cboReplyBy.SelectedItem.Value + "</td>";
    //        strBody = strBody + "</tr>";
    //        strBody = strBody + "<tr>";
    //        strBody = strBody + "<td>Date of enquiry: </td>";
    //        strBody = strBody + "<td>" + DateTime.Now.ToLongDateString() + "</td>";
    //        strBody = strBody + "</tr>";
    //        strBody = strBody + "<tr>";
    //        strBody = strBody + "<td>Would like to request information on: </td>";
    //        strBody = strBody + "<td>" + cboEnqType.SelectedItem.Value + "</td>";
    //        strBody = strBody + "</tr>";
    //        strBody = strBody + "<tr>";
    //        strBody = strBody + "<td valign='top'>Comments: </td>";
    //        strBody = strBody + "<td >" + txtComments.Text + "</td>";
    //        strBody = strBody + "</tr>";
    //        strBody = strBody + "</table>";

    //        strBody = strBody + "<br><br><font style='color:#c0143c'>PLEASE HIT 'REPLY' TO RESPOND DIRECTLY TO THIS ENQUIRY.</font><br><br>";



    //        strBody = strBody + "<table border='0' width='650'>";
    //        strBody = strBody + "<tr>";
    //        strBody = strBody + "<td valign='top'><a href='" + strlink + "'>" + PropertyHelper.GetSearchImageUrl(Property.pID.ToString(), Property.hasPhotoLarge, Property.type, address, Property.status, strprice, "106", "70") + "</a></td>";
    //        strBody = strBody + "<td width='10'></td>";
    //        strBody = strBody + "<td valign='top' align='left'>";
    //        strBody = strBody + "<table cellpadding='0' cellspacing='0' border='0' width='100%'>";
    //        strBody = strBody + "<tr>";
    //        strBody = strBody + "<td colspan='2' align='left' class='txtAddress' height='25' valign='top'>" + address.ToUpper() + "&nbsp;<span class='newly'>" + Property.type + "</span>  &nbsp;" + PropertyHelper.GetFurnished(Property.isFurnished) + "" + PropertyHelper.GetNewlyAdded(Property.dateListed == null ? DateTime.MinValue : (DateTime)Property.dateListed) + "" + getstatus(Property.status) + "</span></td>";
    //        strBody = strBody + "</tr>";
    //        strBody = strBody + "<tr height='20'><td colspan='2' style='color:#595a5f;' valign='top'><b>" + Property.descriptionShort + "</b></td></tr>";
    //        strBody = strBody + "<tr>";
    //        strBody = strBody + "<td colspan='2' align='left'>";
    //        strBody = strBody + PropertyHelper.GetShortDescription(Property.descriptionLong, 120) + "...<br />   ";
    //        strBody = strBody + PropertyHelper.GetAuctionFormat(Property.auctionDate == null ? String.Empty : Property.auctionDate.ToString(), Property.auctionTime);
    //        strBody = strBody + "</td>";
    //        strBody = strBody + "</tr>";
    //        strBody = strBody + checkHomeOpen(PropertyHelper.GetHomeOpensFormat_New(Property.homeopen1From.ToString(), Property.homeopen1To.ToString(), Property.homeopen2From.ToString(), Property.homeopen2To.ToString()));
    //        strBody = strBody + "<tr height='20'><td  colspan='2'><b><span class='txtPink14'>" + strprice + "</span> | <span class='txtPink'>Property Type: " + Property.type + "</span></b></td></tr>";
    //        strBody = strBody + "</table>";
    //        strBody = strBody + "<a href='" + strlink + "' ><img name='btn_view_more2' src='images/btn_view_more.jpg' onMouseOver='this.src='images/btn_view_more_f2.jpg''  onMouseOut='this.src='images/btn_view_more.jpg''/></a>";
    //        strBody = strBody + "</td>";
    //        strBody = strBody + "<td valign='top' width='200' align='right'>";
    //        strBody = strBody + PropertyHelper.GetDisplaySearchFeaturesSmall(Property.numBedrooms.ToString(), Property.numBathrooms.ToString(), Property.numCarbays.ToString(), Property.numStudy.ToString(), Property.hasPool.ToString(), Property.numGarage.ToString());
    //        strBody = strBody + "<br />";
    //        if (Agency != null)
    //        {
    //            strBody = strBody + Images.GetAgencyImage(Agency.acID, 196, 88);
    //            strBody = strBody + "<br /><br />";
    //        }
    //        if (DefaultAgent != null) strBody = strBody + PropertyHelper.GetAgentData(DefaultAgent, Property.pID);
    //        strBody = strBody + "</td>";
    //        strBody = strBody + "</tr>";
    //        strBody = strBody + "</table>";

    //        strBody = PropertyHelper.GetEmailbox(strBody);

    //        string sub = "";
    //        if (address != null)
    //            sub = "Web Enquiry for " + address.Replace("<b>", "").Replace("</b>", "") + "  from REIQ";
    //        else
    //            sub = "Web Enquiry for from REIQ";

    //        try
    //        {
    //            AutoMail.Mail_Send(txtEmail.Text, toEmail, sub, strBody);

    //            LogHelper.InsertLog(Property.pID.ToString(), Property.acID.ToString(), Property.aID1.ToString(), Property.suburb, txtEmail.Text, txtPhone.Text);

    //            if (ConfigurationManager.AppSettings["DefaultThankYouPageURL"] == null)
    //            {
    //                lblMsg.Visible = true;
    //                EnquiryForm.Visible = false;
    //            }
    //            else Response.Redirect(ConfigurationManager.AppSettings["DefaultThankYouPageURL"], true);
    //        }
    //        catch (Exception ex)
    //        {
    //            lblMsg.Visible = true;
    //            EnquiryForm.Visible = false;

    //            lblMsg.Text = ex.Message;

    //            AutoMail.sendErrorMail(ex);
    //        }
    //    }
    //}

    #endregion

    #region Page Methods

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

    protected String GetHeading()
    {
        if (!String.IsNullOrEmpty(CurrentPage.GetProperty("enquireFormHeader").Value))
            return CurrentPage.GetProperty("enquireFormHeader").Value.ToUpper();
        else return "ENQUIRE ABOUT THIS PROPERTY";
    }

    #endregion
}