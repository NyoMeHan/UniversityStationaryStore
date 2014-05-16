<%@ Page Title="" Language="C#" MasterPageFile="~/Store.Master" AutoEventWireup="true" CodeBehind="MaintainStockItem.aspx.cs" Inherits="LogicUniversityWebLogic.MaintainStockItem" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

<style type="text/css">
        .style1
        {
            width: 600px;
        }
        .style2
        {
            height: 16px;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<link href="Styles/btnStyle.css"  rel="Stylesheet"/>
  <table class="style1">
        <tr>
            <td colspan="2">
                <h3>&nbsp;</h3></td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="btnNewStockItem" runat="server" Text="Add New Item" 
                    onclick="btnNewStockItem_Click" 
CssClass="button"/>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblCategoryName" runat="server" Text="CategoryName"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddlCateogryList" runat="server"   >
                </asp:DropDownList>
                <asp:Button ID="btnCheck" runat="server" onclick="btnCheck_Click" 
                    Text="Check" 
CssClass="button"/>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:GridView ID="gvItemInfoList" runat="server" Width="314px"                     
                    onselectedindexchanged="gvItemInfoList_SelectedIndexChanged" 
                   onrowcommand="gvItemInfoList_RowCommand" 
                    onrowdeleting="gvItemInfoList_RowDeleting" BackColor="White" 
                    BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" 
                    ForeColor="Black" GridLines="Vertical" 
                    >
                    <AlternatingRowStyle BackColor="#CCCCCC" />
                    <Columns>
                        <asp:CommandField ShowSelectButton="True" SelectText="Update" />
                        <asp:CommandField ShowDeleteButton="True" />
                    </Columns>
                    <FooterStyle BackColor="#CCCCCC" />
                    <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                    <SortedAscendingHeaderStyle BackColor="#808080" />
                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                    <SortedDescendingHeaderStyle BackColor="#383838" />
                </asp:GridView>
&nbsp;</td>
        </tr>
        <tr>
            <td colspan="2" class="style2">
                <asp:Label ID="lblmsg" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="2">
                &nbsp;</td>
        </tr>
    </table>

</asp:Content>
