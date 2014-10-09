<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SearchByIdForm.ascx.cs" Inherits="usercontrols_SearchByIdForm" %>

<%--<form action="securitypropertydetails" id="securitySearchById" method="post" style="margin-top:20px;">
    <label>Enter property ID:</label>
    <input name="propertyId" id="propertyId" />
    <input type="submit" name="securitySearchByIdSubmit" value="Find" class="red-btn"/>
</form>--%>
<br /><br />
<asp:Label>Enter property ID:</asp:Label>
<asp:TextBox ID="tbPropertyID" runat="server"></asp:TextBox>
<asp:Button ID="btnPropertyIDSearch" runat="server" Text="Search" OnClick="btnPropertyIDSearch_Click" CssClass="red-btn"/>