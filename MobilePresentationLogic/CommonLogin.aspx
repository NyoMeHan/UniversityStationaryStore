<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeBehind="CommonLogin.aspx.cs" Inherits="MobilePresentationLogic.CommonLogin" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <style type="text/css">
        #txtPassword
        {
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div align="center" style="height: 574px">
    
       
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
    
       
        <asp:Panel ID="Panel1" runat="server" BorderColor="#FF6699" 
            BorderStyle="Dotted" Height="266px" Width="385px" >
            <h3> Stationery Store Inventory System </h3>
            <asp:Label ID="lblMessage" runat="server" Text="Label" Visible="False"></asp:Label>
            <br />
            <br />
            <tabel>
            <tr>
            <td> &nbsp; <asp:Label runat="server" Text="Employee ID" ID="lblEmployeeID"></asp:Label></td>
            <td> &nbsp;&nbsp;&nbsp; 
                <asp:TextBox runat="server" ID="txtEmpID" 
                    Width="123px" Height="29px"></asp:TextBox></td>
            </tr>

            <tr>
            <td> <br /><br /> &nbsp; <asp:Label runat="server" Text="Password" ID="lblPassword"></asp:Label></td>
            <td> &nbsp;&nbsp;&nbsp; &nbsp;&nbsp; &nbsp;        
                <asp:TextBox runat="server" ID="txtPassword" TextMode="Password"
                    Width="120px" Height="28px"></asp:TextBox>
                <br />
                <br />
                <br />
                </td>
            </tr>
           
                &nbsp;</tabel>

                 <asp:Button ID="btnLogin" runat="server" onclick="btnLogin_Click" 
            Text="Login" Width="89px" BackColor="#99CCFF" BorderColor="#3399FF" 
                data-Ajax = false Height="32px"  />
    
        </asp:Panel>
    
    </div>
    </form>
</body>
</html>
