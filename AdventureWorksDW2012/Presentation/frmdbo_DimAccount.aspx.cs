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
    public partial class frmdbo_DimAccount : System.Web.UI.Page
    {

        private dbo_DimAccountDataClass clsdbo_DimAccountData = new dbo_DimAccountDataClass();
        private AdventureWorksDW2012DataClass clsAdventureWorksDW2012Data = new AdventureWorksDW2012DataClass();
        private DataView dvdbo_DimAccount;

        protected void Page_Load(object sender, EventArgs e)
        {
		    if (!Page.IsPostBack) {
			    Session["Mode"] = "";
 			    Session["AccountKey"] = "";

			    Session.Remove("dvdbo_DimAccount");

                            cmbFields.Items.Add("Account Key");
                            cmbFields.Items.Add("Parent Account Key");
                            cmbFields.Items.Add("Account Code Alternate Key");
                            cmbFields.Items.Add("Parent Account Code Alternate Key");
                            cmbFields.Items.Add("Account Description");
                            cmbFields.Items.Add("Account Type");
                            cmbFields.Items.Add("Operator");
                            cmbFields.Items.Add("Custom Members");
                            cmbFields.Items.Add("Value Type");
                            cmbFields.Items.Add("Custom Member Options");

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

            Loaddbo_DimAccount_dbo_DimAccountComboBox4();

			    LoadGriddbo_DimAccount();
		    }

        }


	    private void Loaddbo_DimAccount_dbo_DimAccountComboBox4()
	    {
		    List<dbo_DimAccount_dbo_DimAccountClass4> dbo_DimAccount_dbo_DimAccountList = new  List<dbo_DimAccount_dbo_DimAccountClass4>();
		    try {
			    dbo_DimAccount_dbo_DimAccountList = dbo_DimAccount_dbo_DimAccountDataClass4.List();
			    txtParentAccountKey.DataSource = dbo_DimAccount_dbo_DimAccountList;
			    txtParentAccountKey.DataValueField = "AccountKey";
			    txtParentAccountKey.DataTextField = "ParentAccountKey";
			    txtParentAccountKey.DataBind();
		    }
		    catch (Exception ex)
		    {
		    	ec.ShowMessage(ex.Message, " Dbo. Dim Account ");
		    }
	    }

        private void LoadGriddbo_DimAccount()
        {
		    try {
			if ((Session["dvdbo_DimAccount"] != null)) {
				dvdbo_DimAccount = (DataView)Session["dvdbo_DimAccount"];
				// DataView was not found in the session.
		    	} else {
				dvdbo_DimAccount = dbo_DimAccountDataClass.SelectAll().DefaultView;
			    	Session["dvdbo_DimAccount"] = dvdbo_DimAccount;
		    	}
                if (dvdbo_DimAccount.Count > 0)
                {
                    dvdbo_DimAccount.Sort = htmlHiddenSortExpression.Value;
                    grddbo_DimAccount.DataSource = dvdbo_DimAccount;
                    grddbo_DimAccount.DataBind();
                }
                else
                {
                    grddbo_DimAccount.DataSource = null;
                    grddbo_DimAccount.DataBind();
                }
		    }
		    catch (Exception ex)
		    {
		    	ec.ShowMessage(ex.Message, " Dbo. Dim Account ");
		    }
        }

        private void Add()
        {
		    Session.Remove("Mode");
		    Session["Mode"] = "Add";

		    ClearRecord();

		    this.txtParentAccountKey.Enabled = true;
		    this.txtAccountCodeAlternateKey.Enabled = true;
		    this.txtParentAccountCodeAlternateKey.Enabled = true;
		    this.txtAccountDescription.Enabled = true;
		    this.txtAccountType.Enabled = true;
		    this.txtOperator.Enabled = true;
		    this.txtCustomMembers.Enabled = true;
		    this.txtValueType.Enabled = true;
		    this.txtCustomMemberOptions.Enabled = true;
		    txtAccountKey.Enabled = false;
		    txtParentAccountKey.Focus();
		    txtAccountKey.Text = Convert.ToString(clsAdventureWorksDW2012Data.getAutoID("New", "DimAccount"));
        }

        private void GetData()
        {
		    ClearRecord();

		    dbo_DimAccountClass clsdbo_DimAccount = new dbo_DimAccountClass();
		    clsdbo_DimAccount.AccountKey = System.Convert.ToInt32(Session["AccountKey"]);
		    clsdbo_DimAccount = dbo_DimAccountDataClass.Select_Record(clsdbo_DimAccount);

		    if ((clsdbo_DimAccount != null)) {
			    try {
                		txtAccountKey.Text = System.Convert.ToString(clsdbo_DimAccount.AccountKey);
                		if (clsdbo_DimAccount.ParentAccountKey == null) { txtParentAccountKey.SelectedValue = default(string); } else { txtParentAccountKey.SelectedValue = System.Convert.ToString(clsdbo_DimAccount.ParentAccountKey); }
                		if (clsdbo_DimAccount.AccountCodeAlternateKey == null) { txtAccountCodeAlternateKey.Text = default(string); } else { txtAccountCodeAlternateKey.Text = System.Convert.ToString(clsdbo_DimAccount.AccountCodeAlternateKey); }
                		if (clsdbo_DimAccount.ParentAccountCodeAlternateKey == null) { txtParentAccountCodeAlternateKey.Text = default(string); } else { txtParentAccountCodeAlternateKey.Text = System.Convert.ToString(clsdbo_DimAccount.ParentAccountCodeAlternateKey); }
                		if (clsdbo_DimAccount.AccountDescription == null) { txtAccountDescription.Text = default(string); } else { txtAccountDescription.Text = System.Convert.ToString(clsdbo_DimAccount.AccountDescription); }
                		if (clsdbo_DimAccount.AccountType == null) { txtAccountType.Text = default(string); } else { txtAccountType.Text = System.Convert.ToString(clsdbo_DimAccount.AccountType); }
                		if (clsdbo_DimAccount.Operator == null) { txtOperator.Text = default(string); } else { txtOperator.Text = System.Convert.ToString(clsdbo_DimAccount.Operator); }
                		if (clsdbo_DimAccount.CustomMembers == null) { txtCustomMembers.Text = default(string); } else { txtCustomMembers.Text = System.Convert.ToString(clsdbo_DimAccount.CustomMembers); }
                		if (clsdbo_DimAccount.ValueType == null) { txtValueType.Text = default(string); } else { txtValueType.Text = System.Convert.ToString(clsdbo_DimAccount.ValueType); }
                		if (clsdbo_DimAccount.CustomMemberOptions == null) { txtCustomMemberOptions.Text = default(string); } else { txtCustomMemberOptions.Text = System.Convert.ToString(clsdbo_DimAccount.CustomMemberOptions); }
		   	 }
		    	catch (Exception ex)
		    	{
		    		ec.ShowMessage(ex.Message, " Dbo. Dim Account ");
		    	}
		    }

        }

        private void Edit()
        {
		    Session.Remove("Mode");
		    Session["Mode"] = "Edit";

                    GetData();

		    txtParentAccountKey.Enabled = true;
		    txtAccountCodeAlternateKey.Enabled = true;
		    txtParentAccountCodeAlternateKey.Enabled = true;
		    txtAccountDescription.Enabled = true;
		    txtAccountType.Enabled = true;
		    txtOperator.Enabled = true;
		    txtCustomMembers.Enabled = true;
		    txtValueType.Enabled = true;
		    txtCustomMemberOptions.Enabled = true;
		    txtAccountKey.Enabled = false;
		    txtParentAccountKey.Focus();
        }

        private void Delete()
        {
		    Session.Remove("Mode");
		    Session["Mode"] = "Delete";

                    GetData();

		    txtAccountKey.Enabled = false;
		    txtParentAccountKey.Enabled = false;
		    txtAccountCodeAlternateKey.Enabled = false;
		    txtParentAccountCodeAlternateKey.Enabled = false;
		    txtAccountDescription.Enabled = false;
		    txtAccountType.Enabled = false;
		    txtOperator.Enabled = false;
		    txtCustomMembers.Enabled = false;
		    txtValueType.Enabled = false;
		    txtCustomMemberOptions.Enabled = false;
        }

        private void ClearRecord()
        {
	        txtAccountKey.Text = null;
	        txtParentAccountKey.SelectedIndex = -1;
	        txtAccountCodeAlternateKey.Text = null;
	        txtParentAccountCodeAlternateKey.Text = null;
	        txtAccountDescription.Text = null;
	        txtAccountType.Text = null;
	        txtOperator.Text = null;
	        txtCustomMembers.Text = null;
	        txtValueType.Text = null;
	        txtCustomMemberOptions.Text = null;
        }

        public void btnSave_Click(object sender, System.EventArgs e)
        {
		    if ((String)Session["Mode"] == "Add") {
			    this.InsertRecord();
		    } else if ((String)Session["Mode"] == "Edit") {
			    this.UpdateRecord();
		    }
        }

        private void SetData(dbo_DimAccountClass clsdbo_DimAccount)
        {
			    if (string.IsNullOrEmpty(txtParentAccountKey.SelectedValue)) {
			    	clsdbo_DimAccount.ParentAccountKey = null;
			    } else {
			    	clsdbo_DimAccount.ParentAccountKey = System.Convert.ToInt32(txtParentAccountKey.SelectedValue); }
			    if (string.IsNullOrEmpty(txtAccountCodeAlternateKey.Text)) {
			    	clsdbo_DimAccount.AccountCodeAlternateKey = null;
			    } else {
			    	clsdbo_DimAccount.AccountCodeAlternateKey = System.Convert.ToInt32(txtAccountCodeAlternateKey.Text); }
			    if (string.IsNullOrEmpty(txtParentAccountCodeAlternateKey.Text)) {
			    	clsdbo_DimAccount.ParentAccountCodeAlternateKey = null;
			    } else {
			    	clsdbo_DimAccount.ParentAccountCodeAlternateKey = System.Convert.ToInt32(txtParentAccountCodeAlternateKey.Text); }
			    if (string.IsNullOrEmpty(txtAccountDescription.Text)) {
			    	clsdbo_DimAccount.AccountDescription = null;
			    } else {
			    	clsdbo_DimAccount.AccountDescription = txtAccountDescription.Text; }
			    if (string.IsNullOrEmpty(txtAccountType.Text)) {
			    	clsdbo_DimAccount.AccountType = null;
			    } else {
			    	clsdbo_DimAccount.AccountType = txtAccountType.Text; }
			    if (string.IsNullOrEmpty(txtOperator.Text)) {
			    	clsdbo_DimAccount.Operator = null;
			    } else {
			    	clsdbo_DimAccount.Operator = txtOperator.Text; }
			    if (string.IsNullOrEmpty(txtCustomMembers.Text)) {
			    	clsdbo_DimAccount.CustomMembers = null;
			    } else {
			    	clsdbo_DimAccount.CustomMembers = txtCustomMembers.Text; }
			    if (string.IsNullOrEmpty(txtValueType.Text)) {
			    	clsdbo_DimAccount.ValueType = null;
			    } else {
			    	clsdbo_DimAccount.ValueType = txtValueType.Text; }
			    if (string.IsNullOrEmpty(txtCustomMemberOptions.Text)) {
			    	clsdbo_DimAccount.CustomMemberOptions = null;
			    } else {
			    	clsdbo_DimAccount.CustomMemberOptions = txtCustomMemberOptions.Text; }
        }

        private void InsertRecord()
        {
		    dbo_DimAccountClass clsdbo_DimAccount = new dbo_DimAccountClass();
		    if (VerifyData() == true) {
                            SetData(clsdbo_DimAccount);
			    bool bSucess = false;
			    bSucess = dbo_DimAccountDataClass.Add(clsdbo_DimAccount);
			    if (bSucess == true) {
				    pnlForm.Visible = false;
				    pnlSave.Visible = false;
				    pnlGrid.Visible = true;
				    lblMode.InnerText = "";
				    Session.Remove("dvdbo_DimAccount");
				    LoadGriddbo_DimAccount();
			    } else {
				    ec.ShowMessage(" Insert failed. ", " Dbo. Dim Account ");
			    }
		    }
        }

        private void UpdateRecord()
        {
		    dbo_DimAccountClass oclsdbo_DimAccount = new dbo_DimAccountClass();
		    dbo_DimAccountClass clsdbo_DimAccount = new dbo_DimAccountClass();

		    oclsdbo_DimAccount.AccountKey = System.Convert.ToInt32(Session["AccountKey"]);
		    oclsdbo_DimAccount = dbo_DimAccountDataClass.Select_Record(oclsdbo_DimAccount);

		    if (VerifyData() == true) {
                            SetData(clsdbo_DimAccount);
			    bool bSucess = false;
			    bSucess = dbo_DimAccountDataClass.Update(oclsdbo_DimAccount, clsdbo_DimAccount);
			    if (bSucess == true) {
				    pnlForm.Visible = false;
				    pnlSave.Visible = false;
				    pnlGrid.Visible = true;
				    lblMode.InnerText = "";
				    Session.Remove("dvdbo_DimAccount");
				    LoadGriddbo_DimAccount();
			    } else {
				    ec.ShowMessage(" Update failed. ", " Dbo. Dim Account ");
			    }
		    }
        }

        private void DeleteRecord()
        {
		    dbo_DimAccountClass clsdbo_DimAccount = new dbo_DimAccountClass();
		    clsdbo_DimAccount.AccountKey = System.Convert.ToInt32(Session["AccountKey"]);
                    SetData(clsdbo_DimAccount);
		    bool bSucess = false;
		    bSucess = dbo_DimAccountDataClass.Delete(clsdbo_DimAccount);
		    if (bSucess == true) {
			    pnlForm.Visible = false;
			    pnlSave.Visible = false;
			    pnlGrid.Visible = true;
			    pnlDelete.Visible = false;
			    lblMode.InnerText = "";
			    Session.Remove("dvdbo_DimAccount");
			    LoadGriddbo_DimAccount();
		    } else {
			    ec.ShowMessage(" Delete failed. ", " Dbo. Dim Account ");
		    }
        }

        private Boolean VerifyData()
        {
		    return true;
        }

        public void butRecords_Click(object sender, System.EventArgs e)
        {
		    grddbo_DimAccount.CurrentPageIndex = 0;
		    grddbo_DimAccount.PageSize = Convert.ToInt32(cmbRecords.Text);
		    LoadGriddbo_DimAccount();
        }

        public void btnAddNew_Click(object sender, System.EventArgs e)
        {
		    if (pnlForm.Visible) {
			    txtAccountKey.Text = "";
			    txtParentAccountKey.SelectedIndex = -1;
			    txtAccountCodeAlternateKey.Text = "";
			    txtParentAccountCodeAlternateKey.Text = "";
			    txtAccountDescription.Text = "";
			    txtAccountType.Text = "";
			    txtOperator.Text = "";
			    txtCustomMembers.Text = "";
			    txtValueType.Text = "";
			    txtCustomMemberOptions.Text = "";
		    } else {
			    pnlForm.Visible = true;
			    pnlGrid.Visible = false;
			    pnlSave.Visible = true;
			    lblMode.InnerText = "Add new";
		    }
		    btnSave.CommandArgument = "Add";
		    Add();
        }

        public void grddbo_DimAccount_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
        { 
		    if (e.Item.ItemType == ListItemType.Pager | e.Item.ItemType == ListItemType.Header)
			    return;

		    Button btn = (Button)e.CommandSource;
		    if (btn.Text == "Edit" | btn.Text == "Delete") {
			    Session.Remove("AccountKey");
			    Session["AccountKey"] = e.Item.Cells[0 + 0].Text;
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

        public void grddbo_DimAccount_SortCommand(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
        {
		    htmlHiddenSortExpression.Value = e.SortExpression + " " + GetSortDirection(e.SortExpression);
		    LoadGriddbo_DimAccount();
        }

        public void grddbo_DimAccount_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
        {
		    grddbo_DimAccount.CurrentPageIndex = e.NewPageIndex;
		    LoadGriddbo_DimAccount();
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
		    Session.Remove("dvdbo_DimAccount");
		    LoadGriddbo_DimAccount();
        }

        public void butSearch_Click(object sender, System.EventArgs e)
        {
		    try {
                        Session.Remove("dvdbo_DimAccount");
			if ((Session["dvdbo_DimAccount"] != null)) {
				dvdbo_DimAccount = (DataView)Session["dvdbo_DimAccount"];
				// DataView was not found in the session.
		    	} else {
				dvdbo_DimAccount = dbo_DimAccountDataClass.Search(cmbFields.Text, cmbCondition.Text, txtSearch.Text).DefaultView;
			    	Session["dvdbo_DimAccount"] = dvdbo_DimAccount;
		    	}
                if (dvdbo_DimAccount.Count > 0)
                {
                    dvdbo_DimAccount.Sort = htmlHiddenSortExpression.Value;
                    grddbo_DimAccount.DataSource = dvdbo_DimAccount;
                    grddbo_DimAccount.DataBind();
                }
                else
                {
                    grddbo_DimAccount.DataSource = null;
                    grddbo_DimAccount.DataBind();
                }
		    }
		    catch (Exception ex)
		    {
		    	ec.ShowMessage(ex.Message, " Dbo. Dim Account ");
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
                    { dt = dbo_DimAccountDataClass.Search(cmbFields.Text, cmbCondition.Text, txtSearch.Text); }
                    else { dt = dbo_DimAccountDataClass.SelectAll(); }

                    PDFform pdfForm = new PDFform(dt, "Dbo. Dim Account", "Many");
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
                    GVExport.DataSource = Session["dvdbo_DimAccount"];
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
 
