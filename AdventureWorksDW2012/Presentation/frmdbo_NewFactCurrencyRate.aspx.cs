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
    public partial class frmdbo_NewFactCurrencyRate : System.Web.UI.Page
    {

        private dbo_NewFactCurrencyRateDataClass clsdbo_NewFactCurrencyRateData = new dbo_NewFactCurrencyRateDataClass();
        private AdventureWorksDW2012DataClass clsAdventureWorksDW2012Data = new AdventureWorksDW2012DataClass();
        private DataView dvdbo_NewFactCurrencyRate;

        protected void Page_Load(object sender, EventArgs e)
        {
		    if (!Page.IsPostBack) {
			    Session["Mode"] = "";
			    Session["AverageRate"] = "";

			    Session.Remove("dvdbo_NewFactCurrencyRate");

                            cmbFields.Items.Add("Average Rate");
                            cmbFields.Items.Add("Currency I D");
                            cmbFields.Items.Add("Currency Date");
                            cmbFields.Items.Add("End Of Day Rate");
                            cmbFields.Items.Add("Currency Key");
                            cmbFields.Items.Add("Date Key");

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


			    LoadGriddbo_NewFactCurrencyRate();
		    }

        }


        private void LoadGriddbo_NewFactCurrencyRate()
        {
		    try {
			if ((Session["dvdbo_NewFactCurrencyRate"] != null)) {
				dvdbo_NewFactCurrencyRate = (DataView)Session["dvdbo_NewFactCurrencyRate"];
				// DataView was not found in the session.
		    	} else {
				dvdbo_NewFactCurrencyRate = dbo_NewFactCurrencyRateDataClass.SelectAll().DefaultView;
			    	Session["dvdbo_NewFactCurrencyRate"] = dvdbo_NewFactCurrencyRate;
		    	}
                if (dvdbo_NewFactCurrencyRate.Count > 0)
                {
                    dvdbo_NewFactCurrencyRate.Sort = htmlHiddenSortExpression.Value;
                    grddbo_NewFactCurrencyRate.DataSource = dvdbo_NewFactCurrencyRate;
                    grddbo_NewFactCurrencyRate.DataBind();
                }
                else
                {
                    grddbo_NewFactCurrencyRate.DataSource = null;
                    grddbo_NewFactCurrencyRate.DataBind();
                }
		    }
		    catch (Exception ex)
		    {
		    	ec.ShowMessage(ex.Message, " Dbo. New Fact Currency Rate ");
		    }
        }

        private void Add()
        {
		    Session.Remove("Mode");
		    Session["Mode"] = "Add";

		    ClearRecord();

		    this.txtAverageRate.Enabled = true;
		    this.txtCurrencyID.Enabled = true;
		    this.txtCurrencyDate.Enabled = true;
		    this.txtEndOfDayRate.Enabled = true;
		    this.txtCurrencyKey.Enabled = true;
		    this.txtDateKey.Enabled = true;
		    txtAverageRate.Focus();
        }

        private void GetData()
        {
		    ClearRecord();

		    dbo_NewFactCurrencyRateClass clsdbo_NewFactCurrencyRate = new dbo_NewFactCurrencyRateClass();
		    clsdbo_NewFactCurrencyRate.AverageRate = System.Convert.ToDecimal(Session["AverageRate"]);
		    clsdbo_NewFactCurrencyRate = dbo_NewFactCurrencyRateDataClass.Select_Record(clsdbo_NewFactCurrencyRate);

		    if ((clsdbo_NewFactCurrencyRate != null)) {
			    try {
                		if (clsdbo_NewFactCurrencyRate.AverageRate == null) { txtAverageRate.Text = default(string); } else { txtAverageRate.Text = System.Convert.ToString(clsdbo_NewFactCurrencyRate.AverageRate); }
                		if (clsdbo_NewFactCurrencyRate.CurrencyID == null) { txtCurrencyID.Text = default(string); } else { txtCurrencyID.Text = System.Convert.ToString(clsdbo_NewFactCurrencyRate.CurrencyID); }
                		if (clsdbo_NewFactCurrencyRate.CurrencyDate == null) { txtCurrencyDate.Text = DateTime.Now.ToString(); } else { txtCurrencyDate.Text = System.Convert.ToDateTime(clsdbo_NewFactCurrencyRate.CurrencyDate).ToShortDateString(); }
                		if (clsdbo_NewFactCurrencyRate.EndOfDayRate == null) { txtEndOfDayRate.Text = default(string); } else { txtEndOfDayRate.Text = System.Convert.ToString(clsdbo_NewFactCurrencyRate.EndOfDayRate); }
                		if (clsdbo_NewFactCurrencyRate.CurrencyKey == null) { txtCurrencyKey.Text = default(string); } else { txtCurrencyKey.Text = System.Convert.ToString(clsdbo_NewFactCurrencyRate.CurrencyKey); }
                		if (clsdbo_NewFactCurrencyRate.DateKey == null) { txtDateKey.Text = default(string); } else { txtDateKey.Text = System.Convert.ToString(clsdbo_NewFactCurrencyRate.DateKey); }
		   	 }
		    	catch (Exception ex)
		    	{
		    		ec.ShowMessage(ex.Message, " Dbo. New Fact Currency Rate ");
		    	}
		    }

        }

        private void Edit()
        {
		    Session.Remove("Mode");
		    Session["Mode"] = "Edit";

                    GetData();

		    txtAverageRate.Enabled = true;
		    txtCurrencyID.Enabled = true;
		    txtEndOfDayRate.Enabled = true;
		    txtCurrencyKey.Enabled = true;
		    txtDateKey.Enabled = true;
		    txtAverageRate.Enabled = false;
		    txtAverageRate.Focus();
        }

        private void Delete()
        {
		    Session.Remove("Mode");
		    Session["Mode"] = "Delete";

                    GetData();

		    txtAverageRate.Enabled = false;
		    txtCurrencyID.Enabled = false;
		    txtCurrencyDate.Enabled = false;
		    txtEndOfDayRate.Enabled = false;
		    txtCurrencyKey.Enabled = false;
		    txtDateKey.Enabled = false;
        }

        private void ClearRecord()
        {
	        txtAverageRate.Text = null;
	        txtCurrencyID.Text = null;
        	txtCurrencyDate.Text = null;
	        txtEndOfDayRate.Text = null;
	        txtCurrencyKey.Text = null;
	        txtDateKey.Text = null;
        }

        public void btnSave_Click(object sender, System.EventArgs e)
        {
		    if ((String)Session["Mode"] == "Add") {
			    this.InsertRecord();
		    } else if ((String)Session["Mode"] == "Edit") {
			    this.UpdateRecord();
		    }
        }

        private void SetData(dbo_NewFactCurrencyRateClass clsdbo_NewFactCurrencyRate)
        {
			    if (string.IsNullOrEmpty(txtAverageRate.Text)) {
			    	clsdbo_NewFactCurrencyRate.AverageRate = null;
			    } else {
			    	clsdbo_NewFactCurrencyRate.AverageRate = System.Convert.ToDecimal(txtAverageRate.Text); }
			    if (string.IsNullOrEmpty(txtCurrencyID.Text)) {
			    	clsdbo_NewFactCurrencyRate.CurrencyID = null;
			    } else {
			    	clsdbo_NewFactCurrencyRate.CurrencyID = txtCurrencyID.Text; }
			    if (string.IsNullOrEmpty(txtCurrencyDate.Text)) {
			    	clsdbo_NewFactCurrencyRate.CurrencyDate = null;
			    } else {
			    	clsdbo_NewFactCurrencyRate.CurrencyDate = System.Convert.ToDateTime(txtCurrencyDate.Text); }
			    if (string.IsNullOrEmpty(txtEndOfDayRate.Text)) {
			    	clsdbo_NewFactCurrencyRate.EndOfDayRate = null;
			    } else {
			    	clsdbo_NewFactCurrencyRate.EndOfDayRate = System.Convert.ToDecimal(txtEndOfDayRate.Text); }
			    if (string.IsNullOrEmpty(txtCurrencyKey.Text)) {
			    	clsdbo_NewFactCurrencyRate.CurrencyKey = null;
			    } else {
			    	clsdbo_NewFactCurrencyRate.CurrencyKey = System.Convert.ToInt32(txtCurrencyKey.Text); }
			    if (string.IsNullOrEmpty(txtDateKey.Text)) {
			    	clsdbo_NewFactCurrencyRate.DateKey = null;
			    } else {
			    	clsdbo_NewFactCurrencyRate.DateKey = System.Convert.ToInt32(txtDateKey.Text); }
        }

        private void InsertRecord()
        {
		    dbo_NewFactCurrencyRateClass clsdbo_NewFactCurrencyRate = new dbo_NewFactCurrencyRateClass();
		    if (VerifyData() == true) {
                            SetData(clsdbo_NewFactCurrencyRate);
			    bool bSucess = false;
			    bSucess = dbo_NewFactCurrencyRateDataClass.Add(clsdbo_NewFactCurrencyRate);
			    if (bSucess == true) {
				    pnlForm.Visible = false;
				    pnlSave.Visible = false;
				    pnlGrid.Visible = true;
				    lblMode.InnerText = "";
				    Session.Remove("dvdbo_NewFactCurrencyRate");
				    LoadGriddbo_NewFactCurrencyRate();
			    } else {
				    ec.ShowMessage(" Insert failed. ", " Dbo. New Fact Currency Rate ");
			    }
		    }
        }

        private void UpdateRecord()
        {
		    dbo_NewFactCurrencyRateClass oclsdbo_NewFactCurrencyRate = new dbo_NewFactCurrencyRateClass();
		    dbo_NewFactCurrencyRateClass clsdbo_NewFactCurrencyRate = new dbo_NewFactCurrencyRateClass();

		    oclsdbo_NewFactCurrencyRate.AverageRate = System.Convert.ToDecimal(Session["AverageRate"]);
		    oclsdbo_NewFactCurrencyRate = dbo_NewFactCurrencyRateDataClass.Select_Record(oclsdbo_NewFactCurrencyRate);

		    if (VerifyData() == true) {
                            SetData(clsdbo_NewFactCurrencyRate);
			    bool bSucess = false;
			    bSucess = dbo_NewFactCurrencyRateDataClass.Update(oclsdbo_NewFactCurrencyRate, clsdbo_NewFactCurrencyRate);
			    if (bSucess == true) {
				    pnlForm.Visible = false;
				    pnlSave.Visible = false;
				    pnlGrid.Visible = true;
				    lblMode.InnerText = "";
				    Session.Remove("dvdbo_NewFactCurrencyRate");
				    LoadGriddbo_NewFactCurrencyRate();
			    } else {
				    ec.ShowMessage(" Update failed. ", " Dbo. New Fact Currency Rate ");
			    }
		    }
        }

        private void DeleteRecord()
        {
		    dbo_NewFactCurrencyRateClass clsdbo_NewFactCurrencyRate = new dbo_NewFactCurrencyRateClass();
		    clsdbo_NewFactCurrencyRate.AverageRate = System.Convert.ToDecimal(Session["AverageRate"]);
                    SetData(clsdbo_NewFactCurrencyRate);
		    bool bSucess = false;
		    bSucess = dbo_NewFactCurrencyRateDataClass.Delete(clsdbo_NewFactCurrencyRate);
		    if (bSucess == true) {
			    pnlForm.Visible = false;
			    pnlSave.Visible = false;
			    pnlGrid.Visible = true;
			    pnlDelete.Visible = false;
			    lblMode.InnerText = "";
			    Session.Remove("dvdbo_NewFactCurrencyRate");
			    LoadGriddbo_NewFactCurrencyRate();
		    } else {
			    ec.ShowMessage(" Delete failed. ", " Dbo. New Fact Currency Rate ");
		    }
        }

        private Boolean VerifyData()
        {
            if (
            txtAverageRate.Text != "" 
            )  {
            dbo_NewFactCurrencyRateClass clsdbo_NewFactCurrencyRate = new dbo_NewFactCurrencyRateClass();
            clsdbo_NewFactCurrencyRate.AverageRate = System.Convert.ToDecimal(txtAverageRate.Text);
            clsdbo_NewFactCurrencyRate = dbo_NewFactCurrencyRateDataClass.Select_Record(clsdbo_NewFactCurrencyRate);
		    if (clsdbo_NewFactCurrencyRate != null && (String)Session["Mode"] == "Add") {
                    	ec.ShowMessage(" Record already exists. ", " Dbo. New Fact Currency Rate ");
                   	txtAverageRate.Focus();
                	return false; }
            }
		    return true;
        }

        public void butRecords_Click(object sender, System.EventArgs e)
        {
		    grddbo_NewFactCurrencyRate.CurrentPageIndex = 0;
		    grddbo_NewFactCurrencyRate.PageSize = Convert.ToInt32(cmbRecords.Text);
		    LoadGriddbo_NewFactCurrencyRate();
        }

        public void btnAddNew_Click(object sender, System.EventArgs e)
        {
		    if (pnlForm.Visible) {
			    txtAverageRate.Text = "";
			    txtCurrencyID.Text = "";
			    txtCurrencyDate.Text = "";
			    txtEndOfDayRate.Text = "";
			    txtCurrencyKey.Text = "";
			    txtDateKey.Text = "";
		    } else {
			    pnlForm.Visible = true;
			    pnlGrid.Visible = false;
			    pnlSave.Visible = true;
			    lblMode.InnerText = "Add new";
		    }
		    btnSave.CommandArgument = "Add";
		    Add();
        }

        public void grddbo_NewFactCurrencyRate_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
        { 
		    if (e.Item.ItemType == ListItemType.Pager | e.Item.ItemType == ListItemType.Header)
			    return;

		    Button btn = (Button)e.CommandSource;
		    if (btn.Text == "Edit" | btn.Text == "Delete") {
			    Session.Remove("AverageRate");
			    Session["AverageRate"] = e.Item.Cells[0 + 0].Text;
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

        public void grddbo_NewFactCurrencyRate_SortCommand(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
        {
		    htmlHiddenSortExpression.Value = e.SortExpression + " " + GetSortDirection(e.SortExpression);
		    LoadGriddbo_NewFactCurrencyRate();
        }

        public void grddbo_NewFactCurrencyRate_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
        {
		    grddbo_NewFactCurrencyRate.CurrentPageIndex = e.NewPageIndex;
		    LoadGriddbo_NewFactCurrencyRate();
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
		    Session.Remove("dvdbo_NewFactCurrencyRate");
		    LoadGriddbo_NewFactCurrencyRate();
        }

        public void butSearch_Click(object sender, System.EventArgs e)
        {
		    try {
                        Session.Remove("dvdbo_NewFactCurrencyRate");
			if ((Session["dvdbo_NewFactCurrencyRate"] != null)) {
				dvdbo_NewFactCurrencyRate = (DataView)Session["dvdbo_NewFactCurrencyRate"];
				// DataView was not found in the session.
		    	} else {
				dvdbo_NewFactCurrencyRate = dbo_NewFactCurrencyRateDataClass.Search(cmbFields.Text, cmbCondition.Text, txtSearch.Text).DefaultView;
			    	Session["dvdbo_NewFactCurrencyRate"] = dvdbo_NewFactCurrencyRate;
		    	}
                if (dvdbo_NewFactCurrencyRate.Count > 0)
                {
                    dvdbo_NewFactCurrencyRate.Sort = htmlHiddenSortExpression.Value;
                    grddbo_NewFactCurrencyRate.DataSource = dvdbo_NewFactCurrencyRate;
                    grddbo_NewFactCurrencyRate.DataBind();
                }
                else
                {
                    grddbo_NewFactCurrencyRate.DataSource = null;
                    grddbo_NewFactCurrencyRate.DataBind();
                }
		    }
		    catch (Exception ex)
		    {
		    	ec.ShowMessage(ex.Message, " Dbo. New Fact Currency Rate ");
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
                    { dt = dbo_NewFactCurrencyRateDataClass.Search(cmbFields.Text, cmbCondition.Text, txtSearch.Text); }
                    else { dt = dbo_NewFactCurrencyRateDataClass.SelectAll(); }

                    PDFform pdfForm = new PDFform(dt, "Dbo. New Fact Currency Rate", "Many");
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
                    GVExport.DataSource = Session["dvdbo_NewFactCurrencyRate"];
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
 
