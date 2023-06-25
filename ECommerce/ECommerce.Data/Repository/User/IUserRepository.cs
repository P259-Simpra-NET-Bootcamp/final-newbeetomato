using ECommerce.Data.Repository.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Data.Repository.User
{
    public interface IUserRepository : IGenericRepository<Domain.User>
    {
        Domain.User AddMoney(int userId, int value);
    }
}
