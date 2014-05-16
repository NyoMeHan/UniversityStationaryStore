<%@ Page Title="" Language="C#" MasterPageFile="~/Store.Master" AutoEventWireup="true" CodeBehind="NewSupplierForm.aspx.cs" Inherits="LogicUniversityWebLogic.NewSupplierForm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<link href="Styles/btnStyle.css"  rel="Stylesheet"/>
 <table class="style1">
        <tr>
            <td class="style2" colspan="3">
                <h3>&nbsp;</h3></td>
        </tr>
        <tr>
            <td class="style2">
    <asp:Label ID="Label1" runat="server" Text="GST RegNo"></asp:Label>
    <asp:TextBox ID="txtGstregno" runat="server"></asp:TextBox>
            </td>
            <td colspan="2">
    <asp:Label ID="Label5" runat="server" Text="Phone No"></asp:Label>
    <asp:TextBox ID="txtPhoneno" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style2">
    <asp:Label ID="Label2" runat="server" Text="Supplier Code"></asp:Label>
    <asp:TextBox ID="txtSuppliercode" runat="server"></asp:TextBox>
            </td>
            <td colspan="2">
    <asp:Label ID="Label6" runat="server" Text="Fax No"></asp:Label>
    <asp:TextBox ID="txtFaxno" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style2">
    <asp:Label ID="Label3" runat="server" Text="Supplier Name"></asp:Label>
    <asp:TextBox ID="txtSuppliername" runat="server"></asp:TextBox>
            </td>
            <td colspan="2">
    <asp:Label ID="Label7" runat="server" Text="Address"></asp:Label>
    <asp:TextBox ID="txtAddress" runat="server" Height="39px" TextMode="MultiLine" 
        Width="127px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style2">
    <asp:Label ID="Label4" runat="server" Text="Contact Name"></asp:Label>
    <asp:TextBox ID="txtContactname" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:Label ID="lblEmail" runat="server" Text="Email"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
            </td>
        </tr>
</table>
    <br />
    <asp:Button ID="btnSave" runat="server" Text="Save" 
    onclick="btnSave_Click" CssClass="button"/>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="btnUpdate" runat="server" onclick="bttnUpdate_Click" 
        Text="Update" CssClass="button"/>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="button"
         />
    <br />
<asp:Label ID="lblmsg" runat="server"></asp:Label>
    <br />
</asp:Content>
