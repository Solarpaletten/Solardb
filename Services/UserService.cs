using SolarPayAPI.Data;
using SolarPayAPI.Dtos;
using SolarPayAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace SolarPayAPI.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;

        public UserService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<int>> RegisterUserAsync(UserRegisterDto request)
        {
            var response = new ServiceResponse<int>();
        

            if (await _context.Users.AnyAsync(u => u.Email == request.Email))
            {
                response.Success = false;
                response.Message = "User already exists.";
                return response;
            }

            var user = new User
            {
                Username = request.Username,
                Email = request.Email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password)
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            response.Data = user.Id;
            return response;
        }

        public async Task<ServiceResponse<string>> LoginUserAsync(UserLoginDto request)
        {
            var response = new ServiceResponse<string>();

            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == request.Email);
            if (user == null || !BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash))
            {
                response.Success = false;
                response.Message = "Invalid credentials.";
                return response;
            }

            response.Data = "Generated JWT Token"; 
            return response;
        }

        public async Task<ServiceResponse<User>> GetUserByIdAsync(int id)
        {
            var response = new ServiceResponse<User>();
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                response.Success = false;
                response.Message = "User not found.";
                return response;
            }

            response.Data = user;
            return response;
        }

        public async Task<ServiceResponse<bool>> UpdateUserAsync(int id, UserUpdateDto request)
        {
            var response = new ServiceResponse<bool>();
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                response.Success = false;
                response.Message = "User not found.";
                return response;
            }

            user.Username = request.Username;
            user.Email = request.Email;
            _context.Users.Update(user);
            await _context.SaveChangesAsync();

            response.Data = true;
            return response;
        }

        public async Task<ServiceResponse<bool>> DeleteUserAsync(int id)
        {
            var response = new ServiceResponse<bool>();
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                response.Success = false;
                response.Message = "User not found.";
                return response;
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            response.Data = true;
            return response;
        }
    }
}
