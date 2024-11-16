using System.ComponentModel.DataAnnotations;

namespace Asd.Hrm.Authorization.Accounts.Dto
{
    public class SendEmailActivationLinkInput
    {
        [Required]
        public string EmailAddress { get; set; }
    }
}