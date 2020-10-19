<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Page Title="dbo_DimDate" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="frmdbo_DimDate.aspx.cs" Inherits="AdventureWorksDW2012.frmdbo_DimDate" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <link rel="stylesheet" href="../Styles/Reset.css" type="text/css" media="screen" />
    <link rel="stylesheet" href="../Styles/Site.css" type="text/css" media="screen" />
    <ajaxToolkit:ToolkitScriptManager runat="Server" EnableScriptGlobalization="true"
        EnableScriptLocalization="true" ID="ScriptManager1" />
    <uc:OkMessageBox ID="ec" runat="server" />
    <h2>Dbo. Dim Date</h2>
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
                    If GridView (grddbo_DimDate) width is bigger than web-page (or screen) width (for Mobile and Tablet)...
                    1) comment above 2 lines, and
                    2) uncomment following 2 lines
                -------%>
                <%--<div style="width: 100%;">
                <div style="overflow: auto;">--%>
                <%-------------------------------------%>
                <asp:datagrid id="grddbo_DimDate" runat="server" AllowPaging="True" PageSize="5" AutoGenerateColumns="False" AllowSorting="True" DataKeyNames="DateKey" Font-Size="Medium"
                    OnItemCommand="grddbo_DimDate_ItemCommand" OnSortCommand="grddbo_DimDate_SortCommand" OnPageIndexChanged="grddbo_DimDate_PageIndexChanged" >
                    <Columns>
                        <asp:BoundColumn DataField="DateKey" SortExpression="DateKey" HeaderText="Date Key" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right" />
                        <asp:TemplateColumn>
                            <ItemTemplate>
                                <asp:Label runat="server" Width="10px"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:BoundColumn DataField="FullDateAlternateKey" SortExpression="FullDateAlternateKey" HeaderText="Full Date Alternate Key"  DataFormatString="{0:d}" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" />
                        <asp:TemplateColumn>
                            <ItemTemplate>
                                <asp:Label runat="server" Width="10px"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:BoundColumn DataField="DayNumberOfWeek" SortExpression="DayNumberOfWeek" HeaderText="Day Number Of Week" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right" />
                        <asp:TemplateColumn>
                            <ItemTemplate>
                                <asp:Label runat="server" Width="10px"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:BoundColumn DataField="EnglishDayNameOfWeek" SortExpression="EnglishDayNameOfWeek" HeaderText="English Day Name Of Week" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" />
                        <asp:TemplateColumn>
                            <ItemTemplate>
                                <asp:Label runat="server" Width="10px"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:BoundColumn DataField="SpanishDayNameOfWeek" SortExpression="SpanishDayNameOfWeek" HeaderText="Spanish Day Name Of Week" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" />
                        <asp:TemplateColumn>
                            <ItemTemplate>
                                <asp:Label runat="server" Width="10px"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:BoundColumn DataField="FrenchDayNameOfWeek" SortExpression="FrenchDayNameOfWeek" HeaderText="French Day Name Of Week" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" />
                        <asp:TemplateColumn>
                            <ItemTemplate>
                                <asp:Label runat="server" Width="10px"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:BoundColumn DataField="DayNumberOfMonth" SortExpression="DayNumberOfMonth" HeaderText="Day Number Of Month" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right" />
                        <asp:TemplateColumn>
                            <ItemTemplate>
                                <asp:Label runat="server" Width="10px"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:BoundColumn DataField="DayNumberOfYear" SortExpression="DayNumberOfYear" HeaderText="Day Number Of Year" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right" />
                        <asp:TemplateColumn>
                            <ItemTemplate>
                                <asp:Label runat="server" Width="10px"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:BoundColumn DataField="WeekNumberOfYear" SortExpression="WeekNumberOfYear" HeaderText="Week Number Of Year" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right" />
                        <asp:TemplateColumn>
                            <ItemTemplate>
                                <asp:Label runat="server" Width="10px"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:BoundColumn DataField="EnglishMonthName" SortExpression="EnglishMonthName" HeaderText="English Month Name" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" />
                        <asp:TemplateColumn>
                            <ItemTemplate>
                                <asp:Label runat="server" Width="10px"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:BoundColumn DataField="SpanishMonthName" SortExpression="SpanishMonthName" HeaderText="Spanish Month Name" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" />
                        <asp:TemplateColumn>
                            <ItemTemplate>
                                <asp:Label runat="server" Width="10px"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:BoundColumn DataField="FrenchMonthName" SortExpression="FrenchMonthName" HeaderText="French Month Name" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" />
                        <asp:TemplateColumn>
                            <ItemTemplate>
                                <asp:Label runat="server" Width="10px"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:BoundColumn DataField="MonthNumberOfYear" SortExpression="MonthNumberOfYear" HeaderText="Month Number Of Year" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right" />
                        <asp:TemplateColumn>
                            <ItemTemplate>
                                <asp:Label runat="server" Width="10px"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:BoundColumn DataField="CalendarQuarter" SortExpression="CalendarQuarter" HeaderText="Calendar Quarter" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right" />
                        <asp:TemplateColumn>
                            <ItemTemplate>
                                <asp:Label runat="server" Width="10px"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:BoundColumn DataField="CalendarYear" SortExpression="CalendarYear" HeaderText="Calendar Year" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right" />
                        <asp:TemplateColumn>
                            <ItemTemplate>
                                <asp:Label runat="server" Width="10px"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:BoundColumn DataField="CalendarSemester" SortExpression="CalendarSemester" HeaderText="Calendar Semester" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right" />
                        <asp:TemplateColumn>
                            <ItemTemplate>
                                <asp:Label runat="server" Width="10px"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:BoundColumn DataField="FiscalQuarter" SortExpression="FiscalQuarter" HeaderText="Fiscal Quarter" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right" />
                        <asp:TemplateColumn>
                            <ItemTemplate>
                                <asp:Label runat="server" Width="10px"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:BoundColumn DataField="FiscalYear" SortExpression="FiscalYear" HeaderText="Fiscal Year" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right" />
                        <asp:TemplateColumn>
                            <ItemTemplate>
                                <asp:Label runat="server" Width="10px"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:BoundColumn DataField="FiscalSemester" SortExpression="FiscalSemester" HeaderText="Fiscal Semester" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right" />
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
                <input id="htmlHiddenSortExpression" type="hidden" value="DateKey" name="htmlHiddenSortExpression" runat="server" />
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
                Date Key:
            </div>
            <div style="display: inline-block; width: 300px;">
                <asp:textbox id="txtDateKey" width="100px" runat="server" CssClass="input" style="float: left; text-align: right;"></asp:textbox>
                <asp:RequiredFieldValidator id="rfvDateKey" runat="server" ErrorMessage="Required!" Display="Dynamic" ControlToValidate="txtDateKey"></asp:RequiredFieldValidator>
            </div>
        </div>
        <div style="text-align: center;">
            <div style="display: inline-block; width: 100px; text-align: left;">
                Full Date Alternate Key:
            </div>
            <div style="display: inline-block; width: 300px;">
                                     <table>
                                          <tr>
                                               <td>
                <asp:TextBox ID="txtFullDateAlternateKey" width="100px" runat="server" CssClass="input"></asp:TextBox>
                                               </td>
                                               <td>
                <asp:ImageButton runat="Server" ID="ImageFullDateAlternateKey" ImageUrl="/images/Calendar.png" AlternateText="Click to show calendar" CausesValidation="False" /><br />
                <ajaxToolkit:CalendarExtender ID="calendarButtonExtenderFullDateAlternateKey" runat="server" TargetControlID="txtFullDateAlternateKey" PopupButtonID="ImageFullDateAlternateKey" />
                                               </td>
                                          </tr>
                                     </table>
                <asp:RequiredFieldValidator id="rfvFullDateAlternateKey" runat="server" ErrorMessage="Required!" Display="Dynamic" ControlToValidate="txtFullDateAlternateKey"></asp:RequiredFieldValidator>
            </div>
        </div>
        <div style="text-align: center;">
            <div style="display: inline-block; width: 100px; text-align: left;">
                Day Number Of Week:
            </div>
            <div style="display: inline-block; width: 300px;">
                <asp:textbox id="txtDayNumberOfWeek" width="100px" runat="server" CssClass="input" style="float: left; text-align: right;"></asp:textbox>
                <asp:RequiredFieldValidator id="rfvDayNumberOfWeek" runat="server" ErrorMessage="Required!" Display="Dynamic" ControlToValidate="txtDayNumberOfWeek"></asp:RequiredFieldValidator>
            </div>
        </div>
        <div style="text-align: center;">
            <div style="display: inline-block; width: 100px; text-align: left;">
                English Day Name Of Week:
            </div>
            <div style="display: inline-block; width: 300px;">
                <asp:textbox id="txtEnglishDayNameOfWeek" width="300px" runat="server" CssClass="input"></asp:textbox>
                <asp:RequiredFieldValidator id="rfvEnglishDayNameOfWeek" runat="server" ErrorMessage="Required!" Display="Dynamic" ControlToValidate="txtEnglishDayNameOfWeek"></asp:RequiredFieldValidator>
            </div>
        </div>
        <div style="text-align: center;">
            <div style="display: inline-block; width: 100px; text-align: left;">
                Spanish Day Name Of Week:
            </div>
            <div style="display: inline-block; width: 300px;">
                <asp:textbox id="txtSpanishDayNameOfWeek" width="300px" runat="server" CssClass="input"></asp:textbox>
                <asp:RequiredFieldValidator id="rfvSpanishDayNameOfWeek" runat="server" ErrorMessage="Required!" Display="Dynamic" ControlToValidate="txtSpanishDayNameOfWeek"></asp:RequiredFieldValidator>
            </div>
        </div>
        <div style="text-align: center;">
            <div style="display: inline-block; width: 100px; text-align: left;">
                French Day Name Of Week:
            </div>
            <div style="display: inline-block; width: 300px;">
                <asp:textbox id="txtFrenchDayNameOfWeek" width="300px" runat="server" CssClass="input"></asp:textbox>
                <asp:RequiredFieldValidator id="rfvFrenchDayNameOfWeek" runat="server" ErrorMessage="Required!" Display="Dynamic" ControlToValidate="txtFrenchDayNameOfWeek"></asp:RequiredFieldValidator>
            </div>
        </div>
        <div style="text-align: center;">
            <div style="display: inline-block; width: 100px; text-align: left;">
                Day Number Of Month:
            </div>
            <div style="display: inline-block; width: 300px;">
                <asp:textbox id="txtDayNumberOfMonth" width="100px" runat="server" CssClass="input" style="float: left; text-align: right;"></asp:textbox>
                <asp:RequiredFieldValidator id="rfvDayNumberOfMonth" runat="server" ErrorMessage="Required!" Display="Dynamic" ControlToValidate="txtDayNumberOfMonth"></asp:RequiredFieldValidator>
            </div>
        </div>
        <div style="text-align: center;">
            <div style="display: inline-block; width: 100px; text-align: left;">
                Day Number Of Year:
            </div>
            <div style="display: inline-block; width: 300px;">
                <asp:textbox id="txtDayNumberOfYear" width="100px" runat="server" CssClass="input" style="float: left; text-align: right;"></asp:textbox>
                <asp:RequiredFieldValidator id="rfvDayNumberOfYear" runat="server" ErrorMessage="Required!" Display="Dynamic" ControlToValidate="txtDayNumberOfYear"></asp:RequiredFieldValidator>
            </div>
        </div>
        <div style="text-align: center;">
            <div style="display: inline-block; width: 100px; text-align: left;">
                Week Number Of Year:
            </div>
            <div style="display: inline-block; width: 300px;">
                <asp:textbox id="txtWeekNumberOfYear" width="100px" runat="server" CssClass="input" style="float: left; text-align: right;"></asp:textbox>
                <asp:RequiredFieldValidator id="rfvWeekNumberOfYear" runat="server" ErrorMessage="Required!" Display="Dynamic" ControlToValidate="txtWeekNumberOfYear"></asp:RequiredFieldValidator>
            </div>
        </div>
        <div style="text-align: center;">
            <div style="display: inline-block; width: 100px; text-align: left;">
                English Month Name:
            </div>
            <div style="display: inline-block; width: 300px;">
                <asp:textbox id="txtEnglishMonthName" width="300px" runat="server" CssClass="input"></asp:textbox>
                <asp:RequiredFieldValidator id="rfvEnglishMonthName" runat="server" ErrorMessage="Required!" Display="Dynamic" ControlToValidate="txtEnglishMonthName"></asp:RequiredFieldValidator>
            </div>
        </div>
        <div style="text-align: center;">
            <div style="display: inline-block; width: 100px; text-align: left;">
                Spanish Month Name:
            </div>
            <div style="display: inline-block; width: 300px;">
                <asp:textbox id="txtSpanishMonthName" width="300px" runat="server" CssClass="input"></asp:textbox>
                <asp:RequiredFieldValidator id="rfvSpanishMonthName" runat="server" ErrorMessage="Required!" Display="Dynamic" ControlToValidate="txtSpanishMonthName"></asp:RequiredFieldValidator>
            </div>
        </div>
        <div style="text-align: center;">
            <div style="display: inline-block; width: 100px; text-align: left;">
                French Month Name:
            </div>
            <div style="display: inline-block; width: 300px;">
                <asp:textbox id="txtFrenchMonthName" width="300px" runat="server" CssClass="input"></asp:textbox>
                <asp:RequiredFieldValidator id="rfvFrenchMonthName" runat="server" ErrorMessage="Required!" Display="Dynamic" ControlToValidate="txtFrenchMonthName"></asp:RequiredFieldValidator>
            </div>
        </div>
        <div style="text-align: center;">
            <div style="display: inline-block; width: 100px; text-align: left;">
                Month Number Of Year:
            </div>
            <div style="display: inline-block; width: 300px;">
                <asp:textbox id="txtMonthNumberOfYear" width="100px" runat="server" CssClass="input" style="float: left; text-align: right;"></asp:textbox>
                <asp:RequiredFieldValidator id="rfvMonthNumberOfYear" runat="server" ErrorMessage="Required!" Display="Dynamic" ControlToValidate="txtMonthNumberOfYear"></asp:RequiredFieldValidator>
            </div>
        </div>
        <div style="text-align: center;">
            <div style="display: inline-block; width: 100px; text-align: left;">
                Calendar Quarter:
            </div>
            <div style="display: inline-block; width: 300px;">
                <asp:textbox id="txtCalendarQuarter" width="100px" runat="server" CssClass="input" style="float: left; text-align: right;"></asp:textbox>
                <asp:RequiredFieldValidator id="rfvCalendarQuarter" runat="server" ErrorMessage="Required!" Display="Dynamic" ControlToValidate="txtCalendarQuarter"></asp:RequiredFieldValidator>
            </div>
        </div>
        <div style="text-align: center;">
            <div style="display: inline-block; width: 100px; text-align: left;">
                Calendar Year:
            </div>
            <div style="display: inline-block; width: 300px;">
                <asp:textbox id="txtCalendarYear" width="100px" runat="server" CssClass="input" style="float: left; text-align: right;"></asp:textbox>
                <asp:RequiredFieldValidator id="rfvCalendarYear" runat="server" ErrorMessage="Required!" Display="Dynamic" ControlToValidate="txtCalendarYear"></asp:RequiredFieldValidator>
            </div>
        </div>
        <div style="text-align: center;">
            <div style="display: inline-block; width: 100px; text-align: left;">
                Calendar Semester:
            </div>
            <div style="display: inline-block; width: 300px;">
                <asp:textbox id="txtCalendarSemester" width="100px" runat="server" CssClass="input" style="float: left; text-align: right;"></asp:textbox>
                <asp:RequiredFieldValidator id="rfvCalendarSemester" runat="server" ErrorMessage="Required!" Display="Dynamic" ControlToValidate="txtCalendarSemester"></asp:RequiredFieldValidator>
            </div>
        </div>
        <div style="text-align: center;">
            <div style="display: inline-block; width: 100px; text-align: left;">
                Fiscal Quarter:
            </div>
            <div style="display: inline-block; width: 300px;">
                <asp:textbox id="txtFiscalQuarter" width="100px" runat="server" CssClass="input" style="float: left; text-align: right;"></asp:textbox>
                <asp:RequiredFieldValidator id="rfvFiscalQuarter" runat="server" ErrorMessage="Required!" Display="Dynamic" ControlToValidate="txtFiscalQuarter"></asp:RequiredFieldValidator>
            </div>
        </div>
        <div style="text-align: center;">
            <div style="display: inline-block; width: 100px; text-align: left;">
                Fiscal Year:
            </div>
            <div style="display: inline-block; width: 300px;">
                <asp:textbox id="txtFiscalYear" width="100px" runat="server" CssClass="input" style="float: left; text-align: right;"></asp:textbox>
                <asp:RequiredFieldValidator id="rfvFiscalYear" runat="server" ErrorMessage="Required!" Display="Dynamic" ControlToValidate="txtFiscalYear"></asp:RequiredFieldValidator>
            </div>
        </div>
        <div style="text-align: center;">
            <div style="display: inline-block; width: 100px; text-align: left;">
                Fiscal Semester:
            </div>
            <div style="display: inline-block; width: 300px;">
                <asp:textbox id="txtFiscalSemester" width="100px" runat="server" CssClass="input" style="float: left; text-align: right;"></asp:textbox>
                <asp:RequiredFieldValidator id="rfvFiscalSemester" runat="server" ErrorMessage="Required!" Display="Dynamic" ControlToValidate="txtFiscalSemester"></asp:RequiredFieldValidator>
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
 
