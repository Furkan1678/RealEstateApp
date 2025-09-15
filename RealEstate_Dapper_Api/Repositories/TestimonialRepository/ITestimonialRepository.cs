using RealEstate_Dapper_Api.Dtos.TestimonialDtos;

namespace RealEstate_Dapper_Api.Repositories.TestimonialRepository
{
    public interface ITestimonialRepository
    {
        Task<List<ResultTestimonialDto>> GetAllTestimonialsAsync();
        void UpdateTestimonial(UpdateTestimonialDto updateTestimonialDto);
        void DeleteTestimonial(int id);
        void CreateTestimonial(CreateTestimonialDto createTestimonialDto);
        Task<GetByIdTestimonialDto> GetByIDTestimonial(int id);
    }
}
