using GeekShopping.Web.Models;

namespace GeekShopping.Web.Services.IServices
{
    public interface IProductService
    {
        Task<IEnumerable<ProductModel>> FindAllProducts();

        Task<ProductModel> FindProductById(long _Id);

        Task<ProductModel> CreateProduct(ProductModel _Model);

        Task<ProductModel> UpdateProduct(ProductModel _Model);

        Task<bool> DeleteProductById(long _Id);
    }
}
