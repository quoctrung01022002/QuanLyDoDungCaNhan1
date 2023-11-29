// KhachHangRepository.cs
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TranQuocTrung_QLVL.Models;

namespace TranQuocTrung_QLVL.Repository
{
    public class KhachHangRepository : IKhachHangRepository
    {
        private readonly QLBanVaLiContext _dbContext;

        public KhachHangRepository(QLBanVaLiContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<TKhachHang>> GetAllKhachHangs()
        {
            return await _dbContext.TKhachHangs.ToListAsync();
        }

        public async Task CreateKhachHang(TKhachHang khachHang)
        {
            _dbContext.TKhachHangs.Add(khachHang);
            await Save();
        }

        public async Task<TKhachHang> GetKhachHangById(string id)
        {
            return await _dbContext.TKhachHangs.FindAsync(id);
        }

        public async Task UpdateKhachHang(string id, TKhachHang khachHang)
        {
            var existingKhachHang = await _dbContext.TKhachHangs.FindAsync(id);

            if (existingKhachHang != null)
            {
                _dbContext.Entry(existingKhachHang).CurrentValues.SetValues(khachHang);
                await Save();
            }
        }

        public async Task DeleteKhachHang(string id)
        {
            var khachHang = await _dbContext.TKhachHangs.FindAsync(id);

            if (khachHang != null)
            {
                _dbContext.TKhachHangs.Remove(khachHang);
                await Save();
            }
        }

        public async Task<List<TKhachHang>> GetPagedKhachHangs(int page, int pageSize)
        {
            return await _dbContext.TKhachHangs.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
        }

        public async Task<List<TKhachHang>> SearchKhachHangs(string keyword)
        {
            return await _dbContext.TKhachHangs
                .Where(kh => kh.TenKhachHang.Contains(keyword) || kh.DiaChi.Contains(keyword))
                .ToListAsync();
        }

        public async Task<List<TKhachHang>> GetSortedKhachHangs(string sortBy, bool ascending)
        {
            var query = _dbContext.TKhachHangs.AsQueryable();

            switch (sortBy)
            {
                case "TenKhachHang":
                    query = ascending ? query.OrderBy(kh => kh.TenKhachHang) : query.OrderByDescending(kh => kh.TenKhachHang);
                    break;
                case "DiaChi":
                    query = ascending ? query.OrderBy(kh => kh.DiaChi) : query.OrderByDescending(kh => kh.DiaChi);
                    break;
                default:
                    query = query.OrderBy(kh => kh.MaKhanhHang);
                    break;
            }

            return await query.ToListAsync();
        }

        public async Task<bool> KhachHangExists(string id)
        {
            return await _dbContext.TKhachHangs.AnyAsync(e => e.MaKhanhHang == id);
        }

        public async Task Save()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
