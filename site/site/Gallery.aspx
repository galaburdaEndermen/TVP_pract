<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Gallery.aspx.cs" Inherits="site.Gallery" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link rel ="stylesheet" href="styles/mainPage.css" />
    <title></title>
</head>
<body id="bod">
    <form id="form1" runat="server"  >

         
        <div class="top">
            <div class="top-text">
                <h1>Картинна галерея</h1>
                <p>Картини великих художників, живопис майстрів минулого та сучасності з кращих музеїв світу.</p>
            </div>
        </div>

        <div id="maindiv" runat="server" > </div>

        <div class="bot">
            <div class="bot-text">
               
                <a href="Feedback.aspx">Зворотній зв'язок</a>
                 <p>Сайт Галабурди Антона</p>
            </div>
        </div>

    </form>
</body>
</html>