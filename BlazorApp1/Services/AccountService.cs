using BlazorApp1.Data;
using BlazorApp1.Entities;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp1.Services
{
    public class AccountService : IAccountService
    {
        private readonly MyAppContext _context;

        public AccountService(MyAppContext context)
        {
            _context = context;    
        }

        //Login Simple Authentication
        public async Task<bool> AuthenticateAsync(string username, string password)
        {

            var account = await _context.Accounts.FirstOrDefaultAsync(a => a.Username == username && a.Password == password);
            return account != null;
        }

        public async Task<Account> GetAccountByUsernameAsync(string username)
        {
            return await _context.Accounts.FirstOrDefaultAsync(a => a.Username == username);
        }
    }
}
 