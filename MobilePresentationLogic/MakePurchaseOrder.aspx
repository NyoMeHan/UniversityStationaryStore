<%@ Page Title="" Language="C#" MasterPageFile="~/Store_Master.Master" AutoEventWireup="true" CodeBehind="MakePurchaseOrder.aspx.cs" Inherits="MobilePresentationLogic.MakePurchaseOrder" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
 <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style2
        {
         width: 1385px;
     }
        .style3
        {
         width: 1385px;
         height: 33px;
     }
        .style8
        {
            width: 251px;
        }
        .style9
        {
         width: 302px;
         height: 33px;
     }
        .style10
        {
         width: 302px;
     }
        .style11
        {
         height: 33px;
         width: 360px;
     }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<h3 align="center"> Make Purchase Order</h3>
  <table style="width: 609px" >

        <!--Supplier Name !-->
        <tr>
            <td class="style3">
                <asp:Label ID="lblRequestDeliveryDate" runat="server" 
                    Text="Request Delivery Date"></asp:Label>
            </td>
            <td class="style9">
                <asp:TextBox ID="txtRequestDeliveryDate" runat="server" Enabled="true" 
                    TextMode="SingleLine" MaxLength="10"></asp:TextBox>
                <asp:ImageButton ID="imgbtnCalendar" runat="server" Height="22px" 
                    ImageUrl="~/Images/calendar.png" Width="21px" 
                    onclick="imgbtnCalendar_Click" />
                <asp:Calendar ID="CalendarDelReqDate" runat="server" Visible="False" 
                    onselectionchanged="CalendarDelReqDate_SelectionChanged" Height="16px" 
                    Width="16px"></asp:Calendar>
            </td>
            <td class="style11">
                &nbsp;</td>
        </tr>

        <tr>
            <td class="style3">
                <asp:Label ID="lblSupplierName" runat="server" Text="Supplier Name"></asp:Label>
            </td>
            <td class="style9">
                <asp:DropDownList ID="ddlSupplierList" runat="server" Width="300px" 
                    AppendDataBoundItems="True" Height="20px" 
                    onselectedindexchanged="ddlSupplierList_SelectedIndexChanged" >

                </asp:DropDownList>
            </td>
            <td class="style11">
                <asp:Button ID="btnChangeSupplier" runat="server" Text="Change Supplier" 
                    onclick="btnChangeSupplier_Click" />
                </td>
        </tr>

        <!--Item Name !-->

        <tr>
            <td class="style3">
                <asp:Label ID="lblCategoryName" runat="server" Text="Category"></asp:Label>
            </td>
            <td class="style9">
                <asp:DropDownList ID="ddlCategoryList" runat="server" AutoPostBack="true" Width="300px" 
                    AppendDataBoundItems="True" Height="20px" 
                    onselectedindexchanged="ddlCategoryList_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
            <td class="style11">
                &nbsp;</td>
        </tr>

        <tr>
            <td class="style2">
                <asp:Label ID="lblItemName" runat="server" Text="Item Name"></asp:Label>
            </td>
            <td class="style10">
                <asp:DropDownList ID="ddlItemList" runat="server" AutoPostBack="true" Width="300px" 
                AppendDataBoundItems="true" Height="20px" 
                    onselectedindexchanged="ddlItemList_SelectedIndexChanged">
                   
                  
                </asp:DropDownList>
            </td>
        </tr>

        <!--Quantity !-->
        <tr>
            <td class="style2">
                <asp:Label ID="lblQty" runat="server" Text="Quantity"></asp:Label>
            </td>
            <td class="style10">
                <asp:TextBox ID="txtQty" runat="server" Width="92px" Enabled="False"></asp:TextBox>
                <asp:Label ID="lblUOM" runat="server" Text="uom" Visible="False"></asp:Label>
            </td>
        </tr>


        <!--Add Button !-->
        <tr>
            <td class="style2">
                &nbsp;</td>
            <td class="style10">
                <asp:Button ID="btnAddItem" runat="server" Text="Add" 
                    onclick="btnAddItem_Click" Height="38px" Width="60px" />
            </td>
        </tr>
    </table>

    <!--Purchase Order GridView !-->
    <asp:GridView ID="gvPurchaseOrder" runat="server" Width="595px" 
        BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" 
        CellPadding="4" >
        <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
        <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
        <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
        <RowStyle BackColor="White" ForeColor="#003399" />
        <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
        <sortedascendingcellstyle backcolor="#EDF6F6" />
        <sortedascendingheaderstyle backcolor="#0D4AC4" />
        <sorteddescendingcellstyle backcolor="#D6DFDF" />
        <sorteddescendingheaderstyle backcolor="#002876" />

    </asp:GridView>


    <table class="style1">
        
         <!--Request Delivery Date !-->
        <tr>
          
            <td class="style8">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnSubmit" runat="server" Text="Place Order" Enabled="False" 
                    onclick="btnSubmit_Click" />
            </td>
            <td>
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" Width="88px" />
            </td>
        </tr>
    </table>
    <p>
        &nbsp;</p>
    <p>
        <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
    </p>

</asp:Content>
