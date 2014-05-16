<%@ Page Title="" Language="C#" MasterPageFile="~/Department_Master.Master" AutoEventWireup="true" CodeBehind="ViewDepartmentInfo.aspx.cs" Inherits="MobilePresentationLogic.ViewDepartmentInfo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
 <style type="text/css">
        .style1
        {
            width: 68%;
        }
        .style2
        {
            width: 300px;
        }
        .style3
        {
            width: 399px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div>
    <h3 align="center"> Department Information</h3>
        <table class="style1">
            <tr>
                <td class="style2">
                    &nbsp;</td>
                <td class="style3">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style2">
                    &nbsp;</td>
                <td class="style3">
                    <asp:Button ID="btnAddDept" runat="server" Text="Add Department" 
                        onclick="btnAddDept_Click" Height="28px" />
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style2">
                    &nbsp;</td>
                <td class="style3">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
    
    </div>
    <asp:GridView ID="gvDeptList" runat="server" AutoGenerateColumns="False" 
        DataKeyNames="Department_Code" DataSourceID="ObjectDataSource1" 
        onselectedindexchanged="gvDeptList_SelectedIndexChanged" Width="610px">
        <Columns>
            <asp:BoundField DataField="Department_Code" HeaderText="Department Code" 
                SortExpression="Department_Code" />
            <asp:BoundField DataField="Department_Name" HeaderText="Department Name" 
                SortExpression="Department_Name" />
            <asp:BoundField DataField="Phone" HeaderText="Phone No" 
                SortExpression="Phone" />
            <asp:ButtonField CommandName="Select" HeaderText="Details" ShowHeader="True" 
                Text="Detail" />
        </Columns>
    </asp:GridView>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
        SelectMethod="GetAllDepartment" TypeName="BizLogic.DepartmentBLL">
    </asp:ObjectDataSource>

</asp:Content>
