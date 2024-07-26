using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceProvider.Shared.Chats
{
    public class ChatHistoryClass
    {
        [Key]
        public Guid ChatHistoryID { get; set; }
        public Guid AuditID { get; set; }
        public string Messege { get; set; }
        public string ShopName { get; set; }
        public string UserName { get; set; }
        public string MessegeFrom { get; set; }
        public DateTime ChatHistoryDate { get; set; }
    }
}
