using CRM.Entity.DTO.Product;
using FluentValidation;

namespace CRM.Api.Validation.FluentValidation
{
    public class UpdateProductValidator:AbstractValidator<UpdateProductDTORequest>
    {
        public UpdateProductValidator()
        {
            RuleFor(q => q.ProductGUID).NotEmpty().WithMessage("Ürün Boş Olamaz");
            RuleFor(q => q.Name).NotEmpty().WithMessage("Ürün Adı Boş Olamaz");
            RuleFor(q => q.CategoryGUID).NotEmpty().WithMessage("Ürün Kategorisi Boş Olamaz");
            RuleFor(q => q.Description).NotEmpty().WithMessage("Ürün Açıklaması Boş Olamaz");
        }
    }
}
