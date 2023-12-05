using System.Collections.Generic;
using System.Threading.Tasks;
using TranQuocTrung.Models;

namespace TranQuocTrung.Service
{
    public interface IKhachHangService
    {
        Task Add(TKhachHangModel khachHang);
        Task<IEnumerable<TKhachHangModel>> GetAll();
        Task<TKhachHangModel> GetById(string id);
        Task Update(string id, TKhachHangModel khachHang);
        Task Delete(string id);
    }
}
