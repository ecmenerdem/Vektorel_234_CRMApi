using CRM.Api.Validation.FluentValidation;
using CRM.Business.Abstract;
using CRM.Entity.DTO.Group;
using CRM.Entity.DTO.User;
using CRM.Entity.Poco;
using CRM.Entity.Result;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CRM.Api.Controllers
{
    [ApiController]
    [Route("CRMAPI/[action]")]
    public class UserContoller : Controller
    {
        private readonly IUserService _userService;
        private readonly IGroupService _groupService;

        public UserContoller(IUserService userService, IGroupService groupService)
        {
            _userService = userService;
            _groupService = groupService;
        }


        [HttpPost("/User")]
        public async Task<IActionResult> AddUser(UserRegistrationDTORequest userDTO)
        {
            Sonuc<bool> sonuc = new Sonuc<bool>();

            var grup = await _groupService.GetAsync(q => q.guid == userDTO.GrupGUID);


            UserDTOModel model = new()
            {
                Ad = userDTO.Ad,
                Soyad = userDTO.Soyad,
                EPosta = userDTO.EPosta,
                GrupGUID = userDTO.GrupGUID,
                KullaniciAdi = userDTO.KullaniciAdi,
                Sifre = userDTO.Sifre
            };
            model.GrupID = grup?.id;
            AddUserValidator addUserValidator = new AddUserValidator();

            if (addUserValidator.Validate(model).IsValid)
            {
                User user = new User();


                user.FirstName = userDTO.Ad;
                user.LastName = userDTO.Soyad;
                user.Username = userDTO.KullaniciAdi;
                user.Password = userDTO.Sifre;
                user.Email = userDTO.EPosta;
                user.GroupID = grup.id;
                await _userService.AddAsync(user);

                sonuc.Data = true;
                sonuc.Mesaj = "İşlem Başarılı";
                sonuc.StatusCode = (int)HttpStatusCode.OK;

                return Ok(sonuc);
            }
            else
            {
                List<string> validationMessage = new List<string>();

                for (int i = 0; i < addUserValidator.Validate(model).Errors.Count; i++)
                {
                    validationMessage.Add(addUserValidator.Validate(model).Errors[i].ErrorMessage);
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



        [HttpGet("/Users")]
        public async Task<IActionResult> GetUsers()
        {
            Sonuc<IEnumerable<UserDTOResponse>> sonuc = new();

            var users = await _userService.GetAllAsync(q => q.IsActive == true, "Group");


            if (users == null)
            {
                sonuc.Data = Enumerable.Empty<UserDTOResponse>();
                sonuc.Mesaj = "Kullanıcı Bulunamadı";
                sonuc.StatusCode = (int)HttpStatusCode.NotFound;

                return NotFound(sonuc);
            }


            List<UserDTOResponse> userListResponse = new List<UserDTOResponse>();


            foreach (var user in users)
            {

                UserDTOResponse userDTOResponse = new UserDTOResponse();

                userDTOResponse.GUID = user.guid;
                userDTOResponse.Ad = user.FirstName;
                userDTOResponse.Soyad = user.LastName;
                userDTOResponse.KullaniciAdi = user.Username;
                userDTOResponse.Sifre = user.Password;
                userDTOResponse.EPosta = user.Email;

                userDTOResponse.GrupAdi = user.Group.Name;
                userDTOResponse.GrupGUID = user.Group.guid;

                userListResponse.Add(userDTOResponse);
            }

            sonuc.Data = userListResponse;
            sonuc.Mesaj = "İşlem Başarılı";
            sonuc.StatusCode = (int)HttpStatusCode.OK;

            return Ok(sonuc);

        }


        [HttpPut("/User")]
        public async Task<IActionResult> UpdateUser(UserUpdateDTORequest userDTO)
        {
            Sonuc<bool> sonucBilgisi = new Sonuc<bool>();

            var grup = await _groupService.GetAsync(q => q.guid == userDTO.GrupGUID);


            UserDTOModel model = new()
            {
                Ad = userDTO.Ad,
                Soyad = userDTO.Soyad,
                EPosta = userDTO.EPosta,
                GrupGUID = userDTO.GrupGUID,
                Sifre = userDTO.Sifre,
                GUID = userDTO.UserGUID,
            };
            model.GrupID = grup?.id;


            UpdateUserValidator validationRules = new UpdateUserValidator();



            if (validationRules.Validate(model).IsValid)
            {

                var user = await _userService.GetAsync(q => q.guid == model.GUID);

                if (user is null)
                {
                    sonucBilgisi.Data = false;
                    sonucBilgisi.StatusCode = (int)HttpStatusCode.NotFound;
                    sonucBilgisi.Mesaj = "Hata Oluştu";

                    sonucBilgisi.HataBilgisi = new HataBilgisi()
                    {
                        Hata = "Parametre Hatası",
                        HataAciklama = new List<string>() { "Kullanıcı Bilgisi Bulunamadığından Dolayı Güncelleme İşlemi Yapılamadı." }
                    };

                    return NotFound(sonucBilgisi);
                }



                user.FirstName = userDTO.Ad;
                user.LastName = userDTO.Soyad;
                user.Password = userDTO.Sifre;
                user.GroupID = (int)model.GrupID;
                user.Email = userDTO.EPosta;
                await _userService.UpdateAsync(user);

                sonucBilgisi.Data = true;
                sonucBilgisi.Mesaj = "İşlem Başarılı";
                sonucBilgisi.StatusCode = 200;


                return Ok(sonucBilgisi);
            }

            else
            {

                List<string> errors = new List<string>();

                for (int i = 0; i < validationRules.Validate(model).Errors.Count; i++)
                {
                    errors.Add(validationRules.Validate(model).Errors[i].ErrorMessage);
                }

                return BadRequest(errors);

            }


        }

        [HttpDelete("/User/{userGUID}")]
        public async Task<IActionResult> DeleteUser(Guid userGUID)
        {
            Sonuc<bool> sonuc = new Sonuc<bool>();


            var user = await _userService.GetAsync(q => q.guid == userGUID);

            user.IsActive = false;
            user.IsDeleted = true;

            await _userService.UpdateAsync(user);

            sonuc.Data = true;
            sonuc.Mesaj = "İşlem Başarılı";
            sonuc.StatusCode = (int)HttpStatusCode.OK;

            return Ok(sonuc);
        }

        [HttpGet("/User/{userGUID}")]
        public async Task<IActionResult> GetUser(Guid userGUID)
        {
            Sonuc<UserDTOResponse> sonuc = new();

            var user = await _userService.GetAsync(q => q.guid == userGUID, "Group");


            if (user == null)
            {
                sonuc.Data = new UserDTOResponse();
                sonuc.Mesaj = "Kullanıcı Bulunamadı";
                sonuc.StatusCode = (int)HttpStatusCode.NotFound;

                return NotFound(sonuc);
            }

            UserDTOResponse userDTOResponse = new UserDTOResponse();

            userDTOResponse.GUID = user.guid;
            userDTOResponse.Ad = user.FirstName;
            userDTOResponse.Soyad = user.LastName;
            userDTOResponse.KullaniciAdi = user.Username;
            userDTOResponse.Sifre = user.Password;
            userDTOResponse.EPosta = user.Email;
            userDTOResponse.GrupAdi = user.Group.Name;
            userDTOResponse.GrupGUID = user.Group.guid;


        

        sonuc.Data = userDTOResponse;
            sonuc.Mesaj = "İşlem Başarılı";
            sonuc.StatusCode = (int) HttpStatusCode.OK;

            return Ok(sonuc);

    }
}
}
