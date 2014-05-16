<%@ Page Title="" Language="C#" MasterPageFile="~/Department_Master.Master" AutoEventWireup="true" CodeBehind="DelegateEmployee.aspx.cs" Inherits="MobilePresentationLogic.DelegateEmployee" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        
    .style1
    {
        height: 63px;
    }
    .style2
    {
        height: 24px;
    }
        
        .style3
        {
            width: 401px;
        }
        .style4
        {
            height: 24px;
            width: 401px;
        }
        .style5
        {
            height: 63px;
            width: 401px;
        }
        
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <div align="center" style="width: 612px">
    <table class="delegate_form" cellpadding="5px" cellspacing="3px">
        <tr>
            <td colspan="2">
                <h2 align="center">Employee Delegation</h2></td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblName" runat="server" Text="Employee Name"></asp:Label>
            </td>
            <td class="style3">
                <asp:TextBox ID="txtEmpName" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvEmpName" runat="server" 
                    ControlToValidate="txtEmpName" ErrorMessage="Enter Employee Name." 
                    ForeColor="Red">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="style2">
                <asp:Label ID="lblNewEmpName" runat="server" Text="Temporary Employee Type"></asp:Label>
            </td>
            <td class="style4">
                <asp:DropDownList ID="ddlEmpType" runat="server">
                    <asp:ListItem>DeptHead</asp:ListItem>
                    <asp:ListItem>Employee</asp:ListItem>
                    <asp:ListItem>Manager</asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="rfvEmpType" runat="server" 
                    ControlToValidate="ddlEmpType" ErrorMessage="Choose Employee Type." 
                    ForeColor="Red">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblFromDate" runat="server" Text="FromDate"></asp:Label>
            </td>
            <td class="style3">
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
            <td class="style5">
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
                    onclick="btnAssign_Click" Width="66px" />
            </td>
            <td class="style3">
                <asp:HyperLink ID="HyperLink1" runat="server" 
                    NavigateUrl="~/RevokeEmployee.aspx">Revoke Employee</asp:HyperLink>
                <asp:Label ID="lblDatetest" runat="server"></asp:Label>
                <asp:Label ID="lblCurretDate" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblmsg" runat="server"></asp:Label>
            </td>
            <td class="style3">
                <asp:ValidationSummary ID="vldSummery" runat="server" ForeColor="Red" />
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td class="style3">
                &nbsp;</td>
        </tr>
    </table>
   </div>
</asp:Content>
