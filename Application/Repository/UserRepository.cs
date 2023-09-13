using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Repository;
public class UserRepository : GenericRepository<User>, IUserRepository
{
    private readonly ApiIncidenciasIContext _context;
    public UserRepository(ApiIncidenciasIContext context) : base(context)
    {
        _context = context;
    }
    public override async Task<IEnumerable<User>> GetAllAsync()
    {
        return await _context.Users
                            .Include(a => a.Incidences)
                            .Include(a => a.Contacts)
                            .Include(a => a.UserAreas)
                            .ToListAsync();
    }
    public User GetByUsernameAsync(string UserName)
    {
        return Find(x => x.UserName == UserName).FirstOrDefault();
    }
}