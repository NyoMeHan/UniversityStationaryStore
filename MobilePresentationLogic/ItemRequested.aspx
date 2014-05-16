<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Store_Master.Master"   CodeBehind="ItemRequested.aspx.cs" Inherits="MobilePresentationLogic.ItemRetrieved" %>
   
   
    <asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <h3> View items for Retrival</h3><br />
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
            AutoGenerateColumns="False" CellPadding="4" BackColor="White" 
            BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" Width="580px">
            <Columns>
                <asp:BoundField DataField="Description" HeaderText="Item" />
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

<SortedAscendingCellStyle BackColor="#EDF6F6"></SortedAscendingCellStyle>

<SortedAscendingHeaderStyle BackColor="#0D4AC4"></SortedAscendingHeaderStyle>

<SortedDescendingCellStyle BackColor="#D6DFDF"></SortedDescendingCellStyle>

<SortedDescendingHeaderStyle BackColor="#002876"></SortedDescendingHeaderStyle>
        </asp:GridView>
    
  </asp:Content>