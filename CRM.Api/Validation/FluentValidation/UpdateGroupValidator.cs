using CRM.Entity.DTO.Group;
using FluentValidation;

namespace CRM.Api.Validation.FluentValidation
{
    public class UpdateGroupValidator:AbstractValidator<GroupDTORequest>
    {
        public UpdateGroupValidator()
        {
            RuleFor(q => q.Guid).NotEmpty().WithMessage("Güncellenecek Nesne Bilgisi Gelmedi");
            RuleFor(q => q.GrupAdi).NotEmpty().WithMessage("Grup Adı Boş Olamaz");
            RuleFor(q => q.IsActive).NotEmpty().WithMessage("Grup Durum Bilgisi(Is Acitve) Boş Olamaz");
            RuleFor(q => q.IsDeleted).NotEmpty().WithMessage("Grup Durum Bilgisi(Is Deleted) Boş Olamaz");
        }
    }
}
