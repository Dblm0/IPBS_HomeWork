<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BillingInfo.aspx.cs" Inherits="HW.BillingInfo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
    </form>
    <table style="width:50%;">
        <tr>               
            <td> Name </td>            
            <td>BillingInfo</td>   
        </tr>
        <%=GetData()%>

    </table>
</body>
</html>
