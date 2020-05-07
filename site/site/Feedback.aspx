<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Feedback.aspx.cs" Inherits="site.Feedback" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link rel ="stylesheet" href="styles/feedbackPage.css" />
    <title></title>
</head>
<body>
    <%--http://jsfiddle.net/Lg7d3Lz8/5/--%>
    <form id="form1" runat="server">

        <div class="top">
             <h1>Зворотній зв'язок</h1>
                <p>Ваша думка для нас важлива</p>
        </div>

        <div class="mainform">

           
            <p>Ваше ім'я</p>
            <asp:TextBox runat="server" ID="Name" CssClass="text-box"></asp:TextBox>
            
            <p>Тема листа</p>
            <asp:TextBox runat="server" ID="Subject" CssClass="text-box"></asp:TextBox>
            
            <p>Ваша електронна пошта</p>
            <asp:TextBox runat="server" ID="Email" CssClass="text-box"></asp:TextBox>
            
    


             <p>Ваш лист</p>
           
            <asp:TextBox runat="server" ID="Text" CssClass="letter-box"></asp:TextBox>


            <div class="btn-box">
                  <asp:Button runat="server" OnClick="Unnamed_Click" CssClass="butn" Text="Надіслати"/>
            </div>
          
            
        </div>

      <div class="bot">
            <div class="bot-text">
                 <p>Сайт Галабурди Антона</p>
            </div>
        </div>
    </form>
</body>
</html>
