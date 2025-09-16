using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace RealEstate_Dapper_UI.Controllers
{
    public class StatisticController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public StatisticController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            #region Aktif Kategori Sayısı
            
            var responseMessage = await client.GetAsync("https://localhost:7214/api/Statistics/ActiveCategoryCount");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            ViewBag.activeCategoryCount = jsonData;
            #endregion

            #region Aktif Personel Sayısı
            var responseMessage2 = await client.GetAsync("https://localhost:7214/api/Statistics/ActiveEmployeeCount");
            var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
            ViewBag.activeEmployeeCount = jsonData2;
            #endregion

            #region Daire Sayısı
            var responseMessage3 = await client.GetAsync("https://localhost:7214/api/Statistics/ApartmentCount");
            var jsonData3 = await responseMessage3.Content.ReadAsStringAsync();
            ViewBag.apartmentCount = jsonData3;
            #endregion

            #region Ortalama Kiralık İlan Fiyatları
            var responseMessage4 = await client.GetAsync("https://localhost:7214/api/Statistics/AverageProductPriceByRent");
            var jsonData4 = await responseMessage4.Content.ReadAsStringAsync();
            ViewBag.averageProductPriceByRent = jsonData4;
            #endregion
         
            #region Ortalama Satılık İlan Fiyatları
            var responseMessage5 = await client.GetAsync("https://localhost:7214/api/Statistics/AverageProductPriceBySale");
            var jsonData5 = await responseMessage5.Content.ReadAsStringAsync();
            ViewBag.averageProductPriceBySale = jsonData5;
            #endregion
       
            #region En Fazla İlana Sahip Kategori Adı
            var responseMessage6 = await client.GetAsync("https://localhost:7214/api/Statistics/CategoryNameByMaxProductCount");
            var jsonData6 = await responseMessage6.Content.ReadAsStringAsync();
            ViewBag.categoryNameByMaxProductCount = jsonData6;
            #endregion
        
            #region En Fazla İlana Sahip Şehir Adı
            var responseMessage7 = await client.GetAsync("https://localhost:7214/api/Statistics/CityNameByMaxProductCount");
            var jsonData7 = await responseMessage7.Content.ReadAsStringAsync();
            ViewBag.cityNameByMaxProductCount = jsonData7;
            #endregion
         
            #region Toplam Kaç Farklı Şehir Sayısı
            var responseMessage8 = await client.GetAsync("https://localhost:7214/api/Statistics/DifferentCityCount");
            var jsonData8 = await responseMessage8.Content.ReadAsStringAsync();
            ViewBag.differentCityCount = jsonData8;
            #endregion
      
            #region En Fazla İlana Sahip Personel İsmi
            var responseMessage9 = await client.GetAsync("https://localhost:7214/api/Statistics/EmployeeNameByMaxProductCount");
            var jsonData9 = await responseMessage9.Content.ReadAsStringAsync();
            ViewBag.employeeNameByMaxProductCount = jsonData9;
            #endregion
         
            #region Son İlan Fiyatı
            var responseMessage10 = await client.GetAsync("https://localhost:7214/api/Statistics/LastProductPrice");
            var jsonData10 = await responseMessage10.Content.ReadAsStringAsync();
            ViewBag.lastProductPrice = jsonData10;
            #endregion
        
            #region En Yeni İnşa Yılı
            var responseMessage11 = await client.GetAsync("https://localhost:7214/api/Statistics/NewestBuildingYear");
            var jsonData11 = await responseMessage11.Content.ReadAsStringAsync();
            ViewBag.newestBuildingYear = jsonData11;
            #endregion
         
            #region En Eski İnşa Yılı
            var responseMessage12 = await client.GetAsync("https://localhost:7214/api/Statistics/OldestBuildingYear");
            var jsonData12 = await responseMessage12.Content.ReadAsStringAsync();
            ViewBag.oldestBuildingYear = jsonData12;
            #endregion
            
            #region Pasif Kategori
            var responseMessage13 = await client.GetAsync("https://localhost:7214/api/Statistics/PassiveCategoryCount");
            var jsonData13 = await responseMessage13.Content.ReadAsStringAsync();
            ViewBag.passiveCategoryCount = jsonData13;
            #endregion
            
            #region Toplam İlan Sayısı
            var responseMessage14 = await client.GetAsync("https://localhost:7214/api/Statistics/ProductCount");
            var jsonData14 = await responseMessage14.Content.ReadAsStringAsync();
            ViewBag.productCount = jsonData14;
            #endregion
     
            #region Ortalama Oda Sayısı
            var responseMessage15 = await client.GetAsync("https://localhost:7214/api/Statistics/AvarageRoomCount");
            var jsonData15 = await responseMessage15.Content.ReadAsStringAsync();
            ViewBag.avarageRoomCount = jsonData15;
            #endregion 

            #region Toplam Kategori Sayısı
            var responseMessage16 = await client.GetAsync("https://localhost:7214/api/Statistics/CategoryCount");
            var jsonData16 = await responseMessage16.Content.ReadAsStringAsync();
            ViewBag.categoryCount = jsonData16;
            #endregion

            


            return View();
        }
    }
}
