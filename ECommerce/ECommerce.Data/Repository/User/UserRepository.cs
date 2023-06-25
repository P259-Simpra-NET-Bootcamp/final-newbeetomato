using ECommerce.Data.DbContext;
using ECommerce.Data.Domain;
using ECommerce.Data.Repository.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Data.Repository.User;

public class UserRepository :  IUserRepository
{
    protected readonly EComDbContext dbContext;
    private bool disposed;

    public UserRepository(EComDbContext context) 
    {
        this.dbContext = dbContext;

    }
    public ApplicationUser AddMoney(int userId,int value) 
    {
        var entity=dbContext.Set<ApplicationUser>().FirstOrDefault(x=>x.Id==userId);
        if (entity!=null) 
        {
            entity.WalletBalance = entity.WalletBalance + value;
        }
        return entity;

    }
    public void Delete(ApplicationUser entity)
    {
        dbContext.Set<ApplicationUser>().Remove(entity);
    }

    public void DeleteById(int id)
    {
        var entity = dbContext.Set<ApplicationUser>().Find(id);
        dbContext.Set<ApplicationUser>().Remove(entity);
    }

    public List<ApplicationUser> GetAll()
    {
        return dbContext.Set<ApplicationUser>().ToList();
    }
    public List<ApplicationUser> GetAllAsNoTracking()
    {
        return dbContext.Set<ApplicationUser>().AsNoTracking().ToList();
    }
    public List<ApplicationUser> GetAllWithInclude(params string[] includes)
    {
        var query = dbContext.Set<ApplicationUser>().AsQueryable();
        query = includes.Aggregate(query, (current, inc) => current.Include(inc));
        return query.ToList();
    }
    public ApplicationUser GetByIdWithInclude(int id, params string[] includes)
    {
        //string idString=id.ToString();
        var query = dbContext.Set<ApplicationUser>().AsQueryable();
        query = includes.Aggregate(query, (current, inc) => current.Include(inc));
        return query.FirstOrDefault(x => x.Id == id);
    }
    public IEnumerable<ApplicationUser> WhereWithInclude(Expression<Func<ApplicationUser, bool>> expression, params string[] includes)
    {
        var query = dbContext.Set<ApplicationUser>().AsQueryable();
        query.Where(expression);
        query = includes.Aggregate(query, (current, inc) => current.Include(inc));
        return query.ToList();
    }

    public IQueryable<ApplicationUser> GetAsQueryable()
    {
        return dbContext.Set<ApplicationUser>().AsQueryable();
    }
    public ApplicationUser GetById(int id)
    {
        return dbContext.Set<ApplicationUser>().Find(id);
    }
    public ApplicationUser GetByIdAsNoTracking(int id)
    {
        //string idString = id.ToString();
        return dbContext.Set<ApplicationUser>().AsNoTracking().FirstOrDefault(x => x.Id == id);
    }

    public void Insert(ApplicationUser entity)
    {
        entity.CreatedAt = DateTime.UtcNow;

        dbContext.Set<ApplicationUser>().Add(entity);
    }

    public void Update(ApplicationUser entity)
    {
        dbContext.Set<ApplicationUser>().Update(entity);
    }

    public IEnumerable<ApplicationUser> Where(Expression<Func<ApplicationUser, bool>> expression)
    {
        return dbContext.Set<ApplicationUser>().Where(expression).AsQueryable();
    }
    public IEnumerable<ApplicationUser> WhereAsNoTracking(Expression<Func<ApplicationUser, bool>> expression)
    {
        return dbContext.Set<ApplicationUser>().AsNoTracking().Where(expression).AsQueryable();
    }

    public void Complete()
    {
        dbContext.SaveChanges();
    }

    public void CompleteWithTransaction()
    {
        using (var dbDcontextTransaction = dbContext.Database.BeginTransaction())
        {
            try
            {
                dbContext.SaveChanges();
                dbDcontextTransaction.Commit();
            }
            catch (Exception ex)
            {
                dbDcontextTransaction.Rollback();
            }
        }
    }


    private void Clean(bool disposing)
    {
        if (!disposed)
        {
            if (disposing)
            {
                dbContext.Dispose();
            }
        }

        disposed = true;
        GC.SuppressFinalize(this);
    }
    public void Dispose()
    {
        Clean(true);
    }

    public ApplicationUser GetByUsername(string name)
    {
        return dbContext.Set<ApplicationUser>().Where(x => x.UserName == name).FirstOrDefault();
    }
}
