using ECommerce.Base.Model;
using ECommerce.Data.DbContext;
using ECommerce.Data.Repository.Base;
using ECommerce.Data.Repository.Cart;
using ECommerce.Data.Repository.CartItem;
using ECommerce.Data.Repository.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Data.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    private readonly EComDbContext dbContext;
    private bool disposed;

    public UnitOfWork(EComDbContext dbContext)
    {
        this.dbContext = dbContext;

    }
    public ICartRepository 
    public ICartItemRepository AddCartItemToCart(int cartId, int productId, int quantity) 
    {
        return new CartItemRepository(dbContext);
    } 
    
    public ICartItemRepository IncreaseCartItemQuantity(int cartItemId, int quantityToAdd)
    {
        return new CartItemRepository(dbContext);
    }
    public ICartItemRepository DecreaseCartItemQuantity(int cartItemId, int quantityToSubtract) 
    {
        return new CartItemRepository(dbContext);
    }
    public ICartItemRepository UpdateCartItemQuantity(int cartItemId, int newQuantity)
    {
        return new CartItemRepository(dbContext);
    }

    public IGenericRepository<Entity> Repository<Entity>() where Entity : BaseModel
    {
        return new GenericRepository<Entity>(dbContext);
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
            if (disposing && dbContext is not null)
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
}
