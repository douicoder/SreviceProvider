using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceProvider.Shared.Chats
{
    public class ChatHistoryAuditDetailsClass
    {
        //public Guid ChatHistoryID { get; set; }
        //public Guid AuditID { get; set; }
        //public string Messege { get; set; }
        //public string ShopName { get; set; }
        //public string UserName { get; set; }
        //public string MessegeFrom { get; set; }
        //public DateTime ChatHistoryDate { get; set; }

        //public Guid ShopID { get; set; }
        //public Guid UserID { get; set; }
        //public DateTime AuditDate{get; set;}

        public ChatAuditClass auditClass { get; set; }
        public ChatHistoryClass chatHistoryClass { get; set; }

    }

    public class ChatHistoryAuditDetailsClassResponse
    {
        //public Guid ChatHistoryID { get; set; }
        //public Guid AuditID { get; set; }
        //public string Messege { get; set; }
        //public string ShopName { get; set; }
        //public string UserName { get; set; }
        //public string MessegeFrom { get; set; }
        //public DateTime ChatHistoryDate { get; set; }

        //public Guid ShopID { get; set; }
        //public Guid UserID { get; set; }
        //public DateTime AuditDate{get; set;}

        public ChatAuditClass auditClass { get; set; }
        public List<ChatHistoryClass> chatHistoryClass { get; set; }

    }
}
