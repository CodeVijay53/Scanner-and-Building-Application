using HKLS_App.Data;
using HKLS_App.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace HKLS_App.Services
{
    public class AuthService
    {
        private readonly ApplicationDbContext _context;

        public AuthService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> LoginAsync(string email, string password)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email && u.Password == password);
            return user != null;
        }

        public async Task<bool> SignupAsync(string email, string password)
        {
            var existingUser = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
            if (existingUser != null)
            {
                return false; // User already exists
            }

            var newUser = new User
            {
                Email = email,
                Password = password
            };

            _context.Users.Add(newUser);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
