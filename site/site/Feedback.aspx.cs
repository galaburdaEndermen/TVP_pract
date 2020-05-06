using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace site
{
    public partial class Feedback : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Unnamed_Click(object sender, EventArgs e)
        {
        

            try
            {
                // отправитель - устанавливаем адрес и отображаемое в письме имя
                MailAddress from = new MailAddress("galaburda0test@gmail.com", "Mail from gallery");
                // кому отправляем
                MailAddress to = new MailAddress("tipa1488amerikos@gmail.com");
                // создаем объект сообщения
                MailMessage m = new MailMessage(from, to);
                // тема письма
                m.Subject = Subject.Text;
                // текст письма
                m.Body = Text.Text + "\n\n\n" + Email.Text + "\t" + Name.Text;
                // письмо представляет код html
                //m.IsBodyHtml = true;
                // адрес smtp-сервера и порт, с которого будем отправлять письмо
                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                // логин и пароль
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential("galaburda0test@gmail.com", "test007A");
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.EnableSsl = true;
                smtp.Send(m);
                Console.Read();

            }
            catch (Exception ek)
            {
                string sas = ek.Message;
                throw;
            }
        }
    }
}