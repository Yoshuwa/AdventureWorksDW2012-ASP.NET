<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Page Title="dbo_FactInternetSales" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="frmdbo_FactInternetSales.aspx.cs" Inherits="AdventureWorksDW2012.frmdbo_FactInternetSales" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <link rel="stylesheet" href="../Styles/Reset.css" type="text/css" media="screen" />
    <link rel="stylesheet" href="../Styles/Site.css" type="text/css" media="screen" />
    <ajaxToolkit:ToolkitScriptManager runat="Server" EnableScriptGlobalization="true"
        EnableScriptLocalization="true" ID="ScriptManager1" />
    <uc:OkMessageBox ID="ec" runat="server" />
    <h2>Dbo. Fact Internet Sales</h2>
    <div style="height: 10px"></div>
    <h2 id="lblMode" runat="server"></h2>
    <div style="height: 10px"></div>
    <asp:Panel ID="pnlGrid" Visible="True" runat="server">
        <div style="text-align: center;">
            <div style="display: inline-block;">
                <asp:DropDownList id="cmbFields" runat="server" Width="150px" CssClass="input" CausesValidation="False"></asp:DropDownList>
                <asp:DropDownList id="cmbCondition" runat="server" Width="150px" CssClass="input" CausesValidation="False"></asp:DropDownList>
                <asp:textbox id="txtSearch" runat="server" Width="100px" CssClass="input"></asp:textbox>
                <asp:button id="butSearch" Text="Search" Runat="server" Width="70px" CausesValidation="False" OnClick="butSearch_Click"></asp:button>
                <asp:button id="butShowAll" Text="Show All" Runat="server" Width="70px" CausesValidation="False" OnClick="butShowAll_Click"></asp:button>
            </div>
        </div>
        <div style="height: 40px"></div>
        <div style="text-align: center;">
            <div style="display: inline-block;">
                <asp:button id="btnAddNew" Width="130px" Text="Add New Record" Runat="server" CausesValidation="False" OnClick="btnAddNew_Click"></asp:button>
            </div>
        </div>
        <div>
            <div style="float: left;">
                <asp:DropDownList id="ddlFile" Width="100px" runat="server" CssClass="input">
                    <asp:ListItem Value=".pdf">Pdf</asp:ListItem>
                    <asp:ListItem Value=".xls">Excel</asp:ListItem>
                    <asp:ListItem Value=".doc">Word</asp:ListItem>
                </asp:DropDownList>
                <asp:Button Visible="True" id="btnExport" Width="70px" runat="server" Text="Export" OnClick="btnExport_Click" CausesValidation="False"></asp:Button>
            </div>
            <div style="float: right;">
                <asp:DropDownList id="cmbRecords" Width="100px" runat="server" CssClass="input" CausesValidation="False"></asp:DropDownList>
                <asp:button id="butRecords" Width="70px" Text="Records" Runat="server" CausesValidation="False" OnClick="butRecords_Click"></asp:button>&nbsp;
            </div>
        </div>
        <div style="height: 40px"></div>
        <%-------------------------------------%>
        <div style="text-align: center;">
            <div style="display: inline-block; overflow: auto;">
                <%-----
                    If GridView (grddbo_FactInternetSales) width is bigger than web-page (or screen) width (for Mobile and Tablet)...
                    1) comment above 2 lines, and
                    2) uncomment following 2 lines
                -------%>
                <%--<div style="width: 100%;">
                <div style="overflow: auto;">--%>
                <%-------------------------------------%>
                <asp:datagrid id="grddbo_FactInternetSales" runat="server" AllowPaging="True" PageSize="5" AutoGenerateColumns="False" AllowSorting="True" DataKeyNames="SalesOrderNumber" Font-Size="Medium"
                    OnItemCommand="grddbo_FactInternetSales_ItemCommand" OnSortCommand="grddbo_FactInternetSales_SortCommand" OnPageIndexChanged="grddbo_FactInternetSales_PageIndexChanged" >
                    <Columns>
                        <asp:BoundColumn DataField="SalesOrderNumber" SortExpression="SalesOrderNumber" HeaderText="Sales Order Number" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" />
                        <asp:TemplateColumn>
                            <ItemTemplate>
                                <asp:Label runat="server" Width="10px"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:BoundColumn DataField="SalesOrderLineNumber" SortExpression="SalesOrderLineNumber" HeaderText="Sales Order Line Number" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right" />
                        <asp:TemplateColumn>
                            <ItemTemplate>
                                <asp:Label runat="server" Width="10px"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:BoundColumn DataField="EnglishProductName" SortExpression="EnglishProductName" HeaderText="Product Key" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" />
                        <asp:TemplateColumn>
                            <ItemTemplate>
                                <asp:Label runat="server" Width="10px"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:BoundColumn DataField="FullDateAlternateKey" SortExpression="FullDateAlternateKey" HeaderText="Order Date Key" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" />
                        <asp:TemplateColumn>
                            <ItemTemplate>
                                <asp:Label runat="server" Width="10px"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:BoundColumn DataField="FullDateAlternateKey" SortExpression="FullDateAlternateKey" HeaderText="Due Date Key" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" />
                        <asp:TemplateColumn>
                            <ItemTemplate>
                                <asp:Label runat="server" Width="10px"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:BoundColumn DataField="FullDateAlternateKey" SortExpression="FullDateAlternateKey" HeaderText="Ship Date Key" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" />
                        <asp:TemplateColumn>
                            <ItemTemplate>
                                <asp:Label runat="server" Width="10px"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:BoundColumn DataField="FirstName" SortExpression="FirstName" HeaderText="Customer Key" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" />
                        <asp:TemplateColumn>
                            <ItemTemplate>
                                <asp:Label runat="server" Width="10px"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:BoundColumn DataField="EnglishPromotionName" SortExpression="EnglishPromotionName" HeaderText="Promotion Key" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" />
                        <asp:TemplateColumn>
                            <ItemTemplate>
                                <asp:Label runat="server" Width="10px"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:BoundColumn DataField="CurrencyName" SortExpression="CurrencyName" HeaderText="Currency Key" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" />
                        <asp:TemplateColumn>
                            <ItemTemplate>
                                <asp:Label runat="server" Width="10px"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:BoundColumn DataField="SalesTerritoryAlternateKey" SortExpression="SalesTerritoryAlternateKey" HeaderText="Sales Territory Key" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" />
                        <asp:TemplateColumn>
                            <ItemTemplate>
                                <asp:Label runat="server" Width="10px"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:BoundColumn DataField="RevisionNumber" SortExpression="RevisionNumber" HeaderText="Revision Number" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right" />
                        <asp:TemplateColumn>
                            <ItemTemplate>
                                <asp:Label runat="server" Width="10px"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:BoundColumn DataField="OrderQuantity" SortExpression="OrderQuantity" HeaderText="Order Quantity" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right" />
                        <asp:TemplateColumn>
                            <ItemTemplate>
                                <asp:Label runat="server" Width="10px"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:BoundColumn DataField="UnitPrice" SortExpression="UnitPrice" HeaderText="Unit Price"  DataFormatString="{0:C}" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right" />
                        <asp:TemplateColumn>
                            <ItemTemplate>
                                <asp:Label runat="server" Width="10px"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:BoundColumn DataField="ExtendedAmount" SortExpression="ExtendedAmount" HeaderText="Extended Amount"  DataFormatString="{0:C}" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right" />
                        <asp:TemplateColumn>
                            <ItemTemplate>
                                <asp:Label runat="server" Width="10px"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:BoundColumn DataField="UnitPriceDiscountPct" SortExpression="UnitPriceDiscountPct" HeaderText="Unit Price Discount Pct" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right" />
                        <asp:TemplateColumn>
                            <ItemTemplate>
                                <asp:Label runat="server" Width="10px"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:BoundColumn DataField="DiscountAmount" SortExpression="DiscountAmount" HeaderText="Discount Amount" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right" />
                        <asp:TemplateColumn>
                            <ItemTemplate>
                                <asp:Label runat="server" Width="10px"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:BoundColumn DataField="ProductStandardCost" SortExpression="ProductStandardCost" HeaderText="Product Standard Cost"  DataFormatString="{0:C}" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right" />
                        <asp:TemplateColumn>
                            <ItemTemplate>
                                <asp:Label runat="server" Width="10px"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:BoundColumn DataField="TotalProductCost" SortExpression="TotalProductCost" HeaderText="Total Product Cost"  DataFormatString="{0:C}" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right" />
                        <asp:TemplateColumn>
                            <ItemTemplate>
                                <asp:Label runat="server" Width="10px"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:BoundColumn DataField="SalesAmount" SortExpression="SalesAmount" HeaderText="Sales Amount"  DataFormatString="{0:C}" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right" />
                        <asp:TemplateColumn>
                            <ItemTemplate>
                                <asp:Label runat="server" Width="10px"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:BoundColumn DataField="TaxAmt" SortExpression="TaxAmt" HeaderText="Tax Amt"  DataFormatString="{0:C}" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right" />
                        <asp:TemplateColumn>
                            <ItemTemplate>
                                <asp:Label runat="server" Width="10px"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:BoundColumn DataField="Freight" SortExpression="Freight" HeaderText="Freight"  DataFormatString="{0:C}" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right" />
                        <asp:TemplateColumn>
                            <ItemTemplate>
                                <asp:Label runat="server" Width="10px"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:BoundColumn DataField="CarrierTrackingNumber" SortExpression="CarrierTrackingNumber" HeaderText="Carrier Tracking Number" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" />
                        <asp:TemplateColumn>
                            <ItemTemplate>
                                <asp:Label runat="server" Width="10px"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:BoundColumn DataField="CustomerPONumber" SortExpression="CustomerPONumber" HeaderText="Customer P O Number" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" />
                        <asp:TemplateColumn>
                            <ItemTemplate>
                                <asp:Label runat="server" Width="10px"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:BoundColumn DataField="OrderDate" SortExpression="OrderDate" HeaderText="Order Date"  DataFormatString="{0:d}" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" />
                        <asp:TemplateColumn>
                            <ItemTemplate>
                                <asp:Label runat="server" Width="10px"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:BoundColumn DataField="DueDate" SortExpression="DueDate" HeaderText="Due Date"  DataFormatString="{0:d}" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" />
                        <asp:TemplateColumn>
                            <ItemTemplate>
                                <asp:Label runat="server" Width="10px"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:BoundColumn DataField="ShipDate" SortExpression="ShipDate" HeaderText="Ship Date"  DataFormatString="{0:d}" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" />
                        <asp:TemplateColumn>
                            <ItemTemplate>
                                <asp:Label runat="server" Width="10px"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:ButtonColumn Text="Edit" ButtonType="PushButton" CommandName="Select" />
                        <asp:TemplateColumn>
                            <ItemTemplate>
                                <asp:Label runat="server" Width="5px"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:ButtonColumn Text="Delete" ButtonType="PushButton" CommandName="Select" />
                    </Columns>
                    <PagerStyle Mode="NumericPages" HorizontalAlign="Center" CssClass="GridPager" />
                    <AlternatingItemStyle BackColor="AliceBlue" />
                </asp:datagrid><br />
                <input id="htmlHiddenSortExpression" type="hidden" value="SalesOrderNumber" name="htmlHiddenSortExpression" runat="server" />
            </div>
        </div>
    </asp:panel>
    <asp:panel id="pnlDelete" Visible="False" Runat="server">
        <div style="text-align: center;">
            <div style="display: inline-block; overflow: auto;">
                <h3>Are you sure? Delete this record?</h3>
            </div>
            <div style="height: 10px"></div>
            <div style="display: inline-block; overflow: auto;">
                <asp:button id="butYes" Text="Yes" Runat="server" CausesValidation="False" Width="75" OnClick="butYes_Click"></asp:button>
            </div>
            <div style="display: inline-block; overflow: auto;">
                <asp:button id="butNo" Text="No" Runat="server" CausesValidation="False" Width="75" OnClick="butNo_Click"></asp:button>
            </div>
        </div>
        <div style="height: 40px"></div>
    </asp:Panel>
    <asp:Panel ID="pnlForm" Visible="False" runat="server">
        <div style="text-align: center;">
            <div style="display: inline-block; width: 100px; text-align: left;">
                Sales Order Number:
            </div>
            <div style="display: inline-block; width: 300px;">
                <asp:textbox id="txtSalesOrderNumber" width="300px" runat="server" CssClass="input"></asp:textbox>
                <asp:RequiredFieldValidator id="rfvSalesOrderNumber" runat="server" ErrorMessage="Required!" Display="Dynamic" ControlToValidate="txtSalesOrderNumber"></asp:RequiredFieldValidator>
            </div>
        </div>
        <div style="text-align: center;">
            <div style="display: inline-block; width: 100px; text-align: left;">
                Sales Order Line Number:
            </div>
            <div style="display: inline-block; width: 300px;">
                <asp:textbox id="txtSalesOrderLineNumber" width="100px" runat="server" CssClass="input" style="float: left; text-align: right;"></asp:textbox>
                <asp:RequiredFieldValidator id="rfvSalesOrderLineNumber" runat="server" ErrorMessage="Required!" Display="Dynamic" ControlToValidate="txtSalesOrderLineNumber"></asp:RequiredFieldValidator>
            </div>
        </div>
        <div style="text-align: center;">
            <div style="display: inline-block; width: 100px; text-align: left;">
                Product Key:
            </div>
            <div style="display: inline-block; width: 300px;">
                <asp:DropDownList id="txtProductKey" width="300px" runat="server" CssClass="input"></asp:DropDownList>
                <asp:RequiredFieldValidator id="rfvProductKey" runat="server" ErrorMessage="Required!" Display="Dynamic" ControlToValidate="txtProductKey"></asp:RequiredFieldValidator>
            </div>
        </div>
        <div style="text-align: center;">
            <div style="display: inline-block; width: 100px; text-align: left;">
                Order Date Key:
            </div>
            <div style="display: inline-block; width: 300px;">
                <asp:DropDownList id="txtOrderDateKey" width="300px" runat="server" CssClass="input"></asp:DropDownList>
                <asp:RequiredFieldValidator id="rfvOrderDateKey" runat="server" ErrorMessage="Required!" Display="Dynamic" ControlToValidate="txtOrderDateKey"></asp:RequiredFieldValidator>
            </div>
        </div>
        <div style="text-align: center;">
            <div style="display: inline-block; width: 100px; text-align: left;">
                Due Date Key:
            </div>
            <div style="display: inline-block; width: 300px;">
                <asp:DropDownList id="txtDueDateKey" width="300px" runat="server" CssClass="input"></asp:DropDownList>
                <asp:RequiredFieldValidator id="rfvDueDateKey" runat="server" ErrorMessage="Required!" Display="Dynamic" ControlToValidate="txtDueDateKey"></asp:RequiredFieldValidator>
            </div>
        </div>
        <div style="text-align: center;">
            <div style="display: inline-block; width: 100px; text-align: left;">
                Ship Date Key:
            </div>
            <div style="display: inline-block; width: 300px;">
                <asp:DropDownList id="txtShipDateKey" width="300px" runat="server" CssClass="input"></asp:DropDownList>
                <asp:RequiredFieldValidator id="rfvShipDateKey" runat="server" ErrorMessage="Required!" Display="Dynamic" ControlToValidate="txtShipDateKey"></asp:RequiredFieldValidator>
            </div>
        </div>
        <div style="text-align: center;">
            <div style="display: inline-block; width: 100px; text-align: left;">
                Customer Key:
            </div>
            <div style="display: inline-block; width: 300px;">
                <asp:DropDownList id="txtCustomerKey" width="300px" runat="server" CssClass="input"></asp:DropDownList>
                <asp:RequiredFieldValidator id="rfvCustomerKey" runat="server" ErrorMessage="Required!" Display="Dynamic" ControlToValidate="txtCustomerKey"></asp:RequiredFieldValidator>
            </div>
        </div>
        <div style="text-align: center;">
            <div style="display: inline-block; width: 100px; text-align: left;">
                Promotion Key:
            </div>
            <div style="display: inline-block; width: 300px;">
                <asp:DropDownList id="txtPromotionKey" width="300px" runat="server" CssClass="input"></asp:DropDownList>
                <asp:RequiredFieldValidator id="rfvPromotionKey" runat="server" ErrorMessage="Required!" Display="Dynamic" ControlToValidate="txtPromotionKey"></asp:RequiredFieldValidator>
            </div>
        </div>
        <div style="text-align: center;">
            <div style="display: inline-block; width: 100px; text-align: left;">
                Currency Key:
            </div>
            <div style="display: inline-block; width: 300px;">
                <asp:DropDownList id="txtCurrencyKey" width="300px" runat="server" CssClass="input"></asp:DropDownList>
                <asp:RequiredFieldValidator id="rfvCurrencyKey" runat="server" ErrorMessage="Required!" Display="Dynamic" ControlToValidate="txtCurrencyKey"></asp:RequiredFieldValidator>
            </div>
        </div>
        <div style="text-align: center;">
            <div style="display: inline-block; width: 100px; text-align: left;">
                Sales Territory Key:
            </div>
            <div style="display: inline-block; width: 300px;">
                <asp:DropDownList id="txtSalesTerritoryKey" width="300px" runat="server" CssClass="input"></asp:DropDownList>
                <asp:RequiredFieldValidator id="rfvSalesTerritoryKey" runat="server" ErrorMessage="Required!" Display="Dynamic" ControlToValidate="txtSalesTerritoryKey"></asp:RequiredFieldValidator>
            </div>
        </div>
        <div style="text-align: center;">
            <div style="display: inline-block; width: 100px; text-align: left;">
                Revision Number:
            </div>
            <div style="display: inline-block; width: 300px;">
                <asp:textbox id="txtRevisionNumber" width="100px" runat="server" CssClass="input" style="float: left; text-align: right;"></asp:textbox>
                <asp:RequiredFieldValidator id="rfvRevisionNumber" runat="server" ErrorMessage="Required!" Display="Dynamic" ControlToValidate="txtRevisionNumber"></asp:RequiredFieldValidator>
            </div>
        </div>
        <div style="text-align: center;">
            <div style="display: inline-block; width: 100px; text-align: left;">
                Order Quantity:
            </div>
            <div style="display: inline-block; width: 300px;">
                <asp:textbox id="txtOrderQuantity" width="100px" runat="server" CssClass="input" style="float: left; text-align: right;"></asp:textbox>
                <asp:RequiredFieldValidator id="rfvOrderQuantity" runat="server" ErrorMessage="Required!" Display="Dynamic" ControlToValidate="txtOrderQuantity"></asp:RequiredFieldValidator>
            </div>
        </div>
        <div style="text-align: center;">
            <div style="display: inline-block; width: 100px; text-align: left;">
                Unit Price:
            </div>
            <div style="display: inline-block; width: 300px;">
                <asp:textbox id="txtUnitPrice" width="100px" runat="server" CssClass="input" style="float: left; text-align: right;"></asp:textbox>
                <asp:RequiredFieldValidator id="rfvUnitPrice" runat="server" ErrorMessage="Required!" Display="Dynamic" ControlToValidate="txtUnitPrice"></asp:RequiredFieldValidator>
            </div>
        </div>
        <div style="text-align: center;">
            <div style="display: inline-block; width: 100px; text-align: left;">
                Extended Amount:
            </div>
            <div style="display: inline-block; width: 300px;">
                <asp:textbox id="txtExtendedAmount" width="100px" runat="server" CssClass="input" style="float: left; text-align: right;"></asp:textbox>
                <asp:RequiredFieldValidator id="rfvExtendedAmount" runat="server" ErrorMessage="Required!" Display="Dynamic" ControlToValidate="txtExtendedAmount"></asp:RequiredFieldValidator>
            </div>
        </div>
        <div style="text-align: center;">
            <div style="display: inline-block; width: 100px; text-align: left;">
                Unit Price Discount Pct:
            </div>
            <div style="display: inline-block; width: 300px;">
                <asp:textbox id="txtUnitPriceDiscountPct" width="100px" runat="server" CssClass="input" style="float: left; text-align: right;"></asp:textbox>
                <asp:RequiredFieldValidator id="rfvUnitPriceDiscountPct" runat="server" ErrorMessage="Required!" Display="Dynamic" ControlToValidate="txtUnitPriceDiscountPct"></asp:RequiredFieldValidator>
            </div>
        </div>
        <div style="text-align: center;">
            <div style="display: inline-block; width: 100px; text-align: left;">
                Discount Amount:
            </div>
            <div style="display: inline-block; width: 300px;">
                <asp:textbox id="txtDiscountAmount" width="100px" runat="server" CssClass="input" style="float: left; text-align: right;"></asp:textbox>
                <asp:RequiredFieldValidator id="rfvDiscountAmount" runat="server" ErrorMessage="Required!" Display="Dynamic" ControlToValidate="txtDiscountAmount"></asp:RequiredFieldValidator>
            </div>
        </div>
        <div style="text-align: center;">
            <div style="display: inline-block; width: 100px; text-align: left;">
                Product Standard Cost:
            </div>
            <div style="display: inline-block; width: 300px;">
                <asp:textbox id="txtProductStandardCost" width="100px" runat="server" CssClass="input" style="float: left; text-align: right;"></asp:textbox>
                <asp:RequiredFieldValidator id="rfvProductStandardCost" runat="server" ErrorMessage="Required!" Display="Dynamic" ControlToValidate="txtProductStandardCost"></asp:RequiredFieldValidator>
            </div>
        </div>
        <div style="text-align: center;">
            <div style="display: inline-block; width: 100px; text-align: left;">
                Total Product Cost:
            </div>
            <div style="display: inline-block; width: 300px;">
                <asp:textbox id="txtTotalProductCost" width="100px" runat="server" CssClass="input" style="float: left; text-align: right;"></asp:textbox>
                <asp:RequiredFieldValidator id="rfvTotalProductCost" runat="server" ErrorMessage="Required!" Display="Dynamic" ControlToValidate="txtTotalProductCost"></asp:RequiredFieldValidator>
            </div>
        </div>
        <div style="text-align: center;">
            <div style="display: inline-block; width: 100px; text-align: left;">
                Sales Amount:
            </div>
            <div style="display: inline-block; width: 300px;">
                <asp:textbox id="txtSalesAmount" width="100px" runat="server" CssClass="input" style="float: left; text-align: right;"></asp:textbox>
                <asp:RequiredFieldValidator id="rfvSalesAmount" runat="server" ErrorMessage="Required!" Display="Dynamic" ControlToValidate="txtSalesAmount"></asp:RequiredFieldValidator>
            </div>
        </div>
        <div style="text-align: center;">
            <div style="display: inline-block; width: 100px; text-align: left;">
                Tax Amt:
            </div>
            <div style="display: inline-block; width: 300px;">
                <asp:textbox id="txtTaxAmt" width="100px" runat="server" CssClass="input" style="float: left; text-align: right;"></asp:textbox>
                <asp:RequiredFieldValidator id="rfvTaxAmt" runat="server" ErrorMessage="Required!" Display="Dynamic" ControlToValidate="txtTaxAmt"></asp:RequiredFieldValidator>
            </div>
        </div>
        <div style="text-align: center;">
            <div style="display: inline-block; width: 100px; text-align: left;">
                Freight:
            </div>
            <div style="display: inline-block; width: 300px;">
                <asp:textbox id="txtFreight" width="100px" runat="server" CssClass="input" style="float: left; text-align: right;"></asp:textbox>
                <asp:RequiredFieldValidator id="rfvFreight" runat="server" ErrorMessage="Required!" Display="Dynamic" ControlToValidate="txtFreight"></asp:RequiredFieldValidator>
            </div>
        </div>
        <div style="text-align: center;">
            <div style="display: inline-block; width: 100px; text-align: left;">
                Carrier Tracking Number:
            </div>
            <div style="display: inline-block; width: 300px;">
                <asp:textbox id="txtCarrierTrackingNumber" width="300px" runat="server" CssClass="input"></asp:textbox>
            </div>
        </div>
        <div style="text-align: center;">
            <div style="display: inline-block; width: 100px; text-align: left;">
                Customer P O Number:
            </div>
            <div style="display: inline-block; width: 300px;">
                <asp:textbox id="txtCustomerPONumber" width="300px" runat="server" CssClass="input"></asp:textbox>
            </div>
        </div>
        <div style="text-align: center;">
            <div style="display: inline-block; width: 100px; text-align: left;">
                Order Date:
            </div>
            <div style="display: inline-block; width: 300px;">
                                     <table>
                                          <tr>
                                               <td>
                <asp:TextBox ID="txtOrderDate" width="100px" runat="server" CssClass="input"></asp:TextBox>
                                               </td>
                                               <td>
                <asp:ImageButton runat="Server" ID="ImageOrderDate" ImageUrl="/images/Calendar.png" AlternateText="Click to show calendar" CausesValidation="False" /><br />
                <ajaxToolkit:CalendarExtender ID="calendarButtonExtenderOrderDate" runat="server" TargetControlID="txtOrderDate" PopupButtonID="ImageOrderDate" />
                                               </td>
                                          </tr>
                                     </table>
            </div>
        </div>
        <div style="text-align: center;">
            <div style="display: inline-block; width: 100px; text-align: left;">
                Due Date:
            </div>
            <div style="display: inline-block; width: 300px;">
                                     <table>
                                          <tr>
                                               <td>
                <asp:TextBox ID="txtDueDate" width="100px" runat="server" CssClass="input"></asp:TextBox>
                                               </td>
                                               <td>
                <asp:ImageButton runat="Server" ID="ImageDueDate" ImageUrl="/images/Calendar.png" AlternateText="Click to show calendar" CausesValidation="False" /><br />
                <ajaxToolkit:CalendarExtender ID="calendarButtonExtenderDueDate" runat="server" TargetControlID="txtDueDate" PopupButtonID="ImageDueDate" />
                                               </td>
                                          </tr>
                                     </table>
            </div>
        </div>
        <div style="text-align: center;">
            <div style="display: inline-block; width: 100px; text-align: left;">
                Ship Date:
            </div>
            <div style="display: inline-block; width: 300px;">
                                     <table>
                                          <tr>
                                               <td>
                <asp:TextBox ID="txtShipDate" width="100px" runat="server" CssClass="input"></asp:TextBox>
                                               </td>
                                               <td>
                <asp:ImageButton runat="Server" ID="ImageShipDate" ImageUrl="/images/Calendar.png" AlternateText="Click to show calendar" CausesValidation="False" /><br />
                <ajaxToolkit:CalendarExtender ID="calendarButtonExtenderShipDate" runat="server" TargetControlID="txtShipDate" PopupButtonID="ImageShipDate" />
                                               </td>
                                          </tr>
                                     </table>
            </div>
        </div>
        <div style="height: 40px"></div>
    </asp:Panel>
    <asp:Panel ID="pnlSave" Visible="False" runat="server">
        <div style="text-align: center;">
            <div style="display: inline-block; overflow: auto;">
                <asp:Button id="butCancel" Text="Cancel" Runat="server" CausesValidation="False" Width="100" OnClick="butCancel_Click"></asp:Button>
            </div>
            <div style="display: inline-block; overflow: auto;">
                <asp:Button id="btnSave" Text="Save Changes" Runat="server" Width="100" OnClick="btnSave_Click"></asp:Button>
            </div>
        </div>
        <div style="height: 40px"></div>
    </asp:Panel>
    <asp:Panel ID="pnlMessage" Visible="False" runat="server">
        <div style="text-align: center;">
            <div style="display: inline-block; overflow: auto;">
                <asp:Label ID="lblMessage" runat="server"></asp:Label>
            </div>
            <div style="display: inline-block; overflow: auto;">
                <asp:Button id="butOK" Text="OK" Runat="server" Width="50" OnClick="butOK_Click"></asp:Button>
            </div>
        </div>
        <div style="height: 40px"></div>
    </asp:Panel>
</asp:Content>
 
