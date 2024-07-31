using Azure.Core;
using Microsoft.AspNetCore.Mvc;
using ServiceProvider.Server.Modules.Interface;
using ServiceProvider.Shared.Requests;

namespace ServiceProvider.Server.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RequestController : ControllerBase
    {
        public readonly IRequestManager _rm;
        public RequestController(IRequestManager rm)
        {
                _rm = rm;
        }
        [HttpGet]
        public IActionResult GetRequestInfo(Guid AcceptedByGuid) 
        {
            List<GetRequestInfoModel> getRequestInfoModels = _rm.GetRequestInfo(AcceptedByGuid);
            return Ok(getRequestInfoModels);
        }
        [HttpGet]
        public IActionResult GetRequestInfoUser(Guid UserID)
        {
            List<GetRequestInfoModel> getRequestInfoModels = _rm.GetRequestInfoUsers(UserID);
            return Ok(getRequestInfoModels);
        }
        [HttpPost]
        public IActionResult PostRequest([FromBody] RequestClass reequestClass) 
        {
            var result = _rm.AddRequest(reequestClass);
            if (result)
            {
                return Ok(true);
            }
            return NotFound(false);
        }
        [HttpPost]
        public IActionResult AcceptRequest([FromBody] RequestDetailClass reequestClass)
        {
            var result = _rm.AcceptRequest(reequestClass);
            if (result)
            {
                return Ok(true);
            }
            return NotFound(false);
        }
        [HttpGet]
        public IActionResult GetRequests()
        {
        List<RequestClass> list = _rm.GetRequests();
            return Ok(list);
        }

        [HttpPost]
        public IActionResult UpdateRequest(RequestClass reequestClass)
        {
            var result = _rm.UpdateRequest(reequestClass);
            if (result)
            {
                return Ok(true);
            }
            return NotFound(false);
        }
        [HttpDelete]
        public IActionResult DeleteRequest(RequestClass reequestClass)
        {
            var result = _rm.DeleteRequest(reequestClass);
            if (result)
            {
                return Ok(true);
            }
            return NotFound(false);
        }
    }
}
