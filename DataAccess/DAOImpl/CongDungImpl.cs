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
    public class CongDungImpl : ICongDung
    {
        StoreDbContext _storeDbContext;
        public CongDungImpl(StoreDbContext storeDbContext)
        {
            _storeDbContext = storeDbContext;
        }
        public Task<List<CongDung>> GetCongDungs()
        {
            Task<List<CongDung>> list = null;
            try
            {
                list = _storeDbContext.CongDungs.ToListAsync();
            }
            catch (Exception ex)
            {

                throw;
            }
            return list;
        }
    }
}
