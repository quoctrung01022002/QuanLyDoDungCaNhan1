using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TranQuocTrung_62132908._62.CNTT_3.Models;
using TranQuocTrung_62132908._62.CNTT_3.Repository;

namespace TranQuocTrung_62132908._62.CNTT_3.Services
{
    public class AccountService
    {
        private readonly IAccountRepository _accountRepository;

        public AccountService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository ?? throw new ArgumentNullException(nameof(accountRepository));
        }

        public async Task<IEnumerable<TUser>> GetAllUsers()
        {
            return await _accountRepository.GetAllUsers();
        }

        public async Task<TUser> GetUserByUsername(string username)
        {
            return await _accountRepository.GetUserByUsername(username);
        }

        public async Task<IEnumerable<TUser>> GetUsersByRole(string role)
        {
            return await _accountRepository.GetUsersByRole(role);
        }

        public async Task<IEnumerable<TUser>> SearchUsers(string searchTerm)
        {
            return await _accountRepository.SearchUsers(searchTerm);
        }

        public async Task CreateUser(TUser user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            var existingUser = await _accountRepository.GetUserByUsername(user.Username);

            if (existingUser == null)
            {
                // Assign a default role, you can modify this based on your requirements
                user.Role = "User";
                await _accountRepository.CreateUser(user);
            }
            else
            {
                throw new InvalidOperationException("Username is already taken.");
            }
        }

        public async Task UpdateUser(string username, TUser user)
        {
            await _accountRepository.UpdateUser(username, user);
        }

        public async Task DeleteUser(string username)
        {
            await _accountRepository.DeleteUser(username);
        }

        public async Task<bool> UserExists(string username)
        {
            return await _accountRepository.UserExists(username);
        }
    }
}
