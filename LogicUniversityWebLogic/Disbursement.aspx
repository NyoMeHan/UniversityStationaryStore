<%@ Page Title="" Language="C#" MasterPageFile="~/Store.Master" AutoEventWireup="true" CodeBehind="Disbursement.aspx.cs" Inherits="LogicUniversityWebLogic.Disbursement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div>
    <table>
        <tr><td colspan='2'><h3>View Disbursement</h3></td></tr>
        <tr><td></td><td></td></tr>
        <tr>
            <td><asp:Label ID="Label1" runat="server" Text="Select Department"></asp:Label></td><td> <asp:DropDownList ID="DropDownList1" runat="server" 
            DataSourceID="EntityDataSource1" DataTextField="Department_Name" 
            DataValueField="Department_Name" Height="25px" Width="200px">
        </asp:DropDownList>
        <asp:EntityDataSource ID="EntityDataSource1" runat="server" 
            ConnectionString="name=Team4_ADEntities" 
            DefaultContainerName="Team4_ADEntities" EnableFlattening="False" 
            EntitySetName="Departments" EntityTypeFilter="Department" 
            Select="it.[Department_Name]">
        </asp:EntityDataSource></td>
        </tr><link href="Styles/btnStyle.css"  rel="Stylesheet"/>
        <tr><td align="right"> <asp:Button ID="btnRetrieve" runat="server" onclick="btnRetrieve_Click" 
                    Text="Retrieve"  CssClass="button" /></td></tr>
    </table>
</div>
<br /><br />

<div>
<table>
    <tr><td>  <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager></td></tr>
    <tr><td> <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
               
                <asp:GridView ID="deptgridview" runat="server" AutoGenerateColumns="False" 
                    CellPadding="3" ForeColor="Black" GridLines="Vertical" BackColor="White" 
                    BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px">
                    <AlternatingRowStyle BackColor="#CCCCCC" />
                    <Columns>
                        <asp:BoundField DataField="Category_Name" HeaderText="Item Category" />
                        <asp:BoundField DataField="Description" HeaderText="Item Description" />
                        <asp:BoundField DataField="Quantity" HeaderText="Requested Quantity" />
                        <asp:BoundField DataField="Alloted" HeaderText="Alloted Quantity" />
                        <asp:BoundField DataField="Pending_Qty" HeaderText="Pending" />
                    </Columns>
                    <FooterStyle BackColor="#CCCCCC" />
                    <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                    <SortedAscendingHeaderStyle BackColor="#808080" />
                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                    <SortedDescendingHeaderStyle BackColor="#383838" />
                </asp:GridView>
            </ContentTemplate>
        </asp:UpdatePanel>
</td></tr>
</table>
</div>

</asp:Content>
