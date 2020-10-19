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
    public partial class frmdbo_DimDate : System.Web.UI.Page
    {

        private dbo_DimDateDataClass clsdbo_DimDateData = new dbo_DimDateDataClass();
        private AdventureWorksDW2012DataClass clsAdventureWorksDW2012Data = new AdventureWorksDW2012DataClass();
        private DataView dvdbo_DimDate;

        protected void Page_Load(object sender, EventArgs e)
        {
		    if (!Page.IsPostBack) {
			    Session["Mode"] = "";
 			    Session["DateKey"] = "";

			    Session.Remove("dvdbo_DimDate");

                            cmbFields.Items.Add("Date Key");
                            cmbFields.Items.Add("Full Date Alternate Key");
                            cmbFields.Items.Add("Day Number Of Week");
                            cmbFields.Items.Add("English Day Name Of Week");
                            cmbFields.Items.Add("Spanish Day Name Of Week");
                            cmbFields.Items.Add("French Day Name Of Week");
                            cmbFields.Items.Add("Day Number Of Month");
                            cmbFields.Items.Add("Day Number Of Year");
                            cmbFields.Items.Add("Week Number Of Year");
                            cmbFields.Items.Add("English Month Name");
                            cmbFields.Items.Add("Spanish Month Name");
                            cmbFields.Items.Add("French Month Name");
                            cmbFields.Items.Add("Month Number Of Year");
                            cmbFields.Items.Add("Calendar Quarter");
                            cmbFields.Items.Add("Calendar Year");
                            cmbFields.Items.Add("Calendar Semester");
                            cmbFields.Items.Add("Fiscal Quarter");
                            cmbFields.Items.Add("Fiscal Year");
                            cmbFields.Items.Add("Fiscal Semester");

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


			    LoadGriddbo_DimDate();
		    }

        }


        private void LoadGriddbo_DimDate()
        {
		    try {
			if ((Session["dvdbo_DimDate"] != null)) {
				dvdbo_DimDate = (DataView)Session["dvdbo_DimDate"];
				// DataView was not found in the session.
		    	} else {
				dvdbo_DimDate = dbo_DimDateDataClass.SelectAll().DefaultView;
			    	Session["dvdbo_DimDate"] = dvdbo_DimDate;
		    	}
                if (dvdbo_DimDate.Count > 0)
                {
                    dvdbo_DimDate.Sort = htmlHiddenSortExpression.Value;
                    grddbo_DimDate.DataSource = dvdbo_DimDate;
                    grddbo_DimDate.DataBind();
                }
                else
                {
                    grddbo_DimDate.DataSource = null;
                    grddbo_DimDate.DataBind();
                }
		    }
		    catch (Exception ex)
		    {
		    	ec.ShowMessage(ex.Message, " Dbo. Dim Date ");
		    }
        }

        private void Add()
        {
		    Session.Remove("Mode");
		    Session["Mode"] = "Add";

		    ClearRecord();

		    this.txtDateKey.Enabled = true;
		    this.txtFullDateAlternateKey.Enabled = true;
		    this.txtDayNumberOfWeek.Enabled = true;
		    this.txtEnglishDayNameOfWeek.Enabled = true;
		    this.txtSpanishDayNameOfWeek.Enabled = true;
		    this.txtFrenchDayNameOfWeek.Enabled = true;
		    this.txtDayNumberOfMonth.Enabled = true;
		    this.txtDayNumberOfYear.Enabled = true;
		    this.txtWeekNumberOfYear.Enabled = true;
		    this.txtEnglishMonthName.Enabled = true;
		    this.txtSpanishMonthName.Enabled = true;
		    this.txtFrenchMonthName.Enabled = true;
		    this.txtMonthNumberOfYear.Enabled = true;
		    this.txtCalendarQuarter.Enabled = true;
		    this.txtCalendarYear.Enabled = true;
		    this.txtCalendarSemester.Enabled = true;
		    this.txtFiscalQuarter.Enabled = true;
		    this.txtFiscalYear.Enabled = true;
		    this.txtFiscalSemester.Enabled = true;
		    txtDateKey.Focus();
        }

        private void GetData()
        {
		    ClearRecord();

		    dbo_DimDateClass clsdbo_DimDate = new dbo_DimDateClass();
		    clsdbo_DimDate.DateKey = System.Convert.ToInt32(Session["DateKey"]);
		    clsdbo_DimDate = dbo_DimDateDataClass.Select_Record(clsdbo_DimDate);

		    if ((clsdbo_DimDate != null)) {
			    try {
                		txtDateKey.Text = System.Convert.ToString(clsdbo_DimDate.DateKey);
                		txtFullDateAlternateKey.Text = System.Convert.ToDateTime(clsdbo_DimDate.FullDateAlternateKey).ToShortDateString();
                		txtDayNumberOfWeek.Text = System.Convert.ToString(clsdbo_DimDate.DayNumberOfWeek);
                		txtEnglishDayNameOfWeek.Text = System.Convert.ToString(clsdbo_DimDate.EnglishDayNameOfWeek);
                		txtSpanishDayNameOfWeek.Text = System.Convert.ToString(clsdbo_DimDate.SpanishDayNameOfWeek);
                		txtFrenchDayNameOfWeek.Text = System.Convert.ToString(clsdbo_DimDate.FrenchDayNameOfWeek);
                		txtDayNumberOfMonth.Text = System.Convert.ToString(clsdbo_DimDate.DayNumberOfMonth);
                		txtDayNumberOfYear.Text = System.Convert.ToString(clsdbo_DimDate.DayNumberOfYear);
                		txtWeekNumberOfYear.Text = System.Convert.ToString(clsdbo_DimDate.WeekNumberOfYear);
                		txtEnglishMonthName.Text = System.Convert.ToString(clsdbo_DimDate.EnglishMonthName);
                		txtSpanishMonthName.Text = System.Convert.ToString(clsdbo_DimDate.SpanishMonthName);
                		txtFrenchMonthName.Text = System.Convert.ToString(clsdbo_DimDate.FrenchMonthName);
                		txtMonthNumberOfYear.Text = System.Convert.ToString(clsdbo_DimDate.MonthNumberOfYear);
                		txtCalendarQuarter.Text = System.Convert.ToString(clsdbo_DimDate.CalendarQuarter);
                		txtCalendarYear.Text = System.Convert.ToString(clsdbo_DimDate.CalendarYear);
                		txtCalendarSemester.Text = System.Convert.ToString(clsdbo_DimDate.CalendarSemester);
                		txtFiscalQuarter.Text = System.Convert.ToString(clsdbo_DimDate.FiscalQuarter);
                		txtFiscalYear.Text = System.Convert.ToString(clsdbo_DimDate.FiscalYear);
                		txtFiscalSemester.Text = System.Convert.ToString(clsdbo_DimDate.FiscalSemester);
		   	 }
		    	catch (Exception ex)
		    	{
		    		ec.ShowMessage(ex.Message, " Dbo. Dim Date ");
		    	}
		    }

        }

        private void Edit()
        {
		    Session.Remove("Mode");
		    Session["Mode"] = "Edit";

                    GetData();

		    txtDayNumberOfWeek.Enabled = true;
		    txtEnglishDayNameOfWeek.Enabled = true;
		    txtSpanishDayNameOfWeek.Enabled = true;
		    txtFrenchDayNameOfWeek.Enabled = true;
		    txtDayNumberOfMonth.Enabled = true;
		    txtDayNumberOfYear.Enabled = true;
		    txtWeekNumberOfYear.Enabled = true;
		    txtEnglishMonthName.Enabled = true;
		    txtSpanishMonthName.Enabled = true;
		    txtFrenchMonthName.Enabled = true;
		    txtMonthNumberOfYear.Enabled = true;
		    txtCalendarQuarter.Enabled = true;
		    txtCalendarYear.Enabled = true;
		    txtCalendarSemester.Enabled = true;
		    txtFiscalQuarter.Enabled = true;
		    txtFiscalYear.Enabled = true;
		    txtFiscalSemester.Enabled = true;
		    txtDateKey.Enabled = false;
		    txtFullDateAlternateKey.Focus();
        }

        private void Delete()
        {
		    Session.Remove("Mode");
		    Session["Mode"] = "Delete";

                    GetData();

		    txtDateKey.Enabled = false;
		    txtFullDateAlternateKey.Enabled = false;
		    txtDayNumberOfWeek.Enabled = false;
		    txtEnglishDayNameOfWeek.Enabled = false;
		    txtSpanishDayNameOfWeek.Enabled = false;
		    txtFrenchDayNameOfWeek.Enabled = false;
		    txtDayNumberOfMonth.Enabled = false;
		    txtDayNumberOfYear.Enabled = false;
		    txtWeekNumberOfYear.Enabled = false;
		    txtEnglishMonthName.Enabled = false;
		    txtSpanishMonthName.Enabled = false;
		    txtFrenchMonthName.Enabled = false;
		    txtMonthNumberOfYear.Enabled = false;
		    txtCalendarQuarter.Enabled = false;
		    txtCalendarYear.Enabled = false;
		    txtCalendarSemester.Enabled = false;
		    txtFiscalQuarter.Enabled = false;
		    txtFiscalYear.Enabled = false;
		    txtFiscalSemester.Enabled = false;
        }

        private void ClearRecord()
        {
	        txtDateKey.Text = null;
        	txtFullDateAlternateKey.Text = null;
	        txtDayNumberOfWeek.Text = null;
	        txtEnglishDayNameOfWeek.Text = null;
	        txtSpanishDayNameOfWeek.Text = null;
	        txtFrenchDayNameOfWeek.Text = null;
	        txtDayNumberOfMonth.Text = null;
	        txtDayNumberOfYear.Text = null;
	        txtWeekNumberOfYear.Text = null;
	        txtEnglishMonthName.Text = null;
	        txtSpanishMonthName.Text = null;
	        txtFrenchMonthName.Text = null;
	        txtMonthNumberOfYear.Text = null;
	        txtCalendarQuarter.Text = null;
	        txtCalendarYear.Text = null;
	        txtCalendarSemester.Text = null;
	        txtFiscalQuarter.Text = null;
	        txtFiscalYear.Text = null;
	        txtFiscalSemester.Text = null;
        }

        public void btnSave_Click(object sender, System.EventArgs e)
        {
		    if ((String)Session["Mode"] == "Add") {
			    this.InsertRecord();
		    } else if ((String)Session["Mode"] == "Edit") {
			    this.UpdateRecord();
		    }
        }

        private void SetData(dbo_DimDateClass clsdbo_DimDate)
        {
			    clsdbo_DimDate.DateKey = System.Convert.ToInt32(txtDateKey.Text);
			    clsdbo_DimDate.FullDateAlternateKey = System.Convert.ToDateTime(txtFullDateAlternateKey.Text);
			    clsdbo_DimDate.DayNumberOfWeek = System.Convert.ToByte(txtDayNumberOfWeek.Text);
			    clsdbo_DimDate.EnglishDayNameOfWeek = System.Convert.ToString(txtEnglishDayNameOfWeek.Text);
			    clsdbo_DimDate.SpanishDayNameOfWeek = System.Convert.ToString(txtSpanishDayNameOfWeek.Text);
			    clsdbo_DimDate.FrenchDayNameOfWeek = System.Convert.ToString(txtFrenchDayNameOfWeek.Text);
			    clsdbo_DimDate.DayNumberOfMonth = System.Convert.ToByte(txtDayNumberOfMonth.Text);
			    clsdbo_DimDate.DayNumberOfYear = System.Convert.ToInt16(txtDayNumberOfYear.Text);
			    clsdbo_DimDate.WeekNumberOfYear = System.Convert.ToByte(txtWeekNumberOfYear.Text);
			    clsdbo_DimDate.EnglishMonthName = System.Convert.ToString(txtEnglishMonthName.Text);
			    clsdbo_DimDate.SpanishMonthName = System.Convert.ToString(txtSpanishMonthName.Text);
			    clsdbo_DimDate.FrenchMonthName = System.Convert.ToString(txtFrenchMonthName.Text);
			    clsdbo_DimDate.MonthNumberOfYear = System.Convert.ToByte(txtMonthNumberOfYear.Text);
			    clsdbo_DimDate.CalendarQuarter = System.Convert.ToByte(txtCalendarQuarter.Text);
			    clsdbo_DimDate.CalendarYear = System.Convert.ToInt16(txtCalendarYear.Text);
			    clsdbo_DimDate.CalendarSemester = System.Convert.ToByte(txtCalendarSemester.Text);
			    clsdbo_DimDate.FiscalQuarter = System.Convert.ToByte(txtFiscalQuarter.Text);
			    clsdbo_DimDate.FiscalYear = System.Convert.ToInt16(txtFiscalYear.Text);
			    clsdbo_DimDate.FiscalSemester = System.Convert.ToByte(txtFiscalSemester.Text);
        }

        private void InsertRecord()
        {
		    dbo_DimDateClass clsdbo_DimDate = new dbo_DimDateClass();
		    if (VerifyData() == true) {
                            SetData(clsdbo_DimDate);
			    bool bSucess = false;
			    bSucess = dbo_DimDateDataClass.Add(clsdbo_DimDate);
			    if (bSucess == true) {
				    pnlForm.Visible = false;
				    pnlSave.Visible = false;
				    pnlGrid.Visible = true;
				    lblMode.InnerText = "";
				    Session.Remove("dvdbo_DimDate");
				    LoadGriddbo_DimDate();
			    } else {
				    ec.ShowMessage(" Insert failed. ", " Dbo. Dim Date ");
			    }
		    }
        }

        private void UpdateRecord()
        {
		    dbo_DimDateClass oclsdbo_DimDate = new dbo_DimDateClass();
		    dbo_DimDateClass clsdbo_DimDate = new dbo_DimDateClass();

		    oclsdbo_DimDate.DateKey = System.Convert.ToInt32(Session["DateKey"]);
		    oclsdbo_DimDate = dbo_DimDateDataClass.Select_Record(oclsdbo_DimDate);

		    if (VerifyData() == true) {
                            SetData(clsdbo_DimDate);
			    bool bSucess = false;
			    bSucess = dbo_DimDateDataClass.Update(oclsdbo_DimDate, clsdbo_DimDate);
			    if (bSucess == true) {
				    pnlForm.Visible = false;
				    pnlSave.Visible = false;
				    pnlGrid.Visible = true;
				    lblMode.InnerText = "";
				    Session.Remove("dvdbo_DimDate");
				    LoadGriddbo_DimDate();
			    } else {
				    ec.ShowMessage(" Update failed. ", " Dbo. Dim Date ");
			    }
		    }
        }

        private void DeleteRecord()
        {
		    dbo_DimDateClass clsdbo_DimDate = new dbo_DimDateClass();
		    clsdbo_DimDate.DateKey = System.Convert.ToInt32(Session["DateKey"]);
                    SetData(clsdbo_DimDate);
		    bool bSucess = false;
		    bSucess = dbo_DimDateDataClass.Delete(clsdbo_DimDate);
		    if (bSucess == true) {
			    pnlForm.Visible = false;
			    pnlSave.Visible = false;
			    pnlGrid.Visible = true;
			    pnlDelete.Visible = false;
			    lblMode.InnerText = "";
			    Session.Remove("dvdbo_DimDate");
			    LoadGriddbo_DimDate();
		    } else {
			    ec.ShowMessage(" Delete failed. ", " Dbo. Dim Date ");
		    }
        }

        private Boolean VerifyData()
        {
		    if (txtDateKey.Text == "") {
		    	ec.ShowMessage(" Date Key is Required. ", " Dbo. Dim Date ");
	                txtDateKey.Focus();
                	return false;}
            
		    if (txtDayNumberOfWeek.Text == "") {
		    	ec.ShowMessage(" Day Number Of Week is Required. ", " Dbo. Dim Date ");
	                txtDayNumberOfWeek.Focus();
                	return false;}
		    if (txtEnglishDayNameOfWeek.Text == "") {
		    	ec.ShowMessage(" English Day Name Of Week is Required. ", " Dbo. Dim Date ");
	                txtEnglishDayNameOfWeek.Focus();
                	return false;}
		    if (txtSpanishDayNameOfWeek.Text == "") {
		    	ec.ShowMessage(" Spanish Day Name Of Week is Required. ", " Dbo. Dim Date ");
	                txtSpanishDayNameOfWeek.Focus();
                	return false;}
		    if (txtFrenchDayNameOfWeek.Text == "") {
		    	ec.ShowMessage(" French Day Name Of Week is Required. ", " Dbo. Dim Date ");
	                txtFrenchDayNameOfWeek.Focus();
                	return false;}
		    if (txtDayNumberOfMonth.Text == "") {
		    	ec.ShowMessage(" Day Number Of Month is Required. ", " Dbo. Dim Date ");
	                txtDayNumberOfMonth.Focus();
                	return false;}
		    if (txtDayNumberOfYear.Text == "") {
		    	ec.ShowMessage(" Day Number Of Year is Required. ", " Dbo. Dim Date ");
	                txtDayNumberOfYear.Focus();
                	return false;}
		    if (txtWeekNumberOfYear.Text == "") {
		    	ec.ShowMessage(" Week Number Of Year is Required. ", " Dbo. Dim Date ");
	                txtWeekNumberOfYear.Focus();
                	return false;}
		    if (txtEnglishMonthName.Text == "") {
		    	ec.ShowMessage(" English Month Name is Required. ", " Dbo. Dim Date ");
	                txtEnglishMonthName.Focus();
                	return false;}
		    if (txtSpanishMonthName.Text == "") {
		    	ec.ShowMessage(" Spanish Month Name is Required. ", " Dbo. Dim Date ");
	                txtSpanishMonthName.Focus();
                	return false;}
		    if (txtFrenchMonthName.Text == "") {
		    	ec.ShowMessage(" French Month Name is Required. ", " Dbo. Dim Date ");
	                txtFrenchMonthName.Focus();
                	return false;}
		    if (txtMonthNumberOfYear.Text == "") {
		    	ec.ShowMessage(" Month Number Of Year is Required. ", " Dbo. Dim Date ");
	                txtMonthNumberOfYear.Focus();
                	return false;}
		    if (txtCalendarQuarter.Text == "") {
		    	ec.ShowMessage(" Calendar Quarter is Required. ", " Dbo. Dim Date ");
	                txtCalendarQuarter.Focus();
                	return false;}
		    if (txtCalendarYear.Text == "") {
		    	ec.ShowMessage(" Calendar Year is Required. ", " Dbo. Dim Date ");
	                txtCalendarYear.Focus();
                	return false;}
		    if (txtCalendarSemester.Text == "") {
		    	ec.ShowMessage(" Calendar Semester is Required. ", " Dbo. Dim Date ");
	                txtCalendarSemester.Focus();
                	return false;}
		    if (txtFiscalQuarter.Text == "") {
		    	ec.ShowMessage(" Fiscal Quarter is Required. ", " Dbo. Dim Date ");
	                txtFiscalQuarter.Focus();
                	return false;}
		    if (txtFiscalYear.Text == "") {
		    	ec.ShowMessage(" Fiscal Year is Required. ", " Dbo. Dim Date ");
	                txtFiscalYear.Focus();
                	return false;}
		    if (txtFiscalSemester.Text == "") {
		    	ec.ShowMessage(" Fiscal Semester is Required. ", " Dbo. Dim Date ");
	                txtFiscalSemester.Focus();
                	return false;}
            if (
            txtDateKey.Text != "" 
            )  {
            dbo_DimDateClass clsdbo_DimDate = new dbo_DimDateClass();
            clsdbo_DimDate.DateKey = System.Convert.ToInt32(txtDateKey.Text);
            clsdbo_DimDate = dbo_DimDateDataClass.Select_Record(clsdbo_DimDate);
		    if (clsdbo_DimDate != null && (String)Session["Mode"] == "Add") {
                    	ec.ShowMessage(" Record already exists. ", " Dbo. Dim Date ");
                 	txtDateKey.Focus();
                	return false; }
            }
		    return true;
        }

        public void butRecords_Click(object sender, System.EventArgs e)
        {
		    grddbo_DimDate.CurrentPageIndex = 0;
		    grddbo_DimDate.PageSize = Convert.ToInt32(cmbRecords.Text);
		    LoadGriddbo_DimDate();
        }

        public void btnAddNew_Click(object sender, System.EventArgs e)
        {
		    if (pnlForm.Visible) {
			    txtDateKey.Text = "";
			    txtFullDateAlternateKey.Text = "";
			    txtDayNumberOfWeek.Text = "";
			    txtEnglishDayNameOfWeek.Text = "";
			    txtSpanishDayNameOfWeek.Text = "";
			    txtFrenchDayNameOfWeek.Text = "";
			    txtDayNumberOfMonth.Text = "";
			    txtDayNumberOfYear.Text = "";
			    txtWeekNumberOfYear.Text = "";
			    txtEnglishMonthName.Text = "";
			    txtSpanishMonthName.Text = "";
			    txtFrenchMonthName.Text = "";
			    txtMonthNumberOfYear.Text = "";
			    txtCalendarQuarter.Text = "";
			    txtCalendarYear.Text = "";
			    txtCalendarSemester.Text = "";
			    txtFiscalQuarter.Text = "";
			    txtFiscalYear.Text = "";
			    txtFiscalSemester.Text = "";
		    } else {
			    pnlForm.Visible = true;
			    pnlGrid.Visible = false;
			    pnlSave.Visible = true;
			    lblMode.InnerText = "Add new";
		    }
		    btnSave.CommandArgument = "Add";
		    Add();
        }

        public void grddbo_DimDate_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
        { 
		    if (e.Item.ItemType == ListItemType.Pager | e.Item.ItemType == ListItemType.Header)
			    return;

		    Button btn = (Button)e.CommandSource;
		    if (btn.Text == "Edit" | btn.Text == "Delete") {
			    Session.Remove("DateKey");
			    Session["DateKey"] = e.Item.Cells[0 + 0].Text;
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

        public void grddbo_DimDate_SortCommand(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
        {
		    htmlHiddenSortExpression.Value = e.SortExpression + " " + GetSortDirection(e.SortExpression);
		    LoadGriddbo_DimDate();
        }

        public void grddbo_DimDate_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
        {
		    grddbo_DimDate.CurrentPageIndex = e.NewPageIndex;
		    LoadGriddbo_DimDate();
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
		    Session.Remove("dvdbo_DimDate");
		    LoadGriddbo_DimDate();
        }

        public void butSearch_Click(object sender, System.EventArgs e)
        {
		    try {
                        Session.Remove("dvdbo_DimDate");
			if ((Session["dvdbo_DimDate"] != null)) {
				dvdbo_DimDate = (DataView)Session["dvdbo_DimDate"];
				// DataView was not found in the session.
		    	} else {
				dvdbo_DimDate = dbo_DimDateDataClass.Search(cmbFields.Text, cmbCondition.Text, txtSearch.Text).DefaultView;
			    	Session["dvdbo_DimDate"] = dvdbo_DimDate;
		    	}
                if (dvdbo_DimDate.Count > 0)
                {
                    dvdbo_DimDate.Sort = htmlHiddenSortExpression.Value;
                    grddbo_DimDate.DataSource = dvdbo_DimDate;
                    grddbo_DimDate.DataBind();
                }
                else
                {
                    grddbo_DimDate.DataSource = null;
                    grddbo_DimDate.DataBind();
                }
		    }
		    catch (Exception ex)
		    {
		    	ec.ShowMessage(ex.Message, " Dbo. Dim Date ");
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
                    { dt = dbo_DimDateDataClass.Search(cmbFields.Text, cmbCondition.Text, txtSearch.Text); }
                    else { dt = dbo_DimDateDataClass.SelectAll(); }

                    PDFform pdfForm = new PDFform(dt, "Dbo. Dim Date", "Many");
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
                    GVExport.DataSource = Session["dvdbo_DimDate"];
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
 
