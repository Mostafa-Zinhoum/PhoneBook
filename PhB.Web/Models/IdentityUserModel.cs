

using System.ComponentModel.DataAnnotations;

namespace PhB.Web.Models
{
    public class IdentityUserModel
    {
        [Required]
        //[Display(Name = "UserName", ResourceType =typeof(ResourceEn))]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        //[Display(Name = "Password", ResourceType = typeof(ResourceAr))]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        //[Display(Name = "Email", ResourceType = typeof(ResourceAr))]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password")]
        //[Display(Name = "ConfirmPassword", ResourceType = typeof(ResourceAr))]
        public string ConfirmPassword { get; set; }
    }

    public class LoginModel
    {
        [Required]
        //[Display(Name = "UserName", ResourceType = typeof(Resources))]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        //[Display(Name = "Password", ResourceType = typeof(ResourceAr))]
        public string Password { get; set; }
        [Display(Name ="Remember me")]
        public bool Rememberme { get; set; }  
    }
}
