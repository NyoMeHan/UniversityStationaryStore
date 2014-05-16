<%@ Page Title="" Language="C#" MasterPageFile="~/Dept.Master" AutoEventWireup="true" CodeBehind="ChangeCollectionPt.aspx.cs" Inherits="LogicUniversityWebLogic.ChangeCollectionPt" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="Styles/btnStyle.css"  rel="Stylesheet"/>
  <table style="width:900px; ">
                    <tr><td style="text-align:center">
                       <h1> &nbsp;</h1></td></tr>
                    <tr><td>
                        <table>
                                <tr><td>
                                    <asp:Label ID="Label2" runat="server" Text="Current Collection Point :"></asp:Label></td><td>
                                        <asp:TextBox ID="txtCurrCollectionPt" runat="server" Width="212px" 
                                            ReadOnly="True"></asp:TextBox></td></tr>
                                        <tr><td></td><td></td></tr>
                                <tr><td>
                                    <asp:Label ID="Label3" runat="server" Text="New Collection Point :"></asp:Label></td><td>
                                        <asp:DropDownList ID="ddlCollectionPt" runat="server" Height="25px" 
                                            Width="219px">
                                        </asp:DropDownList>
                                    </td></tr>
                                    <tr><td></td><td>
                                        <br />
                                        <br />
                                        </td></tr>
                                    <tr><td></td><td>
                                        <asp:Button ID="btnChange" runat="server" Text="Make Change" 
                                            onclick="btnChange_Click" CssClass="button" /></td></tr>
                                            <tr><td colspan ="2">
                                                <asp:Label ID="lblMessage" runat="server" Text=" "></asp:Label></td></tr>
                        </table>

                    </td></tr>
            </table>

</asp:Content>
