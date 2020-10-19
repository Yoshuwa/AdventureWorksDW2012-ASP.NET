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
    public partial class frmdbo_FactProductInventory : System.Web.UI.Page
    {

        private dbo_FactProductInventoryDataClass clsdbo_FactProductInventoryData = new dbo_FactProductInventoryDataClass();
        private AdventureWorksDW2012DataClass clsAdventureWorksDW2012Data = new AdventureWorksDW2012DataClass();
        private DataView dvdbo_FactProductInventory;

        protected void Page_Load(object sender, EventArgs e)
        {
		    if (!Page.IsPostBack) {
			    Session["Mode"] = "";
 			    Session["ProductKey"] = "";
 			    Session["DateKey"] = "";

			    Session.Remove("dvdbo_FactProductInventory");

                            cmbFields.Items.Add("Product Key");
                            cmbFields.Items.Add("Date Key");
                            cmbFields.Items.Add("Movement Date");
                            cmbFields.Items.Add("Unit Cost");
                            cmbFields.Items.Add("Units In");
                            cmbFields.Items.Add("Units Out");
                            cmbFields.Items.Add("Units Balance");

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

            Loaddbo_FactProductInventory_dbo_DimProductComboBox265();
            Loaddbo_FactProductInventory_dbo_DimDateComboBox266();

			    LoadGriddbo_FactProductInventory();
		    }

        }


	    private void Loaddbo_FactProductInventory_dbo_DimProductComboBox265()
	    {
		    List<dbo_FactProductInventory_dbo_DimProductClass265> dbo_FactProductInventory_dbo_DimProductList = new  List<dbo_FactProductInventory_dbo_DimProductClass265>();
		    try {
			    dbo_FactProductInventory_dbo_DimProductList = dbo_FactProductInventory_dbo_DimProductDataClass265.List();
			    txtProductKey.DataSource = dbo_FactProductInventory_dbo_DimProductList;
			    txtProductKey.DataValueField = "ProductKey";
			    txtProductKey.DataTextField = "ProductAlternateKey";
			    txtProductKey.DataBind();
		    }
		    catch (Exception ex)
		    {
		    	ec.ShowMessage(ex.Message, " Dbo. Fact Product Inventory ");
		    }
	    }

	    private void Loaddbo_FactProductInventory_dbo_DimDateComboBox266()
	    {
		    List<dbo_FactProductInventory_dbo_DimDateClass266> dbo_FactProductInventory_dbo_DimDateList = new  List<dbo_FactProductInventory_dbo_DimDateClass266>();
		    try {
			    dbo_FactProductInventory_dbo_DimDateList = dbo_FactProductInventory_dbo_DimDateDataClass266.List();
			    txtDateKey.DataSource = dbo_FactProductInventory_dbo_DimDateList;
			    txtDateKey.DataValueField = "DateKey";
			    txtDateKey.DataTextField = "EnglishDayNameOfWeek";
			    txtDateKey.DataBind();
		    }
		    catch (Exception ex)
		    {
		    	ec.ShowMessage(ex.Message, " Dbo. Fact Product Inventory ");
		    }
	    }

        private void LoadGriddbo_FactProductInventory()
        {
		    try {
			if ((Session["dvdbo_FactProductInventory"] != null)) {
				dvdbo_FactProductInventory = (DataView)Session["dvdbo_FactProductInventory"];
				// DataView was not found in the session.
		    	} else {
				dvdbo_FactProductInventory = dbo_FactProductInventoryDataClass.SelectAll().DefaultView;
			    	Session["dvdbo_FactProductInventory"] = dvdbo_FactProductInventory;
		    	}
                if (dvdbo_FactProductInventory.Count > 0)
                {
                    dvdbo_FactProductInventory.Sort = htmlHiddenSortExpression.Value;
                    grddbo_FactProductInventory.DataSource = dvdbo_FactProductInventory;
                    grddbo_FactProductInventory.DataBind();
                }
                else
                {
                    grddbo_FactProductInventory.DataSource = null;
                    grddbo_FactProductInventory.DataBind();
                }
		    }
		    catch (Exception ex)
		    {
		    	ec.ShowMessage(ex.Message, " Dbo. Fact Product Inventory ");
		    }
        }

        private void Add()
        {
		    Session.Remove("Mode");
		    Session["Mode"] = "Add";

		    ClearRecord();

		    this.txtProductKey.Enabled = true;
		    this.txtDateKey.Enabled = true;
		    this.txtMovementDate.Enabled = true;
		    this.txtUnitCost.Enabled = true;
		    this.txtUnitsIn.Enabled = true;
		    this.txtUnitsOut.Enabled = true;
		    this.txtUnitsBalance.Enabled = true;
		    txtProductKey.Focus();
        }

        private void GetData()
        {
		    ClearRecord();

		    dbo_FactProductInventoryClass clsdbo_FactProductInventory = new dbo_FactProductInventoryClass();
		    clsdbo_FactProductInventory.ProductKey = System.Convert.ToInt32(Session["ProductKey"]);
		    clsdbo_FactProductInventory.DateKey = System.Convert.ToInt32(Session["DateKey"]);
		    clsdbo_FactProductInventory = dbo_FactProductInventoryDataClass.Select_Record(clsdbo_FactProductInventory);

		    if ((clsdbo_FactProductInventory != null)) {
			    try {
                		txtProductKey.SelectedValue = System.Convert.ToString(clsdbo_FactProductInventory.ProductKey);
                		txtDateKey.SelectedValue = System.Convert.ToString(clsdbo_FactProductInventory.DateKey);
                		txtMovementDate.Text = System.Convert.ToDateTime(clsdbo_FactProductInventory.MovementDate).ToShortDateString();
                		txtUnitCost.Text = System.Convert.ToString(clsdbo_FactProductInventory.UnitCost);
                		txtUnitsIn.Text = System.Convert.ToString(clsdbo_FactProductInventory.UnitsIn);
                		txtUnitsOut.Text = System.Convert.ToString(clsdbo_FactProductInventory.UnitsOut);
                		txtUnitsBalance.Text = System.Convert.ToString(clsdbo_FactProductInventory.UnitsBalance);
		   	 }
		    	catch (Exception ex)
		    	{
		    		ec.ShowMessage(ex.Message, " Dbo. Fact Product Inventory ");
		    	}
		    }

        }

        private void Edit()
        {
		    Session.Remove("Mode");
		    Session["Mode"] = "Edit";

                    GetData();

		    txtUnitCost.Enabled = true;
		    txtUnitsIn.Enabled = true;
		    txtUnitsOut.Enabled = true;
		    txtUnitsBalance.Enabled = true;
		    txtProductKey.Enabled = false;
		    txtDateKey.Enabled = false;
		    txtMovementDate.Focus();
        }

        private void Delete()
        {
		    Session.Remove("Mode");
		    Session["Mode"] = "Delete";

                    GetData();

		    txtProductKey.Enabled = false;
		    txtDateKey.Enabled = false;
		    txtMovementDate.Enabled = false;
		    txtUnitCost.Enabled = false;
		    txtUnitsIn.Enabled = false;
		    txtUnitsOut.Enabled = false;
		    txtUnitsBalance.Enabled = false;
        }

        private void ClearRecord()
        {
	        txtProductKey.SelectedIndex = -1;
	        txtDateKey.SelectedIndex = -1;
        	txtMovementDate.Text = null;
	        txtUnitCost.Text = null;
	        txtUnitsIn.Text = null;
	        txtUnitsOut.Text = null;
	        txtUnitsBalance.Text = null;
        }

        public void btnSave_Click(object sender, System.EventArgs e)
        {
		    if ((String)Session["Mode"] == "Add") {
			    this.InsertRecord();
		    } else if ((String)Session["Mode"] == "Edit") {
			    this.UpdateRecord();
		    }
        }

        private void SetData(dbo_FactProductInventoryClass clsdbo_FactProductInventory)
        {
			    clsdbo_FactProductInventory.ProductKey = System.Convert.ToInt32(txtProductKey.SelectedValue);
			    clsdbo_FactProductInventory.DateKey = System.Convert.ToInt32(txtDateKey.SelectedValue);
			    clsdbo_FactProductInventory.MovementDate = System.Convert.ToDateTime(txtMovementDate.Text);
			    clsdbo_FactProductInventory.UnitCost = System.Convert.ToDecimal(txtUnitCost.Text);
			    clsdbo_FactProductInventory.UnitsIn = System.Convert.ToInt32(txtUnitsIn.Text);
			    clsdbo_FactProductInventory.UnitsOut = System.Convert.ToInt32(txtUnitsOut.Text);
			    clsdbo_FactProductInventory.UnitsBalance = System.Convert.ToInt32(txtUnitsBalance.Text);
        }

        private void InsertRecord()
        {
		    dbo_FactProductInventoryClass clsdbo_FactProductInventory = new dbo_FactProductInventoryClass();
		    if (VerifyData() == true) {
                            SetData(clsdbo_FactProductInventory);
			    bool bSucess = false;
			    bSucess = dbo_FactProductInventoryDataClass.Add(clsdbo_FactProductInventory);
			    if (bSucess == true) {
				    pnlForm.Visible = false;
				    pnlSave.Visible = false;
				    pnlGrid.Visible = true;
				    lblMode.InnerText = "";
				    Session.Remove("dvdbo_FactProductInventory");
				    LoadGriddbo_FactProductInventory();
			    } else {
				    ec.ShowMessage(" Insert failed. ", " Dbo. Fact Product Inventory ");
			    }
		    }
        }

        private void UpdateRecord()
        {
		    dbo_FactProductInventoryClass oclsdbo_FactProductInventory = new dbo_FactProductInventoryClass();
		    dbo_FactProductInventoryClass clsdbo_FactProductInventory = new dbo_FactProductInventoryClass();

		    oclsdbo_FactProductInventory.ProductKey = System.Convert.ToInt32(Session["ProductKey"]);
		    oclsdbo_FactProductInventory.DateKey = System.Convert.ToInt32(Session["DateKey"]);
		    oclsdbo_FactProductInventory = dbo_FactProductInventoryDataClass.Select_Record(oclsdbo_FactProductInventory);

		    if (VerifyData() == true) {
                            SetData(clsdbo_FactProductInventory);
			    bool bSucess = false;
			    bSucess = dbo_FactProductInventoryDataClass.Update(oclsdbo_FactProductInventory, clsdbo_FactProductInventory);
			    if (bSucess == true) {
				    pnlForm.Visible = false;
				    pnlSave.Visible = false;
				    pnlGrid.Visible = true;
				    lblMode.InnerText = "";
				    Session.Remove("dvdbo_FactProductInventory");
				    LoadGriddbo_FactProductInventory();
			    } else {
				    ec.ShowMessage(" Update failed. ", " Dbo. Fact Product Inventory ");
			    }
		    }
        }

        private void DeleteRecord()
        {
		    dbo_FactProductInventoryClass clsdbo_FactProductInventory = new dbo_FactProductInventoryClass();
		    clsdbo_FactProductInventory.ProductKey = System.Convert.ToInt32(Session["ProductKey"]);
		    clsdbo_FactProductInventory.DateKey = System.Convert.ToInt32(Session["DateKey"]);
                    SetData(clsdbo_FactProductInventory);
		    bool bSucess = false;
		    bSucess = dbo_FactProductInventoryDataClass.Delete(clsdbo_FactProductInventory);
		    if (bSucess == true) {
			    pnlForm.Visible = false;
			    pnlSave.Visible = false;
			    pnlGrid.Visible = true;
			    pnlDelete.Visible = false;
			    lblMode.InnerText = "";
			    Session.Remove("dvdbo_FactProductInventory");
			    LoadGriddbo_FactProductInventory();
		    } else {
			    ec.ShowMessage(" Delete failed. ", " Dbo. Fact Product Inventory ");
		    }
        }

        private Boolean VerifyData()
        {
		    if (txtProductKey.Text == "") {
		    	ec.ShowMessage(" Product Key is Required. ", " Dbo. Fact Product Inventory ");
	                txtProductKey.Focus();
                	return false;}
		    if (txtDateKey.Text == "") {
		    	ec.ShowMessage(" Date Key is Required. ", " Dbo. Fact Product Inventory ");
	                txtDateKey.Focus();
                	return false;}
            
		    if (txtUnitCost.Text == "") {
		    	ec.ShowMessage(" Unit Cost is Required. ", " Dbo. Fact Product Inventory ");
	                txtUnitCost.Focus();
                	return false;}
		    if (txtUnitsIn.Text == "") {
		    	ec.ShowMessage(" Units In is Required. ", " Dbo. Fact Product Inventory ");
	                txtUnitsIn.Focus();
                	return false;}
		    if (txtUnitsOut.Text == "") {
		    	ec.ShowMessage(" Units Out is Required. ", " Dbo. Fact Product Inventory ");
	                txtUnitsOut.Focus();
                	return false;}
		    if (txtUnitsBalance.Text == "") {
		    	ec.ShowMessage(" Units Balance is Required. ", " Dbo. Fact Product Inventory ");
	                txtUnitsBalance.Focus();
                	return false;}
            if (
            txtProductKey.SelectedIndex != -1 
            && txtDateKey.SelectedIndex != -1 
            )  {
            dbo_FactProductInventoryClass clsdbo_FactProductInventory = new dbo_FactProductInventoryClass();
            clsdbo_FactProductInventory.ProductKey = System.Convert.ToInt32(txtProductKey.SelectedValue);
            clsdbo_FactProductInventory.DateKey = System.Convert.ToInt32(txtDateKey.SelectedValue);
            clsdbo_FactProductInventory = dbo_FactProductInventoryDataClass.Select_Record(clsdbo_FactProductInventory);
		    if (clsdbo_FactProductInventory != null && (String)Session["Mode"] == "Add") {
                    	ec.ShowMessage(" Record already exists. ", " Dbo. Fact Product Inventory ");
                   	txtProductKey.Focus();
                	return false; }
            }
		    return true;
        }

        public void butRecords_Click(object sender, System.EventArgs e)
        {
		    grddbo_FactProductInventory.CurrentPageIndex = 0;
		    grddbo_FactProductInventory.PageSize = Convert.ToInt32(cmbRecords.Text);
		    LoadGriddbo_FactProductInventory();
        }

        public void btnAddNew_Click(object sender, System.EventArgs e)
        {
		    if (pnlForm.Visible) {
			    txtProductKey.SelectedIndex = -1;
			    txtDateKey.SelectedIndex = -1;
			    txtMovementDate.Text = "";
			    txtUnitCost.Text = "";
			    txtUnitsIn.Text = "";
			    txtUnitsOut.Text = "";
			    txtUnitsBalance.Text = "";
		    } else {
			    pnlForm.Visible = true;
			    pnlGrid.Visible = false;
			    pnlSave.Visible = true;
			    lblMode.InnerText = "Add new";
		    }
		    btnSave.CommandArgument = "Add";
		    Add();
        }

        public void grddbo_FactProductInventory_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
        { 
		    if (e.Item.ItemType == ListItemType.Pager | e.Item.ItemType == ListItemType.Header)
			    return;

		    Button btn = (Button)e.CommandSource;
		    if (btn.Text == "Edit" | btn.Text == "Delete") {
			    Session.Remove("ProductKey");
			    Session["ProductKey"] = e.Item.Cells[0 + 0].Text;
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

        public void grddbo_FactProductInventory_SortCommand(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
        {
		    htmlHiddenSortExpression.Value = e.SortExpression + " " + GetSortDirection(e.SortExpression);
		    LoadGriddbo_FactProductInventory();
        }

        public void grddbo_FactProductInventory_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
        {
		    grddbo_FactProductInventory.CurrentPageIndex = e.NewPageIndex;
		    LoadGriddbo_FactProductInventory();
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
		    Session.Remove("dvdbo_FactProductInventory");
		    LoadGriddbo_FactProductInventory();
        }

        public void butSearch_Click(object sender, System.EventArgs e)
        {
		    try {
                        Session.Remove("dvdbo_FactProductInventory");
			if ((Session["dvdbo_FactProductInventory"] != null)) {
				dvdbo_FactProductInventory = (DataView)Session["dvdbo_FactProductInventory"];
				// DataView was not found in the session.
		    	} else {
				dvdbo_FactProductInventory = dbo_FactProductInventoryDataClass.Search(cmbFields.Text, cmbCondition.Text, txtSearch.Text).DefaultView;
			    	Session["dvdbo_FactProductInventory"] = dvdbo_FactProductInventory;
		    	}
                if (dvdbo_FactProductInventory.Count > 0)
                {
                    dvdbo_FactProductInventory.Sort = htmlHiddenSortExpression.Value;
                    grddbo_FactProductInventory.DataSource = dvdbo_FactProductInventory;
                    grddbo_FactProductInventory.DataBind();
                }
                else
                {
                    grddbo_FactProductInventory.DataSource = null;
                    grddbo_FactProductInventory.DataBind();
                }
		    }
		    catch (Exception ex)
		    {
		    	ec.ShowMessage(ex.Message, " Dbo. Fact Product Inventory ");
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
                    { dt = dbo_FactProductInventoryDataClass.Search(cmbFields.Text, cmbCondition.Text, txtSearch.Text); }
                    else { dt = dbo_FactProductInventoryDataClass.SelectAll(); }

                    PDFform pdfForm = new PDFform(dt, "Dbo. Fact Product Inventory", "Many");
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
                    GVExport.DataSource = Session["dvdbo_FactProductInventory"];
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
 
