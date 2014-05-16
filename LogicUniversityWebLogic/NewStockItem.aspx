<%@ Page Title="" Language="C#" MasterPageFile="~/Store.Master" AutoEventWireup="true" CodeBehind="NewStockItem.aspx.cs" Inherits="LogicUniversityWebLogic.NewStockItem" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<link href="Styles/btnStyle.css"  rel="Stylesheet"/>
 <style type="text/css">
        .style1
        {
            width: 600px;
        }
        .style2
        {
            width: 154px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

 <table class="style1" cellpadding="5px" cellspacing="10px">
        <tr>
            <td colspan="4">
                <h3>Maintain Stock Item Information</h3></td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblItemNo" runat="server" Text="Item No"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtItemNo" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvItemCode" runat="server" 
                    ControlToValidate="txtItemNo" 
                    ErrorMessage="Item Code must  start with one Character and  3 digit." 
                    ForeColor="Red">*</asp:RequiredFieldValidator>
            </td>
            <td>
                <asp:Label ID="lblReorder" runat="server" Text="Reorder Level"></asp:Label>
            </td>
            <td class="style2">
                <asp:TextBox ID="txtReorderLevel" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvReorder" runat="server" 
                    ControlToValidate="txtReorderLevel" ErrorMessage="Enter reorder quantity." 
                    ForeColor="Red">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblCategory" runat="server" Text="Category Name"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtCategory" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvCategoryName" runat="server" 
                    ControlToValidate="txtCategory" ErrorMessage="Enter Category Name." 
                    ForeColor="Red">*</asp:RequiredFieldValidator>
            </td>
            <td>
                <asp:Label ID="lblReorderQty" runat="server" Text="Reorder Quantity"></asp:Label>
            </td>
            <td class="style2">
                <asp:TextBox ID="txtReorderQty" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvReorderQty" runat="server" 
                    ControlToValidate="txtReorderQty" ErrorMessage="Enter Reorder Quantity." 
                    ForeColor="Red">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblDesc" runat="server" Text="Description"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtDesc" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvDesc" runat="server" 
                    ControlToValidate="txtDesc" ErrorMessage="Enter Category Description." 
                    ForeColor="Red">*</asp:RequiredFieldValidator>
            </td>
            <td>
                <asp:Label ID="lblUnit" runat="server" Text="Unit of Measure"></asp:Label>
            </td>
            <td class="style2">
                <asp:DropDownList ID="ddlUnit" runat="server">
                    <asp:ListItem>Box</asp:ListItem>
                    <asp:ListItem>Dozen</asp:ListItem>
                    <asp:ListItem>Each</asp:ListItem>
                    <asp:ListItem>Packet</asp:ListItem>
                    <asp:ListItem>Set</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblQty" runat="server" Text="Quantity"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtQuantity" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvQty" runat="server" 
                    ControlToValidate="txtQuantity" ErrorMessage="Must enter quantity." 
                    ForeColor="Red">*</asp:RequiredFieldValidator>
            </td>
            <td colspan="2">
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="2" align="left">
                &nbsp;</td>
            <td colspan="2" align="left">
                <asp:ValidationSummary ID="vldSummary" runat="server" ForeColor="Red" />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Button ID="btnSave" runat="server" Text="Save" onclick="btnSave_Click" CssClass="button"/>
            </td>
            <td>
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="button"/>
            </td>
            <td class="style2">
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:HyperLink ID="hpkBack" runat="server" 
                    NavigateUrl="~/MaintainStockItem.aspx">Back</asp:HyperLink>
            </td>
            <td colspan="2">
                <asp:Label ID="lblmsg" runat="server"></asp:Label>
            </td>
        </tr>
    </table>


</asp:Content>
