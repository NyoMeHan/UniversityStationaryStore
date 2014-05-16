<%@ Page Title="" Language="C#" MasterPageFile="~/Store_Master.Master" AutoEventWireup="true" CodeBehind="CheckReorderItems.aspx.cs" Inherits="MobilePresentationLogic.CheckReorderItems" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <h3 align="center"> Check Reorder Level</h3>
    <div style="width: 601px">
    <asp:GridView ID="gvReorderItems" runat="server" BackColor="White" 
            BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" 
            Width="191px">
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
        <br />
        <br />
    <asp:Button ID="btn" runat="server" Text="Generate PDF" onclick="btn_Click" />
     </div>

</asp:Content>
