<%@ Control Language="C#" AutoEventWireup="true" Inherits="usercontrols_SearchForm_EbeddableAsMacro" CodeFile="SearchForm_EbeddableAsMacro.ascx.cs"%>
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

    
</script>

<script type="text/javascript" src="/basemedia/scripts/typeahead.min.js"></script>
<link rel="stylesheet" type="text/css" href="/basemedia/css/autocomplete.css" media="all">
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

	    function search_buy() {
	        var string = '/results?st=sa';

	        string += '&txt=' + $('#s-buy').val();

	        if ($('#surr_buy:checked').val() == '1')
	            string += '&surr=' + $('#surr_buy:checked').val();

	        if ($('#exoffer_buy:checked').val() == '1')
	            string += '&exoffer=' + $('#exoffer_buy:checked').val();
	        
	        string += '&be=' + $('#be_buy').val();
	        string += '&prl=' + $('#prl_buy').val();
	        string += '&prh=' + $('#prh_buy').val();

	        var selected = $("#ty-buy option:selected").map(function () { return this.value }).get();
	        for (var i = 0; i < selected.length; i++) {
	            string += '&ty=' + selected[i];
	        }

	        window.location.href = string;
	    }

	    function search_rent() {
	        var string = '/results?st=ra';

	        string += '&txt=' + $('#s-rent').val();

	        if ($('#surr_rent:checked').val() == '1')
	            string += '&surr=' + $('#surr_rent:checked').val();

	        if ($('#exoffer_rent:checked').val() == '1')
	            string += '&exoffer=' + $('#exoffer_rent:checked').val();

	        string += '&be=' + $('#be_rent').val();
	        string += '&prl=' + $('#prl_rent').val();
	        string += '&prh=' + $('#prh_rent').val();

	        var selected = $("#ty-rent option:selected").map(function () { return this.value }).get();
	        for (var i = 0; i < selected.length; i++) {
	            string += '&ty=' + selected[i];
	        }

	        window.location.href = string;
	    }

	    function search_comm() {
	        var string = '/results?';

	        if ($('#st_commsale:checked').val() == 'co')
	            string += 'st=co';

	        if ($('#st_commlease:checked').val() == 'cr')
	            string += 'st=cr';

	        string += '&txt=' + $('#s-commercial').val();

	        if ($('#surr_comm:checked').val() == '1')
	            string += '&surr=' + $('#surr_comm:checked').val();

	        if ($('#exoffer_comm:checked').val() == '1')
	            string += '&exoffer=' + $('#exoffer_comm:checked').val();

	        string += '&prl=' + $('#prl_comm').val();
	        string += '&prh=' + $('#prh_comm').val();

	        window.location.href = string;
	    }

	    function search_bus() {
	        var string = '/results?st=bu';

	        string += '&txt=' + $('#s-business').val();

	        if ($('#surr_bus:checked').val() == '1')
	            string += '&surr=' + $('#surr_bus:checked').val();

	        if ($('#exoffer_bus:checked').val() == '1')
	            string += '&exoffer=' + $('#exoffer_bus:checked').val();

	        string += '&prl=' + $('#prl_bus').val();
	        string += '&prh=' + $('#prh_bus').val();

	        window.location.href = string;
	    }

	    function search_rur() {
	        var string = '/results?st=ru';

	        string += '&txt=' + $('#s-rural').val();

	        if ($('#surr_rur:checked').val() == '1')
	            string += '&surr=' + $('#surr_rur:checked').val();

	        if ($('#exoffer_rur:checked').val() == '1')
	            string += '&exoffer=' + $('#exoffer_rur:checked').val();

	        if ($('#hoonly_rur:checked').val() == '1')
	            string += '&hoonly=' + $('#hoonly_rur:checked').val();

	        string += '&prl=' + $('#prl_rur').val();
	        string += '&prh=' + $('#prh_rur').val();

	        window.location.href = string;
	    }
	</script>

<%--<section class="front-page-top-block"><!-- FRONT PAGE TOP BLOCK -->
  <h1 class="front-page-title">SEARCH FOR QUEENSLAND PROPERTY FROM ACCREDITED AGENTS:</h1>--%>
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
        <%--<form id="BuyTab" <%if(DefaultTab != SearchTab.Buy) {%>class="hide"<%} %> method="get" action="<%=Target %>">--%>
          <section id="BuyTab" <%if(DefaultTab != SearchTab.Buy) {%>class="hide"<%} %>>
          <input type="hidden" name="st" value="sa" />
          <ul class="form-view">
            <h3>Find Qld properties from REIQ accredited agencies</h3>
            <li class="mb5">
              <input id="s-buy" name="txt" type="text" class="text-fi wi-457" value='<%= REIQ.usercontrols.PropertySearchBase.DefaultSearchText %>' onfocus="if(this.value=='<%=REIQ.usercontrols.PropertySearchBase.DefaultSearchText %>')this.value='';" onblur="if(this.value=='')this.value='<%=REIQ.usercontrols.PropertySearchBase.DefaultSearchText %>';"  />
                <%--<asp:TextBox ID="tbSearch_Buy" ClientIDMode="Static" runat="server" CssClass="text-fi wi-457"></asp:TextBox>--%>
            </li>
              
            <li class="checkbox-view"> 
              <span class="tab-width">
                    <label><input id="surr_buy" name="surr" type="checkbox" value="1"/> incl. surrounding suburbs</label>
              </span> 
              <span class="tab-width2 checked">
                  <label><input checked="1" id="exoffer_buy" name="exoffer" type="checkbox" value="1"/> exclude properties under offers</label>
              </span> 
              <%--<span class="tab-width">
                  <label><input name="hoonly" type="checkbox" value="1"/> incl. open for inspection only</label>
              </span> --%>
            </li>
            <li>
              <div class="tab-width3">
                <select id="ty-buy" name="ty" class="multiselectdropdown" multiple="multiple">
                  <%foreach(var p in REIQ.Access.Lookups.ListPropertyTypes()) {%><option><%=p %></option>
                  <%} %>
                </select>
                  <%--<asp:CheckBoxList ID="chblType" runat="server" RepeatLayout="Flow"></asp:CheckBoxList>--%>
              </div>
              <div class="tab-width3">
                <select name="be" id="be_buy">
                  <option value="">Min. Bedrooms</option>
                  <%foreach(var br in REIQ.Access.Lookups.ListNumberOfBedrooms()) {%><option value="<%=br.Key %>"><%=br.Value %></option>
                  <%} %>
                </select>
              </div>
            </li>
            <li>
              <div class="tab-width3">
                <select name="prl" id="prl_buy">
                  <option value="">Min. Price</option>
                  <%foreach(var price in REIQ.Access.Lookups.ListPrices(SearchTab.Buy)){ %><option value="<%=price.ToString() %>"><%=price.ToString("0,000") %></option>
                  <%} %>
                </select> 
              </div>
              <div class="tab-width3">
                <select name="prh" id="prh_buy">
                  <option value="">Max. Price</option>
                  <%foreach(var price in REIQ.Access.Lookups.ListPrices(SearchTab.Buy)){ %><option value="<%=price.ToString() %>"><%=price.ToString("0,000") %></option>
                  <%} %>
                </select>
              </div>
              <input type="submit" class="red-btn" value="Search" onclick="javascript: search_buy(); return false;"/>
                <%--<asp:Button ID="btnSearch_BuyTab" runat="server" Text="Search" CssClass="red-btn" OnClick="btnSearch_BuyTab_Click"/>--%>
            </li>
          </ul>
        <%--</form>
        <form id="RentTab" <%if(DefaultTab != SearchTab.Rent) {%>class="hide"<%} %> method="get" action="<%=Target %>">--%>
              </section>
          <section id="RentTab" <%if(DefaultTab != SearchTab.Rent) {%>class="hide"<%} %>>
          <input type="hidden" name="st" value="ra" />
          <ul class="form-view">
            <h3>Find Qld properties from REIQ accredited agencies</h3>
            <li class="mb5">
              <input id="s-rent" name="txt" type="text" class="text-fi wi-457" value="Type in a suburb, postcode, region or property ID to begin your search" onfocus="if(this.value=='Type in a suburb, postcode, region or property ID to begin your search')this.value='';" onblur="if(this.value=='')this.value='Type in a suburb, postcode, region or property ID to begin your search';"  />
            </li>
            <li class="checkbox-view"> 
                <span class="tab-width">
                    <label><input type="checkbox" name="surr" id="surr_rent" value="1" /> incl. surrounding suburbs</label>
                </span> 
                <span class="tab-width2">
                    <label><input type="checkbox"name="exoffer" id="exoffer_rent" value="1" checked="true"/> exclude properties under offers</label>
                </span> 
            </li>
            <li>
              <div class="tab-width3">
                <select name="ty" id="ty_rent" class="multiselectdropdown" multiple="multiple">
                  <%foreach(var p in REIQ.Access.Lookups.ListPropertyTypes()) {%><option><%=p %></option>
                  <%} %>
                </select>
              </div>
              <div class="tab-width3">
                <select name="be" id="be_rent">
                  <option value="">Min. Bedrooms</option>
                  <%foreach(var br in REIQ.Access.Lookups.ListNumberOfBedrooms()) {%><option value="<%=br.Key %>"><%=br.Value %></option>
                  <%} %>
                </select>
              </div>
            </li>
            <li>
              <div class="tab-width3">
                <select name="prl" id="prl_rent">
                  <option value="">Min. Price</option>
                  <%foreach(var price in REIQ.Access.Lookups.ListPrices(SearchTab.Rent)){ %><option value="<%=price.ToString() %>"><%=price.ToString().Length > 3 ? price.ToString("0,000") : price.ToString() %></option>
                  <%} %>
                </select>
              </div>
              <div class="tab-width3">
                <select name="prh" id="prh_rent">
                  <option value="">Max. Price</option>
                  <%foreach(var price in REIQ.Access.Lookups.ListPrices(SearchTab.Rent)){ %><option value="<%=price.ToString() %>"><%=price.ToString().Length > 3 ? price.ToString("0,000") : price.ToString() %></option>
                  <%} %>
                </select>
              </div>
              <input type="submit" class="red-btn" value="Search" onclick="javascript: search_rent(); return false;"/>
            </li>
          </ul>
        <%--</form>
        <form id="CommercialTab" <%if(DefaultTab != SearchTab.Commercial) {%>class="hide"<%} %> method="get" action="<%=Target %>">--%>
              </section>
          <section id="CommercialTab" <%if(DefaultTab != SearchTab.Commercial) {%>class="hide"<%} %>>
          <ul class="form-view">
            <h3>Find Qld properties from REIQ accredited agencies</h3>
            <li class="mb5">
              <input id="s-commercial" name="txt" type="text" class="text-fi wi-457" value="Type in a suburb, postcode, region or property ID to begin your search" onfocus="if(this.value=='Type in a suburb, postcode, region or property ID to begin your search')this.value='';" onblur="if(this.value=='')this.value='Type in a suburb, postcode, region or property ID to begin your search';"  />
            </li>
            <li class="checkbox-view"> 
                <span class="tab-width">
                    <label><input type="radio" name="st" id="st_commsale" value="co" checked="checked"/> For Sale</label>
                </span> 
                <span class="tab-width2">
                    <label><input type="radio" name="st" id="st_commlease" value="cr"/> For Lease</label>
                </span>
            </li>
            <li class="checkbox-view"> 
                <span class="tab-width">
                    <label><input type="checkbox" name="surr" id="surr_comm" value="1" /> incl. surrounding suburbs</label>
                </span> 
                <span class="tab-width2">
                    <label><input type="checkbox" name="exoffer" id="exoffer_comm" value="1" checked="true"/> exclude properties under offers</label>
                </span> 
            </li>
            <li>
              <div class="tab-width3">
                <select name="prl" id="prl_comm">
                  <option value="">Min. Price</option>
                  <%foreach(var price in REIQ.Access.Lookups.ListPrices(SearchTab.Commercial)){ %><option value="<%=price.ToString() %>"><%=price.ToString("0,000") %></option>
                  <%} %>
                </select>
              </div>
              <div class="tab-width3">
                <select name="prh" id="prh_comm">
                  <option value="">Max. Price</option>
                  <%foreach(var price in REIQ.Access.Lookups.ListPrices(SearchTab.Commercial)){ %><option value="<%=price.ToString() %>"><%=price.ToString("0,000") %></option>
                  <%} %>
                </select>
              </div>
              <input type="submit" class="red-btn" value="Search" onclick="javascript: search_comm(); return false;"/>
            </li>
          </ul>
        <%--</form>
        <form id="BusinessTab" <%if(DefaultTab != SearchTab.Business) {%>class="hide"<%} %> method="get" action="<%=Target %>">--%>
               </section>
          <section id="BusinessTab"  <%if(DefaultTab != SearchTab.Business) {%>class="hide"<%} %>>
          <input type="hidden" name="st" value="bu" />
          <ul class="form-view">
            <h3>Find Qld businesses from REIQ accredited agencies</h3>
            <li class="mb5">
              <input id="s-business" name="txt" type="text" class="text-fi wi-457" value="Type in a suburb, postcode, region or property ID to begin your search" onfocus="if(this.value=='Type in a suburb, postcode, region or property ID to begin your search')this.value='';" onblur="if(this.value=='')this.value='Type in a suburb, postcode, region or property ID to begin your search';"  />
            </li>
            <li class="checkbox-view"> 
                <span class="tab-width">
                    <label><input type="checkbox" name="surr" id="surr_bus" value="1" /> incl. surrounding suburbs</label>
                </span> 
                <span class="tab-width2">
                    <label><input type="checkbox" name="exoffer" id="exoffer_bus" value="1" checked="true"/> exclude properties under offers</label>
                </span> 
            </li>
            <li>
              <div class="tab-width3">
                <select name="prl" id="prl_bus">
                  <option value="">Min. Price</option>
                  <%foreach(var price in REIQ.Access.Lookups.ListPrices(SearchTab.Business)){ %><option value="<%=price.ToString() %>"><%=price.ToString("0,000") %></option>
                  <%} %>
                </select>
              </div>
              <div class="tab-width3">
                <select name="prh" id="prh_bus">
                  <option value="">Max. Price</option>
                  <%foreach(var price in REIQ.Access.Lookups.ListPrices(SearchTab.Business)){ %><option value="<%=price.ToString() %>"><%=price.ToString("0,000") %></option>
                  <%} %>
                </select>
              </div>
              <input type="submit" class="red-btn" value="Search" onclick="javascript: search_bus(); return false;"/>
            </li>
          </ul>
        <%--</form>
        <form id="RuralTab" <%if(DefaultTab != SearchTab.Rural) {%>class="hide"<%} %> method="get" action="<%=Target %>">--%>
              </section>
          <section id="RuralTab" <%if(DefaultTab != SearchTab.Rural) {%>class="hide"<%} %> >
          <input type="hidden" name="st" value="ru" />
          <ul class="form-view">
            <h3>Find Qld properties from REIQ accredited agencies</h3>
            <li class="mb5">
              <input id="s-rural" name="txt" type="text" class="text-fi wi-457" value="Type in a suburb, postcode, region or property ID to begin your search" onfocus="if(this.value=='Type in a suburb, postcode, region or property ID to begin your search')this.value='';" onblur="if(this.value=='')this.value='Type in a suburb, postcode, region or property ID to begin your search';"  />
            </li>
            <li class="checkbox-view"> 
                <span class="tab-width">
                    <label><input type="checkbox" name="surr" id="surr_rur" value="1" /> incl. surrounding suburbs</label>
                </span> 
                <span class="tab-width2">
                    <label><input type="checkbox" name="exoffer" id="exoffer_rur" value="1" checked="true"/> exclude properties under offers</label>
                </span> 
                <span class="tab-width2">
                    <label><input type="checkbox" name="hoonly" id="hoonly_rur" value="1" /> incl. open for inspection only</label>
                </span> 

            </li>
            <li>
              <div class="tab-width3">
                <select name="prl" id="prl_rur">
                  <option value="">Min. Price</option>
                  <%foreach(var price in REIQ.Access.Lookups.ListPrices(SearchTab.Rural)){ %><option value="<%=price.ToString() %>"><%=price.ToString("0,000") %></option>
                  <%} %>
                </select>
              </div>
              <div class="tab-width3">
                <select name="prh" id="prh_rur">
                  <option value="">Max. Price</option>
                  <%foreach(var price in REIQ.Access.Lookups.ListPrices(SearchTab.Rural)){ %><option value="<%=price.ToString() %>"><%=price.ToString("0,000") %></option>
                  <%} %>
                </select>
              </div>
              <input type="submit" class="red-btn" value="Search" onclick="javascript: search_rur(); return false;"/>
            </li>
          </ul>
        </section>
      </section>
      <!-- END List Wrap -->
      <div class="clear"></div>
    </section>
    <!-- /FORM TAB (FIRST TAB) --> 
  </section>
  <!-- /front-search-tab --> 
<%--</section>--%>
