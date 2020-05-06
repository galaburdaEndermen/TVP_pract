<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Feedback.aspx.cs" Inherits="site.Feedback" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link rel ="stylesheet" href="styles/feedbackPage.css" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">

        <div class="top">
             <h1>Зворотній зв'язок</h1>
                <p>Ваша думка для нас важлива</p>
        </div>

        <div class="mainform">
            <asp:TextBox runat="server" ID="Name"></asp:TextBox>
            <asp:TextBox runat="server" ID="Subject"></asp:TextBox>
            <asp:TextBox runat="server" ID="Email"></asp:TextBox>

            <asp:TextBox runat="server" ID="Text"></asp:TextBox>
        </div>

      <div class="bot">
            <div class="bot-text">
                 <p>Сайт Галабурди Антона</p>
            </div>
        </div>
    </form>
</body>
</html>
