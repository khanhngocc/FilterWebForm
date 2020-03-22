<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="View.aspx.cs" Inherits="FilterWebForm.View" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Filtermaster</title>

</head>
<body>
    <form id="form1" runat="server">
       <div>
            <asp:DropDownList AutoPostBack="true" ID="ddlEmployees" runat="server" DataTextField="display_name" DataValueField="id"
                OnSelectedIndexChanged="ddlEmployees_SelectedIndexChanged">
            </asp:DropDownList>
            <asp:DropDownList ID="ddlCustomer" runat="server" DataTextField="name" DataValueField="id"
                AutoPostBack="true" OnSelectedIndexChanged="ddlCustomer_SelectedIndexChanged">
            </asp:DropDownList>
            <asp:Calendar ID="caFrom" runat="server" OnSelectionChanged="caFrom_SelectionChanged"></asp:Calendar>
            <asp:Calendar ID="caTo" runat="server" OnSelectionChanged="caTo_SelectionChanged"></asp:Calendar>
         
        
            <asp:ListView EnableViewState="false" ID="lOrder" runat="server">
                <LayoutTemplate>
                    <table cellpadding="2" width="640px" border="1" id="tbl1" runat="server">
                        <tr runat="server" style="background-color: #98FB98">
                            <th runat="server">OrderID</th>
                            <th runat="server">Employee</th>
                            <th runat="server">Customer</th>
                            <th runat="server">OrderDate</th>
                            <th runat="server">RequiredDate</th>
                            <th runat="server">ShippedDate</th>
                            <th runat="server">ShipVia</th>
                        </tr>
                        <tr runat="server" id="itemPlaceholder" />
                    </table>
                </LayoutTemplate>
                <ItemTemplate>
                    <tr runat="server">
                        <td>
                            <asp:Label ID="OrderID" runat="server" Text='<%# Eval("OrderID") %>' />
                        </td>
                        <td>
                            <asp:Label ID="Employee" runat="server" Text='<%# Eval("Employee") %>' />
                        </td>
                        <td>
                            <asp:Label ID="Customer" runat="server" Text='<%# Eval("Customer") %>' />
                        </td>
                        <td>
                            <asp:Label ID="OrderDate" runat="server" Text='<%# Eval("OrderDate") %>' />
                        </td>
                        <td>
                            <asp:Label ID="RequiredDate" runat="server" Text='<%# Eval("RequiredDate") %>' />
                        </td>
                        <td>
                            <asp:Label ID="ShippedDate" runat="server" Text='<%# Eval("ShippedDate") %>' />
                        </td>
                        <td>
                            <asp:Label ID="ShipVia" runat="server" Text='<%# Eval("ShipVia") %>' />
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:ListView>
            <br />
        </div>
        
        <div>
            <asp:Button runat="server" Text="First" ID="btnFirst" Height="37px" OnClick="btnFirst_Click" Width="94px" />
            <asp:Button runat="server" Text="Previous" ID="btnPre" OnClick="btnPre_Click" Height="36px" Width="134px" />
            <asp:Label runat="server" Text="Label" ID="pageText"></asp:Label>
            <asp:Button runat="server" Text="Next" ID="btnNext" OnClick="btnNext_Click" Height="36px" Width="100px" />
            <asp:Button runat="server" Text="Last" ID="btnLast" Height="35px" OnClick="btnLast_Click" Width="113px" />
        </div>
        <br />
        <div>
            <asp:Label ID="Label1" runat="server" Text="Choose a specific page: "></asp:Label>
            <asp:DropDownList ID="pageNumberList" runat="server"
                AutoPostBack="true" Height="17px" OnSelectedIndexChanged="pageNumberList_SelectedIndexChanged" Width="131px">
            </asp:DropDownList>
        </div>

    </form>

</body>
</html>
