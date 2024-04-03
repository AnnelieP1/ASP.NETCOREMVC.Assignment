using System.ComponentModel.DataAnnotations;
using WebApp.Helpers;

namespace WebApp.Models;

public class SignUpViewModel
{
    [Display(Name ="First name", Prompt = "Enter your first name.")]
    [Required(ErrorMessage ="You must enter a first name")]
    [MinLength(2, ErrorMessage = "A valid first name is required")]
    [DataType(DataType.Text)]
    public string FirstName { get; set; } = null!;


    [Display(Name ="Last name", Prompt = "Enter your last name.")]
    [Required(ErrorMessage = "You must enter a last name")]
    [MinLength(2, ErrorMessage = "A valid last name is required")]
    [DataType(DataType.Text)]
    public string LastName { get; set; } = null!;


    [Display(Name ="Email address", Prompt = "Enter your email address.")]
    [Required(ErrorMessage ="You must enter an email address")]
    [RegularExpression(@"^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?(?:\.[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?)*\.[a-zA-Z]{2,}$", ErrorMessage = "An valid email address is required")]
    [MinLength(2, ErrorMessage = "A valid email address is required")]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; } = null!;
    

    [Display(Name ="Password", Prompt = "Enter your password.")]
    [Required(ErrorMessage = "You must enter a password.")]
    [RegularExpression(@"^(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z])(?=.*[\W_])(?!.*\s).{8,}$", ErrorMessage = "A valid password is required")]
    [MinLength(8, ErrorMessage = "A valid password is required")]
    [DataType(DataType.Password)]
    public string Password { get; set; } = null!;


    [Display(Name ="Confirm password", Prompt = "Confirm your password.")]
    [Required(ErrorMessage = "Password must be confirmed.")]
    [Compare(nameof(Password), ErrorMessage = "Passwords don't match.")]
    [DataType(DataType.Password)]
    public string ConfirmPassword { get; set; } = null!;


    
    [CheckboxRequired(ErrorMessage = "You must accept the Terms and Conditions")]
    [Display(Name ="Terms & Conditions", Prompt = "I agree to the Terms & Conditions.")]
    public bool TermsAndConditions { get; set; }
    
}
