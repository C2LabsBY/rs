<%@ Control Language="C#" AutoEventWireup="true" CodeFile="DatePicker.ascx.cs" Inherits="usercontrols_DatePicker" %>
<script type="text/javascript">
    $(function () {
    	$("#<%=DateTextBox.ClientID %>").datepicker({
    		dateFormat: 'dd-mm-yy',
    		firstDay: 1            
			<%=MinDate.HasValue ? ", minDate: new Date(" + MinDate.Value.Year + ", " + (MinDate.Value.Month - 1) + ", " + MinDate.Value.Day + ")" : ""%>
    	    <%=MaxDate.HasValue ? ", maxDate: new Date(" + MaxDate.Value.Year + ", " + (MaxDate.Value.Month - 1) + ", " + MaxDate.Value.Day + ")" : ""%>
            <%=SelectedDate.HasValue ? ", selectedDate: new Date(" + SelectedDate.Value.Year + ", " + SelectedDate.Value.Month + ", " + SelectedDate.Value.Day + ")" : ""%>
		});
    });
</script>
<asp:TextBox runat="server" Style="color:#555555;" CssClass="DatePicker" ClientIDMode="AutoID" ID="DateTextBox" autocomplete="off" MaxLength="10"></asp:TextBox>
<asp:CustomValidator ValidateEmptyText="true" EnableTheming="false" ForeColor="Red" runat="server" ID="DateCustomValidator" ClientIDMode="AutoID" ControlToValidate="DateTextBox" OnServerValidate="DateCustomValidator_ServerValidate"></asp:CustomValidator>