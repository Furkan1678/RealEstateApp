using RealEstate_Dapper_Api.Dtos.PopularLocationDtos;

namespace RealEstate_Dapper_Api.Repositories.PopularLocationRepository
{
    public interface IPopularLocationRepository
    {
        Task<List<ResultPopularLocationDto>> GetAllPopularLocationsAsync();
        void UpdatePopularLocation(UpdatePopularLocationDto updatePopularLocationDto);
        void DeletePopularLocation(int id);
        void CreatePopularLocation(CreatePopularLocationDto createPopularLocationDto);
        Task<GetByIdPopularLocationDto> GetByIDPopularLocation(int id);
    }
}
