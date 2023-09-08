using Domain.Entities;

namespace Application.Contracts;
public interface IJwtGenerator
{
    string CreateToken(User user);
}