
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceProvider.Shared.Requests
{
    public class GetRequestInfoModel
    {
        [Key]
        public Guid RequestID { get; set; }//auto//1
        [Required]
        public Guid? UserID { get; set; }//auto//2
        [Required]
        public string Problem { get; set; }///3
        [Required]
        public string Description { get; set; }//4
        [Required]
        public string Pincode { get; set; }//5
        [Required]
        public DateTime? CreateDate { get; set; }//auto//6
        [Required]
        public bool? IsCanceled { get; set; }//auto//7
        public bool? IsAccepted { get; set; }//auto//8

        public int? IsCanceledBy { get; set; }//auto//9

        public Guid? IsCanceledByID { get; set; }//auto//10
        
        public string? CancelReason { get; set; }//auto//11

        public DateTime? CancelResonDate { get; set; }//auto//12

        [Key]
        public Guid RequestDetailID { get; set; }//13
      
        public DateTime? AcceptDate { get; set; }//14
        public string RequestStatus { get; set; }//15

        public Guid? AcceptedByID { get; set; }//16

    }
}
