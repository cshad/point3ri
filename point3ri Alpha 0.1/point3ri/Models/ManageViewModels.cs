using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;

namespace point3ri.Models
{
    public class IndexViewModel
    {
        public bool HasPassword { get; set; }
        public IList<UserLoginInfo> Logins { get; set; }
        public string PhoneNumber { get; set; }
        public bool TwoFactor { get; set; }
        public bool BrowserRemembered { get; set; }
    }

    public class ManageLoginsViewModel
    {
        public IList<UserLoginInfo> CurrentLogins { get; set; }
        public IList<AuthenticationDescription> OtherLogins { get; set; }
    }

    public class FactorViewModel
    {
        public string Purpose { get; set; }
    }

    public class SetPasswordViewModel
    {
        [Required]
        [StringLength(100, ErrorMessage = "{0} mora biti {2} znakova duga.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Nova zaporka")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Potvrda nove zaporke")]
        [Compare("NewPassword", ErrorMessage = "Zaporka i potvrda se ne podudaraju.")]
        public string ConfirmPassword { get; set; }
    }

    public class ChangePasswordViewModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Trenutna zaporka")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "{0} mora biti {2} znakova duga..", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Nova zaporka")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Potvrda nove zaporke")]
        [Compare("NewPassword", ErrorMessage = "Zaporka i potvrda se ne podudaraju.")]
        public string ConfirmPassword { get; set; }
    }

    public class AddPhoneNumberViewModel
    {
        [Required]
        [Phone]
        [Display(Name = "Broj mobitela")]
        public string Number { get; set; }
    }

    public class VerifyPhoneNumberViewModel
    {
        [Required]
        [Display(Name = "Kod")]
        public string Code { get; set; }

        [Required]
        [Phone]
        [Display(Name = "Broj mobitela")]
        public string PhoneNumber { get; set; }
    }

    public class ConfigureTwoFactorViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
    }
}