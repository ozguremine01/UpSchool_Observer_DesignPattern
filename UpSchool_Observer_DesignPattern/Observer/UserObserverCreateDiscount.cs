using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using UpSchool_Observer_DesignPattern.Dal;

namespace UpSchool_Observer_DesignPattern.Observer
{
    public class UserObserverCreateDiscount : IUserObserver
    {
        private readonly IServiceProvider _serviceProvider;

        public UserObserverCreateDiscount(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public void CreateUser(AppUser appUser)
        {
            var logger = _serviceProvider.GetRequiredService<ILogger<UserObserverCreateDiscount>>();
            var scoped = _serviceProvider.CreateScope();
            var context = scoped.ServiceProvider.GetRequiredService<Context>();
            context.Discounts.Add(new Discount
            {
                Rate = 25,
                UserID = appUser.Id,

            });
            context.SaveChanges();
            logger.LogInformation($"Yeni kayıt olan kullanıcınız: {appUser.Name+ " "+ appUser.Surname} için %25 oranında bir indirim kodu tanımlandı...");
        }
    }
}
