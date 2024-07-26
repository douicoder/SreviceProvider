using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceProvider.Shared.Requests
{
    public class RequestDetailClass
    {
        [Key]
        public Guid RequestDetailID { get; set; }
        public Guid? RequestID { get; set; }
        public DateTime? AcceptDate { get; set; }
        public string RequestStatus { get; set; }
        public int? IsCanceledBy { get; set; }
        public Guid? AcceptedByID { get; set; }
    }

}
