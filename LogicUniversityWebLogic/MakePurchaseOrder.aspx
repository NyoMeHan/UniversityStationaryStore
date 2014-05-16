<%@ Page Title="" Language="C#" MasterPageFile="~/Store.Master" AutoEventWireup="true" CodeBehind="MakePurchaseOrder.aspx.cs" Inherits="LogicUniversityWebLogic.MakePurchaseOrder" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
 <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style2
        {
            width: 242px;
        }
        .style3
        {
            width: 242px;
            height: 33px;
        }
        .style5
        {
            width: 299px;
        }
        .style8
        {
            width: 251px;
        }
        .style9
        {
            width: 292px;
            height: 33px;
        }
        .style10
        {
            width: 292px;
        }
        .style11
        {
            height: 33px;
            width: 333px;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<link href="Styles/btnStyle.css"  rel="Stylesheet"/>
  <table class="style1">

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
            </td>
            <td class="style11">
                <asp:Calendar ID="CalendarDelReqDate" runat="server" Visible="False" 
                    onselectionchanged="CalendarDelReqDate_SelectionChanged" Height="116px" 
                    Width="154px"></asp:Calendar>
            </td>
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
                &nbsp;</td>
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
                    onclick="btnAddItem_Click"  CssClass="button"/>
            </td>
        </tr>
    </table>

    <!--Purchase Order GridView !-->
    <asp:GridView ID="gvPurchaseOrder" runat="server" Width="1055px" 
        BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" 
        CellPadding="3" ForeColor="Black" GridLines="Vertical" >
        <AlternatingRowStyle BackColor="#CCCCCC" />
        <FooterStyle BackColor="#CCCCCC" />
        <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F1F1F1" />
        <SortedAscendingHeaderStyle BackColor="#808080" />
        <SortedDescendingCellStyle BackColor="#CAC9C9" />
        <SortedDescendingHeaderStyle BackColor="#383838" />

    </asp:GridView>


    <table class="style1">
        
         <!--Request Delivery Date !-->
        <tr>
            <td class="style5">
                &nbsp;</td>
            <td class="style8">
                <asp:Button ID="btnSubmit" runat="server" Text="Place Order" Enabled="False" 
                    onclick="btnSubmit_Click" 
CssClass="button"/>
            </td>
            <td>
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="button"/>
            </td>
        </tr>
    </table>
    <p>
        &nbsp;</p>
    <p>
        <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
    </p>

</asp:Content>
