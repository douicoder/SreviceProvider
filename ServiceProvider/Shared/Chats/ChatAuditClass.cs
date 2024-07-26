using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceProvider.Shared.Chats
{
    public class ChatAuditClass
    {
        [Key]
        public Guid AuditID { get; set; }
        public Guid? ShopID { get; set; }
        public Guid ?UserID { get; set; }
        public DateTime AuditDate { get; set; }
    }
}
