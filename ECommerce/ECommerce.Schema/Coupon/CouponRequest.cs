using ECommerce.Base.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Schema.Coupon;

public class CouponRequest:BaseRequest
{
    public int? OrderId { get; set; }
    public int? CartId { get; set; }
    public string Code { get; set; }
    public bool DiscountAmount100 { get; set; }
    public bool DiscountAmount50 { get; set; }
    public bool DiscountAmount20 { get; set; }
    public bool DiscountAmount10 { get; set; }
    public DateTime ExpirationDate { get; set; }
    public bool IsActive { get; set; }
    public bool IsUsed { get; set; }
    public DateTime CreatedDate { get; set; }
}
