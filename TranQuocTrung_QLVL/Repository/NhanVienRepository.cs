using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TranQuocTrung_QLVL.Models;

namespace TranQuocTrung_QLVL.Repository
{
    public class NhanVienRepository : INhanVienRepository
    {
        private readonly QLBanVaLiContext _dbContext;

        public NhanVienRepository(QLBanVaLiContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<TNhanVien>> GetAllNhanViens()
        {
            return await _dbContext.TNhanViens.ToListAsync();
        }

        public async Task CreateNhanVien(TNhanVien nhanVien)
        {
            _dbContext.TNhanViens.Add(nhanVien);
            await Save();
        }

        public async Task<TNhanVien> GetNhanVienById(string id)
        {
            return await _dbContext.TNhanViens.FindAsync(id);
        }

        public async Task UpdateNhanVien(string id, TNhanVien nhanVien)
        {
            var existingNhanVien = await _dbContext.TNhanViens.FindAsync(id);

            if (existingNhanVien != null)
            {
                _dbContext.Entry(existingNhanVien).CurrentValues.SetValues(nhanVien);
                await Save();
            }
        }

        public async Task DeleteNhanVien(string id)
        {
            var nhanVien = await _dbContext.TNhanViens.FindAsync(id);

            if (nhanVien != null)
            {
                _dbContext.TNhanViens.Remove(nhanVien);
                await Save();
            }
        }

        public async Task<List<TNhanVien>> GetPagedNhanViens(int page, int pageSize)
        {
            return await _dbContext.TNhanViens.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
        }

        public async Task<List<TNhanVien>> SearchNhanViens(string keyword)
        {
            return await _dbContext.TNhanViens
                .Where(nv => nv.TenNhanVien.Contains(keyword) || nv.DiaChi.Contains(keyword))
                .ToListAsync();
        }

        public async Task<List<TNhanVien>> GetSortedNhanViens(string sortBy, bool ascending)
        {
            var query = _dbContext.TNhanViens.AsQueryable();

            switch (sortBy)
            {
                case "TenNhanVien":
                    query = ascending ? query.OrderBy(nv => nv.TenNhanVien) : query.OrderByDescending(nv => nv.TenNhanVien);
                    break;
                case "DiaChi":
                    query = ascending ? query.OrderBy(nv => nv.DiaChi) : query.OrderByDescending(nv => nv.DiaChi);
                    break;
                default:
                    query = query.OrderBy(nv => nv.MaNhanVien);
                    break;
            }

            return await query.ToListAsync();
        }

        public async Task<bool> NhanVienExists(string id)
        {
            return await _dbContext.TNhanViens.AnyAsync(e => e.MaNhanVien == id);
        }

        public async Task Save()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}