using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MigraDoc.DocumentObjectModel;
using MigraDoc.Rendering;
using System.IO;

namespace AdventureWorksDW2012
{
    public partial class frmdbo_DimReseller : System.Web.UI.Page
    {

        private dbo_DimResellerDataClass clsdbo_DimResellerData = new dbo_DimResellerDataClass();
        private AdventureWorksDW2012DataClass clsAdventureWorksDW2012Data = new AdventureWorksDW2012DataClass();
        private DataView dvdbo_DimReseller;

        protected void Page_Load(object sender, EventArgs e)
        {
		    if (!Page.IsPostBack) {
			    Session["Mode"] = "";
 			    Session["ResellerKey"] = "";

			    Session.Remove("dvdbo_DimReseller");

                            cmbFields.Items.Add("Reseller Key");
                            cmbFields.Items.Add("Geography Key");
                            cmbFields.Items.Add("Reseller Alternate Key");
                            cmbFields.Items.Add("Phone");
                            cmbFields.Items.Add("Business Type");
                            cmbFields.Items.Add("Reseller Name");
                            cmbFields.Items.Add("Number Employees");
                            cmbFields.Items.Add("Order Frequency");
                            cmbFields.Items.Add("Order Month");
                            cmbFields.Items.Add("First Order Year");
                            cmbFields.Items.Add("Last Order Year");
                            cmbFields.Items.Add("Product Line");
                            cmbFields.Items.Add("Address Line1");
                            cmbFields.Items.Add("Address Line2");
                            cmbFields.Items.Add("Annual Sales");
                            cmbFields.Items.Add("Bank Name");
                            cmbFields.Items.Add("Min Payment Type");
                            cmbFields.Items.Add("Min Payment Amount");
                            cmbFields.Items.Add("Annual Revenue");
                            cmbFields.Items.Add("Year Opened");

                	    cmbCondition.Items.Add("Contains");
                	    cmbCondition.Items.Add("Equals");
                	    cmbCondition.Items.Add("Starts with...");
                	    cmbCondition.Items.Add("More than...");
                	    cmbCondition.Items.Add("Less than...");
                	    cmbCondition.Items.Add("Equal or more than...");
                	    cmbCondition.Items.Add("Equal or less than...");
			    
			    cmbRecords.Items.Add("5");
			    cmbRecords.Items.Add("10");
			    cmbRecords.Items.Add("25");
			    cmbRecords.Items.Add("50");
			    cmbRecords.Items.Add("100");
			    cmbRecords.Items.Add("500");

            Loaddbo_DimReseller_dbo_DimGeographyComboBox();

			    LoadGriddbo_DimReseller();
		    }

        }


	    private void Loaddbo_DimReseller_dbo_DimGeographyComboBox()
	    {
		    List<dbo_DimReseller_dbo_DimGeographyClass> dbo_DimReseller_dbo_DimGeographyList = new  List<dbo_DimReseller_dbo_DimGeographyClass>();
		    try {
			    dbo_DimReseller_dbo_DimGeographyList = dbo_DimReseller_dbo_DimGeographyDataClass.List();
			    txtGeographyKey.DataSource = dbo_DimReseller_dbo_DimGeographyList;
			    txtGeographyKey.DataValueField = "GeographyKey";
			    txtGeographyKey.DataTextField = "StateProvinceName";
			    txtGeographyKey.DataBind();
		    }
		    catch (Exception ex)
		    {
		    	ec.ShowMessage(ex.Message, " Dbo. Dim Reseller ");
		    }
	    }

        private void LoadGriddbo_DimReseller()
        {
		    try {
			if ((Session["dvdbo_DimReseller"] != null)) {
				dvdbo_DimReseller = (DataView)Session["dvdbo_DimReseller"];
				// DataView was not found in the session.
		    	} else {
				dvdbo_DimReseller = dbo_DimResellerDataClass.SelectAll().DefaultView;
			    	Session["dvdbo_DimReseller"] = dvdbo_DimReseller;
		    	}
                if (dvdbo_DimReseller.Count > 0)
                {
                    dvdbo_DimReseller.Sort = htmlHiddenSortExpression.Value;
                    grddbo_DimReseller.DataSource = dvdbo_DimReseller;
                    grddbo_DimReseller.DataBind();
                }
                else
                {
                    grddbo_DimReseller.DataSource = null;
                    grddbo_DimReseller.DataBind();
                }
		    }
		    catch (Exception ex)
		    {
		    	ec.ShowMessage(ex.Message, " Dbo. Dim Reseller ");
		    }
        }

        private void Add()
        {
		    Session.Remove("Mode");
		    Session["Mode"] = "Add";

		    ClearRecord();

		    this.txtGeographyKey.Enabled = true;
		    this.txtResellerAlternateKey.Enabled = true;
		    this.txtPhone.Enabled = true;
		    this.txtBusinessType.Enabled = true;
		    this.txtResellerName.Enabled = true;
		    this.txtNumberEmployees.Enabled = true;
		    this.txtOrderFrequency.Enabled = true;
		    this.txtOrderMonth.Enabled = true;
		    this.txtFirstOrderYear.Enabled = true;
		    this.txtLastOrderYear.Enabled = true;
		    this.txtProductLine.Enabled = true;
		    this.txtAddressLine1.Enabled = true;
		    this.txtAddressLine2.Enabled = true;
		    this.txtAnnualSales.Enabled = true;
		    this.txtBankName.Enabled = true;
		    this.txtMinPaymentType.Enabled = true;
		    this.txtMinPaymentAmount.Enabled = true;
		    this.txtAnnualRevenue.Enabled = true;
		    this.txtYearOpened.Enabled = true;
		    txtResellerKey.Enabled = false;
		    txtGeographyKey.Focus();
		    txtResellerKey.Text = Convert.ToString(clsAdventureWorksDW2012Data.getAutoID("New", "DimReseller"));
        }

        private void GetData()
        {
		    ClearRecord();

		    dbo_DimResellerClass clsdbo_DimReseller = new dbo_DimResellerClass();
		    clsdbo_DimReseller.ResellerKey = System.Convert.ToInt32(Session["ResellerKey"]);
		    clsdbo_DimReseller = dbo_DimResellerDataClass.Select_Record(clsdbo_DimReseller);

		    if ((clsdbo_DimReseller != null)) {
			    try {
                		txtResellerKey.Text = System.Convert.ToString(clsdbo_DimReseller.ResellerKey);
                		if (clsdbo_DimReseller.GeographyKey == null) { txtGeographyKey.SelectedValue = default(string); } else { txtGeographyKey.SelectedValue = System.Convert.ToString(clsdbo_DimReseller.GeographyKey); }
                		if (clsdbo_DimReseller.ResellerAlternateKey == null) { txtResellerAlternateKey.Text = default(string); } else { txtResellerAlternateKey.Text = System.Convert.ToString(clsdbo_DimReseller.ResellerAlternateKey); }
                		if (clsdbo_DimReseller.Phone == null) { txtPhone.Text = default(string); } else { txtPhone.Text = System.Convert.ToString(clsdbo_DimReseller.Phone); }
                		txtBusinessType.Text = System.Convert.ToString(clsdbo_DimReseller.BusinessType);
                		txtResellerName.Text = System.Convert.ToString(clsdbo_DimReseller.ResellerName);
                		if (clsdbo_DimReseller.NumberEmployees == null) { txtNumberEmployees.Text = default(string); } else { txtNumberEmployees.Text = System.Convert.ToString(clsdbo_DimReseller.NumberEmployees); }
                		if (clsdbo_DimReseller.OrderFrequency == null) { txtOrderFrequency.Text = default(string); } else { txtOrderFrequency.Text = System.Convert.ToString(clsdbo_DimReseller.OrderFrequency); }
                		if (clsdbo_DimReseller.OrderMonth == null) { txtOrderMonth.Text = default(string); } else { txtOrderMonth.Text = System.Convert.ToString(clsdbo_DimReseller.OrderMonth); }
                		if (clsdbo_DimReseller.FirstOrderYear == null) { txtFirstOrderYear.Text = default(string); } else { txtFirstOrderYear.Text = System.Convert.ToString(clsdbo_DimReseller.FirstOrderYear); }
                		if (clsdbo_DimReseller.LastOrderYear == null) { txtLastOrderYear.Text = default(string); } else { txtLastOrderYear.Text = System.Convert.ToString(clsdbo_DimReseller.LastOrderYear); }
                		if (clsdbo_DimReseller.ProductLine == null) { txtProductLine.Text = default(string); } else { txtProductLine.Text = System.Convert.ToString(clsdbo_DimReseller.ProductLine); }
                		if (clsdbo_DimReseller.AddressLine1 == null) { txtAddressLine1.Text = default(string); } else { txtAddressLine1.Text = System.Convert.ToString(clsdbo_DimReseller.AddressLine1); }
                		if (clsdbo_DimReseller.AddressLine2 == null) { txtAddressLine2.Text = default(string); } else { txtAddressLine2.Text = System.Convert.ToString(clsdbo_DimReseller.AddressLine2); }
                		if (clsdbo_DimReseller.AnnualSales == null) { txtAnnualSales.Text = default(string); } else { txtAnnualSales.Text = System.Convert.ToString(clsdbo_DimReseller.AnnualSales); }
                		if (clsdbo_DimReseller.BankName == null) { txtBankName.Text = default(string); } else { txtBankName.Text = System.Convert.ToString(clsdbo_DimReseller.BankName); }
                		if (clsdbo_DimReseller.MinPaymentType == null) { txtMinPaymentType.Text = default(string); } else { txtMinPaymentType.Text = System.Convert.ToString(clsdbo_DimReseller.MinPaymentType); }
                		if (clsdbo_DimReseller.MinPaymentAmount == null) { txtMinPaymentAmount.Text = default(string); } else { txtMinPaymentAmount.Text = System.Convert.ToString(clsdbo_DimReseller.MinPaymentAmount); }
                		if (clsdbo_DimReseller.AnnualRevenue == null) { txtAnnualRevenue.Text = default(string); } else { txtAnnualRevenue.Text = System.Convert.ToString(clsdbo_DimReseller.AnnualRevenue); }
                		if (clsdbo_DimReseller.YearOpened == null) { txtYearOpened.Text = default(string); } else { txtYearOpened.Text = System.Convert.ToString(clsdbo_DimReseller.YearOpened); }
		   	 }
		    	catch (Exception ex)
		    	{
		    		ec.ShowMessage(ex.Message, " Dbo. Dim Reseller ");
		    	}
		    }

        }

        private void Edit()
        {
		    Session.Remove("Mode");
		    Session["Mode"] = "Edit";

                    GetData();

		    txtGeographyKey.Enabled = true;
		    txtResellerAlternateKey.Enabled = true;
		    txtPhone.Enabled = true;
		    txtBusinessType.Enabled = true;
		    txtResellerName.Enabled = true;
		    txtNumberEmployees.Enabled = true;
		    txtOrderFrequency.Enabled = true;
		    txtOrderMonth.Enabled = true;
		    txtFirstOrderYear.Enabled = true;
		    txtLastOrderYear.Enabled = true;
		    txtProductLine.Enabled = true;
		    txtAddressLine1.Enabled = true;
		    txtAddressLine2.Enabled = true;
		    txtAnnualSales.Enabled = true;
		    txtBankName.Enabled = true;
		    txtMinPaymentType.Enabled = true;
		    txtMinPaymentAmount.Enabled = true;
		    txtAnnualRevenue.Enabled = true;
		    txtYearOpened.Enabled = true;
		    txtResellerKey.Enabled = false;
		    txtGeographyKey.Focus();
        }

        private void Delete()
        {
		    Session.Remove("Mode");
		    Session["Mode"] = "Delete";

                    GetData();

		    txtResellerKey.Enabled = false;
		    txtGeographyKey.Enabled = false;
		    txtResellerAlternateKey.Enabled = false;
		    txtPhone.Enabled = false;
		    txtBusinessType.Enabled = false;
		    txtResellerName.Enabled = false;
		    txtNumberEmployees.Enabled = false;
		    txtOrderFrequency.Enabled = false;
		    txtOrderMonth.Enabled = false;
		    txtFirstOrderYear.Enabled = false;
		    txtLastOrderYear.Enabled = false;
		    txtProductLine.Enabled = false;
		    txtAddressLine1.Enabled = false;
		    txtAddressLine2.Enabled = false;
		    txtAnnualSales.Enabled = false;
		    txtBankName.Enabled = false;
		    txtMinPaymentType.Enabled = false;
		    txtMinPaymentAmount.Enabled = false;
		    txtAnnualRevenue.Enabled = false;
		    txtYearOpened.Enabled = false;
        }

        private void ClearRecord()
        {
	        txtResellerKey.Text = null;
	        txtGeographyKey.SelectedIndex = -1;
	        txtResellerAlternateKey.Text = null;
	        txtPhone.Text = null;
	        txtBusinessType.Text = null;
	        txtResellerName.Text = null;
	        txtNumberEmployees.Text = null;
	        txtOrderFrequency.Text = null;
	        txtOrderMonth.Text = null;
	        txtFirstOrderYear.Text = null;
	        txtLastOrderYear.Text = null;
	        txtProductLine.Text = null;
	        txtAddressLine1.Text = null;
	        txtAddressLine2.Text = null;
	        txtAnnualSales.Text = null;
	        txtBankName.Text = null;
	        txtMinPaymentType.Text = null;
	        txtMinPaymentAmount.Text = null;
	        txtAnnualRevenue.Text = null;
	        txtYearOpened.Text = null;
        }

        public void btnSave_Click(object sender, System.EventArgs e)
        {
		    if ((String)Session["Mode"] == "Add") {
			    this.InsertRecord();
		    } else if ((String)Session["Mode"] == "Edit") {
			    this.UpdateRecord();
		    }
        }

        private void SetData(dbo_DimResellerClass clsdbo_DimReseller)
        {
			    if (string.IsNullOrEmpty(txtGeographyKey.SelectedValue)) {
			    	clsdbo_DimReseller.GeographyKey = null;
			    } else {
			    	clsdbo_DimReseller.GeographyKey = System.Convert.ToInt32(txtGeographyKey.SelectedValue); }
			    if (string.IsNullOrEmpty(txtResellerAlternateKey.Text)) {
			    	clsdbo_DimReseller.ResellerAlternateKey = null;
			    } else {
			    	clsdbo_DimReseller.ResellerAlternateKey = txtResellerAlternateKey.Text; }
			    if (string.IsNullOrEmpty(txtPhone.Text)) {
			    	clsdbo_DimReseller.Phone = null;
			    } else {
			    	clsdbo_DimReseller.Phone = txtPhone.Text; }
			    clsdbo_DimReseller.BusinessType = System.Convert.ToString(txtBusinessType.Text);
			    clsdbo_DimReseller.ResellerName = System.Convert.ToString(txtResellerName.Text);
			    if (string.IsNullOrEmpty(txtNumberEmployees.Text)) {
			    	clsdbo_DimReseller.NumberEmployees = null;
			    } else {
			    	clsdbo_DimReseller.NumberEmployees = System.Convert.ToInt32(txtNumberEmployees.Text); }
			    if (string.IsNullOrEmpty(txtOrderFrequency.Text)) {
			    	clsdbo_DimReseller.OrderFrequency = null;
			    } else {
			    	clsdbo_DimReseller.OrderFrequency = txtOrderFrequency.Text; }
			    if (string.IsNullOrEmpty(txtOrderMonth.Text)) {
			    	clsdbo_DimReseller.OrderMonth = null;
			    } else {
			    	clsdbo_DimReseller.OrderMonth = System.Convert.ToByte(txtOrderMonth.Text); }
			    if (string.IsNullOrEmpty(txtFirstOrderYear.Text)) {
			    	clsdbo_DimReseller.FirstOrderYear = null;
			    } else {
			    	clsdbo_DimReseller.FirstOrderYear = System.Convert.ToInt32(txtFirstOrderYear.Text); }
			    if (string.IsNullOrEmpty(txtLastOrderYear.Text)) {
			    	clsdbo_DimReseller.LastOrderYear = null;
			    } else {
			    	clsdbo_DimReseller.LastOrderYear = System.Convert.ToInt32(txtLastOrderYear.Text); }
			    if (string.IsNullOrEmpty(txtProductLine.Text)) {
			    	clsdbo_DimReseller.ProductLine = null;
			    } else {
			    	clsdbo_DimReseller.ProductLine = txtProductLine.Text; }
			    if (string.IsNullOrEmpty(txtAddressLine1.Text)) {
			    	clsdbo_DimReseller.AddressLine1 = null;
			    } else {
			    	clsdbo_DimReseller.AddressLine1 = txtAddressLine1.Text; }
			    if (string.IsNullOrEmpty(txtAddressLine2.Text)) {
			    	clsdbo_DimReseller.AddressLine2 = null;
			    } else {
			    	clsdbo_DimReseller.AddressLine2 = txtAddressLine2.Text; }
			    if (string.IsNullOrEmpty(txtAnnualSales.Text)) {
			    	clsdbo_DimReseller.AnnualSales = null;
			    } else {
			    	clsdbo_DimReseller.AnnualSales = System.Convert.ToDecimal(txtAnnualSales.Text); }
			    if (string.IsNullOrEmpty(txtBankName.Text)) {
			    	clsdbo_DimReseller.BankName = null;
			    } else {
			    	clsdbo_DimReseller.BankName = txtBankName.Text; }
			    if (string.IsNullOrEmpty(txtMinPaymentType.Text)) {
			    	clsdbo_DimReseller.MinPaymentType = null;
			    } else {
			    	clsdbo_DimReseller.MinPaymentType = System.Convert.ToByte(txtMinPaymentType.Text); }
			    if (string.IsNullOrEmpty(txtMinPaymentAmount.Text)) {
			    	clsdbo_DimReseller.MinPaymentAmount = null;
			    } else {
			    	clsdbo_DimReseller.MinPaymentAmount = System.Convert.ToDecimal(txtMinPaymentAmount.Text); }
			    if (string.IsNullOrEmpty(txtAnnualRevenue.Text)) {
			    	clsdbo_DimReseller.AnnualRevenue = null;
			    } else {
			    	clsdbo_DimReseller.AnnualRevenue = System.Convert.ToDecimal(txtAnnualRevenue.Text); }
			    if (string.IsNullOrEmpty(txtYearOpened.Text)) {
			    	clsdbo_DimReseller.YearOpened = null;
			    } else {
			    	clsdbo_DimReseller.YearOpened = System.Convert.ToInt32(txtYearOpened.Text); }
        }

        private void InsertRecord()
        {
		    dbo_DimResellerClass clsdbo_DimReseller = new dbo_DimResellerClass();
		    if (VerifyData() == true) {
                            SetData(clsdbo_DimReseller);
			    bool bSucess = false;
			    bSucess = dbo_DimResellerDataClass.Add(clsdbo_DimReseller);
			    if (bSucess == true) {
				    pnlForm.Visible = false;
				    pnlSave.Visible = false;
				    pnlGrid.Visible = true;
				    lblMode.InnerText = "";
				    Session.Remove("dvdbo_DimReseller");
				    LoadGriddbo_DimReseller();
			    } else {
				    ec.ShowMessage(" Insert failed. ", " Dbo. Dim Reseller ");
			    }
		    }
        }

        private void UpdateRecord()
        {
		    dbo_DimResellerClass oclsdbo_DimReseller = new dbo_DimResellerClass();
		    dbo_DimResellerClass clsdbo_DimReseller = new dbo_DimResellerClass();

		    oclsdbo_DimReseller.ResellerKey = System.Convert.ToInt32(Session["ResellerKey"]);
		    oclsdbo_DimReseller = dbo_DimResellerDataClass.Select_Record(oclsdbo_DimReseller);

		    if (VerifyData() == true) {
                            SetData(clsdbo_DimReseller);
			    bool bSucess = false;
			    bSucess = dbo_DimResellerDataClass.Update(oclsdbo_DimReseller, clsdbo_DimReseller);
			    if (bSucess == true) {
				    pnlForm.Visible = false;
				    pnlSave.Visible = false;
				    pnlGrid.Visible = true;
				    lblMode.InnerText = "";
				    Session.Remove("dvdbo_DimReseller");
				    LoadGriddbo_DimReseller();
			    } else {
				    ec.ShowMessage(" Update failed. ", " Dbo. Dim Reseller ");
			    }
		    }
        }

        private void DeleteRecord()
        {
		    dbo_DimResellerClass clsdbo_DimReseller = new dbo_DimResellerClass();
		    clsdbo_DimReseller.ResellerKey = System.Convert.ToInt32(Session["ResellerKey"]);
                    SetData(clsdbo_DimReseller);
		    bool bSucess = false;
		    bSucess = dbo_DimResellerDataClass.Delete(clsdbo_DimReseller);
		    if (bSucess == true) {
			    pnlForm.Visible = false;
			    pnlSave.Visible = false;
			    pnlGrid.Visible = true;
			    pnlDelete.Visible = false;
			    lblMode.InnerText = "";
			    Session.Remove("dvdbo_DimReseller");
			    LoadGriddbo_DimReseller();
		    } else {
			    ec.ShowMessage(" Delete failed. ", " Dbo. Dim Reseller ");
		    }
        }

        private Boolean VerifyData()
        {
		    if (txtBusinessType.Text == "") {
		    	ec.ShowMessage(" Business Type is Required. ", " Dbo. Dim Reseller ");
	                txtBusinessType.Focus();
                	return false;}
		    if (txtResellerName.Text == "") {
		    	ec.ShowMessage(" Reseller Name is Required. ", " Dbo. Dim Reseller ");
	                txtResellerName.Focus();
                	return false;}
		    return true;
        }

        public void butRecords_Click(object sender, System.EventArgs e)
        {
		    grddbo_DimReseller.CurrentPageIndex = 0;
		    grddbo_DimReseller.PageSize = Convert.ToInt32(cmbRecords.Text);
		    LoadGriddbo_DimReseller();
        }

        public void btnAddNew_Click(object sender, System.EventArgs e)
        {
		    if (pnlForm.Visible) {
			    txtResellerKey.Text = "";
			    txtGeographyKey.SelectedIndex = -1;
			    txtResellerAlternateKey.Text = "";
			    txtPhone.Text = "";
			    txtBusinessType.Text = "";
			    txtResellerName.Text = "";
			    txtNumberEmployees.Text = "";
			    txtOrderFrequency.Text = "";
			    txtOrderMonth.Text = "";
			    txtFirstOrderYear.Text = "";
			    txtLastOrderYear.Text = "";
			    txtProductLine.Text = "";
			    txtAddressLine1.Text = "";
			    txtAddressLine2.Text = "";
			    txtAnnualSales.Text = "";
			    txtBankName.Text = "";
			    txtMinPaymentType.Text = "";
			    txtMinPaymentAmount.Text = "";
			    txtAnnualRevenue.Text = "";
			    txtYearOpened.Text = "";
		    } else {
			    pnlForm.Visible = true;
			    pnlGrid.Visible = false;
			    pnlSave.Visible = true;
			    lblMode.InnerText = "Add new";
		    }
		    btnSave.CommandArgument = "Add";
		    Add();
        }

        public void grddbo_DimReseller_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
        { 
		    if (e.Item.ItemType == ListItemType.Pager | e.Item.ItemType == ListItemType.Header)
			    return;

		    Button btn = (Button)e.CommandSource;
		    if (btn.Text == "Edit" | btn.Text == "Delete") {
			    Session.Remove("ResellerKey");
			    Session["ResellerKey"] = e.Item.Cells[0 + 0].Text;
			    if (btn.Text == "Edit") {
				    Edit();
			    } else if (btn.Text == "Delete") {
				    Delete();
			    }
			    pnlForm.Visible = true;
			    pnlGrid.Visible = false;
			    if (btn.Text == "Edit") {
				    lblMode.InnerText = "Edit record";
				    pnlSave.Visible = true;
			    }
			    if (btn.Text == "Delete") {
				    lblMode.InnerText = "Delete record";
				    pnlDelete.Visible = true;
			    }
		    }
		    btnSave.CommandArgument = "";
        }

        public void grddbo_DimReseller_SortCommand(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
        {
		    htmlHiddenSortExpression.Value = e.SortExpression + " " + GetSortDirection(e.SortExpression);
		    LoadGriddbo_DimReseller();
        }

        public void grddbo_DimReseller_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
        {
		    grddbo_DimReseller.CurrentPageIndex = e.NewPageIndex;
		    LoadGriddbo_DimReseller();
        }

        public void butYes_Click(object sender, System.EventArgs e)
        {
		    this.DeleteRecord();
        }

        public void butNo_Click(object sender, System.EventArgs e)
        {
		    pnlDelete.Visible = false;
		    pnlGrid.Visible = true;
		    pnlForm.Visible = false;
		    lblMode.InnerText = "";
        }

        public void butCancel_Click(object sender, System.EventArgs e)
        {
		    pnlForm.Visible = false;
		    pnlSave.Visible = false;
		    pnlGrid.Visible = true;
		    lblMode.InnerText = "";
        }

        public void butOK_Click(object sender, System.EventArgs e)
        {
		    pnlMessage.Visible = false;
		    pnlGrid.Visible = true;
        }

        private void showMessage()
        {
		    lblMode.InnerText = "";
		    pnlForm.Visible = false;
		    pnlSave.Visible = false;
		    pnlDelete.Visible = false;
		    pnlGrid.Visible = false;
		    pnlMessage.Visible = true;
        }

        public void butShowAll_Click(object sender, System.EventArgs e)
        {
		    txtSearch.Text = null;
		    Session.Remove("dvdbo_DimReseller");
		    LoadGriddbo_DimReseller();
        }

        public void butSearch_Click(object sender, System.EventArgs e)
        {
		    try {
                        Session.Remove("dvdbo_DimReseller");
			if ((Session["dvdbo_DimReseller"] != null)) {
				dvdbo_DimReseller = (DataView)Session["dvdbo_DimReseller"];
				// DataView was not found in the session.
		    	} else {
				dvdbo_DimReseller = dbo_DimResellerDataClass.Search(cmbFields.Text, cmbCondition.Text, txtSearch.Text).DefaultView;
			    	Session["dvdbo_DimReseller"] = dvdbo_DimReseller;
		    	}
                if (dvdbo_DimReseller.Count > 0)
                {
                    dvdbo_DimReseller.Sort = htmlHiddenSortExpression.Value;
                    grddbo_DimReseller.DataSource = dvdbo_DimReseller;
                    grddbo_DimReseller.DataBind();
                }
                else
                {
                    grddbo_DimReseller.DataSource = null;
                    grddbo_DimReseller.DataBind();
                }
		    }
		    catch (Exception ex)
		    {
		    	ec.ShowMessage(ex.Message, " Dbo. Dim Reseller ");
		    }
        }

        public void btnExport_Click(System.Object sender, System.EventArgs e)
        {
            try
            {
                if (ddlFile.SelectedValue == ".pdf")
                {
                    DataTable dt = new DataTable();
                    if (!string.IsNullOrEmpty(txtSearch.Text))
                    { dt = dbo_DimResellerDataClass.Search(cmbFields.Text, cmbCondition.Text, txtSearch.Text); }
                    else { dt = dbo_DimResellerDataClass.SelectAll(); }

                    PDFform pdfForm = new PDFform(dt, "Dbo. Dim Reseller", "Many");
                    Document document = pdfForm.CreateDocument();
                    PdfDocumentRenderer renderer = new PdfDocumentRenderer(true);
                    renderer.Document = document;
                    renderer.RenderDocument();

                    MemoryStream stream = new MemoryStream();
                    renderer.PdfDocument.Save(stream, false);

                    Response.Clear();
                    Response.ContentType = "application/" + ddlFile.SelectedItem.Text + ddlFile.SelectedValue;
                    Response.AddHeader("content-disposition", "attachment;filename=" + "Report" + ddlFile.SelectedValue);
                    Response.BinaryWrite(stream.ToArray());
                    Response.Flush();
                    Response.End();
                }
                else
                {
                    Response.Clear();
                    Response.Charset = "";
                    Response.ContentEncoding = System.Text.Encoding.UTF8;
                    Response.Cache.SetCacheability(HttpCacheability.NoCache);
                    Response.ContentType = "application/" + ddlFile.SelectedItem.Text + ddlFile.SelectedValue;
                    Response.AddHeader("content-disposition", "attachment;filename=" + "Report" + ddlFile.SelectedValue);

                    System.IO.StringWriter sw = new System.IO.StringWriter();
                    HtmlTextWriter htw = new HtmlTextWriter(sw);
                    GridView GVExport = new GridView();
                    GVExport.DataSource = Session["dvdbo_DimReseller"];
                    GVExport.DataBind();
                    GVExport.RenderControl(htw);

                    Response.Write(sw);
                    sw = null;
                    htw = null;
                    Response.Flush();
                    Response.End();
                }
            }
            catch
            {
            }
        }

        private string GetSortDirection(string column)
        {
            dynamic sortDirection = "ASC";
            dynamic sortExpression = ViewState["SortExpression"] as string;
            if (sortExpression != null)
            {
                if (sortExpression == column)
                {
                    dynamic lastDirection = ViewState["SortDirection"] as string;
                    if (lastDirection != null && lastDirection == "ASC")
                    {
                        sortDirection = "DESC";
                    }
                }
            }
            ViewState["SortDirection"] = sortDirection;
            ViewState["SortExpression"] = column;
            return sortDirection;
        }

    }
}
 
