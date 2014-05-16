<%@ Page Title="" Language="C#" MasterPageFile="~/Store_Master.Master" AutoEventWireup="true" CodeBehind="ViewTrendForPurchaseItem.aspx.cs" Inherits="LogicUniversityWebLogic.ViewTrendForPurchaseItem" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

 <table>
           
            <tr style="height:40px"><td> <asp:Label ID="Label2" runat="server" Text="CurrentMonth :"></asp:Label>
            </td><td colspan="2"> 
                    <asp:DropDownList ID="ddlCurrentMonth" runat="server" Height="27px" 
                        Width="72px">
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
        </asp:DropDownList></td></tr>
        <tr style="height:40px"><td><asp:Label ID="Label3" runat="server" Text="Previous Months :" /></td><td>
            <asp:DropDownList ID="ddlPastFirstMonth" runat="server" Height="27px" Width="72px">
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
        </asp:DropDownList></td><td> <asp:Label ID="lblMessage" runat="server" Text=" " 
                    ForeColor="#FF3300" Font-Size="8pt"></asp:Label></td></tr>
       
        <tr style="height:30px"><td colspan="3"> <asp:Button ID="btnView" runat="server" Text="View Reports" 
            onclick="btnView_Click" /></td></tr>
        </table>
        <br />
        <table style="width:900px">
            <tr><td style="width:200px; text-align:center">
                <CR:CrystalReportViewer ID="rptPurchaseItemView" runat="server" AutoDataBind="true" />
            </td></tr>
        </table>

</asp:Content>
