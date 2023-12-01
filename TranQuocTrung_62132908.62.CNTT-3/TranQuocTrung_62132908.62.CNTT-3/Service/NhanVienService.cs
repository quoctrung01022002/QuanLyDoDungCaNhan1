using System.Collections.Generic;
using System.Threading.Tasks;
using TranQuocTrung_62132908._62.CNTT_3.Models;
using TranQuocTrung_62132908._62.CNTT_3.Repository;

namespace TranQuocTrung_62132908.Service
{
    public class NhanVienService : INhanVienRepository
    {
        private readonly INhanVienRepository _nhanVienRepository;

        public NhanVienService(INhanVienRepository nhanVienRepository)
        {
            _nhanVienRepository = nhanVienRepository;
        }

        public async Task<IEnumerable<TNhanVien>> GetAllNhanViens()
        {
            return await _nhanVienRepository.GetAllNhanViens();
        }

        public async Task<TNhanVien> GetNhanVienById(string id)
        {
            return await _nhanVienRepository.GetNhanVienById(id);
        }

        public async Task CreateNhanVien(TNhanVien nhanVien)
        {
            await _nhanVienRepository.CreateNhanVien(nhanVien);
        }

        public async Task UpdateNhanVien(string id, TNhanVien nhanVien)
        {
            await _nhanVienRepository.UpdateNhanVien(id, nhanVien);
        }

        public async Task DeleteNhanVien(string id)
        {
            await _nhanVienRepository.DeleteNhanVien(id);
        }

        public async Task<IEnumerable<TNhanVien>> GetPagedNhanViens(int page, int pageSize)
        {
            return await _nhanVienRepository.GetPagedNhanViens(page, pageSize);
        }

        public async Task<IEnumerable<TNhanVien>> SearchNhanViens(string keyword)
        {
            return await _nhanVienRepository.SearchNhanViens(keyword);
        }

        public async Task<IEnumerable<TNhanVien>> GetSortedNhanViens(string sortBy, bool ascending)
        {
            return await _nhanVienRepository.GetSortedNhanViens(sortBy, ascending);
        }

        public async Task<bool> NhanVienExists(string id)
        {
            return await _nhanVienRepository.NhanVienExists(id);
        }

        public async Task Save()
        {
            await _nhanVienRepository.Save();
        }
    }
}
