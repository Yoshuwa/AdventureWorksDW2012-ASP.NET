<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Page Title="dbo_DimSalesTerritory" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="frmdbo_DimSalesTerritory.aspx.cs" Inherits="AdventureWorksDW2012.frmdbo_DimSalesTerritory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <link rel="stylesheet" href="../Styles/Reset.css" type="text/css" media="screen" />
    <link rel="stylesheet" href="../Styles/Site.css" type="text/css" media="screen" />
    <ajaxToolkit:ToolkitScriptManager runat="Server" EnableScriptGlobalization="true"
        EnableScriptLocalization="true" ID="ScriptManager1" />
    <uc:OkMessageBox ID="ec" runat="server" />
    <h2>Dbo. Dim Sales Territory</h2>
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
                    If GridView (grddbo_DimSalesTerritory) width is bigger than web-page (or screen) width (for Mobile and Tablet)...
                    1) comment above 2 lines, and
                    2) uncomment following 2 lines
                -------%>
                <%--<div style="width: 100%;">
                <div style="overflow: auto;">--%>
                <%-------------------------------------%>
                <asp:datagrid id="grddbo_DimSalesTerritory" runat="server" AllowPaging="True" PageSize="5" AutoGenerateColumns="False" AllowSorting="True" DataKeyNames="SalesTerritoryKey" Font-Size="Medium"
                    OnItemCommand="grddbo_DimSalesTerritory_ItemCommand" OnSortCommand="grddbo_DimSalesTerritory_SortCommand" OnPageIndexChanged="grddbo_DimSalesTerritory_PageIndexChanged" >
                    <Columns>
                        <asp:BoundColumn DataField="SalesTerritoryKey" SortExpression="SalesTerritoryKey" HeaderText="Sales Territory Key" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right" />
                        <asp:TemplateColumn>
                            <ItemTemplate>
                                <asp:Label runat="server" Width="10px"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:BoundColumn DataField="SalesTerritoryAlternateKey" SortExpression="SalesTerritoryAlternateKey" HeaderText="Sales Territory Alternate Key" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right" />
                        <asp:TemplateColumn>
                            <ItemTemplate>
                                <asp:Label runat="server" Width="10px"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:BoundColumn DataField="SalesTerritoryRegion" SortExpression="SalesTerritoryRegion" HeaderText="Sales Territory Region" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" />
                        <asp:TemplateColumn>
                            <ItemTemplate>
                                <asp:Label runat="server" Width="10px"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:BoundColumn DataField="SalesTerritoryCountry" SortExpression="SalesTerritoryCountry" HeaderText="Sales Territory Country" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" />
                        <asp:TemplateColumn>
                            <ItemTemplate>
                                <asp:Label runat="server" Width="10px"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:BoundColumn DataField="SalesTerritoryGroup" SortExpression="SalesTerritoryGroup" HeaderText="Sales Territory Group" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" />
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
                <input id="htmlHiddenSortExpression" type="hidden" value="SalesTerritoryKey" name="htmlHiddenSortExpression" runat="server" />
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
                Sales Territory Key:
            </div>
            <div style="display: inline-block; width: 300px;">
                <asp:textbox id="txtSalesTerritoryKey" width="100px" runat="server" CssClass="input" style="float: left; text-align: right;"></asp:textbox>
                <asp:RequiredFieldValidator id="rfvSalesTerritoryKey" runat="server" ErrorMessage="Required!" Display="Dynamic" ControlToValidate="txtSalesTerritoryKey"></asp:RequiredFieldValidator>
            </div>
        </div>
        <div style="text-align: center;">
            <div style="display: inline-block; width: 100px; text-align: left;">
                Sales Territory Alternate Key:
            </div>
            <div style="display: inline-block; width: 300px;">
                <asp:textbox id="txtSalesTerritoryAlternateKey" width="100px" runat="server" CssClass="input" style="float: left; text-align: right;"></asp:textbox>
            </div>
        </div>
        <div style="text-align: center;">
            <div style="display: inline-block; width: 100px; text-align: left;">
                Sales Territory Region:
            </div>
            <div style="display: inline-block; width: 300px;">
                <asp:textbox id="txtSalesTerritoryRegion" width="300px" runat="server" CssClass="input"></asp:textbox>
                <asp:RequiredFieldValidator id="rfvSalesTerritoryRegion" runat="server" ErrorMessage="Required!" Display="Dynamic" ControlToValidate="txtSalesTerritoryRegion"></asp:RequiredFieldValidator>
            </div>
        </div>
        <div style="text-align: center;">
            <div style="display: inline-block; width: 100px; text-align: left;">
                Sales Territory Country:
            </div>
            <div style="display: inline-block; width: 300px;">
                <asp:textbox id="txtSalesTerritoryCountry" width="300px" runat="server" CssClass="input"></asp:textbox>
                <asp:RequiredFieldValidator id="rfvSalesTerritoryCountry" runat="server" ErrorMessage="Required!" Display="Dynamic" ControlToValidate="txtSalesTerritoryCountry"></asp:RequiredFieldValidator>
            </div>
        </div>
        <div style="text-align: center;">
            <div style="display: inline-block; width: 100px; text-align: left;">
                Sales Territory Group:
            </div>
            <div style="display: inline-block; width: 300px;">
                <asp:textbox id="txtSalesTerritoryGroup" width="300px" runat="server" CssClass="input"></asp:textbox>
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
 
