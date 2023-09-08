using ApiIncidenciasI.Dtos;
using Domain.Entities;

namespace ApiIncidenciasI.Services;
public interface IUserService
{
    Task<string> RegisterAsync(RegisterDto model);
    Task<UserDataDto> GetTokenAsync(LoginDto model);
    Task<string> AddRoleAsync(AddRoleDto model);
}