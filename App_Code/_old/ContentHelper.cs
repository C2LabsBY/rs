using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Provides additional hardcoded content for the CMS pages
/// </summary>
public class ContentHelper
{
    public static string getPageTitleFromPageUrl(string pageUrl)
    {
        pageUrl = pageUrl.Replace("_and_", " & ");
        pageUrl = pageUrl.Replace("_", " ");
        pageUrl = pageUrl.Replace("`", "'");

        if (pageUrl.ToLower() == "conveyancing selling")
            pageUrl = "Conveyancing";

        if (pageUrl.ToLower() == "reiqdotcom advertising")
        {
            pageUrl = "Reiq.com";
        }

        if (pageUrl.ToLower() == "realtor magazine")
        {
            pageUrl = "Realtor magazines";
        }

        if (pageUrl.ToLower() == "events & training sponsorship")
        {
            pageUrl = "Events & training";
        }

        return pageUrl;
    }


    private static string getFootertable(string url, string image, string text, bool istarggetblank)
    {
        string str = "";
        str += "<td>";
        str += "<table class='ShdwBoxContent' border='0' cellpadding='0' cellspacing='0'>";
        str += "<tr>";
        str += "<td width='105' align='right'><a " + (istarggetblank ? " target='_blank' " : "") + " href='" + url + "'><img src='images/" + image + "' /></a></td>";
        str += "<td width='20' align='center'><img src='images/dot_vertical.gif' height='65' /></td>";
        str += "<td align='left' width='200' class='rightSpace'>";
        str += "<a " + (istarggetblank ? " target='_blank' " : "") + " href='" + url + "'><h3 style='text-transform:uppercase;'>" + text + "</h3></a>";
        str += "</td>";
        str += "</tr>";
        str += "</table>";
        str += "</td>";

        return str;
    }

    public static string getfooterhtml(string pageurl)
    {
        string strinsturl = "http://institute.reiq.com/";
        string str = "<tr><td height='10px'></td></tr>";
        str += "<tr><td><hr /></td></tr>";
        str += "<tr><td height='10px'></td></tr>";
        str += "<tr><td>";
        str += "<table width='100%'>";

        switch (pageurl.ToLower().Trim())
        {
            case "advertise_with_us":
                str += "<tr>";
                str += getFootertable("Content.aspx?page=REIQ_Journal", "REIQ_Ad_RJ.jpg", "REIQ Journal", false);
                str += getFootertable("Content.aspx?page=Reiqdotcom_advertising", "REIQ_Ad_dotcom.jpg", "Reiq.com", false);
                str += getFootertable("Content.aspx?page=Realtor_magazine", "REIQ_Ad_Realtor.jpg", "Realtor Magazines", false);

                str += "</tr>";
                str += "<tr>";
                str += getFootertable("Content.aspx?page=Member_Rewards_Program", "REIQ_Ad_rewards.jpg", "Member Rewards Program", false);
                str += getFootertable("Content.aspx?page=Corporate_sponsorship", "REIQ_about_sponsors.jpg", "Corporate Sponsorship", false);
                str += getFootertable("Content.aspx?page=Events_and_training_sponsorship", "REIQ_Ad_eventtraining.jpg", "Events & training", false);
                str += "</tr>";
                break;
            case "research":
                str += "<tr>";
                str += getFootertable(strinsturl + "REIQ/About_us/Publications/Queensland_Market_Monitor/REIQ/Consumer_information/Queensland_Market_Monitor.aspx", "REIQ_research_QMM.jpg", "Queensland Market Monitor", true);
                str += getFootertable("Suburbs.aspx", "REIQ_research_suburbprofiles.jpg", "Suburb profiles", false);
                str += getFootertable("suburbschart.aspx", "REIQ_research_charts.jpg", "Charts", true);
                str += "</tr>";
                str += "<tr>";
                str += getFootertable("calculators.aspx", "REIQ_research_calc.jpg", "Calculators", false);
                //str += getFootertable("#", "REIQ_research_PF.jpg", "PriceFinder", false);
                str += getFootertable(strinsturl + "REIQ/Consumer_information/Research_methodology.aspx", "REIQ_research_research.jpg", "Research methodology", true);
                str += getFootertable(strinsturl + "REIQ/MemberServices/Research/REIQ/Member_Services_Folder/Research.aspx", "REIQ_research_members.jpg", "Member-only resources", true);


                str += "</tr>";
                break;
            case "buying_and_selling_tips":
                str += "<tr>";
                str += getFootertable("Content.aspx?page=Steps_in_the_buying_process", "REIQ_buysell_stepsbuying.jpg", "Steps in the buying process", false);
                str += getFootertable("Content.aspx?page=Costs_of_buying", "REIQ_buysell_costsbuying.jpg", "Cost of buying", false);
                str += getFootertable("Content.aspx?page=First_home_owner`s_grant", "REIQ_buysell_firsthomeowners.jpg", "First home owner’s grant", false);
                str += "</tr>";

                str += "<tr>";
                str += getFootertable("Content.aspx?page=Steps_in_the_selling_process", "REIQ_buysell_stepsselling.jpg", "Steps in the selling process", false);
                str += getFootertable("Content.aspx?page=Costs_of_selling", "REIQ_buysell_costsselling.jpg", "Cost of selling", false);
                str += getFootertable("Content.aspx?page=Methods_of_selling", "REIQ_buysell_methodselling.jpg", "Methods of selling", false);
                str += "</tr>";

                str += "<tr>";
                str += getFootertable("Content.aspx?page=Investment_properties", "REIQ_buysell_investprop.jpg", "Investment properties", false);
                str += getFootertable("Content.aspx?page=Information_for_landlords", "REIQ_X_landlords.jpg", "Information for landlords", false);
                str += getFootertable("Content.aspx?page=Information_for_tenants", "REIQ_X_tenants.jpg", "Information for tenants", false);
                str += "</tr>";

                str += "<tr>";
                str += getFootertable("Content.aspx?page=Commercial_properties", "REIQ_buysell_commprop.jpg", "Commercial properties", false);
                str += getFootertable("Content.aspx?page=Research", "REIQ_buysell_marketresearch.jpg", "market research", false);
                str += getFootertable("Content.aspx?page=Useful_links", "REIQ_buysell_links.jpg", "Useful links", false);
                str += "</tr>";

                str += "<tr>";
                str += getFootertable("Content.aspx?page=Free_Buying_property_seminar", "REIQ_buysell_propertyseminar.jpg", "free buying property seminars", false);
                str += getFootertable("Content.aspx?page=Brisbane_flight_paths", "REIQ_flightpath.jpg", "Brisbane flight paths", false);
                str += "</tr>";
                break;
            case "about_us":
                str += "<tr>";
                str += getFootertable(strinsturl + "REIQ/About_us/Constitution/REIQ/About_us/Constitution.aspx", "REIQ_about_constitution.jpg", "Constitution & by-laws", true);
                str += getFootertable(strinsturl + "REIQ/About_us/Annual_Report/REIQ/About_us/Annual_Report.aspx", "REIQ_about_annualreport.jpg", "Annual report", true);
                str += getFootertable(strinsturl + "REIQ/About_us/Standards_of_Business_Practice/REIQ/About_us/Standards_of_Business_Practice.aspx", "REIQ_about_standards.jpg", "Standards of business practice", true);
                str += "</tr>";
                str += "<tr>";
                str += getFootertable(strinsturl + "REIQ/About_us/History/REIQ/About_us/History.aspx", "REIQ_about_history.jpg", "History", true);
                str += getFootertable(strinsturl + "REIQ/Membership/REIQ/Membership/Membership.aspx", "REIQ_about_membership.jpg", "Membership", true);
                str += getFootertable(strinsturl + "REIQ/About_us/REIQ_accredited_agencies/REIQ/About_us/REIQ_accredited_agencies.aspx", "REIQ_about_aa.jpg", "REIQ accredited agencies", true);
                str += "</tr>";
                str += "<tr>";
                str += getFootertable(strinsturl + "REIQ/About_us/Publications/REIQ/Consumer_information/Publications.aspx", "REIQ_about_pub.jpg", "Publications", true);
                str += getFootertable(strinsturl + "REIQ/About_us/Sponsors/REIQ/About_us/Sponsors.aspx", "REIQ_about_sponsors.jpg", "Sponsors", true);
                str += getFootertable(strinsturl + "REIQ/About_us/Awards_for_Excellence/REIQ/About_us/Awards_for_Excellence.aspx", "REIQ_about_awards.jpg", "Awards for excellence", true);
                str += "</tr>";
                str += "<tr>";
                str += getFootertable(strinsturl + "REIQ/About_us/Board_members/REIQ/About_us/Board_members.aspx", "REIQ_about_board.jpg", "Board members", true);
                str += getFootertable(strinsturl + "REIQ/About_us/Room_hire/REIQ/About_us/Room_hire.aspx", "REIQ_about_roomhire.jpg", "Room hire", true);
                str += getFootertable(strinsturl + "REIQ/About_us/Strategic_plan/REIQ/About_us/Strategic_plan.aspx", "REIQ_about_5yearplan.jpg", "STRATEGIC PLAN", true);
                str += "</tr>";
                break;
            case "real_estate_courses":
                str += "<tr>";
                str += getFootertable(strinsturl + "REIQ/Careers/Free_Introduction_to_Real_Estate_Sessions/REIQ/Careers___Training/Introduction_to_real_estate_sessions.aspx", "REIQ_courses_intro.jpg", "Free introduction to real estate sessions", true);
                str += getFootertable(strinsturl + "REIQ/Careers/Nationally_recognised_real_estate_courses/REIQ/Careers___Training/Real_estate_courses.aspx", "REIQ_courses_rpl.jpg", "Registration courses", true);
                str += getFootertable(strinsturl + "REIQ/Careers/Nationally_recognised_real_estate_courses/REIQ/Careers___Training/Real_estate_courses.aspx", "REIQ_courses_license.jpg", "Licensing courses", true);
                str += "</tr>";
                str += "<tr>";
                str += getFootertable(strinsturl + "REIQ/Careers/Specialised_courses/REIQ/Careers___Training/Specialised_courses.aspx", "REIQ_courses_specialised.jpg", "Specialised courses", true);
                str += getFootertable(strinsturl + "reiq/Careers___Training/Real_estate_course_information/Traineeships.aspx", "REIQ_courses_traineeships.jpg", "Traineeships", true);
                str += getFootertable(strinsturl + "REIQ/Careers___Training/Real_estate_course_information/Commercial_and_industrial.aspx", "REIQ_courses_commtrain.jpg", "Commercial training", true);
                str += "</tr>";
                str += "<tr>";
                str += getFootertable(strinsturl + "REIQ/Careers/University_study/REIQ/Careers___Training/University_study.aspx", "REIQ_courses_uni.jpg", "University study", true);
                str += getFootertable(strinsturl + "REIQ/Careers/Recognition_of_Prior_Learning/REIQ/Careers___Training/Recognition_of_prior_learning.aspx", "REIQ_courses_rego.jpg", "Recognition of prior learning", true);
                str += getFootertable(strinsturl + "REIQ/Events/REIQ/Events_Folder/Events_landing_page.aspx", "REIQ_courses_events.jpg", "Conferences & events", true);
                str += "</tr>";
                str += "<tr>";
                str += getFootertable(strinsturl + "REIQ/Careers/Recruitment/REIQ/Careers___Training/Recruitment.aspx", "REIQ_courses_recruits.jpg", "REIQ Recruits", true);
                str += getFootertable(strinsturl + "REIQ/Careers/Calendars/REIQ/Careers___Training/Training_calendar.aspx", "REIQ_courses_calendar.jpg", "Calendars & enrolment forms", true);
                str += getFootertable(strinsturl + "REIQ/Careers/Continuing_Professional_Development/REIQ/Member_Services_Folder/CPD.aspx", "REIQ_courses_cpd.jpg", "CONTINUING PROFESSIONAL DEVELOPMENT", true);
                str += "</tr>";
                break;
            case "real_estate_shop":
                str += "<tr>";
                str += getFootertable(strinsturl + "REIQ/Store/BrowseCategories/Core/Orders/Default.aspx", "REIQ_shop_onlineshop.jpg", "Online shop", true);
                str += getFootertable("images/Shop_Price_List_Dec12.pdf", "REIQ_shop_catalogue.jpg", "Full product catalogue", true);
                str += getFootertable(strinsturl + "REIQ/Store/Featured_shop_products/REIQ/Real_Estate_Shop/Featured_shop_products.aspx", "REIQ_shop_feature.jpg", "Featured products", true);
                str += "</tr>";
                str += "<tr>";
                str += getFootertable(strinsturl + "indexServiceProtected/REIQ/RealEstateShop/Shop_Order_Form.pdf", "REIQ_shop_form.jpg", "Order form", true);
                str += "</tr>";
                break;
            case "member_resources":
                str += "<tr>";
                str += getFootertable(strinsturl + "REIQ/MemberServices/REIQ/MemberServices.aspx", "REIQ_memberresources_login.jpg", "Log-in to member resources area", true);
                str += getFootertable(ConfigurationManager.AppSettings["REIQCzone"].ToString(), "REIQ_memberresources_listings.jpg", "manage my listings", true);
                str += getFootertable(strinsturl + "REIQ/Membership/REIQ/Membership/Membership.aspx", "REIQ_memberresources_apply.jpg", "Apply for REIQ membership", true);


                str += "</tr>";
                break;
        }


        str += "</table>";
        str += "</td></tr>";
        return str;
    }
}