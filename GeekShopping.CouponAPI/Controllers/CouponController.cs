using GeekShopping.CouponAPI.Data.ValueObjects;
using GeekShopping.CouponAPI.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GeekShopping.CouponAPI.Controllers;
[ApiController]
[Route("api/v1/[controller]")]
public class CouponController : ControllerBase
{
    private readonly ICouponRepository _repository;

    public CouponController(ICouponRepository repository)
    {
        _repository = repository;
    }


    [HttpGet("{couponCode}")]
    public async Task<ActionResult<CouponVO>> FindById(string couponCode)
    {
        var coupon = await _repository.GetCouponByCouponCode(couponCode);
        if (coupon == null)
            return NotFound();
        return Ok(coupon);
    }

}
