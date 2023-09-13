using ApiIncidenciasI.Dtos;
using Domain.Entities;

namespace ApiIncidenciasI.Services;
public interface IUserService
{
    Task<string> RegisterAsync(RegisterDto model);
    UserDataDto GetToken(LoginDto model);
    Task<string> AddRoleAsync(AddRoleDto model);
}