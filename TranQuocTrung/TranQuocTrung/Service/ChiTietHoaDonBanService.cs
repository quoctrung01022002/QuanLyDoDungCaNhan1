using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TranQuocTrung.Entitys;
using TranQuocTrung.Models;
using TranQuocTrung.Repository;

namespace TranQuocTrung.Service
{
    public class ChiTietHoaDonBanService : IChiTietHoaDonBanService
    {
        private readonly QLBanVaLiContext _context;
        private readonly IRepository<TChiTietHdbModel> _repository;

        public ChiTietHoaDonBanService(QLBanVaLiContext context, IRepository<TChiTietHdbModel> repository)
        {
            _context = context;
            _repository = repository;
        }

        public async Task Add(TChiTietHdbModel chiTietHdb)
        {
            try
            {
                await _repository.Create(chiTietHdb);
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

        public async Task<IEnumerable<TChiTietHdbModel>> GetAll()
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

        public async Task<TChiTietHdbModel> GetById(string id)
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

        public async Task Update(string id, TChiTietHdbModel chiTietHdb)
        {
            try
            {
                await _repository.Update(id, chiTietHdb);
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
