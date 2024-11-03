using CRM.Api.Validation.FluentValidation;
using CRM.Business.Abstract;
using CRM.Business.Concrete;
using CRM.Entity.DTO.Group;
using CRM.Entity.Poco;
using CRM.Entity.Result;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.IdentityModel.Tokens;
using System.Net;

namespace CRM.Api.Controllers
{

    [ApiController]
    [Route("CRMApi/[action]")]
    public class GroupController : Controller
    {

        private readonly IGroupService _groupService;

        public GroupController(IGroupService groupService)
        {
            _groupService = groupService;
        }

        [HttpPost("/Group")]
        public async Task<IActionResult> AddGroup(GroupDTORequest grupDTO)
        {
            Sonuc<bool>sonuc = new Sonuc<bool>();

            AddGroupValidator addGroupValidator = new AddGroupValidator();

            if (addGroupValidator.Validate(grupDTO).IsValid)
            {
                Group group = new Group();
                group.Name = grupDTO.GrupAdi;
                group.Comments = grupDTO.Comments;
                await _groupService.AddAsync(group);

                sonuc.Data = true;
                sonuc.Mesaj = "İşlem Başarılı";
                sonuc.StatusCode = (int)HttpStatusCode.OK;

                return Ok(sonuc);
            }
            else { 
            List<string> validationMessage = new List<string>();

                for (int i = 0; i < addGroupValidator.Validate(grupDTO).Errors.Count; i++)
                {
                    validationMessage.Add(addGroupValidator.Validate(grupDTO).Errors[i].ErrorMessage);
                }

                sonuc.Data = false;
                sonuc.Mesaj = "Hata Oluştu";
                sonuc.StatusCode= (int)HttpStatusCode.BadRequest;
                sonuc.HataBilgisi = new HataBilgisi()
                {
                    Hata = "Eksik Alanlar Mevcut",
                    HataAciklama = validationMessage
                };

                return BadRequest(sonuc);
            }

        }

        [HttpGet("/Groups")]
        public async Task<IActionResult> GetGroups()
        {
            Sonuc<IEnumerable<GroupDTOResponse>> sonuc = new();

            var groups = await _groupService.GetAllAsync(q => q.IsActive == true);
            if (groups == null)
            {
                sonuc.Data = Enumerable.Empty<GroupDTOResponse>();
                sonuc.Mesaj = "Grup Bulunamadı";
                sonuc.StatusCode = (int)HttpStatusCode.NotFound;

                return NotFound(sonuc);
            }


            List<GroupDTOResponse> groupListResponse = new List<GroupDTOResponse>();


            foreach (var group in groups)
            {

                GroupDTOResponse groupDTOResponse = new GroupDTOResponse();

                groupDTOResponse.GrupAdi = group.Name;
                groupDTOResponse.Comments = group.Comments;
                groupDTOResponse.Guid = group.guid;

                groupListResponse.Add(groupDTOResponse);
            }

            sonuc.Data= groupListResponse;
            sonuc.Mesaj = "İşlem Başarılı";
            sonuc.StatusCode= (int)HttpStatusCode.OK;

            return Ok(sonuc);

        }

        [HttpGet("/Group/{guid}")]
        public async Task<IActionResult> GetGroup(Guid guid)
        {
            Sonuc<GroupDTOResponse> sonuc = new();

            var group = await _groupService.GetAsync(q => q.guid == guid);


            if (group is null)
            {
                sonuc.Data = null;
                sonuc.Mesaj = "Grup Bulunamadı";
                sonuc.StatusCode = (int)HttpStatusCode.NotFound;
                return NotFound(sonuc);
            }
            else if(group is not null && group.IsDeleted is true)
            {
                sonuc.Data = null;
                sonuc.Mesaj = "Bu Grup Silinmiştir. Detaylarını Görmek İstiyorsanız. Tekrar Aktif Ediniz.";
                sonuc.StatusCode = (int)HttpStatusCode.NotFound;

                return NotFound(sonuc);
            }

            GroupDTOResponse groupDTOResponse = new GroupDTOResponse();
            groupDTOResponse.Guid = group.guid;
            groupDTOResponse.GrupAdi = group.Name;
            groupDTOResponse.Comments = group.Comments;


            sonuc.Data = groupDTOResponse;
            sonuc.Mesaj = "İşlem Başarılı";
            sonuc.StatusCode = (int)HttpStatusCode.OK;

            return Ok(sonuc);
        }

        //[HttpDelete("/Group/{guid}")]
        //public async Task<IActionResult> DeleteGroup(Guid guid)
        //{
        //    var group = await _groupService.GetAsync(q => q.guid == guid);

        //    if (group is null)
        //    {
        //        return NotFound();
        //    }

        //    await _groupService.DeleteAsync(group);

        //    return Ok("İşlem Başarılı");
        //}


        [HttpDelete("/Group/{guid}")]
        public async Task<IActionResult> DeleteGroup(Guid guid)
        {
            Sonuc<bool> sonuc = new();
            var group = await _groupService.GetAsync(q => q.guid == guid);

            if (group is null)
            {
                sonuc.Data = false;
                sonuc.Mesaj = "Grup Bulunamadı";
                sonuc.StatusCode = (int)HttpStatusCode.NotFound;
                return NotFound(sonuc);
            }
            group.IsActive = false;
            group.IsDeleted = true;
            await _groupService.UpdateAsync(group);


            sonuc.Data = true;
            sonuc.Mesaj = "İşlem Başarılı";
            sonuc.StatusCode = (int)HttpStatusCode.OK;

            return Ok(sonuc);
        }
        
        [HttpPut("/Group")]
        public async Task<IActionResult> UpdateGroup(GroupDTORequest groupDTORequest)
        {
            Sonuc<bool> sonucBilgisi = new Sonuc<bool>();

           UpdateGroupValidator validationRules = new UpdateGroupValidator();



            if (validationRules.Validate(groupDTORequest).IsValid)
            {

                var group = await _groupService.GetAsync(q => q.guid == groupDTORequest.Guid);

                if (group is null)
                {
                    sonucBilgisi.Data = false;
                    sonucBilgisi.StatusCode = (int)HttpStatusCode.NotFound;
                    sonucBilgisi.Mesaj = "Hata Oluştu";

                    sonucBilgisi.HataBilgisi = new HataBilgisi()
                    {
                        Hata = "Parametre Hatası",
                        HataAciklama = new List<string>() { "Grup Bilgisi Bulunamadığından Dolayı Güncelleme İşlemi Yapılamadı." }
                    };

                    return NotFound(sonucBilgisi);
                }


                group.IsActive = groupDTORequest.IsActive;
                group.IsDeleted = groupDTORequest.IsDeleted;
                group.Name = groupDTORequest.GrupAdi;
                group.Comments = groupDTORequest.Comments;
                await _groupService.UpdateAsync(group);

                sonucBilgisi.Data=true;
                sonucBilgisi.Mesaj = "İşlem Başarılı";
                sonucBilgisi.StatusCode = 200;


                return Ok(sonucBilgisi);
            }

            else {

                List<string>errors = new List<string>();

                for (int i = 0; i < validationRules.Validate(groupDTORequest).Errors.Count; i++)
                {
                    errors.Add(validationRules.Validate(groupDTORequest).Errors[i].ErrorMessage);
                }

                return BadRequest(errors);

            }


        }

    }
}
