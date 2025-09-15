using Dapper;
using RealEstate_Dapper_Api.Dtos.TestimonialDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.TestimonialRepository
{
    public class TestimonialRepository : ITestimonialRepository
    {
        private readonly Context _context;

        public TestimonialRepository(Context context)
        {
            _context = context;
        }

        public async void CreateTestimonial(CreateTestimonialDto createTestimonialDto)
        {
            string query = "Insert into Testimonial (NameSurname,Title,Comment,Status) Values (@nameSurname,@title,@comment,@status)";
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@nameSurname", createTestimonialDto.NameSurname);
            dynamicParameters.Add("@title", createTestimonialDto.Title);
            dynamicParameters.Add("@comment", createTestimonialDto.Comment);
            dynamicParameters.Add("@status", createTestimonialDto.Status);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, dynamicParameters);
            }
        }

        public async void DeleteTestimonial(int id)
        {
            string query = "Delete From Testimonial Where TestimonialID=@testimonialID";
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@testimonialID", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, dynamicParameters);
            }
        }

        public async Task<List<ResultTestimonialDto>> GetAllTestimonialsAsync()
        {
            string query = "Select * From Testimonial";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultTestimonialDto>(query);
                return values.ToList();
            }
        }

        public async Task<GetByIdTestimonialDto> GetByIDTestimonial(int id)
        {
            string query = "select * From Testimonial Where TestimonialID=@testimonialID";
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@testimonialID", id);
            using (var connection = _context.CreateConnection())
            {
                var value = await connection.QueryFirstOrDefaultAsync<GetByIdTestimonialDto>(query, dynamicParameters);
                return value;
            }
        }

        public async void UpdateTestimonial(UpdateTestimonialDto updateTestimonialDto)
        {
            string query = "Update Testimonial Set NameSurname=@nameSurname,Title=@title,Comment=@comment,Status=@status Where TestimonialID=@testimonialID";
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@testimonialID", updateTestimonialDto.TestimonialID);
            dynamicParameters.Add("@nameSurname", updateTestimonialDto.NameSurname);
            dynamicParameters.Add("@title", updateTestimonialDto.Title);
            dynamicParameters.Add("@comment", updateTestimonialDto.Comment);
            dynamicParameters.Add("@status", updateTestimonialDto.Status);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, dynamicParameters);
            }
        }
    }
}
