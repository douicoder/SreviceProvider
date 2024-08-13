using ServiceProvider.Shared.Chats;

namespace ServiceProvider.Server.Modules.Interface
{
    public interface IChatManager
    {
        public bool SaveChatDetail(ChatHistoryAuditDetailsClass chatHistoryAuditDetails);
        public ChatHistoryAuditDetailsClassResponse GetChatHistoryAuditDetails(Guid ShopID, Guid UserID);
        public bool CreateNewChatAudit(ChatAuditClass chatAuditClass);
        public bool NewMegssage(ChatHistoryClass chatHistoryAuditDetails);
        public  List<ChatHistoryClass>GetChatHistory(Guid AuditID);
        public Guid GetAuditID(Guid userid,Guid shopid);

    }
}
