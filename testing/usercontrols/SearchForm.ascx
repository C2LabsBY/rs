<%@ Control Language="C#" AutoEventWireup="false" Inherits="System.Web.UI.UserControl" %>
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
    public string Target = "/results/";
</script>

<section class="front-page-top-block"><!-- FRONT PAGE TOP BLOCK -->
  <h1 class="front-page-title">SEARCH FOR QUEENSLAND PROPERTY FROM ACCREDITED AGENTS:</h1>
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
              <input name="txt" type="text" class="text-fi wi-457" value="Type in a suburb, postcode, region or property ID to begin your search" onfocus="if(this.value=='Type in a suburb, postcode, region or property ID to begin your search')this.value='';" onblur="if(this.value=='')this.value='Type in a suburb, postcode, region or property ID to begin your search';"  />
            </li>
            <li class="checkbox-view"> 
              <span class="tab-width">
                    <label><input name="surr" type="checkbox" value="1"/> incl. surrounding suburbs</label>
              </span> 
              <span class="tab-width2">
                  <label><input name="exoffer" type="checkbox" value="1"/> exclude properties under offers</label>
              </span> 
              <span class="tab-width">
                  <label><input name="hoonly" type="checkbox" value="1"/> incl. open for inspection only</label>
              </span> 
            </li>
            <li>
              <div class="tab-width3">
                <select name="ty" class="multiselectdropdown" multiple="multiple">
                  <option value="">Property Type</option>
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
                  <%foreach(var price in REIQ.Access.Lookups.ListPrices(SearchTab.Buy)){ %><option><%=price.ToString("0,000") %></option>
                  <%} %>
                </select> 
              </div>
              <div class="tab-width3">
                <select name="prh">
                  <option value="">Max. Price</option>
                  <%foreach(var price in REIQ.Access.Lookups.ListPrices(SearchTab.Buy)){ %><option><%=price.ToString("0,000") %></option>
                  <%} %>
                </select>
              </div>
              <input type="submit" class="red-btn" value="Search" />
            </li>
          </ul>
        </form>
        <form id="RentTab" <%if(DefaultTab != SearchTab.Rent) {%>class="hide"<%} %> method="get" action="<%=Target %>">
          <input type="hidden" name="st" value="ra" />
          <ul class="form-view">
            <h3>Find Qld properties from REIQ accredited agencies</h3>
            <li class="mb5">
              <input name="txt" type="text" class="text-fi wi-457" value="Type in a suburb, postcode, region or property ID to begin your search" onfocus="if(this.value=='Type in a suburb, postcode, region or property ID to begin your search')this.value='';" onblur="if(this.value=='')this.value='Type in a suburb, postcode, region or property ID to begin your search';"  />
            </li>
            <li class="checkbox-view"> 
                <span class="tab-width">
                    <label><input type="checkbox" name="surr" value="1" /> incl. surrounding suburbs</label>
                </span> 
                <span class="tab-width2">
                    <label><input type="checkbox"name="exoffer" value="1"/> exclude properties under offers</label>
                </span> 
            </li>
            <li>
              <div class="tab-width3">
                <select name="ty" class="multiselectdropdown" multiple="multiple">
                  <option value="">Property Type</option>
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
                  <%foreach(var price in REIQ.Access.Lookups.ListPrices(SearchTab.Rent)){ %><option><%=price.ToString() %></option>
                  <%} %>
                </select>
              </div>
              <div class="tab-width3">
                <select name="prh">
                  <option value="">Max. Price</option>
                  <%foreach(var price in REIQ.Access.Lookups.ListPrices(SearchTab.Rent)){ %><option><%=price.ToString() %></option>
                  <%} %>
                </select>
              </div>
              <input type="submit" class="red-btn" value="Search" />
            </li>
          </ul>
        </form>
        <form id="CommercialTab" <%if(DefaultTab != SearchTab.Commercial) {%>class="hide"<%} %> method="get" action="<%=Target %>">
          <ul class="form-view">
            <h3>Find Qld properties from REIQ accredited agencies</h3>
            <li class="mb5">
              <input name="txt" type="text" class="text-fi wi-457" value="Type in a suburb, postcode, region or property ID to begin your search" onfocus="if(this.value=='Type in a suburb, postcode, region or property ID to begin your search')this.value='';" onblur="if(this.value=='')this.value='Type in a suburb, postcode, region or property ID to begin your search';"  />
            </li>
            <li class="checkbox-view"> 
                <span class="tab-width">
                    <label><input type="radio" name="st" value="co"/> For Sale</label>
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
                    <label><input type="checkbox" name="exoffer" value="1" /> exclude properties under offers</label>
                </span> 
            </li>
            <li>
              <div class="tab-width3">
                <select name="prl">
                  <option value="">Min. Price</option>
                  <%foreach(var price in REIQ.Access.Lookups.ListPrices(SearchTab.Commercial)){ %><option><%=price.ToString() %></option>
                  <%} %>
                </select>
              </div>
              <div class="tab-width3">
                <select name="prh">
                  <option value="">Max. Price</option>
                  <%foreach(var price in REIQ.Access.Lookups.ListPrices(SearchTab.Commercial)){ %><option><%=price.ToString() %></option>
                  <%} %>
                </select>
              </div>
              <input type="submit" class="red-btn" value="Search" />
            </li>
          </ul>
        </form>
        <form id="BusinessTab" <%if(DefaultTab != SearchTab.Business) {%>class="hide"<%} %> method="get" action="<%=Target %>">
          <input type="hidden" name="st" value="bu" />
          <ul class="form-view">
            <h3>Find Qld businesses from REIQ accredited agencies</h3>
            <li class="mb5">
              <input name="txt" type="text" class="text-fi wi-457" value="Type in a suburb, postcode, region or property ID to begin your search" onfocus="if(this.value=='Type in a suburb, postcode, region or property ID to begin your search')this.value='';" onblur="if(this.value=='')this.value='Type in a suburb, postcode, region or property ID to begin your search';"  />
            </li>
            <li class="checkbox-view"> 
                <span class="tab-width">
                    <label><input type="checkbox" name="surr" value="1" /> incl. surrounding suburbs</label>
                </span> 
                <span class="tab-width2">
                    <label><input type="checkbox" name="exoffer" value="1" /> exclude properties under offers</label>
                </span> 
            </li>
            <li>
              <div class="tab-width3">
                <select name="prl">
                  <option value="">Min. Price</option>
                  <%foreach(var price in REIQ.Access.Lookups.ListPrices(SearchTab.Business)){ %><option><%=price.ToString() %></option>
                  <%} %>
                </select>
              </div>
              <div class="tab-width3">
                <select name="prh">
                  <option value="">Max. Price</option>
                  <%foreach(var price in REIQ.Access.Lookups.ListPrices(SearchTab.Business)){ %><option><%=price.ToString() %></option>
                  <%} %>
                </select>
              </div>
              <input type="submit" class="red-btn" value="Search" />
            </li>
          </ul>
        </form>
        <form id="RuralTab" <%if(DefaultTab != SearchTab.Rural) {%>class="hide"<%} %> method="get" action="<%=Target %>">
          <input type="hidden" name="st" value="ru" />
          <ul class="form-view">
            <h3>Find Qld properties from REIQ accredited agencies</h3>
            <li class="mb5">
              <input type="text" class="text-fi wi-457" value="Type in a suburb, postcode, region or property ID to begin your search" onfocus="if(this.value=='Type in a suburb, postcode, region or property ID to begin your search')this.value='';" onblur="if(this.value=='')this.value='Type in a suburb, postcode, region or property ID to begin your search';"  />
            </li>
            <li class="checkbox-view"> 
                <span class="tab-width">
                    <label><input type="checkbox" name="surr" value="1" /> incl. surrounding suburbs</label>
                </span> 
                <span class="tab-width2">
                    <label><input type="checkbox" name="exoffer" value="1" /> exclude properties under offers</label>
                </span> 
                <span class="tab-width2">
                    <label><input type="checkbox" name="hoonly" value="1" /> incl. open for inspection only</label>
                </span> 

            </li>
            <li>
              <div class="tab-width3">
                <select name="prl">
                  <option value="">Min. Price</option>
                  <%foreach(var price in REIQ.Access.Lookups.ListPrices(SearchTab.Rural)){ %><option><%=price.ToString() %></option>
                  <%} %>
                </select>
              </div>
              <div class="tab-width3">
                <select name="prh">
                  <option value="">Max. Price</option>
                  <%foreach(var price in REIQ.Access.Lookups.ListPrices(SearchTab.Rural)){ %><option><%=price.ToString() %></option>
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
    <!-- /FORM TAB (FIRST TAB) --> 
  </section>
  <!-- /front-search-tab --> 
</section>
