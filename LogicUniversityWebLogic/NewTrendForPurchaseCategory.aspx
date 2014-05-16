<%@ Page Title="" Language="C#" MasterPageFile="~/Store.Master" AutoEventWireup="true" CodeBehind="NewTrendForPurchaseCategory.aspx.cs" Inherits="LogicUniversityWebLogic.NewTrendForPurchaseCategory" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<table>
           
            <tr><td ><asp:Label ID="Label6" runat="server" Text="Select Type :"></asp:Label>
                 </td><td>
                    <asp:DropDownList ID="ddlSelectType" runat="server" Height="26px" 
                        Width="150px">
                    <asp:ListItem Value="Multiple">Multiple Months</asp:ListItem>
                    <asp:ListItem Value="Three">Three Months</asp:ListItem>
                     </asp:DropDownList> &nbsp 
                     <asp:Button ID="btnGo" runat="server" Text=">>" onclick="btnGo_Click" /></td><td></td>
                   </tr>
            <tr><td> <asp:Label ID="Label2" runat="server" Text="CurrentMonth :"></asp:Label>
            </td><td colspan="2"> <asp:DropDownList ID="ddlCurrentMonth" runat="server" Height="25px" 
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
        </asp:DropDownList></td></tr>
        <tr><td><asp:Label ID="Label3" runat="server" Text="Previous Months :" /></td><td>
            <asp:DropDownList ID="ddlFirstMonth" runat="server" Height="25px" 
                Width="71px">
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
        </asp:DropDownList></td><td>
            <asp:Label ID="lblMessage" runat="server" Text=" " Visible="True" Font-Size="8" ForeColor="#FF3300"></asp:Label></td></tr>
      <tr><td></td><td>
            <asp:DropDownList ID="ddlSecondMonth" runat="server" Height="25px" 
                Width="71px">
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
        </asp:DropDownList></td><td>
            <asp:Label ID="Label5" runat="server" Text=" " Visible="True" Font-Size="8" ForeColor="#FF3300"></asp:Label></td></tr>
        <tr><td colspan="3"> <asp:Button ID="btnView" runat="server" Text="View Reports" 
            onclick="btnView_Click" /></td></tr>
        </table>
        <table width="900px">
       <tr><td>
           <asp:Label ID="lblMessages" runat="server" Text=" "></asp:Label></td></tr>
        <tr><td style="width:200px">
            <CR:CrystalReportViewer ID="rptPurchaseItemView" runat="server" AutoDataBind="true" />
        </td></tr>
        </table>

</asp:Content>
