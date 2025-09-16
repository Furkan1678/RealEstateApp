using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Repositories.StatisticRepository;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticsController : ControllerBase
    {
        private readonly IStatisticRepository _statisticRepository;

        public StatisticsController(IStatisticRepository statisticRepository)
        {
            _statisticRepository = statisticRepository;
        }

        [HttpGet("ActiveCategoryCount")]
        public IActionResult ActiveCategoryCount() 
        {
           var values = _statisticRepository.ActiveCategoryCount();
            return Ok(values);  
        }
        [HttpGet("ActiveEmployeeCount")]
        public IActionResult ActiveEmployeeCount() 
        {
           var values = _statisticRepository.ActiveEmployeeCount();
            return Ok(values);  
        }
        [HttpGet("ApartmentCount")]
        public IActionResult ApartmentCount() 
        {
           var values = _statisticRepository.ApartmentCount();
            return Ok(values);  
        }
        [HttpGet("AvarageRoomCount")]
        public IActionResult AvarageRoomCount() 
        {
           var values = _statisticRepository.AvarageRoomCount();
            return Ok(values);  
        }
        [HttpGet("AverageProductPriceByRent")]
        public IActionResult AverageProductPriceByRent() 
        {
           var values = _statisticRepository.AverageProductPriceByRent();
            return Ok(values);  
        }
        [HttpGet("AverageProductPriceBySale")]
        public IActionResult AverageProductPriceBySale() 
        {
           var values = _statisticRepository.AverageProductPriceBySale();
            return Ok(values);  
        }
        [HttpGet("CategoryCount")]
        public IActionResult CategoryCount() 
        {
           var values = _statisticRepository.CategoryCount();
            return Ok(values);  
        }
        [HttpGet("CategoryNameByMaxProductCount")]
        public IActionResult CategoryNameByMaxProductCount() 
        {
           var values = _statisticRepository.CategoryNameByMaxProductCount();
            return Ok(values);  
        }
        [HttpGet("CityNameByMaxProductCount")]
        public IActionResult CityNameByMaxProductCount() 
        {
           var values = _statisticRepository.CityNameByMaxProductCount();
            return Ok(values);  
        }
        [HttpGet("DifferentCityCount")]
        public IActionResult DifferentCityCount() 
        {
           var values = _statisticRepository.DifferentCityCount();
            return Ok(values);  
        }
        [HttpGet("EmployeeNameByMaxProductCount")]
        public IActionResult EmployeeNameByMaxProductCount() 
        {
           var values = _statisticRepository.EmployeeNameByMaxProductCount();
            return Ok(values);  
        }
        [HttpGet("LastProductPrice")]
        public IActionResult LastProductPrice() 
        {
           var values = _statisticRepository.LastProductPrice();
            return Ok(values);  
        }
        [HttpGet("NewestBuildingYear")]
        public IActionResult NewestBuildingYear() 
        {
           var values = _statisticRepository.NewestBuildingYear();
            return Ok(values);  
        }
        [HttpGet("OldestBuildingYear")]
        public IActionResult OldestBuildingYear() 
        {
           var values = _statisticRepository.OldestBuildingYear();
            return Ok(values);  
        }
        [HttpGet("PassiveCategoryCount")]
        public IActionResult PassiveCategoryCount() 
        {
           var values = _statisticRepository.PassiveCategoryCount();
            return Ok(values);  
        }
        [HttpGet("ProductCount")]
        public IActionResult ProductCount() 
        {
           var values = _statisticRepository.ProductCount();
            return Ok(values);  
        }
    }
}
