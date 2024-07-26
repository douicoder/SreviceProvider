using Microsoft.AspNetCore.Mvc;
using ServiceProvider.Server.Modules.Interface;

namespace ServiceProvider.Server.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PincodeController : ControllerBase
    {
        public readonly IPinCodeManager _pinCodeManager;
        public PincodeController(IPinCodeManager pinCodeManager)
        {
            _pinCodeManager = pinCodeManager;
        }

        [HttpGet]
        public IActionResult CheckPinCode(string code) 
        {

            var result = _pinCodeManager.CheckPinCode(code).Result;
            if (result)
            {
                return Ok(true);
            }
            else 
            {
            return Ok(false);
            }
        }
    }
}
