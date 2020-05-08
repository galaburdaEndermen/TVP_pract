<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="site.Error" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link rel ="stylesheet" href="styles/errorPage.css" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>

             <div class="top" href="Default.aspx">
                 <a href="Default.aspx" style="height: 100%; width: 100%;">
                      <div class="top-text">
                <h1>404, сторінку не знайдено</h1>
                <p>Натисніть сюди, щоб повернутись на головну.</p>
            </div>
                 </a>
        </div>

            <div style="width: 75vw; height:6vh;"></div>


            <div class="bot">
            <div class="bot-text">
               
                 <a href="Default.aspx">Головна сторінка</a>
                 <p>Сайт Галабурди Антона</p>
            </div>
        </div>

        </div>
    </form>
</body>
</html>
