<%@ Page Title="" Language="C#" MasterPageFile="~/Store.Master" AutoEventWireup="true" CodeBehind="IssueStockAdjustment.aspx.cs" Inherits="LogicUniversityWebLogic.IssueStockAdjustment" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style1
        {
            width: 500px;
            height:350px;
        }
    .style2
    {
        height: 41px;
    }
        .style3
        {
            height: 24px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="style1" align="center">
        <tr>
            <td colspan="3">
               <h3>&nbsp;</h3></td>
        </tr>
        <tr>
            <td class="style2" colspan="3">
                <h3>Report Adjustment Form</h3></td>
        </tr>
        <tr>
            <td class="style2">
                <asp:Label ID="lblCategory" runat="server" Text="Category"></asp:Label>
            </td>
            <td class="style2" colspan="2" align="left">
                <asp:DropDownList ID="ddlCategory" runat="server" DataTextField="Category_Name" 
                    DataValueField="CateogryID" 
                     onselectedindexchanged="ddlCategory_SelectedIndexChanged" AutoPostBack="True"  
                    >
                </asp:DropDownList>
                <asp:Label ID="lblCategoryValue" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblItemName" runat="server" Text="Item Name"></asp:Label>
            </td>
            <td colspan="2" align="left">
                <asp:DropDownList ID="ddlItemName" runat="server" DataTextField="Description" 
                    DataValueField="Item_Code">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblQtyToAdjust" runat="server" Text="QuantityToAdjust"></asp:Label>
            </td>
            <td colspan="2" align="left" class="style3">
                <asp:TextBox ID="txtAdjustQty" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvQty" runat="server" 
                    ControlToValidate="txtAdjustQty" ErrorMessage="Enter Adjust Quantity number." 
                    ForeColor="Red">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblStatus" runat="server" Text="Status"></asp:Label>
            </td>
            <td colspan="2" align="left">
                <asp:RadioButtonList ID="rbtnList" runat="server" RepeatDirection="Horizontal">
                    <asp:ListItem>Received</asp:ListItem>
                    <asp:ListItem>Damaged</asp:ListItem>
                </asp:RadioButtonList>
                <asp:RequiredFieldValidator ID="rfv_rbnList" runat="server" 
                    ControlToValidate="rbtnList" ErrorMessage="Choose one for Item status." 
                    ForeColor="Red">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblReason" runat="server" Text="Reason"></asp:Label>
            </td>
            <td colspan="2" align="left">
                <asp:TextBox ID="txtReason" runat="server" TextMode="MultiLine"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfv_reason" runat="server" 
                    ControlToValidate="txtReason" ErrorMessage="Enter reason about Item." 
                    ForeColor="Red">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td colspan="2" align="left">
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td colspan="2" align="left">
                <asp:Button ID="btnAdd" runat="server" Text="Add" onclick="btnAdd_Click" CssClass="button"/>
                <asp:ValidationSummary ID="vldSummary" runat="server" ForeColor="Red" />
            </td>
        </tr>
        <tr>
            <td colspan="3" align="center">
                <asp:GridView ID="gvAdjustList" runat="server" 
                    CellPadding="3" BackColor="White" BorderColor="#999999" BorderStyle="Solid" 
                    BorderWidth="1px" ForeColor="Black" GridLines="Vertical">
                    <AlternatingRowStyle BackColor="#CCCCCC" />
                    <FooterStyle BackColor="#CCCCCC" />
                    <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                    <SortedAscendingHeaderStyle BackColor="#808080" />
                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                    <SortedDescendingHeaderStyle BackColor="#383838" />
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td colspan="2" align="right">
                <asp:Button ID="btnSubmit" runat="server" Text="SubmitAdjustment" 
                    onclick="btnSubmit_Click" CssClass="button"/>
            </td>
            <td>
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="button"/>
            </td>
        </tr>
        <tr>
            <td colspan="2" align="right">
                &nbsp;</td>
            <td>
                <asp:Label ID="lblSubmitMsg" runat="server"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>
