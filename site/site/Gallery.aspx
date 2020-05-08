<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Gallery.aspx.cs" Inherits="site.Gallery" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link rel ="stylesheet" href="styles/galeryPage.css" />
    <title></title>
</head>
<body id="bod">
    <form id="form1" runat="server"  >

         
       

        <div id="maindiv" runat="server" style="width:75vw; ">

         <div id="image" runat="server" class="tmp">
             <%--<a class="left" runat="server"></a>
             <a class="right" runat="server"></a>--%>
         </div>

        </div>






        <div class="bot">
            <div class="bot-text">
               
                <a href="Default.aspx">Головна сторінка</a>
                 <p>Сайт Галабурди Антона</p>
            </div>
        </div>

    </form>
</body>
</html>