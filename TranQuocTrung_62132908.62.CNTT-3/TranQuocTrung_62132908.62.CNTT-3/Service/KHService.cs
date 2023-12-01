using System.Collections.Generic;
using System.Threading.Tasks;
using TranQuocTrung_62132908._62.CNTT_3.Models;
using TranQuocTrung_62132908._62.CNTT_3.Repository;

namespace TranQuocTrung_62132908._62.CNTT_3.Service
{
    public class KhachHangService : IKhachHangRepository
    {
        private readonly IKhachHangRepository _khachHangRepository;

        public KhachHangService(IKhachHangRepository khachHangRepository)
        {
            _khachHangRepository = khachHangRepository;
        }

        public async Task<IEnumerable<TKhachHang>> GetAllKhachHangs()
        {
            return await _khachHangRepository.GetAllKhachHangs();
        }

        public async Task<TKhachHang> GetKhachHangById(string id)
        {
            return await _khachHangRepository.GetKhachHangById(id);
        }

        public async Task CreateKhachHang(TKhachHang khachHang)
        {
            await _khachHangRepository.CreateKhachHang(khachHang);
        }

        public async Task UpdateKhachHang(string id, TKhachHang khachHang)
        {
            await _khachHangRepository.UpdateKhachHang(id, khachHang);
        }

        public async Task DeleteKhachHang(string id)
        {
            await _khachHangRepository.DeleteKhachHang(id);
        }

        public async Task<IEnumerable<TKhachHang>> GetPagedKhachHangs(int page, int pageSize)
        {
            return await _khachHangRepository.GetPagedKhachHangs(page, pageSize);
        }

        public async Task<IEnumerable<TKhachHang>> SearchKhachHangs(string keyword)
        {
            return await _khachHangRepository.SearchKhachHangs(keyword);
        }

        public async Task<IEnumerable<TKhachHang>> GetSortedKhachHangs(string sortBy, bool ascending)
        {
            return await _khachHangRepository.GetSortedKhachHangs(sortBy, ascending);
        }

        public async Task<bool> KhachHangExists(string id)
        {
            return await _khachHangRepository.KhachHangExists(id);
        }

        public async Task Save()
        {
            await _khachHangRepository.Save();
        }
    }
}
