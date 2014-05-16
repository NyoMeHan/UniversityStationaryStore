<%@ Page Title="" Language="C#" MasterPageFile="~/Store_Master.Master" AutoEventWireup="true" CodeBehind="StoreDeliveryRecords.aspx.cs" Inherits="MobilePresentationLogic.StoreDeliveryRecords" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

 <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style2
        {
            width: 180px;
        }
        .style3
        {
            width: 412px;
        }
        .style4
        {
            width: 155px;
        }
        .style5
        {
            width: 414px;
        }
        .style6
        {
            width: 190px;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<h3 align="center"> Store Delivery Records</h3>
    <table class="style1">
            <tr>
                <td class="style2">
                    <asp:Label ID="lblDeliveredDate" runat="server" Text="Delivered Date"></asp:Label>
                </td>
                <td class="style3">
                    <asp:TextBox ID="txtDeliveredDate" runat="server"></asp:TextBox>
                    <asp:ImageButton ID="imgbtnCalendar" runat="server" Height="22px" 
                        ImageUrl="~/Images/calendar.png" Width="21px" 
                        onclick="imgbtnCalendar_Click" />
                </td>
                <td>
                    <asp:Calendar ID="CalendarDeliveredDate" runat="server" 
                        onselectionchanged="CalendarDeliveredDate_SelectionChanged" Visible="False"></asp:Calendar>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    &nbsp;</td>
                <td class="style3">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style2">
                    <asp:Label ID="lblPONumber" runat="server" Text="PO No"></asp:Label>
                </td>
                <td class="style3">
                    <asp:DropDownList ID="ddlPONumber" runat="server" AutoPostBack="true"
                        onselectedindexchanged="ddlPONumber_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style2">
                    &nbsp;</td>
                <td class="style3">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            </table>
    
    <table class="style1">
        <tr>
            <td class="style4">
                <asp:Label ID="lblOrderBy" runat="server" Text="Order By"></asp:Label>
            </td>
            <td class="style5">
                <asp:TextBox ID="txtOrderBy" runat="server"></asp:TextBox>
            </td>
            <td class="style6">
                <asp:Label ID="lblOrderDate" runat="server" Text="Order Date"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtOrderDate" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style4">
                <asp:Label ID="lblSupplierName" runat="server" Text="Supplier"></asp:Label>
            </td>
            <td class="style5">
                <asp:TextBox ID="txtSupplierName" runat="server"></asp:TextBox>
            </td>
            <td class="style6">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style4">
                <asp:Label ID="lblRecievedBy" runat="server" Text="Received By"></asp:Label>
            </td>
            <td class="style5">
                <asp:TextBox ID="txtRecievedBy" runat="server"></asp:TextBox>
            </td>
            <td class="style6">
                    <asp:Label ID="lblDeliveryRefNo" runat="server" Text="Delivery Ref No"></asp:Label>
                </td>
            <td>
                    <asp:TextBox ID="txtDeliveryRefNo" runat="server"></asp:TextBox>
                </td>
        </tr>
        <tr>
            <td class="style4">
                &nbsp;</td>
            <td class="style5">
                &nbsp;</td>
            <td class="style6">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
    <p>
        &nbsp;</p>
    <p>
        <asp:GridView ID="gvPODetailList" runat="server" AutoGenerateColumns="False" 
            DataSourceID="PendingPODetailsObj" Visible="False" >
            <Columns>
                <asp:BoundField DataField="Item_Code" HeaderText="Item Code" 
                    SortExpression="Item_Code" />
                <asp:BoundField DataField="Description" HeaderText="Item Description" />
                <asp:BoundField DataField="Order_Qty" HeaderText="Order Qty" 
                    SortExpression="Order_Qty" />
                <asp:TemplateField HeaderText="Delivered Qty" SortExpression="Deliver_Qty">
                    <ItemTemplate>
                        <asp:TextBox ID="txtDeliveredQty" runat="server"></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <asp:ObjectDataSource ID="PendingPODetailsObj" runat="server" 
            SelectMethod="GetPurchaseOrderDetailsList" 
            TypeName="BizLogic.PurchaseOrderDetailBLL">
            <SelectParameters>
                <asp:ControlParameter ControlID="ddlPONumber" Name="poid" 
                    PropertyName="SelectedValue" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </p>
    <asp:Button ID="btnStoreRecord" runat="server" Text="Update PO" 
        onclick="btnStoreRecord_Click" />

</asp:Content>
