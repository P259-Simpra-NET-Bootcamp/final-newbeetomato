using ECommerce.Base.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Schema.Cart
{
    public class AddCouponRequest:BaseRequest
    {
        public string Code { get; set; }
    }
}
