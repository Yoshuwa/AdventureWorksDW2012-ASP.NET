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
    public partial class frmdbo_FactSalesQuota : System.Web.UI.Page
    {

        private dbo_FactSalesQuotaDataClass clsdbo_FactSalesQuotaData = new dbo_FactSalesQuotaDataClass();
        private AdventureWorksDW2012DataClass clsAdventureWorksDW2012Data = new AdventureWorksDW2012DataClass();
        private DataView dvdbo_FactSalesQuota;

        protected void Page_Load(object sender, EventArgs e)
        {
		    if (!Page.IsPostBack) {
			    Session["Mode"] = "";
 			    Session["SalesQuotaKey"] = "";

			    Session.Remove("dvdbo_FactSalesQuota");

                            cmbFields.Items.Add("Sales Quota Key");
                            cmbFields.Items.Add("Employee Key");
                            cmbFields.Items.Add("Date Key");
                            cmbFields.Items.Add("Calendar Year");
                            cmbFields.Items.Add("Calendar Quarter");
                            cmbFields.Items.Add("Sales Amount Quota");
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

            Loaddbo_FactSalesQuota_dbo_DimEmployeeComboBox300();
            Loaddbo_FactSalesQuota_dbo_DimDateComboBox301();

			    LoadGriddbo_FactSalesQuota();
		    }

        }


	    private void Loaddbo_FactSalesQuota_dbo_DimEmployeeComboBox300()
	    {
		    List<dbo_FactSalesQuota_dbo_DimEmployeeClass300> dbo_FactSalesQuota_dbo_DimEmployeeList = new  List<dbo_FactSalesQuota_dbo_DimEmployeeClass300>();
		    try {
			    dbo_FactSalesQuota_dbo_DimEmployeeList = dbo_FactSalesQuota_dbo_DimEmployeeDataClass300.List();
			    txtEmployeeKey.DataSource = dbo_FactSalesQuota_dbo_DimEmployeeList;
			    txtEmployeeKey.DataValueField = "EmployeeKey";
			    txtEmployeeKey.DataTextField = "EmployeeKey";
			    txtEmployeeKey.DataBind();
		    }
		    catch (Exception ex)
		    {
		    	ec.ShowMessage(ex.Message, " Dbo. Fact Sales Quota ");
		    }
	    }

	    private void Loaddbo_FactSalesQuota_dbo_DimDateComboBox301()
	    {
		    List<dbo_FactSalesQuota_dbo_DimDateClass301> dbo_FactSalesQuota_dbo_DimDateList = new  List<dbo_FactSalesQuota_dbo_DimDateClass301>();
		    try {
			    dbo_FactSalesQuota_dbo_DimDateList = dbo_FactSalesQuota_dbo_DimDateDataClass301.List();
			    txtDateKey.DataSource = dbo_FactSalesQuota_dbo_DimDateList;
			    txtDateKey.DataValueField = "DateKey";
			    txtDateKey.DataTextField = "DateKey";
			    txtDateKey.DataBind();
		    }
		    catch (Exception ex)
		    {
		    	ec.ShowMessage(ex.Message, " Dbo. Fact Sales Quota ");
		    }
	    }

        private void LoadGriddbo_FactSalesQuota()
        {
		    try {
			if ((Session["dvdbo_FactSalesQuota"] != null)) {
				dvdbo_FactSalesQuota = (DataView)Session["dvdbo_FactSalesQuota"];
				// DataView was not found in the session.
		    	} else {
				dvdbo_FactSalesQuota = dbo_FactSalesQuotaDataClass.SelectAll().DefaultView;
			    	Session["dvdbo_FactSalesQuota"] = dvdbo_FactSalesQuota;
		    	}
                if (dvdbo_FactSalesQuota.Count > 0)
                {
                    dvdbo_FactSalesQuota.Sort = htmlHiddenSortExpression.Value;
                    grddbo_FactSalesQuota.DataSource = dvdbo_FactSalesQuota;
                    grddbo_FactSalesQuota.DataBind();
                }
                else
                {
                    grddbo_FactSalesQuota.DataSource = null;
                    grddbo_FactSalesQuota.DataBind();
                }
		    }
		    catch (Exception ex)
		    {
		    	ec.ShowMessage(ex.Message, " Dbo. Fact Sales Quota ");
		    }
        }

        private void Add()
        {
		    Session.Remove("Mode");
		    Session["Mode"] = "Add";

		    ClearRecord();

		    this.txtEmployeeKey.Enabled = true;
		    this.txtDateKey.Enabled = true;
		    this.txtCalendarYear.Enabled = true;
		    this.txtCalendarQuarter.Enabled = true;
		    this.txtSalesAmountQuota.Enabled = true;
		    this.txtDate.Enabled = true;
		    txtSalesQuotaKey.Enabled = false;
		    txtEmployeeKey.Focus();
		    txtSalesQuotaKey.Text = Convert.ToString(clsAdventureWorksDW2012Data.getAutoID("New", "FactSalesQuota"));
        }

        private void GetData()
        {
		    ClearRecord();

		    dbo_FactSalesQuotaClass clsdbo_FactSalesQuota = new dbo_FactSalesQuotaClass();
		    clsdbo_FactSalesQuota.SalesQuotaKey = System.Convert.ToInt32(Session["SalesQuotaKey"]);
		    clsdbo_FactSalesQuota = dbo_FactSalesQuotaDataClass.Select_Record(clsdbo_FactSalesQuota);

		    if ((clsdbo_FactSalesQuota != null)) {
			    try {
                		txtSalesQuotaKey.Text = System.Convert.ToString(clsdbo_FactSalesQuota.SalesQuotaKey);
                		txtEmployeeKey.SelectedValue = System.Convert.ToString(clsdbo_FactSalesQuota.EmployeeKey);
                		txtDateKey.SelectedValue = System.Convert.ToString(clsdbo_FactSalesQuota.DateKey);
                		txtCalendarYear.Text = System.Convert.ToString(clsdbo_FactSalesQuota.CalendarYear);
                		txtCalendarQuarter.Text = System.Convert.ToString(clsdbo_FactSalesQuota.CalendarQuarter);
                		txtSalesAmountQuota.Text = System.Convert.ToString(clsdbo_FactSalesQuota.SalesAmountQuota);
                		if (clsdbo_FactSalesQuota.Date == null) { txtDate.Text = DateTime.Now.ToString(); } else { txtDate.Text = System.Convert.ToDateTime(clsdbo_FactSalesQuota.Date).ToShortDateString(); }
		   	 }
		    	catch (Exception ex)
		    	{
		    		ec.ShowMessage(ex.Message, " Dbo. Fact Sales Quota ");
		    	}
		    }

        }

        private void Edit()
        {
		    Session.Remove("Mode");
		    Session["Mode"] = "Edit";

                    GetData();

		    txtEmployeeKey.Enabled = true;
		    txtDateKey.Enabled = true;
		    txtCalendarYear.Enabled = true;
		    txtCalendarQuarter.Enabled = true;
		    txtSalesAmountQuota.Enabled = true;
		    txtSalesQuotaKey.Enabled = false;
		    txtEmployeeKey.Focus();
        }

        private void Delete()
        {
		    Session.Remove("Mode");
		    Session["Mode"] = "Delete";

                    GetData();

		    txtSalesQuotaKey.Enabled = false;
		    txtEmployeeKey.Enabled = false;
		    txtDateKey.Enabled = false;
		    txtCalendarYear.Enabled = false;
		    txtCalendarQuarter.Enabled = false;
		    txtSalesAmountQuota.Enabled = false;
		    txtDate.Enabled = false;
        }

        private void ClearRecord()
        {
	        txtSalesQuotaKey.Text = null;
	        txtEmployeeKey.SelectedIndex = -1;
	        txtDateKey.SelectedIndex = -1;
	        txtCalendarYear.Text = null;
	        txtCalendarQuarter.Text = null;
	        txtSalesAmountQuota.Text = null;
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

        private void SetData(dbo_FactSalesQuotaClass clsdbo_FactSalesQuota)
        {
			    clsdbo_FactSalesQuota.EmployeeKey = System.Convert.ToInt32(txtEmployeeKey.SelectedValue);
			    clsdbo_FactSalesQuota.DateKey = System.Convert.ToInt32(txtDateKey.SelectedValue);
			    clsdbo_FactSalesQuota.CalendarYear = System.Convert.ToInt16(txtCalendarYear.Text);
			    clsdbo_FactSalesQuota.CalendarQuarter = System.Convert.ToByte(txtCalendarQuarter.Text);
			    clsdbo_FactSalesQuota.SalesAmountQuota = System.Convert.ToDecimal(txtSalesAmountQuota.Text);
			    if (string.IsNullOrEmpty(txtDate.Text)) {
			    	clsdbo_FactSalesQuota.Date = null;
			    } else {
			    	clsdbo_FactSalesQuota.Date = System.Convert.ToDateTime(txtDate.Text); }
        }

        private void InsertRecord()
        {
		    dbo_FactSalesQuotaClass clsdbo_FactSalesQuota = new dbo_FactSalesQuotaClass();
		    if (VerifyData() == true) {
                            SetData(clsdbo_FactSalesQuota);
			    bool bSucess = false;
			    bSucess = dbo_FactSalesQuotaDataClass.Add(clsdbo_FactSalesQuota);
			    if (bSucess == true) {
				    pnlForm.Visible = false;
				    pnlSave.Visible = false;
				    pnlGrid.Visible = true;
				    lblMode.InnerText = "";
				    Session.Remove("dvdbo_FactSalesQuota");
				    LoadGriddbo_FactSalesQuota();
			    } else {
				    ec.ShowMessage(" Insert failed. ", " Dbo. Fact Sales Quota ");
			    }
		    }
        }

        private void UpdateRecord()
        {
		    dbo_FactSalesQuotaClass oclsdbo_FactSalesQuota = new dbo_FactSalesQuotaClass();
		    dbo_FactSalesQuotaClass clsdbo_FactSalesQuota = new dbo_FactSalesQuotaClass();

		    oclsdbo_FactSalesQuota.SalesQuotaKey = System.Convert.ToInt32(Session["SalesQuotaKey"]);
		    oclsdbo_FactSalesQuota = dbo_FactSalesQuotaDataClass.Select_Record(oclsdbo_FactSalesQuota);

		    if (VerifyData() == true) {
                            SetData(clsdbo_FactSalesQuota);
			    bool bSucess = false;
			    bSucess = dbo_FactSalesQuotaDataClass.Update(oclsdbo_FactSalesQuota, clsdbo_FactSalesQuota);
			    if (bSucess == true) {
				    pnlForm.Visible = false;
				    pnlSave.Visible = false;
				    pnlGrid.Visible = true;
				    lblMode.InnerText = "";
				    Session.Remove("dvdbo_FactSalesQuota");
				    LoadGriddbo_FactSalesQuota();
			    } else {
				    ec.ShowMessage(" Update failed. ", " Dbo. Fact Sales Quota ");
			    }
		    }
        }

        private void DeleteRecord()
        {
		    dbo_FactSalesQuotaClass clsdbo_FactSalesQuota = new dbo_FactSalesQuotaClass();
		    clsdbo_FactSalesQuota.SalesQuotaKey = System.Convert.ToInt32(Session["SalesQuotaKey"]);
                    SetData(clsdbo_FactSalesQuota);
		    bool bSucess = false;
		    bSucess = dbo_FactSalesQuotaDataClass.Delete(clsdbo_FactSalesQuota);
		    if (bSucess == true) {
			    pnlForm.Visible = false;
			    pnlSave.Visible = false;
			    pnlGrid.Visible = true;
			    pnlDelete.Visible = false;
			    lblMode.InnerText = "";
			    Session.Remove("dvdbo_FactSalesQuota");
			    LoadGriddbo_FactSalesQuota();
		    } else {
			    ec.ShowMessage(" Delete failed. ", " Dbo. Fact Sales Quota ");
		    }
        }

        private Boolean VerifyData()
        {
		    if (txtEmployeeKey.Text == "") {
		    	ec.ShowMessage(" Employee Key is Required. ", " Dbo. Fact Sales Quota ");
	                txtEmployeeKey.Focus();
                	return false;}
		    if (txtDateKey.Text == "") {
		    	ec.ShowMessage(" Date Key is Required. ", " Dbo. Fact Sales Quota ");
	                txtDateKey.Focus();
                	return false;}
		    if (txtCalendarYear.Text == "") {
		    	ec.ShowMessage(" Calendar Year is Required. ", " Dbo. Fact Sales Quota ");
	                txtCalendarYear.Focus();
                	return false;}
		    if (txtCalendarQuarter.Text == "") {
		    	ec.ShowMessage(" Calendar Quarter is Required. ", " Dbo. Fact Sales Quota ");
	                txtCalendarQuarter.Focus();
                	return false;}
		    if (txtSalesAmountQuota.Text == "") {
		    	ec.ShowMessage(" Sales Amount Quota is Required. ", " Dbo. Fact Sales Quota ");
	                txtSalesAmountQuota.Focus();
                	return false;}
		    return true;
        }

        public void butRecords_Click(object sender, System.EventArgs e)
        {
		    grddbo_FactSalesQuota.CurrentPageIndex = 0;
		    grddbo_FactSalesQuota.PageSize = Convert.ToInt32(cmbRecords.Text);
		    LoadGriddbo_FactSalesQuota();
        }

        public void btnAddNew_Click(object sender, System.EventArgs e)
        {
		    if (pnlForm.Visible) {
			    txtSalesQuotaKey.Text = "";
			    txtEmployeeKey.SelectedIndex = -1;
			    txtDateKey.SelectedIndex = -1;
			    txtCalendarYear.Text = "";
			    txtCalendarQuarter.Text = "";
			    txtSalesAmountQuota.Text = "";
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

        public void grddbo_FactSalesQuota_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
        { 
		    if (e.Item.ItemType == ListItemType.Pager | e.Item.ItemType == ListItemType.Header)
			    return;

		    Button btn = (Button)e.CommandSource;
		    if (btn.Text == "Edit" | btn.Text == "Delete") {
			    Session.Remove("SalesQuotaKey");
			    Session["SalesQuotaKey"] = e.Item.Cells[0 + 0].Text;
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

        public void grddbo_FactSalesQuota_SortCommand(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
        {
		    htmlHiddenSortExpression.Value = e.SortExpression + " " + GetSortDirection(e.SortExpression);
		    LoadGriddbo_FactSalesQuota();
        }

        public void grddbo_FactSalesQuota_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
        {
		    grddbo_FactSalesQuota.CurrentPageIndex = e.NewPageIndex;
		    LoadGriddbo_FactSalesQuota();
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
		    Session.Remove("dvdbo_FactSalesQuota");
		    LoadGriddbo_FactSalesQuota();
        }

        public void butSearch_Click(object sender, System.EventArgs e)
        {
		    try {
                        Session.Remove("dvdbo_FactSalesQuota");
			if ((Session["dvdbo_FactSalesQuota"] != null)) {
				dvdbo_FactSalesQuota = (DataView)Session["dvdbo_FactSalesQuota"];
				// DataView was not found in the session.
		    	} else {
				dvdbo_FactSalesQuota = dbo_FactSalesQuotaDataClass.Search(cmbFields.Text, cmbCondition.Text, txtSearch.Text).DefaultView;
			    	Session["dvdbo_FactSalesQuota"] = dvdbo_FactSalesQuota;
		    	}
                if (dvdbo_FactSalesQuota.Count > 0)
                {
                    dvdbo_FactSalesQuota.Sort = htmlHiddenSortExpression.Value;
                    grddbo_FactSalesQuota.DataSource = dvdbo_FactSalesQuota;
                    grddbo_FactSalesQuota.DataBind();
                }
                else
                {
                    grddbo_FactSalesQuota.DataSource = null;
                    grddbo_FactSalesQuota.DataBind();
                }
		    }
		    catch (Exception ex)
		    {
		    	ec.ShowMessage(ex.Message, " Dbo. Fact Sales Quota ");
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
                    { dt = dbo_FactSalesQuotaDataClass.Search(cmbFields.Text, cmbCondition.Text, txtSearch.Text); }
                    else { dt = dbo_FactSalesQuotaDataClass.SelectAll(); }

                    PDFform pdfForm = new PDFform(dt, "Dbo. Fact Sales Quota", "Many");
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
                    GVExport.DataSource = Session["dvdbo_FactSalesQuota"];
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
 
