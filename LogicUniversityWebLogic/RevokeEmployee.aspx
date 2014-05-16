<%@ Page Title="" Language="C#" MasterPageFile="~/Dept.Master" AutoEventWireup="true" CodeBehind="RevokeEmployee.aspx.cs" Inherits="LogicUniversityWebLogic.RevokeEmployee" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style1
        {
            width: 300px;
            height: 200px;
        }
    </style>
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <table class="style1">
        <tr>
            <td align="center" colspan="2">
                <h3>&nbsp;</h3></td>
        </tr>
        <tr>
            <td><link href="Styles/btnStyle.css"  rel="Stylesheet"/>
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
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                <asp:Button ID="btnRevoke" runat="server" onclick="btnRevoke_Click" 
                    Text="Revoke" CssClass="button"/>
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
