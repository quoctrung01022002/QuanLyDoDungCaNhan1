using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TranQuocTrung.Entitys;
using TranQuocTrung.Models;
using TranQuocTrung.Repository;

namespace TranQuocTrung.Service
{
    public class DanhMucService : IDanhMucService
    {
        private readonly QLBanVaLiContext _context;
        private readonly IRepository<TDanhMucSPModel> _repository;

        public DanhMucService(QLBanVaLiContext context, IRepository<TDanhMucSPModel> repository)
        {
            _context = context;
            _repository = repository;
        }

        public async Task Add(TDanhMucSPModel danhMucSP)
        {
            try
            {
                await _repository.Create(danhMucSP);
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

        public async Task<IEnumerable<TDanhMucSPModel>> GetAll()
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

        public async Task<TDanhMucSPModel> GetById(string id)
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

        public async Task Update(string id, TDanhMucSPModel danhMucSP)
        {
            try
            {
                await _repository.Update(id, danhMucSP);
            }
            catch (Exception ex)
            {
                // Log exception
                Console.WriteLine($"Error in Update: {ex.Message}");
                throw; // Rethrow the exception
            }
        }

        public async Task<IEnumerable<TDanhMucSPModel>> Search(string keyword)
        {
            try
            {
                return await _repository.Search(keyword);
            }
            catch (Exception ex)
            {
                // Log exception
                Console.WriteLine($"Error in Search: {ex.Message}");
                throw; // Rethrow the exception
            }
        }

        public async Task<IEnumerable<TDanhMucSPModel>> GetPaged(int page, int pageSize)
        {
            try
            {
                return await _repository.GetPaged(page, pageSize);
            }
            catch (Exception ex)
            {
                // Log exception
                Console.WriteLine($"Error in GetPaged: {ex.Message}");
                throw; // Rethrow the exception
            }
        }
    }
}
