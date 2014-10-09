<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Enquiry.ascx.cs" Inherits="usercontrols_Enquiry" %>
        <section class="sidebar-form clearfix">
              <h2>CONTACT US</h2>
              <ul class="form-view">
                <li>
                  <label for="contact_name">Name:</label>
                  <input name="contact_name" id="contact_name" type="text" class="text-fi" />
                  <span class="required">*</span> </li>
                <li>
                  <label for="phone">Phone:</label>
                  <input name="phone" id="phone" type="text" class="text-fi" />
                </li>
                <li>
                  <label for="email">Email:</label>
                  <input name="email" id="email" type="text" class="text-fi" />
                </li>
                <li>
                  <label for="message">Your message:</label>
                  <textarea name="message" id="message"></textarea>
                  <span class="required">*</span> </li>
                <li>
                  <label for="code" class="normal">Enter code<br/>
                    from image:</label>
                  <input name="code" id="code" type="text" class="text-fi" />
                  <span class="required">*</span> </li>
                <li class="no-label"> <img src="basemedia/images/capcha-img.png" alt="" /> <a href="#" class="capcha-regen-btn"><img src="basemedia/images/capcha-regen-img.png" alt="" /></a>
                  <p class="required-mesg">* required field</p>
                  <input type="submit" value="Submit" class="red-btn" />
                </li>
              </ul>
            </section>