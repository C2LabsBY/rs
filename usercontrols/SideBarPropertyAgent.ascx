<%@ Control Language="C#" AutoEventWireup="false" CodeFile="SideBarPropertyAgent.ascx.cs" Inherits="usercontrols_SideBarPropertyAgent" %>
<%--
    <!-- original template -->
    <h2>Call Agent</h2>
    <figure class="sidebar-agent-img"><img src="/basemedia/images/agent-pic.png" alt="" /></figure>
    <section class="sidebar-agent-detail">
        <h3>NICOLE DEVINE</h3>
        <p class="agent-ph"> <span class="icons"></span>0402 210 298 </p>
    </section>
    <div class="clear"></div>
    <h2>AGENCY PROFILE</h2>
    <figure class="aligncenter"><a href="javascript:;"><img src="/basemedia/images/agency-profile-img.png" alt="" /></a></figure>
--%>


<%if (Agent != null)
  {%>

<h2>Call Agent</h2>
<figure class="sidebar-agent-img">
    <img src="<%=REIQ.Helpers.Images.GetAgentImage(Agent.acID.Value, Agent.aID, 75, 99) %>" alt="" /></figure>
<section class="sidebar-agent-detail">
    <h3><%=Agent.firstname %> <%=Agent.surname %></h3>

    <%if (!String.IsNullOrWhiteSpace(Agent.mobile))
      {

          bool isHideMobile = false;

          if (Agent.hidemobile != null)
              Boolean.TryParse(Agent.hidemobile.ToString(), out isHideMobile);

          if (!isHideMobile)
          {%>
    <p class="agent-ph">
        <span class="icons"></span>
        <%= AgentHelper.GetAgentPhoneWithLog(Agent)%>
    </p>
    <%}
      } %>
</section>
<div class="clear"></div>

<%} %>
<%if (Agency != null)
  {%>
<h2>AGENCY PROFILE</h2>
<figure class="aligncenter">
    <a href="<%='/' + REIQ.Helpers.PropertyHelper.GenerateURLAgency(Agency.name.ToString(), Agency.suburb.ToString(), Agency.acID) %>">
        <img src="<%=REIQ.Helpers.Images.GetAgencyImage(Agency.acID, 196, 88) %>" alt="" />
    </a>
</figure>
<%} %>