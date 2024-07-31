using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ServiceProvider.Shared.Requests
{
    public class RequestClass
    {
        [Key]
        public Guid RequestID { get; set; }//auto//
        [Required]
        public Guid? UserID { get; set; }//auto//
        [Required]
        public string Problem { get; set; }///
        [Required]
        public string Description { get; set; }//
        [Required]
        public string Pincode { get; set; }//
        [Required]
        public DateTime? CreateDate { get; set; }//auto
        [Required]
        public bool? IsCanceled { get; set; }//auto
        public bool? IsAccepted { get; set; }//auto
   
        public int? IsCanceledBy { get; set; }//auto

        public Guid? IsCanceledByID { get; set; }//auto

        public string? CancelReason { get; set; }//auto
     
        public DateTime? CancelResonDate { get; set; }//auto
        
    }

}
