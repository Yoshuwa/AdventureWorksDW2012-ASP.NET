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
    public partial class frmdbo_DimSalesReason : System.Web.UI.Page
    {

        private dbo_DimSalesReasonDataClass clsdbo_DimSalesReasonData = new dbo_DimSalesReasonDataClass();
        private AdventureWorksDW2012DataClass clsAdventureWorksDW2012Data = new AdventureWorksDW2012DataClass();
        private DataView dvdbo_DimSalesReason;

        protected void Page_Load(object sender, EventArgs e)
        {
		    if (!Page.IsPostBack) {
			    Session["Mode"] = "";
 			    Session["SalesReasonKey"] = "";

			    Session.Remove("dvdbo_DimSalesReason");

                            cmbFields.Items.Add("Sales Reason Key");
                            cmbFields.Items.Add("Sales Reason Alternate Key");
                            cmbFields.Items.Add("Sales Reason Name");
                            cmbFields.Items.Add("Sales Reason Reason Type");

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


			    LoadGriddbo_DimSalesReason();
		    }

        }


        private void LoadGriddbo_DimSalesReason()
        {
		    try {
			if ((Session["dvdbo_DimSalesReason"] != null)) {
				dvdbo_DimSalesReason = (DataView)Session["dvdbo_DimSalesReason"];
				// DataView was not found in the session.
		    	} else {
				dvdbo_DimSalesReason = dbo_DimSalesReasonDataClass.SelectAll().DefaultView;
			    	Session["dvdbo_DimSalesReason"] = dvdbo_DimSalesReason;
		    	}
                if (dvdbo_DimSalesReason.Count > 0)
                {
                    dvdbo_DimSalesReason.Sort = htmlHiddenSortExpression.Value;
                    grddbo_DimSalesReason.DataSource = dvdbo_DimSalesReason;
                    grddbo_DimSalesReason.DataBind();
                }
                else
                {
                    grddbo_DimSalesReason.DataSource = null;
                    grddbo_DimSalesReason.DataBind();
                }
		    }
		    catch (Exception ex)
		    {
		    	ec.ShowMessage(ex.Message, " Dbo. Dim Sales Reason ");
		    }
        }

        private void Add()
        {
		    Session.Remove("Mode");
		    Session["Mode"] = "Add";

		    ClearRecord();

		    this.txtSalesReasonAlternateKey.Enabled = true;
		    this.txtSalesReasonName.Enabled = true;
		    this.txtSalesReasonReasonType.Enabled = true;
		    txtSalesReasonKey.Enabled = false;
		    txtSalesReasonAlternateKey.Focus();
		    txtSalesReasonKey.Text = Convert.ToString(clsAdventureWorksDW2012Data.getAutoID("New", "DimSalesReason"));
        }

        private void GetData()
        {
		    ClearRecord();

		    dbo_DimSalesReasonClass clsdbo_DimSalesReason = new dbo_DimSalesReasonClass();
		    clsdbo_DimSalesReason.SalesReasonKey = System.Convert.ToInt32(Session["SalesReasonKey"]);
		    clsdbo_DimSalesReason = dbo_DimSalesReasonDataClass.Select_Record(clsdbo_DimSalesReason);

		    if ((clsdbo_DimSalesReason != null)) {
			    try {
                		txtSalesReasonKey.Text = System.Convert.ToString(clsdbo_DimSalesReason.SalesReasonKey);
                		txtSalesReasonAlternateKey.Text = System.Convert.ToString(clsdbo_DimSalesReason.SalesReasonAlternateKey);
                		txtSalesReasonName.Text = System.Convert.ToString(clsdbo_DimSalesReason.SalesReasonName);
                		txtSalesReasonReasonType.Text = System.Convert.ToString(clsdbo_DimSalesReason.SalesReasonReasonType);
		   	 }
		    	catch (Exception ex)
		    	{
		    		ec.ShowMessage(ex.Message, " Dbo. Dim Sales Reason ");
		    	}
		    }

        }

        private void Edit()
        {
		    Session.Remove("Mode");
		    Session["Mode"] = "Edit";

                    GetData();

		    txtSalesReasonAlternateKey.Enabled = true;
		    txtSalesReasonName.Enabled = true;
		    txtSalesReasonReasonType.Enabled = true;
		    txtSalesReasonKey.Enabled = false;
		    txtSalesReasonAlternateKey.Focus();
        }

        private void Delete()
        {
		    Session.Remove("Mode");
		    Session["Mode"] = "Delete";

                    GetData();

		    txtSalesReasonKey.Enabled = false;
		    txtSalesReasonAlternateKey.Enabled = false;
		    txtSalesReasonName.Enabled = false;
		    txtSalesReasonReasonType.Enabled = false;
        }

        private void ClearRecord()
        {
	        txtSalesReasonKey.Text = null;
	        txtSalesReasonAlternateKey.Text = null;
	        txtSalesReasonName.Text = null;
	        txtSalesReasonReasonType.Text = null;
        }

        public void btnSave_Click(object sender, System.EventArgs e)
        {
		    if ((String)Session["Mode"] == "Add") {
			    this.InsertRecord();
		    } else if ((String)Session["Mode"] == "Edit") {
			    this.UpdateRecord();
		    }
        }

        private void SetData(dbo_DimSalesReasonClass clsdbo_DimSalesReason)
        {
			    clsdbo_DimSalesReason.SalesReasonAlternateKey = System.Convert.ToInt32(txtSalesReasonAlternateKey.Text);
			    clsdbo_DimSalesReason.SalesReasonName = System.Convert.ToString(txtSalesReasonName.Text);
			    clsdbo_DimSalesReason.SalesReasonReasonType = System.Convert.ToString(txtSalesReasonReasonType.Text);
        }

        private void InsertRecord()
        {
		    dbo_DimSalesReasonClass clsdbo_DimSalesReason = new dbo_DimSalesReasonClass();
		    if (VerifyData() == true) {
                            SetData(clsdbo_DimSalesReason);
			    bool bSucess = false;
			    bSucess = dbo_DimSalesReasonDataClass.Add(clsdbo_DimSalesReason);
			    if (bSucess == true) {
				    pnlForm.Visible = false;
				    pnlSave.Visible = false;
				    pnlGrid.Visible = true;
				    lblMode.InnerText = "";
				    Session.Remove("dvdbo_DimSalesReason");
				    LoadGriddbo_DimSalesReason();
			    } else {
				    ec.ShowMessage(" Insert failed. ", " Dbo. Dim Sales Reason ");
			    }
		    }
        }

        private void UpdateRecord()
        {
		    dbo_DimSalesReasonClass oclsdbo_DimSalesReason = new dbo_DimSalesReasonClass();
		    dbo_DimSalesReasonClass clsdbo_DimSalesReason = new dbo_DimSalesReasonClass();

		    oclsdbo_DimSalesReason.SalesReasonKey = System.Convert.ToInt32(Session["SalesReasonKey"]);
		    oclsdbo_DimSalesReason = dbo_DimSalesReasonDataClass.Select_Record(oclsdbo_DimSalesReason);

		    if (VerifyData() == true) {
                            SetData(clsdbo_DimSalesReason);
			    bool bSucess = false;
			    bSucess = dbo_DimSalesReasonDataClass.Update(oclsdbo_DimSalesReason, clsdbo_DimSalesReason);
			    if (bSucess == true) {
				    pnlForm.Visible = false;
				    pnlSave.Visible = false;
				    pnlGrid.Visible = true;
				    lblMode.InnerText = "";
				    Session.Remove("dvdbo_DimSalesReason");
				    LoadGriddbo_DimSalesReason();
			    } else {
				    ec.ShowMessage(" Update failed. ", " Dbo. Dim Sales Reason ");
			    }
		    }
        }

        private void DeleteRecord()
        {
		    dbo_DimSalesReasonClass clsdbo_DimSalesReason = new dbo_DimSalesReasonClass();
		    clsdbo_DimSalesReason.SalesReasonKey = System.Convert.ToInt32(Session["SalesReasonKey"]);
                    SetData(clsdbo_DimSalesReason);
		    bool bSucess = false;
		    bSucess = dbo_DimSalesReasonDataClass.Delete(clsdbo_DimSalesReason);
		    if (bSucess == true) {
			    pnlForm.Visible = false;
			    pnlSave.Visible = false;
			    pnlGrid.Visible = true;
			    pnlDelete.Visible = false;
			    lblMode.InnerText = "";
			    Session.Remove("dvdbo_DimSalesReason");
			    LoadGriddbo_DimSalesReason();
		    } else {
			    ec.ShowMessage(" Delete failed. ", " Dbo. Dim Sales Reason ");
		    }
        }

        private Boolean VerifyData()
        {
		    if (txtSalesReasonAlternateKey.Text == "") {
		    	ec.ShowMessage(" Sales Reason Alternate Key is Required. ", " Dbo. Dim Sales Reason ");
	                txtSalesReasonAlternateKey.Focus();
                	return false;}
		    if (txtSalesReasonName.Text == "") {
		    	ec.ShowMessage(" Sales Reason Name is Required. ", " Dbo. Dim Sales Reason ");
	                txtSalesReasonName.Focus();
                	return false;}
		    if (txtSalesReasonReasonType.Text == "") {
		    	ec.ShowMessage(" Sales Reason Reason Type is Required. ", " Dbo. Dim Sales Reason ");
	                txtSalesReasonReasonType.Focus();
                	return false;}
		    return true;
        }

        public void butRecords_Click(object sender, System.EventArgs e)
        {
		    grddbo_DimSalesReason.CurrentPageIndex = 0;
		    grddbo_DimSalesReason.PageSize = Convert.ToInt32(cmbRecords.Text);
		    LoadGriddbo_DimSalesReason();
        }

        public void btnAddNew_Click(object sender, System.EventArgs e)
        {
		    if (pnlForm.Visible) {
			    txtSalesReasonKey.Text = "";
			    txtSalesReasonAlternateKey.Text = "";
			    txtSalesReasonName.Text = "";
			    txtSalesReasonReasonType.Text = "";
		    } else {
			    pnlForm.Visible = true;
			    pnlGrid.Visible = false;
			    pnlSave.Visible = true;
			    lblMode.InnerText = "Add new";
		    }
		    btnSave.CommandArgument = "Add";
		    Add();
        }

        public void grddbo_DimSalesReason_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
        { 
		    if (e.Item.ItemType == ListItemType.Pager | e.Item.ItemType == ListItemType.Header)
			    return;

		    Button btn = (Button)e.CommandSource;
		    if (btn.Text == "Edit" | btn.Text == "Delete") {
			    Session.Remove("SalesReasonKey");
			    Session["SalesReasonKey"] = e.Item.Cells[0 + 0].Text;
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

        public void grddbo_DimSalesReason_SortCommand(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
        {
		    htmlHiddenSortExpression.Value = e.SortExpression + " " + GetSortDirection(e.SortExpression);
		    LoadGriddbo_DimSalesReason();
        }

        public void grddbo_DimSalesReason_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
        {
		    grddbo_DimSalesReason.CurrentPageIndex = e.NewPageIndex;
		    LoadGriddbo_DimSalesReason();
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
		    Session.Remove("dvdbo_DimSalesReason");
		    LoadGriddbo_DimSalesReason();
        }

        public void butSearch_Click(object sender, System.EventArgs e)
        {
		    try {
                        Session.Remove("dvdbo_DimSalesReason");
			if ((Session["dvdbo_DimSalesReason"] != null)) {
				dvdbo_DimSalesReason = (DataView)Session["dvdbo_DimSalesReason"];
				// DataView was not found in the session.
		    	} else {
				dvdbo_DimSalesReason = dbo_DimSalesReasonDataClass.Search(cmbFields.Text, cmbCondition.Text, txtSearch.Text).DefaultView;
			    	Session["dvdbo_DimSalesReason"] = dvdbo_DimSalesReason;
		    	}
                if (dvdbo_DimSalesReason.Count > 0)
                {
                    dvdbo_DimSalesReason.Sort = htmlHiddenSortExpression.Value;
                    grddbo_DimSalesReason.DataSource = dvdbo_DimSalesReason;
                    grddbo_DimSalesReason.DataBind();
                }
                else
                {
                    grddbo_DimSalesReason.DataSource = null;
                    grddbo_DimSalesReason.DataBind();
                }
		    }
		    catch (Exception ex)
		    {
		    	ec.ShowMessage(ex.Message, " Dbo. Dim Sales Reason ");
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
                    { dt = dbo_DimSalesReasonDataClass.Search(cmbFields.Text, cmbCondition.Text, txtSearch.Text); }
                    else { dt = dbo_DimSalesReasonDataClass.SelectAll(); }

                    PDFform pdfForm = new PDFform(dt, "Dbo. Dim Sales Reason", "Many");
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
                    GVExport.DataSource = Session["dvdbo_DimSalesReason"];
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
 
