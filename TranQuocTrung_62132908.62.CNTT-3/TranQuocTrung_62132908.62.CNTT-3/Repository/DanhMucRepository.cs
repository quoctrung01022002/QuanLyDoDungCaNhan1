using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TranQuocTrung_62132908._62.CNTT_3.Models;

namespace TranQuocTrung_62132908._62.CNTT_3.Repositories
{
    public class DanhMucRepository : IDanhMucRepository
    {
        private readonly QLBanVaLiContext _dbContext;

        public DanhMucRepository(QLBanVaLiContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<TDanhMucSp>> GetAllAsync()
        {
            return await _dbContext.TDanhMucSps.ToListAsync();
        }

        public async Task<TDanhMucSp> GetByIdAsync(string maSp)
        {
            return await _dbContext.TDanhMucSps.FindAsync(maSp);
        }

        public async Task AddAsync(TDanhMucSp danhMucSp)
        {
            _dbContext.TDanhMucSps.Add(danhMucSp);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(TDanhMucSp danhMucSp)
        {
            _dbContext.Entry(danhMucSp).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(string maSp)
        {
            var danhMucSp = await _dbContext.TDanhMucSps.FindAsync(maSp);
            if (danhMucSp != null)
            {
                _dbContext.TDanhMucSps.Remove(danhMucSp);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<TDanhMucSp>> SearchAsync(string keyword)
        {
            return await _dbContext.TDanhMucSps
                .Where(d => d.TenSp.Contains(keyword) || d.Model.Contains(keyword))
                .ToListAsync();
        }

        public async Task<IEnumerable<TDanhMucSp>> GetPagedAsync(int page, int pageSize)
        {
            return await _dbContext.TDanhMucSps
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }
        public async Task<IEnumerable<TDanhMucSp>> GetByManufacturerAsync(string manufacturerCode)
        {
            return await _dbContext.TDanhMucSps
                .Where(d => d.MaHangSx == manufacturerCode)
                .ToListAsync();
        }

        public async Task<IEnumerable<TDanhMucSp>> GetByCategoryAsync(string categoryCode)
        {
            return await _dbContext.TDanhMucSps
                .Where(d => d.MaLoai == categoryCode)
                .ToListAsync();
        }

        public async Task<IEnumerable<TDanhMucSp>> GetTopSellingAsync(int count)
        {
            return await _dbContext.TDanhMucSps
                .OrderByDescending(d => d.SalesCount)
                .Take(count)
                .ToListAsync();
        }
    }
}