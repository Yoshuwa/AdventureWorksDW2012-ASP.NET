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
    public partial class frmdbo_DimProductSubcategory : System.Web.UI.Page
    {

        private dbo_DimProductSubcategoryDataClass clsdbo_DimProductSubcategoryData = new dbo_DimProductSubcategoryDataClass();
        private AdventureWorksDW2012DataClass clsAdventureWorksDW2012Data = new AdventureWorksDW2012DataClass();
        private DataView dvdbo_DimProductSubcategory;

        protected void Page_Load(object sender, EventArgs e)
        {
		    if (!Page.IsPostBack) {
			    Session["Mode"] = "";
 			    Session["ProductSubcategoryKey"] = "";

			    Session.Remove("dvdbo_DimProductSubcategory");

                            cmbFields.Items.Add("Product Subcategory Key");
                            cmbFields.Items.Add("Product Subcategory Alternate Key");
                            cmbFields.Items.Add("English Product Subcategory Name");
                            cmbFields.Items.Add("Spanish Product Subcategory Name");
                            cmbFields.Items.Add("French Product Subcategory Name");
                            cmbFields.Items.Add("Product Category Key");

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

            Loaddbo_DimProductSubcategory_dbo_DimProductCategoryComboBox();

			    LoadGriddbo_DimProductSubcategory();
		    }

        }


	    private void Loaddbo_DimProductSubcategory_dbo_DimProductCategoryComboBox()
	    {
		    List<dbo_DimProductSubcategory_dbo_DimProductCategoryClass> dbo_DimProductSubcategory_dbo_DimProductCategoryList = new  List<dbo_DimProductSubcategory_dbo_DimProductCategoryClass>();
		    try {
			    dbo_DimProductSubcategory_dbo_DimProductCategoryList = dbo_DimProductSubcategory_dbo_DimProductCategoryDataClass.List();
			    txtProductCategoryKey.DataSource = dbo_DimProductSubcategory_dbo_DimProductCategoryList;
			    txtProductCategoryKey.DataValueField = "ProductCategoryKey";
			    txtProductCategoryKey.DataTextField = "EnglishProductCategoryName";
			    txtProductCategoryKey.DataBind();
		    }
		    catch (Exception ex)
		    {
		    	ec.ShowMessage(ex.Message, " Dbo. Dim Product Subcategory ");
		    }
	    }

        private void LoadGriddbo_DimProductSubcategory()
        {
		    try {
			if ((Session["dvdbo_DimProductSubcategory"] != null)) {
				dvdbo_DimProductSubcategory = (DataView)Session["dvdbo_DimProductSubcategory"];
				// DataView was not found in the session.
		    	} else {
				dvdbo_DimProductSubcategory = dbo_DimProductSubcategoryDataClass.SelectAll().DefaultView;
			    	Session["dvdbo_DimProductSubcategory"] = dvdbo_DimProductSubcategory;
		    	}
                if (dvdbo_DimProductSubcategory.Count > 0)
                {
                    dvdbo_DimProductSubcategory.Sort = htmlHiddenSortExpression.Value;
                    grddbo_DimProductSubcategory.DataSource = dvdbo_DimProductSubcategory;
                    grddbo_DimProductSubcategory.DataBind();
                }
                else
                {
                    grddbo_DimProductSubcategory.DataSource = null;
                    grddbo_DimProductSubcategory.DataBind();
                }
		    }
		    catch (Exception ex)
		    {
		    	ec.ShowMessage(ex.Message, " Dbo. Dim Product Subcategory ");
		    }
        }

        private void Add()
        {
		    Session.Remove("Mode");
		    Session["Mode"] = "Add";

		    ClearRecord();

		    this.txtProductSubcategoryAlternateKey.Enabled = true;
		    this.txtEnglishProductSubcategoryName.Enabled = true;
		    this.txtSpanishProductSubcategoryName.Enabled = true;
		    this.txtFrenchProductSubcategoryName.Enabled = true;
		    this.txtProductCategoryKey.Enabled = true;
		    txtProductSubcategoryKey.Enabled = false;
		    txtProductSubcategoryAlternateKey.Focus();
		    txtProductSubcategoryKey.Text = Convert.ToString(clsAdventureWorksDW2012Data.getAutoID("New", "DimProductSubcategory"));
        }

        private void GetData()
        {
		    ClearRecord();

		    dbo_DimProductSubcategoryClass clsdbo_DimProductSubcategory = new dbo_DimProductSubcategoryClass();
		    clsdbo_DimProductSubcategory.ProductSubcategoryKey = System.Convert.ToInt32(Session["ProductSubcategoryKey"]);
		    clsdbo_DimProductSubcategory = dbo_DimProductSubcategoryDataClass.Select_Record(clsdbo_DimProductSubcategory);

		    if ((clsdbo_DimProductSubcategory != null)) {
			    try {
                		txtProductSubcategoryKey.Text = System.Convert.ToString(clsdbo_DimProductSubcategory.ProductSubcategoryKey);
                		if (clsdbo_DimProductSubcategory.ProductSubcategoryAlternateKey == null) { txtProductSubcategoryAlternateKey.Text = default(string); } else { txtProductSubcategoryAlternateKey.Text = System.Convert.ToString(clsdbo_DimProductSubcategory.ProductSubcategoryAlternateKey); }
                		txtEnglishProductSubcategoryName.Text = System.Convert.ToString(clsdbo_DimProductSubcategory.EnglishProductSubcategoryName);
                		txtSpanishProductSubcategoryName.Text = System.Convert.ToString(clsdbo_DimProductSubcategory.SpanishProductSubcategoryName);
                		txtFrenchProductSubcategoryName.Text = System.Convert.ToString(clsdbo_DimProductSubcategory.FrenchProductSubcategoryName);
                		if (clsdbo_DimProductSubcategory.ProductCategoryKey == null) { txtProductCategoryKey.SelectedValue = default(string); } else { txtProductCategoryKey.SelectedValue = System.Convert.ToString(clsdbo_DimProductSubcategory.ProductCategoryKey); }
		   	 }
		    	catch (Exception ex)
		    	{
		    		ec.ShowMessage(ex.Message, " Dbo. Dim Product Subcategory ");
		    	}
		    }

        }

        private void Edit()
        {
		    Session.Remove("Mode");
		    Session["Mode"] = "Edit";

                    GetData();

		    txtProductSubcategoryAlternateKey.Enabled = true;
		    txtEnglishProductSubcategoryName.Enabled = true;
		    txtSpanishProductSubcategoryName.Enabled = true;
		    txtFrenchProductSubcategoryName.Enabled = true;
		    txtProductCategoryKey.Enabled = true;
		    txtProductSubcategoryKey.Enabled = false;
		    txtProductSubcategoryAlternateKey.Focus();
        }

        private void Delete()
        {
		    Session.Remove("Mode");
		    Session["Mode"] = "Delete";

                    GetData();

		    txtProductSubcategoryKey.Enabled = false;
		    txtProductSubcategoryAlternateKey.Enabled = false;
		    txtEnglishProductSubcategoryName.Enabled = false;
		    txtSpanishProductSubcategoryName.Enabled = false;
		    txtFrenchProductSubcategoryName.Enabled = false;
		    txtProductCategoryKey.Enabled = false;
        }

        private void ClearRecord()
        {
	        txtProductSubcategoryKey.Text = null;
	        txtProductSubcategoryAlternateKey.Text = null;
	        txtEnglishProductSubcategoryName.Text = null;
	        txtSpanishProductSubcategoryName.Text = null;
	        txtFrenchProductSubcategoryName.Text = null;
	        txtProductCategoryKey.SelectedIndex = -1;
        }

        public void btnSave_Click(object sender, System.EventArgs e)
        {
		    if ((String)Session["Mode"] == "Add") {
			    this.InsertRecord();
		    } else if ((String)Session["Mode"] == "Edit") {
			    this.UpdateRecord();
		    }
        }

        private void SetData(dbo_DimProductSubcategoryClass clsdbo_DimProductSubcategory)
        {
			    if (string.IsNullOrEmpty(txtProductSubcategoryAlternateKey.Text)) {
			    	clsdbo_DimProductSubcategory.ProductSubcategoryAlternateKey = null;
			    } else {
			    	clsdbo_DimProductSubcategory.ProductSubcategoryAlternateKey = System.Convert.ToInt32(txtProductSubcategoryAlternateKey.Text); }
			    clsdbo_DimProductSubcategory.EnglishProductSubcategoryName = System.Convert.ToString(txtEnglishProductSubcategoryName.Text);
			    clsdbo_DimProductSubcategory.SpanishProductSubcategoryName = System.Convert.ToString(txtSpanishProductSubcategoryName.Text);
			    clsdbo_DimProductSubcategory.FrenchProductSubcategoryName = System.Convert.ToString(txtFrenchProductSubcategoryName.Text);
			    if (string.IsNullOrEmpty(txtProductCategoryKey.SelectedValue)) {
			    	clsdbo_DimProductSubcategory.ProductCategoryKey = null;
			    } else {
			    	clsdbo_DimProductSubcategory.ProductCategoryKey = System.Convert.ToInt32(txtProductCategoryKey.SelectedValue); }
        }

        private void InsertRecord()
        {
		    dbo_DimProductSubcategoryClass clsdbo_DimProductSubcategory = new dbo_DimProductSubcategoryClass();
		    if (VerifyData() == true) {
                            SetData(clsdbo_DimProductSubcategory);
			    bool bSucess = false;
			    bSucess = dbo_DimProductSubcategoryDataClass.Add(clsdbo_DimProductSubcategory);
			    if (bSucess == true) {
				    pnlForm.Visible = false;
				    pnlSave.Visible = false;
				    pnlGrid.Visible = true;
				    lblMode.InnerText = "";
				    Session.Remove("dvdbo_DimProductSubcategory");
				    LoadGriddbo_DimProductSubcategory();
			    } else {
				    ec.ShowMessage(" Insert failed. ", " Dbo. Dim Product Subcategory ");
			    }
		    }
        }

        private void UpdateRecord()
        {
		    dbo_DimProductSubcategoryClass oclsdbo_DimProductSubcategory = new dbo_DimProductSubcategoryClass();
		    dbo_DimProductSubcategoryClass clsdbo_DimProductSubcategory = new dbo_DimProductSubcategoryClass();

		    oclsdbo_DimProductSubcategory.ProductSubcategoryKey = System.Convert.ToInt32(Session["ProductSubcategoryKey"]);
		    oclsdbo_DimProductSubcategory = dbo_DimProductSubcategoryDataClass.Select_Record(oclsdbo_DimProductSubcategory);

		    if (VerifyData() == true) {
                            SetData(clsdbo_DimProductSubcategory);
			    bool bSucess = false;
			    bSucess = dbo_DimProductSubcategoryDataClass.Update(oclsdbo_DimProductSubcategory, clsdbo_DimProductSubcategory);
			    if (bSucess == true) {
				    pnlForm.Visible = false;
				    pnlSave.Visible = false;
				    pnlGrid.Visible = true;
				    lblMode.InnerText = "";
				    Session.Remove("dvdbo_DimProductSubcategory");
				    LoadGriddbo_DimProductSubcategory();
			    } else {
				    ec.ShowMessage(" Update failed. ", " Dbo. Dim Product Subcategory ");
			    }
		    }
        }

        private void DeleteRecord()
        {
		    dbo_DimProductSubcategoryClass clsdbo_DimProductSubcategory = new dbo_DimProductSubcategoryClass();
		    clsdbo_DimProductSubcategory.ProductSubcategoryKey = System.Convert.ToInt32(Session["ProductSubcategoryKey"]);
                    SetData(clsdbo_DimProductSubcategory);
		    bool bSucess = false;
		    bSucess = dbo_DimProductSubcategoryDataClass.Delete(clsdbo_DimProductSubcategory);
		    if (bSucess == true) {
			    pnlForm.Visible = false;
			    pnlSave.Visible = false;
			    pnlGrid.Visible = true;
			    pnlDelete.Visible = false;
			    lblMode.InnerText = "";
			    Session.Remove("dvdbo_DimProductSubcategory");
			    LoadGriddbo_DimProductSubcategory();
		    } else {
			    ec.ShowMessage(" Delete failed. ", " Dbo. Dim Product Subcategory ");
		    }
        }

        private Boolean VerifyData()
        {
		    if (txtEnglishProductSubcategoryName.Text == "") {
		    	ec.ShowMessage(" English Product Subcategory Name is Required. ", " Dbo. Dim Product Subcategory ");
	                txtEnglishProductSubcategoryName.Focus();
                	return false;}
		    if (txtSpanishProductSubcategoryName.Text == "") {
		    	ec.ShowMessage(" Spanish Product Subcategory Name is Required. ", " Dbo. Dim Product Subcategory ");
	                txtSpanishProductSubcategoryName.Focus();
                	return false;}
		    if (txtFrenchProductSubcategoryName.Text == "") {
		    	ec.ShowMessage(" French Product Subcategory Name is Required. ", " Dbo. Dim Product Subcategory ");
	                txtFrenchProductSubcategoryName.Focus();
                	return false;}
		    return true;
        }

        public void butRecords_Click(object sender, System.EventArgs e)
        {
		    grddbo_DimProductSubcategory.CurrentPageIndex = 0;
		    grddbo_DimProductSubcategory.PageSize = Convert.ToInt32(cmbRecords.Text);
		    LoadGriddbo_DimProductSubcategory();
        }

        public void btnAddNew_Click(object sender, System.EventArgs e)
        {
		    if (pnlForm.Visible) {
			    txtProductSubcategoryKey.Text = "";
			    txtProductSubcategoryAlternateKey.Text = "";
			    txtEnglishProductSubcategoryName.Text = "";
			    txtSpanishProductSubcategoryName.Text = "";
			    txtFrenchProductSubcategoryName.Text = "";
			    txtProductCategoryKey.SelectedIndex = -1;
		    } else {
			    pnlForm.Visible = true;
			    pnlGrid.Visible = false;
			    pnlSave.Visible = true;
			    lblMode.InnerText = "Add new";
		    }
		    btnSave.CommandArgument = "Add";
		    Add();
        }

        public void grddbo_DimProductSubcategory_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
        { 
		    if (e.Item.ItemType == ListItemType.Pager | e.Item.ItemType == ListItemType.Header)
			    return;

		    Button btn = (Button)e.CommandSource;
		    if (btn.Text == "Edit" | btn.Text == "Delete") {
			    Session.Remove("ProductSubcategoryKey");
			    Session["ProductSubcategoryKey"] = e.Item.Cells[0 + 0].Text;
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

        public void grddbo_DimProductSubcategory_SortCommand(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
        {
		    htmlHiddenSortExpression.Value = e.SortExpression + " " + GetSortDirection(e.SortExpression);
		    LoadGriddbo_DimProductSubcategory();
        }

        public void grddbo_DimProductSubcategory_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
        {
		    grddbo_DimProductSubcategory.CurrentPageIndex = e.NewPageIndex;
		    LoadGriddbo_DimProductSubcategory();
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
		    Session.Remove("dvdbo_DimProductSubcategory");
		    LoadGriddbo_DimProductSubcategory();
        }

        public void butSearch_Click(object sender, System.EventArgs e)
        {
		    try {
                        Session.Remove("dvdbo_DimProductSubcategory");
			if ((Session["dvdbo_DimProductSubcategory"] != null)) {
				dvdbo_DimProductSubcategory = (DataView)Session["dvdbo_DimProductSubcategory"];
				// DataView was not found in the session.
		    	} else {
				dvdbo_DimProductSubcategory = dbo_DimProductSubcategoryDataClass.Search(cmbFields.Text, cmbCondition.Text, txtSearch.Text).DefaultView;
			    	Session["dvdbo_DimProductSubcategory"] = dvdbo_DimProductSubcategory;
		    	}
                if (dvdbo_DimProductSubcategory.Count > 0)
                {
                    dvdbo_DimProductSubcategory.Sort = htmlHiddenSortExpression.Value;
                    grddbo_DimProductSubcategory.DataSource = dvdbo_DimProductSubcategory;
                    grddbo_DimProductSubcategory.DataBind();
                }
                else
                {
                    grddbo_DimProductSubcategory.DataSource = null;
                    grddbo_DimProductSubcategory.DataBind();
                }
		    }
		    catch (Exception ex)
		    {
		    	ec.ShowMessage(ex.Message, " Dbo. Dim Product Subcategory ");
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
                    { dt = dbo_DimProductSubcategoryDataClass.Search(cmbFields.Text, cmbCondition.Text, txtSearch.Text); }
                    else { dt = dbo_DimProductSubcategoryDataClass.SelectAll(); }

                    PDFform pdfForm = new PDFform(dt, "Dbo. Dim Product Subcategory", "Many");
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
                    GVExport.DataSource = Session["dvdbo_DimProductSubcategory"];
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
 
