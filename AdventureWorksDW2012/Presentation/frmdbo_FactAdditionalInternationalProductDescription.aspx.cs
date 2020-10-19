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
    public partial class frmdbo_FactAdditionalInternationalProductDescription : System.Web.UI.Page
    {

        private dbo_FactAdditionalInternationalProductDescriptionDataClass clsdbo_FactAdditionalInternationalProductDescriptionData = new dbo_FactAdditionalInternationalProductDescriptionDataClass();
        private AdventureWorksDW2012DataClass clsAdventureWorksDW2012Data = new AdventureWorksDW2012DataClass();
        private DataView dvdbo_FactAdditionalInternationalProductDescription;

        protected void Page_Load(object sender, EventArgs e)
        {
		    if (!Page.IsPostBack) {
			    Session["Mode"] = "";
 			    Session["ProductKey"] = "";
 			    Session["CultureName"] = "";

			    Session.Remove("dvdbo_FactAdditionalInternationalProductDescription");

                            cmbFields.Items.Add("Product Key");
                            cmbFields.Items.Add("Culture Name");
                            cmbFields.Items.Add("Product Description");

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


			    LoadGriddbo_FactAdditionalInternationalProductDescription();
		    }

        }


        private void LoadGriddbo_FactAdditionalInternationalProductDescription()
        {
		    try {
			if ((Session["dvdbo_FactAdditionalInternationalProductDescription"] != null)) {
				dvdbo_FactAdditionalInternationalProductDescription = (DataView)Session["dvdbo_FactAdditionalInternationalProductDescription"];
				// DataView was not found in the session.
		    	} else {
				dvdbo_FactAdditionalInternationalProductDescription = dbo_FactAdditionalInternationalProductDescriptionDataClass.SelectAll().DefaultView;
			    	Session["dvdbo_FactAdditionalInternationalProductDescription"] = dvdbo_FactAdditionalInternationalProductDescription;
		    	}
                if (dvdbo_FactAdditionalInternationalProductDescription.Count > 0)
                {
                    dvdbo_FactAdditionalInternationalProductDescription.Sort = htmlHiddenSortExpression.Value;
                    grddbo_FactAdditionalInternationalProductDescription.DataSource = dvdbo_FactAdditionalInternationalProductDescription;
                    grddbo_FactAdditionalInternationalProductDescription.DataBind();
                }
                else
                {
                    grddbo_FactAdditionalInternationalProductDescription.DataSource = null;
                    grddbo_FactAdditionalInternationalProductDescription.DataBind();
                }
		    }
		    catch (Exception ex)
		    {
		    	ec.ShowMessage(ex.Message, " Dbo. Fact Additional International Product Description ");
		    }
        }

        private void Add()
        {
		    Session.Remove("Mode");
		    Session["Mode"] = "Add";

		    ClearRecord();

		    this.txtProductKey.Enabled = true;
		    this.txtCultureName.Enabled = true;
		    this.txtProductDescription.Enabled = true;
		    txtProductKey.Focus();
        }

        private void GetData()
        {
		    ClearRecord();

		    dbo_FactAdditionalInternationalProductDescriptionClass clsdbo_FactAdditionalInternationalProductDescription = new dbo_FactAdditionalInternationalProductDescriptionClass();
		    clsdbo_FactAdditionalInternationalProductDescription.ProductKey = System.Convert.ToInt32(Session["ProductKey"]);
		    clsdbo_FactAdditionalInternationalProductDescription.CultureName = System.Convert.ToString(Session["CultureName"]);
		    clsdbo_FactAdditionalInternationalProductDescription = dbo_FactAdditionalInternationalProductDescriptionDataClass.Select_Record(clsdbo_FactAdditionalInternationalProductDescription);

		    if ((clsdbo_FactAdditionalInternationalProductDescription != null)) {
			    try {
                		txtProductKey.Text = System.Convert.ToString(clsdbo_FactAdditionalInternationalProductDescription.ProductKey);
                		txtCultureName.Text = System.Convert.ToString(clsdbo_FactAdditionalInternationalProductDescription.CultureName);
                		txtProductDescription.Text = System.Convert.ToString(clsdbo_FactAdditionalInternationalProductDescription.ProductDescription);
		   	 }
		    	catch (Exception ex)
		    	{
		    		ec.ShowMessage(ex.Message, " Dbo. Fact Additional International Product Description ");
		    	}
		    }

        }

        private void Edit()
        {
		    Session.Remove("Mode");
		    Session["Mode"] = "Edit";

                    GetData();

		    txtProductDescription.Enabled = true;
		    txtProductKey.Enabled = false;
		    txtCultureName.Enabled = false;
		    txtProductDescription.Focus();
        }

        private void Delete()
        {
		    Session.Remove("Mode");
		    Session["Mode"] = "Delete";

                    GetData();

		    txtProductKey.Enabled = false;
		    txtCultureName.Enabled = false;
		    txtProductDescription.Enabled = false;
        }

        private void ClearRecord()
        {
	        txtProductKey.Text = null;
	        txtCultureName.Text = null;
	        txtProductDescription.Text = null;
        }

        public void btnSave_Click(object sender, System.EventArgs e)
        {
		    if ((String)Session["Mode"] == "Add") {
			    this.InsertRecord();
		    } else if ((String)Session["Mode"] == "Edit") {
			    this.UpdateRecord();
		    }
        }

        private void SetData(dbo_FactAdditionalInternationalProductDescriptionClass clsdbo_FactAdditionalInternationalProductDescription)
        {
			    clsdbo_FactAdditionalInternationalProductDescription.ProductKey = System.Convert.ToInt32(txtProductKey.Text);
			    clsdbo_FactAdditionalInternationalProductDescription.CultureName = System.Convert.ToString(txtCultureName.Text);
			    clsdbo_FactAdditionalInternationalProductDescription.ProductDescription = System.Convert.ToString(txtProductDescription.Text);
        }

        private void InsertRecord()
        {
		    dbo_FactAdditionalInternationalProductDescriptionClass clsdbo_FactAdditionalInternationalProductDescription = new dbo_FactAdditionalInternationalProductDescriptionClass();
		    if (VerifyData() == true) {
                            SetData(clsdbo_FactAdditionalInternationalProductDescription);
			    bool bSucess = false;
			    bSucess = dbo_FactAdditionalInternationalProductDescriptionDataClass.Add(clsdbo_FactAdditionalInternationalProductDescription);
			    if (bSucess == true) {
				    pnlForm.Visible = false;
				    pnlSave.Visible = false;
				    pnlGrid.Visible = true;
				    lblMode.InnerText = "";
				    Session.Remove("dvdbo_FactAdditionalInternationalProductDescription");
				    LoadGriddbo_FactAdditionalInternationalProductDescription();
			    } else {
				    ec.ShowMessage(" Insert failed. ", " Dbo. Fact Additional International Product Description ");
			    }
		    }
        }

        private void UpdateRecord()
        {
		    dbo_FactAdditionalInternationalProductDescriptionClass oclsdbo_FactAdditionalInternationalProductDescription = new dbo_FactAdditionalInternationalProductDescriptionClass();
		    dbo_FactAdditionalInternationalProductDescriptionClass clsdbo_FactAdditionalInternationalProductDescription = new dbo_FactAdditionalInternationalProductDescriptionClass();

		    oclsdbo_FactAdditionalInternationalProductDescription.ProductKey = System.Convert.ToInt32(Session["ProductKey"]);
		    oclsdbo_FactAdditionalInternationalProductDescription.CultureName = System.Convert.ToString(Session["CultureName"]);
		    oclsdbo_FactAdditionalInternationalProductDescription = dbo_FactAdditionalInternationalProductDescriptionDataClass.Select_Record(oclsdbo_FactAdditionalInternationalProductDescription);

		    if (VerifyData() == true) {
                            SetData(clsdbo_FactAdditionalInternationalProductDescription);
			    bool bSucess = false;
			    bSucess = dbo_FactAdditionalInternationalProductDescriptionDataClass.Update(oclsdbo_FactAdditionalInternationalProductDescription, clsdbo_FactAdditionalInternationalProductDescription);
			    if (bSucess == true) {
				    pnlForm.Visible = false;
				    pnlSave.Visible = false;
				    pnlGrid.Visible = true;
				    lblMode.InnerText = "";
				    Session.Remove("dvdbo_FactAdditionalInternationalProductDescription");
				    LoadGriddbo_FactAdditionalInternationalProductDescription();
			    } else {
				    ec.ShowMessage(" Update failed. ", " Dbo. Fact Additional International Product Description ");
			    }
		    }
        }

        private void DeleteRecord()
        {
		    dbo_FactAdditionalInternationalProductDescriptionClass clsdbo_FactAdditionalInternationalProductDescription = new dbo_FactAdditionalInternationalProductDescriptionClass();
		    clsdbo_FactAdditionalInternationalProductDescription.ProductKey = System.Convert.ToInt32(Session["ProductKey"]);
		    clsdbo_FactAdditionalInternationalProductDescription.CultureName = System.Convert.ToString(Session["CultureName"]);
                    SetData(clsdbo_FactAdditionalInternationalProductDescription);
		    bool bSucess = false;
		    bSucess = dbo_FactAdditionalInternationalProductDescriptionDataClass.Delete(clsdbo_FactAdditionalInternationalProductDescription);
		    if (bSucess == true) {
			    pnlForm.Visible = false;
			    pnlSave.Visible = false;
			    pnlGrid.Visible = true;
			    pnlDelete.Visible = false;
			    lblMode.InnerText = "";
			    Session.Remove("dvdbo_FactAdditionalInternationalProductDescription");
			    LoadGriddbo_FactAdditionalInternationalProductDescription();
		    } else {
			    ec.ShowMessage(" Delete failed. ", " Dbo. Fact Additional International Product Description ");
		    }
        }

        private Boolean VerifyData()
        {
		    if (txtProductKey.Text == "") {
		    	ec.ShowMessage(" Product Key is Required. ", " Dbo. Fact Additional International Product Description ");
	                txtProductKey.Focus();
                	return false;}
		    if (txtCultureName.Text == "") {
		    	ec.ShowMessage(" Culture Name is Required. ", " Dbo. Fact Additional International Product Description ");
	                txtCultureName.Focus();
                	return false;}
		    if (txtProductDescription.Text == "") {
		    	ec.ShowMessage(" Product Description is Required. ", " Dbo. Fact Additional International Product Description ");
	                txtProductDescription.Focus();
                	return false;}
            if (
            txtProductKey.Text != "" 
            && txtCultureName.Text != "" 
            )  {
            dbo_FactAdditionalInternationalProductDescriptionClass clsdbo_FactAdditionalInternationalProductDescription = new dbo_FactAdditionalInternationalProductDescriptionClass();
            clsdbo_FactAdditionalInternationalProductDescription.ProductKey = System.Convert.ToInt32(txtProductKey.Text);
            clsdbo_FactAdditionalInternationalProductDescription.CultureName = System.Convert.ToString(txtCultureName.Text);
            clsdbo_FactAdditionalInternationalProductDescription = dbo_FactAdditionalInternationalProductDescriptionDataClass.Select_Record(clsdbo_FactAdditionalInternationalProductDescription);
		    if (clsdbo_FactAdditionalInternationalProductDescription != null && (String)Session["Mode"] == "Add") {
                    	ec.ShowMessage(" Record already exists. ", " Dbo. Fact Additional International Product Description ");
                 	txtProductKey.Focus();
                	return false; }
            }
		    return true;
        }

        public void butRecords_Click(object sender, System.EventArgs e)
        {
		    grddbo_FactAdditionalInternationalProductDescription.CurrentPageIndex = 0;
		    grddbo_FactAdditionalInternationalProductDescription.PageSize = Convert.ToInt32(cmbRecords.Text);
		    LoadGriddbo_FactAdditionalInternationalProductDescription();
        }

        public void btnAddNew_Click(object sender, System.EventArgs e)
        {
		    if (pnlForm.Visible) {
			    txtProductKey.Text = "";
			    txtCultureName.Text = "";
			    txtProductDescription.Text = "";
		    } else {
			    pnlForm.Visible = true;
			    pnlGrid.Visible = false;
			    pnlSave.Visible = true;
			    lblMode.InnerText = "Add new";
		    }
		    btnSave.CommandArgument = "Add";
		    Add();
        }

        public void grddbo_FactAdditionalInternationalProductDescription_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
        { 
		    if (e.Item.ItemType == ListItemType.Pager | e.Item.ItemType == ListItemType.Header)
			    return;

		    Button btn = (Button)e.CommandSource;
		    if (btn.Text == "Edit" | btn.Text == "Delete") {
			    Session.Remove("ProductKey");
			    Session["ProductKey"] = e.Item.Cells[0 + 0].Text;
			    Session.Remove("CultureName");
			    Session["CultureName"] = e.Item.Cells[1 + 1].Text;
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

        public void grddbo_FactAdditionalInternationalProductDescription_SortCommand(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
        {
		    htmlHiddenSortExpression.Value = e.SortExpression + " " + GetSortDirection(e.SortExpression);
		    LoadGriddbo_FactAdditionalInternationalProductDescription();
        }

        public void grddbo_FactAdditionalInternationalProductDescription_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
        {
		    grddbo_FactAdditionalInternationalProductDescription.CurrentPageIndex = e.NewPageIndex;
		    LoadGriddbo_FactAdditionalInternationalProductDescription();
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
		    Session.Remove("dvdbo_FactAdditionalInternationalProductDescription");
		    LoadGriddbo_FactAdditionalInternationalProductDescription();
        }

        public void butSearch_Click(object sender, System.EventArgs e)
        {
		    try {
                        Session.Remove("dvdbo_FactAdditionalInternationalProductDescription");
			if ((Session["dvdbo_FactAdditionalInternationalProductDescription"] != null)) {
				dvdbo_FactAdditionalInternationalProductDescription = (DataView)Session["dvdbo_FactAdditionalInternationalProductDescription"];
				// DataView was not found in the session.
		    	} else {
				dvdbo_FactAdditionalInternationalProductDescription = dbo_FactAdditionalInternationalProductDescriptionDataClass.Search(cmbFields.Text, cmbCondition.Text, txtSearch.Text).DefaultView;
			    	Session["dvdbo_FactAdditionalInternationalProductDescription"] = dvdbo_FactAdditionalInternationalProductDescription;
		    	}
                if (dvdbo_FactAdditionalInternationalProductDescription.Count > 0)
                {
                    dvdbo_FactAdditionalInternationalProductDescription.Sort = htmlHiddenSortExpression.Value;
                    grddbo_FactAdditionalInternationalProductDescription.DataSource = dvdbo_FactAdditionalInternationalProductDescription;
                    grddbo_FactAdditionalInternationalProductDescription.DataBind();
                }
                else
                {
                    grddbo_FactAdditionalInternationalProductDescription.DataSource = null;
                    grddbo_FactAdditionalInternationalProductDescription.DataBind();
                }
		    }
		    catch (Exception ex)
		    {
		    	ec.ShowMessage(ex.Message, " Dbo. Fact Additional International Product Description ");
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
                    { dt = dbo_FactAdditionalInternationalProductDescriptionDataClass.Search(cmbFields.Text, cmbCondition.Text, txtSearch.Text); }
                    else { dt = dbo_FactAdditionalInternationalProductDescriptionDataClass.SelectAll(); }

                    PDFform pdfForm = new PDFform(dt, "Dbo. Fact Additional International Product Description", "Many");
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
                    GVExport.DataSource = Session["dvdbo_FactAdditionalInternationalProductDescription"];
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
 
