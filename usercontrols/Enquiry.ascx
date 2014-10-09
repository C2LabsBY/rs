<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Enquiry.ascx.cs" Inherits="usercontrols_Enquiry" %>

<%if (Property != null)
  {%>
<script type="text/javascript">
    $(document).ready(function () {
        $("a[rel^='enquireForm']").prettyPhoto();        
    });

    function email() {
        //check form on errors
        var checkResult = checkEmailForm();

        if (checkResult) {
            var txtName = $('#txtName').val();
            var txtPhone = $('#txtPhone').val();
            if (txtPhone == 'Phone') txtPhone = '';
            var txtEmail = $('#txtEmail').val();
            var txtComments = $('#txtComments').val();
            if (txtComments == 'Type your message here') txtComments = '';
            var txtCode = $('#txtCode').val();
            var currentPageName = "<%=CurrentPage.Name%>";
            var replyBy = $('#cboReplyBy').val();
            var toKnow = $('#cboEnqType').val();
            if (toKnow == 'General') toKnow = '';           

            if (sendEnquire(txtName, txtPhone, txtEmail, txtComments, txtCode, currentPageName, replyBy, toKnow, '<%=PropertyId%>', '<%=CurrentUrl%>')) {
                $('#txtName').val("Name");
                $('#txtPhone').val("Phone");
                $('#txtEmail').val("Email");
                $('#txtComments').val("Type your message here");
                $('#txtCode').val("");
                $('#cboReplyBy').val('Email').trigger('change');
                $('#cboEnqType').val('General').trigger('change');
                $("a[rel^='enquireForm']").click();
            }
            else {
                txtCode = $('#txtCode').val("");
            }
        }
        $('.capcha-regen-btn').click();
        return false;
    }    

    function checkEmailForm() {
        var objName = document.getElementById('txtName');
        var objEmail = document.getElementById('txtEmail');


        if (objName.value == "" || objName.value == "Name") {
            alert("Name should not be left blank");
            objName.focus();
            return false;
        }
        if (objEmail.value == "" || objEmail.value == "Email") {
            alert("Email should not be left blank");
            objEmail.focus();
            return false;
        }
        if (!echeck(objEmail.value)) {
            objEmail.value = "";
            objEmail.focus();
            return false;
        }
        if (document.getElementById('txtCode').value == "") {
            alert("Please type the code shown in the image");
            document.getElementById('txtCode').focus();
            return false;
        }
        return true;
    }

    // Email Check Function
    function echeck(str) {

        var at = "@"
        var dot = "."
        var lat = str.indexOf(at)
        var lstr = str.length
        var ldot = str.indexOf(dot)
        if (str.indexOf(at) == -1) {
            alert("Invalid Email")
            return false
        }

        if (str.indexOf(at) == -1 || str.indexOf(at) == 0 || str.indexOf(at) == lstr) {
            alert("Invalid Email")
            return false
        }

        if (str.indexOf(dot) == -1 || str.indexOf(dot) == 0 || str.indexOf(dot) == lstr) {
            alert("Invalid Email")
            return false
        }

        if (str.indexOf(at, (lat + 1)) != -1) {
            alert("Invalid Email")
            return false
        }

        if (str.substring(lat - 1, lat) == dot || str.substring(lat + 1, lat + 2) == dot) {
            alert("Invalid Email")
            return false
        }

        if (str.indexOf(dot, (lat + 2)) == -1) {
            alert("Invalid Email")
            return false
        }

        if (str.indexOf(" ") != -1) {
            alert("Invalid Email")
            return false
        }

        return true
    }

</script>

<section class="sidebar-form clearfix">
    <h2><%= GetHeading() %></h2>
    <asp:PlaceHolder runat="server" ID="EnquiryForm">
        <ul class="form-view">
            <li>
                <label for="receive-info" class="normal">
                    Receive more<br />
                    information by:</label>
                <asp:DropDownList ClientIDMode="Static" class="dropdown" runat="server" ID="cboReplyBy">
                    <asp:ListItem Value="Email" Text="Email"></asp:ListItem>
                    <asp:ListItem Value="Phone" Text="Phone"></asp:ListItem>
                </asp:DropDownList>
                from 
                    <% if (DefaultAgent != null)
                       {
                           bool isShowName = false;
                           if(DefaultAgent.ImisAid != null)
                           {
                               isShowName = true;
                           }
                           else if (DefaultAgent.nonIMIS != null)
                           {
                               if ((bool)DefaultAgent.nonIMIS)
                                   isShowName = true;
                           }
                           
                           if(isShowName)
                           {%><%=DefaultAgent.firstname%><%} %>
                <%} 
                         else if(Agency != null)
                         {%><%=Agency.name%><%} %>
                <%--Weird werid logycs - but it was like that:
                                                 <%if((!string.IsNullOrEmpty(prop.agentimisAid) || prop.isnonimis)){ %>
                                                 <%=prop.agentFirstName %>
                                                 <%}else{ %>
                                                  <%  prop.connection.Close(); prop.getAgency(prop.acid.ToString());%>  
                                                 <%=prop.agencyname %>
                                                 <%} %>--%>
            </li>
            <li>
                <label for="property-name">Name:</label>
                <asp:TextBox ID="txtName" ClientIDMode="Static" runat="server" CssClass="text-fi" value="Name" onFocus="if(this.value == 'Name'){this.value = ''}" onBlur="if(this.value == ''){this.value = 'Name'}"></asp:TextBox>
                <span class="required">*</span>
            </li>
            <li>
                <label for="phone">Phone:</label>
                <asp:TextBox ID="txtPhone" ClientIDMode="Static" runat="server" size="25" CssClass="text-fi" value="Phone" onFocus="if(this.value == 'Phone'){this.value = ''}" onBlur="if(this.value == ''){this.value = 'Phone'}"></asp:TextBox>
                <%--<span class="required">*</span>--%>
            </li>
            <li>
                <label for="email-fi">Email:</label>
                <asp:TextBox ID="txtEmail" ClientIDMode="Static" runat="server" CssClass="text-fi" size="25" value="Email" onFocus="if(this.value == 'Email'){this.value = ''}" onBlur="if(this.value == ''){this.value = 'Email'}"></asp:TextBox>
                <span class="required">*</span>
            </li>
            <li>
                <label for="like-know" class="normal">
                    I would like<br />
                    to know:</label>
                <asp:DropDownList ClientIDMode="Static" runat="server" ID="cboEnqType" CssClass="dropdown">
                    <asp:ListItem Value="General" Text="I would like to know..."></asp:ListItem>
                    <asp:ListItem Value="the price of the property" Text="the price of the property"></asp:ListItem>
                    <asp:ListItem Value="the land area in sqm" Text="the land area in sqm"></asp:ListItem>
                    <asp:ListItem Value="the exact address" Text="the exact address"></asp:ListItem>
                    <asp:ListItem Value="open home time" Text="open home time"></asp:ListItem>
                    <asp:ListItem Value="other (use text box below)" Text="other (use text box below)"></asp:ListItem>
                </asp:DropDownList>
            <li>
                <label for="your-message">Your message:</label>
                <asp:TextBox ID="txtComments" ClientIDMode="Static" TextMode="MultiLine" runat="server" CssClass="text-fi" Text="Type your message here" onFocus="if(this.value == 'Type your message here'){this.value = ''}" onBlur="if(this.value == ''){this.value = 'Type your message here'}"></asp:TextBox>
            </li>
            <li>
                <label for="code" class="normal">
                    Enter code<br />
                    from image:</label>
                <asp:TextBox ID="txtCode" ClientIDMode="Static" CssClass="text-fi" size="25" runat="server"></asp:TextBox>
                <span class="required">*</span> </li>
            <li class="no-label">
                <img id="captchaImage" src="/CaptchaImage.ashx" />
                <%--<iframe id="captchaFrame" src="http://new.dev.reiq.com/CaptchaImage.ashx" frameborder="0" height="40" style="background-color: Transparent;" width="150" scrolling="no"></iframe>--%>
                <a href="javascript:;" class="capcha-regen-btn" onclick="document.getElementById('captchaImage').src = '/CaptchaImage.ashx?' + Math.random(); return false">
                    <img src="/basemedia/images/capcha-regen-img.png" alt="" />
                </a>
                <asp:Label runat="server" ID="lblError" ForeColor="Red" EnableViewState="false"></asp:Label>
                <p class="required-mesg">* required field</p>
                <asp:Button ID="btnSend" CssClass="red-btn" ImageUrl="images/btn_send.jpg" runat="server" Text="Send" OnClientClick="javascript: return email();" />
                <a rel="enquireForm" href="<%=RelatedThankYouPage %>?ajax=true" class="red-btn" id="cf-send" style="position:absolute;top:-10000px;"></a>
            </li>
        </ul>
    </asp:PlaceHolder>
    <asp:Label ID="lblMsg" runat="server" Visible="False">Thank you for your query, we'll be in touch as soon as possible.</asp:Label>
</section>
<%} %>
