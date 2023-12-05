using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TranQuocTrung.Entitys;
using TranQuocTrung.Models;

namespace TranQuocTrung.Repository
{
    public class ChiTietHoaDonBanRepository : IRepository<TChiTietHdbModel>
    {
        private readonly QLBanVaLiContext _context;

        public ChiTietHoaDonBanRepository(QLBanVaLiContext context)
        {
            _context = context;
        }

        public async Task Create(TChiTietHdbModel entity)
        {
            try
            {
                var chiTietHDonBan = new TChiTietHdb
                {
                    MaHoaDon = entity.MaHoaDon,
                    MaChiTietSp = entity.MaChiTietSp,
                    SoLuongBan = entity.SoLuongBan,
                    DonGiaBan = entity.DonGiaBan,
                    GiamGia = entity.GiamGia,
                    GhiChu = entity.GhiChu,
                };

                _context.TChiTietHdbs.Add(chiTietHDonBan);
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
                var chiTietHDonBan = await _context.TChiTietHdbs.FindAsync(id);
                if (chiTietHDonBan != null)
                {
                    _context.TChiTietHdbs.Remove(chiTietHDonBan);
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

        public async Task<IEnumerable<TChiTietHdbModel>> GetAll()
        {
            try
            {
                var chiTietHdbList = await _context.TChiTietHdbs
                    .Select(ct => new TChiTietHdbModel
                    {
                        MaHoaDon = ct.MaHoaDon,
                        MaChiTietSp = ct.MaChiTietSp,
                        SoLuongBan = ct.SoLuongBan,
                        DonGiaBan = ct.DonGiaBan,
                        GiamGia = ct.GiamGia,
                        GhiChu = ct.GhiChu,
                    })
                    .ToListAsync();

                return chiTietHdbList;
            }
            catch (Exception ex)
            {
                // Log exception
                Console.WriteLine($"Error in GetAll: {ex.Message}");
                throw; // Rethrow the exception
            }
        }

        public async Task<TChiTietHdbModel> GetById(string id)
        {
            try
            {
                var chiTietHDonBan = await _context.TChiTietHdbs.FindAsync(id);
                if (chiTietHDonBan != null)
                {
                    return new TChiTietHdbModel
                    {
                        MaHoaDon = chiTietHDonBan.MaHoaDon,
                        MaChiTietSp = chiTietHDonBan.MaChiTietSp,
                        SoLuongBan = chiTietHDonBan.SoLuongBan,
                        DonGiaBan = chiTietHDonBan.DonGiaBan,
                        GiamGia = chiTietHDonBan.GiamGia,
                        GhiChu = chiTietHDonBan.GhiChu,
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

        public Task<IEnumerable<TChiTietHdbModel>> GetPaged(int page, int pageSize)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TChiTietHdbModel>> Search(string keyword)
        {
            throw new NotImplementedException();
        }

        public async Task Update(string id, TChiTietHdbModel entity)
        {
            try
            {
                var chiTietHDonBan = await _context.TChiTietHdbs.FindAsync(id);
                if (chiTietHDonBan != null)
                {
                    chiTietHDonBan.MaHoaDon = entity.MaHoaDon;
                    chiTietHDonBan.MaChiTietSp = entity.MaChiTietSp;
                    chiTietHDonBan.SoLuongBan = entity.SoLuongBan;
                    chiTietHDonBan.DonGiaBan = entity.DonGiaBan;
                    chiTietHDonBan.GiamGia = entity.GiamGia;
                    chiTietHDonBan.GhiChu = entity.GhiChu;

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
