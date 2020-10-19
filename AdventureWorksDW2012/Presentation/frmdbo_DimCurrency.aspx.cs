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
    public partial class frmdbo_DimCurrency : System.Web.UI.Page
    {

        private dbo_DimCurrencyDataClass clsdbo_DimCurrencyData = new dbo_DimCurrencyDataClass();
        private AdventureWorksDW2012DataClass clsAdventureWorksDW2012Data = new AdventureWorksDW2012DataClass();
        private DataView dvdbo_DimCurrency;

        protected void Page_Load(object sender, EventArgs e)
        {
		    if (!Page.IsPostBack) {
			    Session["Mode"] = "";
 			    Session["CurrencyKey"] = "";

			    Session.Remove("dvdbo_DimCurrency");

                            cmbFields.Items.Add("Currency Key");
                            cmbFields.Items.Add("Currency Alternate Key");
                            cmbFields.Items.Add("Currency Name");

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


			    LoadGriddbo_DimCurrency();
		    }

        }


        private void LoadGriddbo_DimCurrency()
        {
		    try {
			if ((Session["dvdbo_DimCurrency"] != null)) {
				dvdbo_DimCurrency = (DataView)Session["dvdbo_DimCurrency"];
				// DataView was not found in the session.
		    	} else {
				dvdbo_DimCurrency = dbo_DimCurrencyDataClass.SelectAll().DefaultView;
			    	Session["dvdbo_DimCurrency"] = dvdbo_DimCurrency;
		    	}
                if (dvdbo_DimCurrency.Count > 0)
                {
                    dvdbo_DimCurrency.Sort = htmlHiddenSortExpression.Value;
                    grddbo_DimCurrency.DataSource = dvdbo_DimCurrency;
                    grddbo_DimCurrency.DataBind();
                }
                else
                {
                    grddbo_DimCurrency.DataSource = null;
                    grddbo_DimCurrency.DataBind();
                }
		    }
		    catch (Exception ex)
		    {
		    	ec.ShowMessage(ex.Message, " Dbo. Dim Currency ");
		    }
        }

        private void Add()
        {
		    Session.Remove("Mode");
		    Session["Mode"] = "Add";

		    ClearRecord();

		    this.txtCurrencyAlternateKey.Enabled = true;
		    this.txtCurrencyName.Enabled = true;
		    txtCurrencyKey.Enabled = false;
		    txtCurrencyAlternateKey.Focus();
		    txtCurrencyKey.Text = Convert.ToString(clsAdventureWorksDW2012Data.getAutoID("New", "DimCurrency"));
        }

        private void GetData()
        {
		    ClearRecord();

		    dbo_DimCurrencyClass clsdbo_DimCurrency = new dbo_DimCurrencyClass();
		    clsdbo_DimCurrency.CurrencyKey = System.Convert.ToInt32(Session["CurrencyKey"]);
		    clsdbo_DimCurrency = dbo_DimCurrencyDataClass.Select_Record(clsdbo_DimCurrency);

		    if ((clsdbo_DimCurrency != null)) {
			    try {
                		txtCurrencyKey.Text = System.Convert.ToString(clsdbo_DimCurrency.CurrencyKey);
                		txtCurrencyAlternateKey.Text = System.Convert.ToString(clsdbo_DimCurrency.CurrencyAlternateKey);
                		txtCurrencyName.Text = System.Convert.ToString(clsdbo_DimCurrency.CurrencyName);
		   	 }
		    	catch (Exception ex)
		    	{
		    		ec.ShowMessage(ex.Message, " Dbo. Dim Currency ");
		    	}
		    }

        }

        private void Edit()
        {
		    Session.Remove("Mode");
		    Session["Mode"] = "Edit";

                    GetData();

		    txtCurrencyAlternateKey.Enabled = true;
		    txtCurrencyName.Enabled = true;
		    txtCurrencyKey.Enabled = false;
		    txtCurrencyAlternateKey.Focus();
        }

        private void Delete()
        {
		    Session.Remove("Mode");
		    Session["Mode"] = "Delete";

                    GetData();

		    txtCurrencyKey.Enabled = false;
		    txtCurrencyAlternateKey.Enabled = false;
		    txtCurrencyName.Enabled = false;
        }

        private void ClearRecord()
        {
	        txtCurrencyKey.Text = null;
	        txtCurrencyAlternateKey.Text = null;
	        txtCurrencyName.Text = null;
        }

        public void btnSave_Click(object sender, System.EventArgs e)
        {
		    if ((String)Session["Mode"] == "Add") {
			    this.InsertRecord();
		    } else if ((String)Session["Mode"] == "Edit") {
			    this.UpdateRecord();
		    }
        }

        private void SetData(dbo_DimCurrencyClass clsdbo_DimCurrency)
        {
			    clsdbo_DimCurrency.CurrencyAlternateKey = System.Convert.ToString(txtCurrencyAlternateKey.Text);
			    clsdbo_DimCurrency.CurrencyName = System.Convert.ToString(txtCurrencyName.Text);
        }

        private void InsertRecord()
        {
		    dbo_DimCurrencyClass clsdbo_DimCurrency = new dbo_DimCurrencyClass();
		    if (VerifyData() == true) {
                            SetData(clsdbo_DimCurrency);
			    bool bSucess = false;
			    bSucess = dbo_DimCurrencyDataClass.Add(clsdbo_DimCurrency);
			    if (bSucess == true) {
				    pnlForm.Visible = false;
				    pnlSave.Visible = false;
				    pnlGrid.Visible = true;
				    lblMode.InnerText = "";
				    Session.Remove("dvdbo_DimCurrency");
				    LoadGriddbo_DimCurrency();
			    } else {
				    ec.ShowMessage(" Insert failed. ", " Dbo. Dim Currency ");
			    }
		    }
        }

        private void UpdateRecord()
        {
		    dbo_DimCurrencyClass oclsdbo_DimCurrency = new dbo_DimCurrencyClass();
		    dbo_DimCurrencyClass clsdbo_DimCurrency = new dbo_DimCurrencyClass();

		    oclsdbo_DimCurrency.CurrencyKey = System.Convert.ToInt32(Session["CurrencyKey"]);
		    oclsdbo_DimCurrency = dbo_DimCurrencyDataClass.Select_Record(oclsdbo_DimCurrency);

		    if (VerifyData() == true) {
                            SetData(clsdbo_DimCurrency);
			    bool bSucess = false;
			    bSucess = dbo_DimCurrencyDataClass.Update(oclsdbo_DimCurrency, clsdbo_DimCurrency);
			    if (bSucess == true) {
				    pnlForm.Visible = false;
				    pnlSave.Visible = false;
				    pnlGrid.Visible = true;
				    lblMode.InnerText = "";
				    Session.Remove("dvdbo_DimCurrency");
				    LoadGriddbo_DimCurrency();
			    } else {
				    ec.ShowMessage(" Update failed. ", " Dbo. Dim Currency ");
			    }
		    }
        }

        private void DeleteRecord()
        {
		    dbo_DimCurrencyClass clsdbo_DimCurrency = new dbo_DimCurrencyClass();
		    clsdbo_DimCurrency.CurrencyKey = System.Convert.ToInt32(Session["CurrencyKey"]);
                    SetData(clsdbo_DimCurrency);
		    bool bSucess = false;
		    bSucess = dbo_DimCurrencyDataClass.Delete(clsdbo_DimCurrency);
		    if (bSucess == true) {
			    pnlForm.Visible = false;
			    pnlSave.Visible = false;
			    pnlGrid.Visible = true;
			    pnlDelete.Visible = false;
			    lblMode.InnerText = "";
			    Session.Remove("dvdbo_DimCurrency");
			    LoadGriddbo_DimCurrency();
		    } else {
			    ec.ShowMessage(" Delete failed. ", " Dbo. Dim Currency ");
		    }
        }

        private Boolean VerifyData()
        {
		    if (txtCurrencyAlternateKey.Text == "") {
		    	ec.ShowMessage(" Currency Alternate Key is Required. ", " Dbo. Dim Currency ");
	                txtCurrencyAlternateKey.Focus();
                	return false;}
		    if (txtCurrencyName.Text == "") {
		    	ec.ShowMessage(" Currency Name is Required. ", " Dbo. Dim Currency ");
	                txtCurrencyName.Focus();
                	return false;}
		    return true;
        }

        public void butRecords_Click(object sender, System.EventArgs e)
        {
		    grddbo_DimCurrency.CurrentPageIndex = 0;
		    grddbo_DimCurrency.PageSize = Convert.ToInt32(cmbRecords.Text);
		    LoadGriddbo_DimCurrency();
        }

        public void btnAddNew_Click(object sender, System.EventArgs e)
        {
		    if (pnlForm.Visible) {
			    txtCurrencyKey.Text = "";
			    txtCurrencyAlternateKey.Text = "";
			    txtCurrencyName.Text = "";
		    } else {
			    pnlForm.Visible = true;
			    pnlGrid.Visible = false;
			    pnlSave.Visible = true;
			    lblMode.InnerText = "Add new";
		    }
		    btnSave.CommandArgument = "Add";
		    Add();
        }

        public void grddbo_DimCurrency_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
        { 
		    if (e.Item.ItemType == ListItemType.Pager | e.Item.ItemType == ListItemType.Header)
			    return;

		    Button btn = (Button)e.CommandSource;
		    if (btn.Text == "Edit" | btn.Text == "Delete") {
			    Session.Remove("CurrencyKey");
			    Session["CurrencyKey"] = e.Item.Cells[0 + 0].Text;
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

        public void grddbo_DimCurrency_SortCommand(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
        {
		    htmlHiddenSortExpression.Value = e.SortExpression + " " + GetSortDirection(e.SortExpression);
		    LoadGriddbo_DimCurrency();
        }

        public void grddbo_DimCurrency_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
        {
		    grddbo_DimCurrency.CurrentPageIndex = e.NewPageIndex;
		    LoadGriddbo_DimCurrency();
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
		    Session.Remove("dvdbo_DimCurrency");
		    LoadGriddbo_DimCurrency();
        }

        public void butSearch_Click(object sender, System.EventArgs e)
        {
		    try {
                        Session.Remove("dvdbo_DimCurrency");
			if ((Session["dvdbo_DimCurrency"] != null)) {
				dvdbo_DimCurrency = (DataView)Session["dvdbo_DimCurrency"];
				// DataView was not found in the session.
		    	} else {
				dvdbo_DimCurrency = dbo_DimCurrencyDataClass.Search(cmbFields.Text, cmbCondition.Text, txtSearch.Text).DefaultView;
			    	Session["dvdbo_DimCurrency"] = dvdbo_DimCurrency;
		    	}
                if (dvdbo_DimCurrency.Count > 0)
                {
                    dvdbo_DimCurrency.Sort = htmlHiddenSortExpression.Value;
                    grddbo_DimCurrency.DataSource = dvdbo_DimCurrency;
                    grddbo_DimCurrency.DataBind();
                }
                else
                {
                    grddbo_DimCurrency.DataSource = null;
                    grddbo_DimCurrency.DataBind();
                }
		    }
		    catch (Exception ex)
		    {
		    	ec.ShowMessage(ex.Message, " Dbo. Dim Currency ");
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
                    { dt = dbo_DimCurrencyDataClass.Search(cmbFields.Text, cmbCondition.Text, txtSearch.Text); }
                    else { dt = dbo_DimCurrencyDataClass.SelectAll(); }

                    PDFform pdfForm = new PDFform(dt, "Dbo. Dim Currency", "Many");
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
                    GVExport.DataSource = Session["dvdbo_DimCurrency"];
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
 
