using ECommerce.Data.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Data.Repository.User;

public interface IUserRepository
{
    Domain.ApplicationUser AddMoney(int userId, int value);
    ApplicationUser GetById(int id);
    ApplicationUser GetByIdAsNoTracking(int id);
    ApplicationUser GetByIdWithInclude(int id, params string[] includes);
    void Insert(ApplicationUser entity);
    void Update(ApplicationUser entity);
    void DeleteById(int id);
    void Delete(ApplicationUser entity);
    List<ApplicationUser> GetAll();
    IQueryable<ApplicationUser> GetAsQueryable();
    List<ApplicationUser> GetAllAsNoTracking();
    List<ApplicationUser> GetAllWithInclude(params string[] includes);
    IEnumerable<ApplicationUser> Where(Expression<Func<ApplicationUser, bool>> expression);
    IEnumerable<ApplicationUser> WhereAsNoTracking(Expression<Func<ApplicationUser, bool>> expression);
    IEnumerable<ApplicationUser> WhereWithInclude(Expression<Func<ApplicationUser, bool>> expression, params string[] includes);
    ApplicationUser GetByUsername(string name);

    void Complete();
    void CompleteWithTransaction();
}
