using CRM.Entity.DTO.User;
using FluentValidation;

namespace CRM.Api.Validation.FluentValidation
{
    public class AddUserValidator:AbstractValidator<UserDTOModel>
    {
        public AddUserValidator()
        {
            RuleFor(q => q.Ad).NotEmpty().WithMessage("Ad Boş Olamaz");

            RuleFor(q => q.Soyad).NotEmpty().WithMessage("Soyad Boş Olamaz");
            RuleFor(q => q.KullaniciAdi).NotEmpty().WithMessage("Kullanıcı Adı Boş Olamaz");
            RuleFor(q => q.Sifre).NotEmpty().WithMessage("Şifre Boş Olamaz");
            RuleFor(q => q.EPosta).NotEmpty().WithMessage("E-Posta Boş Olamaz");
            RuleFor(q => q.GrupGUID).NotEmpty().WithMessage("Grup Boş Olamaz");
            RuleFor(q => q.GrupID).NotEmpty().WithMessage("Grup Boş Olamaz");
        }
    }
}
