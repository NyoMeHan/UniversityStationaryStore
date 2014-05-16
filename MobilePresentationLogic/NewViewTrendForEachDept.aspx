<%@ Page Title="" Language="C#" MasterPageFile="~/Store_Master.Master" AutoEventWireup="true" CodeBehind="NewViewTrendForEachDept.aspx.cs" Inherits="MobilePresentationLogic.NewViewTrendForEachDept" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style1
        {
            width: 26px;
        }
        .style2
        {
            width: 550px;
        }
        .style3
        {
            width: 78px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<h3 align="center"> Trend Analysis for Each Department</h3>
<table
        <tr style="width: 636px; height: 160px"><td>
            <asp:Label ID="Label1" runat="server" Text="Department :"></asp:Label></td>
            <td class="style2">  <asp:DropDownList ID="ddlDeptName" runat="server" Height="25px" Width="224px">
                     </asp:DropDownList>
            </td><td></td></tr>
            <tr><td ><asp:Label ID="Label5" runat="server" Text="Select Type :"></asp:Label>
                 </td><td class="style2">
                    <asp:DropDownList ID="ddlSelectType" runat="server" Height="26px" 
                        Width="150px">
                    <asp:ListItem Value="Multiple">Multiple Months</asp:ListItem>
                    <asp:ListItem Value="Three">Three Months</asp:ListItem>
                     </asp:DropDownList> &nbsp 
                     <asp:Button ID="btnGo" runat="server" Text=">>" onclick="btnGo_Click" /></td><td></td>
                   </tr>
        <tr><td>
            <asp:Label ID="Label2" runat="server" Text="Current Month :"></asp:Label></td>
            <td class="style2">
               <asp:DropDownList ID="ddlCurrMonth" runat="server" Height="26px" 
                        Width="113px">
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
        </asp:DropDownList>
            </td><td></td></tr>
        <tr><td>
            <asp:Label ID="Label3" runat="server" Text="Previous Months :"></asp:Label></td>
            <td class="style2">
                <asp:DropDownList ID="ddlFirstPreviousMonth" runat="server" Height="26px" 
                        Width="113px">
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
        </asp:DropDownList>
            </td><td><asp:Label ID="lblMessage" runat="server" Text=" " Visible="True" Font-Size="8" ForeColor="#FF3300"></asp:Label></td></tr>
        <tr><td></td><td class="style2">
                <asp:DropDownList ID="ddlSecPreviousMonth" runat="server" Height="26px" 
                        Width="113px">
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
        </asp:DropDownList>
            </td><td></td></tr>
             <tr><td><asp:Label ID="Label4" runat="server" Text="Status"></asp:Label></td>
                 <td class="style2">
                <asp:DropDownList ID="ddlStatus" runat="server" Height="25px" Width="116px">
                    <asp:ListItem>ALL</asp:ListItem>
                    <asp:ListItem>Approve</asp:ListItem>
                    <asp:ListItem>Panding</asp:ListItem>
                </asp:DropDownList></td><td></td></tr>
        <tr><td colspan="3">
            <asp:Button ID="btnViewRpt" runat="server" Text="View Report" 
                onclick="btnViewRpt_Click" />

         <table style="width:200px">
            <tr><td style="text-align:center" class="style3">
                <CR:CrystalReportViewer ID="rptViewTrendForDept" runat="server" AutoDataBind="true" />
            </td></tr>
        </table>

            </td></tr>
        </table>

         </asp:Content>
