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
    public partial class frmdbo_FactCurrencyRate : System.Web.UI.Page
    {

        private dbo_FactCurrencyRateDataClass clsdbo_FactCurrencyRateData = new dbo_FactCurrencyRateDataClass();
        private AdventureWorksDW2012DataClass clsAdventureWorksDW2012Data = new AdventureWorksDW2012DataClass();
        private DataView dvdbo_FactCurrencyRate;

        protected void Page_Load(object sender, EventArgs e)
        {
		    if (!Page.IsPostBack) {
			    Session["Mode"] = "";
 			    Session["CurrencyKey"] = "";
 			    Session["DateKey"] = "";

			    Session.Remove("dvdbo_FactCurrencyRate");

                            cmbFields.Items.Add("Currency Key");
                            cmbFields.Items.Add("Date Key");
                            cmbFields.Items.Add("Average Rate");
                            cmbFields.Items.Add("End Of Day Rate");
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

            Loaddbo_FactCurrencyRate_dbo_DimCurrencyComboBox223();
            Loaddbo_FactCurrencyRate_dbo_DimDateComboBox224();

			    LoadGriddbo_FactCurrencyRate();
		    }

        }


	    private void Loaddbo_FactCurrencyRate_dbo_DimCurrencyComboBox223()
	    {
		    List<dbo_FactCurrencyRate_dbo_DimCurrencyClass223> dbo_FactCurrencyRate_dbo_DimCurrencyList = new  List<dbo_FactCurrencyRate_dbo_DimCurrencyClass223>();
		    try {
			    dbo_FactCurrencyRate_dbo_DimCurrencyList = dbo_FactCurrencyRate_dbo_DimCurrencyDataClass223.List();
			    txtCurrencyKey.DataSource = dbo_FactCurrencyRate_dbo_DimCurrencyList;
			    txtCurrencyKey.DataValueField = "CurrencyKey";
			    txtCurrencyKey.DataTextField = "CurrencyName";
			    txtCurrencyKey.DataBind();
		    }
		    catch (Exception ex)
		    {
		    	ec.ShowMessage(ex.Message, " Dbo. Fact Currency Rate ");
		    }
	    }

	    private void Loaddbo_FactCurrencyRate_dbo_DimDateComboBox224()
	    {
		    List<dbo_FactCurrencyRate_dbo_DimDateClass224> dbo_FactCurrencyRate_dbo_DimDateList = new  List<dbo_FactCurrencyRate_dbo_DimDateClass224>();
		    try {
			    dbo_FactCurrencyRate_dbo_DimDateList = dbo_FactCurrencyRate_dbo_DimDateDataClass224.List();
			    txtDateKey.DataSource = dbo_FactCurrencyRate_dbo_DimDateList;
			    txtDateKey.DataValueField = "DateKey";
			    txtDateKey.DataTextField = "FullDateAlternateKey";
			    txtDateKey.DataBind();
		    }
		    catch (Exception ex)
		    {
		    	ec.ShowMessage(ex.Message, " Dbo. Fact Currency Rate ");
		    }
	    }

        private void LoadGriddbo_FactCurrencyRate()
        {
		    try {
			if ((Session["dvdbo_FactCurrencyRate"] != null)) {
				dvdbo_FactCurrencyRate = (DataView)Session["dvdbo_FactCurrencyRate"];
				// DataView was not found in the session.
		    	} else {
				dvdbo_FactCurrencyRate = dbo_FactCurrencyRateDataClass.SelectAll().DefaultView;
			    	Session["dvdbo_FactCurrencyRate"] = dvdbo_FactCurrencyRate;
		    	}
                if (dvdbo_FactCurrencyRate.Count > 0)
                {
                    dvdbo_FactCurrencyRate.Sort = htmlHiddenSortExpression.Value;
                    grddbo_FactCurrencyRate.DataSource = dvdbo_FactCurrencyRate;
                    grddbo_FactCurrencyRate.DataBind();
                }
                else
                {
                    grddbo_FactCurrencyRate.DataSource = null;
                    grddbo_FactCurrencyRate.DataBind();
                }
		    }
		    catch (Exception ex)
		    {
		    	ec.ShowMessage(ex.Message, " Dbo. Fact Currency Rate ");
		    }
        }

        private void Add()
        {
		    Session.Remove("Mode");
		    Session["Mode"] = "Add";

		    ClearRecord();

		    this.txtCurrencyKey.Enabled = true;
		    this.txtDateKey.Enabled = true;
		    this.txtAverageRate.Enabled = true;
		    this.txtEndOfDayRate.Enabled = true;
		    this.txtDate.Enabled = true;
		    txtCurrencyKey.Focus();
        }

        private void GetData()
        {
		    ClearRecord();

		    dbo_FactCurrencyRateClass clsdbo_FactCurrencyRate = new dbo_FactCurrencyRateClass();
		    clsdbo_FactCurrencyRate.CurrencyKey = System.Convert.ToInt32(Session["CurrencyKey"]);
		    clsdbo_FactCurrencyRate.DateKey = System.Convert.ToInt32(Session["DateKey"]);
		    clsdbo_FactCurrencyRate = dbo_FactCurrencyRateDataClass.Select_Record(clsdbo_FactCurrencyRate);

		    if ((clsdbo_FactCurrencyRate != null)) {
			    try {
                		txtCurrencyKey.SelectedValue = System.Convert.ToString(clsdbo_FactCurrencyRate.CurrencyKey);
                		txtDateKey.SelectedValue = System.Convert.ToString(clsdbo_FactCurrencyRate.DateKey);
                		txtAverageRate.Text = System.Convert.ToString(clsdbo_FactCurrencyRate.AverageRate);
                		txtEndOfDayRate.Text = System.Convert.ToString(clsdbo_FactCurrencyRate.EndOfDayRate);
                		if (clsdbo_FactCurrencyRate.Date == null) { txtDate.Text = DateTime.Now.ToString(); } else { txtDate.Text = System.Convert.ToDateTime(clsdbo_FactCurrencyRate.Date).ToShortDateString(); }
		   	 }
		    	catch (Exception ex)
		    	{
		    		ec.ShowMessage(ex.Message, " Dbo. Fact Currency Rate ");
		    	}
		    }

        }

        private void Edit()
        {
		    Session.Remove("Mode");
		    Session["Mode"] = "Edit";

                    GetData();

		    txtAverageRate.Enabled = true;
		    txtEndOfDayRate.Enabled = true;
		    txtCurrencyKey.Enabled = false;
		    txtDateKey.Enabled = false;
		    txtAverageRate.Focus();
        }

        private void Delete()
        {
		    Session.Remove("Mode");
		    Session["Mode"] = "Delete";

                    GetData();

		    txtCurrencyKey.Enabled = false;
		    txtDateKey.Enabled = false;
		    txtAverageRate.Enabled = false;
		    txtEndOfDayRate.Enabled = false;
		    txtDate.Enabled = false;
        }

        private void ClearRecord()
        {
	        txtCurrencyKey.SelectedIndex = -1;
	        txtDateKey.SelectedIndex = -1;
	        txtAverageRate.Text = null;
	        txtEndOfDayRate.Text = null;
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

        private void SetData(dbo_FactCurrencyRateClass clsdbo_FactCurrencyRate)
        {
			    clsdbo_FactCurrencyRate.CurrencyKey = System.Convert.ToInt32(txtCurrencyKey.SelectedValue);
			    clsdbo_FactCurrencyRate.DateKey = System.Convert.ToInt32(txtDateKey.SelectedValue);
			    clsdbo_FactCurrencyRate.AverageRate = System.Convert.ToDecimal(txtAverageRate.Text);
			    clsdbo_FactCurrencyRate.EndOfDayRate = System.Convert.ToDecimal(txtEndOfDayRate.Text);
			    if (string.IsNullOrEmpty(txtDate.Text)) {
			    	clsdbo_FactCurrencyRate.Date = null;
			    } else {
			    	clsdbo_FactCurrencyRate.Date = System.Convert.ToDateTime(txtDate.Text); }
        }

        private void InsertRecord()
        {
		    dbo_FactCurrencyRateClass clsdbo_FactCurrencyRate = new dbo_FactCurrencyRateClass();
		    if (VerifyData() == true) {
                            SetData(clsdbo_FactCurrencyRate);
			    bool bSucess = false;
			    bSucess = dbo_FactCurrencyRateDataClass.Add(clsdbo_FactCurrencyRate);
			    if (bSucess == true) {
				    pnlForm.Visible = false;
				    pnlSave.Visible = false;
				    pnlGrid.Visible = true;
				    lblMode.InnerText = "";
				    Session.Remove("dvdbo_FactCurrencyRate");
				    LoadGriddbo_FactCurrencyRate();
			    } else {
				    ec.ShowMessage(" Insert failed. ", " Dbo. Fact Currency Rate ");
			    }
		    }
        }

        private void UpdateRecord()
        {
		    dbo_FactCurrencyRateClass oclsdbo_FactCurrencyRate = new dbo_FactCurrencyRateClass();
		    dbo_FactCurrencyRateClass clsdbo_FactCurrencyRate = new dbo_FactCurrencyRateClass();

		    oclsdbo_FactCurrencyRate.CurrencyKey = System.Convert.ToInt32(Session["CurrencyKey"]);
		    oclsdbo_FactCurrencyRate.DateKey = System.Convert.ToInt32(Session["DateKey"]);
		    oclsdbo_FactCurrencyRate = dbo_FactCurrencyRateDataClass.Select_Record(oclsdbo_FactCurrencyRate);

		    if (VerifyData() == true) {
                            SetData(clsdbo_FactCurrencyRate);
			    bool bSucess = false;
			    bSucess = dbo_FactCurrencyRateDataClass.Update(oclsdbo_FactCurrencyRate, clsdbo_FactCurrencyRate);
			    if (bSucess == true) {
				    pnlForm.Visible = false;
				    pnlSave.Visible = false;
				    pnlGrid.Visible = true;
				    lblMode.InnerText = "";
				    Session.Remove("dvdbo_FactCurrencyRate");
				    LoadGriddbo_FactCurrencyRate();
			    } else {
				    ec.ShowMessage(" Update failed. ", " Dbo. Fact Currency Rate ");
			    }
		    }
        }

        private void DeleteRecord()
        {
		    dbo_FactCurrencyRateClass clsdbo_FactCurrencyRate = new dbo_FactCurrencyRateClass();
		    clsdbo_FactCurrencyRate.CurrencyKey = System.Convert.ToInt32(Session["CurrencyKey"]);
		    clsdbo_FactCurrencyRate.DateKey = System.Convert.ToInt32(Session["DateKey"]);
                    SetData(clsdbo_FactCurrencyRate);
		    bool bSucess = false;
		    bSucess = dbo_FactCurrencyRateDataClass.Delete(clsdbo_FactCurrencyRate);
		    if (bSucess == true) {
			    pnlForm.Visible = false;
			    pnlSave.Visible = false;
			    pnlGrid.Visible = true;
			    pnlDelete.Visible = false;
			    lblMode.InnerText = "";
			    Session.Remove("dvdbo_FactCurrencyRate");
			    LoadGriddbo_FactCurrencyRate();
		    } else {
			    ec.ShowMessage(" Delete failed. ", " Dbo. Fact Currency Rate ");
		    }
        }

        private Boolean VerifyData()
        {
		    if (txtCurrencyKey.Text == "") {
		    	ec.ShowMessage(" Currency Key is Required. ", " Dbo. Fact Currency Rate ");
	                txtCurrencyKey.Focus();
                	return false;}
		    if (txtDateKey.Text == "") {
		    	ec.ShowMessage(" Date Key is Required. ", " Dbo. Fact Currency Rate ");
	                txtDateKey.Focus();
                	return false;}
		    if (txtAverageRate.Text == "") {
		    	ec.ShowMessage(" Average Rate is Required. ", " Dbo. Fact Currency Rate ");
	                txtAverageRate.Focus();
                	return false;}
		    if (txtEndOfDayRate.Text == "") {
		    	ec.ShowMessage(" End Of Day Rate is Required. ", " Dbo. Fact Currency Rate ");
	                txtEndOfDayRate.Focus();
                	return false;}
            if (
            txtCurrencyKey.SelectedIndex != -1 
            && txtDateKey.SelectedIndex != -1 
            )  {
            dbo_FactCurrencyRateClass clsdbo_FactCurrencyRate = new dbo_FactCurrencyRateClass();
            clsdbo_FactCurrencyRate.CurrencyKey = System.Convert.ToInt32(txtCurrencyKey.SelectedValue);
            clsdbo_FactCurrencyRate.DateKey = System.Convert.ToInt32(txtDateKey.SelectedValue);
            clsdbo_FactCurrencyRate = dbo_FactCurrencyRateDataClass.Select_Record(clsdbo_FactCurrencyRate);
		    if (clsdbo_FactCurrencyRate != null && (String)Session["Mode"] == "Add") {
                    	ec.ShowMessage(" Record already exists. ", " Dbo. Fact Currency Rate ");
                   	txtCurrencyKey.Focus();
                	return false; }
            }
		    return true;
        }

        public void butRecords_Click(object sender, System.EventArgs e)
        {
		    grddbo_FactCurrencyRate.CurrentPageIndex = 0;
		    grddbo_FactCurrencyRate.PageSize = Convert.ToInt32(cmbRecords.Text);
		    LoadGriddbo_FactCurrencyRate();
        }

        public void btnAddNew_Click(object sender, System.EventArgs e)
        {
		    if (pnlForm.Visible) {
			    txtCurrencyKey.SelectedIndex = -1;
			    txtDateKey.SelectedIndex = -1;
			    txtAverageRate.Text = "";
			    txtEndOfDayRate.Text = "";
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

        public void grddbo_FactCurrencyRate_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
        { 
		    if (e.Item.ItemType == ListItemType.Pager | e.Item.ItemType == ListItemType.Header)
			    return;

		    Button btn = (Button)e.CommandSource;
		    if (btn.Text == "Edit" | btn.Text == "Delete") {
			    Session.Remove("CurrencyKey");
			    Session["CurrencyKey"] = e.Item.Cells[0 + 0].Text;
			    Session.Remove("DateKey");
			    Session["DateKey"] = e.Item.Cells[1 + 1].Text;
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

        public void grddbo_FactCurrencyRate_SortCommand(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
        {
		    htmlHiddenSortExpression.Value = e.SortExpression + " " + GetSortDirection(e.SortExpression);
		    LoadGriddbo_FactCurrencyRate();
        }

        public void grddbo_FactCurrencyRate_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
        {
		    grddbo_FactCurrencyRate.CurrentPageIndex = e.NewPageIndex;
		    LoadGriddbo_FactCurrencyRate();
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
		    Session.Remove("dvdbo_FactCurrencyRate");
		    LoadGriddbo_FactCurrencyRate();
        }

        public void butSearch_Click(object sender, System.EventArgs e)
        {
		    try {
                        Session.Remove("dvdbo_FactCurrencyRate");
			if ((Session["dvdbo_FactCurrencyRate"] != null)) {
				dvdbo_FactCurrencyRate = (DataView)Session["dvdbo_FactCurrencyRate"];
				// DataView was not found in the session.
		    	} else {
				dvdbo_FactCurrencyRate = dbo_FactCurrencyRateDataClass.Search(cmbFields.Text, cmbCondition.Text, txtSearch.Text).DefaultView;
			    	Session["dvdbo_FactCurrencyRate"] = dvdbo_FactCurrencyRate;
		    	}
                if (dvdbo_FactCurrencyRate.Count > 0)
                {
                    dvdbo_FactCurrencyRate.Sort = htmlHiddenSortExpression.Value;
                    grddbo_FactCurrencyRate.DataSource = dvdbo_FactCurrencyRate;
                    grddbo_FactCurrencyRate.DataBind();
                }
                else
                {
                    grddbo_FactCurrencyRate.DataSource = null;
                    grddbo_FactCurrencyRate.DataBind();
                }
		    }
		    catch (Exception ex)
		    {
		    	ec.ShowMessage(ex.Message, " Dbo. Fact Currency Rate ");
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
                    { dt = dbo_FactCurrencyRateDataClass.Search(cmbFields.Text, cmbCondition.Text, txtSearch.Text); }
                    else { dt = dbo_FactCurrencyRateDataClass.SelectAll(); }

                    PDFform pdfForm = new PDFform(dt, "Dbo. Fact Currency Rate", "Many");
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
                    GVExport.DataSource = Session["dvdbo_FactCurrencyRate"];
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
 
