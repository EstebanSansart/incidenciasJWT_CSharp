using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Repository;
public class ContactTypeRepository : GenericRepository<ContactType>, IContactTypeRepository
{
    private readonly ApiIncidenciasIContext _context;
    public ContactTypeRepository(ApiIncidenciasIContext context) : base(context)
    {
        _context = context;
    }
    public override async Task<IEnumerable<ContactType>> GetAllAsync()
    {
        return await _context.ContactTypes
                            .Include(a => a.Contacts)
                            .ToListAsync();
    }
}