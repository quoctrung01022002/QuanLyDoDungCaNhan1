using System.Collections.Generic;
using System.Threading.Tasks;
using TranQuocTrung_QLVL.Models;

namespace TranQuocTrung_QLVL.Service
{
    public interface IDanhMucService
    {
        Task<IEnumerable<TDanhMucSp>> GetDanhMucSPsByCategory(string categoryId);
        Task<IEnumerable<TDanhMucSp>> GetDanhMucSPsByBrand(string brandId);
        Task<IEnumerable<TDanhMucSp>> GetAllBrands();
        Task<IEnumerable<TDanhMucSp>> GetAllCategories();
        Task<IEnumerable<TDanhMucSp>> GetProductsByPriceRange(decimal minPrice, decimal maxPrice);
        Task<IEnumerable<TDanhMucSp>> GetDanhMucSPsByCountry(string countryId);
        Task<IEnumerable<TDanhMucSp>> GetAllMaterials();

        Task<IEnumerable<TDanhMucSp>> GetDanhMucSPsByMaterial(string materialId);
        Task<IEnumerable<TDanhMucSp>> GetDanhMucSPsByCharacteristic(string characteristicId);
        Task<IEnumerable<TDanhMucSp>> GetDanhMucSPsByWarrantyTime(double warrantyTime);
        Task<IEnumerable<TDanhMucSp>> GetDanhMucSPsByWeightRange(double minWeight, double maxWeight);
        Task<IEnumerable<TDanhMucSp>> GetDanhMucSPsByFeature(string feature);
        Task<IEnumerable<TDanhMucSp>> GetDanhMucSPsBySpecification(string specification);
        Task<IEnumerable<TDanhMucSp>> GetDanhMucSPsByPriceAndCategory(decimal minPrice, decimal maxPrice, string categoryId);
        Task<IEnumerable<TDanhMucSp>> GetDanhMucSPsByBrandAndCountry(string brandId, string countryId);
        Task<IEnumerable<TDanhMucSp>> GetDanhMucSPsByMultipleConditions(Dictionary<string, string> conditions);

        // Add more methods as needed based on your requirements

        // Ensure to implement the remaining methods from IDanhMucService interface
        // ...
    }
}
