using Dapper;
using RealEstate_Dapper_Api.Dtos.ProductDtos;
using RealEstate_Dapper_Api.Models.DapperContext;
using System.Threading.Tasks;

namespace RealEstate_Dapper_Api.Repositories.ProductRepository
{
    public class ProductRepository : IProductRepository
    {
        private readonly Context _context;

        public ProductRepository(Context context)
        {
            _context = context;
        }

        public async Task<List<ResultProductDto>> GetAllProductAsync()
        {
            var query = "select * from Product";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultProductDto>(query);
                return values.ToList();
            }
        }

        public async Task<List<ResultProductWithCategoryDto>> GetAllProductWithCategoryAsync()
        {
            var query = "select ProductID, Title,Price,City,District,CoverImage,Type,Address,CategoryName,DealOfTheDay from Product inner join Category on Product.ProductCategory=Category.CategoryID";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultProductWithCategoryDto>(query);
                return values.ToList();
            }
        }

        public async Task<List<ResultLast5ProductWithCategoryDto>> GetLast5ProductAsync()
        {
            string query = "Select top(5) ProductID,Title,Price,City,District,ProductCategory,CategoryName,AdvertisementDate from Product\r\nInner Join Category on Product.ProductCategory=Category.CategoryID\r\nWhere Type='Kiralık' order by ProductID desc";
            using(var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultLast5ProductWithCategoryDto>(query);
                return values.ToList();
            }
        }

        public async void ProductDealOfTheDayStatusChangeToFalse(int id)
        {
            string query = "Update Product Set DealOfTheDay=0 Where ProductID =@productID";
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@productID", id);
            using (var connection = _context.CreateConnection())
            {
                 await connection.ExecuteAsync(query, dynamicParameters);
            }
        }

        public async void ProductDealOfTheDayStatusChangeToTrue(int id)
        {
            string query = "Update Product Set DealOfTheDay=1 Where ProductID =@productID";
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@productID", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, dynamicParameters);
            }
        }
    }
}
