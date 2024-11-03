using CRM.Entity.DTO.Group;
using FluentValidation;

namespace CRM.Api.Validation.FluentValidation
{
    public class AddGroupValidator:AbstractValidator<GroupDTORequest>
    {
        public AddGroupValidator()
        {
            RuleFor(q => q.GrupAdi).NotEmpty().WithMessage("Grup Adı Boş Olamaz");
        }
    }
}
