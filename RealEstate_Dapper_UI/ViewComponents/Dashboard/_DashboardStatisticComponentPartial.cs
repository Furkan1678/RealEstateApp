using Microsoft.AspNetCore.Mvc;

namespace RealEstate_Dapper_UI.ViewComponents.Dashboard
{
    public class _DashboardStatisticComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DashboardStatisticComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();

            #region Toplam İlan Sayısı
            var responseMessage14 = await client.GetAsync("https://localhost:7214/api/Statistics/ProductCount");
            var jsonData14 = await responseMessage14.Content.ReadAsStringAsync();
            ViewBag.productCount = jsonData14;

            #endregion

            #region En Fazla İlana Sahip Personel İsmi
            var responseMessage9 = await client.GetAsync("https://localhost:7214/api/Statistics/EmployeeNameByMaxProductCount");
            var jsonData9 = await responseMessage9.Content.ReadAsStringAsync();
            ViewBag.employeeNameByMaxProductCount = jsonData9;
            #endregion

            #region Toplam Kaç Farklı Şehir Sayısı
            var responseMessage8 = await client.GetAsync("https://localhost:7214/api/Statistics/DifferentCityCount");
            var jsonData8 = await responseMessage8.Content.ReadAsStringAsync();
            ViewBag.differentCityCount = jsonData8;
            #endregion

            #region Aktif Personel Sayısı
            var responseMessage2 = await client.GetAsync("https://localhost:7214/api/Statistics/ActiveEmployeeCount");
            var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
            ViewBag.activeEmployeeCount = jsonData2;
            #endregion

            return View();
        }
    }
}
