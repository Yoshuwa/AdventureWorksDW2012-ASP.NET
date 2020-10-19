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
    public partial class frmdbo_DimPromotion : System.Web.UI.Page
    {

        private dbo_DimPromotionDataClass clsdbo_DimPromotionData = new dbo_DimPromotionDataClass();
        private AdventureWorksDW2012DataClass clsAdventureWorksDW2012Data = new AdventureWorksDW2012DataClass();
        private DataView dvdbo_DimPromotion;

        protected void Page_Load(object sender, EventArgs e)
        {
		    if (!Page.IsPostBack) {
			    Session["Mode"] = "";
 			    Session["PromotionKey"] = "";

			    Session.Remove("dvdbo_DimPromotion");

                            cmbFields.Items.Add("Promotion Key");
                            cmbFields.Items.Add("Promotion Alternate Key");
                            cmbFields.Items.Add("English Promotion Name");
                            cmbFields.Items.Add("Spanish Promotion Name");
                            cmbFields.Items.Add("French Promotion Name");
                            cmbFields.Items.Add("Discount Pct");
                            cmbFields.Items.Add("English Promotion Type");
                            cmbFields.Items.Add("Spanish Promotion Type");
                            cmbFields.Items.Add("French Promotion Type");
                            cmbFields.Items.Add("English Promotion Category");
                            cmbFields.Items.Add("Spanish Promotion Category");
                            cmbFields.Items.Add("French Promotion Category");
                            cmbFields.Items.Add("Start Date");
                            cmbFields.Items.Add("End Date");
                            cmbFields.Items.Add("Min Qty");
                            cmbFields.Items.Add("Max Qty");

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


			    LoadGriddbo_DimPromotion();
		    }

        }


        private void LoadGriddbo_DimPromotion()
        {
		    try {
			if ((Session["dvdbo_DimPromotion"] != null)) {
				dvdbo_DimPromotion = (DataView)Session["dvdbo_DimPromotion"];
				// DataView was not found in the session.
		    	} else {
				dvdbo_DimPromotion = dbo_DimPromotionDataClass.SelectAll().DefaultView;
			    	Session["dvdbo_DimPromotion"] = dvdbo_DimPromotion;
		    	}
                if (dvdbo_DimPromotion.Count > 0)
                {
                    dvdbo_DimPromotion.Sort = htmlHiddenSortExpression.Value;
                    grddbo_DimPromotion.DataSource = dvdbo_DimPromotion;
                    grddbo_DimPromotion.DataBind();
                }
                else
                {
                    grddbo_DimPromotion.DataSource = null;
                    grddbo_DimPromotion.DataBind();
                }
		    }
		    catch (Exception ex)
		    {
		    	ec.ShowMessage(ex.Message, " Dbo. Dim Promotion ");
		    }
        }

        private void Add()
        {
		    Session.Remove("Mode");
		    Session["Mode"] = "Add";

		    ClearRecord();

		    this.txtPromotionAlternateKey.Enabled = true;
		    this.txtEnglishPromotionName.Enabled = true;
		    this.txtSpanishPromotionName.Enabled = true;
		    this.txtFrenchPromotionName.Enabled = true;
		    this.txtDiscountPct.Enabled = true;
		    this.txtEnglishPromotionType.Enabled = true;
		    this.txtSpanishPromotionType.Enabled = true;
		    this.txtFrenchPromotionType.Enabled = true;
		    this.txtEnglishPromotionCategory.Enabled = true;
		    this.txtSpanishPromotionCategory.Enabled = true;
		    this.txtFrenchPromotionCategory.Enabled = true;
		    this.txtStartDate.Enabled = true;
		    this.txtEndDate.Enabled = true;
		    this.txtMinQty.Enabled = true;
		    this.txtMaxQty.Enabled = true;
		    txtPromotionKey.Enabled = false;
		    txtPromotionAlternateKey.Focus();
		    txtPromotionKey.Text = Convert.ToString(clsAdventureWorksDW2012Data.getAutoID("New", "DimPromotion"));
        }

        private void GetData()
        {
		    ClearRecord();

		    dbo_DimPromotionClass clsdbo_DimPromotion = new dbo_DimPromotionClass();
		    clsdbo_DimPromotion.PromotionKey = System.Convert.ToInt32(Session["PromotionKey"]);
		    clsdbo_DimPromotion = dbo_DimPromotionDataClass.Select_Record(clsdbo_DimPromotion);

		    if ((clsdbo_DimPromotion != null)) {
			    try {
                		txtPromotionKey.Text = System.Convert.ToString(clsdbo_DimPromotion.PromotionKey);
                		if (clsdbo_DimPromotion.PromotionAlternateKey == null) { txtPromotionAlternateKey.Text = default(string); } else { txtPromotionAlternateKey.Text = System.Convert.ToString(clsdbo_DimPromotion.PromotionAlternateKey); }
                		if (clsdbo_DimPromotion.EnglishPromotionName == null) { txtEnglishPromotionName.Text = default(string); } else { txtEnglishPromotionName.Text = System.Convert.ToString(clsdbo_DimPromotion.EnglishPromotionName); }
                		if (clsdbo_DimPromotion.SpanishPromotionName == null) { txtSpanishPromotionName.Text = default(string); } else { txtSpanishPromotionName.Text = System.Convert.ToString(clsdbo_DimPromotion.SpanishPromotionName); }
                		if (clsdbo_DimPromotion.FrenchPromotionName == null) { txtFrenchPromotionName.Text = default(string); } else { txtFrenchPromotionName.Text = System.Convert.ToString(clsdbo_DimPromotion.FrenchPromotionName); }
                		if (clsdbo_DimPromotion.DiscountPct == null) { txtDiscountPct.Text = default(string); } else { txtDiscountPct.Text = System.Convert.ToString(clsdbo_DimPromotion.DiscountPct); }
                		if (clsdbo_DimPromotion.EnglishPromotionType == null) { txtEnglishPromotionType.Text = default(string); } else { txtEnglishPromotionType.Text = System.Convert.ToString(clsdbo_DimPromotion.EnglishPromotionType); }
                		if (clsdbo_DimPromotion.SpanishPromotionType == null) { txtSpanishPromotionType.Text = default(string); } else { txtSpanishPromotionType.Text = System.Convert.ToString(clsdbo_DimPromotion.SpanishPromotionType); }
                		if (clsdbo_DimPromotion.FrenchPromotionType == null) { txtFrenchPromotionType.Text = default(string); } else { txtFrenchPromotionType.Text = System.Convert.ToString(clsdbo_DimPromotion.FrenchPromotionType); }
                		if (clsdbo_DimPromotion.EnglishPromotionCategory == null) { txtEnglishPromotionCategory.Text = default(string); } else { txtEnglishPromotionCategory.Text = System.Convert.ToString(clsdbo_DimPromotion.EnglishPromotionCategory); }
                		if (clsdbo_DimPromotion.SpanishPromotionCategory == null) { txtSpanishPromotionCategory.Text = default(string); } else { txtSpanishPromotionCategory.Text = System.Convert.ToString(clsdbo_DimPromotion.SpanishPromotionCategory); }
                		if (clsdbo_DimPromotion.FrenchPromotionCategory == null) { txtFrenchPromotionCategory.Text = default(string); } else { txtFrenchPromotionCategory.Text = System.Convert.ToString(clsdbo_DimPromotion.FrenchPromotionCategory); }
                		txtStartDate.Text = System.Convert.ToDateTime(clsdbo_DimPromotion.StartDate).ToShortDateString();
                		if (clsdbo_DimPromotion.EndDate == null) { txtEndDate.Text = DateTime.Now.ToString(); } else { txtEndDate.Text = System.Convert.ToDateTime(clsdbo_DimPromotion.EndDate).ToShortDateString(); }
                		if (clsdbo_DimPromotion.MinQty == null) { txtMinQty.Text = default(string); } else { txtMinQty.Text = System.Convert.ToString(clsdbo_DimPromotion.MinQty); }
                		if (clsdbo_DimPromotion.MaxQty == null) { txtMaxQty.Text = default(string); } else { txtMaxQty.Text = System.Convert.ToString(clsdbo_DimPromotion.MaxQty); }
		   	 }
		    	catch (Exception ex)
		    	{
		    		ec.ShowMessage(ex.Message, " Dbo. Dim Promotion ");
		    	}
		    }

        }

        private void Edit()
        {
		    Session.Remove("Mode");
		    Session["Mode"] = "Edit";

                    GetData();

		    txtPromotionAlternateKey.Enabled = true;
		    txtEnglishPromotionName.Enabled = true;
		    txtSpanishPromotionName.Enabled = true;
		    txtFrenchPromotionName.Enabled = true;
		    txtDiscountPct.Enabled = true;
		    txtEnglishPromotionType.Enabled = true;
		    txtSpanishPromotionType.Enabled = true;
		    txtFrenchPromotionType.Enabled = true;
		    txtEnglishPromotionCategory.Enabled = true;
		    txtSpanishPromotionCategory.Enabled = true;
		    txtFrenchPromotionCategory.Enabled = true;
		    txtMinQty.Enabled = true;
		    txtMaxQty.Enabled = true;
		    txtPromotionKey.Enabled = false;
		    txtPromotionAlternateKey.Focus();
        }

        private void Delete()
        {
		    Session.Remove("Mode");
		    Session["Mode"] = "Delete";

                    GetData();

		    txtPromotionKey.Enabled = false;
		    txtPromotionAlternateKey.Enabled = false;
		    txtEnglishPromotionName.Enabled = false;
		    txtSpanishPromotionName.Enabled = false;
		    txtFrenchPromotionName.Enabled = false;
		    txtDiscountPct.Enabled = false;
		    txtEnglishPromotionType.Enabled = false;
		    txtSpanishPromotionType.Enabled = false;
		    txtFrenchPromotionType.Enabled = false;
		    txtEnglishPromotionCategory.Enabled = false;
		    txtSpanishPromotionCategory.Enabled = false;
		    txtFrenchPromotionCategory.Enabled = false;
		    txtStartDate.Enabled = false;
		    txtEndDate.Enabled = false;
		    txtMinQty.Enabled = false;
		    txtMaxQty.Enabled = false;
        }

        private void ClearRecord()
        {
	        txtPromotionKey.Text = null;
	        txtPromotionAlternateKey.Text = null;
	        txtEnglishPromotionName.Text = null;
	        txtSpanishPromotionName.Text = null;
	        txtFrenchPromotionName.Text = null;
	        txtDiscountPct.Text = null;
	        txtEnglishPromotionType.Text = null;
	        txtSpanishPromotionType.Text = null;
	        txtFrenchPromotionType.Text = null;
	        txtEnglishPromotionCategory.Text = null;
	        txtSpanishPromotionCategory.Text = null;
	        txtFrenchPromotionCategory.Text = null;
        	txtStartDate.Text = null;
        	txtEndDate.Text = null;
	        txtMinQty.Text = null;
	        txtMaxQty.Text = null;
        }

        public void btnSave_Click(object sender, System.EventArgs e)
        {
		    if ((String)Session["Mode"] == "Add") {
			    this.InsertRecord();
		    } else if ((String)Session["Mode"] == "Edit") {
			    this.UpdateRecord();
		    }
        }

        private void SetData(dbo_DimPromotionClass clsdbo_DimPromotion)
        {
			    if (string.IsNullOrEmpty(txtPromotionAlternateKey.Text)) {
			    	clsdbo_DimPromotion.PromotionAlternateKey = null;
			    } else {
			    	clsdbo_DimPromotion.PromotionAlternateKey = System.Convert.ToInt32(txtPromotionAlternateKey.Text); }
			    if (string.IsNullOrEmpty(txtEnglishPromotionName.Text)) {
			    	clsdbo_DimPromotion.EnglishPromotionName = null;
			    } else {
			    	clsdbo_DimPromotion.EnglishPromotionName = txtEnglishPromotionName.Text; }
			    if (string.IsNullOrEmpty(txtSpanishPromotionName.Text)) {
			    	clsdbo_DimPromotion.SpanishPromotionName = null;
			    } else {
			    	clsdbo_DimPromotion.SpanishPromotionName = txtSpanishPromotionName.Text; }
			    if (string.IsNullOrEmpty(txtFrenchPromotionName.Text)) {
			    	clsdbo_DimPromotion.FrenchPromotionName = null;
			    } else {
			    	clsdbo_DimPromotion.FrenchPromotionName = txtFrenchPromotionName.Text; }
			    if (string.IsNullOrEmpty(txtDiscountPct.Text)) {
			    	clsdbo_DimPromotion.DiscountPct = null;
			    } else {
			    	clsdbo_DimPromotion.DiscountPct = System.Convert.ToDecimal(txtDiscountPct.Text); }
			    if (string.IsNullOrEmpty(txtEnglishPromotionType.Text)) {
			    	clsdbo_DimPromotion.EnglishPromotionType = null;
			    } else {
			    	clsdbo_DimPromotion.EnglishPromotionType = txtEnglishPromotionType.Text; }
			    if (string.IsNullOrEmpty(txtSpanishPromotionType.Text)) {
			    	clsdbo_DimPromotion.SpanishPromotionType = null;
			    } else {
			    	clsdbo_DimPromotion.SpanishPromotionType = txtSpanishPromotionType.Text; }
			    if (string.IsNullOrEmpty(txtFrenchPromotionType.Text)) {
			    	clsdbo_DimPromotion.FrenchPromotionType = null;
			    } else {
			    	clsdbo_DimPromotion.FrenchPromotionType = txtFrenchPromotionType.Text; }
			    if (string.IsNullOrEmpty(txtEnglishPromotionCategory.Text)) {
			    	clsdbo_DimPromotion.EnglishPromotionCategory = null;
			    } else {
			    	clsdbo_DimPromotion.EnglishPromotionCategory = txtEnglishPromotionCategory.Text; }
			    if (string.IsNullOrEmpty(txtSpanishPromotionCategory.Text)) {
			    	clsdbo_DimPromotion.SpanishPromotionCategory = null;
			    } else {
			    	clsdbo_DimPromotion.SpanishPromotionCategory = txtSpanishPromotionCategory.Text; }
			    if (string.IsNullOrEmpty(txtFrenchPromotionCategory.Text)) {
			    	clsdbo_DimPromotion.FrenchPromotionCategory = null;
			    } else {
			    	clsdbo_DimPromotion.FrenchPromotionCategory = txtFrenchPromotionCategory.Text; }
			    clsdbo_DimPromotion.StartDate = System.Convert.ToDateTime(txtStartDate.Text);
			    if (string.IsNullOrEmpty(txtEndDate.Text)) {
			    	clsdbo_DimPromotion.EndDate = null;
			    } else {
			    	clsdbo_DimPromotion.EndDate = System.Convert.ToDateTime(txtEndDate.Text); }
			    if (string.IsNullOrEmpty(txtMinQty.Text)) {
			    	clsdbo_DimPromotion.MinQty = null;
			    } else {
			    	clsdbo_DimPromotion.MinQty = System.Convert.ToInt32(txtMinQty.Text); }
			    if (string.IsNullOrEmpty(txtMaxQty.Text)) {
			    	clsdbo_DimPromotion.MaxQty = null;
			    } else {
			    	clsdbo_DimPromotion.MaxQty = System.Convert.ToInt32(txtMaxQty.Text); }
        }

        private void InsertRecord()
        {
		    dbo_DimPromotionClass clsdbo_DimPromotion = new dbo_DimPromotionClass();
		    if (VerifyData() == true) {
                            SetData(clsdbo_DimPromotion);
			    bool bSucess = false;
			    bSucess = dbo_DimPromotionDataClass.Add(clsdbo_DimPromotion);
			    if (bSucess == true) {
				    pnlForm.Visible = false;
				    pnlSave.Visible = false;
				    pnlGrid.Visible = true;
				    lblMode.InnerText = "";
				    Session.Remove("dvdbo_DimPromotion");
				    LoadGriddbo_DimPromotion();
			    } else {
				    ec.ShowMessage(" Insert failed. ", " Dbo. Dim Promotion ");
			    }
		    }
        }

        private void UpdateRecord()
        {
		    dbo_DimPromotionClass oclsdbo_DimPromotion = new dbo_DimPromotionClass();
		    dbo_DimPromotionClass clsdbo_DimPromotion = new dbo_DimPromotionClass();

		    oclsdbo_DimPromotion.PromotionKey = System.Convert.ToInt32(Session["PromotionKey"]);
		    oclsdbo_DimPromotion = dbo_DimPromotionDataClass.Select_Record(oclsdbo_DimPromotion);

		    if (VerifyData() == true) {
                            SetData(clsdbo_DimPromotion);
			    bool bSucess = false;
			    bSucess = dbo_DimPromotionDataClass.Update(oclsdbo_DimPromotion, clsdbo_DimPromotion);
			    if (bSucess == true) {
				    pnlForm.Visible = false;
				    pnlSave.Visible = false;
				    pnlGrid.Visible = true;
				    lblMode.InnerText = "";
				    Session.Remove("dvdbo_DimPromotion");
				    LoadGriddbo_DimPromotion();
			    } else {
				    ec.ShowMessage(" Update failed. ", " Dbo. Dim Promotion ");
			    }
		    }
        }

        private void DeleteRecord()
        {
		    dbo_DimPromotionClass clsdbo_DimPromotion = new dbo_DimPromotionClass();
		    clsdbo_DimPromotion.PromotionKey = System.Convert.ToInt32(Session["PromotionKey"]);
                    SetData(clsdbo_DimPromotion);
		    bool bSucess = false;
		    bSucess = dbo_DimPromotionDataClass.Delete(clsdbo_DimPromotion);
		    if (bSucess == true) {
			    pnlForm.Visible = false;
			    pnlSave.Visible = false;
			    pnlGrid.Visible = true;
			    pnlDelete.Visible = false;
			    lblMode.InnerText = "";
			    Session.Remove("dvdbo_DimPromotion");
			    LoadGriddbo_DimPromotion();
		    } else {
			    ec.ShowMessage(" Delete failed. ", " Dbo. Dim Promotion ");
		    }
        }

        private Boolean VerifyData()
        {
            
		    return true;
        }

        public void butRecords_Click(object sender, System.EventArgs e)
        {
		    grddbo_DimPromotion.CurrentPageIndex = 0;
		    grddbo_DimPromotion.PageSize = Convert.ToInt32(cmbRecords.Text);
		    LoadGriddbo_DimPromotion();
        }

        public void btnAddNew_Click(object sender, System.EventArgs e)
        {
		    if (pnlForm.Visible) {
			    txtPromotionKey.Text = "";
			    txtPromotionAlternateKey.Text = "";
			    txtEnglishPromotionName.Text = "";
			    txtSpanishPromotionName.Text = "";
			    txtFrenchPromotionName.Text = "";
			    txtDiscountPct.Text = "";
			    txtEnglishPromotionType.Text = "";
			    txtSpanishPromotionType.Text = "";
			    txtFrenchPromotionType.Text = "";
			    txtEnglishPromotionCategory.Text = "";
			    txtSpanishPromotionCategory.Text = "";
			    txtFrenchPromotionCategory.Text = "";
			    txtStartDate.Text = "";
			    txtEndDate.Text = "";
			    txtMinQty.Text = "";
			    txtMaxQty.Text = "";
		    } else {
			    pnlForm.Visible = true;
			    pnlGrid.Visible = false;
			    pnlSave.Visible = true;
			    lblMode.InnerText = "Add new";
		    }
		    btnSave.CommandArgument = "Add";
		    Add();
        }

        public void grddbo_DimPromotion_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
        { 
		    if (e.Item.ItemType == ListItemType.Pager | e.Item.ItemType == ListItemType.Header)
			    return;

		    Button btn = (Button)e.CommandSource;
		    if (btn.Text == "Edit" | btn.Text == "Delete") {
			    Session.Remove("PromotionKey");
			    Session["PromotionKey"] = e.Item.Cells[0 + 0].Text;
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

        public void grddbo_DimPromotion_SortCommand(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
        {
		    htmlHiddenSortExpression.Value = e.SortExpression + " " + GetSortDirection(e.SortExpression);
		    LoadGriddbo_DimPromotion();
        }

        public void grddbo_DimPromotion_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
        {
		    grddbo_DimPromotion.CurrentPageIndex = e.NewPageIndex;
		    LoadGriddbo_DimPromotion();
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
		    Session.Remove("dvdbo_DimPromotion");
		    LoadGriddbo_DimPromotion();
        }

        public void butSearch_Click(object sender, System.EventArgs e)
        {
		    try {
                        Session.Remove("dvdbo_DimPromotion");
			if ((Session["dvdbo_DimPromotion"] != null)) {
				dvdbo_DimPromotion = (DataView)Session["dvdbo_DimPromotion"];
				// DataView was not found in the session.
		    	} else {
				dvdbo_DimPromotion = dbo_DimPromotionDataClass.Search(cmbFields.Text, cmbCondition.Text, txtSearch.Text).DefaultView;
			    	Session["dvdbo_DimPromotion"] = dvdbo_DimPromotion;
		    	}
                if (dvdbo_DimPromotion.Count > 0)
                {
                    dvdbo_DimPromotion.Sort = htmlHiddenSortExpression.Value;
                    grddbo_DimPromotion.DataSource = dvdbo_DimPromotion;
                    grddbo_DimPromotion.DataBind();
                }
                else
                {
                    grddbo_DimPromotion.DataSource = null;
                    grddbo_DimPromotion.DataBind();
                }
		    }
		    catch (Exception ex)
		    {
		    	ec.ShowMessage(ex.Message, " Dbo. Dim Promotion ");
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
                    { dt = dbo_DimPromotionDataClass.Search(cmbFields.Text, cmbCondition.Text, txtSearch.Text); }
                    else { dt = dbo_DimPromotionDataClass.SelectAll(); }

                    PDFform pdfForm = new PDFform(dt, "Dbo. Dim Promotion", "Many");
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
                    GVExport.DataSource = Session["dvdbo_DimPromotion"];
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
 
