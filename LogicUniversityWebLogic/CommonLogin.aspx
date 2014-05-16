<%@ Page Title="" Language="C#" MasterPageFile="~/Login.Master" AutoEventWireup="true" CodeBehind="CommonLogin.aspx.cs" Inherits="LogicUniversityWebLogic.CommonLogin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style10
        {
        width: 713px;
    }
        .style11
        {
            width: 1024px;
        }
        .style12
        {
            width: 713px;
            height: 30px;
        }
        .style13
        {
            width: 1024px;
            height: 30px;
        }
    
    </style>
    <link href="Styles/btnStyle.css"  rel="Stylesheet"/>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="style7" style="width: 31%">
        <tr>
            <td class="style12">
                <asp:Label ID="Label1" runat="server" Text="Employee ID"></asp:Label>
            </td>
            <td class="style13">
                <asp:TextBox ID="txtEmpID" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style10">
                <asp:Label ID="Label2" runat="server" Text="Password"></asp:Label>
            </td>
            <td class="style11">
                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style10">
                &nbsp;</td>
            <td class="style11">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style10">
                <asp:Button ID="btnLogin" runat="server" Text="Login" CssClass="button" 
                    onclick="btnLogin_Click" />
            </td>
            <td class="style11">
                &nbsp;</td>
        </tr>
    </table>
    <asp:Label ID="Label3" runat="server"></asp:Label>
&nbsp;&nbsp;
    <asp:Label ID="Label4" runat="server"></asp:Label>
    <br />
    <br />
    <br />
</asp:Content>
