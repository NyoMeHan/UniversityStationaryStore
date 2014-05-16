<%@ Page Title="" Language="C#" MasterPageFile="~/Department_Master.Master" AutoEventWireup="true" Inherits="MobilePresentationLogic.Employee_Requisition" Codebehind="Employee_Requisition.aspx.cs" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div style="width: 568px; margin-right: 0px; height: 1584px;">
    <h3 align="center">Stationery Requisition</h3>
    <asp:ScriptManager EnablePartialRendering="true" ID="ScriptManager1" runat="server"></asp:ScriptManager>
   
    <br />
        
    <div align="left" >
    <asp:Button ID="btnAddNew" 
            runat="server" Text="Make Requisition" 
            onclick="btnAddNew_Click" CausesValidation="False" Width="164px" 
            Height="33px" />  
      
    </div>
    
  	<div style="height:656px; width: 508px;" align="center" dir="ltr">
    
    <table style="width: 72%; margin-top: 0px; height: 164px;">
        <tr> <td class="style2">
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
                    Font-Names="Century Gothic" Font-Size="10pt" ShowMessageBox="True" 
                    ShowSummary="False" Height="16px" ForeColor="MediumBlue" Width="200px" >
            </asp:ValidationSummary>
           
            <br />
            </td>
            <td class="style2"> <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label> </td>
            </tr>
        <tr>
            <td align="left" class="style3" >
                <asp:Label ID="lblSelectCategory" runat="server" Text=" Select Category"></asp:Label>
            </td>
            <td align="left" class="style3">
                <asp:DropDownList ID="ddlCategory" runat="server" Height="39px" Width="190px" 
                    AutoPostBack="True" onselectedindexchanged="ddlCategory_SelectedIndexChanged" 
                    >
                </asp:DropDownList>
                  <asp:RequiredFieldValidator ID="reqCategory" runat="server" ErrorMessage="Choose Category" 
                    ForeColor="Red" Font-Size="9pt" ControlToValidate="ddlCategory" Height="20px" Font-Names="Verdana" >*</asp:RequiredFieldValidator>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                </td>

        </tr>
        <tr>
            <td align="left">
                <asp:Label ID="lblItemName" runat="server" Text="Item Name"></asp:Label>

               </td>
            <td align="left" >
                
                <asp:DropDownList ID="ddlItem" runat="server" Height="40px" 
                    Width="190px" AutoPostBack="True">
                    <asp:ListItem></asp:ListItem>
                </asp:DropDownList>
                  <asp:RequiredFieldValidator ID="reqItem" runat="server" ErrorMessage="Choose one item" 
                    ForeColor="Red" Font-Size="9pt" ControlToValidate="ddlItem" Height="20px" Font-Names="Verdana" >*</asp:RequiredFieldValidator>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    
                     &nbsp;&nbsp;
                                         
            </td>

        </tr>
        <tr>
            <td align="left">

                <asp:Label ID="lblQuantity" runat="server" Text="Quantity"></asp:Label>
              </td>
                <td align="left">
                
                    <br />
                
                    <asp:TextBox ID="txtQty" runat="server" Width="154px" Height="30px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="reqQuantity" runat="server" ErrorMessage="Quantity can't be blank" 
                    ForeColor="Red" Font-Size="9pt" ControlToValidate="txtQty" Height="20px" 
                        Font-Names="Verdana" Width="16px" >*</asp:RequiredFieldValidator>
                    <asp:RangeValidator ID="rvQty" runat="server" ControlToValidate="txtQty" 
                        ErrorMessage="Quantity must be number and greater than 0." Font-Names="Verdana" 
                        Font-Size="9pt" ForeColor="Red" Height="20px" MaximumValue="999999999.99" 
                        MinimumValue="0.01" Width="1px">*</asp:RangeValidator>
                
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp;&nbsp;&nbsp;&nbsp;
                                    
                </td>
        </tr>
         <tr>
            <td align="left" class="style6" >

                <asp:Button ID="btnAddItem" runat="server" Text="Add Item" 
                    style="margin-top: 25px" onclick="btnAddItem_Click" Height="29px" />

                 </td>
                 <td align="left" class="style6">
                    
                 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                     <asp:TextBox ID="txtDeptName" runat="server" Enabled="False" Width="174px" 
                         Visible="False"></asp:TextBox>
                    
                 </td>
        </tr>

    </table>
          
             <br />
        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>
                &nbsp;<asp:GridView ID="gvRequestDetail" runat="server" AllowPaging="True" 
                    AutoGenerateColumns="False" BackColor="White" BorderColor="#3366CC" 
                    BorderStyle="None" BorderWidth="1px" CellPadding="4" 
                    EmptyDataText="No Records Found" Height="16px" 
                    onpageindexchanging="gvRequestDetail_PageIndexChanging" 
                    onrowdeleting="gvRequestDetail_RowDeleting" 
                    onrowupdating="gvRequestDetail_RowUpdating" PageSize="5" 
                    ShowHeaderWhenEmpty="True" style="margin-top: 0px; margin-left: 0px;" 
                    Width="565px">
                    <sortedascendingcellstyle backcolor="#FEFCEB" />
                    <sortedascendingheaderstyle backcolor="#AF0101" />
                    <sorteddescendingcellstyle backcolor="#F6F0C0" />
                    <sorteddescendingheaderstyle backcolor="#7E0000" />
                    <Columns>
                        <asp:BoundField DataField="Emp_Req_DetailID" HeaderText="Emp_Req_DetailID" 
                            Visible="False">
                            <ItemStyle BorderStyle="Solid" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Emp_ReqID" HeaderText="Emp_ReqID" ReadOnly="True" 
                            Visible="False">
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
                                <asp:TextBox ID="txtReqQtyupdate" runat="server" Enabled="False" 
                                    Text='<%# Bind("Requested_Qty") %>' Height="29px"></asp:TextBox>
                            </ItemTemplate>
                            <ItemStyle BorderStyle="Solid" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Actions">
                            <ItemTemplate>
                                <asp:Button ID="btnEdit" runat="server" CommandName="Update" Text="Edit" 
                                    Width="62px" CausesValidation="False" />
                                &nbsp;<asp:Button ID="btnDelete" runat="server" CommandName="Delete" 
                                    Text="Delete" CausesValidation="False" Width="66px" Height="25px" />
                            </ItemTemplate>
                            <ItemStyle BorderStyle="Solid" />
                        </asp:TemplateField>
                    </Columns>
                    <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                    <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                    <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                    <RowStyle BackColor="White" ForeColor="#003399" />
                    <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                    <sortedascendingcellstyle backcolor="#EDF6F6" />
                    <sortedascendingheaderstyle backcolor="#0D4AC4" />
                    <sorteddescendingcellstyle backcolor="#D6DFDF" />
                    <sorteddescendingheaderstyle backcolor="#002876" />
                    <sortedascendingcellstyle backcolor="#EDF6F6" />
                    <sortedascendingheaderstyle backcolor="#0D4AC4" />
                    <sorteddescendingcellstyle backcolor="#D6DFDF" />
                    <sorteddescendingheaderstyle backcolor="#002876" />
                    <sortedascendingcellstyle backcolor="#EDF6F6" />
                    <sortedascendingheaderstyle backcolor="#0D4AC4" />
                    <sorteddescendingcellstyle backcolor="#D6DFDF" />
                    <sorteddescendingheaderstyle backcolor="#002876" />
                    <sortedascendingcellstyle backcolor="#EDF6F6" />
                    <sortedascendingheaderstyle backcolor="#0D4AC4" />
                    <sorteddescendingcellstyle backcolor="#D6DFDF" />
                    <sorteddescendingheaderstyle backcolor="#002876" />
                    <sortedascendingcellstyle backcolor="#EDF6F6" />
                    <sortedascendingheaderstyle backcolor="#0D4AC4" />
                    <sorteddescendingcellstyle backcolor="#D6DFDF" />
                    <sorteddescendingheaderstyle backcolor="#002876" />
                </asp:GridView>
                <br />
                <br />
                <asp:Button ID="btnSubmit" runat="server" CausesValidation="False" 
                    onclick="btnSubmit_Click" Text="Submit" Height="38px" Width="173px" />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnCancel" runat="server" CausesValidation="False" 
                    onclick="btnCancel_Click" Text="Cancel" Height="38px" 
                    Width="173px" />
            </ContentTemplate>
        </asp:UpdatePanel>
        <br />
            <asp:TextBox ID="txtEvent" runat="server" Visible="False" Width="78px"></asp:TextBox>
    <asp:TextBox ID="txtRequestID" runat="server" Visible="False" Width="75px"></asp:TextBox>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox 
        ID="txtDeptCode" runat="server" Visible="False" Width="50px"></asp:TextBox>
                <asp:TextBox ID="txtRequestedDate" runat="server" Enabled="False" 
                    Visible="False" Width="100px"></asp:TextBox>
                     <asp:TextBox ID="txtTotalQty" runat="server" Enabled="False" 
                    Visible="False" Width="58px">0</asp:TextBox>
                    
                    <asp:TextBox ID="txtStatus" runat="server" Enabled="False" 
            Visible="False" Width="139px"></asp:TextBox>
                
        <br />
    </div>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:GridView ID="gvRequestHeader" runat="server" AllowPaging="True" 
                AllowSorting="True" AutoGenerateColumns="False" BackColor="White" 
                BorderColor="#3366CC" BorderWidth="1px" CellPadding="4" 
                DataKeyNames="Requested_Date" EmptyDataText="No Records Found" Height="16px" 
                onpageindexchanging="gvRequestHeader_PageIndexChanging" 
                onrowcommand="gvRequestHeader_RowCommand" 
                onrowdeleting="gvRequestHeader_RowDeleting" PageSize="7" 
                ShowHeaderWhenEmpty="True" Width="558px">
                <Columns>
                    <asp:BoundField DataField="Emp_ReqID" HeaderText="Request ID">
                        <ItemStyle BorderStyle="Solid" />
                    </asp:BoundField>
                    <asp:BoundField DataField="EmployeeName" HeaderText="Employee Name">
                        <ItemStyle BorderStyle="Solid" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Requested_Date" DataFormatString="{0:MMMM d, yyyy}" 
                        HeaderText="Requested Date" HtmlEncode="False">
                        <ItemStyle BorderStyle="Solid" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Status" HeaderText="Status">
                        <ItemStyle BorderStyle="Solid" />
                    </asp:BoundField>
                    <asp:BoundField DataField="TotalRequested_Qty" HeaderText="Total Requested Qty" 
                        Visible="False">
                        <ItemStyle BorderStyle="Solid" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Department_Name" HeaderText="Department Name" 
                        Visible="False">
                        <ItemStyle BorderStyle="Solid" />
                    </asp:BoundField>
                    <asp:CommandField ButtonType="Button" HeaderText="Action" 
                        ShowDeleteButton="True" ShowSelectButton="True">
                        <ItemStyle BorderStyle="Solid" HorizontalAlign="Center" />
                    </asp:CommandField>
                    <asp:BoundField DataField="Department_Code" HeaderText="Dept_Code" 
                        Visible="False"></asp:BoundField>
                </Columns>
                <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                <RowStyle BackColor="White" ForeColor="#003399" />
                <selectedrowstyle backcolor="#009999" font-bold="true" forecolor="#CCFF99" />
        <sortedascendingcellstyle backcolor="#E9E7E2" />
        <sortedascendingheaderstyle backcolor="#506C8C" />
        <sorteddescendingcellstyle backcolor="#FFFDF8" />
        <sorteddescendingheaderstyle backcolor="#6F8DAE" />

                <sortedascendingcellstyle backcolor="#EDF6F6" />
                <sortedascendingheaderstyle backcolor="#0D4AC4" />
                <sorteddescendingcellstyle backcolor="#D6DFDF" />
                <sorteddescendingheaderstyle backcolor="#002876" />
                <sortedascendingcellstyle backcolor="#EDF6F6" />
                <sortedascendingheaderstyle backcolor="#0D4AC4" />
                <sorteddescendingcellstyle backcolor="#D6DFDF" />
                <sorteddescendingheaderstyle backcolor="#002876" />
                <sortedascendingcellstyle backcolor="#EDF6F6" />
                <sortedascendingheaderstyle backcolor="#0D4AC4" />
                <sorteddescendingcellstyle backcolor="#D6DFDF" />
                <sorteddescendingheaderstyle backcolor="#002876" />
            </asp:GridView>
            <br />
            <br />
            <br />
        </ContentTemplate>
</asp:UpdatePanel>


</div>
</asp:Content>



