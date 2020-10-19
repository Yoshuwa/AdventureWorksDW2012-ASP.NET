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
    public partial class frmdbo_DimEmployee : System.Web.UI.Page
    {

        private dbo_DimEmployeeDataClass clsdbo_DimEmployeeData = new dbo_DimEmployeeDataClass();
        private AdventureWorksDW2012DataClass clsAdventureWorksDW2012Data = new AdventureWorksDW2012DataClass();
        private DataView dvdbo_DimEmployee;

        protected void Page_Load(object sender, EventArgs e)
        {
		    if (!Page.IsPostBack) {
			    Session["Mode"] = "";
 			    Session["EmployeeKey"] = "";

			    Session.Remove("dvdbo_DimEmployee");

                            cmbFields.Items.Add("Employee Key");
                            cmbFields.Items.Add("Parent Employee Key");
                            cmbFields.Items.Add("Employee National I D Alternate Key");
                            cmbFields.Items.Add("Parent Employee National I D Alternate Key");
                            cmbFields.Items.Add("Sales Territory Key");
                            cmbFields.Items.Add("First Name");
                            cmbFields.Items.Add("Last Name");
                            cmbFields.Items.Add("Middle Name");
                            cmbFields.Items.Add("Name Style");
                            cmbFields.Items.Add("Title");
                            cmbFields.Items.Add("Hire Date");
                            cmbFields.Items.Add("Birth Date");
                            cmbFields.Items.Add("Login I D");
                            cmbFields.Items.Add("Email Address");
                            cmbFields.Items.Add("Phone");
                            cmbFields.Items.Add("Marital Status");
                            cmbFields.Items.Add("Emergency Contact Name");
                            cmbFields.Items.Add("Emergency Contact Phone");
                            cmbFields.Items.Add("Salaried Flag");
                            cmbFields.Items.Add("Gender");
                            cmbFields.Items.Add("Pay Frequency");
                            cmbFields.Items.Add("Base Rate");
                            cmbFields.Items.Add("Vacation Hours");
                            cmbFields.Items.Add("Sick Leave Hours");
                            cmbFields.Items.Add("Current Flag");
                            cmbFields.Items.Add("Sales Person Flag");
                            cmbFields.Items.Add("Department Name");
                            cmbFields.Items.Add("Start Date");
                            cmbFields.Items.Add("End Date");
                            cmbFields.Items.Add("Status");

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

            Loaddbo_DimEmployee_dbo_DimEmployeeComboBox68();
            Loaddbo_DimEmployee_dbo_DimSalesTerritoryComboBox71();

			    LoadGriddbo_DimEmployee();
		    }

        }


	    private void Loaddbo_DimEmployee_dbo_DimEmployeeComboBox68()
	    {
		    List<dbo_DimEmployee_dbo_DimEmployeeClass68> dbo_DimEmployee_dbo_DimEmployeeList = new  List<dbo_DimEmployee_dbo_DimEmployeeClass68>();
		    try {
			    dbo_DimEmployee_dbo_DimEmployeeList = dbo_DimEmployee_dbo_DimEmployeeDataClass68.List();
			    txtParentEmployeeKey.DataSource = dbo_DimEmployee_dbo_DimEmployeeList;
			    txtParentEmployeeKey.DataValueField = "ParentEmployeeKey";
			    txtParentEmployeeKey.DataTextField = "FirstName";
			    txtParentEmployeeKey.DataBind();
		    }
		    catch (Exception ex)
		    {
		    	ec.ShowMessage(ex.Message, " Dbo. Dim Employee ");
		    }
	    }

	    private void Loaddbo_DimEmployee_dbo_DimSalesTerritoryComboBox71()
	    {
		    List<dbo_DimEmployee_dbo_DimSalesTerritoryClass71> dbo_DimEmployee_dbo_DimSalesTerritoryList = new  List<dbo_DimEmployee_dbo_DimSalesTerritoryClass71>();
		    try {
			    dbo_DimEmployee_dbo_DimSalesTerritoryList = dbo_DimEmployee_dbo_DimSalesTerritoryDataClass71.List();
			    txtSalesTerritoryKey.DataSource = dbo_DimEmployee_dbo_DimSalesTerritoryList;
			    txtSalesTerritoryKey.DataValueField = "SalesTerritoryAlternateKey";
			    txtSalesTerritoryKey.DataTextField = "SalesTerritoryAlternateKey";
			    txtSalesTerritoryKey.DataBind();
		    }
		    catch (Exception ex)
		    {
		    	ec.ShowMessage(ex.Message, " Dbo. Dim Employee ");
		    }
	    }

        private void LoadGriddbo_DimEmployee()
        {
		    try {
			if ((Session["dvdbo_DimEmployee"] != null)) {
				dvdbo_DimEmployee = (DataView)Session["dvdbo_DimEmployee"];
				// DataView was not found in the session.
		    	} else {
				dvdbo_DimEmployee = dbo_DimEmployeeDataClass.SelectAll().DefaultView;
			    	Session["dvdbo_DimEmployee"] = dvdbo_DimEmployee;
		    	}
                if (dvdbo_DimEmployee.Count > 0)
                {
                    dvdbo_DimEmployee.Sort = htmlHiddenSortExpression.Value;
                    grddbo_DimEmployee.DataSource = dvdbo_DimEmployee;
                    grddbo_DimEmployee.DataBind();
                }
                else
                {
                    grddbo_DimEmployee.DataSource = null;
                    grddbo_DimEmployee.DataBind();
                }
		    }
		    catch (Exception ex)
		    {
		    	ec.ShowMessage(ex.Message, " Dbo. Dim Employee ");
		    }
        }

        private void Add()
        {
		    Session.Remove("Mode");
		    Session["Mode"] = "Add";

		    ClearRecord();

		    this.txtParentEmployeeKey.Enabled = true;
		    this.txtEmployeeNationalIDAlternateKey.Enabled = true;
		    this.txtParentEmployeeNationalIDAlternateKey.Enabled = true;
		    this.txtSalesTerritoryKey.Enabled = true;
		    this.txtFirstName.Enabled = true;
		    this.txtLastName.Enabled = true;
		    this.txtMiddleName.Enabled = true;
		    this.txtNameStyle.Enabled = true;
		    this.txtTitle.Enabled = true;
		    this.txtHireDate.Enabled = true;
		    this.txtBirthDate.Enabled = true;
		    this.txtLoginID.Enabled = true;
		    this.txtEmailAddress.Enabled = true;
		    this.txtPhone.Enabled = true;
		    this.txtMaritalStatus.Enabled = true;
		    this.txtEmergencyContactName.Enabled = true;
		    this.txtEmergencyContactPhone.Enabled = true;
		    this.txtSalariedFlag.Enabled = true;
		    this.txtGender.Enabled = true;
		    this.txtPayFrequency.Enabled = true;
		    this.txtBaseRate.Enabled = true;
		    this.txtVacationHours.Enabled = true;
		    this.txtSickLeaveHours.Enabled = true;
		    this.txtCurrentFlag.Enabled = true;
		    this.txtSalesPersonFlag.Enabled = true;
		    this.txtDepartmentName.Enabled = true;
		    this.txtStartDate.Enabled = true;
		    this.txtEndDate.Enabled = true;
		    this.txtStatus.Enabled = true;
		    txtEmployeeKey.Enabled = false;
		    txtParentEmployeeKey.Focus();
		    txtEmployeeKey.Text = Convert.ToString(clsAdventureWorksDW2012Data.getAutoID("New", "DimEmployee"));
        }

        private void GetData()
        {
		    ClearRecord();

		    dbo_DimEmployeeClass clsdbo_DimEmployee = new dbo_DimEmployeeClass();
		    clsdbo_DimEmployee.EmployeeKey = System.Convert.ToInt32(Session["EmployeeKey"]);
		    clsdbo_DimEmployee = dbo_DimEmployeeDataClass.Select_Record(clsdbo_DimEmployee);

		    if ((clsdbo_DimEmployee != null)) {
			    try {
                		txtEmployeeKey.Text = System.Convert.ToString(clsdbo_DimEmployee.EmployeeKey);
                		if (clsdbo_DimEmployee.ParentEmployeeKey == null) { txtParentEmployeeKey.SelectedValue = default(string); } else { txtParentEmployeeKey.SelectedValue = System.Convert.ToString(clsdbo_DimEmployee.ParentEmployeeKey); }
                		if (clsdbo_DimEmployee.EmployeeNationalIDAlternateKey == null) { txtEmployeeNationalIDAlternateKey.Text = default(string); } else { txtEmployeeNationalIDAlternateKey.Text = System.Convert.ToString(clsdbo_DimEmployee.EmployeeNationalIDAlternateKey); }
                		if (clsdbo_DimEmployee.ParentEmployeeNationalIDAlternateKey == null) { txtParentEmployeeNationalIDAlternateKey.Text = default(string); } else { txtParentEmployeeNationalIDAlternateKey.Text = System.Convert.ToString(clsdbo_DimEmployee.ParentEmployeeNationalIDAlternateKey); }
                		if (clsdbo_DimEmployee.SalesTerritoryKey == null) { txtSalesTerritoryKey.SelectedValue = default(string); } else { txtSalesTerritoryKey.SelectedValue = System.Convert.ToString(clsdbo_DimEmployee.SalesTerritoryKey); }
                		txtFirstName.Text = System.Convert.ToString(clsdbo_DimEmployee.FirstName);
                		txtLastName.Text = System.Convert.ToString(clsdbo_DimEmployee.LastName);
                		if (clsdbo_DimEmployee.MiddleName == null) { txtMiddleName.Text = default(string); } else { txtMiddleName.Text = System.Convert.ToString(clsdbo_DimEmployee.MiddleName); }
                		txtNameStyle.Checked = System.Convert.ToBoolean(clsdbo_DimEmployee.NameStyle);
                		if (clsdbo_DimEmployee.Title == null) { txtTitle.Text = default(string); } else { txtTitle.Text = System.Convert.ToString(clsdbo_DimEmployee.Title); }
                		if (clsdbo_DimEmployee.HireDate == null) { txtHireDate.Text = DateTime.Now.ToString(); } else { txtHireDate.Text = System.Convert.ToDateTime(clsdbo_DimEmployee.HireDate).ToShortDateString(); }
                		if (clsdbo_DimEmployee.BirthDate == null) { txtBirthDate.Text = DateTime.Now.ToString(); } else { txtBirthDate.Text = System.Convert.ToDateTime(clsdbo_DimEmployee.BirthDate).ToShortDateString(); }
                		if (clsdbo_DimEmployee.LoginID == null) { txtLoginID.Text = default(string); } else { txtLoginID.Text = System.Convert.ToString(clsdbo_DimEmployee.LoginID); }
                		if (clsdbo_DimEmployee.EmailAddress == null) { txtEmailAddress.Text = default(string); } else { txtEmailAddress.Text = System.Convert.ToString(clsdbo_DimEmployee.EmailAddress); }
                		if (clsdbo_DimEmployee.Phone == null) { txtPhone.Text = default(string); } else { txtPhone.Text = System.Convert.ToString(clsdbo_DimEmployee.Phone); }
                		if (clsdbo_DimEmployee.MaritalStatus == null) { txtMaritalStatus.Text = default(string); } else { txtMaritalStatus.Text = System.Convert.ToString(clsdbo_DimEmployee.MaritalStatus); }
                		if (clsdbo_DimEmployee.EmergencyContactName == null) { txtEmergencyContactName.Text = default(string); } else { txtEmergencyContactName.Text = System.Convert.ToString(clsdbo_DimEmployee.EmergencyContactName); }
                		if (clsdbo_DimEmployee.EmergencyContactPhone == null) { txtEmergencyContactPhone.Text = default(string); } else { txtEmergencyContactPhone.Text = System.Convert.ToString(clsdbo_DimEmployee.EmergencyContactPhone); }
                		//if (clsdbo_DimEmployee.SalariedFlag == null) { txtSalariedFlag.Checked = default(string); } else { txtSalariedFlag.Checked = System.Convert.ToBoolean(clsdbo_DimEmployee.SalariedFlag); }
                		if (clsdbo_DimEmployee.Gender == null) { txtGender.Text = default(string); } else { txtGender.Text = System.Convert.ToString(clsdbo_DimEmployee.Gender); }
                		if (clsdbo_DimEmployee.PayFrequency == null) { txtPayFrequency.Text = default(string); } else { txtPayFrequency.Text = System.Convert.ToString(clsdbo_DimEmployee.PayFrequency); }
                		if (clsdbo_DimEmployee.BaseRate == null) { txtBaseRate.Text = default(string); } else { txtBaseRate.Text = System.Convert.ToString(clsdbo_DimEmployee.BaseRate); }
                		if (clsdbo_DimEmployee.VacationHours == null) { txtVacationHours.Text = default(string); } else { txtVacationHours.Text = System.Convert.ToString(clsdbo_DimEmployee.VacationHours); }
                		if (clsdbo_DimEmployee.SickLeaveHours == null) { txtSickLeaveHours.Text = default(string); } else { txtSickLeaveHours.Text = System.Convert.ToString(clsdbo_DimEmployee.SickLeaveHours); }
                		txtCurrentFlag.Checked = System.Convert.ToBoolean(clsdbo_DimEmployee.CurrentFlag);
                		txtSalesPersonFlag.Checked = System.Convert.ToBoolean(clsdbo_DimEmployee.SalesPersonFlag);
                		if (clsdbo_DimEmployee.DepartmentName == null) { txtDepartmentName.Text = default(string); } else { txtDepartmentName.Text = System.Convert.ToString(clsdbo_DimEmployee.DepartmentName); }
                		if (clsdbo_DimEmployee.StartDate == null) { txtStartDate.Text = DateTime.Now.ToString(); } else { txtStartDate.Text = System.Convert.ToDateTime(clsdbo_DimEmployee.StartDate).ToShortDateString(); }
                		if (clsdbo_DimEmployee.EndDate == null) { txtEndDate.Text = DateTime.Now.ToString(); } else { txtEndDate.Text = System.Convert.ToDateTime(clsdbo_DimEmployee.EndDate).ToShortDateString(); }
                		if (clsdbo_DimEmployee.Status == null) { txtStatus.Text = default(string); } else { txtStatus.Text = System.Convert.ToString(clsdbo_DimEmployee.Status); }
		   	 }
		    	catch (Exception ex)
		    	{
		    		ec.ShowMessage(ex.Message, " Dbo. Dim Employee ");
		    	}
		    }

        }

        private void Edit()
        {
		    Session.Remove("Mode");
		    Session["Mode"] = "Edit";

                    GetData();

		    txtParentEmployeeKey.Enabled = true;
		    txtEmployeeNationalIDAlternateKey.Enabled = true;
		    txtParentEmployeeNationalIDAlternateKey.Enabled = true;
		    txtSalesTerritoryKey.Enabled = true;
		    txtFirstName.Enabled = true;
		    txtLastName.Enabled = true;
		    txtMiddleName.Enabled = true;
		    txtTitle.Enabled = true;
		    txtLoginID.Enabled = true;
		    txtEmailAddress.Enabled = true;
		    txtPhone.Enabled = true;
		    txtMaritalStatus.Enabled = true;
		    txtEmergencyContactName.Enabled = true;
		    txtEmergencyContactPhone.Enabled = true;
		    txtGender.Enabled = true;
		    txtPayFrequency.Enabled = true;
		    txtBaseRate.Enabled = true;
		    txtVacationHours.Enabled = true;
		    txtSickLeaveHours.Enabled = true;
		    txtDepartmentName.Enabled = true;
		    txtStatus.Enabled = true;
		    txtEmployeeKey.Enabled = false;
		    txtParentEmployeeKey.Focus();
        }

        private void Delete()
        {
		    Session.Remove("Mode");
		    Session["Mode"] = "Delete";

                    GetData();

		    txtEmployeeKey.Enabled = false;
		    txtParentEmployeeKey.Enabled = false;
		    txtEmployeeNationalIDAlternateKey.Enabled = false;
		    txtParentEmployeeNationalIDAlternateKey.Enabled = false;
		    txtSalesTerritoryKey.Enabled = false;
		    txtFirstName.Enabled = false;
		    txtLastName.Enabled = false;
		    txtMiddleName.Enabled = false;
		    txtNameStyle.Enabled = false;
		    txtTitle.Enabled = false;
		    txtHireDate.Enabled = false;
		    txtBirthDate.Enabled = false;
		    txtLoginID.Enabled = false;
		    txtEmailAddress.Enabled = false;
		    txtPhone.Enabled = false;
		    txtMaritalStatus.Enabled = false;
		    txtEmergencyContactName.Enabled = false;
		    txtEmergencyContactPhone.Enabled = false;
		    txtSalariedFlag.Enabled = false;
		    txtGender.Enabled = false;
		    txtPayFrequency.Enabled = false;
		    txtBaseRate.Enabled = false;
		    txtVacationHours.Enabled = false;
		    txtSickLeaveHours.Enabled = false;
		    txtCurrentFlag.Enabled = false;
		    txtSalesPersonFlag.Enabled = false;
		    txtDepartmentName.Enabled = false;
		    txtStartDate.Enabled = false;
		    txtEndDate.Enabled = false;
		    txtStatus.Enabled = false;
        }

        private void ClearRecord()
        {
	        txtEmployeeKey.Text = null;
	        txtParentEmployeeKey.SelectedIndex = -1;
	        txtEmployeeNationalIDAlternateKey.Text = null;
	        txtParentEmployeeNationalIDAlternateKey.Text = null;
	        txtSalesTerritoryKey.SelectedIndex = -1;
	        txtFirstName.Text = null;
	        txtLastName.Text = null;
	        txtMiddleName.Text = null;
        	txtNameStyle.Text = null;
	        txtTitle.Text = null;
        	txtHireDate.Text = null;
        	txtBirthDate.Text = null;
	        txtLoginID.Text = null;
	        txtEmailAddress.Text = null;
	        txtPhone.Text = null;
	        txtMaritalStatus.Text = null;
	        txtEmergencyContactName.Text = null;
	        txtEmergencyContactPhone.Text = null;
        	txtSalariedFlag.Text = null;
	        txtGender.Text = null;
	        txtPayFrequency.Text = null;
	        txtBaseRate.Text = null;
	        txtVacationHours.Text = null;
	        txtSickLeaveHours.Text = null;
        	txtCurrentFlag.Text = null;
        	txtSalesPersonFlag.Text = null;
	        txtDepartmentName.Text = null;
        	txtStartDate.Text = null;
        	txtEndDate.Text = null;
	        txtStatus.Text = null;
        }

        public void btnSave_Click(object sender, System.EventArgs e)
        {
		    if ((String)Session["Mode"] == "Add") {
			    this.InsertRecord();
		    } else if ((String)Session["Mode"] == "Edit") {
			    this.UpdateRecord();
		    }
        }

        private void SetData(dbo_DimEmployeeClass clsdbo_DimEmployee)
        {
			    if (string.IsNullOrEmpty(txtParentEmployeeKey.SelectedValue)) {
			    	clsdbo_DimEmployee.ParentEmployeeKey = null;
			    } else {
			    	clsdbo_DimEmployee.ParentEmployeeKey = System.Convert.ToInt32(txtParentEmployeeKey.SelectedValue); }
			    if (string.IsNullOrEmpty(txtEmployeeNationalIDAlternateKey.Text)) {
			    	clsdbo_DimEmployee.EmployeeNationalIDAlternateKey = null;
			    } else {
			    	clsdbo_DimEmployee.EmployeeNationalIDAlternateKey = txtEmployeeNationalIDAlternateKey.Text; }
			    if (string.IsNullOrEmpty(txtParentEmployeeNationalIDAlternateKey.Text)) {
			    	clsdbo_DimEmployee.ParentEmployeeNationalIDAlternateKey = null;
			    } else {
			    	clsdbo_DimEmployee.ParentEmployeeNationalIDAlternateKey = txtParentEmployeeNationalIDAlternateKey.Text; }
			    if (string.IsNullOrEmpty(txtSalesTerritoryKey.SelectedValue)) {
			    	clsdbo_DimEmployee.SalesTerritoryKey = null;
			    } else {
			    	clsdbo_DimEmployee.SalesTerritoryKey = System.Convert.ToInt32(txtSalesTerritoryKey.SelectedValue); }
			    clsdbo_DimEmployee.FirstName = System.Convert.ToString(txtFirstName.Text);
			    clsdbo_DimEmployee.LastName = System.Convert.ToString(txtLastName.Text);
			    if (string.IsNullOrEmpty(txtMiddleName.Text)) {
			    	clsdbo_DimEmployee.MiddleName = null;
			    } else {
			    	clsdbo_DimEmployee.MiddleName = txtMiddleName.Text; }
			    clsdbo_DimEmployee.NameStyle = System.Convert.ToBoolean(txtNameStyle.Checked ? true : false);
			    if (string.IsNullOrEmpty(txtTitle.Text)) {
			    	clsdbo_DimEmployee.Title = null;
			    } else {
			    	clsdbo_DimEmployee.Title = txtTitle.Text; }
			    if (string.IsNullOrEmpty(txtHireDate.Text)) {
			    	clsdbo_DimEmployee.HireDate = null;
			    } else {
			    	clsdbo_DimEmployee.HireDate = System.Convert.ToDateTime(txtHireDate.Text); }
			    if (string.IsNullOrEmpty(txtBirthDate.Text)) {
			    	clsdbo_DimEmployee.BirthDate = null;
			    } else {
			    	clsdbo_DimEmployee.BirthDate = System.Convert.ToDateTime(txtBirthDate.Text); }
			    if (string.IsNullOrEmpty(txtLoginID.Text)) {
			    	clsdbo_DimEmployee.LoginID = null;
			    } else {
			    	clsdbo_DimEmployee.LoginID = txtLoginID.Text; }
			    if (string.IsNullOrEmpty(txtEmailAddress.Text)) {
			    	clsdbo_DimEmployee.EmailAddress = null;
			    } else {
			    	clsdbo_DimEmployee.EmailAddress = txtEmailAddress.Text; }
			    if (string.IsNullOrEmpty(txtPhone.Text)) {
			    	clsdbo_DimEmployee.Phone = null;
			    } else {
			    	clsdbo_DimEmployee.Phone = txtPhone.Text; }
			    if (string.IsNullOrEmpty(txtMaritalStatus.Text)) {
			    	clsdbo_DimEmployee.MaritalStatus = null;
			    } else {
			    	clsdbo_DimEmployee.MaritalStatus = txtMaritalStatus.Text; }
			    if (string.IsNullOrEmpty(txtEmergencyContactName.Text)) {
			    	clsdbo_DimEmployee.EmergencyContactName = null;
			    } else {
			    	clsdbo_DimEmployee.EmergencyContactName = txtEmergencyContactName.Text; }
			    if (string.IsNullOrEmpty(txtEmergencyContactPhone.Text)) {
			    	clsdbo_DimEmployee.EmergencyContactPhone = null;
			    } else {
			    	clsdbo_DimEmployee.EmergencyContactPhone = txtEmergencyContactPhone.Text; }
			    clsdbo_DimEmployee.SalariedFlag = txtSalariedFlag.Checked ? true : false;                        
			    if (string.IsNullOrEmpty(txtGender.Text)) {
			    	clsdbo_DimEmployee.Gender = null;
			    } else {
			    	clsdbo_DimEmployee.Gender = txtGender.Text; }
			    if (string.IsNullOrEmpty(txtPayFrequency.Text)) {
			    	clsdbo_DimEmployee.PayFrequency = null;
			    } else {
			    	clsdbo_DimEmployee.PayFrequency = System.Convert.ToByte(txtPayFrequency.Text); }
			    if (string.IsNullOrEmpty(txtBaseRate.Text)) {
			    	clsdbo_DimEmployee.BaseRate = null;
			    } else {
			    	clsdbo_DimEmployee.BaseRate = System.Convert.ToDecimal(txtBaseRate.Text); }
			    if (string.IsNullOrEmpty(txtVacationHours.Text)) {
			    	clsdbo_DimEmployee.VacationHours = null;
			    } else {
			    	clsdbo_DimEmployee.VacationHours = System.Convert.ToInt16(txtVacationHours.Text); }
			    if (string.IsNullOrEmpty(txtSickLeaveHours.Text)) {
			    	clsdbo_DimEmployee.SickLeaveHours = null;
			    } else {
			    	clsdbo_DimEmployee.SickLeaveHours = System.Convert.ToInt16(txtSickLeaveHours.Text); }
			    clsdbo_DimEmployee.CurrentFlag = System.Convert.ToBoolean(txtCurrentFlag.Checked ? true : false);
			    clsdbo_DimEmployee.SalesPersonFlag = System.Convert.ToBoolean(txtSalesPersonFlag.Checked ? true : false);
			    if (string.IsNullOrEmpty(txtDepartmentName.Text)) {
			    	clsdbo_DimEmployee.DepartmentName = null;
			    } else {
			    	clsdbo_DimEmployee.DepartmentName = txtDepartmentName.Text; }
			    if (string.IsNullOrEmpty(txtStartDate.Text)) {
			    	clsdbo_DimEmployee.StartDate = null;
			    } else {
			    	clsdbo_DimEmployee.StartDate = System.Convert.ToDateTime(txtStartDate.Text); }
			    if (string.IsNullOrEmpty(txtEndDate.Text)) {
			    	clsdbo_DimEmployee.EndDate = null;
			    } else {
			    	clsdbo_DimEmployee.EndDate = System.Convert.ToDateTime(txtEndDate.Text); }
			    if (string.IsNullOrEmpty(txtStatus.Text)) {
			    	clsdbo_DimEmployee.Status = null;
			    } else {
			    	clsdbo_DimEmployee.Status = txtStatus.Text; }
        }

        private void InsertRecord()
        {
		    dbo_DimEmployeeClass clsdbo_DimEmployee = new dbo_DimEmployeeClass();
		    if (VerifyData() == true) {
                            SetData(clsdbo_DimEmployee);
			    bool bSucess = false;
			    bSucess = dbo_DimEmployeeDataClass.Add(clsdbo_DimEmployee);
			    if (bSucess == true) {
				    pnlForm.Visible = false;
				    pnlSave.Visible = false;
				    pnlGrid.Visible = true;
				    lblMode.InnerText = "";
				    Session.Remove("dvdbo_DimEmployee");
				    LoadGriddbo_DimEmployee();
			    } else {
				    ec.ShowMessage(" Insert failed. ", " Dbo. Dim Employee ");
			    }
		    }
        }

        private void UpdateRecord()
        {
		    dbo_DimEmployeeClass oclsdbo_DimEmployee = new dbo_DimEmployeeClass();
		    dbo_DimEmployeeClass clsdbo_DimEmployee = new dbo_DimEmployeeClass();

		    oclsdbo_DimEmployee.EmployeeKey = System.Convert.ToInt32(Session["EmployeeKey"]);
		    oclsdbo_DimEmployee = dbo_DimEmployeeDataClass.Select_Record(oclsdbo_DimEmployee);

		    if (VerifyData() == true) {
                            SetData(clsdbo_DimEmployee);
			    bool bSucess = false;
			    bSucess = dbo_DimEmployeeDataClass.Update(oclsdbo_DimEmployee, clsdbo_DimEmployee);
			    if (bSucess == true) {
				    pnlForm.Visible = false;
				    pnlSave.Visible = false;
				    pnlGrid.Visible = true;
				    lblMode.InnerText = "";
				    Session.Remove("dvdbo_DimEmployee");
				    LoadGriddbo_DimEmployee();
			    } else {
				    ec.ShowMessage(" Update failed. ", " Dbo. Dim Employee ");
			    }
		    }
        }

        private void DeleteRecord()
        {
		    dbo_DimEmployeeClass clsdbo_DimEmployee = new dbo_DimEmployeeClass();
		    clsdbo_DimEmployee.EmployeeKey = System.Convert.ToInt32(Session["EmployeeKey"]);
                    SetData(clsdbo_DimEmployee);
		    bool bSucess = false;
		    bSucess = dbo_DimEmployeeDataClass.Delete(clsdbo_DimEmployee);
		    if (bSucess == true) {
			    pnlForm.Visible = false;
			    pnlSave.Visible = false;
			    pnlGrid.Visible = true;
			    pnlDelete.Visible = false;
			    lblMode.InnerText = "";
			    Session.Remove("dvdbo_DimEmployee");
			    LoadGriddbo_DimEmployee();
		    } else {
			    ec.ShowMessage(" Delete failed. ", " Dbo. Dim Employee ");
		    }
        }

        private Boolean VerifyData()
        {
		    if (txtFirstName.Text == "") {
		    	ec.ShowMessage(" First Name is Required. ", " Dbo. Dim Employee ");
	                txtFirstName.Focus();
                	return false;}
		    if (txtLastName.Text == "") {
		    	ec.ShowMessage(" Last Name is Required. ", " Dbo. Dim Employee ");
	                txtLastName.Focus();
                	return false;}
            
            
            
		    return true;
        }

        public void butRecords_Click(object sender, System.EventArgs e)
        {
		    grddbo_DimEmployee.CurrentPageIndex = 0;
		    grddbo_DimEmployee.PageSize = Convert.ToInt32(cmbRecords.Text);
		    LoadGriddbo_DimEmployee();
        }

        public void btnAddNew_Click(object sender, System.EventArgs e)
        {
		    if (pnlForm.Visible) {
			    txtEmployeeKey.Text = "";
			    txtParentEmployeeKey.SelectedIndex = -1;
			    txtEmployeeNationalIDAlternateKey.Text = "";
			    txtParentEmployeeNationalIDAlternateKey.Text = "";
			    txtSalesTerritoryKey.SelectedIndex = -1;
			    txtFirstName.Text = "";
			    txtLastName.Text = "";
			    txtMiddleName.Text = "";
			    txtNameStyle.Checked = false;
			    txtTitle.Text = "";
			    txtHireDate.Text = "";
			    txtBirthDate.Text = "";
			    txtLoginID.Text = "";
			    txtEmailAddress.Text = "";
			    txtPhone.Text = "";
			    txtMaritalStatus.Text = "";
			    txtEmergencyContactName.Text = "";
			    txtEmergencyContactPhone.Text = "";
			    txtSalariedFlag.Checked = false;
			    txtGender.Text = "";
			    txtPayFrequency.Text = "";
			    txtBaseRate.Text = "";
			    txtVacationHours.Text = "";
			    txtSickLeaveHours.Text = "";
			    txtCurrentFlag.Checked = false;
			    txtSalesPersonFlag.Checked = false;
			    txtDepartmentName.Text = "";
			    txtStartDate.Text = "";
			    txtEndDate.Text = "";
			    txtStatus.Text = "";
		    } else {
			    pnlForm.Visible = true;
			    pnlGrid.Visible = false;
			    pnlSave.Visible = true;
			    lblMode.InnerText = "Add new";
		    }
		    btnSave.CommandArgument = "Add";
		    Add();
        }

        public void grddbo_DimEmployee_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
        { 
		    if (e.Item.ItemType == ListItemType.Pager | e.Item.ItemType == ListItemType.Header)
			    return;

		    Button btn = (Button)e.CommandSource;
		    if (btn.Text == "Edit" | btn.Text == "Delete") {
			    Session.Remove("EmployeeKey");
			    Session["EmployeeKey"] = e.Item.Cells[0 + 0].Text;
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

        public void grddbo_DimEmployee_SortCommand(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
        {
		    htmlHiddenSortExpression.Value = e.SortExpression + " " + GetSortDirection(e.SortExpression);
		    LoadGriddbo_DimEmployee();
        }

        public void grddbo_DimEmployee_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
        {
		    grddbo_DimEmployee.CurrentPageIndex = e.NewPageIndex;
		    LoadGriddbo_DimEmployee();
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
		    Session.Remove("dvdbo_DimEmployee");
		    LoadGriddbo_DimEmployee();
        }

        public void butSearch_Click(object sender, System.EventArgs e)
        {
		    try {
                        Session.Remove("dvdbo_DimEmployee");
			if ((Session["dvdbo_DimEmployee"] != null)) {
				dvdbo_DimEmployee = (DataView)Session["dvdbo_DimEmployee"];
				// DataView was not found in the session.
		    	} else {
				dvdbo_DimEmployee = dbo_DimEmployeeDataClass.Search(cmbFields.Text, cmbCondition.Text, txtSearch.Text).DefaultView;
			    	Session["dvdbo_DimEmployee"] = dvdbo_DimEmployee;
		    	}
                if (dvdbo_DimEmployee.Count > 0)
                {
                    dvdbo_DimEmployee.Sort = htmlHiddenSortExpression.Value;
                    grddbo_DimEmployee.DataSource = dvdbo_DimEmployee;
                    grddbo_DimEmployee.DataBind();
                }
                else
                {
                    grddbo_DimEmployee.DataSource = null;
                    grddbo_DimEmployee.DataBind();
                }
		    }
		    catch (Exception ex)
		    {
		    	ec.ShowMessage(ex.Message, " Dbo. Dim Employee ");
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
                    { dt = dbo_DimEmployeeDataClass.Search(cmbFields.Text, cmbCondition.Text, txtSearch.Text); }
                    else { dt = dbo_DimEmployeeDataClass.SelectAll(); }

                    PDFform pdfForm = new PDFform(dt, "Dbo. Dim Employee", "Many");
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
                    GVExport.DataSource = Session["dvdbo_DimEmployee"];
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
 
