using GeekShopping.CartAPI.Data.ValueObjects;
using GeekShopping.CartAPI.Repository;
using Microsoft.AspNetCore.Mvc;

namespace GeekShopping.CartAPI.Controllers;
[ApiController]
[Route("api/v1/[controller]")]
public class CartController : ControllerBase
{
    private readonly ICartRepository _cartRepository;

    public CartController(ICartRepository cartRepository)
    {
        _cartRepository = cartRepository;
    }

    [HttpGet("find-cart/{id}")]
    public async Task<ActionResult<CartVO>> FindById(string userid)
    {
        var cart = await _cartRepository.FindCartByUserId(userid);
        if(cart == null)
            return NotFound();
        return Ok(cart);
    } 
    
    [HttpPost("add-cart/{id}")]
    public async Task<ActionResult<CartVO>> AddCart(CartVO vo)
    {
        var cart = await _cartRepository.SaveOrUpdateCart(vo);
        if(cart == null)
            return NotFound();
        return Ok(cart);
    }

    [HttpPut("update-cart/{id}")]
    public async Task<ActionResult<CartVO>> UpdateCart(CartVO vo)
    {
        var cart = await _cartRepository.SaveOrUpdateCart(vo);
        if(cart == null)
            return NotFound();
        return Ok(cart);
    }

    [HttpDelete("remove-cart/{id}")]
    public async Task<ActionResult<bool>> RemoveCart(int Id)
    {
        var status = await _cartRepository.RemoveFromCart(Id);
        if(!status)
            return BadRequest();
        return Ok(status);
    }

}
