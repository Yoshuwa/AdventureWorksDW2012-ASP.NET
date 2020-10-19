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
    public partial class frmdbo_FactResellerSales : System.Web.UI.Page
    {

        private dbo_FactResellerSalesDataClass clsdbo_FactResellerSalesData = new dbo_FactResellerSalesDataClass();
        private AdventureWorksDW2012DataClass clsAdventureWorksDW2012Data = new AdventureWorksDW2012DataClass();
        private DataView dvdbo_FactResellerSales;

        protected void Page_Load(object sender, EventArgs e)
        {
		    if (!Page.IsPostBack) {
			    Session["Mode"] = "";
 			    Session["SalesOrderNumber"] = "";
 			    Session["SalesOrderLineNumber"] = "";

			    Session.Remove("dvdbo_FactResellerSales");

                            cmbFields.Items.Add("Sales Order Number");
                            cmbFields.Items.Add("Sales Order Line Number");
                            cmbFields.Items.Add("Product Key");
                            cmbFields.Items.Add("Order Date Key");
                            cmbFields.Items.Add("Due Date Key");
                            cmbFields.Items.Add("Ship Date Key");
                            cmbFields.Items.Add("Reseller Key");
                            cmbFields.Items.Add("Employee Key");
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

            Loaddbo_FactResellerSales_dbo_DimProductComboBox274();
            Loaddbo_FactResellerSales_dbo_DimDateComboBox275();
            Loaddbo_FactResellerSales_dbo_DimDateComboBox276();
            Loaddbo_FactResellerSales_dbo_DimDateComboBox277();
            Loaddbo_FactResellerSales_dbo_DimResellerComboBox278();
            Loaddbo_FactResellerSales_dbo_DimEmployeeComboBox279();
            Loaddbo_FactResellerSales_dbo_DimPromotionComboBox280();
            Loaddbo_FactResellerSales_dbo_DimCurrencyComboBox281();
            Loaddbo_FactResellerSales_dbo_DimSalesTerritoryComboBox282();

			    LoadGriddbo_FactResellerSales();
		    }

        }


	    private void Loaddbo_FactResellerSales_dbo_DimProductComboBox274()
	    {
		    List<dbo_FactResellerSales_dbo_DimProductClass274> dbo_FactResellerSales_dbo_DimProductList = new  List<dbo_FactResellerSales_dbo_DimProductClass274>();
		    try {
			    dbo_FactResellerSales_dbo_DimProductList = dbo_FactResellerSales_dbo_DimProductDataClass274.List();
			    txtProductKey.DataSource = dbo_FactResellerSales_dbo_DimProductList;
			    txtProductKey.DataValueField = "ProductKey";
			    txtProductKey.DataTextField = "ProductAlternateKey";
			    txtProductKey.DataBind();
		    }
		    catch (Exception ex)
		    {
		    	ec.ShowMessage(ex.Message, " Dbo. Fact Reseller Sales ");
		    }
	    }

	    private void Loaddbo_FactResellerSales_dbo_DimDateComboBox275()
	    {
		    List<dbo_FactResellerSales_dbo_DimDateClass275> dbo_FactResellerSales_dbo_DimDateList = new  List<dbo_FactResellerSales_dbo_DimDateClass275>();
		    try {
			    dbo_FactResellerSales_dbo_DimDateList = dbo_FactResellerSales_dbo_DimDateDataClass275.List();
			    txtOrderDateKey.DataSource = dbo_FactResellerSales_dbo_DimDateList;
			    txtOrderDateKey.DataValueField = "DateKey";
			    txtOrderDateKey.DataTextField = "DateKey";
			    txtOrderDateKey.DataBind();
		    }
		    catch (Exception ex)
		    {
		    	ec.ShowMessage(ex.Message, " Dbo. Fact Reseller Sales ");
		    }
	    }

	    private void Loaddbo_FactResellerSales_dbo_DimDateComboBox276()
	    {
		    List<dbo_FactResellerSales_dbo_DimDateClass276> dbo_FactResellerSales_dbo_DimDateList = new  List<dbo_FactResellerSales_dbo_DimDateClass276>();
		    try {
			    dbo_FactResellerSales_dbo_DimDateList = dbo_FactResellerSales_dbo_DimDateDataClass276.List();
			    txtDueDateKey.DataSource = dbo_FactResellerSales_dbo_DimDateList;
			    txtDueDateKey.DataValueField = "DateKey";
			    txtDueDateKey.DataTextField = "DateKey";
			    txtDueDateKey.DataBind();
		    }
		    catch (Exception ex)
		    {
		    	ec.ShowMessage(ex.Message, " Dbo. Fact Reseller Sales ");
		    }
	    }

	    private void Loaddbo_FactResellerSales_dbo_DimDateComboBox277()
	    {
		    List<dbo_FactResellerSales_dbo_DimDateClass277> dbo_FactResellerSales_dbo_DimDateList = new  List<dbo_FactResellerSales_dbo_DimDateClass277>();
		    try {
			    dbo_FactResellerSales_dbo_DimDateList = dbo_FactResellerSales_dbo_DimDateDataClass277.List();
			    txtShipDateKey.DataSource = dbo_FactResellerSales_dbo_DimDateList;
			    txtShipDateKey.DataValueField = "DateKey";
			    txtShipDateKey.DataTextField = "DateKey";
			    txtShipDateKey.DataBind();
		    }
		    catch (Exception ex)
		    {
		    	ec.ShowMessage(ex.Message, " Dbo. Fact Reseller Sales ");
		    }
	    }

	    private void Loaddbo_FactResellerSales_dbo_DimResellerComboBox278()
	    {
		    List<dbo_FactResellerSales_dbo_DimResellerClass278> dbo_FactResellerSales_dbo_DimResellerList = new  List<dbo_FactResellerSales_dbo_DimResellerClass278>();
		    try {
			    dbo_FactResellerSales_dbo_DimResellerList = dbo_FactResellerSales_dbo_DimResellerDataClass278.List();
			    txtResellerKey.DataSource = dbo_FactResellerSales_dbo_DimResellerList;
			    txtResellerKey.DataValueField = "ResellerKey";
			    txtResellerKey.DataTextField = "ResellerKey";
			    txtResellerKey.DataBind();
		    }
		    catch (Exception ex)
		    {
		    	ec.ShowMessage(ex.Message, " Dbo. Fact Reseller Sales ");
		    }
	    }

	    private void Loaddbo_FactResellerSales_dbo_DimEmployeeComboBox279()
	    {
		    List<dbo_FactResellerSales_dbo_DimEmployeeClass279> dbo_FactResellerSales_dbo_DimEmployeeList = new  List<dbo_FactResellerSales_dbo_DimEmployeeClass279>();
		    try {
			    dbo_FactResellerSales_dbo_DimEmployeeList = dbo_FactResellerSales_dbo_DimEmployeeDataClass279.List();
			    txtEmployeeKey.DataSource = dbo_FactResellerSales_dbo_DimEmployeeList;
			    txtEmployeeKey.DataValueField = "EmployeeKey";
			    txtEmployeeKey.DataTextField = "EmployeeKey";
			    txtEmployeeKey.DataBind();
		    }
		    catch (Exception ex)
		    {
		    	ec.ShowMessage(ex.Message, " Dbo. Fact Reseller Sales ");
		    }
	    }

	    private void Loaddbo_FactResellerSales_dbo_DimPromotionComboBox280()
	    {
		    List<dbo_FactResellerSales_dbo_DimPromotionClass280> dbo_FactResellerSales_dbo_DimPromotionList = new  List<dbo_FactResellerSales_dbo_DimPromotionClass280>();
		    try {
			    dbo_FactResellerSales_dbo_DimPromotionList = dbo_FactResellerSales_dbo_DimPromotionDataClass280.List();
			    txtPromotionKey.DataSource = dbo_FactResellerSales_dbo_DimPromotionList;
			    txtPromotionKey.DataValueField = "PromotionKey";
			    txtPromotionKey.DataTextField = "PromotionKey";
			    txtPromotionKey.DataBind();
		    }
		    catch (Exception ex)
		    {
		    	ec.ShowMessage(ex.Message, " Dbo. Fact Reseller Sales ");
		    }
	    }

	    private void Loaddbo_FactResellerSales_dbo_DimCurrencyComboBox281()
	    {
		    List<dbo_FactResellerSales_dbo_DimCurrencyClass281> dbo_FactResellerSales_dbo_DimCurrencyList = new  List<dbo_FactResellerSales_dbo_DimCurrencyClass281>();
		    try {
			    dbo_FactResellerSales_dbo_DimCurrencyList = dbo_FactResellerSales_dbo_DimCurrencyDataClass281.List();
			    txtCurrencyKey.DataSource = dbo_FactResellerSales_dbo_DimCurrencyList;
			    txtCurrencyKey.DataValueField = "CurrencyKey";
			    txtCurrencyKey.DataTextField = "CurrencyKey";
			    txtCurrencyKey.DataBind();
		    }
		    catch (Exception ex)
		    {
		    	ec.ShowMessage(ex.Message, " Dbo. Fact Reseller Sales ");
		    }
	    }

	    private void Loaddbo_FactResellerSales_dbo_DimSalesTerritoryComboBox282()
	    {
		    List<dbo_FactResellerSales_dbo_DimSalesTerritoryClass282> dbo_FactResellerSales_dbo_DimSalesTerritoryList = new  List<dbo_FactResellerSales_dbo_DimSalesTerritoryClass282>();
		    try {
			    dbo_FactResellerSales_dbo_DimSalesTerritoryList = dbo_FactResellerSales_dbo_DimSalesTerritoryDataClass282.List();
			    txtSalesTerritoryKey.DataSource = dbo_FactResellerSales_dbo_DimSalesTerritoryList;
			    txtSalesTerritoryKey.DataValueField = "SalesTerritoryKey";
			    txtSalesTerritoryKey.DataTextField = "SalesTerritoryKey";
			    txtSalesTerritoryKey.DataBind();
		    }
		    catch (Exception ex)
		    {
		    	ec.ShowMessage(ex.Message, " Dbo. Fact Reseller Sales ");
		    }
	    }

        private void LoadGriddbo_FactResellerSales()
        {
		    try {
			if ((Session["dvdbo_FactResellerSales"] != null)) {
				dvdbo_FactResellerSales = (DataView)Session["dvdbo_FactResellerSales"];
				// DataView was not found in the session.
		    	} else {
				dvdbo_FactResellerSales = dbo_FactResellerSalesDataClass.SelectAll().DefaultView;
			    	Session["dvdbo_FactResellerSales"] = dvdbo_FactResellerSales;
		    	}
                if (dvdbo_FactResellerSales.Count > 0)
                {
                    dvdbo_FactResellerSales.Sort = htmlHiddenSortExpression.Value;
                    grddbo_FactResellerSales.DataSource = dvdbo_FactResellerSales;
                    grddbo_FactResellerSales.DataBind();
                }
                else
                {
                    grddbo_FactResellerSales.DataSource = null;
                    grddbo_FactResellerSales.DataBind();
                }
		    }
		    catch (Exception ex)
		    {
		    	ec.ShowMessage(ex.Message, " Dbo. Fact Reseller Sales ");
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
		    this.txtResellerKey.Enabled = true;
		    this.txtEmployeeKey.Enabled = true;
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

		    dbo_FactResellerSalesClass clsdbo_FactResellerSales = new dbo_FactResellerSalesClass();
		    clsdbo_FactResellerSales.SalesOrderNumber = System.Convert.ToString(Session["SalesOrderNumber"]);
		    clsdbo_FactResellerSales.SalesOrderLineNumber = System.Convert.ToByte(Session["SalesOrderLineNumber"]);
		    clsdbo_FactResellerSales = dbo_FactResellerSalesDataClass.Select_Record(clsdbo_FactResellerSales);

		    if ((clsdbo_FactResellerSales != null)) {
			    try {
                		txtSalesOrderNumber.Text = System.Convert.ToString(clsdbo_FactResellerSales.SalesOrderNumber);
                		txtSalesOrderLineNumber.Text = System.Convert.ToString(clsdbo_FactResellerSales.SalesOrderLineNumber);
                		txtProductKey.SelectedValue = System.Convert.ToString(clsdbo_FactResellerSales.ProductKey);
                		txtOrderDateKey.SelectedValue = System.Convert.ToString(clsdbo_FactResellerSales.OrderDateKey);
                		txtDueDateKey.SelectedValue = System.Convert.ToString(clsdbo_FactResellerSales.DueDateKey);
                		txtShipDateKey.SelectedValue = System.Convert.ToString(clsdbo_FactResellerSales.ShipDateKey);
                		txtResellerKey.SelectedValue = System.Convert.ToString(clsdbo_FactResellerSales.ResellerKey);
                		txtEmployeeKey.SelectedValue = System.Convert.ToString(clsdbo_FactResellerSales.EmployeeKey);
                		txtPromotionKey.SelectedValue = System.Convert.ToString(clsdbo_FactResellerSales.PromotionKey);
                		txtCurrencyKey.SelectedValue = System.Convert.ToString(clsdbo_FactResellerSales.CurrencyKey);
                		txtSalesTerritoryKey.SelectedValue = System.Convert.ToString(clsdbo_FactResellerSales.SalesTerritoryKey);
                		if (clsdbo_FactResellerSales.RevisionNumber == null) { txtRevisionNumber.Text = default(string); } else { txtRevisionNumber.Text = System.Convert.ToString(clsdbo_FactResellerSales.RevisionNumber); }
                		if (clsdbo_FactResellerSales.OrderQuantity == null) { txtOrderQuantity.Text = default(string); } else { txtOrderQuantity.Text = System.Convert.ToString(clsdbo_FactResellerSales.OrderQuantity); }
                		if (clsdbo_FactResellerSales.UnitPrice == null) { txtUnitPrice.Text = default(string); } else { txtUnitPrice.Text = System.Convert.ToString(clsdbo_FactResellerSales.UnitPrice); }
                		if (clsdbo_FactResellerSales.ExtendedAmount == null) { txtExtendedAmount.Text = default(string); } else { txtExtendedAmount.Text = System.Convert.ToString(clsdbo_FactResellerSales.ExtendedAmount); }
                		if (clsdbo_FactResellerSales.UnitPriceDiscountPct == null) { txtUnitPriceDiscountPct.Text = default(string); } else { txtUnitPriceDiscountPct.Text = System.Convert.ToString(clsdbo_FactResellerSales.UnitPriceDiscountPct); }
                		if (clsdbo_FactResellerSales.DiscountAmount == null) { txtDiscountAmount.Text = default(string); } else { txtDiscountAmount.Text = System.Convert.ToString(clsdbo_FactResellerSales.DiscountAmount); }
                		if (clsdbo_FactResellerSales.ProductStandardCost == null) { txtProductStandardCost.Text = default(string); } else { txtProductStandardCost.Text = System.Convert.ToString(clsdbo_FactResellerSales.ProductStandardCost); }
                		if (clsdbo_FactResellerSales.TotalProductCost == null) { txtTotalProductCost.Text = default(string); } else { txtTotalProductCost.Text = System.Convert.ToString(clsdbo_FactResellerSales.TotalProductCost); }
                		if (clsdbo_FactResellerSales.SalesAmount == null) { txtSalesAmount.Text = default(string); } else { txtSalesAmount.Text = System.Convert.ToString(clsdbo_FactResellerSales.SalesAmount); }
                		if (clsdbo_FactResellerSales.TaxAmt == null) { txtTaxAmt.Text = default(string); } else { txtTaxAmt.Text = System.Convert.ToString(clsdbo_FactResellerSales.TaxAmt); }
                		if (clsdbo_FactResellerSales.Freight == null) { txtFreight.Text = default(string); } else { txtFreight.Text = System.Convert.ToString(clsdbo_FactResellerSales.Freight); }
                		if (clsdbo_FactResellerSales.CarrierTrackingNumber == null) { txtCarrierTrackingNumber.Text = default(string); } else { txtCarrierTrackingNumber.Text = System.Convert.ToString(clsdbo_FactResellerSales.CarrierTrackingNumber); }
                		if (clsdbo_FactResellerSales.CustomerPONumber == null) { txtCustomerPONumber.Text = default(string); } else { txtCustomerPONumber.Text = System.Convert.ToString(clsdbo_FactResellerSales.CustomerPONumber); }
                		if (clsdbo_FactResellerSales.OrderDate == null) { txtOrderDate.Text = DateTime.Now.ToString(); } else { txtOrderDate.Text = System.Convert.ToDateTime(clsdbo_FactResellerSales.OrderDate).ToShortDateString(); }
                		if (clsdbo_FactResellerSales.DueDate == null) { txtDueDate.Text = DateTime.Now.ToString(); } else { txtDueDate.Text = System.Convert.ToDateTime(clsdbo_FactResellerSales.DueDate).ToShortDateString(); }
                		if (clsdbo_FactResellerSales.ShipDate == null) { txtShipDate.Text = DateTime.Now.ToString(); } else { txtShipDate.Text = System.Convert.ToDateTime(clsdbo_FactResellerSales.ShipDate).ToShortDateString(); }
		   	 }
		    	catch (Exception ex)
		    	{
		    		ec.ShowMessage(ex.Message, " Dbo. Fact Reseller Sales ");
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
		    txtResellerKey.Enabled = true;
		    txtEmployeeKey.Enabled = true;
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
		    txtResellerKey.Enabled = false;
		    txtEmployeeKey.Enabled = false;
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
	        txtResellerKey.SelectedIndex = -1;
	        txtEmployeeKey.SelectedIndex = -1;
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

        private void SetData(dbo_FactResellerSalesClass clsdbo_FactResellerSales)
        {
			    clsdbo_FactResellerSales.SalesOrderNumber = System.Convert.ToString(txtSalesOrderNumber.Text);
			    clsdbo_FactResellerSales.SalesOrderLineNumber = System.Convert.ToByte(txtSalesOrderLineNumber.Text);
			    clsdbo_FactResellerSales.ProductKey = System.Convert.ToInt32(txtProductKey.SelectedValue);
			    clsdbo_FactResellerSales.OrderDateKey = System.Convert.ToInt32(txtOrderDateKey.SelectedValue);
			    clsdbo_FactResellerSales.DueDateKey = System.Convert.ToInt32(txtDueDateKey.SelectedValue);
			    clsdbo_FactResellerSales.ShipDateKey = System.Convert.ToInt32(txtShipDateKey.SelectedValue);
			    clsdbo_FactResellerSales.ResellerKey = System.Convert.ToInt32(txtResellerKey.SelectedValue);
			    clsdbo_FactResellerSales.EmployeeKey = System.Convert.ToInt32(txtEmployeeKey.SelectedValue);
			    clsdbo_FactResellerSales.PromotionKey = System.Convert.ToInt32(txtPromotionKey.SelectedValue);
			    clsdbo_FactResellerSales.CurrencyKey = System.Convert.ToInt32(txtCurrencyKey.SelectedValue);
			    clsdbo_FactResellerSales.SalesTerritoryKey = System.Convert.ToInt32(txtSalesTerritoryKey.SelectedValue);
			    if (string.IsNullOrEmpty(txtRevisionNumber.Text)) {
			    	clsdbo_FactResellerSales.RevisionNumber = null;
			    } else {
			    	clsdbo_FactResellerSales.RevisionNumber = System.Convert.ToByte(txtRevisionNumber.Text); }
			    if (string.IsNullOrEmpty(txtOrderQuantity.Text)) {
			    	clsdbo_FactResellerSales.OrderQuantity = null;
			    } else {
			    	clsdbo_FactResellerSales.OrderQuantity = System.Convert.ToInt16(txtOrderQuantity.Text); }
			    if (string.IsNullOrEmpty(txtUnitPrice.Text)) {
			    	clsdbo_FactResellerSales.UnitPrice = null;
			    } else {
			    	clsdbo_FactResellerSales.UnitPrice = System.Convert.ToDecimal(txtUnitPrice.Text); }
			    if (string.IsNullOrEmpty(txtExtendedAmount.Text)) {
			    	clsdbo_FactResellerSales.ExtendedAmount = null;
			    } else {
			    	clsdbo_FactResellerSales.ExtendedAmount = System.Convert.ToDecimal(txtExtendedAmount.Text); }
			    if (string.IsNullOrEmpty(txtUnitPriceDiscountPct.Text)) {
			    	clsdbo_FactResellerSales.UnitPriceDiscountPct = null;
			    } else {
			    	clsdbo_FactResellerSales.UnitPriceDiscountPct = System.Convert.ToDecimal(txtUnitPriceDiscountPct.Text); }
			    if (string.IsNullOrEmpty(txtDiscountAmount.Text)) {
			    	clsdbo_FactResellerSales.DiscountAmount = null;
			    } else {
			    	clsdbo_FactResellerSales.DiscountAmount = System.Convert.ToDecimal(txtDiscountAmount.Text); }
			    if (string.IsNullOrEmpty(txtProductStandardCost.Text)) {
			    	clsdbo_FactResellerSales.ProductStandardCost = null;
			    } else {
			    	clsdbo_FactResellerSales.ProductStandardCost = System.Convert.ToDecimal(txtProductStandardCost.Text); }
			    if (string.IsNullOrEmpty(txtTotalProductCost.Text)) {
			    	clsdbo_FactResellerSales.TotalProductCost = null;
			    } else {
			    	clsdbo_FactResellerSales.TotalProductCost = System.Convert.ToDecimal(txtTotalProductCost.Text); }
			    if (string.IsNullOrEmpty(txtSalesAmount.Text)) {
			    	clsdbo_FactResellerSales.SalesAmount = null;
			    } else {
			    	clsdbo_FactResellerSales.SalesAmount = System.Convert.ToDecimal(txtSalesAmount.Text); }
			    if (string.IsNullOrEmpty(txtTaxAmt.Text)) {
			    	clsdbo_FactResellerSales.TaxAmt = null;
			    } else {
			    	clsdbo_FactResellerSales.TaxAmt = System.Convert.ToDecimal(txtTaxAmt.Text); }
			    if (string.IsNullOrEmpty(txtFreight.Text)) {
			    	clsdbo_FactResellerSales.Freight = null;
			    } else {
			    	clsdbo_FactResellerSales.Freight = System.Convert.ToDecimal(txtFreight.Text); }
			    if (string.IsNullOrEmpty(txtCarrierTrackingNumber.Text)) {
			    	clsdbo_FactResellerSales.CarrierTrackingNumber = null;
			    } else {
			    	clsdbo_FactResellerSales.CarrierTrackingNumber = txtCarrierTrackingNumber.Text; }
			    if (string.IsNullOrEmpty(txtCustomerPONumber.Text)) {
			    	clsdbo_FactResellerSales.CustomerPONumber = null;
			    } else {
			    	clsdbo_FactResellerSales.CustomerPONumber = txtCustomerPONumber.Text; }
			    if (string.IsNullOrEmpty(txtOrderDate.Text)) {
			    	clsdbo_FactResellerSales.OrderDate = null;
			    } else {
			    	clsdbo_FactResellerSales.OrderDate = System.Convert.ToDateTime(txtOrderDate.Text); }
			    if (string.IsNullOrEmpty(txtDueDate.Text)) {
			    	clsdbo_FactResellerSales.DueDate = null;
			    } else {
			    	clsdbo_FactResellerSales.DueDate = System.Convert.ToDateTime(txtDueDate.Text); }
			    if (string.IsNullOrEmpty(txtShipDate.Text)) {
			    	clsdbo_FactResellerSales.ShipDate = null;
			    } else {
			    	clsdbo_FactResellerSales.ShipDate = System.Convert.ToDateTime(txtShipDate.Text); }
        }

        private void InsertRecord()
        {
		    dbo_FactResellerSalesClass clsdbo_FactResellerSales = new dbo_FactResellerSalesClass();
		    if (VerifyData() == true) {
                            SetData(clsdbo_FactResellerSales);
			    bool bSucess = false;
			    bSucess = dbo_FactResellerSalesDataClass.Add(clsdbo_FactResellerSales);
			    if (bSucess == true) {
				    pnlForm.Visible = false;
				    pnlSave.Visible = false;
				    pnlGrid.Visible = true;
				    lblMode.InnerText = "";
				    Session.Remove("dvdbo_FactResellerSales");
				    LoadGriddbo_FactResellerSales();
			    } else {
				    ec.ShowMessage(" Insert failed. ", " Dbo. Fact Reseller Sales ");
			    }
		    }
        }

        private void UpdateRecord()
        {
		    dbo_FactResellerSalesClass oclsdbo_FactResellerSales = new dbo_FactResellerSalesClass();
		    dbo_FactResellerSalesClass clsdbo_FactResellerSales = new dbo_FactResellerSalesClass();

		    oclsdbo_FactResellerSales.SalesOrderNumber = System.Convert.ToString(Session["SalesOrderNumber"]);
		    oclsdbo_FactResellerSales.SalesOrderLineNumber = System.Convert.ToByte(Session["SalesOrderLineNumber"]);
		    oclsdbo_FactResellerSales = dbo_FactResellerSalesDataClass.Select_Record(oclsdbo_FactResellerSales);

		    if (VerifyData() == true) {
                            SetData(clsdbo_FactResellerSales);
			    bool bSucess = false;
			    bSucess = dbo_FactResellerSalesDataClass.Update(oclsdbo_FactResellerSales, clsdbo_FactResellerSales);
			    if (bSucess == true) {
				    pnlForm.Visible = false;
				    pnlSave.Visible = false;
				    pnlGrid.Visible = true;
				    lblMode.InnerText = "";
				    Session.Remove("dvdbo_FactResellerSales");
				    LoadGriddbo_FactResellerSales();
			    } else {
				    ec.ShowMessage(" Update failed. ", " Dbo. Fact Reseller Sales ");
			    }
		    }
        }

        private void DeleteRecord()
        {
		    dbo_FactResellerSalesClass clsdbo_FactResellerSales = new dbo_FactResellerSalesClass();
		    clsdbo_FactResellerSales.SalesOrderNumber = System.Convert.ToString(Session["SalesOrderNumber"]);
		    clsdbo_FactResellerSales.SalesOrderLineNumber = System.Convert.ToByte(Session["SalesOrderLineNumber"]);
                    SetData(clsdbo_FactResellerSales);
		    bool bSucess = false;
		    bSucess = dbo_FactResellerSalesDataClass.Delete(clsdbo_FactResellerSales);
		    if (bSucess == true) {
			    pnlForm.Visible = false;
			    pnlSave.Visible = false;
			    pnlGrid.Visible = true;
			    pnlDelete.Visible = false;
			    lblMode.InnerText = "";
			    Session.Remove("dvdbo_FactResellerSales");
			    LoadGriddbo_FactResellerSales();
		    } else {
			    ec.ShowMessage(" Delete failed. ", " Dbo. Fact Reseller Sales ");
		    }
        }

        private Boolean VerifyData()
        {
		    if (txtSalesOrderNumber.Text == "") {
		    	ec.ShowMessage(" Sales Order Number is Required. ", " Dbo. Fact Reseller Sales ");
	                txtSalesOrderNumber.Focus();
                	return false;}
		    if (txtSalesOrderLineNumber.Text == "") {
		    	ec.ShowMessage(" Sales Order Line Number is Required. ", " Dbo. Fact Reseller Sales ");
	                txtSalesOrderLineNumber.Focus();
                	return false;}
		    if (txtProductKey.Text == "") {
		    	ec.ShowMessage(" Product Key is Required. ", " Dbo. Fact Reseller Sales ");
	                txtProductKey.Focus();
                	return false;}
		    if (txtOrderDateKey.Text == "") {
		    	ec.ShowMessage(" Order Date Key is Required. ", " Dbo. Fact Reseller Sales ");
	                txtOrderDateKey.Focus();
                	return false;}
		    if (txtDueDateKey.Text == "") {
		    	ec.ShowMessage(" Due Date Key is Required. ", " Dbo. Fact Reseller Sales ");
	                txtDueDateKey.Focus();
                	return false;}
		    if (txtShipDateKey.Text == "") {
		    	ec.ShowMessage(" Ship Date Key is Required. ", " Dbo. Fact Reseller Sales ");
	                txtShipDateKey.Focus();
                	return false;}
		    if (txtResellerKey.Text == "") {
		    	ec.ShowMessage(" Reseller Key is Required. ", " Dbo. Fact Reseller Sales ");
	                txtResellerKey.Focus();
                	return false;}
		    if (txtEmployeeKey.Text == "") {
		    	ec.ShowMessage(" Employee Key is Required. ", " Dbo. Fact Reseller Sales ");
	                txtEmployeeKey.Focus();
                	return false;}
		    if (txtPromotionKey.Text == "") {
		    	ec.ShowMessage(" Promotion Key is Required. ", " Dbo. Fact Reseller Sales ");
	                txtPromotionKey.Focus();
                	return false;}
		    if (txtCurrencyKey.Text == "") {
		    	ec.ShowMessage(" Currency Key is Required. ", " Dbo. Fact Reseller Sales ");
	                txtCurrencyKey.Focus();
                	return false;}
		    if (txtSalesTerritoryKey.Text == "") {
		    	ec.ShowMessage(" Sales Territory Key is Required. ", " Dbo. Fact Reseller Sales ");
	                txtSalesTerritoryKey.Focus();
                	return false;}
            if (
            txtSalesOrderNumber.Text != "" 
            && txtSalesOrderLineNumber.Text != "" 
            )  {
            dbo_FactResellerSalesClass clsdbo_FactResellerSales = new dbo_FactResellerSalesClass();
            clsdbo_FactResellerSales.SalesOrderNumber = System.Convert.ToString(txtSalesOrderNumber.Text);
            clsdbo_FactResellerSales.SalesOrderLineNumber = System.Convert.ToByte(txtSalesOrderLineNumber.Text);
            clsdbo_FactResellerSales = dbo_FactResellerSalesDataClass.Select_Record(clsdbo_FactResellerSales);
		    if (clsdbo_FactResellerSales != null && (String)Session["Mode"] == "Add") {
                    	ec.ShowMessage(" Record already exists. ", " Dbo. Fact Reseller Sales ");
                 	txtSalesOrderNumber.Focus();
                	return false; }
            }
		    return true;
        }

        public void butRecords_Click(object sender, System.EventArgs e)
        {
		    grddbo_FactResellerSales.CurrentPageIndex = 0;
		    grddbo_FactResellerSales.PageSize = Convert.ToInt32(cmbRecords.Text);
		    LoadGriddbo_FactResellerSales();
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
			    txtResellerKey.SelectedIndex = -1;
			    txtEmployeeKey.SelectedIndex = -1;
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

        public void grddbo_FactResellerSales_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
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

        public void grddbo_FactResellerSales_SortCommand(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
        {
		    htmlHiddenSortExpression.Value = e.SortExpression + " " + GetSortDirection(e.SortExpression);
		    LoadGriddbo_FactResellerSales();
        }

        public void grddbo_FactResellerSales_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
        {
		    grddbo_FactResellerSales.CurrentPageIndex = e.NewPageIndex;
		    LoadGriddbo_FactResellerSales();
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
		    Session.Remove("dvdbo_FactResellerSales");
		    LoadGriddbo_FactResellerSales();
        }

        public void butSearch_Click(object sender, System.EventArgs e)
        {
		    try {
                        Session.Remove("dvdbo_FactResellerSales");
			if ((Session["dvdbo_FactResellerSales"] != null)) {
				dvdbo_FactResellerSales = (DataView)Session["dvdbo_FactResellerSales"];
				// DataView was not found in the session.
		    	} else {
				dvdbo_FactResellerSales = dbo_FactResellerSalesDataClass.Search(cmbFields.Text, cmbCondition.Text, txtSearch.Text).DefaultView;
			    	Session["dvdbo_FactResellerSales"] = dvdbo_FactResellerSales;
		    	}
                if (dvdbo_FactResellerSales.Count > 0)
                {
                    dvdbo_FactResellerSales.Sort = htmlHiddenSortExpression.Value;
                    grddbo_FactResellerSales.DataSource = dvdbo_FactResellerSales;
                    grddbo_FactResellerSales.DataBind();
                }
                else
                {
                    grddbo_FactResellerSales.DataSource = null;
                    grddbo_FactResellerSales.DataBind();
                }
		    }
		    catch (Exception ex)
		    {
		    	ec.ShowMessage(ex.Message, " Dbo. Fact Reseller Sales ");
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
                    { dt = dbo_FactResellerSalesDataClass.Search(cmbFields.Text, cmbCondition.Text, txtSearch.Text); }
                    else { dt = dbo_FactResellerSalesDataClass.SelectAll(); }

                    PDFform pdfForm = new PDFform(dt, "Dbo. Fact Reseller Sales", "Many");
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
                    GVExport.DataSource = Session["dvdbo_FactResellerSales"];
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
 
