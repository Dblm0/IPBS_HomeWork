<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="HW.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

</head>
<body>
    <form id="form1" runat="server">
    <div>
        Регистрация&nbsp;&nbsp;
        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Default.aspx">На главную</asp:HyperLink>
        <br />
        <table style="height: 80px; width: 272px">
	        <tr>
		<td align="right" class="auto-style4"><asp:label runat="server" AssociatedControlID="UserName" ID="UserNameLabel">Имя пользователя:</asp:label></td><td class="auto-style1"><asp:TextBox runat="server" ID="UserName" Width="128px"></asp:TextBox>
</td>
	</tr><tr>
		<td align="right" class="auto-style6"><asp:label runat="server" AssociatedControlID="Password" ID="PasswordLabel">Пароль:</asp:label></td><td class="auto-style7"><asp:TextBox runat="server" TextMode="Password" ID="Password" Width="128px"></asp:TextBox>
                </td>
	</tr><tr>
		<td align="right" class="auto-style4"><asp:label runat="server" AssociatedControlID="Password" ID="Label1">N:</asp:label></td><td class="auto-style1">
        <asp:DropDownList ID="DropDownN" runat="server">
            <asp:ListItem>1</asp:ListItem>
            <asp:ListItem>2</asp:ListItem>
            <asp:ListItem>3</asp:ListItem>
            <asp:ListItem>4</asp:ListItem>
            <asp:ListItem>5</asp:ListItem>
        </asp:DropDownList>
                </td>
	</tr><tr>
		<td align="right" class="auto-style5">BillingInfo:</td><td class="auto-style3">
                <asp:TextBox runat="server" ID="BillingInfo" Width="128px"></asp:TextBox>
                </td>
	</tr>

</table>
        <br />
        <asp:Button ID="RegButton" runat="server" Text="Регистрация" OnClick="RegButton_Click" />
        <asp:Label ID="StatusLabel" runat="server"></asp:Label>
    </div>
    </form>
</body>
</html>
