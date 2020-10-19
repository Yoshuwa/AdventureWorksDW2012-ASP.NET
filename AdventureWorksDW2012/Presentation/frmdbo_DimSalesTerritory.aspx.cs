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
    public partial class frmdbo_DimSalesTerritory : System.Web.UI.Page
    {

        private dbo_DimSalesTerritoryDataClass clsdbo_DimSalesTerritoryData = new dbo_DimSalesTerritoryDataClass();
        private AdventureWorksDW2012DataClass clsAdventureWorksDW2012Data = new AdventureWorksDW2012DataClass();
        private DataView dvdbo_DimSalesTerritory;

        protected void Page_Load(object sender, EventArgs e)
        {
		    if (!Page.IsPostBack) {
			    Session["Mode"] = "";
 			    Session["SalesTerritoryKey"] = "";

			    Session.Remove("dvdbo_DimSalesTerritory");

                            cmbFields.Items.Add("Sales Territory Key");
                            cmbFields.Items.Add("Sales Territory Alternate Key");
                            cmbFields.Items.Add("Sales Territory Region");
                            cmbFields.Items.Add("Sales Territory Country");
                            cmbFields.Items.Add("Sales Territory Group");

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


			    LoadGriddbo_DimSalesTerritory();
		    }

        }


        private void LoadGriddbo_DimSalesTerritory()
        {
		    try {
			if ((Session["dvdbo_DimSalesTerritory"] != null)) {
				dvdbo_DimSalesTerritory = (DataView)Session["dvdbo_DimSalesTerritory"];
				// DataView was not found in the session.
		    	} else {
				dvdbo_DimSalesTerritory = dbo_DimSalesTerritoryDataClass.SelectAll().DefaultView;
			    	Session["dvdbo_DimSalesTerritory"] = dvdbo_DimSalesTerritory;
		    	}
                if (dvdbo_DimSalesTerritory.Count > 0)
                {
                    dvdbo_DimSalesTerritory.Sort = htmlHiddenSortExpression.Value;
                    grddbo_DimSalesTerritory.DataSource = dvdbo_DimSalesTerritory;
                    grddbo_DimSalesTerritory.DataBind();
                }
                else
                {
                    grddbo_DimSalesTerritory.DataSource = null;
                    grddbo_DimSalesTerritory.DataBind();
                }
		    }
		    catch (Exception ex)
		    {
		    	ec.ShowMessage(ex.Message, " Dbo. Dim Sales Territory ");
		    }
        }

        private void Add()
        {
		    Session.Remove("Mode");
		    Session["Mode"] = "Add";

		    ClearRecord();

		    this.txtSalesTerritoryAlternateKey.Enabled = true;
		    this.txtSalesTerritoryRegion.Enabled = true;
		    this.txtSalesTerritoryCountry.Enabled = true;
		    this.txtSalesTerritoryGroup.Enabled = true;
		    txtSalesTerritoryKey.Enabled = false;
		    txtSalesTerritoryAlternateKey.Focus();
		    txtSalesTerritoryKey.Text = Convert.ToString(clsAdventureWorksDW2012Data.getAutoID("New", "DimSalesTerritory"));
        }

        private void GetData()
        {
		    ClearRecord();

		    dbo_DimSalesTerritoryClass clsdbo_DimSalesTerritory = new dbo_DimSalesTerritoryClass();
		    clsdbo_DimSalesTerritory.SalesTerritoryKey = System.Convert.ToInt32(Session["SalesTerritoryKey"]);
		    clsdbo_DimSalesTerritory = dbo_DimSalesTerritoryDataClass.Select_Record(clsdbo_DimSalesTerritory);

		    if ((clsdbo_DimSalesTerritory != null)) {
			    try {
                		txtSalesTerritoryKey.Text = System.Convert.ToString(clsdbo_DimSalesTerritory.SalesTerritoryKey);
                		if (clsdbo_DimSalesTerritory.SalesTerritoryAlternateKey == null) { txtSalesTerritoryAlternateKey.Text = default(string); } else { txtSalesTerritoryAlternateKey.Text = System.Convert.ToString(clsdbo_DimSalesTerritory.SalesTerritoryAlternateKey); }
                		txtSalesTerritoryRegion.Text = System.Convert.ToString(clsdbo_DimSalesTerritory.SalesTerritoryRegion);
                		txtSalesTerritoryCountry.Text = System.Convert.ToString(clsdbo_DimSalesTerritory.SalesTerritoryCountry);
                		if (clsdbo_DimSalesTerritory.SalesTerritoryGroup == null) { txtSalesTerritoryGroup.Text = default(string); } else { txtSalesTerritoryGroup.Text = System.Convert.ToString(clsdbo_DimSalesTerritory.SalesTerritoryGroup); }
		   	 }
		    	catch (Exception ex)
		    	{
		    		ec.ShowMessage(ex.Message, " Dbo. Dim Sales Territory ");
		    	}
		    }

        }

        private void Edit()
        {
		    Session.Remove("Mode");
		    Session["Mode"] = "Edit";

                    GetData();

		    txtSalesTerritoryAlternateKey.Enabled = true;
		    txtSalesTerritoryRegion.Enabled = true;
		    txtSalesTerritoryCountry.Enabled = true;
		    txtSalesTerritoryGroup.Enabled = true;
		    txtSalesTerritoryKey.Enabled = false;
		    txtSalesTerritoryAlternateKey.Focus();
        }

        private void Delete()
        {
		    Session.Remove("Mode");
		    Session["Mode"] = "Delete";

                    GetData();

		    txtSalesTerritoryKey.Enabled = false;
		    txtSalesTerritoryAlternateKey.Enabled = false;
		    txtSalesTerritoryRegion.Enabled = false;
		    txtSalesTerritoryCountry.Enabled = false;
		    txtSalesTerritoryGroup.Enabled = false;
        }

        private void ClearRecord()
        {
	        txtSalesTerritoryKey.Text = null;
	        txtSalesTerritoryAlternateKey.Text = null;
	        txtSalesTerritoryRegion.Text = null;
	        txtSalesTerritoryCountry.Text = null;
	        txtSalesTerritoryGroup.Text = null;
        }

        public void btnSave_Click(object sender, System.EventArgs e)
        {
		    if ((String)Session["Mode"] == "Add") {
			    this.InsertRecord();
		    } else if ((String)Session["Mode"] == "Edit") {
			    this.UpdateRecord();
		    }
        }

        private void SetData(dbo_DimSalesTerritoryClass clsdbo_DimSalesTerritory)
        {
			    if (string.IsNullOrEmpty(txtSalesTerritoryAlternateKey.Text)) {
			    	clsdbo_DimSalesTerritory.SalesTerritoryAlternateKey = null;
			    } else {
			    	clsdbo_DimSalesTerritory.SalesTerritoryAlternateKey = System.Convert.ToInt32(txtSalesTerritoryAlternateKey.Text); }
			    clsdbo_DimSalesTerritory.SalesTerritoryRegion = System.Convert.ToString(txtSalesTerritoryRegion.Text);
			    clsdbo_DimSalesTerritory.SalesTerritoryCountry = System.Convert.ToString(txtSalesTerritoryCountry.Text);
			    if (string.IsNullOrEmpty(txtSalesTerritoryGroup.Text)) {
			    	clsdbo_DimSalesTerritory.SalesTerritoryGroup = null;
			    } else {
			    	clsdbo_DimSalesTerritory.SalesTerritoryGroup = txtSalesTerritoryGroup.Text; }
        }

        private void InsertRecord()
        {
		    dbo_DimSalesTerritoryClass clsdbo_DimSalesTerritory = new dbo_DimSalesTerritoryClass();
		    if (VerifyData() == true) {
                            SetData(clsdbo_DimSalesTerritory);
			    bool bSucess = false;
			    bSucess = dbo_DimSalesTerritoryDataClass.Add(clsdbo_DimSalesTerritory);
			    if (bSucess == true) {
				    pnlForm.Visible = false;
				    pnlSave.Visible = false;
				    pnlGrid.Visible = true;
				    lblMode.InnerText = "";
				    Session.Remove("dvdbo_DimSalesTerritory");
				    LoadGriddbo_DimSalesTerritory();
			    } else {
				    ec.ShowMessage(" Insert failed. ", " Dbo. Dim Sales Territory ");
			    }
		    }
        }

        private void UpdateRecord()
        {
		    dbo_DimSalesTerritoryClass oclsdbo_DimSalesTerritory = new dbo_DimSalesTerritoryClass();
		    dbo_DimSalesTerritoryClass clsdbo_DimSalesTerritory = new dbo_DimSalesTerritoryClass();

		    oclsdbo_DimSalesTerritory.SalesTerritoryKey = System.Convert.ToInt32(Session["SalesTerritoryKey"]);
		    oclsdbo_DimSalesTerritory = dbo_DimSalesTerritoryDataClass.Select_Record(oclsdbo_DimSalesTerritory);

		    if (VerifyData() == true) {
                            SetData(clsdbo_DimSalesTerritory);
			    bool bSucess = false;
			    bSucess = dbo_DimSalesTerritoryDataClass.Update(oclsdbo_DimSalesTerritory, clsdbo_DimSalesTerritory);
			    if (bSucess == true) {
				    pnlForm.Visible = false;
				    pnlSave.Visible = false;
				    pnlGrid.Visible = true;
				    lblMode.InnerText = "";
				    Session.Remove("dvdbo_DimSalesTerritory");
				    LoadGriddbo_DimSalesTerritory();
			    } else {
				    ec.ShowMessage(" Update failed. ", " Dbo. Dim Sales Territory ");
			    }
		    }
        }

        private void DeleteRecord()
        {
		    dbo_DimSalesTerritoryClass clsdbo_DimSalesTerritory = new dbo_DimSalesTerritoryClass();
		    clsdbo_DimSalesTerritory.SalesTerritoryKey = System.Convert.ToInt32(Session["SalesTerritoryKey"]);
                    SetData(clsdbo_DimSalesTerritory);
		    bool bSucess = false;
		    bSucess = dbo_DimSalesTerritoryDataClass.Delete(clsdbo_DimSalesTerritory);
		    if (bSucess == true) {
			    pnlForm.Visible = false;
			    pnlSave.Visible = false;
			    pnlGrid.Visible = true;
			    pnlDelete.Visible = false;
			    lblMode.InnerText = "";
			    Session.Remove("dvdbo_DimSalesTerritory");
			    LoadGriddbo_DimSalesTerritory();
		    } else {
			    ec.ShowMessage(" Delete failed. ", " Dbo. Dim Sales Territory ");
		    }
        }

        private Boolean VerifyData()
        {
		    if (txtSalesTerritoryRegion.Text == "") {
		    	ec.ShowMessage(" Sales Territory Region is Required. ", " Dbo. Dim Sales Territory ");
	                txtSalesTerritoryRegion.Focus();
                	return false;}
		    if (txtSalesTerritoryCountry.Text == "") {
		    	ec.ShowMessage(" Sales Territory Country is Required. ", " Dbo. Dim Sales Territory ");
	                txtSalesTerritoryCountry.Focus();
                	return false;}
		    return true;
        }

        public void butRecords_Click(object sender, System.EventArgs e)
        {
		    grddbo_DimSalesTerritory.CurrentPageIndex = 0;
		    grddbo_DimSalesTerritory.PageSize = Convert.ToInt32(cmbRecords.Text);
		    LoadGriddbo_DimSalesTerritory();
        }

        public void btnAddNew_Click(object sender, System.EventArgs e)
        {
		    if (pnlForm.Visible) {
			    txtSalesTerritoryKey.Text = "";
			    txtSalesTerritoryAlternateKey.Text = "";
			    txtSalesTerritoryRegion.Text = "";
			    txtSalesTerritoryCountry.Text = "";
			    txtSalesTerritoryGroup.Text = "";
		    } else {
			    pnlForm.Visible = true;
			    pnlGrid.Visible = false;
			    pnlSave.Visible = true;
			    lblMode.InnerText = "Add new";
		    }
		    btnSave.CommandArgument = "Add";
		    Add();
        }

        public void grddbo_DimSalesTerritory_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
        { 
		    if (e.Item.ItemType == ListItemType.Pager | e.Item.ItemType == ListItemType.Header)
			    return;

		    Button btn = (Button)e.CommandSource;
		    if (btn.Text == "Edit" | btn.Text == "Delete") {
			    Session.Remove("SalesTerritoryKey");
			    Session["SalesTerritoryKey"] = e.Item.Cells[0 + 0].Text;
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

        public void grddbo_DimSalesTerritory_SortCommand(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
        {
		    htmlHiddenSortExpression.Value = e.SortExpression + " " + GetSortDirection(e.SortExpression);
		    LoadGriddbo_DimSalesTerritory();
        }

        public void grddbo_DimSalesTerritory_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
        {
		    grddbo_DimSalesTerritory.CurrentPageIndex = e.NewPageIndex;
		    LoadGriddbo_DimSalesTerritory();
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
		    Session.Remove("dvdbo_DimSalesTerritory");
		    LoadGriddbo_DimSalesTerritory();
        }

        public void butSearch_Click(object sender, System.EventArgs e)
        {
		    try {
                        Session.Remove("dvdbo_DimSalesTerritory");
			if ((Session["dvdbo_DimSalesTerritory"] != null)) {
				dvdbo_DimSalesTerritory = (DataView)Session["dvdbo_DimSalesTerritory"];
				// DataView was not found in the session.
		    	} else {
				dvdbo_DimSalesTerritory = dbo_DimSalesTerritoryDataClass.Search(cmbFields.Text, cmbCondition.Text, txtSearch.Text).DefaultView;
			    	Session["dvdbo_DimSalesTerritory"] = dvdbo_DimSalesTerritory;
		    	}
                if (dvdbo_DimSalesTerritory.Count > 0)
                {
                    dvdbo_DimSalesTerritory.Sort = htmlHiddenSortExpression.Value;
                    grddbo_DimSalesTerritory.DataSource = dvdbo_DimSalesTerritory;
                    grddbo_DimSalesTerritory.DataBind();
                }
                else
                {
                    grddbo_DimSalesTerritory.DataSource = null;
                    grddbo_DimSalesTerritory.DataBind();
                }
		    }
		    catch (Exception ex)
		    {
		    	ec.ShowMessage(ex.Message, " Dbo. Dim Sales Territory ");
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
                    { dt = dbo_DimSalesTerritoryDataClass.Search(cmbFields.Text, cmbCondition.Text, txtSearch.Text); }
                    else { dt = dbo_DimSalesTerritoryDataClass.SelectAll(); }

                    PDFform pdfForm = new PDFform(dt, "Dbo. Dim Sales Territory", "Many");
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
                    GVExport.DataSource = Session["dvdbo_DimSalesTerritory"];
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
 
