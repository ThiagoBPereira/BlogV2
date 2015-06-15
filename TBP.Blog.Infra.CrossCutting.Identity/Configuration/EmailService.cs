using System;
using System.Configuration;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.Identity;

namespace TBP.Blog.Infra.CrossCutting.Identity.Configuration
{
    public class EmailService : IIdentityMessageService
    {
        public Task SendAsync(IdentityMessage message)
        {
            return SendMail(message);
        }

        // Implementação de e-mail manual
        private static Task SendMail(IdentityMessage message)
        {
            if (ConfigurationManager.AppSettings["Internet"] != "true")
                return Task.FromResult(0);

            var text = HttpUtility.HtmlEncode(message.Body);

            //TODO 2: Verificar melhor forma de guardar as informações de envio de email e se envio tá sendo feito corretamente
            var msg = new MailMessage { From = new MailAddress(ConfigurationManager.AppSettings["ContaDeEmail"], "Admin do Portal") };
            msg.To.Add(new MailAddress(message.Destination));
            msg.Subject = message.Subject;
            msg.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(text, null, MediaTypeNames.Text.Plain));
            msg.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(text, null, MediaTypeNames.Text.Html));

            var smtpClient = new SmtpClient(ConfigurationManager.AppSettings["smtpProvedor"], Convert.ToInt32(ConfigurationManager.AppSettings["smtpPort"]));
            var credentials = new NetworkCredential(ConfigurationManager.AppSettings["ContaDeEmail"],
                ConfigurationManager.AppSettings["SenhaEmail"]);
            smtpClient.Credentials = credentials;
            smtpClient.EnableSsl = true;
            smtpClient.Send(msg);

            return Task.FromResult(0);
        }
    }
}
