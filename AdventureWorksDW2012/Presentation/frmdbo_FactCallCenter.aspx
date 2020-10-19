<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Page Title="dbo_FactCallCenter" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="frmdbo_FactCallCenter.aspx.cs" Inherits="AdventureWorksDW2012.frmdbo_FactCallCenter" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <link rel="stylesheet" href="../Styles/Reset.css" type="text/css" media="screen" />
    <link rel="stylesheet" href="../Styles/Site.css" type="text/css" media="screen" />
    <ajaxToolkit:ToolkitScriptManager runat="Server" EnableScriptGlobalization="true"
        EnableScriptLocalization="true" ID="ScriptManager1" />
    <uc:OkMessageBox ID="ec" runat="server" />
    <h2>Dbo. Fact Call Center</h2>
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
                    If GridView (grddbo_FactCallCenter) width is bigger than web-page (or screen) width (for Mobile and Tablet)...
                    1) comment above 2 lines, and
                    2) uncomment following 2 lines
                -------%>
                <%--<div style="width: 100%;">
                <div style="overflow: auto;">--%>
                <%-------------------------------------%>
                <asp:datagrid id="grddbo_FactCallCenter" runat="server" AllowPaging="True" PageSize="5" AutoGenerateColumns="False" AllowSorting="True" DataKeyNames="FactCallCenterID" Font-Size="Medium"
                    OnItemCommand="grddbo_FactCallCenter_ItemCommand" OnSortCommand="grddbo_FactCallCenter_SortCommand" OnPageIndexChanged="grddbo_FactCallCenter_PageIndexChanged" >
                    <Columns>
                        <asp:BoundColumn DataField="FactCallCenterID" SortExpression="FactCallCenterID" HeaderText="Fact Call Center I D" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right" />
                        <asp:TemplateColumn>
                            <ItemTemplate>
                                <asp:Label runat="server" Width="10px"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:BoundColumn DataField="FullDateAlternateKey" SortExpression="FullDateAlternateKey" HeaderText="Date Key" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" />
                        <asp:TemplateColumn>
                            <ItemTemplate>
                                <asp:Label runat="server" Width="10px"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:BoundColumn DataField="WageType" SortExpression="WageType" HeaderText="Wage Type" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" />
                        <asp:TemplateColumn>
                            <ItemTemplate>
                                <asp:Label runat="server" Width="10px"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:BoundColumn DataField="Shift" SortExpression="Shift" HeaderText="Shift" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" />
                        <asp:TemplateColumn>
                            <ItemTemplate>
                                <asp:Label runat="server" Width="10px"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:BoundColumn DataField="LevelOneOperators" SortExpression="LevelOneOperators" HeaderText="Level One Operators" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right" />
                        <asp:TemplateColumn>
                            <ItemTemplate>
                                <asp:Label runat="server" Width="10px"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:BoundColumn DataField="LevelTwoOperators" SortExpression="LevelTwoOperators" HeaderText="Level Two Operators" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right" />
                        <asp:TemplateColumn>
                            <ItemTemplate>
                                <asp:Label runat="server" Width="10px"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:BoundColumn DataField="TotalOperators" SortExpression="TotalOperators" HeaderText="Total Operators" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right" />
                        <asp:TemplateColumn>
                            <ItemTemplate>
                                <asp:Label runat="server" Width="10px"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:BoundColumn DataField="Calls" SortExpression="Calls" HeaderText="Calls" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right" />
                        <asp:TemplateColumn>
                            <ItemTemplate>
                                <asp:Label runat="server" Width="10px"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:BoundColumn DataField="AutomaticResponses" SortExpression="AutomaticResponses" HeaderText="Automatic Responses" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right" />
                        <asp:TemplateColumn>
                            <ItemTemplate>
                                <asp:Label runat="server" Width="10px"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:BoundColumn DataField="Orders" SortExpression="Orders" HeaderText="Orders" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right" />
                        <asp:TemplateColumn>
                            <ItemTemplate>
                                <asp:Label runat="server" Width="10px"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:BoundColumn DataField="IssuesRaised" SortExpression="IssuesRaised" HeaderText="Issues Raised" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right" />
                        <asp:TemplateColumn>
                            <ItemTemplate>
                                <asp:Label runat="server" Width="10px"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:BoundColumn DataField="AverageTimePerIssue" SortExpression="AverageTimePerIssue" HeaderText="Average Time Per Issue" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right" />
                        <asp:TemplateColumn>
                            <ItemTemplate>
                                <asp:Label runat="server" Width="10px"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:BoundColumn DataField="ServiceGrade" SortExpression="ServiceGrade" HeaderText="Service Grade" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right" />
                        <asp:TemplateColumn>
                            <ItemTemplate>
                                <asp:Label runat="server" Width="10px"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:BoundColumn DataField="Date" SortExpression="Date" HeaderText="Date"  DataFormatString="{0:d}" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" />
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
                <input id="htmlHiddenSortExpression" type="hidden" value="FactCallCenterID" name="htmlHiddenSortExpression" runat="server" />
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
                Fact Call Center I D:
            </div>
            <div style="display: inline-block; width: 300px;">
                <asp:textbox id="txtFactCallCenterID" width="100px" runat="server" CssClass="input" style="float: left; text-align: right;"></asp:textbox>
                <asp:RequiredFieldValidator id="rfvFactCallCenterID" runat="server" ErrorMessage="Required!" Display="Dynamic" ControlToValidate="txtFactCallCenterID"></asp:RequiredFieldValidator>
            </div>
        </div>
        <div style="text-align: center;">
            <div style="display: inline-block; width: 100px; text-align: left;">
                Date Key:
            </div>
            <div style="display: inline-block; width: 300px;">
                <asp:DropDownList id="txtDateKey" width="300px" runat="server" CssClass="input"></asp:DropDownList>
                <asp:RequiredFieldValidator id="rfvDateKey" runat="server" ErrorMessage="Required!" Display="Dynamic" ControlToValidate="txtDateKey"></asp:RequiredFieldValidator>
            </div>
        </div>
        <div style="text-align: center;">
            <div style="display: inline-block; width: 100px; text-align: left;">
                Wage Type:
            </div>
            <div style="display: inline-block; width: 300px;">
                <asp:textbox id="txtWageType" width="300px" runat="server" CssClass="input"></asp:textbox>
                <asp:RequiredFieldValidator id="rfvWageType" runat="server" ErrorMessage="Required!" Display="Dynamic" ControlToValidate="txtWageType"></asp:RequiredFieldValidator>
            </div>
        </div>
        <div style="text-align: center;">
            <div style="display: inline-block; width: 100px; text-align: left;">
                Shift:
            </div>
            <div style="display: inline-block; width: 300px;">
                <asp:textbox id="txtShift" width="300px" runat="server" CssClass="input"></asp:textbox>
                <asp:RequiredFieldValidator id="rfvShift" runat="server" ErrorMessage="Required!" Display="Dynamic" ControlToValidate="txtShift"></asp:RequiredFieldValidator>
            </div>
        </div>
        <div style="text-align: center;">
            <div style="display: inline-block; width: 100px; text-align: left;">
                Level One Operators:
            </div>
            <div style="display: inline-block; width: 300px;">
                <asp:textbox id="txtLevelOneOperators" width="100px" runat="server" CssClass="input" style="float: left; text-align: right;"></asp:textbox>
                <asp:RequiredFieldValidator id="rfvLevelOneOperators" runat="server" ErrorMessage="Required!" Display="Dynamic" ControlToValidate="txtLevelOneOperators"></asp:RequiredFieldValidator>
            </div>
        </div>
        <div style="text-align: center;">
            <div style="display: inline-block; width: 100px; text-align: left;">
                Level Two Operators:
            </div>
            <div style="display: inline-block; width: 300px;">
                <asp:textbox id="txtLevelTwoOperators" width="100px" runat="server" CssClass="input" style="float: left; text-align: right;"></asp:textbox>
                <asp:RequiredFieldValidator id="rfvLevelTwoOperators" runat="server" ErrorMessage="Required!" Display="Dynamic" ControlToValidate="txtLevelTwoOperators"></asp:RequiredFieldValidator>
            </div>
        </div>
        <div style="text-align: center;">
            <div style="display: inline-block; width: 100px; text-align: left;">
                Total Operators:
            </div>
            <div style="display: inline-block; width: 300px;">
                <asp:textbox id="txtTotalOperators" width="100px" runat="server" CssClass="input" style="float: left; text-align: right;"></asp:textbox>
                <asp:RequiredFieldValidator id="rfvTotalOperators" runat="server" ErrorMessage="Required!" Display="Dynamic" ControlToValidate="txtTotalOperators"></asp:RequiredFieldValidator>
            </div>
        </div>
        <div style="text-align: center;">
            <div style="display: inline-block; width: 100px; text-align: left;">
                Calls:
            </div>
            <div style="display: inline-block; width: 300px;">
                <asp:textbox id="txtCalls" width="100px" runat="server" CssClass="input" style="float: left; text-align: right;"></asp:textbox>
                <asp:RequiredFieldValidator id="rfvCalls" runat="server" ErrorMessage="Required!" Display="Dynamic" ControlToValidate="txtCalls"></asp:RequiredFieldValidator>
            </div>
        </div>
        <div style="text-align: center;">
            <div style="display: inline-block; width: 100px; text-align: left;">
                Automatic Responses:
            </div>
            <div style="display: inline-block; width: 300px;">
                <asp:textbox id="txtAutomaticResponses" width="100px" runat="server" CssClass="input" style="float: left; text-align: right;"></asp:textbox>
                <asp:RequiredFieldValidator id="rfvAutomaticResponses" runat="server" ErrorMessage="Required!" Display="Dynamic" ControlToValidate="txtAutomaticResponses"></asp:RequiredFieldValidator>
            </div>
        </div>
        <div style="text-align: center;">
            <div style="display: inline-block; width: 100px; text-align: left;">
                Orders:
            </div>
            <div style="display: inline-block; width: 300px;">
                <asp:textbox id="txtOrders" width="100px" runat="server" CssClass="input" style="float: left; text-align: right;"></asp:textbox>
                <asp:RequiredFieldValidator id="rfvOrders" runat="server" ErrorMessage="Required!" Display="Dynamic" ControlToValidate="txtOrders"></asp:RequiredFieldValidator>
            </div>
        </div>
        <div style="text-align: center;">
            <div style="display: inline-block; width: 100px; text-align: left;">
                Issues Raised:
            </div>
            <div style="display: inline-block; width: 300px;">
                <asp:textbox id="txtIssuesRaised" width="100px" runat="server" CssClass="input" style="float: left; text-align: right;"></asp:textbox>
                <asp:RequiredFieldValidator id="rfvIssuesRaised" runat="server" ErrorMessage="Required!" Display="Dynamic" ControlToValidate="txtIssuesRaised"></asp:RequiredFieldValidator>
            </div>
        </div>
        <div style="text-align: center;">
            <div style="display: inline-block; width: 100px; text-align: left;">
                Average Time Per Issue:
            </div>
            <div style="display: inline-block; width: 300px;">
                <asp:textbox id="txtAverageTimePerIssue" width="100px" runat="server" CssClass="input" style="float: left; text-align: right;"></asp:textbox>
                <asp:RequiredFieldValidator id="rfvAverageTimePerIssue" runat="server" ErrorMessage="Required!" Display="Dynamic" ControlToValidate="txtAverageTimePerIssue"></asp:RequiredFieldValidator>
            </div>
        </div>
        <div style="text-align: center;">
            <div style="display: inline-block; width: 100px; text-align: left;">
                Service Grade:
            </div>
            <div style="display: inline-block; width: 300px;">
                <asp:textbox id="txtServiceGrade" width="100px" runat="server" CssClass="input" style="float: left; text-align: right;"></asp:textbox>
                <asp:RequiredFieldValidator id="rfvServiceGrade" runat="server" ErrorMessage="Required!" Display="Dynamic" ControlToValidate="txtServiceGrade"></asp:RequiredFieldValidator>
            </div>
        </div>
        <div style="text-align: center;">
            <div style="display: inline-block; width: 100px; text-align: left;">
                Date:
            </div>
            <div style="display: inline-block; width: 300px;">
                                     <table>
                                          <tr>
                                               <td>
                <asp:TextBox ID="txtDate" width="100px" runat="server" CssClass="input"></asp:TextBox>
                                               </td>
                                               <td>
                <asp:ImageButton runat="Server" ID="ImageDate" ImageUrl="/images/Calendar.png" AlternateText="Click to show calendar" CausesValidation="False" /><br />
                <ajaxToolkit:CalendarExtender ID="calendarButtonExtenderDate" runat="server" TargetControlID="txtDate" PopupButtonID="ImageDate" />
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
 
