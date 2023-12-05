using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TranQuocTrung.Entitys;
using TranQuocTrung.Models;

namespace TranQuocTrung.Repository
{
    public class KhachHangRepository : IRepository<TKhachHangModel>
    {
        private readonly QLBanVaLiContext _context;

        public KhachHangRepository(QLBanVaLiContext context)
        {
            _context = context;
        }

        public async Task Create(TKhachHangModel entity)
        {
            try
            {
                var khachHang = new TKhachHang
                {
                    MaKhanhHang = entity.MaKhanhHang,
                    TenKhachHang = entity.TenKhachHang,
                    NgaySinh = entity.NgaySinh,
                    SoDienThoai = entity.SoDienThoai,
                    DiaChi = entity.DiaChi,
                    LoaiKhachHang = entity.LoaiKhachHang,
                    AnhDaiDien = entity.AnhDaiDien,
                    GhiChu = entity.GhiChu,
                };

                _context.TKhachHangs.Add(khachHang);
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
                var khachHang = await _context.TKhachHangs.FindAsync(id);
                if (khachHang != null)
                {
                    _context.TKhachHangs.Remove(khachHang);
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

        public async Task<IEnumerable<TKhachHangModel>> GetAll()
        {
            try
            {
                var khachHangs = await _context.TKhachHangs
                    .Select(kh => new TKhachHangModel
                    {
                        MaKhanhHang = kh.MaKhanhHang,
                        TenKhachHang = kh.TenKhachHang,
                        NgaySinh = kh.NgaySinh,
                        SoDienThoai = kh.SoDienThoai,
                        DiaChi = kh.DiaChi,
                        LoaiKhachHang = kh.LoaiKhachHang,
                        AnhDaiDien = kh.AnhDaiDien,
                        GhiChu = kh.GhiChu,
                    })
                    .ToListAsync();

                return khachHangs;
            }
            catch (Exception ex)
            {
                // Log exception
                Console.WriteLine($"Error in GetAll: {ex.Message}");
                throw; // Rethrow the exception
            }
        }

        public async Task<TKhachHangModel> GetById(string id)
        {
            try
            {
                var khachHang = await _context.TKhachHangs.FindAsync(id);
                if (khachHang != null)
                {
                    return new TKhachHangModel
                    {
                        MaKhanhHang = khachHang.MaKhanhHang,
                        TenKhachHang = khachHang.TenKhachHang,
                        NgaySinh = khachHang.NgaySinh,
                        SoDienThoai = khachHang.SoDienThoai,
                        DiaChi = khachHang.DiaChi,
                        LoaiKhachHang = khachHang.LoaiKhachHang,
                        AnhDaiDien = khachHang.AnhDaiDien,
                        GhiChu = khachHang.GhiChu,
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

        public Task<IEnumerable<TKhachHangModel>> GetPaged(int page, int pageSize)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TKhachHangModel>> Search(string keyword)
        {
            throw new NotImplementedException();
        }

        public async Task Update(string id, TKhachHangModel entity)
        {
            try
            {
                var khachHang = await _context.TKhachHangs.FindAsync(id);
                if (khachHang != null)
                {
                    khachHang.MaKhanhHang = entity.MaKhanhHang;
                    khachHang.TenKhachHang = entity.TenKhachHang;
                    khachHang.NgaySinh = entity.NgaySinh;
                    khachHang.SoDienThoai = entity.SoDienThoai;
                    khachHang.DiaChi = entity.DiaChi;
                    khachHang.LoaiKhachHang = entity.LoaiKhachHang;
                    khachHang.AnhDaiDien = entity.AnhDaiDien;
                    khachHang.GhiChu = entity.GhiChu;

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
