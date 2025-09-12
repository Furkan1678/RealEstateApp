namespace RealEstate_Dapper_Api.Dtos.WhoWeAreServiceDtos
{
    public class GetByIdWhoWeAreServiceDto
    {
        public int WhoWeAreServiceID { get; set; }
        public string ServiceName { get; set; }
        public bool ServiceStatus { get; set; }
    }
}
