using ECommerce.Base.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Schema.Category;

public class CategoryRequest:BaseRequest
{
    public string Name { get; set; }
    public int DisplayOrder { get; set; }
}
