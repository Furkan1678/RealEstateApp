using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate_Dapper_UI.Dtos.WhoWeAreDetailDtos;
using RealEstate_Dapper_UI.ViewModels;

namespace RealEstate_Dapper_UI.ViewComponents.HomePage
{
    public class _DefaulWhoWeAreComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DefaulWhoWeAreComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();

          
            var responseDetail = await client.GetAsync("https://localhost:7214/api/WhoWeAreDetails");
            var details = new List<ResultWhoWeAreDetailDto>();

            if (responseDetail.IsSuccessStatusCode)
            {
                var jsonData = await responseDetail.Content.ReadAsStringAsync();
                details = JsonConvert.DeserializeObject<List<ResultWhoWeAreDetailDto>>(jsonData);
            }

           
            var responseService = await client.GetAsync("https://localhost:7214/api/WhoWeAreServices");
            var services = new List<ResultWhoWeAreServiceDto>();

            if (responseService.IsSuccessStatusCode)
            {
                var jsonData = await responseService.Content.ReadAsStringAsync();
                services = JsonConvert.DeserializeObject<List<ResultWhoWeAreServiceDto>>(jsonData);
            }

            var viewModel = new WhoWeAreViewModel
            {
                WhoWeAreDetails = details,
                WhoWeAreServices = services
            };

            return View(viewModel);
        }
    }
}
