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
    public partial class frmdbo_ProspectiveBuyer : System.Web.UI.Page
    {

        private dbo_ProspectiveBuyerDataClass clsdbo_ProspectiveBuyerData = new dbo_ProspectiveBuyerDataClass();
        private AdventureWorksDW2012DataClass clsAdventureWorksDW2012Data = new AdventureWorksDW2012DataClass();
        private DataView dvdbo_ProspectiveBuyer;

        protected void Page_Load(object sender, EventArgs e)
        {
		    if (!Page.IsPostBack) {
			    Session["Mode"] = "";
 			    Session["ProspectiveBuyerKey"] = "";

			    Session.Remove("dvdbo_ProspectiveBuyer");

                            cmbFields.Items.Add("Prospective Buyer Key");
                            cmbFields.Items.Add("Prospect Alternate Key");
                            cmbFields.Items.Add("First Name");
                            cmbFields.Items.Add("Middle Name");
                            cmbFields.Items.Add("Last Name");
                            cmbFields.Items.Add("Birth Date");
                            cmbFields.Items.Add("Marital Status");
                            cmbFields.Items.Add("Gender");
                            cmbFields.Items.Add("Email Address");
                            cmbFields.Items.Add("Yearly Income");
                            cmbFields.Items.Add("Total Children");
                            cmbFields.Items.Add("Number Children At Home");
                            cmbFields.Items.Add("Education");
                            cmbFields.Items.Add("Occupation");
                            cmbFields.Items.Add("House Owner Flag");
                            cmbFields.Items.Add("Number Cars Owned");
                            cmbFields.Items.Add("Address Line1");
                            cmbFields.Items.Add("Address Line2");
                            cmbFields.Items.Add("City");
                            cmbFields.Items.Add("State Province Code");
                            cmbFields.Items.Add("Postal Code");
                            cmbFields.Items.Add("Phone");
                            cmbFields.Items.Add("Salutation");
                            cmbFields.Items.Add("Unknown");

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


			    LoadGriddbo_ProspectiveBuyer();
		    }

        }


        private void LoadGriddbo_ProspectiveBuyer()
        {
		    try {
			if ((Session["dvdbo_ProspectiveBuyer"] != null)) {
				dvdbo_ProspectiveBuyer = (DataView)Session["dvdbo_ProspectiveBuyer"];
				// DataView was not found in the session.
		    	} else {
				dvdbo_ProspectiveBuyer = dbo_ProspectiveBuyerDataClass.SelectAll().DefaultView;
			    	Session["dvdbo_ProspectiveBuyer"] = dvdbo_ProspectiveBuyer;
		    	}
                if (dvdbo_ProspectiveBuyer.Count > 0)
                {
                    dvdbo_ProspectiveBuyer.Sort = htmlHiddenSortExpression.Value;
                    grddbo_ProspectiveBuyer.DataSource = dvdbo_ProspectiveBuyer;
                    grddbo_ProspectiveBuyer.DataBind();
                }
                else
                {
                    grddbo_ProspectiveBuyer.DataSource = null;
                    grddbo_ProspectiveBuyer.DataBind();
                }
		    }
		    catch (Exception ex)
		    {
		    	ec.ShowMessage(ex.Message, " Dbo. Prospective Buyer ");
		    }
        }

        private void Add()
        {
		    Session.Remove("Mode");
		    Session["Mode"] = "Add";

		    ClearRecord();

		    this.txtProspectAlternateKey.Enabled = true;
		    this.txtFirstName.Enabled = true;
		    this.txtMiddleName.Enabled = true;
		    this.txtLastName.Enabled = true;
		    this.txtBirthDate.Enabled = true;
		    this.txtMaritalStatus.Enabled = true;
		    this.txtGender.Enabled = true;
		    this.txtEmailAddress.Enabled = true;
		    this.txtYearlyIncome.Enabled = true;
		    this.txtTotalChildren.Enabled = true;
		    this.txtNumberChildrenAtHome.Enabled = true;
		    this.txtEducation.Enabled = true;
		    this.txtOccupation.Enabled = true;
		    this.txtHouseOwnerFlag.Enabled = true;
		    this.txtNumberCarsOwned.Enabled = true;
		    this.txtAddressLine1.Enabled = true;
		    this.txtAddressLine2.Enabled = true;
		    this.txtCity.Enabled = true;
		    this.txtStateProvinceCode.Enabled = true;
		    this.txtPostalCode.Enabled = true;
		    this.txtPhone.Enabled = true;
		    this.txtSalutation.Enabled = true;
		    this.txtUnknown.Enabled = true;
		    txtProspectiveBuyerKey.Enabled = false;
		    txtProspectAlternateKey.Focus();
		    txtProspectiveBuyerKey.Text = Convert.ToString(clsAdventureWorksDW2012Data.getAutoID("New", "ProspectiveBuyer"));
        }

        private void GetData()
        {
		    ClearRecord();

		    dbo_ProspectiveBuyerClass clsdbo_ProspectiveBuyer = new dbo_ProspectiveBuyerClass();
		    clsdbo_ProspectiveBuyer.ProspectiveBuyerKey = System.Convert.ToInt32(Session["ProspectiveBuyerKey"]);
		    clsdbo_ProspectiveBuyer = dbo_ProspectiveBuyerDataClass.Select_Record(clsdbo_ProspectiveBuyer);

		    if ((clsdbo_ProspectiveBuyer != null)) {
			    try {
                		txtProspectiveBuyerKey.Text = System.Convert.ToString(clsdbo_ProspectiveBuyer.ProspectiveBuyerKey);
                		if (clsdbo_ProspectiveBuyer.ProspectAlternateKey == null) { txtProspectAlternateKey.Text = default(string); } else { txtProspectAlternateKey.Text = System.Convert.ToString(clsdbo_ProspectiveBuyer.ProspectAlternateKey); }
                		if (clsdbo_ProspectiveBuyer.FirstName == null) { txtFirstName.Text = default(string); } else { txtFirstName.Text = System.Convert.ToString(clsdbo_ProspectiveBuyer.FirstName); }
                		if (clsdbo_ProspectiveBuyer.MiddleName == null) { txtMiddleName.Text = default(string); } else { txtMiddleName.Text = System.Convert.ToString(clsdbo_ProspectiveBuyer.MiddleName); }
                		if (clsdbo_ProspectiveBuyer.LastName == null) { txtLastName.Text = default(string); } else { txtLastName.Text = System.Convert.ToString(clsdbo_ProspectiveBuyer.LastName); }
                		if (clsdbo_ProspectiveBuyer.BirthDate == null) { txtBirthDate.Text = DateTime.Now.ToString(); } else { txtBirthDate.Text = System.Convert.ToDateTime(clsdbo_ProspectiveBuyer.BirthDate).ToShortDateString(); }
                		if (clsdbo_ProspectiveBuyer.MaritalStatus == null) { txtMaritalStatus.Text = default(string); } else { txtMaritalStatus.Text = System.Convert.ToString(clsdbo_ProspectiveBuyer.MaritalStatus); }
                		if (clsdbo_ProspectiveBuyer.Gender == null) { txtGender.Text = default(string); } else { txtGender.Text = System.Convert.ToString(clsdbo_ProspectiveBuyer.Gender); }
                		if (clsdbo_ProspectiveBuyer.EmailAddress == null) { txtEmailAddress.Text = default(string); } else { txtEmailAddress.Text = System.Convert.ToString(clsdbo_ProspectiveBuyer.EmailAddress); }
                		if (clsdbo_ProspectiveBuyer.YearlyIncome == null) { txtYearlyIncome.Text = default(string); } else { txtYearlyIncome.Text = System.Convert.ToString(clsdbo_ProspectiveBuyer.YearlyIncome); }
                		if (clsdbo_ProspectiveBuyer.TotalChildren == null) { txtTotalChildren.Text = default(string); } else { txtTotalChildren.Text = System.Convert.ToString(clsdbo_ProspectiveBuyer.TotalChildren); }
                		if (clsdbo_ProspectiveBuyer.NumberChildrenAtHome == null) { txtNumberChildrenAtHome.Text = default(string); } else { txtNumberChildrenAtHome.Text = System.Convert.ToString(clsdbo_ProspectiveBuyer.NumberChildrenAtHome); }
                		if (clsdbo_ProspectiveBuyer.Education == null) { txtEducation.Text = default(string); } else { txtEducation.Text = System.Convert.ToString(clsdbo_ProspectiveBuyer.Education); }
                		if (clsdbo_ProspectiveBuyer.Occupation == null) { txtOccupation.Text = default(string); } else { txtOccupation.Text = System.Convert.ToString(clsdbo_ProspectiveBuyer.Occupation); }
                		if (clsdbo_ProspectiveBuyer.HouseOwnerFlag == null) { txtHouseOwnerFlag.Text = default(string); } else { txtHouseOwnerFlag.Text = System.Convert.ToString(clsdbo_ProspectiveBuyer.HouseOwnerFlag); }
                		if (clsdbo_ProspectiveBuyer.NumberCarsOwned == null) { txtNumberCarsOwned.Text = default(string); } else { txtNumberCarsOwned.Text = System.Convert.ToString(clsdbo_ProspectiveBuyer.NumberCarsOwned); }
                		if (clsdbo_ProspectiveBuyer.AddressLine1 == null) { txtAddressLine1.Text = default(string); } else { txtAddressLine1.Text = System.Convert.ToString(clsdbo_ProspectiveBuyer.AddressLine1); }
                		if (clsdbo_ProspectiveBuyer.AddressLine2 == null) { txtAddressLine2.Text = default(string); } else { txtAddressLine2.Text = System.Convert.ToString(clsdbo_ProspectiveBuyer.AddressLine2); }
                		if (clsdbo_ProspectiveBuyer.City == null) { txtCity.Text = default(string); } else { txtCity.Text = System.Convert.ToString(clsdbo_ProspectiveBuyer.City); }
                		if (clsdbo_ProspectiveBuyer.StateProvinceCode == null) { txtStateProvinceCode.Text = default(string); } else { txtStateProvinceCode.Text = System.Convert.ToString(clsdbo_ProspectiveBuyer.StateProvinceCode); }
                		if (clsdbo_ProspectiveBuyer.PostalCode == null) { txtPostalCode.Text = default(string); } else { txtPostalCode.Text = System.Convert.ToString(clsdbo_ProspectiveBuyer.PostalCode); }
                		if (clsdbo_ProspectiveBuyer.Phone == null) { txtPhone.Text = default(string); } else { txtPhone.Text = System.Convert.ToString(clsdbo_ProspectiveBuyer.Phone); }
                		if (clsdbo_ProspectiveBuyer.Salutation == null) { txtSalutation.Text = default(string); } else { txtSalutation.Text = System.Convert.ToString(clsdbo_ProspectiveBuyer.Salutation); }
                		if (clsdbo_ProspectiveBuyer.Unknown == null) { txtUnknown.Text = default(string); } else { txtUnknown.Text = System.Convert.ToString(clsdbo_ProspectiveBuyer.Unknown); }
		   	 }
		    	catch (Exception ex)
		    	{
		    		ec.ShowMessage(ex.Message, " Dbo. Prospective Buyer ");
		    	}
		    }

        }

        private void Edit()
        {
		    Session.Remove("Mode");
		    Session["Mode"] = "Edit";

                    GetData();

		    txtProspectAlternateKey.Enabled = true;
		    txtFirstName.Enabled = true;
		    txtMiddleName.Enabled = true;
		    txtLastName.Enabled = true;
		    txtMaritalStatus.Enabled = true;
		    txtGender.Enabled = true;
		    txtEmailAddress.Enabled = true;
		    txtYearlyIncome.Enabled = true;
		    txtTotalChildren.Enabled = true;
		    txtNumberChildrenAtHome.Enabled = true;
		    txtEducation.Enabled = true;
		    txtOccupation.Enabled = true;
		    txtHouseOwnerFlag.Enabled = true;
		    txtNumberCarsOwned.Enabled = true;
		    txtAddressLine1.Enabled = true;
		    txtAddressLine2.Enabled = true;
		    txtCity.Enabled = true;
		    txtStateProvinceCode.Enabled = true;
		    txtPostalCode.Enabled = true;
		    txtPhone.Enabled = true;
		    txtSalutation.Enabled = true;
		    txtUnknown.Enabled = true;
		    txtProspectiveBuyerKey.Enabled = false;
		    txtProspectAlternateKey.Focus();
        }

        private void Delete()
        {
		    Session.Remove("Mode");
		    Session["Mode"] = "Delete";

                    GetData();

		    txtProspectiveBuyerKey.Enabled = false;
		    txtProspectAlternateKey.Enabled = false;
		    txtFirstName.Enabled = false;
		    txtMiddleName.Enabled = false;
		    txtLastName.Enabled = false;
		    txtBirthDate.Enabled = false;
		    txtMaritalStatus.Enabled = false;
		    txtGender.Enabled = false;
		    txtEmailAddress.Enabled = false;
		    txtYearlyIncome.Enabled = false;
		    txtTotalChildren.Enabled = false;
		    txtNumberChildrenAtHome.Enabled = false;
		    txtEducation.Enabled = false;
		    txtOccupation.Enabled = false;
		    txtHouseOwnerFlag.Enabled = false;
		    txtNumberCarsOwned.Enabled = false;
		    txtAddressLine1.Enabled = false;
		    txtAddressLine2.Enabled = false;
		    txtCity.Enabled = false;
		    txtStateProvinceCode.Enabled = false;
		    txtPostalCode.Enabled = false;
		    txtPhone.Enabled = false;
		    txtSalutation.Enabled = false;
		    txtUnknown.Enabled = false;
        }

        private void ClearRecord()
        {
	        txtProspectiveBuyerKey.Text = null;
	        txtProspectAlternateKey.Text = null;
	        txtFirstName.Text = null;
	        txtMiddleName.Text = null;
	        txtLastName.Text = null;
        	txtBirthDate.Text = null;
	        txtMaritalStatus.Text = null;
	        txtGender.Text = null;
	        txtEmailAddress.Text = null;
	        txtYearlyIncome.Text = null;
	        txtTotalChildren.Text = null;
	        txtNumberChildrenAtHome.Text = null;
	        txtEducation.Text = null;
	        txtOccupation.Text = null;
	        txtHouseOwnerFlag.Text = null;
	        txtNumberCarsOwned.Text = null;
	        txtAddressLine1.Text = null;
	        txtAddressLine2.Text = null;
	        txtCity.Text = null;
	        txtStateProvinceCode.Text = null;
	        txtPostalCode.Text = null;
	        txtPhone.Text = null;
	        txtSalutation.Text = null;
	        txtUnknown.Text = null;
        }

        public void btnSave_Click(object sender, System.EventArgs e)
        {
		    if ((String)Session["Mode"] == "Add") {
			    this.InsertRecord();
		    } else if ((String)Session["Mode"] == "Edit") {
			    this.UpdateRecord();
		    }
        }

        private void SetData(dbo_ProspectiveBuyerClass clsdbo_ProspectiveBuyer)
        {
			    if (string.IsNullOrEmpty(txtProspectAlternateKey.Text)) {
			    	clsdbo_ProspectiveBuyer.ProspectAlternateKey = null;
			    } else {
			    	clsdbo_ProspectiveBuyer.ProspectAlternateKey = txtProspectAlternateKey.Text; }
			    if (string.IsNullOrEmpty(txtFirstName.Text)) {
			    	clsdbo_ProspectiveBuyer.FirstName = null;
			    } else {
			    	clsdbo_ProspectiveBuyer.FirstName = txtFirstName.Text; }
			    if (string.IsNullOrEmpty(txtMiddleName.Text)) {
			    	clsdbo_ProspectiveBuyer.MiddleName = null;
			    } else {
			    	clsdbo_ProspectiveBuyer.MiddleName = txtMiddleName.Text; }
			    if (string.IsNullOrEmpty(txtLastName.Text)) {
			    	clsdbo_ProspectiveBuyer.LastName = null;
			    } else {
			    	clsdbo_ProspectiveBuyer.LastName = txtLastName.Text; }
			    if (string.IsNullOrEmpty(txtBirthDate.Text)) {
			    	clsdbo_ProspectiveBuyer.BirthDate = null;
			    } else {
			    	clsdbo_ProspectiveBuyer.BirthDate = System.Convert.ToDateTime(txtBirthDate.Text); }
			    if (string.IsNullOrEmpty(txtMaritalStatus.Text)) {
			    	clsdbo_ProspectiveBuyer.MaritalStatus = null;
			    } else {
			    	clsdbo_ProspectiveBuyer.MaritalStatus = txtMaritalStatus.Text; }
			    if (string.IsNullOrEmpty(txtGender.Text)) {
			    	clsdbo_ProspectiveBuyer.Gender = null;
			    } else {
			    	clsdbo_ProspectiveBuyer.Gender = txtGender.Text; }
			    if (string.IsNullOrEmpty(txtEmailAddress.Text)) {
			    	clsdbo_ProspectiveBuyer.EmailAddress = null;
			    } else {
			    	clsdbo_ProspectiveBuyer.EmailAddress = txtEmailAddress.Text; }
			    if (string.IsNullOrEmpty(txtYearlyIncome.Text)) {
			    	clsdbo_ProspectiveBuyer.YearlyIncome = null;
			    } else {
			    	clsdbo_ProspectiveBuyer.YearlyIncome = System.Convert.ToDecimal(txtYearlyIncome.Text); }
			    if (string.IsNullOrEmpty(txtTotalChildren.Text)) {
			    	clsdbo_ProspectiveBuyer.TotalChildren = null;
			    } else {
			    	clsdbo_ProspectiveBuyer.TotalChildren = System.Convert.ToByte(txtTotalChildren.Text); }
			    if (string.IsNullOrEmpty(txtNumberChildrenAtHome.Text)) {
			    	clsdbo_ProspectiveBuyer.NumberChildrenAtHome = null;
			    } else {
			    	clsdbo_ProspectiveBuyer.NumberChildrenAtHome = System.Convert.ToByte(txtNumberChildrenAtHome.Text); }
			    if (string.IsNullOrEmpty(txtEducation.Text)) {
			    	clsdbo_ProspectiveBuyer.Education = null;
			    } else {
			    	clsdbo_ProspectiveBuyer.Education = txtEducation.Text; }
			    if (string.IsNullOrEmpty(txtOccupation.Text)) {
			    	clsdbo_ProspectiveBuyer.Occupation = null;
			    } else {
			    	clsdbo_ProspectiveBuyer.Occupation = txtOccupation.Text; }
			    if (string.IsNullOrEmpty(txtHouseOwnerFlag.Text)) {
			    	clsdbo_ProspectiveBuyer.HouseOwnerFlag = null;
			    } else {
			    	clsdbo_ProspectiveBuyer.HouseOwnerFlag = txtHouseOwnerFlag.Text; }
			    if (string.IsNullOrEmpty(txtNumberCarsOwned.Text)) {
			    	clsdbo_ProspectiveBuyer.NumberCarsOwned = null;
			    } else {
			    	clsdbo_ProspectiveBuyer.NumberCarsOwned = System.Convert.ToByte(txtNumberCarsOwned.Text); }
			    if (string.IsNullOrEmpty(txtAddressLine1.Text)) {
			    	clsdbo_ProspectiveBuyer.AddressLine1 = null;
			    } else {
			    	clsdbo_ProspectiveBuyer.AddressLine1 = txtAddressLine1.Text; }
			    if (string.IsNullOrEmpty(txtAddressLine2.Text)) {
			    	clsdbo_ProspectiveBuyer.AddressLine2 = null;
			    } else {
			    	clsdbo_ProspectiveBuyer.AddressLine2 = txtAddressLine2.Text; }
			    if (string.IsNullOrEmpty(txtCity.Text)) {
			    	clsdbo_ProspectiveBuyer.City = null;
			    } else {
			    	clsdbo_ProspectiveBuyer.City = txtCity.Text; }
			    if (string.IsNullOrEmpty(txtStateProvinceCode.Text)) {
			    	clsdbo_ProspectiveBuyer.StateProvinceCode = null;
			    } else {
			    	clsdbo_ProspectiveBuyer.StateProvinceCode = txtStateProvinceCode.Text; }
			    if (string.IsNullOrEmpty(txtPostalCode.Text)) {
			    	clsdbo_ProspectiveBuyer.PostalCode = null;
			    } else {
			    	clsdbo_ProspectiveBuyer.PostalCode = txtPostalCode.Text; }
			    if (string.IsNullOrEmpty(txtPhone.Text)) {
			    	clsdbo_ProspectiveBuyer.Phone = null;
			    } else {
			    	clsdbo_ProspectiveBuyer.Phone = txtPhone.Text; }
			    if (string.IsNullOrEmpty(txtSalutation.Text)) {
			    	clsdbo_ProspectiveBuyer.Salutation = null;
			    } else {
			    	clsdbo_ProspectiveBuyer.Salutation = txtSalutation.Text; }
			    if (string.IsNullOrEmpty(txtUnknown.Text)) {
			    	clsdbo_ProspectiveBuyer.Unknown = null;
			    } else {
			    	clsdbo_ProspectiveBuyer.Unknown = System.Convert.ToInt32(txtUnknown.Text); }
        }

        private void InsertRecord()
        {
		    dbo_ProspectiveBuyerClass clsdbo_ProspectiveBuyer = new dbo_ProspectiveBuyerClass();
		    if (VerifyData() == true) {
                            SetData(clsdbo_ProspectiveBuyer);
			    bool bSucess = false;
			    bSucess = dbo_ProspectiveBuyerDataClass.Add(clsdbo_ProspectiveBuyer);
			    if (bSucess == true) {
				    pnlForm.Visible = false;
				    pnlSave.Visible = false;
				    pnlGrid.Visible = true;
				    lblMode.InnerText = "";
				    Session.Remove("dvdbo_ProspectiveBuyer");
				    LoadGriddbo_ProspectiveBuyer();
			    } else {
				    ec.ShowMessage(" Insert failed. ", " Dbo. Prospective Buyer ");
			    }
		    }
        }

        private void UpdateRecord()
        {
		    dbo_ProspectiveBuyerClass oclsdbo_ProspectiveBuyer = new dbo_ProspectiveBuyerClass();
		    dbo_ProspectiveBuyerClass clsdbo_ProspectiveBuyer = new dbo_ProspectiveBuyerClass();

		    oclsdbo_ProspectiveBuyer.ProspectiveBuyerKey = System.Convert.ToInt32(Session["ProspectiveBuyerKey"]);
		    oclsdbo_ProspectiveBuyer = dbo_ProspectiveBuyerDataClass.Select_Record(oclsdbo_ProspectiveBuyer);

		    if (VerifyData() == true) {
                            SetData(clsdbo_ProspectiveBuyer);
			    bool bSucess = false;
			    bSucess = dbo_ProspectiveBuyerDataClass.Update(oclsdbo_ProspectiveBuyer, clsdbo_ProspectiveBuyer);
			    if (bSucess == true) {
				    pnlForm.Visible = false;
				    pnlSave.Visible = false;
				    pnlGrid.Visible = true;
				    lblMode.InnerText = "";
				    Session.Remove("dvdbo_ProspectiveBuyer");
				    LoadGriddbo_ProspectiveBuyer();
			    } else {
				    ec.ShowMessage(" Update failed. ", " Dbo. Prospective Buyer ");
			    }
		    }
        }

        private void DeleteRecord()
        {
		    dbo_ProspectiveBuyerClass clsdbo_ProspectiveBuyer = new dbo_ProspectiveBuyerClass();
		    clsdbo_ProspectiveBuyer.ProspectiveBuyerKey = System.Convert.ToInt32(Session["ProspectiveBuyerKey"]);
                    SetData(clsdbo_ProspectiveBuyer);
		    bool bSucess = false;
		    bSucess = dbo_ProspectiveBuyerDataClass.Delete(clsdbo_ProspectiveBuyer);
		    if (bSucess == true) {
			    pnlForm.Visible = false;
			    pnlSave.Visible = false;
			    pnlGrid.Visible = true;
			    pnlDelete.Visible = false;
			    lblMode.InnerText = "";
			    Session.Remove("dvdbo_ProspectiveBuyer");
			    LoadGriddbo_ProspectiveBuyer();
		    } else {
			    ec.ShowMessage(" Delete failed. ", " Dbo. Prospective Buyer ");
		    }
        }

        private Boolean VerifyData()
        {
		    return true;
        }

        public void butRecords_Click(object sender, System.EventArgs e)
        {
		    grddbo_ProspectiveBuyer.CurrentPageIndex = 0;
		    grddbo_ProspectiveBuyer.PageSize = Convert.ToInt32(cmbRecords.Text);
		    LoadGriddbo_ProspectiveBuyer();
        }

        public void btnAddNew_Click(object sender, System.EventArgs e)
        {
		    if (pnlForm.Visible) {
			    txtProspectiveBuyerKey.Text = "";
			    txtProspectAlternateKey.Text = "";
			    txtFirstName.Text = "";
			    txtMiddleName.Text = "";
			    txtLastName.Text = "";
			    txtBirthDate.Text = "";
			    txtMaritalStatus.Text = "";
			    txtGender.Text = "";
			    txtEmailAddress.Text = "";
			    txtYearlyIncome.Text = "";
			    txtTotalChildren.Text = "";
			    txtNumberChildrenAtHome.Text = "";
			    txtEducation.Text = "";
			    txtOccupation.Text = "";
			    txtHouseOwnerFlag.Text = "";
			    txtNumberCarsOwned.Text = "";
			    txtAddressLine1.Text = "";
			    txtAddressLine2.Text = "";
			    txtCity.Text = "";
			    txtStateProvinceCode.Text = "";
			    txtPostalCode.Text = "";
			    txtPhone.Text = "";
			    txtSalutation.Text = "";
			    txtUnknown.Text = "";
		    } else {
			    pnlForm.Visible = true;
			    pnlGrid.Visible = false;
			    pnlSave.Visible = true;
			    lblMode.InnerText = "Add new";
		    }
		    btnSave.CommandArgument = "Add";
		    Add();
        }

        public void grddbo_ProspectiveBuyer_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
        { 
		    if (e.Item.ItemType == ListItemType.Pager | e.Item.ItemType == ListItemType.Header)
			    return;

		    Button btn = (Button)e.CommandSource;
		    if (btn.Text == "Edit" | btn.Text == "Delete") {
			    Session.Remove("ProspectiveBuyerKey");
			    Session["ProspectiveBuyerKey"] = e.Item.Cells[0 + 0].Text;
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

        public void grddbo_ProspectiveBuyer_SortCommand(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
        {
		    htmlHiddenSortExpression.Value = e.SortExpression + " " + GetSortDirection(e.SortExpression);
		    LoadGriddbo_ProspectiveBuyer();
        }

        public void grddbo_ProspectiveBuyer_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
        {
		    grddbo_ProspectiveBuyer.CurrentPageIndex = e.NewPageIndex;
		    LoadGriddbo_ProspectiveBuyer();
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
		    Session.Remove("dvdbo_ProspectiveBuyer");
		    LoadGriddbo_ProspectiveBuyer();
        }

        public void butSearch_Click(object sender, System.EventArgs e)
        {
		    try {
                        Session.Remove("dvdbo_ProspectiveBuyer");
			if ((Session["dvdbo_ProspectiveBuyer"] != null)) {
				dvdbo_ProspectiveBuyer = (DataView)Session["dvdbo_ProspectiveBuyer"];
				// DataView was not found in the session.
		    	} else {
				dvdbo_ProspectiveBuyer = dbo_ProspectiveBuyerDataClass.Search(cmbFields.Text, cmbCondition.Text, txtSearch.Text).DefaultView;
			    	Session["dvdbo_ProspectiveBuyer"] = dvdbo_ProspectiveBuyer;
		    	}
                if (dvdbo_ProspectiveBuyer.Count > 0)
                {
                    dvdbo_ProspectiveBuyer.Sort = htmlHiddenSortExpression.Value;
                    grddbo_ProspectiveBuyer.DataSource = dvdbo_ProspectiveBuyer;
                    grddbo_ProspectiveBuyer.DataBind();
                }
                else
                {
                    grddbo_ProspectiveBuyer.DataSource = null;
                    grddbo_ProspectiveBuyer.DataBind();
                }
		    }
		    catch (Exception ex)
		    {
		    	ec.ShowMessage(ex.Message, " Dbo. Prospective Buyer ");
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
                    { dt = dbo_ProspectiveBuyerDataClass.Search(cmbFields.Text, cmbCondition.Text, txtSearch.Text); }
                    else { dt = dbo_ProspectiveBuyerDataClass.SelectAll(); }

                    PDFform pdfForm = new PDFform(dt, "Dbo. Prospective Buyer", "Many");
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
                    GVExport.DataSource = Session["dvdbo_ProspectiveBuyer"];
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
 
