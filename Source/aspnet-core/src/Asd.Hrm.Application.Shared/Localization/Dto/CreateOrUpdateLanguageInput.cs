using System.ComponentModel.DataAnnotations;

namespace Asd.Hrm.Localization.Dto
{
    public class CreateOrUpdateLanguageInput
    {
        [Required]
        public ApplicationLanguageEditDto Language { get; set; }
    }
}