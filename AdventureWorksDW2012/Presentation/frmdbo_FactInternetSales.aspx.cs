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
    public partial class frmdbo_FactInternetSales : System.Web.UI.Page
    {

        private dbo_FactInternetSalesDataClass clsdbo_FactInternetSalesData = new dbo_FactInternetSalesDataClass();
        private AdventureWorksDW2012DataClass clsAdventureWorksDW2012Data = new AdventureWorksDW2012DataClass();
        private DataView dvdbo_FactInternetSales;

        protected void Page_Load(object sender, EventArgs e)
        {
		    if (!Page.IsPostBack) {
			    Session["Mode"] = "";
 			    Session["SalesOrderNumber"] = "";
 			    Session["SalesOrderLineNumber"] = "";

			    Session.Remove("dvdbo_FactInternetSales");

                            cmbFields.Items.Add("Sales Order Number");
                            cmbFields.Items.Add("Sales Order Line Number");
                            cmbFields.Items.Add("Product Key");
                            cmbFields.Items.Add("Order Date Key");
                            cmbFields.Items.Add("Due Date Key");
                            cmbFields.Items.Add("Ship Date Key");
                            cmbFields.Items.Add("Customer Key");
                            cmbFields.Items.Add("Promotion Key");
                            cmbFields.Items.Add("Currency Key");
                            cmbFields.Items.Add("Sales Territory Key");
                            cmbFields.Items.Add("Revision Number");
                            cmbFields.Items.Add("Order Quantity");
                            cmbFields.Items.Add("Unit Price");
                            cmbFields.Items.Add("Extended Amount");
                            cmbFields.Items.Add("Unit Price Discount Pct");
                            cmbFields.Items.Add("Discount Amount");
                            cmbFields.Items.Add("Product Standard Cost");
                            cmbFields.Items.Add("Total Product Cost");
                            cmbFields.Items.Add("Sales Amount");
                            cmbFields.Items.Add("Tax Amt");
                            cmbFields.Items.Add("Freight");
                            cmbFields.Items.Add("Carrier Tracking Number");
                            cmbFields.Items.Add("Customer P O Number");
                            cmbFields.Items.Add("Order Date");
                            cmbFields.Items.Add("Due Date");
                            cmbFields.Items.Add("Ship Date");

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

            Loaddbo_FactInternetSales_dbo_DimProductComboBox238();
            Loaddbo_FactInternetSales_dbo_DimDateComboBox239();
            Loaddbo_FactInternetSales_dbo_DimDateComboBox240();
            Loaddbo_FactInternetSales_dbo_DimDateComboBox241();
            Loaddbo_FactInternetSales_dbo_DimCustomerComboBox242();
            Loaddbo_FactInternetSales_dbo_DimPromotionComboBox243();
            Loaddbo_FactInternetSales_dbo_DimCurrencyComboBox244();
            Loaddbo_FactInternetSales_dbo_DimSalesTerritoryComboBox245();

			    LoadGriddbo_FactInternetSales();
		    }

        }


	    private void Loaddbo_FactInternetSales_dbo_DimProductComboBox238()
	    {
		    List<dbo_FactInternetSales_dbo_DimProductClass238> dbo_FactInternetSales_dbo_DimProductList = new  List<dbo_FactInternetSales_dbo_DimProductClass238>();
		    try {
			    dbo_FactInternetSales_dbo_DimProductList = dbo_FactInternetSales_dbo_DimProductDataClass238.List();
			    txtProductKey.DataSource = dbo_FactInternetSales_dbo_DimProductList;
			    txtProductKey.DataValueField = "ProductKey";
			    txtProductKey.DataTextField = "EnglishProductName";
			    txtProductKey.DataBind();
		    }
		    catch (Exception ex)
		    {
		    	ec.ShowMessage(ex.Message, " Dbo. Fact Internet Sales ");
		    }
	    }

	    private void Loaddbo_FactInternetSales_dbo_DimDateComboBox239()
	    {
		    List<dbo_FactInternetSales_dbo_DimDateClass239> dbo_FactInternetSales_dbo_DimDateList = new  List<dbo_FactInternetSales_dbo_DimDateClass239>();
		    try {
			    dbo_FactInternetSales_dbo_DimDateList = dbo_FactInternetSales_dbo_DimDateDataClass239.List();
			    txtOrderDateKey.DataSource = dbo_FactInternetSales_dbo_DimDateList;
			    txtOrderDateKey.DataValueField = "DateKey";
			    txtOrderDateKey.DataTextField = "FullDateAlternateKey";
			    txtOrderDateKey.DataBind();
		    }
		    catch (Exception ex)
		    {
		    	ec.ShowMessage(ex.Message, " Dbo. Fact Internet Sales ");
		    }
	    }

	    private void Loaddbo_FactInternetSales_dbo_DimDateComboBox240()
	    {
		    List<dbo_FactInternetSales_dbo_DimDateClass240> dbo_FactInternetSales_dbo_DimDateList = new  List<dbo_FactInternetSales_dbo_DimDateClass240>();
		    try {
			    dbo_FactInternetSales_dbo_DimDateList = dbo_FactInternetSales_dbo_DimDateDataClass240.List();
			    txtDueDateKey.DataSource = dbo_FactInternetSales_dbo_DimDateList;
			    txtDueDateKey.DataValueField = "DateKey";
			    txtDueDateKey.DataTextField = "FullDateAlternateKey";
			    txtDueDateKey.DataBind();
		    }
		    catch (Exception ex)
		    {
		    	ec.ShowMessage(ex.Message, " Dbo. Fact Internet Sales ");
		    }
	    }

	    private void Loaddbo_FactInternetSales_dbo_DimDateComboBox241()
	    {
		    List<dbo_FactInternetSales_dbo_DimDateClass241> dbo_FactInternetSales_dbo_DimDateList = new  List<dbo_FactInternetSales_dbo_DimDateClass241>();
		    try {
			    dbo_FactInternetSales_dbo_DimDateList = dbo_FactInternetSales_dbo_DimDateDataClass241.List();
			    txtShipDateKey.DataSource = dbo_FactInternetSales_dbo_DimDateList;
			    txtShipDateKey.DataValueField = "DateKey";
			    txtShipDateKey.DataTextField = "FullDateAlternateKey";
			    txtShipDateKey.DataBind();
		    }
		    catch (Exception ex)
		    {
		    	ec.ShowMessage(ex.Message, " Dbo. Fact Internet Sales ");
		    }
	    }

	    private void Loaddbo_FactInternetSales_dbo_DimCustomerComboBox242()
	    {
		    List<dbo_FactInternetSales_dbo_DimCustomerClass242> dbo_FactInternetSales_dbo_DimCustomerList = new  List<dbo_FactInternetSales_dbo_DimCustomerClass242>();
		    try {
			    dbo_FactInternetSales_dbo_DimCustomerList = dbo_FactInternetSales_dbo_DimCustomerDataClass242.List();
			    txtCustomerKey.DataSource = dbo_FactInternetSales_dbo_DimCustomerList;
			    txtCustomerKey.DataValueField = "CustomerKey";
			    txtCustomerKey.DataTextField = "FirstName";
			    txtCustomerKey.DataBind();
		    }
		    catch (Exception ex)
		    {
		    	ec.ShowMessage(ex.Message, " Dbo. Fact Internet Sales ");
		    }
	    }

	    private void Loaddbo_FactInternetSales_dbo_DimPromotionComboBox243()
	    {
		    List<dbo_FactInternetSales_dbo_DimPromotionClass243> dbo_FactInternetSales_dbo_DimPromotionList = new  List<dbo_FactInternetSales_dbo_DimPromotionClass243>();
		    try {
			    dbo_FactInternetSales_dbo_DimPromotionList = dbo_FactInternetSales_dbo_DimPromotionDataClass243.List();
			    txtPromotionKey.DataSource = dbo_FactInternetSales_dbo_DimPromotionList;
			    txtPromotionKey.DataValueField = "PromotionKey";
			    txtPromotionKey.DataTextField = "EnglishPromotionName";
			    txtPromotionKey.DataBind();
		    }
		    catch (Exception ex)
		    {
		    	ec.ShowMessage(ex.Message, " Dbo. Fact Internet Sales ");
		    }
	    }

	    private void Loaddbo_FactInternetSales_dbo_DimCurrencyComboBox244()
	    {
		    List<dbo_FactInternetSales_dbo_DimCurrencyClass244> dbo_FactInternetSales_dbo_DimCurrencyList = new  List<dbo_FactInternetSales_dbo_DimCurrencyClass244>();
		    try {
			    dbo_FactInternetSales_dbo_DimCurrencyList = dbo_FactInternetSales_dbo_DimCurrencyDataClass244.List();
			    txtCurrencyKey.DataSource = dbo_FactInternetSales_dbo_DimCurrencyList;
			    txtCurrencyKey.DataValueField = "CurrencyKey";
			    txtCurrencyKey.DataTextField = "CurrencyName";
			    txtCurrencyKey.DataBind();
		    }
		    catch (Exception ex)
		    {
		    	ec.ShowMessage(ex.Message, " Dbo. Fact Internet Sales ");
		    }
	    }

	    private void Loaddbo_FactInternetSales_dbo_DimSalesTerritoryComboBox245()
	    {
		    List<dbo_FactInternetSales_dbo_DimSalesTerritoryClass245> dbo_FactInternetSales_dbo_DimSalesTerritoryList = new  List<dbo_FactInternetSales_dbo_DimSalesTerritoryClass245>();
		    try {
			    dbo_FactInternetSales_dbo_DimSalesTerritoryList = dbo_FactInternetSales_dbo_DimSalesTerritoryDataClass245.List();
			    txtSalesTerritoryKey.DataSource = dbo_FactInternetSales_dbo_DimSalesTerritoryList;
			    txtSalesTerritoryKey.DataValueField = "SalesTerritoryKey";
			    txtSalesTerritoryKey.DataTextField = "SalesTerritoryAlternateKey";
			    txtSalesTerritoryKey.DataBind();
		    }
		    catch (Exception ex)
		    {
		    	ec.ShowMessage(ex.Message, " Dbo. Fact Internet Sales ");
		    }
	    }

        private void LoadGriddbo_FactInternetSales()
        {
		    try {
			if ((Session["dvdbo_FactInternetSales"] != null)) {
				dvdbo_FactInternetSales = (DataView)Session["dvdbo_FactInternetSales"];
				// DataView was not found in the session.
		    	} else {
				dvdbo_FactInternetSales = dbo_FactInternetSalesDataClass.SelectAll().DefaultView;
			    	Session["dvdbo_FactInternetSales"] = dvdbo_FactInternetSales;
		    	}
                if (dvdbo_FactInternetSales.Count > 0)
                {
                    dvdbo_FactInternetSales.Sort = htmlHiddenSortExpression.Value;
                    grddbo_FactInternetSales.DataSource = dvdbo_FactInternetSales;
                    grddbo_FactInternetSales.DataBind();
                }
                else
                {
                    grddbo_FactInternetSales.DataSource = null;
                    grddbo_FactInternetSales.DataBind();
                }
		    }
		    catch (Exception ex)
		    {
		    	ec.ShowMessage(ex.Message, " Dbo. Fact Internet Sales ");
		    }
        }

        private void Add()
        {
		    Session.Remove("Mode");
		    Session["Mode"] = "Add";

		    ClearRecord();

		    this.txtSalesOrderNumber.Enabled = true;
		    this.txtSalesOrderLineNumber.Enabled = true;
		    this.txtProductKey.Enabled = true;
		    this.txtOrderDateKey.Enabled = true;
		    this.txtDueDateKey.Enabled = true;
		    this.txtShipDateKey.Enabled = true;
		    this.txtCustomerKey.Enabled = true;
		    this.txtPromotionKey.Enabled = true;
		    this.txtCurrencyKey.Enabled = true;
		    this.txtSalesTerritoryKey.Enabled = true;
		    this.txtRevisionNumber.Enabled = true;
		    this.txtOrderQuantity.Enabled = true;
		    this.txtUnitPrice.Enabled = true;
		    this.txtExtendedAmount.Enabled = true;
		    this.txtUnitPriceDiscountPct.Enabled = true;
		    this.txtDiscountAmount.Enabled = true;
		    this.txtProductStandardCost.Enabled = true;
		    this.txtTotalProductCost.Enabled = true;
		    this.txtSalesAmount.Enabled = true;
		    this.txtTaxAmt.Enabled = true;
		    this.txtFreight.Enabled = true;
		    this.txtCarrierTrackingNumber.Enabled = true;
		    this.txtCustomerPONumber.Enabled = true;
		    this.txtOrderDate.Enabled = true;
		    this.txtDueDate.Enabled = true;
		    this.txtShipDate.Enabled = true;
		    txtSalesOrderNumber.Focus();
        }

        private void GetData()
        {
		    ClearRecord();

		    dbo_FactInternetSalesClass clsdbo_FactInternetSales = new dbo_FactInternetSalesClass();
		    clsdbo_FactInternetSales.SalesOrderNumber = System.Convert.ToString(Session["SalesOrderNumber"]);
		    clsdbo_FactInternetSales.SalesOrderLineNumber = System.Convert.ToByte(Session["SalesOrderLineNumber"]);
		    clsdbo_FactInternetSales = dbo_FactInternetSalesDataClass.Select_Record(clsdbo_FactInternetSales);

		    if ((clsdbo_FactInternetSales != null)) {
			    try {
                		txtSalesOrderNumber.Text = System.Convert.ToString(clsdbo_FactInternetSales.SalesOrderNumber);
                		txtSalesOrderLineNumber.Text = System.Convert.ToString(clsdbo_FactInternetSales.SalesOrderLineNumber);
                		txtProductKey.SelectedValue = System.Convert.ToString(clsdbo_FactInternetSales.ProductKey);
                		txtOrderDateKey.SelectedValue = System.Convert.ToString(clsdbo_FactInternetSales.OrderDateKey);
                		txtDueDateKey.SelectedValue = System.Convert.ToString(clsdbo_FactInternetSales.DueDateKey);
                		txtShipDateKey.SelectedValue = System.Convert.ToString(clsdbo_FactInternetSales.ShipDateKey);
                		txtCustomerKey.SelectedValue = System.Convert.ToString(clsdbo_FactInternetSales.CustomerKey);
                		txtPromotionKey.SelectedValue = System.Convert.ToString(clsdbo_FactInternetSales.PromotionKey);
                		txtCurrencyKey.SelectedValue = System.Convert.ToString(clsdbo_FactInternetSales.CurrencyKey);
                		txtSalesTerritoryKey.SelectedValue = System.Convert.ToString(clsdbo_FactInternetSales.SalesTerritoryKey);
                		txtRevisionNumber.Text = System.Convert.ToString(clsdbo_FactInternetSales.RevisionNumber);
                		txtOrderQuantity.Text = System.Convert.ToString(clsdbo_FactInternetSales.OrderQuantity);
                		txtUnitPrice.Text = System.Convert.ToString(clsdbo_FactInternetSales.UnitPrice);
                		txtExtendedAmount.Text = System.Convert.ToString(clsdbo_FactInternetSales.ExtendedAmount);
                		txtUnitPriceDiscountPct.Text = System.Convert.ToString(clsdbo_FactInternetSales.UnitPriceDiscountPct);
                		txtDiscountAmount.Text = System.Convert.ToString(clsdbo_FactInternetSales.DiscountAmount);
                		txtProductStandardCost.Text = System.Convert.ToString(clsdbo_FactInternetSales.ProductStandardCost);
                		txtTotalProductCost.Text = System.Convert.ToString(clsdbo_FactInternetSales.TotalProductCost);
                		txtSalesAmount.Text = System.Convert.ToString(clsdbo_FactInternetSales.SalesAmount);
                		txtTaxAmt.Text = System.Convert.ToString(clsdbo_FactInternetSales.TaxAmt);
                		txtFreight.Text = System.Convert.ToString(clsdbo_FactInternetSales.Freight);
                		if (clsdbo_FactInternetSales.CarrierTrackingNumber == null) { txtCarrierTrackingNumber.Text = default(string); } else { txtCarrierTrackingNumber.Text = System.Convert.ToString(clsdbo_FactInternetSales.CarrierTrackingNumber); }
                		if (clsdbo_FactInternetSales.CustomerPONumber == null) { txtCustomerPONumber.Text = default(string); } else { txtCustomerPONumber.Text = System.Convert.ToString(clsdbo_FactInternetSales.CustomerPONumber); }
                		if (clsdbo_FactInternetSales.OrderDate == null) { txtOrderDate.Text = DateTime.Now.ToString(); } else { txtOrderDate.Text = System.Convert.ToDateTime(clsdbo_FactInternetSales.OrderDate).ToShortDateString(); }
                		if (clsdbo_FactInternetSales.DueDate == null) { txtDueDate.Text = DateTime.Now.ToString(); } else { txtDueDate.Text = System.Convert.ToDateTime(clsdbo_FactInternetSales.DueDate).ToShortDateString(); }
                		if (clsdbo_FactInternetSales.ShipDate == null) { txtShipDate.Text = DateTime.Now.ToString(); } else { txtShipDate.Text = System.Convert.ToDateTime(clsdbo_FactInternetSales.ShipDate).ToShortDateString(); }
		   	 }
		    	catch (Exception ex)
		    	{
		    		ec.ShowMessage(ex.Message, " Dbo. Fact Internet Sales ");
		    	}
		    }

        }

        private void Edit()
        {
		    Session.Remove("Mode");
		    Session["Mode"] = "Edit";

                    GetData();

		    txtProductKey.Enabled = true;
		    txtOrderDateKey.Enabled = true;
		    txtDueDateKey.Enabled = true;
		    txtShipDateKey.Enabled = true;
		    txtCustomerKey.Enabled = true;
		    txtPromotionKey.Enabled = true;
		    txtCurrencyKey.Enabled = true;
		    txtSalesTerritoryKey.Enabled = true;
		    txtRevisionNumber.Enabled = true;
		    txtOrderQuantity.Enabled = true;
		    txtUnitPrice.Enabled = true;
		    txtExtendedAmount.Enabled = true;
		    txtUnitPriceDiscountPct.Enabled = true;
		    txtDiscountAmount.Enabled = true;
		    txtProductStandardCost.Enabled = true;
		    txtTotalProductCost.Enabled = true;
		    txtSalesAmount.Enabled = true;
		    txtTaxAmt.Enabled = true;
		    txtFreight.Enabled = true;
		    txtCarrierTrackingNumber.Enabled = true;
		    txtCustomerPONumber.Enabled = true;
		    txtSalesOrderNumber.Enabled = false;
		    txtSalesOrderLineNumber.Enabled = false;
		    txtProductKey.Focus();
        }

        private void Delete()
        {
		    Session.Remove("Mode");
		    Session["Mode"] = "Delete";

                    GetData();

		    txtSalesOrderNumber.Enabled = false;
		    txtSalesOrderLineNumber.Enabled = false;
		    txtProductKey.Enabled = false;
		    txtOrderDateKey.Enabled = false;
		    txtDueDateKey.Enabled = false;
		    txtShipDateKey.Enabled = false;
		    txtCustomerKey.Enabled = false;
		    txtPromotionKey.Enabled = false;
		    txtCurrencyKey.Enabled = false;
		    txtSalesTerritoryKey.Enabled = false;
		    txtRevisionNumber.Enabled = false;
		    txtOrderQuantity.Enabled = false;
		    txtUnitPrice.Enabled = false;
		    txtExtendedAmount.Enabled = false;
		    txtUnitPriceDiscountPct.Enabled = false;
		    txtDiscountAmount.Enabled = false;
		    txtProductStandardCost.Enabled = false;
		    txtTotalProductCost.Enabled = false;
		    txtSalesAmount.Enabled = false;
		    txtTaxAmt.Enabled = false;
		    txtFreight.Enabled = false;
		    txtCarrierTrackingNumber.Enabled = false;
		    txtCustomerPONumber.Enabled = false;
		    txtOrderDate.Enabled = false;
		    txtDueDate.Enabled = false;
		    txtShipDate.Enabled = false;
        }

        private void ClearRecord()
        {
	        txtSalesOrderNumber.Text = null;
	        txtSalesOrderLineNumber.Text = null;
	        txtProductKey.SelectedIndex = -1;
	        txtOrderDateKey.SelectedIndex = -1;
	        txtDueDateKey.SelectedIndex = -1;
	        txtShipDateKey.SelectedIndex = -1;
	        txtCustomerKey.SelectedIndex = -1;
	        txtPromotionKey.SelectedIndex = -1;
	        txtCurrencyKey.SelectedIndex = -1;
	        txtSalesTerritoryKey.SelectedIndex = -1;
	        txtRevisionNumber.Text = null;
	        txtOrderQuantity.Text = null;
	        txtUnitPrice.Text = null;
	        txtExtendedAmount.Text = null;
	        txtUnitPriceDiscountPct.Text = null;
	        txtDiscountAmount.Text = null;
	        txtProductStandardCost.Text = null;
	        txtTotalProductCost.Text = null;
	        txtSalesAmount.Text = null;
	        txtTaxAmt.Text = null;
	        txtFreight.Text = null;
	        txtCarrierTrackingNumber.Text = null;
	        txtCustomerPONumber.Text = null;
        	txtOrderDate.Text = null;
        	txtDueDate.Text = null;
        	txtShipDate.Text = null;
        }

        public void btnSave_Click(object sender, System.EventArgs e)
        {
		    if ((String)Session["Mode"] == "Add") {
			    this.InsertRecord();
		    } else if ((String)Session["Mode"] == "Edit") {
			    this.UpdateRecord();
		    }
        }

        private void SetData(dbo_FactInternetSalesClass clsdbo_FactInternetSales)
        {
			    clsdbo_FactInternetSales.SalesOrderNumber = System.Convert.ToString(txtSalesOrderNumber.Text);
			    clsdbo_FactInternetSales.SalesOrderLineNumber = System.Convert.ToByte(txtSalesOrderLineNumber.Text);
			    clsdbo_FactInternetSales.ProductKey = System.Convert.ToInt32(txtProductKey.SelectedValue);
			    clsdbo_FactInternetSales.OrderDateKey = System.Convert.ToInt32(txtOrderDateKey.SelectedValue);
			    clsdbo_FactInternetSales.DueDateKey = System.Convert.ToInt32(txtDueDateKey.SelectedValue);
			    clsdbo_FactInternetSales.ShipDateKey = System.Convert.ToInt32(txtShipDateKey.SelectedValue);
			    clsdbo_FactInternetSales.CustomerKey = System.Convert.ToInt32(txtCustomerKey.SelectedValue);
			    clsdbo_FactInternetSales.PromotionKey = System.Convert.ToInt32(txtPromotionKey.SelectedValue);
			    clsdbo_FactInternetSales.CurrencyKey = System.Convert.ToInt32(txtCurrencyKey.SelectedValue);
			    clsdbo_FactInternetSales.SalesTerritoryKey = System.Convert.ToInt32(txtSalesTerritoryKey.SelectedValue);
			    clsdbo_FactInternetSales.RevisionNumber = System.Convert.ToByte(txtRevisionNumber.Text);
			    clsdbo_FactInternetSales.OrderQuantity = System.Convert.ToInt16(txtOrderQuantity.Text);
			    clsdbo_FactInternetSales.UnitPrice = System.Convert.ToDecimal(txtUnitPrice.Text);
			    clsdbo_FactInternetSales.ExtendedAmount = System.Convert.ToDecimal(txtExtendedAmount.Text);
			    clsdbo_FactInternetSales.UnitPriceDiscountPct = System.Convert.ToDecimal(txtUnitPriceDiscountPct.Text);
			    clsdbo_FactInternetSales.DiscountAmount = System.Convert.ToDecimal(txtDiscountAmount.Text);
			    clsdbo_FactInternetSales.ProductStandardCost = System.Convert.ToDecimal(txtProductStandardCost.Text);
			    clsdbo_FactInternetSales.TotalProductCost = System.Convert.ToDecimal(txtTotalProductCost.Text);
			    clsdbo_FactInternetSales.SalesAmount = System.Convert.ToDecimal(txtSalesAmount.Text);
			    clsdbo_FactInternetSales.TaxAmt = System.Convert.ToDecimal(txtTaxAmt.Text);
			    clsdbo_FactInternetSales.Freight = System.Convert.ToDecimal(txtFreight.Text);
			    if (string.IsNullOrEmpty(txtCarrierTrackingNumber.Text)) {
			    	clsdbo_FactInternetSales.CarrierTrackingNumber = null;
			    } else {
			    	clsdbo_FactInternetSales.CarrierTrackingNumber = txtCarrierTrackingNumber.Text; }
			    if (string.IsNullOrEmpty(txtCustomerPONumber.Text)) {
			    	clsdbo_FactInternetSales.CustomerPONumber = null;
			    } else {
			    	clsdbo_FactInternetSales.CustomerPONumber = txtCustomerPONumber.Text; }
			    if (string.IsNullOrEmpty(txtOrderDate.Text)) {
			    	clsdbo_FactInternetSales.OrderDate = null;
			    } else {
			    	clsdbo_FactInternetSales.OrderDate = System.Convert.ToDateTime(txtOrderDate.Text); }
			    if (string.IsNullOrEmpty(txtDueDate.Text)) {
			    	clsdbo_FactInternetSales.DueDate = null;
			    } else {
			    	clsdbo_FactInternetSales.DueDate = System.Convert.ToDateTime(txtDueDate.Text); }
			    if (string.IsNullOrEmpty(txtShipDate.Text)) {
			    	clsdbo_FactInternetSales.ShipDate = null;
			    } else {
			    	clsdbo_FactInternetSales.ShipDate = System.Convert.ToDateTime(txtShipDate.Text); }
        }

        private void InsertRecord()
        {
		    dbo_FactInternetSalesClass clsdbo_FactInternetSales = new dbo_FactInternetSalesClass();
		    if (VerifyData() == true) {
                            SetData(clsdbo_FactInternetSales);
			    bool bSucess = false;
			    bSucess = dbo_FactInternetSalesDataClass.Add(clsdbo_FactInternetSales);
			    if (bSucess == true) {
				    pnlForm.Visible = false;
				    pnlSave.Visible = false;
				    pnlGrid.Visible = true;
				    lblMode.InnerText = "";
				    Session.Remove("dvdbo_FactInternetSales");
				    LoadGriddbo_FactInternetSales();
			    } else {
				    ec.ShowMessage(" Insert failed. ", " Dbo. Fact Internet Sales ");
			    }
		    }
        }

        private void UpdateRecord()
        {
		    dbo_FactInternetSalesClass oclsdbo_FactInternetSales = new dbo_FactInternetSalesClass();
		    dbo_FactInternetSalesClass clsdbo_FactInternetSales = new dbo_FactInternetSalesClass();

		    oclsdbo_FactInternetSales.SalesOrderNumber = System.Convert.ToString(Session["SalesOrderNumber"]);
		    oclsdbo_FactInternetSales.SalesOrderLineNumber = System.Convert.ToByte(Session["SalesOrderLineNumber"]);
		    oclsdbo_FactInternetSales = dbo_FactInternetSalesDataClass.Select_Record(oclsdbo_FactInternetSales);

		    if (VerifyData() == true) {
                            SetData(clsdbo_FactInternetSales);
			    bool bSucess = false;
			    bSucess = dbo_FactInternetSalesDataClass.Update(oclsdbo_FactInternetSales, clsdbo_FactInternetSales);
			    if (bSucess == true) {
				    pnlForm.Visible = false;
				    pnlSave.Visible = false;
				    pnlGrid.Visible = true;
				    lblMode.InnerText = "";
				    Session.Remove("dvdbo_FactInternetSales");
				    LoadGriddbo_FactInternetSales();
			    } else {
				    ec.ShowMessage(" Update failed. ", " Dbo. Fact Internet Sales ");
			    }
		    }
        }

        private void DeleteRecord()
        {
		    dbo_FactInternetSalesClass clsdbo_FactInternetSales = new dbo_FactInternetSalesClass();
		    clsdbo_FactInternetSales.SalesOrderNumber = System.Convert.ToString(Session["SalesOrderNumber"]);
		    clsdbo_FactInternetSales.SalesOrderLineNumber = System.Convert.ToByte(Session["SalesOrderLineNumber"]);
                    SetData(clsdbo_FactInternetSales);
		    bool bSucess = false;
		    bSucess = dbo_FactInternetSalesDataClass.Delete(clsdbo_FactInternetSales);
		    if (bSucess == true) {
			    pnlForm.Visible = false;
			    pnlSave.Visible = false;
			    pnlGrid.Visible = true;
			    pnlDelete.Visible = false;
			    lblMode.InnerText = "";
			    Session.Remove("dvdbo_FactInternetSales");
			    LoadGriddbo_FactInternetSales();
		    } else {
			    ec.ShowMessage(" Delete failed. ", " Dbo. Fact Internet Sales ");
		    }
        }

        private Boolean VerifyData()
        {
		    if (txtSalesOrderNumber.Text == "") {
		    	ec.ShowMessage(" Sales Order Number is Required. ", " Dbo. Fact Internet Sales ");
	                txtSalesOrderNumber.Focus();
                	return false;}
		    if (txtSalesOrderLineNumber.Text == "") {
		    	ec.ShowMessage(" Sales Order Line Number is Required. ", " Dbo. Fact Internet Sales ");
	                txtSalesOrderLineNumber.Focus();
                	return false;}
		    if (txtProductKey.Text == "") {
		    	ec.ShowMessage(" Product Key is Required. ", " Dbo. Fact Internet Sales ");
	                txtProductKey.Focus();
                	return false;}
		    if (txtOrderDateKey.Text == "") {
		    	ec.ShowMessage(" Order Date Key is Required. ", " Dbo. Fact Internet Sales ");
	                txtOrderDateKey.Focus();
                	return false;}
		    if (txtDueDateKey.Text == "") {
		    	ec.ShowMessage(" Due Date Key is Required. ", " Dbo. Fact Internet Sales ");
	                txtDueDateKey.Focus();
                	return false;}
		    if (txtShipDateKey.Text == "") {
		    	ec.ShowMessage(" Ship Date Key is Required. ", " Dbo. Fact Internet Sales ");
	                txtShipDateKey.Focus();
                	return false;}
		    if (txtCustomerKey.Text == "") {
		    	ec.ShowMessage(" Customer Key is Required. ", " Dbo. Fact Internet Sales ");
	                txtCustomerKey.Focus();
                	return false;}
		    if (txtPromotionKey.Text == "") {
		    	ec.ShowMessage(" Promotion Key is Required. ", " Dbo. Fact Internet Sales ");
	                txtPromotionKey.Focus();
                	return false;}
		    if (txtCurrencyKey.Text == "") {
		    	ec.ShowMessage(" Currency Key is Required. ", " Dbo. Fact Internet Sales ");
	                txtCurrencyKey.Focus();
                	return false;}
		    if (txtSalesTerritoryKey.Text == "") {
		    	ec.ShowMessage(" Sales Territory Key is Required. ", " Dbo. Fact Internet Sales ");
	                txtSalesTerritoryKey.Focus();
                	return false;}
		    if (txtRevisionNumber.Text == "") {
		    	ec.ShowMessage(" Revision Number is Required. ", " Dbo. Fact Internet Sales ");
	                txtRevisionNumber.Focus();
                	return false;}
		    if (txtOrderQuantity.Text == "") {
		    	ec.ShowMessage(" Order Quantity is Required. ", " Dbo. Fact Internet Sales ");
	                txtOrderQuantity.Focus();
                	return false;}
		    if (txtUnitPrice.Text == "") {
		    	ec.ShowMessage(" Unit Price is Required. ", " Dbo. Fact Internet Sales ");
	                txtUnitPrice.Focus();
                	return false;}
		    if (txtExtendedAmount.Text == "") {
		    	ec.ShowMessage(" Extended Amount is Required. ", " Dbo. Fact Internet Sales ");
	                txtExtendedAmount.Focus();
                	return false;}
		    if (txtUnitPriceDiscountPct.Text == "") {
		    	ec.ShowMessage(" Unit Price Discount Pct is Required. ", " Dbo. Fact Internet Sales ");
	                txtUnitPriceDiscountPct.Focus();
                	return false;}
		    if (txtDiscountAmount.Text == "") {
		    	ec.ShowMessage(" Discount Amount is Required. ", " Dbo. Fact Internet Sales ");
	                txtDiscountAmount.Focus();
                	return false;}
		    if (txtProductStandardCost.Text == "") {
		    	ec.ShowMessage(" Product Standard Cost is Required. ", " Dbo. Fact Internet Sales ");
	                txtProductStandardCost.Focus();
                	return false;}
		    if (txtTotalProductCost.Text == "") {
		    	ec.ShowMessage(" Total Product Cost is Required. ", " Dbo. Fact Internet Sales ");
	                txtTotalProductCost.Focus();
                	return false;}
		    if (txtSalesAmount.Text == "") {
		    	ec.ShowMessage(" Sales Amount is Required. ", " Dbo. Fact Internet Sales ");
	                txtSalesAmount.Focus();
                	return false;}
		    if (txtTaxAmt.Text == "") {
		    	ec.ShowMessage(" Tax Amt is Required. ", " Dbo. Fact Internet Sales ");
	                txtTaxAmt.Focus();
                	return false;}
		    if (txtFreight.Text == "") {
		    	ec.ShowMessage(" Freight is Required. ", " Dbo. Fact Internet Sales ");
	                txtFreight.Focus();
                	return false;}
            if (
            txtSalesOrderNumber.Text != "" 
            && txtSalesOrderLineNumber.Text != "" 
            )  {
            dbo_FactInternetSalesClass clsdbo_FactInternetSales = new dbo_FactInternetSalesClass();
            clsdbo_FactInternetSales.SalesOrderNumber = System.Convert.ToString(txtSalesOrderNumber.Text);
            clsdbo_FactInternetSales.SalesOrderLineNumber = System.Convert.ToByte(txtSalesOrderLineNumber.Text);
            clsdbo_FactInternetSales = dbo_FactInternetSalesDataClass.Select_Record(clsdbo_FactInternetSales);
		    if (clsdbo_FactInternetSales != null && (String)Session["Mode"] == "Add") {
                    	ec.ShowMessage(" Record already exists. ", " Dbo. Fact Internet Sales ");
                 	txtSalesOrderNumber.Focus();
                	return false; }
            }
		    return true;
        }

        public void butRecords_Click(object sender, System.EventArgs e)
        {
		    grddbo_FactInternetSales.CurrentPageIndex = 0;
		    grddbo_FactInternetSales.PageSize = Convert.ToInt32(cmbRecords.Text);
		    LoadGriddbo_FactInternetSales();
        }

        public void btnAddNew_Click(object sender, System.EventArgs e)
        {
		    if (pnlForm.Visible) {
			    txtSalesOrderNumber.Text = "";
			    txtSalesOrderLineNumber.Text = "";
			    txtProductKey.SelectedIndex = -1;
			    txtOrderDateKey.SelectedIndex = -1;
			    txtDueDateKey.SelectedIndex = -1;
			    txtShipDateKey.SelectedIndex = -1;
			    txtCustomerKey.SelectedIndex = -1;
			    txtPromotionKey.SelectedIndex = -1;
			    txtCurrencyKey.SelectedIndex = -1;
			    txtSalesTerritoryKey.SelectedIndex = -1;
			    txtRevisionNumber.Text = "";
			    txtOrderQuantity.Text = "";
			    txtUnitPrice.Text = "";
			    txtExtendedAmount.Text = "";
			    txtUnitPriceDiscountPct.Text = "";
			    txtDiscountAmount.Text = "";
			    txtProductStandardCost.Text = "";
			    txtTotalProductCost.Text = "";
			    txtSalesAmount.Text = "";
			    txtTaxAmt.Text = "";
			    txtFreight.Text = "";
			    txtCarrierTrackingNumber.Text = "";
			    txtCustomerPONumber.Text = "";
			    txtOrderDate.Text = "";
			    txtDueDate.Text = "";
			    txtShipDate.Text = "";
		    } else {
			    pnlForm.Visible = true;
			    pnlGrid.Visible = false;
			    pnlSave.Visible = true;
			    lblMode.InnerText = "Add new";
		    }
		    btnSave.CommandArgument = "Add";
		    Add();
        }

        public void grddbo_FactInternetSales_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
        { 
		    if (e.Item.ItemType == ListItemType.Pager | e.Item.ItemType == ListItemType.Header)
			    return;

		    Button btn = (Button)e.CommandSource;
		    if (btn.Text == "Edit" | btn.Text == "Delete") {
			    Session.Remove("SalesOrderNumber");
			    Session["SalesOrderNumber"] = e.Item.Cells[0 + 0].Text;
			    Session.Remove("SalesOrderLineNumber");
			    Session["SalesOrderLineNumber"] = e.Item.Cells[1 + 1].Text;
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

        public void grddbo_FactInternetSales_SortCommand(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
        {
		    htmlHiddenSortExpression.Value = e.SortExpression + " " + GetSortDirection(e.SortExpression);
		    LoadGriddbo_FactInternetSales();
        }

        public void grddbo_FactInternetSales_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
        {
		    grddbo_FactInternetSales.CurrentPageIndex = e.NewPageIndex;
		    LoadGriddbo_FactInternetSales();
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
		    Session.Remove("dvdbo_FactInternetSales");
		    LoadGriddbo_FactInternetSales();
        }

        public void butSearch_Click(object sender, System.EventArgs e)
        {
		    try {
                        Session.Remove("dvdbo_FactInternetSales");
			if ((Session["dvdbo_FactInternetSales"] != null)) {
				dvdbo_FactInternetSales = (DataView)Session["dvdbo_FactInternetSales"];
				// DataView was not found in the session.
		    	} else {
				dvdbo_FactInternetSales = dbo_FactInternetSalesDataClass.Search(cmbFields.Text, cmbCondition.Text, txtSearch.Text).DefaultView;
			    	Session["dvdbo_FactInternetSales"] = dvdbo_FactInternetSales;
		    	}
                if (dvdbo_FactInternetSales.Count > 0)
                {
                    dvdbo_FactInternetSales.Sort = htmlHiddenSortExpression.Value;
                    grddbo_FactInternetSales.DataSource = dvdbo_FactInternetSales;
                    grddbo_FactInternetSales.DataBind();
                }
                else
                {
                    grddbo_FactInternetSales.DataSource = null;
                    grddbo_FactInternetSales.DataBind();
                }
		    }
		    catch (Exception ex)
		    {
		    	ec.ShowMessage(ex.Message, " Dbo. Fact Internet Sales ");
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
                    { dt = dbo_FactInternetSalesDataClass.Search(cmbFields.Text, cmbCondition.Text, txtSearch.Text); }
                    else { dt = dbo_FactInternetSalesDataClass.SelectAll(); }

                    PDFform pdfForm = new PDFform(dt, "Dbo. Fact Internet Sales", "Many");
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
                    GVExport.DataSource = Session["dvdbo_FactInternetSales"];
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
 
