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
    public partial class frmdbo_DimDepartmentGroup : System.Web.UI.Page
    {

        private dbo_DimDepartmentGroupDataClass clsdbo_DimDepartmentGroupData = new dbo_DimDepartmentGroupDataClass();
        private AdventureWorksDW2012DataClass clsAdventureWorksDW2012Data = new AdventureWorksDW2012DataClass();
        private DataView dvdbo_DimDepartmentGroup;

        protected void Page_Load(object sender, EventArgs e)
        {
		    if (!Page.IsPostBack) {
			    Session["Mode"] = "";
 			    Session["DepartmentGroupKey"] = "";

			    Session.Remove("dvdbo_DimDepartmentGroup");

                            cmbFields.Items.Add("Department Group Key");
                            cmbFields.Items.Add("Parent Department Group Key");
                            cmbFields.Items.Add("Department Group Name");

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

            Loaddbo_DimDepartmentGroup_dbo_DimDepartmentGroupComboBox65();

			    LoadGriddbo_DimDepartmentGroup();
		    }

        }


	    private void Loaddbo_DimDepartmentGroup_dbo_DimDepartmentGroupComboBox65()
	    {
		    List<dbo_DimDepartmentGroup_dbo_DimDepartmentGroupClass65> dbo_DimDepartmentGroup_dbo_DimDepartmentGroupList = new  List<dbo_DimDepartmentGroup_dbo_DimDepartmentGroupClass65>();
		    try {
			    dbo_DimDepartmentGroup_dbo_DimDepartmentGroupList = dbo_DimDepartmentGroup_dbo_DimDepartmentGroupDataClass65.List();
			    txtParentDepartmentGroupKey.DataSource = dbo_DimDepartmentGroup_dbo_DimDepartmentGroupList;
			    txtParentDepartmentGroupKey.DataValueField = "DepartmentGroupKey";
			    txtParentDepartmentGroupKey.DataTextField = "DepartmentGroupName";
			    txtParentDepartmentGroupKey.DataBind();
		    }
		    catch (Exception ex)
		    {
		    	ec.ShowMessage(ex.Message, " Dbo. Dim Department Group ");
		    }
	    }

        private void LoadGriddbo_DimDepartmentGroup()
        {
		    try {
			if ((Session["dvdbo_DimDepartmentGroup"] != null)) {
				dvdbo_DimDepartmentGroup = (DataView)Session["dvdbo_DimDepartmentGroup"];
				// DataView was not found in the session.
		    	} else {
				dvdbo_DimDepartmentGroup = dbo_DimDepartmentGroupDataClass.SelectAll().DefaultView;
			    	Session["dvdbo_DimDepartmentGroup"] = dvdbo_DimDepartmentGroup;
		    	}
                if (dvdbo_DimDepartmentGroup.Count > 0)
                {
                    dvdbo_DimDepartmentGroup.Sort = htmlHiddenSortExpression.Value;
                    grddbo_DimDepartmentGroup.DataSource = dvdbo_DimDepartmentGroup;
                    grddbo_DimDepartmentGroup.DataBind();
                }
                else
                {
                    grddbo_DimDepartmentGroup.DataSource = null;
                    grddbo_DimDepartmentGroup.DataBind();
                }
		    }
		    catch (Exception ex)
		    {
		    	ec.ShowMessage(ex.Message, " Dbo. Dim Department Group ");
		    }
        }

        private void Add()
        {
		    Session.Remove("Mode");
		    Session["Mode"] = "Add";

		    ClearRecord();

		    this.txtParentDepartmentGroupKey.Enabled = true;
		    this.txtDepartmentGroupName.Enabled = true;
		    txtDepartmentGroupKey.Enabled = false;
		    txtParentDepartmentGroupKey.Focus();
		    txtDepartmentGroupKey.Text = Convert.ToString(clsAdventureWorksDW2012Data.getAutoID("New", "DimDepartmentGroup"));
        }

        private void GetData()
        {
		    ClearRecord();

		    dbo_DimDepartmentGroupClass clsdbo_DimDepartmentGroup = new dbo_DimDepartmentGroupClass();
		    clsdbo_DimDepartmentGroup.DepartmentGroupKey = System.Convert.ToInt32(Session["DepartmentGroupKey"]);
		    clsdbo_DimDepartmentGroup = dbo_DimDepartmentGroupDataClass.Select_Record(clsdbo_DimDepartmentGroup);

		    if ((clsdbo_DimDepartmentGroup != null)) {
			    try {
                		txtDepartmentGroupKey.Text = System.Convert.ToString(clsdbo_DimDepartmentGroup.DepartmentGroupKey);
                		if (clsdbo_DimDepartmentGroup.ParentDepartmentGroupKey == null) { txtParentDepartmentGroupKey.SelectedValue = default(string); } else { txtParentDepartmentGroupKey.SelectedValue = System.Convert.ToString(clsdbo_DimDepartmentGroup.ParentDepartmentGroupKey); }
                		if (clsdbo_DimDepartmentGroup.DepartmentGroupName == null) { txtDepartmentGroupName.Text = default(string); } else { txtDepartmentGroupName.Text = System.Convert.ToString(clsdbo_DimDepartmentGroup.DepartmentGroupName); }
		   	 }
		    	catch (Exception ex)
		    	{
		    		ec.ShowMessage(ex.Message, " Dbo. Dim Department Group ");
		    	}
		    }

        }

        private void Edit()
        {
		    Session.Remove("Mode");
		    Session["Mode"] = "Edit";

                    GetData();

		    txtParentDepartmentGroupKey.Enabled = true;
		    txtDepartmentGroupName.Enabled = true;
		    txtDepartmentGroupKey.Enabled = false;
		    txtParentDepartmentGroupKey.Focus();
        }

        private void Delete()
        {
		    Session.Remove("Mode");
		    Session["Mode"] = "Delete";

                    GetData();

		    txtDepartmentGroupKey.Enabled = false;
		    txtParentDepartmentGroupKey.Enabled = false;
		    txtDepartmentGroupName.Enabled = false;
        }

        private void ClearRecord()
        {
	        txtDepartmentGroupKey.Text = null;
	        txtParentDepartmentGroupKey.SelectedIndex = -1;
	        txtDepartmentGroupName.Text = null;
        }

        public void btnSave_Click(object sender, System.EventArgs e)
        {
		    if ((String)Session["Mode"] == "Add") {
			    this.InsertRecord();
		    } else if ((String)Session["Mode"] == "Edit") {
			    this.UpdateRecord();
		    }
        }

        private void SetData(dbo_DimDepartmentGroupClass clsdbo_DimDepartmentGroup)
        {
			    if (string.IsNullOrEmpty(txtParentDepartmentGroupKey.SelectedValue)) {
			    	clsdbo_DimDepartmentGroup.ParentDepartmentGroupKey = null;
			    } else {
			    	clsdbo_DimDepartmentGroup.ParentDepartmentGroupKey = System.Convert.ToInt32(txtParentDepartmentGroupKey.SelectedValue); }
			    if (string.IsNullOrEmpty(txtDepartmentGroupName.Text)) {
			    	clsdbo_DimDepartmentGroup.DepartmentGroupName = null;
			    } else {
			    	clsdbo_DimDepartmentGroup.DepartmentGroupName = txtDepartmentGroupName.Text; }
        }

        private void InsertRecord()
        {
		    dbo_DimDepartmentGroupClass clsdbo_DimDepartmentGroup = new dbo_DimDepartmentGroupClass();
		    if (VerifyData() == true) {
                            SetData(clsdbo_DimDepartmentGroup);
			    bool bSucess = false;
			    bSucess = dbo_DimDepartmentGroupDataClass.Add(clsdbo_DimDepartmentGroup);
			    if (bSucess == true) {
				    pnlForm.Visible = false;
				    pnlSave.Visible = false;
				    pnlGrid.Visible = true;
				    lblMode.InnerText = "";
				    Session.Remove("dvdbo_DimDepartmentGroup");
				    LoadGriddbo_DimDepartmentGroup();
			    } else {
				    ec.ShowMessage(" Insert failed. ", " Dbo. Dim Department Group ");
			    }
		    }
        }

        private void UpdateRecord()
        {
		    dbo_DimDepartmentGroupClass oclsdbo_DimDepartmentGroup = new dbo_DimDepartmentGroupClass();
		    dbo_DimDepartmentGroupClass clsdbo_DimDepartmentGroup = new dbo_DimDepartmentGroupClass();

		    oclsdbo_DimDepartmentGroup.DepartmentGroupKey = System.Convert.ToInt32(Session["DepartmentGroupKey"]);
		    oclsdbo_DimDepartmentGroup = dbo_DimDepartmentGroupDataClass.Select_Record(oclsdbo_DimDepartmentGroup);

		    if (VerifyData() == true) {
                            SetData(clsdbo_DimDepartmentGroup);
			    bool bSucess = false;
			    bSucess = dbo_DimDepartmentGroupDataClass.Update(oclsdbo_DimDepartmentGroup, clsdbo_DimDepartmentGroup);
			    if (bSucess == true) {
				    pnlForm.Visible = false;
				    pnlSave.Visible = false;
				    pnlGrid.Visible = true;
				    lblMode.InnerText = "";
				    Session.Remove("dvdbo_DimDepartmentGroup");
				    LoadGriddbo_DimDepartmentGroup();
			    } else {
				    ec.ShowMessage(" Update failed. ", " Dbo. Dim Department Group ");
			    }
		    }
        }

        private void DeleteRecord()
        {
		    dbo_DimDepartmentGroupClass clsdbo_DimDepartmentGroup = new dbo_DimDepartmentGroupClass();
		    clsdbo_DimDepartmentGroup.DepartmentGroupKey = System.Convert.ToInt32(Session["DepartmentGroupKey"]);
                    SetData(clsdbo_DimDepartmentGroup);
		    bool bSucess = false;
		    bSucess = dbo_DimDepartmentGroupDataClass.Delete(clsdbo_DimDepartmentGroup);
		    if (bSucess == true) {
			    pnlForm.Visible = false;
			    pnlSave.Visible = false;
			    pnlGrid.Visible = true;
			    pnlDelete.Visible = false;
			    lblMode.InnerText = "";
			    Session.Remove("dvdbo_DimDepartmentGroup");
			    LoadGriddbo_DimDepartmentGroup();
		    } else {
			    ec.ShowMessage(" Delete failed. ", " Dbo. Dim Department Group ");
		    }
        }

        private Boolean VerifyData()
        {
		    return true;
        }

        public void butRecords_Click(object sender, System.EventArgs e)
        {
		    grddbo_DimDepartmentGroup.CurrentPageIndex = 0;
		    grddbo_DimDepartmentGroup.PageSize = Convert.ToInt32(cmbRecords.Text);
		    LoadGriddbo_DimDepartmentGroup();
        }

        public void btnAddNew_Click(object sender, System.EventArgs e)
        {
		    if (pnlForm.Visible) {
			    txtDepartmentGroupKey.Text = "";
			    txtParentDepartmentGroupKey.SelectedIndex = -1;
			    txtDepartmentGroupName.Text = "";
		    } else {
			    pnlForm.Visible = true;
			    pnlGrid.Visible = false;
			    pnlSave.Visible = true;
			    lblMode.InnerText = "Add new";
		    }
		    btnSave.CommandArgument = "Add";
		    Add();
        }

        public void grddbo_DimDepartmentGroup_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
        { 
		    if (e.Item.ItemType == ListItemType.Pager | e.Item.ItemType == ListItemType.Header)
			    return;

		    Button btn = (Button)e.CommandSource;
		    if (btn.Text == "Edit" | btn.Text == "Delete") {
			    Session.Remove("DepartmentGroupKey");
			    Session["DepartmentGroupKey"] = e.Item.Cells[0 + 0].Text;
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

        public void grddbo_DimDepartmentGroup_SortCommand(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
        {
		    htmlHiddenSortExpression.Value = e.SortExpression + " " + GetSortDirection(e.SortExpression);
		    LoadGriddbo_DimDepartmentGroup();
        }

        public void grddbo_DimDepartmentGroup_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
        {
		    grddbo_DimDepartmentGroup.CurrentPageIndex = e.NewPageIndex;
		    LoadGriddbo_DimDepartmentGroup();
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
		    Session.Remove("dvdbo_DimDepartmentGroup");
		    LoadGriddbo_DimDepartmentGroup();
        }

        public void butSearch_Click(object sender, System.EventArgs e)
        {
		    try {
                        Session.Remove("dvdbo_DimDepartmentGroup");
			if ((Session["dvdbo_DimDepartmentGroup"] != null)) {
				dvdbo_DimDepartmentGroup = (DataView)Session["dvdbo_DimDepartmentGroup"];
				// DataView was not found in the session.
		    	} else {
				dvdbo_DimDepartmentGroup = dbo_DimDepartmentGroupDataClass.Search(cmbFields.Text, cmbCondition.Text, txtSearch.Text).DefaultView;
			    	Session["dvdbo_DimDepartmentGroup"] = dvdbo_DimDepartmentGroup;
		    	}
                if (dvdbo_DimDepartmentGroup.Count > 0)
                {
                    dvdbo_DimDepartmentGroup.Sort = htmlHiddenSortExpression.Value;
                    grddbo_DimDepartmentGroup.DataSource = dvdbo_DimDepartmentGroup;
                    grddbo_DimDepartmentGroup.DataBind();
                }
                else
                {
                    grddbo_DimDepartmentGroup.DataSource = null;
                    grddbo_DimDepartmentGroup.DataBind();
                }
		    }
		    catch (Exception ex)
		    {
		    	ec.ShowMessage(ex.Message, " Dbo. Dim Department Group ");
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
                    { dt = dbo_DimDepartmentGroupDataClass.Search(cmbFields.Text, cmbCondition.Text, txtSearch.Text); }
                    else { dt = dbo_DimDepartmentGroupDataClass.SelectAll(); }

                    PDFform pdfForm = new PDFform(dt, "Dbo. Dim Department Group", "Many");
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
                    GVExport.DataSource = Session["dvdbo_DimDepartmentGroup"];
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
 
