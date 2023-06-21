using ECommerce.Data.Repository.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Data.Repository.Category;

public interface ICategoryRepository: IGenericRepository<Domain.Category>
{
    IEnumerable<Domain.Category> FindByName(string name);

    int GetAllCount();
}
