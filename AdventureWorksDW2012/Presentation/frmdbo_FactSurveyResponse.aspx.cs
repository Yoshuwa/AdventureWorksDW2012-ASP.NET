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
    public partial class frmdbo_FactSurveyResponse : System.Web.UI.Page
    {

        private dbo_FactSurveyResponseDataClass clsdbo_FactSurveyResponseData = new dbo_FactSurveyResponseDataClass();
        private AdventureWorksDW2012DataClass clsAdventureWorksDW2012Data = new AdventureWorksDW2012DataClass();
        private DataView dvdbo_FactSurveyResponse;

        protected void Page_Load(object sender, EventArgs e)
        {
		    if (!Page.IsPostBack) {
			    Session["Mode"] = "";
 			    Session["SurveyResponseKey"] = "";

			    Session.Remove("dvdbo_FactSurveyResponse");

                            cmbFields.Items.Add("Survey Response Key");
                            cmbFields.Items.Add("Date Key");
                            cmbFields.Items.Add("Customer Key");
                            cmbFields.Items.Add("Product Category Key");
                            cmbFields.Items.Add("English Product Category Name");
                            cmbFields.Items.Add("Product Subcategory Key");
                            cmbFields.Items.Add("English Product Subcategory Name");
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

            Loaddbo_FactSurveyResponse_dbo_DimDateComboBox307();
            Loaddbo_FactSurveyResponse_dbo_DimCustomerComboBox308();

			    LoadGriddbo_FactSurveyResponse();
		    }

        }


	    private void Loaddbo_FactSurveyResponse_dbo_DimDateComboBox307()
	    {
		    List<dbo_FactSurveyResponse_dbo_DimDateClass307> dbo_FactSurveyResponse_dbo_DimDateList = new  List<dbo_FactSurveyResponse_dbo_DimDateClass307>();
		    try {
			    dbo_FactSurveyResponse_dbo_DimDateList = dbo_FactSurveyResponse_dbo_DimDateDataClass307.List();
			    txtDateKey.DataSource = dbo_FactSurveyResponse_dbo_DimDateList;
			    txtDateKey.DataValueField = "DateKey";
			    txtDateKey.DataTextField = "DateKey";
			    txtDateKey.DataBind();
		    }
		    catch (Exception ex)
		    {
		    	ec.ShowMessage(ex.Message, " Dbo. Fact Survey Response ");
		    }
	    }

	    private void Loaddbo_FactSurveyResponse_dbo_DimCustomerComboBox308()
	    {
		    List<dbo_FactSurveyResponse_dbo_DimCustomerClass308> dbo_FactSurveyResponse_dbo_DimCustomerList = new  List<dbo_FactSurveyResponse_dbo_DimCustomerClass308>();
		    try {
			    dbo_FactSurveyResponse_dbo_DimCustomerList = dbo_FactSurveyResponse_dbo_DimCustomerDataClass308.List();
			    txtCustomerKey.DataSource = dbo_FactSurveyResponse_dbo_DimCustomerList;
			    txtCustomerKey.DataValueField = "CustomerKey";
			    txtCustomerKey.DataTextField = "CustomerKey";
			    txtCustomerKey.DataBind();
		    }
		    catch (Exception ex)
		    {
		    	ec.ShowMessage(ex.Message, " Dbo. Fact Survey Response ");
		    }
	    }

        private void LoadGriddbo_FactSurveyResponse()
        {
		    try {
			if ((Session["dvdbo_FactSurveyResponse"] != null)) {
				dvdbo_FactSurveyResponse = (DataView)Session["dvdbo_FactSurveyResponse"];
				// DataView was not found in the session.
		    	} else {
				dvdbo_FactSurveyResponse = dbo_FactSurveyResponseDataClass.SelectAll().DefaultView;
			    	Session["dvdbo_FactSurveyResponse"] = dvdbo_FactSurveyResponse;
		    	}
                if (dvdbo_FactSurveyResponse.Count > 0)
                {
                    dvdbo_FactSurveyResponse.Sort = htmlHiddenSortExpression.Value;
                    grddbo_FactSurveyResponse.DataSource = dvdbo_FactSurveyResponse;
                    grddbo_FactSurveyResponse.DataBind();
                }
                else
                {
                    grddbo_FactSurveyResponse.DataSource = null;
                    grddbo_FactSurveyResponse.DataBind();
                }
		    }
		    catch (Exception ex)
		    {
		    	ec.ShowMessage(ex.Message, " Dbo. Fact Survey Response ");
		    }
        }

        private void Add()
        {
		    Session.Remove("Mode");
		    Session["Mode"] = "Add";

		    ClearRecord();

		    this.txtDateKey.Enabled = true;
		    this.txtCustomerKey.Enabled = true;
		    this.txtProductCategoryKey.Enabled = true;
		    this.txtEnglishProductCategoryName.Enabled = true;
		    this.txtProductSubcategoryKey.Enabled = true;
		    this.txtEnglishProductSubcategoryName.Enabled = true;
		    this.txtDate.Enabled = true;
		    txtSurveyResponseKey.Enabled = false;
		    txtDateKey.Focus();
		    txtSurveyResponseKey.Text = Convert.ToString(clsAdventureWorksDW2012Data.getAutoID("New", "FactSurveyResponse"));
        }

        private void GetData()
        {
		    ClearRecord();

		    dbo_FactSurveyResponseClass clsdbo_FactSurveyResponse = new dbo_FactSurveyResponseClass();
		    clsdbo_FactSurveyResponse.SurveyResponseKey = System.Convert.ToInt32(Session["SurveyResponseKey"]);
		    clsdbo_FactSurveyResponse = dbo_FactSurveyResponseDataClass.Select_Record(clsdbo_FactSurveyResponse);

		    if ((clsdbo_FactSurveyResponse != null)) {
			    try {
                		txtSurveyResponseKey.Text = System.Convert.ToString(clsdbo_FactSurveyResponse.SurveyResponseKey);
                		txtDateKey.SelectedValue = System.Convert.ToString(clsdbo_FactSurveyResponse.DateKey);
                		txtCustomerKey.SelectedValue = System.Convert.ToString(clsdbo_FactSurveyResponse.CustomerKey);
                		txtProductCategoryKey.Text = System.Convert.ToString(clsdbo_FactSurveyResponse.ProductCategoryKey);
                		txtEnglishProductCategoryName.Text = System.Convert.ToString(clsdbo_FactSurveyResponse.EnglishProductCategoryName);
                		txtProductSubcategoryKey.Text = System.Convert.ToString(clsdbo_FactSurveyResponse.ProductSubcategoryKey);
                		txtEnglishProductSubcategoryName.Text = System.Convert.ToString(clsdbo_FactSurveyResponse.EnglishProductSubcategoryName);
                		if (clsdbo_FactSurveyResponse.Date == null) { txtDate.Text = DateTime.Now.ToString(); } else { txtDate.Text = System.Convert.ToDateTime(clsdbo_FactSurveyResponse.Date).ToShortDateString(); }
		   	 }
		    	catch (Exception ex)
		    	{
		    		ec.ShowMessage(ex.Message, " Dbo. Fact Survey Response ");
		    	}
		    }

        }

        private void Edit()
        {
		    Session.Remove("Mode");
		    Session["Mode"] = "Edit";

                    GetData();

		    txtDateKey.Enabled = true;
		    txtCustomerKey.Enabled = true;
		    txtProductCategoryKey.Enabled = true;
		    txtEnglishProductCategoryName.Enabled = true;
		    txtProductSubcategoryKey.Enabled = true;
		    txtEnglishProductSubcategoryName.Enabled = true;
		    txtSurveyResponseKey.Enabled = false;
		    txtDateKey.Focus();
        }

        private void Delete()
        {
		    Session.Remove("Mode");
		    Session["Mode"] = "Delete";

                    GetData();

		    txtSurveyResponseKey.Enabled = false;
		    txtDateKey.Enabled = false;
		    txtCustomerKey.Enabled = false;
		    txtProductCategoryKey.Enabled = false;
		    txtEnglishProductCategoryName.Enabled = false;
		    txtProductSubcategoryKey.Enabled = false;
		    txtEnglishProductSubcategoryName.Enabled = false;
		    txtDate.Enabled = false;
        }

        private void ClearRecord()
        {
	        txtSurveyResponseKey.Text = null;
	        txtDateKey.SelectedIndex = -1;
	        txtCustomerKey.SelectedIndex = -1;
	        txtProductCategoryKey.Text = null;
	        txtEnglishProductCategoryName.Text = null;
	        txtProductSubcategoryKey.Text = null;
	        txtEnglishProductSubcategoryName.Text = null;
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

        private void SetData(dbo_FactSurveyResponseClass clsdbo_FactSurveyResponse)
        {
			    clsdbo_FactSurveyResponse.DateKey = System.Convert.ToInt32(txtDateKey.SelectedValue);
			    clsdbo_FactSurveyResponse.CustomerKey = System.Convert.ToInt32(txtCustomerKey.SelectedValue);
			    clsdbo_FactSurveyResponse.ProductCategoryKey = System.Convert.ToInt32(txtProductCategoryKey.Text);
			    clsdbo_FactSurveyResponse.EnglishProductCategoryName = System.Convert.ToString(txtEnglishProductCategoryName.Text);
			    clsdbo_FactSurveyResponse.ProductSubcategoryKey = System.Convert.ToInt32(txtProductSubcategoryKey.Text);
			    clsdbo_FactSurveyResponse.EnglishProductSubcategoryName = System.Convert.ToString(txtEnglishProductSubcategoryName.Text);
			    if (string.IsNullOrEmpty(txtDate.Text)) {
			    	clsdbo_FactSurveyResponse.Date = null;
			    } else {
			    	clsdbo_FactSurveyResponse.Date = System.Convert.ToDateTime(txtDate.Text); }
        }

        private void InsertRecord()
        {
		    dbo_FactSurveyResponseClass clsdbo_FactSurveyResponse = new dbo_FactSurveyResponseClass();
		    if (VerifyData() == true) {
                            SetData(clsdbo_FactSurveyResponse);
			    bool bSucess = false;
			    bSucess = dbo_FactSurveyResponseDataClass.Add(clsdbo_FactSurveyResponse);
			    if (bSucess == true) {
				    pnlForm.Visible = false;
				    pnlSave.Visible = false;
				    pnlGrid.Visible = true;
				    lblMode.InnerText = "";
				    Session.Remove("dvdbo_FactSurveyResponse");
				    LoadGriddbo_FactSurveyResponse();
			    } else {
				    ec.ShowMessage(" Insert failed. ", " Dbo. Fact Survey Response ");
			    }
		    }
        }

        private void UpdateRecord()
        {
		    dbo_FactSurveyResponseClass oclsdbo_FactSurveyResponse = new dbo_FactSurveyResponseClass();
		    dbo_FactSurveyResponseClass clsdbo_FactSurveyResponse = new dbo_FactSurveyResponseClass();

		    oclsdbo_FactSurveyResponse.SurveyResponseKey = System.Convert.ToInt32(Session["SurveyResponseKey"]);
		    oclsdbo_FactSurveyResponse = dbo_FactSurveyResponseDataClass.Select_Record(oclsdbo_FactSurveyResponse);

		    if (VerifyData() == true) {
                            SetData(clsdbo_FactSurveyResponse);
			    bool bSucess = false;
			    bSucess = dbo_FactSurveyResponseDataClass.Update(oclsdbo_FactSurveyResponse, clsdbo_FactSurveyResponse);
			    if (bSucess == true) {
				    pnlForm.Visible = false;
				    pnlSave.Visible = false;
				    pnlGrid.Visible = true;
				    lblMode.InnerText = "";
				    Session.Remove("dvdbo_FactSurveyResponse");
				    LoadGriddbo_FactSurveyResponse();
			    } else {
				    ec.ShowMessage(" Update failed. ", " Dbo. Fact Survey Response ");
			    }
		    }
        }

        private void DeleteRecord()
        {
		    dbo_FactSurveyResponseClass clsdbo_FactSurveyResponse = new dbo_FactSurveyResponseClass();
		    clsdbo_FactSurveyResponse.SurveyResponseKey = System.Convert.ToInt32(Session["SurveyResponseKey"]);
                    SetData(clsdbo_FactSurveyResponse);
		    bool bSucess = false;
		    bSucess = dbo_FactSurveyResponseDataClass.Delete(clsdbo_FactSurveyResponse);
		    if (bSucess == true) {
			    pnlForm.Visible = false;
			    pnlSave.Visible = false;
			    pnlGrid.Visible = true;
			    pnlDelete.Visible = false;
			    lblMode.InnerText = "";
			    Session.Remove("dvdbo_FactSurveyResponse");
			    LoadGriddbo_FactSurveyResponse();
		    } else {
			    ec.ShowMessage(" Delete failed. ", " Dbo. Fact Survey Response ");
		    }
        }

        private Boolean VerifyData()
        {
		    if (txtDateKey.Text == "") {
		    	ec.ShowMessage(" Date Key is Required. ", " Dbo. Fact Survey Response ");
	                txtDateKey.Focus();
                	return false;}
		    if (txtCustomerKey.Text == "") {
		    	ec.ShowMessage(" Customer Key is Required. ", " Dbo. Fact Survey Response ");
	                txtCustomerKey.Focus();
                	return false;}
		    if (txtProductCategoryKey.Text == "") {
		    	ec.ShowMessage(" Product Category Key is Required. ", " Dbo. Fact Survey Response ");
	                txtProductCategoryKey.Focus();
                	return false;}
		    if (txtEnglishProductCategoryName.Text == "") {
		    	ec.ShowMessage(" English Product Category Name is Required. ", " Dbo. Fact Survey Response ");
	                txtEnglishProductCategoryName.Focus();
                	return false;}
		    if (txtProductSubcategoryKey.Text == "") {
		    	ec.ShowMessage(" Product Subcategory Key is Required. ", " Dbo. Fact Survey Response ");
	                txtProductSubcategoryKey.Focus();
                	return false;}
		    if (txtEnglishProductSubcategoryName.Text == "") {
		    	ec.ShowMessage(" English Product Subcategory Name is Required. ", " Dbo. Fact Survey Response ");
	                txtEnglishProductSubcategoryName.Focus();
                	return false;}
		    return true;
        }

        public void butRecords_Click(object sender, System.EventArgs e)
        {
		    grddbo_FactSurveyResponse.CurrentPageIndex = 0;
		    grddbo_FactSurveyResponse.PageSize = Convert.ToInt32(cmbRecords.Text);
		    LoadGriddbo_FactSurveyResponse();
        }

        public void btnAddNew_Click(object sender, System.EventArgs e)
        {
		    if (pnlForm.Visible) {
			    txtSurveyResponseKey.Text = "";
			    txtDateKey.SelectedIndex = -1;
			    txtCustomerKey.SelectedIndex = -1;
			    txtProductCategoryKey.Text = "";
			    txtEnglishProductCategoryName.Text = "";
			    txtProductSubcategoryKey.Text = "";
			    txtEnglishProductSubcategoryName.Text = "";
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

        public void grddbo_FactSurveyResponse_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
        { 
		    if (e.Item.ItemType == ListItemType.Pager | e.Item.ItemType == ListItemType.Header)
			    return;

		    Button btn = (Button)e.CommandSource;
		    if (btn.Text == "Edit" | btn.Text == "Delete") {
			    Session.Remove("SurveyResponseKey");
			    Session["SurveyResponseKey"] = e.Item.Cells[0 + 0].Text;
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

        public void grddbo_FactSurveyResponse_SortCommand(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
        {
		    htmlHiddenSortExpression.Value = e.SortExpression + " " + GetSortDirection(e.SortExpression);
		    LoadGriddbo_FactSurveyResponse();
        }

        public void grddbo_FactSurveyResponse_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
        {
		    grddbo_FactSurveyResponse.CurrentPageIndex = e.NewPageIndex;
		    LoadGriddbo_FactSurveyResponse();
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
		    Session.Remove("dvdbo_FactSurveyResponse");
		    LoadGriddbo_FactSurveyResponse();
        }

        public void butSearch_Click(object sender, System.EventArgs e)
        {
		    try {
                        Session.Remove("dvdbo_FactSurveyResponse");
			if ((Session["dvdbo_FactSurveyResponse"] != null)) {
				dvdbo_FactSurveyResponse = (DataView)Session["dvdbo_FactSurveyResponse"];
				// DataView was not found in the session.
		    	} else {
				dvdbo_FactSurveyResponse = dbo_FactSurveyResponseDataClass.Search(cmbFields.Text, cmbCondition.Text, txtSearch.Text).DefaultView;
			    	Session["dvdbo_FactSurveyResponse"] = dvdbo_FactSurveyResponse;
		    	}
                if (dvdbo_FactSurveyResponse.Count > 0)
                {
                    dvdbo_FactSurveyResponse.Sort = htmlHiddenSortExpression.Value;
                    grddbo_FactSurveyResponse.DataSource = dvdbo_FactSurveyResponse;
                    grddbo_FactSurveyResponse.DataBind();
                }
                else
                {
                    grddbo_FactSurveyResponse.DataSource = null;
                    grddbo_FactSurveyResponse.DataBind();
                }
		    }
		    catch (Exception ex)
		    {
		    	ec.ShowMessage(ex.Message, " Dbo. Fact Survey Response ");
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
                    { dt = dbo_FactSurveyResponseDataClass.Search(cmbFields.Text, cmbCondition.Text, txtSearch.Text); }
                    else { dt = dbo_FactSurveyResponseDataClass.SelectAll(); }

                    PDFform pdfForm = new PDFform(dt, "Dbo. Fact Survey Response", "Many");
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
                    GVExport.DataSource = Session["dvdbo_FactSurveyResponse"];
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
 
