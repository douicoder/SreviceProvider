using Class.User.UserModel;
using ServiceProvider.Shared.User;

namespace Modules.User.UserInteface
{
    public interface IUserManager
    {

        public bool Registration(UserModel model);
        public bool Login(string emaiil, string password);
        public bool ChangePassword(ChangePasswordModel changePasswordModel);
        public Task<int> GenrateCode(string email);
 

    }
}
