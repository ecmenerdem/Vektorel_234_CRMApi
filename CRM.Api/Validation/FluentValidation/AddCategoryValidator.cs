using CRM.Entity.DTO.Category;
using FluentValidation;

namespace CRM.Api.Validation.FluentValidation
{
    public class AddCategoryValidator:AbstractValidator<CategoryAddRequestDTO>
    {
        public AddCategoryValidator()
        {
            RuleFor(q => q.Name).NotEmpty().WithMessage("Kategori Adı Boş Olamaz");
        }
    }
}
