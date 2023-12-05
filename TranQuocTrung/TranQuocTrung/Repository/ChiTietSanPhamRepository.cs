using TranQuocTrung.Models;

namespace TranQuocTrung.Repository
{
    public class ChiTietSanPhamRepository : IRepository<TChiTietSanPhamModel>
    {
        public Task Create(TChiTietSanPhamModel entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(string id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TChiTietSanPhamModel>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<TChiTietSanPhamModel> GetById(string id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TChiTietSanPhamModel>> GetPaged(int page, int pageSize)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TChiTietSanPhamModel>> Search(string keyword)
        {
            throw new NotImplementedException();
        }

        public Task Update(string id, TChiTietSanPhamModel entity)
        {
            throw new NotImplementedException();
        }
    }
}
