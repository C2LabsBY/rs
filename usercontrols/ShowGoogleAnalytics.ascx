<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ShowGoogleAnalytics.ascx.cs" Inherits="usercontrols_ShowGoogleAnalytics" %>
<asp:PlaceHolder runat="server" ID="phGACode" Visible="false">
    <script type="text/javascript">

      var _gaq = _gaq || [];
      _gaq.push(['_setAccount', 'UA-5394751-3']);
      _gaq.push(['_setDomainName', 'reiq.com']);
      _gaq.push(['_trackPageview']);

      (function() {
        var ga = document.createElement('script'); ga.type = 'text/javascript'; ga.async = true;
        ga.src = ('https:' == document.location.protocol ? 'https://ssl' : 'http://www') + '.google-analytics.com/ga.js';
        var s = document.getElementsByTagName('script')[0]; s.parentNode.insertBefore(ga, s);
      })();

    </script></asp:PlaceHolder>