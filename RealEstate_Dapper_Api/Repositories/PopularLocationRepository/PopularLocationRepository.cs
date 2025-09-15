using Dapper;
using RealEstate_Dapper_Api.Dtos.PopularLocationDtos;
using RealEstate_Dapper_Api.Models.DapperContext;
using System.Threading.Tasks;

namespace RealEstate_Dapper_Api.Repositories.PopularLocationRepository
{
    public class PopularLocationRepository : IPopularLocationRepository
    {
        private readonly Context _context;

        public PopularLocationRepository(Context context)
        {
            _context = context;
        }

        public async void CreatePopularLocation(CreatePopularLocationDto createPopularLocationDto)
        {
            string query = "Insert into PopularLocation (CityName,ImageUrl) Values (@cityName,@imageUrl)";
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@cityName", createPopularLocationDto.CityName);
            dynamicParameters.Add("@imageUrl", createPopularLocationDto.ImageUrl);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, dynamicParameters);
            }
        }

        public async void DeletePopularLocation(int id)
        {
            string query = "Delete From PopularLocation Where LocationID=@locationID";
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@locationID", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, dynamicParameters);
            }
        }

        public async Task<List<ResultPopularLocationDto>> GetAllPopularLocationsAsync()
        {
            string query = "Select * From PopularLocation";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultPopularLocationDto>(query);
                return values.ToList();
            }
        }

        public async Task<GetByIdPopularLocationDto> GetByIDPopularLocation(int id)
        {
            string query = "select * From PopularLocation Where LocationID=@locationID";
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@locationID", id);
            using (var connection = _context.CreateConnection())
            {
                var value = await connection.QueryFirstOrDefaultAsync<GetByIdPopularLocationDto>(query, dynamicParameters);
                return value;
            }
        }

        public async void  UpdatePopularLocation(UpdatePopularLocationDto updatePopularLocationDto)
        {
            string query = "Update PopularLocation Set CityName=@cityName,ImageUrl=@imageUrl Where LocationID=@locationID";
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@locationID", updatePopularLocationDto.LocationID);
            dynamicParameters.Add("@cityName", updatePopularLocationDto.CityName);
            dynamicParameters.Add("@imageUrl", updatePopularLocationDto.ImageUrl);
            using(var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, dynamicParameters);
            }
        }
    }
}
