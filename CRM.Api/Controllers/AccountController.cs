using CRM.Business.Abstract;
using CRM.Entity.DTO.Login;
using CRM.Entity.Result;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;

namespace CRM.Api.Controllers
{
    [ApiController]
    [Route("CRMApi/[action]")]
    public class AccountController : Controller
    {
        private readonly IUserService _userService;
        private readonly IConfiguration _configuration;

        public AccountController(IUserService userService, IConfiguration configuration)
        {
            _userService = userService;
            _configuration = configuration;
        }

        [HttpPost("/Login")]
        public async Task<IActionResult> LoginAsync(LoginRequestDTO loginDTORequest)
        {
            var user = await _userService.GetAsync(q => q.Username == loginDTORequest.KullaniciAdi && q.Password == loginDTORequest.Sifre);

            if (user is null)
            {
                Sonuc<LoginResponseDTO> sonuc = new Sonuc<LoginResponseDTO>();
                LoginResponseDTO loginResponseDTO = new();
                sonuc.Data = loginResponseDTO;
                sonuc.Mesaj = "Hata Oluştu";
                sonuc.StatusCode = (int)HttpStatusCode.NotFound;
                sonuc.HataBilgisi = new HataBilgisi()
                {
                    Hata = "Login Hatası",
                    HataAciklama = new List<string>() { "Kullanıcı Bulunamadı" }
                };
                return NotFound(sonuc);
            }
            else {

                var key = Encoding.UTF8.GetBytes(_configuration.GetValue<string>("AppSettings:JWTKey"));

                var claims = new List<Claim>();

                claims.Add(new Claim("Ad", user.FirstName));
                claims.Add(new Claim("Soyad", user.LastName));
                claims.Add(new Claim("KullaniciAdi", user.Username));

                var jwt = new JwtSecurityToken(
                    
                    expires:DateTime.Now.AddYears(30),
                    claims: claims,
                    issuer:"https://asdasddasdas.com",
                    signingCredentials:new SigningCredentials(new SymmetricSecurityKey(key),SecurityAlgorithms.HmacSha256Signature));

                var token = new JwtSecurityTokenHandler().WriteToken(jwt);

                Sonuc<LoginResponseDTO> sonuc = new Sonuc<LoginResponseDTO>();

                LoginResponseDTO loginResponse = new LoginResponseDTO()
                {
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Token = token,
                    Email = user.Email,
                    UserID = user.id,
                    Username = user.Username,
                };

                sonuc.Data = loginResponse;
                sonuc.Mesaj = "İşlem Başarılı";
                sonuc.StatusCode = (int)HttpStatusCode.OK;

                return Ok(sonuc);

            }

        }
    }
}
