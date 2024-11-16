using System.ComponentModel.DataAnnotations;

namespace Asd.Hrm.Web.Models.Account
{
    public class SendPasswordResetLinkViewModel
    {
        [Required]
        public string EmailAddress { get; set; }
    }
}