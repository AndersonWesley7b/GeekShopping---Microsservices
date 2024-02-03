using GeekShopping.Web.Models;
using GeekShopping.Web.Services.IServices;
using GeekShopping.Web.Utils;
using Microsoft.AspNetCore.Mvc;

namespace GeekShopping.Web.Services
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _Client;
        public const string BasePath = "api/v1/Product";
        public ProductService(HttpClient Client)
        {
            _Client = Client;
        }
        public async Task<IEnumerable<ProductModel>> FindAllProducts()
        {
            var Response = await _Client.GetAsync(BasePath);
            return await Response.ReadContentAs<List<ProductModel>>();
        }

        public async Task<ProductModel> FindProductById(long _Id)
        {
            var Response = await _Client.GetAsync($"{BasePath}/{_Id}");
            return await Response.ReadContentAs<ProductModel>();
        }

        public async Task<ProductModel> CreateProduct([FromBody]ProductModel _Model)
        {
            var Response = await _Client.PostAsJsonAsync(BasePath ,_Model);
            if (Response.IsSuccessStatusCode)
                return await Response.ReadContentAs<ProductModel>();
            else throw new Exception("Something went wrong when calling API");
        }

        public async Task<ProductModel> UpdateProduct(ProductModel _Model)
        {
            var Response = await _Client.PutAsJsonAsync(BasePath, _Model);
            if (Response.IsSuccessStatusCode)
                return await Response.ReadContentAs<ProductModel>();
            else throw new Exception("Something went wrong when calling API");
        }

        public async Task<bool> DeleteProductById(long _Id)
        {
            var Response = await _Client.DeleteAsync($"{BasePath}/{_Id}");
            if (Response.IsSuccessStatusCode)
                return await Response.ReadContentAs<bool>();
            else throw new Exception("Something went wrong when calling API");
        }

    }
}
