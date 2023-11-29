using System.Collections.Generic;
using System.Threading.Tasks;
using TranQuocTrung_QLVL.Models;
using TranQuocTrung_QLVL.Repository;

namespace TranQuocTrung_QLVL.Service
{
    public class DanhMucService : IDanhMucService
    {
        private readonly IDanhMucRepository _danhMucRepository;

        public DanhMucService(IDanhMucRepository danhMucRepository)
        {
            _danhMucRepository = danhMucRepository;
        }

        public async Task<IEnumerable<TDanhMucSp>> GetDanhMucSPsByCategory(string categoryId)
        {
            return await _danhMucRepository.GetDanhMucSPsByCategory(categoryId);
        }

        public async Task<IEnumerable<TDanhMucSp>> GetDanhMucSPsByBrand(string brandId)
        {
            return await _danhMucRepository.GetDanhMucSPsByBrand(brandId);
        }

        public async Task<IEnumerable<TDanhMucSp>> GetAllBrands()
        {
            return await _danhMucRepository.GetAllBrands();
        }

        public async Task<IEnumerable<TDanhMucSp>> GetAllCategories()
        {
            return await _danhMucRepository.GetAllCategories();
        }

        public async Task<IEnumerable<TDanhMucSp>> GetProductsByPriceRange(decimal minPrice, decimal maxPrice)
        {
            return await _danhMucRepository.GetProductsByPriceRange(minPrice, maxPrice);
        }

        public async Task<IEnumerable<TDanhMucSp>> GetDanhMucSPsByCountry(string countryId)
        {
            return await _danhMucRepository.GetDanhMucSPsByCountry(countryId);
        }

        public async Task<IEnumerable<TDanhMucSp>> GetAllMaterials()
        {
            return await _danhMucRepository.GetAllMaterials();
        }

        public async Task<IEnumerable<TDanhMucSp>> GetDanhMucSPsByMaterial(string materialId)
        {
            return await _danhMucRepository.GetDanhMucSPsByMaterial(materialId);
        }

        public async Task<IEnumerable<TDanhMucSp>> GetDanhMucSPsByCharacteristic(string characteristicId)
        {
            // Implement logic to filter by characteristicId
        }

        public async Task<IEnumerable<TDanhMucSp>> GetDanhMucSPsByWarrantyTime(double warrantyTime)
        {
            return await _danhMucRepository.GetDanhMucSPsByWarrantyTime(warrantyTime);
        }

        public async Task<IEnumerable<TDanhMucSp>> GetDanhMucSPsByWeightRange(double minWeight, double maxWeight)
        {
            return await _danhMucRepository.GetDanhMucSPsByWeightRange(minWeight, maxWeight);
        }

        public async Task<IEnumerable<TDanhMucSp>> GetDanhMucSPsByFeature(string feature)
        {
            // Implement logic to filter by feature
        }

        public async Task<IEnumerable<TDanhMucSp>> GetDanhMucSPsBySpecification(string specification)
        {
            // Implement logic to filter by specification
        }

        public async Task<IEnumerable<TDanhMucSp>> GetDanhMucSPsByPriceAndCategory(decimal minPrice, decimal maxPrice, string categoryId)
        {
            return await _danhMucRepository.GetDanhMucSPsByPriceAndCategory(minPrice, maxPrice, categoryId);
        }

        public async Task<IEnumerable<TDanhMucSp>> GetDanhMucSPsByBrandAndCountry(string brandId, string countryId)
        {
            return await _danhMucRepository.GetDanhMucSPsByBrandAndCountry(brandId, countryId);
        }

        public async Task<IEnumerable<TDanhMucSp>> GetDanhMucSPsByMultipleConditions(Dictionary<string, string> conditions)
        {
            return await _danhMucRepository.GetDanhMucSPsByMultipleConditions(conditions);
        }

        // Implement other methods from IDanhMucService interface
        // ...
    }
}
