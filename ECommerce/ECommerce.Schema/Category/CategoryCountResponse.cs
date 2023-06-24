using ECommerce.Base.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Schema.Category
{
    public class CategoryCountResponse:BaseResponse
    {
        public int Count { get; set; }
    }
}
