<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Store_Master.Master"   CodeBehind="disbursement.aspx.cs" Inherits="MobilePresentationLogic.disbursement" %>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
        
        <h3> Check Disbursement</h3><br />

        <asp:Label ID="Label1" runat="server" Text="Please select the department"></asp:Label>
        &nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="DropDownList1" runat="server" 
            DataSourceID="EntityDataSource1" DataTextField="Department_Name" 
            DataValueField="Department_Name">
        </asp:DropDownList>
        <asp:EntityDataSource ID="EntityDataSource1" runat="server" 
            ConnectionString="name=Team4_ADEntities" 
            DefaultContainerName="Team4_ADEntities" EnableFlattening="False" 
            EntitySetName="Departments" EntityTypeFilter="Department" 
            Select="it.[Department_Name]">
        </asp:EntityDataSource>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:Button ID="btnRetrieve" runat="server" onclick="btnRetrieve_Click" 
                    Text="Retrieve" />
                <asp:GridView ID="deptgridview" runat="server" AutoGenerateColumns="False" 
                    CellPadding="4" BackColor="White" BorderColor="#3366CC" BorderStyle="None" 
                    BorderWidth="1px" Width="549px">
                    <Columns>
                        <asp:BoundField DataField="Category_Name" HeaderText="Item Category" />
                        <asp:BoundField DataField="Description" HeaderText="Item Description" />
                        <asp:BoundField DataField="Quantity" HeaderText="Requested Quantity" />
                        <asp:BoundField DataField="Alloted" HeaderText="Alloted Quantity" />
                        <asp:BoundField DataField="Pending_Qty" HeaderText="Pending" />
                        <asp:BoundField DataField="CollectionPoint" HeaderText="Collection Point" />
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
            </ContentTemplate>
        </asp:UpdatePanel>
 </asp:Content>