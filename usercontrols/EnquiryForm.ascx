<%@ Control Language="C#" AutoEventWireup="false" CodeFile="EnquiryForm.ascx.cs" Inherits="usercontrols_EnquiryForm" %>
<section class="sidebar-inn"><!-- SIDEBAR INN -->
          
          <section class="sidebar-block "><!-- SIDEBAR BLOCK -->
            <section class="sidebar-form clearfix">
              <h2>ENQUIRE ABOUT COURSES</h2>
              <ul class="form-view">
                <li>
                  <label for="course_name">Name:</label>
                  <input name="course_name" id="course_name" type="text" class="text-fi" />
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
                <li class="no-label"> <img src="Captcha.ashx" alt="" /> <a href="#" class="capcha-regen-btn"><img src="basemedia/images/capcha-regen-img.png" alt="" /></a>
                  <p class="required-mesg">* required field</p>
                  <input type="submit" value="Submit" class="red-btn" />
                </li>
              </ul>
            </section>
          </section>

          <!-- /SIDEBAR BLOCK --> 
          
        </section>