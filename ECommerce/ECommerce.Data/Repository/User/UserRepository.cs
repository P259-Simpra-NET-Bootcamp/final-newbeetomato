using ECommerce.Data.Context;
using ECommerce.Data.Repository.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Data.Repository.User
{
    public class UserRepository : GenericRepository<Domain.User>, IUserRepository
    {
        public UserRepository(EComDbContext dbContext) : base(dbContext)
        {
        }
        public Domain.User AddMoney(int userId, int value)
        {
            var entity = dbContext.Set<Domain.User>().FirstOrDefault(x => x.Id == userId);
            if (entity != null)
            {
                entity.WalletBalance = entity.WalletBalance + value;
            }
            return entity;

        }
        public void InsertUser() { }
    }
}
