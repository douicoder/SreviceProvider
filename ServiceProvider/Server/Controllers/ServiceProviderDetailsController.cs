using Class.User.UserModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServiceProvider.Server.Modules.Interface;
using ServiceProvider.Shared.User;

namespace ServiceProvider.Server.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ServiceProviderDetailsController : ControllerBase
    {
        public readonly IServiceProviderDetailsManager _spd;
        public ServiceProviderDetailsController(IServiceProviderDetailsManager spd)
        {
             _spd= spd;
        }

        [HttpPost]
        public IActionResult Adddetails(ServiceProviderProfile spdclass)
        {
            var result = _spd.AddDetails(spdclass);
            if (result)
            {
                return Ok(true);
            }
            return NotFound(false);
        }


        public ServiceProviderProfile GetServiceProviderProfile(Guid userId)
        {
            try
            {
                ServiceProviderProfile serviceProviderProfile = _spd.GetDetail(userId);

                return serviceProviderProfile;
              
                    
                
            }
            catch (Exception ex)
            {
                // Log the exception
                return null;
            }
        }


    }
}
