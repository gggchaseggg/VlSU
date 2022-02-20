<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DataList.aspx.cs" Inherits="DataList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:DataList ID="DataList1" runat="server" RepeatColumns="2" CellPadding="4" BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" GridLines="Both">
                <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
                <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="#FFFFCC" />
                <ItemStyle BackColor="White" ForeColor="#330099" />
                <ItemTemplate>
                    <table>
                        <tr>
                            <td>Название товара: </td>
                            <br />
                            <td><%# DataBinder.Eval(TovarList[0]) %> </td>
                        </tr>
                        <tr>
                            <td>Описание товара: </td>
                            <td>Какой_классный_товар</td>
                        </tr>
                        <tr>
                            <td>Цена: </td>
                            <td>Все_деньги_мира</td>
                        </tr>
                    </table>
                </ItemTemplate>
                <SelectedItemStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
            </asp:DataList>
        </div>
    </form>
</body>

</html>
