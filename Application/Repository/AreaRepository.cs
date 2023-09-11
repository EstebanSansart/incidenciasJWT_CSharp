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
}