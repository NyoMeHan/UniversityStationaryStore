<%@ Page Language="C#" AutoEventWireup="true"  MasterPageFile="~/Store_Master.Master"  CodeBehind="DeptView.aspx.cs" Inherits="MobilePresentationLogic.DeptView" %>


<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
   <h3>  View Department Requisition </h3>
    <br />
    <asp:DropDownList ID="deptdropdown" runat="server" 
        DataSourceID="Team4_ADEntities" DataTextField="Department_Name" 
        DataValueField="Department_Name" 
        onselectedindexchanged="deptdropdown_SelectedIndexChanged">
    </asp:DropDownList><br /><br />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:EntityDataSource ID="Team4_ADEntities" runat="server" 
        ConnectionString="name=Team4_ADEntities" 
        DefaultContainerName="Team4_ADEntities" EnableFlattening="False" 
        EntitySetName="Departments" 
        Select="it.[Department_Name]" EntityTypeFilter="Department">
    </asp:EntityDataSource>
  
    
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:Button ID="btnDeptReq" runat="server" onclick="btnDeptReq_Click" 
        Text="Retrieve" Width="78px" /><br /><br />
            <asp:GridView ID="deptviewgrid" runat="server" AllowPaging="True" 
                AutoGenerateColumns="False" CellPadding="4" BackColor="White" 
                BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" Width="319px">
                <Columns>
                    <asp:BoundField DataField="Item" HeaderText="Item" />
                    <asp:BoundField DataField="Requested_Quantity" 
                        HeaderText="Quantity Requested" />
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
    <p><br /><br />
    
        <asp:Button ID="Button1" runat="server" onclick="Button1_Click" 
            Text="Process All Request(s)" />
    </p>
</asp:Content>
