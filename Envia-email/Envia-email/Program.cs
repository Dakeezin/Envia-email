using System;
using System.Net;
using System.Net.Mail;

namespace Envia_email
{
    class Program
    {
        static void Main(string[] args)
        {
            string remetente = "contato.gjesus@gmail.com";
            string destinatario = "gustavoldndev@email.com";
            string senha = "******";
            string assunto = "Teste envio de E-mail";
            string corpo = "teste";

            //  SMTP Gmail
            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
            smtpClient.EnableSsl = true;
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = new NetworkCredential(remetente, senha);

            MailMessage mailMessage = new MailMessage(remetente, destinatario, assunto, corpo);
            mailMessage.IsBodyHtml = false; // Corpo HTML

            try
            {
                smtpClient.Send(mailMessage);
                Console.WriteLine("E-mail enviado com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao enviar e-mail: " + ex.Message);
            }
        }
    }
}
