using BlazorApp1.Entities;

namespace BlazorApp1.Services
{
    public interface IAccountService
    {
        Task<bool> AuthenticateAsync(string username, string password);
        Task<Account?> GetAccountByUsernameAsync(string username);
    }
}
