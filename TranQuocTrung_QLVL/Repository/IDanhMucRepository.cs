using System.Collections.Generic;
using System.Threading.Tasks;
using TranQuocTrung_QLVL.Models;

namespace TranQuocTrung_QLVL.Repository
{
    public interface IDanhMucRepository
    {
        Task<IEnumerable<TDanhMucSp>> GetAllDanhMucSPs();
        Task<TDanhMucSp> GetDanhMucSPById(string id);
        Task CreateDanhMucSP(TDanhMucSp danhMucSP);
        Task UpdateDanhMucSP(string id, TDanhMucSp danhMucSP);
        Task DeleteDanhMucSP(string id);

        // Additional simple functions
        Task<IEnumerable<TDanhMucSp>> GetDanhMucSPsByCategory(string categoryId);
        Task<IEnumerable<TDanhMucSp>> GetDanhMucSPsByBrand(string brandId);
        Task<IEnumerable<TDanhMucSp>> GetAllBrands();
        Task<IEnumerable<TDanhMucSp>> GetAllCategories();
        Task<IEnumerable<TDanhMucSp>> GetProductsByPriceRange(decimal minPrice, decimal maxPrice);
        Task<IEnumerable<TDanhMucSp>> GetDanhMucSPsByCountry(string countryId);
        Task<IEnumerable<TDanhMucSp>> GetAllMaterials();
    }
}
