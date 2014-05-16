<%@ Page Title="" Language="C#" MasterPageFile="~/Department_Master.Master" AutoEventWireup="true" Inherits="MobilePresentationLogic.Department_Requisition" Codebehind="Department_Requisition.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   
   </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
       <h3 align="center">Approve or Reject Stationery Requisition</h3><br />
      <div style="width: 587px">
     <asp:GridView ID="gvRequest" runat="server" AllowPaging="True" 
        AutoGenerateColumns="False" Height="16px" Width="565px" AllowSorting="True" 
                    CellPadding="4" PageSize="7" 
        BackColor="White" BorderColor="#3366CC" 
        BorderWidth="1px" onpageindexchanging="gvRequest_PageIndexChanging" 
        EmptyDataText="No Records Found" ShowHeaderWhenEmpty="True" DataKeyNames="Emp_ReqID,EmployeeID" 
                    onrowdatabound="gvRequest_RowDataBound">
        <sortedascendingcellstyle backcolor="#E9E7E2" />
        <sortedascendingheaderstyle backcolor="#506C8C" />
        <sorteddescendingcellstyle backcolor="#FFFDF8" />
        <sorteddescendingheaderstyle backcolor="#6F8DAE" />

        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:CheckBox ID="chkResult1" runat="server" AutoPostBack="True" />
                </ItemTemplate>
                <ItemStyle BorderStyle="Solid" />
            </asp:TemplateField>
            <asp:BoundField DataField="Emp_ReqID" HeaderText="Request ID">
                <ItemStyle BorderStyle="Solid" />
            </asp:BoundField>
            <asp:BoundField DataField="EmployeeName" HeaderText="Employee Name">
                <ItemStyle BorderStyle="Solid" />
            </asp:BoundField>
            <asp:TemplateField HeaderText="Detail Items">
                <ItemTemplate>
                    <asp:GridView ID="gvItemDetail" runat="server" AutoGenerateColumns="False" 
                        Height="29px" Width="386px" AllowPaging="True" AllowSorting="True" 
                        onpageindexchanging="gvItemDetail_PageIndexChanging" 
                         PageSize="5" CellPadding="3" BackColor="White" BorderColor="White" 
                        BorderStyle="Ridge" BorderWidth="2px" CellSpacing="1" GridLines="None">
                        <Columns>
                            <asp:BoundField DataField="Item_Code" HeaderText="Item Code">
                                <ItemStyle BorderColor="White" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Description" HeaderText="Item Name">
                                <ItemStyle BorderColor="White" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Requested_Qty" HeaderText="Requested Qty">
                                <ItemStyle BorderColor="White" />
                            </asp:BoundField>
                        </Columns>
                        <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                        <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#E7E7FF" />
                        <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
                        <RowStyle ForeColor="Black" BackColor="#DEDFDE" />
                        <SelectedRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
                        <sortedascendingcellstyle backcolor="#F1F1F1" />
                        <sortedascendingheaderstyle backcolor="#0000A9" />
                        <sorteddescendingcellstyle backcolor="#CAC9C9" />
                        <sorteddescendingheaderstyle backcolor="#000065" />
                        <sortedascendingcellstyle backcolor="#FDF5AC" />
                        <sortedascendingheaderstyle backcolor="#4D0000" />
                        <sorteddescendingcellstyle backcolor="#FCF6C0" />
                        <sorteddescendingheaderstyle backcolor="#820000" />
                        <sortedascendingcellstyle backcolor="#FEFCEB" />
                        <sortedascendingheaderstyle backcolor="#AF0101" />
                        <sorteddescendingcellstyle backcolor="#F6F0C0" />
                        <sorteddescendingheaderstyle backcolor="#7E0000" />
                        <sortedascendingcellstyle backcolor="#F1F1F1" />
                        <sortedascendingheaderstyle backcolor="#007DBB" />
                        <sorteddescendingcellstyle backcolor="#CAC9C9" />
                        <sorteddescendingheaderstyle backcolor="#00547E" />
                        <sortedascendingcellstyle backcolor="#F1F1F1" />
                        <sortedascendingheaderstyle backcolor="#007DBB" />
                        <sorteddescendingcellstyle backcolor="#CAC9C9" />
                        <sorteddescendingheaderstyle backcolor="#00547E" />
                        <sortedascendingcellstyle backcolor="#F1F1F1" />
                        <sortedascendingheaderstyle backcolor="#594B9C" />
                        <sorteddescendingcellstyle backcolor="#CAC9C9" />
                        <sorteddescendingheaderstyle backcolor="#33276A" />
                    </asp:GridView>
                </ItemTemplate>
                <ItemStyle BorderStyle="Solid" />
            </asp:TemplateField>
            <asp:BoundField DataField="Requested_Date" HeaderText="Requested Date"  DataFormatString="{0:MMMM d, yyyy}" HtmlEncode="False">
                <ItemStyle BorderStyle="Solid" />
            </asp:BoundField>
            <asp:BoundField DataField="Status" HeaderText="Status">
                <ItemStyle BorderStyle="Solid" />
            </asp:BoundField>
            <asp:BoundField DataField="EmployeeID" HeaderText="Employee ID" Visible="False">
            </asp:BoundField>
        </Columns>
        <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
        <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
        <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
        <RowStyle BackColor="White" BorderStyle="Solid" ForeColor="#003399" />
        <selectedrowstyle backcolor="#009999"
         forecolor="#CCFF99"
         font-bold="true"/> 

<SortedAscendingCellStyle BackColor="#EDF6F6"></SortedAscendingCellStyle>

<SortedAscendingHeaderStyle BackColor="#0D4AC4"></SortedAscendingHeaderStyle>

<SortedDescendingCellStyle BackColor="#D6DFDF"></SortedDescendingCellStyle>

<SortedDescendingHeaderStyle BackColor="#002876"></SortedDescendingHeaderStyle>
    </asp:GridView>
    </div>
            <div align="center">
    <table align="center" >
       
        <tr>
            <td align="left">
                <asp:Button ID="btnSelectAll" 
            runat="server" Text="Select All" 
           CausesValidation="False" Width="96px" onclick="btnSelectAll_Click" />  
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

                <asp:Label ID="lblMessage" runat="server" ForeColor="#990000"></asp:Label>
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
                    Font-Names="Century Gothic" Font-Size="10pt" ShowMessageBox="True" 
                    ShowSummary="False" Height="5px" ForeColor="MediumBlue" 
                Width="206px" >
            </asp:ValidationSummary><br />
                </td>
            
        </tr>
      
        <tr>
            <td align="left" class="style4">

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;
                <asp:Label ID="lblRejectInfo" runat="server" Text="Remarks for your action"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="txtRejectInfo" runat="server" Height="42px" 
                    TextMode="MultiLine" Width="181px" BackColor="#FFFFCC"></asp:TextBox>
            </td>        
            </tr>

         <tr>
            <td align="center"  >

                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button 
                    ID="btnApprove" runat="server" Text="Approve" 
                    onclick="btnApprove_Click" Height="25px" Width="88px" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnReject" runat="server" Text="Reject" 
                    onclick="btnReject_Click" Height="27px" Width="89px" 
                    />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

                </td>
              
        </tr>

       <asp:TextBox ID="txtEvent" runat="server" Visible="False"></asp:TextBox>
    <asp:TextBox ID="txtRequestID" runat="server" Visible="False"></asp:TextBox>
  
 </table>
 </div>
</asp:Content>


