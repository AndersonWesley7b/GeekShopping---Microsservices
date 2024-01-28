using GeekShopping.ProductApi.Data.ValueObjects;

namespace GeekShopping.ProductApi.Repository
{
    public interface IProductRepository
    {
        Task<IEnumerable<ProductVO>> FindAll();
        Task<ProductVO> FindById(long Id);
        Task<ProductVO> Create(ProductVO Vo);
        Task<ProductVO> Update(ProductVO Vo);
        Task<bool> Delete(long Id);
    }
}
