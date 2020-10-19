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
    public partial class frmdbo_DimScenario : System.Web.UI.Page
    {

        private dbo_DimScenarioDataClass clsdbo_DimScenarioData = new dbo_DimScenarioDataClass();
        private AdventureWorksDW2012DataClass clsAdventureWorksDW2012Data = new AdventureWorksDW2012DataClass();
        private DataView dvdbo_DimScenario;

        protected void Page_Load(object sender, EventArgs e)
        {
		    if (!Page.IsPostBack) {
			    Session["Mode"] = "";
 			    Session["ScenarioKey"] = "";

			    Session.Remove("dvdbo_DimScenario");

                            cmbFields.Items.Add("Scenario Key");
                            cmbFields.Items.Add("Scenario Name");

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


			    LoadGriddbo_DimScenario();
		    }

        }


        private void LoadGriddbo_DimScenario()
        {
		    try {
			if ((Session["dvdbo_DimScenario"] != null)) {
				dvdbo_DimScenario = (DataView)Session["dvdbo_DimScenario"];
				// DataView was not found in the session.
		    	} else {
				dvdbo_DimScenario = dbo_DimScenarioDataClass.SelectAll().DefaultView;
			    	Session["dvdbo_DimScenario"] = dvdbo_DimScenario;
		    	}
                if (dvdbo_DimScenario.Count > 0)
                {
                    dvdbo_DimScenario.Sort = htmlHiddenSortExpression.Value;
                    grddbo_DimScenario.DataSource = dvdbo_DimScenario;
                    grddbo_DimScenario.DataBind();
                }
                else
                {
                    grddbo_DimScenario.DataSource = null;
                    grddbo_DimScenario.DataBind();
                }
		    }
		    catch (Exception ex)
		    {
		    	ec.ShowMessage(ex.Message, " Dbo. Dim Scenario ");
		    }
        }

        private void Add()
        {
		    Session.Remove("Mode");
		    Session["Mode"] = "Add";

		    ClearRecord();

		    this.txtScenarioName.Enabled = true;
		    txtScenarioKey.Enabled = false;
		    txtScenarioName.Focus();
		    txtScenarioKey.Text = Convert.ToString(clsAdventureWorksDW2012Data.getAutoID("New", "DimScenario"));
        }

        private void GetData()
        {
		    ClearRecord();

		    dbo_DimScenarioClass clsdbo_DimScenario = new dbo_DimScenarioClass();
		    clsdbo_DimScenario.ScenarioKey = System.Convert.ToInt32(Session["ScenarioKey"]);
		    clsdbo_DimScenario = dbo_DimScenarioDataClass.Select_Record(clsdbo_DimScenario);

		    if ((clsdbo_DimScenario != null)) {
			    try {
                		txtScenarioKey.Text = System.Convert.ToString(clsdbo_DimScenario.ScenarioKey);
                		if (clsdbo_DimScenario.ScenarioName == null) { txtScenarioName.Text = default(string); } else { txtScenarioName.Text = System.Convert.ToString(clsdbo_DimScenario.ScenarioName); }
		   	 }
		    	catch (Exception ex)
		    	{
		    		ec.ShowMessage(ex.Message, " Dbo. Dim Scenario ");
		    	}
		    }

        }

        private void Edit()
        {
		    Session.Remove("Mode");
		    Session["Mode"] = "Edit";

                    GetData();

		    txtScenarioName.Enabled = true;
		    txtScenarioKey.Enabled = false;
		    txtScenarioName.Focus();
        }

        private void Delete()
        {
		    Session.Remove("Mode");
		    Session["Mode"] = "Delete";

                    GetData();

		    txtScenarioKey.Enabled = false;
		    txtScenarioName.Enabled = false;
        }

        private void ClearRecord()
        {
	        txtScenarioKey.Text = null;
	        txtScenarioName.Text = null;
        }

        public void btnSave_Click(object sender, System.EventArgs e)
        {
		    if ((String)Session["Mode"] == "Add") {
			    this.InsertRecord();
		    } else if ((String)Session["Mode"] == "Edit") {
			    this.UpdateRecord();
		    }
        }

        private void SetData(dbo_DimScenarioClass clsdbo_DimScenario)
        {
			    if (string.IsNullOrEmpty(txtScenarioName.Text)) {
			    	clsdbo_DimScenario.ScenarioName = null;
			    } else {
			    	clsdbo_DimScenario.ScenarioName = txtScenarioName.Text; }
        }

        private void InsertRecord()
        {
		    dbo_DimScenarioClass clsdbo_DimScenario = new dbo_DimScenarioClass();
		    if (VerifyData() == true) {
                            SetData(clsdbo_DimScenario);
			    bool bSucess = false;
			    bSucess = dbo_DimScenarioDataClass.Add(clsdbo_DimScenario);
			    if (bSucess == true) {
				    pnlForm.Visible = false;
				    pnlSave.Visible = false;
				    pnlGrid.Visible = true;
				    lblMode.InnerText = "";
				    Session.Remove("dvdbo_DimScenario");
				    LoadGriddbo_DimScenario();
			    } else {
				    ec.ShowMessage(" Insert failed. ", " Dbo. Dim Scenario ");
			    }
		    }
        }

        private void UpdateRecord()
        {
		    dbo_DimScenarioClass oclsdbo_DimScenario = new dbo_DimScenarioClass();
		    dbo_DimScenarioClass clsdbo_DimScenario = new dbo_DimScenarioClass();

		    oclsdbo_DimScenario.ScenarioKey = System.Convert.ToInt32(Session["ScenarioKey"]);
		    oclsdbo_DimScenario = dbo_DimScenarioDataClass.Select_Record(oclsdbo_DimScenario);

		    if (VerifyData() == true) {
                            SetData(clsdbo_DimScenario);
			    bool bSucess = false;
			    bSucess = dbo_DimScenarioDataClass.Update(oclsdbo_DimScenario, clsdbo_DimScenario);
			    if (bSucess == true) {
				    pnlForm.Visible = false;
				    pnlSave.Visible = false;
				    pnlGrid.Visible = true;
				    lblMode.InnerText = "";
				    Session.Remove("dvdbo_DimScenario");
				    LoadGriddbo_DimScenario();
			    } else {
				    ec.ShowMessage(" Update failed. ", " Dbo. Dim Scenario ");
			    }
		    }
        }

        private void DeleteRecord()
        {
		    dbo_DimScenarioClass clsdbo_DimScenario = new dbo_DimScenarioClass();
		    clsdbo_DimScenario.ScenarioKey = System.Convert.ToInt32(Session["ScenarioKey"]);
                    SetData(clsdbo_DimScenario);
		    bool bSucess = false;
		    bSucess = dbo_DimScenarioDataClass.Delete(clsdbo_DimScenario);
		    if (bSucess == true) {
			    pnlForm.Visible = false;
			    pnlSave.Visible = false;
			    pnlGrid.Visible = true;
			    pnlDelete.Visible = false;
			    lblMode.InnerText = "";
			    Session.Remove("dvdbo_DimScenario");
			    LoadGriddbo_DimScenario();
		    } else {
			    ec.ShowMessage(" Delete failed. ", " Dbo. Dim Scenario ");
		    }
        }

        private Boolean VerifyData()
        {
		    return true;
        }

        public void butRecords_Click(object sender, System.EventArgs e)
        {
		    grddbo_DimScenario.CurrentPageIndex = 0;
		    grddbo_DimScenario.PageSize = Convert.ToInt32(cmbRecords.Text);
		    LoadGriddbo_DimScenario();
        }

        public void btnAddNew_Click(object sender, System.EventArgs e)
        {
		    if (pnlForm.Visible) {
			    txtScenarioKey.Text = "";
			    txtScenarioName.Text = "";
		    } else {
			    pnlForm.Visible = true;
			    pnlGrid.Visible = false;
			    pnlSave.Visible = true;
			    lblMode.InnerText = "Add new";
		    }
		    btnSave.CommandArgument = "Add";
		    Add();
        }

        public void grddbo_DimScenario_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
        { 
		    if (e.Item.ItemType == ListItemType.Pager | e.Item.ItemType == ListItemType.Header)
			    return;

		    Button btn = (Button)e.CommandSource;
		    if (btn.Text == "Edit" | btn.Text == "Delete") {
			    Session.Remove("ScenarioKey");
			    Session["ScenarioKey"] = e.Item.Cells[0 + 0].Text;
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

        public void grddbo_DimScenario_SortCommand(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
        {
		    htmlHiddenSortExpression.Value = e.SortExpression + " " + GetSortDirection(e.SortExpression);
		    LoadGriddbo_DimScenario();
        }

        public void grddbo_DimScenario_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
        {
		    grddbo_DimScenario.CurrentPageIndex = e.NewPageIndex;
		    LoadGriddbo_DimScenario();
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
		    Session.Remove("dvdbo_DimScenario");
		    LoadGriddbo_DimScenario();
        }

        public void butSearch_Click(object sender, System.EventArgs e)
        {
		    try {
                        Session.Remove("dvdbo_DimScenario");
			if ((Session["dvdbo_DimScenario"] != null)) {
				dvdbo_DimScenario = (DataView)Session["dvdbo_DimScenario"];
				// DataView was not found in the session.
		    	} else {
				dvdbo_DimScenario = dbo_DimScenarioDataClass.Search(cmbFields.Text, cmbCondition.Text, txtSearch.Text).DefaultView;
			    	Session["dvdbo_DimScenario"] = dvdbo_DimScenario;
		    	}
                if (dvdbo_DimScenario.Count > 0)
                {
                    dvdbo_DimScenario.Sort = htmlHiddenSortExpression.Value;
                    grddbo_DimScenario.DataSource = dvdbo_DimScenario;
                    grddbo_DimScenario.DataBind();
                }
                else
                {
                    grddbo_DimScenario.DataSource = null;
                    grddbo_DimScenario.DataBind();
                }
		    }
		    catch (Exception ex)
		    {
		    	ec.ShowMessage(ex.Message, " Dbo. Dim Scenario ");
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
                    { dt = dbo_DimScenarioDataClass.Search(cmbFields.Text, cmbCondition.Text, txtSearch.Text); }
                    else { dt = dbo_DimScenarioDataClass.SelectAll(); }

                    PDFform pdfForm = new PDFform(dt, "Dbo. Dim Scenario", "Many");
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
                    GVExport.DataSource = Session["dvdbo_DimScenario"];
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
 
