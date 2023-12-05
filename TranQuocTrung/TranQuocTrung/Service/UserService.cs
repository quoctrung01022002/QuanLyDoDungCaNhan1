using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TranQuocTrung.Entitys;
using TranQuocTrung.Models;
using TranQuocTrung.Repository;

namespace TranQuocTrung.Service
{
    public class UserService : IUserService
    {
        private readonly QLBanVaLiContext _context;
        private readonly IRepository<TUserModel> _userRepository;

        public UserService(QLBanVaLiContext context, IRepository<TUserModel> userRepository)
        {
            _context = context;
            _userRepository = userRepository;
        }

        public async Task Add(TUserModel user)
        {
            try
            {
                await _userRepository.Create(user);
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
                await _userRepository.Delete(id);
            }
            catch (Exception ex)
            {
                // Log exception
                Console.WriteLine($"Error in Delete: {ex.Message}");
                throw; // Rethrow the exception
            }
        }

        public async Task<IEnumerable<TUserModel>> GetAll()
        {
            try
            {
                return await _userRepository.GetAll();
            }
            catch (Exception ex)
            {
                // Log exception
                Console.WriteLine($"Error in GetAll: {ex.Message}");
                throw; // Rethrow the exception
            }
        }

        public async Task<TUserModel> GetById(string id)
        {
            try
            {
                return await _userRepository.GetById(id);
            }
            catch (Exception ex)
            {
                // Log exception
                Console.WriteLine($"Error in GetById: {ex.Message}");
                throw; // Rethrow the exception
            }
        }

        public async Task Update(string id, TUserModel user)
        {
            try
            {
                await _userRepository.Update(id, user);
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
