using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Dtos.TestimonialDtos;
using RealEstate_Dapper_Api.Repositories.TestimonialRepository;


namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialsController : ControllerBase
    {
        private readonly ITestimonialRepository _testimonialRepository;

        public TestimonialsController(ITestimonialRepository testimonialRepository)
        {
            _testimonialRepository = testimonialRepository;
        }
      
        [HttpGet]
        public async Task<IActionResult> TestimonialList()
        {
            var values = await _testimonialRepository.GetAllTestimonialsAsync();
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateTestimonial(CreateTestimonialDto createTestimonialDto)
        {
            _testimonialRepository.CreateTestimonial(createTestimonialDto);
            return Ok("Yorum Başarıyla Oluşturuldu.");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteTestimonial(int id)
        {
            _testimonialRepository.DeleteTestimonial(id);
            return Ok("Yorum Başarıyla Silindi.");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateTestimonial(UpdateTestimonialDto updateTestimonialDto)
        {
            _testimonialRepository.UpdateTestimonial(updateTestimonialDto);
            return Ok("Yorum Başarıyla Güncellendi.");
        }
        [HttpGet("GetByIDTestimonial")]
        public async Task<IActionResult> GetByIDTestimonial(int id)
        {
            var value = await _testimonialRepository.GetByIDTestimonial(id);
            return Ok(value);
        }
    }
}
