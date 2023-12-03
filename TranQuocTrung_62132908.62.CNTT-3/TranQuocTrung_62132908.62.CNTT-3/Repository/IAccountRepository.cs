using System.Collections.Generic;
using System.Threading.Tasks;
using TranQuocTrung_62132908._62.CNTT_3.Models;

namespace TranQuocTrung_62132908._62.CNTT_3.Repository
{
    public interface IAccountRepository : BaseRepository<TUser>
    {
        Task<IEnumerable<TUser>> GetAllUsers();
        Task<TUser> GetUserByUsername(string username);
        Task<IEnumerable<TUser>> GetUsersByRole(string role);
        Task<IEnumerable<TUser>> SearchUsers(string searchTerm);
        Task CreateUser(TUser user);
        Task UpdateUser(string username, TUser user);
        Task DeleteUser(string username);
        Task<bool> UserExists(string username);
        Task Save();
    }
}
