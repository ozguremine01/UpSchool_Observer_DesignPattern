using MailKit.Net.Smtp;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MimeKit;
using System;
using UpSchool_Observer_DesignPattern.Dal;

namespace UpSchool_Observer_DesignPattern.Observer
{
    public class UserObserverSendMail : IUserObserver
    {
        private readonly IServiceProvider _serviceProvider;

        public UserObserverSendMail(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public void CreateUser(AppUser appUser)
        {
            var logger = _serviceProvider.GetRequiredService<ILogger<UserObserverSendMail>>();
            MimeMessage mimeMessage = new MimeMessage();
            //2. parametre mesaj gönderilecek mail adresi -> Kimden kısmı
            MailboxAddress mailboxAddressFrom = new MailboxAddress("Admin Observer"," ");
            mimeMessage.From.Add(mailboxAddressFrom);

            MailboxAddress mailboxAddressTo = new MailboxAddress("User",appUser.Email);
            mimeMessage.To.Add(mailboxAddressTo);

            var bodyBuilder= new BodyBuilder();
            bodyBuilder.TextBody = "İndirim kodunuz: GIFT0001";
            mimeMessage.Body = bodyBuilder.ToMessageBody();
            mimeMessage.Subject = "Hoş Geldiniz İndirim Hediyesi";

            SmtpClient client=new SmtpClient();
            client.Connect("smtp.gmail.com",587,false);
            client.Authenticate("deneme@gmail.com","Gmail'den alınacak kod");
            client.Send(mimeMessage);
            client.Disconnect(true);

            logger.LogInformation($"{appUser.Name + " " + appUser.Surname} isimli kullanıcının {appUser.Email} adlı mail adresine indirim kodu maili başarıyla gönderildi.");

        }
    }
}
