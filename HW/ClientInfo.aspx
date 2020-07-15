<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ClientInfo.aspx.cs" Inherits="HW.ClientInfo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Default.aspx">На главную</asp:HyperLink>
        <br />
    
        <asp:LoginName ID="LoginName1" runat="server" />
        <asp:LoginStatus ID="LoginStatus1" runat="server" />
        <br />
        <table>
	        <tr>
		<td align="right"><asp:label runat="server" AssociatedControlID="Password" ID="PasswordLabel">Пароль:</asp:label></td><td class="auto-style1"><asp:TextBox runat="server" TextMode="Password" ID="Password" Width="128px"></asp:TextBox>
        <asp:Label ID="StatusLabel" runat="server"></asp:Label>
                </td>
	</tr>

</table>
        <asp:Button ID="AccesButton" runat="server" OnClick="AccesButton_Click" Text="Подтвердить" />
        <br />
        <asp:TextBox ID="TextBox" runat="server" Height="212px" TextMode="MultiLine" Visible="False" Width="437px"></asp:TextBox>
        <br />
        <asp:Button ID="SaveButton" runat="server" OnClick="SaveButton_Click" Text="Сохранить" Visible="False" />
    
    </div>
    </form>
</body>
</html>
