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
    public partial class frmdbo_DimProductCategory : System.Web.UI.Page
    {

        private dbo_DimProductCategoryDataClass clsdbo_DimProductCategoryData = new dbo_DimProductCategoryDataClass();
        private AdventureWorksDW2012DataClass clsAdventureWorksDW2012Data = new AdventureWorksDW2012DataClass();
        private DataView dvdbo_DimProductCategory;

        protected void Page_Load(object sender, EventArgs e)
        {
		    if (!Page.IsPostBack) {
			    Session["Mode"] = "";
 			    Session["ProductCategoryKey"] = "";

			    Session.Remove("dvdbo_DimProductCategory");

                            cmbFields.Items.Add("Product Category Key");
                            cmbFields.Items.Add("Product Category Alternate Key");
                            cmbFields.Items.Add("English Product Category Name");
                            cmbFields.Items.Add("Spanish Product Category Name");
                            cmbFields.Items.Add("French Product Category Name");

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


			    LoadGriddbo_DimProductCategory();
		    }

        }


        private void LoadGriddbo_DimProductCategory()
        {
		    try {
			if ((Session["dvdbo_DimProductCategory"] != null)) {
				dvdbo_DimProductCategory = (DataView)Session["dvdbo_DimProductCategory"];
				// DataView was not found in the session.
		    	} else {
				dvdbo_DimProductCategory = dbo_DimProductCategoryDataClass.SelectAll().DefaultView;
			    	Session["dvdbo_DimProductCategory"] = dvdbo_DimProductCategory;
		    	}
                if (dvdbo_DimProductCategory.Count > 0)
                {
                    dvdbo_DimProductCategory.Sort = htmlHiddenSortExpression.Value;
                    grddbo_DimProductCategory.DataSource = dvdbo_DimProductCategory;
                    grddbo_DimProductCategory.DataBind();
                }
                else
                {
                    grddbo_DimProductCategory.DataSource = null;
                    grddbo_DimProductCategory.DataBind();
                }
		    }
		    catch (Exception ex)
		    {
		    	ec.ShowMessage(ex.Message, " Dbo. Dim Product Category ");
		    }
        }

        private void Add()
        {
		    Session.Remove("Mode");
		    Session["Mode"] = "Add";

		    ClearRecord();

		    this.txtProductCategoryAlternateKey.Enabled = true;
		    this.txtEnglishProductCategoryName.Enabled = true;
		    this.txtSpanishProductCategoryName.Enabled = true;
		    this.txtFrenchProductCategoryName.Enabled = true;
		    txtProductCategoryKey.Enabled = false;
		    txtProductCategoryAlternateKey.Focus();
		    txtProductCategoryKey.Text = Convert.ToString(clsAdventureWorksDW2012Data.getAutoID("New", "DimProductCategory"));
        }

        private void GetData()
        {
		    ClearRecord();

		    dbo_DimProductCategoryClass clsdbo_DimProductCategory = new dbo_DimProductCategoryClass();
		    clsdbo_DimProductCategory.ProductCategoryKey = System.Convert.ToInt32(Session["ProductCategoryKey"]);
		    clsdbo_DimProductCategory = dbo_DimProductCategoryDataClass.Select_Record(clsdbo_DimProductCategory);

		    if ((clsdbo_DimProductCategory != null)) {
			    try {
                		txtProductCategoryKey.Text = System.Convert.ToString(clsdbo_DimProductCategory.ProductCategoryKey);
                		if (clsdbo_DimProductCategory.ProductCategoryAlternateKey == null) { txtProductCategoryAlternateKey.Text = default(string); } else { txtProductCategoryAlternateKey.Text = System.Convert.ToString(clsdbo_DimProductCategory.ProductCategoryAlternateKey); }
                		txtEnglishProductCategoryName.Text = System.Convert.ToString(clsdbo_DimProductCategory.EnglishProductCategoryName);
                		txtSpanishProductCategoryName.Text = System.Convert.ToString(clsdbo_DimProductCategory.SpanishProductCategoryName);
                		txtFrenchProductCategoryName.Text = System.Convert.ToString(clsdbo_DimProductCategory.FrenchProductCategoryName);
		   	 }
		    	catch (Exception ex)
		    	{
		    		ec.ShowMessage(ex.Message, " Dbo. Dim Product Category ");
		    	}
		    }

        }

        private void Edit()
        {
		    Session.Remove("Mode");
		    Session["Mode"] = "Edit";

                    GetData();

		    txtProductCategoryAlternateKey.Enabled = true;
		    txtEnglishProductCategoryName.Enabled = true;
		    txtSpanishProductCategoryName.Enabled = true;
		    txtFrenchProductCategoryName.Enabled = true;
		    txtProductCategoryKey.Enabled = false;
		    txtProductCategoryAlternateKey.Focus();
        }

        private void Delete()
        {
		    Session.Remove("Mode");
		    Session["Mode"] = "Delete";

                    GetData();

		    txtProductCategoryKey.Enabled = false;
		    txtProductCategoryAlternateKey.Enabled = false;
		    txtEnglishProductCategoryName.Enabled = false;
		    txtSpanishProductCategoryName.Enabled = false;
		    txtFrenchProductCategoryName.Enabled = false;
        }

        private void ClearRecord()
        {
	        txtProductCategoryKey.Text = null;
	        txtProductCategoryAlternateKey.Text = null;
	        txtEnglishProductCategoryName.Text = null;
	        txtSpanishProductCategoryName.Text = null;
	        txtFrenchProductCategoryName.Text = null;
        }

        public void btnSave_Click(object sender, System.EventArgs e)
        {
		    if ((String)Session["Mode"] == "Add") {
			    this.InsertRecord();
		    } else if ((String)Session["Mode"] == "Edit") {
			    this.UpdateRecord();
		    }
        }

        private void SetData(dbo_DimProductCategoryClass clsdbo_DimProductCategory)
        {
			    if (string.IsNullOrEmpty(txtProductCategoryAlternateKey.Text)) {
			    	clsdbo_DimProductCategory.ProductCategoryAlternateKey = null;
			    } else {
			    	clsdbo_DimProductCategory.ProductCategoryAlternateKey = System.Convert.ToInt32(txtProductCategoryAlternateKey.Text); }
			    clsdbo_DimProductCategory.EnglishProductCategoryName = System.Convert.ToString(txtEnglishProductCategoryName.Text);
			    clsdbo_DimProductCategory.SpanishProductCategoryName = System.Convert.ToString(txtSpanishProductCategoryName.Text);
			    clsdbo_DimProductCategory.FrenchProductCategoryName = System.Convert.ToString(txtFrenchProductCategoryName.Text);
        }

        private void InsertRecord()
        {
		    dbo_DimProductCategoryClass clsdbo_DimProductCategory = new dbo_DimProductCategoryClass();
		    if (VerifyData() == true) {
                            SetData(clsdbo_DimProductCategory);
			    bool bSucess = false;
			    bSucess = dbo_DimProductCategoryDataClass.Add(clsdbo_DimProductCategory);
			    if (bSucess == true) {
				    pnlForm.Visible = false;
				    pnlSave.Visible = false;
				    pnlGrid.Visible = true;
				    lblMode.InnerText = "";
				    Session.Remove("dvdbo_DimProductCategory");
				    LoadGriddbo_DimProductCategory();
			    } else {
				    ec.ShowMessage(" Insert failed. ", " Dbo. Dim Product Category ");
			    }
		    }
        }

        private void UpdateRecord()
        {
		    dbo_DimProductCategoryClass oclsdbo_DimProductCategory = new dbo_DimProductCategoryClass();
		    dbo_DimProductCategoryClass clsdbo_DimProductCategory = new dbo_DimProductCategoryClass();

		    oclsdbo_DimProductCategory.ProductCategoryKey = System.Convert.ToInt32(Session["ProductCategoryKey"]);
		    oclsdbo_DimProductCategory = dbo_DimProductCategoryDataClass.Select_Record(oclsdbo_DimProductCategory);

		    if (VerifyData() == true) {
                            SetData(clsdbo_DimProductCategory);
			    bool bSucess = false;
			    bSucess = dbo_DimProductCategoryDataClass.Update(oclsdbo_DimProductCategory, clsdbo_DimProductCategory);
			    if (bSucess == true) {
				    pnlForm.Visible = false;
				    pnlSave.Visible = false;
				    pnlGrid.Visible = true;
				    lblMode.InnerText = "";
				    Session.Remove("dvdbo_DimProductCategory");
				    LoadGriddbo_DimProductCategory();
			    } else {
				    ec.ShowMessage(" Update failed. ", " Dbo. Dim Product Category ");
			    }
		    }
        }

        private void DeleteRecord()
        {
		    dbo_DimProductCategoryClass clsdbo_DimProductCategory = new dbo_DimProductCategoryClass();
		    clsdbo_DimProductCategory.ProductCategoryKey = System.Convert.ToInt32(Session["ProductCategoryKey"]);
                    SetData(clsdbo_DimProductCategory);
		    bool bSucess = false;
		    bSucess = dbo_DimProductCategoryDataClass.Delete(clsdbo_DimProductCategory);
		    if (bSucess == true) {
			    pnlForm.Visible = false;
			    pnlSave.Visible = false;
			    pnlGrid.Visible = true;
			    pnlDelete.Visible = false;
			    lblMode.InnerText = "";
			    Session.Remove("dvdbo_DimProductCategory");
			    LoadGriddbo_DimProductCategory();
		    } else {
			    ec.ShowMessage(" Delete failed. ", " Dbo. Dim Product Category ");
		    }
        }

        private Boolean VerifyData()
        {
		    if (txtEnglishProductCategoryName.Text == "") {
		    	ec.ShowMessage(" English Product Category Name is Required. ", " Dbo. Dim Product Category ");
	                txtEnglishProductCategoryName.Focus();
                	return false;}
		    if (txtSpanishProductCategoryName.Text == "") {
		    	ec.ShowMessage(" Spanish Product Category Name is Required. ", " Dbo. Dim Product Category ");
	                txtSpanishProductCategoryName.Focus();
                	return false;}
		    if (txtFrenchProductCategoryName.Text == "") {
		    	ec.ShowMessage(" French Product Category Name is Required. ", " Dbo. Dim Product Category ");
	                txtFrenchProductCategoryName.Focus();
                	return false;}
		    return true;
        }

        public void butRecords_Click(object sender, System.EventArgs e)
        {
		    grddbo_DimProductCategory.CurrentPageIndex = 0;
		    grddbo_DimProductCategory.PageSize = Convert.ToInt32(cmbRecords.Text);
		    LoadGriddbo_DimProductCategory();
        }

        public void btnAddNew_Click(object sender, System.EventArgs e)
        {
		    if (pnlForm.Visible) {
			    txtProductCategoryKey.Text = "";
			    txtProductCategoryAlternateKey.Text = "";
			    txtEnglishProductCategoryName.Text = "";
			    txtSpanishProductCategoryName.Text = "";
			    txtFrenchProductCategoryName.Text = "";
		    } else {
			    pnlForm.Visible = true;
			    pnlGrid.Visible = false;
			    pnlSave.Visible = true;
			    lblMode.InnerText = "Add new";
		    }
		    btnSave.CommandArgument = "Add";
		    Add();
        }

        public void grddbo_DimProductCategory_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
        { 
		    if (e.Item.ItemType == ListItemType.Pager | e.Item.ItemType == ListItemType.Header)
			    return;

		    Button btn = (Button)e.CommandSource;
		    if (btn.Text == "Edit" | btn.Text == "Delete") {
			    Session.Remove("ProductCategoryKey");
			    Session["ProductCategoryKey"] = e.Item.Cells[0 + 0].Text;
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

        public void grddbo_DimProductCategory_SortCommand(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
        {
		    htmlHiddenSortExpression.Value = e.SortExpression + " " + GetSortDirection(e.SortExpression);
		    LoadGriddbo_DimProductCategory();
        }

        public void grddbo_DimProductCategory_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
        {
		    grddbo_DimProductCategory.CurrentPageIndex = e.NewPageIndex;
		    LoadGriddbo_DimProductCategory();
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
		    Session.Remove("dvdbo_DimProductCategory");
		    LoadGriddbo_DimProductCategory();
        }

        public void butSearch_Click(object sender, System.EventArgs e)
        {
		    try {
                        Session.Remove("dvdbo_DimProductCategory");
			if ((Session["dvdbo_DimProductCategory"] != null)) {
				dvdbo_DimProductCategory = (DataView)Session["dvdbo_DimProductCategory"];
				// DataView was not found in the session.
		    	} else {
				dvdbo_DimProductCategory = dbo_DimProductCategoryDataClass.Search(cmbFields.Text, cmbCondition.Text, txtSearch.Text).DefaultView;
			    	Session["dvdbo_DimProductCategory"] = dvdbo_DimProductCategory;
		    	}
                if (dvdbo_DimProductCategory.Count > 0)
                {
                    dvdbo_DimProductCategory.Sort = htmlHiddenSortExpression.Value;
                    grddbo_DimProductCategory.DataSource = dvdbo_DimProductCategory;
                    grddbo_DimProductCategory.DataBind();
                }
                else
                {
                    grddbo_DimProductCategory.DataSource = null;
                    grddbo_DimProductCategory.DataBind();
                }
		    }
		    catch (Exception ex)
		    {
		    	ec.ShowMessage(ex.Message, " Dbo. Dim Product Category ");
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
                    { dt = dbo_DimProductCategoryDataClass.Search(cmbFields.Text, cmbCondition.Text, txtSearch.Text); }
                    else { dt = dbo_DimProductCategoryDataClass.SelectAll(); }

                    PDFform pdfForm = new PDFform(dt, "Dbo. Dim Product Category", "Many");
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
                    GVExport.DataSource = Session["dvdbo_DimProductCategory"];
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
 
