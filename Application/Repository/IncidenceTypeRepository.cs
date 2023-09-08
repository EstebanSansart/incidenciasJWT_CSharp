using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Repository;
public class IncidenceTypeRepository : GenericRepository<IncidenceType>, IIncidenceTypeRepository
{
    private readonly ApiIncidenciasIContext _context;
    public IncidenceTypeRepository(ApiIncidenciasIContext context) : base(context)
    {
        _context = context;
    }
    public override async Task<IEnumerable<IncidenceType>> GetAllAsync()
    {
        return await _context.IncidenceTypes
                            .Include(a => a.IncidenceDetails)
                            .ToListAsync();
    }
}