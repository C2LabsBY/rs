// get today's date
today = new Date();
sDate = today.getDate();
var sDay;
var sMonth;
var dayNames = new Array ('Sunday','Monday','Tuesday','Wednesday','Thursday','Friday','Saturday');
var monthNames = new Array ('January','February','March','April','May','June','July','August','September','October','November','December');
sDay = dayNames[today.getDay()];
sMonth = monthNames[today.getMonth()];
sYear =  today.getYear();
sYear = sYear < 2000 ? sYear + 1900 : sYear;
finalDate =  sDay + ", " + sMonth + " " + sDate;


function openPopUp(theURL,winName,features) { //v2.0
  mapWin = window.open(theURL,winName,features);
  mapWin.focus();
}

// Macromdedia javascript for mouseovers.
function MM_swapImgRestore() { //v3.0
  var i,x,a=document.MM_sr; for(i=0;a&&i<a.length&&(x=a[i])&&x.oSrc;i++) x.src=x.oSrc;
}

function MM_preloadImages() { //v3.0
  var d=document; if(d.images){ if(!d.MM_p) d.MM_p=new Array();
    var i,j=d.MM_p.length,a=MM_preloadImages.arguments; for(i=0; i<a.length; i++)
    if (a[i].indexOf("#")!=0){ d.MM_p[j]=new Image; d.MM_p[j++].src=a[i];}}
}

function MM_findObj(n, d) { //v4.01
  var p,i,x;  if(!d) d=document; if((p=n.indexOf("?"))>0&&parent.frames.length) {
    d=parent.frames[n.substring(p+1)].document; n=n.substring(0,p);}
  if(!(x=d[n])&&d.all) x=d.all[n]; for (i=0;!x&&i<d.forms.length;i++) x=d.forms[i][n];
  for(i=0;!x&&d.layers&&i<d.layers.length;i++) x=MM_findObj(n,d.layers[i].document);
  if(!x && d.getElementById) x=d.getElementById(n); return x;
}

function MM_swapImage() { //v3.0
  var i,j=0,x,a=MM_swapImage.arguments; document.MM_sr=new Array; for(i=0;i<(a.length-2);i+=3)
   if ((x=MM_findObj(a[i]))!=null){document.MM_sr[j++]=x; if(!x.oSrc) x.oSrc=x.src; x.src=a[i+2];}
}

// Our URL used for terms of use.
strUrl = 'codebase/termsOfUse.asp?url=';
strUrl2 = 'codebase/disclaimer.asp?url=';
function openTerms(sUrl) {
	openPopUp(sUrl, "ca", "scrollbars=yes, menubar=no, width=450, height=500, resizable=yes");
}

// open VT Window
function openVT(sUrl) {
	openPopUp(sUrl, "vt","scrollbars=no, status=yes, menubar=no, width=700, height=456, resizable=yes");
}
// open more photos
function openMorePhotos(sUrl) {
	openPopUp(sUrl, "mp","scrollbars=yes, menubar=no, width=350, height=310, resizable=yes");
}
// open visualInfo (property.aspx)
function openVisualInfo(sUrl) {
	openPopUp(sUrl, "vi","scrollbars=yes, menubar=no, width=350, height=350, resizable=yes");
}

// open  plans (property.aspx - large, fp, lp)
function openPlans(sUrl) {
	openPopUp(sUrl, "pl","scrollbars=yes, menubar=no, toolbar=yes, width=600, height=500, resizable=yes");
}

// open Brochure
function openBrochure(sUrl) {
	openPopUp(sUrl, "br","scrollbars=yes, menubar=no, toolbar=yes, width=700, height=500, resizable=yes");
}

// open suburb info (property.aspx, building.asp)
function openSuburb(sUrl) {
	openPopUp(sUrl, "su","scrollbars=yes, menubar=no, width=450, height=350, resizable=yes");
}

// open Call Me
function openCallMe(sUrl) {
	openPopUp(sUrl, "cm","scrollbars=no, menubar=no, width=280, height=400, resizable=yes");
}

function openCalc(sUrl) {
	openPopUp(sUrl, "ca", "scrollbars=yes, menubar=no, width=450, height=500, resizable=yes");
}

// open agent window
function openAgent(sUrl) {
	openPopUp(sUrl, "ag","scrollbars=yes, menubar=no, width=350, height=400, resizable=yes");
}

// open new agent window
function openAgentNew(sUrl) {
	openPopUp(sUrl, "ag","scrollbars=yes, menubar=no, width=500, height=550, resizable=yes");
}
// open chart
function openChart(sUrl) {
	openPopUp(sUrl, "ch","scrollbars=no, menubar=no, width=975, height=800, resizable=yes");
}

//pass a form name an array of itmes and an array of descriptive names - for the alert messages.
function checkFormItems(form, items, messages) {
	for (var i=0; i<items.length; i++) {				
		formItem = eval(form + "." + items[i]);
		formItemValue = eval(form + "." + items[i] + ".value");
		if (formItemValue == "" || formItemValue == "any") {
			alert("Please fill in the field: " + "\"" + messages[i] + "\"");
			formItem.focus();
			return false;
		}
	}
	return true;
}

function checkIsNumber(form, items, messages) {
	for (var i=0; i<items.length; i++) {				
		formItem = eval(form + "." + items[i]);
		formItemValue = eval(form + "." + items[i] + ".value");
		if (formItemValue != "") {			
			if (isNaN(formItemValue)) {
				alert("The field: " + "\"" + messages[i] + "\"" + "is not a valid number.");
				formItem.focus();
				return false;
			}
		}
	}
	return true;
}

// Check the quicksearch form.
function checkQuickSearchForm() {
	var pid = frmQuickSearch.txtPid.value;
	if ( !pid || isNaN(pid)) {
		alert("Property IDs must be a valid number. Please try again.");
		frmQuickSearch.txtPid.focus();
	} else {
		frmQuickSearch.submit();
	}
	
	return false;
}
//for favetotes
   function getnumberofproperty(x)
    {  
        window.opener.document.getElementById('divno').innerHTML='&nbsp;&nbsp;<b>My Favourites List -</b> <span style=color:Red;><b> '+x+' </b></span> <b>property added</b>';
    }

function CheckSaveSearch()
{
   if(document.getElementById('txtSearchName').value=="")
    {
        alert("Property search's name should not be left blank");
        document.getElementById('txtSearchName').focus();
        return false;
    } 
}
function CheckSaveFab()
{
   if(document.getElementById('txtFavName').value=="")
    {
        alert("Fav name should not be left blank");
        document.getElementById('txtFavName').focus();
        return false;
    } 
}
function checkLogin()
{   
    if(document.getElementById('ctl00_ContentPlaceHolder1_txtEmail').value=="")
    {
        alert("Your email should not be left blank");
        document.getElementById('ctl00_ContentPlaceHolder1_txtEmail').focus();
        return false;
    }    
    if(document.getElementById('ctl00_ContentPlaceHolder1_txtPassword').value=="")
    {
        alert("Password should not be left blank");
        document.getElementById('ctl00_ContentPlaceHolder1_txtPassword').focus();
        return false;    
    }
}
function checkLogin2()
{   
    if(document.getElementById('txtEmail').value=="")
    {
        alert("Your email should not be left blank");
        document.getElementById('txtEmail').focus();
        return false;
    }    
    if(document.getElementById('txtPassword').value=="")
    {
        alert("Password should not be left blank");
        document.getElementById('txtPassword').focus();
        return false;    
    }
}

function checkLoginAgent()
{   
    if(document.getElementById('ctl00_ContentPlaceHolder1_txtAgetLogin').value=="")
    {
        alert("Username should not be left blank");
        document.getElementById('ctl00_ContentPlaceHolder1_txtAgetLogin').focus();
        return false;
    }    
    if(document.getElementById('ctl00_ContentPlaceHolder1_txtAgentPassWord').value=="")
    {
        alert("Password should not be left blank");
        document.getElementById('ctl00_ContentPlaceHolder1_txtAgentPassWord').focus();
        return false;    
    }
}

function checkEmailForm()
{
    var objName = document.getElementById('ctl00_ContentPlaceHolder1_txtName');
    var objEmail = document.getElementById('ctl00_ContentPlaceHolder1_txtEmail');
	 
	 
     if(objName.value=="" || objName.value=="Name")
    {
        alert("Name should not be left blank");
        objName.focus();
        return false;
    }    
     if(objEmail.value=="" || objEmail.value=="Email")
    {
        alert("Email should not be left blank");
        objEmail.focus();
        return false;    
    }
    if(!echeck(objEmail.value))
    {
        objEmail.value="";
        objEmail.focus();
        return false;
    }
	if(document.getElementById('ctl00_ContentPlaceHolder1_txtCode').value=="")
    {
        alert("Please type the code shown in the image");
        document.getElementById('ctl00_ContentPlaceHolder1_txtCode').focus();
        return false;
    }
	 	
}

function checkEmailForm2()
{
    var objName = document.getElementById('txtName');
    var objEmail = document.getElementById('txtEmail');
     if(objName.value=="")
    {
        alert("Name should not be left blank");
        objName.focus();
        return false;
    }    
     if(objEmail.value=="")
    {
        alert("Email should not be left blank");
        objEmail.focus();
        return false;    
    }
    if(!echeck(objEmail.value))
    {
        objEmail.value="";
        objEmail.focus();
        return false;
    }
if(document.getElementById('txtCode').value=="")
    {
        alert("Please type the code shown in the image");
        document.getElementById('txtCode').focus();
        return false;
    }	
}
function checkFeedbackForm()
{
    var objName = document.getElementById('txtName');
    var objEmail = document.getElementById('txtEmail');
    var objFeedback = document.getElementById('txtComments');
     if(objName.value=="")
    {
        alert("Name should not be left blank");
        objName.focus();
        return false;
    }    
     if(objEmail.value=="")
    {
        alert("Email should not be left blank");
        objEmail.focus();
        return false;    
    }
    if(!echeck(objEmail.value))
    {
        objEmail.value="";
        objEmail.focus();
        return false;
    }
      if(objFeedback.value=="")
    {
        alert("Feedback should not be left blank");
        objFeedback.focus();
        return false;
    } 	
}
function DelConfirm()
{
var x = confirm("Are you sure you want to Delete?")
if (x)
return true;
else
return false;
}
// Email Check Function
function echeck(str) {

	var at="@"
	var dot="."
	var lat=str.indexOf(at)
	var lstr=str.length
	var ldot=str.indexOf(dot)
	if (str.indexOf(at)==-1){
	   alert("Invalid Email")
	   return false
	}

	if (str.indexOf(at)==-1 || str.indexOf(at)==0 || str.indexOf(at)==lstr){
	   alert("Invalid Email")
	   return false
	}

	if (str.indexOf(dot)==-1 || str.indexOf(dot)==0 || str.indexOf(dot)==lstr){
	    alert("Invalid Email")
	    return false
	}

	 if (str.indexOf(at,(lat+1))!=-1){
	    alert("Invalid Email")
	    return false
	 }

	 if (str.substring(lat-1,lat)==dot || str.substring(lat+1,lat+2)==dot){
	    alert("Invalid Email")
	    return false
	 }

	 if (str.indexOf(dot,(lat+2))==-1){
	    alert("Invalid Email")
	    return false
	 }
	
	 if (str.indexOf(" ")!=-1){
	    alert("Invalid Email")
	    return false
	 }

	 return true
}

function mySetStyleDisplay(myDiv, myStyle) {
    if (document.all) {
        obj = document.all(myDiv);
        obj.style.display = myStyle;
    } else if (document.getElementById) {
        obj = document.getElementById(myDiv);
        obj.style.display = myStyle;
    } else { alert(Err_Browser); }
}

function myShow(myDiv) {
    mySetStyleDisplay(myDiv, '');
}

function myHide(myDiv) {
    mySetStyleDisplay(myDiv, 'none');
}	

function doClick(buttonName,e)
{
//the purpose of this function is to allow the enter key to
//point to the correct button to click.

    var key;
    if(window.event)
    key = window.event.keyCode; //IE
    else
    key = e.which; //firefox

            if (key == 13)
            {
            //Get the button the user wants to have clicked

            var btn = document.getElementById(buttonName);
                    if (btn != null)
                    { //If we find the button click it

                    btn.click();
                    event.keyCode = 0
                    }
            }
}
							
