<%@ Page Title="" Language="C#" MasterPageFile="~/Dept.Master" AutoEventWireup="true" Inherits="LogicUniversityWebLogic.Employee_Requisition" Codebehind="Employee_Requisition.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
 </asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<link href="Styles/btnStyle.css"  rel="Stylesheet"/>
   <h3>Stationery Requisition</h3>
    <br />
   
        <div>
    <div align="left" >
      
      
    </div>
    
  	<div style="height:400px; width: 715px;">
    
    <table style="width: 100%; margin-top: 0px; height: 153px;">
    <tr><td>
        <asp:Button ID="btnAddNew" 
            runat="server" Text="Make Requisition" 
            onclick="btnAddNew_Click" CausesValidation="False" Width="129px" 
CssClass="button"/></td></tr>
        <tr> <td>
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
                    Font-Names="Century Gothic" Font-Size="10pt" ShowMessageBox="True" 
                    ShowSummary="False" Height="16px" ForeColor="MediumBlue" Width="200px" >
            </asp:ValidationSummary>
           
            <br />
            </td>
            <td> <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label> </td>
            </tr>
        <tr>
            <td align="left" >
                <asp:Label ID="lblSelectCategory" runat="server" Text=" Select Category"></asp:Label>
            </td>
            <td align="left">
                <asp:DropDownList ID="ddlCategory" runat="server" Height="29px" Width="190px" 
                    AutoPostBack="True" onselectedindexchanged="ddlCategory_SelectedIndexChanged" 
                    >
                </asp:DropDownList>
                  <asp:RequiredFieldValidator ID="reqCategory" runat="server" ErrorMessage="Choose Category" 
                    ForeColor="Red" Font-Size="9pt" ControlToValidate="ddlCategory" Height="20px" Font-Names="Verdana" >*</asp:RequiredFieldValidator>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="txtRequestedDate" runat="server" Enabled="False" 
                    Visible="False"></asp:TextBox>
            </td>

        </tr>
        <tr>
            <td align="left">
                <asp:Label ID="lblItemName" runat="server" Text="Item Name"></asp:Label>

               </td>
            <td align="left" >
                
                <asp:DropDownList ID="ddlItem" runat="server" Height="21px" 
                    Width="190px" AutoPostBack="True">
                    <asp:ListItem></asp:ListItem>
                </asp:DropDownList>
                  <asp:RequiredFieldValidator ID="reqItem" runat="server" ErrorMessage="Choose one item" 
                    ForeColor="Red" Font-Size="9pt" ControlToValidate="ddlItem" Height="20px" Font-Names="Verdana" >*</asp:RequiredFieldValidator>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    
                     &nbsp;&nbsp;
                     <asp:TextBox ID="txtTotalQty" runat="server" Enabled="False" 
                    Visible="False">0</asp:TextBox>
                    
            </td>

        </tr>
        <tr>
            <td align="left">

                <asp:Label ID="lblQuantity" runat="server" Text="Quantity"></asp:Label>
              </td>
                <td align="left">
                
                    <asp:TextBox ID="txtQty" runat="server" Width="91px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="reqQuantity" runat="server" ErrorMessage="Quantity can't be blank" 
                    ForeColor="Red" Font-Size="9pt" ControlToValidate="txtQty" Height="20px" 
                        Font-Names="Verdana" Width="16px" >*</asp:RequiredFieldValidator>
                    <asp:RangeValidator ID="rvQty" runat="server" ControlToValidate="txtQty" 
                        ErrorMessage="Quantity must be number and greater than 0." Font-Names="Verdana" 
                        Font-Size="9pt" ForeColor="Red" Height="20px" MaximumValue="999999999.99" 
                        MinimumValue="0.01" Width="1px">*</asp:RangeValidator>
                
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="txtStatus" runat="server" Enabled="False" Visible="False"></asp:TextBox>
                
                </td>
        </tr>
         <tr>
            <td align="left" >

                <asp:Button ID="btnAddItem" runat="server" Text="Add New Item" 
                    style="margin-top: 25px" onclick="btnAddItem_Click" 
CssClass="button"/>

                 </td>
                 <td align="left">
                    
                 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                     <asp:TextBox ID="txtDeptName" runat="server" Enabled="False" Width="174px" 
                         Visible="False"></asp:TextBox>
                    
                 </td>
        </tr>

    </table>
         <div align="left" style="height: 161px; width: 708px">
             &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
             <asp:GridView ID="gvRequestDetail" runat="server" AutoGenerateColumns="False" 
                BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" 
                CellPadding="3" Height="16px" Width="709px" 
                 style="margin-top: 0px; margin-left: 0px;" PageSize="5" AllowPaging="True" 
                 ShowHeaderWhenEmpty="True" EmptyDataText="No Records Found" 
                 onpageindexchanging="gvRequestDetail_PageIndexChanging" 
                 onrowdeleting="gvRequestDetail_RowDeleting" 
                 onrowupdating="gvRequestDetail_RowUpdating" ForeColor="Black" 
                 GridLines="Vertical" >
                <sortedascendingcellstyle backcolor="#F1F1F1" />
                <sortedascendingheaderstyle backcolor="#808080" />
                <sorteddescendingcellstyle backcolor="#CAC9C9" />
                <sorteddescendingheaderstyle backcolor="#383838" />
                 <AlternatingRowStyle BackColor="#CCCCCC" />
                 <Columns>
                     <asp:BoundField DataField="Emp_Req_DetailID" HeaderText="Emp_Req_DetailID" 
                         Visible="False">
                         <ItemStyle BorderStyle="Solid" />
                     </asp:BoundField>
                     <asp:BoundField DataField="Emp_ReqID" HeaderText="Emp_ReqID" Visible="False" 
                         ReadOnly="True">
                         <ItemStyle BorderStyle="Solid" />
                     </asp:BoundField>
                     <asp:BoundField DataField="Category_Name" HeaderText="Category">
                         <ItemStyle BorderStyle="Solid" />
                     </asp:BoundField>
                     <asp:BoundField DataField="Item_Code" HeaderText="Item Code">
                         <ItemStyle BorderStyle="Solid" />
                     </asp:BoundField>
                     <asp:BoundField DataField="Description" HeaderText="Item Description">
                         <ItemStyle BorderStyle="Solid" />
                     </asp:BoundField>
                     <asp:BoundField DataField="Requested_Qty" HeaderText="Requested Qty" 
                         Visible="False">
                         <ItemStyle BorderStyle="Solid" />
                     </asp:BoundField>
                     <asp:TemplateField HeaderText="Requested Qty">
                         <ItemTemplate>
                             <asp:TextBox ID="txtReqQtyupdate" runat="server" 
                                 Text='<%# Bind("Requested_Qty") %>' Enabled="False" 
                                ></asp:TextBox>
                         </ItemTemplate>
                         <ItemStyle BorderStyle="Solid" />
                     </asp:TemplateField>
                     <asp:TemplateField HeaderText="Actions">
                         <ItemTemplate>
                             <asp:ImageButton ID="imgBtnUpdate" runat="server" CommandName="Update" 
                                 ImageUrl="~/Images/Edit.gif" CausesValidation="False" />
                             <asp:ImageButton ID="imgBtnDelete" runat="server" CommandName="Delete" 
                                 ImageUrl="~/Images/Delete.gif" CausesValidation="False" />
                         </ItemTemplate>
                         <ItemStyle BorderStyle="Solid" />
                     </asp:TemplateField>
                 </Columns>
                <FooterStyle BackColor="#CCCCCC" />
                <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />

        <SortedAscendingCellStyle BackColor="#EDF6F6"></SortedAscendingCellStyle>

        <SortedAscendingHeaderStyle BackColor="#0D4AC4"></SortedAscendingHeaderStyle>

        <SortedDescendingCellStyle BackColor="#D6DFDF"></SortedDescendingCellStyle>

        <SortedDescendingHeaderStyle BackColor="#002876"></SortedDescendingHeaderStyle>
            </asp:GridView>

        </div>
        <br />
        <asp:Button ID="btnSubmit" runat="server" Text="Submit" 
            onclick="btnSubmit_Click" CausesValidation="False" 
CssClass="button" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnCancel" runat="server" Text="Cancel" 
            onclick="btnCancel_Click" style="height: 26px" CausesValidation="False" 
CssClass="button"/>
        <br /> <br /> <br />
    </div>
    <br />
            &nbsp;&nbsp;
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />
    <br />
    <br />
    <br />
    <asp:TextBox ID="txtEvent" runat="server" Visible="False"></asp:TextBox>
    <asp:TextBox ID="txtRequestID" runat="server" Visible="False"></asp:TextBox>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox 
        ID="txtDeptCode" runat="server" Visible="False"></asp:TextBox>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <br />

</div>

<div>
 <asp:GridView ID="gvRequestHeader" runat="server" AllowPaging="True" 
        AutoGenerateColumns="False" Height="16px" Width="693px" AllowSorting="True" 
    onrowcommand="gvRequestHeader_RowCommand" CellPadding="3" PageSize="7" 
        BackColor="White" BorderColor="#999999" BorderStyle="Solid" 
        BorderWidth="1px" onpageindexchanging="gvRequestHeader_PageIndexChanging" 
        EmptyDataText="No Records Found" ShowHeaderWhenEmpty="True" 
        onrowdeleting="gvRequestHeader_RowDeleting" DataKeyNames="Requested_Date" 
        ForeColor="Black" GridLines="Vertical">
        <AlternatingRowStyle BackColor="#CCCCCC" />
        <Columns>
            <asp:BoundField DataField="Emp_ReqID" HeaderText="Request ID">
                <ItemStyle BorderStyle="Solid" />
            </asp:BoundField>
            <asp:BoundField DataField="EmployeeName" HeaderText="Employee Name">
                <ItemStyle BorderStyle="Solid" />
            </asp:BoundField>
            <asp:BoundField DataField="Requested_Date" HeaderText="Requested Date" 
                DataFormatString="{0:MMMM d, yyyy}" HtmlEncode="False">
                <ItemStyle BorderStyle="Solid" />
            </asp:BoundField>
            <asp:BoundField DataField="Status" HeaderText="Status">
                <ItemStyle BorderStyle="Solid" />
            </asp:BoundField>
            <asp:BoundField DataField="TotalRequested_Qty" HeaderText="Total Requested Qty" 
                Visible="False">
                <ItemStyle BorderStyle="Solid" />
            </asp:BoundField>
            <asp:BoundField DataField="Department_Name" HeaderText="Department Name">
                <ItemStyle BorderStyle="Solid" />
            </asp:BoundField>
            <asp:CommandField ButtonType="Image" HeaderText="Action" 
                SelectImageUrl="~/Images/Select.gif" SelectText="" ShowSelectButton="True" 
                DeleteImageUrl="~/Images/Delete.gif" ShowDeleteButton="True">
                <ItemStyle BorderStyle="Solid" />
            </asp:CommandField>
            <asp:BoundField DataField="Department_Code" HeaderText="Dept_Code" 
                Visible="False"></asp:BoundField>
        </Columns>
        <FooterStyle BackColor="#CCCCCC" />
        <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
        <RowStyle BorderStyle="Solid" />
        <selectedrowstyle backcolor="#000099"
         forecolor="White"
         font-bold="true"/> 
        <sortedascendingcellstyle backcolor="#F1F1F1" />
        <sortedascendingheaderstyle backcolor="#808080" />
        <sorteddescendingcellstyle backcolor="#CAC9C9" />
        <sorteddescendingheaderstyle backcolor="#383838" />

<SortedAscendingCellStyle BackColor="#EDF6F6"></SortedAscendingCellStyle>

<SortedAscendingHeaderStyle BackColor="#0D4AC4"></SortedAscendingHeaderStyle>

<SortedDescendingCellStyle BackColor="#D6DFDF"></SortedDescendingCellStyle>

<SortedDescendingHeaderStyle BackColor="#002876"></SortedDescendingHeaderStyle>
    </asp:GridView>
</div>
</asp:Content>

