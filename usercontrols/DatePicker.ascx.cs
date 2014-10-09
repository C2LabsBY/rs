using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class usercontrols_DatePicker : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

	public bool IsRequired = true;

	public DateTime? MinDate
	{
		get
		{
			if (ViewState["MinDate"] != null)
				return ViewState["MinDate"] as DateTime?;
			else
				return null;
		}
		set
		{
			ViewState["MinDate"] = value;
		}
	}
	public DateTime? MaxDate
	{
		get
		{
			if (ViewState["MaxDate"] != null)
				return ViewState["MaxDate"] as DateTime?;
			else
				return null;
		}
		set
		{
			ViewState["MaxDate"] = value;
		}
	}

	public void DateCustomValidator_ServerValidate(object sender, ServerValidateEventArgs e)
	{
		if(string.IsNullOrEmpty(DateTextBox.Text) && IsRequired)
		{
			e.IsValid = false;
			DateCustomValidator.ErrorMessage = "Required.";
		}
		else if (string.IsNullOrEmpty(DateTextBox.Text) && !IsRequired)
			e.IsValid = true;
		else
		{
			DateTime? dt = SelectedDate;

			if (dt == null)
			{
				e.IsValid = false;
                DateCustomValidator.ErrorMessage = "Date is not valid.";
			}
            else if ((MinDate.HasValue && dt.Value.Date < MinDate.Value.Date) || (MaxDate.HasValue && dt.Value.Date > MaxDate.Value.Date))
            {
                e.IsValid = false;
                DateCustomValidator.ErrorMessage = "Date is out of range (" + MinDate.Value.Date.ToString("dd-MM-yyyy") + " - " + MaxDate.Value.Date.ToString("dd-MM-yyyy") + ").";
            }
		}	
	}

	public DateTime? SelectedDate
	{
		get
		{
			DateTime dt;
            List <string> tmpDate = new List<string>();
            String convertedDate = String.Empty;

            if (!String.IsNullOrEmpty(DateTextBox.Text))
            {
                tmpDate = DateTextBox.Text.Split('-').ToList();
                convertedDate = tmpDate[2] + "-" + tmpDate[1] + "-" + tmpDate[0];
            }           

            if (DateTime.TryParse(convertedDate, out dt))
			{
				return dt;
			}
			else
				return null;
		}
		set
		{
			if (value == null)
				DateTextBox.Text = "";
			else
                DateTextBox.Text = value.Value.ToString("dd-MM-yyyy");
		}
	}
}