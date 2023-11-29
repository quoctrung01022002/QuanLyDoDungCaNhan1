using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TranQuocTrung_QLVL.Models;

namespace TranQuocTrung_QLVL.Repository
{
    public class DanhMucRepository : IDanhMucRepository
    {
        private readonly YourDbContext _context;

        public DanhMucRepository(YourDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TDanhMucSp>> GetAllDanhMucSPs()
        {
            return await _context.TDanhMucSp.ToListAsync();
        }

        public async Task<TDanhMucSp> GetDanhMucSPById(string id)
        {
            return await _context.TDanhMucSp.FirstOrDefaultAsync(d => d.MaSp == id);
        }

        public async Task CreateDanhMucSP(TDanhMucSp danhMucSP)
        {
            _context.TDanhMucSp.Add(danhMucSP);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateDanhMucSP(string id, TDanhMucSp danhMucSP)
        {
            var existingDanhMucSP = await _context.TDanhMucSp.FirstOrDefaultAsync(d => d.MaSp == id);

            if (existingDanhMucSP != null)
            {
                existingDanhMucSP.TenSp = danhMucSP.TenSp;
                // Update other properties as needed
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteDanhMucSP(string id)
        {
            var danhMucSP = await _context.TDanhMucSp.FirstOrDefaultAsync(d => d.MaSp == id);

            if (danhMucSP != null)
            {
                _context.TDanhMucSp.Remove(danhMucSP);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<TDanhMucSp>> GetDanhMucSPsByCategory(string categoryId)
        {
            return await _context.TDanhMucSp.Where(d => d.MaLoai == categoryId).ToListAsync();
        }

        public async Task<IEnumerable<TDanhMucSp>> GetDanhMucSPsByBrand(string brandId)
        {
            return await _context.TDanhMucSp.Where(d => d.MaHangSx == brandId).ToListAsync();
        }

        public async Task<IEnumerable<TDanhMucSp>> GetAllBrands()
        {
            return await _context.TDanhMucSp.Select(d => d.MaHangSx).Distinct().ToListAsync();
        }

        public async Task<IEnumerable<TDanhMucSp>> GetAllCategories()
        {
            return await _context.TDanhMucSp.Select(d => d.MaLoai).Distinct().ToListAsync();
        }

        public async Task<IEnumerable<TDanhMucSp>> GetProductsByPriceRange(decimal minPrice, decimal maxPrice)
        {
            return await _context.TDanhMucSp
                .Where(d => d.GiaNhoNhat >= minPrice && d.GiaLonNhat <= maxPrice)
                .ToListAsync();
        }

        public async Task<IEnumerable<TDanhMucSp>> GetDanhMucSPsByCountry(string countryId)
        {
            return await _context.TDanhMucSp.Where(d => d.MaNuocSx == countryId).ToListAsync();
        }

        public async Task<IEnumerable<TDanhMucSp>> GetAllMaterials()
        {
            return await _context.TDanhMucSp.Select(d => d.MaChatLieu).Distinct().ToListAsync();
        }
    }
}
