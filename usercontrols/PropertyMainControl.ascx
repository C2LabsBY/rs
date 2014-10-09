<%@ Control Language="C#" AutoEventWireup="true" CodeFile="PropertyMainControl.ascx.cs" Inherits="usercontrols_PropertyMainControl" %>

<%if (Property != null)
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
                <%--<br />--%>
                <%if (Property.numFloorPlan != null)
                  {
                      if (Property.numFloorPlan > 0)
                      {%>
                <%--<h3>Floor Plans</h3>--%>
                <%  int counter = 0;
                    do
                    {
                        counter = counter + 1;
                        if (counter == 1)
                        {//Showing first image tile
                            if (counter == Property.numFloorPlan)
                            {  //If one and only floorplan
                %>
                <div class="property-detail-button">
                    <a rel="prettyPhoto" href="<%=REIQ.Helpers.Images.GetPropertyFloorImage(Property.pID, counter, 640) %>" target="_blank">
                        Floor Plan<%--<img src="\basemedia\images\floorplan.jpg" alt="Floor Plan" />--%>
                    </a>
                </div>
                <%}
                                    else
                                    {//will be more floorplan images%>
                <div class="property-detail-button">
                    <a rel="prettyPhoto[pp_gal]" href="<%=REIQ.Helpers.Images.GetPropertyFloorImage(Property.pID, counter, 640) %>" target="_blank">
                        Floor Plan<%--<img src="\basemedia\images\floorplan.jpg" alt="Floor Plan" />--%>
                    </a>
                </div>
                <%}
                                }
                                else
                                { //hiding all images except 1st one%>
                <div class="property-detail-button">
                    <a style="display: none;" rel="prettyPhoto[pp_gal]" href="<%=REIQ.Helpers.Images.GetPropertyFloorImage(Property.pID, counter, 640) %>" target="_blank">
                       Floor Plan<%-- <img src="\basemedia\images\floorplan.jpg" alt="Floor Plan" />--%>
                    </a>
                </div>
                <%} %>
                <%
                            } while (Property.numFloorPlan > counter);
                %>
                <br />
                <%--<br />--%>
                <%}
                } %>

                <%if (!String.IsNullOrEmpty(Property.link))
                  {%>
                <%--<h3>Virtual Tour</h3>--%>
                <div class="property-detail-button">
                    <%if (Property.link.ToLower().Contains("http"))
                      { %>
                    <a href="<%=Property.link %>" target="_blank">Virtual Tour<%--<img src="\basemedia\images\reiq_media.png" title="virtual tour" />--%></a>
                    <% }
                      else
                      {%>
                    <a href="http://<%=Property.link %>" target="_blank">Virtual Tour<%--<img src="\basemedia\images\reiq_media.png" title="virtual tour" />--%></a>
                    <%} %>
                </div>
                <br />
                <%--<br />--%>
                <%} %>

                <%if (!String.IsNullOrEmpty(Property.link2))
                  {%>
                <%--<h3>Movie Tour</h3>--%>
                <div class="property-detail-button">
                    <%if (Property.link2.ToLower().Contains("http"))
                      { %>
                    <a href="<%=Property.link2 %>" target="_blank">Movie Tour<%--<img src="\basemedia\images\reiq_media.png" title="movie tour" />--%></a>
                    <% }
                      else
                      {%>
                    <a href="http://<%=Property.link2 %>" target="_blank">Movie Tour<%--<img src="\basemedia\images\reiq_media.png" title="movie tour" />--%></a>
                    <%} %>
                </div>
                <br />
                <%--<br />--%>
                <%} %>

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
                <%if (Property.hidePrice != null)
                  {
                      if (!(bool)Property.hidePrice && Property.commercialPriceYearly != null)
                      {
                          if (Property.commercialPriceYearly.ToString() != "" && Property.commercialPriceYearly.ToString() != "0.00" && Property.commercialPriceYearly.ToString() != "0.0000" && Property.commercialPriceYearly.ToString() != "0")
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
            <section class="pro-detail-tab-data-suburb" style="height: 964px !important;">
                <iframe id="Iframe1" width="616" height="990" src="/accessory/suburbprofile.aspx?pid=<%=Property.pID %>" frameborder="0"></iframe>
            </section>
        </section>
        <div style="float: right; font-size: 10px; padding-right: 5px;"><%= showLastUpdatedDate() %></div>
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
  else
  {%>
<h2>No Property found</h2>
<%} %>

