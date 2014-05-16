<%@ Page Title="" Language="C#" MasterPageFile="~/Department_Master.Master" AutoEventWireup="true" CodeBehind="DepartmentDetail.aspx.cs" Inherits="MobilePresentationLogic.DepartmentDetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

 <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style4
        {
            width: 217px;
        }
        .style5
        {
            width: 267px;
        }
        .style6
        {
            width: 179px;
        }
        .style7
        {
            width: 352px;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<h3 align="center"> Department Information </h3>
  <table class="style1">
        <tr>
            <td class="style6">
                &nbsp;</td>
            <td class="style7">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style6">
                <asp:Label ID="lblDeptCode" runat="server" Text="Department Code"></asp:Label>
            </td>
            <td class="style7">
                <asp:TextBox ID="txtDeptCode" runat="server" Enabled="False"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style6">
                <asp:Label ID="lblDeptName" runat="server" Text="Department Name"></asp:Label>
            </td>
            <td class="style7">
                <asp:TextBox ID="txtDeptName" runat="server" Width="122px" Enabled="False"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style6">
                <asp:Label ID="lblContactName" runat="server" Text="Contact Name"></asp:Label>
            </td>
            <td class="style7">
                <asp:DropDownList ID="ddlContactEmp" runat="server" AutoPostBack="true">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="style6">
                <asp:Label ID="lblPhoneNo" runat="server" Text="Telephone No"></asp:Label>
            </td>
            <td class="style7">
                <asp:TextBox ID="txtPhoneNo" runat="server" Enabled="False"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style6">
                <asp:Label ID="lblFaxNo" runat="server" Text="Fax No"></asp:Label>
            </td>
            <td class="style7">
                <asp:TextBox ID="txtFaxNo" runat="server" Enabled="False"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style6">
                <asp:Label ID="lblDeptHead" runat="server" Text="Department Head"></asp:Label>
            </td>
            <td class="style7">
                <asp:DropDownList ID="ddlDeptHead" runat="server" AutoPostBack="True" 
                    Enabled="False">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="style6">
                <asp:Label ID="lblCollectionPoint" runat="server" Text="Collection Point"></asp:Label>
            </td>
            <td class="style7">
                <asp:DropDownList ID="ddlCollectionPts" AutoPostBack="true" runat="server" 
                    Enabled="False">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="style6">
                <asp:Label ID="lblRepName" runat="server" Text="Department Representative"></asp:Label>
            </td>
            <td class="style7">
                <asp:DropDownList ID="ddlDeptRep" AutoPostBack="true" runat="server" 
                    Enabled="False">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="style6">
                &nbsp;</td>
            <td class="style7">
                &nbsp;</td>
        </tr>
 
    </table>
    <table class="style1">
        <tr>
            <td class="style4">
                <asp:Button ID="btnEdit" runat="server" Text="Edit" onclick="btnEdit_Click" 
                    Width="88px" />
                </td>
            <td class="style5">
                <asp:Button ID="btnUpdate" runat="server" Text="Update" 
                    onclick="btnUpdate_Click" Width="89px" />
                &nbsp;<asp:Button ID="btnAdd" runat="server" Text="Add" Visible="False" 
                    onclick="btnAdd_Click" Width="75px" />
            </td>
            <td>
                <asp:Button ID="btnRestore" runat="server" Text="Restore" 
                    onclick="btnRestore_Click"  />
                <asp:Button ID="btnReset" runat="server" Text="Reset" onclick="btnReset_Click" 
                    Visible="False" Width="66px" />
            </td>
        </tr>
    </table>
    <asp:Label ID="lblDisplay" runat="server" Text=""></asp:Label>

</asp:Content>
