using DataAccess.DAO;
using DataAccess.DbContext;
using DataAccess.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAOImpl
{
    public class CategoryImpl : ICategory
    {
        StoreDbContext _storeDbContext;
        public CategoryImpl(StoreDbContext storeDbContext)
        {
            _storeDbContext = storeDbContext;
        }
        public Task<List<Category>> GetCategories()
        {
            Task<List<Category>> list = null;
            try
            {
                list = _storeDbContext.Categories.ToListAsync();
            }
            catch (Exception ex)
            {

                throw;
            }
            return list;
        }
    }
}
