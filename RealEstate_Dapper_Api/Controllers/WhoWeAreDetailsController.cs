using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Dtos.WhoWeAreDetailDtos;
using RealEstate_Dapper_Api.Repositories.WhoWeAreRepository;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WhoWeAreDetailsController : ControllerBase
    {
        private readonly IWhoWeAreDetailRepository _whoWeAreRepository;

        public WhoWeAreDetailsController(IWhoWeAreDetailRepository whoWeAreRepository)
        {
            _whoWeAreRepository = whoWeAreRepository;
        }

        [HttpGet]
        public async Task<IActionResult> WhoWeAreDetailList()
        {
          var values = await  _whoWeAreRepository.GetAllWhoWeAreDetailAsync();
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateWhoWeAreDetail(CreateWhoWeAreDetailDto createWhoWeAreDetailDto)
        {
            _whoWeAreRepository.CreateWhoWeAreDetail(createWhoWeAreDetailDto);
            return Ok("Biz Kimiz Kısmı Başarıyla Eklenmiştir");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWhoWeAreDetail(int id)
        {
            _whoWeAreRepository.DeleteWhoWeAreDetail(id);
            return Ok("Biz Kimiz Kısmı Başarıyla Silinmiştir");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateWhoWeAreDetail(UpdateWhoWeAreDetailDto updateWhoWeAreDetailDto)
        {
            _whoWeAreRepository.UpdateWhoWeAreDetail(updateWhoWeAreDetailDto);
            return Ok("Biz Kimiz Kısmı Başarıyla Güncellenmiştir");
        }

        [HttpGet("GetIDWhoWeAreDetail{id}")]
        public async Task<IActionResult> GetIDWhoWeAreDetail(int id)
        {
            var value = await _whoWeAreRepository.GetWhoWeAreDetail(id);
            return Ok(value);
        }
    }
}
