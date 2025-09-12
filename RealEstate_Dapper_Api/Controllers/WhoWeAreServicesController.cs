using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Dtos.WhoWeAreServiceDtos;
using RealEstate_Dapper_Api.Repositories.WhoWeAreRepository;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WhoWeAreServicesController : ControllerBase
    {
        private readonly IWhoWeAreServiceRepository _whoWeAreService;

        public WhoWeAreServicesController(IWhoWeAreServiceRepository whoWeAreService)
        {
            _whoWeAreService = whoWeAreService;
        }

        [HttpGet]
        public async Task<IActionResult> WhoWeAreServiceList()
        {
           var values = await _whoWeAreService.GetAllWhoWeAreServiceAsync();
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateWhoWeAreService(CreateWhoWeAreServiceDto createWhoWeAreServiceDto)
        {
            _whoWeAreService.CreateWhoWeAreService(createWhoWeAreServiceDto);
            return Ok("Biz Kimiz Servisler Kısmı Başarıyla Eklendi.");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteWhoWeAreService(int id)
        {
            _whoWeAreService.DeleteWhoWeAreService(id);
            return Ok("Biz Kimiz Servisler Kısmı Başarıyla Silindi.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateWhoWeAreService(UpdateWhoWeAreServiceDto updateWhoWeAreServiceDto)
        {
            _whoWeAreService.UpdateWhoWeAreService(updateWhoWeAreServiceDto);
            return Ok("Biz Kimiz Servisler Kısmı Başarıyla Güncellendi.");
        }

        [HttpGet("GetIDWhoWeAreService")]
        public async Task<IActionResult> GetIDWhoWeAreService(int id)
        {
            var value = await _whoWeAreService.GetWhoWeAreService(id);
            return Ok(value);
        }
    }
}
