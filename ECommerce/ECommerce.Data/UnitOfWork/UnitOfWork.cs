﻿using ECommerce.Base.Model;
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
    public ICartItemRepository CartItemRepository()
    { 
        return new CartItemRepository(dbContext); 
    }

    public ICartRepository CartRepository()
    {
        return new CartRepository(dbContext);
    }
   
    public ICategoryRepository CategoryRepository()
    {
        return new CategoryRepository(dbContext);
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
            catch (Exception )
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
