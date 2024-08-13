using Microsoft.AspNetCore.Mvc;
using ServiceProvider.Server.Modules.Interface;
using ServiceProvider.Shared.Chats;

namespace ServiceProvider.Server.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ChatController : ControllerBase
    {
        IChatManager _chatManager;
        public ChatController(IChatManager _chatManager2)
        {
                _chatManager = _chatManager2;
        }

        [HttpPost]
        public IActionResult SaveNewChat(ChatHistoryAuditDetailsClass chatHistoryAuditDetails)
        {
        var response = _chatManager.SaveChatDetail(chatHistoryAuditDetails);
            if (response)
            {
                return Ok(response);
            }
            else 
            {
            return NotFound();
            }
        }

        [HttpPost]
        public IActionResult PostNewChat(ChatHistoryClass chatHistoryAuditDetails)
        {
            var response = _chatManager.NewMegssage(chatHistoryAuditDetails);
            if (response)
            {
                return Ok(response);
            }
            else
            {
                return NotFound();
            }
        }
        [HttpPost]
        public IActionResult CreateChatAudit(ChatAuditClass chatAuditDetails) 
        {
        dynamic result=_chatManager.CreateNewChatAudit(chatAuditDetails);
            if (result) { return Ok(result); }
          else if (!result) { return Ok(result); }
            else { return NotFound(); }
        }
        [HttpGet]
        public IActionResult ShowChat(Guid ShopID, Guid UserID)
        {
            ChatHistoryAuditDetailsClassResponse response = _chatManager.GetChatHistoryAuditDetails(ShopID, UserID);
            if (response != null) 
            {
                return Ok(response);
            }
            else {return NotFound(); }
        }

        [HttpGet]
        public IActionResult ShowChatHistory(Guid AuditID) 
        {
        List<ChatHistoryClass> list=new List<ChatHistoryClass>();
            list= _chatManager.GetChatHistory(AuditID);
            return Ok(list);
        }

        [HttpGet]
        public IActionResult GetAuditID(Guid ShopID, Guid UserID)
        {
            Guid ChatAuditID = _chatManager.GetAuditID(UserID, ShopID);

            return Ok(ChatAuditID);
           
        }
    }
}
