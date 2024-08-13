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
        public bool NewMegssage(ChatHistoryClass chatHistoryAuditDetails)
        {
            try
            {
                _database.ChatHistoryDB.Add(chatHistoryAuditDetails);
                _database.SaveChanges();
                return true;
            }
            catch(Exception ex) 
            {
                return false;
            }
        }
        public bool CreateNewChatAudit(ChatAuditClass chatAuditClass)
        {
            var ischatAuditexict = _database.ChatAuditDB.Any(x =>x.ShopID== chatAuditClass.ShopID&& x.UserID== chatAuditClass.UserID);
            if (ischatAuditexict)
            {
                return false;
            }

            _database.ChatAuditDB.Add(chatAuditClass);
            _database.SaveChanges();
            return true;
        }

        public Guid GetAuditID(Guid userid, Guid shopid)
        {
            ChatAuditClass? _chatAuditDB = new ChatAuditClass();
            _chatAuditDB = _database.ChatAuditDB.Where(x => x.UserID== userid&&x.ShopID==shopid).FirstOrDefault();

            return _chatAuditDB.AuditID;
        }

        public List<ChatHistoryClass> GetChatHistory(Guid AuditID)
        {
            List<ChatHistoryClass> list=new List<ChatHistoryClass>();
            list=_database.ChatHistoryDB.Where(x=>x.AuditID==AuditID).OrderBy(x=>x.ChatHistoryDate).ToList();
            return list;
        }

        //method which will create the onlyaudit
    }
}
