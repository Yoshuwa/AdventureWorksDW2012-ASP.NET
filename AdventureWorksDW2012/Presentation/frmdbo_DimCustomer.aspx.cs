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
    public partial class frmdbo_DimCustomer : System.Web.UI.Page
    {

        private dbo_DimCustomerDataClass clsdbo_DimCustomerData = new dbo_DimCustomerDataClass();
        private AdventureWorksDW2012DataClass clsAdventureWorksDW2012Data = new AdventureWorksDW2012DataClass();
        private DataView dvdbo_DimCustomer;

        protected void Page_Load(object sender, EventArgs e)
        {
		    if (!Page.IsPostBack) {
			    Session["Mode"] = "";
 			    Session["CustomerKey"] = "";

			    Session.Remove("dvdbo_DimCustomer");

                            cmbFields.Items.Add("Customer Key");
                            cmbFields.Items.Add("Geography Key");
                            cmbFields.Items.Add("Customer Alternate Key");
                            cmbFields.Items.Add("Title");
                            cmbFields.Items.Add("First Name");
                            cmbFields.Items.Add("Middle Name");
                            cmbFields.Items.Add("Last Name");
                            cmbFields.Items.Add("Name Style");
                            cmbFields.Items.Add("Birth Date");
                            cmbFields.Items.Add("Marital Status");
                            cmbFields.Items.Add("Suffix");
                            cmbFields.Items.Add("Gender");
                            cmbFields.Items.Add("Email Address");
                            cmbFields.Items.Add("Yearly Income");
                            cmbFields.Items.Add("Total Children");
                            cmbFields.Items.Add("Number Children At Home");
                            cmbFields.Items.Add("English Education");
                            cmbFields.Items.Add("Spanish Education");
                            cmbFields.Items.Add("French Education");
                            cmbFields.Items.Add("English Occupation");
                            cmbFields.Items.Add("Spanish Occupation");
                            cmbFields.Items.Add("French Occupation");
                            cmbFields.Items.Add("House Owner Flag");
                            cmbFields.Items.Add("Number Cars Owned");
                            cmbFields.Items.Add("Address Line1");
                            cmbFields.Items.Add("Address Line2");
                            cmbFields.Items.Add("Phone");
                            cmbFields.Items.Add("Date First Purchase");
                            cmbFields.Items.Add("Commute Distance");

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

            Loaddbo_DimCustomer_dbo_DimGeographyComboBox();

			    LoadGriddbo_DimCustomer();
		    }

        }


	    private void Loaddbo_DimCustomer_dbo_DimGeographyComboBox()
	    {
		    List<dbo_DimCustomer_dbo_DimGeographyClass> dbo_DimCustomer_dbo_DimGeographyList = new  List<dbo_DimCustomer_dbo_DimGeographyClass>();
		    try {
			    dbo_DimCustomer_dbo_DimGeographyList = dbo_DimCustomer_dbo_DimGeographyDataClass.List();
			    txtGeographyKey.DataSource = dbo_DimCustomer_dbo_DimGeographyList;
			    txtGeographyKey.DataValueField = "GeographyKey";
			    txtGeographyKey.DataTextField = "StateProvinceName";
			    txtGeographyKey.DataBind();
		    }
		    catch (Exception ex)
		    {
		    	ec.ShowMessage(ex.Message, " Dbo. Dim Customer ");
		    }
	    }

        private void LoadGriddbo_DimCustomer()
        {
		    try {
			if ((Session["dvdbo_DimCustomer"] != null)) {
				dvdbo_DimCustomer = (DataView)Session["dvdbo_DimCustomer"];
				// DataView was not found in the session.
		    	} else {
				dvdbo_DimCustomer = dbo_DimCustomerDataClass.SelectAll().DefaultView;
			    	Session["dvdbo_DimCustomer"] = dvdbo_DimCustomer;
		    	}
                if (dvdbo_DimCustomer.Count > 0)
                {
                    dvdbo_DimCustomer.Sort = htmlHiddenSortExpression.Value;
                    grddbo_DimCustomer.DataSource = dvdbo_DimCustomer;
                    grddbo_DimCustomer.DataBind();
                }
                else
                {
                    grddbo_DimCustomer.DataSource = null;
                    grddbo_DimCustomer.DataBind();
                }
		    }
		    catch (Exception ex)
		    {
		    	ec.ShowMessage(ex.Message, " Dbo. Dim Customer ");
		    }
        }

        private void Add()
        {
		    Session.Remove("Mode");
		    Session["Mode"] = "Add";

		    ClearRecord();

		    this.txtGeographyKey.Enabled = true;
		    this.txtCustomerAlternateKey.Enabled = true;
		    this.txtTitle.Enabled = true;
		    this.txtFirstName.Enabled = true;
		    this.txtMiddleName.Enabled = true;
		    this.txtLastName.Enabled = true;
		    this.txtNameStyle.Enabled = true;
		    this.txtBirthDate.Enabled = true;
		    this.txtMaritalStatus.Enabled = true;
		    this.txtSuffix.Enabled = true;
		    this.txtGender.Enabled = true;
		    this.txtEmailAddress.Enabled = true;
		    this.txtYearlyIncome.Enabled = true;
		    this.txtTotalChildren.Enabled = true;
		    this.txtNumberChildrenAtHome.Enabled = true;
		    this.txtEnglishEducation.Enabled = true;
		    this.txtSpanishEducation.Enabled = true;
		    this.txtFrenchEducation.Enabled = true;
		    this.txtEnglishOccupation.Enabled = true;
		    this.txtSpanishOccupation.Enabled = true;
		    this.txtFrenchOccupation.Enabled = true;
		    this.txtHouseOwnerFlag.Enabled = true;
		    this.txtNumberCarsOwned.Enabled = true;
		    this.txtAddressLine1.Enabled = true;
		    this.txtAddressLine2.Enabled = true;
		    this.txtPhone.Enabled = true;
		    this.txtDateFirstPurchase.Enabled = true;
		    this.txtCommuteDistance.Enabled = true;
		    txtCustomerKey.Enabled = false;
		    txtGeographyKey.Focus();
		    txtCustomerKey.Text = Convert.ToString(clsAdventureWorksDW2012Data.getAutoID("New", "DimCustomer"));
        }

        private void GetData()
        {
		    ClearRecord();

		    dbo_DimCustomerClass clsdbo_DimCustomer = new dbo_DimCustomerClass();
		    clsdbo_DimCustomer.CustomerKey = System.Convert.ToInt32(Session["CustomerKey"]);
		    clsdbo_DimCustomer = dbo_DimCustomerDataClass.Select_Record(clsdbo_DimCustomer);

		    if ((clsdbo_DimCustomer != null)) {
			    try {
                		txtCustomerKey.Text = System.Convert.ToString(clsdbo_DimCustomer.CustomerKey);
                		if (clsdbo_DimCustomer.GeographyKey == null) { txtGeographyKey.SelectedValue = default(string); } else { txtGeographyKey.SelectedValue = System.Convert.ToString(clsdbo_DimCustomer.GeographyKey); }
                		txtCustomerAlternateKey.Text = System.Convert.ToString(clsdbo_DimCustomer.CustomerAlternateKey);
                		if (clsdbo_DimCustomer.Title == null) { txtTitle.Text = default(string); } else { txtTitle.Text = System.Convert.ToString(clsdbo_DimCustomer.Title); }
                		if (clsdbo_DimCustomer.FirstName == null) { txtFirstName.Text = default(string); } else { txtFirstName.Text = System.Convert.ToString(clsdbo_DimCustomer.FirstName); }
                		if (clsdbo_DimCustomer.MiddleName == null) { txtMiddleName.Text = default(string); } else { txtMiddleName.Text = System.Convert.ToString(clsdbo_DimCustomer.MiddleName); }
                		if (clsdbo_DimCustomer.LastName == null) { txtLastName.Text = default(string); } else { txtLastName.Text = System.Convert.ToString(clsdbo_DimCustomer.LastName); }
                		//if (clsdbo_DimCustomer.NameStyle == null) { txtNameStyle.Checked = default(string); } else { txtNameStyle.Checked = System.Convert.ToBoolean(clsdbo_DimCustomer.NameStyle); }
                		if (clsdbo_DimCustomer.BirthDate == null) { txtBirthDate.Text = DateTime.Now.ToString(); } else { txtBirthDate.Text = System.Convert.ToDateTime(clsdbo_DimCustomer.BirthDate).ToShortDateString(); }
                		if (clsdbo_DimCustomer.MaritalStatus == null) { txtMaritalStatus.Text = default(string); } else { txtMaritalStatus.Text = System.Convert.ToString(clsdbo_DimCustomer.MaritalStatus); }
                		if (clsdbo_DimCustomer.Suffix == null) { txtSuffix.Text = default(string); } else { txtSuffix.Text = System.Convert.ToString(clsdbo_DimCustomer.Suffix); }
                		if (clsdbo_DimCustomer.Gender == null) { txtGender.Text = default(string); } else { txtGender.Text = System.Convert.ToString(clsdbo_DimCustomer.Gender); }
                		if (clsdbo_DimCustomer.EmailAddress == null) { txtEmailAddress.Text = default(string); } else { txtEmailAddress.Text = System.Convert.ToString(clsdbo_DimCustomer.EmailAddress); }
                		if (clsdbo_DimCustomer.YearlyIncome == null) { txtYearlyIncome.Text = default(string); } else { txtYearlyIncome.Text = System.Convert.ToString(clsdbo_DimCustomer.YearlyIncome); }
                		if (clsdbo_DimCustomer.TotalChildren == null) { txtTotalChildren.Text = default(string); } else { txtTotalChildren.Text = System.Convert.ToString(clsdbo_DimCustomer.TotalChildren); }
                		if (clsdbo_DimCustomer.NumberChildrenAtHome == null) { txtNumberChildrenAtHome.Text = default(string); } else { txtNumberChildrenAtHome.Text = System.Convert.ToString(clsdbo_DimCustomer.NumberChildrenAtHome); }
                		if (clsdbo_DimCustomer.EnglishEducation == null) { txtEnglishEducation.Text = default(string); } else { txtEnglishEducation.Text = System.Convert.ToString(clsdbo_DimCustomer.EnglishEducation); }
                		if (clsdbo_DimCustomer.SpanishEducation == null) { txtSpanishEducation.Text = default(string); } else { txtSpanishEducation.Text = System.Convert.ToString(clsdbo_DimCustomer.SpanishEducation); }
                		if (clsdbo_DimCustomer.FrenchEducation == null) { txtFrenchEducation.Text = default(string); } else { txtFrenchEducation.Text = System.Convert.ToString(clsdbo_DimCustomer.FrenchEducation); }
                		if (clsdbo_DimCustomer.EnglishOccupation == null) { txtEnglishOccupation.Text = default(string); } else { txtEnglishOccupation.Text = System.Convert.ToString(clsdbo_DimCustomer.EnglishOccupation); }
                		if (clsdbo_DimCustomer.SpanishOccupation == null) { txtSpanishOccupation.Text = default(string); } else { txtSpanishOccupation.Text = System.Convert.ToString(clsdbo_DimCustomer.SpanishOccupation); }
                		if (clsdbo_DimCustomer.FrenchOccupation == null) { txtFrenchOccupation.Text = default(string); } else { txtFrenchOccupation.Text = System.Convert.ToString(clsdbo_DimCustomer.FrenchOccupation); }
                		if (clsdbo_DimCustomer.HouseOwnerFlag == null) { txtHouseOwnerFlag.Text = default(string); } else { txtHouseOwnerFlag.Text = System.Convert.ToString(clsdbo_DimCustomer.HouseOwnerFlag); }
                		if (clsdbo_DimCustomer.NumberCarsOwned == null) { txtNumberCarsOwned.Text = default(string); } else { txtNumberCarsOwned.Text = System.Convert.ToString(clsdbo_DimCustomer.NumberCarsOwned); }
                		if (clsdbo_DimCustomer.AddressLine1 == null) { txtAddressLine1.Text = default(string); } else { txtAddressLine1.Text = System.Convert.ToString(clsdbo_DimCustomer.AddressLine1); }
                		if (clsdbo_DimCustomer.AddressLine2 == null) { txtAddressLine2.Text = default(string); } else { txtAddressLine2.Text = System.Convert.ToString(clsdbo_DimCustomer.AddressLine2); }
                		if (clsdbo_DimCustomer.Phone == null) { txtPhone.Text = default(string); } else { txtPhone.Text = System.Convert.ToString(clsdbo_DimCustomer.Phone); }
                		if (clsdbo_DimCustomer.DateFirstPurchase == null) { txtDateFirstPurchase.Text = DateTime.Now.ToString(); } else { txtDateFirstPurchase.Text = System.Convert.ToDateTime(clsdbo_DimCustomer.DateFirstPurchase).ToShortDateString(); }
                		if (clsdbo_DimCustomer.CommuteDistance == null) { txtCommuteDistance.Text = default(string); } else { txtCommuteDistance.Text = System.Convert.ToString(clsdbo_DimCustomer.CommuteDistance); }
		   	 }
		    	catch (Exception ex)
		    	{
		    		ec.ShowMessage(ex.Message, " Dbo. Dim Customer ");
		    	}
		    }

        }

        private void Edit()
        {
		    Session.Remove("Mode");
		    Session["Mode"] = "Edit";

                    GetData();

		    txtGeographyKey.Enabled = true;
		    txtCustomerAlternateKey.Enabled = true;
		    txtTitle.Enabled = true;
		    txtFirstName.Enabled = true;
		    txtMiddleName.Enabled = true;
		    txtLastName.Enabled = true;
		    txtMaritalStatus.Enabled = true;
		    txtSuffix.Enabled = true;
		    txtGender.Enabled = true;
		    txtEmailAddress.Enabled = true;
		    txtYearlyIncome.Enabled = true;
		    txtTotalChildren.Enabled = true;
		    txtNumberChildrenAtHome.Enabled = true;
		    txtEnglishEducation.Enabled = true;
		    txtSpanishEducation.Enabled = true;
		    txtFrenchEducation.Enabled = true;
		    txtEnglishOccupation.Enabled = true;
		    txtSpanishOccupation.Enabled = true;
		    txtFrenchOccupation.Enabled = true;
		    txtHouseOwnerFlag.Enabled = true;
		    txtNumberCarsOwned.Enabled = true;
		    txtAddressLine1.Enabled = true;
		    txtAddressLine2.Enabled = true;
		    txtPhone.Enabled = true;
		    txtCommuteDistance.Enabled = true;
		    txtCustomerKey.Enabled = false;
		    txtGeographyKey.Focus();
        }

        private void Delete()
        {
		    Session.Remove("Mode");
		    Session["Mode"] = "Delete";

                    GetData();

		    txtCustomerKey.Enabled = false;
		    txtGeographyKey.Enabled = false;
		    txtCustomerAlternateKey.Enabled = false;
		    txtTitle.Enabled = false;
		    txtFirstName.Enabled = false;
		    txtMiddleName.Enabled = false;
		    txtLastName.Enabled = false;
		    txtNameStyle.Enabled = false;
		    txtBirthDate.Enabled = false;
		    txtMaritalStatus.Enabled = false;
		    txtSuffix.Enabled = false;
		    txtGender.Enabled = false;
		    txtEmailAddress.Enabled = false;
		    txtYearlyIncome.Enabled = false;
		    txtTotalChildren.Enabled = false;
		    txtNumberChildrenAtHome.Enabled = false;
		    txtEnglishEducation.Enabled = false;
		    txtSpanishEducation.Enabled = false;
		    txtFrenchEducation.Enabled = false;
		    txtEnglishOccupation.Enabled = false;
		    txtSpanishOccupation.Enabled = false;
		    txtFrenchOccupation.Enabled = false;
		    txtHouseOwnerFlag.Enabled = false;
		    txtNumberCarsOwned.Enabled = false;
		    txtAddressLine1.Enabled = false;
		    txtAddressLine2.Enabled = false;
		    txtPhone.Enabled = false;
		    txtDateFirstPurchase.Enabled = false;
		    txtCommuteDistance.Enabled = false;
        }

        private void ClearRecord()
        {
	        txtCustomerKey.Text = null;
	        txtGeographyKey.SelectedIndex = -1;
	        txtCustomerAlternateKey.Text = null;
	        txtTitle.Text = null;
	        txtFirstName.Text = null;
	        txtMiddleName.Text = null;
	        txtLastName.Text = null;
        	txtNameStyle.Text = null;
        	txtBirthDate.Text = null;
	        txtMaritalStatus.Text = null;
	        txtSuffix.Text = null;
	        txtGender.Text = null;
	        txtEmailAddress.Text = null;
	        txtYearlyIncome.Text = null;
	        txtTotalChildren.Text = null;
	        txtNumberChildrenAtHome.Text = null;
	        txtEnglishEducation.Text = null;
	        txtSpanishEducation.Text = null;
	        txtFrenchEducation.Text = null;
	        txtEnglishOccupation.Text = null;
	        txtSpanishOccupation.Text = null;
	        txtFrenchOccupation.Text = null;
	        txtHouseOwnerFlag.Text = null;
	        txtNumberCarsOwned.Text = null;
	        txtAddressLine1.Text = null;
	        txtAddressLine2.Text = null;
	        txtPhone.Text = null;
        	txtDateFirstPurchase.Text = null;
	        txtCommuteDistance.Text = null;
        }

        public void btnSave_Click(object sender, System.EventArgs e)
        {
		    if ((String)Session["Mode"] == "Add") {
			    this.InsertRecord();
		    } else if ((String)Session["Mode"] == "Edit") {
			    this.UpdateRecord();
		    }
        }

        private void SetData(dbo_DimCustomerClass clsdbo_DimCustomer)
        {
			    if (string.IsNullOrEmpty(txtGeographyKey.SelectedValue)) {
			    	clsdbo_DimCustomer.GeographyKey = null;
			    } else {
			    	clsdbo_DimCustomer.GeographyKey = System.Convert.ToInt32(txtGeographyKey.SelectedValue); }
			    clsdbo_DimCustomer.CustomerAlternateKey = System.Convert.ToString(txtCustomerAlternateKey.Text);
			    if (string.IsNullOrEmpty(txtTitle.Text)) {
			    	clsdbo_DimCustomer.Title = null;
			    } else {
			    	clsdbo_DimCustomer.Title = txtTitle.Text; }
			    if (string.IsNullOrEmpty(txtFirstName.Text)) {
			    	clsdbo_DimCustomer.FirstName = null;
			    } else {
			    	clsdbo_DimCustomer.FirstName = txtFirstName.Text; }
			    if (string.IsNullOrEmpty(txtMiddleName.Text)) {
			    	clsdbo_DimCustomer.MiddleName = null;
			    } else {
			    	clsdbo_DimCustomer.MiddleName = txtMiddleName.Text; }
			    if (string.IsNullOrEmpty(txtLastName.Text)) {
			    	clsdbo_DimCustomer.LastName = null;
			    } else {
			    	clsdbo_DimCustomer.LastName = txtLastName.Text; }
			    clsdbo_DimCustomer.NameStyle = txtNameStyle.Checked ? true : false;                        
			    if (string.IsNullOrEmpty(txtBirthDate.Text)) {
			    	clsdbo_DimCustomer.BirthDate = null;
			    } else {
			    	clsdbo_DimCustomer.BirthDate = System.Convert.ToDateTime(txtBirthDate.Text); }
			    if (string.IsNullOrEmpty(txtMaritalStatus.Text)) {
			    	clsdbo_DimCustomer.MaritalStatus = null;
			    } else {
			    	clsdbo_DimCustomer.MaritalStatus = txtMaritalStatus.Text; }
			    if (string.IsNullOrEmpty(txtSuffix.Text)) {
			    	clsdbo_DimCustomer.Suffix = null;
			    } else {
			    	clsdbo_DimCustomer.Suffix = txtSuffix.Text; }
			    if (string.IsNullOrEmpty(txtGender.Text)) {
			    	clsdbo_DimCustomer.Gender = null;
			    } else {
			    	clsdbo_DimCustomer.Gender = txtGender.Text; }
			    if (string.IsNullOrEmpty(txtEmailAddress.Text)) {
			    	clsdbo_DimCustomer.EmailAddress = null;
			    } else {
			    	clsdbo_DimCustomer.EmailAddress = txtEmailAddress.Text; }
			    if (string.IsNullOrEmpty(txtYearlyIncome.Text)) {
			    	clsdbo_DimCustomer.YearlyIncome = null;
			    } else {
			    	clsdbo_DimCustomer.YearlyIncome = System.Convert.ToDecimal(txtYearlyIncome.Text); }
			    if (string.IsNullOrEmpty(txtTotalChildren.Text)) {
			    	clsdbo_DimCustomer.TotalChildren = null;
			    } else {
			    	clsdbo_DimCustomer.TotalChildren = System.Convert.ToByte(txtTotalChildren.Text); }
			    if (string.IsNullOrEmpty(txtNumberChildrenAtHome.Text)) {
			    	clsdbo_DimCustomer.NumberChildrenAtHome = null;
			    } else {
			    	clsdbo_DimCustomer.NumberChildrenAtHome = System.Convert.ToByte(txtNumberChildrenAtHome.Text); }
			    if (string.IsNullOrEmpty(txtEnglishEducation.Text)) {
			    	clsdbo_DimCustomer.EnglishEducation = null;
			    } else {
			    	clsdbo_DimCustomer.EnglishEducation = txtEnglishEducation.Text; }
			    if (string.IsNullOrEmpty(txtSpanishEducation.Text)) {
			    	clsdbo_DimCustomer.SpanishEducation = null;
			    } else {
			    	clsdbo_DimCustomer.SpanishEducation = txtSpanishEducation.Text; }
			    if (string.IsNullOrEmpty(txtFrenchEducation.Text)) {
			    	clsdbo_DimCustomer.FrenchEducation = null;
			    } else {
			    	clsdbo_DimCustomer.FrenchEducation = txtFrenchEducation.Text; }
			    if (string.IsNullOrEmpty(txtEnglishOccupation.Text)) {
			    	clsdbo_DimCustomer.EnglishOccupation = null;
			    } else {
			    	clsdbo_DimCustomer.EnglishOccupation = txtEnglishOccupation.Text; }
			    if (string.IsNullOrEmpty(txtSpanishOccupation.Text)) {
			    	clsdbo_DimCustomer.SpanishOccupation = null;
			    } else {
			    	clsdbo_DimCustomer.SpanishOccupation = txtSpanishOccupation.Text; }
			    if (string.IsNullOrEmpty(txtFrenchOccupation.Text)) {
			    	clsdbo_DimCustomer.FrenchOccupation = null;
			    } else {
			    	clsdbo_DimCustomer.FrenchOccupation = txtFrenchOccupation.Text; }
			    if (string.IsNullOrEmpty(txtHouseOwnerFlag.Text)) {
			    	clsdbo_DimCustomer.HouseOwnerFlag = null;
			    } else {
			    	clsdbo_DimCustomer.HouseOwnerFlag = txtHouseOwnerFlag.Text; }
			    if (string.IsNullOrEmpty(txtNumberCarsOwned.Text)) {
			    	clsdbo_DimCustomer.NumberCarsOwned = null;
			    } else {
			    	clsdbo_DimCustomer.NumberCarsOwned = System.Convert.ToByte(txtNumberCarsOwned.Text); }
			    if (string.IsNullOrEmpty(txtAddressLine1.Text)) {
			    	clsdbo_DimCustomer.AddressLine1 = null;
			    } else {
			    	clsdbo_DimCustomer.AddressLine1 = txtAddressLine1.Text; }
			    if (string.IsNullOrEmpty(txtAddressLine2.Text)) {
			    	clsdbo_DimCustomer.AddressLine2 = null;
			    } else {
			    	clsdbo_DimCustomer.AddressLine2 = txtAddressLine2.Text; }
			    if (string.IsNullOrEmpty(txtPhone.Text)) {
			    	clsdbo_DimCustomer.Phone = null;
			    } else {
			    	clsdbo_DimCustomer.Phone = txtPhone.Text; }
			    if (string.IsNullOrEmpty(txtDateFirstPurchase.Text)) {
			    	clsdbo_DimCustomer.DateFirstPurchase = null;
			    } else {
			    	clsdbo_DimCustomer.DateFirstPurchase = System.Convert.ToDateTime(txtDateFirstPurchase.Text); }
			    if (string.IsNullOrEmpty(txtCommuteDistance.Text)) {
			    	clsdbo_DimCustomer.CommuteDistance = null;
			    } else {
			    	clsdbo_DimCustomer.CommuteDistance = txtCommuteDistance.Text; }
        }

        private void InsertRecord()
        {
		    dbo_DimCustomerClass clsdbo_DimCustomer = new dbo_DimCustomerClass();
		    if (VerifyData() == true) {
                            SetData(clsdbo_DimCustomer);
			    bool bSucess = false;
			    bSucess = dbo_DimCustomerDataClass.Add(clsdbo_DimCustomer);
			    if (bSucess == true) {
				    pnlForm.Visible = false;
				    pnlSave.Visible = false;
				    pnlGrid.Visible = true;
				    lblMode.InnerText = "";
				    Session.Remove("dvdbo_DimCustomer");
				    LoadGriddbo_DimCustomer();
			    } else {
				    ec.ShowMessage(" Insert failed. ", " Dbo. Dim Customer ");
			    }
		    }
        }

        private void UpdateRecord()
        {
		    dbo_DimCustomerClass oclsdbo_DimCustomer = new dbo_DimCustomerClass();
		    dbo_DimCustomerClass clsdbo_DimCustomer = new dbo_DimCustomerClass();

		    oclsdbo_DimCustomer.CustomerKey = System.Convert.ToInt32(Session["CustomerKey"]);
		    oclsdbo_DimCustomer = dbo_DimCustomerDataClass.Select_Record(oclsdbo_DimCustomer);

		    if (VerifyData() == true) {
                            SetData(clsdbo_DimCustomer);
			    bool bSucess = false;
			    bSucess = dbo_DimCustomerDataClass.Update(oclsdbo_DimCustomer, clsdbo_DimCustomer);
			    if (bSucess == true) {
				    pnlForm.Visible = false;
				    pnlSave.Visible = false;
				    pnlGrid.Visible = true;
				    lblMode.InnerText = "";
				    Session.Remove("dvdbo_DimCustomer");
				    LoadGriddbo_DimCustomer();
			    } else {
				    ec.ShowMessage(" Update failed. ", " Dbo. Dim Customer ");
			    }
		    }
        }

        private void DeleteRecord()
        {
		    dbo_DimCustomerClass clsdbo_DimCustomer = new dbo_DimCustomerClass();
		    clsdbo_DimCustomer.CustomerKey = System.Convert.ToInt32(Session["CustomerKey"]);
                    SetData(clsdbo_DimCustomer);
		    bool bSucess = false;
		    bSucess = dbo_DimCustomerDataClass.Delete(clsdbo_DimCustomer);
		    if (bSucess == true) {
			    pnlForm.Visible = false;
			    pnlSave.Visible = false;
			    pnlGrid.Visible = true;
			    pnlDelete.Visible = false;
			    lblMode.InnerText = "";
			    Session.Remove("dvdbo_DimCustomer");
			    LoadGriddbo_DimCustomer();
		    } else {
			    ec.ShowMessage(" Delete failed. ", " Dbo. Dim Customer ");
		    }
        }

        private Boolean VerifyData()
        {
		    if (txtCustomerAlternateKey.Text == "") {
		    	ec.ShowMessage(" Customer Alternate Key is Required. ", " Dbo. Dim Customer ");
	                txtCustomerAlternateKey.Focus();
                	return false;}
		    return true;
        }

        public void butRecords_Click(object sender, System.EventArgs e)
        {
		    grddbo_DimCustomer.CurrentPageIndex = 0;
		    grddbo_DimCustomer.PageSize = Convert.ToInt32(cmbRecords.Text);
		    LoadGriddbo_DimCustomer();
        }

        public void btnAddNew_Click(object sender, System.EventArgs e)
        {
		    if (pnlForm.Visible) {
			    txtCustomerKey.Text = "";
			    txtGeographyKey.SelectedIndex = -1;
			    txtCustomerAlternateKey.Text = "";
			    txtTitle.Text = "";
			    txtFirstName.Text = "";
			    txtMiddleName.Text = "";
			    txtLastName.Text = "";
			    txtNameStyle.Checked = false;
			    txtBirthDate.Text = "";
			    txtMaritalStatus.Text = "";
			    txtSuffix.Text = "";
			    txtGender.Text = "";
			    txtEmailAddress.Text = "";
			    txtYearlyIncome.Text = "";
			    txtTotalChildren.Text = "";
			    txtNumberChildrenAtHome.Text = "";
			    txtEnglishEducation.Text = "";
			    txtSpanishEducation.Text = "";
			    txtFrenchEducation.Text = "";
			    txtEnglishOccupation.Text = "";
			    txtSpanishOccupation.Text = "";
			    txtFrenchOccupation.Text = "";
			    txtHouseOwnerFlag.Text = "";
			    txtNumberCarsOwned.Text = "";
			    txtAddressLine1.Text = "";
			    txtAddressLine2.Text = "";
			    txtPhone.Text = "";
			    txtDateFirstPurchase.Text = "";
			    txtCommuteDistance.Text = "";
		    } else {
			    pnlForm.Visible = true;
			    pnlGrid.Visible = false;
			    pnlSave.Visible = true;
			    lblMode.InnerText = "Add new";
		    }
		    btnSave.CommandArgument = "Add";
		    Add();
        }

        public void grddbo_DimCustomer_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
        { 
		    if (e.Item.ItemType == ListItemType.Pager | e.Item.ItemType == ListItemType.Header)
			    return;

		    Button btn = (Button)e.CommandSource;
		    if (btn.Text == "Edit" | btn.Text == "Delete") {
			    Session.Remove("CustomerKey");
			    Session["CustomerKey"] = e.Item.Cells[0 + 0].Text;
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

        public void grddbo_DimCustomer_SortCommand(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
        {
		    htmlHiddenSortExpression.Value = e.SortExpression + " " + GetSortDirection(e.SortExpression);
		    LoadGriddbo_DimCustomer();
        }

        public void grddbo_DimCustomer_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
        {
		    grddbo_DimCustomer.CurrentPageIndex = e.NewPageIndex;
		    LoadGriddbo_DimCustomer();
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
		    Session.Remove("dvdbo_DimCustomer");
		    LoadGriddbo_DimCustomer();
        }

        public void butSearch_Click(object sender, System.EventArgs e)
        {
		    try {
                        Session.Remove("dvdbo_DimCustomer");
			if ((Session["dvdbo_DimCustomer"] != null)) {
				dvdbo_DimCustomer = (DataView)Session["dvdbo_DimCustomer"];
				// DataView was not found in the session.
		    	} else {
				dvdbo_DimCustomer = dbo_DimCustomerDataClass.Search(cmbFields.Text, cmbCondition.Text, txtSearch.Text).DefaultView;
			    	Session["dvdbo_DimCustomer"] = dvdbo_DimCustomer;
		    	}
                if (dvdbo_DimCustomer.Count > 0)
                {
                    dvdbo_DimCustomer.Sort = htmlHiddenSortExpression.Value;
                    grddbo_DimCustomer.DataSource = dvdbo_DimCustomer;
                    grddbo_DimCustomer.DataBind();
                }
                else
                {
                    grddbo_DimCustomer.DataSource = null;
                    grddbo_DimCustomer.DataBind();
                }
		    }
		    catch (Exception ex)
		    {
		    	ec.ShowMessage(ex.Message, " Dbo. Dim Customer ");
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
                    { dt = dbo_DimCustomerDataClass.Search(cmbFields.Text, cmbCondition.Text, txtSearch.Text); }
                    else { dt = dbo_DimCustomerDataClass.SelectAll(); }

                    PDFform pdfForm = new PDFform(dt, "Dbo. Dim Customer", "Many");
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
                    GVExport.DataSource = Session["dvdbo_DimCustomer"];
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
 
