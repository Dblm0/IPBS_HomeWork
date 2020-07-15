<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChangePass.aspx.cs" Inherits="HW.ChangePass" %>

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
		<td align="right"><asp:label runat="server" AssociatedControlID="OldPass" ID="label1">Старый пароль:</asp:label></td><td class="auto-style1"><asp:TextBox runat="server" ID="OldPass" Width="128px" TextMode="Password"></asp:TextBox>
</td>
	</tr><tr>
		<td align="right"><asp:label runat="server" AssociatedControlID="NewPass" ID="label2">Новый пароль:</asp:label></td><td class="auto-style1"><asp:TextBox runat="server" TextMode="Password" ID="NewPass" Width="128px"></asp:TextBox>
                </td>
	</tr>

</table>
        <br />
        <asp:Label ID="StatusLabel" runat="server"></asp:Label>
        <br />
        <asp:Button ID="ChangeButton" runat="server" OnClick="ChangeButton_Click" Text="Изменить" />
    
    </div>
    </form>
</body>
</html>
