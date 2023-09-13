using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Repository;
public class AreaRepository : GenericRepository<Area>, IAreaRepository
{
    public readonly ApiIncidenciasIContext _context;
    public AreaRepository(ApiIncidenciasIContext context) : base(context)
    {
        _context = context;
    }
    public override async Task<IEnumerable<Area>> GetAllAsync()
    {
        return await _context.Areas
                            .Include(p => p.Places)
                            .Include(p => p.Incidences)
                            .ToListAsync();
    }
    /*public override async Task<(int totalRegistros, IEnumerable<Area> registros)> GetAllAsync(int pageIndex, int pageSize, string Search)
    {
        var query = _context.Areas as IQueryable<Area>;
        if (!string.IsNullOrEmpty(Search))
        {
            query = query.Where(p => p.Name.ToLower().Contains(Search));
        }
        var totalRegistros = await query.CountAsync();
        var registros = await query
                                 .Include(u => u.Places)
                                 .Include(u => u.Incidences)
                                 .Skip((pageIndex - 1) * pageSize)
                                 .Take(pageSize)
                                 .ToListAsync();
        return (totalRegistros, registros);
    }*/
}