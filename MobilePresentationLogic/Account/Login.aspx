<%@ Page Title="Log In" Language="C#" MasterPageFile="~/Master_Store.Master" AutoEventWireup="true"
    CodeBehind="Login.aspx.cs" Inherits="MobilePresentationLogic.Account.Login" %>


<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    
    <asp:Label ID="Label1" runat="server" Text="User ID"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="txtUser" runat="server"></asp:TextBox>
    <br />
    <br />
    <asp:Label runat="server" Text="Password"></asp:Label>
&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="txtPassword" runat="server"></asp:TextBox>
    <br />
    <br />
    <br />
    <asp:Button ID="btnSubmit" runat="server" onclick="btnSubmit_Click" 
        Text="Login" Width="95px" />
&nbsp;
    
</asp:Content>
