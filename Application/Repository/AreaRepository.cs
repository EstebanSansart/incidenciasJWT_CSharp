using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Repository;
public class AreaRepository : GenericRepository<Area>, IAreaRepository
{
    protected readonly ApiIncidenciasIContext _context;
    public AreaRepository(ApiIncidenciasIContext context) : base(context)
    {
        _context = context;
    }
    public override async Task<(int totalRegistros, IEnumerable<Area> registros)> GetAllAsync(int pageIndex, int pageSize, string search)
    {
        var query = _context.Areas as IQueryable<Area>;

        if (string.IsNullOrEmpty(search))
        {
            query = query.Where(p => p.Name.ToLower().Contains(search));
        }

        var totalRegistros = await query.CountAsync();
        var registros = await query
                                .Include(u => u.UserAreas)
                                .Include(v => v.Places)
                                .Include(w => w.Incidences)
                                .Skip((pageIndex -1) * pageSize)
                                .Take(pageSize)
                                .ToListAsync();

        return(totalRegistros, registros);
    }
}