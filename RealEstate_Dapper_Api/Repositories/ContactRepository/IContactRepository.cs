using RealEstate_Dapper_Api.Dtos.ContactDtos;

namespace RealEstate_Dapper_Api.Repositories.ContactRepository
{
    public interface IContactRepository
    {
        Task<List<ResultContactDto>> GetAllContactAsync();
        void CreateContact(CreateContactDto createContactDto);
        void DeleteContact(int id);
        Task<List<ResultLast4ContactDto>> GetAllLast4ContactAsync();
        Task<GetByIdContactDto> GetByIdContactAsync(int id);
    }
}
