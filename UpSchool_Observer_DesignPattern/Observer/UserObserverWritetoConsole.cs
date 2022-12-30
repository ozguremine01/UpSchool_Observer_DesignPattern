using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using UpSchool_Observer_DesignPattern.Dal;

namespace UpSchool_Observer_DesignPattern.Observer
{
    public class UserObserverWritetoConsole : IUserObserver
    {
        private readonly IServiceProvider _serviceProvider;

        public UserObserverWritetoConsole(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        //UserObserverWritetoConsole  -> Loglayacağımız alan bu olduğu için bunu kullandık.

        public void CreateUser(AppUser appUser)
        {
            var logger = _serviceProvider.GetRequiredService<ILogger<UserObserverWritetoConsole>>();
            logger.LogInformation($"{appUser.Name+ " "+ appUser.Surname} isimli kullanıcı sisteme kaydoldu.");

        }
    }
}
