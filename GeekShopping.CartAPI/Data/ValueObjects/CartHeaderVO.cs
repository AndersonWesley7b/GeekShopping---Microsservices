using GeekShopping.CartAPI.Model.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace GeekShopping.CartAPI.Data.ValueObjects;

public class CartHeaderVO
{
    public string UserId { get; set; }
    public string CouponCode { get; set;}
}
