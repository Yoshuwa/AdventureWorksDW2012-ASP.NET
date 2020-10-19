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
    public partial class frmdbo_DimProduct : System.Web.UI.Page
    {

        private dbo_DimProductDataClass clsdbo_DimProductData = new dbo_DimProductDataClass();
        private AdventureWorksDW2012DataClass clsAdventureWorksDW2012Data = new AdventureWorksDW2012DataClass();
        private DataView dvdbo_DimProduct;

        protected void Page_Load(object sender, EventArgs e)
        {
		    if (!Page.IsPostBack) {
			    Session["Mode"] = "";
 			    Session["ProductKey"] = "";

			    Session.Remove("dvdbo_DimProduct");

                            cmbFields.Items.Add("Product Key");
                            cmbFields.Items.Add("Product Alternate Key");
                            cmbFields.Items.Add("Product Subcategory Key");
                            cmbFields.Items.Add("Weight Unit Measure Code");
                            cmbFields.Items.Add("Size Unit Measure Code");
                            cmbFields.Items.Add("English Product Name");
                            cmbFields.Items.Add("Spanish Product Name");
                            cmbFields.Items.Add("French Product Name");
                            cmbFields.Items.Add("Standard Cost");
                            cmbFields.Items.Add("Finished Goods Flag");
                            cmbFields.Items.Add("Color");
                            cmbFields.Items.Add("Safety Stock Level");
                            cmbFields.Items.Add("Reorder Point");
                            cmbFields.Items.Add("List Price");
                            cmbFields.Items.Add("Size");
                            cmbFields.Items.Add("Size Range");
                            cmbFields.Items.Add("Weight");
                            cmbFields.Items.Add("Days To Manufacture");
                            cmbFields.Items.Add("Product Line");
                            cmbFields.Items.Add("Dealer Price");
                            cmbFields.Items.Add("Class");
                            cmbFields.Items.Add("Style");
                            cmbFields.Items.Add("Model Name");
                            cmbFields.Items.Add("English Description");
                            cmbFields.Items.Add("French Description");
                            cmbFields.Items.Add("Chinese Description");
                            cmbFields.Items.Add("Arabic Description");
                            cmbFields.Items.Add("Hebrew Description");
                            cmbFields.Items.Add("Thai Description");
                            cmbFields.Items.Add("German Description");
                            cmbFields.Items.Add("Japanese Description");
                            cmbFields.Items.Add("Turkish Description");
                            cmbFields.Items.Add("Start Date");
                            cmbFields.Items.Add("End Date");
                            cmbFields.Items.Add("Status");

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

            Loaddbo_DimProduct_dbo_DimProductSubcategoryComboBox();

			    LoadGriddbo_DimProduct();
		    }

        }


	    private void Loaddbo_DimProduct_dbo_DimProductSubcategoryComboBox()
	    {
		    List<dbo_DimProduct_dbo_DimProductSubcategoryClass> dbo_DimProduct_dbo_DimProductSubcategoryList = new  List<dbo_DimProduct_dbo_DimProductSubcategoryClass>();
		    try {
			    dbo_DimProduct_dbo_DimProductSubcategoryList = dbo_DimProduct_dbo_DimProductSubcategoryDataClass.List();
			    txtProductSubcategoryKey.DataSource = dbo_DimProduct_dbo_DimProductSubcategoryList;
			    txtProductSubcategoryKey.DataValueField = "ProductSubcategoryKey";
			    txtProductSubcategoryKey.DataTextField = "EnglishProductSubcategoryName";
			    txtProductSubcategoryKey.DataBind();
		    }
		    catch (Exception ex)
		    {
		    	ec.ShowMessage(ex.Message, " Dbo. Dim Product ");
		    }
	    }

        private void LoadGriddbo_DimProduct()
        {
		    try {
			if ((Session["dvdbo_DimProduct"] != null)) {
				dvdbo_DimProduct = (DataView)Session["dvdbo_DimProduct"];
				// DataView was not found in the session.
		    	} else {
				dvdbo_DimProduct = dbo_DimProductDataClass.SelectAll().DefaultView;
			    	Session["dvdbo_DimProduct"] = dvdbo_DimProduct;
		    	}
                if (dvdbo_DimProduct.Count > 0)
                {
                    dvdbo_DimProduct.Sort = htmlHiddenSortExpression.Value;
                    grddbo_DimProduct.DataSource = dvdbo_DimProduct;
                    grddbo_DimProduct.DataBind();
                }
                else
                {
                    grddbo_DimProduct.DataSource = null;
                    grddbo_DimProduct.DataBind();
                }
		    }
		    catch (Exception ex)
		    {
		    	ec.ShowMessage(ex.Message, " Dbo. Dim Product ");
		    }
        }

        private void Add()
        {
		    Session.Remove("Mode");
		    Session["Mode"] = "Add";

		    ClearRecord();

		    this.txtProductAlternateKey.Enabled = true;
		    this.txtProductSubcategoryKey.Enabled = true;
		    this.txtWeightUnitMeasureCode.Enabled = true;
		    this.txtSizeUnitMeasureCode.Enabled = true;
		    this.txtEnglishProductName.Enabled = true;
		    this.txtSpanishProductName.Enabled = true;
		    this.txtFrenchProductName.Enabled = true;
		    this.txtStandardCost.Enabled = true;
		    this.txtFinishedGoodsFlag.Enabled = true;
		    this.txtColor.Enabled = true;
		    this.txtSafetyStockLevel.Enabled = true;
		    this.txtReorderPoint.Enabled = true;
		    this.txtListPrice.Enabled = true;
		    this.txtSize.Enabled = true;
		    this.txtSizeRange.Enabled = true;
		    this.txtWeight.Enabled = true;
		    this.txtDaysToManufacture.Enabled = true;
		    this.txtProductLine.Enabled = true;
		    this.txtDealerPrice.Enabled = true;
		    this.txtClass.Enabled = true;
		    this.txtStyle.Enabled = true;
		    this.txtModelName.Enabled = true;
		    this.txtEnglishDescription.Enabled = true;
		    this.txtFrenchDescription.Enabled = true;
		    this.txtChineseDescription.Enabled = true;
		    this.txtArabicDescription.Enabled = true;
		    this.txtHebrewDescription.Enabled = true;
		    this.txtThaiDescription.Enabled = true;
		    this.txtGermanDescription.Enabled = true;
		    this.txtJapaneseDescription.Enabled = true;
		    this.txtTurkishDescription.Enabled = true;
		    this.txtStartDate.Enabled = true;
		    this.txtEndDate.Enabled = true;
		    this.txtStatus.Enabled = true;
		    txtProductKey.Enabled = false;
		    txtProductAlternateKey.Focus();
		    txtProductKey.Text = Convert.ToString(clsAdventureWorksDW2012Data.getAutoID("New", "DimProduct"));
        }

        private void GetData()
        {
		    ClearRecord();

		    dbo_DimProductClass clsdbo_DimProduct = new dbo_DimProductClass();
		    clsdbo_DimProduct.ProductKey = System.Convert.ToInt32(Session["ProductKey"]);
		    clsdbo_DimProduct = dbo_DimProductDataClass.Select_Record(clsdbo_DimProduct);

		    if ((clsdbo_DimProduct != null)) {
			    try {
                		txtProductKey.Text = System.Convert.ToString(clsdbo_DimProduct.ProductKey);
                		if (clsdbo_DimProduct.ProductAlternateKey == null) { txtProductAlternateKey.Text = default(string); } else { txtProductAlternateKey.Text = System.Convert.ToString(clsdbo_DimProduct.ProductAlternateKey); }
                		if (clsdbo_DimProduct.ProductSubcategoryKey == null) { txtProductSubcategoryKey.SelectedValue = default(string); } else { txtProductSubcategoryKey.SelectedValue = System.Convert.ToString(clsdbo_DimProduct.ProductSubcategoryKey); }
                		if (clsdbo_DimProduct.WeightUnitMeasureCode == null) { txtWeightUnitMeasureCode.Text = default(string); } else { txtWeightUnitMeasureCode.Text = System.Convert.ToString(clsdbo_DimProduct.WeightUnitMeasureCode); }
                		if (clsdbo_DimProduct.SizeUnitMeasureCode == null) { txtSizeUnitMeasureCode.Text = default(string); } else { txtSizeUnitMeasureCode.Text = System.Convert.ToString(clsdbo_DimProduct.SizeUnitMeasureCode); }
                		txtEnglishProductName.Text = System.Convert.ToString(clsdbo_DimProduct.EnglishProductName);
                		txtSpanishProductName.Text = System.Convert.ToString(clsdbo_DimProduct.SpanishProductName);
                		txtFrenchProductName.Text = System.Convert.ToString(clsdbo_DimProduct.FrenchProductName);
                		if (clsdbo_DimProduct.StandardCost == null) { txtStandardCost.Text = default(string); } else { txtStandardCost.Text = System.Convert.ToString(clsdbo_DimProduct.StandardCost); }
                		txtFinishedGoodsFlag.Checked = System.Convert.ToBoolean(clsdbo_DimProduct.FinishedGoodsFlag);
                		txtColor.Text = System.Convert.ToString(clsdbo_DimProduct.Color);
                		if (clsdbo_DimProduct.SafetyStockLevel == null) { txtSafetyStockLevel.Text = default(string); } else { txtSafetyStockLevel.Text = System.Convert.ToString(clsdbo_DimProduct.SafetyStockLevel); }
                		if (clsdbo_DimProduct.ReorderPoint == null) { txtReorderPoint.Text = default(string); } else { txtReorderPoint.Text = System.Convert.ToString(clsdbo_DimProduct.ReorderPoint); }
                		if (clsdbo_DimProduct.ListPrice == null) { txtListPrice.Text = default(string); } else { txtListPrice.Text = System.Convert.ToString(clsdbo_DimProduct.ListPrice); }
                		if (clsdbo_DimProduct.Size == null) { txtSize.Text = default(string); } else { txtSize.Text = System.Convert.ToString(clsdbo_DimProduct.Size); }
                		if (clsdbo_DimProduct.SizeRange == null) { txtSizeRange.Text = default(string); } else { txtSizeRange.Text = System.Convert.ToString(clsdbo_DimProduct.SizeRange); }
                		if (clsdbo_DimProduct.Weight == null) { txtWeight.Text = default(string); } else { txtWeight.Text = System.Convert.ToString(clsdbo_DimProduct.Weight); }
                		if (clsdbo_DimProduct.DaysToManufacture == null) { txtDaysToManufacture.Text = default(string); } else { txtDaysToManufacture.Text = System.Convert.ToString(clsdbo_DimProduct.DaysToManufacture); }
                		if (clsdbo_DimProduct.ProductLine == null) { txtProductLine.Text = default(string); } else { txtProductLine.Text = System.Convert.ToString(clsdbo_DimProduct.ProductLine); }
                		if (clsdbo_DimProduct.DealerPrice == null) { txtDealerPrice.Text = default(string); } else { txtDealerPrice.Text = System.Convert.ToString(clsdbo_DimProduct.DealerPrice); }
                		if (clsdbo_DimProduct.Class == null) { txtClass.Text = default(string); } else { txtClass.Text = System.Convert.ToString(clsdbo_DimProduct.Class); }
                		if (clsdbo_DimProduct.Style == null) { txtStyle.Text = default(string); } else { txtStyle.Text = System.Convert.ToString(clsdbo_DimProduct.Style); }
                		if (clsdbo_DimProduct.ModelName == null) { txtModelName.Text = default(string); } else { txtModelName.Text = System.Convert.ToString(clsdbo_DimProduct.ModelName); }
                		if (clsdbo_DimProduct.EnglishDescription == null) { txtEnglishDescription.Text = default(string); } else { txtEnglishDescription.Text = System.Convert.ToString(clsdbo_DimProduct.EnglishDescription); }
                		if (clsdbo_DimProduct.FrenchDescription == null) { txtFrenchDescription.Text = default(string); } else { txtFrenchDescription.Text = System.Convert.ToString(clsdbo_DimProduct.FrenchDescription); }
                		if (clsdbo_DimProduct.ChineseDescription == null) { txtChineseDescription.Text = default(string); } else { txtChineseDescription.Text = System.Convert.ToString(clsdbo_DimProduct.ChineseDescription); }
                		if (clsdbo_DimProduct.ArabicDescription == null) { txtArabicDescription.Text = default(string); } else { txtArabicDescription.Text = System.Convert.ToString(clsdbo_DimProduct.ArabicDescription); }
                		if (clsdbo_DimProduct.HebrewDescription == null) { txtHebrewDescription.Text = default(string); } else { txtHebrewDescription.Text = System.Convert.ToString(clsdbo_DimProduct.HebrewDescription); }
                		if (clsdbo_DimProduct.ThaiDescription == null) { txtThaiDescription.Text = default(string); } else { txtThaiDescription.Text = System.Convert.ToString(clsdbo_DimProduct.ThaiDescription); }
                		if (clsdbo_DimProduct.GermanDescription == null) { txtGermanDescription.Text = default(string); } else { txtGermanDescription.Text = System.Convert.ToString(clsdbo_DimProduct.GermanDescription); }
                		if (clsdbo_DimProduct.JapaneseDescription == null) { txtJapaneseDescription.Text = default(string); } else { txtJapaneseDescription.Text = System.Convert.ToString(clsdbo_DimProduct.JapaneseDescription); }
                		if (clsdbo_DimProduct.TurkishDescription == null) { txtTurkishDescription.Text = default(string); } else { txtTurkishDescription.Text = System.Convert.ToString(clsdbo_DimProduct.TurkishDescription); }
                		if (clsdbo_DimProduct.StartDate == null) { txtStartDate.Text = DateTime.Now.ToString(); } else { txtStartDate.Text = System.Convert.ToDateTime(clsdbo_DimProduct.StartDate).ToShortDateString(); }
                		if (clsdbo_DimProduct.EndDate == null) { txtEndDate.Text = DateTime.Now.ToString(); } else { txtEndDate.Text = System.Convert.ToDateTime(clsdbo_DimProduct.EndDate).ToShortDateString(); }
                		if (clsdbo_DimProduct.Status == null) { txtStatus.Text = default(string); } else { txtStatus.Text = System.Convert.ToString(clsdbo_DimProduct.Status); }
		   	 }
		    	catch (Exception ex)
		    	{
		    		ec.ShowMessage(ex.Message, " Dbo. Dim Product ");
		    	}
		    }

        }

        private void Edit()
        {
		    Session.Remove("Mode");
		    Session["Mode"] = "Edit";

                    GetData();

		    txtProductAlternateKey.Enabled = true;
		    txtProductSubcategoryKey.Enabled = true;
		    txtWeightUnitMeasureCode.Enabled = true;
		    txtSizeUnitMeasureCode.Enabled = true;
		    txtEnglishProductName.Enabled = true;
		    txtSpanishProductName.Enabled = true;
		    txtFrenchProductName.Enabled = true;
		    txtStandardCost.Enabled = true;
		    txtColor.Enabled = true;
		    txtSafetyStockLevel.Enabled = true;
		    txtReorderPoint.Enabled = true;
		    txtListPrice.Enabled = true;
		    txtSize.Enabled = true;
		    txtSizeRange.Enabled = true;
		    txtWeight.Enabled = true;
		    txtDaysToManufacture.Enabled = true;
		    txtProductLine.Enabled = true;
		    txtDealerPrice.Enabled = true;
		    txtClass.Enabled = true;
		    txtStyle.Enabled = true;
		    txtModelName.Enabled = true;
		    txtEnglishDescription.Enabled = true;
		    txtFrenchDescription.Enabled = true;
		    txtChineseDescription.Enabled = true;
		    txtArabicDescription.Enabled = true;
		    txtHebrewDescription.Enabled = true;
		    txtThaiDescription.Enabled = true;
		    txtGermanDescription.Enabled = true;
		    txtJapaneseDescription.Enabled = true;
		    txtTurkishDescription.Enabled = true;
		    txtStatus.Enabled = true;
		    txtProductKey.Enabled = false;
		    txtProductAlternateKey.Focus();
        }

        private void Delete()
        {
		    Session.Remove("Mode");
		    Session["Mode"] = "Delete";

                    GetData();

		    txtProductKey.Enabled = false;
		    txtProductAlternateKey.Enabled = false;
		    txtProductSubcategoryKey.Enabled = false;
		    txtWeightUnitMeasureCode.Enabled = false;
		    txtSizeUnitMeasureCode.Enabled = false;
		    txtEnglishProductName.Enabled = false;
		    txtSpanishProductName.Enabled = false;
		    txtFrenchProductName.Enabled = false;
		    txtStandardCost.Enabled = false;
		    txtFinishedGoodsFlag.Enabled = false;
		    txtColor.Enabled = false;
		    txtSafetyStockLevel.Enabled = false;
		    txtReorderPoint.Enabled = false;
		    txtListPrice.Enabled = false;
		    txtSize.Enabled = false;
		    txtSizeRange.Enabled = false;
		    txtWeight.Enabled = false;
		    txtDaysToManufacture.Enabled = false;
		    txtProductLine.Enabled = false;
		    txtDealerPrice.Enabled = false;
		    txtClass.Enabled = false;
		    txtStyle.Enabled = false;
		    txtModelName.Enabled = false;
		    txtEnglishDescription.Enabled = false;
		    txtFrenchDescription.Enabled = false;
		    txtChineseDescription.Enabled = false;
		    txtArabicDescription.Enabled = false;
		    txtHebrewDescription.Enabled = false;
		    txtThaiDescription.Enabled = false;
		    txtGermanDescription.Enabled = false;
		    txtJapaneseDescription.Enabled = false;
		    txtTurkishDescription.Enabled = false;
		    txtStartDate.Enabled = false;
		    txtEndDate.Enabled = false;
		    txtStatus.Enabled = false;
        }

        private void ClearRecord()
        {
	        txtProductKey.Text = null;
	        txtProductAlternateKey.Text = null;
	        txtProductSubcategoryKey.SelectedIndex = -1;
	        txtWeightUnitMeasureCode.Text = null;
	        txtSizeUnitMeasureCode.Text = null;
	        txtEnglishProductName.Text = null;
	        txtSpanishProductName.Text = null;
	        txtFrenchProductName.Text = null;
	        txtStandardCost.Text = null;
        	txtFinishedGoodsFlag.Text = null;
	        txtColor.Text = null;
	        txtSafetyStockLevel.Text = null;
	        txtReorderPoint.Text = null;
	        txtListPrice.Text = null;
	        txtSize.Text = null;
	        txtSizeRange.Text = null;
	        txtWeight.Text = null;
	        txtDaysToManufacture.Text = null;
	        txtProductLine.Text = null;
	        txtDealerPrice.Text = null;
	        txtClass.Text = null;
	        txtStyle.Text = null;
	        txtModelName.Text = null;
	        txtEnglishDescription.Text = null;
	        txtFrenchDescription.Text = null;
	        txtChineseDescription.Text = null;
	        txtArabicDescription.Text = null;
	        txtHebrewDescription.Text = null;
	        txtThaiDescription.Text = null;
	        txtGermanDescription.Text = null;
	        txtJapaneseDescription.Text = null;
	        txtTurkishDescription.Text = null;
        	txtStartDate.Text = null;
        	txtEndDate.Text = null;
	        txtStatus.Text = null;
        }

        public void btnSave_Click(object sender, System.EventArgs e)
        {
		    if ((String)Session["Mode"] == "Add") {
			    this.InsertRecord();
		    } else if ((String)Session["Mode"] == "Edit") {
			    this.UpdateRecord();
		    }
        }

        private void SetData(dbo_DimProductClass clsdbo_DimProduct)
        {
			    if (string.IsNullOrEmpty(txtProductAlternateKey.Text)) {
			    	clsdbo_DimProduct.ProductAlternateKey = null;
			    } else {
			    	clsdbo_DimProduct.ProductAlternateKey = txtProductAlternateKey.Text; }
			    if (string.IsNullOrEmpty(txtProductSubcategoryKey.SelectedValue)) {
			    	clsdbo_DimProduct.ProductSubcategoryKey = null;
			    } else {
			    	clsdbo_DimProduct.ProductSubcategoryKey = System.Convert.ToInt32(txtProductSubcategoryKey.SelectedValue); }
			    if (string.IsNullOrEmpty(txtWeightUnitMeasureCode.Text)) {
			    	clsdbo_DimProduct.WeightUnitMeasureCode = null;
			    } else {
			    	clsdbo_DimProduct.WeightUnitMeasureCode = txtWeightUnitMeasureCode.Text; }
			    if (string.IsNullOrEmpty(txtSizeUnitMeasureCode.Text)) {
			    	clsdbo_DimProduct.SizeUnitMeasureCode = null;
			    } else {
			    	clsdbo_DimProduct.SizeUnitMeasureCode = txtSizeUnitMeasureCode.Text; }
			    clsdbo_DimProduct.EnglishProductName = System.Convert.ToString(txtEnglishProductName.Text);
			    clsdbo_DimProduct.SpanishProductName = System.Convert.ToString(txtSpanishProductName.Text);
			    clsdbo_DimProduct.FrenchProductName = System.Convert.ToString(txtFrenchProductName.Text);
			    if (string.IsNullOrEmpty(txtStandardCost.Text)) {
			    	clsdbo_DimProduct.StandardCost = null;
			    } else {
			    	clsdbo_DimProduct.StandardCost = System.Convert.ToDecimal(txtStandardCost.Text); }
			    clsdbo_DimProduct.FinishedGoodsFlag = System.Convert.ToBoolean(txtFinishedGoodsFlag.Checked ? true : false);
			    clsdbo_DimProduct.Color = System.Convert.ToString(txtColor.Text);
			    if (string.IsNullOrEmpty(txtSafetyStockLevel.Text)) {
			    	clsdbo_DimProduct.SafetyStockLevel = null;
			    } else {
			    	clsdbo_DimProduct.SafetyStockLevel = System.Convert.ToInt16(txtSafetyStockLevel.Text); }
			    if (string.IsNullOrEmpty(txtReorderPoint.Text)) {
			    	clsdbo_DimProduct.ReorderPoint = null;
			    } else {
			    	clsdbo_DimProduct.ReorderPoint = System.Convert.ToInt16(txtReorderPoint.Text); }
			    if (string.IsNullOrEmpty(txtListPrice.Text)) {
			    	clsdbo_DimProduct.ListPrice = null;
			    } else {
			    	clsdbo_DimProduct.ListPrice = System.Convert.ToDecimal(txtListPrice.Text); }
			    if (string.IsNullOrEmpty(txtSize.Text)) {
			    	clsdbo_DimProduct.Size = null;
			    } else {
			    	clsdbo_DimProduct.Size = txtSize.Text; }
			    if (string.IsNullOrEmpty(txtSizeRange.Text)) {
			    	clsdbo_DimProduct.SizeRange = null;
			    } else {
			    	clsdbo_DimProduct.SizeRange = txtSizeRange.Text; }
			    if (string.IsNullOrEmpty(txtWeight.Text)) {
			    	clsdbo_DimProduct.Weight = null;
			    } else {
			    	clsdbo_DimProduct.Weight = System.Convert.ToDecimal(txtWeight.Text); }
			    if (string.IsNullOrEmpty(txtDaysToManufacture.Text)) {
			    	clsdbo_DimProduct.DaysToManufacture = null;
			    } else {
			    	clsdbo_DimProduct.DaysToManufacture = System.Convert.ToInt32(txtDaysToManufacture.Text); }
			    if (string.IsNullOrEmpty(txtProductLine.Text)) {
			    	clsdbo_DimProduct.ProductLine = null;
			    } else {
			    	clsdbo_DimProduct.ProductLine = txtProductLine.Text; }
			    if (string.IsNullOrEmpty(txtDealerPrice.Text)) {
			    	clsdbo_DimProduct.DealerPrice = null;
			    } else {
			    	clsdbo_DimProduct.DealerPrice = System.Convert.ToDecimal(txtDealerPrice.Text); }
			    if (string.IsNullOrEmpty(txtClass.Text)) {
			    	clsdbo_DimProduct.Class = null;
			    } else {
			    	clsdbo_DimProduct.Class = txtClass.Text; }
			    if (string.IsNullOrEmpty(txtStyle.Text)) {
			    	clsdbo_DimProduct.Style = null;
			    } else {
			    	clsdbo_DimProduct.Style = txtStyle.Text; }
			    if (string.IsNullOrEmpty(txtModelName.Text)) {
			    	clsdbo_DimProduct.ModelName = null;
			    } else {
			    	clsdbo_DimProduct.ModelName = txtModelName.Text; }
			    if (string.IsNullOrEmpty(txtEnglishDescription.Text)) {
			    	clsdbo_DimProduct.EnglishDescription = null;
			    } else {
			    	clsdbo_DimProduct.EnglishDescription = txtEnglishDescription.Text; }
			    if (string.IsNullOrEmpty(txtFrenchDescription.Text)) {
			    	clsdbo_DimProduct.FrenchDescription = null;
			    } else {
			    	clsdbo_DimProduct.FrenchDescription = txtFrenchDescription.Text; }
			    if (string.IsNullOrEmpty(txtChineseDescription.Text)) {
			    	clsdbo_DimProduct.ChineseDescription = null;
			    } else {
			    	clsdbo_DimProduct.ChineseDescription = txtChineseDescription.Text; }
			    if (string.IsNullOrEmpty(txtArabicDescription.Text)) {
			    	clsdbo_DimProduct.ArabicDescription = null;
			    } else {
			    	clsdbo_DimProduct.ArabicDescription = txtArabicDescription.Text; }
			    if (string.IsNullOrEmpty(txtHebrewDescription.Text)) {
			    	clsdbo_DimProduct.HebrewDescription = null;
			    } else {
			    	clsdbo_DimProduct.HebrewDescription = txtHebrewDescription.Text; }
			    if (string.IsNullOrEmpty(txtThaiDescription.Text)) {
			    	clsdbo_DimProduct.ThaiDescription = null;
			    } else {
			    	clsdbo_DimProduct.ThaiDescription = txtThaiDescription.Text; }
			    if (string.IsNullOrEmpty(txtGermanDescription.Text)) {
			    	clsdbo_DimProduct.GermanDescription = null;
			    } else {
			    	clsdbo_DimProduct.GermanDescription = txtGermanDescription.Text; }
			    if (string.IsNullOrEmpty(txtJapaneseDescription.Text)) {
			    	clsdbo_DimProduct.JapaneseDescription = null;
			    } else {
			    	clsdbo_DimProduct.JapaneseDescription = txtJapaneseDescription.Text; }
			    if (string.IsNullOrEmpty(txtTurkishDescription.Text)) {
			    	clsdbo_DimProduct.TurkishDescription = null;
			    } else {
			    	clsdbo_DimProduct.TurkishDescription = txtTurkishDescription.Text; }
			    if (string.IsNullOrEmpty(txtStartDate.Text)) {
			    	clsdbo_DimProduct.StartDate = null;
			    } else {
			    	clsdbo_DimProduct.StartDate = System.Convert.ToDateTime(txtStartDate.Text); }
			    if (string.IsNullOrEmpty(txtEndDate.Text)) {
			    	clsdbo_DimProduct.EndDate = null;
			    } else {
			    	clsdbo_DimProduct.EndDate = System.Convert.ToDateTime(txtEndDate.Text); }
			    if (string.IsNullOrEmpty(txtStatus.Text)) {
			    	clsdbo_DimProduct.Status = null;
			    } else {
			    	clsdbo_DimProduct.Status = txtStatus.Text; }
        }

        private void InsertRecord()
        {
		    dbo_DimProductClass clsdbo_DimProduct = new dbo_DimProductClass();
		    if (VerifyData() == true) {
                            SetData(clsdbo_DimProduct);
			    bool bSucess = false;
			    bSucess = dbo_DimProductDataClass.Add(clsdbo_DimProduct);
			    if (bSucess == true) {
				    pnlForm.Visible = false;
				    pnlSave.Visible = false;
				    pnlGrid.Visible = true;
				    lblMode.InnerText = "";
				    Session.Remove("dvdbo_DimProduct");
				    LoadGriddbo_DimProduct();
			    } else {
				    ec.ShowMessage(" Insert failed. ", " Dbo. Dim Product ");
			    }
		    }
        }

        private void UpdateRecord()
        {
		    dbo_DimProductClass oclsdbo_DimProduct = new dbo_DimProductClass();
		    dbo_DimProductClass clsdbo_DimProduct = new dbo_DimProductClass();

		    oclsdbo_DimProduct.ProductKey = System.Convert.ToInt32(Session["ProductKey"]);
		    oclsdbo_DimProduct = dbo_DimProductDataClass.Select_Record(oclsdbo_DimProduct);

		    if (VerifyData() == true) {
                            SetData(clsdbo_DimProduct);
			    bool bSucess = false;
			    bSucess = dbo_DimProductDataClass.Update(oclsdbo_DimProduct, clsdbo_DimProduct);
			    if (bSucess == true) {
				    pnlForm.Visible = false;
				    pnlSave.Visible = false;
				    pnlGrid.Visible = true;
				    lblMode.InnerText = "";
				    Session.Remove("dvdbo_DimProduct");
				    LoadGriddbo_DimProduct();
			    } else {
				    ec.ShowMessage(" Update failed. ", " Dbo. Dim Product ");
			    }
		    }
        }

        private void DeleteRecord()
        {
		    dbo_DimProductClass clsdbo_DimProduct = new dbo_DimProductClass();
		    clsdbo_DimProduct.ProductKey = System.Convert.ToInt32(Session["ProductKey"]);
                    SetData(clsdbo_DimProduct);
		    bool bSucess = false;
		    bSucess = dbo_DimProductDataClass.Delete(clsdbo_DimProduct);
		    if (bSucess == true) {
			    pnlForm.Visible = false;
			    pnlSave.Visible = false;
			    pnlGrid.Visible = true;
			    pnlDelete.Visible = false;
			    lblMode.InnerText = "";
			    Session.Remove("dvdbo_DimProduct");
			    LoadGriddbo_DimProduct();
		    } else {
			    ec.ShowMessage(" Delete failed. ", " Dbo. Dim Product ");
		    }
        }

        private Boolean VerifyData()
        {
		    if (txtEnglishProductName.Text == "") {
		    	ec.ShowMessage(" English Product Name is Required. ", " Dbo. Dim Product ");
	                txtEnglishProductName.Focus();
                	return false;}
		    if (txtSpanishProductName.Text == "") {
		    	ec.ShowMessage(" Spanish Product Name is Required. ", " Dbo. Dim Product ");
	                txtSpanishProductName.Focus();
                	return false;}
		    if (txtFrenchProductName.Text == "") {
		    	ec.ShowMessage(" French Product Name is Required. ", " Dbo. Dim Product ");
	                txtFrenchProductName.Focus();
                	return false;}
            
		    if (txtColor.Text == "") {
		    	ec.ShowMessage(" Color is Required. ", " Dbo. Dim Product ");
	                txtColor.Focus();
                	return false;}
		    return true;
        }

        public void butRecords_Click(object sender, System.EventArgs e)
        {
		    grddbo_DimProduct.CurrentPageIndex = 0;
		    grddbo_DimProduct.PageSize = Convert.ToInt32(cmbRecords.Text);
		    LoadGriddbo_DimProduct();
        }

        public void btnAddNew_Click(object sender, System.EventArgs e)
        {
		    if (pnlForm.Visible) {
			    txtProductKey.Text = "";
			    txtProductAlternateKey.Text = "";
			    txtProductSubcategoryKey.SelectedIndex = -1;
			    txtWeightUnitMeasureCode.Text = "";
			    txtSizeUnitMeasureCode.Text = "";
			    txtEnglishProductName.Text = "";
			    txtSpanishProductName.Text = "";
			    txtFrenchProductName.Text = "";
			    txtStandardCost.Text = "";
			    txtFinishedGoodsFlag.Checked = false;
			    txtColor.Text = "";
			    txtSafetyStockLevel.Text = "";
			    txtReorderPoint.Text = "";
			    txtListPrice.Text = "";
			    txtSize.Text = "";
			    txtSizeRange.Text = "";
			    txtWeight.Text = "";
			    txtDaysToManufacture.Text = "";
			    txtProductLine.Text = "";
			    txtDealerPrice.Text = "";
			    txtClass.Text = "";
			    txtStyle.Text = "";
			    txtModelName.Text = "";
			    txtEnglishDescription.Text = "";
			    txtFrenchDescription.Text = "";
			    txtChineseDescription.Text = "";
			    txtArabicDescription.Text = "";
			    txtHebrewDescription.Text = "";
			    txtThaiDescription.Text = "";
			    txtGermanDescription.Text = "";
			    txtJapaneseDescription.Text = "";
			    txtTurkishDescription.Text = "";
			    txtStartDate.Text = "";
			    txtEndDate.Text = "";
			    txtStatus.Text = "";
		    } else {
			    pnlForm.Visible = true;
			    pnlGrid.Visible = false;
			    pnlSave.Visible = true;
			    lblMode.InnerText = "Add new";
		    }
		    btnSave.CommandArgument = "Add";
		    Add();
        }

        public void grddbo_DimProduct_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
        { 
		    if (e.Item.ItemType == ListItemType.Pager | e.Item.ItemType == ListItemType.Header)
			    return;

		    Button btn = (Button)e.CommandSource;
		    if (btn.Text == "Edit" | btn.Text == "Delete") {
			    Session.Remove("ProductKey");
			    Session["ProductKey"] = e.Item.Cells[0 + 0].Text;
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

        public void grddbo_DimProduct_SortCommand(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
        {
		    htmlHiddenSortExpression.Value = e.SortExpression + " " + GetSortDirection(e.SortExpression);
		    LoadGriddbo_DimProduct();
        }

        public void grddbo_DimProduct_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
        {
		    grddbo_DimProduct.CurrentPageIndex = e.NewPageIndex;
		    LoadGriddbo_DimProduct();
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
		    Session.Remove("dvdbo_DimProduct");
		    LoadGriddbo_DimProduct();
        }

        public void butSearch_Click(object sender, System.EventArgs e)
        {
		    try {
                        Session.Remove("dvdbo_DimProduct");
			if ((Session["dvdbo_DimProduct"] != null)) {
				dvdbo_DimProduct = (DataView)Session["dvdbo_DimProduct"];
				// DataView was not found in the session.
		    	} else {
				dvdbo_DimProduct = dbo_DimProductDataClass.Search(cmbFields.Text, cmbCondition.Text, txtSearch.Text).DefaultView;
			    	Session["dvdbo_DimProduct"] = dvdbo_DimProduct;
		    	}
                if (dvdbo_DimProduct.Count > 0)
                {
                    dvdbo_DimProduct.Sort = htmlHiddenSortExpression.Value;
                    grddbo_DimProduct.DataSource = dvdbo_DimProduct;
                    grddbo_DimProduct.DataBind();
                }
                else
                {
                    grddbo_DimProduct.DataSource = null;
                    grddbo_DimProduct.DataBind();
                }
		    }
		    catch (Exception ex)
		    {
		    	ec.ShowMessage(ex.Message, " Dbo. Dim Product ");
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
                    { dt = dbo_DimProductDataClass.Search(cmbFields.Text, cmbCondition.Text, txtSearch.Text); }
                    else { dt = dbo_DimProductDataClass.SelectAll(); }

                    PDFform pdfForm = new PDFform(dt, "Dbo. Dim Product", "Many");
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
                    GVExport.DataSource = Session["dvdbo_DimProduct"];
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
 
