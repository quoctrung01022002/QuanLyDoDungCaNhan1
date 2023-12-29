using System.Collections.Generic;
using System.Threading.Tasks;
using TranQuocTrung1.Entities;
using TranQuocTrung1.Models;
using TranQuocTrung1.Repositories;

namespace TranQuocTrung1.Services
{
    public class BerthService : IBerthService
    {
        private readonly ROCKERContext _context;
        private readonly IRepository<BerthModel> _berthRepository;

        public BerthService(ROCKERContext context, IRepository<BerthModel> berthRepository)
        {
            _context = context;
            _berthRepository = berthRepository;
        }

        public async Task Add(BerthModel berth)
        {
            await _berthRepository.Create(berth);
        }

        public async Task<IEnumerable<BerthModel>> GetAll()
        {
            return await _berthRepository.GetAll();
        }

        public async Task<BerthModel> GetById(int id)
        {
            return await _berthRepository.GetById(id);
        }

        public async Task Update(int id, BerthModel berth)
        {
            await _berthRepository.Update(id, berth);
        }

        public async Task Delete(int id)
        {
            await _berthRepository.Delete(id);
        }

        public async Task<IEnumerable<BerthModel>> SearchBerths(string keyword)
        {
            return await _berthRepository.Search(keyword.ToString());
        }
    }
}
