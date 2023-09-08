using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Repository;
public class RoleRepository : GenericRepository<Role>, IRoleRepository
{
    private readonly ApiIncidenciasIContext _context;
    public RoleRepository(ApiIncidenciasIContext context) : base(context)
    {
        _context = context;
    }
    public override async Task<IEnumerable<Role>> GetAllAsync()
    {
        return await _context.Roles
                            .Include(a => a.Users)
                            .ToListAsync();
    }
}