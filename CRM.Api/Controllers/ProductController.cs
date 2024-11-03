using CRM.Api.Validation.FluentValidation;
using CRM.Business.Abstract;
using CRM.Entity.DTO.Product;
using CRM.Entity.Poco;
using CRM.Entity.Result;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CRM.Api.Controllers
{
    [ApiController]
    [Route("CRMAPI/[action]")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;

        public ProductController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }


        [HttpPost("/Product")]
        [ProducesResponseType<Sonuc<bool>>(200)]
        public async Task<IActionResult> AddProduct(AddProductDTORequest productDTO)
        {
            Sonuc<bool> sonuc = new Sonuc<bool>();

            var category = await _categoryService.GetAsync(q => q.guid == productDTO.CategoryGUID);


            ProductDTOModel model = new()
            {
                Name = productDTO.Name,
                Description = productDTO.Description,
                CategoryID = category?.id,
                ProductImage = productDTO.ProductImage,
            };
            AddProductValidator addProductValidator = new AddProductValidator();

            if (addProductValidator.Validate(model).IsValid)
            {
                Product product = new Product();


                product.Name = model.Name;
                product.Description = model.Description;
                product.CategoryID = (int)model.CategoryID;
                product.ProductImage = model.ProductImage;
                await _productService.AddAsync(product);

                sonuc.Data = true;
                sonuc.Mesaj = "İşlem Başarılı";
                sonuc.StatusCode = (int)HttpStatusCode.OK;

                return Ok(sonuc);
            }
            else
            {
                List<string> validationMessage = new List<string>();

                for (int i = 0; i < addProductValidator.Validate(model).Errors.Count; i++)
                {
                    validationMessage.Add(addProductValidator.Validate(model).Errors[i].ErrorMessage);
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


        [HttpPut("/Product")]
        [ProducesResponseType<Sonuc<bool>>(200)]
        public async Task<IActionResult> UpdateProduct(UpdateProductDTORequest productDTO)
        {
            Sonuc<bool> sonuc = new Sonuc<bool>();

            UpdateProductValidator updateProductValidator = new UpdateProductValidator();
            /*sddsd*/

            if (updateProductValidator.Validate(productDTO).IsValid)
            {


                var category = await _categoryService.GetAsync(q => q.guid == productDTO.CategoryGUID);

                var product = await _productService.GetAsync(q => q.guid == productDTO.ProductGUID);

                product.Name = productDTO.Name;
                product.Description = productDTO.Description;
                product.CategoryID = category.id;
                product.ProductImage = productDTO.ProductImage is not null? productDTO.ProductImage:product.ProductImage;
                await _productService.UpdateAsync(product);

                sonuc.Data = true;
                sonuc.Mesaj = "İşlem Başarılı";
                sonuc.StatusCode = (int)HttpStatusCode.OK;

                return Ok(sonuc);
            }
            else
            {
                List<string> validationMessage = new List<string>();

                for (int i = 0; i < updateProductValidator.Validate(productDTO).Errors.Count; i++)
                {
                    validationMessage.Add(updateProductValidator.Validate(productDTO).Errors[i].ErrorMessage);
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


        [HttpGet("/Products")]
        [ProducesResponseType<Sonuc<List<ProductDTOResponse>>>(200)]
        public async Task<IActionResult> GetProducts()
        {
            Sonuc<IEnumerable<ProductDTOResponse>> sonuc = new();

            var products = await _productService.GetAllAsync(q => q.IsActive == true, "Category");


            if (products == null)
            {
                sonuc.Data = Enumerable.Empty<ProductDTOResponse>();
                sonuc.Mesaj = "Ürün Bulunamadı";
                sonuc.StatusCode = (int)HttpStatusCode.NotFound;

                return NotFound(sonuc);
            }


            List<ProductDTOResponse> productListResponse = new List<ProductDTOResponse>();


            foreach (var product in products)
            {

                ProductDTOResponse productDTOResponse = new ProductDTOResponse();

                productDTOResponse.GUID = product.guid;
                productDTOResponse.Ad = product.Name;
                productDTOResponse.Aciklama = product.Description;
                productDTOResponse.KategoriAdi = product.Category.Name;
                productDTOResponse.OneCikanGorsel = product.ProductImage;
                productDTOResponse.KategoriGUID = product.Category.guid;


                productListResponse.Add(productDTOResponse);
            }

            sonuc.Data = productListResponse;
            sonuc.Mesaj = "İşlem Başarılı";
            sonuc.StatusCode = (int)HttpStatusCode.OK;

            return Ok(sonuc);

        }

        [HttpGet("/Product/{productGUID}")]
        [ProducesResponseType<Sonuc<ProductDTOResponse>>(200)]
        public async Task<IActionResult> GetProduct(Guid productGUID)
        {
            Sonuc<ProductDTOResponse> sonuc = new();

            var product = await _productService.GetAsync(q => q.guid == productGUID, "Category");


            if (product is not null)
            {
                ProductDTOResponse productDTOResponse = new ProductDTOResponse();

                productDTOResponse.GUID = product.guid;
                productDTOResponse.Ad = product.Name;
                productDTOResponse.Aciklama = product.Description;
                productDTOResponse.KategoriAdi = product.Category.Name;
                productDTOResponse.OneCikanGorsel = product.ProductImage;
                productDTOResponse.KategoriGUID = product.Category.guid;
                sonuc.Data = productDTOResponse;
                sonuc.Mesaj = "İşlem Başarılı";
                sonuc.StatusCode = (int)HttpStatusCode.OK;

                return Ok(sonuc);
            }
            sonuc.Data = null;
            sonuc.Mesaj = "Ürün Bulunamadı";
            sonuc.StatusCode = (int)HttpStatusCode.NotFound;
            return NotFound(sonuc);

        }

    }
}
