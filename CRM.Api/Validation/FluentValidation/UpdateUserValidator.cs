using CRM.Entity.DTO.User;
using FluentValidation;

namespace CRM.Api.Validation.FluentValidation
{
    public class UpdateUserValidator:AbstractValidator<UserDTOModel>
    {
        public UpdateUserValidator()
        {
            RuleFor(q => q.Ad).NotEmpty().WithMessage("Ad Boş Olamaz");

            RuleFor(q => q.Soyad).NotEmpty().WithMessage("Soyad Boş Olamaz");
        
            RuleFor(q => q.Sifre).NotEmpty().WithMessage("Şifre Boş Olamaz");
           
            RuleFor(q => q.GrupGUID).NotEmpty().WithMessage("Grup Boş Olamaz");
            RuleFor(q => q.GrupID).NotEmpty().WithMessage("Grup Boş Olamaz");
        }
    }
}
