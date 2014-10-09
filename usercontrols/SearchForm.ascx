<%@ Control Language="C#" AutoEventWireup="true" Inherits="usercontrols_SearchForm" CodeFile="SearchForm.ascx.cs"%>
<%@ Import Namespace="REIQ.Enum" %>
<script runat="server">
    /// <summary>
    /// The default tab to show
    /// </summary>
    public SearchTab DefaultTab
    {
        get { return defaultTab; }
        set { defaultTab = value; }
    }
    private SearchTab defaultTab = SearchTab.Buy;

    /// <summary>
    /// Where the search form should submit to (i.e. the search results page URL)
    /// </summary>
    public string Target = "/results";
</script>

<script type="text/javascript" src="/basemedia/scripts/typeahead.min.js"></script>
<link rel="stylesheet" type="text/css" href="/basemedia/css/autocomplete.css" media="all">
<style>
    <% if (LeftBannersCount > 1) { %>
        #leftAdsSlider{
            display: none;
        }
    <% } %>
    <% if (RightBannersCount > 1) { %>
        #rightAdsSlider{
            display: none;
        }
    <% } %>
    .front-page-banner-l {
        width: 142px;
        height: 142px;
        float: left;
        position: relative;
        left: 40px;
        top: 50px;
    }
    .front-page-banner-r {
        position: relative;
        right: 40px;
        top: 50px;
        float: right;
        width: 142px;
        height: 142px;
    }
    .front-page-banner-l img {
        margin-left: 0;
        margin-top: 0;
    }
    .front-page-banner-r img {
        margin-right: 0px;
        margin-top: 0px;
    }
</style>	
<script type="text/javascript" src="/basemedia/scripts/jquery.slides.min.js"></script>

<script>
    $(document).ready(function () { 
        <% if (LeftBannersCount > 1) { %>
        //homepage left slider
        $("#leftAdsSlider").slidesjs({
            width: 140,
            height: 140,
            navigation: {
                active: false,
                effect: "slide"
            },
            pagination: {
                active: false
            },
            play: {
                active: false,
                // [boolean] Generate the play and stop buttons.
                // You cannot use your own buttons. Sorry.
                effect: "slide",
                // [string] Can be either "slide" or "fade".
                interval: <%=ScrollSpeed %>,
                // [number] Time spent on each slide in milliseconds.
                auto: true,
                // [boolean] Start playing the slideshow on load.
                swap: false,
                // [boolean] show/hide stop and play buttons
                pauseOnHover: false,
                // [boolean] pause a playing slideshow on hover
            },
            effect: {
                slide: {
                    // Slide effect settings.
                    speed: 1000
                    // [number] Speed in milliseconds of the slide animation.
                }
            },
            callback: {
                start: function (number) {
                    getSlideData(number, '#leftAdsSlider');
                }
            }
        });
        <% } else { %>
            getImageData('#leftAdsSlider');
        <% } %>

        <% if (RightBannersCount > 1) { %>
        //homepage right slider
        $("#rightAdsSlider").slidesjs({
            width: 140,
            height: 140,
            navigation: {
                active: false,
                effect: "slide"
            },
            pagination: {
                active: false
            },
            play: {
                active: false,
                // [boolean] Generate the play and stop buttons.
                // You cannot use your own buttons. Sorry.
                effect: "slide",
                // [string] Can be either "slide" or "fade".
                interval: <%=ScrollSpeed %>,
                // [number] Time spent on each slide in milliseconds.
                auto: true,
                // [boolean] Start playing the slideshow on load.
                swap: false,
                // [boolean] show/hide stop and play buttons
                pauseOnHover: false,
                // [boolean] pause a playing slideshow on hover
            },
            effect: {
                slide: {
                    // Slide effect settings.
                    speed: 1000
                    // [number] Speed in milliseconds of the slide animation.
                }
            },
            callback: {
                start: function (number) {
                    getSlideData(number, '#rightAdsSlider');
                }
            }
        });
        <% } else { %>
            getImageData('#rightAdsSlider');
        <% } %>
    });
</script>
<script type="text/javascript">
    $(function () {
        // multiple datasets
        $('#s-buy').typeahead(
            [
                {
                    name: 'Suburbs',
                    valueKey: 'name',
                    remote: '/SuburbAutoComplete.ashx?q=%QUERY&type=suburb',
                    header: '<p>Select suburb</p>',
                    limit: 100
                },
                {
                    name: 'Regions',
                    remote: '/SuburbAutoComplete.ashx?q=%QUERY&type=region',
                    header: '<p>Select region</p>'
                }
            ]);

        $('#s-rent').typeahead(
            [
                {
                    name: 'Suburbs',
                    valueKey: 'name',
                    remote: '/SuburbAutoComplete.ashx?q=%QUERY&type=suburb',
                    header: '<p>Select suburb</p>',
                    limit: 100
                },
                {
                    name: 'Regions',
                    remote: '/SuburbAutoComplete.ashx?q=%QUERY&type=region',
                    header: '<p>Select region</p>'
                }
            ]);

        $('#s-commercial').typeahead(
            [
                {
                    name: 'Suburbs',
                    valueKey: 'name',
                    remote: '/SuburbAutoComplete.ashx?q=%QUERY&type=suburb',
                    header: '<p>Select suburb</p>',
                    limit: 100
                },
                {
                    name: 'Regions',
                    remote: '/SuburbAutoComplete.ashx?q=%QUERY&type=region',
                    header: '<p>Select region</p>'
                }
            ]);

        $('#s-business').typeahead(
            [
                {
                    name: 'Suburbs',
                    valueKey: 'name',
                    remote: '/SuburbAutoComplete.ashx?q=%QUERY&type=suburb',
                    header: '<p>Select suburb</p>',
                    limit: 100
                },
                {
                    name: 'Regions',
                    remote: '/SuburbAutoComplete.ashx?q=%QUERY&type=region',
                    header: '<p>Select region</p>'
                }
            ]);


        $('#s-rural').typeahead(
            [
                {
                    name: 'Suburbs',
                    valueKey: 'name',
                    remote: '/SuburbAutoComplete.ashx?q=%QUERY&type=suburb',
                    header: '<p>Select suburb</p>',
                    limit: 100
                },
                {
                    name: 'Regions',
                    remote: '/SuburbAutoComplete.ashx?q=%QUERY&type=region',
                    header: '<p>Select region</p>'
                }
            ]);
    });
	</script>
<section class="front-page-top-block"><!-- FRONT PAGE TOP BLOCK -->
    <h1 class="front-page-title">SEARCH FOR QUEENSLAND PROPERTY FROM ACCREDITED AGENTS:</h1>
    <div class="front-box-wrapper">
        <!-- left banner -->
        <div class="front-page-banner-l">
            <div id="leftAdsSlider">
                <asp:Literal ID="leftAds" runat="server"></asp:Literal>
            </div>
        </div>
        <!-- search form -->
        <div class="front-page-c">        
            <section class="front-search-tab"><!-- front-search-tab -->    
                <section id="form-tab"><!-- FORM TAB (FIRST TAB) -->      
                  <ul class="nav">
                    <!-- TAB NAV -->
                    <li class="nav-one"><a href="#BuyTab"           <%if(DefaultTab == SearchTab.Buy) {%>class="current"<%} %>>BUY</a></li>
                    <li class="nav-two"><a href="#RentTab"          <%if(DefaultTab == SearchTab.Rent) {%>class="current"<%} %>>RENT</a></li>
                    <li class="nav-three"><a href="#CommercialTab"  <%if(DefaultTab == SearchTab.Commercial) {%>class="current"<%} %>>COMMERCIAL</a></li>
                    <li class="nav-four"><a href="#BusinessTab"     <%if(DefaultTab == SearchTab.Business) {%>class="current"<%} %>>BUSINESS</a></li>
                    <li class="nav-four"><a href="#RuralTab"        <%if(DefaultTab == SearchTab.Rural) {%>class="current"<%} %>>RURAL</a></li>
                  </ul>
                  <!-- TAB NAV -->      
                  <section class="list-wrap"><!-- TAB LIST WRAP -->
                    <form id="BuyTab" <%if(DefaultTab != SearchTab.Buy) {%>class="hide"<%} %> method="get" action="<%=Target %>">
                      <input type="hidden" name="st" value="sa" />
                      <ul class="form-view">
                        <h3>Find Qld properties from REIQ accredited agencies</h3>
                        <li class="mb5">
                          <input id="s-buy" name="txt" type="text" class="text-fi wi-457" value="<%=REIQ.usercontrols.PropertySearchBase.DefaultSearchText %>" onfocus="if(this.value=='<%=REIQ.usercontrols.PropertySearchBase.DefaultSearchText %>')this.value='';" onblur="if(this.value=='')this.value='<%=REIQ.usercontrols.PropertySearchBase.DefaultSearchText %>';"  />
                        </li>
                        <li class="checkbox-view"> 
                          <span class="tab-width">
                                <label><input name="surr" type="checkbox" value="1"/> incl. surrounding suburbs</label>
                          </span> 
                          <span class="tab-width2 checked">
                              <label><input checked="true" name="exoffer" type="checkbox" value="1"/> exclude properties under offers</label>
                          </span> 
                          <%--<span class="tab-width">
                              <label><input name="hoonly" type="checkbox" value="1"/> incl. open for inspection only</label>
                          </span> --%>
                        </li>
                        <li>
                          <div class="tab-width3">
                            <select name="ty" class="multiselectdropdown" multiple="multiple">
                              <%--<option value="">Property Type</option>--%>
                              <%foreach(var p in REIQ.Access.Lookups.ListPropertyTypes()) {%><option><%=p %></option>
                              <%} %>
                            </select>
                          </div>
                          <div class="tab-width3">
                            <select name="be">
                              <option value="">Min. Bedrooms</option>
                              <%foreach(var br in REIQ.Access.Lookups.ListNumberOfBedrooms()) {%><option value="<%=br.Key %>"><%=br.Value %></option>
                              <%} %>
                            </select>
                          </div>
                        </li>
                        <li>
                          <div class="tab-width3">
                            <select name="prl">
                              <option value="">Min. Price</option>
                              <%foreach(var price in REIQ.Access.Lookups.ListPrices(SearchTab.Buy)){ %><option value="<%=price.ToString() %>"><%=price.ToString("0,000") %></option>
                              <%} %>
                            </select> 
                          </div>
                          <div class="tab-width3">
                            <select name="prh">
                              <option value="">Max. Price</option>
                              <%foreach(var price in REIQ.Access.Lookups.ListPrices(SearchTab.Buy)){ %><option value="<%=price.ToString() %>"><%=price.ToString("0,000") %></option>
                              <%} %>
                            </select>
                          </div>
                          <input type="submit" class="red-btn" value="Search" />
                        </li>
                      </ul>
                    </form>
                    <form id="RentTab" <%if(DefaultTab != SearchTab.Rent) {%>class="hide"<%} %> method="get" action="<%=Target %>" style="display:none;">
                      <input type="hidden" name="st" value="ra" />
                      <ul class="form-view">
                        <h3>Find Qld properties from REIQ accredited agencies</h3>
                        <li class="mb5">
                          <input id="s-rent" name="txt" type="text" class="text-fi wi-457" value="Type in a suburb, postcode, region or property ID to begin your search" onfocus="if(this.value=='Type in a suburb, postcode, region or property ID to begin your search')this.value='';" onblur="if(this.value=='')this.value='Type in a suburb, postcode, region or property ID to begin your search';"  />
                        </li>
                        <li class="checkbox-view"> 
                            <span class="tab-width">
                                <label><input type="checkbox" name="surr" value="1" /> incl. surrounding suburbs</label>
                            </span> 
                            <span class="tab-width2">
                                <label><input type="checkbox"name="exoffer" value="1" checked="true"/> exclude properties under offers</label>
                            </span> 
                        </li>
                        <li>
                          <div class="tab-width3">
                            <select name="ty" class="multiselectdropdown" multiple="multiple">
                              <%foreach(var p in REIQ.Access.Lookups.ListPropertyTypes()) {%><option><%=p %></option>
                              <%} %>
                            </select>
                          </div>
                          <div class="tab-width3">
                            <select name="be">
                              <option value="">Min. Bedrooms</option>
                              <%foreach(var br in REIQ.Access.Lookups.ListNumberOfBedrooms()) {%><option value="<%=br.Key %>"><%=br.Value %></option>
                              <%} %>
                            </select>
                          </div>
                        </li>
                        <li>
                          <div class="tab-width3">
                            <select name="prl">
                              <option value="">Min. Price</option>
                              <%foreach(var price in REIQ.Access.Lookups.ListPrices(SearchTab.Rent)){ %><option value="<%=price.ToString() %>"><%=price.ToString().Length > 3 ? price.ToString("0,000") : price.ToString() %></option>
                              <%} %>
                            </select>
                          </div>
                          <div class="tab-width3">
                            <select name="prh">
                              <option value="">Max. Price</option>
                              <%foreach(var price in REIQ.Access.Lookups.ListPrices(SearchTab.Rent)){ %><option value="<%=price.ToString() %>"><%=price.ToString().Length > 3 ? price.ToString("0,000") : price.ToString() %></option>
                              <%} %>
                            </select>
                          </div>
                          <input type="submit" class="red-btn" value="Search" />
                        </li>
                      </ul>
                    </form>
                    <form id="CommercialTab" <%if(DefaultTab != SearchTab.Commercial) {%>class="hide"<%} %> method="get" action="<%=Target %>" style="display:none;">
                      <ul class="form-view">
                        <h3>Find Qld properties from REIQ accredited agencies</h3>
                        <li class="mb5">
                          <input id="s-commercial" name="txt" type="text" class="text-fi wi-457" value="Type in a suburb, postcode, region or property ID to begin your search" onfocus="if(this.value=='Type in a suburb, postcode, region or property ID to begin your search')this.value='';" onblur="if(this.value=='')this.value='Type in a suburb, postcode, region or property ID to begin your search';"  />
                        </li>
                        <li class="checkbox-view"> 
                            <span class="tab-width">
                                <label><input type="radio" name="st" value="co" checked="checked"/> For Sale</label>
                            </span> 
                            <span class="tab-width2">
                                <label><input type="radio" name="st" value="cr"/> For Lease</label>
                            </span>
                        </li>
                        <li class="checkbox-view"> 
                            <span class="tab-width">
                                <label><input type="checkbox" name="surr" value="1" /> incl. surrounding suburbs</label>
                            </span> 
                            <span class="tab-width2">
                                <label><input type="checkbox" name="exoffer" value="1" checked="true"/> exclude properties under offers</label>
                            </span> 
                        </li>
                        <li>
                          <div class="tab-width3">
                            <select name="prl">
                              <option value="">Min. Price</option>
                              <%foreach(var price in REIQ.Access.Lookups.ListPrices(SearchTab.Commercial)){ %><option value="<%=price.ToString() %>"><%=price.ToString("0,000") %></option>
                              <%} %>
                            </select>
                          </div>
                          <div class="tab-width3">
                            <select name="prh">
                              <option value="">Max. Price</option>
                              <%foreach(var price in REIQ.Access.Lookups.ListPrices(SearchTab.Commercial)){ %><option value="<%=price.ToString() %>"><%=price.ToString("0,000") %></option>
                              <%} %>
                            </select>
                          </div>
                          <input type="submit" class="red-btn" value="Search" />
                        </li>
                      </ul>
                    </form>
                    <form id="BusinessTab" <%if(DefaultTab != SearchTab.Business) {%>class="hide"<%} %> method="get" action="<%=Target %>" style="display:none;">
                      <input type="hidden" name="st" value="bu" />
                      <ul class="form-view">
                        <h3>Find Qld businesses from REIQ accredited agencies</h3>
                        <li class="mb5">
                          <input id="s-business" name="txt" type="text" class="text-fi wi-457" value="Type in a suburb, postcode, region or property ID to begin your search" onfocus="if(this.value=='Type in a suburb, postcode, region or property ID to begin your search')this.value='';" onblur="if(this.value=='')this.value='Type in a suburb, postcode, region or property ID to begin your search';"  />
                        </li>
                        <li class="checkbox-view"> 
                            <span class="tab-width">
                                <label><input type="checkbox" name="surr" value="1" /> incl. surrounding suburbs</label>
                            </span> 
                            <span class="tab-width2">
                                <label><input type="checkbox" name="exoffer" value="1" checked="true"/> exclude properties under offers</label>
                            </span> 
                        </li>
                        <li>
                          <div class="tab-width3">
                            <select name="prl">
                              <option value="">Min. Price</option>
                              <%foreach(var price in REIQ.Access.Lookups.ListPrices(SearchTab.Business)){ %><option value="<%=price.ToString() %>"><%=price.ToString("0,000") %></option>
                              <%} %>
                            </select>
                          </div>
                          <div class="tab-width3">
                            <select name="prh">
                              <option value="">Max. Price</option>
                              <%foreach(var price in REIQ.Access.Lookups.ListPrices(SearchTab.Business)){ %><option value="<%=price.ToString() %>"><%=price.ToString("0,000") %></option>
                              <%} %>
                            </select>
                          </div>
                          <input type="submit" class="red-btn" value="Search" />
                        </li>
                      </ul>
                    </form>
                    <form id="RuralTab" <%if(DefaultTab != SearchTab.Rural) {%>class="hide"<%} %> method="get" action="<%=Target %>" style="display:none;">
                      <input type="hidden" name="st" value="ru" />
                      <ul class="form-view">
                        <h3>Find Qld properties from REIQ accredited agencies</h3>
                        <li class="mb5">
                          <input id="s-rural" name="txt" type="text" class="text-fi wi-457" value="Type in a suburb, postcode, region or property ID to begin your search" onfocus="if(this.value=='Type in a suburb, postcode, region or property ID to begin your search')this.value='';" onblur="if(this.value=='')this.value='Type in a suburb, postcode, region or property ID to begin your search';"  />
                        </li>
                        <li class="checkbox-view"> 
                            <span class="tab-width">
                                <label><input type="checkbox" name="surr" value="1" /> incl. surrounding suburbs</label>
                            </span> 
                            <span class="tab-width2">
                                <label><input type="checkbox" name="exoffer" value="1" checked="true"/> exclude properties under offers</label>
                            </span> 
                            <span class="tab-width2">
                                <label><input type="checkbox" name="hoonly" value="1" /> incl. open for inspection only</label>
                            </span> 

                        </li>
                        <li>
                          <div class="tab-width3">
                            <select name="prl">
                              <option value="">Min. Price</option>
                              <%foreach(var price in REIQ.Access.Lookups.ListPrices(SearchTab.Rural)){ %><option value="<%=price.ToString() %>"><%=price.ToString("0,000") %></option>
                              <%} %>
                            </select>
                          </div>
                          <div class="tab-width3">
                            <select name="prh">
                              <option value="">Max. Price</option>
                              <%foreach(var price in REIQ.Access.Lookups.ListPrices(SearchTab.Rural)){ %><option value="<%=price.ToString() %>"><%=price.ToString("0,000") %></option>
                              <%} %>
                            </select>
                          </div>
                          <input type="submit" class="red-btn" value="Search" />
                        </li>
                      </ul>
                    </form>
                  </section>
                  <!-- END List Wrap -->
                  <div class="clear"></div>
                </section> 
            </section><!-- /front-search-tab -->
        </div>
        <!-- right banner -->
        <div class="front-page-banner-r" >
            <div id="rightAdsSlider">
                <asp:Literal ID="rightAds" runat="server"></asp:Literal>
            </div>
        </div>         
    </div>
</section>


