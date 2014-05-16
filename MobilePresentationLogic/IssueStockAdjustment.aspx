<%@ Page Title="" Language="C#" MasterPageFile="~/Store_Master.Master" AutoEventWireup="true" CodeBehind="IssueStockAdjustment.aspx.cs" Inherits="MobilePresentationLogic.IssueStockAdjustment" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
    <style type="text/css">
        .style2
        {
            width: 268435520px;
        }
    </style>
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table align="center">
        <tr>
            <td colspan="3">
               <h3 align="center">Adjustment Report Form</h3></td>
        </tr>
        <tr>
            <td >
                <asp:Label ID="lblCategory" runat="server" Text="Category"></asp:Label>
            </td>
            <td  colspan="2" align="left">
                <asp:DropDownList ID="ddlCategory" runat="server" DataTextField="Category_Name" 
                    DataValueField="CateogryID" 
                     onselectedindexchanged="ddlCategory_SelectedIndexChanged"  
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
                <asp:Label ID="Label1" runat="server" Text="ItemPrice"></asp:Label>
            </td>
            <td colspan="2" align="left">
                <asp:DropDownList ID="ddlPrice" runat="server">
                    <asp:ListItem Value="251">Above $ 250 </asp:ListItem>
                    <asp:ListItem Value="250">Under $250</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td colspan="2" align="left">
                <asp:Button ID="btnAdd" runat="server" Text="Add" onclick="btnAdd_Click" />
                <asp:ValidationSummary ID="vldSummary" runat="server" ForeColor="Red" />
            </td>
        </tr>
        <tr>
            <td colspan="3" align="center">
                <asp:GridView ID="gvAdjustList" runat="server" 
                    CellPadding="4" BackColor="White" BorderColor="#3366CC" BorderStyle="None" 
                    BorderWidth="1px" Width="620px">
                    <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                    <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                    <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                    <RowStyle ForeColor="#003399" BackColor="White" />
                    <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                    <SortedAscendingHeaderStyle BackColor="#007DBB" />
                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                    <SortedDescendingHeaderStyle BackColor="#00547E" />

<SortedAscendingCellStyle BackColor="#EDF6F6"></SortedAscendingCellStyle>

<SortedAscendingHeaderStyle BackColor="#0D4AC4"></SortedAscendingHeaderStyle>

<SortedDescendingCellStyle BackColor="#D6DFDF"></SortedDescendingCellStyle>

<SortedDescendingHeaderStyle BackColor="#002876"></SortedDescendingHeaderStyle>
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td colspan="2" align="right">
                <asp:Button ID="btnSubmit" runat="server" Text="SubmitAdjustment" 
                    onclick="btnSubmit_Click" />
            &nbsp;&nbsp;&nbsp;&nbsp;
            </td>
            <td class="style2" >
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" Width="88px" />
            </td>
        </tr>
        <tr>
            <td colspan="2" align="right">
                &nbsp;</td>
            <td class="style2">
                <asp:Label ID="lblSubmitMsg" runat="server"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>
