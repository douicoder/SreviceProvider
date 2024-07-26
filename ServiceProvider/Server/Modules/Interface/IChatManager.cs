using ServiceProvider.Shared.Chats;

namespace ServiceProvider.Server.Modules.Interface
{
    public interface IChatManager
    {
        public bool SaveChatDetail(ChatHistoryAuditDetailsClass chatHistoryAuditDetails);
        public ChatHistoryAuditDetailsClassResponse GetChatHistoryAuditDetails(Guid ShopID, Guid UserID);
        public bool CreateNewChatAudit(ChatAuditClass chatAuditClass);

    }
}
