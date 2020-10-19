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
    public partial class frmdbo_FactFinance : System.Web.UI.Page
    {

        private dbo_FactFinanceDataClass clsdbo_FactFinanceData = new dbo_FactFinanceDataClass();
        private AdventureWorksDW2012DataClass clsAdventureWorksDW2012Data = new AdventureWorksDW2012DataClass();
        private DataView dvdbo_FactFinance;

        protected void Page_Load(object sender, EventArgs e)
        {
		    if (!Page.IsPostBack) {
			    Session["Mode"] = "";
			    Session["FinanceKey"] = "";

			    Session.Remove("dvdbo_FactFinance");

                            cmbFields.Items.Add("Finance Key");
                            cmbFields.Items.Add("Date Key");
                            cmbFields.Items.Add("Organization Key");
                            cmbFields.Items.Add("Department Group Key");
                            cmbFields.Items.Add("Scenario Key");
                            cmbFields.Items.Add("Account Key");
                            cmbFields.Items.Add("Amount");
                            cmbFields.Items.Add("Date");

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

            Loaddbo_FactFinance_dbo_DimDateComboBox229();
            Loaddbo_FactFinance_dbo_DimOrganizationComboBox230();
            Loaddbo_FactFinance_dbo_DimDepartmentGroupComboBox231();
            Loaddbo_FactFinance_dbo_DimScenarioComboBox232();
            Loaddbo_FactFinance_dbo_DimAccountComboBox233();

			    LoadGriddbo_FactFinance();
		    }

        }


	    private void Loaddbo_FactFinance_dbo_DimDateComboBox229()
	    {
		    List<dbo_FactFinance_dbo_DimDateClass229> dbo_FactFinance_dbo_DimDateList = new  List<dbo_FactFinance_dbo_DimDateClass229>();
		    try {
			    dbo_FactFinance_dbo_DimDateList = dbo_FactFinance_dbo_DimDateDataClass229.List();
			    txtDateKey.DataSource = dbo_FactFinance_dbo_DimDateList;
			    txtDateKey.DataValueField = "DateKey";
			    txtDateKey.DataTextField = "DateKey";
			    txtDateKey.DataBind();
		    }
		    catch (Exception ex)
		    {
		    	ec.ShowMessage(ex.Message, " Dbo. Fact Finance ");
		    }
	    }

	    private void Loaddbo_FactFinance_dbo_DimOrganizationComboBox230()
	    {
		    List<dbo_FactFinance_dbo_DimOrganizationClass230> dbo_FactFinance_dbo_DimOrganizationList = new  List<dbo_FactFinance_dbo_DimOrganizationClass230>();
		    try {
			    dbo_FactFinance_dbo_DimOrganizationList = dbo_FactFinance_dbo_DimOrganizationDataClass230.List();
			    txtOrganizationKey.DataSource = dbo_FactFinance_dbo_DimOrganizationList;
			    txtOrganizationKey.DataValueField = "OrganizationKey";
			    txtOrganizationKey.DataTextField = "OrganizationName";
			    txtOrganizationKey.DataBind();
		    }
		    catch (Exception ex)
		    {
		    	ec.ShowMessage(ex.Message, " Dbo. Fact Finance ");
		    }
	    }

	    private void Loaddbo_FactFinance_dbo_DimDepartmentGroupComboBox231()
	    {
		    List<dbo_FactFinance_dbo_DimDepartmentGroupClass231> dbo_FactFinance_dbo_DimDepartmentGroupList = new  List<dbo_FactFinance_dbo_DimDepartmentGroupClass231>();
		    try {
			    dbo_FactFinance_dbo_DimDepartmentGroupList = dbo_FactFinance_dbo_DimDepartmentGroupDataClass231.List();
			    txtDepartmentGroupKey.DataSource = dbo_FactFinance_dbo_DimDepartmentGroupList;
			    txtDepartmentGroupKey.DataValueField = "DepartmentGroupKey";
			    txtDepartmentGroupKey.DataTextField = "DepartmentGroupName";
			    txtDepartmentGroupKey.DataBind();
		    }
		    catch (Exception ex)
		    {
		    	ec.ShowMessage(ex.Message, " Dbo. Fact Finance ");
		    }
	    }

	    private void Loaddbo_FactFinance_dbo_DimScenarioComboBox232()
	    {
		    List<dbo_FactFinance_dbo_DimScenarioClass232> dbo_FactFinance_dbo_DimScenarioList = new  List<dbo_FactFinance_dbo_DimScenarioClass232>();
		    try {
			    dbo_FactFinance_dbo_DimScenarioList = dbo_FactFinance_dbo_DimScenarioDataClass232.List();
			    txtScenarioKey.DataSource = dbo_FactFinance_dbo_DimScenarioList;
			    txtScenarioKey.DataValueField = "ScenarioKey";
			    txtScenarioKey.DataTextField = "ScenarioName";
			    txtScenarioKey.DataBind();
		    }
		    catch (Exception ex)
		    {
		    	ec.ShowMessage(ex.Message, " Dbo. Fact Finance ");
		    }
	    }

	    private void Loaddbo_FactFinance_dbo_DimAccountComboBox233()
	    {
		    List<dbo_FactFinance_dbo_DimAccountClass233> dbo_FactFinance_dbo_DimAccountList = new  List<dbo_FactFinance_dbo_DimAccountClass233>();
		    try {
			    dbo_FactFinance_dbo_DimAccountList = dbo_FactFinance_dbo_DimAccountDataClass233.List();
			    txtAccountKey.DataSource = dbo_FactFinance_dbo_DimAccountList;
			    txtAccountKey.DataValueField = "AccountKey";
			    txtAccountKey.DataTextField = "ParentAccountKey";
			    txtAccountKey.DataBind();
		    }
		    catch (Exception ex)
		    {
		    	ec.ShowMessage(ex.Message, " Dbo. Fact Finance ");
		    }
	    }

        private void LoadGriddbo_FactFinance()
        {
		    try {
			if ((Session["dvdbo_FactFinance"] != null)) {
				dvdbo_FactFinance = (DataView)Session["dvdbo_FactFinance"];
				// DataView was not found in the session.
		    	} else {
				dvdbo_FactFinance = dbo_FactFinanceDataClass.SelectAll().DefaultView;
			    	Session["dvdbo_FactFinance"] = dvdbo_FactFinance;
		    	}
                if (dvdbo_FactFinance.Count > 0)
                {
                    dvdbo_FactFinance.Sort = htmlHiddenSortExpression.Value;
                    grddbo_FactFinance.DataSource = dvdbo_FactFinance;
                    grddbo_FactFinance.DataBind();
                }
                else
                {
                    grddbo_FactFinance.DataSource = null;
                    grddbo_FactFinance.DataBind();
                }
		    }
		    catch (Exception ex)
		    {
		    	ec.ShowMessage(ex.Message, " Dbo. Fact Finance ");
		    }
        }

        private void Add()
        {
		    Session.Remove("Mode");
		    Session["Mode"] = "Add";

		    ClearRecord();

		    this.txtDateKey.Enabled = true;
		    this.txtOrganizationKey.Enabled = true;
		    this.txtDepartmentGroupKey.Enabled = true;
		    this.txtScenarioKey.Enabled = true;
		    this.txtAccountKey.Enabled = true;
		    this.txtAmount.Enabled = true;
		    this.txtDate.Enabled = true;
		    txtFinanceKey.Enabled = false;
		    txtDateKey.Focus();
		    txtFinanceKey.Text = Convert.ToString(clsAdventureWorksDW2012Data.getAutoID("New", "FactFinance"));
        }

        private void GetData()
        {
		    ClearRecord();

		    dbo_FactFinanceClass clsdbo_FactFinance = new dbo_FactFinanceClass();
		    clsdbo_FactFinance.FinanceKey = System.Convert.ToInt32(Session["FinanceKey"]);
		    clsdbo_FactFinance = dbo_FactFinanceDataClass.Select_Record(clsdbo_FactFinance);

		    if ((clsdbo_FactFinance != null)) {
			    try {
                		txtFinanceKey.Text = System.Convert.ToString(clsdbo_FactFinance.FinanceKey);
                		txtDateKey.SelectedValue = System.Convert.ToString(clsdbo_FactFinance.DateKey);
                		txtOrganizationKey.SelectedValue = System.Convert.ToString(clsdbo_FactFinance.OrganizationKey);
                		txtDepartmentGroupKey.SelectedValue = System.Convert.ToString(clsdbo_FactFinance.DepartmentGroupKey);
                		txtScenarioKey.SelectedValue = System.Convert.ToString(clsdbo_FactFinance.ScenarioKey);
                		txtAccountKey.SelectedValue = System.Convert.ToString(clsdbo_FactFinance.AccountKey);
                		txtAmount.Text = System.Convert.ToString(clsdbo_FactFinance.Amount);
                		if (clsdbo_FactFinance.Date == null) { txtDate.Text = DateTime.Now.ToString(); } else { txtDate.Text = System.Convert.ToDateTime(clsdbo_FactFinance.Date).ToShortDateString(); }
		   	 }
		    	catch (Exception ex)
		    	{
		    		ec.ShowMessage(ex.Message, " Dbo. Fact Finance ");
		    	}
		    }

        }

        private void Edit()
        {
		    Session.Remove("Mode");
		    Session["Mode"] = "Edit";

                    GetData();

		    txtDateKey.Enabled = true;
		    txtOrganizationKey.Enabled = true;
		    txtDepartmentGroupKey.Enabled = true;
		    txtScenarioKey.Enabled = true;
		    txtAccountKey.Enabled = true;
		    txtAmount.Enabled = true;
		    txtFinanceKey.Enabled = false;
		    txtDateKey.Focus();
        }

        private void Delete()
        {
		    Session.Remove("Mode");
		    Session["Mode"] = "Delete";

                    GetData();

		    txtFinanceKey.Enabled = false;
		    txtDateKey.Enabled = false;
		    txtOrganizationKey.Enabled = false;
		    txtDepartmentGroupKey.Enabled = false;
		    txtScenarioKey.Enabled = false;
		    txtAccountKey.Enabled = false;
		    txtAmount.Enabled = false;
		    txtDate.Enabled = false;
        }

        private void ClearRecord()
        {
	        txtFinanceKey.Text = null;
	        txtDateKey.SelectedIndex = -1;
	        txtOrganizationKey.SelectedIndex = -1;
	        txtDepartmentGroupKey.SelectedIndex = -1;
	        txtScenarioKey.SelectedIndex = -1;
	        txtAccountKey.SelectedIndex = -1;
	        txtAmount.Text = null;
        	txtDate.Text = null;
        }

        public void btnSave_Click(object sender, System.EventArgs e)
        {
		    if ((String)Session["Mode"] == "Add") {
			    this.InsertRecord();
		    } else if ((String)Session["Mode"] == "Edit") {
			    this.UpdateRecord();
		    }
        }

        private void SetData(dbo_FactFinanceClass clsdbo_FactFinance)
        {
			    clsdbo_FactFinance.DateKey = System.Convert.ToInt32(txtDateKey.SelectedValue);
			    clsdbo_FactFinance.OrganizationKey = System.Convert.ToInt32(txtOrganizationKey.SelectedValue);
			    clsdbo_FactFinance.DepartmentGroupKey = System.Convert.ToInt32(txtDepartmentGroupKey.SelectedValue);
			    clsdbo_FactFinance.ScenarioKey = System.Convert.ToInt32(txtScenarioKey.SelectedValue);
			    clsdbo_FactFinance.AccountKey = System.Convert.ToInt32(txtAccountKey.SelectedValue);
			    clsdbo_FactFinance.Amount = System.Convert.ToDecimal(txtAmount.Text);
			    if (string.IsNullOrEmpty(txtDate.Text)) {
			    	clsdbo_FactFinance.Date = null;
			    } else {
			    	clsdbo_FactFinance.Date = System.Convert.ToDateTime(txtDate.Text); }
        }

        private void InsertRecord()
        {
		    dbo_FactFinanceClass clsdbo_FactFinance = new dbo_FactFinanceClass();
		    if (VerifyData() == true) {
                            SetData(clsdbo_FactFinance);
			    bool bSucess = false;
			    bSucess = dbo_FactFinanceDataClass.Add(clsdbo_FactFinance);
			    if (bSucess == true) {
				    pnlForm.Visible = false;
				    pnlSave.Visible = false;
				    pnlGrid.Visible = true;
				    lblMode.InnerText = "";
				    Session.Remove("dvdbo_FactFinance");
				    LoadGriddbo_FactFinance();
			    } else {
				    ec.ShowMessage(" Insert failed. ", " Dbo. Fact Finance ");
			    }
		    }
        }

        private void UpdateRecord()
        {
		    dbo_FactFinanceClass oclsdbo_FactFinance = new dbo_FactFinanceClass();
		    dbo_FactFinanceClass clsdbo_FactFinance = new dbo_FactFinanceClass();

		    oclsdbo_FactFinance.FinanceKey = System.Convert.ToInt32(Session["FinanceKey"]);
		    oclsdbo_FactFinance = dbo_FactFinanceDataClass.Select_Record(oclsdbo_FactFinance);

		    if (VerifyData() == true) {
                            SetData(clsdbo_FactFinance);
			    bool bSucess = false;
			    bSucess = dbo_FactFinanceDataClass.Update(oclsdbo_FactFinance, clsdbo_FactFinance);
			    if (bSucess == true) {
				    pnlForm.Visible = false;
				    pnlSave.Visible = false;
				    pnlGrid.Visible = true;
				    lblMode.InnerText = "";
				    Session.Remove("dvdbo_FactFinance");
				    LoadGriddbo_FactFinance();
			    } else {
				    ec.ShowMessage(" Update failed. ", " Dbo. Fact Finance ");
			    }
		    }
        }

        private void DeleteRecord()
        {
		    dbo_FactFinanceClass clsdbo_FactFinance = new dbo_FactFinanceClass();
		    clsdbo_FactFinance.FinanceKey = System.Convert.ToInt32(Session["FinanceKey"]);
                    SetData(clsdbo_FactFinance);
		    bool bSucess = false;
		    bSucess = dbo_FactFinanceDataClass.Delete(clsdbo_FactFinance);
		    if (bSucess == true) {
			    pnlForm.Visible = false;
			    pnlSave.Visible = false;
			    pnlGrid.Visible = true;
			    pnlDelete.Visible = false;
			    lblMode.InnerText = "";
			    Session.Remove("dvdbo_FactFinance");
			    LoadGriddbo_FactFinance();
		    } else {
			    ec.ShowMessage(" Delete failed. ", " Dbo. Fact Finance ");
		    }
        }

        private Boolean VerifyData()
        {
		    if (txtDateKey.Text == "") {
		    	ec.ShowMessage(" Date Key is Required. ", " Dbo. Fact Finance ");
	                txtDateKey.Focus();
                	return false;}
		    if (txtOrganizationKey.Text == "") {
		    	ec.ShowMessage(" Organization Key is Required. ", " Dbo. Fact Finance ");
	                txtOrganizationKey.Focus();
                	return false;}
		    if (txtDepartmentGroupKey.Text == "") {
		    	ec.ShowMessage(" Department Group Key is Required. ", " Dbo. Fact Finance ");
	                txtDepartmentGroupKey.Focus();
                	return false;}
		    if (txtScenarioKey.Text == "") {
		    	ec.ShowMessage(" Scenario Key is Required. ", " Dbo. Fact Finance ");
	                txtScenarioKey.Focus();
                	return false;}
		    if (txtAccountKey.Text == "") {
		    	ec.ShowMessage(" Account Key is Required. ", " Dbo. Fact Finance ");
	                txtAccountKey.Focus();
                	return false;}
		    if (txtAmount.Text == "") {
		    	ec.ShowMessage(" Amount is Required. ", " Dbo. Fact Finance ");
	                txtAmount.Focus();
                	return false;}
		    return true;
        }

        public void butRecords_Click(object sender, System.EventArgs e)
        {
		    grddbo_FactFinance.CurrentPageIndex = 0;
		    grddbo_FactFinance.PageSize = Convert.ToInt32(cmbRecords.Text);
		    LoadGriddbo_FactFinance();
        }

        public void btnAddNew_Click(object sender, System.EventArgs e)
        {
		    if (pnlForm.Visible) {
			    txtFinanceKey.Text = "";
			    txtDateKey.SelectedIndex = -1;
			    txtOrganizationKey.SelectedIndex = -1;
			    txtDepartmentGroupKey.SelectedIndex = -1;
			    txtScenarioKey.SelectedIndex = -1;
			    txtAccountKey.SelectedIndex = -1;
			    txtAmount.Text = "";
			    txtDate.Text = "";
		    } else {
			    pnlForm.Visible = true;
			    pnlGrid.Visible = false;
			    pnlSave.Visible = true;
			    lblMode.InnerText = "Add new";
		    }
		    btnSave.CommandArgument = "Add";
		    Add();
        }

        public void grddbo_FactFinance_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
        { 
		    if (e.Item.ItemType == ListItemType.Pager | e.Item.ItemType == ListItemType.Header)
			    return;

		    Button btn = (Button)e.CommandSource;
		    if (btn.Text == "Edit" | btn.Text == "Delete") {
			    Session.Remove("FinanceKey");
			    Session["FinanceKey"] = e.Item.Cells[0 + 0].Text;
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

        public void grddbo_FactFinance_SortCommand(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
        {
		    htmlHiddenSortExpression.Value = e.SortExpression + " " + GetSortDirection(e.SortExpression);
		    LoadGriddbo_FactFinance();
        }

        public void grddbo_FactFinance_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
        {
		    grddbo_FactFinance.CurrentPageIndex = e.NewPageIndex;
		    LoadGriddbo_FactFinance();
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
		    Session.Remove("dvdbo_FactFinance");
		    LoadGriddbo_FactFinance();
        }

        public void butSearch_Click(object sender, System.EventArgs e)
        {
		    try {
                        Session.Remove("dvdbo_FactFinance");
			if ((Session["dvdbo_FactFinance"] != null)) {
				dvdbo_FactFinance = (DataView)Session["dvdbo_FactFinance"];
				// DataView was not found in the session.
		    	} else {
				dvdbo_FactFinance = dbo_FactFinanceDataClass.Search(cmbFields.Text, cmbCondition.Text, txtSearch.Text).DefaultView;
			    	Session["dvdbo_FactFinance"] = dvdbo_FactFinance;
		    	}
                if (dvdbo_FactFinance.Count > 0)
                {
                    dvdbo_FactFinance.Sort = htmlHiddenSortExpression.Value;
                    grddbo_FactFinance.DataSource = dvdbo_FactFinance;
                    grddbo_FactFinance.DataBind();
                }
                else
                {
                    grddbo_FactFinance.DataSource = null;
                    grddbo_FactFinance.DataBind();
                }
		    }
		    catch (Exception ex)
		    {
		    	ec.ShowMessage(ex.Message, " Dbo. Fact Finance ");
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
                    { dt = dbo_FactFinanceDataClass.Search(cmbFields.Text, cmbCondition.Text, txtSearch.Text); }
                    else { dt = dbo_FactFinanceDataClass.SelectAll(); }

                    PDFform pdfForm = new PDFform(dt, "Dbo. Fact Finance", "Many");
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
                    GVExport.DataSource = Session["dvdbo_FactFinance"];
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
 
