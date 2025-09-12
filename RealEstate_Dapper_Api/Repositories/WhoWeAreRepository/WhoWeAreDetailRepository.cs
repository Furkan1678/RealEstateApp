using Dapper;
using RealEstate_Dapper_Api.Dtos.WhoWeAreDetailDtos;
using RealEstate_Dapper_Api.Models.DapperContext;
using System.Threading.Tasks;

namespace RealEstate_Dapper_Api.Repositories.WhoWeAreRepository
{
    public class WhoWeAreDetailRepository : IWhoWeAreDetailRepository
    {
        private readonly Context _context;

        public WhoWeAreDetailRepository(Context context)
        {
            _context = context;
        }

        public async void  CreateWhoWeAreDetail(CreateWhoWeAreDetailDto createWhoWeAreDetailDto)
        {
            string query = "insert into WhoWeAreDetail (Title,SubTitle,Description1,Description2) Values(@title,@subTitle,@description1,@description2)";
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@title",createWhoWeAreDetailDto.Title);
            dynamicParameters.Add("@subTitle",createWhoWeAreDetailDto.SubTitle);
            dynamicParameters.Add("@description1",createWhoWeAreDetailDto.Description1);
            dynamicParameters.Add("@description2",createWhoWeAreDetailDto.Description2);
            using (var connection = _context.CreateConnection())
            {
              await   connection.ExecuteAsync(query, dynamicParameters);
            }
        }

        public async void DeleteWhoWeAreDetail(int id)
        {
            string query = "Delete From WhoWeAreDetail Where WhoWeAreDetailID =@whoWeAreDetailID";
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@whoWeAreDetailID", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, dynamicParameters);
            }
        }

        public async Task<List<ResultWhoWeAreDetailDto>> GetAllWhoWeAreDetailAsync()
        {
            string query = "select * from WhoWeAreDetail";
            using(var connection = _context.CreateConnection())
            {
               var values =await connection.QueryAsync<ResultWhoWeAreDetailDto>(query);
                return values.ToList();
            }
        }

        public async Task<GetByIdWhoWeAreDetailDto> GetWhoWeAreDetail(int id)
        {
            string query = "select * from WhoWeAreDetail Where WhoWeAreDetailID=@whoWeAreDetailID";
            DynamicParameters dynParameters = new DynamicParameters();
            dynParameters.Add("@whoWeAreDetailID", id);
            using(var connection = _context.CreateConnection())
            {
                var value = await connection.QueryFirstOrDefaultAsync<GetByIdWhoWeAreDetailDto>(query, dynParameters);
                return value;
            }
        }

        public async void UpdateWhoWeAreDetail(UpdateWhoWeAreDetailDto updateWhoWeAreDetailDto)
        {
            var query = "Update WhoWeAreDetail set Title=@title,Description1=@description1,Description2=@description2 where  WhoWeAreDetailID=@whoWeAreDetailID";
            DynamicParameters dynParameters = new DynamicParameters();
            dynParameters.Add("@whoWeAreDetailID", updateWhoWeAreDetailDto.WhoWeAreDetailID);
            dynParameters.Add("@title", updateWhoWeAreDetailDto.Title);
            dynParameters.Add("@description1", updateWhoWeAreDetailDto.Description1);
            dynParameters.Add("@description2", updateWhoWeAreDetailDto.Description2);
            using(var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query,dynParameters);
               
            }
        }
    }
}
