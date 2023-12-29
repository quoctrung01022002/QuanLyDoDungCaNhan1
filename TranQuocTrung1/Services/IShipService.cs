using TranQuocTrung1.Models;

namespace TranQuocTrung1.Services
{
    public interface IShipService
    {
        Task Add(ShipModel ship);
        Task<IEnumerable<ShipModel>> GetAll();
        Task<ShipModel> GetById(int id);
        Task Update(int id, ShipModel ship);
        Task Delete(int id);
        Task<IEnumerable<ShipModel>> SearchShips(string keyword);
    }
}
