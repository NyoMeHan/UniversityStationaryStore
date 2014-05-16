<%@ Page Title="" Language="C#" MasterPageFile="~/Store.Master" AutoEventWireup="true" CodeBehind="StockHistoryCard.aspx.cs" Inherits="LogicUniversityWebLogic.StockHistoryCard" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="Styles/btnStyle.css"  rel="Stylesheet"/>
<div>
<table>
    <tr><td colspan="3"> &nbsp;</td></tr>
    <tr><td>
        <asp:Label ID="Label1" runat="server" Text="Category :"></asp:Label></td><td>
            <asp:DropDownList ID="ddlCategories" runat="server" AutoPostBack="True" 
                onselectedindexchanged="ddlCategories_SelectedIndexChanged">
            </asp:DropDownList>
        </td><td></td></tr>
    <tr><td>
        <asp:Label ID="lblItemName" runat="server" Text="Item Name :"></asp:Label></td><td>
            <asp:DropDownList ID="ddlItems" runat="server">
            </asp:DropDownList>
        </td><td></td></tr>
        <tr><td>
            <asp:Label ID="Label3" runat="server" Text="Select Month"></asp:Label></td><td><asp:DropDownList ID="ddlMonths" runat="server" Height="25px" 
                        Width="70px">
            <asp:ListItem Value="1">Jan</asp:ListItem>
            <asp:ListItem Value="2">Feb</asp:ListItem>
            <asp:ListItem Value="3">Mar</asp:ListItem>
            <asp:ListItem Value="4">Apr</asp:ListItem>
            <asp:ListItem Value="5">May</asp:ListItem>
            <asp:ListItem Value="6">Jun</asp:ListItem>
            <asp:ListItem Value="7">Jul</asp:ListItem>
            <asp:ListItem Value="8">Aug</asp:ListItem>
            <asp:ListItem Value="9">Sep</asp:ListItem>
            <asp:ListItem Value="10">Oct</asp:ListItem>
            <asp:ListItem Value="11">Nov</asp:ListItem>
            <asp:ListItem Value="12">Dec</asp:ListItem>
        </asp:DropDownList></td><td></td></tr>
    <tr><td></td><td>
        <asp:Button ID="btnView" runat="server" Text="View Stock History" 
            onclick="btnView_Click" CssClass="button" /></td><td></td></tr>

</table>
</div>
<div>
<table>
<tr><td>
    <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label></td></tr>
<tr><td>
    <CR:CrystalReportViewer ID="rptStockHistory" runat="server" AutoDataBind="true" />
</td></tr></table>

</div>

</asp:Content>
