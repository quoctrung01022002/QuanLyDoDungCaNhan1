using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TranQuocTrung.Entitys;
using TranQuocTrung.Models;

namespace TranQuocTrung.Repository
{
    public class NhanVienRepository : IRepository<TNhanVienModel>
    {
        private readonly QLBanVaLiContext _context;

        public NhanVienRepository(QLBanVaLiContext context)
        {
            _context = context;
        }

        public async Task Create(TNhanVienModel entity)
        {
            try
            {
                var nhanVien = new TNhanVien
                {
                    MaNhanVien = entity.MaNhanVien,
                    TenNhanVien = entity.TenNhanVien,
                    NgaySinh = entity.NgaySinh,
                    SoDienThoai1 = entity.SoDienThoai1,
                    SoDienThoai2 = entity.SoDienThoai2,
                    DiaChi = entity.DiaChi,
                    ChucVu = entity.ChucVu,
                    AnhDaiDien = entity.AnhDaiDien,
                    GhiChu = entity.GhiChu,
                };

                _context.TNhanViens.Add(nhanVien);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Log exception
                Console.WriteLine($"Error in Create: {ex.Message}");
                throw; // Rethrow the exception
            }
        }

        public async Task Delete(string id)
        {
            try
            {
                var nhanVien = await _context.TNhanViens.FindAsync(id);
                if (nhanVien != null)
                {
                    _context.TNhanViens.Remove(nhanVien);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                // Log exception
                Console.WriteLine($"Error in Delete: {ex.Message}");
                throw; // Rethrow the exception
            }
        }

        public async Task<IEnumerable<TNhanVienModel>> GetAll()
        {
            try
            {
                var nhanViens = await _context.TNhanViens
                    .Select(nv => new TNhanVienModel
                    {
                        MaNhanVien = nv.MaNhanVien,
                        TenNhanVien = nv.TenNhanVien,
                        NgaySinh = nv.NgaySinh,
                        SoDienThoai1 = nv.SoDienThoai1,
                        SoDienThoai2 = nv.SoDienThoai2,
                        DiaChi = nv.DiaChi,
                        ChucVu = nv.ChucVu,
                        AnhDaiDien = nv.AnhDaiDien,
                        GhiChu = nv.GhiChu,
                    })
                    .ToListAsync();

                return nhanViens;
            }
            catch (Exception ex)
            {
                // Log exception
                Console.WriteLine($"Error in GetAll: {ex.Message}");
                throw; // Rethrow the exception
            }
        }

        public async Task<TNhanVienModel> GetById(string id)
        {
            try
            {
                var nhanVien = await _context.TNhanViens.FindAsync(id);
                if (nhanVien != null)
                {
                    return new TNhanVienModel
                    {
                        MaNhanVien = nhanVien.MaNhanVien,
                        TenNhanVien = nhanVien.TenNhanVien,
                        NgaySinh = nhanVien.NgaySinh,
                        SoDienThoai1 = nhanVien.SoDienThoai1,
                        SoDienThoai2 = nhanVien.SoDienThoai2,
                        DiaChi = nhanVien.DiaChi,
                        ChucVu = nhanVien.ChucVu,
                        AnhDaiDien = nhanVien.AnhDaiDien,
                        GhiChu = nhanVien.GhiChu,
                    };
                }
                return null;
            }
            catch (Exception ex)
            {
                // Log exception
                Console.WriteLine($"Error in GetById: {ex.Message}");
                throw; // Rethrow the exception
            }
        }

        public Task<IEnumerable<TNhanVienModel>> GetPaged(int page, int pageSize)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TNhanVienModel>> Search(string keyword)
        {
            throw new NotImplementedException();
        }

        public async Task Update(string id, TNhanVienModel entity)
        {
            try
            {
                var nhanVien = await _context.TNhanViens.FindAsync(id);
                if (nhanVien != null)
                {
                    nhanVien.MaNhanVien = entity.MaNhanVien;
                    nhanVien.TenNhanVien = entity.TenNhanVien;
                    nhanVien.NgaySinh = entity.NgaySinh;
                    nhanVien.SoDienThoai1 = entity.SoDienThoai1;
                    nhanVien.SoDienThoai2 = entity.SoDienThoai2;
                    nhanVien.DiaChi = entity.DiaChi;
                    nhanVien.ChucVu = entity.ChucVu;
                    nhanVien.AnhDaiDien = entity.AnhDaiDien;
                    nhanVien.GhiChu = entity.GhiChu;

                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                // Log exception
                Console.WriteLine($"Error in Update: {ex.Message}");
                throw; // Rethrow the exception
            }
        }
    }
}
