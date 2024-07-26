using ServiceProvider.Server.Modules.Interface;
using ServiceProvider.Shared.Chats;
using ServiceProvider.Shared.Requests;

namespace ServiceProvider.Server.Modules.Manager
{
    public class ChatManager : IChatManager
    {
        DatabaseContext _database = new DatabaseContext();
        public ChatManager(DatabaseContext db)
        {
            _database = db;
        }
        //what
        public ChatHistoryAuditDetailsClassResponse GetChatHistoryAuditDetails(Guid ShopID, Guid UserID)
        {
            ChatHistoryAuditDetailsClassResponse response = new ChatHistoryAuditDetailsClassResponse();
            try {
              
                ChatAuditClass chatAuditClass = _database.ChatAuditDB.Where(x => x.ShopID == ShopID && x.UserID == UserID).FirstOrDefault();
                response.auditClass = chatAuditClass;
                if (chatAuditClass != null)
                {
                    response.chatHistoryClass = chatHistory(chatAuditClass.AuditID);
                }
                else
                {
                    response.chatHistoryClass = new List<ChatHistoryClass>();
                }
                return response;
            }
            catch 
            {
                return response;
            } 
           }

        private List<ChatHistoryClass> chatHistory(Guid auditid) 
        {
        List<ChatHistoryClass> responce= _database.ChatHistoryDB.Where(x=>x.AuditID==auditid).ToList();
            return responce;    
        }

        public bool SaveChatDetail(ChatHistoryAuditDetailsClass chatHistoryAuditDetails)
        {
           ChatAuditClass chatAuditClass = chatHistoryAuditDetails.auditClass;
           ChatHistoryClass chatHistoryClass = chatHistoryAuditDetails.chatHistoryClass;



            _database.ChatAuditDB.Add(chatAuditClass);
            _database.SaveChanges();
            _database.ChatHistoryDB.Add(chatHistoryClass);
            _database.SaveChanges();
            return true;
        }

        public bool CreateNewChatAudit(ChatAuditClass chatAuditClass)
        {
            _database.ChatAuditDB.Add(chatAuditClass);
            _database.SaveChanges();
            return true;
        }

        //method which will create the onlyaudit
    }
}
