using GeekShopping.ProductApi.Data.ValueObjects;
using GeekShopping.ProductApi.Model;
using GeekShopping.ProductApi.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GeekShopping.ProductApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductRepository _Repository;

        public ProductController(IProductRepository Repository)
        {
                _Repository = Repository ?? throw new
                ArgumentNullException(nameof(Repository));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductVO>>> FindAll()
        {
            IEnumerable<ProductVO> Products = await _Repository.FindAll();
            return Ok(Products);
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<ProductVO>> FindById(long Id)
        {
            var Product = await _Repository.FindById(Id);
            if (Equals(Product, null))
                return NotFound();

            return Ok(Product);
        }

        [HttpPost]
        public async Task<ActionResult<ProductVO>> Create(ProductVO VO)
        {
            if (Equals(VO, null))
                return BadRequest();

            ProductVO ProductVO = await _Repository.Create(VO);
            return Ok(ProductVO);
        } 
        
        [HttpPut]
        public async Task<ActionResult<ProductVO>> Update(ProductVO VO)
        {
            if (Equals(VO, null))
                return BadRequest();

            ProductVO ProductEntity = await _Repository.Update(VO);
            return Ok(ProductEntity);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(long id)
        {
            var status = await _Repository.Delete(id);
            if (!status) return BadRequest();
            return Ok(status);
        }


    }
}
