﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication2.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:TextBox ID ="Login" runat="server"></asp:TextBox>
            <asp:TextBox ID ="Password" runat="server"></asp:TextBox>

            <asp:Button ID="Submit" OnClick="Submit_Click" runat="server" />
        </div>
    </form>
</body>
</html>
