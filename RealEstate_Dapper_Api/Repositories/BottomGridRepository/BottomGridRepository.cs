using Dapper;
using RealEstate_Dapper_Api.Dtos.BottomGridDtos;
using RealEstate_Dapper_Api.Models.DapperContext;
using System.Threading.Tasks;

namespace RealEstate_Dapper_Api.Repositories.BottomGridRepository
{
    public class BottomGridRepository: IBottomGridRepository
    {
        private readonly Context _context;

        public BottomGridRepository(Context context)
        {
            _context = context;
        }

        public async void  CreateBottomGrid(CreateBottomGridDto createBottomGridDto)
        {
            string query = "insert into BottomGrid (Icon,Title,Description) Values (@icon,@title,@description)";
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@icon", createBottomGridDto.Icon);
            dynamicParameters.Add("@title", createBottomGridDto.Title);
            dynamicParameters.Add("@description", createBottomGridDto.Description);
            using(var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, dynamicParameters);
            }
        }

        public async void DeleteBottomGrid(int id)
        {
            string query = "Delete from BottomGrid Where BottomGridID=@bottomGridID";
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@bottomGridID", id);
            using( var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, dynamicParameters);
            }
        }

        public async  Task<List<ResultBottomGridDto>> GetAllBottomGridAsync()
        {
            string query = "Select * From BottomGrid";
            using( var connection = _context.CreateConnection())
            {
               var values = await connection.QueryAsync<ResultBottomGridDto>(query);
                return values.ToList();
            }
        }

        public async Task<GetByIdBottomGridDto> GetByIdBottomGridAsync(int id)
        {
            string query = "Select * From BottomGrid Where BottomGridID=@bottomGridID";
            DynamicParameters dynamicParameters = new();
            dynamicParameters.Add("@bottomGridID", id);
            using(var connection = _context.CreateConnection())
            {
                var value = await connection.QueryFirstOrDefaultAsync<GetByIdBottomGridDto>(query,dynamicParameters);
                return value;
            }
        }

        public async void UpdateBottomGrid(UpdateBottomGridDto updateBottomGridDto)
        {
            string query = "Update BottomGrid Set Icon=@icon,Title=@title,Description=@description Where BottomGridID=@bottomGridID";
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@bottomGridID", updateBottomGridDto.BottomGridID);
            dynamicParameters.Add("@icon", updateBottomGridDto.Icon);
            dynamicParameters.Add("@title", updateBottomGridDto.Title);
            dynamicParameters.Add("@description", updateBottomGridDto.Description);
            using(var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, dynamicParameters);
            }
        }
    }
}
