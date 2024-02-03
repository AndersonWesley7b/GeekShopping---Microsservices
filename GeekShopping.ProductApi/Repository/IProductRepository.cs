using GeekShopping.ProductApi.Data.ValueObjects;

namespace GeekShopping.ProductApi.Repository
{
    public interface IProductRepository
    {
        Task<IEnumerable<ProductVO>> FindAll();
        Task<ProductVO> FindById(long _Id);
        Task<ProductVO> Create(ProductVO _Vo);
        Task<ProductVO> Update(ProductVO _Vo);
        Task<bool> Delete(long _Id);
    }
}
