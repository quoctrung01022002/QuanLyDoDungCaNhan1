using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TranQuocTrung1.Entities;
using TranQuocTrung1.Models;

namespace TranQuocTrung1.Repositories
{
    public class ShipRepository : IRepository<ShipModel>
    {
        private readonly ROCKERContext _context;

        public ShipRepository(ROCKERContext context)
        {
            _context = context;
        }

        public async Task Create(ShipModel entity)
        {
            try
            {
                var ship = new Ship
                {
                    ShipName = entity.ShipName,
                    ShipNameAuth = entity.ShipNameAuth,
                    ShipNationality = entity.ShipNationality,
                    ShipPlate = entity.ShipPlate,
                    ShipSize = entity.ShipSize,
                    ShipWeight = entity.ShipWeight,
                    ShipWattage = entity.ShipWattage,
                    ShipCheckIn = entity.ShipCheckIn,
                    ShipAuthInfo = entity.ShipAuthInfo,
                    ShipImage = entity.ShipImage,
                };

                _context.Ships.Add(ship);
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
                var ship = await _context.Ships.FindAsync(id);
                if (ship != null)
                {
                    _context.Ships.Remove(ship);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                // Log exception
                Console.WriteLine($"Error in Delete: {ex.Message}");
                throw;
            }
        }

        public async Task<IEnumerable<ShipModel>> GetAll()
        {
            return await _context.Ships
                .Select(ship => new ShipModel
                {
                    Id = ship.Id,
                    ShipName = ship.ShipName,
                    ShipNameAuth = ship.ShipNameAuth,
                    ShipNationality = ship.ShipNationality,
                    ShipPlate = ship.ShipPlate,
                    ShipSize = ship.ShipSize,
                    ShipWeight = ship.ShipWeight,
                    ShipWattage = ship.ShipWattage,
                    ShipCheckIn = ship.ShipCheckIn,
                    ShipAuthInfo = ship.ShipAuthInfo,
                    ShipImage = ship.ShipImage,
                })
                .ToListAsync();
        }

        public async Task<ShipModel> GetById(int id)
        {
            var ship = await _context.Ships.FindAsync(id);
            if (ship == null)
            {
                return null;
            }

            return new ShipModel
            {
                Id = ship.Id,
                ShipName = ship.ShipName,
                ShipNameAuth = ship.ShipNameAuth,
                ShipNationality = ship.ShipNationality,
                ShipPlate = ship.ShipPlate,
                ShipSize = ship.ShipSize,
                ShipWeight = ship.ShipWeight,
                ShipWattage = ship.ShipWattage,
                ShipCheckIn = ship.ShipCheckIn,
                ShipAuthInfo = ship.ShipAuthInfo,
                ShipImage = ship.ShipImage,
            };
        }

        public async Task<IEnumerable<ShipModel>> Search(string keyword)
        {
            return await _context.Ships
                .Where(ship => ship.ShipName.Contains(keyword) || ship.ShipNationality.Contains(keyword))
                .Select(ship => new ShipModel
                {
                    Id = ship.Id,
                    ShipName = ship.ShipName,
                    ShipNameAuth = ship.ShipNameAuth,
                    ShipNationality = ship.ShipNationality,
                    ShipPlate = ship.ShipPlate,
                    ShipSize = ship.ShipSize,
                    ShipWeight = ship.ShipWeight,
                    ShipWattage = ship.ShipWattage,
                    ShipCheckIn = ship.ShipCheckIn,
                    ShipAuthInfo = ship.ShipAuthInfo,
                    ShipImage = ship.ShipImage,
                })
                .ToListAsync();
        }

        public async Task Update(int id, ShipModel entity)
        {
            try
            {
                var ship = await _context.Ships.FindAsync(id);
                if (ship != null)
                {
                    ship.ShipName = entity.ShipName;
                    ship.ShipNameAuth = entity.ShipNameAuth;
                    ship.ShipNationality = entity.ShipNationality;
                    ship.ShipPlate = entity.ShipPlate;
                    ship.ShipSize = entity.ShipSize;
                    ship.ShipWeight = entity.ShipWeight;
                    ship.ShipWattage = entity.ShipWattage;
                    ship.ShipCheckIn = entity.ShipCheckIn;
                    ship.ShipAuthInfo = entity.ShipAuthInfo;
                    ship.ShipImage = entity.ShipImage;

                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                // Log exception
                Console.WriteLine($"Error in Update: {ex.Message}");
                throw;
            }
        }
    }
}
