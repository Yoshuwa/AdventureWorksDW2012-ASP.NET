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
    public partial class frmdbo_FactInternetSalesReason : System.Web.UI.Page
    {

        private dbo_FactInternetSalesReasonDataClass clsdbo_FactInternetSalesReasonData = new dbo_FactInternetSalesReasonDataClass();
        private AdventureWorksDW2012DataClass clsAdventureWorksDW2012Data = new AdventureWorksDW2012DataClass();
        private DataView dvdbo_FactInternetSalesReason;

        protected void Page_Load(object sender, EventArgs e)
        {
		    if (!Page.IsPostBack) {
			    Session["Mode"] = "";
 			    Session["SalesOrderNumber"] = "";
 			    Session["SalesOrderLineNumber"] = "";
 			    Session["SalesReasonKey"] = "";

			    Session.Remove("dvdbo_FactInternetSalesReason");

                            cmbFields.Items.Add("Sales Order Number");
                            cmbFields.Items.Add("Sales Order Line Number");
                            cmbFields.Items.Add("Sales Reason Key");

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

            Loaddbo_FactInternetSalesReason_dbo_FactInternetSalesComboBox262();
            Loaddbo_FactInternetSalesReason_dbo_FactInternetSalesComboBox263();
            Loaddbo_FactInternetSalesReason_dbo_DimSalesReasonComboBox264();

			    LoadGriddbo_FactInternetSalesReason();
		    }

        }


	    private void Loaddbo_FactInternetSalesReason_dbo_FactInternetSalesComboBox262()
	    {
		    List<dbo_FactInternetSalesReason_dbo_FactInternetSalesClass262> dbo_FactInternetSalesReason_dbo_FactInternetSalesList = new  List<dbo_FactInternetSalesReason_dbo_FactInternetSalesClass262>();
		    try {
			    dbo_FactInternetSalesReason_dbo_FactInternetSalesList = dbo_FactInternetSalesReason_dbo_FactInternetSalesDataClass262.List();
			    txtSalesOrderNumber.DataSource = dbo_FactInternetSalesReason_dbo_FactInternetSalesList;
			    txtSalesOrderNumber.DataValueField = "SalesOrderNumber";
			    txtSalesOrderNumber.DataTextField = "ProductKey";
			    txtSalesOrderNumber.DataBind();
		    }
		    catch (Exception ex)
		    {
		    	ec.ShowMessage(ex.Message, " Dbo. Fact Internet Sales Reason ");
		    }
	    }

	    private void Loaddbo_FactInternetSalesReason_dbo_FactInternetSalesComboBox263()
	    {
		    List<dbo_FactInternetSalesReason_dbo_FactInternetSalesClass263> dbo_FactInternetSalesReason_dbo_FactInternetSalesList = new  List<dbo_FactInternetSalesReason_dbo_FactInternetSalesClass263>();
		    try {
			    dbo_FactInternetSalesReason_dbo_FactInternetSalesList = dbo_FactInternetSalesReason_dbo_FactInternetSalesDataClass263.List();
			    txtSalesOrderLineNumber.DataSource = dbo_FactInternetSalesReason_dbo_FactInternetSalesList;
			    txtSalesOrderLineNumber.DataValueField = "SalesOrderLineNumber";
			    txtSalesOrderLineNumber.DataTextField = "ProductKey";
			    txtSalesOrderLineNumber.DataBind();
		    }
		    catch (Exception ex)
		    {
		    	ec.ShowMessage(ex.Message, " Dbo. Fact Internet Sales Reason ");
		    }
	    }

	    private void Loaddbo_FactInternetSalesReason_dbo_DimSalesReasonComboBox264()
	    {
		    List<dbo_FactInternetSalesReason_dbo_DimSalesReasonClass264> dbo_FactInternetSalesReason_dbo_DimSalesReasonList = new  List<dbo_FactInternetSalesReason_dbo_DimSalesReasonClass264>();
		    try {
			    dbo_FactInternetSalesReason_dbo_DimSalesReasonList = dbo_FactInternetSalesReason_dbo_DimSalesReasonDataClass264.List();
			    txtSalesReasonKey.DataSource = dbo_FactInternetSalesReason_dbo_DimSalesReasonList;
			    txtSalesReasonKey.DataValueField = "SalesReasonKey";
			    txtSalesReasonKey.DataTextField = "SalesReasonName";
			    txtSalesReasonKey.DataBind();
		    }
		    catch (Exception ex)
		    {
		    	ec.ShowMessage(ex.Message, " Dbo. Fact Internet Sales Reason ");
		    }
	    }

        private void LoadGriddbo_FactInternetSalesReason()
        {
		    try {
			if ((Session["dvdbo_FactInternetSalesReason"] != null)) {
				dvdbo_FactInternetSalesReason = (DataView)Session["dvdbo_FactInternetSalesReason"];
				// DataView was not found in the session.
		    	} else {
				dvdbo_FactInternetSalesReason = dbo_FactInternetSalesReasonDataClass.SelectAll().DefaultView;
			    	Session["dvdbo_FactInternetSalesReason"] = dvdbo_FactInternetSalesReason;
		    	}
                if (dvdbo_FactInternetSalesReason.Count > 0)
                {
                    dvdbo_FactInternetSalesReason.Sort = htmlHiddenSortExpression.Value;
                    grddbo_FactInternetSalesReason.DataSource = dvdbo_FactInternetSalesReason;
                    grddbo_FactInternetSalesReason.DataBind();
                }
                else
                {
                    grddbo_FactInternetSalesReason.DataSource = null;
                    grddbo_FactInternetSalesReason.DataBind();
                }
		    }
		    catch (Exception ex)
		    {
		    	ec.ShowMessage(ex.Message, " Dbo. Fact Internet Sales Reason ");
		    }
        }

        private void Add()
        {
		    Session.Remove("Mode");
		    Session["Mode"] = "Add";

		    ClearRecord();

		    this.txtSalesOrderNumber.Enabled = true;
		    this.txtSalesOrderLineNumber.Enabled = true;
		    this.txtSalesReasonKey.Enabled = true;
		    txtSalesOrderNumber.Focus();
        }

        private void GetData()
        {
		    ClearRecord();

		    dbo_FactInternetSalesReasonClass clsdbo_FactInternetSalesReason = new dbo_FactInternetSalesReasonClass();
		    clsdbo_FactInternetSalesReason.SalesOrderNumber = System.Convert.ToString(Session["SalesOrderNumber"]);
		    clsdbo_FactInternetSalesReason.SalesOrderLineNumber = System.Convert.ToByte(Session["SalesOrderLineNumber"]);
		    clsdbo_FactInternetSalesReason.SalesReasonKey = System.Convert.ToInt32(Session["SalesReasonKey"]);
		    clsdbo_FactInternetSalesReason = dbo_FactInternetSalesReasonDataClass.Select_Record(clsdbo_FactInternetSalesReason);

		    if ((clsdbo_FactInternetSalesReason != null)) {
			    try {
                		txtSalesOrderNumber.SelectedValue = System.Convert.ToString(clsdbo_FactInternetSalesReason.SalesOrderNumber);
                		txtSalesOrderLineNumber.SelectedValue = System.Convert.ToString(clsdbo_FactInternetSalesReason.SalesOrderLineNumber);
                		txtSalesReasonKey.SelectedValue = System.Convert.ToString(clsdbo_FactInternetSalesReason.SalesReasonKey);
		   	 }
		    	catch (Exception ex)
		    	{
		    		ec.ShowMessage(ex.Message, " Dbo. Fact Internet Sales Reason ");
		    	}
		    }

        }

        private void Edit()
        {
		    Session.Remove("Mode");
		    Session["Mode"] = "Edit";

                    GetData();

		    txtSalesOrderNumber.Enabled = false;
		    txtSalesOrderLineNumber.Enabled = false;
		    txtSalesReasonKey.Enabled = false;
        }

        private void Delete()
        {
		    Session.Remove("Mode");
		    Session["Mode"] = "Delete";

                    GetData();

		    txtSalesOrderNumber.Enabled = false;
		    txtSalesOrderLineNumber.Enabled = false;
		    txtSalesReasonKey.Enabled = false;
        }

        private void ClearRecord()
        {
	        txtSalesOrderNumber.SelectedIndex = -1;
	        txtSalesOrderLineNumber.SelectedIndex = -1;
	        txtSalesReasonKey.SelectedIndex = -1;
        }

        public void btnSave_Click(object sender, System.EventArgs e)
        {
		    if ((String)Session["Mode"] == "Add") {
			    this.InsertRecord();
		    } else if ((String)Session["Mode"] == "Edit") {
			    this.UpdateRecord();
		    }
        }

        private void SetData(dbo_FactInternetSalesReasonClass clsdbo_FactInternetSalesReason)
        {
			    clsdbo_FactInternetSalesReason.SalesOrderNumber = System.Convert.ToString(txtSalesOrderNumber.SelectedValue);
			    clsdbo_FactInternetSalesReason.SalesOrderLineNumber = System.Convert.ToByte(txtSalesOrderLineNumber.SelectedValue);
			    clsdbo_FactInternetSalesReason.SalesReasonKey = System.Convert.ToInt32(txtSalesReasonKey.SelectedValue);
        }

        private void InsertRecord()
        {
		    dbo_FactInternetSalesReasonClass clsdbo_FactInternetSalesReason = new dbo_FactInternetSalesReasonClass();
		    if (VerifyData() == true) {
                            SetData(clsdbo_FactInternetSalesReason);
			    bool bSucess = false;
			    bSucess = dbo_FactInternetSalesReasonDataClass.Add(clsdbo_FactInternetSalesReason);
			    if (bSucess == true) {
				    pnlForm.Visible = false;
				    pnlSave.Visible = false;
				    pnlGrid.Visible = true;
				    lblMode.InnerText = "";
				    Session.Remove("dvdbo_FactInternetSalesReason");
				    LoadGriddbo_FactInternetSalesReason();
			    } else {
				    ec.ShowMessage(" Insert failed. ", " Dbo. Fact Internet Sales Reason ");
			    }
		    }
        }

        private void UpdateRecord()
        {
		    dbo_FactInternetSalesReasonClass oclsdbo_FactInternetSalesReason = new dbo_FactInternetSalesReasonClass();
		    dbo_FactInternetSalesReasonClass clsdbo_FactInternetSalesReason = new dbo_FactInternetSalesReasonClass();

		    oclsdbo_FactInternetSalesReason.SalesOrderNumber = System.Convert.ToString(Session["SalesOrderNumber"]);
		    oclsdbo_FactInternetSalesReason.SalesOrderLineNumber = System.Convert.ToByte(Session["SalesOrderLineNumber"]);
		    oclsdbo_FactInternetSalesReason.SalesReasonKey = System.Convert.ToInt32(Session["SalesReasonKey"]);
		    oclsdbo_FactInternetSalesReason = dbo_FactInternetSalesReasonDataClass.Select_Record(oclsdbo_FactInternetSalesReason);

		    if (VerifyData() == true) {
                            SetData(clsdbo_FactInternetSalesReason);
			    bool bSucess = false;
			    bSucess = dbo_FactInternetSalesReasonDataClass.Update(oclsdbo_FactInternetSalesReason, clsdbo_FactInternetSalesReason);
			    if (bSucess == true) {
				    pnlForm.Visible = false;
				    pnlSave.Visible = false;
				    pnlGrid.Visible = true;
				    lblMode.InnerText = "";
				    Session.Remove("dvdbo_FactInternetSalesReason");
				    LoadGriddbo_FactInternetSalesReason();
			    } else {
				    ec.ShowMessage(" Update failed. ", " Dbo. Fact Internet Sales Reason ");
			    }
		    }
        }

        private void DeleteRecord()
        {
		    dbo_FactInternetSalesReasonClass clsdbo_FactInternetSalesReason = new dbo_FactInternetSalesReasonClass();
		    clsdbo_FactInternetSalesReason.SalesOrderNumber = System.Convert.ToString(Session["SalesOrderNumber"]);
		    clsdbo_FactInternetSalesReason.SalesOrderLineNumber = System.Convert.ToByte(Session["SalesOrderLineNumber"]);
		    clsdbo_FactInternetSalesReason.SalesReasonKey = System.Convert.ToInt32(Session["SalesReasonKey"]);
                    SetData(clsdbo_FactInternetSalesReason);
		    bool bSucess = false;
		    bSucess = dbo_FactInternetSalesReasonDataClass.Delete(clsdbo_FactInternetSalesReason);
		    if (bSucess == true) {
			    pnlForm.Visible = false;
			    pnlSave.Visible = false;
			    pnlGrid.Visible = true;
			    pnlDelete.Visible = false;
			    lblMode.InnerText = "";
			    Session.Remove("dvdbo_FactInternetSalesReason");
			    LoadGriddbo_FactInternetSalesReason();
		    } else {
			    ec.ShowMessage(" Delete failed. ", " Dbo. Fact Internet Sales Reason ");
		    }
        }

        private Boolean VerifyData()
        {
		    if (txtSalesOrderNumber.Text == "") {
		    	ec.ShowMessage(" Sales Order Number is Required. ", " Dbo. Fact Internet Sales Reason ");
	                txtSalesOrderNumber.Focus();
                	return false;}
		    if (txtSalesOrderLineNumber.Text == "") {
		    	ec.ShowMessage(" Sales Order Line Number is Required. ", " Dbo. Fact Internet Sales Reason ");
	                txtSalesOrderLineNumber.Focus();
                	return false;}
		    if (txtSalesReasonKey.Text == "") {
		    	ec.ShowMessage(" Sales Reason Key is Required. ", " Dbo. Fact Internet Sales Reason ");
	                txtSalesReasonKey.Focus();
                	return false;}
            if (
            txtSalesOrderNumber.SelectedIndex != -1 
            && txtSalesOrderLineNumber.SelectedIndex != -1 
            && txtSalesReasonKey.SelectedIndex != -1 
            )  {
            dbo_FactInternetSalesReasonClass clsdbo_FactInternetSalesReason = new dbo_FactInternetSalesReasonClass();
            clsdbo_FactInternetSalesReason.SalesOrderNumber = System.Convert.ToString(txtSalesOrderNumber.SelectedValue);
            clsdbo_FactInternetSalesReason.SalesOrderLineNumber = System.Convert.ToByte(txtSalesOrderLineNumber.SelectedValue);
            clsdbo_FactInternetSalesReason.SalesReasonKey = System.Convert.ToInt32(txtSalesReasonKey.SelectedValue);
            clsdbo_FactInternetSalesReason = dbo_FactInternetSalesReasonDataClass.Select_Record(clsdbo_FactInternetSalesReason);
		    if (clsdbo_FactInternetSalesReason != null && (String)Session["Mode"] == "Add") {
                    	ec.ShowMessage(" Record already exists. ", " Dbo. Fact Internet Sales Reason ");
                   	txtSalesOrderNumber.Focus();
                	return false; }
            }
		    return true;
        }

        public void butRecords_Click(object sender, System.EventArgs e)
        {
		    grddbo_FactInternetSalesReason.CurrentPageIndex = 0;
		    grddbo_FactInternetSalesReason.PageSize = Convert.ToInt32(cmbRecords.Text);
		    LoadGriddbo_FactInternetSalesReason();
        }

        public void btnAddNew_Click(object sender, System.EventArgs e)
        {
		    if (pnlForm.Visible) {
			    txtSalesOrderNumber.SelectedIndex = -1;
			    txtSalesOrderLineNumber.SelectedIndex = -1;
			    txtSalesReasonKey.SelectedIndex = -1;
		    } else {
			    pnlForm.Visible = true;
			    pnlGrid.Visible = false;
			    pnlSave.Visible = true;
			    lblMode.InnerText = "Add new";
		    }
		    btnSave.CommandArgument = "Add";
		    Add();
        }

        public void grddbo_FactInternetSalesReason_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
        { 
		    if (e.Item.ItemType == ListItemType.Pager | e.Item.ItemType == ListItemType.Header)
			    return;

		    Button btn = (Button)e.CommandSource;
		    if (btn.Text == "Edit" | btn.Text == "Delete") {
			    Session.Remove("SalesOrderNumber");
			    Session["SalesOrderNumber"] = e.Item.Cells[0 + 0].Text;
			    Session.Remove("SalesOrderLineNumber");
			    Session["SalesOrderLineNumber"] = e.Item.Cells[1 + 1].Text;
			    Session.Remove("SalesReasonKey");
			    Session["SalesReasonKey"] = e.Item.Cells[2 + 2].Text;
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

        public void grddbo_FactInternetSalesReason_SortCommand(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
        {
		    htmlHiddenSortExpression.Value = e.SortExpression + " " + GetSortDirection(e.SortExpression);
		    LoadGriddbo_FactInternetSalesReason();
        }

        public void grddbo_FactInternetSalesReason_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
        {
		    grddbo_FactInternetSalesReason.CurrentPageIndex = e.NewPageIndex;
		    LoadGriddbo_FactInternetSalesReason();
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
		    Session.Remove("dvdbo_FactInternetSalesReason");
		    LoadGriddbo_FactInternetSalesReason();
        }

        public void butSearch_Click(object sender, System.EventArgs e)
        {
		    try {
                        Session.Remove("dvdbo_FactInternetSalesReason");
			if ((Session["dvdbo_FactInternetSalesReason"] != null)) {
				dvdbo_FactInternetSalesReason = (DataView)Session["dvdbo_FactInternetSalesReason"];
				// DataView was not found in the session.
		    	} else {
				dvdbo_FactInternetSalesReason = dbo_FactInternetSalesReasonDataClass.Search(cmbFields.Text, cmbCondition.Text, txtSearch.Text).DefaultView;
			    	Session["dvdbo_FactInternetSalesReason"] = dvdbo_FactInternetSalesReason;
		    	}
                if (dvdbo_FactInternetSalesReason.Count > 0)
                {
                    dvdbo_FactInternetSalesReason.Sort = htmlHiddenSortExpression.Value;
                    grddbo_FactInternetSalesReason.DataSource = dvdbo_FactInternetSalesReason;
                    grddbo_FactInternetSalesReason.DataBind();
                }
                else
                {
                    grddbo_FactInternetSalesReason.DataSource = null;
                    grddbo_FactInternetSalesReason.DataBind();
                }
		    }
		    catch (Exception ex)
		    {
		    	ec.ShowMessage(ex.Message, " Dbo. Fact Internet Sales Reason ");
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
                    { dt = dbo_FactInternetSalesReasonDataClass.Search(cmbFields.Text, cmbCondition.Text, txtSearch.Text); }
                    else { dt = dbo_FactInternetSalesReasonDataClass.SelectAll(); }

                    PDFform pdfForm = new PDFform(dt, "Dbo. Fact Internet Sales Reason", "Many");
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
                    GVExport.DataSource = Session["dvdbo_FactInternetSalesReason"];
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
 
