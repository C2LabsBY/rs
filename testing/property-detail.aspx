<%@ Page Title="" Language="C#" MasterPageFile="Main.master" AutoEventWireup="true" Inherits="TemplateBase" %>
<%@ Register Src="~/usercontrols/HeadingProperty.ascx" TagPrefix="reiq" TagName="heading" %>
<%@ Register Src="~/usercontrols/SideBarPropertyAgent.ascx" TagPrefix="reiq" TagName="agent" %>
<%@ Register Src="~/usercontrols/Enquiry.ascx" TagPrefix="reiq" TagName="enq" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentHeader" Runat="Server">
    <reiq:heading runat="server" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="SideBarTopControl" Runat="Server">
     <a href="javascript:;" class="favourite"><span class="icons"></span>Add to Favourites</a> <a href="javascript:;" class="find"><span class="icons"></span>Find me Similar</a>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="RightSideBar" Runat="Server">
    <reiq:agent runat="server" />

    <reiq:enq runat="server" />
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="MainDataTopControl" Runat="Server">
    <a href="javascript:;" class="back"><span class="icons"></span>BACK TO PROPERTY LISTINGS</a> <span class="fright">Property ID: 2487072</span>
</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="MainData" Runat="Server">

         <h2 class="title"> $690 per week <span class="fright">Apartment/Unit</span> </h2>
          <section class="property-slider-outer"><!-- PROPERTY SLIDER OUTER --> 
            <span class="new-label"></span>
            <section id="property-slider"><!-- PROPERTY SLIDER -->
              <ul>
                <li><img src="basemedia/images/property-slide1.png" alt="" /></li>
                <li><img src="basemedia/images/property-slide1.png" alt="" /></li>
                <li><img src="basemedia/images/property-slide1.png" alt="" /></li>
              </ul>
            </section>
            <!-- /PROPERTY SLIDER --> 
          </section>
          <!-- PROPERTY SLIDER OUTER -->
          
          <div class="clear"></div>
          <section id="property-detail-tab"><!-- PROPERTY DETAIL TAB (TAB) -->
            
            <ul class="nav">
              <!-- TAB NAV -->
              <li class="nav-one"><a href="#pro-detail-tab" class="current">Detail</a></li>
              <li class="nav-two"><a href="#pro-map-tab">Map</a></li>
              <li class="nav-three"><a href="#pro-street-view">Property in street view</a></li>
              <li class="nav-four"><a href="#suburb-protile">Suburb Profile</a></li>
            </ul>
            <!-- TAB NAV -->
            
            <section class="list-wrap"><!-- TAB LIST WRAP -->
              
              <section id="pro-detail-tab">
                <aside class="pro-detail-tab-sidebar">
                  <h3>Property Details</h3>
                  Property Type: House<br/>
                  Number of Bathrooms: 2<br/>
                  Number of Rooms: 3 <br/>
                  <br/>
                  <h3>Furnishings</h3>
                  <ul class="right-sign">
                    <li>Bed Linen & Towels</li>
                    <li>Kitchen</li>
                    <li>Wilreless Internet</li>
                    <li>Internet</li>
                    <li>TV</li>
                    <li>Parking Included</li>
                    <li>Air Conditionning</li>
                  </ul>
                </aside>
                <section class="pro-detail-tab-data">
                  <h2>OPEN INSPECTION SUN 12:00-13:00</h2>
                  <p><strong>Available now</strong></p>
                  <p>CORPORATE FULLY FURNISHED!</p>
                  <p> This 3 bedroom apartment is AMAZING, furnished with ultra modern, 
                    stylish, furniture and fittings. </p>
                  <p> The apartment is large, light and airy and set over 2 levels with lofty 
                    ceilings, polished floors, ducted air conditioning and some river views. </p>
                  <p> The London Woolstore is located in the heart of Teneriffe amidst 
                    trendy cafes, restaurants, health clubs with transport and the river 
                    nearby. </p>
                  <p> The fully furnished apartment in neutral contemporary tones features: </p>
                  <ul class="normal-listing">
                    <li>+ 3 bedrooms with built in wardrobes main with ensuite</li>
                    <li>+ Fully equipped gourmet kitchen with state of the art appliances</li>
                    <li>+ Ducted air conditioning<br/>
                    </li>
                    <li>+ Cable and ADSL wired</li>
                    <li>+ Secure undercover car space<br/>
                    </li>
                    <li>+ Lap pool</li>
                    <li>+ Convenient location close to James Street, cosmopolitan Emporium and CBD</li>
                  </ul>
                  <p></p>
                  <p>For an inspection phone 32570015.</p>
                  <p>Intercom : Yes</p>
                </section>
              </section>
              <section id="pro-map-tab" class="hide">
                <aside class="pro-detail-tab-sidebar">
                  <h3>Property Details</h3>
                  Property Type: House<br/>
                  Number of Bathrooms: 2<br/>
                  Number of Rooms: 3 <br/>
                  <br/>
                  <h3>Furnishings</h3>
                  <ul class="right-sign">
                    <li>Bed Linen & Towels</li>
                    <li>Kitchen</li>
                    <li>Wilreless Internet</li>
                    <li>Internet</li>
                    <li>TV</li>
                    <li>Parking Included</li>
                    <li>Air Conditionning</li>
                  </ul>
                </aside>
                <section class="pro-detail-tab-data">
                  <h2>OPEN INSPECTION SUN 12:00-13:00</h2>
                  <p><strong>Available now</strong></p>
                  <p>CORPORATE FULLY FURNISHED!</p>
                  <p> This 3 bedroom apartment is AMAZING, furnished with ultra modern, 
                    stylish, furniture and fittings. </p>
                  <p> The apartment is large, light and airy and set over 2 levels with lofty 
                    ceilings, polished floors, ducted air conditioning and some river views. </p>
                  <p> The London Woolstore is located in the heart of Teneriffe amidst 
                    trendy cafes, restaurants, health clubs with transport and the river 
                    nearby. </p>
                  <p> The fully furnished apartment in neutral contemporary tones features: </p>
                  <ul class="normal-listing">
                    <li>+ 3 bedrooms with built in wardrobes main with ensuite</li>
                    <li>+ Fully equipped gourmet kitchen with state of the art appliances</li>
                    <li>+ Ducted air conditioning<br/>
                    </li>
                    <li>+ Cable and ADSL wired</li>
                    <li>+ Secure undercover car space<br/>
                    </li>
                    <li>+ Lap pool</li>
                    <li>+ Convenient location close to James Street, cosmopolitan Emporium and CBD</li>
                  </ul>
                  <p></p>
                  <p>For an inspection phone 32570015.</p>
                  <p>Intercom : Yes</p>
                </section>
              </section>
              <section id="pro-street-view" class="hide">
                <aside class="pro-detail-tab-sidebar">
                  <h3>Property Details</h3>
                  Property Type: House<br/>
                  Number of Bathrooms: 2<br/>
                  Number of Rooms: 3 <br/>
                  <br/>
                  <h3>Furnishings</h3>
                  <ul class="right-sign">
                    <li>Bed Linen & Towels</li>
                    <li>Kitchen</li>
                    <li>Wilreless Internet</li>
                    <li>Internet</li>
                    <li>TV</li>
                    <li>Parking Included</li>
                    <li>Air Conditionning</li>
                  </ul>
                </aside>
                <section class="pro-detail-tab-data">
                  <h2>OPEN INSPECTION SUN 12:00-13:00</h2>
                  <p><strong>Available now</strong></p>
                  <p>CORPORATE FULLY FURNISHED!</p>
                  <p> This 3 bedroom apartment is AMAZING, furnished with ultra modern, 
                    stylish, furniture and fittings. </p>
                  <p> The apartment is large, light and airy and set over 2 levels with lofty 
                    ceilings, polished floors, ducted air conditioning and some river views. </p>
                  <p> The London Woolstore is located in the heart of Teneriffe amidst 
                    trendy cafes, restaurants, health clubs with transport and the river 
                    nearby. </p>
                  <p> The fully furnished apartment in neutral contemporary tones features: </p>
                  <ul class="normal-listing">
                    <li>+ 3 bedrooms with built in wardrobes main with ensuite</li>
                    <li>+ Fully equipped gourmet kitchen with state of the art appliances</li>
                    <li>+ Ducted air conditioning<br/>
                    </li>
                    <li>+ Cable and ADSL wired</li>
                    <li>+ Secure undercover car space<br/>
                    </li>
                    <li>+ Lap pool</li>
                    <li>+ Convenient location close to James Street, cosmopolitan Emporium and CBD</li>
                  </ul>
                  <p></p>
                  <p>For an inspection phone 32570015.</p>
                  <p>Intercom : Yes</p>
                </section>
              </section>
              <section id="suburb-protile" class="hide">
                <aside class="pro-detail-tab-sidebar">
                  <h3>Property Details</h3>
                  Property Type: House<br/>
                  Number of Bathrooms: 2<br/>
                  Number of Rooms: 3 <br/>
                  <br/>
                  <h3>Furnishings</h3>
                  <ul class="right-sign">
                    <li>Bed Linen & Towels</li>
                    <li>Kitchen</li>
                    <li>Wilreless Internet</li>
                    <li>Internet</li>
                    <li>TV</li>
                    <li>Parking Included</li>
                    <li>Air Conditionning</li>
                  </ul>
                </aside>
                <section class="pro-detail-tab-data">
                  <h2>OPEN INSPECTION SUN 12:00-13:00</h2>
                  <p><strong>Available now</strong></p>
                  <p>CORPORATE FULLY FURNISHED!</p>
                  <p> This 3 bedroom apartment is AMAZING, furnished with ultra modern, 
                    stylish, furniture and fittings. </p>
                  <p> The apartment is large, light and airy and set over 2 levels with lofty 
                    ceilings, polished floors, ducted air conditioning and some river views. </p>
                  <p> The London Woolstore is located in the heart of Teneriffe amidst 
                    trendy cafes, restaurants, health clubs with transport and the river 
                    nearby. </p>
                  <p> The fully furnished apartment in neutral contemporary tones features: </p>
                  <ul class="normal-listing">
                    <li>+ 3 bedrooms with built in wardrobes main with ensuite</li>
                    <li>+ Fully equipped gourmet kitchen with state of the art appliances</li>
                    <li>+ Ducted air conditioning<br/>
                    </li>
                    <li>+ Cable and ADSL wired</li>
                    <li>+ Secure undercover car space<br/>
                    </li>
                    <li>+ Lap pool</li>
                    <li>+ Convenient location close to James Street, cosmopolitan Emporium and CBD</li>
                  </ul>
                  <p></p>
                  <p>For an inspection phone 32570015.</p>
                  <p>Intercom : Yes</p>
                </section>
              </section>
              <div class="clear"></div>
            </section>
            <!-- END List Wrap -->
            <div class="clear"></div>
          </section>
          <!-- /PROPERTY DETAIL TAB (TAB) --> 


</asp:Content>

