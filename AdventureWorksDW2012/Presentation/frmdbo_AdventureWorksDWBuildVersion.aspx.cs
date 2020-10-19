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
    public partial class frmdbo_AdventureWorksDWBuildVersion : System.Web.UI.Page
    {

        private dbo_AdventureWorksDWBuildVersionDataClass clsdbo_AdventureWorksDWBuildVersionData = new dbo_AdventureWorksDWBuildVersionDataClass();
        private AdventureWorksDW2012DataClass clsAdventureWorksDW2012Data = new AdventureWorksDW2012DataClass();
        private DataView dvdbo_AdventureWorksDWBuildVersion;

        protected void Page_Load(object sender, EventArgs e)
        {
		    if (!Page.IsPostBack) {
			    Session["Mode"] = "";
			    Session["DBVersion"] = "";

			    Session.Remove("dvdbo_AdventureWorksDWBuildVersion");

                            cmbFields.Items.Add("D B Version");
                            cmbFields.Items.Add("Version Date");

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


			    LoadGriddbo_AdventureWorksDWBuildVersion();
		    }

        }


        private void LoadGriddbo_AdventureWorksDWBuildVersion()
        {
		    try {
			if ((Session["dvdbo_AdventureWorksDWBuildVersion"] != null)) {
				dvdbo_AdventureWorksDWBuildVersion = (DataView)Session["dvdbo_AdventureWorksDWBuildVersion"];
				// DataView was not found in the session.
		    	} else {
				dvdbo_AdventureWorksDWBuildVersion = dbo_AdventureWorksDWBuildVersionDataClass.SelectAll().DefaultView;
			    	Session["dvdbo_AdventureWorksDWBuildVersion"] = dvdbo_AdventureWorksDWBuildVersion;
		    	}
                if (dvdbo_AdventureWorksDWBuildVersion.Count > 0)
                {
                    dvdbo_AdventureWorksDWBuildVersion.Sort = htmlHiddenSortExpression.Value;
                    grddbo_AdventureWorksDWBuildVersion.DataSource = dvdbo_AdventureWorksDWBuildVersion;
                    grddbo_AdventureWorksDWBuildVersion.DataBind();
                }
                else
                {
                    grddbo_AdventureWorksDWBuildVersion.DataSource = null;
                    grddbo_AdventureWorksDWBuildVersion.DataBind();
                }
		    }
		    catch (Exception ex)
		    {
		    	ec.ShowMessage(ex.Message, " Dbo. Adventure Works D W Build Version ");
		    }
        }

        private void Add()
        {
		    Session.Remove("Mode");
		    Session["Mode"] = "Add";

		    ClearRecord();

		    this.txtDBVersion.Enabled = true;
		    this.txtVersionDate.Enabled = true;
		    txtDBVersion.Focus();
        }

        private void GetData()
        {
		    ClearRecord();

		    dbo_AdventureWorksDWBuildVersionClass clsdbo_AdventureWorksDWBuildVersion = new dbo_AdventureWorksDWBuildVersionClass();
		    clsdbo_AdventureWorksDWBuildVersion.DBVersion = System.Convert.ToString(Session["DBVersion"]);
		    clsdbo_AdventureWorksDWBuildVersion = dbo_AdventureWorksDWBuildVersionDataClass.Select_Record(clsdbo_AdventureWorksDWBuildVersion);

		    if ((clsdbo_AdventureWorksDWBuildVersion != null)) {
			    try {
                		if (clsdbo_AdventureWorksDWBuildVersion.DBVersion == null) { txtDBVersion.Text = default(string); } else { txtDBVersion.Text = System.Convert.ToString(clsdbo_AdventureWorksDWBuildVersion.DBVersion); }
                		if (clsdbo_AdventureWorksDWBuildVersion.VersionDate == null) { txtVersionDate.Text = DateTime.Now.ToString(); } else { txtVersionDate.Text = System.Convert.ToDateTime(clsdbo_AdventureWorksDWBuildVersion.VersionDate).ToShortDateString(); }
		   	 }
		    	catch (Exception ex)
		    	{
		    		ec.ShowMessage(ex.Message, " Dbo. Adventure Works D W Build Version ");
		    	}
		    }

        }

        private void Edit()
        {
		    Session.Remove("Mode");
		    Session["Mode"] = "Edit";

                    GetData();

		    txtDBVersion.Enabled = true;
		    txtDBVersion.Enabled = false;
		    txtDBVersion.Focus();
        }

        private void Delete()
        {
		    Session.Remove("Mode");
		    Session["Mode"] = "Delete";

                    GetData();

		    txtDBVersion.Enabled = false;
		    txtVersionDate.Enabled = false;
        }

        private void ClearRecord()
        {
	        txtDBVersion.Text = null;
        	txtVersionDate.Text = null;
        }

        public void btnSave_Click(object sender, System.EventArgs e)
        {
		    if ((String)Session["Mode"] == "Add") {
			    this.InsertRecord();
		    } else if ((String)Session["Mode"] == "Edit") {
			    this.UpdateRecord();
		    }
        }

        private void SetData(dbo_AdventureWorksDWBuildVersionClass clsdbo_AdventureWorksDWBuildVersion)
        {
			    if (string.IsNullOrEmpty(txtDBVersion.Text)) {
			    	clsdbo_AdventureWorksDWBuildVersion.DBVersion = null;
			    } else {
			    	clsdbo_AdventureWorksDWBuildVersion.DBVersion = txtDBVersion.Text; }
			    if (string.IsNullOrEmpty(txtVersionDate.Text)) {
			    	clsdbo_AdventureWorksDWBuildVersion.VersionDate = null;
			    } else {
			    	clsdbo_AdventureWorksDWBuildVersion.VersionDate = System.Convert.ToDateTime(txtVersionDate.Text); }
        }

        private void InsertRecord()
        {
		    dbo_AdventureWorksDWBuildVersionClass clsdbo_AdventureWorksDWBuildVersion = new dbo_AdventureWorksDWBuildVersionClass();
		    if (VerifyData() == true) {
                            SetData(clsdbo_AdventureWorksDWBuildVersion);
			    bool bSucess = false;
			    bSucess = dbo_AdventureWorksDWBuildVersionDataClass.Add(clsdbo_AdventureWorksDWBuildVersion);
			    if (bSucess == true) {
				    pnlForm.Visible = false;
				    pnlSave.Visible = false;
				    pnlGrid.Visible = true;
				    lblMode.InnerText = "";
				    Session.Remove("dvdbo_AdventureWorksDWBuildVersion");
				    LoadGriddbo_AdventureWorksDWBuildVersion();
			    } else {
				    ec.ShowMessage(" Insert failed. ", " Dbo. Adventure Works D W Build Version ");
			    }
		    }
        }

        private void UpdateRecord()
        {
		    dbo_AdventureWorksDWBuildVersionClass oclsdbo_AdventureWorksDWBuildVersion = new dbo_AdventureWorksDWBuildVersionClass();
		    dbo_AdventureWorksDWBuildVersionClass clsdbo_AdventureWorksDWBuildVersion = new dbo_AdventureWorksDWBuildVersionClass();

		    oclsdbo_AdventureWorksDWBuildVersion.DBVersion = System.Convert.ToString(Session["DBVersion"]);
		    oclsdbo_AdventureWorksDWBuildVersion = dbo_AdventureWorksDWBuildVersionDataClass.Select_Record(oclsdbo_AdventureWorksDWBuildVersion);

		    if (VerifyData() == true) {
                            SetData(clsdbo_AdventureWorksDWBuildVersion);
			    bool bSucess = false;
			    bSucess = dbo_AdventureWorksDWBuildVersionDataClass.Update(oclsdbo_AdventureWorksDWBuildVersion, clsdbo_AdventureWorksDWBuildVersion);
			    if (bSucess == true) {
				    pnlForm.Visible = false;
				    pnlSave.Visible = false;
				    pnlGrid.Visible = true;
				    lblMode.InnerText = "";
				    Session.Remove("dvdbo_AdventureWorksDWBuildVersion");
				    LoadGriddbo_AdventureWorksDWBuildVersion();
			    } else {
				    ec.ShowMessage(" Update failed. ", " Dbo. Adventure Works D W Build Version ");
			    }
		    }
        }

        private void DeleteRecord()
        {
		    dbo_AdventureWorksDWBuildVersionClass clsdbo_AdventureWorksDWBuildVersion = new dbo_AdventureWorksDWBuildVersionClass();
		    clsdbo_AdventureWorksDWBuildVersion.DBVersion = System.Convert.ToString(Session["DBVersion"]);
                    SetData(clsdbo_AdventureWorksDWBuildVersion);
		    bool bSucess = false;
		    bSucess = dbo_AdventureWorksDWBuildVersionDataClass.Delete(clsdbo_AdventureWorksDWBuildVersion);
		    if (bSucess == true) {
			    pnlForm.Visible = false;
			    pnlSave.Visible = false;
			    pnlGrid.Visible = true;
			    pnlDelete.Visible = false;
			    lblMode.InnerText = "";
			    Session.Remove("dvdbo_AdventureWorksDWBuildVersion");
			    LoadGriddbo_AdventureWorksDWBuildVersion();
		    } else {
			    ec.ShowMessage(" Delete failed. ", " Dbo. Adventure Works D W Build Version ");
		    }
        }

        private Boolean VerifyData()
        {
            if (
            txtDBVersion.Text != "" 
            )  {
            dbo_AdventureWorksDWBuildVersionClass clsdbo_AdventureWorksDWBuildVersion = new dbo_AdventureWorksDWBuildVersionClass();
            clsdbo_AdventureWorksDWBuildVersion.DBVersion = System.Convert.ToString(txtDBVersion.Text);
            clsdbo_AdventureWorksDWBuildVersion = dbo_AdventureWorksDWBuildVersionDataClass.Select_Record(clsdbo_AdventureWorksDWBuildVersion);
		    if (clsdbo_AdventureWorksDWBuildVersion != null && (String)Session["Mode"] == "Add") {
                    	ec.ShowMessage(" Record already exists. ", " Dbo. Adventure Works D W Build Version ");
                  	txtDBVersion.Focus();
                	return false; }
            }
		    return true;
        }

        public void butRecords_Click(object sender, System.EventArgs e)
        {
		    grddbo_AdventureWorksDWBuildVersion.CurrentPageIndex = 0;
		    grddbo_AdventureWorksDWBuildVersion.PageSize = Convert.ToInt32(cmbRecords.Text);
		    LoadGriddbo_AdventureWorksDWBuildVersion();
        }

        public void btnAddNew_Click(object sender, System.EventArgs e)
        {
		    if (pnlForm.Visible) {
			    txtDBVersion.Text = "";
			    txtVersionDate.Text = "";
		    } else {
			    pnlForm.Visible = true;
			    pnlGrid.Visible = false;
			    pnlSave.Visible = true;
			    lblMode.InnerText = "Add new";
		    }
		    btnSave.CommandArgument = "Add";
		    Add();
        }

        public void grddbo_AdventureWorksDWBuildVersion_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
        { 
		    if (e.Item.ItemType == ListItemType.Pager | e.Item.ItemType == ListItemType.Header)
			    return;

		    Button btn = (Button)e.CommandSource;
		    if (btn.Text == "Edit" | btn.Text == "Delete") {
			    Session.Remove("DBVersion");
			    Session["DBVersion"] = e.Item.Cells[0 + 0].Text;
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

        public void grddbo_AdventureWorksDWBuildVersion_SortCommand(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
        {
		    htmlHiddenSortExpression.Value = e.SortExpression + " " + GetSortDirection(e.SortExpression);
		    LoadGriddbo_AdventureWorksDWBuildVersion();
        }

        public void grddbo_AdventureWorksDWBuildVersion_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
        {
		    grddbo_AdventureWorksDWBuildVersion.CurrentPageIndex = e.NewPageIndex;
		    LoadGriddbo_AdventureWorksDWBuildVersion();
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
		    Session.Remove("dvdbo_AdventureWorksDWBuildVersion");
		    LoadGriddbo_AdventureWorksDWBuildVersion();
        }

        public void butSearch_Click(object sender, System.EventArgs e)
        {
		    try {
                        Session.Remove("dvdbo_AdventureWorksDWBuildVersion");
			if ((Session["dvdbo_AdventureWorksDWBuildVersion"] != null)) {
				dvdbo_AdventureWorksDWBuildVersion = (DataView)Session["dvdbo_AdventureWorksDWBuildVersion"];
				// DataView was not found in the session.
		    	} else {
				dvdbo_AdventureWorksDWBuildVersion = dbo_AdventureWorksDWBuildVersionDataClass.Search(cmbFields.Text, cmbCondition.Text, txtSearch.Text).DefaultView;
			    	Session["dvdbo_AdventureWorksDWBuildVersion"] = dvdbo_AdventureWorksDWBuildVersion;
		    	}
                if (dvdbo_AdventureWorksDWBuildVersion.Count > 0)
                {
                    dvdbo_AdventureWorksDWBuildVersion.Sort = htmlHiddenSortExpression.Value;
                    grddbo_AdventureWorksDWBuildVersion.DataSource = dvdbo_AdventureWorksDWBuildVersion;
                    grddbo_AdventureWorksDWBuildVersion.DataBind();
                }
                else
                {
                    grddbo_AdventureWorksDWBuildVersion.DataSource = null;
                    grddbo_AdventureWorksDWBuildVersion.DataBind();
                }
		    }
		    catch (Exception ex)
		    {
		    	ec.ShowMessage(ex.Message, " Dbo. Adventure Works D W Build Version ");
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
                    { dt = dbo_AdventureWorksDWBuildVersionDataClass.Search(cmbFields.Text, cmbCondition.Text, txtSearch.Text); }
                    else { dt = dbo_AdventureWorksDWBuildVersionDataClass.SelectAll(); }

                    PDFform pdfForm = new PDFform(dt, "Dbo. Adventure Works D W Build Version", "Many");
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
                    GVExport.DataSource = Session["dvdbo_AdventureWorksDWBuildVersion"];
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
 
