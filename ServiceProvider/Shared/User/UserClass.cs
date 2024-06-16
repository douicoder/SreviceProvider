using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace Class.User.UserModel
{
  

    public class UserModel
    {
        [Key]
        [Required]
        public Guid? ID { get; set; }//

        [Required]
        public string FirstName { get; set; }//

        [Required]
        public string LastName { get; set; }//



        [Required(ErrorMessage = "You must provide a phone number")]
        
        [DataType(DataType.PhoneNumber)]
       // [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]      
        public string PhoneNumber { get; set; }//

        [Required(ErrorMessage = "Provide a valid email")]
        [DataType(DataType.EmailAddress)]
        public string EmailID { get; set; }//

        [Required]
        public string Password { get; set; }//

        [Required]
        public int CategoryID { get; set; }//
    }

}
