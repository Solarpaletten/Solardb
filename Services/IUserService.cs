using SolarPayAPI.Dtos;
using SolarPayAPI.Models;
using System.Threading.Tasks;

namespace SolarPayAPI.Services
{
    public interface IUserService
    {
        Task<ServiceResponse<int>> RegisterUserAsync(UserRegisterDto request);
        Task<ServiceResponse<string>> LoginUserAsync(UserLoginDto request);
        Task<ServiceResponse<User>> GetUserByIdAsync(int id);
        Task<ServiceResponse<bool>> UpdateUserAsync(int id, UserUpdateDto request);
        Task<ServiceResponse<bool>> DeleteUserAsync(int id);
    }
}
