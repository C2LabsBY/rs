<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SecurityPropertyDetails.ascx.cs" Inherits="usercontrols_SecurityPropertyDetails" %>

<link rel="stylesheet" type="text/css" href="/basemedia/css/prettyPhoto.css" media="all">
<script src="/basemedia/scripts/jquery.prettyPhoto.js" type="text/javascript"></script>

<% if (!String.IsNullOrEmpty(Request.QueryString["pId"]))
   {
    if (Property != null)
  {%>
<h2 class="title">
    <%=Property.type%>
    &nbsp; 
    <span class="fright"><%=REIQ.Helpers.PropertyHelper.GetPropertyPrice(Property)%></span>
</h2>
<section class="property-slider-outer">
    <!-- PROPERTY SLIDER OUTER -->
    <% if (REIQ.Helpers.PropertyHelper.isNewlyAdded(Property.dateListed))
       { %>
    <span class="new-label"></span>
    <%} %>
    <section id="property-slider">
        <!-- PROPERTY SLIDER -->
        <ul>
            <%if (!Property.hasPhotoLarge && Property.numPhotoMore == 0)
              { %>
            <li>
                <img src="<%=REIQ.Helpers.Images.GetDefaultPropertyImage(0, 640) %>" alt="" />
            </li>
            <%}
              if (Property.hasPhotoLarge)
              { %>
            <li>
                <img src="<%=REIQ.Helpers.Images.GetDefaultPropertyImage(Property.pID, 640) %>" alt="" />
            </li>
            <%}
         if (Property.numPhotoMore > 0)
         {
             int counter = 1;
             do
             {   
            %>
            <li>
                <img src="<%=REIQ.Helpers.Images.GetPropertyImage(Property.pID, counter, 640) %>" alt="" />
            </li>
            <%
                counter = counter + 1;
            } while (counter <= Property.numPhotoMore);

          } %>
        </ul>
    </section>
    <!-- /PROPERTY SLIDER -->
</section>
<!-- PROPERTY SLIDER OUTER -->

<div class="clear"></div>
<section id="property-detail-tab">
    <!-- PROPERTY DETAIL TAB (TAB) -->
    <ul class="nav">
        <!-- TAB NAV -->
        <li class="nav-one"><a href="#pro-detail-tab" class="current">Detail</a></li>
        <li class="nav-two"><a href="#pro-map-tab">Map</a></li>
        <li class="nav-three"><a href="#pro-street-view">Property in street view</a></li>
        <li class="nav-four"><a href="#suburb-protile">Suburb Profile</a></li>
        <li class="nav-five"><a href="#pro-db-info">Property database information</a></li>
    </ul>
    <!-- TAB NAV -->
    <section class="list-wrap">
        <!-- TAB LIST WRAP -->
        <section id="pro-detail-tab">
            <aside class="pro-detail-tab-sidebar">
                <h3>Property Details</h3>
                Property Type: <%=Property.type%><br />
                Number of Bathrooms: <%=Property.numBathrooms%><br />
                Number of Rooms: <%=Property.numBedrooms%><br />
                <br />
                <br />
                <%if (Property.numFloorPlan != null)
                {
                    if (Property.numFloorPlan > 0)
                    {%> 
                        <h3>Floor Plans</h3>
                        <%  int counter = 0;
                            do
                            {
                                counter = counter + 1;
                                if(counter == 1) {//Showing first image tile
                                    if (counter == Property.numFloorPlan){  //If one and only floorplan
                                    %>    
                                    <a rel="prettyPhoto" href="<%=REIQ.Helpers.Images.GetPropertyFloorImage(Property.pID, counter, 640) %>" target="_blank">
                                        <img src="\basemedia\images\floorplan.jpg" alt="Floor Plan" />
                                    </a>
                                    <%}
                                      else {//will be more floorplan images%>
                                    <a rel="prettyPhoto[pp_gal]" href="<%=REIQ.Helpers.Images.GetPropertyFloorImage(Property.pID, counter, 640) %>" target="_blank">
                                        <img src="\basemedia\images\floorplan.jpg" alt="Floor Plan" />
                                    </a>
                                <%}}
                                  else { //hiding all images except 1st one%>
                                    <a style="display:none;" rel="prettyPhoto[pp_gal]" href="<%=REIQ.Helpers.Images.GetPropertyFloorImage(Property.pID, counter, 640) %>" target="_blank">
                                        <img src="\basemedia\images\floorplan.jpg" alt="Floor Plan" />
                                    </a>
                                <%} %>
                            <%
                            } while (Property.numFloorPlan > counter);
                        %>
                        <br />
                        <br />
                    <%}
               } %>
               <%= showMoreInfo() %>
            </aside>
            <section class="pro-detail-tab-data">
                <h2><%= REIQ.Helpers.PropertyHelper.GetHomeOpensFormat_New(Property.homeopen1From.ToString(), Property.homeopen1To.ToString(), Property.homeopen2From.ToString(), Property.homeopen2To.ToString())%></h2>
                <p>
                    <%=getAvailableFrom(Property.isAvailableNow, Property.availableFrom) %>
                </p>
                <p><%=Property.descriptionShort %></p>
                <% if (Property.descriptionLong != null)
                   { %>
                <p><%=Property.descriptionLong.Replace("\n", "<br>")%></p>
                <%}%>
                <% if (!String.IsNullOrEmpty(Property.descriptionBullet))
                   { %>
                <ul class="normal-listing">
                    <%=Property.descriptionBullet%>
                </ul>
                <% }  %>
                <%= getRates(Property.ratesWater.ToString(), Property.ratesCouncil.ToString(), Property.ratesStrata.ToString())%>
                <%if (Property.hidePrice != null) {
                      if (!(bool)Property.hidePrice && Property.commercialPriceYearly != null)
                      {
                          if(Property.commercialPriceYearly.ToString() != "" && Property.commercialPriceYearly.ToString() != "0.00" && Property.commercialPriceYearly.ToString() != "0.0000" && Property.commercialPriceYearly.ToString() != "0")
                          {%>
                            <b>Commercial Rent : $<%=string.Format("{0:0}",Property.commercialPriceYearly)%> / yr</b>
                        <%}
                      }
                }%>
                <%if (Property.hassustainability != null)
                  {%>
                <%if ((bool)Property.hassustainability)
                  {%>
                        A copy of the sustainability declaration is available from the agent on request.<br>
                <br>
                <%}%>
                <%}%>
                <%= REIQ.Helpers.PropertyHelper.GetAuctionFormat(Property.auctionDate == null ? "" : Property.auctionDate.ToString(), Property.auctionTime) %>
            </section>
        </section>
        <section id="pro-map-tab" class="hide">
            <section class="pro-detail-tab-data">
                <iframe width="616" height="590" src="/accessory/Gmap.aspx?pid=<%=Property.pID %>" frameborder="0"></iframe>
            </section>
        </section>
        <section id="pro-street-view" class="hide">
            <section class="pro-detail-tab-data">
                <iframe id="streetViewFrame" width="616" height="590" src="/accessory/GoogleMapsStreet.aspx?pid=<%=Property.pID %>" frameborder="0"></iframe>
            </section>
        </section>
        <section id="suburb-protile" class="hide">
            <section class="pro-detail-tab-data-suburb" style="height: 920px !important;">
                <iframe id="Iframe1" width="616" height="990" src="/accessory/suburbprofile.aspx?pid=<%=Property.pID %>" frameborder="0"></iframe>
            </section>
        </section>
        <section id="pro-db-info" class="hide">
            <section class="pro-detail-tab-data" style="overflow-y:auto;">
                <h2>Property Info</h2>
                <section class="pro-db-info-content" style="height: auto;">
                    <table>
                        <caption">Information about property from Database<br /><br /></caption>
                        <thead>
                            <tr style="border-bottom: 1px solid #dddddd;color:#ba002f;">
                                <th width="50%">Field Name</th>
                                <th width="50%">Field Value</th>
                            </tr>
                        </thead>
                        <tbody>
                            <% foreach (var field in Property.GetType().GetProperties()) 
                             {%><tr>
                                <th><%=field.Name %></th>
                                <td><%=field.GetValue(Property, null) %></td>
                                 </tr>
                            <%} %>
                            <%--<tr>
                                <th>feederPID</th>
                                <td><%=Property.feederPID %></td>
                            </tr>
                            <tr>
                                <th>acID</th>
                                <td><%=Property.acID %></td>
                            </tr>
                            <tr>
                                <th>aID1</th>
                                <td><%=Property.aID1 %></td>
                            </tr>
                            <tr>
                                <th>aID2</th>
                                <td><%=Property.aID2 %></td>
                            </tr>
                            <tr>
                                <th>aID3</th>
                                <td><%=Property.aID3 %></td>
                            </tr>
                            <tr>
                                <th>type</th>
                                <td><%=Property.type %></td>
                            </tr>
                            <tr>
                                <th>lifestyle</th>
                                <td><%=Property.lifestyle %></td>
                            </tr>
                            <tr>
                                <th>isInvestment</th>
                                <td><%=Property.isInvestment %></td>
                            </tr>
                            <tr>
                                <th>isWebDisplay</th>
                                <td><%=Property.isWebDisplay %></td>
                            </tr>
                            <tr>
                                <th>bID</th>
                                <td><%=Property.bID %></td>
                            </tr>
                            <tr>
                                <th>name</th>
                                <td><%=Property.name %></td>
                            </tr>
                            <tr>
                                <th>unitNum</th>
                                <td><%=Property.unitNum %></td>
                            </tr>
                            <tr>
                                <th>rdNum</th>
                                <td><%=Property.rdNum %></td>
                            </tr>
                            <tr>
                                <th>rdName</th>
                                <td><%=Property.rdName %></td>
                            </tr>
                            <tr>
                                <th>rdType</th>
                                <td><%=Property.rdType %></td>
                            </tr>
                            <tr>
                                <th>suburb</th>
                                <td><%=Property.suburb %></td>
                            </tr>
                            <tr>
                                <th>state</th>
                                <td><%=Property.state %></td>
                            </tr>
                            <tr>
                                <th>postcode</th>
                                <td><%=Property.postcode %></td>
                            </tr>
                            <tr>
                                <th>country</th>
                                <td><%=Property.country %></td>
                            </tr>
                            <tr>
                                <th>hideRoadNum</th>
                                <td><%=Property.hideRoadNum %></td>
                            </tr>
                            <tr>
                                <th>hideRoadName</th>
                                <td><%=Property.hideRoadName %></td>
                            </tr>
                            <tr>
                                <th>status</th>
                                <td><%=Property.status %></td>
                            </tr>
                            <tr>
                                <th>priceOption</th>
                                <td><%=Property.priceOption %></td>
                            </tr>
                            <tr>
                                <th>isFIRB</th>
                                <td><%=Property.isFIRB %></td>
                            </tr>
                            <tr>
                                <th>priceLow</th>
                                <td><%=Property.priceLow %></td>
                            </tr>
                            <tr>
                                <th>priceHigh</th>
                                <td><%=Property.priceHigh %></td>
                            </tr>
                            <tr>
                                <th>hidePrice</th>
                                <td><%=Property.hidePrice %></td>
                            </tr>
                            <tr>
                                <th>pricetext</th>
                                <td><%=Property.pricetext %></td>
                            </tr>
                            <tr>
                                <th>auctionLoc</th>
                                <td><%=Property.auctionLoc %></td>
                            </tr>
                            <tr>
                                <th>auctionDate</th>
                                <td><%=Property.auctionDate %></td>
                            </tr>
                            <tr>
                                <th>auctionTime</th>
                                <td><%=Property.auctionTime %></td>
                            </tr>
                            <tr>
                                <th>ratesCouncil</th>
                                <td><%=Property.ratesCouncil %></td>
                            </tr>
                            <tr>
                                <th>ratesWater</th>
                                <td><%=Property.ratesWater %></td>
                            </tr>
                            <tr>
                                <th>ratesStrata</th>
                                <td><%=Property.ratesStrata %></td>
                            </tr>
                            <tr>
                                <th>outgoings</th>
                                <td><%=Property.outgoings %></td>
                            </tr>
                            <tr>
                                <th>numBedrooms</th>
                                <td><%=Property.numBedrooms %></td>
                            </tr>
                            <tr>
                                <th>numBathrooms</th>
                                <td><%=Property.numBathrooms %></td>
                            </tr>
                            <tr>
                                <th>numStudy</th>
                                <td><%=Property.numStudy %></td>
                            </tr>
                            <tr>
                                <th>numWC</th>
                                <td><%=Property.numWC %></td>
                            </tr>
                            <tr>
                                <th>hasRoomDining</th>
                                <td><%=Property.hasRoomDining %></td>
                            </tr>
                            <tr>
                                <th>hasRoomLiving</th>
                                <td><%=Property.hasRoomLiving %></td>
                            </tr>
                            <tr>
                                <th>hasRoomGames</th>
                                <td><%=Property.hasRoomGames %></td>
                            </tr>
                            <tr>
                                <th>hasRoomFamily</th>
                                <td><%=Property.hasRoomFamily %></td>
                            </tr>
                            <tr>
                                <th>zoning</th>
                                <td><%=Property.zoning %></td>
                            </tr>
                            <tr>
                                <th>lotSize</th>
                                <td><%=Property.lotSize %></td>
                            </tr>
                            <tr>
                                <th>lotMeasurement</th>
                                <td><%=Property.lotMeasurement %></td>
                            </tr>
                            <tr>
                                <th>lotOrientation</th>
                                <td><%=Property.lotOrientation %></td>
                            </tr>
                            <tr>
                                <th>lotFrontage</th>
                                <td><%=Property.lotFrontage %></td>
                            </tr>
                            <tr>
                                <th>rentPotential</th>
                                <td><%=Property.rentPotential %></td>
                            </tr>
                            <tr>
                                <th>investmentReturn</th>
                                <td><%=Property.investmentReturn %></td>
                            </tr>
                            <tr>
                                <th>investmentMin</th>
                                <td><%=Property.investmentMin %></td>
                            </tr>
                            <tr>
                                <th>investmentPaid</th>
                                <td><%=Property.investmentPaid %></td>
                            </tr>
                            <tr>
                                <th>investmentClosingDate</th>
                                <td><%=Property.investmentClosingDate %></td>
                            </tr>
                            <tr>
                                <th>investmentLen</th>
                                <td><%=Property.investmentLen %></td>
                            </tr>
                            <tr>
                                <th>numGarage</th>
                                <td><%=Property.numGarage %></td>
                            </tr>
                            <tr>
                                <th>hasGarageRemote</th>
                                <td><%=Property.hasGarageRemote %></td>
                            </tr>
                            <tr>
                                <th>numCarbays</th>
                                <td><%=Property.numCarbays %></td>
                            </tr>
                            <tr>
                                <th>hasOutdoorEnt</th>
                                <td><%=Property.hasOutdoorEnt %></td>
                            </tr>
                            <tr>
                                <th>hasCourtyard</th>
                                <td><%=Property.hasCourtyard %></td>
                            </tr>
                            <tr>
                                <th>hasPool</th>
                                <td><%=Property.hasPool %></td>
                            </tr>
                            <tr>
                                <th>hasReticulation</th>
                                <td><%=Property.hasReticulation %></td>
                            </tr>
                            <tr>
                                <th>hasBore</th>
                                <td><%=Property.hasBore %></td>
                            </tr>
                            <tr>
                                <th>hasGardenShed</th>
                                <td><%=Property.hasGardenShed %></td>
                            </tr>
                            <tr>
                                <th>stage</th>
                                <td><%=Property.stage %></td>
                            </tr>
                            <tr>
                                <th>unitLevel</th>
                                <td><%=Property.unitLevel %></td>
                            </tr>
                            <tr>
                                <th>hasLift</th>
                                <td><%=Property.hasLift %></td>
                            </tr>
                            <tr>
                                <th>hasGym</th>
                                <td><%=Property.hasGym %></td>
                            </tr>
                            <tr>
                                <th>hasSpa</th>
                                <td><%=Property.hasSpa %></td>
                            </tr>
                            <tr>
                                <th>hasManager</th>
                                <td><%=Property.hasManager %></td>
                            </tr>
                            <tr>
                                <th>hasDoorman</th>
                                <td><%=Property.hasDoorman %></td>
                            </tr>
                            <tr>
                                <th>sqmInternal</th>
                                <td><%=Property.sqmInternal %></td>
                            </tr>
                            <tr>
                                <th>sqmExternal</th>
                                <td><%=Property.sqmExternal %></td>
                            </tr>
                            <tr>
                                <th>numBalcony</th>
                                <td><%=Property.numBalcony %></td>
                            </tr>
                            <tr>
                                <th>heatingType</th>
                                <td><%=Property.heatingType %></td>
                            </tr>
                            <tr>
                                <th>coolingtype</th>
                                <td><%=Property.coolingtype %></td>
                            </tr>
                            <tr>
                                <th>hasHouseAlarm</th>
                                <td><%=Property.hasHouseAlarm %></td>
                            </tr>
                            <tr>
                                <th>hasSecuritySystem</th>
                                <td><%=Property.hasSecuritySystem %></td>
                            </tr>
                            <tr>
                                <th>hasBedroomDetails</th>
                                <td><%=Property.hasBedroomDetails %></td>
                            </tr>
                            <tr>
                                <th>descriptionShort</th>
                                <td><%=Property.descriptionShort %></td>
                            </tr>
                            <tr>
                                <th>descriptionLong</th>
                                <td><%=Property.descriptionLong %></td>
                            </tr>
                            <tr>
                                <th>descriptionBullet</th>
                                <td><%=Property.descriptionBullet %></td>
                            </tr>
                            <tr>
                                <th>hasThumbnail</th>
                                <td><%=Property.hasThumbnail %></td>
                            </tr>
                            <tr>
                                <th>hasPhotosmall</th>
                                <td><%=Property.hasPhotosmall %></td>
                            </tr>
                            <tr>
                                <th>hasPhotoLarge</th>
                                <td><%=Property.hasPhotoLarge %></td>
                            </tr>
                            <tr>
                                <th>numPhotoMore</th>
                                <td><%=Property.numPhotoMore %></td>
                            </tr>
                            <tr>
                                <th>numFloorPlan</th>
                                <td><%=Property.numFloorPlan %></td>
                            </tr>
                            <tr>
                                <th>numviews</th>
                                <td><%=Property.numviews %></td>
                            </tr>
                            <tr>
                                <th>hasVT</th>
                                <td><%=Property.hasVT %></td>
                            </tr>
                            <tr>
                                <th>hasLotPlan</th>
                                <td><%=Property.hasLotPlan %></td>
                            </tr>
                            <tr>
                                <th>homeopen1From</th>
                                <td><%=Property.homeopen1From %></td>
                            </tr>
                            <tr>
                                <th>homeopen1To</th>
                                <td><%=Property.homeopen1To %></td>
                            </tr>
                            <tr>
                                <th>homeopen2From</th>
                                <td><%=Property.homeopen2From %></td>
                            </tr>
                            <tr>
                                <th>homeopen2To</th>
                                <td><%=Property.homeopen2To %></td>
                            </tr>
                            <tr>
                                <th>link</th>
                                <td><%=Property.link %></td>
                            </tr>
                            <tr>
                                <th>link2</th>
                                <td><%=Property.link2 %></td>
                            </tr>
                            <tr>
                                <th>isMagazine</th>
                                <td><%=Property.isMagazine %></td>
                            </tr>
                            <tr>
                                <th>isExecutive</th>
                                <td><%=Property.isExecutive %></td>
                            </tr>
                            <tr>
                                <th>paymentPeriod</th>
                                <td><%=Property.paymentPeriod %></td>
                            </tr>
                            <tr>
                                <th>isAvailableNow</th>
                                <td><%=Property.isAvailableNow %></td>
                            </tr>
                            <tr>
                                <th>availableFrom</th>
                                <td><%=Property.availableFrom %></td>
                            </tr>
                            <tr>
                                <th>securityBond</th>
                                <td><%=Property.securityBond %></td>
                            </tr>
                            <tr>
                                <th>leaseTerm</th>
                                <td><%=Property.leaseTerm %></td>
                            </tr>
                            <tr>
                                <th>petStatus</th>
                                <td><%=Property.petStatus %></td>
                            </tr>
                            <tr>
                                <th>isFurnished</th>
                                <td><%=Property.isFurnished %></td>
                            </tr>
                            <tr>
                                <th>reiwaListing</th>
                                <td><%=Property.reiwaListing %></td>
                            </tr>
                            <tr>
                                <th>hasVaccumSystem</th>
                                <td><%=Property.hasVaccumSystem %></td>
                            </tr>
                            <tr>
                                <th>hasParkingExposed</th>
                                <td><%=Property.hasParkingExposed %></td>
                            </tr>
                            <tr>
                                <th>hasParkingUnderCover</th>
                                <td><%=Property.hasParkingUnderCover %></td>
                            </tr>
                            <tr>
                                <th>hasSecureCarPark</th>
                                <td><%=Property.hasSecureCarPark %></td>
                            </tr>
                            <tr>
                                <th>commercialCategory</th>
                                <td><%=Property.commercialCategory %></td>
                            </tr>
                            <tr>
                                <th>commercialLeaseHold</th>
                                <td><%=Property.commercialLeaseHold %></td>
                            </tr>
                            <tr>
                                <th>commercialPriceSqm</th>
                                <td><%=Property.commercialPriceSqm %></td>
                            </tr>
                            <tr>
                                <th>commercialPriceYearly</th>
                                <td><%=Property.commercialPriceYearly %></td>
                            </tr>
                            <tr>
                                <th>commercialOutgoingSqm</th>
                                <td><%=Property.commercialOutgoingSqm %></td>
                            </tr>
                            <tr>
                                <th>commercialOutgoingYearly</th>
                                <td><%=Property.commercialOutgoingYearly %></td>
                            </tr>
                            <tr>
                                <th>commercialCarBayMonthly</th>
                                <td><%=Property.commercialCarBayMonthly %></td>
                            </tr>
                            <tr>
                                <th>isReiwaFeed</th>
                                <td><%=Property.isReiwaFeed %></td>
                            </tr>
                            <tr>
                                <th>priceSold</th>
                                <td><%=Property.priceSold %></td>
                            </tr>
                            <tr>
                                <th>hotwatersystem</th>
                                <td><%=Property.hotwatersystem %></td>
                            </tr>
                            <tr>
                                <th>storey</th>
                                <td><%=Property.storey %></td>
                            </tr>
                            <tr>
                                <th>yearBuild</th>
                                <td><%=Property.yearBuild %></td>
                            </tr>
                            <tr>
                                <th>encumbrances</th>
                                <td><%=Property.encumbrances %></td>
                            </tr>
                            <tr>
                                <th>walltype</th>
                                <td><%=Property.walltype %></td>
                            </tr>
                            <tr>
                                <th>rooftype</th>
                                <td><%=Property.rooftype %></td>
                            </tr>
                            <tr>
                                <th>dateExpiry</th>
                                <td><%=Property.dateExpiry %></td>
                            </tr>
                            <tr>
                                <th>dateListed</th>
                                <td><%=Property.dateListed %></td>
                            </tr>
                            <tr>
                                <th>dateSold</th>
                                <td><%=Property.dateSold %></td>
                            </tr>
                            <tr>
                                <th>dateUpdated</th>
                                <td><%=Property.dateUpdated %></td>
                            </tr>
                            <tr>
                                <th>dateUpdatedVisual</th>
                                <td><%=Property.dateUpdatedVisual %></td>
                            </tr>
                            <tr>
                                <th>lat</th>
                                <td><%=Property.lat %></td>
                            </tr>
                            <tr>
                                <th>lon</th>
                                <td><%=Property.lon %></td>
                            </tr>
                            <tr>
                                <th>geoQuality</th>
                                <td><%=Property.geoQuality %></td>
                            </tr>
                            <tr>
                                <th>hasAttachment</th>
                                <td><%=Property.hasAttachment %></td>
                            </tr>
                            <tr>
                                <th>propertyDisplay</th>
                                <td><%=Property.propertyDisplay %></td>
                            </tr>
                            <tr>
                                <th>onadate</th>
                                <td><%=Property.onadate %></td>
                            </tr>
                            <tr>
                                <th>googlex</th>
                                <td><%=Property.googlex %></td>
                            </tr>
                            <tr>
                                <th>googley</th>
                                <td><%=Property.googley %></td>
                            </tr>
                            <tr>
                                <th>isRea</th>
                                <td><%=Property.isRea %></td>
                            </tr>
                            <tr>
                                <th>isDomain</th>
                                <td><%=Property.isDomain %></td>
                            </tr>
                            <tr>
                                <th>goLive</th>
                                <td><%=Property.goLive %></td>
                            </tr>
                            <tr>
                                <th>pricered</th>
                                <td><%=Property.pricered %></td>
                            </tr>
                            <tr>
                                <th>hideahc</th>
                                <td><%=Property.hideahc %></td>
                            </tr>
                            <tr>
                                <th>hidemap</th>
                                <td><%=Property.hidemap %></td>
                            </tr>
                            <tr>
                                <th>hidestreet</th>
                                <td><%=Property.hidestreet %></td>
                            </tr>
                            <tr>
                                <th>nonreasold</th>
                                <td><%=Property.nonreasold %></td>
                            </tr>
                            <tr>
                                <th>feederid</th>
                                <td><%=Property.feederid %></td>
                            </tr>
                            <tr>
                                <th>displaysoldprice</th>
                                <td><%=Property.displaysoldprice %></td>
                            </tr>
                            <tr>
                                <th>hassustainability</th>
                                <td><%=Property.hassustainability %></td>
                            </tr>--%>
                        </tbody>
                    </table>
                </section>
            </section>
        </section>
        <div style="float: right;font-size: 10px;padding-right: 5px;"><%= showLastUpdatedDate() %></div>
        <div class="clear"></div>
    </section>
    <!-- END List Wrap -->
    <div class="clear"></div>
</section>
<!-- /PROPERTY DETAIL TAB (TAB) -->

<script type="text/javascript" charset="utf-8">
    $(document).ready(function () {
        $("a[rel^='prettyPhoto']").prettyPhoto({ allow_resize: true, deeplinking: false });
    });
</script>

<%} 
  else{%> <h2>No Property found</h2><%} 
}%>

