<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="HW.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        Вход&nbsp;&nbsp;&nbsp;
        <asp:LinkButton ID="RegisterButton" runat="server" PostBackUrl="~/Register.aspx">Регистрация</asp:LinkButton>
    
        <br />
&nbsp;<table>
	        <tr>
		<td align="right"><asp:label runat="server" AssociatedControlID="UserName" ID="UserNameLabel">Имя пользователя:</asp:label></td><td class="auto-style1"><asp:TextBox runat="server" ID="UserName" Width="128px"></asp:TextBox>
</td>
	</tr><tr>
		<td align="right"><asp:label runat="server" AssociatedControlID="Password" ID="PasswordLabel">Пароль:</asp:label></td><td class="auto-style1"><asp:TextBox runat="server" TextMode="Password" ID="Password" Width="128px"></asp:TextBox>
                </td>
	</tr>

</table>
        <asp:Label ID="StatusLabel" runat="server"></asp:Label>
        <br />
        <asp:Button ID="LogInButton" runat="server" OnClick="LogInButton_Click" Text="Вход" />
        <br />
    
    </div>
    </form>
</body>
</html>
