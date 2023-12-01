using System.Collections.Generic;
using System.Threading.Tasks;
using TranQuocTrung_62132908._62.CNTT_3.Models;
using TranQuocTrung_62132908._62.CNTT_3.Repositories;

namespace TranQuocTrung_62132908._62.CNTT_3.Services
{
    public class DanhMucService
    {
        private readonly IDanhMucRepository _danhMucRepository;

        public DanhMucService(IDanhMucRepository danhMucRepository)
        {
            _danhMucRepository = danhMucRepository;
        }

        public Task<IEnumerable<TDanhMucSp>> GetAllAsync()
        {
            return _danhMucRepository.GetAllAsync();
        }

        public Task<TDanhMucSp> GetByIdAsync(string maSp)
        {
            return _danhMucRepository.GetByIdAsync(maSp);
        }

        public Task AddAsync(TDanhMucSp danhMucSp)
        {
            return _danhMucRepository.AddAsync(danhMucSp);
        }

        public Task UpdateAsync(TDanhMucSp danhMucSp)
        {
            return _danhMucRepository.UpdateAsync(danhMucSp);
        }

        public Task DeleteAsync(string maSp)
        {
            return _danhMucRepository.DeleteAsync(maSp);
        }

        public Task<IEnumerable<TDanhMucSp>> SearchAsync(string keyword)
        {
            return _danhMucRepository.SearchAsync(keyword);
        }

        public Task<IEnumerable<TDanhMucSp>> GetPagedAsync(int page, int pageSize)
        {
            return _danhMucRepository.GetPagedAsync(page, pageSize);
        }
        public Task<IEnumerable<TDanhMucSp>> GetByManufacturerAsync(string manufacturerCode)
        {
            return _danhMucRepository.GetByManufacturerAsync(manufacturerCode);
        }

        public Task<IEnumerable<TDanhMucSp>> GetByCategoryAsync(string categoryCode)
        {
            return _danhMucRepository.GetByCategoryAsync(categoryCode);
        }

        public Task<IEnumerable<TDanhMucSp>> GetTopSellingAsync(int count)
        {
            return _danhMucRepository.GetTopSellingAsync(count);
        }
    }
}