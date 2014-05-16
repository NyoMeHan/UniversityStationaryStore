<%@ Page Title="" Language="C#" MasterPageFile="~/Store.Master" AutoEventWireup="true" CodeBehind="Acknowledge.aspx.cs" Inherits="LogicUniversityWebLogic.Acknowledge" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <br />
    <br />
    <br />


    <asp:Label ID="Label1" runat="server" Text="Do you have adjustment"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:RadioButton ID="radioYes" runat="server" Text="Yes" 
        GroupName="yes" />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:RadioButton ID="radioNo" runat="server" Text="No" 
        GroupName="yes" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="Button1" runat="server" onclick="Button1_Click" 
        Text="Proceed" />
    <br />
    <br />
    <asp:MultiView ID="MultiView1" runat="server">
        <asp:View ID="NoadjustmentView" runat="server">
            <asp:Label ID="Label2" runat="server" Text="Select the Department"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
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
            <asp:Button ID="btnNoACK" runat="server" Text="Acknowledge" 
                onclick="btnNoACK_Click" />
        </asp:View>
        <asp:View ID="AdjustmentView" runat="server">
            <table style="width: 100%">
                <tr>
                    <td style="width: 334px">
                        Disbursement Id</td>
                    <td>
                        <asp:TextBox ID="txtDisburseID" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="width: 334px; height: 21px">
                    </td>
                    <td style="height: 21px">
                    </td>
                </tr>
                <tr>
                    <td style="width: 334px">
                        Item Category</td>
                    <td>
                        <asp:DropDownList ID="DropDownList1" runat="server" 
                            DataSourceID="EntityDataSource1" DataTextField="Category_Name" 
                            DataValueField="Category_Name" AutoPostBack="True" 
                            onselectedindexchanged="DropDownList1_SelectedIndexChanged">
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
                    <td style="width: 334px">
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 334px">
                        Item Description</td>
                    <td>
                        <asp:DropDownList ID="dropdownItem" runat="server" 
                            DataSourceID="EntityDataSource2" DataTextField="Description" 
                            DataValueField="Description">
                        </asp:DropDownList>
                        <asp:EntityDataSource ID="EntityDataSource2" runat="server" 
                            ConnectionString="name=Team4_ADEntities" 
                            DefaultContainerName="Team4_ADEntities" EnableFlattening="False" 
                            EntitySetName="Stock_Item" Select="it.[Description]">
                        </asp:EntityDataSource>
                    </td>
                </tr>
                <tr>
                    <td style="width: 334px">
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 334px">
                        Type</td>
                    <td>
                        <asp:RadioButton ID="RadioButton1" runat="server" GroupName="sindhu" 
                            Text="Damaged" />
                        <asp:RadioButton ID="RadioButton2" runat="server" GroupName="sindhu" 
                            Text="Missing" />
                    </td>
                </tr>
                <tr>
                    <td style="width: 334px">
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 334px">
                        Quantity</td>
                    <td>
                        <asp:TextBox ID="txtDamaged" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="width: 334px">
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 334px">
                        <asp:Button ID="btnAdd" runat="server" BackColor="#993333" ForeColor="Black" 
                            onclick="btnAdd_Click" Text="Add" Width="145px" />
                    </td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 334px">
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 334px">
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                            onselectedindexchanged="GridView1_SelectedIndexChanged" BackColor="White" 
                            BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" 
                            ForeColor="Black" GridLines="Vertical">
                            <AlternatingRowStyle BackColor="#CCCCCC" />
                            <Columns>
                                <asp:BoundField DataField="DepartmentRequestID" 
                                    HeaderText="Department Request ID" />
                                <asp:BoundField DataField="ItemCategory" HeaderText="Item Category" />
                                <asp:BoundField DataField="ItemDescription" HeaderText="Item Description" />
                                <asp:BoundField DataField="Quantity" HeaderText="Adjust Quantity" />
                                <asp:BoundField DataField="Type" HeaderText="Type" />
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
                    </td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 334px">
                        <asp:Button ID="btnAck" runat="server" BackColor="#993333" ForeColor="Black" 
                            onclick="btnAck_Click" Text="Acknowledge" Width="145px" />
                    </td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 334px">
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 334px">
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 334px">
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 334px">
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 334px">
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 334px">
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 334px">
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
            </table>
        </asp:View>
    </asp:MultiView>
    <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 

</asp:Content>
