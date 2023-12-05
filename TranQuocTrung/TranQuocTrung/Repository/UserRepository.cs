using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TranQuocTrung.Entitys;
using TranQuocTrung.Models;

namespace TranQuocTrung.Repository
{
    public class UserRepository : IRepository<TUserModel>
    {
        private readonly QLBanVaLiContext _context;

        public UserRepository(QLBanVaLiContext context)
        {
            _context = context;
        }

        public async Task Create(TUserModel entity)
        {
            try
            {
                var user = new TUser
                {
                    Username = entity.Username,
                    Password = entity.Password,
                    LoaiUser = entity.LoaiUser,
                };

                _context.TUsers.Add(user);
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
                var user = await _context.TUsers.FindAsync(id);
                if (user != null)
                {
                    _context.TUsers.Remove(user);
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

        public async Task<IEnumerable<TUserModel>> GetAll()
        {
            try
            {
                var users = await _context.TUsers
                    .Select(u => new TUserModel
                    {
                        Username = u.Username,
                        Password = u.Password,
                        LoaiUser = u.LoaiUser,
                    })
                    .ToListAsync();

                return users;
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
                var user = await _context.TUsers.FindAsync(id);
                if (user != null)
                {
                    return new TUserModel
                    {
                        Username = user.Username,
                        Password = user.Password,
                        LoaiUser = user.LoaiUser,
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

        public Task<IEnumerable<TUserModel>> GetPaged(int page, int pageSize)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TUserModel>> Search(string keyword)
        {
            throw new NotImplementedException();
        }

        public async Task Update(string id, TUserModel entity)
        {
            try
            {
                var user = await _context.TUsers.FindAsync(id);
                if (user != null)
                {
                    user.Username = entity.Username;
                    user.Password = entity.Password;
                    user.LoaiUser = entity.LoaiUser;

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
