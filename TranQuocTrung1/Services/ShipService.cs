using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TranQuocTrung1.Entities;
using TranQuocTrung1.Models;
using TranQuocTrung1.Repositories;

namespace TranQuocTrung1.Services
{
    public class ShipService : IShipService
    {
        private readonly ROCKERContext _context;
        private readonly IRepository<ShipModel> _shipRepository;

        public ShipService(ROCKERContext context, IRepository<ShipModel> shipRepository)
        {
            _context = context;
            _shipRepository = shipRepository;
        }

        public async Task Add(ShipModel ship)
        {
            await _shipRepository.Create(ship);
        }

        public async Task Delete(int id)
        {
            await _shipRepository.Delete(id);
        }

        public async Task<IEnumerable<ShipModel>> GetAll()
        {
            return await _shipRepository.GetAll();
        }

        public async Task<ShipModel> GetById(int id)
        {
            return await _shipRepository.GetById(id);
        }

        public async Task<IEnumerable<ShipModel>> SearchShips(string keyword)
        {
            return await _shipRepository.Search(keyword);
        }

        public async Task Update(int id, ShipModel ship)
        {
            await _shipRepository.Update(id, ship);
        }
    }
}
