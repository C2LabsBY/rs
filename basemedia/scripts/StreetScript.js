// JScript File

//   var myPano;
//   var geocoder= null;
//   var XL="", YL = "";
//     function initialize(address) {
//     var fenwayPark ;
//       geocoder = new GClientGeocoder();

//        if (geocoder) 
//        {
//            geocoder.getLatLng(address, function(point) {
//                if (!point) {
//                    fenwayPark = new google.maps.LatLng(-19.7061,145.774002);
//                }
//                else {

//                    var fenwayPark = new google.maps.LatLng(point.y, point.x);
//                    panoramaOptions = { latlng: fenwayPark };
//                    myPano = new GStreetviewPanorama(document.getElementById("pano"), panoramaOptions);

//                    GEvent.addListener(myPano, "error", handleNoFlash);
//                }
//            }
//      );
//    }
    
//    }

//    function handleNoFlash(errorCode) {
        
//            if (errorCode == FLASH_UNAVAILABLE) 
//            {
//                alert("Error: Flash doesn't appear to be supported by your browser");
//                return;
//            }
//    } 
    
////function GAddress( a, c ) 
////{
////  var xmlhttp = false;
////  try 
////  {
////   xmlhttp = new ActiveXObject("Msxml2.XMLHTTP");
////   }
////    catch (e)
////     {
////   try {
////    xmlhttp = new ActiveXObject("Microsoft.XMLHTTP");
////    } 
////    catch (E) 
////    {
////        xmlhttp = false;
////   }
////  }
////  if (!xmlhttp && typeof XMLHttpRequest!='undefined') 
////  {
////    xmlhttp = new XMLHttpRequest();
////  }

////  var l = new Array();
////  xmlhttp.open("GET", "gaddress.cgi?a=" + escape(a), true);
////  xmlhttp.onreadystatechange=function() 
////  {
////   if (xmlhttp.readyState==4) {
////    l = xmlhttp.responseText.split(',');
////    if ( l[0] == '' )
////      c( null, a );
////    else
////      c( new GPoint( l[0] - 0, l[1] - 0 ), a );
////   }
////  }
////  xmlhttp.send(null)
////}

//var map;
//    var gdir;
//    var geocoder = null;
//    var addressMarker;	    
//    function load(FromAddress, ToAddress) {
//    document.getElementById("directions").innerHTML='';
//    var address1= FromAddress ;
//    var address2= ToAddress;
    
    
//      if (GBrowserIsCompatible()) {      
//        map = new google.maps.Map(document.getElementById("map"));	
//        gdir = new GDirections(map, document.getElementById("directions"));
//        GEvent.addListener(gdir, "load", onGDirectionsLoad);
//        GEvent.addListener(gdir, "error", handleErrors);
//        setDirections(address1, address2);        
//      }
//    }
    
//    function setDirections(fromAddress, toAddress, locale) {    	
//       gdir.load("from: " + fromAddress + " to: " + toAddress,
//                { "locale": locale });		
//    }

//    function handleErrors(){
//	   if (gdir.getStatus().code == G_GEO_UNKNOWN_ADDRESS)
//	     alert("No corresponding geographic location could be found for one of the specified addresses. This may be due to the fact that the address is relatively new, or it may be incorrect.\nError code: " + gdir.getStatus().code);
//	   else if (gdir.getStatus().code == G_GEO_SERVER_ERROR)
//	     alert("A geocoding or directions request could not be successfully processed, yet the exact reason for the failure is not known.\n Error code: " + gdir.getStatus().code);
	   
//	   else if (gdir.getStatus().code == G_GEO_MISSING_QUERY)
//	     alert("The HTTP q parameter was either missing or had no value. For geocoder requests, this means that an empty address was specified as input. For directions requests, this means that no query was specified in the input.\n Error code: " + gdir.getStatus().code);
//	   else if (gdir.getStatus().code == G_GEO_BAD_KEY)
//	     alert("The given key is either invalid or does not match the domain for which it was given. \n Error code: " + gdir.getStatus().code);

//	   else if (gdir.getStatus().code == G_GEO_BAD_REQUEST)
//	     alert("A directions request could not be successfully parsed.\n Error code: " + gdir.getStatus().code);
	    
//	   else alert("An unknown error occurred.");
	   
//	}

//	function onGDirectionsLoad(){ 
	
//          // Use this function to access information about the latest load()
//          // results.          
//	}



