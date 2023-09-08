using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Repository;
public class IncidenceDetailRepository : GenericRepository<IncidenceDetail>, IIncidenceDetailRepository
{
    private readonly ApiIncidenciasIContext _context;
    public IncidenceDetailRepository(ApiIncidenciasIContext context) : base(context)
    {
        _context = context;
    }
    public override async Task<IEnumerable<IncidenceDetail>> GetAllAsync()
    {
        return await _context.IncidenceDetails
                            .ToListAsync();
    }
}