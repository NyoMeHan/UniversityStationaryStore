<%@ Page Title="" Language="C#" MasterPageFile="~/Store_Master.Master" AutoEventWireup="true" CodeBehind="UpdateStockItem.aspx.cs" Inherits="MobilePresentationLogic.UpdateStockItem" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <style type="text/css">
        .style1
        {
            height: 24px;
        }
        .style2
        {
            width: 108%;
        }
        .style3
        {
            height: 24px;
            width: 108%;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<table class="style1" cellpadding="5px" cellspacing="10px">
        <tr>
            <td colspan="4">
                <h3 align="center">Update Stock Item Information</h3></td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblItemNo" runat="server" Text="Item No"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblItemCode" runat="server"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblReorder" runat="server" Text="Reorder Level"></asp:Label>
            </td>
            <td class="style2">
                <asp:TextBox ID="txtReorder" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblCategoryID" runat="server" Text="Category ID"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtCategory" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:Label ID="lblReorderQty" runat="server" Text="Reorder Quantity"></asp:Label>
            </td>
            <td class="style2">
                <asp:TextBox ID="txtReorderQty" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblDesc" runat="server" Text="Description"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtDesc" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:Label ID="lblUnit" runat="server" Text="Unit of Measure"></asp:Label>
            </td>
            <td class="style2">
                <asp:TextBox ID="txtUnit" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="2" class="style1">
            </td>
            <td class="style1">
                <asp:Label ID="lblQty" runat="server" Text="Quantity"></asp:Label>
            </td>
            <td class="style3">
                <asp:TextBox ID="txtQuantity" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Button ID="btnUpdate" runat="server" onclick="btnUpdate_Click" 
                    Text="Update" Height="34px" Width="81px" />
            </td>
            <td colspan="2">
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" 
                    onclick="btnCancel_Click" Height="30px" Width="82px" />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:HyperLink ID="hlkBack" runat="server" 
                    NavigateUrl="~/MaintainStockItem.aspx">Back</asp:HyperLink>
            </td>
            <td colspan="2">
                <asp:Label ID="lblmsg" runat="server"></asp:Label>
            </td>
        </tr>
    </table>

</asp:Content>
