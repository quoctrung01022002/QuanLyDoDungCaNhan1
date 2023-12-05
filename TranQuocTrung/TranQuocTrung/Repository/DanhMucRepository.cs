using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TranQuocTrung.Entitys;
using TranQuocTrung.Models;

namespace TranQuocTrung.Repository
{
    public class DanhMucRepository : IRepository<TDanhMucSPModel>
    {
        private readonly QLBanVaLiContext _context;

        public DanhMucRepository(QLBanVaLiContext context)
        {
            _context = context;
        }

        public async Task Create(TDanhMucSPModel entity)
        {
            try
            {
                var danhMuc = new TDanhMucSp
                {
                    MaSp = entity.MaSp,
                    TenSp = entity.TenSp,
                    NganLapTop = entity.NganLapTop,
                    Model = entity.Model,
                    CanNang = entity.CanNang,
                    DoNoi = entity.DoNoi,
                    Website = entity.Website,
                    ThoiGianBaoHanh = entity.ThoiGianBaoHanh,
                    GioiThieuSp = entity.GioiThieuSp,
                    ChietKhau = entity.ChietKhau,
                    AnhDaiDien = entity.AnhDaiDien,
                    GiaNhoNhat = entity.GiaNhoNhat,
                    GiaLonNhat = entity.GiaLonNhat,
                };

                _context.Add(danhMuc);
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
                var danhMuc = await _context.TDanhMucSps.FindAsync(id);
                if (danhMuc != null)
                {
                    _context.TDanhMucSps.Remove(danhMuc);
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

        public async Task<IEnumerable<TDanhMucSPModel>> GetAll()
        {
            try
            {
                var danhMucs = await _context.TDanhMucSps
                    .Select(dm => new TDanhMucSPModel
                    {
                        MaSp = dm.MaSp,
                        TenSp = dm.TenSp,
                        NganLapTop = dm.NganLapTop,
                        Model = dm.Model,
                        CanNang = dm.CanNang,
                        DoNoi = dm.DoNoi,
                        Website = dm.Website,
                        ThoiGianBaoHanh = dm.ThoiGianBaoHanh,
                        GioiThieuSp = dm.GioiThieuSp,
                        ChietKhau = dm.ChietKhau,
                        AnhDaiDien = dm.AnhDaiDien,
                        GiaNhoNhat = dm.GiaNhoNhat,
                        GiaLonNhat = dm.GiaLonNhat,
                    })
                    .ToListAsync();

                return danhMucs;
            }
            catch (Exception ex)
            {
                // Log exception
                Console.WriteLine($"Error in GetAll: {ex.Message}");
                throw; // Rethrow the exception
            }
        }

        public async Task<TDanhMucSPModel> GetById(string id)
        {
            try
            {
                var danhMuc = await _context.TDanhMucSps.FindAsync(id);
                if (danhMuc != null)
                {
                    return new TDanhMucSPModel
                    {
                        MaSp = danhMuc.MaSp,
                        TenSp = danhMuc.TenSp,
                        NganLapTop = danhMuc.NganLapTop,
                        Model = danhMuc.Model,
                        CanNang = danhMuc.CanNang,
                        DoNoi = danhMuc.DoNoi,
                        Website = danhMuc.Website,
                        ThoiGianBaoHanh = danhMuc.ThoiGianBaoHanh,
                        GioiThieuSp = danhMuc.GioiThieuSp,
                        ChietKhau = danhMuc.ChietKhau,
                        AnhDaiDien = danhMuc.AnhDaiDien,
                        GiaNhoNhat = danhMuc.GiaNhoNhat,
                        GiaLonNhat = danhMuc.GiaLonNhat,
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

        public async Task<IEnumerable<TDanhMucSPModel>> GetPaged(int page, int pageSize)
        {
            try
            {
                var danhMucs = await _context.TDanhMucSps
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize)
                    .Select(dm => new TDanhMucSPModel
                    {
                        MaSp = dm.MaSp,
                        TenSp = dm.TenSp,
                        NganLapTop = dm.NganLapTop,
                        Model = dm.Model,
                        CanNang = dm.CanNang,
                        DoNoi = dm.DoNoi,
                        Website = dm.Website,
                        ThoiGianBaoHanh = dm.ThoiGianBaoHanh,
                        GioiThieuSp = dm.GioiThieuSp,
                        ChietKhau = dm.ChietKhau,
                        AnhDaiDien = dm.AnhDaiDien,
                        GiaNhoNhat = dm.GiaNhoNhat,
                        GiaLonNhat = dm.GiaLonNhat,
                    })
                    .ToListAsync();

                return danhMucs;
            }
            catch (Exception ex)
            {
                // Log exception
                Console.WriteLine($"Error in GetPaged: {ex.Message}");
                throw; // Rethrow the exception
            }
        }

        public async Task<IEnumerable<TDanhMucSPModel>> Search(string keyword)
        {
            try
            {
                var danhMucs = await _context.TDanhMucSps
                    .Where(dm =>
                        dm.TenSp.Contains(keyword) ||
                        dm.Model.Contains(keyword)
                    )
                    .Select(dm => new TDanhMucSPModel
                    {
                        MaSp = dm.MaSp,
                        TenSp = dm.TenSp,
                    })
                    .ToListAsync();

                return danhMucs;
            }
            catch (Exception ex)
            {
                // Log exception
                Console.WriteLine($"Error in Search: {ex.Message}");
                throw; // Rethrow the exception
            }
        }

        public async Task Update(string id, TDanhMucSPModel entity)
        {
            try
            {
                var danhMuc = await _context.TDanhMucSps.FindAsync(id);
                if (danhMuc != null)
                {
                    danhMuc.MaSp = entity.MaSp;
                    danhMuc.TenSp = entity.TenSp;
                    danhMuc.NganLapTop = entity.NganLapTop;
                    danhMuc.Model = entity.Model;
                    danhMuc.CanNang = entity.CanNang;
                    danhMuc.DoNoi = entity.DoNoi;
                    danhMuc.Website = entity.Website;
                    danhMuc.ThoiGianBaoHanh = entity.ThoiGianBaoHanh;
                    danhMuc.GioiThieuSp = entity.GioiThieuSp;
                    danhMuc.ChietKhau = entity.ChietKhau;
                    danhMuc.AnhDaiDien = entity.AnhDaiDien;
                    danhMuc.GiaNhoNhat = entity.GiaNhoNhat;
                    danhMuc.GiaLonNhat = entity.GiaLonNhat;

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
