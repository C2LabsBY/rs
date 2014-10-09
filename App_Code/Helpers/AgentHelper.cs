using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using REIQ.Entities;
using REIQ.Helpers;

/// <summary>
/// Сводное описание для AgentHelper
/// </summary>
public static class AgentHelper
{
    public static string GetAgentMobilePhoneWithLog(Agent agent)
    {
        String html = String.Empty;

        if (agent != null)
            html = GetClickToCallBasicHtml(agent, agent.mobile);

        return HttpUtility.HtmlDecode(html);
    }

    public static string GetAgentPhoneWithLog(Agent agent)
    {
        String html = String.Empty;

        if (agent != null)
        {
            String number = String.Empty;

            String phonetemp = String.IsNullOrEmpty(agent.phone) ? String.Empty : agent.phone.Replace("(", "").Replace(")", "").Replace(" ", "").Trim();
            String mobiletemp = String.IsNullOrEmpty(agent.mobile) ? String.Empty : agent.mobile.Replace("(", "").Replace(")", "").Replace(" ", "").Trim();
            
            //If phones are different -> show them in priority(1-mobile, 2-phone)
            if (phonetemp != mobiletemp)
            {

                bool isHideMobile = false;

                if (agent.hidemobile != null)
                    Boolean.TryParse(agent.hidemobile.ToString(), out isHideMobile);

                if (!String.IsNullOrEmpty(agent.mobile) && !isHideMobile)
                    number = AgencyHelper.GetAgentMobileFormat(agent.mobile);
                else if (!String.IsNullOrEmpty(agent.phone))
                    number = agent.phone;
            }//If phones are the same - consider them both as office phone
            else if (!String.IsNullOrEmpty(agent.phone))
                number = agent.phone;

            html = GetClickToCallBasicHtml(agent, number);
        }

        return HttpUtility.HtmlDecode(html);
    }

    public static string GetClickToCallBasicHtml(Agent agent, String number)
    {
        String html = String.Empty;

        if (!String.IsNullOrEmpty(number))
        {
            //Trim number
            number = number.TrimEnd();

            if (number.Length > 3)
            {
                html =
                    "<a href='#' onclick='javascript:agentClick(" + agent.aID + "," + agent.acID + ");return false;' class='agent-mobile" + agent.aID + "'>" + number.Remove(number.Length - 3) + " . . .</a>";
                html += "<span class='agent-mobile-full" + agent.aID + "' style='display:none;'>" + number + "</span>";
            }
            else
            {
                html = "<span class='agent-mobile-full" + agent.aID + "'>" + number + "</span>";
            }
        }

        return html;
    }
}