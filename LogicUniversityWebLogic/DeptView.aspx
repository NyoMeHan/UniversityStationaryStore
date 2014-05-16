<%@ Page Title="" Language="C#" MasterPageFile="~/Store.Master" AutoEventWireup="true" CodeBehind="DeptView.aspx.cs" Inherits="LogicUniversityWebLogic.DeptView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div>
<link href="Styles/btnStyle.css"  rel="Stylesheet"/>
<table width="900px">
<tr align="left"><td><table width = "700px"><tr><td style="width:200px"></td><td align="left">
    <asp:Label ID="Label1" runat="server" Text="Select Department"></asp:Label></td><td align="left" style="height:27px"> 
        <asp:DropDownList ID="deptdropdown" runat="server" 
        DataSourceID="Team4_ADEntities" DataTextField="Department_Name" 
        DataValueField="Department_Name" 
        onselectedindexchanged="deptdropdown_SelectedIndexChanged" Height="25px" 
            Width="172px">
    </asp:DropDownList>

    <asp:EntityDataSource ID="Team4_ADEntities" runat="server" 
        ConnectionString="name=Team4_ADEntities" 
        DefaultContainerName="Team4_ADEntities" EnableFlattening="False" 
        EntitySetName="Departments" 
        Select="it.[Department_Name]" EntityTypeFilter="Department">
    </asp:EntityDataSource></td></tr>
    <tr><td></td><td></td><td><asp:Button ID="btnDeptReq" runat="server" onclick="btnDeptReq_Click" 
        Text="Retrieve" Width="78px" CssClass="button"/></td></tr>
    </table>
    </td></tr>
<tr><td>    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>      
    </td></tr>
</table>
</div>
<div>
<table>
<tr><td>
 <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
      
            <asp:GridView ID="deptviewgrid" runat="server" AllowPaging="True" 
                AutoGenerateColumns="False" CellPadding="3" ForeColor="Black" 
                GridLines="Vertical" BackColor="White" BorderColor="#999999" 
                BorderStyle="Solid" BorderWidth="1px">
                <AlternatingRowStyle BackColor="#CCCCCC" />
                <Columns>
                    <asp:BoundField DataField="Item" HeaderText="Item" />
                    <asp:BoundField DataField="Requested_Quantity" 
                        HeaderText="Quantity Requested" />
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

            </td>

    </tr>
    <tr><td>        <asp:Button ID="Button1" runat="server" onclick="Button1_Click" 
            Text="Process All Request(s)" CssClass="button"/>
        </td></tr>
</table>
</div>



  
    

   

</asp:Content>
