using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TranQuocTrung_62132908._62.CNTT_3.Models;

namespace TranQuocTrung_62132908._62.CNTT_3.Repository
{
    public class KhachHangRepository : IKhachHangRepository
    {
        private readonly QLBanVaLiContext _dbContext;

        public KhachHangRepository(QLBanVaLiContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<TKhachHang>> GetAllKhachHangs()
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
                // Cập nhật các thuộc tính riêng lẻ
                existingKhachHang.TenKhachHang = khachHang.TenKhachHang;
                existingKhachHang.DiaChi = khachHang.DiaChi;
                // Cập nhật các thuộc tính khác tùy theo cần thiết

                await Save();
            }
            else
            {
                throw new InvalidOperationException("KhachHang not found");
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
            else
            {
                throw new InvalidOperationException("KhachHang not found");
            }
        }

        public async Task<IEnumerable<TKhachHang>> GetPagedKhachHangs(int page, int pageSize)
        {
            return await _dbContext.TKhachHangs.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
        }

        public async Task<IEnumerable<TKhachHang>> SearchKhachHangs(string keyword)
        {
            return await _dbContext.TKhachHangs
                .Where(kh => kh.TenKhachHang.Contains(keyword) || kh.DiaChi.Contains(keyword))
                .ToListAsync();
        }

        public async Task<IEnumerable<TKhachHang>> GetSortedKhachHangs(string sortBy, bool ascending)
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
