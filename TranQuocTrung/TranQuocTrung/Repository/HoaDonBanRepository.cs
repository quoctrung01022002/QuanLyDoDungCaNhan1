using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TranQuocTrung.Entitys;
using TranQuocTrung.Models;

namespace TranQuocTrung.Repository
{
    public class HoaDonBanRepository : IRepository<THoaDonBanModel>
    {
        private readonly QLBanVaLiContext _context;

        public HoaDonBanRepository(QLBanVaLiContext context)
        {
            _context = context;
        }

        public async Task Create(THoaDonBanModel entity)
        {
            try
            {
                var hoaDonBan = new THoaDonBan
                {
                    MaHoaDon = entity.MaHoaDon,
                    NgayHoaDon = entity.NgayHoaDon,
                    MaKhachHang = entity.MaKhachHang,
                    MaNhanVien = entity.MaNhanVien,
                    TongTienHd = entity.TongTienHd,
                    GiamGiaHd = entity.GiamGiaHd,
                    PhuongThucThanhToan = entity.PhuongThucThanhToan,
                    MaSoThue = entity.MaSoThue,
                    ThongTinThue = entity.ThongTinThue,
                    GhiChu = entity.GhiChu,
                };

                _context.THoaDonBans.Add(hoaDonBan);
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
                var hoaDonBan = await _context.THoaDonBans.FindAsync(id);
                if (hoaDonBan != null)
                {
                    _context.THoaDonBans.Remove(hoaDonBan);
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

        public async Task<IEnumerable<THoaDonBanModel>> GetAll()
        {
            try
            {
                var hoaDonBans = await _context.THoaDonBans
                    .Select(hd => new THoaDonBanModel
                    {
                        MaHoaDon = hd.MaHoaDon,
                        NgayHoaDon = hd.NgayHoaDon,
                        MaKhachHang = hd.MaKhachHang,
                        MaNhanVien = hd.MaNhanVien,
                        TongTienHd = hd.TongTienHd,
                        GiamGiaHd = hd.GiamGiaHd,
                        PhuongThucThanhToan = hd.PhuongThucThanhToan,
                        MaSoThue = hd.MaSoThue,
                        ThongTinThue = hd.ThongTinThue,
                        GhiChu = hd.GhiChu,
                    })
                    .ToListAsync();

                return hoaDonBans;
            }
            catch (Exception ex)
            {
                // Log exception
                Console.WriteLine($"Error in GetAll: {ex.Message}");
                throw; // Rethrow the exception
            }
        }

        public async Task<THoaDonBanModel> GetById(string id)
        {
            try
            {
                var hoaDonBan = await _context.THoaDonBans.FindAsync(id);
                if (hoaDonBan != null)
                {
                    return new THoaDonBanModel
                    {
                        MaHoaDon = hoaDonBan.MaHoaDon,
                        NgayHoaDon = hoaDonBan.NgayHoaDon,
                        MaKhachHang = hoaDonBan.MaKhachHang,
                        MaNhanVien = hoaDonBan.MaNhanVien,
                        TongTienHd = hoaDonBan.TongTienHd,
                        GiamGiaHd = hoaDonBan.GiamGiaHd,
                        PhuongThucThanhToan = hoaDonBan.PhuongThucThanhToan,
                        MaSoThue = hoaDonBan.MaSoThue,
                        ThongTinThue = hoaDonBan.ThongTinThue,
                        GhiChu = hoaDonBan.GhiChu,
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

        public Task<IEnumerable<THoaDonBanModel>> Search(string keyword)
        {
            throw new NotImplementedException();
        }

        public async Task Update(string id, THoaDonBanModel entity)
        {
            try
            {
                var hoaDonBan = await _context.THoaDonBans.FindAsync(id);
                if (hoaDonBan != null)
                {
                    hoaDonBan.MaHoaDon = entity.MaHoaDon;
                    hoaDonBan.NgayHoaDon = entity.NgayHoaDon;
                    hoaDonBan.MaKhachHang = entity.MaKhachHang;
                    hoaDonBan.MaNhanVien = entity.MaNhanVien;
                    hoaDonBan.TongTienHd = entity.TongTienHd;
                    hoaDonBan.GiamGiaHd = entity.GiamGiaHd;
                    hoaDonBan.PhuongThucThanhToan = entity.PhuongThucThanhToan;
                    hoaDonBan.MaSoThue = entity.MaSoThue;
                    hoaDonBan.ThongTinThue = entity.ThongTinThue;
                    hoaDonBan.GhiChu = entity.GhiChu;

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
