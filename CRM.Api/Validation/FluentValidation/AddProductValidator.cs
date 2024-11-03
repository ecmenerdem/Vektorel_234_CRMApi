using CRM.Entity.DTO.Product;
using FluentValidation;

namespace CRM.Api.Validation.FluentValidation
{
    public class AddProductValidator:AbstractValidator<ProductDTOModel>
    {
        public AddProductValidator()
        {
            RuleFor(q => q.Name).NotEmpty().WithMessage("Ürün Adı Boş Olamaz");
            RuleFor(q => q.CategoryID).NotEmpty().WithMessage("Ürün Kategorisi Boş Olamaz");
            RuleFor(q => q.Description).NotEmpty().WithMessage("Ürün Açıklaması Boş Olamaz");
        }
    }
}
