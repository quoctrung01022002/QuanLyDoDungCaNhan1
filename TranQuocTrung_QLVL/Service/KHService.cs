// KhachHangService.cs
using System.Collections.Generic;
using System.Threading.Tasks;
using TranQuocTrung_QLVL.Models;
using TranQuocTrung_QLVL.Repository;

namespace TranQuocTrung_QLVL.Service
{
    public class KhachHangService : IKhachHangService
    {
        private readonly IKhachHangRepository _khachHangRepository;

        public KhachHangService(IKhachHangRepository khachHangRepository)
        {
            _khachHangRepository = khachHangRepository;
        }

        public async Task<List<TKhachHang>> GetAllKhachHangs()
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

        public async Task<List<TKhachHang>> GetPagedKhachHangs(int page, int pageSize)
        {
            return await _khachHangRepository.GetPagedKhachHangs(page, pageSize);
        }

        public async Task<List<TKhachHang>> SearchKhachHangs(string keyword)
        {
            return await _khachHangRepository.SearchKhachHangs(keyword);
        }

        public async Task<List<TKhachHang>> GetSortedKhachHangs(string sortBy, bool ascending)
        {
            return await _khachHangRepository.GetSortedKhachHangs(sortBy, ascending);
        }
    }
}
