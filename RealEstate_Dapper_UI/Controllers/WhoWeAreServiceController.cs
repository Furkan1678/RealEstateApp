using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate_Dapper_UI.Dtos.WhoWeAreDetailDtos;
using System.Text;

namespace RealEstate_Dapper_UI.Controllers
{
    public class WhoWeAreServiceController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public WhoWeAreServiceController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7214/api/WhoWeAreServices");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultWhoWeAreServiceDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpGet]
        public IActionResult CreateWhoWeAreService()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateWhoWeAreService(CreateWhoWeAreServiceDto createWhoWeAreServiceDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createWhoWeAreServiceDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7214/api/WhoWeAreServices", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<IActionResult> DeleteWhoWeAreService(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7214/api/WhoWeAreServices/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> UpdateWhoWeAreService(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7214/api/WhoWeAreServices/GetIDWhoWeAreService{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<GetByIdWhoWeAreServiceDto>(jsonData);
                return View(value);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateWhoWeAreService(UpdateWhoWeAreServiceDto updateWhoWeAreServiceDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateWhoWeAreServiceDto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7214/api/WhoWeAreServices", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
