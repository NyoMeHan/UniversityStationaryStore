<%@ Page Language="C#"   MasterPageFile="~/Store_Master.Master" AutoEventWireup="true" CodeBehind="ItemRetrieved.aspx.cs" Inherits="MobilePresentationLogic.ItemRetrieved1" %>


<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
   
    <h3> Retrieve Requested items </h3><br />

        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            CellPadding="4" 
            BackColor="White" BorderColor="#3366CC" BorderWidth="1px" 
            BorderStyle="None" Width="593px" >
            <Columns>
                <asp:BoundField DataField="Category_Name" HeaderText="Category Name" />
                <asp:BoundField DataField="Description" HeaderText="Description" />
                <asp:BoundField DataField="RequestedQuantity" HeaderText="Requested Quantity" />
                <asp:BoundField DataField="RetrievedQuantity" HeaderText="Retrieved Quantity" />
                <asp:BoundField DataField="PendingQuantity" HeaderText="PendingQuantity" />
            </Columns>
            <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
            <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
            <PagerStyle BackColor="#99CCCC" ForeColor="#003399" 
                HorizontalAlign="Left" />
            <RowStyle BackColor="White" ForeColor="#003399" />
            <SelectedRowStyle BackColor="#009999" ForeColor="#CCFF99" Font-Bold="True" />
            <SortedAscendingCellStyle BackColor="#FAFAE7" />
            <SortedAscendingHeaderStyle BackColor="#DAC09E" />
            <SortedDescendingCellStyle BackColor="#E1DB9C" />
            <SortedDescendingHeaderStyle BackColor="#C2A47B" />
            
<SortedAscendingCellStyle BackColor="#EDF6F6"></SortedAscendingCellStyle>

<SortedAscendingHeaderStyle BackColor="#0D4AC4"></SortedAscendingHeaderStyle>

<SortedDescendingCellStyle BackColor="#D6DFDF"></SortedDescendingCellStyle>

<SortedDescendingHeaderStyle BackColor="#002876"></SortedDescendingHeaderStyle>
            
        </asp:GridView>
    

        <br />
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    

    <asp:Button ID="Button1" runat="server" onclick="Button1_Click" 
        Text="Disburse" />

</asp:Content>
