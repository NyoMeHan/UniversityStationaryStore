<%@ Page Title="" Language="C#" MasterPageFile="~/Store_Master.Master" AutoEventWireup="true" CodeBehind="Adjustment.aspx.cs" Inherits="MobilePresentationLogic.Adjustment" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style1
        {
            width: 412px;
        }
        .style2
        {
            height: 55px;
            width: 404px;
        }
        .style3
        {
            height: 22px;
            width: 404px;
        }
        .style4
        {
            width: 404px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

 <table style="width: 50%">
 <tr> <td> <h3 align="center" >Disbursement Acknowledge </h3></td></tr>
        <tr>
            <td class="style4">
                Do you have adjustments</td>
            <td style="width: 221px">
                <asp:RadioButton ID="radioYes" runat="server" Text="Yes" />
                <asp:RadioButton ID="radioNo" runat="server" Text="No" />
            </td>
        </tr>
        <tr>
            <td class="style4">
                Disbursement Id</td>
            <td style="width: 221px">
                <asp:TextBox ID="txtDisburseID" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style2">
                Item Category</td>
            <td style="width: 221px; height: 55px">
                <asp:DropDownList ID="DropDownList1" runat="server" 
                    DataSourceID="EntityDataSource1" DataTextField="Category_Name" 
                    DataValueField="Category_Name">
                </asp:DropDownList>
                <asp:EntityDataSource ID="EntityDataSource1" runat="server" 
                    ConnectionString="name=Team4_ADEntities" 
                    DefaultContainerName="Team4_ADEntities" EnableFlattening="False" 
                    EntitySetName="Categories" EntityTypeFilter="Category" 
                    Select="it.[Category_Name]">
                </asp:EntityDataSource>
            </td>
        </tr>
        <tr>
            <td class="style4">
                Item Description</td>
            <td style="width: 221px">
                <asp:DropDownList ID="DropDownList2" runat="server" 
                    DataSourceID="EntityDataSource2" DataTextField="Description" 
                    DataValueField="Description">
                </asp:DropDownList>
                <asp:EntityDataSource ID="EntityDataSource2" runat="server" 
                    ConnectionString="name=Team4_ADEntities" 
                    DefaultContainerName="Team4_ADEntities" EnableFlattening="False" 
                    EntitySetName="Stock_Items" EntityTypeFilter="Stock_Item" 
                    Select="it.[Description]" Where="">
                </asp:EntityDataSource>
            </td>
        </tr>
        <tr>
            <td class="style4">
                Type</td>
            <td style="width: 221px">
                <asp:RadioButton ID="RadioButton1" runat="server" GroupName="sindhu" 
                    Text="Damaged" />
                <asp:RadioButton ID="RadioButton2" runat="server" GroupName="sindhu" 
                    Text="Missing" />
            </td>
        </tr>
        <tr>
            <td class="style3">
                Quantity</td>
            <td style="width: 221px; height: 22px;">
                <asp:TextBox ID="txtDamaged" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style4">
                &nbsp;</td>
            <td style="width: 221px">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style4">
                <asp:Button ID="btnAdd" runat="server" ForeColor="Black" 
                    Text="Add" Width="145px" onclick="btnAdd_Click" />
            </td>
            <td style="width: 221px">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style4">
                <asp:MultiView ID="MultiView1" runat="server">
                    <asp:View ID="noAdjustmentView" runat="server">
                        Select the department
                        <asp:DropDownList ID="DropDownList3" runat="server" 
                            DataSourceID="EntityDataSource3" DataTextField="Department_Name" 
                            DataValueField="Department_Name">
                        </asp:DropDownList>
                        <asp:EntityDataSource ID="EntityDataSource3" runat="server" 
                            ConnectionString="name=Team4_ADEntities" 
                            DefaultContainerName="Team4_ADEntities" EnableFlattening="False" 
                            EntitySetName="Departments" Select="it.[Department_Name]">
                        </asp:EntityDataSource>
                        <br />
                    </asp:View>
                    <asp:View ID="adjustmentView" runat="server">
                        <table style="width: 100%">
                            <tr>
                                <td>
                                    Do you have adjustments</td>
                                <td style="width: 138px">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td style="width: 138px">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td style="width: 138px">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td style="width: 138px">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td style="width: 138px">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td style="width: 138px">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td style="width: 138px">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td style="width: 138px">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td style="width: 138px">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td style="width: 138px">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td style="width: 138px">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td style="width: 138px">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td style="width: 138px">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td style="width: 138px">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td style="width: 138px">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td style="width: 138px">
                                    &nbsp;</td>
                            </tr>
                        </table>
                    </asp:View>
                </asp:MultiView>
            </td>
            <td style="width: 221px">
                &nbsp;</td>
        </tr>
         <tr>
            
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                    onselectedindexchanged="GridView1_SelectedIndexChanged" BackColor="White" 
                    BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4">
                    <Columns>
                        <asp:BoundField HeaderText="Department Request ID" 
                            DataField="DepartmentRequestID" />
                        <asp:BoundField HeaderText="Item Category" DataField="ItemCategory" />
                        <asp:BoundField HeaderText="Item Description" DataField="ItemDescription" />
                        <asp:BoundField HeaderText="Adjust Quantity" DataField="Quantity" />
                        <asp:BoundField HeaderText="Type" DataField="Type" />
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
                </asp:GridView>
            </td>
            <td style="width: 221px">
                &nbsp;</td>
       
        <tr>
            <td class="style2">
                <br />
                <asp:Button ID="btnAck" runat="server" BackColor="#993333" ForeColor="Black" 
                    Text="Acknowledge" Width="145px" onclick="btnAck_Click" />
                <br />
            </td>
            <td style="width: 221px; height: 55px;">
                </td>
        </tr>
    </table>

</asp:Content>
