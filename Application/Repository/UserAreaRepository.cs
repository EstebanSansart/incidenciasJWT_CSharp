using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Repository;
public class UserAreaRepository : GenericRepository<UserArea>, IUserAreaRepository
{
    private readonly ApiIncidenciasIContext _context;
    public UserAreaRepository(ApiIncidenciasIContext context) : base(context)
    {
        _context = context;
    }
    public override async Task<IEnumerable<UserArea>> GetAllAsync()
    {
        return await _context.UserAreas
                            .ToListAsync();
    }
}