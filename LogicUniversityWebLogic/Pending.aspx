<%@ Page Title="" Language="C#" MasterPageFile="~/Store.Master" AutoEventWireup="true" CodeBehind="Pending.aspx.cs" Inherits="LogicUniversityWebLogic.Pending" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div>
<table>
    <tr><td colspan='2'><asp:Button ID="Button1" runat="server" onclick="Button1_Click1" 
            Text="Generate Updated Pending Report" 
 CssClass="button" /></td></tr>
    <tr>
        <td> <asp:Label ID="Label1" runat="server" Text="Select Type"></asp:Label></td><td>  <asp:DropDownList ID="dropdownview" runat="server">
            <asp:ListItem>Item Based</asp:ListItem>
            <asp:ListItem>Department Based</asp:ListItem>
        </asp:DropDownList></td>
    </tr>
    <tr><td></td><td>
        <asp:Button ID="btnSelect" runat="server" Text="Select" OnClick="btnSelect_Click1" /></td></tr>
</table>
</div>
<div>
    <table>
        <tr><td><link href="Styles/btnStyle.css"  rel="Stylesheet"/>
            <asp:Label ID="lblTitle" runat="server" Text="Select Department"></asp:Label></td><td><asp:DropDownList ID="DropDownList1" runat="server" 
                    DataSourceID="EntityDataSource1" DataTextField="Department_Name" 
                    DataValueField="Department_Name" 
                    onselectedindexchanged="DropDownList1_SelectedIndexChanged">
                </asp:DropDownList></td> <td>  <asp:Button ID="btnRetrieve" runat="server" onclick="btnRetrieve_Click" 
                            Text="Retrieve"
 CssClass="button" /> </td></tr>
    </table>
</div>
<div>
    <table>
        <tr><td><asp:MultiView ID="MultiView1" runat="server">
            <asp:View ID="DepartmentView" runat="server">
                
                <asp:EntityDataSource ID="EntityDataSource1" runat="server" 
                    ConnectionString="name=Team4_ADEntities" 
                    DefaultContainerName="Team4_ADEntities" EnableFlattening="False" 
                    EntitySetName="Departments" Select="it.[Department_Name]">
                </asp:EntityDataSource>
                <br />
                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                       
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                            CellPadding="4" ForeColor="#333333" GridLines="None">
                            <AlternatingRowStyle BackColor="White" />
                            <Columns>
                                <asp:BoundField DataField="Category_Name" HeaderText="Item Category" />
                                <asp:BoundField DataField="Description" HeaderText="Item Description" />
                                <asp:BoundField DataField="PendingQuantity" HeaderText="Pending Quantity" />
                                <asp:BoundField DataField="Status" HeaderText="Status" />
                            </Columns>
                            <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#FFCC66" ForeColor="#333333" 
                                HorizontalAlign="Center" />
                            <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                            <SelectedRowStyle BackColor="#FFCC66" ForeColor="Navy" Font-Bold="True" />
                            <SortedAscendingCellStyle BackColor="#FDF5AC" />
                            <SortedAscendingHeaderStyle BackColor="#4D0000" />
                            <SortedDescendingCellStyle BackColor="#FCF6C0" />
                            <SortedDescendingHeaderStyle BackColor="#820000" />
                        </asp:GridView>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </asp:View>
            <asp:View ID="ItemView" runat="server">
                <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" 
                    CellPadding="4" ForeColor="#333333" GridLines="None">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:BoundField DataField="Category_Name" HeaderText="Item Category" />
                        <asp:BoundField DataField="Description" HeaderText="Item Description" />
                        <asp:BoundField DataField="PendingQuantity" HeaderText="Pending Quantity" />
                    </Columns>
                    <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                    <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                    <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                    <SortedAscendingCellStyle BackColor="#FDF5AC" />
                    <SortedAscendingHeaderStyle BackColor="#4D0000" />
                    <SortedDescendingCellStyle BackColor="#FCF6C0" />
                    <SortedDescendingHeaderStyle BackColor="#820000" />
                </asp:GridView>
            </asp:View>
        </asp:MultiView>
        </td></tr>
         <tr><td>        <asp:Button ID="btnProcess" runat="server" onclick="Button1_Click" 
            Text="Process Pending Request(s)" 
 CssClass="button"/></td></tr>
    </table>
</div>

</asp:Content>
