
using RealEstate_Dapper_Api.Dtos.WhoWeAreServiceDtos;

namespace RealEstate_Dapper_Api.Repositories.WhoWeAreRepository
{
    public interface IWhoWeAreServiceRepository
    {
        Task<List<ResultWhoWeAreServiceDto>> GetAllWhoWeAreServiceAsync();
        void UpdateWhoWeAreService(UpdateWhoWeAreServiceDto updateWhoWeAreServiceDto);
        void DeleteWhoWeAreService(int id);
        void CreateWhoWeAreService(CreateWhoWeAreServiceDto CreateWhoWeAreServiceDto);
        Task<GetByIdWhoWeAreServiceDto> GetWhoWeAreService(int id);
    }
}
