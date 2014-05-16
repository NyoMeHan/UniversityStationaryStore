<%@ Page Title="" Language="C#" MasterPageFile="~/Store_Master.Master" AutoEventWireup="true" CodeBehind="UpdateSupplierInfo.aspx.cs" Inherits="MobilePresentationLogic.UpdateSupplierInfo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <style type="text/css">
        .style1
        {
            width: 600px;
           
            
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<table class="style1" align="center" cellpadding="5px" cellspacing="10px">
        <tr>
            <td colspan="2">
                <h3 align="center">Maintain Supplier Informantion</h3></td>
        </tr>
        <tr>
            <td colspan="2" align="center">
    <asp:GridView ID="gvSupplierList" runat="server" 
    onselectedindexchanged="gvSupplierList_SelectedIndexChanged" BackColor="White" 
    BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="5" Width="79px" 
    >
        <Columns>
            <asp:CommandField ShowSelectButton="True" />
        </Columns>
        <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
        <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
        <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
        <RowStyle BackColor="White" ForeColor="#003399" />
        <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
        <SortedAscendingCellStyle BackColor="#EDF6F6" />
        <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
        <SortedDescendingCellStyle BackColor="#D6DFDF" />
        <SortedDescendingHeaderStyle BackColor="#002876" />
    </asp:GridView>
            </td>
        </tr>
        <tr>
            <td>

    <asp:Button ID="btnAddnewcustomer" runat="server" 
        onclick="btnAddnewcustomer_Click" Text="Add NewSupplier" Width="133px" />
            </td>
            <td>
    <asp:Button ID="btnUpdate" runat="server" onclick="btnUpdate_Click" 
        style="height: 26px" Text="Update" />
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                <asp:Label ID="lblMsg" runat="server"></asp:Label>
            </td>
        </tr>
    </table>
    <br />

</asp:Content>
