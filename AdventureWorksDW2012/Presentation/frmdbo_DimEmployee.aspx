<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Page Title="dbo_DimEmployee" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="frmdbo_DimEmployee.aspx.cs" Inherits="AdventureWorksDW2012.frmdbo_DimEmployee" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <link rel="stylesheet" href="../Styles/Reset.css" type="text/css" media="screen" />
    <link rel="stylesheet" href="../Styles/Site.css" type="text/css" media="screen" />
    <ajaxToolkit:ToolkitScriptManager runat="Server" EnableScriptGlobalization="true"
        EnableScriptLocalization="true" ID="ScriptManager1" />
    <uc:OkMessageBox ID="ec" runat="server" />
    <h2>Dbo. Dim Employee</h2>
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
                    If GridView (grddbo_DimEmployee) width is bigger than web-page (or screen) width (for Mobile and Tablet)...
                    1) comment above 2 lines, and
                    2) uncomment following 2 lines
                -------%>
                <%--<div style="width: 100%;">
                <div style="overflow: auto;">--%>
                <%-------------------------------------%>
                <asp:datagrid id="grddbo_DimEmployee" runat="server" AllowPaging="True" PageSize="5" AutoGenerateColumns="False" AllowSorting="True" DataKeyNames="EmployeeKey" Font-Size="Medium"
                    OnItemCommand="grddbo_DimEmployee_ItemCommand" OnSortCommand="grddbo_DimEmployee_SortCommand" OnPageIndexChanged="grddbo_DimEmployee_PageIndexChanged" >
                    <Columns>
                        <asp:BoundColumn DataField="EmployeeKey" SortExpression="EmployeeKey" HeaderText="Employee Key" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right" />
                        <asp:TemplateColumn>
                            <ItemTemplate>
                                <asp:Label runat="server" Width="10px"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:BoundColumn DataField="FirstName" SortExpression="FirstName" HeaderText="Parent Employee Key" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" />
                        <asp:TemplateColumn>
                            <ItemTemplate>
                                <asp:Label runat="server" Width="10px"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:BoundColumn DataField="EmployeeNationalIDAlternateKey" SortExpression="EmployeeNationalIDAlternateKey" HeaderText="Employee National I D Alternate Key" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" />
                        <asp:TemplateColumn>
                            <ItemTemplate>
                                <asp:Label runat="server" Width="10px"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:BoundColumn DataField="ParentEmployeeNationalIDAlternateKey" SortExpression="ParentEmployeeNationalIDAlternateKey" HeaderText="Parent Employee National I D Alternate Key" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" />
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
                        <asp:BoundColumn DataField="FirstName" SortExpression="FirstName" HeaderText="First Name" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" />
                        <asp:TemplateColumn>
                            <ItemTemplate>
                                <asp:Label runat="server" Width="10px"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:BoundColumn DataField="LastName" SortExpression="LastName" HeaderText="Last Name" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" />
                        <asp:TemplateColumn>
                            <ItemTemplate>
                                <asp:Label runat="server" Width="10px"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:BoundColumn DataField="MiddleName" SortExpression="MiddleName" HeaderText="Middle Name" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" />
                        <asp:TemplateColumn>
                            <ItemTemplate>
                                <asp:Label runat="server" Width="10px"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:BoundColumn DataField="NameStyle" SortExpression="NameStyle" HeaderText="Name Style" />
                        <asp:TemplateColumn>
                            <ItemTemplate>
                                <asp:Label runat="server" Width="10px"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:BoundColumn DataField="Title" SortExpression="Title" HeaderText="Title" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" />
                        <asp:TemplateColumn>
                            <ItemTemplate>
                                <asp:Label runat="server" Width="10px"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:BoundColumn DataField="HireDate" SortExpression="HireDate" HeaderText="Hire Date"  DataFormatString="{0:d}" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" />
                        <asp:TemplateColumn>
                            <ItemTemplate>
                                <asp:Label runat="server" Width="10px"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:BoundColumn DataField="BirthDate" SortExpression="BirthDate" HeaderText="Birth Date"  DataFormatString="{0:d}" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" />
                        <asp:TemplateColumn>
                            <ItemTemplate>
                                <asp:Label runat="server" Width="10px"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:BoundColumn DataField="LoginID" SortExpression="LoginID" HeaderText="Login I D" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" />
                        <asp:TemplateColumn>
                            <ItemTemplate>
                                <asp:Label runat="server" Width="10px"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:BoundColumn DataField="EmailAddress" SortExpression="EmailAddress" HeaderText="Email Address" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" />
                        <asp:TemplateColumn>
                            <ItemTemplate>
                                <asp:Label runat="server" Width="10px"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:BoundColumn DataField="Phone" SortExpression="Phone" HeaderText="Phone" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" />
                        <asp:TemplateColumn>
                            <ItemTemplate>
                                <asp:Label runat="server" Width="10px"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:BoundColumn DataField="MaritalStatus" SortExpression="MaritalStatus" HeaderText="Marital Status" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" />
                        <asp:TemplateColumn>
                            <ItemTemplate>
                                <asp:Label runat="server" Width="10px"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:BoundColumn DataField="EmergencyContactName" SortExpression="EmergencyContactName" HeaderText="Emergency Contact Name" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" />
                        <asp:TemplateColumn>
                            <ItemTemplate>
                                <asp:Label runat="server" Width="10px"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:BoundColumn DataField="EmergencyContactPhone" SortExpression="EmergencyContactPhone" HeaderText="Emergency Contact Phone" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" />
                        <asp:TemplateColumn>
                            <ItemTemplate>
                                <asp:Label runat="server" Width="10px"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:BoundColumn DataField="SalariedFlag" SortExpression="SalariedFlag" HeaderText="Salaried Flag" />
                        <asp:TemplateColumn>
                            <ItemTemplate>
                                <asp:Label runat="server" Width="10px"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:BoundColumn DataField="Gender" SortExpression="Gender" HeaderText="Gender" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" />
                        <asp:TemplateColumn>
                            <ItemTemplate>
                                <asp:Label runat="server" Width="10px"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:BoundColumn DataField="PayFrequency" SortExpression="PayFrequency" HeaderText="Pay Frequency" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right" />
                        <asp:TemplateColumn>
                            <ItemTemplate>
                                <asp:Label runat="server" Width="10px"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:BoundColumn DataField="BaseRate" SortExpression="BaseRate" HeaderText="Base Rate"  DataFormatString="{0:C}" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right" />
                        <asp:TemplateColumn>
                            <ItemTemplate>
                                <asp:Label runat="server" Width="10px"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:BoundColumn DataField="VacationHours" SortExpression="VacationHours" HeaderText="Vacation Hours" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right" />
                        <asp:TemplateColumn>
                            <ItemTemplate>
                                <asp:Label runat="server" Width="10px"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:BoundColumn DataField="SickLeaveHours" SortExpression="SickLeaveHours" HeaderText="Sick Leave Hours" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right" />
                        <asp:TemplateColumn>
                            <ItemTemplate>
                                <asp:Label runat="server" Width="10px"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:BoundColumn DataField="CurrentFlag" SortExpression="CurrentFlag" HeaderText="Current Flag" />
                        <asp:TemplateColumn>
                            <ItemTemplate>
                                <asp:Label runat="server" Width="10px"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:BoundColumn DataField="SalesPersonFlag" SortExpression="SalesPersonFlag" HeaderText="Sales Person Flag" />
                        <asp:TemplateColumn>
                            <ItemTemplate>
                                <asp:Label runat="server" Width="10px"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:BoundColumn DataField="DepartmentName" SortExpression="DepartmentName" HeaderText="Department Name" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" />
                        <asp:TemplateColumn>
                            <ItemTemplate>
                                <asp:Label runat="server" Width="10px"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:BoundColumn DataField="StartDate" SortExpression="StartDate" HeaderText="Start Date"  DataFormatString="{0:d}" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" />
                        <asp:TemplateColumn>
                            <ItemTemplate>
                                <asp:Label runat="server" Width="10px"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:BoundColumn DataField="EndDate" SortExpression="EndDate" HeaderText="End Date"  DataFormatString="{0:d}" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" />
                        <asp:TemplateColumn>
                            <ItemTemplate>
                                <asp:Label runat="server" Width="10px"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:BoundColumn DataField="Status" SortExpression="Status" HeaderText="Status" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" />
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
                <input id="htmlHiddenSortExpression" type="hidden" value="EmployeeKey" name="htmlHiddenSortExpression" runat="server" />
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
                Employee Key:
            </div>
            <div style="display: inline-block; width: 300px;">
                <asp:textbox id="txtEmployeeKey" width="100px" runat="server" CssClass="input" style="float: left; text-align: right;"></asp:textbox>
                <asp:RequiredFieldValidator id="rfvEmployeeKey" runat="server" ErrorMessage="Required!" Display="Dynamic" ControlToValidate="txtEmployeeKey"></asp:RequiredFieldValidator>
            </div>
        </div>
        <div style="text-align: center;">
            <div style="display: inline-block; width: 100px; text-align: left;">
                Parent Employee Key:
            </div>
            <div style="display: inline-block; width: 300px;">
                <asp:DropDownList id="txtParentEmployeeKey" width="300px" runat="server" CssClass="input"></asp:DropDownList>
            </div>
        </div>
        <div style="text-align: center;">
            <div style="display: inline-block; width: 100px; text-align: left;">
                Employee National I D Alternate Key:
            </div>
            <div style="display: inline-block; width: 300px;">
                <asp:textbox id="txtEmployeeNationalIDAlternateKey" width="300px" runat="server" CssClass="input"></asp:textbox>
            </div>
        </div>
        <div style="text-align: center;">
            <div style="display: inline-block; width: 100px; text-align: left;">
                Parent Employee National I D Alternate Key:
            </div>
            <div style="display: inline-block; width: 300px;">
                <asp:textbox id="txtParentEmployeeNationalIDAlternateKey" width="300px" runat="server" CssClass="input"></asp:textbox>
            </div>
        </div>
        <div style="text-align: center;">
            <div style="display: inline-block; width: 100px; text-align: left;">
                Sales Territory Key:
            </div>
            <div style="display: inline-block; width: 300px;">
                <asp:DropDownList id="txtSalesTerritoryKey" width="300px" runat="server" CssClass="input"></asp:DropDownList>
            </div>
        </div>
        <div style="text-align: center;">
            <div style="display: inline-block; width: 100px; text-align: left;">
                First Name:
            </div>
            <div style="display: inline-block; width: 300px;">
                <asp:textbox id="txtFirstName" width="300px" runat="server" CssClass="input"></asp:textbox>
                <asp:RequiredFieldValidator id="rfvFirstName" runat="server" ErrorMessage="Required!" Display="Dynamic" ControlToValidate="txtFirstName"></asp:RequiredFieldValidator>
            </div>
        </div>
        <div style="text-align: center;">
            <div style="display: inline-block; width: 100px; text-align: left;">
                Last Name:
            </div>
            <div style="display: inline-block; width: 300px;">
                <asp:textbox id="txtLastName" width="300px" runat="server" CssClass="input"></asp:textbox>
                <asp:RequiredFieldValidator id="rfvLastName" runat="server" ErrorMessage="Required!" Display="Dynamic" ControlToValidate="txtLastName"></asp:RequiredFieldValidator>
            </div>
        </div>
        <div style="text-align: center;">
            <div style="display: inline-block; width: 100px; text-align: left;">
                Middle Name:
            </div>
            <div style="display: inline-block; width: 300px;">
                <asp:textbox id="txtMiddleName" width="300px" runat="server" CssClass="input"></asp:textbox>
            </div>
        </div>
        <div style="text-align: center;">
            <div style="display: inline-block; width: 100px; text-align: left;">
                Name Style:
            </div>
            <div style="display: inline-block; width: 300px;">
                <asp:checkbox id="txtNameStyle" width="100px" runat="server" CssClass="CheckBox" style="float: left;"></asp:checkbox>
            </div>
        </div>
        <div style="text-align: center;">
            <div style="display: inline-block; width: 100px; text-align: left;">
                Title:
            </div>
            <div style="display: inline-block; width: 300px;">
                <asp:textbox id="txtTitle" width="300px" runat="server" CssClass="input"></asp:textbox>
            </div>
        </div>
        <div style="text-align: center;">
            <div style="display: inline-block; width: 100px; text-align: left;">
                Hire Date:
            </div>
            <div style="display: inline-block; width: 300px;">
                                     <table>
                                          <tr>
                                               <td>
                <asp:TextBox ID="txtHireDate" width="100px" runat="server" CssClass="input"></asp:TextBox>
                                               </td>
                                               <td>
                <asp:ImageButton runat="Server" ID="ImageHireDate" ImageUrl="/images/Calendar.png" AlternateText="Click to show calendar" CausesValidation="False" /><br />
                <ajaxToolkit:CalendarExtender ID="calendarButtonExtenderHireDate" runat="server" TargetControlID="txtHireDate" PopupButtonID="ImageHireDate" />
                                               </td>
                                          </tr>
                                     </table>
            </div>
        </div>
        <div style="text-align: center;">
            <div style="display: inline-block; width: 100px; text-align: left;">
                Birth Date:
            </div>
            <div style="display: inline-block; width: 300px;">
                                     <table>
                                          <tr>
                                               <td>
                <asp:TextBox ID="txtBirthDate" width="100px" runat="server" CssClass="input"></asp:TextBox>
                                               </td>
                                               <td>
                <asp:ImageButton runat="Server" ID="ImageBirthDate" ImageUrl="/images/Calendar.png" AlternateText="Click to show calendar" CausesValidation="False" /><br />
                <ajaxToolkit:CalendarExtender ID="calendarButtonExtenderBirthDate" runat="server" TargetControlID="txtBirthDate" PopupButtonID="ImageBirthDate" />
                                               </td>
                                          </tr>
                                     </table>
            </div>
        </div>
        <div style="text-align: center;">
            <div style="display: inline-block; width: 100px; text-align: left;">
                Login I D:
            </div>
            <div style="display: inline-block; width: 300px;">
                <asp:textbox id="txtLoginID" width="300px" runat="server" CssClass="input"></asp:textbox>
            </div>
        </div>
        <div style="text-align: center;">
            <div style="display: inline-block; width: 100px; text-align: left;">
                Email Address:
            </div>
            <div style="display: inline-block; width: 300px;">
                <asp:textbox id="txtEmailAddress" width="300px" runat="server" CssClass="input"></asp:textbox>
            </div>
        </div>
        <div style="text-align: center;">
            <div style="display: inline-block; width: 100px; text-align: left;">
                Phone:
            </div>
            <div style="display: inline-block; width: 300px;">
                <asp:textbox id="txtPhone" width="300px" runat="server" CssClass="input"></asp:textbox>
            </div>
        </div>
        <div style="text-align: center;">
            <div style="display: inline-block; width: 100px; text-align: left;">
                Marital Status:
            </div>
            <div style="display: inline-block; width: 300px;">
                <asp:textbox id="txtMaritalStatus" width="300px" runat="server" CssClass="input"></asp:textbox>
            </div>
        </div>
        <div style="text-align: center;">
            <div style="display: inline-block; width: 100px; text-align: left;">
                Emergency Contact Name:
            </div>
            <div style="display: inline-block; width: 300px;">
                <asp:textbox id="txtEmergencyContactName" width="300px" runat="server" CssClass="input"></asp:textbox>
            </div>
        </div>
        <div style="text-align: center;">
            <div style="display: inline-block; width: 100px; text-align: left;">
                Emergency Contact Phone:
            </div>
            <div style="display: inline-block; width: 300px;">
                <asp:textbox id="txtEmergencyContactPhone" width="300px" runat="server" CssClass="input"></asp:textbox>
            </div>
        </div>
        <div style="text-align: center;">
            <div style="display: inline-block; width: 100px; text-align: left;">
                Salaried Flag:
            </div>
            <div style="display: inline-block; width: 300px;">
                <asp:checkbox id="txtSalariedFlag" width="100px" runat="server" CssClass="CheckBox" style="float: left;"></asp:checkbox>
            </div>
        </div>
        <div style="text-align: center;">
            <div style="display: inline-block; width: 100px; text-align: left;">
                Gender:
            </div>
            <div style="display: inline-block; width: 300px;">
                <asp:textbox id="txtGender" width="300px" runat="server" CssClass="input"></asp:textbox>
            </div>
        </div>
        <div style="text-align: center;">
            <div style="display: inline-block; width: 100px; text-align: left;">
                Pay Frequency:
            </div>
            <div style="display: inline-block; width: 300px;">
                <asp:textbox id="txtPayFrequency" width="100px" runat="server" CssClass="input" style="float: left; text-align: right;"></asp:textbox>
            </div>
        </div>
        <div style="text-align: center;">
            <div style="display: inline-block; width: 100px; text-align: left;">
                Base Rate:
            </div>
            <div style="display: inline-block; width: 300px;">
                <asp:textbox id="txtBaseRate" width="100px" runat="server" CssClass="input" style="float: left; text-align: right;"></asp:textbox>
            </div>
        </div>
        <div style="text-align: center;">
            <div style="display: inline-block; width: 100px; text-align: left;">
                Vacation Hours:
            </div>
            <div style="display: inline-block; width: 300px;">
                <asp:textbox id="txtVacationHours" width="100px" runat="server" CssClass="input" style="float: left; text-align: right;"></asp:textbox>
            </div>
        </div>
        <div style="text-align: center;">
            <div style="display: inline-block; width: 100px; text-align: left;">
                Sick Leave Hours:
            </div>
            <div style="display: inline-block; width: 300px;">
                <asp:textbox id="txtSickLeaveHours" width="100px" runat="server" CssClass="input" style="float: left; text-align: right;"></asp:textbox>
            </div>
        </div>
        <div style="text-align: center;">
            <div style="display: inline-block; width: 100px; text-align: left;">
                Current Flag:
            </div>
            <div style="display: inline-block; width: 300px;">
                <asp:checkbox id="txtCurrentFlag" width="100px" runat="server" CssClass="CheckBox" style="float: left;"></asp:checkbox>
            </div>
        </div>
        <div style="text-align: center;">
            <div style="display: inline-block; width: 100px; text-align: left;">
                Sales Person Flag:
            </div>
            <div style="display: inline-block; width: 300px;">
                <asp:checkbox id="txtSalesPersonFlag" width="100px" runat="server" CssClass="CheckBox" style="float: left;"></asp:checkbox>
            </div>
        </div>
        <div style="text-align: center;">
            <div style="display: inline-block; width: 100px; text-align: left;">
                Department Name:
            </div>
            <div style="display: inline-block; width: 300px;">
                <asp:textbox id="txtDepartmentName" width="300px" runat="server" CssClass="input"></asp:textbox>
            </div>
        </div>
        <div style="text-align: center;">
            <div style="display: inline-block; width: 100px; text-align: left;">
                Start Date:
            </div>
            <div style="display: inline-block; width: 300px;">
                                     <table>
                                          <tr>
                                               <td>
                <asp:TextBox ID="txtStartDate" width="100px" runat="server" CssClass="input"></asp:TextBox>
                                               </td>
                                               <td>
                <asp:ImageButton runat="Server" ID="ImageStartDate" ImageUrl="/images/Calendar.png" AlternateText="Click to show calendar" CausesValidation="False" /><br />
                <ajaxToolkit:CalendarExtender ID="calendarButtonExtenderStartDate" runat="server" TargetControlID="txtStartDate" PopupButtonID="ImageStartDate" />
                                               </td>
                                          </tr>
                                     </table>
            </div>
        </div>
        <div style="text-align: center;">
            <div style="display: inline-block; width: 100px; text-align: left;">
                End Date:
            </div>
            <div style="display: inline-block; width: 300px;">
                                     <table>
                                          <tr>
                                               <td>
                <asp:TextBox ID="txtEndDate" width="100px" runat="server" CssClass="input"></asp:TextBox>
                                               </td>
                                               <td>
                <asp:ImageButton runat="Server" ID="ImageEndDate" ImageUrl="/images/Calendar.png" AlternateText="Click to show calendar" CausesValidation="False" /><br />
                <ajaxToolkit:CalendarExtender ID="calendarButtonExtenderEndDate" runat="server" TargetControlID="txtEndDate" PopupButtonID="ImageEndDate" />
                                               </td>
                                          </tr>
                                     </table>
            </div>
        </div>
        <div style="text-align: center;">
            <div style="display: inline-block; width: 100px; text-align: left;">
                Status:
            </div>
            <div style="display: inline-block; width: 300px;">
                <asp:textbox id="txtStatus" width="300px" runat="server" CssClass="input"></asp:textbox>
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
 
