using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TranQuocTrung1.Entities;
using TranQuocTrung1.Models;

namespace TranQuocTrung1.Repositories
{
    public class BerthRepository : IRepository<BerthModel>
    {
        private readonly ROCKERContext _context;

        public BerthRepository(ROCKERContext context)
        {
            _context = context;
        }

        public async Task Create(BerthModel entity)
        {
            try
            {
                var berth = new Berth
                {
                    BerthName = entity.BerthName,
                    BerthCapacity = entity.BerthCapacity,
                    BerthStatus = entity.BerthStatus,
                };

                _context.Berths.Add(berth);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Log exception (consider using a logging framework)
                Console.WriteLine($"Error in Create: {ex.Message}");
                throw; // Rethrow the exception
            }
        }

        public async Task Delete(int id)
        {
            try
            {
                var berth = await _context.Berths.FindAsync(id);
                if (berth != null)
                {
                    _context.Berths.Remove(berth);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                // Log exception (consider using a logging framework)
                Console.WriteLine($"Error in Delete: {ex.Message}");
                throw; // Rethrow the exception
            }
        }

        public async Task<IEnumerable<BerthModel>> GetAll()
        {
            try
            {
                var berths = await _context.Berths
                    .Select(b => new BerthModel
                    {
                        Id = b.Id,
                        BerthName = b.BerthName,
                        BerthCapacity = b.BerthCapacity,
                        BerthStatus = b.BerthStatus,
                    })
                    .ToListAsync();

                return berths;
            }
            catch (Exception ex)
            {
                // Log exception (consider using a logging framework)
                Console.WriteLine($"Error in GetAll: {ex.Message}");
                throw; // Rethrow the exception
            }
        }

        public async Task<BerthModel> GetById(int id)
        {
            try
            {
                var berth = await _context.Berths.FindAsync(id);
                if (berth != null)
                {
                    return new BerthModel
                    {
                        Id = berth.Id,
                        BerthName = berth.BerthName,
                        BerthCapacity = berth.BerthCapacity,
                        BerthStatus = berth.BerthStatus,
                    };
                }
                return null;
            }
            catch (Exception ex)
            {
                // Log exception (consider using a logging framework)
                Console.WriteLine($"Error in GetById: {ex.Message}");
                throw; // Rethrow the exception
            }
        }

        public async Task<IEnumerable<BerthModel>> Search(string keyword)
        {
            try
            {
                var berths = await _context.Berths
                    .Where(b =>
                        b.BerthName.Contains(keyword) ||
                        b.BerthCapacity.ToString().Contains(keyword) ||
                        b.BerthStatus.Contains(keyword)
                    )
                    .Select(b => new BerthModel
                    {
                        BerthName = b.BerthName,
                        BerthCapacity = b.BerthCapacity,
                        BerthStatus = b.BerthStatus,
                    })
                    .ToListAsync();

                return berths;
            }
            catch (Exception ex)
            {
                // Log exception (consider using a logging framework)
                Console.WriteLine($"Error in Search: {ex.Message}");
                throw; // Rethrow the exception
            }
        }

        public async Task Update(int id, BerthModel entity)
        {
            try
            {
                var berth = await _context.Berths.FindAsync(id);
                if (berth != null)
                {
                    berth.BerthName = entity.BerthName;
                    berth.BerthCapacity = entity.BerthCapacity;
                    berth.BerthStatus = entity.BerthStatus;

                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                // Log exception (consider using a logging framework)
                Console.WriteLine($"Error in Update: {ex.Message}");
                throw; // Rethrow the exception
            }
        }
    }
}
