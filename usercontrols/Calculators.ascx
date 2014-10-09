<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Calculators.ascx.cs" Inherits="usercontrols_Calculators" %>

 
    <%if (!string.IsNullOrEmpty(Request.QueryString["id"]))
      { %>

    <%if (Request.QueryString["id"].ToLower() == "borrowing")
      { %>
      <div style="width:500px;background-color:white"><div><h2 style="float:left; margin:0 0 0 0; max-width:370px; text-align:left">Borrowing Power Calculator</h2></div><iframe style="margin-top:20px" scrolling="no" frameborder="0" width="500" height="860px" src="http://www.ratesonline.com.au/calculators_external/all-calc.aspx?userid=reiq1&chart=bp"></iframe><div style="width:250px;text-align:center;margin-right:auto;margin-left:auto;font-size:10px;"><img style="margin-bottom:10px" border="0" src="http://www.ratesonline.com.au/images/powered_by_logo_small.gif" alt="Ratesonline home loans" /><br /><a href="http://www.ratesonline.com.au/home-loans" >home loans at Ratesonline</a></div></div>
    <%} %>
    <%else if (Request.QueryString["id"].ToLower() == "extrarepayments")
      { %>
      <div style="width:500px;background-color:white"><div><h2 style="float:left; margin:0 0 0 0; max-width:370px; text-align:left">Extra Repayments Calculator</h2></div><iframe style="margin-top:20px" scrolling="no" frameborder="0" width="500" height="720px" src="http://www.ratesonline.com.au/calculators_external/all-calc.aspx?userid=reiq1&chart=er"></iframe><div style="width:250px;text-align:center;margin-right:auto;margin-left:auto;font-size:10px;"><img style="margin-bottom:10px" border="0" src="http://www.ratesonline.com.au/images/powered_by_logo_small.gif" alt="Ratesonline home loans" /><br /><a href="http://www.ratesonline.com.au/home-loans" >home loan comparison at Ratesonline</a></div></div>
    <%} %>
    <%else if (Request.QueryString["id"].ToLower() == "repayments")
      { %>
      <div style="width:500px;background-color:white"><div><h2 style="float:left; margin:0 0 0 0; max-width:370px; text-align:left">Home Loan Repayment Calculator</h2></div><iframe style="margin-top:20px" scrolling="no" frameborder="0" width="500" height="600px" src="http://www.ratesonline.com.au/calculators_external/all-calc.aspx?userid=reiq1&chart=lr"></iframe><div style="width:250px;text-align:center;margin-right:auto;margin-left:auto;font-size:10px;"><img style="margin-bottom:10px" border="0" src="http://www.ratesonline.com.au/images/powered_by_logo_small.gif" alt="Ratesonline home loans" /><br /><a href="http://www.ratesonline.com.au/home-loans/fixed-rate-home-loans" >fixed rate home loans at Ratesonline</a></div></div>
    <%} %>
    <%else if (Request.QueryString["id"].ToLower() == "switching")
      { %>
      <div style="width:500px;background-color:white"><div><h2 style="float:left; margin:0 0 0 0; max-width:370px; text-align:left">Loan Switching Calculator</h2></div><iframe style="margin-top:20px" scrolling="no" frameborder="0" width="500" height="1050px" src="http://www.ratesonline.com.au/calculators_external/all-calc.aspx?userid=reiq1&chart=lw"></iframe><div style="width:250px;text-align:center;margin-right:auto;margin-left:auto;font-size:10px;"><img style="margin-bottom:10px" border="0" src="http://www.ratesonline.com.au/images/powered_by_logo_small.gif" alt="Ratesonline home loans" /><br /><a href="http://www.ratesonline.com.au/home-loans" >compare home loans at Ratesonline</a></div></div>
    <%} %>
    <%else if (Request.QueryString["id"].ToLower() == "lumpsum")
      { %>
      <div style="width:500px;background-color:white"><div><h2 style="float:left; margin:0 0 0 0; max-width:370px; text-align:left">Lump Sum Payment Calculator</h2></div><iframe style="margin-top:20px" scrolling="no" frameborder="0" width="500" height="750px" src="http://www.ratesonline.com.au/calculators_external/all-calc.aspx?userid=reiq1&chart=ls"></iframe><div style="width:250px;text-align:center;margin-right:auto;margin-left:auto;font-size:10px;"><img style="margin-bottom:10px" border="0" src="http://www.ratesonline.com.au/images/powered_by_logo_small.gif" alt="Ratesonline home loans" /><br /><a href="http://www.ratesonline.com.au/home-loans/variable-rate-home-loans" >compare variable rate home loans at Ratesonline</a></div></div>
    <%} %>
    <%else if (Request.QueryString["id"].ToLower() == "transferduty")
      { %>
      <div style="width:500px;background-color:white"><div><h2 style="float:left; margin:0 0 0 0; max-width:370px; text-align:left">Stamp Duty Calculator</h2></div><iframe style="margin-top:20px" scrolling="no" frameborder="0" width="500" height="520" src="http://www.ratesonline.com.au/calculators_external/all-calc.aspx?userid=reiq1&chart=sd"></iframe><div style="width:250px;text-align:center;margin-right:auto;margin-left:auto;font-size:10px;"><img style="margin-bottom:10px" border="0" src="http://www.ratesonline.com.au/images/powered_by_logo_small.gif" alt="Ratesonline home loans" /><br /><a href="http://www.ratesonline.com.au/home-loans" >home loan comparison at Ratesonline</a></div></div>
    <%} %>
    
    <%} %>