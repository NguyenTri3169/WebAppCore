using DataAccess.DAO;
using DataAccess.DbContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork , IDisposable
    {
        StoreDbContext _storeDbContext;
        public IUser _user { get; set; }
        public UnitOfWork(StoreDbContext storeDbContext, IUser user)
        {
            _storeDbContext = storeDbContext;
            _user = user;
        }


        public int SaveChanges()
        {
            return _storeDbContext.SaveChanges();
        }
        public void Dispose()
        {
            _storeDbContext.Dispose();
        }
    }
}
