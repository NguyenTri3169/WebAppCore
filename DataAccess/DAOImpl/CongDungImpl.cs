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
        //public async Task<List<CongDung>> GetCongDungs()
        //{
        //    List<CongDung> list = null;
        //    try
        //    {
        //        list = await _storeDbContext.CongDungs
        //            .Select(cd => new CongDung
        //            {
        //                Id = cd.Id,
        //                TenCd = cd.TenCd,
        //                DoiTuong = cd.DoiTuong
        //            })
        //            .ToListAsync();

        //        // Kiểm tra và xử lý giá trị NULL nếu cần
        //        list.ForEach(cd =>
        //        {
        //            cd.TenCd = cd.TenCd ?? string.Empty;
        //            cd.DoiTuong = cd.DoiTuong ?? string.Empty;
        //        });
        //    }
        //    catch (Exception ex)
        //    {
        //        throw;
        //    }
        //    return list ?? new List<CongDung>();
        //}

        public Task<List<CongDung>> GetCongDungs()
        {
            //List<CongDung> list = null;
            Task<List<CongDung>> list = null;
            try
            {
                list = _storeDbContext.CongDungs.ToListAsync();
                // Kiểm tra và xử lý giá trị NULL nếu cần
                //list.ForEach(cd =>
                //{
                //    cd.TenCd = cd.TenCd ?? string.Empty;
                //    cd.MaCd = cd.MaCd ?? string.Empty;
                //    cd.GhiChu = cd.GhiChu ?? string.Empty;
                //    cd.DoiTuong = cd.DoiTuong ?? string.Empty;
                //    cd.Version = cd.Version ?? 0; // Hoặc giá trị mặc định khác
                //});
            }
            catch (Exception ex)
            {
                throw;
            }
            return list;/*?? new List<CongDung>();*/
        }
    }
}
