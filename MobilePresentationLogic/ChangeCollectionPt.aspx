<%@ Page Title="" Language="C#" MasterPageFile="~/Department_Master.Master" AutoEventWireup="true" CodeBehind="ChangeCollectionPt.aspx.cs" Inherits="MobilePresentationLogic.ChangeCollectionPt" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style1
        {
            height: 158px;
        }
        .style2
        {
            height: 185px;
            width: 643px;
        }
        .style3
        {
            width: 643px;
        }
        .style4
        {
            width: 453px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

  <table 
                    <tr><td style="text-align:center" class="style3">
                       <h1> <asp:Label ID="Label1" runat="server" Text="Change Collection Point" 
                            Font-Size="Large"></asp:Label></h1></td></tr>
                    <tr><td class="style2">
                        <table>
                                <tr><td>
                                    <asp:Label ID="Label2" runat="server" Text="Current Collection Point :"></asp:Label></td>
                                    <td class="style4">
                                        <asp:TextBox ID="txtCurrCollectionPt" runat="server" Width="212px"></asp:TextBox></td></tr>
                                        <tr><td></td><td class="style4"></td></tr>
                                <tr><td>
                                    <asp:Label ID="Label3" runat="server" Text="New Collection Point :"></asp:Label></td>
                                    <td class="style4">
                                        <asp:DropDownList ID="ddlCollectionPt" runat="server" Height="25px" 
                                            Width="219px">
                                        </asp:DropDownList>
                                    </td></tr>
                                    <tr><td></td><td class="style4"></td></tr>
                                    <tr><td></td><td class="style4">
                                        <asp:Button ID="btnChange" runat="server" Text="Make Change" 
                                            onclick="btnChange_Click" /></td></tr>
                                            <tr><td colspan ="2">
                                                <asp:Label ID="lblMessage" runat="server" Text=" "></asp:Label></td></tr>
                        </table>

                    </td></tr>
            </table>

</asp:Content>
