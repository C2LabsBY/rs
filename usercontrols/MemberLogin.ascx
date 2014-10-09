<%@ Control Language="C#" AutoEventWireup="true" CodeFile="MemberLogin.ascx.cs" Inherits="usercontrols_MemberLogin" %>
<form name="form1" method="post" action="LoginPopUp.aspx" id="form1">
    <table width="710">
        <tr>
            <td colspan="3" align="center">
                <img src="/basemedia/images/reiq_logo_small.gif" align="absmiddle" vspace="3" hspace="8" />
            </td>
        </tr>
        <tr>
            <td width="350" valign="top" valign="bottom">
                <table width="85%" align="right">
                    <tr>
                        <td align="left">
                            <h1 style="text-transform: none; color: #000000;">REIQ Members</h1>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table class='ShdwBoxContent' border='0' cellpadding='0' cellspacing='0' width="100%">
                                <tr>
                                    <td width='105' align='right'><a target="_blank" href='http://institute.reiq.com/REIQ/MemberServices/REIQ/MemberServices.aspx'>
                                        <img src='/basemedia/images/REIQ_memberresources_login.jpg' /></a></td>
                                    <td width='20' align='center'>
                                        <img src='/basemedia/images/dot_vertical.gif' height='65' /></td>
                                    <td align='left' width='200' class='rightSpace'>
                                        <a target="_blank" href='http://institute.reiq.com/REIQ/MemberServices/REIQ/MemberServices.aspx'>
                                            <h3 style='text-transform: uppercase;'>Log-in to member resources area</h3>
                                        </a>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table class='ShdwBoxContent' border='0' cellpadding='0' cellspacing='0' width="100%">
                                <tr>
                                    <td width='105' align='right'><a target="_blank" href='http://psagent.reiq.com.au/'>
                                        <img src='/basemedia/images/REIQ_memberresources_listings.jpg' /></a></td>
                                    <td width='20' align='center'>
                                        <img src='/basemedia/images/dot_vertical.gif' height='65' /></td>
                                    <td align='left' width='200' class='rightSpace'>
                                        <a target="_blank" href='http://psagent.reiq.com.au/'>
                                            <h3 style='text-transform: uppercase;'>manage my listings</h3>
                                        </a>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>

            <td width="10" align="center" valign="bottom">
                <img src='/basemedia/images/dotlong_vertical.gif' height='190' /></td>
            <td width="350" valign="top">
                <table width="100%" class="contactform">
                    <tr>
                        <td>
                            <h1 style="text-transform: none; color: #000000;">General Public Access</h1>
                        </td>
                    </tr>
                    <tr>
                        <td>To access your property alerts, shortlist and saved searches
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table width="100%" border="0" class="contactform">

                                <tr>
                                    <td width="80">Your email
                                    </td>
                                    <td>
                                        <input name="txtEmail" type="text" id="txtEmail" size="27" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>Password
                                    </td>
                                    <td>
                                        <input name="txtPassword" type="password" id="txtPassword" size="27" />
                                    </td>
                                </tr>
                                <tr>
                                    <td></td>
                                    <td>
                                        <table>
                                            <tr>
                                                <td>
                                                    <input type="image" name="Button_REIQ_Login" id="Button_REIQ_Login" title="Login" onmouseout="this.src='images/btn_login_pink.jpg'" onmouseover="this.src='images/btn_login_pink_f2.jpg'" src="images/btn_login_pink.jpg" alt="Login" onclick="return checkLogin2();" style="border-width: 0px;" />
                                                </td>
                                                <td>
                                                    <a href="WebUserForgotPassword.aspx" target="_blank">forgot password</a>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td height="10"></td>
                                </tr>
                                <tr>
                                    <td colspan="2" align="center">
                                        <h3>
                                            <b>Don't have a My REIQ account?<br />
                                                <a href="WebUserJoin.aspx" target="_blank">SIGN UP HERE (it's free)</a></b></h3>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</form>