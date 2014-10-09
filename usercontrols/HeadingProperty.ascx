<%@ Control Language="C#" AutoEventWireup="true" CodeFile="HeadingProperty.ascx.cs" Inherits="usercontrols_content_header_PropertyHeading" %>
<%if (Property != null)
  {%>
<header id="content-header" class="" style="min-height:40px !important;height: auto;">
    <section class="content-header-first-full-block">
        <h1><%= REIQ.Helpers.PropertyHelper.GetAddress(Property) %></h1>
    </section>
    <section class="content-header-third-block">
        <!-- THIRD BLOCK -->
        <%= getdisplaysearchfeatures(Property.numBedrooms.ToString(), Property.numBathrooms.ToString(), Property.numCarbays.ToString(), Property.numStudy.ToString(), Property.hasPool.ToString(), Property.numGarage.ToString()) %>
    </section>
    <!-- /THIRD BLOCK -->
</header>
<%} %>
