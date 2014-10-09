<%@ Control Language="C#" AutoEventWireup="true" CodeFile="GoogleMapsStreet.ascx.cs" Inherits="usercontrols_GoogleMapsStreet" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <style>
        body {
            margin: 0;
            padding: 0;
        }
    </style>
    <link rel="stylesheet" type="text/css" href="/basemedia/css/style.css" media="all"/>
    <script language="JavaScript">
    <!--

    function SymError() {
        return true;
    }

    window.onerror = SymError;

    var SymRealWinOpen = window.open;

    function SymWinOpen(url, name, attributes) {
        return (new Object());
    }

    window.open = SymWinOpen;

    //-->
    </script>
    <script type='text/javascript'>
        var myPano;
        var geocoder = null;
        var XL = "", YL = "";
        function initialize(address) {
            var fenwayPark;
            geocoder = new google.maps.Geocoder();

            if (geocoder) {
                geocoder.geocode({ 'address': address }, function (results, status) {
                    if (status == google.maps.GeocoderStatus.OK) {

                        var fenwayPark = results[0].geometry.location;

                        var panoramaOptions = {
                            position: fenwayPark,allowfullscreen : true,
                            pov: {
                                heading: 35,
                                pitch: 5,
                                zoom: 1
                            }
                        };

                        var panorama = new google.maps.StreetViewPanorama(
                            document.getElementById('pano'),
                            panoramaOptions);

                        var service = new google.maps.StreetViewService();
                        service.getPanoramaByLocation(fenwayPark, 50, showPanoData);

                    }
                    else {
                        //fenwayPark = new google.maps.LatLng(-19.7061, 145.774002);
                        document.getElementById('pano').style.display = "none";
                        document.getElementById('additionalContent').style.display = "none";
                        document.getElementById('nomap').style.display = "inline";
                    }
                });
            }
        }

        function showPanoData(panoData, status) {
            if (status != google.maps.StreetViewStatus.OK) {
                fenwayPark = new google.maps.LatLng(-19.7061, 145.774002);
                document.getElementById('pano').style.display = "none";
                document.getElementById('additionalContent').style.display = "none";
                document.getElementById('nomap').style.display = "inline";
                return;
            }
            //$('#pano').show();
            
            };

        function onGDirectionsLoad() {

            // Use this function to access information about the latest load()
            // results.          
        }
    </script>
    <script type="text/javascript" src="//maps.googleapis.com/maps/api/js?sensor=false"></script>
</head>
<body onload="initialize('<%=address %>');">
    <div name="pano" id="pano" style="width: 616px; height: 402px"></div>
    <div id="nomap" style="display:none;"><h2><%= address %> was not found on Google Street View</h2><br /></div>
    <div id="additionalContent">
        <a class="nav1" href="javascript:initialize('<%=address %>');">PLEASE CLICK HERE IF YOU ARE UNABLE TO VIEW THE STREET VIEW</a><br />
        <br />
        <font size="2">Please note: these street images were taken sometime between Nov 2007 & Feb 2008 </font>
        <br />
        <font size="2">Please note that some properties do not match the address.  <%--<a class="nav" href="/subpages/WarrantyGoogle.aspx" target="_blank">No Warranty</a>.--%>  </font>
        <br />
        <font size="2">This map is produced by <a href="http://maps.google.com/" class="nav" target="_new">Google</a> and <a href="/" class="nav" target="_new">REIQ</a>; for more information please email <a class="nav" href="mailto:<%=ConfigurationManager.AppSettings["adminemail"].ToString() %>"><%=ConfigurationManager.AppSettings["adminemail"].ToString() %></a></font>
    </div>
</body>
</html>
<script language="JavaScript">
<!--
    var SymRealOnLoad;
    var SymRealOnUnload;

    function SymOnUnload() {
        window.open = SymWinOpen;
        if (SymRealOnUnload != null)
            SymRealOnUnload();
    }

    function SymOnLoad() {
        if (SymRealOnLoad != null)
            SymRealOnLoad();
        window.open = SymRealWinOpen;
        SymRealOnUnload = window.onunload;
        window.onunload = SymOnUnload;
    }

    SymRealOnLoad = window.onload;
    window.onload = SymOnLoad;

    //-->
</script>
