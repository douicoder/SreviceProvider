using System.ComponentModel.DataAnnotations;

namespace Class.User.verify;
public class VerifyModel
{
    [Required(ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "Invalid email address")]
    public string? Email { get; set; }

    [Required(ErrorMessage = "Verification code is required")]
    public int? VerificationCode { get; set; }
}