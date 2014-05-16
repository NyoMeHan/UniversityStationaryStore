<%@ Page Title="" Language="C#" MasterPageFile="~/Dept.Master" AutoEventWireup="true" CodeBehind="DelegateEmployee.aspx.cs" Inherits="LogicUniversityWebLogic.DelegateEmployee" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        
    .style1
    {
        height: 63px;
    }
            
            
    </style>
    <link href="Styles/btnStyle.css"  rel="Stylesheet"/>
</asp:Content>
   
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <div align="center">
   
    <table class="delegate_form" cellpadding="5px" cellspacing="3px">
        <tr>
            <td colspan="2">
                <h2 align="center">Employee Delegation</h2></td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblName" runat="server" Text="Employee Name"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtEmpName" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvEmpName" runat="server" 
                    ControlToValidate="txtEmpName" ErrorMessage="Enter Employee Name." 
                    ForeColor="Red">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblFromDate" runat="server" Text="FromDate"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtFromDate" runat="server"></asp:TextBox>
                <asp:Image ID="imgFrom" runat="server" Height="16px" 
                    ImageUrl="~/images/calendar.png" Width="30px" />

                <asp:RequiredFieldValidator ID="rfvFromDate" runat="server" 
                    ControlToValidate="txtFromDate" ErrorMessage="Choose Start Date to assign." 
                    ForeColor="Red">*</asp:RequiredFieldValidator>

            </td>
            <asp:CalendarExtender ID="CalendarExtender1" runat="server" 
                PopupButtonID="imgFrom" TargetControlID="txtFromDate">
            </asp:CalendarExtender>
        </tr>
        <tr>
            <td class="style1">
                <asp:Label ID="lblToDate" runat="server" Text="ToDate"></asp:Label>
            </td>
            <td class="style1">
                <asp:TextBox ID="txtToDate" runat="server"></asp:TextBox>
                <asp:Image ID="imgTo" runat="server" Height="16px" 
                    ImageUrl="~/images/calendar.png" Width="30px" />

                <asp:RequiredFieldValidator ID="rfvToDate" runat="server" 
                    ControlToValidate="txtToDate" ErrorMessage="Choose End Date to Assign." 
                    ForeColor="Red">*</asp:RequiredFieldValidator>

                <asp:CalendarExtender ID="CalendarExtender2" runat="server" PopupButtonID="imgTo" TargetControlID="txtToDate">
                </asp:CalendarExtender>
                    <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            </td>
            
        </tr>
        <tr>
            <td>
                <asp:Button ID="btnAssign" runat="server" Text="Assign" 
                    onclick="btnAssign_Click" CssClass="button"/>
            </td>
            <td>
                <asp:HyperLink ID="HyperLink1" runat="server" 
                    NavigateUrl="~/RevokeEmployee.aspx">Revoke Employee</asp:HyperLink>
                &nbsp;&nbsp;&nbsp;
                <asp:Label ID="lblDatetest" runat="server"></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;
                <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="lblCurretDate" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblmsg" runat="server"></asp:Label>
            </td>
            <td>
                <asp:ValidationSummary ID="vldSummery" runat="server" ForeColor="Red" />
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
   </div>
</asp:Content>
