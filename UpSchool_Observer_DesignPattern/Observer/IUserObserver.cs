using UpSchool_Observer_DesignPattern.Dal;

namespace UpSchool_Observer_DesignPattern.Observer
{
    public interface IUserObserver
    {
        void CreateUser(AppUser appUser);
    }
}
