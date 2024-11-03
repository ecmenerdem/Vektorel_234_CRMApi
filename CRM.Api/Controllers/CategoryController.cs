using CRM.Api.Validation.FluentValidation;
using CRM.Business.Abstract;
using CRM.Entity.DTO.Category;
using CRM.Entity.DTO.Group;
using CRM.Entity.Poco;
using CRM.Entity.Result;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CRM.Api.Controllers
{
    [ApiController]
    [Route("CRMApi/[action]")]

    public class CategoryController:Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }


        [HttpPost("/Category")]
        public async Task<IActionResult> AddCategory(CategoryAddRequestDTO categoryDTO)
        {
            Sonuc<bool> sonuc = new Sonuc<bool>();

            AddCategoryValidator addCategoryValidator = new AddCategoryValidator();

            if (addCategoryValidator.Validate(categoryDTO).IsValid)
            {
                Category category = new Category();
                category.Name = categoryDTO.Name;
               
                await _categoryService.AddAsync(category);

                sonuc.Data = true;
                sonuc.Mesaj = "İşlem Başarılı";
                sonuc.StatusCode = (int)HttpStatusCode.OK;

                return Ok(sonuc);
            }
            else
            {
                List<string> validationMessage = new List<string>();

                for (int i = 0; i < addCategoryValidator.Validate(categoryDTO).Errors.Count; i++)
                {
                    validationMessage.Add(addCategoryValidator.Validate(categoryDTO).Errors[i].ErrorMessage);
                }

                sonuc.Data = false;
                sonuc.Mesaj = "Hata Oluştu";
                sonuc.StatusCode = (int)HttpStatusCode.BadRequest;
                sonuc.HataBilgisi = new HataBilgisi()
                {
                    Hata = "Eksik Alanlar Mevcut",
                    HataAciklama = validationMessage
                };

                return BadRequest(sonuc);
            }

        }

        [HttpGet("/Categories")]
        public async Task<IActionResult> GetCategories()
        {
            Sonuc<IEnumerable<CategoryDTOResponse>> sonuc = new();

            var categories = await _categoryService.GetAllAsync(q => q.IsActive == true);
            if (categories == null)
            {
                sonuc.Data = Enumerable.Empty<CategoryDTOResponse>();
                sonuc.Mesaj = "Kategori Bulunamadı";
                sonuc.StatusCode = (int)HttpStatusCode.NotFound;

                return NotFound(sonuc);
            }


            List<CategoryDTOResponse> categoryListResponse = new List<CategoryDTOResponse>();


            foreach (var category in categories)
            {

                CategoryDTOResponse categoryDTOResponse = new CategoryDTOResponse();

                categoryDTOResponse.KategoriAdi = category.Name;
                categoryDTOResponse.Comments = category.Comments;
                categoryDTOResponse.Guid = category.guid;

                categoryListResponse.Add(categoryDTOResponse);
            }

            sonuc.Data = categoryListResponse;
            sonuc.Mesaj = "İşlem Başarılı";
            sonuc.StatusCode = (int)HttpStatusCode.OK;

            return Ok(sonuc);

        }
    }
}
