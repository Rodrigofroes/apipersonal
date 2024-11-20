using System.Net;
using System.Net.Mail;
using System.Text.RegularExpressions;
using api_personal.Services.Interfaces;
using api_personal.Utils;

namespace api_personal.Services
{
    public class EmailService : IEmail
    {
        public string Provedor { get; set; }
        public string Usuario { get; set; }
        public string Senha { get; set; }

        private readonly ValidateUltis _validateUltis;

        public EmailService(ValidateUltis validate)
        {
            Provedor = "smtp.gmail.com";
            Usuario = "rodrigofroesport@gmail.com";
            Senha = "yjdz qfor jvik dojb";
            _validateUltis = validate;
            
        }

        public void EnviarEmail(string email, string subject, string body)
        {
            var message = PreparaMensagem(email, body, subject);
            if (message != null)
            {
                EnviarEmail(message);
            }
        }

        private MailMessage PreparaMensagem(string email, string subject, string body)
        {
            if (_validateUltis.ValidacaoEmail(email))
            {
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(Usuario);
                mail.To.Add(email);
                mail.Subject = subject;
                mail.Body = body;
                mail.IsBodyHtml = true;
                return mail;
            }

            return null;
        }

        private void EnviarEmail(MailMessage message)
        {
            SmtpClient smtp = new SmtpClient();
            smtp.Host = Provedor;
            smtp.Port = 587;
            smtp.EnableSsl = true;
            smtp.Timeout = 5000;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential(Usuario, Senha);
            smtp.Send(message);
            smtp.Dispose();
        }
    }
}
