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
    public partial class frmdbo_DimOrganization : System.Web.UI.Page
    {

        private dbo_DimOrganizationDataClass clsdbo_DimOrganizationData = new dbo_DimOrganizationDataClass();
        private AdventureWorksDW2012DataClass clsAdventureWorksDW2012Data = new AdventureWorksDW2012DataClass();
        private DataView dvdbo_DimOrganization;

        protected void Page_Load(object sender, EventArgs e)
        {
		    if (!Page.IsPostBack) {
			    Session["Mode"] = "";
 			    Session["OrganizationKey"] = "";

			    Session.Remove("dvdbo_DimOrganization");

                            cmbFields.Items.Add("Organization Key");
                            cmbFields.Items.Add("Parent Organization Key");
                            cmbFields.Items.Add("Percentage Of Ownership");
                            cmbFields.Items.Add("Organization Name");
                            cmbFields.Items.Add("Currency Key");

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

            Loaddbo_DimOrganization_dbo_DimOrganizationComboBox109();
            Loaddbo_DimOrganization_dbo_DimCurrencyComboBox112();

			    LoadGriddbo_DimOrganization();
		    }

        }


	    private void Loaddbo_DimOrganization_dbo_DimOrganizationComboBox109()
	    {
		    List<dbo_DimOrganization_dbo_DimOrganizationClass109> dbo_DimOrganization_dbo_DimOrganizationList = new  List<dbo_DimOrganization_dbo_DimOrganizationClass109>();
		    try {
			    dbo_DimOrganization_dbo_DimOrganizationList = dbo_DimOrganization_dbo_DimOrganizationDataClass109.List();
			    txtParentOrganizationKey.DataSource = dbo_DimOrganization_dbo_DimOrganizationList;
			    txtParentOrganizationKey.DataValueField = "OrganizationKey";
			    txtParentOrganizationKey.DataTextField = "OrganizationName";
			    txtParentOrganizationKey.DataBind();
		    }
		    catch (Exception ex)
		    {
		    	ec.ShowMessage(ex.Message, " Dbo. Dim Organization ");
		    }
	    }

	    private void Loaddbo_DimOrganization_dbo_DimCurrencyComboBox112()
	    {
		    List<dbo_DimOrganization_dbo_DimCurrencyClass112> dbo_DimOrganization_dbo_DimCurrencyList = new  List<dbo_DimOrganization_dbo_DimCurrencyClass112>();
		    try {
			    dbo_DimOrganization_dbo_DimCurrencyList = dbo_DimOrganization_dbo_DimCurrencyDataClass112.List();
			    txtCurrencyKey.DataSource = dbo_DimOrganization_dbo_DimCurrencyList;
			    txtCurrencyKey.DataValueField = "CurrencyKey";
			    txtCurrencyKey.DataTextField = "CurrencyName";
			    txtCurrencyKey.DataBind();
		    }
		    catch (Exception ex)
		    {
		    	ec.ShowMessage(ex.Message, " Dbo. Dim Organization ");
		    }
	    }

        private void LoadGriddbo_DimOrganization()
        {
		    try {
			if ((Session["dvdbo_DimOrganization"] != null)) {
				dvdbo_DimOrganization = (DataView)Session["dvdbo_DimOrganization"];
				// DataView was not found in the session.
		    	} else {
				dvdbo_DimOrganization = dbo_DimOrganizationDataClass.SelectAll().DefaultView;
			    	Session["dvdbo_DimOrganization"] = dvdbo_DimOrganization;
		    	}
                if (dvdbo_DimOrganization.Count > 0)
                {
                    dvdbo_DimOrganization.Sort = htmlHiddenSortExpression.Value;
                    grddbo_DimOrganization.DataSource = dvdbo_DimOrganization;
                    grddbo_DimOrganization.DataBind();
                }
                else
                {
                    grddbo_DimOrganization.DataSource = null;
                    grddbo_DimOrganization.DataBind();
                }
		    }
		    catch (Exception ex)
		    {
		    	ec.ShowMessage(ex.Message, " Dbo. Dim Organization ");
		    }
        }

        private void Add()
        {
		    Session.Remove("Mode");
		    Session["Mode"] = "Add";

		    ClearRecord();

		    this.txtParentOrganizationKey.Enabled = true;
		    this.txtPercentageOfOwnership.Enabled = true;
		    this.txtOrganizationName.Enabled = true;
		    this.txtCurrencyKey.Enabled = true;
		    txtOrganizationKey.Enabled = false;
		    txtParentOrganizationKey.Focus();
		    txtOrganizationKey.Text = Convert.ToString(clsAdventureWorksDW2012Data.getAutoID("New", "DimOrganization"));
        }

        private void GetData()
        {
		    ClearRecord();

		    dbo_DimOrganizationClass clsdbo_DimOrganization = new dbo_DimOrganizationClass();
		    clsdbo_DimOrganization.OrganizationKey = System.Convert.ToInt32(Session["OrganizationKey"]);
		    clsdbo_DimOrganization = dbo_DimOrganizationDataClass.Select_Record(clsdbo_DimOrganization);

		    if ((clsdbo_DimOrganization != null)) {
			    try {
                		txtOrganizationKey.Text = System.Convert.ToString(clsdbo_DimOrganization.OrganizationKey);
                		if (clsdbo_DimOrganization.ParentOrganizationKey == null) { txtParentOrganizationKey.SelectedValue = default(string); } else { txtParentOrganizationKey.SelectedValue = System.Convert.ToString(clsdbo_DimOrganization.ParentOrganizationKey); }
                		if (clsdbo_DimOrganization.PercentageOfOwnership == null) { txtPercentageOfOwnership.Text = default(string); } else { txtPercentageOfOwnership.Text = System.Convert.ToString(clsdbo_DimOrganization.PercentageOfOwnership); }
                		if (clsdbo_DimOrganization.OrganizationName == null) { txtOrganizationName.Text = default(string); } else { txtOrganizationName.Text = System.Convert.ToString(clsdbo_DimOrganization.OrganizationName); }
                		if (clsdbo_DimOrganization.CurrencyKey == null) { txtCurrencyKey.SelectedValue = default(string); } else { txtCurrencyKey.SelectedValue = System.Convert.ToString(clsdbo_DimOrganization.CurrencyKey); }
		   	 }
		    	catch (Exception ex)
		    	{
		    		ec.ShowMessage(ex.Message, " Dbo. Dim Organization ");
		    	}
		    }

        }

        private void Edit()
        {
		    Session.Remove("Mode");
		    Session["Mode"] = "Edit";

                    GetData();

		    txtParentOrganizationKey.Enabled = true;
		    txtPercentageOfOwnership.Enabled = true;
		    txtOrganizationName.Enabled = true;
		    txtCurrencyKey.Enabled = true;
		    txtOrganizationKey.Enabled = false;
		    txtParentOrganizationKey.Focus();
        }

        private void Delete()
        {
		    Session.Remove("Mode");
		    Session["Mode"] = "Delete";

                    GetData();

		    txtOrganizationKey.Enabled = false;
		    txtParentOrganizationKey.Enabled = false;
		    txtPercentageOfOwnership.Enabled = false;
		    txtOrganizationName.Enabled = false;
		    txtCurrencyKey.Enabled = false;
        }

        private void ClearRecord()
        {
	        txtOrganizationKey.Text = null;
	        txtParentOrganizationKey.SelectedIndex = -1;
	        txtPercentageOfOwnership.Text = null;
	        txtOrganizationName.Text = null;
	        txtCurrencyKey.SelectedIndex = -1;
        }

        public void btnSave_Click(object sender, System.EventArgs e)
        {
		    if ((String)Session["Mode"] == "Add") {
			    this.InsertRecord();
		    } else if ((String)Session["Mode"] == "Edit") {
			    this.UpdateRecord();
		    }
        }

        private void SetData(dbo_DimOrganizationClass clsdbo_DimOrganization)
        {
			    if (string.IsNullOrEmpty(txtParentOrganizationKey.SelectedValue)) {
			    	clsdbo_DimOrganization.ParentOrganizationKey = null;
			    } else {
			    	clsdbo_DimOrganization.ParentOrganizationKey = System.Convert.ToInt32(txtParentOrganizationKey.SelectedValue); }
			    if (string.IsNullOrEmpty(txtPercentageOfOwnership.Text)) {
			    	clsdbo_DimOrganization.PercentageOfOwnership = null;
			    } else {
			    	clsdbo_DimOrganization.PercentageOfOwnership = txtPercentageOfOwnership.Text; }
			    if (string.IsNullOrEmpty(txtOrganizationName.Text)) {
			    	clsdbo_DimOrganization.OrganizationName = null;
			    } else {
			    	clsdbo_DimOrganization.OrganizationName = txtOrganizationName.Text; }
			    if (string.IsNullOrEmpty(txtCurrencyKey.SelectedValue)) {
			    	clsdbo_DimOrganization.CurrencyKey = null;
			    } else {
			    	clsdbo_DimOrganization.CurrencyKey = System.Convert.ToInt32(txtCurrencyKey.SelectedValue); }
        }

        private void InsertRecord()
        {
		    dbo_DimOrganizationClass clsdbo_DimOrganization = new dbo_DimOrganizationClass();
		    if (VerifyData() == true) {
                            SetData(clsdbo_DimOrganization);
			    bool bSucess = false;
			    bSucess = dbo_DimOrganizationDataClass.Add(clsdbo_DimOrganization);
			    if (bSucess == true) {
				    pnlForm.Visible = false;
				    pnlSave.Visible = false;
				    pnlGrid.Visible = true;
				    lblMode.InnerText = "";
				    Session.Remove("dvdbo_DimOrganization");
				    LoadGriddbo_DimOrganization();
			    } else {
				    ec.ShowMessage(" Insert failed. ", " Dbo. Dim Organization ");
			    }
		    }
        }

        private void UpdateRecord()
        {
		    dbo_DimOrganizationClass oclsdbo_DimOrganization = new dbo_DimOrganizationClass();
		    dbo_DimOrganizationClass clsdbo_DimOrganization = new dbo_DimOrganizationClass();

		    oclsdbo_DimOrganization.OrganizationKey = System.Convert.ToInt32(Session["OrganizationKey"]);
		    oclsdbo_DimOrganization = dbo_DimOrganizationDataClass.Select_Record(oclsdbo_DimOrganization);

		    if (VerifyData() == true) {
                            SetData(clsdbo_DimOrganization);
			    bool bSucess = false;
			    bSucess = dbo_DimOrganizationDataClass.Update(oclsdbo_DimOrganization, clsdbo_DimOrganization);
			    if (bSucess == true) {
				    pnlForm.Visible = false;
				    pnlSave.Visible = false;
				    pnlGrid.Visible = true;
				    lblMode.InnerText = "";
				    Session.Remove("dvdbo_DimOrganization");
				    LoadGriddbo_DimOrganization();
			    } else {
				    ec.ShowMessage(" Update failed. ", " Dbo. Dim Organization ");
			    }
		    }
        }

        private void DeleteRecord()
        {
		    dbo_DimOrganizationClass clsdbo_DimOrganization = new dbo_DimOrganizationClass();
		    clsdbo_DimOrganization.OrganizationKey = System.Convert.ToInt32(Session["OrganizationKey"]);
                    SetData(clsdbo_DimOrganization);
		    bool bSucess = false;
		    bSucess = dbo_DimOrganizationDataClass.Delete(clsdbo_DimOrganization);
		    if (bSucess == true) {
			    pnlForm.Visible = false;
			    pnlSave.Visible = false;
			    pnlGrid.Visible = true;
			    pnlDelete.Visible = false;
			    lblMode.InnerText = "";
			    Session.Remove("dvdbo_DimOrganization");
			    LoadGriddbo_DimOrganization();
		    } else {
			    ec.ShowMessage(" Delete failed. ", " Dbo. Dim Organization ");
		    }
        }

        private Boolean VerifyData()
        {
		    return true;
        }

        public void butRecords_Click(object sender, System.EventArgs e)
        {
		    grddbo_DimOrganization.CurrentPageIndex = 0;
		    grddbo_DimOrganization.PageSize = Convert.ToInt32(cmbRecords.Text);
		    LoadGriddbo_DimOrganization();
        }

        public void btnAddNew_Click(object sender, System.EventArgs e)
        {
		    if (pnlForm.Visible) {
			    txtOrganizationKey.Text = "";
			    txtParentOrganizationKey.SelectedIndex = -1;
			    txtPercentageOfOwnership.Text = "";
			    txtOrganizationName.Text = "";
			    txtCurrencyKey.SelectedIndex = -1;
		    } else {
			    pnlForm.Visible = true;
			    pnlGrid.Visible = false;
			    pnlSave.Visible = true;
			    lblMode.InnerText = "Add new";
		    }
		    btnSave.CommandArgument = "Add";
		    Add();
        }

        public void grddbo_DimOrganization_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
        { 
		    if (e.Item.ItemType == ListItemType.Pager | e.Item.ItemType == ListItemType.Header)
			    return;

		    Button btn = (Button)e.CommandSource;
		    if (btn.Text == "Edit" | btn.Text == "Delete") {
			    Session.Remove("OrganizationKey");
			    Session["OrganizationKey"] = e.Item.Cells[0 + 0].Text;
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

        public void grddbo_DimOrganization_SortCommand(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
        {
		    htmlHiddenSortExpression.Value = e.SortExpression + " " + GetSortDirection(e.SortExpression);
		    LoadGriddbo_DimOrganization();
        }

        public void grddbo_DimOrganization_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
        {
		    grddbo_DimOrganization.CurrentPageIndex = e.NewPageIndex;
		    LoadGriddbo_DimOrganization();
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
		    Session.Remove("dvdbo_DimOrganization");
		    LoadGriddbo_DimOrganization();
        }

        public void butSearch_Click(object sender, System.EventArgs e)
        {
		    try {
                        Session.Remove("dvdbo_DimOrganization");
			if ((Session["dvdbo_DimOrganization"] != null)) {
				dvdbo_DimOrganization = (DataView)Session["dvdbo_DimOrganization"];
				// DataView was not found in the session.
		    	} else {
				dvdbo_DimOrganization = dbo_DimOrganizationDataClass.Search(cmbFields.Text, cmbCondition.Text, txtSearch.Text).DefaultView;
			    	Session["dvdbo_DimOrganization"] = dvdbo_DimOrganization;
		    	}
                if (dvdbo_DimOrganization.Count > 0)
                {
                    dvdbo_DimOrganization.Sort = htmlHiddenSortExpression.Value;
                    grddbo_DimOrganization.DataSource = dvdbo_DimOrganization;
                    grddbo_DimOrganization.DataBind();
                }
                else
                {
                    grddbo_DimOrganization.DataSource = null;
                    grddbo_DimOrganization.DataBind();
                }
		    }
		    catch (Exception ex)
		    {
		    	ec.ShowMessage(ex.Message, " Dbo. Dim Organization ");
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
                    { dt = dbo_DimOrganizationDataClass.Search(cmbFields.Text, cmbCondition.Text, txtSearch.Text); }
                    else { dt = dbo_DimOrganizationDataClass.SelectAll(); }

                    PDFform pdfForm = new PDFform(dt, "Dbo. Dim Organization", "Many");
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
                    GVExport.DataSource = Session["dvdbo_DimOrganization"];
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
 
