using System.ComponentModel.DataAnnotations;

namespace Asd.Hrm.Authorization.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}
