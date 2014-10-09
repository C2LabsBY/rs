<%@ Page Title="" Language="C#" MasterPageFile="Main.master" AutoEventWireup="true" CodeFile="agents.aspx.cs" Inherits="agents" %>
<%@ Register Src="usercontrols/HeadingAgency.ascx" TagPrefix="reiq" TagName="heading" %>
<%@ Register Src="usercontrols/SideBarAgents.ascx" TagPrefix="reiq" TagName="sidebar" %>
<%@ Register Src="usercontrols/Enquiry.ascx" TagPrefix="reiq" TagName="enq" %>
<%@ Register Src="usercontrols/OurTeam.ascx" TagPrefix="reiq" TagName="ourteam" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentHeader" Runat="Server">
    <reiq:heading runat="server" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="SideBarTopControl" Runat="Server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="RightSideBar" Runat="Server">
    <reiq:sidebar runat="server" />
    <reiq:enq runat="server" />
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="MainDataTopControl" Runat="Server">
       <a href="javascript:;" class="back"><span class="icons"></span>BACK TO PROPERTY LISTINGS</a>
</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="MainData" Runat="Server">

            <h2 class="title">About us</h2>
          <p> Since the rebirth of Teneriffe as a residential precinct in 1995 Jennifer Lockley and Teneriffe Realty have been 
            acknowledged as the leaders in the local real estate market. Our reputation has been built around our long 
            and dedicated commitment to the local community. </p>
          <p> We are an independent, innovative and experienced boutique agency which has continued to break real 
            estate records and drive our market forward year after year. </p>
          <p> Our team pride themselves on providing our clients, (whether buying or selling) a level of service that is 
            unparalleled through access to the latest technology, statistics and intimate knowledge of the property 
            market in Teneriffe. </p>
          <section class="hide-data">
            <p> Since the rebirth of Teneriffe as a residential precinct in 1995 Jennifer Lockley and Teneriffe Realty have been 
              acknowledged as the leaders in the local real estate market. Our reputation has been built around our long 
              and dedicated commitment to the local community. </p>
            <p> We are an independent, innovative and experienced boutique agency which has continued to break real 
              estate records and drive our market forward year after year. </p>
            <p> Our team pride themselves on providing our clients, (whether buying or selling) a level of service that is 
              unparalleled through access to the latest technology, statistics and intimate knowledge of the property 
              market in Teneriffe. </p>
        </section>
        <a href="#" class="read-more"><span class="name">Read More</span> <span class="icons"></span></a>
    
        <div class="clear"></div>
        <h2 class="title">Our Team</h2>

        <reiq:ourteam ID="Enq1" runat="server" />
</asp:Content>

