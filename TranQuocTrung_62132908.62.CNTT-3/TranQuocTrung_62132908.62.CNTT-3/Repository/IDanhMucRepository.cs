using System.Collections.Generic;
using System.Threading.Tasks;
using TranQuocTrung_62132908._62.CNTT_3.Models;
using TranQuocTrung_62132908._62.CNTT_3.Repository;

namespace TranQuocTrung_62132908._62.CNTT_3.Repositories
{
    public interface IDanhMucRepository : BaseRepository<TDanhMucSp>
    {
        Task<IEnumerable<TDanhMucSp>> GetAllAsync();
        Task<TDanhMucSp> GetByIdAsync(string maSp);
        Task AddAsync(TDanhMucSp danhMucSp);
        Task UpdateAsync(TDanhMucSp danhMucSp);
        Task DeleteAsync(string maSp);
        Task<IEnumerable<TDanhMucSp>> SearchAsync(string keyword);
        Task<IEnumerable<TDanhMucSp>> GetPagedAsync(int page, int pageSize);
        Task<IEnumerable<TDanhMucSp>> GetByManufacturerAsync(string manufacturerCode);
        Task<IEnumerable<TDanhMucSp>> GetByCategoryAsync(string categoryCode);
        Task<IEnumerable<TDanhMucSp>> GetTopSellingAsync(int count);
    }
}