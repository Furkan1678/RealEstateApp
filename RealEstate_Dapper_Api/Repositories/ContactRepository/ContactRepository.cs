using Dapper;
using RealEstate_Dapper_Api.Dtos.ContactDtos;
using RealEstate_Dapper_Api.Models.DapperContext;
using System.Threading.Tasks;

namespace RealEstate_Dapper_Api.Repositories.ContactRepository
{
    public class ContactRepository : IContactRepository
    {
        private readonly Context _context;

        public ContactRepository(Context context)
        {
            _context = context;
        }

        public async void CreateContact(CreateContactDto createContactDto)
        {
            string query = "Insert into Contact (Name,Subject,Email,Message,SendDate) Values (@name,@subject,@email,@message,@sendDate)";
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@name", createContactDto.Name);
            dynamicParameters.Add("@subject", createContactDto.Subject);
            dynamicParameters.Add("@email", createContactDto.Email);
            dynamicParameters.Add("@message", createContactDto.Message);
            dynamicParameters.Add("@sendDate", createContactDto.SendDate);
            using(var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, dynamicParameters);
            }
        }

        public async void DeleteContact(int id)
        {
            string query = "Delete From Contact Where ContactID=@contactID";
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("contactID", id);
            using(var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, dynamicParameters);
            }
        }

        public async Task<List<ResultContactDto>> GetAllContactAsync()
        {
            string query = "Select * From Contact";
            using(var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultContactDto>(query);
                return values.ToList();
            }
        }

        public async Task<List<ResultLast4ContactDto>> GetAllLast4ContactAsync()
        {
            string query = "select top(4) * from Contact order by ContactID desc";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultLast4ContactDto>(query);
                return values.ToList();
            }
        }

        public async Task<GetByIdContactDto> GetByIdContactAsync(int id)
        {
            string query = "Select * From Contact Where ContactID=@contactID";
            DynamicParameters dynParameters = new DynamicParameters();
            dynParameters.Add("@contactID", id);
            using(var connection = _context.CreateConnection())
            {
                var value = await connection.QueryFirstOrDefaultAsync<GetByIdContactDto>(query,dynParameters);
                return value;
            }
        }
    }
}
