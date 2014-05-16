<%@ Page Title="Register" Language="C#" MasterPageFile="~/New.Master" AutoEventWireup="true"
    CodeBehind="Register.aspx.cs" Inherits="MobilePresentationLogic.Account.Register" %>


<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    
    <p>
        <br />
    </p>
    <p>
        User name&nbsp;&nbsp;
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    </p>
    <p>
        Password&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    </p>
    <p>
        Confirm Password
        <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
    </p>
    <p>
        <asp:CheckBox ID="CheckBox1" runat="server" Text="DepartmentHead" />
        <asp:CheckBox ID="CheckBox2" runat="server" Text="StoreClerk" />
        <asp:CheckBox ID="CheckBox3" runat="server" Text="StoreManager" />
        <asp:CheckBox ID="CheckBox4" runat="server" Text="StoreSupervisor" />
        <asp:CheckBox ID="CheckBox5" runat="server" Text="DepartmentRepresentative" />
    </p>
    <p>
        &nbsp;</p>
    <p>
        <asp:Button ID="Button1" runat="server" onclick="Button1_Click" 
            Text="Register" />
    </p>
    
</asp:Content>
