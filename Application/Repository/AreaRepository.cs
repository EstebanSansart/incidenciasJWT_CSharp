using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Repository;
public class AreaRepository : GenericRepository<Area>, IAreaRepository
{
    private readonly ApiIncidenciasIContext _context;
    public AreaRepository(ApiIncidenciasIContext context) : base(context)
    {
        _context = context;
    }
    public override async Task<IEnumerable<Area>> GetAllAsync()
    {
        return await _context.Areas
                            .Include(a => a.UserAreas)
                            .Include(a => a.Places)
                            .Include(a => a.Incidences)
                            .ToListAsync();
    }
}