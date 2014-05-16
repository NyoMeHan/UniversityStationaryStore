<%@ Page Title="" Language="C#" MasterPageFile="~/Store_Master.Master" AutoEventWireup="true" CodeBehind="MaintainStockItem.aspx.cs" Inherits="MobilePresentationLogic.MaintainStockItem" %>
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

  <table class="style1">
        <tr>
            <td colspan="2">
                <h3>Maintain Stock Item Information</h3></td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="btnNewStockItem" runat="server" Text="Add New Item" 
                    onclick="btnNewStockItem_Click" />
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
                    Text="Check" />
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
                    BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" 
                    >
                    <Columns>
                        <asp:CommandField ShowSelectButton="True" SelectText="Update" />
                        <asp:CommandField ShowDeleteButton="True" />
                    </Columns>
                    <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                    <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                    <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                    <RowStyle BackColor="White" ForeColor="#003399" />
                    <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                    <sortedascendingcellstyle backcolor="#EDF6F6" />
                    <sortedascendingheaderstyle backcolor="#0D4AC4" />
                    <sorteddescendingcellstyle backcolor="#D6DFDF" />
                    <sorteddescendingheaderstyle backcolor="#002876" />
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
