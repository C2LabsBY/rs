<%@ Control Language="C#" AutoEventWireup="true" CodeFile="GenericContactForm.ascx.cs" Inherits="usercontrols_GenericContactForm" %>

<asp:PlaceHolder runat="server" ID="ContactForm" Visible="false">
    <script type="text/javascript">
        $(document).ready(function () {
            $("a[rel^='contactForm']").prettyPhoto();
        });        

        function email(){
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
                var sendToEmail = "<%=ToEmail%>";

                if (sendEmail(txtName, txtPhone, txtEmail, txtComments, txtCode, sendToEmail, currentPageName)) {
                    txtName = $('#txtName').val("Name");
                    txtPhone = $('#txtPhone').val("Phone");
                    txtEmail = $('#txtEmail').val("Email");
                    txtComments = $('#txtComments').val("Type your message here");
                    txtCode = $('#txtCode').val("");                    
                    $("a[rel^='contactForm']").click();
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
        <asp:PlaceHolder runat="server" ID="ContactUs">
            <ul class="form-view">
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
                    <a href="javascript:;" class="capcha-regen-btn" onclick="document.getElementById('captchaImage').src = '/CaptchaImage.ashx?' + Math.random(); return false">
                        <img src="/basemedia/images/capcha-regen-img.png" alt="" />
                    </a>
                    <asp:Label runat="server" ID="lblError" ForeColor="Red" EnableViewState="false"></asp:Label>
                    <p class="required-mesg">* required field</p>
                    <asp:Button ID="btnSend" CssClass="red-btn" ImageUrl="images/btn_send.jpg" runat="server" Text="Send" OnClientClick="javascript: return email();" />
                    <a rel="contactForm" href="<%=RelatedThankYouPage %>?ajax=true" class="red-btn" id="cf-send" style="position:absolute;top:-10000px;"></a>
                </li>
            </ul>
        </asp:PlaceHolder>
        <asp:Label ID="lblMsg" runat="server" Visible="False">Thank you for your input, we'll be in touch as soon as possible.</asp:Label>
    </section>
</asp:PlaceHolder>

