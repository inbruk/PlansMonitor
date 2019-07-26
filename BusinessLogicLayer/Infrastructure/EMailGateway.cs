using System.IO;
using System.Linq;
using System.Net.Mail;

using Microsoft.Extensions.Configuration;

namespace BusinessLogicLayer.Infrastructure
{
    public class EMailGateway
    {
        string _defaultFromAddress;
        SmtpClient _currSmtpClient;

        public EMailGateway()
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .Build();

            IConfigurationSection configSection = config.GetSection("EMailGateway");
            configSection = configSection.GetSection("SMTP");

            string _smtpServerUrl      = configSection.GetSection("ServerUrl").Value;
            int _smtpServerPort        = int.Parse(configSection.GetSection("ServerPort").Value);
            string _smtpServerLogin    = configSection.GetSection("ServerLogin").Value;
            string _smtpServerPassword = configSection.GetSection("ServerPassword").Value;
            _defaultFromAddress        = configSection.GetSection("DefaultFromAddress").Value;

            _currSmtpClient = new SmtpClient();
            _currSmtpClient.Host = _smtpServerUrl;
            _currSmtpClient.Port = _smtpServerPort;
            _currSmtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            _currSmtpClient.UseDefaultCredentials = false;
            _currSmtpClient.EnableSsl = true;
            _currSmtpClient.Credentials = new System.Net.NetworkCredential(_smtpServerLogin, _smtpServerPassword);            
        }

        public void Send
        (
            string from,
            string toRecipients,
            string subject,
            string body
        )
        {        
            _currSmtpClient.Send(from, toRecipients, subject, body);
        }
        public void SendFromDefault
        (
            string toRecipients,
            string subject,
            string body
        )
        {
            _currSmtpClient.Send(_defaultFromAddress, toRecipients, subject, body);
        }
    }
}
        