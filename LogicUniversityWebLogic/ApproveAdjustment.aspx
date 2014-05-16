<%@ Page Title="" Language="C#" MasterPageFile="~/Store.Master" AutoEventWireup="true" CodeBehind="ApproveAdjustment.aspx.cs" Inherits="LogicUniversityWebLogic.ApproveAdjustment" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style1
        {
            width: 600px;
            height: 250px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="style1" align="center">
        <tr><link href="Styles/btnStyle.css"  rel="Stylesheet"/>
            <td colspan="2">
                <h2>Approve Items Adjustment</h2></td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblLoginPerson" runat="server" Text="Login Person"></asp:Label>
            </td>
            <td align="left">
                <asp:Label ID="lblTest" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblAdjustmentID" runat="server" Text="AdjustmentReportNo"></asp:Label>
            </td>
            <td align="left">
                <asp:DropDownList ID="ddlAdjustID" runat="server" DataTextField="AdjustmentID" 
                    DataValueField="AdjustmentID" >
                </asp:DropDownList>
                <asp:Button ID="btnCheck" runat="server" onclick="btnCheck_Click" 
                    Text="Check" CssClass="button" />
            </td>
        </tr>
        <tr>
            <td colspan="2" align="center">
                <asp:GridView ID="gvAdjustmentReport" runat="server" BackColor="White" 
                    BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" 
                    ForeColor="Black" GridLines="Vertical">
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
            <td>
                <asp:Button ID="btnApproveAdjust" runat="server" Text="ApproveAdjustment" 
                    onclick="btnApproveAdjust_Click" CssClass="button" />
            </td>
            <td align="left">
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="button" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblUpdateMsg" runat="server"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>
