using System;
using System.Diagnostics;
using System.Net;
using System.Net.Mail;

namespace BUS.Handlers
{
    public class EmailSender
    {
        private const string USERNAME = "conghau31052004@gmail.com";
        private const string PASSWORD = "xdqzdhcrbmtryjyn";

        private static string _code = string.Empty;
        private static DateTime _timeCreate;

        public async static Task<bool> SendEmail(string emailTO)
        {
            _code = CodeGenerator.Generate();
            
            // Config mail
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress(USERNAME);
            mail.To.Add(USERNAME);
            mail.Subject = "RESET PASSWORD CODE";
            mail.Body = $"<strong>{_code}</strong> is your code.";
            mail.IsBodyHtml = true;

            // Config smtp to send mail
            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
            smtpClient.EnableSsl = true;
            smtpClient.Credentials = new NetworkCredential(USERNAME, PASSWORD);
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;            

            try
            {
                await smtpClient.SendMailAsync(mail);
                _timeCreate = DateTime.Now;
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public static bool CheckCode(string inputCode)
        {
            TimeSpan timeSpan = DateTime.Now.Subtract(_timeCreate);
            if (timeSpan.TotalMinutes > 2)
                return false;
            if (inputCode != _code)
                return false;
            return true;
        }
    
    }
}