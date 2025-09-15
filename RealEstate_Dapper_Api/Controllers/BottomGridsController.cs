using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Dtos.BottomGridDtos;
using RealEstate_Dapper_Api.Repositories.BottomGridRepository;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BottomGridsController : ControllerBase
    {
        private readonly IBottomGridRepository _bottomGridRepository;

        public BottomGridsController(IBottomGridRepository bottomGridRepository)
        {
            _bottomGridRepository = bottomGridRepository;
        }
        [HttpGet]
        public async Task<IActionResult> ListBottomGrid()
        {
            var values = await _bottomGridRepository.GetAllBottomGridAsync();
            return Ok(values);
        } 
        [HttpPost]
        public async Task<IActionResult> CreateBottomGrid(CreateBottomGridDto createBottomGridDto)
        {
             _bottomGridRepository.CreateBottomGrid(createBottomGridDto);
            return Ok("Servisler Başarıyla Oluşturuldu.");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteBottomGrid(int id)
        {
            _bottomGridRepository.DeleteBottomGrid(id);
            return Ok("Servisler Başarıyla Silindi.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateBottomGrid(UpdateBottomGridDto updateBottomGridDto)
        {
            _bottomGridRepository.UpdateBottomGrid(updateBottomGridDto);
            return Ok("Servisler Başarıyla Güncellendi.");
        }
        [HttpGet("GetByIDBottomGrid")]
        public async Task<IActionResult> GetByIDBottomGrid(int id)
        {
            var value = await _bottomGridRepository.GetByIdBottomGridAsync(id);
            return Ok(value);
        }
    }
}
