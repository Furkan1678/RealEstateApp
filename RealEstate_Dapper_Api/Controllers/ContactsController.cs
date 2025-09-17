using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Dtos.ContactDtos;
using RealEstate_Dapper_Api.Repositories.ContactRepository;
using System.Threading.Tasks;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IContactRepository _contactRepository;

        public ContactsController(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        [HttpGet]
        public async Task<IActionResult> ListContact()
        {
            var values = await _contactRepository.GetAllContactAsync();
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateContact(CreateContactDto createContactDto)
        {
            _contactRepository.CreateContact(createContactDto);
            return Ok("Mesajınız Başarıyla Oluşturuldu");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContact(int id)
        {
            _contactRepository.DeleteContact(id);
            return Ok("Mesajınız Başarıyla Silindi");
        }
        [HttpGet("GetByIdContactAsync{id}")]
        public async Task<IActionResult> GetByIdContactAsync(int id)
        {
            var value = await _contactRepository.GetByIdContactAsync(id);
            return Ok(value);
        }
        [HttpGet("GetAllLast4ContactAsync")]
        public async Task<IActionResult> GetAllLast4ContactAsync()
        {
            var values = await _contactRepository.GetAllLast4ContactAsync();
            return Ok(values);
        }
    }
}
