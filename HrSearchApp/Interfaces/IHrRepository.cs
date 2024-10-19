using HrSearchApp.Models;

namespace HrSearchApp.Interfaces
{
    public interface IHrRepository
    {
        Task<Hr> GetByLoginAsync(string login);
        Task<Hr> AuthenticateAsync(string login, string password);

    }
}
