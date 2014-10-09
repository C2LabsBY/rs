<%@ Control Language="C#" AutoEventWireup="true" CodeFile="MemberJoin.ascx.cs" Inherits="usercontrols_MemberJoin" %>

<h1 style="text-transform: none">General Public Access</h1>
<h3>Why should you set up your <b>free</b> My REIQ account?</h3>
<p>You can have multiple property alerts, and then save and edit your alerts. You can also save and edit multiple property lists (favourites). A new feature is to save your favourite searches, as well as viewing the REIQ tweet stream and facebook fan page.</p>

<table cellpadding="2" cellspacing="2" align="left">
    <tr>
        <td width="150">First Name*</td>
        <td>
            <input name="ctl00$ContentPlaceHolder1$txtFirstName" type="text" id="ctl00_ContentPlaceHolder1_txtFirstName" /></td>
    </tr>
    <tr>
        <td>Last Name</td>
        <td>
            <input name="ctl00$ContentPlaceHolder1$txtLastName" type="text" id="ctl00_ContentPlaceHolder1_txtLastName" /></td>
    </tr>
    <tr>
        <td>Email Address*</td>
        <td>
            <input name="ctl00$ContentPlaceHolder1$txtEmail" type="text" id="ctl00_ContentPlaceHolder1_txtEmail" style="width: 200px;" /></td>
    </tr>
    <tr>
        <td>Phone</td>
        <td>
            <input name="ctl00$ContentPlaceHolder1$txtPhone" type="text" id="ctl00_ContentPlaceHolder1_txtPhone" style="width: 120px;" /></td>
    </tr>
    <tr>
        <td>Password*</td>
        <td>
            <input name="ctl00$ContentPlaceHolder1$txtPassword" type="password" id="ctl00_ContentPlaceHolder1_txtPassword" /></td>
    </tr>
    <tr>
        <td>Re-type Password*</td>
        <td>
            <input name="ctl00$ContentPlaceHolder1$txtPasswordC" type="password" id="ctl00_ContentPlaceHolder1_txtPasswordC" /></td>
    </tr>

    <tr>
        <td>Screen Name*</td>
        <td>
            <input name="ctl00$ContentPlaceHolder1$txtScreenName" type="text" id="ctl00_ContentPlaceHolder1_txtScreenName" /></td>
    </tr>

    <tr>
        <td>Please type the code shown in the image (Case Sensitive)*</td>
        <td>
            <input name="ctl00$ContentPlaceHolder1$txtCode" type="text" id="ctl00_ContentPlaceHolder1_txtCode" /><span id="ctl00_ContentPlaceHolder1_Label2" style="color: Red;"></span></td>
    </tr>
    <tr>
        <td></td>
        <td>
            <iframe src="captchFrame.aspx" frameborder="0" height="40" style="background-color: Transparent;" scrolling="no"></iframe>
        </td>
    </tr>
    <tr>

        <td colspan='2' align='center'>
            <input id="ctl00_ContentPlaceHolder1_chkcondition" type="checkbox" name="ctl00$ContentPlaceHolder1$chkcondition" checked="checked" /><font style='font-size: 10px;'>I would like to receive the REIQ's newsletter containing the latest property market information, research and valuable articles on buying, selling and renting property in Queensland.</font></td>
    </tr>

    <tr>
        <td class="comment">* required<br>
        </td>
        <td>
            <input type="submit" name="ctl00$ContentPlaceHolder1$Button1" value="Join My REIQ" onclick="return checkFormWebUserJoin();" id="ctl00_ContentPlaceHolder1_Button1" /></td>
    </tr>
</table>
