<%@ Page Language="C#" AutoEventWireup="true"  MasterPageFile="~/Store_Master.Master"  CodeBehind="pending.aspx.cs" Inherits="MobilePresentationLogic.pending" %>


<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
<h3 align="center">View Outstanding items</h3>
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        <asp:DropDownList ID="dropdownview" runat="server">
            <asp:ListItem>Item Based</asp:ListItem>
            <asp:ListItem>Department Based</asp:ListItem>
        </asp:DropDownList>
        <asp:Button ID="btnSelect" runat="server" Text="Select" OnClick="btnSelect_Click1" />
        &nbsp;&nbsp;
        <asp:Button ID="Button1" runat="server" onclick="Button1_Click1" 
            Text="Generate Updated Pending Report" />
        <asp:MultiView ID="MultiView1" runat="server">
            <asp:View ID="DepartmentView" runat="server">
                Select&nbsp; the department<asp:DropDownList ID="DropDownList1" runat="server" 
                    DataSourceID="EntityDataSource1" DataTextField="Department_Name" 
                    DataValueField="Department_Name" 
                    onselectedindexchanged="DropDownList1_SelectedIndexChanged">
                </asp:DropDownList>
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
                        <asp:Button ID="btnRetrieve" runat="server" onclick="btnRetrieve_Click" 
                            Text="Retrieve" />
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                            CellPadding="4" BackColor="White" BorderColor="#3366CC" BorderStyle="None" 
                            BorderWidth="1px">
                            <Columns>
                                <asp:BoundField DataField="Category_Name" HeaderText="Item Category" />
                                <asp:BoundField DataField="Description" HeaderText="Item Description" />
                                <asp:BoundField DataField="PendingQuantity" HeaderText="Pending Quantity" />
                                <asp:BoundField DataField="Status" HeaderText="Status" />
                            </Columns>
                            <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                            <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                            <PagerStyle BackColor="#99CCCC" ForeColor="#003399" 
                                HorizontalAlign="Left" />
                            <RowStyle BackColor="White" ForeColor="#003399" />
                            <SelectedRowStyle BackColor="#009999" ForeColor="#CCFF99" Font-Bold="True" />
                            <SortedAscendingCellStyle BackColor="#FDF5AC" />
                            <SortedAscendingHeaderStyle BackColor="#4D0000" />
                            <SortedDescendingCellStyle BackColor="#FCF6C0" />
                            <SortedDescendingHeaderStyle BackColor="#820000" />
                            <sortedascendingcellstyle backcolor="#EDF6F6" />
                            <sortedascendingheaderstyle backcolor="#0D4AC4" />
                            <sorteddescendingcellstyle backcolor="#D6DFDF" />
                            <sorteddescendingheaderstyle backcolor="#002876" />
                        </asp:GridView>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </asp:View>
            <asp:View ID="ItemView" runat="server">
                <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" 
                    CellPadding="4" BackColor="White" BorderColor="#3366CC" BorderStyle="None" 
                    BorderWidth="1px" Width="423px">
                    <Columns>
                        <asp:BoundField DataField="Category_Name" HeaderText="Item Category" />
                        <asp:BoundField DataField="Description" HeaderText="Item Description" />
                        <asp:BoundField DataField="PendingQuantity" HeaderText="Pending Quantity" />
                    </Columns>
                    <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                    <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                    <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                    <RowStyle BackColor="White" ForeColor="#003399" />
                    <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                    <SortedAscendingCellStyle BackColor="#FDF5AC" />
                    <SortedAscendingHeaderStyle BackColor="#4D0000" />
                    <SortedDescendingCellStyle BackColor="#FCF6C0" />
                    <SortedDescendingHeaderStyle BackColor="#820000" />
                    <sortedascendingcellstyle backcolor="#EDF6F6" />
                    <sortedascendingheaderstyle backcolor="#0D4AC4" />
                    <sorteddescendingcellstyle backcolor="#D6DFDF" />
                    <sorteddescendingheaderstyle backcolor="#002876" />
                </asp:GridView>
            </asp:View>
        </asp:MultiView>
    
        <asp:Button ID="btnProcess" runat="server" onclick="Button1_Click" 
            Text="Process Pending Request(s)" />
</asp:Content>