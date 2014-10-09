<%@ Page Title="" Language="C#" MasterPageFile="Main.master" AutoEventWireup="true" Inherits="TemplateBase" %>
<%@ Register Src="usercontrols/HeadingDefault.ascx" TagPrefix="reiq" TagName="heading" %>
<%@ Register Src="usercontrols/Enquiry.ascx" TagPrefix="reiq" TagName="enq" %>

<script runat="server">
    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
        SetBodyClass("cms-page");
        
    }
</script>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentHeader" Runat="Server">
    <reiq:heading runat="server" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="SideBarTopControl" Runat="Server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="RightSideBar" Runat="Server">

            <h2>KEY INFORMATION</h2>
            <ul class="sidebar-key-info">
              <li>
                <figure class="key-img"><a href="javacscript:;"><img src="basemedia/images/key-img.png" alt="" /></a></figure>
                <p class="key-data"><a href="javacscript:;">FREE INTRODUCTION TO REAL <br/>
                  ESTATE SESSIONS</a></p>
              </li>
              <li>
                <figure class="key-img"><a href="javacscript:;"><img src="basemedia/images/key-img.png" alt="" /></a></figure>
                <p class="key-data"><a href="javacscript:;">FREE INTRODUCTION TO REAL <br/>
                  ESTATE SESSIONS</a></p>
              </li>
              <li>
                <figure class="key-img"><a href="javacscript:;"><img src="basemedia/images/key-img.png" alt="" /></a></figure>
                <p class="key-data"><a href="javacscript:;">FREE INTRODUCTION TO REAL <br/>
                  ESTATE SESSIONS</a></p>
              </li>
              <li>
                <figure class="key-img"><a href="javacscript:;"><img src="basemedia/images/key-img.png" alt="" /></a></figure>
                <p class="key-data"><a href="javacscript:;">FREE INTRODUCTION TO REAL <br/>
                  ESTATE SESSIONS</a></p>
              </li>
            </ul>

            <reiq:enq runat="server" />

</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="MainDataTopControl" Runat="Server">
</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="MainData" Runat="Server">

    <h2 class="title">INTRODUCTION</h2>
          <figure class="imgleft2"><img src="basemedia/images/cms-img1.png" alt="" /></figure>
          <p> The real estate industry offers a range of dynamic 
            career options for nearly everyone. To enter into thes 
            careers first requires a little training, and the REIQ 
            offers a range of real estate courses for training and 
            professional development. </p>
          <p> Whether you're thinking of becoming a salesperson, 
            property manager, resident letting agent, an 
            auctioneer or a business broker, core vocational skill
            form the basis of any successful career. Real estate 
            courses will provide you with specialised information 
            to help you build the technical skills you require. </p>
          <p> The REIQ is the longest established provider of real estate courses and training in Queensland and can 
            assist you in achieving your career goals. </p>
          <p> With so many different real estate courses on offer, the REIQ is the one-stop shop for your professional 
            development needs. </p>
          <p> If you would like to keep updated on all the latest training sessions subscribe to the fortnightly Professional 
            Development Update email. </p>
          <div class="clear"></div>
          <blockquote> Sed ut perspiciatis unde<br/>
            omnis iste natus error sit <br/>
            voluptatem <br/>
          </blockquote>
          <p> Lorem ipsum dolor sit amet, consectetur adipisicing 
            elit, sed do eiusmod tempor incididunt ut labore et 
            dolore magna aliqua. Ut enim ad minim veniam, quis 
            nostrud exercitation ullamco laboris nisi ut aliquip ex 
            ea commodo consequat. Duis aute irure dolor in 
            reprehenderit in voluptate velit esse cillum dolore eu 
            fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt 
            mollit anim id est laborum. Sed ut perspiciatis unde omnis iste natus error sit voluptatem accusantium </p>
          <br/>
          <p>At vero eos et accusamus et iusto odio dignissimos ducimus qui blanditiis praesentium voluptatum deleniti:</p>
          <ul>
            <li>atque corrupti quos dolores et quas molestias excepturi sint occaecati </li>
            <li>cupiditate non provident, similique sunt in culpa qui officia deserunt </li>
            <li>mollitia animi, id est laborum et dolorum fuga. Et harum quidem rerum facilis est et </li>
            <li>expedita distinctio. Nam libero tempore, </li>
          </ul>
          <div class="clear"></div>
          <br/>
          <br/>
          <br/>
          <table width="100%" cellpadding="0" cellspacing="0" border="0">
            <tr>
              <th>TABLE COLUMN HEADER 1</th>
              <th>TABLE COLUMN HEADER 1</th>
            </tr>
            <tr>
              <td>Temporibus autem quibusdam et aut officiis</td>
              <td>&nbsp;</td>
            </tr>
            <tr>
              <td>Debitis aut rerum necessitatibus saepe eveniet </td>
              <td>&nbsp;</td>
            </tr>
            <tr>
              <td>&nbsp;</td>
              <td>&nbsp;</td>
            </tr>
            <tr>
              <td>&nbsp;</td>
              <td>&nbsp;</td>
            </tr>
            <tr>
              <td>&nbsp;</td>
              <td>&nbsp;</td>
            </tr>
            <tr>
              <td>&nbsp;</td>
              <td>&nbsp;</td>
            </tr>
            <tr>
              <td>&nbsp;</td>
              <td>&nbsp;</td>
            </tr>
          </table>

</asp:Content>

