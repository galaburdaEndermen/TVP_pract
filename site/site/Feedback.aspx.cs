using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
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
            MailAddress from = new MailAddress("galaburda0test@gmail.com", "Mail from gallery");
            MailAddress to = new MailAddress("tipa1488amerikos@gmail.com");
            MailMessage m = new MailMessage(from, to);
            m.Subject = Subject.Text;
            m.Body = Text.Text + "\n\n\n" + Email.Text + "\t" + Name.Text;
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential("galaburda0test@gmail.com", "test007A");
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.EnableSsl = true;
            smtp.Send(m);
        }
    }
}