using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TranQuocTrung.Entitys;
using TranQuocTrung.Models;
using TranQuocTrung.Repository;

namespace TranQuocTrung.Service
{
    public class KhachHangService : IKhachHangService
    {
        private readonly QLBanVaLiContext _context;
        private readonly IRepository<TKhachHangModel> _repository;

        public KhachHangService(QLBanVaLiContext context, IRepository<TKhachHangModel> repository)
        {
            _context = context;
            _repository = repository;
        }

        public async Task Add(TKhachHangModel khachHang)
        {
            try
            {
                await _repository.Create(khachHang);
            }
            catch (Exception ex)
            {
                // Log exception
                Console.WriteLine($"Error in Add: {ex.Message}");
                throw; // Rethrow the exception
            }
        }

        public async Task Delete(string id)
        {
            try
            {
                await _repository.Delete(id);
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
                return await _repository.GetAll();
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
                return await _repository.GetById(id);
            }
            catch (Exception ex)
            {
                // Log exception
                Console.WriteLine($"Error in GetById: {ex.Message}");
                throw; // Rethrow the exception
            }
        }

        public async Task Update(string id, TKhachHangModel khachHang)
        {
            try
            {
                await _repository.Update(id, khachHang);
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
