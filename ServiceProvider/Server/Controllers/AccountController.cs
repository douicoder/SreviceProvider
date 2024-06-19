using Class.User.CategoryModel;
using Class.User.UserModel;
using Microsoft.AspNetCore.Mvc;
using Modules.User.UserInteface;
using ServiceProvider.Shared.User;


namespace ServiceProvider.Server.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        public readonly IUserManager _userAcc;

        public AccountController(IUserManager userAcc)
        {
            _userAcc = userAcc;
        }

        [HttpPost]
        public IActionResult AddUser(UserModel userRegistration)
        {
            var result = _userAcc.Registration(userRegistration);
            if (result)
            {
                return Ok(true);
            }
            return NotFound(false);
        }

        [HttpPost]
        public IActionResult Login(LoginModel loginModel)
        {
            var result = _userAcc.Login(loginModel.Email, loginModel.Password);
            if (result)
            {
                return Ok(true);
            }
            return NotFound(false);
        }

        [HttpPost]
        public IActionResult ChangePassword(ChangePasswordModel changePasswordModel)
        {
            var result = _userAcc.ChangePassword(changePasswordModel);
            if (result)
            {
                return Ok(true);
            }
            return NotFound(false);
        }

        [HttpGet]
        public IActionResult GenrateCode(string email)
        {
            var result = _userAcc.GenrateCode(email.ToLower()).Result;
          
            return Ok(result);
        }

        [HttpGet]
        public List<CategoryModel> GetCategories() 
        {
        List<CategoryModel> categoryModels = _userAcc.GetAllCategories();

            return categoryModels;
        }

    }
}
