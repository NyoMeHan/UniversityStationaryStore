<%@ Page Title="" Language="C#" MasterPageFile="~/Store.Master" AutoEventWireup="true" CodeBehind="ItemRetrieved.aspx.cs" Inherits="LogicUniversityWebLogic.ItemRetrieved" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<link href="Styles/btnStyle.css"  rel="Stylesheet"/>
<div>
<table>
    <tr>
        <td>
            <asp:GridView ID="grvItemRetrieved" runat="server" AutoGenerateColumns="False" 
            CellPadding="2" ForeColor="Black" GridLines="None" 
            BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" >
            <AlternatingRowStyle BackColor="PaleGoldenrod" />
            <Columns>
                <asp:BoundField DataField="Category_Name" HeaderText="Category Name" />
                <asp:BoundField DataField="Description" HeaderText="Description" />
                <asp:BoundField DataField="RequestedQuantity" HeaderText="Requested Quantity" />
                <asp:BoundField DataField="RetrievedQuantity" HeaderText="Retrieved Quantity" />
                <asp:BoundField DataField="PendingQuantity" HeaderText="PendingQuantity" />
            </Columns>
            <FooterStyle BackColor="Tan" />
            <HeaderStyle BackColor="Tan" Font-Bold="True" />
            <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" 
                HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
            <SortedAscendingCellStyle BackColor="#FAFAE7" />
            <SortedAscendingHeaderStyle BackColor="#DAC09E" />
            <SortedDescendingCellStyle BackColor="#E1DB9C" />
            <SortedDescendingHeaderStyle BackColor="#C2A47B" />
            
        </asp:GridView>
        <br />
        <br />
        </td>
    </tr>
</table>
</div>
 <div>
    <table>
        <tr><td></td></tr>
        <tr><td> <asp:Button ID="btnDisburse" runat="server" onclick="btnDisburse_Click" 
        Text="Disburse" CssClass="button"
 />
</td></tr>
    </table>
 </div>

</asp:Content>
