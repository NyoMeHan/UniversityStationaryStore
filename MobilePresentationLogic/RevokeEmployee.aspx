<%@ Page Title="" Language="C#" MasterPageFile="~/Store_Master.Master" AutoEventWireup="true" CodeBehind="RevokeEmployee.aspx.cs" Inherits="MobilePresentationLogic.RevokeEmployee" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style1
        {
            width: 575px;
            height: 200px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

  <table class="style1">
        <tr>
            <td align="center" colspan="2">
                <h3>Revoke Employee</h3></td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblEmpName" runat="server" Text="Employee Name"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtEmpName" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvEmpName" runat="server" 
                    ControlToValidate="txtEmpName" ErrorMessage="Enter Employee Name." 
                    ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblEmpID" runat="server" Text="Employee ID"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                <asp:Button ID="btnRevoke" runat="server" onclick="btnRevoke_Click" 
                    Text="Revoke" />
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                <asp:Label ID="lblmsg" runat="server"></asp:Label>
            </td>
        </tr>
    </table>

</asp:Content>
