using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceProvider.Shared.User
{
    public class ChangePasswordModel
    {
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Current password is required")]
        public string CurrentPassword { get; set; }

        [Required(ErrorMessage = "New password is required")]
        public string NewPassword { get; set; }
    }
}
