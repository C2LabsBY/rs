<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AgencyMainControl.ascx.cs" Inherits="usercontrols_content_header_AgencyMainControl" %>
<% if (Agency != null)
{ %>
    <script type="text/javascript" src="//maps.googleapis.com/maps/api/js?sensor=false"></script>
    <SCRIPT type=text/javascript>
    //<![CDATA[
    var map = null;
    var geocoder = null;

    function load(address) {

        var mapOptions = {
            zoom: 14,
            overviewMapControl: true,
            overviewMapControlOptions: { opened: true },
            mapTypeId: google.maps.MapTypeId.ROADMAP,
            scaleControl: true
        };
        map = new google.maps.Map(document.getElementById("map"), mapOptions);

        //map.setCenter(new google.maps.LatLng(-19.7061, 145.774002), 13);
        geocoder = new google.maps.Geocoder();
        geocoder.geocode({ 'address': address }, function (results, status) {
            if (status == google.maps.GeocoderStatus.OK) {
                map.setCenter(results[0].geometry.location, 13);
                var icon = {
                    position: results[0].geometry.location,
                    map: map,
                    title: 'REIQ Icon',
                    icon: "/images/googleMapIcons/gmap_icon_n.png",
                    shadow: "/images/shadow3.png"
                };
                var marker = new google.maps.Marker(icon);
                marker.setMap(map);

                var infowindow = new google.maps.InfoWindow({
                    content: '<table style="overflow: hidden;"><tr><td>' + address + '</td></tr></table>'
                });

                //infowindow.open(map, marker);

                google.maps.event.addListener(marker, 'click', function () {
                    infowindow.open(map, marker);
                });
            }
            else {
                document.getElementById('map').style.display = "none";
            }
        });    }

    //]]>
</SCRIPT>
    <h2 class="title">About <%=Agency.name %></h2>
    <p><%= Agency.Profile %></p>
    <div id="map" style="width: 100%; height: 308px" class="tableborder" ></div><br />
<%} %>