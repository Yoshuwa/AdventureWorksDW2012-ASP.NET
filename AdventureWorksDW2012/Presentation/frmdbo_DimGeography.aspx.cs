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
    public partial class frmdbo_DimGeography : System.Web.UI.Page
    {

        private dbo_DimGeographyDataClass clsdbo_DimGeographyData = new dbo_DimGeographyDataClass();
        private AdventureWorksDW2012DataClass clsAdventureWorksDW2012Data = new AdventureWorksDW2012DataClass();
        private DataView dvdbo_DimGeography;

        protected void Page_Load(object sender, EventArgs e)
        {
		    if (!Page.IsPostBack) {
			    Session["Mode"] = "";
 			    Session["GeographyKey"] = "";

			    Session.Remove("dvdbo_DimGeography");

                            cmbFields.Items.Add("Geography Key");
                            cmbFields.Items.Add("City");
                            cmbFields.Items.Add("State Province Code");
                            cmbFields.Items.Add("State Province Name");
                            cmbFields.Items.Add("Country Region Code");
                            cmbFields.Items.Add("English Country Region Name");
                            cmbFields.Items.Add("Spanish Country Region Name");
                            cmbFields.Items.Add("French Country Region Name");
                            cmbFields.Items.Add("Postal Code");
                            cmbFields.Items.Add("Sales Territory Key");
                            cmbFields.Items.Add("Ip Address Locator");

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

            Loaddbo_DimGeography_dbo_DimSalesTerritoryComboBox();

			    LoadGriddbo_DimGeography();
		    }

        }


	    private void Loaddbo_DimGeography_dbo_DimSalesTerritoryComboBox()
	    {
		    List<dbo_DimGeography_dbo_DimSalesTerritoryClass> dbo_DimGeography_dbo_DimSalesTerritoryList = new  List<dbo_DimGeography_dbo_DimSalesTerritoryClass>();
		    try {
			    dbo_DimGeography_dbo_DimSalesTerritoryList = dbo_DimGeography_dbo_DimSalesTerritoryDataClass.List();
			    txtSalesTerritoryKey.DataSource = dbo_DimGeography_dbo_DimSalesTerritoryList;
			    txtSalesTerritoryKey.DataValueField = "SalesTerritoryKey";
			    txtSalesTerritoryKey.DataTextField = "SalesTerritoryAlternateKey";
			    txtSalesTerritoryKey.DataBind();
		    }
		    catch (Exception ex)
		    {
		    	ec.ShowMessage(ex.Message, " Dbo. Dim Geography ");
		    }
	    }

        private void LoadGriddbo_DimGeography()
        {
		    try {
			if ((Session["dvdbo_DimGeography"] != null)) {
				dvdbo_DimGeography = (DataView)Session["dvdbo_DimGeography"];
				// DataView was not found in the session.
		    	} else {
				dvdbo_DimGeography = dbo_DimGeographyDataClass.SelectAll().DefaultView;
			    	Session["dvdbo_DimGeography"] = dvdbo_DimGeography;
		    	}
                if (dvdbo_DimGeography.Count > 0)
                {
                    dvdbo_DimGeography.Sort = htmlHiddenSortExpression.Value;
                    grddbo_DimGeography.DataSource = dvdbo_DimGeography;
                    grddbo_DimGeography.DataBind();
                }
                else
                {
                    grddbo_DimGeography.DataSource = null;
                    grddbo_DimGeography.DataBind();
                }
		    }
		    catch (Exception ex)
		    {
		    	ec.ShowMessage(ex.Message, " Dbo. Dim Geography ");
		    }
        }

        private void Add()
        {
		    Session.Remove("Mode");
		    Session["Mode"] = "Add";

		    ClearRecord();

		    this.txtCity.Enabled = true;
		    this.txtStateProvinceCode.Enabled = true;
		    this.txtStateProvinceName.Enabled = true;
		    this.txtCountryRegionCode.Enabled = true;
		    this.txtEnglishCountryRegionName.Enabled = true;
		    this.txtSpanishCountryRegionName.Enabled = true;
		    this.txtFrenchCountryRegionName.Enabled = true;
		    this.txtPostalCode.Enabled = true;
		    this.txtSalesTerritoryKey.Enabled = true;
		    this.txtIpAddressLocator.Enabled = true;
		    txtGeographyKey.Enabled = false;
		    txtCity.Focus();
		    txtGeographyKey.Text = Convert.ToString(clsAdventureWorksDW2012Data.getAutoID("New", "DimGeography"));
        }

        private void GetData()
        {
		    ClearRecord();

		    dbo_DimGeographyClass clsdbo_DimGeography = new dbo_DimGeographyClass();
		    clsdbo_DimGeography.GeographyKey = System.Convert.ToInt32(Session["GeographyKey"]);
		    clsdbo_DimGeography = dbo_DimGeographyDataClass.Select_Record(clsdbo_DimGeography);

		    if ((clsdbo_DimGeography != null)) {
			    try {
                		txtGeographyKey.Text = System.Convert.ToString(clsdbo_DimGeography.GeographyKey);
                		if (clsdbo_DimGeography.City == null) { txtCity.Text = default(string); } else { txtCity.Text = System.Convert.ToString(clsdbo_DimGeography.City); }
                		if (clsdbo_DimGeography.StateProvinceCode == null) { txtStateProvinceCode.Text = default(string); } else { txtStateProvinceCode.Text = System.Convert.ToString(clsdbo_DimGeography.StateProvinceCode); }
                		if (clsdbo_DimGeography.StateProvinceName == null) { txtStateProvinceName.Text = default(string); } else { txtStateProvinceName.Text = System.Convert.ToString(clsdbo_DimGeography.StateProvinceName); }
                		if (clsdbo_DimGeography.CountryRegionCode == null) { txtCountryRegionCode.Text = default(string); } else { txtCountryRegionCode.Text = System.Convert.ToString(clsdbo_DimGeography.CountryRegionCode); }
                		if (clsdbo_DimGeography.EnglishCountryRegionName == null) { txtEnglishCountryRegionName.Text = default(string); } else { txtEnglishCountryRegionName.Text = System.Convert.ToString(clsdbo_DimGeography.EnglishCountryRegionName); }
                		if (clsdbo_DimGeography.SpanishCountryRegionName == null) { txtSpanishCountryRegionName.Text = default(string); } else { txtSpanishCountryRegionName.Text = System.Convert.ToString(clsdbo_DimGeography.SpanishCountryRegionName); }
                		if (clsdbo_DimGeography.FrenchCountryRegionName == null) { txtFrenchCountryRegionName.Text = default(string); } else { txtFrenchCountryRegionName.Text = System.Convert.ToString(clsdbo_DimGeography.FrenchCountryRegionName); }
                		if (clsdbo_DimGeography.PostalCode == null) { txtPostalCode.Text = default(string); } else { txtPostalCode.Text = System.Convert.ToString(clsdbo_DimGeography.PostalCode); }
                		if (clsdbo_DimGeography.SalesTerritoryKey == null) { txtSalesTerritoryKey.SelectedValue = default(string); } else { txtSalesTerritoryKey.SelectedValue = System.Convert.ToString(clsdbo_DimGeography.SalesTerritoryKey); }
                		if (clsdbo_DimGeography.IpAddressLocator == null) { txtIpAddressLocator.Text = default(string); } else { txtIpAddressLocator.Text = System.Convert.ToString(clsdbo_DimGeography.IpAddressLocator); }
		   	 }
		    	catch (Exception ex)
		    	{
		    		ec.ShowMessage(ex.Message, " Dbo. Dim Geography ");
		    	}
		    }

        }

        private void Edit()
        {
		    Session.Remove("Mode");
		    Session["Mode"] = "Edit";

                    GetData();

		    txtCity.Enabled = true;
		    txtStateProvinceCode.Enabled = true;
		    txtStateProvinceName.Enabled = true;
		    txtCountryRegionCode.Enabled = true;
		    txtEnglishCountryRegionName.Enabled = true;
		    txtSpanishCountryRegionName.Enabled = true;
		    txtFrenchCountryRegionName.Enabled = true;
		    txtPostalCode.Enabled = true;
		    txtSalesTerritoryKey.Enabled = true;
		    txtIpAddressLocator.Enabled = true;
		    txtGeographyKey.Enabled = false;
		    txtCity.Focus();
        }

        private void Delete()
        {
		    Session.Remove("Mode");
		    Session["Mode"] = "Delete";

                    GetData();

		    txtGeographyKey.Enabled = false;
		    txtCity.Enabled = false;
		    txtStateProvinceCode.Enabled = false;
		    txtStateProvinceName.Enabled = false;
		    txtCountryRegionCode.Enabled = false;
		    txtEnglishCountryRegionName.Enabled = false;
		    txtSpanishCountryRegionName.Enabled = false;
		    txtFrenchCountryRegionName.Enabled = false;
		    txtPostalCode.Enabled = false;
		    txtSalesTerritoryKey.Enabled = false;
		    txtIpAddressLocator.Enabled = false;
        }

        private void ClearRecord()
        {
	        txtGeographyKey.Text = null;
	        txtCity.Text = null;
	        txtStateProvinceCode.Text = null;
	        txtStateProvinceName.Text = null;
	        txtCountryRegionCode.Text = null;
	        txtEnglishCountryRegionName.Text = null;
	        txtSpanishCountryRegionName.Text = null;
	        txtFrenchCountryRegionName.Text = null;
	        txtPostalCode.Text = null;
	        txtSalesTerritoryKey.SelectedIndex = -1;
	        txtIpAddressLocator.Text = null;
        }

        public void btnSave_Click(object sender, System.EventArgs e)
        {
		    if ((String)Session["Mode"] == "Add") {
			    this.InsertRecord();
		    } else if ((String)Session["Mode"] == "Edit") {
			    this.UpdateRecord();
		    }
        }

        private void SetData(dbo_DimGeographyClass clsdbo_DimGeography)
        {
			    if (string.IsNullOrEmpty(txtCity.Text)) {
			    	clsdbo_DimGeography.City = null;
			    } else {
			    	clsdbo_DimGeography.City = txtCity.Text; }
			    if (string.IsNullOrEmpty(txtStateProvinceCode.Text)) {
			    	clsdbo_DimGeography.StateProvinceCode = null;
			    } else {
			    	clsdbo_DimGeography.StateProvinceCode = txtStateProvinceCode.Text; }
			    if (string.IsNullOrEmpty(txtStateProvinceName.Text)) {
			    	clsdbo_DimGeography.StateProvinceName = null;
			    } else {
			    	clsdbo_DimGeography.StateProvinceName = txtStateProvinceName.Text; }
			    if (string.IsNullOrEmpty(txtCountryRegionCode.Text)) {
			    	clsdbo_DimGeography.CountryRegionCode = null;
			    } else {
			    	clsdbo_DimGeography.CountryRegionCode = txtCountryRegionCode.Text; }
			    if (string.IsNullOrEmpty(txtEnglishCountryRegionName.Text)) {
			    	clsdbo_DimGeography.EnglishCountryRegionName = null;
			    } else {
			    	clsdbo_DimGeography.EnglishCountryRegionName = txtEnglishCountryRegionName.Text; }
			    if (string.IsNullOrEmpty(txtSpanishCountryRegionName.Text)) {
			    	clsdbo_DimGeography.SpanishCountryRegionName = null;
			    } else {
			    	clsdbo_DimGeography.SpanishCountryRegionName = txtSpanishCountryRegionName.Text; }
			    if (string.IsNullOrEmpty(txtFrenchCountryRegionName.Text)) {
			    	clsdbo_DimGeography.FrenchCountryRegionName = null;
			    } else {
			    	clsdbo_DimGeography.FrenchCountryRegionName = txtFrenchCountryRegionName.Text; }
			    if (string.IsNullOrEmpty(txtPostalCode.Text)) {
			    	clsdbo_DimGeography.PostalCode = null;
			    } else {
			    	clsdbo_DimGeography.PostalCode = txtPostalCode.Text; }
			    if (string.IsNullOrEmpty(txtSalesTerritoryKey.SelectedValue)) {
			    	clsdbo_DimGeography.SalesTerritoryKey = null;
			    } else {
			    	clsdbo_DimGeography.SalesTerritoryKey = System.Convert.ToInt32(txtSalesTerritoryKey.SelectedValue); }
			    if (string.IsNullOrEmpty(txtIpAddressLocator.Text)) {
			    	clsdbo_DimGeography.IpAddressLocator = null;
			    } else {
			    	clsdbo_DimGeography.IpAddressLocator = txtIpAddressLocator.Text; }
        }

        private void InsertRecord()
        {
		    dbo_DimGeographyClass clsdbo_DimGeography = new dbo_DimGeographyClass();
		    if (VerifyData() == true) {
                            SetData(clsdbo_DimGeography);
			    bool bSucess = false;
			    bSucess = dbo_DimGeographyDataClass.Add(clsdbo_DimGeography);
			    if (bSucess == true) {
				    pnlForm.Visible = false;
				    pnlSave.Visible = false;
				    pnlGrid.Visible = true;
				    lblMode.InnerText = "";
				    Session.Remove("dvdbo_DimGeography");
				    LoadGriddbo_DimGeography();
			    } else {
				    ec.ShowMessage(" Insert failed. ", " Dbo. Dim Geography ");
			    }
		    }
        }

        private void UpdateRecord()
        {
		    dbo_DimGeographyClass oclsdbo_DimGeography = new dbo_DimGeographyClass();
		    dbo_DimGeographyClass clsdbo_DimGeography = new dbo_DimGeographyClass();

		    oclsdbo_DimGeography.GeographyKey = System.Convert.ToInt32(Session["GeographyKey"]);
		    oclsdbo_DimGeography = dbo_DimGeographyDataClass.Select_Record(oclsdbo_DimGeography);

		    if (VerifyData() == true) {
                            SetData(clsdbo_DimGeography);
			    bool bSucess = false;
			    bSucess = dbo_DimGeographyDataClass.Update(oclsdbo_DimGeography, clsdbo_DimGeography);
			    if (bSucess == true) {
				    pnlForm.Visible = false;
				    pnlSave.Visible = false;
				    pnlGrid.Visible = true;
				    lblMode.InnerText = "";
				    Session.Remove("dvdbo_DimGeography");
				    LoadGriddbo_DimGeography();
			    } else {
				    ec.ShowMessage(" Update failed. ", " Dbo. Dim Geography ");
			    }
		    }
        }

        private void DeleteRecord()
        {
		    dbo_DimGeographyClass clsdbo_DimGeography = new dbo_DimGeographyClass();
		    clsdbo_DimGeography.GeographyKey = System.Convert.ToInt32(Session["GeographyKey"]);
                    SetData(clsdbo_DimGeography);
		    bool bSucess = false;
		    bSucess = dbo_DimGeographyDataClass.Delete(clsdbo_DimGeography);
		    if (bSucess == true) {
			    pnlForm.Visible = false;
			    pnlSave.Visible = false;
			    pnlGrid.Visible = true;
			    pnlDelete.Visible = false;
			    lblMode.InnerText = "";
			    Session.Remove("dvdbo_DimGeography");
			    LoadGriddbo_DimGeography();
		    } else {
			    ec.ShowMessage(" Delete failed. ", " Dbo. Dim Geography ");
		    }
        }

        private Boolean VerifyData()
        {
		    return true;
        }

        public void butRecords_Click(object sender, System.EventArgs e)
        {
		    grddbo_DimGeography.CurrentPageIndex = 0;
		    grddbo_DimGeography.PageSize = Convert.ToInt32(cmbRecords.Text);
		    LoadGriddbo_DimGeography();
        }

        public void btnAddNew_Click(object sender, System.EventArgs e)
        {
		    if (pnlForm.Visible) {
			    txtGeographyKey.Text = "";
			    txtCity.Text = "";
			    txtStateProvinceCode.Text = "";
			    txtStateProvinceName.Text = "";
			    txtCountryRegionCode.Text = "";
			    txtEnglishCountryRegionName.Text = "";
			    txtSpanishCountryRegionName.Text = "";
			    txtFrenchCountryRegionName.Text = "";
			    txtPostalCode.Text = "";
			    txtSalesTerritoryKey.SelectedIndex = -1;
			    txtIpAddressLocator.Text = "";
		    } else {
			    pnlForm.Visible = true;
			    pnlGrid.Visible = false;
			    pnlSave.Visible = true;
			    lblMode.InnerText = "Add new";
		    }
		    btnSave.CommandArgument = "Add";
		    Add();
        }

        public void grddbo_DimGeography_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
        { 
		    if (e.Item.ItemType == ListItemType.Pager | e.Item.ItemType == ListItemType.Header)
			    return;

		    Button btn = (Button)e.CommandSource;
		    if (btn.Text == "Edit" | btn.Text == "Delete") {
			    Session.Remove("GeographyKey");
			    Session["GeographyKey"] = e.Item.Cells[0 + 0].Text;
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

        public void grddbo_DimGeography_SortCommand(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
        {
		    htmlHiddenSortExpression.Value = e.SortExpression + " " + GetSortDirection(e.SortExpression);
		    LoadGriddbo_DimGeography();
        }

        public void grddbo_DimGeography_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
        {
		    grddbo_DimGeography.CurrentPageIndex = e.NewPageIndex;
		    LoadGriddbo_DimGeography();
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
		    Session.Remove("dvdbo_DimGeography");
		    LoadGriddbo_DimGeography();
        }

        public void butSearch_Click(object sender, System.EventArgs e)
        {
		    try {
                        Session.Remove("dvdbo_DimGeography");
			if ((Session["dvdbo_DimGeography"] != null)) {
				dvdbo_DimGeography = (DataView)Session["dvdbo_DimGeography"];
				// DataView was not found in the session.
		    	} else {
				dvdbo_DimGeography = dbo_DimGeographyDataClass.Search(cmbFields.Text, cmbCondition.Text, txtSearch.Text).DefaultView;
			    	Session["dvdbo_DimGeography"] = dvdbo_DimGeography;
		    	}
                if (dvdbo_DimGeography.Count > 0)
                {
                    dvdbo_DimGeography.Sort = htmlHiddenSortExpression.Value;
                    grddbo_DimGeography.DataSource = dvdbo_DimGeography;
                    grddbo_DimGeography.DataBind();
                }
                else
                {
                    grddbo_DimGeography.DataSource = null;
                    grddbo_DimGeography.DataBind();
                }
		    }
		    catch (Exception ex)
		    {
		    	ec.ShowMessage(ex.Message, " Dbo. Dim Geography ");
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
                    { dt = dbo_DimGeographyDataClass.Search(cmbFields.Text, cmbCondition.Text, txtSearch.Text); }
                    else { dt = dbo_DimGeographyDataClass.SelectAll(); }

                    PDFform pdfForm = new PDFform(dt, "Dbo. Dim Geography", "Many");
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
                    GVExport.DataSource = Session["dvdbo_DimGeography"];
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
 
