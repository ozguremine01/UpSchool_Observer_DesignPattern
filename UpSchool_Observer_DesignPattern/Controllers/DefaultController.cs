using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using UpSchool_Observer_DesignPattern.Dal;
using UpSchool_Observer_DesignPattern.Models;
using UpSchool_Observer_DesignPattern.Observer;

namespace UpSchool_Observer_DesignPattern.Controllers
{
    public class DefaultController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly UserObserverSubject _userObserver;

        public DefaultController(UserManager<AppUser> userManager, UserObserverSubject userObserver)
        {
            _userManager = userManager;
            _userObserver = userObserver;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(UserRegisterViewModel model)
        {
            var appUser = new AppUser()
            {
                UserName = model.UserName,
                Email = model.Mail,
                Name = model.Name,
                Surname = model.Surname
            };
            var result= await _userManager.CreateAsync(appUser, model.Password);
            if(result.Succeeded)
            {
                _userObserver.NotifyObserver(appUser);
                ViewBag.message = "Üyelik sistemi başarılı bir şekilde oluşturuldu";
            }

            else
            {
                ViewBag.message = "Üyelik kaydında bir hata oluştu";
            }
            return View();
        }
    }
}
