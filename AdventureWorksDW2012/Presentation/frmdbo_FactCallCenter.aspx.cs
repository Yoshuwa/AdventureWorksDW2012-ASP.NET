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
    public partial class frmdbo_FactCallCenter : System.Web.UI.Page
    {

        private dbo_FactCallCenterDataClass clsdbo_FactCallCenterData = new dbo_FactCallCenterDataClass();
        private AdventureWorksDW2012DataClass clsAdventureWorksDW2012Data = new AdventureWorksDW2012DataClass();
        private DataView dvdbo_FactCallCenter;

        protected void Page_Load(object sender, EventArgs e)
        {
		    if (!Page.IsPostBack) {
			    Session["Mode"] = "";
 			    Session["FactCallCenterID"] = "";

			    Session.Remove("dvdbo_FactCallCenter");

                            cmbFields.Items.Add("Fact Call Center I D");
                            cmbFields.Items.Add("Date Key");
                            cmbFields.Items.Add("Wage Type");
                            cmbFields.Items.Add("Shift");
                            cmbFields.Items.Add("Level One Operators");
                            cmbFields.Items.Add("Level Two Operators");
                            cmbFields.Items.Add("Total Operators");
                            cmbFields.Items.Add("Calls");
                            cmbFields.Items.Add("Automatic Responses");
                            cmbFields.Items.Add("Orders");
                            cmbFields.Items.Add("Issues Raised");
                            cmbFields.Items.Add("Average Time Per Issue");
                            cmbFields.Items.Add("Service Grade");
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

            Loaddbo_FactCallCenter_dbo_DimDateComboBox();

			    LoadGriddbo_FactCallCenter();
		    }

        }


	    private void Loaddbo_FactCallCenter_dbo_DimDateComboBox()
	    {
		    List<dbo_FactCallCenter_dbo_DimDateClass> dbo_FactCallCenter_dbo_DimDateList = new  List<dbo_FactCallCenter_dbo_DimDateClass>();
		    try {
			    dbo_FactCallCenter_dbo_DimDateList = dbo_FactCallCenter_dbo_DimDateDataClass.List();
			    txtDateKey.DataSource = dbo_FactCallCenter_dbo_DimDateList;
			    txtDateKey.DataValueField = "DateKey";
			    txtDateKey.DataTextField = "FullDateAlternateKey";
			    txtDateKey.DataBind();
		    }
		    catch (Exception ex)
		    {
		    	ec.ShowMessage(ex.Message, " Dbo. Fact Call Center ");
		    }
	    }

        private void LoadGriddbo_FactCallCenter()
        {
		    try {
			if ((Session["dvdbo_FactCallCenter"] != null)) {
				dvdbo_FactCallCenter = (DataView)Session["dvdbo_FactCallCenter"];
				// DataView was not found in the session.
		    	} else {
				dvdbo_FactCallCenter = dbo_FactCallCenterDataClass.SelectAll().DefaultView;
			    	Session["dvdbo_FactCallCenter"] = dvdbo_FactCallCenter;
		    	}
                if (dvdbo_FactCallCenter.Count > 0)
                {
                    dvdbo_FactCallCenter.Sort = htmlHiddenSortExpression.Value;
                    grddbo_FactCallCenter.DataSource = dvdbo_FactCallCenter;
                    grddbo_FactCallCenter.DataBind();
                }
                else
                {
                    grddbo_FactCallCenter.DataSource = null;
                    grddbo_FactCallCenter.DataBind();
                }
		    }
		    catch (Exception ex)
		    {
		    	ec.ShowMessage(ex.Message, " Dbo. Fact Call Center ");
		    }
        }

        private void Add()
        {
		    Session.Remove("Mode");
		    Session["Mode"] = "Add";

		    ClearRecord();

		    this.txtDateKey.Enabled = true;
		    this.txtWageType.Enabled = true;
		    this.txtShift.Enabled = true;
		    this.txtLevelOneOperators.Enabled = true;
		    this.txtLevelTwoOperators.Enabled = true;
		    this.txtTotalOperators.Enabled = true;
		    this.txtCalls.Enabled = true;
		    this.txtAutomaticResponses.Enabled = true;
		    this.txtOrders.Enabled = true;
		    this.txtIssuesRaised.Enabled = true;
		    this.txtAverageTimePerIssue.Enabled = true;
		    this.txtServiceGrade.Enabled = true;
		    this.txtDate.Enabled = true;
		    txtFactCallCenterID.Enabled = false;
		    txtDateKey.Focus();
		    txtFactCallCenterID.Text = Convert.ToString(clsAdventureWorksDW2012Data.getAutoID("New", "FactCallCenter"));
        }

        private void GetData()
        {
		    ClearRecord();

		    dbo_FactCallCenterClass clsdbo_FactCallCenter = new dbo_FactCallCenterClass();
		    clsdbo_FactCallCenter.FactCallCenterID = System.Convert.ToInt32(Session["FactCallCenterID"]);
		    clsdbo_FactCallCenter = dbo_FactCallCenterDataClass.Select_Record(clsdbo_FactCallCenter);

		    if ((clsdbo_FactCallCenter != null)) {
			    try {
                		txtFactCallCenterID.Text = System.Convert.ToString(clsdbo_FactCallCenter.FactCallCenterID);
                		txtDateKey.SelectedValue = System.Convert.ToString(clsdbo_FactCallCenter.DateKey);
                		txtWageType.Text = System.Convert.ToString(clsdbo_FactCallCenter.WageType);
                		txtShift.Text = System.Convert.ToString(clsdbo_FactCallCenter.Shift);
                		txtLevelOneOperators.Text = System.Convert.ToString(clsdbo_FactCallCenter.LevelOneOperators);
                		txtLevelTwoOperators.Text = System.Convert.ToString(clsdbo_FactCallCenter.LevelTwoOperators);
                		txtTotalOperators.Text = System.Convert.ToString(clsdbo_FactCallCenter.TotalOperators);
                		txtCalls.Text = System.Convert.ToString(clsdbo_FactCallCenter.Calls);
                		txtAutomaticResponses.Text = System.Convert.ToString(clsdbo_FactCallCenter.AutomaticResponses);
                		txtOrders.Text = System.Convert.ToString(clsdbo_FactCallCenter.Orders);
                		txtIssuesRaised.Text = System.Convert.ToString(clsdbo_FactCallCenter.IssuesRaised);
                		txtAverageTimePerIssue.Text = System.Convert.ToString(clsdbo_FactCallCenter.AverageTimePerIssue);
                		txtServiceGrade.Text = System.Convert.ToString(clsdbo_FactCallCenter.ServiceGrade);
                		if (clsdbo_FactCallCenter.Date == null) { txtDate.Text = DateTime.Now.ToString(); } else { txtDate.Text = System.Convert.ToDateTime(clsdbo_FactCallCenter.Date).ToShortDateString(); }
		   	 }
		    	catch (Exception ex)
		    	{
		    		ec.ShowMessage(ex.Message, " Dbo. Fact Call Center ");
		    	}
		    }

        }

        private void Edit()
        {
		    Session.Remove("Mode");
		    Session["Mode"] = "Edit";

                    GetData();

		    txtDateKey.Enabled = true;
		    txtWageType.Enabled = true;
		    txtShift.Enabled = true;
		    txtLevelOneOperators.Enabled = true;
		    txtLevelTwoOperators.Enabled = true;
		    txtTotalOperators.Enabled = true;
		    txtCalls.Enabled = true;
		    txtAutomaticResponses.Enabled = true;
		    txtOrders.Enabled = true;
		    txtIssuesRaised.Enabled = true;
		    txtAverageTimePerIssue.Enabled = true;
		    txtServiceGrade.Enabled = true;
		    txtFactCallCenterID.Enabled = false;
		    txtDateKey.Focus();
        }

        private void Delete()
        {
		    Session.Remove("Mode");
		    Session["Mode"] = "Delete";

                    GetData();

		    txtFactCallCenterID.Enabled = false;
		    txtDateKey.Enabled = false;
		    txtWageType.Enabled = false;
		    txtShift.Enabled = false;
		    txtLevelOneOperators.Enabled = false;
		    txtLevelTwoOperators.Enabled = false;
		    txtTotalOperators.Enabled = false;
		    txtCalls.Enabled = false;
		    txtAutomaticResponses.Enabled = false;
		    txtOrders.Enabled = false;
		    txtIssuesRaised.Enabled = false;
		    txtAverageTimePerIssue.Enabled = false;
		    txtServiceGrade.Enabled = false;
		    txtDate.Enabled = false;
        }

        private void ClearRecord()
        {
	        txtFactCallCenterID.Text = null;
	        txtDateKey.SelectedIndex = -1;
	        txtWageType.Text = null;
	        txtShift.Text = null;
	        txtLevelOneOperators.Text = null;
	        txtLevelTwoOperators.Text = null;
	        txtTotalOperators.Text = null;
	        txtCalls.Text = null;
	        txtAutomaticResponses.Text = null;
	        txtOrders.Text = null;
	        txtIssuesRaised.Text = null;
	        txtAverageTimePerIssue.Text = null;
	        txtServiceGrade.Text = null;
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

        private void SetData(dbo_FactCallCenterClass clsdbo_FactCallCenter)
        {
			    clsdbo_FactCallCenter.DateKey = System.Convert.ToInt32(txtDateKey.SelectedValue);
			    clsdbo_FactCallCenter.WageType = System.Convert.ToString(txtWageType.Text);
			    clsdbo_FactCallCenter.Shift = System.Convert.ToString(txtShift.Text);
			    clsdbo_FactCallCenter.LevelOneOperators = System.Convert.ToInt16(txtLevelOneOperators.Text);
			    clsdbo_FactCallCenter.LevelTwoOperators = System.Convert.ToInt16(txtLevelTwoOperators.Text);
			    clsdbo_FactCallCenter.TotalOperators = System.Convert.ToInt16(txtTotalOperators.Text);
			    clsdbo_FactCallCenter.Calls = System.Convert.ToInt32(txtCalls.Text);
			    clsdbo_FactCallCenter.AutomaticResponses = System.Convert.ToInt32(txtAutomaticResponses.Text);
			    clsdbo_FactCallCenter.Orders = System.Convert.ToInt32(txtOrders.Text);
			    clsdbo_FactCallCenter.IssuesRaised = System.Convert.ToInt16(txtIssuesRaised.Text);
			    clsdbo_FactCallCenter.AverageTimePerIssue = System.Convert.ToInt16(txtAverageTimePerIssue.Text);
			    clsdbo_FactCallCenter.ServiceGrade = System.Convert.ToDecimal(txtServiceGrade.Text);
			    if (string.IsNullOrEmpty(txtDate.Text)) {
			    	clsdbo_FactCallCenter.Date = null;
			    } else {
			    	clsdbo_FactCallCenter.Date = System.Convert.ToDateTime(txtDate.Text); }
        }

        private void InsertRecord()
        {
		    dbo_FactCallCenterClass clsdbo_FactCallCenter = new dbo_FactCallCenterClass();
		    if (VerifyData() == true) {
                            SetData(clsdbo_FactCallCenter);
			    bool bSucess = false;
			    bSucess = dbo_FactCallCenterDataClass.Add(clsdbo_FactCallCenter);
			    if (bSucess == true) {
				    pnlForm.Visible = false;
				    pnlSave.Visible = false;
				    pnlGrid.Visible = true;
				    lblMode.InnerText = "";
				    Session.Remove("dvdbo_FactCallCenter");
				    LoadGriddbo_FactCallCenter();
			    } else {
				    ec.ShowMessage(" Insert failed. ", " Dbo. Fact Call Center ");
			    }
		    }
        }

        private void UpdateRecord()
        {
		    dbo_FactCallCenterClass oclsdbo_FactCallCenter = new dbo_FactCallCenterClass();
		    dbo_FactCallCenterClass clsdbo_FactCallCenter = new dbo_FactCallCenterClass();

		    oclsdbo_FactCallCenter.FactCallCenterID = System.Convert.ToInt32(Session["FactCallCenterID"]);
		    oclsdbo_FactCallCenter = dbo_FactCallCenterDataClass.Select_Record(oclsdbo_FactCallCenter);

		    if (VerifyData() == true) {
                            SetData(clsdbo_FactCallCenter);
			    bool bSucess = false;
			    bSucess = dbo_FactCallCenterDataClass.Update(oclsdbo_FactCallCenter, clsdbo_FactCallCenter);
			    if (bSucess == true) {
				    pnlForm.Visible = false;
				    pnlSave.Visible = false;
				    pnlGrid.Visible = true;
				    lblMode.InnerText = "";
				    Session.Remove("dvdbo_FactCallCenter");
				    LoadGriddbo_FactCallCenter();
			    } else {
				    ec.ShowMessage(" Update failed. ", " Dbo. Fact Call Center ");
			    }
		    }
        }

        private void DeleteRecord()
        {
		    dbo_FactCallCenterClass clsdbo_FactCallCenter = new dbo_FactCallCenterClass();
		    clsdbo_FactCallCenter.FactCallCenterID = System.Convert.ToInt32(Session["FactCallCenterID"]);
                    SetData(clsdbo_FactCallCenter);
		    bool bSucess = false;
		    bSucess = dbo_FactCallCenterDataClass.Delete(clsdbo_FactCallCenter);
		    if (bSucess == true) {
			    pnlForm.Visible = false;
			    pnlSave.Visible = false;
			    pnlGrid.Visible = true;
			    pnlDelete.Visible = false;
			    lblMode.InnerText = "";
			    Session.Remove("dvdbo_FactCallCenter");
			    LoadGriddbo_FactCallCenter();
		    } else {
			    ec.ShowMessage(" Delete failed. ", " Dbo. Fact Call Center ");
		    }
        }

        private Boolean VerifyData()
        {
		    if (txtDateKey.Text == "") {
		    	ec.ShowMessage(" Date Key is Required. ", " Dbo. Fact Call Center ");
	                txtDateKey.Focus();
                	return false;}
		    if (txtWageType.Text == "") {
		    	ec.ShowMessage(" Wage Type is Required. ", " Dbo. Fact Call Center ");
	                txtWageType.Focus();
                	return false;}
		    if (txtShift.Text == "") {
		    	ec.ShowMessage(" Shift is Required. ", " Dbo. Fact Call Center ");
	                txtShift.Focus();
                	return false;}
		    if (txtLevelOneOperators.Text == "") {
		    	ec.ShowMessage(" Level One Operators is Required. ", " Dbo. Fact Call Center ");
	                txtLevelOneOperators.Focus();
                	return false;}
		    if (txtLevelTwoOperators.Text == "") {
		    	ec.ShowMessage(" Level Two Operators is Required. ", " Dbo. Fact Call Center ");
	                txtLevelTwoOperators.Focus();
                	return false;}
		    if (txtTotalOperators.Text == "") {
		    	ec.ShowMessage(" Total Operators is Required. ", " Dbo. Fact Call Center ");
	                txtTotalOperators.Focus();
                	return false;}
		    if (txtCalls.Text == "") {
		    	ec.ShowMessage(" Calls is Required. ", " Dbo. Fact Call Center ");
	                txtCalls.Focus();
                	return false;}
		    if (txtAutomaticResponses.Text == "") {
		    	ec.ShowMessage(" Automatic Responses is Required. ", " Dbo. Fact Call Center ");
	                txtAutomaticResponses.Focus();
                	return false;}
		    if (txtOrders.Text == "") {
		    	ec.ShowMessage(" Orders is Required. ", " Dbo. Fact Call Center ");
	                txtOrders.Focus();
                	return false;}
		    if (txtIssuesRaised.Text == "") {
		    	ec.ShowMessage(" Issues Raised is Required. ", " Dbo. Fact Call Center ");
	                txtIssuesRaised.Focus();
                	return false;}
		    if (txtAverageTimePerIssue.Text == "") {
		    	ec.ShowMessage(" Average Time Per Issue is Required. ", " Dbo. Fact Call Center ");
	                txtAverageTimePerIssue.Focus();
                	return false;}
		    if (txtServiceGrade.Text == "") {
		    	ec.ShowMessage(" Service Grade is Required. ", " Dbo. Fact Call Center ");
	                txtServiceGrade.Focus();
                	return false;}
		    return true;
        }

        public void butRecords_Click(object sender, System.EventArgs e)
        {
		    grddbo_FactCallCenter.CurrentPageIndex = 0;
		    grddbo_FactCallCenter.PageSize = Convert.ToInt32(cmbRecords.Text);
		    LoadGriddbo_FactCallCenter();
        }

        public void btnAddNew_Click(object sender, System.EventArgs e)
        {
		    if (pnlForm.Visible) {
			    txtFactCallCenterID.Text = "";
			    txtDateKey.SelectedIndex = -1;
			    txtWageType.Text = "";
			    txtShift.Text = "";
			    txtLevelOneOperators.Text = "";
			    txtLevelTwoOperators.Text = "";
			    txtTotalOperators.Text = "";
			    txtCalls.Text = "";
			    txtAutomaticResponses.Text = "";
			    txtOrders.Text = "";
			    txtIssuesRaised.Text = "";
			    txtAverageTimePerIssue.Text = "";
			    txtServiceGrade.Text = "";
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

        public void grddbo_FactCallCenter_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
        { 
		    if (e.Item.ItemType == ListItemType.Pager | e.Item.ItemType == ListItemType.Header)
			    return;

		    Button btn = (Button)e.CommandSource;
		    if (btn.Text == "Edit" | btn.Text == "Delete") {
			    Session.Remove("FactCallCenterID");
			    Session["FactCallCenterID"] = e.Item.Cells[0 + 0].Text;
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

        public void grddbo_FactCallCenter_SortCommand(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
        {
		    htmlHiddenSortExpression.Value = e.SortExpression + " " + GetSortDirection(e.SortExpression);
		    LoadGriddbo_FactCallCenter();
        }

        public void grddbo_FactCallCenter_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
        {
		    grddbo_FactCallCenter.CurrentPageIndex = e.NewPageIndex;
		    LoadGriddbo_FactCallCenter();
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
		    Session.Remove("dvdbo_FactCallCenter");
		    LoadGriddbo_FactCallCenter();
        }

        public void butSearch_Click(object sender, System.EventArgs e)
        {
		    try {
                        Session.Remove("dvdbo_FactCallCenter");
			if ((Session["dvdbo_FactCallCenter"] != null)) {
				dvdbo_FactCallCenter = (DataView)Session["dvdbo_FactCallCenter"];
				// DataView was not found in the session.
		    	} else {
				dvdbo_FactCallCenter = dbo_FactCallCenterDataClass.Search(cmbFields.Text, cmbCondition.Text, txtSearch.Text).DefaultView;
			    	Session["dvdbo_FactCallCenter"] = dvdbo_FactCallCenter;
		    	}
                if (dvdbo_FactCallCenter.Count > 0)
                {
                    dvdbo_FactCallCenter.Sort = htmlHiddenSortExpression.Value;
                    grddbo_FactCallCenter.DataSource = dvdbo_FactCallCenter;
                    grddbo_FactCallCenter.DataBind();
                }
                else
                {
                    grddbo_FactCallCenter.DataSource = null;
                    grddbo_FactCallCenter.DataBind();
                }
		    }
		    catch (Exception ex)
		    {
		    	ec.ShowMessage(ex.Message, " Dbo. Fact Call Center ");
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
                    { dt = dbo_FactCallCenterDataClass.Search(cmbFields.Text, cmbCondition.Text, txtSearch.Text); }
                    else { dt = dbo_FactCallCenterDataClass.SelectAll(); }

                    PDFform pdfForm = new PDFform(dt, "Dbo. Fact Call Center", "Many");
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
                    GVExport.DataSource = Session["dvdbo_FactCallCenter"];
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
 
