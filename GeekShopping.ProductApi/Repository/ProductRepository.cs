using AutoMapper;
using GeekShopping.ProductApi.Data.ValueObjects;
using GeekShopping.ProductApi.Model;
using GeekShopping.ProductApi.Model.Context;
using Microsoft.EntityFrameworkCore;

namespace GeekShopping.ProductApi.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly MySqlContext _Context;
        private IMapper _Mapper;

        public ProductRepository(MySqlContext Context, IMapper Mapper)
        {
            _Context = Context;
            _Mapper = Mapper;
        }
          
        public async Task<IEnumerable<ProductVO>> FindAll()
        {
            List<Product> Products = await _Context.Products.ToListAsync();
            return _Mapper.Map<List<ProductVO>>(Products);
        }

        public async Task<ProductVO> FindById(long Id)
        {
            Product Product = await _Context.Products
                                .Where(x => x.Id == Id)
                                .FirstOrDefaultAsync();
            return _Mapper.Map<ProductVO>(Product);
        }

        public async Task<ProductVO> Create(ProductVO Vo)
        {
            Product Product = _Mapper.Map<Product>(Vo);
            _Context.Products.Add(Product);
            await _Context.SaveChangesAsync();
            return _Mapper.Map<ProductVO>(Product);
        }

        public async Task<ProductVO> Update(ProductVO Vo)
        {
            Product Product = _Mapper.Map<Product>(Vo);
            _Context.Products.Update(Product);
            await _Context.SaveChangesAsync();
            return _Mapper.Map<ProductVO>(Product);
        }

        public async Task<bool> Delete(long Id)
        {
            Product Product = await _Context.Products.Where(p => p.Id == Id)
                    .FirstOrDefaultAsync();
            if (Product == null) 
                return false;
            _Context.Products.Remove(Product);
            await _Context.SaveChangesAsync();
            return true;
        }
    }
}
