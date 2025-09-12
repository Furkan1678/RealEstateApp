using Dapper;
using RealEstate_Dapper_Api.Dtos.WhoWeAreServiceDtos;
using RealEstate_Dapper_Api.Models.DapperContext;
using System.Threading.Tasks;

namespace RealEstate_Dapper_Api.Repositories.WhoWeAreRepository
{
    public class WhoWeAreServiceRepository : IWhoWeAreServiceRepository
    {
        private readonly Context _context;

        public WhoWeAreServiceRepository(Context context)
        {
            _context = context;
        }

        public async void CreateWhoWeAreService (CreateWhoWeAreServiceDto createWhoWeAreServiceDto)
        {
            string query = "insert into WhoWeAreService (ServiceName,ServiceStatus) Values (@serviceName,@serviceStatus)";
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@serviceName", createWhoWeAreServiceDto.ServiceName);
            dynamicParameters.Add("@serviceStatus", createWhoWeAreServiceDto.ServiceStatus);
            using(var connect = _context.CreateConnection())
            {
                 await connect.ExecuteAsync(query, dynamicParameters);
            }
        }

        public async void DeleteWhoWeAreService(int id)
        {
            var query = "delete from WhoWeAreService where WhoWeAreServiceID =@whoWeAreServiceID";
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@whoWeAreServiceID", id);
            using( var connect = _context.CreateConnection())
            {
              await  connect.ExecuteAsync(query, dynamicParameters);
            }
        }

        public async Task<List<ResultWhoWeAreServiceDto>> GetAllWhoWeAreServiceAsync()
        {
            string query = "select * from WhoWeAreService";
            using( var connect = _context.CreateConnection())
            {
                var values = await connect.QueryAsync<ResultWhoWeAreServiceDto>(query);
                return values.ToList();
            }
        }

        public async Task<GetByIdWhoWeAreServiceDto> GetWhoWeAreService(int id)
        {
            string query = "select * from WhoWeAreService where WhoWeAreServiceID =@whoWeAreServiceID";
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@whoWeAreServiceID", id);
            using(var connect = _context.CreateConnection())
            {
                var value = await connect.QueryFirstOrDefaultAsync<GetByIdWhoWeAreServiceDto>(query, dynamicParameters);
                return value;
            }
        }

        public async void  UpdateWhoWeAreService(UpdateWhoWeAreServiceDto updateWhoWeAreServiceDto)
        {
            var query = "Update WhoWeAreService set ServiceName=@serviceName,ServiceStatus=@serviceStatus where WhoWeAreServiceID =@whoWeAreServiceID";
            DynamicParameters dynamicParameters = new();
            dynamicParameters.Add("@whoWeAreServiceID", updateWhoWeAreServiceDto.WhoWeAreServiceID);
            dynamicParameters.Add("@serviceName", updateWhoWeAreServiceDto.ServiceName);
            dynamicParameters.Add("@serviceStatus", updateWhoWeAreServiceDto.ServiceStatus);
            using( var connect = _context.CreateConnection())
            {
                await connect.ExecuteAsync(query,dynamicParameters);
            }
        }
    }
}
