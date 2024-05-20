using DataAccess.DAO;
using DataAccess.DbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        StoreDbContext _storeDbContext;
        public UnitOfWork(StoreDbContext storeDbContext)
        {
            _storeDbContext = storeDbContext;
        }
        public IUser _user { get; set; }

        public int SaveChanges()
        {
            return _storeDbContext.SaveChanges();
        }
    }
}
