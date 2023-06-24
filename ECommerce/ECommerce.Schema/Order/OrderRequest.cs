using ECommerce.Data.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Schema.Order
{
    public class OrderRequest
    {
        public int UserId { get; set; }
        public int CardNo { get; set; }
        public virtual List<Data.Domain.OrderItem> OrderItems { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal UsedPoints { get; set; }
        public decimal CouponPoints { get; set; }
        public decimal TotalDiscount { get; set; }
        public decimal GainedPoints { get; set; }
        public decimal NetAmount { get; set; }
        public bool IsCanceled { get; set; }
        public bool IsMoneyDeliveredBack { get; set; }
        public bool IsDelivered { get; set; }
        public virtual List<Data.Domain.Coupon> Coupons { get; set; }
    }
}
