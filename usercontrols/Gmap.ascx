<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Gmap.ascx.cs" Inherits="usercontrols_Gmap" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <style>
        body {
            margin: 0;
            padding: 0;
        }
    </style>
    <link rel="stylesheet" type="text/css" href="/basemedia/css/style.css" media="all">
    <script type="text/javascript" src="//maps.googleapis.com/maps/api/js?sensor=false"></script>
</head>
<body onload="load()">
    <script type='text/javascript'>
    <!--
    var map = null;
    var geocoder = null;

    function showAddress(address, tablestring) {
        geocoder.geocode({ 'address': address }, function (results, status) {
            if (status == google.maps.GeocoderStatus.OK) {
                map.setCenter(results[0].geometry.location, 13);
                var icon = {
                    position: results[0].geometry.location,
                    map: map,
                    title: 'REIQ Icon',
                    icon: "/images/googleMapIcons/gmap_icon_n.png",
                    shadow: '/images/googleMapIcons/shadow.png'
                };
                var marker = new google.maps.Marker(icon);
                marker.setMap(map);

                var infowindow = new google.maps.InfoWindow({
                    content: '<table style="overflow: hidden;"><tr><td>' + tablestring + '</td></tr></table>'
                });

                //infowindow.open(map, marker);

                google.maps.event.addListener(marker, 'click', function () {
                    infowindow.open(map, marker);
                });
            }
            else {
                document.getElementById('map').style.display = "none";
                document.getElementById('additionalContent').style.display = "none";
                document.getElementById('nomap').style.display = "inline";
            }
        });
    }
    //-->    
    </script>
    <script type="text/javascript">
        <%=strLoadMap%>
    </script>
    <div id="map" style="width: 616px; height: 502px"></div>
    <div id="nomap" style="display:none;"><h2><%= daddress %> was not found on Google Maps</h2><br /></div>
    <div id="additionalContent">
        <a class="nav1" href="javascript:load('<%= daddress %>')">PLEASE CLICK HERE IF YOU ARE UNABLE TO VIEW THE MAP</a><br />
        <font size="2">Please note that some properties do not match the address.<%--  <a href="/subpages/WarrantyGoogle.aspx" target="_blank"><b>No Warranty</b></a>--%>. <br />  
        <br />This map is produced by <a href="http://maps.google.com/"  class="nav1" target="_new"><b>Google</b></a> and <a href="<%=ConfigurationManager.AppSettings["webUrl"].ToString() %>" class="nav1" target="_new"><b>REIQ</b></a>; for more information please email <a class="nav1" href="mailto:<%=ConfigurationManager.AppSettings["adminemail"].ToString() %>"><%=ConfigurationManager.AppSettings["adminemail"].ToString() %></a></font>
    </div>
</body>
</html>
