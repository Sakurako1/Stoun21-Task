using HrSearchApp.Data;
using HrSearchApp.Interfaces;
using HrSearchApp.Models;
using Microsoft.EntityFrameworkCore;

namespace HrSearchApp.Repository
{
    public class HrRepository : IHrRepository
    {
        private readonly DataContext _context;
        public HrRepository(DataContext context)
        { 
            _context = context;
        }
        public async Task<Hr> AuthenticateAsync(string login, string password)
        {
            var user = await GetByLoginAsync(login);
            if (user == null || user.Password != password)
            {
                return null;
            }

            return user;
        }

        public async Task<Hr> GetByLoginAsync(string login)
        {
            return await _context.Set<Hr>().FirstOrDefaultAsync(h => h.Login == login);
        }
    }
}
